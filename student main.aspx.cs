using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class student_main : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FetchUserInfo();
        }
    }
    protected void RedirectToWeb(object sender, EventArgs e)
    {
        Response.Redirect("generic.aspx");
    }
    protected void RedirectToMarks(object sender, EventArgs e)
    {
        Response.Redirect("student marks.aspx");
    }
    protected void RedirectToAttend(object sender, EventArgs e)
    {
        Response.Redirect("student attend.aspx");
    }
    protected void RedirectToTranscript(object sender, EventArgs e)
    {
        Response.Redirect("transcript.aspx");
    }
    protected void RedirectToFeedback(object sender, EventArgs e)
    {
        Response.Redirect("Assessment.aspx");
    }
    protected void RedirectToLog(object sender, EventArgs e)
    {
        prompt.Visible = true;
        timer.Enabled = true;
    }

    protected void timer_Tick(object sender, EventArgs e)
    {
        timer.Enabled = false;
        prompt.Visible = false;
        Response.Redirect("generic.aspx");
    }
    private void FetchUserInfo()
    {
        if (Session["users_id"] == null)
        {
            // Redirect the user to the previous page or display an error message.
            return;
        }

        string users_id = Session["users_id"].ToString();
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-UNH3EMQ\\SQLEXPRESS;Initial Catalog=flex;Integrated Security=True"); // Connection String
        conn.Open();
        // MessageBox.Show("Connection Open");
        SqlCommand cm;
        string query = "SELECT roll, Fname, Lname, email, cnic, phone, users_id, gender, batch, section, DoB, Father_Name FROM student WHERE users_id = @users_id";
        SqlCommand command = new SqlCommand(query, conn);
        command.Parameters.AddWithValue("@users_id", users_id);
        SqlDataReader reader = command.ExecuteReader();

        if (reader.Read())
        {
            RollNumberDTextBox.Text = reader["roll"].ToString();
            FirstNameTextBox.Text = reader["Fname"].ToString();
            LastNameTextBox.Text = reader["Lname"].ToString();
            EmailTextBox.Text = reader["email"].ToString();
            CNICTextBox.Text = reader["cnic"].ToString();
            ContactNumberTextBox.Text = reader["phone"].ToString();
            UserIDTextBox.Text = reader["users_id"].ToString();
            GenderTextBox.Text = reader["gender"].ToString();
            BatchTextBox.Text = reader["batch"].ToString();
            SectionTextBox.Text = reader["section"].ToString();
            DOBTextBox.Text = reader["DoB"].ToString();
            FatherNameTextBox.Text = reader["Father_Name"].ToString();

            string enteredStudentID = RollNumberDTextBox.Text;
            Session["users_id2"] = enteredStudentID;
        }
        else
        {
            // Display an error message or handle the case when user information is not found.
        }
    }

}