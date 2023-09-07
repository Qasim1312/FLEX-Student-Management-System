using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class generic : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void studentButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("student login.aspx");
    }

    protected void facultyButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("faculty login.aspx");
    }

    protected void adminButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("admin first.aspx");
    }
}