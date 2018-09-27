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
using WM.Utils;
using WM.Data;
using FounderTecInfoSys.Addin.CAR;
using FounderTecInfoSys.Addin.CAR.Model;
using FounderTecInfoSys.Addin.CAR.BLL;

public partial class Tools_AddinForERP_CAR_SA_View : FounderTecInfoSys.Common.PageBase.DomainMasterPage
{
    #region 字段
    /// <summary>
    /// 工厂ID
    /// </summary>
    protected int FactoryID
    {
        get { return int.Parse(ViewState["FactoryID"].ToString()); }
        set { ViewState["FactoryID"] = value; }
    }
    protected string UserAD
    {
        get { return ViewState["UserAD"].ToString(); }
        set { ViewState["UserAD"] = value; }
    }
    protected int did
    {
        get { return int.Parse(ViewState["did"].ToString()); }
        set { ViewState["did"] = value; }
    }
    protected int SP_Step
    {
        get { return int.Parse(ViewState["SP_Step"].ToString()); }
        set { ViewState["SP_Step"] = value; }
    }
    protected int SP_Total_Step
    {
        get { return int.Parse(ViewState["SP_Total_Step"].ToString()); }
        set { ViewState["SP_Total_Step"] = value; }
    }
    private SAInfo saInfo
    {
        get
        {
            if (ViewState["saInfo"] == null)
            {
                ViewState["saInfo"] = new SAInfo();
            }
            return (SAInfo)ViewState["saInfo"];
        }
        set
        {
            ViewState["saInfo"] = value;
        }
    }
    private DataTable ApprovalTable
    {
        get
        {
            if (ViewState["ApprovalTable"] == null)
            {
                ViewState["ApprovalTable"] = new DataTable();
            }
            return (DataTable)ViewState["ApprovalTable"];
        }
        set
        {
            ViewState["ApprovalTable"] = value;
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
    private DataTable tb_SA
    {
        get
        {
            if (ViewState["tb_SA"] == null)
            {
                ViewState["tb_SA"] = new DataTable();
            }
            return (DataTable)ViewState["tb_SA"];
        }
        set
        {
            ViewState["tb_SA"] = value;
        }
    }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FactoryID = String.IsNullOrEmpty(Request.QueryString["FID"]) ? 98 : int.Parse(Request.QueryString["FID"]);
            did = String.IsNullOrEmpty(Request.QueryString["did"]) ? 0 : int.Parse(Request.QueryString["did"]);
            type = String.IsNullOrEmpty(Request.QueryString["type"]) ? "view" : Request.QueryString["type"];
            try
            {
                this.UserAD = CurrentUser.UserADAcount;
            }
            catch
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('用户AD丢失！');</script>");
                Response.End();
            }

            SABLL saBLL = new SABLL(FactoryID);
            saInfo = saBLL.getSAInfoByrkey(did);

            if (type == "view")
            {
                if (!HasRight(XmlSource.GetRightIndex("VIEW")) || !HasRight(XmlSource.GetRightIndex("SA")))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('您没有查看此页面的权限！');</script>");
                    Response.End();
                }
                div_sp.Visible = false;
                InitPage(saInfo);
            }
            else if (type == "approval")
            {
                Check();
                InitPage(saInfo);
            }
        }
    }
    protected void Check()
    {
        string sqllog = "select * from CAR_Table_LOG where SN_PTR=" + did.ToString() + " and sn_type = 'SA' and Status = 0 order by sp_step";
        CARLogBLL logBll = new CARLogBLL(FactoryID);
        ApprovalTable = logBll.GetDataSet(sqllog);
        if (ApprovalTable.Rows.Count > 0)
        {
            if (ApprovalTable.Rows[0]["SP_User"].ToString() != UserAD && !CurrentUser.RightIsAdmin)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('您没有审批此单的权限！');</script>");
                div_sp.Visible = false;
                Response.End();
            }
            SP_Step = int.Parse(ApprovalTable.Rows[0]["sp_step"].ToString());
            SP_Total_Step = int.Parse(ApprovalTable.Rows[0]["SP_Total_Step"].ToString());
        }
    }

    protected void InitPage(SAInfo info)
    {
        try
        {
            SAListBLL saBll = new SAListBLL(CurrentFactoryID);
            tb_SA = saBll.GetDataSet("select * from CAR_Table_SAList where sn_ptr = " + did.ToString());
            GridView3.DataSource = tb_SA;
            GridView3.DataBind();
            Serial_No.Text = info.SERIALNO;
            CAR_Content.Text = Server.HtmlDecode(info.CAR_CONTENT);

            CAR_Content.AutoConfigure = CuteEditor.AutoConfigure.None;
            CAR_Content.ActiveTab = CuteEditor.TabType.View;
            CAR_Content.ShowBottomBar = false;
            CAR_Content.ReadOnly = true;
        }
        catch { }
        #region 文件路径

        string id = System.Web.HttpContext.Current.User.Identity.Name.Replace("FOUNDERPCB\\", "");

        id = id + @"/" + System.DateTime.Now.Date.ToShortDateString();

        //Response.Write("id" + id);


        //建立用户目录
        string path = Server.MapPath(@"uploads/" + id);

        if (!System.IO.Directory.Exists(path))
        {
            System.IO.Directory.CreateDirectory(path);//在指定路径下新建一个文件夹
        }

        CAR_Content.SetSecurityImageGalleryPath(path);
        CAR_Content.SetSecurityImageGalleryPath(path);
        CAR_Content.SetSecurityMediaGalleryPath(path);
        CAR_Content.SetSecurityFlashGalleryPath(path);
        CAR_Content.SetSecurityFilesGalleryPath(path);

        #endregion
    }

    /// <summary>
    /// 审批通过 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void button_shenpi_yes_Click(object sender, ImageClickEventArgs e)
    {
        SABLL saBLL = new SABLL(FactoryID);
        CARLogBLL logbll = new CARLogBLL(FactoryID);
        LogInfo loginfo = new LogInfo();
        #region data
        if (SP_Step == SP_Total_Step)
        {
            saInfo.STATUS = 1;
            saInfo.CLOSE_DATE = DateTime.Now;
        }
        saBLL.Update(saInfo);
        #endregion
        #region log
        if (ApprovalTable.Rows.Count >= 1)
        {
            loginfo = logbll.GetByKey(int.Parse(ApprovalTable.Rows[0]["rkey"].ToString()));
            loginfo.sp_end_date = DateTime.Now;
            loginfo.sp_content = SP_Content.Text;
            loginfo.status = 1;
            logbll.UpdateData(loginfo);
            if (ApprovalTable.Rows.Count >= 2)
            {
                loginfo = logbll.GetByKey(int.Parse(ApprovalTable.Rows[1]["rkey"].ToString()));
                loginfo.sp_start_date = DateTime.Now;
                logbll.UpdateData(loginfo);
            }
        }
        #endregion
        #region mail
        string sp_user = "";
        string subject = "";
        string body = "";
        if (ApprovalTable.Rows.Count == 1 )
        {
            if (SP_Step == SP_Total_Step)
            {
                sp_user = saInfo.ENT_USER;
                subject = "不良品确认单，审批通过。";
                string url = System.Configuration.ConfigurationManager.AppSettings["url"].ToString();
                body = url;
            }
            else
            {
                sp_user = ApprovalTable.Rows[1]["sp_user"].ToString();
                subject = "有新的不良品确认单，请审批。";
                string url = System.Configuration.ConfigurationManager.AppSettings["url"].ToString();
                body = url;
            }
            XmlSource.SendEmail(sp_user, subject, body);
        }
        #endregion
        Response.Write("<script language='javaScript'>alert('操作成功');window.opener = null;window.close();</script>");//无提示关闭页面
        button_shenpi_yes.Enabled = false;
        button_shenpi_no.Enabled = false;
    }

    /// <summary>
    /// 拒绝
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void button_shenpi_no_Click(object sender, ImageClickEventArgs e)
    {
        CARDataBLL dataBll = new CARDataBLL(FactoryID);
        CARLogBLL logbll = new CARLogBLL(FactoryID);
        DataInfo datainfo = new DataInfo();
        #region data
        datainfo = dataBll.GetByKey(did);
        datainfo.status = 14;//拒绝
        dataBll.UpdateData(datainfo);
        #endregion
        #region log
        LogInfo loginfo = new LogInfo();
        if (ApprovalTable.Rows.Count > 0)
        {
            loginfo = logbll.GetByKey(int.Parse(ApprovalTable.Rows[0]["rkey"].ToString()));
            loginfo.sp_end_date = DateTime.Now;
            loginfo.sp_content = SP_Content.Text;
            loginfo.status = 2;
            logbll.UpdateData(loginfo);
        }
        #endregion
        #region mail
        string sp_user = datainfo.nowuser;
        string subject = "不良品确认单，未通过审批。";
        string url = System.Configuration.ConfigurationManager.AppSettings["url"].ToString();
        string body = url;
        XmlSource.SendEmail(sp_user, subject, body);
        #endregion

        Response.Write("<script language='javaScript'>alert('操作成功');window.opener = null;window.close();</script>");//无提示关闭页面
        button_shenpi_yes.Enabled = false;
        button_shenpi_no.Enabled = false;
    }
}
