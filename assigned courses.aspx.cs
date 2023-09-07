using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class assigned_courses : System.Web.UI.Page
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
        string query = "SELECT f.Fname, f.Lname, c.course_name FROM faculty f JOIN teaches t ON f.Teacher_id = t.teacher_id JOIN course c ON t.course_id = c.code WHERE f.Teacher_id ='" + users_id + "'";
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-UNH3EMQ\\SQLEXPRESS;Initial Catalog=flex;Integrated Security=True");
        SqlCommand cmd = new SqlCommand(query, conn);
        conn.Open();
        SqlDataReader reader = cmd.ExecuteReader();

        // Create an HTML string builder
        StringBuilder html = new StringBuilder();

        // Add HTML header
        html.Append("<html><body>");
        html.Append("<h1>Teacher All Assigned Courses</h1>");

        // Add table header
        html.Append("<table>");
        html.Append("<tr>");
        html.Append("<th>First Name</th>");
        html.Append("<th>Last Name</th>");
        html.Append("<th>Course Name </th>");

        html.Append("</tr>");

        // Add rows dynamically based on query results
        while (reader.Read())
        {
            html.Append("<tr>");
          
            html.Append("<td>" + reader["Fname"] + "</td>");
            html.Append("<td>" + reader["Lname"] + "</td>");
            html.Append("<td>" + reader["course_name"] + "</td>");
           

            html.Append("</tr>");
        }

        // Close table and HTML
        html.Append("</table>");
        html.Append("</body></html>");

        // Load HTML string into Response object
        Response.Write(html.ToString());


    }
}