<%@ Page Language="C#" AutoEventWireup="true" CodeFile="delete course.aspx.cs" Inherits="delete_course" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Delete Course</title>
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
            <h2>Delete a course</h2>
            <div class="add-button">
                <asp:Button ID="deleteButton" runat="server" Text="Delete" OnClick="DeleteCourse" CssClass="add-button" />
                <asp:Label ID="courseDeletedPrompt" runat="server" Text="Course Deleted." Visible="false" CssClass="prompt" />
                <asp:Timer ID="timer" runat="server" Interval="5000" OnTick="timer_Tick" Enabled="false" />

            </div>
            <div class="form-container">
                <h2>Enter course code you want to delete</h2>
                <label for="courseId">Course Code:</label>
                <asp:TextBox ID="courseId" runat="server"></asp:TextBox>
                <br />
            </div>
        </div>
    </form>
</body>
</html>
