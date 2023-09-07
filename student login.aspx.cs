using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class other_login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

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
            Response.Redirect("student main.aspx");
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
}
