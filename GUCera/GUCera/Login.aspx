<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="GUCera.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Welcome to GUCera</title>
    <link href="Style.css" rel="stylesheet" />
    <link rel="preconnect" href="https://fonts.gstatic.com">
    <link href="https://fonts.googleapis.com/css2?family=Roboto+Condensed:wght@300&display=swap" rel="stylesheet">
</head>
<body>
      <h1>
      Welcome To GUCera!<br />
      </h1>
    <form id="form1" runat="server">
        <p class="labels">
            Please Login:</p>
        <asp:Label CssClass="labels" runat="server" Text="Label">ID:</asp:Label>
        <br />
        <asp:TextBox ID="Username" runat="server" Height="16px"></asp:TextBox>
        <br />
        <asp:Label CssClass="labels" runat="server" Text="Label">Password:

        </asp:Label>
        <br />
        <asp:TextBox TextMode="Password" ID="Password" runat="server" Height="16px"></asp:TextBox>
        <br />
        <asp:Button CssClass="Button" runat="server" Height="40px" Text="Login" Width="111px" OnClick="login" />
        <br />
        <asp:Button ID="Reg" runat="server" Text="Create New Account" onClick="goRegister"></asp:Button>
    </form>
</body>
</html>
