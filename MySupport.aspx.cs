using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using msdnh.util;
using msdnh.BF.MsDotnetHeaven;

public partial class MyDetails : System.Web.UI.Page
{
    MsDotNetHeaven objMsDnH = new MsDotNetHeaven();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillSupportDetails();
            //Show title
            this.Title = "Client Panel :: My Domains";

            //Create Bread Crumbs
            lblBreadCrumb.Text = String.Format("<a href=\'{0}\'>Home</a>  &gt; <a href=\'{1}\'>My Support</a>", ResolveUrl("~"), ResolveUrl("~/MySupport.aspx"));

        }


    }


    protected void gvSupport_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvSupport.PageIndex = e.NewPageIndex;
        FillSupportDetails();
    }
    private void FillSupportDetails()
    {
        DataSet ds = new DataSet();
        ds = objMsDnH.GetSupportDetail(CleanUtils.ToInt(Session["UserID"]), 0, "GetSupportDetails");
        if (ds != null)
        {
            if (ds.Tables["GetSupportDetails"].Rows.Count > 0)
            {
                int intRows = ds.Tables["GetSupportDetails"].Rows.Count;
                lblRows.ForeColor = System.Drawing.Color.Blue;
                lblRows.Text = String.Format("Total {0} record(s) found.", intRows);

                //Bind grid
                gvSupport.DataSource = ds;
                gvSupport.DataBind();
            }
            else
            {
                lblRows.ForeColor = System.Drawing.Color.Red;
                lblRows.Text = "No record(s) found.";
            }
        }
        else
        {
            lblRows.ForeColor = System.Drawing.Color.Red;
            lblRows.Text = "No record(s) found.";
        }

    }

    protected void gvSupport_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Read")
        {
            int id = CleanUtils.ToInt(e.CommandArgument.ToString());
            DataSet dsMessages = objMsDnH.GetSupportDetail(CleanUtils.ToInt(Session["UserID"]), id, "GetSupportDetails");
            pnlMyTickets.Visible = false;
            pnlRaiseTicket.Visible = false;
            pnlReadTickets.Visible = true;
            pnlReopen.Visible = false;



            if (dsMessages.Tables["GetSupportDetails"].Rows.Count > 0)
            {
                foreach (DataRow msgRow in dsMessages.Tables["GetSupportDetails"].Rows)
                {

                    //Display a message at a time
                    lblMessage.Text = string.Format("<strong>Subject : </strong>{0}<br /><br /><br />{1}", CleanUtils.ToString(msgRow["Subject"]), (CleanUtils.ToString(msgRow["Query"])));

                    //Change BreadCrumbs

                    lblBreadCrumb.Text = String.Format("<a href=\'{0}\'>Home</a>  &gt; <a href=\'{1}\'>My Support</a>  &gt; {2}", ResolveUrl("~"), ResolveUrl("~/MySupport.aspx"), CleanUtils.ToString(msgRow["Subject"]));

                }

            }

        }
        if (e.CommandName == "Reopen")
        {
            int id = CleanUtils.ToInt(e.CommandArgument.ToString());
            ViewState["id"] = id;
            DataSet dsMessages = objMsDnH.GetSupportDetail(CleanUtils.ToInt(Session["UserID"]), id, "GetSupportDetails");
            foreach (DataRow msgRow in dsMessages.Tables["GetSupportDetails"].Rows)
            {
                //Prepare control for reply/reopen
                txtReopen.Text = string.Format("<br /><hr /><strong>Last Updated : {0} on Date : {1}</strong><br /><font color=\"blue\">{2}</font>", CleanUtils.ToString(msgRow["Staff Name"]), CleanUtils.ToString(msgRow["UpdatedDate"]), CleanUtils.ToString(msgRow["Query"]));
                txtReopen.Focus();
            }


            pnlMyTickets.Visible = false;
            pnlRaiseTicket.Visible = false;
            pnlReadTickets.Visible = false;
            pnlReopen.Visible = true;

            //Change BreadCrumbs

            lblBreadCrumb.Text = String.Format("<a href=\'{0}\'>Home</a>  &gt; <a href=\'{1}\'>My Support</a>  &gt; Reopen", ResolveUrl("~"), ResolveUrl("~/MySupport.aspx"));
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        pnlMyTickets.Visible = true;
        pnlReadTickets.Visible = false;
        pnlRaiseTicket.Visible = false;
        pnlReopen.Visible = false;
        //Create Bread Crumbs
        lblBreadCrumb.Text = String.Format("<a href=\'{0}\'>Home</a>  &gt; <a href=\'{1}\'>My Support</a>", ResolveUrl("~"), ResolveUrl("~/MySupport.aspx"));

    }
    protected void btnRaise_Click(object sender, EventArgs e)
    {
        pnlMyTickets.Visible = false;
        pnlReadTickets.Visible = false;
        pnlRaiseTicket.Visible = true;
        pnlReopen.Visible = false;
        //Create Bread Crumbs
        lblBreadCrumb.Text = String.Format("<a href=\'{0}\'>Home</a>  &gt; <a href=\'{1}\'>My Support</a>  &gt; Raise Ticket", ResolveUrl("~"), ResolveUrl("~/MySupport.aspx"));

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        //lblDetMsg.ForeColor = System.Drawing.Color.Red;
        //lblDetMsg.Text = "Error during submission. If you are getting error frequently, report Site Admin.";

        //If all data is valid insert into table
        string strKey = CleanUtils.GenerateTicketID();
        bool blnRes = objMsDnH.GenerateTicket(strKey, Convert.ToInt32(Session["UserID"]), rbDept.SelectedValue, ddlPriority.SelectedValue, txtPanelDetail.Text, txtACCID.Text, txtSubject.Text, txtQuery.Text, "Open", Convert.ToInt32(Session["UserID"]));

        if (blnRes)
        {
            //Clear all fields search and show the new entry
            rbDept.SelectedValue = "Support";
            ddlPriority.SelectedValue = "Low";
            txtACCID.Text = txtPanelDetail.Text = txtSubject.Text = txtQuery.Text = string.Empty;
            //Show results
            FillSupportDetails();

            pnlMyTickets.Visible = true;
            pnlReadTickets.Visible = false;
            pnlRaiseTicket.Visible = false;
            pnlReopen.Visible = false;
            //Show breadcrumbs
            lblBreadCrumb.Text = String.Format("<a href=\'{0}\'>Home</a>  &gt; <a href=\'{1}\'>My Support</a>", ResolveUrl("~"), ResolveUrl("~/MySupport.aspx"));
        }
    }
    protected void btnReSubmit_Click(object sender, EventArgs e)
    {
        //Update the ticket detaisl and disable this panel

        bool blnRes = objMsDnH.UpdateTicket(CleanUtils.ToString(ViewState["id"]), txtReopen.Text, "Reopen", Convert.ToInt32(Session["UserID"]));
        if (blnRes)
        {
            //Reload grid
            FillSupportDetails();

            //Show panel
            pnlMyTickets.Visible = true;
            pnlReadTickets.Visible = false;
            pnlRaiseTicket.Visible = false;
            pnlReopen.Visible = false;
            //Show breadcrumbs
            lblBreadCrumb.Text = String.Format("<a href=\'{0}\'>Home</a>  &gt; <a href=\'{1}\'>My Support</a>", ResolveUrl("~"), ResolveUrl("~/MySupport.aspx"));
        }
    }
}
