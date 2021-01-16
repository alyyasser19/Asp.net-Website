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
    public partial class Enroll : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
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
        }
        protected void home(object sender, EventArgs e)
        {
            Response.Redirect((String)Session["home"]);
        }

        protected void logout(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }
        protected void enroll(object sender, EventArgs e)
        {
            //Establishing A Connection
            String conStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(conStr);

            //handle empty username/ password
            if (ID.Text == "" || Instructor.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Must Input Course ID and Instructor ID.')", true);
                return;
            }

            //Recive input from user and check if ID is int
            try
            {
                Int16.Parse(ID.Text);
                Int16.Parse(Instructor.Text);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('IDs must be a number.')", true);
                return;
            }
            int id = Int16.Parse(ID.Text);
            int instructor = Int16.Parse(Instructor.Text);

            //Call the procedure and give inputs
            SqlCommand enroll = new SqlCommand("enrollInCourse", conn);
            enroll.CommandType = CommandType.StoredProcedure;
            enroll.Parameters.Add(new SqlParameter("@cid", id));
            enroll.Parameters.Add(new SqlParameter("@instr", instructor));
            enroll.Parameters.Add(new SqlParameter("@sid", (int)Session["user"]));

            //execute proc
            conn.Open();
            try
            {
                enroll.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Course Not Available')", true);
                return;
            }
            conn.Close();
            Response.Write("Success!");
        }
    }
}