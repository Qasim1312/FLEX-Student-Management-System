using System;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class delete_course : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void DeleteCourse(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-UNH3EMQ\\SQLEXPRESS;Initial Catalog=flex;Integrated Security=True"); // Connection String
        {
            conn.Open();

            // Check if the course code exists
            string checkCourseCodeQuery = "SELECT COUNT(*) FROM course WHERE code = @CourseCode;";
            using (SqlCommand checkCourseCodeCmd = new SqlCommand(checkCourseCodeQuery, conn))
            {
                checkCourseCodeCmd.Parameters.AddWithValue("@CourseCode", courseId.Text);

                int count = (int)checkCourseCodeCmd.ExecuteScalar();
                if (count == 0)
                {
                    courseDeletedPrompt.Text = "Course ID not found.";
                    courseDeletedPrompt.Visible = true;
                    timer.Enabled = true;
                    return;
                }
            }

            // Delete the course
            string deleteCourseQuery = "DELETE FROM course WHERE code = @CourseCode;";
            using (SqlCommand deleteCourseCmd = new SqlCommand(deleteCourseQuery, conn))
            {
                deleteCourseCmd.Parameters.AddWithValue("@CourseCode", courseId.Text);

                int rowsAffected = deleteCourseCmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    courseDeletedPrompt.Text = "Course deleted.";
                }
                else
                {
                    courseDeletedPrompt.Text = "Failed to delete course.";
                }
            }
        }

        courseDeletedPrompt.Visible = true;
        timer.Enabled = true;
    }

    protected void timer_Tick(object sender, EventArgs e)
    {
        timer.Enabled = false;
        courseDeletedPrompt.Visible = false;
    }
    protected void backButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("admin main.aspx");
    }
}
