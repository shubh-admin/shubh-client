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

/// <summary>
/// Summary description for Image1
/// </summary>
public class Image1
{
    #region Variables

    private int _itemslno;
    private int _ID;
    private string _Image;
    private string _Categoryname;
    private string _ImgCap;
    private string _ImgDescr;
    private decimal _CostINR;
    private decimal _CostUSD;
    public string _idd;

    #endregion


    #region Property
    public int ID
    {
        get { return _ID; }
        set { _ID = value; }

    }
    public int itemslno
    {
        get { return _itemslno; }
        set { _itemslno = value; }

    }
    public string Image
    {
        get { return _Image; }
        set { _Image = value; }

    }


    public string Categoryname
    {
        get { return _Categoryname; }
        set { _Categoryname = value; }

    }

    public string ImageCaption
    {
        get { return _ImgCap; }
        set { _ImgCap = value; }

    }
    public string ImageDescr
    {
        get { return _ImgDescr; }
        set { _ImgDescr = value; }

    }
    public decimal CostINR
    {
        get { return _CostINR; }
        set { _CostINR = value; }

    }
    public decimal CostUSD
    {
        get { return _CostUSD; }
        set { _CostUSD = value; }

    }
    public string idd
    {
        get { return _idd; }
        set { _idd = value; }

    }
    #endregion
    public Image1()
    {

    }

    public Image1(int itemslno, string Image, string Categoryname, string ImageCap, string ImgDescr, decimal CostInr, decimal CostUsd, string id)
    {
        _itemslno = itemslno;
        _Image = Image;
        _Categoryname = Categoryname;
        _ImgCap = ImageCap;
        _ImgDescr = ImgDescr;
        _CostINR = CostInr;
        _CostUSD = CostUsd;
        _idd = id;
    }

}
