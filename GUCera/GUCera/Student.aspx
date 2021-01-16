<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Student.aspx.cs" Inherits="GUCera.Student" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link href="Style.css" rel="stylesheet" />
<link rel="preconnect" href="https://fonts.gstatic.com">
<link href="https://fonts.googleapis.com/css2?family=Roboto+Condensed:wght@300&display=swap" rel="stylesheet">
    <title>Home</title>
  
    </head>
<body>
    <form id="form1" runat="server">
        <div>
                    <asp:Button ID="Button2" runat="server" OnClick="home" Text="Home" />
        <asp:Button ID="Button3" runat="server" OnClick="logout" Text="Logout" />
                    <br />
            I am a student
        </div>
        <!--  
            User1 VIEWPROFILE
        --> 
        <asp:Button ID="Button4" runat="server"  OnClick="ViewProfile" Text="View Profile" />
         <br />
        <asp:Button ID="Button8" runat="server"  OnClick="ViewPromo" Text="View Promocodes" />
         <br />
        <asp:Button ID="Button5" runat="server"  OnClick="ViewAvailableCourses" Text="View Available Courses" />
         <br />
        <asp:Button ID="Button6" runat="server"  OnClick="Enroll" Text="Enroll in a Course" />
         <br />
         <asp:Button ID="Button1" runat="server"  OnClick="addNumber" Text="Add Phone Number" />
         <br />
        <asp:Button ID="Button7" runat="server"  OnClick="credit" Text="Add Credit Card" />
         <br />
        <asp:Button ID="Button9" runat="server"  OnClick="assignments" Text="View/Submit/Check Assignment Grades" />
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" CssClass="Labels"  Text="Enter a course ID to view its certificate (if earned):"></asp:Label>
        <br />
        <asp:TextBox ID="certificateCID" runat="server" CssClass="Style.css" ></asp:TextBox>
        <br />
        <asp:Button ID="Button10" runat="server"  OnClick="certificate" Text="View Certificate" />
         <br />
        <br />
         <br />
        <asp:Label ID="Label2" runat="server" CssClass="Style.css"  Text="Add a feedback to a course you are enrolled in:"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" CssClass="Style.css"  Text="Enter the course ID :"></asp:Label>
        <br />
        <asp:TextBox ID="fbCID" runat="server" CssClass="Style.css" ></asp:TextBox>
        <br />
        <asp:Label ID="Label4" runat="server" CssClass="Style.css"  Text="Enter a comment (optional) (max. 100 characters) :"></asp:Label>
        <br />
        <asp:TextBox ID="comment" runat="server" CssClass="Style.css" ></asp:TextBox>
        <br />
        <asp:Button ID="Button11" runat="server" CssClass="Style.css" OnClick="feedback" Text="Submit Feedback" />
        <br />
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server" Width="378px"> </asp:GridView>
        <br />
        <br />
    </form>
</body>
</html>
