using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class faculty_report : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void attendButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("faculty attend.aspx");
    }
    protected void evaluationButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("evaluation report.aspx");
    }
    protected void gradeButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("grade report.aspx");
    }

    protected void countButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("count grade report.aspx");
    }

    protected void feedbackButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("feedback report.aspx");
    }
    protected void backButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("faculty main.aspx");
    }
}