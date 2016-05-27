using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using msdnh.BF.MsDotnetHeaven;
using msdnh.util;
using System.Data;
public partial class ClientLogin : System.Web.UI.Page
{
    MsDotNetHeaven objMsDnH = new MsDotNetHeaven();
    protected void Page_Load(object sender, EventArgs e)
    {
        txtusername.Focus();
        if (!IsPostBack)
        {

        }
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {

            bool blnRes = objMsDnH.VerifyCredentials(txtusername.Text, converter.Encrypt(txtpassword.Text), "Client");
            if (blnRes)
            {
                Session["Client"] = txtusername.Text; //Get the UserName

                //Set UserID
                DataSet dsGetUsers = new DataSet();
                dsGetUsers = objMsDnH.GetUsers(CleanUtils.ToString(Session["Client"]), string.Empty, "GetUsers");
                if (dsGetUsers != null)
                {
                    if (dsGetUsers.Tables["GetUsers"].Rows.Count > 0)
                    {
                        //Store Userid
                        Session["UserID"] = dsGetUsers.Tables["GetUsers"].Rows[0]["ID"]; //UserID
                    }
                }



                //Log User Entry
                bool blnLog = objMsDnH.LoggedUser(CleanUtils.ToInt(Session["UserID"]), Request.UserHostAddress, true);

                Response.Redirect("Default.aspx", false);

            }
            else
                lblMsg.Text = "Username Password Mismatch";

            txtusername.Text = txtpassword.Text = "";
        }
        catch (Exception ex)
        {
            lblMsg.Text = "Some error occured." + ex.Message;

        }

    }
}
