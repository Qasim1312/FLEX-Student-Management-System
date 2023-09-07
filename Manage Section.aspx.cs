using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manage_Section : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void backButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("admin main.aspx");
    }
    protected void AddSection_Click(object sender, EventArgs e)
    {
        Response.Redirect("add section.aspx");
    }

    protected void DeleteSection_Click(object sender, EventArgs e)
    {
        Response.Redirect("delete section.aspx");
    }

    protected void SectionA_Click(object sender, EventArgs e)
    {
        Response.Redirect("Section A.aspx");
    }

    protected void SectionB_Click(object sender, EventArgs e)
    {
        Response.Redirect("Section B.aspx");
    }
}