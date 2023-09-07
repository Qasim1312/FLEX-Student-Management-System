using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class feedback_report : System.Web.UI.Page
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
        string query = "SELECT * \r\nFROM feedback\r\nWHERE teacher_id ='" + users_id + "'";
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-UNH3EMQ\\SQLEXPRESS;Initial Catalog=flex;Integrated Security=True");
        SqlCommand cmd = new SqlCommand(query, conn);
        conn.Open();
        SqlDataReader reader = cmd.ExecuteReader();

        // Create an HTML string builder
        StringBuilder html = new StringBuilder();

        // Add HTML header
        html.Append("<html><body>");
        html.Append("<h1>Student FeedBack Report</h1>");

        // Add table header    
        html.Append("<table>");
        html.Append("<tr>");
        html.Append("<th>Student Roll</th>");
        html.Append("<th>Teacher ID</th>");
        html.Append("<th>Course Code</th>");
        html.Append("<th>Ratings</th>");
        html.Append("<th>Questions</th>");
        html.Append("</tr>");

        // Add rows dynamically     
        while (reader.Read())
        {

            html.Append("<tr>");
            html.Append("<td>" + reader["student_roll"] + "</td>");
            html.Append("<td>" + reader["teacher_id"] + "</td>");
            html.Append("<td>" + reader["course_id"] + "</td>");
      
            // Check if the student is assigned to any courses
            if (!reader.IsDBNull(reader.GetOrdinal("rating")))
            {
                html.Append("<td '>" + reader["rating"] + "</td>");
            }
            else
            {
                html.Append("<td>No Ratings</td>");
            }
            if (!reader.IsDBNull(reader.GetOrdinal("rtype")))
            {
                html.Append("<td>" + reader["rtype"] + "</td>");
            }
            else
            {
                html.Append("<td>No Ratings</td>");
            }

            html.Append("</tr>");

        }

        // Close table and HTML    
        html.Append("</table>");
        html.Append("</body></html>");

        // Load HTML string  
        Response.Write(html.ToString());

    }
}