<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Manage Section.aspx.cs" Inherits="Manage_Section" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Section Management</title>
    <link rel="stylesheet" href="styles.css">
</head>
<body>
    <form id="form1" runat="server">
        <div class="back-button">
            <asp:Button ID="back" runat="server" Text="Back" OnClick="backButton_Click" />
        </div>
        <div class="container">
            <h1>Flex Management System</h1>
                        <h2>Manage Sections</h2>
            <div class="section-action-container">
                <div class="section-buttons">
                    <asp:Button ID="addSectionButton" runat="server" Text="Add Section" OnClick="AddSection_Click" CssClass="section-button" />
                    <asp:Button ID="deleteSectionButton" runat="server" Text="Delete Section" OnClick="DeleteSection_Click" CssClass="section-button" />
                </div>
            </div>
            <div class="section-list-container">
                <h2>List of all the sections</h2>
                <div class="section-list">
                    <asp:Button ID="sectionAButton" runat="server" Text="Section A" OnClick="SectionA_Click" CssClass="section-button" />
                    <asp:Button ID="sectionBButton" runat="server" Text="Section B" OnClick="SectionB_Click" CssClass="section-button" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>