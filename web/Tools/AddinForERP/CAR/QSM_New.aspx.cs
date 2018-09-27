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

public partial class Tools_AddinForERP_CAR_QSM_New : FounderTecInfoSys.Common.PageBase.DomainMasterPage
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
    private DataTable tb_ApprovalInfo    //用于查看已经发起的审批
    {
        get
        {
            if (ViewState["tb_ApprovalInfo"] == null)
            {
                ViewState["tb_ApprovalInfo"] = new DataTable();
            }
            return (DataTable)ViewState["tb_ApprovalInfo"];
        }
        set
        {
            ViewState["tb_ApprovalInfo"] = value;
        }
    }
    private DataTable ApprovalTable    //用于审批流程
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
    private void InitDataTable()
    {
        ApprovalTable.Columns.Add(new DataColumn("步骤", typeof(string)));
        ApprovalTable.Columns.Add(new DataColumn("审批人", typeof(string)));
        ApprovalTable.Columns.Add(new DataColumn("帐号", typeof(string)));
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            InitDataTable();
            Initialize();
        }
    }
    #region 初始化
    protected void Initialize()
    {
        #region 判断用户权限
        if (!HasRight(XmlSource.GetRightIndex("QSM")))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('对不起，你没有权限访问此页面！');</script>");
            Response.End();
            return;
        }
        #endregion
        #region 初始化界面
        did = String.IsNullOrEmpty(Request.QueryString["did"]) ? 0 : int.Parse(Request.QueryString["did"]);
        if (did > 0)
        {
            QSMInfo qsminfo = new QSMBLL(CurrentFactoryID).getQSMInfoByrkey(did);

            if (qsminfo.STATUS == 0 || qsminfo.STATUS == 14)   //未审批、未发启  注意:不显示gridview2(审批记录)
            {

                div_AppListEdit.Visible = true;
                div_AppListShow.Visible = false;
                #region 审批信息
                ApprovalTable = new CARLogBLL(CurrentFactoryID).GetDataSet("select sp_step as 步骤,'' as 审批人,sp_user as 帐号 from CAR_Table_LOG where SN_PTR=" + qsminfo.RKEY.ToString() + " and sn_type = 'QSM' order by sp_step");
                for (int i = 0; i < ApprovalTable.Rows.Count; i++)
                {
                    ApprovalTable.Rows[i][1] = GetUserName(ApprovalTable.Rows[i][2].ToString());
                }
                GridView1.DataSource = ApprovalTable;
                GridView1.DataBind();
                #endregion
            }
            else                        //已经发送审批,不可更改
            {
                sendApproval.Enabled = false;
                ibtn_Save.Enabled = false;
                //ibtn_Cancel.Enabled = false; 取消按钮不实现任何功能
                div_AppListEdit.Visible = false;
                div_AppListShow.Visible = false;
                #region 审批信息
                tb_ApprovalInfo = new CARLogBLL(CurrentFactoryID).GetDataSet("select sp_step,sp_user,sp_end_date,status,sp_content from CAR_Table_LOG where SN_PTR=" + qsminfo.RKEY.ToString() + " and sn_type = 'QSM' order by sp_step");
                GridView2.DataSource = tb_ApprovalInfo;
                GridView2.DataBind();
                #endregion
            }
            #region 申请信息
            Serial_No.Text = qsminfo.SERIALNO;
            CustName.Text = qsminfo.CUST_NAME;
            CustCode.Value = qsminfo.CUST_CODE;
            factoryList.Items.FindByText(qsminfo.FACTORY_NAME).Selected = true;
            Happen_Date.Text = qsminfo.HAPPEN_DATE.ToString();
            cust_MaterialNo.Text = qsminfo.CUST_MATERIALNO;
            interalNo.Text = qsminfo.INTERALNO;
            require_Date.Text = qsminfo.REQUIRE_DATE.ToString();
            CAR_Content.Text = Server.HtmlDecode(qsminfo.CAR_CONTENT);
            chuhuo_qty.Text = qsminfo.CHUHUO_QTY.ToString();
            jiancha_qty.Text = qsminfo.JIANCHA_QTY.ToString();
            buliang_qty.Text = qsminfo.BULIANG_QTY.ToString();
            buliangbili.Text = qsminfo.BULIANGBILI.ToString() + "%";
            buliangDC.Text = qsminfo.BULIANGDC;
            zaixian_qty.Text = qsminfo.ZAITU_QTY.ToString();
            kucun_qty.Text = qsminfo.KUCUN_QTY.ToString();
            try { tousu_level.Items.FindByText(qsminfo.TOUSU_LEVEL).Selected = true; }
            catch { }
            try { tousu_type.Items.FindByText(qsminfo.TOUSU_TYPE).Selected = true; }
            catch { }

            if (Convert.ToInt32(qsminfo.TUIHUO_STATUS) == 0)
            {
                tuihuo_status_ck1.Checked = true;
                tuihuo_status_ck2.Checked = false;
                tuihuo_qty.Text = "0";
            }
            else if (Convert.ToInt32(qsminfo.TUIHUO_STATUS) == 1)
            {
                tuihuo_status_ck1.Checked = false;
                tuihuo_status_ck2.Checked = true;
                tuihuo_qty.Text = qsminfo.TUIHUO_QTY.ToString();
            }

            try { happen_address.Items.FindByValue(qsminfo.HAPPEN_ADDRESS.ToString()).Selected = true; }
            catch { }
            if (Convert.ToInt32(qsminfo.TIJIAO_STATUS) == 0)
            {
                tijiao_status_ck1.Checked = true;
                tijiao_status_ck2.Checked = false;
            }
            else if (Convert.ToInt32(qsminfo.TIJIAO_STATUS) == 1)
            {
                tijiao_status_ck1.Checked = false;
                tijiao_status_ck2.Checked = true;

                if (Convert.ToInt32(qsminfo.TIJIAO_TYPE) == 1)
                {
                    tijiao_type_ck1.Checked = true;
                    tijiao_type_ck2.Checked = false;
                    tijiao_type_ck3.Checked = false;
                }
                else if (Convert.ToInt32(qsminfo.TIJIAO_TYPE) == 2)
                {
                    tijiao_type_ck1.Checked = false;
                    tijiao_type_ck2.Checked = true;
                    tijiao_type_ck3.Checked = false;
                }
                else if (Convert.ToInt32(qsminfo.TIJIAO_TYPE) == 3)
                {
                    tijiao_type_ck1.Checked = false;
                    tijiao_type_ck2.Checked = false;
                    tijiao_type_ck3.Checked = true;
                }
            }
            notes.Text = qsminfo.NOTES;
            #endregion
        }
        else        //新建QSM
        {
            tuihuo_status_ck2.Checked = true;
            happen_address.Items[0].Selected = true;
            tijiao_status_ck2.Checked = true;
            tijiao_type_ck1.Checked = true;
        }
        #endregion

        #region 根据权限来控制页面功能
        if (!HasRight(XmlSource.GetRightIndex("EDIT")))
        {
            sendApproval.Enabled = false;
            ibtn_Save.Enabled = false;
        }
        if (did > 0)
        {
            if (qsminfo.ENT_USER != CurrentUser.UserADAcount && !CurrentUser.RightIsAdmin)//如果当前用户不是发启人,就只能查看
            {
                sendApproval.Enabled = false;
                ibtn_Save.Enabled = false;
            }
        }
        #endregion
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
    #endregion

    private void BindGrid()
    {
        GridView1.DataSource = ApprovalTable;
        GridView1.DataBind();

        int currentStep = GridView1.Rows.Count + 1;
        lableStepNum.Text = currentStep.ToString();
        textApprovalUserNameList.Value = "";
        sendApproval.Enabled = true;
    }
    //查看固定审批流
    protected void Button2_Click(object sender, EventArgs e)
    {
        Button2.Enabled = false;
        ApprovalTable.Clear();
        if (!ApprovalTable.Columns.Contains("步骤"))
        {
            ApprovalTable.Columns.Add(new DataColumn("步骤", typeof(string)));
        }
        if (!ApprovalTable.Columns.Contains("审批人"))
        {
            ApprovalTable.Columns.Add(new DataColumn("审批人", typeof(string)));
        }
        if (!ApprovalTable.Columns.Contains("帐号"))
        {
            ApprovalTable.Columns.Add(new DataColumn("帐号", typeof(string)));
        }

        for (int i = 1; i <= int.Parse(ReadApprovalUserList(1, "totalstep")); i++)
        {
            DataRow dr = ApprovalTable.NewRow();
            dr[0] = i.ToString();
            dr[1] = GetUserName(ReadApprovalUserList(1, "stepuser" + i.ToString()));
            dr[2] = ReadApprovalUserList(1, "stepuser" + i.ToString());
            ApprovalTable.Rows.Add(dr);
        }
        BindGrid();
    }

    //添加确定审批人员
    protected void Button1_Click(object sender, EventArgs e)
    {
        DataRow dr = ApprovalTable.NewRow();
        //dr.ItemArray = new object[] { lableStepNum.Text, textApprovalUserNameList.Value };
        dr[0] = lableStepNum.Text;
        dr[1] = textApprovalUserNameList.Value.Split('(')[0];
        //dr[2] = textApprovalUserNameList.Value.Trim().Remove(textApprovalUserNameList.Value.Trim().Length - 1).Split('(')[1];
        dr[2] = textApprovalUserNameList.Value.Trim().Split('(')[1].Split(')')[0];
        ApprovalTable.Rows.Add(dr);
        BindGrid();
    }

    //发启审批
    protected void sendApproval_Click(object sender, ImageClickEventArgs e)
    {
        if (ApprovalTable.Rows.Count <= 1)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('未设置审批流程或审批人少于两个！');</script>");
            return;
        }
        #region 保存
        int sn_ptr = Writedata(2);
        if (sn_ptr == -1)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('保存失败！');</script>");
            return;
        }
        if (Writelog(sn_ptr) == -1)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('保存失败！');</script>");
            return;
        }
        #endregion
        #region 邮件提示
        CARDataBLL dataBll = new CARDataBLL(CurrentFactoryID);
        string sp_user = ApprovalTable.Rows[0][2].ToString();
        string subject = "客户投诉有新的审批。";
        string url = System.Configuration.ConfigurationManager.AppSettings["url"].ToString();
        string body = url;
        XmlSource.SendEmail(sp_user, subject, body);
        #endregion
        Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('发启成功！');</script>");
        ibtn_Save.Enabled = false;
        sendApproval.Enabled = false;
    }

    //保存
    protected void ibtn_Save_Click(object sender, ImageClickEventArgs e)
    {
        int sn_ptr = Writedata(0);
        if (sn_ptr == -1)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('保存失败！');</script>");
            return;
        }
        if (Writelog(sn_ptr) == -1)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('保存失败！');</script>");
            return;
        }
        Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('保存成功');</script>");
        ibtn_Save.Enabled = false;
        sendApproval.Enabled = false;
    }

    //取消
    protected void ibtn_Cancel_Click(object sender, ImageClickEventArgs e)
    {

    }
    //固定审批流
    protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
    {
        RadioButton1.Checked = true;
        RadioButton2.Checked = false;
        ViewShenPi.Visible = true;
        SetShenPi.Visible = false;
        if (GridView1.Rows.Count < 1)
        {
            Button2_Click(sender, e);
            Button2.Enabled = true;
        }
    }
    //自由审批流
    protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
    {
        RadioButton1.Checked = false;
        RadioButton2.Checked = true;
        ViewShenPi.Visible = false;
        SetShenPi.Visible = true;
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        ApprovalTable.Rows.RemoveAt(e.RowIndex);
        BindGrid();
    }
    #region 将信息写入库
    /// <summary>
    /// 将信息写入库
    /// </summary>
    private int Writedata(int status)
    {
        QSMBLL qsmbll = new QSMBLL(CurrentFactoryID);
        QSMInfo qsminfo = new QSMInfo();
        if (did == 0)
        {
            qsminfo.RKEY = 0;
            qsminfo.SERIALNO = qsmbll.GetSerialNo();
        }
        else
        {
            qsminfo = qsmbll.getQSMInfoByrkey(did);
            if (qsminfo.STATUS == 14)
            {
                string strTemp = qsminfo.SERIALNO;
                qsminfo = new QSMInfo();
                qsminfo.RKEY = did;
                qsminfo.SERIALNO = strTemp;
            }
        }
        qsminfo.ENT_DATE = DateTime.Now;
        qsminfo.ENT_USER = CurrentUser.UserADAcount;
        qsminfo.CUST_CODE = CustCode.Value;
        qsminfo.CUST_NAME = CustName.Text;
        qsminfo.FACTORY_NAME = factoryList.SelectedItem.Text;

        try { qsminfo.HAPPEN_DATE = Convert.ToDateTime(Happen_Date.Text); }
        catch { qsminfo.HAPPEN_DATE = DateTime.Now; }

        qsminfo.CUST_MATERIALNO = cust_MaterialNo.Text;
        qsminfo.INTERALNO = interalNo.Text;

        try { qsminfo.REQUIRE_DATE = Convert.ToDateTime(require_Date.Text); }
        catch { }
        qsminfo.TOUSU_LEVEL = tousu_level.SelectedItem.Text;
        qsminfo.TOUSU_TYPE = tousu_type.SelectedItem.Text;

        try { qsminfo.CHUHUO_QTY = decimal.Parse(chuhuo_qty.Text); }
        catch { qsminfo.CHUHUO_QTY = 0; }
        try { qsminfo.JIANCHA_QTY = decimal.Parse(jiancha_qty.Text); }
        catch { qsminfo.JIANCHA_QTY = 0; }
        try { qsminfo.BULIANG_QTY = decimal.Parse(buliang_qty.Text); }
        catch { qsminfo.BULIANG_QTY = 0; }
        try 
        {
            qsminfo.BULIANGBILI = decimal.Parse(buliangbili.Text.Trim().Replace("%", "")); 
        }
        catch { qsminfo.BULIANGBILI = 0; }
        qsminfo.BULIANGDC = buliangDC.Text;
        try { qsminfo.ZAIXIAN_QTY = decimal.Parse(zaixian_qty.Text); }
        catch { qsminfo.ZAIXIAN_QTY = 0; }
        try { qsminfo.KUCUN_QTY = decimal.Parse(kucun_qty.Text); }
        catch { qsminfo.KUCUN_QTY = 0; }
        if (tuihuo_status_ck1.Checked == true)
        {
            qsminfo.TUIHUO_STATUS = 0;
            qsminfo.TUIHUO_QTY = 0;
        }
        else if (tuihuo_status_ck2.Checked == true)
        {
            qsminfo.TUIHUO_STATUS = 1;
            try { qsminfo.TUIHUO_QTY = decimal.Parse(tuihuo_qty.Text); }
            catch { qsminfo.TUIHUO_QTY = 0; }
        }
        qsminfo.HAPPEN_ADDRESS = int.Parse(happen_address.SelectedValue);
        if (tijiao_status_ck1.Checked == true)
        {
            qsminfo.TIJIAO_STATUS = 0;
        }
        else if (tijiao_status_ck2.Checked == true)
        {
            qsminfo.TIJIAO_STATUS = 1;
            if (tijiao_type_ck1.Checked == true)
            {
                qsminfo.TIJIAO_TYPE = 1;
            }
            else if (tijiao_type_ck2.Checked == true)
            {
                qsminfo.TIJIAO_TYPE = 2;
            }
            else if (tijiao_type_ck3.Checked == true)
            {
                qsminfo.TIJIAO_TYPE = 3;
            }
        }
        qsminfo.NOTES = notes.Text;

        qsminfo.CAR_CONTENT = CAR_Content.Text;

        qsminfo.STATUS = status;

        int a = 0;
        if (did == 0)
        {
            a = qsmbll.add(qsminfo);
        }
        else
        {
            a = qsmbll.Update(qsminfo);
        }
        if (a != 0)
        {
            return -1;
        }
        return int.Parse(qsminfo.RKEY.ToString());
    }

    private int Writelog(int sn_ptr)
    {
        CARLogBLL logBll = new CARLogBLL(CurrentFactoryID);
        DataTable tb_temp = new DataTable();
        tb_temp = logBll.GetDataSet("select rkey from CAR_Table_LOG where sn_type = 'QSM' and  SN_PTR = " + sn_ptr.ToString());
        int a = 0;
        for (int i = 0; i < tb_temp.Rows.Count; i++)
        {
            a = logBll.DelData(int.Parse(tb_temp.Rows[i][0].ToString()));
            if (a != 0)
            {
                return -1;
            }
        }
        if (ApprovalTable.Rows.Count > 0)
        {
            for (int j = 0; j < ApprovalTable.Rows.Count; j++)
            {
                LogInfo logInfo = new LogInfo();
                logInfo.sn_ptr = sn_ptr;
                logInfo.sn_type = "QSM";
                logInfo.sp_total_step = ApprovalTable.Rows.Count;
                if (j == 0)
                {
                    logInfo.sp_start_date = DateTime.Now;
                    //logInfo.sp_end_date
                }
                logInfo.sp_type = 1;
                logInfo.sp_step = j + 1;
                logInfo.sp_user = ApprovalTable.Rows[j][2].ToString();
                //logInfo.sp_content
                logInfo.status = 0;
                a = logBll.AddData(logInfo);
                if (a != 0)
                {
                    return -1;
                }
            }
        }
        return 0;
    }
    #endregion
    public string ReadApprovalUserList(int i, string XName)
    {
        XmlDocument xmDoc = new XmlDocument();
        xmDoc.Load(Server.MapPath(".") + @"\Configuration\SelfApprovalUserList.xml");

        XmlNode rightList = xmDoc.SelectSingleNode("configuration");

        XmlNode rightItem = rightList.SelectSingleNode("list" + i.ToString());

        XmlNode Item = rightItem.SelectSingleNode(XName);

        return Item.Attributes["index"].Value;
    }
    protected void linkButtonAddUser_Click(object sender, EventArgs e)
    {
        string[] strUserList = DomainUserTreeControl1.GetUserList.Split('*');
        if (strUserList.Length == 2)
        {
            strUserList[0] = removeLastComma(strUserList[0]);
            strUserList[1] = removeLastComma(strUserList[1]);

            textApprovalUserNameList.Value = strUserList[0] + "(" + strUserList[1] + ")";


        }
    }
    private string removeLastComma(string strValue)
    {
        if (string.IsNullOrEmpty(strValue))
        {
            return string.Empty;
        }

        while (strValue.EndsWith(","))
        {
            strValue = strValue.Remove(strValue.Length - 1);
        }

        return strValue;
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
    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
            {
                e.Row.Cells[1].Text = GetUserName(e.Row.Cells[1].Text);
                switch (DataBinder.Eval(e.Row.DataItem, "status").ToString())
                {
                    case "0": e.Row.Cells[3].Text = "未处理"; break;
                    case "1": e.Row.Cells[3].Text = "通过"; break;
                    case "2": e.Row.Cells[3].Text = "未通过"; break;
                    default: break;
                }
            }
        }
    }
}
