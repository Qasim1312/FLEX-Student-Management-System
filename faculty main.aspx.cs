using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class faculty_main : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FetchUserInfo();
        }
    }
    protected void RedirectToCourses(object sender, EventArgs e)
    {
        Response.Redirect("assigned courses.aspx");
    }
    protected void RedirectToAttend(object sender, EventArgs e)
    {
        Response.Redirect("take attendance.aspx");
    }
    protected void RedirectToReport(object sender, EventArgs e)
    {
        Response.Redirect("faculty report.aspx");
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
       string enteredUserID = users_id;
        //Session["users_id1"] = enteredUserID;
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-UNH3EMQ\\SQLEXPRESS;Initial Catalog=flex;Integrated Security=True"); // Connection String
        conn.Open();
        // MessageBox.Show("Connection Open");
        SqlCommand cm;
        string query = "SELECT Teacher_id, Fname, Lname, email, cnic, phone, users_id FROM faculty WHERE users_id = @users_id";
        SqlCommand command = new SqlCommand(query, conn);
        command.Parameters.AddWithValue("@users_id", users_id);
        SqlDataReader reader = command.ExecuteReader();

        if (reader.Read())
        {
            TeacherIDTextBox.Text = reader["Teacher_id"].ToString();
            FirstNameTextBox.Text = reader["Fname"].ToString();
            LastNameTextBox.Text = reader["Lname"].ToString();
            EmailTextBox.Text = reader["email"].ToString();
            CNICTextBox.Text = reader["cnic"].ToString();
            ContactNumberTextBox.Text = reader["phone"].ToString();
            UserIDTextBox.Text = reader["users_id"].ToString();

            string enteredTeacherID = TeacherIDTextBox.Text;
            Session["users_id1"] = enteredTeacherID;
        }
        else
        {
            // Display an error message or handle the case when user information is not found.
        }
    }
}