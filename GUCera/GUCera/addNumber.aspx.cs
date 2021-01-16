using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUCera
{
    public partial class addNumber : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["success"] !=null  && (Boolean)Session["success"] ==true)
            {
                Response.Write("success!");
                Session["success"] = false;
            }

            //Read Database to display numbers

            //Connect to database
            string connStr = ConfigurationManager.ConnectionStrings["GUCera"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);

            //Query current ID
            conn.Open();
            int current = (int)Session["user"];
            string sql = "SELECT mobileNumber from UserMobileNumber where id=@current";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@current", current);
            SqlDataReader reader = cmd.ExecuteReader();
            

            //Display the Data
            Phones.DataSource = reader;
            Phones.DataBind();
            conn.Close();

        }

        protected void add(object sender, EventArgs e)
        {
            //Establishing A Connection
            String conStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(conStr);

            //handle empty input
            if (Number.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Must Input Number')", true);
                return;
            }

            //handle invalid input
            try
            {
                Int32.Parse(Number.Text);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Invalid input')", true);
                return;
            }
          
            //Recive input from user
            int id = (int)Session["user"] ;
            String number = Number.Text;
            
            //Call the procedure and give inputs
            SqlCommand addNumber = new SqlCommand("addMobile", conn);
            addNumber.CommandType = CommandType.StoredProcedure;
            addNumber.Parameters.Add(new SqlParameter("@id", id));
            addNumber.Parameters.Add(new SqlParameter("@mobile_number", number));

            //execute proc
            try
            {
                conn.Open();
                addNumber.ExecuteNonQuery();
                conn.Close();

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Cannot add duplicate phone numbers')", true);
                return;
            }
            Session["success"] = true;
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
    }
}