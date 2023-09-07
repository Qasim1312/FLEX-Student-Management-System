using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class student_marks : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["users_id2"] == null)
        {
            // Redirect the user to the previous page or display an error message.
            return;
        }

        string users_id = Session["users_id2"].ToString();
        // Clear any previous response
        Response.Clear();
        // Query to get all offered courses
        string query = "SELECT s.roll, s.Fname, s.Lname, c.course_name, sw.obtained, e.total\r\nFROM student s\r\nJOIN registered r ON s.roll = r.student_roll\r\nJOIN evaluation e ON r.course_id = e.course_id\r\nJOIN student_work sw ON s.roll = sw.student_roll AND e.eid = sw.eval_id\r\nJOIN course c ON r.course_id = c.code\r\nWHERE s.roll = '" + users_id + "'\r\nGROUP BY s.roll, s.Fname, s.Lname, c.course_name, sw.obtained, e.total";
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-UNH3EMQ\\SQLEXPRESS;Initial Catalog=flex;Integrated Security=True");
        SqlCommand cmd = new SqlCommand(query, conn);
        conn.Open();
        SqlDataReader reader = cmd.ExecuteReader();

        // Create an HTML string builder
        StringBuilder html = new StringBuilder();

        // Add HTML header
        html.Append("<html><body>");
        html.Append("<h1>Student Total Marks</h1>");

        // Add table header
        html.Append("<table>");
        html.Append("<tr>");
        html.Append("<th>Roll number</th>");
        html.Append("<th>First Name</th>");
        html.Append("<th>Last Name</th>");
        html.Append("<th>Course Name </th>");
        html.Append("<th>Obtained Marks</th>");
        html.Append("<th>Total Marks</th>");

        html.Append("</tr>");

        // Add rows dynamically based on query results
        while (reader.Read())
        {
            html.Append("<tr>");
            html.Append("<td>" + reader["roll"] + "</td>");
            html.Append("<td>" + reader["Fname"] + "</td>");
            html.Append("<td>" + reader["Lname"] + "</td>");
            html.Append("<td>" + reader["course_name"]+ "&nbsp;"+ "</td>");
            html.Append("<td style='padding-left: 30px;'>" + reader["obtained"] + "</td>");
            html.Append("<td style='padding-left: 10px;'>" + reader["total"] + "</td>");

            html.Append("</tr>");
        }

        // Close table and HTML
        html.Append("</table>");
        html.Append("</body></html>");

        // Load HTML string into Response object
        Response.Write(html.ToString());

    }
}