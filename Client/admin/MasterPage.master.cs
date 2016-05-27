using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;

public partial class admin_MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["admin"] != null && Session["admin"].ToString() == "admin")
        {
        }
        else if (Session["admin"] == null)
            Response.Redirect("../admin/Default.aspx");

    }
    protected void Unnamed1_Click(object sender, ImageClickEventArgs e)
    {
        Session.Abandon();
        //Session.Clear();
        Session["admin"] = "";
        Response.Redirect("../admin/Default.aspx");
    }
}
