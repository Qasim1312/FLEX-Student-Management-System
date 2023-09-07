using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class assign_course : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void SubmitData(object sender, EventArgs e)
    {
        
    }
    protected void AddCourse(object sender, EventArgs e)
    {
        // Check that the course code is not empty
        if (string.IsNullOrEmpty(courseCodeTextBox.Text))
        {
            courseAddedPrompt.Text = "Please enter a course code.";
            courseAddedPrompt.ForeColor = System.Drawing.Color.Red;
            courseAddedPrompt.Visible = true;
            return;
        }

        // Check that the section name is not empty
        if (string.IsNullOrEmpty(sectionNameTextBox.Text))
        {
            courseAddedPrompt.Text = "Please enter a section name.";
            courseAddedPrompt.ForeColor = System.Drawing.Color.Red;
            courseAddedPrompt.Visible = true;
            return;
        }

        // Check that the section exists
        bool sectionExists = false;
        using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-UNH3EMQ\\SQLEXPRESS;Initial Catalog=flex;Integrated Security=True"))
        {
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM sections WHERE section = @sectionName", connection);
            command.Parameters.AddWithValue("@sectionName", sectionNameTextBox.Text);
            int count = (int)command.ExecuteScalar();
            if (count > 0)
            {
                sectionExists = true;
            }
        }
        if (!sectionExists)
        {
            courseAddedPrompt.Text = "The specified section does not exist.";
            courseAddedPrompt.ForeColor = System.Drawing.Color.Red;
            courseAddedPrompt.Visible = true;
            return;
        }
        // Assign about 10 students from the specified section to the specified course
        using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-UNH3EMQ\\SQLEXPRESS;Initial Catalog=flex;Integrated Security=True"))
        {
            connection.Open();
            // Get the last 10 students from the source section and assign them to the new course
            SqlCommand command = new SqlCommand("SELECT TOP 10 roll FROM (SELECT TOP 10 * FROM student WHERE section = @sourceSectionName ORDER BY roll DESC) sub ORDER BY roll ASC", connection);
            command.Parameters.AddWithValue("@sourceSectionName", sectionNameTextBox.Text);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    string roll = reader.GetString(0);
                    // Create a new SqlConnection object for the update command
                    using (SqlConnection updateConnection = new SqlConnection("Data Source=DESKTOP-UNH3EMQ\\SQLEXPRESS;Initial Catalog=flex;Integrated Security=True"))
                    {
                        updateConnection.Open();
                        SqlCommand assignCommand = new SqlCommand("INSERT INTO registered (student_roll, course_id) VALUES (@studentRoll, @courseCode)", updateConnection);
                        assignCommand.Parameters.AddWithValue("@studentRoll", roll);
                        assignCommand.Parameters.AddWithValue("@courseCode", courseCodeTextBox.Text);
                        assignCommand.ExecuteNonQuery();
                    }
                }
            }
        }

        // Display a success message
        courseAddedPrompt.Text = "Course added successfully.";
        courseAddedPrompt.ForeColor = System.Drawing.Color.Green;
        courseAddedPrompt.Visible = true;
       // await Task.Delay(5000);
        courseAddedPrompt.Visible = false;
    }
    protected void backButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("admin main.aspx");
    }

}