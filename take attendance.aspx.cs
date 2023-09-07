using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class student_attend : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Nothing to do on first load.
        }
    }

    protected void LoadStudents(object sender, EventArgs e)
    {
        string query = "SELECT student.roll AS student_roll, student.Fname, student.Lname FROM student JOIN registered ON student.roll = registered.student_roll JOIN teaches ON registered.course_id = teaches.course_id WHERE teaches.teacher_id = 824 AND teaches.course_id = 'CS-2048'";

        using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-UNH3EMQ\\SQLEXPRESS;Initial Catalog=flex;Integrated Security=True"))
        {
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    studentsRepeater.DataSource = reader;
                    studentsRepeater.DataBind();
                }
            }
        }
    }

    protected void SaveAllAttendance(object sender, EventArgs e)
    {
        DateTime dateParsed;
        if (DateTime.TryParseExact(datePicker.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateParsed))
        {
            string date = dateParsed.ToString("MM/dd/yyyy");
            string query = @"
            MERGE attendance AS target
            USING (SELECT @rollNumber AS student_roll, 'CS-2048' AS course_id, @date AS Attend_Date) AS source
            ON (target.student_roll = source.student_roll AND target.course_id = source.course_id AND target.Attend_Date = source.Attend_Date)
            WHEN MATCHED THEN
                UPDATE SET target.a_status = @status
            WHEN NOT MATCHED THEN
                INSERT (student_roll, course_id, Attend_Date, teacher_id, a_status)
                VALUES (source.student_roll, source.course_id, source.Attend_Date, 824, @status);";

            using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-UNH3EMQ\\SQLEXPRESS;Initial Catalog=flex;Integrated Security=True"))
            {
                conn.Open();
                foreach (RepeaterItem item in studentsRepeater.Items)
                {
                    string rollNumber = ((Label)item.FindControl("rollNumberLabel")).Text;
                    DropDownList statusDropDown = (DropDownList)item.FindControl("statusDropDown");
                    string status = statusDropDown.SelectedValue == "Present" ? "P" : "A";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@rollNumber", rollNumber);
                        cmd.Parameters.AddWithValue("@date", date);
                        cmd.Parameters.AddWithValue("@status", status);
                        cmd.ExecuteNonQuery();
                    }
                }
            }

            // JavaScript to show alert after saving changes
            ScriptManager.RegisterStartupScript(this, GetType(), "Saved", "alert('Attendance saved');", true);
        }
        else
        {
            // JavaScript to show alert if date format is incorrect
            ScriptManager.RegisterStartupScript(this, GetType(), "DateError", "alert('Date format is incorrect');", true);
        }
    }


}