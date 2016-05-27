using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Net.Mail;
using System.Collections.Generic;
using System.Text;
using msdnh.util;

/// <summary>
/// Summary description for MailUtility
/// </summary>
public class MailUtility
{
    public MailUtility()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="sbMail"></param>
    /// <returns></returns>
    public static bool SendActivationMail(List<string> lStrMail, StringBuilder sbMail, bool blnIsBodyHtml)
    {
        string from = Config.From;
        string to = (lStrMail[2].ToString());
        bool blnRes = true;
        System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
        mail.To.Add(to);

        mail.From = new MailAddress(from, Config.FromName, System.Text.Encoding.UTF8);
        if (!Config.IsReplyAsSender)
        {
            mail.ReplyTo = new MailAddress(Config.ReplyEmail, Config.ReplyName, System.Text.Encoding.UTF8);
        }
        mail.Subject = lStrMail[3].ToString();
        mail.SubjectEncoding = System.Text.Encoding.UTF8;
        mail.Body = sbMail.ToString(); //"<b>This is Email Body Text</b>";
        mail.BodyEncoding = System.Text.Encoding.UTF8;
        mail.IsBodyHtml = blnIsBodyHtml;
        mail.Priority = MailPriority.Normal;

        SmtpClient client = new SmtpClient();

        //Add the Creddentials- use your own email id and password

        client.Credentials = new System.Net.NetworkCredential(from, Config.FromPassword);

        client.EnableSsl = Config.UseSMTPSSL; //Gmail works on Server Secured Layer
        client.Port = Config.SmtpPort;
        client.Host = Config.SmtpHost;

        client.Send(mail);

        //try
        //{
        //    client.Send(mail);
        //}
        //catch (Exception ex)
        //{
        //    Exception ex2 = ex;
        //    string errorMessage = string.Empty;
        //    while (ex2 != null)
        //    {
        //        errorMessage += ex2.ToString() + "<br />";
        //        ex2 = ex2.InnerException;

        //    }
        //    //  HttpContext.Current.Response.Write(errorMessage);
        //    blnRes = false;
        //} // end try 

        return blnRes;
    }
}
