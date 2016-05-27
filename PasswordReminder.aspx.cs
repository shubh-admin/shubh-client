using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using msdnh.BF.MsDotnetHeaven;
using msdnh.util;
using System.Text;
using System.Data;

public partial class PasswordReminder : System.Web.UI.Page
{
    MsDotNetHeaven objMsDnH = new MsDotNetHeaven();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnRemind_Click(object sender, EventArgs e)
    {
        //First check the existance of username
        int intRes = objMsDnH.VerifyExistance(txtusername.Text, string.Empty, "Client", string.Empty);
        if (intRes == 0)
        {
            lblMsg.ForeColor = System.Drawing.Color.Red;
            lblMsg.Text = string.Format("UserName {0} does not exist.", txtusername.Text);
        }
        else
        {
            //Send Password Reminder email
            SendMail();

        }
    }

    private void SendMail()
    {
        //First get the user information including password
        DataSet dsUser = objMsDnH.GetUsers(txtusername.Text, string.Empty, "GetUser");
        string strName = string.Empty;
        string strPass = string.Empty;
        string strEmail = string.Empty;
        if (dsUser != null)
        {
            if (dsUser.Tables["GetUser"].Rows.Count > 0)
            {
                //There will be always only one row
                strName = CleanUtils.ToString(dsUser.Tables["GetUser"].Rows[0]["Name"]);
                strPass = converter.Decrypt(CleanUtils.ToString(dsUser.Tables["GetUser"].Rows[0]["Password"])); //get plain password
                strEmail = CleanUtils.ToString(dsUser.Tables["GetUser"].Rows[0]["Email"]);
            }
        }
        //Send Reset Password Email
        List<string> lStrMail = new List<string>();
        StringBuilder sbMail = new StringBuilder();
        String strEmailBody = string.Empty;
        Boolean blnIsBodyHtml = true; //IsBodyHtml default true

        lStrMail.Add(CleanUtils.ToString(Config.GetConfigValueAsString("smtpserver")));  //smtp server
        lStrMail.Add(CleanUtils.ToString(Config.GetConfigValueAsString("noreply")));    //From address
        lStrMail.Add(strEmail);   //To address
        lStrMail.Add("Reset Password");  //subject

        //mail template should be fetched from database

        //Fetch Mail Template from Database : 2=>Reset Password mail

        //Write html Body Message
        strEmailBody = string.Format(@"<table width=""100%"">
                            <tr>
                            <td> 
                            Hello <b>{0}</b>,
                            <br/><br />
                            You are welcomed to <strong>{1}.</strong>
                            <br /><br />
                            Your password is : <strong>{2}</strong>
                            <br />
                            <br/>
                            <br />
                            Thanks,
                            <br />
                            {3} Team,
                            <br />
                            {4}
                            <br /><br />
                            <hr />
                            <i>You received this email because you have requested to reset your password from I.P. {5}</i>
                            </td>
                            </tr>
                            </table>", strName, "Client Service Panel", strPass, "Client Panel", "http://client.shubhcomputing.com", Request.UserHostAddress);

        sbMail.Append(strEmailBody);

        try
        {
            if (MailUtility.SendActivationMail(lStrMail, sbMail, blnIsBodyHtml))    //Send mail
            {
                //Show the success message
                txtusername.Text = "";
                lblMsg.ForeColor = System.Drawing.Color.Blue;
                lblMsg.Text = "Password has been sent to your registered email.<br/>If you will not get email check your spam folder. For any problem, contact to Admin.";
            }
        }
        catch (Exception ex)
        {
            lblMsg.ForeColor = System.Drawing.Color.Red;
            lblMsg.Text = "There is an error : " + ex.Message + "<br />Please make sure your registered email is valid.";
        }
    }
}
