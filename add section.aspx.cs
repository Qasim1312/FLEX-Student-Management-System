using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class add_section : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void SubmitData(object sender, EventArgs e)
{
    /*int counter = int.Parse(entryCounter.Text);
    counter++;
    entryCounter.Text = counter.ToString();

    // Add your logic to save the entered data here

    if (counter >= 10)
    {
        entryPrompt.Visible = false;
    }

    if (counter >= 50)
    {
        submitButton.Enabled = false;
    } */
}

    protected void AddCourse(object sender, EventArgs e)
    {
        // Check that the section name is not empty
        if (string.IsNullOrEmpty(sectionNameTextBox.Text))
        {
            courseAddedPrompt.Text = "Please enter a section name.";
            courseAddedPrompt.ForeColor = System.Drawing.Color.Red;
            courseAddedPrompt.Visible = true;
            return;
        }

        // Check that the source section name is not empty
        if (string.IsNullOrEmpty(studentRollNumberTextBox.Text))
        {
            courseAddedPrompt.Text = "Please enter a source section name.";
            courseAddedPrompt.ForeColor = System.Drawing.Color.Red;
            courseAddedPrompt.Visible = true;
            return;
        }

        // Check that the source section exists and has more than 20 students
        int sourceSectionCount = 0;
        using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-UNH3EMQ\\SQLEXPRESS;Initial Catalog=flex;Integrated Security=True"))
        {
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM student WHERE section = @sourceSectionName", connection);
            command.Parameters.AddWithValue("@sourceSectionName", studentRollNumberTextBox.Text);
            sourceSectionCount = (int)command.ExecuteScalar();
        }
        if (sourceSectionCount < 20)
        {
            courseAddedPrompt.Text = "The source section does not have enough students.";
            courseAddedPrompt.ForeColor = System.Drawing.Color.Red;
            courseAddedPrompt.Visible = true;
            return;
        }

        // Check that the new section name does not already exist in the database
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
        if (sectionExists)
        {
            courseAddedPrompt.Text = "A section with this name already exists.";
            courseAddedPrompt.ForeColor = System.Drawing.Color.Red;
            courseAddedPrompt.Visible = true;
            return;
        }

        // Add the new section to the database
        using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-UNH3EMQ\\SQLEXPRESS;Initial Catalog=flex;Integrated Security=True"))
        {
            connection.Open();
            SqlCommand command = new SqlCommand("INSERT INTO sections (section) VALUES (@sectionName)", connection);
            command.Parameters.AddWithValue("@sectionName", sectionNameTextBox.Text);
            int rowsAffected = command.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                // Get the last 10 students from the source section and assign them to the new section
                command = new SqlCommand("SELECT TOP 10 roll FROM (SELECT TOP 10 * FROM student WHERE section = @sourceSectionName ORDER BY roll DESC) sub ORDER BY roll ASC", connection);
                command.Parameters.AddWithValue("@sourceSectionName", studentRollNumberTextBox.Text);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string roll = reader.GetString(0);

                        // Create a new SqlConnection object for the update command
                        using (SqlConnection updateConnection = new SqlConnection("Data Source=DESKTOP-UNH3EMQ\\SQLEXPRESS;Initial Catalog=flex;Integrated Security=True"))
                        {
                            updateConnection.Open();
                            SqlCommand assignCommand = new SqlCommand("UPDATE student SET section = @sectionName WHERE roll = @roll", updateConnection);
                            assignCommand.Parameters.AddWithValue("@sectionName", sectionNameTextBox.Text);
                            assignCommand.Parameters.AddWithValue("@roll", roll);
                            assignCommand.ExecuteNonQuery();
                        }
                    }
                }

            }
        }
    }
    protected void backButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("admin main.aspx");
    }
}