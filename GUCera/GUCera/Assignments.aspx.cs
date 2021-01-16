using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUCera
{
    public partial class Assignments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Establishing A Connection
            String conStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(conStr);
            
        }
        protected void home(object sender, EventArgs e)
        {
            Response.Redirect((String)Session["home"]);
        }

        protected void logout(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }
        protected void viewAssignment(object sender, EventArgs e)
        {
            //Establishing A Connection
            String conStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(conStr);

            //handling empty input
            if (ID.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Enter course ID')", true);
                return;
            }

            //Check validity of input
            try
            {
                Int16.Parse(ID.Text);
            }
            catch(Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Course ID must be a number')", true);
                return;
            }

            //Execute procedure
            int id = Int16.Parse(ID.Text);
            SqlCommand viewAssign = new SqlCommand("viewAssign", conn);
            viewAssign.CommandType = CommandType.StoredProcedure;
            viewAssign.Parameters.Add(new SqlParameter("@sid", (int)Session["user"]));
            viewAssign.Parameters.Add(new SqlParameter("@courseId", id));

            
            
            try
            {
                conn.Open();
                viewAssign.ExecuteNonQuery();
                SqlDataReader reader = viewAssign.ExecuteReader();

                //Display the Data
                GridView1.DataSource = reader;
                GridView1.DataBind();
                conn.Close();

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No Assignments Available')", true);
                return;
            }
            //Display Course Name
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT name FROM Course where id = @id";
            cmd.Parameters.AddWithValue("@id", id);
            String cName = (String)cmd.ExecuteScalar();
            Response.Write("Course: " + cName);
            conn.Close();

            //Reset Page
            GradeLabel.Text = "  ";

        }
        protected void submitAssignment(object sender, EventArgs e)
        {
            //Establishing A Connection
            String conStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(conStr);

            //handling empty input
            if (aType.Text == "" || aNumber.Text == "" || aCID.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Enter full assignment details')", true);
                return;
            }

            //Check validity of input(s)
            try
            {
                Int16.Parse(aCID.Text);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Course ID must be a number')", true);
                return;
            }
            try
            {
                Int16.Parse(aNumber.Text);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Assignment Number must be a number')", true);
                return;
            }

            if (aType.Text.ToLower() != "quiz" && aType.Text.ToLower() != "exam" && aType.Text.ToLower() != "project")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Assignment type must be Quiz/Exam/Project')", true);
                return;
            }

            //Execute procedure
            int id = Int16.Parse(aCID.Text);
            String type = aType.Text;
            int number = Int16.Parse(aNumber.Text);
            SqlCommand submitAssign = new SqlCommand("submitAssign", conn);
            submitAssign.CommandType = CommandType.StoredProcedure;
            submitAssign.Parameters.Add(new SqlParameter("@sid", (int)Session["user"]));
            submitAssign.Parameters.Add(new SqlParameter("@cid", id));
            submitAssign.Parameters.Add(new SqlParameter("@assignType", type));
            submitAssign.Parameters.Add(new SqlParameter("@assignnumber", number));

            try
            {
                conn.Open();
                submitAssign.ExecuteNonQuery();
                conn.Close();

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Invalid Assignment Details')", true);
                return;
            }

            Response.Write("Assignment Submitted!");

            //Reset Page
            GradeLabel.Text = "  ";
            GridView1.DataSource = null;
            GridView1.DataBind();
        }
        protected void viewGrade(object sender, EventArgs e)
        {
            //Establishing A Connection
            String conStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(conStr);

            //handling empty input
            if (vType.Text == "" || vNumber.Text == "" || vCID.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Enter full assignment details')", true);
                return;
            }

            //Check validity of input(s)
            try
            {
                Int16.Parse(vCID.Text);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Course ID must be a number')", true);
                return;
            }
            try
            {
                Int16.Parse(vNumber.Text);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Assignment Number must be a number')", true);
                return;
            }

            if (vType.Text.ToLower() != "quiz" && vType.Text.ToLower() != "exam" && vType.Text.ToLower() != "project")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Assignment type must be Quiz/Exam/Project')", true);
                return;
            }

            //Execute procedure
            int cid = Int16.Parse(vCID.Text);
            String type = vType.Text;
            int number = Int16.Parse(vNumber.Text);
            SqlCommand viewGrade = new SqlCommand("viewAssignGrades", conn);
            viewGrade.CommandType = CommandType.StoredProcedure;
            viewGrade.Parameters.Add(new SqlParameter("@sid", (int)Session["user"]));
            viewGrade.Parameters.Add(new SqlParameter("@cid", cid));
            viewGrade.Parameters.Add(new SqlParameter("@assignType", type));
            viewGrade.Parameters.Add(new SqlParameter("@assignnumber", number));

            //Output
            SqlParameter grade = viewGrade.Parameters.Add("@assignGrade", SqlDbType.Int);
            grade.Direction = ParameterDirection.Output;

            try
            {
                conn.Open();
                viewGrade.ExecuteNonQuery();
                conn.Close();

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Invalid Assignment Details')", true);
                return;
            }
            //Display Grade
           
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT fullGrade FROM Assignment where cid = @cid and type = @type and number = @number" ;
            cmd.Parameters.AddWithValue("@cid", cid);
            cmd.Parameters.AddWithValue("@type", type);
            cmd.Parameters.AddWithValue("@number", number);
            if(grade.Value.ToString() == "" && cmd.ExecuteScalar() == null)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Invalid Assignment Details')", true);
                return;
            }
            else
            {
                GradeLabel.Text = "Your grade: " + grade.Value.ToString() + "/" + cmd.ExecuteScalar();
            }
            conn.Close();

            //Reset Page
          
            GridView1.DataSource = null;
            GridView1.DataBind();
        }
    }
}