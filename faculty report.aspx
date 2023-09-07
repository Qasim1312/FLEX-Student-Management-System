<%@ Page Language="C#" AutoEventWireup="true" CodeFile="faculty report.aspx.cs" Inherits="faculty_report" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Faculty report generation</title>
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
                <asp:Button ID="attendance" runat="server" Text="Attendance sheet report" OnClick="attendButton_Click" />
                <asp:Button ID="evaluation" runat="server" Text="Evaluation report" OnClick="evaluationButton_Click" />
                <asp:Button ID="grade" runat="server" Text="Grade report" OnClick="gradeButton_Click" />
                <asp:Button ID="countGrade" runat="server" Text="Count grade report" OnClick="countButton_Click" />
                <asp:Button ID="feedback" runat="server" Text="Student feedback report" OnClick="feedbackButton_Click" />
            </div>
        </div>
    </form>
</body>
</html>
