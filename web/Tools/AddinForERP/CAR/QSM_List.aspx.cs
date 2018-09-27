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

public partial class Tools_AddinForERP_CAR_QSM_List : FounderTecInfoSys.Common.PageBase.DomainMasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Date_Start.Text = DateTime.Now.AddDays(-10).ToShortDateString();
            Date_End.Text = DateTime.Now.ToShortDateString();
            if (!HasRight(XmlSource.GetRightIndex("QSM")) || !HasRight(XmlSource.GetRightIndex("VIEW")))
            {
                Response.Write("<script>alert('你没有权限进入此页面!');</script>");
                Response.End();
            }
        }
    }
    protected void btn_search_Click(object sender, ImageClickEventArgs e)
    {
        string sql = "select rkey,SerialNo,convert(char(10),ent_Date,20) as ent_Date,factory_Name,Cust_Name,cust_materialno,interalNo,status from Table_CAR_QSM where 1=1 ";
        if (CustName.Text.Trim() != "")
        {
            sql += " and Cust_Name like '%" + CustName.Text.Trim() + "%' ";
        }
        if (Date_Start.Text != "")
        {
            sql += " and datediff(d,ent_Date,'" + Date_Start.Text + "') <= 0 ";
        }
        if (Date_End.Text != "")
        {
            sql += " and datediff(d,ent_Date,'" + Date_End.Text + "') >= 0";
        }
        DataTable tb = new DataTable();
        CARDataBLL dataBll = new CARDataBLL(CurrentFactoryID);
        tb = dataBll.GetDataSet(sql);
        UltraWebGrid1.DataSource = tb;
        UltraWebGrid1.DataBind();
    }
    protected void UltraWebGrid1_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        switch (DataBinder.Eval(e.Data, "status").ToString())
        {
            case "0": e.Row.Cells[8].Value = "未提交审批"; break;
            case "1": e.Row.Cells[8].Value = "审批完成"; break;
            case "14": e.Row.Cells[8].Value = "审批拒绝"; break;
            default: e.Row.Cells[8].Value = "审批中"; break;
        }
    }
}
