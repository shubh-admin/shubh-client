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

public partial class admin_DomainManager : System.Web.UI.Page
{
    int intID;
    MsDotNetHeaven objMsDnH = new MsDotNetHeaven();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["ID"] != null)
            {
                intID = CleanUtils.ToInt(Request.QueryString["ID"].ToString());

                FillClient();
                ShowDomains();

                if (intID == 0)
                {
                    paneladd.Visible = true;
                    panelshow.Visible = false;
                    return;
                }
                if (intID == 1)
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

    private void FillClient()
    {
        DataSet dsUserDetail = objMsDnH.GetUsersByType(Enumerations.UserType.Client.ToString(), 1, "UserDetails");
        if (dsUserDetail != null)
        {
            foreach (DataRow dRow in dsUserDetail.Tables["UserDetails"].Rows)
            {
                //Client Name
                ddlClientName.Items.Add(new ListItem(string.Format("{0} ({1})", dRow["Name"], dRow["UserName"]), CleanUtils.ToString(dRow["ID"])));
                //Clien COmbo for edit
                ddlClientEdit.Items.Add(new ListItem(string.Format("{0} ({1})", dRow["Name"], dRow["UserName"]), CleanUtils.ToString(dRow["ID"])));
            }

        }


    }

    private void ShowDomains()
    {
        DataSet dsDomain = objMsDnH.GetDomainsDetail(string.Empty, string.Empty, "DomainDetails");
        gvDomains.DataSource = dsDomain;
        gvDomains.DataBind();
    }
    protected void btnadd_Click(object sender, EventArgs e)
    {
        //Save domains
        bool blnRes = objMsDnH.AddDomains(ddlClientName.SelectedValue, txtStatus.Text, txtDomain.Text, txtcost.Text, txtRegDate.Text, txtNextDue.Text, CleanUtils.ToInt(Session["StaffID"]));
        if (blnRes)
        {
            lblMsg.Text = "Record added successfully!";
            txtStatus.Text = txtDomain.Text = txtcost.Text = txtRegDate.Text = txtNextDue.Text = string.Empty;
        }
    }
    protected void gvDomains_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditText")
        {
            string strID = CleanUtils.ToString(e.CommandArgument.ToString());
            ViewState["DomainID"] = Convert.ToString(e.CommandArgument.ToString());
            paneladd.Visible = false;
            paneledit.Visible = true;
            panelshow.Visible = false;
            lblMsgEdit.Text = "";
            DataSet dsGetDomain = new DataSet();
            dsGetDomain = objMsDnH.GetDomainsByID(strID, "DomainByID");
            if (dsGetDomain != null)
            {
                if (dsGetDomain.Tables["DomainByID"].Rows.Count != 0)
                {
                    ddlClientEdit.SelectedValue = CleanUtils.ToString(dsGetDomain.Tables["DomainByID"].Rows[0]["USERID"]);
                    txtDomainEdit.Text = CleanUtils.ToString(dsGetDomain.Tables["DomainByID"].Rows[0]["Domain"]);
                    txtStatusEdit.Text = CleanUtils.ToString(dsGetDomain.Tables["DomainByID"].Rows[0]["Status"]);
                    //txtRegDateEdit.Text = CleanUtils.ToString(dsGetDomain.Tables["DomainByID"].Rows[0]["RegDate"]);
                    txtRegDateEdit.Text = Convert.ToDateTime(CleanUtils.ToString(dsGetDomain.Tables["DomainByID"].Rows[0]["RegDate"])).ToString("MM/dd/yyyy").Replace('-', '/');
                    txtCostEdit.Text = CleanUtils.ToString(dsGetDomain.Tables["DomainByID"].Rows[0]["Price"]);
                    //txtNextDueEdit.Text = String.Format("{0}:D", CleanUtils.ToString(dsGetDomain.Tables["DomainByID"].Rows[0]["NextDue"]));
                    txtNextDueEdit.Text = Convert.ToDateTime(CleanUtils.ToString(dsGetDomain.Tables["DomainByID"].Rows[0]["NextDue"])).ToString("MM/dd/yyyy").Replace('-', '/');
                }
            }
        }
    }

    protected void btnupdate_Click(object sender, EventArgs e)
    {
        //Update the domains
        bool blnRes = objMsDnH.UpdateDomains(ddlClientEdit.SelectedValue, CleanUtils.ToString(ViewState["DomainID"]), txtStatusEdit.Text, txtDomainEdit.Text, txtCostEdit.Text, txtRegDateEdit.Text, txtNextDueEdit.Text, CleanUtils.ToInt(Session["StaffID"]));

        if (blnRes)
        {
            lblMsgEdit.Text = "Record updated successfully!";
            txtStatusEdit.Text = txtDomainEdit.Text = txtCostEdit.Text = txtRegDateEdit.Text = txtNextDueEdit.Text = string.Empty;
        }
    }
    protected void gvDomains_PageIndexChanging(object sender, GridViewPageEventArgs e)
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
