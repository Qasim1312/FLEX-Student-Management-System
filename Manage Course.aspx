<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Manage Course.aspx.cs" Inherits="Manage_Course" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Generic User</title>
    <link rel="stylesheet" href="buttonstyles.css?v=2">
</head>
<body>
    <form id="form1" runat="server">
        <div class="back-button">
            <asp:Button ID="back" runat="server" Text="Back" OnClick="backButton_Click" />
        </div>
        <div class="container">
            <h1>Flex Management System</h1>
            <h2>Manage Courses</h2>

            <div class="button-container">
                <asp:Button ID="add" runat="server" Text="Add a course" OnClick="addButton_Click" />
                <asp:Button ID="delete" runat="server" Text="Delete a course" OnClick="deleteButton_Click" />
                <asp:Button ID="assign" runat="server" Text="Assign a course" OnClick="assignButton_Click" />
            </div>
        </div>
    </form>
</body>
</html>
