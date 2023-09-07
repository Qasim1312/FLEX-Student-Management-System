using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class evaluation_report : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Clear any previous response
        Response.Clear();
        // Query to get all offered courses
        string query = "select evaluation.eid, evaluation.tid, eval_type.tid as e_type, student_work.obtained, evaluation.total, evaluation.weightage\r\nfrom student_work inner join evaluation on student_work.eval_id = evaluation.eid inner join eval_type on evaluation.tid = eval_type.etype\r\nwhere student_work.student_roll = '21i-7421' and evaluation.course_id = 'CS-2048';";
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-UNH3EMQ\\SQLEXPRESS;Initial Catalog=flex;Integrated Security=True");
        SqlCommand cmd = new SqlCommand(query, conn);
        conn.Open();
        SqlDataReader reader = cmd.ExecuteReader();

        // Create an HTML string builder
        StringBuilder html = new StringBuilder();

        // Add HTML header
        html.Append("<html><body>");
        html.Append("<h1>Student Evaluation Report</h1>");

        // Add table header
        html.Append("<table>");
        html.Append("<tr>");
        html.Append("<th>Evaluation ID</th>");
        html.Append("<th>Evaluation Type ID</th>");
        html.Append("<th>Obtained Marks</th>");
        html.Append("<th>Total Marks </th>");
        html.Append("<th>Weightage</th>");

        html.Append("</tr>");

        // Add rows dynamically based on query results
        while (reader.Read())
        {
            html.Append("<tr>");
            html.Append("<td>" + reader["eid"] + "</td>");
            html.Append("<td>" + reader["tid"] + "</td>");
            html.Append("<td>" + reader["obtained"] + "</td>");
            html.Append("<td>" + reader["total"] + "</td>");
            html.Append("<td>" + reader["weightage"] + "</td>");

            html.Append("</tr>");
        }

        // Close table and HTML
        html.Append("</table>");
        html.Append("</body></html>");

        // Load HTML string into Response object
        Response.Write(html.ToString());

    }
}