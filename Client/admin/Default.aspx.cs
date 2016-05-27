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
using System.Data.SqlClient;
using System.Web.Configuration;
using msdnh.BF.MsDotnetHeaven;
using msdnh.util;

public partial class admin_login : System.Web.UI.Page
{
    string connectionString = WebConfigurationManager.ConnectionStrings["cn"].ConnectionString;
    SqlConnection con = new SqlConnection();
    string queary;
    int ID;
    MsDotNetHeaven objMsDnH = new MsDotNetHeaven();

    protected void Page_Load(object sender, EventArgs e)
    {
        con = new SqlConnection(connectionString);
        txtusername.Focus();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {

            bool blnRes = objMsDnH.VerifyCredentials(txtusername.Text, converter.Encrypt(txtpassword.Text), "Staff"); //This is an Admin panel so allow only Staff
            if (blnRes)
            {
                Session["admin"] = txtusername.Text;

                //Set UserID
                DataSet dsGetUsers = new DataSet();
                dsGetUsers = objMsDnH.GetUsers(CleanUtils.ToString(Session["admin"]), string.Empty, "GetUsers");
                if (dsGetUsers != null)
                {
                    if (dsGetUsers.Tables["GetUsers"].Rows.Count > 0)
                    {
                        //Store Userid
                        Session["StaffID"] = dsGetUsers.Tables["GetUsers"].Rows[0]["ID"]; //UserID
                    }
                }



                //Log User Entry
                bool blnLog = objMsDnH.LoggedUser(CleanUtils.ToInt(Session["StaffID"]), Request.UserHostAddress, true);

                Response.Redirect("../admin/home.aspx", false);

            }
            else
                Label1.Text = "Username Password Mismatch";

            txtusername.Text = txtpassword.Text = "";
        }
        catch (Exception ex)
        {
            Label1.Text = "Some error occured." + ex.Message;

        }
    }
}
