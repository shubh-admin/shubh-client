﻿using System;
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

public partial class admin_ServiceManager : System.Web.UI.Page
{
    int ID;
    MsDotNetHeaven objMsDnH = new MsDotNetHeaven();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ShowServices();
        }
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

    private void ShowServices()
    {
        DataSet dsServices = objMsDnH.GetServicesDetail(string.Empty, string.Empty, "ServiceDetails");
        gvServices.DataSource = dsServices;
        gvServices.DataBind();
    }
    protected void btnadd_Click(object sender, EventArgs e)
    {

    }
    protected void gvServices_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }

    protected void btnupdate_Click(object sender, EventArgs e)
    {

    }
    protected void gvServices_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }

    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {


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

    protected void gv_imgdetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
    }

    protected void gv_imgdetails_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }

    protected void gv_imgdetails_SelectedIndexChanged(object sender, EventArgs e)
    {


    }
    protected void gv_imgdetails_PageIndexChanging(Object sender, GridViewPageEventArgs e)
    {

    }
    public void gv_Bind()
    {


    }
    public void ShowCraft()
    {

    }
}
