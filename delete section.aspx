<%@ Page Language="C#" AutoEventWireup="true" CodeFile="delete section.aspx.cs" Inherits="delete_section" %>

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
            <h2>Delete a section</h2>
            <div class="add-button">
                <asp:Button ID="addButton" runat="server" Text="Delete" OnClick="AddCourse" CssClass="add-button" />
                <asp:Label ID="courseAddedPrompt" runat="server" Text="Section Deleted." Visible="false" CssClass="prompt" />
                <asp:Timer ID="timer" runat="server" Interval="5000" OnTick="timer_Tick" Enabled="false" />

            </div>
            <div class="form-container">
                <h2>Enter section name you want to delete</h2>
                <label for="sectionCode">Section Name:</label>
                <asp:TextBox ID="sectionCode" runat="server"></asp:TextBox>
                <br />
            </div>
        </div>
    </form>
</body>
</html>