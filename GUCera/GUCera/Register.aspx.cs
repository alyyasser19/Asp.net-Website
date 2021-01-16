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
    public partial class Register2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void register(object sender, EventArgs e)
        {
            //Establishing A Connection
            String conStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(conStr);

            //Check if none or both boxes are checked
            if (studentBox.Checked == true && instructorBox.Checked == true)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please check only one box')", true);
                return;
            }
            else if (studentBox.Checked == false && instructorBox.Checked == false)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please check one box')", true);
                return;
            }
            //If only one box is checked
            else
            {
                //handle empty details
                if (firstName.Text == "" || lastName.Text == "" || password.Text == "" || email.Text == "" || address.Text == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please enter full details')", true);
                    return;
                }
                

                String fName = firstName.Text;
                String lName = lastName.Text;
                String pass = password.Text;
                String mail = email.Text;
                int Gender = Int16.Parse(gender.SelectedValue);
                String location = address.Text;

  

                //Call and execute a procedure based on the checked box
                if (studentBox.Checked == true)
                {
                    SqlCommand registerProc = new SqlCommand("studentRegister", conn);
                    registerProc.CommandType = CommandType.StoredProcedure;
                    registerProc.Parameters.Add(new SqlParameter("@first_name", fName));
                    registerProc.Parameters.Add(new SqlParameter("@last_name", lName));
                    registerProc.Parameters.Add(new SqlParameter("@password", pass));
                    registerProc.Parameters.Add(new SqlParameter("@email", mail));
                    registerProc.Parameters.Add(new SqlParameter("@gender", Gender));
                    registerProc.Parameters.Add(new SqlParameter("@address", location));

                    //execute proc
                    try
                    {
                        conn.Open();
                        registerProc.ExecuteNonQuery();
                        conn.Close();

                    }
                    catch (Exception ex)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Invalid Credentials')", true);
                        return;
                    }
                }
                else if (instructorBox.Checked == true)
                {
                    SqlCommand registerProc = new SqlCommand("InstructorRegister", conn);
                    registerProc.CommandType = CommandType.StoredProcedure;
                    registerProc.Parameters.Add(new SqlParameter("@first_name", fName));
                    registerProc.Parameters.Add(new SqlParameter("@last_name", lName));
                    registerProc.Parameters.Add(new SqlParameter("@password", pass));
                    registerProc.Parameters.Add(new SqlParameter("@email", mail));
                    registerProc.Parameters.Add(new SqlParameter("@gender", Gender));
                    registerProc.Parameters.Add(new SqlParameter("@address", location));

                    //execute proc
                    try
                    {
                        conn.Open();
                        registerProc.ExecuteNonQuery();
                        conn.Close();

                    }
                    catch (Exception ex)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Invalid Credentials')", true);
                        return;
                    }
                }

                //Go back to login page & give ID

                String connection = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
                SqlConnection newConn = new SqlConnection(connection);
                
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = newConn;
                cmd.CommandType = CommandType.Text;
                newConn.Open();
                cmd.CommandText = "SELECT Max(id) FROM Users";
                Session["latestUser"] = cmd.ExecuteScalar();
                newConn.Close();
                Session["newUser"] = true;
                Response.Redirect("Login.aspx");


            }
        }
    }
}