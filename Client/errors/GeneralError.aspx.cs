using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class errors_GeneralError : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
     //Check if the error is within querystring
        if (Request.QueryString["Message"] != null)
        {
            lblMessage.InnerText = Convert.ToString(Request.QueryString["Message"]);
        }
    }
}
