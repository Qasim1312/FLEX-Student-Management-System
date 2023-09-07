<%@ Page Language="C#" AutoEventWireup="true" CodeFile="generic.aspx.cs" Inherits="generic" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Generic User</title>
    <link rel="stylesheet" href="buttonstyles.css?v=2">
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>Flex Management System</h1>
            <p>Which type of user are you?</p>
            <div class="button-container">
                <asp:Button ID="studentButton" runat="server" Text="Student" OnClick="studentButton_Click" />
                <asp:Button ID="facultyButton" runat="server" Text="Faculty" OnClick="facultyButton_Click" />
                <asp:Button ID="adminButton" runat="server" Text="Admin" OnClick="adminButton_Click" />
            </div>
        </div>
    </form>
</body>
</html>