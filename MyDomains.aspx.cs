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
            this.Title = "Client Panel :: My Domains";
            //Create Bread Crumbs
            lblBreadCrumb.Text = String.Format("<a href=\'{0}\'>Home</a>  &gt; <a href=\'{1}\'>My Domains</a>", ResolveUrl("~"), ResolveUrl("~/MyDomains.aspx"));

        }

    }

    private void FillServiceDetails()
    {
        DataSet ds = new DataSet();
        ds = objMsDnH.GetDomainsDetail(CleanUtils.ToString(Session["Client"]), string.Empty, "GetDomainDetails");
        if (ds != null)
        {
            if (ds.Tables["GetDomainDetails"].Rows.Count > 0)
            {
                int intRows = ds.Tables["GetDomainDetails"].Rows.Count;
                lblRows.ForeColor = System.Drawing.Color.Blue;
                lblRows.Text = String.Format("Total {0} record(s) found.", intRows);

                //Bind grid
                gvDomains.DataSource = ds;
                gvDomains.DataBind();
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
    protected void gvDomains_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvDomains.PageIndex = e.NewPageIndex;
        FillServiceDetails();
    }
}
