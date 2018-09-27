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


public partial class SAReport : FounderTecInfoSys.Common.PageBase.DomainMasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!HasRight(XmlSource.GetRightIndex("SA")) || !HasRight(XmlSource.GetRightIndex("VIEW")))
            {
                Response.Clear();
                Response.Write("<script>alert('你没有权限进入此页面!');</script>");
                Response.End();
            }
            InitWebElement();
            BindData();
        }
    }
    protected void InitWebElement()
    {
        tb_DateStart.Text = DateTime.Now.AddMonths(-1).ToShortDateString();
        tb_DateEnd.Text = DateTime.Now.ToShortDateString();
    }
    protected void BindData()
    {
        string sql = @"select a.serialNo,a.status,b.*
                       from table_car_sa as a inner join car_table_salist as b on a.rkey = b.sn_ptr
                       where 1=1 ";
        if (tb_DateStart.Text.Trim() != "")
        {
            sql += " and datediff(d,a.ent_Date,'" + tb_DateStart.Text + "') <= 0 ";
        }
        if (tb_DateEnd.Text.Trim() != "")
        {
            sql += " and datediff(d,a.ent_Date,'" + tb_DateEnd.Text + "') >= 0";
        }
        if (tb_CustName.Text.Trim() != "")
        {
            sql += " and b.custName like '%" + tb_CustName.Text.Trim() + "'";
        }
        CARDataBLL cardataBll = new CARDataBLL(CurrentFactoryID);
        DataTable tb = new DataTable();
        tb = cardataBll.GetDataSet(sql);

        GridView1.DataSource = tb;
        GridView1.DataBind();
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
    }
    protected void lkbtn_ToExcel_Click(object sender, EventArgs e)
    {
        FounderTecInfoSys.Common.CommonFunction.OutputFunction.ToExecl(GridView1, "SA" + DateTime.Now.ToShortDateString());
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
            {
                switch (DataBinder.Eval(e.Row.DataItem, "status").ToString())
                {
                    case "0": e.Row.Cells[2].Text = "未提交审批"; break;
                    case "1": e.Row.Cells[2].Text = "审批完成"; break;
                    case "14": e.Row.Cells[2].Text = "审批拒绝"; break;
                    default: e.Row.Cells[2].Text = "审批中"; break;
                }
                e.Row.Cells[3].Text = string.Format("{0:yyyy-MM-dd}", DataBinder.Eval(e.Row.DataItem, "recordDateTime"));
                e.Row.Cells[15].Text = string.Format("{0:yyyy-MM-dd}", DataBinder.Eval(e.Row.DataItem, "signDate"));
            }
        }
    }
}
