using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class delete_section : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void AddCourse(object sender, EventArgs e)
    {
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