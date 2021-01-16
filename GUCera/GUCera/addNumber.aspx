<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addNumber.aspx.cs" Inherits="GUCera.addNumber" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link href="Style.css" rel="stylesheet" />
<link rel="preconnect" href="https://fonts.gstatic.com"/>
<link href="https://fonts.googleapis.com/css2?family=Roboto+Condensed:wght@300&display=swap" rel="stylesheet"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        <asp:Button ID="Button2" runat="server" OnClick="home" Text="Home" />
        <asp:Button ID="Button3" runat="server" OnClick="logout" Text="Logout" />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Enter Number:"></asp:Label>
            <br />
        </div>
        <p>
            <asp:TextBox ID="Number" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="Button1" runat="server" Text="Add" OnClick="add" />
        </p>
        <div class="labels">Your Numbers:</div>
    <asp:GridView ID="Phones" runat="server"> </asp:GridView>
    </form>
    

</body>
</html>
