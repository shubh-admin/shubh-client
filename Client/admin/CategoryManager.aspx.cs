using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Client.admin
{
    public partial class AdminCategoryManager : Page
    {
        private SqlConnection con = new SqlConnection();
        //string connectionString = WebConfigurationManager.ConnectionStrings["deeps105connectionstring"].ConnectionString;
        private readonly string _connectionString = WebConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        private int ID;
        private string queary;


        private void Show()
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            queary = "SELECT * from tblcategory where Status='1'";
            var cmd = new SqlCommand(queary, con);
            var dr = cmd.ExecuteReader();
            var dt = new DataTable();
            dt.Load(dr);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(_connectionString);
            if (!IsPostBack)
            {
                Show();
                ID = Convert.ToInt32(Request.QueryString[0]);
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
                }
            }
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            try
            {
                var a =
                    Convert.ToInt32(
                        new SqlCommand("Select Count(*) from tblcategory where CategoryName='" + txtcategory.Text + "'", con)
                            .ExecuteScalar());
                if (a == 0)
                {
                    var insert =
                        Convert.ToString(
                            new SqlCommand(
                                "INSERT INTO tblcategory (CategoryName,EntryDate) Values ('" + txtcategory.Text + "','" +
                                DateTime.Now.Date + "')", con).ExecuteNonQuery());
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
                var id = Convert.ToInt32(e.CommandArgument.ToString());
                ViewState["userid"] = Convert.ToInt32(e.CommandArgument.ToString());
                paneladd.Visible = false;
                paneledit.Visible = true;
                panelshow.Visible = false;
                if (con.State == ConnectionState.Closed)
                    con.Open();

                queary = "Select CategoryName,ID from tblcategory where ID=" + id + "";
                var cmd = new SqlCommand(queary, con);
                var dr = cmd.ExecuteReader();
                var dt = new DataTable();
                dt.Load(dr);
                txtupcategory.Text = dt.Rows[0][0].ToString();
            }
            if (e.CommandName == "DeleteText")
            {
                var id = Convert.ToInt32(e.CommandArgument.ToString());
                if (con.State == ConnectionState.Closed)
                    con.Open();
                var delete =
                    Convert.ToString(new SqlCommand("delete  from tblcategory where ID=" + id + "", con).ExecuteNonQuery());
                Show();
            }
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                var update =
                    Convert.ToString(
                        new SqlCommand(
                            "Update tblcategory set CategoryName='" + txtupcategory.Text + "' where ID=" +
                            ViewState["userid"] + "", con).ExecuteNonQuery());
                Show();
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
            Show();
        }
    }
}