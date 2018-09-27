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

public partial class MyShenPi : FounderTecInfoSys.Common.PageBase.DomainMasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Date_Start.Text = DateTime.Now.AddDays(-10).ToShortDateString();
            Date_End.Text = DateTime.Now.ToShortDateString();
            BindData();
        }
    }
    protected void UltraWebGrid1_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        switch (DataBinder.Eval(e.Data, "status").ToString())
        {
            case "0": e.Row.Cells[7].Value = "未提交审批"; break;
            case "1": e.Row.Cells[7].Value = "审批完成"; break;
            case "14": e.Row.Cells[7].Value = "审批拒绝"; break;
            default: e.Row.Cells[7].Value = "审批中"; break;
        }
        switch (DataBinder.Eval(e.Data, "op_type").ToString())
        {
            case "1": e.Row.Cells[4].Value = "8D"; break;
            case "2": e.Row.Cells[4].Value = "HSF"; break;
            case "3": e.Row.Cells[4].Value = "异常矫正"; break;
            case "4": e.Row.Cells[4].Value = "客户投诉"; break;
            case "5": e.Row.Cells[4].Value = "不良品确认"; break;
            default: break;
        }
    }
    protected void btn_search_Click(object sender, ImageClickEventArgs e)
    {
        BindData();
    }
    protected void BindData()
    {
//        string sql = @"select rkey,serial_no,convert(char(10),issued_date,20) as issued_date,convert(char(10),Required_date,20) as Required_date,custName,op_type,status,
//                        case when op_type=1 then '8D' when op_type=2 then 'HSF' when op_type=3 then 'JIAOZHENG' when op_type=4 then 'QSM' when op_type=5 then 'SA' end as linkName,
//                        c.sp_user
//                        from CAR_Table_Data01 as a 
//                        inner join 
//                        (
//	                        select sn_ptr,sp_user from [CAR_Table_LOG] as b
//	                        where sp_step = (select min(sp_step) from [CAR_Table_LOG] where sn_ptr = b.sn_ptr and status = 0)
//                        ) as c
//                        on a.rkey = c.sn_ptr
//                        where a.status not in (0,1,14)";
//        if (Date_Start.Text != "")
//        {
//            sql += " and datediff(d,issued_date,'" + Date_Start.Text + "') <= 0 ";
//        }
//        if (Date_End.Text != "")
//        {
//            sql += " and datediff(d,issued_date,'" + Date_End.Text + "') >= 0 ";
//        }
//        if (!CurrentUser.RightIsAdmin)
//        {
//            sql += " and sp_user = '" + CurrentUser.UserADAcount + "'";
//        }
        string sql = @" select rkey,serialNo,convert(char(10),ent_date,20) as ent_date,convert(char(10),Require_date,20) as Require_date,
                            cust_name,status,'QSM' as linkName,4 as op_type
                        from Table_CAR_QSM as a
                            inner join
                            (
	                            select sn_ptr,sp_user from [CAR_Table_LOG] as b
	                            where b.sp_step = (select min(sp_step) from [CAR_Table_LOG] where sn_ptr = b.sn_ptr and status = 0 and sn_type = 'QSM')
                                      and b.sn_type = 'QSM'
                            ) as c  on a.rkey = c.sn_ptr
                        where status not in (0,1,14)";
        if (Date_Start.Text != "")
        {
            sql += " and datediff(d,ent_date,'" + Date_Start.Text + "') <= 0 ";
        }
        if (Date_End.Text != "")
        {
            sql += " and datediff(d,ent_date,'" + Date_End.Text + "') >= 0 ";
        }
        if (!CurrentUser.RightIsAdmin)
        {
            sql += " and ent_user = '" + CurrentUser.UserADAcount + "'";
        }
        sql += @"union all
                 select rkey,serialNo,convert(char(10),ent_date,20) as ent_date,null,'',status,'SA',5
                 from Table_CAR_SA as a 
                 inner join
                 (
                    select sn_ptr,sp_user from [CAR_Table_LOG] as b
                    where b.sp_step = (select min(sp_step) from [CAR_Table_LOG] where sn_ptr = b.sn_ptr and status = 0 and sn_type = 'SA')
                          and b.sn_type = 'SA'
                 ) as c on a.rkey = c.sn_ptr
                 where status not in (0)";
        if (Date_Start.Text != "")
        {
            sql += " and datediff(d,ent_date,'" + Date_Start.Text + "') <= 0 ";
        }
        if (Date_End.Text != "")
        {
            sql += " and datediff(d,ent_date,'" + Date_End.Text + "') >= 0 ";
        }
        if (!CurrentUser.RightIsAdmin)
        {
            sql += " and ent_user = '" + CurrentUser.UserADAcount + "'";
        }
        DataTable tb = new DataTable();
        CARDataBLL dataBll = new CARDataBLL(CurrentFactoryID);
        tb = dataBll.GetDataSet(sql);

        UltraWebGrid1.DataSource = tb;
        UltraWebGrid1.DataBind();
    }
}
