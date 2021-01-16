<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Assignments.aspx.cs" Inherits="GUCera.Assignments" %>

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
            <br />
            <asp:Label ID="Label1" CssClass="titles" runat="server" Text="Viewing Available Assignments:"></asp:Label>
             <br />
             <br />
            <asp:Label ID="Label2" CssClass="labels" runat="server" Text="Course ID:"></asp:Label>
             <br />
            <asp:TextBox ID="ID"  runat="server"></asp:TextBox>
             <br />
             <asp:Button ID="Button4" runat="server" Text="View Assignments" OnClick="viewAssignment" />
            <asp:GridView ID="GridView1" runat="server"> </asp:GridView>
             <br />
            <br />
             <br />
             <asp:Label ID="Label3" CssClass="titles" runat="server" Text="Submitting Assignments:"></asp:Label>
             <br />
             <br />
             <asp:Label ID="Label4" CssClass="labels" runat="server" Text="Assignment Type:"></asp:Label>
            <br />
            <asp:TextBox ID="aType"  runat="server"></asp:TextBox>
             <br /><asp:Label ID="Label5" CssClass="labels" runat="server" Text="Assignment Number:"></asp:Label>
            <br />
            <asp:TextBox ID="aNumber"  runat="server"></asp:TextBox>
             <br />
             <asp:Label ID="Label6" CssClass="labels" runat="server" Text="Course ID:"></asp:Label>
            <br />
            <asp:TextBox ID="aCID"  runat="server"></asp:TextBox>
             <br />
             <asp:Button ID="Button1" runat="server" Text="Submit Assignment" OnClick="submitAssignment" />
             <br />
             <br />
             <br />
             <asp:Label ID="Label7" CssClass="titles" runat="server" Text="Viewing Assignment Grades:"></asp:Label>
             <br />
             <br />
             <asp:Label ID="Label8" CssClass="lables" runat="server" Text="Assignment Type:"></asp:Label>
            <br />
            <asp:TextBox ID="vType"  runat="server"></asp:TextBox>
             <br /><asp:Label ID="Label9" CssClass="lables" runat="server" Text="Assignment Number:"></asp:Label>
            <br />
            <asp:TextBox ID="vNumber"  runat="server"></asp:TextBox>
             <br />
             <asp:Label ID="Label10" CssClass="lables" runat="server" Text="Course ID:"></asp:Label>
            <br />
            <asp:TextBox ID="vCID"  runat="server"></asp:TextBox>
             <br />
             <asp:Button ID="Button5" runat="server" Text="View Grade" OnClick="viewGrade" />
             <br />
             <br />
             <asp:Label ID="GradeLabel" CssClass="lables" runat="server" Text=" "></asp:Label>
             

        </div>
    </form>
</body>
</html>
