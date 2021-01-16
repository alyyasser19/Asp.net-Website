<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Enroll.aspx.cs" Inherits="GUCera.Enroll" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link href="Style.css" rel="stylesheet" />
<link rel="preconnect" href="https://fonts.gstatic.com">
<link href="https://fonts.googleapis.com/css2?family=Roboto+Condensed:wght@300&display=swap" rel="stylesheet">
    <title>Enroll</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <asp:Button ID="Button2" runat="server" OnClick="home" Text="Home" />
        <asp:Button ID="Button3" runat="server" OnClick="logout" Text="Logout" />
            <br />
            <asp:Label ID="Label1" CssClass="lables" runat="server" Text="Available Courses:"></asp:Label>
            <asp:GridView ID="GridView1" runat="server"> </asp:GridView>
            <br />
            <asp:Label ID="Label2" CssClass="lables" runat="server" Text="Course ID:"></asp:Label>
            <br />
            <asp:TextBox ID="ID"  runat="server"></asp:TextBox>
            <br />
            <asp:Label CssClass="lables" ID="Label3" runat="server" Text="Instructor ID:"></asp:Label>
            <br />
            <asp:TextBox ID="Instructor" runat="server"></asp:TextBox>
             <br />
             <asp:Button ID="Button4" runat="server" Text="Enroll" OnClick="enroll" />
        </div>
    </form>
</body>
</html>
