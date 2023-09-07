using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class student_section_rep : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        // Clear any previous response
        Response.Clear();
        // Query to get all offered courses
        string query = "SELECT * FROM student where section='CS-4A'";
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-UNH3EMQ\\SQLEXPRESS;Initial Catalog=flex;Integrated Security=True");
        SqlCommand cmd = new SqlCommand(query, conn);
        conn.Open();
        SqlDataReader reader = cmd.ExecuteReader();

        // Create an HTML string builder
        StringBuilder html = new StringBuilder(); 

        // Add HTML header
        html.Append("<html><body>");
        html.Append("<h1>Student Section Report</h1>");

        // Add table header
        html.Append("<table>");
        html.Append("<tr>");
        html.Append("<th>Roll number</th>");
        html.Append("<th>First Name</th>");
        html.Append("<th>Last Name</th>");
        html.Append("<th>Email </th>");
        html.Append("<th>CNIC</th>");
        html.Append("<th>Phone Number</th>");
        html.Append("<th>Batch</th>");
        html.Append("<th>Section</th>");
        html.Append("<th>Date of Birth</th>");
        html.Append("<th>Gender</th>");
        html.Append("<th>Father Name</th>");
        html.Append("<th>User ID</th>");

        html.Append("</tr>");

        // Add rows dynamically based on query results
        while (reader.Read())
        {
            html.Append("<tr>");
            html.Append("<td>" + reader["roll"] + "</td>");
            html.Append("<td>" + reader["Fname"] + "</td>");
            html.Append("<td>" + reader["Lname"] + "</td>");
            html.Append("<td>" + reader["email"] + "</td>");
            html.Append("<td>" + reader["cnic"] + "</td>");
            html.Append("<td>" + reader["phone"] + "</td>");
            html.Append("<td>" + reader["batch"] + "</td>");
            html.Append("<td>" + reader["section"] + "</td>");
            html.Append("<td>" + reader["DoB"] + "</td>");
            html.Append("<td>" + reader["gender"] + "</td>");
            html.Append("<td>" + reader["Father_Name"] + "</td>");
            html.Append("<td>" + reader["users_id"] + "</td>");
          
            html.Append("</tr>");
        }

        // Close table and HTML
        html.Append("</table>");
        html.Append("</body></html>");

        // Load HTML string into Response object
        Response.Write(html.ToString());

    }
}