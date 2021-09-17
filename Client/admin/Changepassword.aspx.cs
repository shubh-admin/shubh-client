using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

public partial class admin_Changepassword : System.Web.UI.Page
{
    //string connectionString = WebConfigurationManager.ConnectionStrings["deeps105connectionstring"].ConnectionString;
    string connectionString = WebConfigurationManager.ConnectionStrings["cn"].ConnectionString;
    SqlConnection con = new SqlConnection();
    string queary;
    int ID;

    protected void Page_Load(object sender, EventArgs e)
    {
        con = new SqlConnection(connectionString);
    }
    protected void btnchange_Click(object sender, EventArgs e)
    {
        if (con.State == ConnectionState.Closed)
            con.Open();
     
        
        string update=Convert.ToString(new SqlCommand("UPDATE tbllogin set Password='"+converter.Encrypt(txtnewpwd.Text)+"' where UserName='"+Session["admin"].ToString()+"'",con).ExecuteNonQuery());
        msg.Text = "Password changed Successfully";
    }
}
