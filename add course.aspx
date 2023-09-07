<%@ Page Language="C#" AutoEventWireup="true" CodeFile="add course.aspx.cs" Inherits="add_course" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Add Course</title>
    <link rel="stylesheet" href="styles.css">
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="back-button">
            <asp:Button ID="back" runat="server" Text="Back" OnClick="backButton_Click" />
        </div>
        <div class="container">
            <h1>Flex Management System</h1>
            <h2>Add a course</h2>
            <div class="add-button">
                <asp:Button ID="addButton" runat="server" Text="Add" OnClick="AddCourse" CssClass="add-button" />
                <asp:Label ID="courseAddedPrompt" runat="server" Text="Course Added." Visible="false" CssClass="prompt" />
                <asp:Timer ID="timer" runat="server" Interval="5000" OnTick="timer_Tick" Enabled="false" />

            </div>
            <div class="form-container">
                <label for="courseCode">Course Code:</label>
                <asp:TextBox ID="courseCode" runat="server"></asp:TextBox>
                <br />
                <label for="courseName">Course Name:</label>
                <asp:TextBox ID="courseName" runat="server"></asp:TextBox>
                <br />
                <label for="courseType">Course Type:</label>
                <asp:TextBox ID="courseType" runat="server"></asp:TextBox>
                <br />
                <label for="creditHours">Credit Hours:</label>
                <asp:TextBox ID="creditHours" runat="server"></asp:TextBox>
                <br />
                <label for="coordinatorId">Coordinator ID:</label>
                <asp:TextBox ID="coordinatorId" runat="server"></asp:TextBox>
            </div>
        </div>
    </form>
</body>
</html>