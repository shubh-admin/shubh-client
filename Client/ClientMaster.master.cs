using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using msdnh.BF.MsDotnetHeaven;
using msdnh.util;
public partial class ClientMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        MsDotNetHeaven objMsDnH = new MsDotNetHeaven();
        if (Session["Client"] != null)
        {

            //Get and display information
            lblLogout.Text = string.Format("Welcome to client Panel <a href={0}>{1}</a>", "ClientLogout.aspx", "Logout");

            DataSet dsGetUsers = new DataSet();
            dsGetUsers = objMsDnH.GetUsers(CleanUtils.ToString(Session["Client"]), string.Empty, "GetUsers");
            if (dsGetUsers != null)
            {
                if (dsGetUsers.Tables["GetUsers"].Rows.Count > 0)
                {
                    //Store Userid
                    //Session["UserID"] = dsGetUsers.Tables["GetUsers"].Rows[0]["ID"]; //UserID
                    lblUserInfo.Text = string.Format("<strong>{0}</strong>,<br />{1}<br />{2}<br />{3}<br/>{4},{5}<br />{6}",
                        CleanUtils.ToString(dsGetUsers.Tables["GetUsers"].Rows[0]["Name"]), CleanUtils.ToString(dsGetUsers.Tables["GetUsers"].Rows[0]["Address1"]),
                        CleanUtils.ToString(dsGetUsers.Tables["GetUsers"].Rows[0]["Address2"]), CleanUtils.ToString(dsGetUsers.Tables["GetUsers"].Rows[0]["City"]),
                        CleanUtils.ToString(dsGetUsers.Tables["GetUsers"].Rows[0]["Country"]), CleanUtils.ToString(dsGetUsers.Tables["GetUsers"].Rows[0]["Phone"]),
                        CleanUtils.ToString(dsGetUsers.Tables["GetUsers"].Rows[0]["Email"])
                        );
                }
            }


        }
        else if (Session["Client"] == null)
        {
            lblLogout.Text = lblUserInfo.Text = string.Empty;
            Session.Abandon();
            Session.Clear();
            Response.Redirect("ClientLogin.aspx");
        }
        if (!IsPostBack)
        {
            DataSet dsUserStat = new DataSet();
            dsUserStat = objMsDnH.GetUserStats(Convert.ToInt32(Session["UserID"]), "UserStats");
            Double dblDr = 0.00;
            Double dblCr = 0.00;
            int ticket = 0;
            int domain = 0;
            int service = 0;
            if (dsUserStat != null)
            {
                if (dsUserStat.Tables["UserStats"].Rows.Count > 0)
                {
                    if (CleanUtils.ToDouble(dsUserStat.Tables["UserStats"].Rows[0]["Balance"]) > 0.00)
                        dblDr = CleanUtils.ToDouble(dsUserStat.Tables["UserStats"].Rows[0]["Balance"]);
                    else
                        dblCr = CleanUtils.ToDouble(dsUserStat.Tables["UserStats"].Rows[0]["Balance"]);

                    ticket = CleanUtils.ToInt(dsUserStat.Tables["UserStats"].Rows[0]["Ticket"]);
                    domain = CleanUtils.ToInt(dsUserStat.Tables["UserStats"].Rows[0]["domains"]);
                    service = CleanUtils.ToInt(dsUserStat.Tables["UserStats"].Rows[0]["services"]);

                    lblStats.Text = String.Format(@"<li>Number of Products/Services: <b>{0}</b></li> <li>Number of Domains: <b>{1}</b></li>
                        <li>Number of Open Tickets: <b>{2}</b></li><li>Number of Referred Signups: 0</li><li>Account Credit Balance: <font color=""Blue""><b>Rs. {3}</b></font></li>
                        <li>Due Invoices Balance: <font color=""Red""><b>Rs. {4}</b></font></li>", service, domain, ticket, -dblCr, dblDr);


                }
            }
        }

    }
}
