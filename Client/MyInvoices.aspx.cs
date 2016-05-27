using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using msdnh.util;
using msdnh.BF.MsDotnetHeaven;

public partial class MyDetails : System.Web.UI.Page
{
    MsDotNetHeaven objMsDnH = new MsDotNetHeaven();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillTransDetails();
            //Show title
            this.Title = "Client Panel :: My Invoices";
            //Create Bread Crumbs
            lblBreadCrumb.Text = String.Format("<a href=\'{0}\'>Home</a>  &gt; <a href=\'{1}\'>My Invoices</a>", ResolveUrl("~"), ResolveUrl("~/MyInvoices.aspx"));

        }

    }
    private void FillTransDetails()
    {
        DataSet ds = new DataSet();
        Double dblDr = 0.00;
        Double dblCr = 0.00;
        Double dblBal = 0.00;
        ds = objMsDnH.GetTransactionDetails(CleanUtils.ToInt(Session["UserID"]), false, "GetTransactionDetails");
        if (ds != null)
        {
            if (ds.Tables["GetTransactionDetails"].Rows.Count > 0)
            {
                int intRows = ds.Tables["GetTransactionDetails"].Rows.Count;
                lblRows.ForeColor = System.Drawing.Color.Blue;
                lblRows.Text = String.Format("Total {0} record(s) found.", intRows);

                //Bind grid
                gvTrans.DataSource = ds;
                gvTrans.DataBind();

                //Calculate Balance Amt.
                foreach (DataRow dRow in ds.Tables["GetTransactionDetails"].Rows)
                {
                    dblDr += CleanUtils.ToDouble(dRow["DRAMT"]);
                    dblCr += CleanUtils.ToDouble(dRow["CRAMT"]);
                }
                dblBal = dblDr - dblCr;
                if (dblBal > 0) //Due payment
                {
                    //Mean mebers has debit balance, due payment alert
                    lblBalAmt.ForeColor = System.Drawing.Color.Red;
                    lblBalAmt.Text = string.Format("Pending Amt. Rs. {0} as on Dt. {1}", dblBal, DateTime.Now.ToString("dd-MMM-yyyy"));
                }
                else
                {
                    lblBalAmt.ForeColor = System.Drawing.Color.Blue;
                    lblBalAmt.Text = string.Format("Final Balance <strong>Rs. <Font color=Red>({0})</Font></strong> as on Dt. {1}", -dblBal, DateTime.Now.ToString("dd-MMM-yyyy"));
                }
            }
            else
            {
                lblRows.ForeColor = System.Drawing.Color.Red;
                lblRows.Text = "No record(s) found.";
            }
        }
        else
        {
            lblRows.ForeColor = System.Drawing.Color.Red;
            lblRows.Text = "No record(s) found.";
        }

    }
    protected void gvTrans_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvTrans.PageIndex = e.NewPageIndex;
        FillTransDetails();
    }


}
