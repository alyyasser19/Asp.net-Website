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
    public partial class Student : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Display a greeting message
            String connection = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection newConn = new SqlConnection(connection);

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = newConn;
            cmd.CommandType = CommandType.Text;
            int current = (int)Session["user"];
            newConn.Open();

            cmd.CommandText = "SELECT firstName FROM Users where id = @current";
            cmd.Parameters.AddWithValue("@current", current);
            Session["first_name"] = cmd.ExecuteScalar();
            Response.Write("Hello, " + Session["first_name"]);
            newConn.Close();


        }
        protected void addNumber(object sender, EventArgs e)
        {
            Response.Redirect("addNumber.aspx");
        }

        protected void home(object sender, EventArgs e)
        {
            Response.Redirect((String)Session["home"]);
        }

        protected void logout(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }

        //Student 1
        protected void ViewProfile(object sender, EventArgs e)
        {

            //Establishing A Connection
            String conStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(conStr);

            //Call the procedure and give inputs
            conn.Open();
            SqlCommand view = new SqlCommand("viewMyProfile", conn);
            view.CommandType = CommandType.StoredProcedure;
            view.Parameters.Add(new SqlParameter("@id", Session["user"]));
            SqlDataReader reader = view.ExecuteReader();



            //Display the Data
            GridView1.DataSource = reader;
            GridView1.DataBind();
            conn.Close();
        }
        protected void ViewAvailableCourses(object sender, EventArgs e)
        {

            //Establishing A Connection
            String conStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(conStr);

            //Call the procedure and give inputs
            conn.Open();
            SqlCommand view = new SqlCommand("availableCourses", conn);
            view.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = view.ExecuteReader();



            //Display the Data
            GridView1.DataSource = reader;
            GridView1.DataBind();
            conn.Close();
            if (GridView1.Rows.Count == 0)
            {
                Response.Write("<br />No Courses Available");
            }
        }
        protected void Enroll(object sender, EventArgs e)
        {
            Response.Redirect("Enroll.aspx");
        }
        protected void credit(object sender, EventArgs e)
        {
            Response.Redirect("credit.aspx");
        }
        protected void ViewPromo(object sender, EventArgs e)
        {

            //Establishing A Connection
            String conStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(conStr);

            //Call the procedure and give inputs
            conn.Open();
            SqlCommand view = new SqlCommand("viewPromocode", conn);
            view.CommandType = CommandType.StoredProcedure;
            view.Parameters.Add(new SqlParameter("@sid", Session["user"]));
            SqlDataReader reader = view.ExecuteReader();



            //Display the Data
            GridView1.DataSource = reader;
            GridView1.DataBind();
            conn.Close();
            if (GridView1.Rows.Count == 0)
            {
                Response.Write("<br />No Promocode Available");
            }
        }

        //STUDENT 2

        protected void assignments(object sender, EventArgs e)
        {
            Response.Redirect("Assignments.aspx");
        }
        protected void certificate(object sender, EventArgs e)
        {
            //Establishing A Connection
            String conStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(conStr);

            //handling empty input
            if (certificateCID.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Enter course ID')", true);
                return;
            }

            //Check validity of input
            try
            {
                Int16.Parse(certificateCID.Text);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Course ID must be a number')", true);
                return;
            }

            //Execute Procedure

            SqlCommand viewCertficate = new SqlCommand("viewCertificate", conn);
            int cid = Int16.Parse(certificateCID.Text);
            viewCertficate.CommandType = CommandType.StoredProcedure;
            viewCertficate.Parameters.Add(new SqlParameter("@sid", Session["user"]));
            viewCertficate.Parameters.Add(new SqlParameter("@cid", cid));

            try
            {
                conn.Open();
                viewCertficate.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('an error occured')", true);
                return;
            }

            //Display the Data
            conn.Open();
            SqlDataReader read = viewCertficate.ExecuteReader();
            GridView1.DataSource = read;
            GridView1.DataBind();
            conn.Close();
            if (GridView1.Rows.Count == 0)
            {
                Response.Write("<br />You either do not take this course or have not finished it");
            }
        }
        protected void feedback(object sender, EventArgs e)
        {
            //Establishing A Connection
            String conStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(conStr);

            //handling empty input
            if (fbCID.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Enter course ID')", true);
                return;
            }

            //Check validity of input
            try
            {
                Int16.Parse(fbCID.Text);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Course ID must be a number')", true);
                return;
            }

            //Execute Procedure

            SqlCommand addFeedback = new SqlCommand("addFeedback", conn);
            int cid = Int16.Parse(fbCID.Text);
            String cmnt = comment.Text;
            addFeedback.CommandType = CommandType.StoredProcedure;
            addFeedback.Parameters.Add(new SqlParameter("@sid", Session["user"]));
            addFeedback.Parameters.Add(new SqlParameter("@cid", cid));
            addFeedback.Parameters.Add(new SqlParameter("@comment", cmnt));
            
            //Check count of feedbacks prior to execution
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            conn.Open();

            cmd.CommandText = "SELECT count(*) FROM Feedback";
            Int16 oldCount = Int16.Parse(cmd.ExecuteScalar().ToString());
            conn.Close();

            try
            {
                conn.Open();
                addFeedback.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('There was an error submitting your feedback')", true);
                return;
            }
            //Check count of feedbacks post execution
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = conn;
            cmd2.CommandType = CommandType.Text;
            conn.Open();

            cmd2.CommandText = "SELECT count(*) FROM Feedback";
            Int16 newCount = Int16.Parse(cmd2.ExecuteScalar().ToString());
            conn.Close();

            if(oldCount == newCount)
            {
                Response.Write("<br /> You do not take this course to submit a feedback");
            }
            else
            {
                Response.Write("<br /> Feedback Submitted successfully");
            }

        }

    }
}