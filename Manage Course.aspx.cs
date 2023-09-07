using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manage_Course : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void addButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("add course.aspx");
    }

    protected void deleteButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("delete course.aspx");
    }

    protected void assignButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("assign course.aspx");
    }
    protected void backButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("admin main.aspx");
    }
}