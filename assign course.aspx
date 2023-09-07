<%@ Page Language="C#" AutoEventWireup="true" CodeFile="assign course.aspx.cs" Inherits="assign_course" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Data Entry</title>
    <link rel="stylesheet" href="styles.css">
</head>
<body>
    <form id="form1" runat="server">
        <div class="back-button">
            <asp:Button ID="back" runat="server" Text="Back" OnClick="backButton_Click" />
        </div>
        <div class="container">
            <h1>Flex Management System</h1>
            <h2>Assign courses</h2>
            <div class="add-button">
                <asp:Button ID="addButton" runat="server" Text="Assign" OnClick="AddCourse" CssClass="add-button" />
                <asp:Label ID="courseAddedPrompt" runat="server" Text="Course Assigned." Visible="false" CssClass="prompt" />

            </div>
            <div class="data-entry-form">
                <p>Course code: <asp:TextBox ID="courseCodeTextBox" runat="server"></asp:TextBox></p>
                <p>Section Name: <asp:TextBox ID="sectionNameTextBox" runat="server"></asp:TextBox></p>
                <asp:Button ID="submitButton" runat="server" Text="Submit" OnClick="SubmitData" />
                <asp:Label ID="entryPrompt" runat="server" Text="Please enter at least 10 data values." CssClass="prompt" />
                <asp:Label ID="entryCounter" runat="server" Text="0" Visible="false" />
            </div>
        </div>
    </form>
</body>
</html>
