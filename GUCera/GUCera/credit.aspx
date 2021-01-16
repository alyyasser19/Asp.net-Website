<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="credit.aspx.cs" Inherits="GUCera.credit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link href="Style.css" rel="stylesheet" />
<link rel="preconnect" href="https://fonts.gstatic.com"/>
<link href="https://fonts.googleapis.com/css2?family=Roboto+Condensed:wght@300&display=swap" rel="stylesheet"/>
    <title>Credit Card</title>
</head>
<body>
    <form id="form1" runat="server">
      <div>
        <asp:Button ID="Button2" runat="server" OnClick="home" Text="Home" />
        <asp:Button ID="Button3" runat="server" OnClick="logout" Text="Logout" />
            <br />
        </div>
        <p>
            <asp:Label ID="Label3" runat="server" Text="Enter Number:"></asp:Label>
            <br />
            <asp:TextBox ID="Number" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="Label1" runat="server" Text="Holder Name:"></asp:Label>
            <br />
            <asp:TextBox ID="Name" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="Label2" runat="server" Text="Expiry Date:"></asp:Label>
            <br />
            <asp:TextBox ID="expiryDate" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="Label4" runat="server" Text="CVV:"></asp:Label>
            <br />
            <asp:TextBox ID="CVV" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="Button1" runat="server" Text="Add" OnClick="add" />
        </p>
        <div class="labels">Your Cards:</div>
    <asp:GridView ID="GridView1" runat="server"> </asp:GridView>
    </form>
</body>
</html>
