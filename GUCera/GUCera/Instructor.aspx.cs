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
    public partial class Instructor : System.Web.UI.Page
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

        protected void addCourse(object sender, EventArgs e)
        {

            //Call the procedure and give inputs
            String conStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(conStr);


            //handle empty input
            if (courseCreditHours.Text == "" || coursename.Text == "" || courseprice.Text == "" )
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Missing Data')", true);
                return;
            }
            //Check validity of input
            try
            {
                float.Parse(courseprice.Text);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Price must be a number')", true);
                return;
            }
            //Check validity of input
            try
            {
                Int16.Parse(courseCreditHours.Text);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Course credit hours must be a number')", true);
                return;
            }

            //Call the procedure and give inputs
            int insid = (int)Session["user"];
            String name = coursename.Text;
            float price = float.Parse(courseprice.Text);
            int hours = Int16.Parse(courseCreditHours.Text);
            String description = coursedescription.Text;
            String content = coursecontent.Text;

            SqlCommand cmd = new SqlCommand("InstAddCourse", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@instructorId", insid));
                cmd.Parameters.Add(new SqlParameter("@name", name));
                cmd.Parameters.Add(new SqlParameter("@price", price));
                cmd.Parameters.Add(new SqlParameter("@creditHours", hours));
                cmd.Parameters.Add(new SqlParameter("@description",description));
                cmd.Parameters.Add(new SqlParameter("@content",content));
                cmd.Parameters.Add(new SqlParameter("@cid", (int)1));

            //Check count of courses prior to execution
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = conn;
            cmd2.CommandType = CommandType.Text;
            conn.Open();

            cmd2.CommandText = "SELECT count(*) FROM Course";
            Int16 oldCount = Int16.Parse(cmd2.ExecuteScalar().ToString());
            conn.Close();

            //execute proc           
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

           

            //Check count of courses post execution
            SqlCommand cmd3 = new SqlCommand();
            cmd3.Connection = conn;
            cmd3.CommandType = CommandType.Text;
            conn.Open();

            cmd3.CommandText = "SELECT count(*) FROM Course";
            Int16 newCount = Int16.Parse(cmd3.ExecuteScalar().ToString());
            conn.Close();

            if (oldCount == newCount)
            {
                Response.Write("<br /> Course cannot be added (Make sure a duplicate course doesn't exist)");
            }
            else
            {
                Response.Write("<br /> Course Added Successfully");
            }

        }
        protected void addPrereq(object sender, EventArgs e)
        {
            //Establishing connection
            String conStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(conStr);

            //Handling empty input
            if (courseID.Text == "" || prerequisite.Text == "") {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Missing Data')", true);
                return;
            }
            //Handling invalid data
            try
            {
                Int16.Parse(courseID.Text);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Course ID must be a number')", true);
                return;
            }
            //Check validity of input
            try
            {
                Int16.Parse(prerequisite.Text);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Prerequisite ID must be a number')", true);
                return;
            }

            int course = Int16.Parse(courseID.Text);
            int prereq = Int16.Parse(prerequisite.Text);
            SqlCommand cmd = new SqlCommand("DefineCoursePrerequisites", conn);
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@prerequsiteId", prereq));
            cmd.Parameters.Add(new SqlParameter("@cid", course));

            //Check count of prerequisites prior to execution
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = conn;
            cmd2.CommandType = CommandType.Text;
            conn.Open();
            cmd2.CommandText = "SELECT count(*) FROM CoursePrerequisiteCourse";
            Int16 oldCount = Int16.Parse(cmd2.ExecuteScalar().ToString());
            conn.Close();

            //Execute procedure

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert(' Error')", true);
                return;
            }

            //Check count of prerequisites post execution
            SqlCommand cmd3 = new SqlCommand();
            cmd3.Connection = conn;
            cmd3.CommandType = CommandType.Text;
            conn.Open();

            cmd3.CommandText = "SELECT count(*) FROM CoursePrerequisiteCourse";
            Int16 newCount = Int16.Parse(cmd3.ExecuteScalar().ToString());
            conn.Close();

            if (oldCount == newCount)
            {
                Response.Write("<br /> Prerequiste cannot be added (Make sure it's not a duplicate and that both courses exist)");
            }
            else
            {
                Response.Write("<br /> Prerequisite Added Successfully");
            }
        }
        protected void addAssignment(object sender, EventArgs e)
        {
            //Establishing connection
            String conStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(conStr);

            //Handling empty input
            if (addassigncid.Text == "" || addassignsnumber.Text == "" || addassignweight.Text == "" || addassignfullgrade.Text== "" || addassigndeadline.Text == "" || addassingtype.Text == "" || addassigncontent.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Missing Data')", true);
                return;
            }

            if (addassingtype.Text.ToLower() != "quiz" && addassingtype.Text.ToLower() != "exam" && addassingtype.Text.ToLower() != "project")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Assignment type must be Quiz/Exam/Project')", true);
                return;
            }
                //Check validity of input
            try
                {
                Int16.Parse(addassigncid.Text);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('CID must be a number')", true);
                return;
            }
            //Check validity of input
            try
            {
                Int16.Parse(addassignsnumber.Text);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('assignment number must be a number')", true);
                return;
            }
            
            try
            {
                Int16.Parse(addassignfullgrade.Text);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Full Grade must be a number')", true);
                return;
            } 
            try
            {
                DateTime.Parse(addassigndeadline.Text);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Deadline must be a Datetime')", true);
                return;
            }
            try
            {
                Decimal.Parse(addassignweight.Text);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('weight must be a number')", true);
                return;
            }


            //taking input and executing
            int insid = (int)Session["user"];
            int cid = Int16.Parse(addassigncid.Text);
            String type = addassingtype.Text;
            int fullgrade = Int16.Parse(addassignfullgrade.Text);
            int number = Int16.Parse(addassignsnumber.Text);
            DateTime deadline = DateTime.Parse(addassigndeadline.Text);
            String content = addassigncontent.Text;
            Decimal weight = Decimal.Parse(addassignweight.Text);


            SqlCommand cmd = new SqlCommand("DefineAssignmentOfCourseOfCertianType", conn);
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@instId", insid));
            cmd.Parameters.Add(new SqlParameter("@cid", cid));
            cmd.Parameters.Add(new SqlParameter("@type", type));
            cmd.Parameters.Add(new SqlParameter("@fullGrade", fullgrade));
            cmd.Parameters.Add(new SqlParameter("@number", number));
            cmd.Parameters.Add(new SqlParameter("@weight", weight));
            cmd.Parameters.Add(new SqlParameter("@deadline", deadline));
            cmd.Parameters.Add(new SqlParameter("@content", content));

            //Check count of assignments prior to execution
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = conn;
            cmd2.CommandType = CommandType.Text;
            conn.Open();

            cmd2.CommandText = "SELECT count(*) FROM Assignment";
            Int16 oldCount = Int16.Parse(cmd2.ExecuteScalar().ToString());
            conn.Close();

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Error')", true);
                return;
            }

            //Check count of certificates post execution
            SqlCommand cmd3 = new SqlCommand();
            cmd3.Connection = conn;
            cmd3.CommandType = CommandType.Text;
            conn.Open();

            cmd3.CommandText = "SELECT count(*) FROM Assignment";
            Int16 newCount = Int16.Parse(cmd3.ExecuteScalar().ToString());
            conn.Close();

            if (oldCount == newCount)
            {
                Response.Write("<br /> Assignment cannot be issued (Make sure you give its course and a duplicate assignment doesn't exist)");
            }
            else
            {
                Response.Write("<br /> Assignment Issued Successfully");
            }




        }

        protected void gradeAssignments(object sender, EventArgs e)
        {
            //Establishing a connection
            String conStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(conStr);

            if (gradeassigncid.Text == "" || gradeassigngrade.Text == "" || gradeassignnumber.Text == "" || gradeassignsid.Text == "" )
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Missing Data')", true);
                return;
            }
            if (gradeassigntype.Text.ToLower() != "quiz" && gradeassigntype.Text.ToLower() != "exam" && gradeassigntype.Text.ToLower() != "project")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Assignment type must be Quiz/Exam/Project')", true);
                return;
            }
            //Check validity of input
            try
            {
                Int16.Parse(gradeassigncid.Text);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('CID must be a number')", true);
                return;
            }
            try
            {
                Int16.Parse(gradeassignsid.Text);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('SID must be a number')", true);
                return;
            }
            //Check validity of input
            try
            {
                Int16.Parse(gradeassignnumber.Text);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('assignment number must be a number')", true);
                return;
            }

            try
            {
                Int16.Parse(gradeassigngrade.Text);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Grade must be a number')", true);
                return;
            }

            //Call the procedure and give inputs

                int insid = (int)Session["user"];
                int cid = Int16.Parse(gradeassigncid.Text);
                int sid = Int16.Parse(gradeassignsid.Text);
                String type = gradeassigntype.Text;
                int grade = Int16.Parse(gradeassigngrade.Text);
                int number = Int16.Parse(gradeassignnumber.Text);

               
                SqlCommand cmd = new SqlCommand("InstructorgradeAssignmentOfAStudent", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@instrId", insid));
                cmd.Parameters.Add(new SqlParameter("@sid", sid));
                cmd.Parameters.Add(new SqlParameter("@cid", cid));
                cmd.Parameters.Add(new SqlParameter("@type", type));
                cmd.Parameters.Add(new SqlParameter("@grade", grade));
                cmd.Parameters.Add(new SqlParameter("@assignmentNumber", number));
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Error')", true);
                return;
            }

            //Call the procedure and give inputs
            SqlCommand cmd2 = new SqlCommand("InstructorViewAssignmentsStudents", conn);
            int insid2 = (int)Session["user"];
            int cid2 = Int16.Parse(gradeassigncid.Text);
            cmd2.Connection = conn;
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.Parameters.Add(new SqlParameter("@instrId", insid2));
            cmd2.Parameters.Add(new SqlParameter("@cid", cid2));

            try
            {
                conn.Open();
                cmd2.ExecuteNonQuery();
                SqlDataReader reader = cmd2.ExecuteReader();

                //Display the Data
                GridView1.DataSource = reader;
                GridView1.DataBind();
                conn.Close();

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Error')", true);
                return;
            }

        }
           
        

        protected void Issuecertificate(object sender, EventArgs e)
        {
            //Establishing a connection

            String conStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(conStr);

            //handle invalid input
            if (issuecid.Text == "" || issuedate.Text == "" || issuesid.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Missing Data')", true);
                return;
            }
            try
            {
                Int16.Parse(issuecid.Text);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('cid must be a number')", true);
                return;
            }
            try
            {
                DateTime.Parse(issuedate.Text);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('issue date must be in date time format')", true);
                return;
            }
            try
            {
                Int16.Parse(issuesid.Text);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('sid must be a number')", true);
                return;
            }
            

                //Call the procedure and give inputs
                
                SqlCommand cmd = new SqlCommand("InstructorIssueCertificateToStudent", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                int cid = Int16.Parse(issuecid.Text);
                int insid = (int)Session["user"];
                int sid = Int16.Parse(issuesid.Text);
                DateTime issue = DateTime.Parse(issuedate.Text);
                cmd.Parameters.Add(new SqlParameter("@insId", Session["user"]));
                cmd.Parameters.Add(new SqlParameter("@cid", issuecid.Text));
                cmd.Parameters.Add(new SqlParameter("@sid", issuesid.Text));
                cmd.Parameters.Add(new SqlParameter("@IssueDate", issuedate.Text));

                //Check count of certificates prior to execution
                SqlCommand cmd2 = new SqlCommand();
                cmd2.Connection = conn;
                cmd2.CommandType = CommandType.Text;
                conn.Open();

                cmd2.CommandText = "SELECT count(*) FROM StudentCertifyCourse";
                Int16 oldCount = Int16.Parse(cmd2.ExecuteScalar().ToString());
                conn.Close();

            //Execute procedure

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert(' Error')", true);
                return;
            }

            //Check count of certificates post execution
            SqlCommand cmd3 = new SqlCommand();
            cmd3.Connection = conn;
            cmd3.CommandType = CommandType.Text;
            conn.Open();

            cmd3.CommandText = "SELECT count(*) FROM StudentCertifyCourse";
            Int16 newCount = Int16.Parse(cmd3.ExecuteScalar().ToString());
            conn.Close();

            if (oldCount == newCount)
            {
                Response.Write("<br /> Certificate cannot be issued (The student must be taking the course and pass)");
            }
            else
            {
                Response.Write("<br /> Certificate Issued Successfully");
            }

        }

        protected void viewAssignments(object sender, EventArgs e)
        {
            //Establish a connection
            String conStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(conStr);

            //handle invalid input
            if (viewassigncid.Text == "" )
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Missing Data')", true);
                return;
            }

            try
            {
                Int16.Parse(viewassigncid.Text);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Course ID must be a number')", true);
                return;
            }


                //Call the procedure and give inputs
                SqlCommand cmd = new SqlCommand("InstructorViewAssignmentsStudents", conn);
                int insid = (int)Session["user"];
                int cid = Int16.Parse(viewassigncid.Text);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@instrId", insid));
                cmd.Parameters.Add(new SqlParameter("@cid", cid));
               

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                SqlDataReader reader = cmd.ExecuteReader();

                //Display the Data
                GridView1.DataSource = reader;
                GridView1.DataBind();
                conn.Close();

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Error')", true);
                return;
            }


        }

        protected void ViewFeedback(object sender, EventArgs e)
        {
            //Establishing A Connection
            String conStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(conStr);

            //handling empty input
            if (viewfeedcid.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Missing Data')", true);
                return;
            }

            //Check validity of input
            try
            {
                Int16.Parse(viewfeedcid.Text);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Course ID must be a number')", true);
                return;
            }


            //Call the procedure and give inputs

            SqlCommand viewFeedback = new SqlCommand("ViewFeedbacksAddedByStudentsOnMyCourse", conn);
            viewFeedback.CommandType = CommandType.StoredProcedure;
            int insid = (int)Session["user"];
            int cid = Int16.Parse(viewfeedcid.Text);
            viewFeedback.Parameters.Add(new SqlParameter("@instrId", insid));
            viewFeedback.Parameters.Add(new SqlParameter("@cid", cid));
            

            try
            {
                conn.Open();
                viewFeedback.ExecuteNonQuery();
                SqlDataReader reader = viewFeedback.ExecuteReader();

                //Display the Data
                GridView1.DataSource = reader;
                GridView1.DataBind();
                conn.Close();

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Invalid Data')", true);
                return;
            }

            conn.Open();
            SqlCommand check = new SqlCommand();
            check.Connection = conn;
            check.CommandType = CommandType.Text;
            check.CommandText = "SELECT name FROM Course where id = @courseID and instructorId = @insid";
            check.Parameters.AddWithValue("@courseID", cid);
            check.Parameters.AddWithValue("@insid",insid);
            if (check.ExecuteScalar() == null)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Course does not exist or you do not teach it')", true);
                return;
            }
            conn.Close();


        }

        protected void viewCourses(object sender, EventArgs e)
        {
            //Establishing A Connection
            String conStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(conStr);

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            conn.Open();

            cmd.CommandText = "SELECT * FROM Course where instructorId = @instID";
            cmd.Parameters.AddWithValue("@instID", Session["user"]);
            SqlDataReader reader = cmd.ExecuteReader();
            GridView1.DataSource = reader;
            GridView1.DataBind();
            conn.Close();
        }
    }
}
