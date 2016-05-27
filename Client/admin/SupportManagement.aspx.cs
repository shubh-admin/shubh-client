using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Web.Configuration;

using msdnh.BF.MsDotnetHeaven;
using msdnh.util;

public partial class admin_SupportManager : System.Web.UI.Page
{
    int ID;
    MsDotNetHeaven objMsDnH = new MsDotNetHeaven();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ShowSupport();
            if (Request.QueryString["ID"] != null)
            {
                ID = CleanUtils.ToInt(Request.QueryString["ID"].ToString());
                if (ID == 0)
                {
                    paneladd.Visible = true;
                    panelshow.Visible = false;
                    return;
                }
                if (ID == 1)
                {
                    paneladd.Visible = false;
                    panelshow.Visible = true;
                    return;
                }
            }
            else
            {
                paneladd.Visible = false;
                panelshow.Visible = true;
            }
        }
    }

    private void ShowSupport()
    {
        DataSet dsSupport = new DataSet();
        dsSupport = objMsDnH.GetSupportDetail(0, 0, "Support");
        gvSupport.DataSource = dsSupport;
        gvSupport.DataBind();
    }
    protected void btnadd_Click(object sender, EventArgs e)
    {

    }
    protected void gvSupport_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }

    protected void btnupdate_Click(object sender, EventArgs e)
    {

    }
    protected void gvSupport_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvSupport.PageIndex = e.NewPageIndex;
        ShowSupport();
    }


    protected void btnchange_Click(object sender, EventArgs e)
    {

    }
    protected void btncancel_Click(object sender, EventArgs e)
    {

    }
    protected void btnadd1_Click(object sender, EventArgs e)
    {

    }
    protected void btndone_Click(object sender, EventArgs e)
    {

    }
    protected void btnAddNewCraft_Click(object sender, EventArgs e)
    {

    }

}
