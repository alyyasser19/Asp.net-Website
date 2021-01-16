<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Instructor.aspx.cs" Inherits="GUCera.Instructor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Welcome Instructor</title>
    <link href="Style.css" rel="stylesheet" />
    <link rel="preconnect" href="https://fonts.gstatic.com">
    <link href="https://fonts.googleapis.com/css2?family=Roboto+Condensed:wght@300&display=swap" rel="stylesheet">
    <style type="text/css">
        .auto-style1 {
            position: absolute;
            top: 609px;
            left: 47px;
            z-index: 1;
            width: 105px;
            height: 23px;
            right: 1720px;
        }
        .auto-style3 {
            position: absolute;
            top: 678px;
            left: 47px;
        }
        .auto-style4 {
            position: absolute;
            top: 655px;
            left: 42px;
        }
        .auto-style5 {
            position: absolute;
            top: 701px;
            left: 42px;
            right: 601px;
        }
        </style>
    </head>
<body>
    <form id="form1" runat="server">
        <div>
                    <br />
                    Welcome, Instructor<br />
                    <asp:Button ID="Button2" runat="server" OnClick="home" Text="Home" />
        <asp:Button ID="Button3" runat="server" OnClick="logout" Text="Logout" />
            <br />
                    <br />
                    <br />
                    <br />
        </div>
                <asp:Button ID="Button1" runat="server" OnClick="addNumber" Text="Add Phone Number" />
        <br />
        <asp:Label ID="Label2" runat="server" CssClass="titles" style="z-index: 1" Text="Adding Course:"></asp:Label>
        <br />
        <br />
        &nbsp;Credit Hours&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
        <asp:TextBox ID="courseCreditHours" runat="server" style="margin-right: 0px"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Price<br />
        <asp:TextBox ID="coursename" runat="server"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="courseprice" runat="server"></asp:TextBox>
        <br />
        Content (optional)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Description (optional)<br />
        <asp:TextBox ID="coursecontent" runat="server" style="margin-right: 0px"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="coursedescription" runat="server" style="margin-right: 0px"></asp:TextBox>
        <br />
        <asp:Button ID="addcoursedetails" runat="server" OnClick="addCourse" Text="Add Course" />
        <br />
        <br /> 
        <asp:Label ID="Label1" runat="server" CssClass="titles" style="z-index: 1" Text="Adding Course Prerequisite:"></asp:Label>
        <br />

      <asp:Label ID="Label9" runat="server" Text="Course ID:"></asp:Label><br />
        <asp:TextBox ID="courseID" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label10" runat="server" Text="Prerequisite ID:"></asp:Label><br />
        <asp:TextBox ID="prerequisite" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button4" runat="server" OnClick ="addPrereq" Text="Add Prerequisite" />
        <br />
       <asp:Label ID="Label4" runat="server" CssClass="titles" style="z-index: 1" Text="Adding Assignments:"></asp:Label><br />
        <br />
       <asp:Label ID="Label11" runat="server" Text="CID"></asp:Label><br />
        <asp:TextBox ID="addassigncid" runat="server"></asp:TextBox>
        <br />
        Number&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Type<br />
        <asp:TextBox ID="addassignsnumber" runat="server"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="addassingtype" runat="server" ></asp:TextBox>
        <br />
        Full Grade&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Weight<br />
        <asp:TextBox ID="addassignfullgrade" runat="server"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="addassignweight" runat="server"></asp:TextBox>
        <br />
        Deadline&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; content<br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="addassigndeadline" runat="server"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="addassigncontent" runat="server"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
                <asp:Button ID="addassignment" runat="server" OnClick="addAssignment" Text="Add Assignment" />
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" CssClass="titles" style="z-index: 1" Text="Grade Assignments:"></asp:Label><br />
        SID<br />
        <asp:TextBox ID="gradeassignsid" runat="server"></asp:TextBox>
        <br />
        Cid&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Assignment number<br />
        <asp:TextBox ID="gradeassigncid" runat="server"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="gradeassignnumber" runat="server"></asp:TextBox>
        <br />
        Type&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Grade<br />
        <asp:TextBox ID="gradeassigntype" runat="server"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="gradeassigngrade" runat="server"></asp:TextBox>
        <br />
        <br />
                <asp:Button ID="gradeassignments" runat="server" OnClick="gradeAssignments" Text="Grade Assignments" />
        <br />
        <br />
        <asp:Label ID="Label5" runat="server" CssClass="titles" style="z-index: 1" Text="Issuing a Certificate:"></asp:Label>
        <br />
        <br />
        CID&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; SID<br />
        <asp:TextBox ID="issuecid" runat="server"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="issuesid" runat="server"></asp:TextBox>
        <br />
        Issue Date<br />
        <asp:TextBox ID="issuedate" runat="server"></asp:TextBox>
        <br />
                <asp:Button ID="issuecertificate" runat="server" OnClick="Issuecertificate" Text="Issue Certificate" />
        <br />
        <br />
       <asp:Label ID="Label6" runat="server" CssClass="titles" style="z-index: 1" Text="View Assignments:"></asp:Label><br />
        CID<br />
        <asp:TextBox ID="viewassigncid" runat="server"></asp:TextBox>
        <br />
                <asp:Button ID="viewassignments" runat="server" OnClick="viewAssignments" Text="View Assignments" />
        <br />
        <br />
        <asp:Label ID="Label7" runat="server" CssClass="titles" style="z-index: 1" Text="View Feedback:"></asp:Label><br />
        <br />
        CID<br />
        <asp:TextBox ID="viewfeedcid" runat="server"></asp:TextBox>
        <br />
        <br />
                <asp:Button ID="viewfeedback" runat="server" OnClick="ViewFeedback" Text="View Feedback" />
        <br />
        <br />
        <asp:Label ID="Label8" runat="server" CssClass="titles" style="z-index: 1" Text="View Your Courses:"></asp:Label>
                <br />
                <asp:Button ID="viewcourses" runat="server" OnClick="viewCourses" Text="View Courses" />
        <br />
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
        <br />
        <br />
    </form>
</body>
</html>
