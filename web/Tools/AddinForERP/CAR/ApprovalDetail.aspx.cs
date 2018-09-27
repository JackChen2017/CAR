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

public partial class Tools_AddinForERP_CAR_ApprovalDetail : FounderTecInfoSys.Common.PageBase.DomainMasterPage 
{
    private int did
    {
        get
        {
            if (ViewState["did"] == null)
            {
                ViewState["did"] = "0";
            }
            return int.Parse(ViewState["did"].ToString());
        }
        set
        {
            ViewState["did"] = value;
        }
    }
    private string type
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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!HasRight(XmlSource.GetRightIndex("VIEW")))
            {
                Response.Write("<script>alert('你没有权限进入此页面!');</script>");
                Response.End();
                return;
            }
            did = String.IsNullOrEmpty(Request.QueryString["did"]) ? 0 : int.Parse(Request.QueryString["did"]);
            type = string.IsNullOrEmpty(Request.QueryString["type"]) ? "" : Request.QueryString["type"].ToString();
            BindData();
        }
    }
    protected void BindData()
    {
        CARDataBLL dataBll = new CARDataBLL(CurrentFactoryID);
        DataInfo dataInfo = dataBll.GetByKey(did);
        if (dataInfo.status == 0)
        {
            Response.Write("<script>alert('未发启审批!');</script>");
            return;
        }
        CARLogBLL logBll = new CARLogBLL(CurrentFactoryID);
        DataTable tb = new DataTable();
        string sql = "select SP_Step ,SP_User,Status,SP_Content from [CAR_Table_LOG] where sn_ptr = " + did.ToString() + " and sn_type = '"+ type +"' order by SP_Step";
        tb = logBll.GetDataSet(sql);
        if (tb.Rows.Count == 0)
        {
            Response.Write("<script>alert('无数据!');window.opener = null;window.close();</script>");
            return;
        }
        foreach (DataRow row in tb.Rows)
        {
            row["sp_user"] = GetUserName(row["sp_user"].ToString());
        }
        GridView1.DataSource = tb;
        GridView1.DataBind();
    }
    public string GetUserName(string loginName)
    {
        if (!loginName.StartsWith("founderpcb\\"))
        {
            loginName = "founderpcb\\" + loginName;
        }
        return FounderTecInfoSys.Common.CommonFunction.FuncForDomain.GetUserName(
            System.Configuration.ConfigurationManager.AppSettings["DomainName"],
            System.Configuration.ConfigurationManager.AppSettings["NameOfLoginAD"],
            System.Configuration.ConfigurationManager.AppSettings["PWDofLoginAD"],
            loginName
            );
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
            {
                if (DataBinder.Eval(e.Row.DataItem, "status").ToString() == "1")
                {
                    e.Row.Cells[2].Text = "审批通过";
                }
                else if (DataBinder.Eval(e.Row.DataItem, "status").ToString() == "2")
                {
                    e.Row.Cells[2].Text = "审批拒绝";
                }
                else if (DataBinder.Eval(e.Row.DataItem, "status").ToString() == "0")
                {
                    e.Row.Cells[2].Text = "未审批";
                }
            }
        }
    }
}
