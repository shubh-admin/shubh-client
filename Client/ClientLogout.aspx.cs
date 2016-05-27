using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using msdnh.util;
using msdnh.BF.MsDotnetHeaven;

public partial class ClientLogout : System.Web.UI.Page
{
    MsDotNetHeaven objMsDnH = new MsDotNetHeaven();
    protected void Page_Load(object sender, EventArgs e)
    {
        //Log user
        //Log User Entry
        bool blnLog = objMsDnH.LoggedUser(CleanUtils.ToInt(Session["UserID"]), Request.UserHostAddress, false);


        Session.Clear(); //clear sessions
        Session.Abandon(); //abandon session

        //Redirects to home page
        Response.Redirect("~/");
    }
}
