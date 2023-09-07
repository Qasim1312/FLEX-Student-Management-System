using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_main : System.Web.UI.Page
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
    protected void RedirectToReport(object sender, EventArgs e)
    {
        Response.Redirect("admin report.aspx");
    }

    protected void RedirectToSection(object sender, EventArgs e)
    {
        Response.Redirect("Manage Section.aspx");
    }
    protected void RedirectToCourse(object sender, EventArgs e)
    {
        Response.Redirect("Manage Course.aspx");
    }
    private void ClearDisplayedData()
    {
        Session.Clear();
        Session.Abandon();
        AdminIDTextBox.Text = string.Empty;
        FirstNameTextBox.Text = string.Empty;
        LastNameTextBox.Text = string.Empty;
        EmailTextBox.Text = string.Empty;
        CNICTextBox.Text = string.Empty;
        ContactNumberTextBox.Text = string.Empty;
        UserIDTextBox.Text = string.Empty;
    }
    protected void RedirectToLog(object sender, EventArgs e)
    {
        ClearDisplayedData();
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
        string query = "SELECT admin_id, Fname, Lname, email, cnic, phone, users_id FROM academics WHERE users_id = @users_id";
        SqlCommand command = new SqlCommand(query, conn);
        command.Parameters.AddWithValue("@users_id", users_id);
        SqlDataReader reader = command.ExecuteReader();
        string enteredUserID = users_id;
        Session["users_id"] = enteredUserID;

        if (reader.Read())
        {
            AdminIDTextBox.Text = reader["admin_id"].ToString();
            FirstNameTextBox.Text = reader["Fname"].ToString();
            LastNameTextBox.Text = reader["Lname"].ToString();
            EmailTextBox.Text = reader["email"].ToString();
            CNICTextBox.Text = reader["cnic"].ToString();
            ContactNumberTextBox.Text = reader["phone"].ToString();
            UserIDTextBox.Text = reader["users_id"].ToString();
        }
        else
        {
            // Display an error message or handle the case when user information is not found.
        }
    }

}