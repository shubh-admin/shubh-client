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

public partial class admin_enquiry : System.Web.UI.Page
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
            //    con = new SqlConnection(connectionString);
            //    if (con.State == ConnectionState.Open)
            //        con.Close();
            //    con.Open();

            //    queary = "SELECT * FROM TBLCONTACT WHERE STATUS = 1 ORDER BY ID";
            //    SqlCommand cmdCont = new SqlCommand(queary, con);
            //    SqlDataReader drCont = cmdCont.ExecuteReader();
            //    DataTable tblCont = new DataTable();
            //    tblCont.Load(drCont);
            //    drCont.Close();

            DataSet dsGetContacts = new DataSet();
            dsGetContacts = objMsDnH.GetContacts(true, "GetContacts");
            if (dsGetContacts != null)
            {
                gvEnquiry.DataSource = dsGetContacts.Tables["GetContacts"];
                gvEnquiry.DataBind();
                //con.Close();
            }
        }
        catch (Exception ex)
        {

            WriteLog.ErrorLog.WriteErrorLog(Request.Url.ToString(), ex.Message, "Error in Grid Binding Admin Enquiry");
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
        try
        {
            //con = new SqlConnection(connectionString);
            //if (con.State == ConnectionState.Open)
            //{
            //    con.Close();
            //}
            //con.Open();
            //con.Open();
            if (e.CommandName == "DeleteEnquiry")
            {
                int intID = Convert.ToInt32(e.CommandArgument);
                //string query = "Update TBLCONTACT SET STATUS=0 WHERE ID = " + intID;
                //SqlCommand cmd = new SqlCommand(query, con);
                //cmd.ExecuteNonQuery();
                //con.Close();

                Boolean blnRes = objMsDnH.DeleteContacts(intID);
                
                //Bind Grid
                BindGrid();

            }
        }
        catch (Exception ex)
        {
            WriteLog.ErrorLog.WriteErrorLog(Request.Url.ToString(), ex.Message, "Error in Deleting Row, Admin Enquiry");
            Server.Transfer("../errors/GeneralError.aspx?Message=" + ex.Message);
        }
    }
    protected void gvEnquiry_SelectedIndexChanged(object sender, EventArgs e)
    {
    }


}
