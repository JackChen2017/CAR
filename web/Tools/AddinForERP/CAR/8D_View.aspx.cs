﻿using System;
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

public partial class _8D_View : FounderTecInfoSys.Common.PageBase.DomainMasterPage 
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
    private DataInfo dataInfo
    {
        get
        {
            if (ViewState["dataInfo"] == null)
            {
                ViewState["dataInfo"] = new DataInfo();
            }
            return (DataInfo)ViewState["dataInfo"];
        }
        set
        {
            ViewState["dataInfo"] = value;
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
            CARDataBLL dataBll = new CARDataBLL(FactoryID);
            dataInfo = dataBll.GetByKey(did);
            if (dataInfo.op_type != 1)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('非法访问！');</script>");
                Response.End();
            }

            if (type == "view")
            {
                if (!HasRight(XmlSource.GetRightIndex("VIEW")) || !HasRight(XmlSource.GetRightIndex("BD")))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('您没有查看此页面的权限！');</script>");
                    Response.End();
                }
                div_sp.Visible = false;
                Interim_Action.AutoConfigure = CuteEditor.AutoConfigure.None;
                Interim_Action.ActiveTab = CuteEditor.TabType.View;
                Interim_Action.ShowBottomBar = false;
                Info_Content.AutoConfigure = CuteEditor.AutoConfigure.None;
                Info_Content.ActiveTab = CuteEditor.TabType.View;
                Info_Content.ShowBottomBar = false;
                Corrective_Action.AutoConfigure = CuteEditor.AutoConfigure.None;
                Corrective_Action.ActiveTab = CuteEditor.TabType.View;
                Corrective_Action.ShowBottomBar = false;
                IPCA.AutoConfigure = CuteEditor.AutoConfigure.None;
                IPCA.ActiveTab = CuteEditor.TabType.View;
                IPCA.ShowBottomBar = false;
                ATPR.AutoConfigure = CuteEditor.AutoConfigure.None;
                ATPR.ActiveTab = CuteEditor.TabType.View;
                ATPR.ShowBottomBar = false;
                CONF_Content.AutoConfigure = CuteEditor.AutoConfigure.None;
                CONF_Content.ActiveTab = CuteEditor.TabType.View;
                CONF_Content.ShowBottomBar = false;
                InitPage(dataInfo);
            }
            else if (type == "approval")
            {
                if (dataInfo.status == 0 || dataInfo.status == 1 || dataInfo.status == 14)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('此单未在审批中！');</script>");
                    Response.End();
                }
                Check();
                InitPage(dataInfo);
            }
        }
    }
    #region 初始化发出单位异常单位列表
    /// <summary>
    /// 初始化发出单位异常单位列表
    /// </summary>
    /// <param name="i">工厂ID</param>
    protected void Init_Company(int i)
    {
        From_Comp.Items.Clear();
        CAR_Comp.Items.Clear();

        XmlDocument doc = new XmlDocument();
        doc.Load(Server.MapPath(".") + @"\Configuration\CompanyAndUser.xml");
        XmlNodeList nodeList;
        XmlNode root = doc.DocumentElement;
        nodeList = root.SelectNodes("//configuration/list" + i.ToString().Trim() + "/item");
        foreach (XmlNode nodeitem in nodeList)
        {
            string tmp = nodeitem.Attributes["name"].Value.ToString();
            From_Comp.Items.Add(tmp);
            CAR_Comp.Items.Add(tmp);
        }

    }
    #endregion
    protected void Check()
    {
        string sqllog = "select * from CAR_Table_LOG where SN_PTR=" + did.ToString() + " and Status = 0 order by sp_step";
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
        if (SP_Step == SP_Total_Step)
        {
            div_center.Visible = true;
            Interim_Action.AutoConfigure = CuteEditor.AutoConfigure.None;
            Interim_Action.ActiveTab = CuteEditor.TabType.View;
            Interim_Action.ShowBottomBar = false;
            Info_Content.AutoConfigure = CuteEditor.AutoConfigure.None;
            Info_Content.ActiveTab = CuteEditor.TabType.View;
            Info_Content.ShowBottomBar = false;
            Corrective_Action.AutoConfigure = CuteEditor.AutoConfigure.None;
            Corrective_Action.ActiveTab = CuteEditor.TabType.View;
            Corrective_Action.ShowBottomBar = false;
            IPCA.AutoConfigure = CuteEditor.AutoConfigure.None;
            IPCA.ActiveTab = CuteEditor.TabType.View;
            IPCA.ShowBottomBar = false;
            ATPR.AutoConfigure = CuteEditor.AutoConfigure.None;
            ATPR.ActiveTab = CuteEditor.TabType.View;
            ATPR.ShowBottomBar = false;
        }
        else
        {
            div_center.Visible = false;
        }

    }

    protected void InitPage(DataInfo info)
    {
        Init_Company(1);
        CAR_Content.AutoConfigure = CuteEditor.AutoConfigure.None;
        try
        {
            Required_Date.Text = info.required_date.ToString();
            Serial_No.Text = info.serial_no;
            Happen_Date.Text = info.happen_date.ToString();
            From_Comp.Items.FindByText(info.from_comp).Selected = true;
            CAR_Comp.Items.FindByText(info.car_comp).Selected = true;
            Issued_User.Text = info.issued_user;
            Issued_APP.Text = info.issued_app;
            Received_User.Text = info.received_user;

            CAR_Content.Text = Server.HtmlDecode(info.car_content);
            CAR_Content.AutoConfigure = CuteEditor.AutoConfigure.None;
            CAR_Content.ActiveTab = CuteEditor.TabType.View;
            CAR_Content.ShowBottomBar = false;

            Interim_Action.Text = Server.HtmlDecode(info.interim_action);
            IA_Date.Text = info.ia_date.ToString();
            Info_Content.Text = Server.HtmlDecode(info.info_content);
            Info_Date.Text = info.Info_Date.ToString();
            Corrective_Action.Text = Server.HtmlDecode(info.corrective_action);
            CA_Date.Text = info.ca_date.ToString();
            IPCA.Text = Server.HtmlDecode(info.ipca);
            IPCA_Date.Text = info.ipca_date.ToString();
            ATPR.Text = Server.HtmlDecode(info.atpr);
            ATPR_Date.Text = info.ipca_date.ToString();
            CONF_Content.Text = Server.HtmlDecode(info.conf_content);
            if ((int)info.sop_status == 1)
            {
                SOP_Status_ck_2.Checked = true;
                SOP_Name.Text = info.sop_name;
            }
            else
            {
                SOP_Status_ck_1.Checked = true;
                SOP_Name.Text = "";
            }
            Z_APP.Text = info.z_app;
            Z_User.Text = info.z_user;
            SOP_Date.Text = info.sop_date.ToString();
            CONF_User.Text = info.conf_user;
            CONF_User_Date.Text = info.conf_user_date.ToString();
            CONF_APP.Text = info.conf_app;
            CONF_APP_Date.Text = info.conf_app_date.ToString();
        }
        catch(Exception ex)
        { }
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

        Interim_Action.SetSecurityImageGalleryPath(path);
        Interim_Action.SetSecurityImageGalleryPath(path);
        Interim_Action.SetSecurityMediaGalleryPath(path);
        Interim_Action.SetSecurityFlashGalleryPath(path);
        Interim_Action.SetSecurityFilesGalleryPath(path);

        Info_Content.SetSecurityImageGalleryPath(path);
        Info_Content.SetSecurityImageGalleryPath(path);
        Info_Content.SetSecurityMediaGalleryPath(path);
        Info_Content.SetSecurityFlashGalleryPath(path);
        Info_Content.SetSecurityFilesGalleryPath(path);

        Corrective_Action.SetSecurityImageGalleryPath(path);
        Corrective_Action.SetSecurityImageGalleryPath(path);
        Corrective_Action.SetSecurityMediaGalleryPath(path);
        Corrective_Action.SetSecurityFlashGalleryPath(path);
        Corrective_Action.SetSecurityFilesGalleryPath(path);

        IPCA.SetSecurityImageGalleryPath(path);
        IPCA.SetSecurityImageGalleryPath(path);
        IPCA.SetSecurityMediaGalleryPath(path);
        IPCA.SetSecurityFlashGalleryPath(path);
        IPCA.SetSecurityFilesGalleryPath(path);

        ATPR.SetSecurityImageGalleryPath(path);
        ATPR.SetSecurityImageGalleryPath(path);
        ATPR.SetSecurityMediaGalleryPath(path);
        ATPR.SetSecurityFlashGalleryPath(path);
        ATPR.SetSecurityFilesGalleryPath(path);

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
        CARDataBLL dataBll = new CARDataBLL(FactoryID);
        CARLogBLL logbll = new CARLogBLL(FactoryID);
        DataInfo datainfo = new DataInfo();
        LogInfo loginfo = new LogInfo();
        #region data
        datainfo = dataBll.GetByKey(did);
        if (SP_Step == 1 && datainfo.serial_no.Trim().Length < 5)   //第一步审批之后获得单号
        {
            datainfo.serial_no = dataBll.getSerialNo(datainfo.serial_no);
        }
        if (SP_Step == SP_Total_Step)
        {
            datainfo.conf_content = CONF_Content.Text;
            datainfo.conf_user = CONF_User.Text.Trim();
            try{datainfo.conf_user_date = Convert.ToDateTime(CONF_User_Date.Text.Trim());}
            catch{}
            datainfo.conf_app = CONF_APP.Text;
            try{datainfo.conf_app_date = Convert.ToDateTime(CONF_APP_Date.Text.Trim());}
            catch{}
            datainfo.status = 1;
            dataBll.UpdateData(datainfo);

        }
        else
        {
            datainfo.interim_action = Interim_Action.Text;
            try { datainfo.ia_date = Convert.ToDateTime(IA_Date.Text.Trim()); }
            catch { }
            datainfo.info_content = Info_Content.Text;
            try { datainfo.Info_Date = Convert.ToDateTime(Info_Date.Text.Trim()); }
            catch { }
            datainfo.corrective_action = Corrective_Action.Text;
            try { datainfo.ca_date = Convert.ToDateTime(CA_Date.Text.Trim()); }
            catch { }
            datainfo.ipca = IPCA.Text;
            try {  datainfo.ipca_date = Convert.ToDateTime(IPCA_Date.Text.Trim());}
            catch{}
            datainfo.atpr = ATPR.Text;
            try { datainfo.atpr_date = Convert.ToDateTime(IPCA_Date.Text.Trim()); }
            catch { }
            if (SOP_Status_ck_2.Checked == true)
            {
                datainfo.sop_status = 1;
                datainfo.sop_name = SOP_Name.Text.Trim();
            }
            else if (SOP_Status_ck_1.Checked == true)
            {
                datainfo.sop_status = 0;
            }
            datainfo.z_app = Z_APP.Text.Trim();
            datainfo.z_user = Z_User.Text.Trim();
            try { datainfo.sop_date = Convert.ToDateTime(SOP_Date.Text.Trim()); }
            catch { }

            dataBll.UpdateData(datainfo);
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
                sp_user = datainfo.nowuser;
                subject = "8D form，审批通过。";
                string url = System.Configuration.ConfigurationManager.AppSettings["url"].ToString();
                body = url;
            }
        }
        else
        {
            sp_user = ApprovalTable.Rows[1]["sp_user"].ToString();
            subject = "8D form，请审批。";
            string url = System.Configuration.ConfigurationManager.AppSettings["url"].ToString();
            body = url;
        }
        XmlSource.SendEmail(sp_user, subject, body);
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
        datainfo = dataBll.GetByKey(did);
        datainfo.status = 14;//拒绝
        dataBll.UpdateData(datainfo);
        LogInfo loginfo = new LogInfo();
        if (ApprovalTable.Rows.Count > 0)
        {
            loginfo = logbll.GetByKey(int.Parse(ApprovalTable.Rows[0]["rkey"].ToString()));
            loginfo.sp_end_date = DateTime.Now;
            loginfo.sp_content = SP_Content.Text;
            loginfo.status = 2;
            logbll.UpdateData(loginfo);
        }

        string sp_user = datainfo.nowuser;
        string subject = "8D form，未通过审批。";
        string url = System.Configuration.ConfigurationManager.AppSettings["url"].ToString();
        string body = url;
        XmlSource.SendEmail(sp_user, subject, body);

        Response.Write("<script language='javaScript'>alert('操作成功');window.opener = null;window.close();</script>");//无提示关闭页面
        button_shenpi_yes.Enabled = false;
        button_shenpi_no.Enabled = false;
    }
}
