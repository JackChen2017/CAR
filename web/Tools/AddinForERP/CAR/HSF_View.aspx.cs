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

public partial class HSF_Show : FounderTecInfoSys.Common.PageBase.DomainMasterPage 
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
        //if (!IsPostBack)
        //{
        //    FactoryID = String.IsNullOrEmpty(Request.QueryString["FID"]) ? 98 : int.Parse(Request.QueryString["FID"]);
        //    did = String.IsNullOrEmpty(Request.QueryString["did"]) ? 0 : int.Parse(Request.QueryString["did"]);
        //    type = String.IsNullOrEmpty(Request.QueryString["type"]) ? "view" : Request.QueryString["type"];
        //    try
        //    {
        //        this.UserAD = CurrentUser.UserADAcount;
        //    }
        //    catch
        //    {
        //        Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('用户AD丢失！');</script>");
        //        Response.End();
        //    }
        //    CARDataBLL dataBll = new CARDataBLL(FactoryID);
        //    dataInfo = dataBll.GetByKey(did);
        //    if ((int)dataInfo.op_type != 2)
        //    {
        //        Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('非法访问！');</script>");
        //        Response.End();
        //    }
        //    if (type == "view")
        //    {
        //        if (!HasRight(XmlSource.GetRightIndex("VIEW")) || !HasRight(XmlSource.GetRightIndex("HSF")))
        //        {
        //            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('您没有查看此页面的权限！');</script>");
        //            Response.End();
        //        }
        //        div_sp.Visible = false;
        //        Info_Content.AutoConfigure = CuteEditor.AutoConfigure.None;
        //        Info_Content.ActiveTab = CuteEditor.TabType.View;
        //        Info_Content.ShowBottomBar = false;
        //        Interim_Action.AutoConfigure = CuteEditor.AutoConfigure.None;
        //        Interim_Action.ActiveTab = CuteEditor.TabType.View;
        //        Interim_Action.ShowBottomBar = false;
        //        IPCA.AutoConfigure = CuteEditor.AutoConfigure.None;
        //        IPCA.ActiveTab = CuteEditor.TabType.View;
        //        IPCA.ShowBottomBar = false;
        //        CONF_Content.AutoConfigure = CuteEditor.AutoConfigure.None;
        //        CONF_Content.ActiveTab = CuteEditor.TabType.View;
        //        CONF_Content.ShowBottomBar = false;
        //        InitPage(dataInfo);
        //    }
        //    else if (type == "approval")
        //    {
        //        if (dataInfo.status == 0 || dataInfo.status == 1 || dataInfo.status == 14)
        //        {
        //            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('此单未在审批中！');</script>");
        //            Response.End();
        //        }
        //        Check();
        //        InitPage(dataInfo);
        //    }
        //}
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
            Info_Content.AutoConfigure = CuteEditor.AutoConfigure.None;
            Info_Content.ActiveTab = CuteEditor.TabType.View;
            Info_Content.ShowBottomBar = false;
            Interim_Action.AutoConfigure = CuteEditor.AutoConfigure.None;
            Interim_Action.ActiveTab = CuteEditor.TabType.View;
            Interim_Action.ShowBottomBar = false;
            IPCA.AutoConfigure = CuteEditor.AutoConfigure.None;
            IPCA.ActiveTab = CuteEditor.TabType.View;
            IPCA.ShowBottomBar = false;
        }
        else
        {
            div_center.Visible = false;
        }

    }

    protected void InitPage(DataInfo info)
    {
        Init_Company(1);
        try
        {
            happen_date.Text = info.happen_date.ToString();
            Issued_User.Text = info.issued_user;
            Required_Date.Text = info.required_date.ToString();
            CAR_Part_Num.Text = info.car_part_num;
            From_Comp.Items.FindByText(info.from_comp).Selected = true;
            CAR_Comp.Items.FindByText(info.car_comp).Selected = true;
            if (info.hsf_happen_type == "1")
            {
                HSF_Happen_Type_1.Checked = true;
            }
            else if (info.hsf_happen_type == "2")
            {
                HSF_Happen_Type_2.Checked = true;
            }
            else if (info.hsf_happen_type == "3")
            {
                HSF_Happen_Type_3.Checked = true;
            }
            else if (info.hsf_happen_type == "4")
            {
                HSF_Happen_Type_4.Checked = true;
            }
            else if (info.hsf_happen_type == "5")
            {
                HSF_Happen_Type_5.Checked = true;
            }
            Serial_No.Text = info.serial_no;
            Issued_APP.Text = info.issued_app;
            Received_User.Text = info.received_user;

            CAR_Content.Text = Server.HtmlDecode(info.car_content);
            CAR_Content.AutoConfigure = CuteEditor.AutoConfigure.None;
            CAR_Content.ActiveTab = CuteEditor.TabType.View;
            CAR_Content.ShowBottomBar = false;

            LOT.Text = info.lot;
            batch.Text = info.batch.ToString();
            badness_Num.Text = info.badness_num.ToString();
            ReWork.Text = info.rework.ToString();
            Reject.Text = info.reject.ToString();
            NoWork.Text = info.nowork.ToString();
            if ((int)info.info_type_1 == 1)
            {
                Info_Type_1.Checked = true;
            }
            if ((int)info.info_type_2 == 1)
            {
                Info_Type_2.Checked = true;
            }
            if ((int)info.info_type_3 == 1)
            {
                Info_Type_3.Checked = true;
            }
            if ((int)info.info_type_4 == 1)
            {
                Info_Type_4.Checked = true;
            }
            if ((int)info.info_type_5 == 1)
            {
                Info_Type_5.Checked = true;
            }
            Info_Content.Text = Server.HtmlDecode(info.info_content);
            Interim_Action.Text = Server.HtmlDecode(info.interim_action);
            IA_APP.Text = info.IA_APP;
            IA_User.Text = info.IA_USER;
            IA_Date.Text = info.ia_date.ToString();
            IPCA.Text = Server.HtmlDecode(info.ipca);
            IPCA_APP.Text = info.IPCA_APP;
            IPCA_User.Text = info.IPCA_USER;
            IPCA_Date.Text = info.ipca_date.ToString();
            Levels.Text = info.levels;
            if ((int)info.sop_status == 1)
            {
                SOP_Status_2.Checked = true;
                SOP_Name.Text = info.sop_name;
            }
            else
            {
                SOP_Status_1.Checked = true;
            }
            SOP_Content.Text = info.sop_content;
            SOP_Date.Text = info.sop_date.ToString();
            Together_Write.Text = info.together_write;
            if ((int)info.conf_status == 1)
            {
                CONF_Status_1.Checked = true;
                CONF_Status_2.Checked = false;
                CONF_Status_3.Checked = false;
            }
            else if ((int)info.conf_status == 2)
            {
                CONF_Status_1.Checked = false;
                CONF_Status_2.Checked = true;
                CONF_Status_3.Checked = false;
            }
            else if ((int)info.conf_status == 3)
            {
                CONF_Status_1.Checked = false;
                CONF_Status_2.Checked = false;
                CONF_Status_3.Checked = true;
            }
            CONF_Content.Text = Server.HtmlDecode(info.conf_content);
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

        IPCA.SetSecurityImageGalleryPath(path);
        IPCA.SetSecurityImageGalleryPath(path);
        IPCA.SetSecurityMediaGalleryPath(path);
        IPCA.SetSecurityFlashGalleryPath(path);
        IPCA.SetSecurityFilesGalleryPath(path);

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
        datainfo = dataBll.GetByKey(did);
        if (SP_Step == 1 && datainfo.serial_no.Trim().Length < 5)   //第一步审批之后获得单号
        {
            datainfo.serial_no = dataBll.getSerialNo(datainfo.serial_no);
        }
        if (SP_Step == SP_Total_Step)
        {
            if (CONF_Status_1.Checked == true)
            {
                datainfo.conf_status = 1;
            }
            else if (CONF_Status_2.Checked == true)
            {
                datainfo.conf_status = 2;
            }
            else if (CONF_Status_3.Checked == true)
            {
                datainfo.conf_status = 3;
            }
            datainfo.conf_content = CONF_Content.Text;
            datainfo.status = 1;
            dataBll.UpdateData(datainfo);

        }
        else
        {
            if (Info_Type_1.Checked == true)
            {
                datainfo.info_type_1 = 1;
            }
            if (Info_Type_2.Checked == true)
            {
                datainfo.info_type_2 = 1;
            }
            if (Info_Type_3.Checked == true)
            {
                datainfo.info_type_3 = 1;
            }
            if (Info_Type_4.Checked == true)
            {
                datainfo.info_type_4 = 1;
            }
            if (Info_Type_5.Checked == true)
            {
                datainfo.info_type_5 = 1;
            }
            datainfo.info_content = Info_Content.Text;
            datainfo.interim_action = Interim_Action.Text;
            datainfo.IA_APP = IA_APP.Text;
            datainfo.IA_USER = IA_User.Text;
            try { datainfo.ia_date = Convert.ToDateTime(IA_Date.Text.Trim()); }
            catch { }
            datainfo.ipca = IPCA.Text;
            datainfo.IPCA_APP = IPCA.Text;
            datainfo.IPCA_USER = IPCA_User.Text;
            try { datainfo.ipca_date = Convert.ToDateTime(IPCA_Date.Text.Trim()); }
            catch{}
            datainfo.levels = Levels.Text;
            
            if (SOP_Status_2.Checked == true)
            {
                datainfo.sop_status = 1;
                datainfo.sop_name = SOP_Name.Text.Trim();
            }
            else
            {
                datainfo.sop_status = 0;
                datainfo.sop_name = "";
            }
            datainfo.sop_content = SOP_Content.Text.Trim();
            try { datainfo.sop_date = Convert.ToDateTime(SOP_Date.Text.Trim()); }
            catch { }
            datainfo.together_write = Together_Write.Text;

            dataBll.UpdateData(datainfo);
        }

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

        string sp_user = "";
        string subject = "";
        string body = "";
        if (ApprovalTable.Rows.Count == 1)
        {
            if (SP_Step == SP_Total_Step)
            {
                sp_user = datainfo.nowuser;
                subject = "HSF异常处理，审批通过。";
                string url = System.Configuration.ConfigurationManager.AppSettings["url"].ToString();
                body = url;
            }
        }
        else
        {
            sp_user = ApprovalTable.Rows[1]["sp_user"].ToString();
            subject = "有新的HSF异常处理，请审批。";
            string url = System.Configuration.ConfigurationManager.AppSettings["url"].ToString();
            body = url;
        }
        XmlSource.SendEmail(sp_user, subject, body);

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
        string subject = "HSF异常处理，未通过审批。";
        string url = System.Configuration.ConfigurationManager.AppSettings["url"].ToString();
        string body = url;
        XmlSource.SendEmail(sp_user, subject, body);

        Response.Write("<script language='javaScript'>alert('操作成功');window.opener = null;window.close();</script>");//无提示关闭页面
        button_shenpi_yes.Enabled = false;
        button_shenpi_no.Enabled = false;
    }
}
