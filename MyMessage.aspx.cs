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
            FillServiceDetails();

            //Show title
            this.Title = "Client Panel :: My Messages";
            //Create Bread Crumbs
            lblBreadCrumb.Text = String.Format("<a href=\'{0}\'>Home</a>  &gt; <a href=\'{1}\'>My Messages</a>", ResolveUrl("~"), ResolveUrl("~/MyMessage.aspx"));

        }

    }
    private void FillServiceDetails()
    {
        DataSet ds = new DataSet();
        ds = objMsDnH.GetMessagesDetail(CleanUtils.ToInt(Session["UserID"]), 0, "GetMessageDetails");
        if (ds != null)
        {
            if (ds.Tables["GetMessageDetails"].Rows.Count > 0)
            {
                int intRows = ds.Tables["GetMessageDetails"].Rows.Count;
                lblRows.ForeColor = System.Drawing.Color.Blue;
                lblRows.Text = String.Format("Total {0} record(s) found.", intRows);

                //Bind grid
                gvMessages.DataSource = ds;
                gvMessages.DataBind();
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
    protected void gvMessages_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvMessages.PageIndex = e.NewPageIndex;
        FillServiceDetails();
    }


    protected void gvMessages_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Read")
        {
            int id = CleanUtils.ToInt(e.CommandArgument.ToString());
            DataSet dsMessages = objMsDnH.GetMessagesDetail(CleanUtils.ToInt(Session["UserID"]), id, "GetMessageDetails"); ;
            pnlMyMessages.Visible = false;
            pnlReadMessage.Visible = true;

            if (dsMessages.Tables["GetMessageDetails"].Rows.Count > 0)
            {
                foreach (DataRow msgRow in dsMessages.Tables["GetMessageDetails"].Rows)
                {

                    //Display a message at a time
                    lblMessage.Text = string.Format("<strong>Subject : </strong>{0}<br /><br /><br />{1}", CleanUtils.ToString(msgRow["Subject"]), (CleanUtils.ToString(msgRow["Message"])));

                    //Change BreadCrumbs

                    lblBreadCrumb.Text = String.Format("<a href=\'{0}\'>Home</a>  &gt; <a href=\'{1}\'>My Messages</a>  &gt; {2}", ResolveUrl("~"), ResolveUrl("~/MyMessage.aspx"), CleanUtils.ToString(msgRow["Subject"]));

                }

            }


        }
    }
    protected void btnRead_Click(object sender, EventArgs e)
    {
        pnlMyMessages.Visible = true;
        pnlReadMessage.Visible = false;
        //Create Bread Crumbs
        lblBreadCrumb.Text = String.Format("<a href=\'{0}\'>Home</a>  &gt; <a href=\'{1}\'>My Messages</a>", ResolveUrl("~"), ResolveUrl("~/MyMessage.aspx"));
        //Refresh messges
        FillServiceDetails();
    }
}
