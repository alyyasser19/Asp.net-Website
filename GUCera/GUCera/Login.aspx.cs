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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["newUser"]==null)
            {
                Session["newUser"] = false;
            }
            if((Boolean)Session["newUser"])
            {
                Response.Write("Your New ID is: " + Session["latestUser"]);
                Session["newUser"] = false;
            }
        }

        protected void login(object sender, EventArgs e)
        {
            //Establishing A Connection
            String conStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(conStr);

            //handle empty username/ password
            if (Username.Text == "" || Password.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Must Input ID and Password.')", true);
                return;
            }

            //Recive input from user and check if ID is int
            try
            {
                Int16.Parse(Username.Text);
            }
            catch(Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ID must be a number.')", true);
                return;
            }
            int id = Int16.Parse(Username.Text);
            String password = Password.Text;

            //Call the procedure and give inputs
            SqlCommand loginProc = new SqlCommand("userLogin",conn);
            loginProc.CommandType = CommandType.StoredProcedure;
            loginProc.Parameters.Add(new SqlParameter("@id", id));
            loginProc.Parameters.Add(new SqlParameter("@password", password));

            //Output
            SqlParameter success = loginProc.Parameters.Add("@success", SqlDbType.Int);
            SqlParameter type = loginProc.Parameters.Add("@type", SqlDbType.Int);
            success.Direction = ParameterDirection.Output;
            type.Direction = ParameterDirection.Output;

            //execute proc
            try
            {
                conn.Open();
                loginProc.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('An Error Occured')", true);
                return;
            }
           
            

            //check if User Exists and Redirect to Type
            if (success.Value.ToString() == "1")
            {
                //Detrmine Type
                Response.Write("Success");
                if (type.Value.ToString() == "0")
                {
                    Session["user"] = id;
                    Session["home"] = "Instructor.aspx";
                    Response.Redirect("Instructor.aspx");
                }
                if (type.Value.ToString() == "1")
                {
                    Session["user"] = id;
                    Session["home"] = "Admin.aspx";
                    Response.Redirect("Admin.aspx");
                }
                if (type.Value.ToString() == "2")
                {
                    Session["user"] = id;
                    Session["home"] = "Student.aspx";
                    Response.Redirect("Student.aspx");
                }
            }
            else
            {
                //Display an error
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Invalid ID / Password : if you do not have an account please create one.')", true);
            }

        }
        protected void goRegister(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }
    }
}