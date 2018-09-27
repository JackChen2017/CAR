using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.DirectoryServices;
using System.Data.SqlClient;
using System.Text;
using System.Xml;
using WM.Utils;
using WM.Data;
using FounderTecInfoSys.Addin.CAR;
using FounderTecInfoSys.Addin.CAR.Model;
using FounderTecInfoSys.Addin.CAR.BLL;

public partial class QSMReport : FounderTecInfoSys.Common.PageBase.DomainMasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!HasRight(XmlSource.GetRightIndex("QSM")) || !HasRight(XmlSource.GetRightIndex("VIEW")))
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
        QSMBLL qsmBLL = new QSMBLL(CurrentFactoryID);
        IList<QSMInfo> qsmList = new List<QSMInfo>();
        
        string strWhere = " 1=1 ";

        if (tb_DateStart.Text.Trim() != "")
        {
            strWhere += " and datediff(d,ent_Date,'" + tb_DateStart.Text + "') <= 0 ";
        }
        if (tb_DateEnd.Text.Trim() != "")
        {
            strWhere += " and datediff(d,ent_Date,'" + tb_DateEnd.Text + "') >= 0";
        }
        if (tb_CustName.Text.Trim() != "")
        {
            strWhere += " and cust_name like '%" + tb_CustName.Text.Trim() + "'";
        }

        qsmList = qsmBLL.FindBySql(strWhere);

        GridView1.DataSource = qsmList;
        GridView1.DataBind();
    }
    protected void btn_Query_Click(object sender, EventArgs e)
    {
        BindData();
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
                e.Row.Cells[3].Text = string.Format("{0:yyyy-MM-dd}", DataBinder.Eval(e.Row.DataItem, "require_date"));
                #region e.Row.Cells[10].Text
                StringBuilder strInfo = new StringBuilder();
                strInfo.Append("出货数量:"+DataBinder.Eval(e.Row.DataItem, "chuhuo_qty").ToString());
                strInfo.Append("  检查/上线数量:"+DataBinder.Eval(e.Row.DataItem, "jiancha_qty").ToString());
                strInfo.Append("  不良数量:" + DataBinder.Eval(e.Row.DataItem, "buliang_qty").ToString());
                strInfo.Append("  不良比例:" + DataBinder.Eval(e.Row.DataItem, "buliangbili").ToString()+"%");
                strInfo.Append("  不良D/C:" + DataBinder.Eval(e.Row.DataItem, "buliangDC").ToString());
                strInfo.Append("  客户在线数量:" + DataBinder.Eval(e.Row.DataItem, "zaixian_qty").ToString());
                strInfo.Append("  客户库存数量:" + DataBinder.Eval(e.Row.DataItem, "kucun_qty").ToString());
                if (DataBinder.Eval(e.Row.DataItem, "tuihuo_status").ToString() == "0")
                {
                    strInfo.Append("  无退货");
                }
                else if (DataBinder.Eval(e.Row.DataItem, "tuihuo_status").ToString() == "1")
                {
                    strInfo.Append("  退货数量:" + DataBinder.Eval(e.Row.DataItem, "tuihuo_qty").ToString());    
                }
                switch (DataBinder.Eval(e.Row.DataItem, "happen_address").ToString())
                {
                    case "1": strInfo.Append("  客户端发生场所:IQC"); break;
                    case "2": strInfo.Append("  客户端发生场所:SMT"); break;
                    case "3": strInfo.Append("  客户端发生场所:测试"); break;
                    case "4": strInfo.Append("  客户端发生场所:装配"); break;
                    case "5": strInfo.Append("  客户端发生场所:客户售后"); break;
                    default: break;
                }
                if (DataBinder.Eval(e.Row.DataItem, "tijiao_status").ToString() == "0")
                {
                    strInfo.Append("  不用提交报告");    
                }
                else if (DataBinder.Eval(e.Row.DataItem, "tijiao_status").ToString() == "1")
                {
                    switch (DataBinder.Eval(e.Row.DataItem, "tijiao_type").ToString())
                    {
                        case "1": strInfo.Append("  提交报告格式:客户格式"); break;
                        case "2": strInfo.Append("  提交报告格式:Founder 8D "); break;
                        case "3": strInfo.Append("  提交报告格式:Founder PPT"); break;
                        default: break;
                    }
                }

                e.Row.Cells[10].Text = strInfo.ToString();
                #endregion

                #region e.Row.Cells[12]
                StringBuilder clzk = new StringBuilder();
                clzk.Append("同DC交货总数:" + DataBinder.Eval(e.Row.DataItem, "dcjiaohuo_qty").ToString());
                if (DataBinder.Eval(e.Row.DataItem, "zaitu_status").ToString() == "0")
                {
                    clzk.Append("  无在途货");
                }
                else if (DataBinder.Eval(e.Row.DataItem, "zaitu_status").ToString() == "1")
                {
                    clzk.Append("  在途数量:" + DataBinder.Eval(e.Row.DataItem, "zaitu_qty").ToString());
                    switch (DataBinder.Eval(e.Row.DataItem, "zaituchuli_type").ToString())
                    {
                        case "1": clzk.Append("处理意见:召回"); break;
                        case "2": clzk.Append("处理意见:赴客户端处理"); break;
                        case "3": clzk.Append("处理意见:返工"); break;
                        default: break;
                    }
                }
                if (DataBinder.Eval(e.Row.DataItem, "cangcun_status").ToString() == "0")
                {
                    clzk.Append("  无厂内仓存板");
                }
                else if (DataBinder.Eval(e.Row.DataItem, "cangcun_status").ToString() == "1")
                {
                    clzk.Append("  存在厂内仓存板");
                    switch (DataBinder.Eval(e.Row.DataItem, "zaituchuli_type").ToString())
                    {
                        case "1": clzk.Append("  处理方法:全检"); break;
                        case "2": clzk.Append("  处理方法:返工"); break;
                        case "3": clzk.Append("  处理方法:返测"); break;
                        case "4": clzk.Append("  处理方法:报废"); break;
                        default: break;
                    }
                }
                e.Row.Cells[12].Text = clzk.ToString();
                #endregion
                e.Row.Cells[14].Text = string.Format("{0:yyyy-MM-dd}", DataBinder.Eval(e.Row.DataItem, "last_reply_date"));
                e.Row.Cells[15].Text = string.Format("{0:yyyy-MM-dd}", DataBinder.Eval(e.Row.DataItem, "close_date"));
            }
        }
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
    }
    protected void lkbtn_ToExcel_Click(object sender, EventArgs e)
    {
        FounderTecInfoSys.Common.CommonFunction.OutputFunction.ToExecl(GridView1, "QSM" + DateTime.Now.ToShortDateString());
    }
}
