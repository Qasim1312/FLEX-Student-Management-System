<%@ Page Language="C#" AutoEventWireup="true" CodeFile="take attendance.aspx.cs" Inherits="student_attend" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <link rel="stylesheet" href="styles.css">
    <form id="form1" runat="server">
        <div class="user-info">
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<asp:TextBox ID="datePicker" runat="server" TextMode="Date"></asp:TextBox>
<asp:Button ID="loadStudentsButton" runat="server" Text="Load Students" OnClick="LoadStudents" />
<asp:Button ID="saveAttendanceButton" runat="server" Text="Save Attendance" OnClick="SaveAllAttendance" />
<asp:Repeater ID="studentsRepeater" runat="server">
    <ItemTemplate>
        <div class="student">
<asp:Label ID="rollNumberLabel" runat="server" Text='<%# Eval("student_roll") %>' CssClass="roll-number"></asp:Label>
            <span class="name"><%# Eval("Fname") %> <%# Eval("Lname") %></span>
            <asp:DropDownList ID="statusDropDown" runat="server" AutoPostBack="True" >
                <asp:ListItem>Present</asp:ListItem>
                <asp:ListItem>Absent</asp:ListItem>
            </asp:DropDownList>
        </div>
    </ItemTemplate>
</asp:Repeater>


        </div>
    </form>
</body>
</html>