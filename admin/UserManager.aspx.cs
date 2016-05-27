using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;
using System.Data.SqlClient;
using System.Web.Configuration;

using msdnh.BF.MsDotnetHeaven;
using msdnh.util;

public partial class admin_UserManager : System.Web.UI.Page
{

    string connectionString = WebConfigurationManager.ConnectionStrings["cn"].ConnectionString;
    SqlConnection con = new SqlConnection();
    string queary;
    int ID;
    MsDotNetHeaven objMsDnH = new MsDotNetHeaven();
    private void show()
    {
        DataSet dsGetUsers = new DataSet();
        dsGetUsers = objMsDnH.GetUsers(string.Empty, "GetUsers"); //show all record(s)
        //Bind gridview
        GridView1.DataSource = dsGetUsers;
        GridView1.DataBind();

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        con = new SqlConnection(connectionString);
        if (!IsPostBack)
        {
            show();
            if (Request.QueryString["ID"] != null)
            {
                ID = Convert.ToInt32(Request.QueryString["ID"].ToString());
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
    protected void btnadd_Click(object sender, EventArgs e)
    {
        if (con.State == ConnectionState.Closed)
            con.Open();
        try
        {
            if (txtusername.Text.ToLower() == "admin")
            {
                msg.Text = "You cant Insert Admin as a New User";
                return;
            }
            if (ddType.SelectedValue == "0")
            {
                msg.ForeColor = System.Drawing.Color.Red;
                msg.Text = "Please select type first.";
                return;
            }
            //Check whether user exist

            int intRec = 0;
            intRec = objMsDnH.VerifyExistance(txtusername.Text, txtACCID.Text, ddType.SelectedValue, txtemail.Text); //show current user

            int intUserID = 0;
            //Data set is null, it mean username does not exist

            if (intRec == 0)
            {
                //Get Updated user id
                DataSet dsGetUsers = new DataSet();
                dsGetUsers = objMsDnH.GetUsers(CleanUtils.ToString(Session["admin"]), "GetUsers"); //show current user
                if (dsGetUsers != null)
                {
                    if (dsGetUsers.Tables["GetUsers"].Rows.Count > 0)
                    {
                        intUserID = CleanUtils.ToInt(dsGetUsers.Tables["GetUsers"].Rows[0]["ID"]);
                    }
                }
                bool blnRes = objMsDnH.AddUser(txtusername.Text, converter.Encrypt(txtpwd.Text), txtemail.Text, ddType.SelectedValue, txtACCID.Text, intUserID);

                if (blnRes)
                {
                    msg.ForeColor = System.Drawing.Color.Blue;
                    msg.Text = "New User Added Successfully";
                    txtemail.Text = txtpwd.Text = txtusername.Text = "";
                    ddType.SelectedIndex = 0;
                }
            }
            else
            {
                msg.ForeColor = System.Drawing.Color.Blue;
                msg.Text = String.Format("Please check ACC. ID : {0} OR UserName : {1} OR Email : {2}, already Exists for Type : {3}.", txtACCID.Text, txtusername.Text, txtemail.Text, ddType.SelectedValue);
            }
        }
        catch (Exception ex)
        {
            msg.Text = "Some Error Occured." + ex.Message;
        }
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditText")
        {
            int id = CleanUtils.ToInt(e.CommandArgument.ToString());
            ViewState["userid"] = Convert.ToInt32(e.CommandArgument.ToString());
            paneladd.Visible = false;
            paneledit.Visible = true;
            panelshow.Visible = false;
            lblUMsg.Text = "";
            DataSet dsGetUsers = new DataSet();
            dsGetUsers = objMsDnH.GetUsers(string.Empty, CleanUtils.ToString(id), "GetUsers"); //Get Detail by ID
            if (dsGetUsers != null)
            {
                if (dsGetUsers.Tables["GetUsers"].Rows.Count != 0)
                {
                    ddUpType.SelectedValue = CleanUtils.ToString(dsGetUsers.Tables["GetUsers"].Rows[0]["Type"]);
                    txtuACCID.Text = CleanUtils.ToString(dsGetUsers.Tables["GetUsers"].Rows[0]["ACCID"]);
                    txtupuname.Text = CleanUtils.ToString(dsGetUsers.Tables["GetUsers"].Rows[0]["UserName"]);
                    //txtuppassword.Text = dt.Rows[0][2].ToString();
                    txtupemail.Text = CleanUtils.ToString(dsGetUsers.Tables["GetUsers"].Rows[0]["Email"]);
                }
            }
        }
        if (e.CommandName == "DeleteText")
        {
            int id = Convert.ToInt32(e.CommandArgument.ToString());
            bool blnRes = objMsDnH.DeleteUser(CleanUtils.ToString(id));
            if (blnRes)
                show();
        }
        if (e.CommandName == "Deactive")
        {
            int id = Convert.ToInt32(e.CommandArgument.ToString());
            bool blnRes = objMsDnH.ActivateUser(CleanUtils.ToString(id), "0");
            if (blnRes)
                show();
        }
        if (e.CommandName == "active")
        {
            int id = Convert.ToInt32(e.CommandArgument.ToString());
            bool blnRes = objMsDnH.ActivateUser(CleanUtils.ToString(id), "1");
            if (blnRes)
                show();
        }
    }
    protected void btnupdate_Click(object sender, EventArgs e)
    {
        int intRec = 0;
        int intUserID = 0;
        intRec = objMsDnH.VerifyExistance(txtupuname.Text, txtuACCID.Text, ddUpType.SelectedValue, txtupemail.Text); //show current user

        if (intRec <= 1)
        {
            //Get Updated user id
            DataSet dsGetUsers = new DataSet();
            dsGetUsers = objMsDnH.GetUsers(CleanUtils.ToString(Session["admin"]), "GetUsers"); //show current user
            if (dsGetUsers != null)
            {
                if (dsGetUsers.Tables["GetUsers"].Rows.Count > 0)
                {
                    intUserID = CleanUtils.ToInt(dsGetUsers.Tables["GetUsers"].Rows[0]["ID"]);
                }
            }
            bool blnRes = objMsDnH.UpdateUser(CleanUtils.ToString(ViewState["userid"]), txtupuname.Text, converter.Encrypt(txtuppassword.Text), txtupemail.Text, ddUpType.SelectedValue, txtuACCID.Text, intUserID);

            if (blnRes)
            {
                lblUMsg.ForeColor = System.Drawing.Color.Blue;
                lblUMsg.Text = "Record updated Successfully";
                txtupemail.Text = txtpwd.Text = txtusername.Text = "";
                ddUpType.SelectedIndex = 0;
            }
        }
        else
        {
            lblUMsg.ForeColor = System.Drawing.Color.Blue;
            lblUMsg.Text = String.Format("Please check ACC. ID : {0} OR UserName : {1} OR Email : {2}, already Exists for Type : {3}.", txtACCID.Text, txtusername.Text, txtemail.Text, ddType.SelectedValue);
        }

        show();
        paneladd.Visible = false;
        paneledit.Visible = false;
        panelshow.Visible = true;
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int a = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Status").ToString());
            string strUserName = CleanUtils.ToLoawerCase(CleanUtils.ToString(DataBinder.Eval(e.Row.DataItem, "UserName")));

            Button btnActive = (Button)e.Row.FindControl("btnactive");
            Button btnStatus = (Button)e.Row.FindControl("btnstatus");
            Button btnDelete = (Button)e.Row.FindControl("btndelete");
            Button btnEdit = (Button)e.Row.FindControl("btnedit");

            //Make sure only admin can Delete all users
            if (CleanUtils.ToLoawerCase(CleanUtils.ToString(Session["admin"])) != "admin")
            {
                if (strUserName == "admin")
                {
                    //Deactivate action buttons
                    if (btnActive != null)
                        btnActive.Visible = false;
                    if (btnStatus != null)
                        btnStatus.Visible = false;
                    if (btnDelete != null)
                        btnDelete.Visible = false;
                    if (btnEdit != null)
                        btnEdit.Visible = false;

                }
                else
                {
                    //Disable delete button
                    if (btnDelete != null)
                        btnDelete.Visible = false;
                    if (a == 1)
                    {
                        if (btnActive != null)
                            btnActive.Visible = false;

                    }
                    else
                        if (btnStatus != null)
                            btnStatus.Visible = false;
                }
            }
            else
            {
                if (a == 1)
                {
                    if (btnActive != null)
                        btnActive.Visible = false;

                }
                else
                    if (btnStatus != null)
                        btnStatus.Visible = false;

            }

        }
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        show();
    }
}
