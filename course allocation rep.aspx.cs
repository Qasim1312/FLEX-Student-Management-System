using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class course_allocation_rep : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        // Clear any previous response
         Response.Clear();
        // Query to get all offered courses
        string query = "SELECT s.roll, s.Fname, s.Lname, s.email, se.section, c.course_name\r\nFROM (\r\n  SELECT r.student_roll, r.course_id\r\n  FROM registered r\r\n  JOIN student s ON r.student_roll = s.roll\r\n  JOIN sections se ON s.section = se.section\r\n  WHERE se.section = 'CS-4A'\r\n) AS rc\r\nJOIN student s ON rc.student_roll = s.roll\r\nJOIN sections se ON s.section = se.section\r\nJOIN course c ON rc.course_id = c.code\r\nWHERE se.section = 'CS-4A'\r\nORDER BY s.roll, c.course_name;\r\n";
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-UNH3EMQ\\SQLEXPRESS;Initial Catalog=flex;Integrated Security=True");
        SqlCommand cmd = new SqlCommand(query, conn);
        conn.Open();
        SqlDataReader reader = cmd.ExecuteReader();

        // Create an HTML string builder
        StringBuilder html = new StringBuilder();

        // Add HTML header
        html.Append("<html><body>");
        html.Append("<h1>Course Allocation Report</h1>");

        // Add table header
        html.Append("<table>");
        html.Append("<tr>");
        html.Append("<th>Roll number</th>");
        html.Append("<th>First Name</th>");
        html.Append("<th>Last Name</th>");
        html.Append("<th>Email </th>");
        html.Append("<th>Section</th>");
        html.Append("<th>Course Name</th>");

        html.Append("</tr>");

        // Add rows dynamically based on query results
        while (reader.Read())
        {
            html.Append("<tr>");
            html.Append("<td>" + reader["roll"] + "</td>");
            html.Append("<td>" + reader["Fname"] + "</td>");
            html.Append("<td>" + reader["Lname"] + "</td>");
            html.Append("<td>" + reader["email"] + "</td>");
            html.Append("<td>" + reader["section"] + "</td>");
         
            // Check if the student is assigned to any courses
            if (!reader.IsDBNull(reader.GetOrdinal("course_name")))
            {
                html.Append("<td>" + reader["course_name"] + "</td>");
            }
            else
            {
                html.Append("<td>No courses assigned</td>");
            }

            html.Append("</tr>");
        }

        // Close table and HTML
        html.Append("</table>");
        html.Append("</body></html>");

        // Load HTML string into Response object
        Response.Write(html.ToString());


    }
}