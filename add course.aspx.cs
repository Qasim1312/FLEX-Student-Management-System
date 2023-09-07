using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;


public partial class add_course : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void AddCourse(object sender, EventArgs e)
    {
        string connectionString = "Data Source=DESKTOP-UNH3EMQ\\SQLEXPRESS;Initial Catalog=flex;Integrated Security=True";

        try
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Check if the course code already exists
                string checkCourseCodeQuery = "SELECT COUNT(*) FROM course WHERE code = @CourseCode;";
                using (SqlCommand checkCourseCodeCmd = new SqlCommand(checkCourseCodeQuery, conn))
                {
                    checkCourseCodeCmd.Parameters.AddWithValue("@CourseCode", courseCode.Text);

                    int count = (int)checkCourseCodeCmd.ExecuteScalar();
                    if (count > 0)
                    {
                        courseAddedPrompt.Text = "Course code already exists.";
                        courseAddedPrompt.Visible = true;
                        timer.Enabled = true;
                        return;
                    }
                }

                int coordinatorIdInt;
                if (!int.TryParse(coordinatorId.Text, out coordinatorIdInt))
                {
                    courseAddedPrompt.Text = "Coordinator ID must be an integer.";
                    courseAddedPrompt.Visible = true;
                    timer.Enabled = true;
                    return;
                }

                // Check if the coordinator_id exists in the faculty table
                string checkCoordinatorIdQuery = "SELECT teacher_id FROM faculty WHERE teacher_id = @CoordinatorId;";
                using (SqlCommand checkCoordinatorIdCmd = new SqlCommand(checkCoordinatorIdQuery, conn))
                {
                    checkCoordinatorIdCmd.Parameters.AddWithValue("@CoordinatorId", coordinatorIdInt);

                    SqlDataReader reader = checkCoordinatorIdCmd.ExecuteReader();
                    if (!reader.HasRows)
                    {
                        courseAddedPrompt.Text = "Coordinator ID not found.";
                        courseAddedPrompt.Visible = true;
                        timer.Enabled = true;
                        reader.Close();
                        return;
                    }
                    reader.Close();
                }

                // Insert the new course
                string insertCourseQuery = "INSERT INTO course (code, course_name, course_type, credit_hours, coordinator_id) VALUES (@Code, @CourseName, @CourseType, @CreditHours, @CoordinatorId);";
                using (SqlCommand insertCourseCmd = new SqlCommand(insertCourseQuery, conn))
                {
                    insertCourseCmd.Parameters.AddWithValue("@Code", courseCode.Text);
                    insertCourseCmd.Parameters.AddWithValue("@CourseName", courseName.Text);
                    insertCourseCmd.Parameters.AddWithValue("@CourseType", courseType.Text);
                    insertCourseCmd.Parameters.AddWithValue("@CreditHours", creditHours.Text);
                    insertCourseCmd.Parameters.AddWithValue("@CoordinatorId", coordinatorIdInt);

                    int rowsAffected = insertCourseCmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        courseAddedPrompt.Text = "Course added.";
                    }
                    else
                    {
                        courseAddedPrompt.Text = "Failed to add course.";
                    }
                }
            }
        }
        catch (Exception ex)
        {
            courseAddedPrompt.Text = "Error: " + ex.Message;
            courseAddedPrompt.Visible = true;
            timer.Enabled = true;
        }

        courseAddedPrompt.Visible = true;
        timer.Enabled = true;
    }



    protected void timer_Tick(object sender, EventArgs e)
    {
        timer.Enabled = false;
        courseAddedPrompt.Visible = false;
    }
    protected void backButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("admin main.aspx");
    }
}