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

public partial class admin_CategoryManager : System.Web.UI.Page
{
    //string connectionString = WebConfigurationManager.ConnectionStrings["deeps105connectionstring"].ConnectionString;
    string connectionString = WebConfigurationManager.ConnectionStrings["cn"].ConnectionString;
    SqlConnection con = new SqlConnection();
    string queary;
    int ID;
    
   
    private void show()
    {
        if (con.State == ConnectionState.Closed)
            con.Open();
        queary = "SELECT * from tblcategory where Status='1'";
        SqlCommand cmd = new SqlCommand(queary, con);
        SqlDataReader dr = cmd.ExecuteReader();
        DataTable dt = new DataTable();
        dt.Load(dr);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        con = new SqlConnection(connectionString);
        if (!IsPostBack)
        {
            show();
            ID =Convert.ToInt32(Request.QueryString[0].ToString());
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
    }
    protected void btnadd_Click(object sender, EventArgs e)
    {
        if (con.State == ConnectionState.Closed)
            con.Open();
        try
        {
            int a = Convert.ToInt32(new SqlCommand("Select Count(*) from tblcategory where CategoryName='" + txtcategory.Text + "'", con).ExecuteScalar());
            if (a == 0)
            {
                string insert = Convert.ToString(new SqlCommand("INSERT INTO tblcategory (CategoryName,EntryDate) Values ('" + txtcategory.Text + "','" + System.DateTime.Now.Date + "')", con).ExecuteNonQuery());
                msg.Text = "New Category Add Successfully";
                 txtcategory.Text = "";
            }
            else
            {
                msg.Text = "Category Already Exists";
            }
        }
        catch (Exception ex)
        {
            msg.Text = "Some Error Occured.Try Again";
        }
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditText")
        {
            int id = Convert.ToInt32(e.CommandArgument.ToString());
           ViewState["userid"] = Convert.ToInt32(e.CommandArgument.ToString());
            paneladd.Visible = false;
            paneledit.Visible = true;
             panelshow.Visible = false;
            if (con.State == ConnectionState.Closed)
              con.Open();
          
                queary = "Select CategoryName,ID from tblcategory where ID=" + id + "";
                SqlCommand cmd = new SqlCommand(queary, con);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                txtupcategory.Text = dt.Rows[0][0].ToString();
            

        }
        if (e.CommandName == "DeleteText")
        {
            int id=Convert.ToInt32(e.CommandArgument.ToString());
            if (con.State == ConnectionState.Closed)
                con.Open();
            string delete = Convert.ToString(new SqlCommand("delete  from tblcategory where ID=" + id + "", con).ExecuteNonQuery());
            show();
        }
    }
    protected void btnupdate_Click(object sender, EventArgs e)
    {
        try
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            string update = Convert.ToString(new SqlCommand("Update tblcategory set CategoryName='" + txtupcategory.Text + "' where ID=" + ViewState["userid"] + "", con).ExecuteNonQuery());
            show();
            paneladd.Visible = false;
            paneledit.Visible = false;
            panelshow.Visible = true;
        }
        catch (Exception ex)
        {
            Label1.Text = "some error occured. Try again.";

        }
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        show();
    }
}
