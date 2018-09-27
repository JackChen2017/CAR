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

public partial class Tools_AddinForERP_CAR_QSM_View : FounderTecInfoSys.Common.PageBase.DomainMasterPage 
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
    private QSMInfo qsminfo
    {
        get
        {
            if (ViewState["qsminfo"] == null)
            {
                ViewState["qsminfo"] = new QSMInfo();
            }
            return (QSMInfo)ViewState["qsminfo"];
        }
        set
        {
            ViewState["qsminfo"] = value;
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
            QSMBLL qsmbll = new QSMBLL(FactoryID);
            qsminfo = qsmbll.getQSMInfoByrkey(did);

            if (type == "view")
            {
                if (!HasRight(XmlSource.GetRightIndex("VIEW")) || !HasRight(XmlSource.GetRightIndex("QSM")))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('您没有查看此页面的权限！');</script>");
                    Response.End();
                }
                div_sp.Visible = false;
                CAR_Content.AutoConfigure = CuteEditor.AutoConfigure.None;
                CAR_Content.ActiveTab = CuteEditor.TabType.View;
                CAR_Content.ShowBottomBar = false;
                Info_Content.AutoConfigure = CuteEditor.AutoConfigure.None;
                Info_Content.ActiveTab = CuteEditor.TabType.View;
                Info_Content.ShowBottomBar = false;
                CONF_Content.AutoConfigure = CuteEditor.AutoConfigure.None;
                CONF_Content.ActiveTab = CuteEditor.TabType.View;
                CONF_Content.ShowBottomBar = false;
                InitPage(qsminfo);
            }
            else if(type == "approval")
            {
                if (qsminfo.STATUS == 0 || qsminfo.STATUS == 1 || qsminfo.STATUS == 14)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('此单未在审批中！');</script>");
                    Response.End();
                }
                Check();
                InitPage(qsminfo);
            }
        }
    }
    protected void Check()
    {
        string sqllog = "select * from CAR_Table_LOG where SN_PTR=" + did.ToString() + " and Status = 0 and sn_type = 'QSM' order by sp_step";
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
        CAR_Content.AutoConfigure = CuteEditor.AutoConfigure.None;
        CAR_Content.ActiveTab = CuteEditor.TabType.View;
        CAR_Content.ShowBottomBar = false;
        if (SP_Step == SP_Total_Step)
        {
            div_center.Visible = true;
            Info_Content.AutoConfigure = CuteEditor.AutoConfigure.None;
            Info_Content.ActiveTab = CuteEditor.TabType.View;
            Info_Content.ShowBottomBar = false;
        }
        else
        {
            div_center.Visible = false;
        }

    }

    protected void InitPage(QSMInfo info)
    {
        try
        {
            Serial_No.Text = info.SERIALNO.Trim();
            CustName.Text = info.CUST_NAME.Trim();
            FactoryName.Text = info.FACTORY_NAME;
            Happen_Date.Text = info.HAPPEN_DATE.ToString();
            cust_MaterialNo.Text = info.CUST_MATERIALNO;
            interalNo.Text = info.INTERALNO;
            require_Date.Text = info.REQUIRE_DATE.ToString();
            tousu_level.Text = info.TOUSU_LEVEL;
            tousu_type.Text = info.TOUSU_TYPE;

            CAR_Content.Text = Server.HtmlDecode(info.CAR_CONTENT);
            
            chuhuo_qty.Text = info.CHUHUO_QTY.ToString();
            jiancha_qty.Text = info.JIANCHA_QTY.ToString();
            buliang_qty.Text = info.BULIANG_QTY.ToString();
            buliangbili.Text = info.BULIANGBILI.ToString() + "%";
            buliangDC.Text = info.BULIANGDC;
            zaixian_qty.Text = info.ZAIXIAN_QTY.ToString();
            kucun_qty.Text = info.KUCUN_QTY.ToString();

            try
            {
                if (Convert.ToInt32(info.TUIHUO_STATUS) == 1)
                {
                    tuihuo_status_ck1.Checked = false;
                    tuihuo_status_ck2.Checked = true;
                    tuihuo_qty.Text = info.TUIHUO_QTY.ToString();
                }
                else if (Convert.ToInt32(info.TUIHUO_STATUS) == 0)
                {
                    tuihuo_status_ck1.Checked = true;
                    tuihuo_status_ck2.Checked = false;
                }
                happen_address.Items.FindByValue(info.HAPPEN_ADDRESS.ToString()).Selected = true;

                if (Convert.ToInt32(info.TIJIAO_STATUS.ToString()) == 1)
                {
                    tijiao_status_ck1.Checked = false;
                    tijiao_status_ck2.Checked = true;
                    switch (Convert.ToInt32(info.TIJIAO_TYPE.ToString()))
                    {
                        case 1:
                            tijiao_type_ck1.Checked = true;
                            tijiao_type_ck2.Checked = false;
                            tijiao_type_ck3.Checked = false;
                            break;
                        case 2:
                            tijiao_type_ck1.Checked = false;
                            tijiao_type_ck2.Checked = true;
                            tijiao_type_ck3.Checked = false;
                            break;
                        case 3:
                            tijiao_type_ck1.Checked = false;
                            tijiao_type_ck2.Checked = false;
                            tijiao_type_ck3.Checked = true;
                            break;
                    }
                }
                else
                {
                    tijiao_status_ck1.Checked = true;
                    tijiao_status_ck2.Checked = false;
                }
            }
            catch { }
            notes.Text = info.NOTES;

            dcjiaohuo_qty.Text = info.DCJIAOHUO_QTY.ToString();
            try
            {
                if (Convert.ToInt32(info.ZAITU_STATUS) == 1)
                {
                    zaitu_status_ck1.Checked = false;
                    zaitu_status_ck2.Checked = true;
                    zaitu_qty.Text = info.ZAITU_QTY.ToString();
                }
                else
                {
                    zaitu_status_ck1.Checked = true;
                    zaitu_status_ck2.Checked = false;
                }
                switch (Convert.ToInt32(info.ZAITUCHULI_TYPE.ToString()))
                {
                    case 1:
                        chuli_status_ck1.Checked = true;
                        chuli_status_ck2.Checked = false;
                        chuli_status_ck3.Checked = false;
                        break;
                    case 2:
                        chuli_status_ck1.Checked = false;
                        chuli_status_ck2.Checked = true;
                        chuli_status_ck3.Checked = false;
                        break;
                    case 3:
                        chuli_status_ck1.Checked = false;
                        chuli_status_ck2.Checked = false;
                        chuli_status_ck3.Checked = true;
                        break;
                }
                if (Convert.ToInt32(info.CANGCUN_STATUS) == 1)
                {
                    changleikuchun_status_ck1.Checked = false;
                    changleikuchun_status_ck2.Checked = true;
                }
                else
                {
                    changleikuchun_status_ck1.Checked = true;
                    changleikuchun_status_ck2.Checked = false;
                }
                switch (Convert.ToInt32(info.CANGCUNCHULI_TYPE.ToString()))
                {
                    case 1:
                        chuli_type_ck1.Checked = true;
                        chuli_type_ck2.Checked = false;
                        chuli_type_ck3.Checked = false;
                        chuli_type_ck4.Checked = false;
                        break;
                    case 2:
                        chuli_type_ck1.Checked = false;
                        chuli_type_ck2.Checked = true;
                        chuli_type_ck3.Checked = false;
                        chuli_type_ck4.Checked = false;
                        break;
                    case 3:
                        chuli_type_ck1.Checked = false;
                        chuli_type_ck2.Checked = false;
                        chuli_type_ck3.Checked = true;
                        chuli_type_ck4.Checked = false;
                        break;
                    case 4:
                        chuli_type_ck1.Checked = false;
                        chuli_type_ck2.Checked = false;
                        chuli_type_ck3.Checked = false;
                        chuli_type_ck4.Checked = true;
                        break;
                }
            }
            catch { }

            Info_Content.Text = Server.HtmlDecode(info.INFO_CONTENT);
            CONF_Content.Text = Server.HtmlDecode(info.CONF_CONTENT);
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

        CONF_Content.SetSecurityImageGalleryPath(path);
        CONF_Content.SetSecurityImageGalleryPath(path);
        CONF_Content.SetSecurityMediaGalleryPath(path);
        CONF_Content.SetSecurityFlashGalleryPath(path);
        CONF_Content.SetSecurityFilesGalleryPath(path);
        #endregion
    }

    /// <summary>
    /// 审批通过 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void button_shenpi_yes_Click(object sender, ImageClickEventArgs e)
    {
        QSMBLL qsmbll = new QSMBLL(FactoryID);
        CARLogBLL logbll = new CARLogBLL(FactoryID);
        LogInfo loginfo = new LogInfo();

        #region data
        if (SP_Step == SP_Total_Step)
        {
            qsminfo.CONF_CONTENT = CONF_Content.Text;
            qsminfo.STATUS = 1;
            qsminfo.CLOSE_DATE = DateTime.Now;
            qsmbll.Update(qsminfo);            
        }
        else
        {
            try { qsminfo.DCJIAOHUO_QTY = decimal.Parse(dcjiaohuo_qty.Text); }
            catch { qsminfo.DCJIAOHUO_QTY = 0; }
            if (zaitu_status_ck1.Checked)
            {
                qsminfo.ZAITU_STATUS = 0;
                qsminfo.ZAITU_QTY = 0;
            }
            if (zaitu_status_ck2.Checked)
            {
                qsminfo.ZAITU_STATUS = 1;
                try { qsminfo.ZAITU_QTY = decimal.Parse(zaitu_qty.Text); }
                catch { qsminfo.ZAITU_QTY = 0; }
            }
            if (chuli_status_ck1.Checked) qsminfo.ZAITUCHULI_TYPE = 1;
            if (chuli_status_ck2.Checked) qsminfo.ZAITUCHULI_TYPE = 2;
            if (chuli_status_ck3.Checked) qsminfo.ZAITUCHULI_TYPE = 3;
            if (changleikuchun_status_ck1.Checked)
            {
                qsminfo.CANGCUN_STATUS = 0;
                qsminfo.CANGCUNCHULI_TYPE = 0;
            }
            if (changleikuchun_status_ck2.Checked)
            {
                qsminfo.CANGCUN_STATUS = 1;
                if (chuli_type_ck1.Checked) qsminfo.CANGCUNCHULI_TYPE = 1;
                if (chuli_type_ck2.Checked) qsminfo.CANGCUNCHULI_TYPE = 2;
                if (chuli_type_ck3.Checked) qsminfo.CANGCUNCHULI_TYPE = 3;
                if (chuli_type_ck4.Checked) qsminfo.CANGCUNCHULI_TYPE = 4;
            }
            qsminfo.INFO_CONTENT = Info_Content.Text;

            if (ApprovalTable.Rows.Count == SP_Total_Step)
            {
                qsminfo.FIRST_REPLY_DATE = DateTime.Now;
            }
            if (ApprovalTable.Rows.Count == 2)//倒数第二次审批
            {
                qsminfo.LAST_REPLY_DATE = DateTime.Now;
            }
            qsmbll.Update(qsminfo);
        }
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
        if (ApprovalTable.Rows.Count == 1)
        {
            if (SP_Step == SP_Total_Step)
            {
                sp_user = qsminfo.ENT_USER;
                subject = "客户投诉单，审批通过。";
                string url = System.Configuration.ConfigurationManager.AppSettings["url"].ToString();
                body = url;
            }
        }
        else
        {
            sp_user = ApprovalTable.Rows[1]["sp_user"].ToString();
            subject = "有新的客户投诉单，请审批。";
            string url = System.Configuration.ConfigurationManager.AppSettings["url"].ToString();
            body = url;
        }
        XmlSource.SendEmail(sp_user, subject, body);
        #endregion
        Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('提交成功！');window.opener = null;window.close();</script>");
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
        QSMBLL qsmbll = new QSMBLL(FactoryID);
        CARLogBLL logbll = new CARLogBLL(FactoryID);

        qsminfo.STATUS = 14;
        qsmbll.Update(qsminfo);

        LogInfo loginfo = new LogInfo();
        if (ApprovalTable.Rows.Count > 0)
        {
            loginfo = logbll.GetByKey(int.Parse(ApprovalTable.Rows[0]["rkey"].ToString()));
            loginfo.sp_end_date = DateTime.Now;            
            loginfo.sp_content = SP_Content.Text;
            loginfo.status = 2;
            logbll.UpdateData(loginfo);
        }

        string sp_user = qsminfo.ENT_USER;
        string subject = "客户投诉单，未通过审批。";
        string url = System.Configuration.ConfigurationManager.AppSettings["url"].ToString();
        string body = url;
        XmlSource.SendEmail(sp_user, subject, body);

        Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('提交成功！');window.opener = null;window.close();</script>");
        button_shenpi_yes.Enabled = false;
        button_shenpi_no.Enabled = false;
    }
  
}
