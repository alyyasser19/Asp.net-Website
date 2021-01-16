using System;
using System.Collections;
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
    public partial class Admin : System.Web.UI.Page
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

            //For the Accept Course Method
            Label1.Visible = false;
            TextBox1.Visible = false;
            Button9.Visible = false;

            //For the Create Promocode Method
            Label2.Visible = false;
            Label3.Visible = false;
            Label4.Visible = false;
            Label5.Visible = false;
            Label6.Visible = false;
            Label7.Visible = false;

            TextBox2.Visible = false;
            TextBox3.Visible = false;
            TextBox4.Visible = false;
            TextBox5.Visible = false;
            TextBox6.Visible = false;

            Button10.Visible = false;

            Button10.Text = "Create";
            Label2.Text = "Please Insert the Following Data";
            Label3.Text = "Promo Code";
            Label4.Text = "IssueDate";
            Label5.Text = "ExpiryDate";
            Label6.Text = "Discount";
            Label7.Text = "Admin ID";   

            //For the Issue PromoCode Method
            Button11.Visible = false;
            Button11.Text = "Issue";


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

        protected void BulletedList1_Click(object sender, BulletedListEventArgs e)
        {

        }

        protected void ListAllCourses(object sender, EventArgs e)
        {

            //Establishing A Connection
            String conStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(conStr);

            //Call the procedure and give inputs
            conn.Open();
            SqlCommand viewAllCourses = new SqlCommand("AdminViewAllCourses", conn);
            viewAllCourses.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = viewAllCourses.ExecuteReader();

            //Display the Data
            GridView1.DataSource = reader;
            GridView1.DataBind();
            conn.Close();

        }

       protected void ListNonAcceptedCourses(object sender, EventArgs e)
        {

            //Establishing A Connection
            String conStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(conStr);

            //Call the procedure and give inputs
            conn.Open();
            SqlCommand ViewNonAcceptedCourses = new SqlCommand("AdminViewNonAcceptedCourses", conn);
            ViewNonAcceptedCourses.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = ViewNonAcceptedCourses.ExecuteReader();

            //Display the Data
            GridView1.DataSource = reader;
            GridView1.DataBind();
            conn.Close();

        }

        protected void AcceptAddedCourses(object sender, EventArgs e)
        {

            //Establishing A Connection
            String conStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(conStr);

            //Call the procedure and give inputs
            
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;

            conn.Open();

            //Display the Data
            cmd.CommandText = "Select id, name, creditHours, price, content From Course Where accepted = 0 or accepted is null";
            SqlDataReader reader = cmd.ExecuteReader();
            GridView1.DataSource = reader;
            GridView1.DataBind();

            Label1.Visible = true;
            TextBox1.Visible = true;
            Button9.Visible = true;

            Label1.Text = "Please Insert the ID of The Course";
            TextBox1.Text = "";
            Button9.Text = "Accept";

            //On selecting the id
            Button9.OnClientClick += new EventHandler(Accept_Click);

            conn.Close();

        }

        protected void Accept_Click(object sender, EventArgs e)
        {
            //Establishing A Connection
            String conStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(conStr);

            //Check if input is empty
            if(TextBox1.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Must Enter a course ID')", true);
                Label1.Visible = true;
                TextBox1.Visible = true;
                TextBox1.Text = "";
                Button9.Visible = true;
                return;
            }
            
            //Handle non-number input
            try
            {
                Int16.Parse(TextBox1.Text);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Course ID must be a number')", true);
                Label1.Visible = true;
                TextBox1.Visible = true;
                TextBox1.Text = "";
                Button9.Visible = true;
                return;
            }

               
            //Check if course exists
            conn.Open();
            SqlCommand check = new SqlCommand();
            check.Connection = conn;
            check.CommandType = CommandType.Text;
            check.CommandText = "SELECT name FROM Course where id = @courseID" ;
            check.Parameters.AddWithValue("@courseID", Int16.Parse(TextBox1.Text));
            if (check.ExecuteScalar() == null )
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Course does not exist')", true);
                Label1.Visible = true;
                TextBox1.Visible = true;
                TextBox1.Text = "";
                Button9.Visible = true;
                return;
            }
            conn.Close();

            //Check if course accepted
            conn.Open();
            SqlCommand check2 = new SqlCommand();
            check2.Connection = conn;
            check2.CommandType = CommandType.Text;
            check2.CommandText = "SELECT accepted FROM Course where id = @courseID";
            check2.Parameters.AddWithValue("@courseID", Int16.Parse(TextBox1.Text));
            if ((bool)check2.ExecuteScalar() == true)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Course was already accepted')", true);
                Label1.Visible = true;
                TextBox1.Visible = true;
                TextBox1.Text = "";
                Button9.Visible = true;
                return;
            }
            conn.Close();

            //Call the procedure and give inputs
            conn.Open();
            SqlCommand cmd = new SqlCommand("AdminAcceptRejectCourse", conn);
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@adminid", Session["user"]));
            cmd.Parameters.Add(new SqlParameter("@courseId", Int16.Parse(TextBox1.Text)));
            Response.Write("<br/ >Course was accepted successfully!");
            SqlDataReader reader = cmd.ExecuteReader();
                
            //Display the Data
            GridView1.DataSource = reader;
            GridView1.DataBind();
            conn.Close();  
        }
        protected void CreateAPromoCode(object sender, EventArgs e)
        {
            //Establishing A Connection
            String conStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(conStr);

            //Call the procedure and give inputs

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;

            conn.Open();

            //Display the Data
            Label2.Visible = true;
            Label3.Visible = true;
            Label4.Visible = true;
            Label5.Visible = true;
            Label6.Visible = true;
            Label7.Visible = true;

            TextBox2.Visible = true;
            TextBox3.Visible = true;
            TextBox4.Visible = true;
            TextBox5.Visible = true;
            TextBox6.Visible = true;

            Button10.Visible = true;

            TextBox5.MaxLength = 5;
            TextBox2.MaxLength = 6;
            TextBox3.MaxLength = 0;

            TextBox2.Text = "";
            TextBox3.Text = "";

            GridView1.DataSource = null;
            GridView1.DataBind();


            //On selecting the Create button
            Button9.OnClientClick += new EventHandler(Create_Click);

            cmd.CommandText = "Select * From Promocode";
            SqlDataReader reader = cmd.ExecuteReader();
            GridView1.DataSource = reader;
            GridView1.DataBind();
            conn.Close();

        }
        protected void Create_Click(object sender, EventArgs e)
        {
            try
            {
                //Establishing A Connection
                String conStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
                SqlConnection conn = new SqlConnection(conStr);

                //Call the procedure and give inputs
                conn.Open();

                SqlCommand cmd = new SqlCommand("AdminCreatePromocode", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@code", TextBox2.Text));
                cmd.Parameters.Add(new SqlParameter("@isuueDate", TextBox3.Text));
                cmd.Parameters.Add(new SqlParameter("@expiryDate", TextBox4.Text));
                cmd.Parameters.Add(new SqlParameter("@discount", TextBox5.Text));
                cmd.Parameters.Add(new SqlParameter("@adminid", Session["user"]));
               
                SqlDataReader reader = cmd.ExecuteReader();

                //Display the Data
                GridView1.DataSource = reader;
                GridView1.DataBind();

                TextBox2.Text = "";
                TextBox3.Text = "";
                TextBox4.Text = "";
                TextBox5.Text = "";
                TextBox6.Text = "";

                conn.Close();

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Make Sure the Following Holds:\\nThe code is not empty,\\nDates should be in a format of dd/mm/yy,\\nDiscounts should be in nn.nn format, where n is a number\\nAnd the admin ID is yours')", true);

                Label2.Visible = true;
                Label3.Visible = true;
                Label4.Visible = true;
                Label5.Visible = true;
                Label6.Visible = true;
                Label7.Visible = true;

                TextBox2.Visible = true;
                TextBox3.Visible = true;
                TextBox4.Visible = true;
                TextBox5.Visible = true;
                TextBox6.Visible = true;

                Button10.Visible = true;

                return;
            }

        }


        protected void IssueAPromoCode(object sender, EventArgs e)
        {

            String conStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(conStr);

            //Call the procedure and give inputs

            GridView1.DataSource = null;
            GridView1.DataBind();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;

            conn.Open();  

            cmd.CommandText = "Select * From Promocode";
            SqlDataReader reader = cmd.ExecuteReader();
            GridView1.DataSource = reader;
            GridView1.DataBind();

            Label2.Visible = true;
            Label3.Visible = true;
            Label4.Visible = true;

            TextBox2.Visible = true;
            TextBox3.Visible = true;


            Button11.Visible = true;

            Label3.Text = "Student ID";
            Label4.Text = "Promocode";
            TextBox2.MaxLength = 0;
            TextBox3.MaxLength = 5;

            TextBox2.Text= "";
            TextBox3.Text = "";

            Button11.OnClientClick += new EventHandler(Create_Click);
            conn.Close();

        }

        protected void Issue_Click(object sender, EventArgs e)
        {

            try
            {

                //Establishing A Connection
                String conStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
                SqlConnection conn = new SqlConnection(conStr);

                //Call the procedure and give inputs
                conn.Open();

                SqlCommand cmd = new SqlCommand("AdminIssuePromocodeToStudent", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@sid", TextBox2.Text));
                cmd.Parameters.Add(new SqlParameter("@pid", TextBox3.Text));

                SqlDataReader reader = cmd.ExecuteReader();

                //Display the Data
                GridView1.DataSource = reader;
                GridView1.DataBind();

                TextBox2.Text = "";
                TextBox3.Text = "";

                conn.Close();

            }
            catch(Exception ex)
            {

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Make Sure the Following Holds:\\nThe Student ID,\\nAnd The PromoCode')", true);

                Label2.Visible = true;
                Label3.Visible = true;
                Label4.Visible = true;

                TextBox2.Visible = true;
                TextBox3.Visible = true;

                Button11.Visible = true;

                return;

            }

        }
    }
}