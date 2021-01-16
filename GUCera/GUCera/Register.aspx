<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="GUCera.Register2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registration Page</title>
    <link href="Style.css" rel="stylesheet" />
    <link rel="preconnect" href="https://fonts.gstatic.com">
    <link href="https://fonts.googleapis.com/css2?family=Roboto+Condensed:wght@300&display=swap" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
     <h1>
      Create an account<br />
     </h1>
        <p class="labels">
            <asp:CheckBox ID="instructorBox" runat="server" Text="I am an instructor" CssClass="CheckBox" />
        </p>
        <p class="labels">
            <asp:CheckBox ID="studentBox" runat="server" Text="I am a student" CssClass="CheckBox" />
        </p>
       
        <asp:Label CssClass="labels" runat="server" Text="Label">First Name:</asp:Label>
        <br />
        <asp:TextBox ID="firstName" runat="server" Height="16px"></asp:TextBox>
        <br />
        <asp:Label CssClass="labels" runat="server" Text="Label">Last Name:</asp:Label>
        <br />
        <asp:TextBox ID="lastName" runat="server" Height="16px"></asp:TextBox>
        <br />
        <asp:Label CssClass="labels" runat="server" Text="Label">Password:</asp:Label>
        <br />
        <asp:TextBox TextMode="Password" ID="password" runat="server" Height="16px"></asp:TextBox>
        <br />
        <asp:Label CssClass="labels" runat="server" Text="Label">E-mail:</asp:Label>
        <br />
        <asp:TextBox ID="email" runat="server" Height="16px"></asp:TextBox>
        <br />
        <asp:Label CssClass="labels" runat="server" Text="Label">Gender:</asp:Label>
        <br />
        <asp:DropDownList ID="gender" runat="server" CssClass="dropDown" style="z-index: 1">
            <asp:ListItem Value="0">Male</asp:ListItem>
            <asp:ListItem Value="1">Female</asp:ListItem>
        </asp:DropDownList>
        <br />
        <asp:Label CssClass="labels" runat="server" Text="Label">Address:</asp:Label>
        <br />
        <asp:TextBox ID="address" runat="server" Height="16px"></asp:TextBox>
        <br />
        <asp:Button CssClass="Button" runat="server" Height="40px" Text="Register" Width="111px" OnClick="register" />
    
    </form>
</body>
</html>
