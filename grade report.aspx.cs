using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class grade_report : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Clear any previous response
        Response.Clear();

        // Query to get all offered courses
        string query = "SELECT course.course_name, SUM(gt_tbl.grand_total) AS student_grand_total " +
                       "FROM ( " +
                       "SELECT (SUM(tbl.obtained*tbl.weightage)/SUM(tbl.total)) AS grand_total, tbl.e_type, evaluation.course_id " +
                       "FROM ( " +
                       "SELECT evaluation.eid, evaluation.tid, eval_type.tid AS e_type, student_work.obtained, evaluation.total, evaluation.weightage " +
                       "FROM student_work " +
                       "INNER JOIN evaluation ON student_work.eval_id = evaluation.eid " +
                       "INNER JOIN eval_type ON evaluation.tid = eval_type.etype " +
                       "WHERE student_work.student_roll = '21i-7421' AND evaluation.course_id = 'CS-2048' " +
                       ") AS tbl " +
                       "INNER JOIN evaluation ON tbl.eid = evaluation.eid " +
                       "GROUP BY tbl.e_type, evaluation.course_id " +
                       ") AS gt_tbl " +
                       "INNER JOIN course ON course.code = gt_tbl.course_id " +
                       "GROUP BY course.course_name";

        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-UNH3EMQ\\SQLEXPRESS;Initial Catalog=flex;Integrated Security=True");
        SqlCommand cmd = new SqlCommand(query, conn);
        conn.Open();
        SqlDataReader reader = cmd.ExecuteReader();

        // Create an HTML string builder
        StringBuilder html = new StringBuilder();

        // Add HTML header
        html.Append("<html><body>");
        html.Append("<h1>Per Subject Grand Total Marks</h1>");

        // Add table header
        html.Append("<table>");
        html.Append("<tr>");
        html.Append("<th>Course Name</th>");
        html.Append("<th>Grand Total Marks</th>");
        html.Append("</tr>");

        // Add rows dynamically based on query results
        while (reader.Read())
        {
            html.Append("<tr>");
            html.Append("<td>" + reader["course_name"] + "</td>");
            html.Append("<td style='padding-left: 50px'>" + reader["student_grand_total"] + "</td>");
            html.Append("</tr>");
        }

        // Close table and HTML
        html.Append("</table>");
        html.Append("</body></html>");

        // Load HTML string into Response object
        Response.Write(html.ToString());

    }
}