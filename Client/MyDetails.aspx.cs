using System;
using System.Data;
using System.Web.UI;
using msdnh.util;
using msdnh.BF.MsDotnetHeaven;

namespace Client
{
public partial class MyDetails : Page
{
    MsDotNetHeaven objMsDnH = new MsDotNetHeaven();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillUserDetails();
        }

        //Show Sub-menus and handle the page accordingly
        if (Request.QueryString["action"] == "ChangePass")
        {
            //Show title
            this.Title = "Client Panel :: Change Password";
            //Create Bread Crumbs
            lblBreadCrumb.Text = String.Format("<a href=\'{0}\'>Home</a>  &gt; <a href=\'{1}\'>My Details</a> &gt; <a href=\'{2}\'>Change Password</a>", ResolveUrl("~"), ResolveUrl("~/MyDetails.aspx"), ResolveUrl("~/MyDetails.aspx?action=ChangePass"));

            //show detail section and make submenus
            lblSubMenu.Text = string.Format("<a href=\'{0}\'>My Details</a> | <strong>{1}</strong>", ResolveUrl("~/MyDetails.aspx?action=MyDetail"), "Change Password");

            pnlMyDetails.Visible = false;
            pnlChangePassword.Visible = true;



        }
        else if (Request.QueryString["action"] == "MyDetail")
        {
            //Show title
            this.Title = "Client Panel :: My Details";
            lblBreadCrumb.Text = String.Format("<a href=\'{0}\'>Home</a>  &gt; <a href=\'{1}\'>My Details</a>", ResolveUrl("~"), ResolveUrl("~/MyDetails.aspx"));

            //show change password section section and make submenus
            lblSubMenu.Text = string.Format(" <strong>{0}</strong> | <a href=\'{1}\'>Change Password</a>", "My Details", ResolveUrl("~/MyDetails.aspx?action=ChangePass"));

            pnlMyDetails.Visible = true;
            pnlChangePassword.Visible = false;

        }
        else
        {
            //Show title
            this.Title = "Client Panel :: My Details";
            lblBreadCrumb.Text = String.Format("<a href=\'{0}\'>Home</a>  &gt; <a href=\'{1}\'>My Details</a>", ResolveUrl("~"), ResolveUrl("~/MyDetails.aspx"));

            //show detail section and make submenus
            lblSubMenu.Text = string.Format(" <strong>{0}</strong> | <a href=\'{1}\'>Change Password</a>", "My Details", ResolveUrl("~/MyDetails.aspx?action=ChangePass"));


            pnlMyDetails.Visible = true;
            pnlChangePassword.Visible = false;
        }
    }

    private void FillUserDetails()
    {
        DataSet dsGetUsers = new DataSet();
        dsGetUsers = objMsDnH.GetUsers(CleanUtils.ToString(Session["Client"]), string.Empty, "GetUsers");
        if (dsGetUsers != null)
        {
            if (dsGetUsers.Tables["GetUsers"].Rows.Count > 0)
            {
                txtACCID.Text = CleanUtils.ToString(dsGetUsers.Tables["GetUsers"].Rows[0]["ACCID"]);
                txtName.Text = CleanUtils.ToString(dsGetUsers.Tables["GetUsers"].Rows[0]["Name"]);
                txtUserName.Text = CleanUtils.ToString(dsGetUsers.Tables["GetUsers"].Rows[0]["UserName"]);
                txtEmail.Text = CleanUtils.ToString(dsGetUsers.Tables["GetUsers"].Rows[0]["Email"]);
                txtAddress1.Text = CleanUtils.ToString(dsGetUsers.Tables["GetUsers"].Rows[0]["Address1"]);
                txtAddress2.Text = CleanUtils.ToString(dsGetUsers.Tables["GetUsers"].Rows[0]["Address2"]);
                txtCity.Text = CleanUtils.ToString(dsGetUsers.Tables["GetUsers"].Rows[0]["City"]);
                txtCountry.Text = CleanUtils.ToString(dsGetUsers.Tables["GetUsers"].Rows[0]["Country"]);
                txtPhone.Text = CleanUtils.ToString(dsGetUsers.Tables["GetUsers"].Rows[0]["Phone"]);
                btnSaveDetails.CommandArgument = CleanUtils.ToString(dsGetUsers.Tables["GetUsers"].Rows[0]["ID"]);
                btnSavePass.CommandArgument = CleanUtils.ToString(dsGetUsers.Tables["GetUsers"].Rows[0]["ID"]);
            }
        }
    }
    protected void btnSaveDetails_Click(object sender, EventArgs e)
    {
        bool blnRes = false;
        try
        {
            blnRes = objMsDnH.UpdateUser(btnSavePass.CommandArgument, txtUserName.Text, string.Empty, txtEmail.Text, "Client", txtACCID.Text, CleanUtils.ToInt(btnSavePass.CommandArgument), txtName.Text, txtAddress1.Text, txtAddress2.Text, txtCity.Text, txtCountry.Text, txtPhone.Text);


            if (blnRes)
            {
                lblDetMsg.ForeColor = System.Drawing.Color.Blue;
                lblDetMsg.Text = "Details updated Successfully";
            }
        }
        catch (Exception ex)
        {
            lblDetMsg.ForeColor = System.Drawing.Color.Red;
            lblDetMsg.Text = "There is error during operation. Error is : " + ex.Message;
        }
    }
    protected void btnSavePass_Click(object sender, EventArgs e)
    {
        bool blnRes = false;
        try
        {
            blnRes = objMsDnH.VerifyPassword(CleanUtils.ToString(Session["Client"]), btnSavePass.CommandArgument, converter.Encrypt(txtPass.Text), "Client");

            if (blnRes)
            {

                bool blnUpdate = objMsDnH.UpdateUserPassword(converter.Encrypt(txtNPass.Text), btnSavePass.CommandArgument);
                if (blnUpdate)
                {
                    lblPassMsg.ForeColor = System.Drawing.Color.Blue;
                    lblPassMsg.Text = "Password updated! You need to login again.";
                }
                else
                {
                    lblPassMsg.ForeColor = System.Drawing.Color.Red;
                    lblPassMsg.Text = "Password is not updated, contact Admin.";
                }
            }
            else
            {
                lblPassMsg.ForeColor = System.Drawing.Color.Red;
                lblPassMsg.Text = "Existing password does not match!";
            }
        }
        catch (Exception ex)
        {
            lblPassMsg.ForeColor = System.Drawing.Color.Red;
            lblPassMsg.Text = "Password is not updated. Erro : " + ex.Message;
        }
        finally
        {

            txtPass.Text = txtNPass.Text = txtConfirmPass.Text = string.Empty;
        }
    }
}

}
