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
using System.Web.Configuration;
using System.Data.SqlClient;
using msdnh.BF.MsDotnetHeaven;

public partial class admin_ErrorLogReport : System.Web.UI.Page
{
    //string connectionString = WebConfigurationManager.ConnectionStrings["deeps105connectionstring"].ConnectionString;
    //SqlConnection con = new SqlConnection();
    //string queary;
    MsDotNetHeaven objMsDnH = new MsDotNetHeaven();

    protected void Page_Load(object sender, EventArgs e)
    {
        //Show the data on Grid
        if (!IsPostBack)
        {
            BindGrid();
        }
    }



    private void BindGrid()
    {
        try
        {
            //con = new SqlConnection(connectionString);
            //if (con.State == ConnectionState.Open)
            //    con.Close();
            //con.Open();
            DataSet dsGetErrorLog = new DataSet();
            dsGetErrorLog = objMsDnH.GetErrorLog("GetErrorLog");
            if (dsGetErrorLog != null)
            {
                //queary = "SELECT * FROM ERRORLOG ORDER BY DATETIME";
                //SqlCommand cmdCont = new SqlCommand(queary, con);
                //SqlDataReader drCont = cmdCont.ExecuteReader();
                //DataTable tblCont = new DataTable();
                //tblCont.Load(drCont);
                //drCont.Close();
                if (dsGetErrorLog.Tables["GetErrorLog"].Rows.Count > 0)
                {
                    lblMsg.Text = "Following error(s) are reported as on date";
                    btnClear.Visible = true;
                }
                else
                {
                    lblMsg.Text = "No error log reported.";
                    btnClear.Visible = false;
                }
                gvEnquiry.DataSource = dsGetErrorLog.Tables["GetErrorLog"];
                gvEnquiry.DataBind();
                //con.Close();
            }
        }
        catch (Exception ex)
        {

            WriteLog.ErrorLog.WriteErrorLog(Request.Url.ToString(), ex.Message, "Error in Grid Binding Admin ErrorLog");
            Server.Transfer("../errors/GeneralError.aspx?Message=" + ex.Message);
        }
    }

    protected void gvEnquiry_PageIndexChanging(Object sender, GridViewPageEventArgs e)
    {
        gvEnquiry.PageIndex = e.NewPageIndex;

        //Bind Grid
        BindGrid();
    }

    protected void gvEnquiry_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void gvEnquiry_SelectedIndexChanged(object sender, EventArgs e)
    {
    }


    protected void btnClear_Click(object sender, EventArgs e)
    {

        try
        {

            bool blnRes = objMsDnH.DeleteErrorLog();
            //con = new SqlConnection(connectionString);
            //if (con.State == ConnectionState.Open)
            //    con.Close();
            //con.Open();

            //queary = "DELETE ERRORLOG";
            //SqlCommand cmdCont = new SqlCommand(queary, con);
            //SqlDataReader drCont = cmdCont.ExecuteReader();
            //DataTable tblCont = new DataTable();
            //tblCont.Load(drCont);
            //drCont.Close();
            //gvEnquiry.DataSource = tblCont;
            //gvEnquiry.DataBind();
            //con.Close();
            BindGrid(); //Bidn Grid again
        }
        catch (Exception ex)
        {

            WriteLog.ErrorLog.WriteErrorLog(Request.Url.ToString(), ex.Message, "Error in clearing Log File.");
            Server.Transfer("../errors/GeneralError.aspx?Message=" + ex.Message);
        }

    }
}
