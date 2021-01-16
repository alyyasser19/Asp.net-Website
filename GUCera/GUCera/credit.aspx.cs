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
    public partial class credit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["success"] != null && (Boolean)Session["success"] == true)
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
            string sql = "SELECT creditCardNumber from StudentAddCreditCard where sid=@current";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@current", current);
            SqlDataReader reader = cmd.ExecuteReader();


            //Display the Data
            GridView1.DataSource = reader;
            GridView1.DataBind();
            conn.Close();

        }

        protected void add(object sender, EventArgs e)
        {
           

            //Establishing A Connection
            String conStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(conStr);

            //handle empty input
            if (Number.Text == "" || Name.Text=="" || expiryDate.Text=="" || CVV.Text=="")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Must Input All Data')", true);
                return;
            }
            //CVV must be 3 digits
            if (CVV.Text.Length != 3)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('CVV has to be 3 digits')", true);
                return;
            }
            //handle invalid input
            try
            {
                Int32.Parse(Number.Text);
                Int32.Parse(CVV.Text);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Invalid input')", true);
                return;
            }

            //Recive input from user
            int id = (int)Session["user"];
            String number = Number.Text;
            String name = Name.Text;
            String Cvv = CVV.Text;
            String expiry = expiryDate.Text;

            //Call the procedure and give inputs
            SqlCommand addNumber = new SqlCommand("addCreditCard", conn);
            addNumber.CommandType = CommandType.StoredProcedure;
            addNumber.Parameters.Add(new SqlParameter("@sid", id));
            addNumber.Parameters.Add(new SqlParameter("@number", number));
            addNumber.Parameters.Add(new SqlParameter("@cardHolderName", name));
            addNumber.Parameters.Add(new SqlParameter("@expiryDate", expiry));
            addNumber.Parameters.Add(new SqlParameter("@cvv", Cvv));

            //execute proc
            conn.Open();
            try
            {
                addNumber.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Invalid input')", true);
                return;
            }
            conn.Close();
            Session["success"] = true;
            Response.Redirect("Credit.aspx");
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