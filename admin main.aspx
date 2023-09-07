<%@ Page Language="C#" AutoEventWireup="true" CodeFile="admin main.aspx.cs" Inherits="admin_main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Dashboard Admin</title>
    <link rel="stylesheet" href="styles.css">
</head>
<body>
    <form id="form1" runat="server">
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="container">
        <h1>Flex Management System</h1>
        <div class="user-greeting">
            Hey, Admin Member!
        </div>
        <div class="dashboard">
            <div class="user-info">
                <h2>User Information:</h2>
                <p><asp:Label ID="AdminIDLabel" runat="server" Text="Admin ID:" /><asp:TextBox ID="AdminIDTextBox" runat="server" /></p>
                <p><asp:Label ID="FirstNameLabel" runat="server" Text="First Name:" /><asp:TextBox ID="FirstNameTextBox" runat="server" /></p>
                <p><asp:Label ID="LastNameLabel" runat="server" Text="Last Name:" /><asp:TextBox ID="LastNameTextBox" runat="server" /></p>
                <p><asp:Label ID="EmailLabel" runat="server" Text="Email:" /><asp:TextBox ID="EmailTextBox" runat="server" /></p>
                <p><asp:Label ID="CNICLabel" runat="server" Text="CNIC:" /><asp:TextBox ID="CNICTextBox" runat="server" /></p>
                <p><asp:Label ID="ContactNumberLabel" runat="server" Text="Contact Number:" /><asp:TextBox ID="ContactNumberTextBox" runat="server" /></p>
                <p><asp:Label ID="UserIDLabel" runat="server" Text="User ID:" /><asp:TextBox ID="UserIDTextBox" runat="server" /></p>
            </div>
                        <div class="navigation-panel">
                <h2>Navigation</h2>
                <asp:Button ID="manageCoursesButton" runat="server" Text="Manage Courses" OnClick="RedirectToCourse" CssClass="nav-button" />
                <asp:Button ID="manageSectionsButton" runat="server" Text="Manage Sections" OnClick="RedirectToSection" CssClass="nav-button" />
                <asp:Button ID="manageReportsButton" runat="server" Text="Manage Reports" OnClick="RedirectToReport" CssClass="nav-button" />
                <asp:Button ID="userLogoutButton" runat="server" Text="User Log Out" OnClick="RedirectToLog" CssClass="nav-button" />
            <asp:Label ID="prompt" runat="server" Text="Logged Out." Visible="false" />
            <asp:Timer ID="timer" runat="server" Interval="2000" OnTick="timer_Tick" Enabled="false" />
            </div>
        </div>
    </div>
        </form>
</body>
</html>
