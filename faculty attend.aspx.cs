using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class student_attend : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["users_id1"] == null)
        {
            // Redirect the user to the previous page or display an error message.
            return;
        }

        string users_id = Session["users_id1"].ToString();
        // Clear any previous response
        Response.Clear();
        // Query to get all offered courses
        string query = "SELECT attendance.student_roll, student.Fname, student.Lname, attendance.Attend_Date, attendance.a_status, student.section\r\nFROM attendance\r\nJOIN student ON attendance.student_roll = student.roll\r\nJOIN teaches ON attendance.course_id = teaches.course_id AND attendance.teacher_id = teaches.teacher_id\r\nWHERE teaches.teacher_id ='" + users_id + "'";
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-UNH3EMQ\\SQLEXPRESS;Initial Catalog=flex;Integrated Security=True");
        SqlCommand cmd = new SqlCommand(query, conn);
        conn.Open();
        SqlDataReader reader = cmd.ExecuteReader();

        // Create an HTML string builder
        StringBuilder html = new StringBuilder();

        // Add HTML header
        html.Append("<html><body>");
        html.Append("<h1>Attendance Sheet</h1>");

        // Add table header
        html.Append("<table>");
        html.Append("<tr>");
        html.Append("<th>Roll number</th>");
        html.Append("<th>First Name</th>");
        html.Append("<th>Last Name</th>");
        html.Append("<th>Attendance Date </th>");
        html.Append("<th>Section Number</th>");
        html.Append("<th>Status</th>");

        html.Append("</tr>");

        // Add rows dynamically based on query results
        while (reader.Read())
        {
            html.Append("<tr>");
            html.Append("<td>" + reader["student_roll"] + "</td>");
            html.Append("<td>" + reader["Fname"] + "</td>");
            html.Append("<td>" + reader["Lname"] + "</td>");
            html.Append("<td>" + reader["Attend_Date"] + "</td>");
            html.Append("<td>" + reader["section"] + "</td>");
            html.Append("<td>" + reader["a_status"] + "</td>");
            

            html.Append("</tr>");
        }

        // Close table and HTML
        html.Append("</table>");
        html.Append("</body></html>");

        // Load HTML string into Response object
        Response.Write(html.ToString());


    }
}