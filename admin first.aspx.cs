using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class first : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public static int GenerateRandomNumber()
    {
        Random rand = new Random();
        int randomNumber = rand.Next(1, 101);
        return randomNumber;
    }
    protected void logButton_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-UNH3EMQ\\SQLEXPRESS;Initial Catalog=flex;Integrated Security=True"); //Connection String
        conn.Open();
        // MessageBox.Show("Connection Open");
        SqlCommand cm;
        string un = login_username.Text;
        string pass = login_password.Text;
        // Assuming the users_id is entered in a TextBox with ID "EnteredUserIDTextBox"
        string enteredUserID = login_username.Text;
        Session["users_id"] = enteredUserID;

        string query = "select * from users where users_id='" + un + "'and password='" + pass + "';";
        cm = new SqlCommand(query, conn);
        SqlDataReader reader_ = cm.ExecuteReader();
        if (reader_.Read())
        {
            // MessageBox.Show("Logged in");
            lblMessage.Text = "Logged in";
            Response.Redirect("admin main.aspx");
        }
        else
        {
            // MessageBox.Show("Invalid data entry");
            lblMessage.Text = "Invalid data entry";
        }
        reader_.Close();
        // cm.ExecuteNonQuery();
        cm.Dispose();
        conn.Close();
        // Application.Exit();
    }
    protected void SignButton_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-UNH3EMQ\\SQLEXPRESS;Initial Catalog=flex;Integrated Security=True"); //Connection String
        conn.Open();
        SqlCommand cm;
        SqlCommand cm1;
        string un = sign_username.Text;
        string pass = sign_password.Text;
        string enteredUserID = sign_username.Text;
        Session["users_id"] = enteredUserID;
        string userType = "Academic Officers";
        string Fname = this.Fname.Text;
        string Lname = this.Lname.Text;
        string email = this.email.Text;
        string cnic = this.cnic.Text;
        string phone = this.phone.Text;
        string admin_id = this.admin_id.Text;
        // Insert query to store data into the "users" table
        string query = "INSERT INTO users (users_id, password, user_type) VALUES (@UsersId, @Password, @UserType);";
        string query1 = "INSERT INTO academics (admin_id,Fname,Lname,email,cnic,phone,users_id) VALUES (@admin_id, @Fname, @Lname, @email, @cnic, @phone, @users_id);";
        cm = new SqlCommand(query, conn);
        cm.Parameters.AddWithValue("@UsersId", un);
        cm.Parameters.AddWithValue("@Password", pass);
        cm.Parameters.AddWithValue("@UserType", userType);
        cm1 = new SqlCommand(query1, conn);
        // Add parameters to the SqlCommand to prevent SQL Injection
        cm1.Parameters.AddWithValue("@admin_id", admin_id);
        cm1.Parameters.AddWithValue("@Fname", Fname);
        cm1.Parameters.AddWithValue("@Lname", Lname);
        cm1.Parameters.AddWithValue("@cnic", cnic);
        cm1.Parameters.AddWithValue("@email", email);
        cm1.Parameters.AddWithValue("@phone", phone);
        cm1.Parameters.AddWithValue("@users_id", un);

        // Execute the queries
        int rowsAffected = cm.ExecuteNonQuery();
        int rowsAffected1 = cm1.ExecuteNonQuery();
        if (rowsAffected > 0 && rowsAffected1 > 0)
        {
            lblMessage1.Text = "User successfully registered.";
            Response.Redirect("admin main.aspx");
        }
        else
        {
            lblMessage1.Text = "Registration failed.";
        }

        cm.Dispose();
        cm1.Dispose();
        conn.Close();
    }


}