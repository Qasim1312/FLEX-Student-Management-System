using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Offered_courses1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Clear any previous response
        Response.Clear();
        // Query to get all offered courses
        string query = "SELECT * FROM course";
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-UNH3EMQ\\SQLEXPRESS;Initial Catalog=flex;Integrated Security=True");
        SqlCommand cmd = new SqlCommand(query, conn);
        conn.Open();
        SqlDataReader reader = cmd.ExecuteReader();

        // Create an HTML string builder
        StringBuilder html = new StringBuilder();

        // Add HTML header
        html.Append("<html><body>");
        html.Append("<h1>Offered Courses Report</h1>");

        // Add table header
        html.Append("<table>");
        html.Append("<tr>");
        html.Append("<th>Course ID</th>");
        html.Append("<th>Course Name</th>");
        html.Append("<th>Coordinator ID</th>");
        html.Append("<th>Course Type</th>");
        html.Append("<th>Credit Hours</th>");
        html.Append("</tr>");

        // Add rows dynamically based on query results
        while (reader.Read())
        {
            html.Append("<tr>");
            html.Append("<td>" + reader["code"] + "</td>");
            html.Append("<td>" + reader["course_name"] + "</td>");
            html.Append("<td>" + reader["coordinator_id"] + "</td>");
            html.Append("<td>" + reader["course_type"] + "</td>");
            html.Append("<td>" + reader["credit_hours"] + "</td>");
            html.Append("</tr>");
        }

        // Close table and HTML
        html.Append("</table>");
        html.Append("</body></html>");

        // Load HTML string into Response object
        Response.Write(html.ToString());


    }
}