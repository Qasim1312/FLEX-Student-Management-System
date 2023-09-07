<%@ Page Language="C#" AutoEventWireup="true" CodeFile="admin first.aspx.cs" Inherits="first" %>

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
            <p>If you already have an account then log in; otherwise, create a new account by signing up!</p>
            <div class="form-container">
                <h2>Login</h2>
                <label for="login_username">Username:</label>
                <asp:TextBox ID="login_username" runat="server"></asp:TextBox>
                <br>
                <label for="login_password">Password:</label>
                <asp:TextBox ID="login_password" runat="server" TextMode="Password"></asp:TextBox>
                <br>
                <asp:Button ID="loginButton" runat="server" Text="Log In" OnClick="logButton_Click" />
                <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
            </div>
            <div class="form-container">
                <h2>Sign Up</h2>
                <label for="login_username">Username:</label>
                <asp:TextBox ID="sign_username" runat="server"></asp:TextBox>
                <br>
                <label for="login_password">Password:</label>
                <asp:TextBox ID="sign_password" runat="server" TextMode="Password"></asp:TextBox>
                <br>
                <label for="name">First Name:</label>
                <asp:TextBox ID="Fname" runat="server"></asp:TextBox> 
                <br>
                <label for="dob">Last Name:</label>
                <asp:TextBox ID="Lname" runat="server"></asp:TextBox>
                <br>
                <label for="cnic">CNIC:</label>
                <asp:TextBox ID="cnic" runat="server"></asp:TextBox>
                <br>
                <label for="address">Email Address:</label>
                <asp:TextBox ID="email" runat="server"></asp:TextBox>
                <br>
                <label for="contact">Contact Number:</label>
                <asp:TextBox ID="phone" runat="server" ></asp:TextBox>
                <br>
                <label for="userId">Admin ID:</label>
                <asp:TextBox ID="admin_id" runat="server" ></asp:TextBox>
                <br>
                <asp:Button ID="SignButton" runat="server" Text="Sign Up" OnClick="SignButton_Click" />
                <asp:Label ID="lblMessage1" runat="server" ForeColor="Red"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
