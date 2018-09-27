using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.DirectoryServices;
using System.Data.SqlClient;
using System.Xml;
using WM.Utils;
using WM.Data;
using FounderTecInfoSys.Addin.CAR;
using FounderTecInfoSys.Addin.CAR.Model;
using FounderTecInfoSys.Addin.CAR.BLL;

public partial class Base_Container : FounderTecInfoSys.Common.PageBase.DomainMasterPage
{

    protected string type
    {
        get
        {
            return ViewState["type"].ToString();
        }
        set
        {
            ViewState["type"] = value;
        }
    }
    protected string id
    {
        get
        {
            return ViewState["id"].ToString();
        }
        set
        {
            ViewState["id"] = value;
        }
    }
    protected string rkey
    {
        get
        {
            return ViewState["rkey"].ToString();
        }
        set
        {
            ViewState["rkey"] = value;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            type = string.IsNullOrEmpty(Request.QueryString["type"].ToString()) ? "" : Request.QueryString["type"].ToString();
            id = string.IsNullOrEmpty(Request.QueryString["id"].ToString()) ? "" : Request.QueryString["id"].ToString();
            rkey = string.IsNullOrEmpty(Request.QueryString["rkey"].ToString()) ? "" : Request.QueryString["rkey"].ToString();

            BindData();
        }
    }
    protected void BindData()
    {
        string columnName="";
        string tableName="";
        if (type == "QSM")
        {
            tableName = "table_car_qsm";
            if (id == "1")
            {
                columnName = "CAR_Content";
            }
            else if (id == "2")
            {
                columnName = "info_content";
            }
            else if (id == "3")
            {
                columnName = "conf_content";
            }
        }
        if (!string.IsNullOrEmpty(columnName) && !string.IsNullOrEmpty(tableName))
        {
            string sql = "select "+columnName+" from "+tableName+ " where rkey = "+rkey;
            CARDataBLL cardatabll = new CARDataBLL(CurrentFactoryID);
            DataTable tb = new DataTable();
            tb = cardatabll.GetDataSet(sql);
            if (tb != null && tb.Rows.Count > 0)
            {
                Content.Text = Server.HtmlDecode(tb.Rows[0][0].ToString());
            }
        }
    }
}
