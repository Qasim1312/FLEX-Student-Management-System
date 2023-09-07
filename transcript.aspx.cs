using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class transcript : System.Web.UI.Page
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
        string query = "SELECT c.code AS course_code,  \r\n       c.course_name,       \r\n       CASE \r\n          WHEN SUM(e.obtained)/SUM(ev.total)*100 >= 90 THEN 'A+'   \r\n          WHEN SUM(e.obtained)/SUM(ev.total)*100 BETWEEN 86 AND 89 THEN 'A'\r\n\t\t   WHEN SUM(e.obtained)/SUM(ev.total)*100 BETWEEN 82 AND 85 THEN 'A-'\r\n          WHEN SUM(e.obtained)/SUM(ev.total)*100 BETWEEN 78 AND 81 THEN 'B+' \r\n          WHEN SUM(e.obtained)/SUM(ev.total)*100 BETWEEN 74 AND 77 THEN 'B'\r\n          WHEN SUM(e.obtained)/SUM(ev.total)*100 BETWEEN 70 AND 73 THEN 'B-' \r\n          WHEN SUM(e.obtained)/SUM(ev.total)*100 BETWEEN 66 AND 69 THEN 'C+'\r\n          WHEN SUM(e.obtained)/SUM(ev.total)*100 BETWEEN 62 AND 65 THEN 'C'\r\n          WHEN SUM(e.obtained)/SUM(ev.total)*100 BETWEEN 58 AND 61 THEN 'C-'\r\n          WHEN SUM(e.obtained)/SUM(ev.total)*100 BETWEEN 54 AND 57 THEN 'D+'\r\n          WHEN SUM(e.obtained)/SUM(ev.total)*100 BETWEEN 50 AND 53 THEN 'D'\r\n          \r\n          ELSE 'F'  \r\n       END AS letter_grade\r\nFROM student_work e  \r\nJOIN evaluation ev ON e.eval_id = ev.eid    \r\nJOIN course c ON ev.course_id = c.code\r\nWHERE e.student_roll = '" + users_id + "'      \r\nGROUP BY c.code, c.course_name       \r\nORDER BY course_code;";
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-UNH3EMQ\\SQLEXPRESS;Initial Catalog=flex;Integrated Security=True");
        SqlCommand cmd = new SqlCommand(query, conn);
        conn.Open();
        SqlDataReader reader = cmd.ExecuteReader();

        // Create an HTML string builder
        StringBuilder html = new StringBuilder();

        // Add HTML header
        html.Append("<html><body>");
        html.Append("<h1>Student Transcript </h1>");

        // Add table header
        html.Append("<table>");
        html.Append("<tr>");
        html.Append("<th>Course Code</th>");
        html.Append("<th>Course Name</th>");
        html.Append("<th>Letter Grade</th>");
        

        html.Append("</tr>");

        // Add rows dynamically based on query results
        while (reader.Read())
        {
            html.Append("<tr>");
            html.Append("<td>" + reader["course_code"] + "</td>");
            html.Append("<td>" + reader["course_name"] + "</td>");
            html.Append("<td style='padding-left:25px' >" + reader["letter_grade"] + "</td>");
           

           
            html.Append("</tr>");
        }

        // Close table and HTML
        html.Append("</table>");
        html.Append("</body></html>");

        // Load HTML string into Response object
        Response.Write(html.ToString());


    }

}
