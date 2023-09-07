<%@ Page Language="C#" AutoEventWireup="true" CodeFile="admin report.aspx.cs" Inherits="admin_report" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin report generation</title>
    <link rel="stylesheet" href="buttonstyles.css?v=2">
</head>
<body>
    <form id="form1" runat="server">
        <div class="back-button">
            <asp:Button ID="back" runat="server" Text="Back" OnClick="backButton_Click" />
        </div>
        <div class="container">
            <h1>Flex Management System</h1>
            <h2>Generate Reports</h2>

            <div class="button-container">
                <asp:Button ID="courses" runat="server" Text="Generate offered courses report" OnClick="coursesButton_Click" />
                <asp:Button ID="section" runat="server" Text="Generate students section report" OnClick="sectionButton_Click" />
                <asp:Button ID="allocation" runat="server" Text="Generate course allocation report" OnClick="allocateButton_Click" />
            </div>
        </div>
    </form>
</body>
</html>
