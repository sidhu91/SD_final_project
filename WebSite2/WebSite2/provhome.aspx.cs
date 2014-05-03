using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class provhome : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Response.Redirect("viewreqfromxml.aspx");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("dispreq.aspx");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("mysubsc.aspx");
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("submitserv.aspx");
    }
}