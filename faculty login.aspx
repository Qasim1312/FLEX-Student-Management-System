<%@ Page Language="C#" AutoEventWireup="true" CodeFile="faculty login.aspx.cs" Inherits="faculty_login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Flex Management System</title>
    <link rel="stylesheet" href="styles.css">
</head>
<body>
        <form id="form1" runat="server">
    <div class="container">
        <h1>Flex Management System</h1>
        <div class="form-container">
            <h2>Login</h2>
            <form action="login_redirect_page.html" method="POST">
                <label for="login_username">Username:</label>
<asp:TextBox ID="login_username" runat="server"></asp:TextBox>
                <br>
                <label for="login_password">Password:</label>
<asp:TextBox ID="login_password" runat="server" TextMode="Password"></asp:TextBox>
                <br>
                <asp:Button ID="loginButton" runat="server" Text="Log In" OnClick="logButton_Click" />
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>

            </form>
        </div>
    </div>
            </form>
</body>
</html>