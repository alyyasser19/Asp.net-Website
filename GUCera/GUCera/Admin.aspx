<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="GUCera.Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Welcome Admin</title>
    <link href="Style.css" rel="stylesheet" />
    <link rel="preconnect" href="https://fonts.gstatic.com">
    <link href="https://fonts.googleapis.com/css2?family=Roboto+Condensed:wght@300&display=swap" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
        <div>
        	Welcome Admin<br />
			<br />
        <asp:Button ID="Button2" runat="server" OnClick="home" Text="Home" />
        <asp:Button ID="Button3" runat="server" OnClick="logout" Text="Logout" />
            <br />
            <br />
        </div>
        <asp:Button ID="Button1" runat="server" OnClick="addNumber" Text="Add Phone Number" />
    	<br />
		<asp:Button ID="Button4" runat="server" OnClick="ListAllCourses" Text="List All Courses" Width="211px" />
		<br />
		<asp:Button ID="Button5" runat="server" Text="List Non-Accepted Courses" Width="211px" OnClick="ListNonAcceptedCourses" />
		<br />
		<asp:Button ID="Button6" runat="server" Text="Accept Added Courses" Width="211px" OnClick="AcceptAddedCourses" />
		<br />
		<asp:Button ID="Button7" runat="server" Text="Create a Promo Code" Width="211px" OnClick="CreateAPromoCode" />
		<br />
		<asp:Button ID="Button8" runat="server" Text="Issue a Promo Code" Width="211px" OnClick="IssueAPromoCode" />
		<br />
		<br />
		<br />
		<asp:GridView ID="GridView1" runat="server">
		</asp:GridView>
		<br />
		<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
		<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		<asp:TextBox ID="TextBox1" runat="server" Width="196px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;
		<asp:Button ID="Button9" runat="server" OnClick="Accept_Click" Text="Button" />
		<br />
		<asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
		<br />
		<br />
		&nbsp;<asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		<asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		<asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		<asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
		<asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>
		<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		<asp:TextBox ID="TextBox2" runat="server" Width="57px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
		<asp:TextBox ID="TextBox3" runat="server" Width="66px"></asp:TextBox>
		&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;
		<asp:TextBox ID="TextBox4" runat="server" Width="66px"></asp:TextBox>
		&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; &nbsp;
		<asp:TextBox ID="TextBox5" runat="server" Width="57px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
		<asp:TextBox ID="TextBox6" runat="server" Width="57px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		<asp:Button ID="Button10" runat="server" OnClick="Create_Click" Text="Button" />
		<br />
		<asp:Button ID="Button11" runat="server" OnClick="Issue_Click" style="height: 29px" Text="Button" />
		<br />
	</form>
</body>
</html>
