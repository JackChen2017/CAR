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

public partial class Tools_AddinForERP_CAR_SA_New : FounderTecInfoSys.Common.PageBase.DomainMasterPage
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
    private void InitDataTable()
    {
        ApprovalTable.Columns.Add(new DataColumn("步骤", typeof(string)));
        ApprovalTable.Columns.Add(new DataColumn("审批人", typeof(string)));
        ApprovalTable.Columns.Add(new DataColumn("帐号", typeof(string)));
    }
    int row_Number = 100;

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
        lnk_CSS.Href = Request.Path.Substring(0, Request.Path.LastIndexOf('/')) + "/CSS/GV.css";
        #region 判断用户权限
        if (!HasRight(XmlSource.GetRightIndex("SA")))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('你没有权限进入此页面！');</script>");
            Response.End();
            return;
        }
        #endregion
        #region 初始化界面
        did = String.IsNullOrEmpty(Request.QueryString["did"]) ? 0 : int.Parse(Request.QueryString["did"]);
        #region gridview3数据绑定
        tb_SA = new CARDataBLL(CurrentFactoryID).GetDataSet("select * from CAR_Table_SAList where sn_ptr = " + did.ToString());
        if (tb_SA.Rows.Count < row_Number)
        {
            for (int i = 0; i < row_Number - tb_SA.Rows.Count; )
            {
                DataRow row = tb_SA.NewRow();
                for (int j = 0; j < tb_SA.Columns.Count; j++)
                {
                    row[j] = DBNull.Value;
                }
                tb_SA.Rows.Add(row);
            }
        }
        GridView3.DataSource = tb_SA;
        GridView3.DataBind();
        #endregion
        if (did > 0)
        {
            saInfo = new SABLL(CurrentFactoryID).getSAInfoByrkey(did);
            CAR_Content.Text = Server.HtmlDecode(saInfo.CAR_CONTENT);
            CAR_Content.ActiveTab = CuteEditor.TabType.View;
            if (saInfo.STATUS != 0 && saInfo.STATUS != 14)//审批中或审批完成
            {
                CAR_Content.AutoConfigure = CuteEditor.AutoConfigure.None;
                CAR_Content.ShowBottomBar = false;
            }
            if (saInfo.STATUS == 0 || saInfo.STATUS == 14)   //未审批、未发启或审批拒绝
            {
                div_AppListEdit.Visible = true;
                #region 审批信息
                ApprovalTable = new CARLogBLL(CurrentFactoryID).GetDataSet("select sp_step as 步骤,'' as 审批人,sp_user as 帐号 from CAR_Table_LOG where sn_type = 'SA' and SN_PTR=" + saInfo.RKEY.ToString() + " order by sp_step");
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
                div_AppListEdit.Visible = false;
            }
            #region 申请信息

            #endregion
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
            if (saInfo.ENT_USER != CurrentUser.UserADAcount && !CurrentUser.RightIsAdmin)//如果当前用户不是发启人,就只能查看
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
        dr[2] = textApprovalUserNameList.Value.Trim().Remove(textApprovalUserNameList.Value.Trim().Length - 1).Split('(')[1];
        ApprovalTable.Rows.Add(dr);
        BindGrid();
    }

    //发启审批
    protected void sendApproval_Click(object sender, ImageClickEventArgs e)
    {
        if (ApprovalTable.Rows.Count == 0)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('请设置审批流程！');</script>");
            return;
        }
        #region 保存
        int sn_ptr = Writedata(2);
        if (sn_ptr == -1)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('保存失败！');</script>");
            return;
        }
        GetData();
        CheckData();
        if (Writelog(sn_ptr) == -1)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('保存失败！');</script>");
            return;
        }
        #endregion
        #region 邮件提示
        CARDataBLL dataBll = new CARDataBLL(CurrentFactoryID);
        string sp_user = ApprovalTable.Rows[0][2].ToString();
        string subject = "不良品确认 有新的审批。";
        string url = System.Configuration.ConfigurationManager.AppSettings["url"].ToString();
        string body = url;
        XmlSource.SendEmail(sp_user, subject, body);
        #endregion
        Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('发送成功！');window.opener = null;window.close();</script>");
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
        GetData();
        if (Writelog(sn_ptr) == -1)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('保存失败！');</script>");
            return;
        }
        Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('保存成功！');window.opener = null;window.close();</script>");
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
        SABLL saBLL = new SABLL(CurrentFactoryID);
        SAInfo sa = new SAInfo();
        if (did == 0)
        {
            sa.RKEY = 0;
            sa.SERIALNO = saBLL.GetSerialNo();
        }
        else
        {
            sa = saBLL.getSAInfoByrkey(did);
            if (sa.STATUS == 14)
            {
                string temp = sa.SERIALNO;
                sa = new SAInfo();
                sa.RKEY = did;
                sa.SERIALNO = temp;
            }
        }
        #region 赋值
        sa.ENT_DATE = DateTime.Now;
        sa.ENT_USER = CurrentUser.UserADAcount;
        sa.CAR_CONTENT = CAR_Content.Text;
        sa.STATUS = status;
        #endregion
        #region 保存
        int a = 0;
        if (did == 0)
        {
            a = saBLL.add(sa);
        }
        else
        {
            a = saBLL.Update(sa);
        }
        if (a != 0)
        {
            return -1;
        }
        return int.Parse(sa.RKEY.ToString());
        #endregion
    }
    #endregion
    private int Writelog(int sn_ptr)
    {
        DataRow[] rows = tb_SA.Select("custName <>'' and custCode <> ''");
        SAListBLL salistBll = new SAListBLL(CurrentFactoryID);
        salistBll.DeteleByKey(did);
        for (int b = 0; b < rows.Length; b++)
        {
            SAList sa = new SAList();
            sa.sn_ptr = sn_ptr;
            sa.custCode = tb_SA.Rows[b]["custCode"].ToString();
            sa.custName = tb_SA.Rows[b]["custName"].ToString();
            try { sa.recordDateTime = Convert.ToDateTime(tb_SA.Rows[b]["recordDateTime"].ToString()); }
            catch { }
            sa.founderMaterilNo = tb_SA.Rows[b]["founderMaterilNo"].ToString();
            sa.custPartNo = tb_SA.Rows[b]["custPartNo"].ToString();
            sa.cycleValue = tb_SA.Rows[b]["cycleValue"].ToString();
            sa.happenAddress = tb_SA.Rows[b]["happenAddress"].ToString();
            sa.LOT = tb_SA.Rows[b]["LOT"].ToString();
            sa.ET = tb_SA.Rows[b]["ET"].ToString();
            sa.T = tb_SA.Rows[b]["T"].ToString();
            sa.reason = tb_SA.Rows[b]["reason"].ToString();
            sa.mateialType = tb_SA.Rows[b]["mateialType"].ToString();
            sa.results = tb_SA.Rows[b]["results"].ToString();
            try { sa.quantity = decimal.Parse(tb_SA.Rows[b]["quantity"].ToString()); }
            catch { sa.quantity = 0; }
            try { sa.signDate = Convert.ToDateTime(tb_SA.Rows[b]["signDate"].ToString()); }
            catch { }
            sa.signingPerson = tb_SA.Rows[b]["signingPerson"].ToString();
            sa.factoryName = tb_SA.Rows[b]["factoryName"].ToString();
            try { sa.discountPrice = decimal.Parse(tb_SA.Rows[b]["discountPrice"].ToString()); }
            catch { }
            try { sa.discountAmount = decimal.Parse(tb_SA.Rows[b]["discountAmount"].ToString()); }
            catch { }

            salistBll.Add(sa);
        }


        CARLogBLL logBll = new CARLogBLL(CurrentFactoryID);
        DataTable tb_temp = new DataTable();
        tb_temp = logBll.GetDataSet("select rkey from CAR_Table_LOG where sn_type = 'SA' and  SN_PTR = " + sn_ptr.ToString());
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
                logInfo.sn_type = "SA";
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
    protected void GridView3_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        GetData();
        tb_SA.Rows.RemoveAt(e.RowIndex);
        GridView3.DataSource = tb_SA;
        GridView3.DataBind();
    }
    protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
            {
                #region 初始化
                #region 原因
                DropDownList ddlReason = (DropDownList)e.Row.FindControl("ddl_reason");
                ddlReason.Items.Add(new ListItem("开路"));
                ddlReason.Items.Add(new ListItem("短路"));
                ddlReason.Items.Add(new ListItem("爆板"));
                ddlReason.Items.Add(new ListItem("掉pad"));
                ddlReason.Items.Add(new ListItem("key pad 露铜 "));
                ddlReason.Items.Add(new ListItem("key pad 刮伤"));
                ddlReason.Items.Add(new ListItem("沾绿漆"));
                ddlReason.Items.Add(new ListItem("绿油积墨"));
                ddlReason.Items.Add(new ListItem("绿漆剥落"));
                ddlReason.Items.Add(new ListItem("补漆不良"));
                ddlReason.Items.Add(new ListItem("防焊异物"));
                ddlReason.Items.Add(new ListItem("防焊刮伤露铜"));
                ddlReason.Items.Add(new ListItem("化金露铜"));
                ddlReason.Items.Add(new ListItem("渗镀金"));
                ddlReason.Items.Add(new ListItem("金面氧化"));
                ddlReason.Items.Add(new ListItem("金面异色"));
                ddlReason.Items.Add(new ListItem("金面刮伤"));
                ddlReason.Items.Add(new ListItem("补镀不良"));
                ddlReason.Items.Add(new ListItem("压合皱折"));
                #endregion
                #region 板子种类
                DropDownList ddlMateialType = (DropDownList)e.Row.FindControl("ddl_mateialType");
                ddlMateialType.Items.Add(new ListItem("空板"));
                ddlMateialType.Items.Add(new ListItem("上件板(单面)"));
                ddlMateialType.Items.Add(new ListItem("上件板(双面)"));
                #endregion
                #region 处理结果
                //DropDownList ddlResults = (DropDownList)e.Row.FindControl("ddl_results");
                //ddlResults.Items.Add(new ListItem("修理OK"));
                //ddlResults.Items.Add(new ListItem("报废"));
                #endregion
                #region 责任厂别
                DropDownList ddlFactoryName = (DropDownList)e.Row.FindControl("ddl_factoryName");
                ddlFactoryName.Items.Add(new ListItem("珠海富山"));
                ddlFactoryName.Items.Add(new ListItem("珠海多层"));
                ddlFactoryName.Items.Add(new ListItem("珠海高密"));
                ddlFactoryName.Items.Add(new ListItem("珠海越亚"));
                ddlFactoryName.Items.Add(new ListItem("杭州速能"));
                ddlFactoryName.Items.Add(new ListItem("重庆高密"));
                #endregion
                #region 查询
                e.Row.Cells[3].Attributes.Add("OnClick", string.Format("Open({0})", e.Row.RowIndex.ToString()));
                e.Row.Cells[4].Attributes.Add("OnClick", string.Format("Open({0})", e.Row.RowIndex.ToString()));
                #endregion
                #endregion
                #region 绑定
                try
                {
                    ddlReason.Items.FindByText(DataBinder.Eval(e.Row.DataItem, "reason").ToString()).Selected = true;
                }
                catch { }
                try
                {
                    ddlMateialType.Items.FindByText(DataBinder.Eval(e.Row.DataItem, "mateialType").ToString()).Selected = true;
                }
                catch { }
                //try
                //{
                //    ddlResults.Items.FindByText(DataBinder.Eval(e.Row.DataItem, "results").ToString()).Selected = true;
                //}
                //catch { }
                try
                {
                    ddlFactoryName.Items.FindByText(DataBinder.Eval(e.Row.DataItem, "factoryName").ToString()).Selected = true;
                }
                catch { }
                #endregion
            }
        }
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

    /// <summary>
    /// 将明细信息保存到datatable中.
    /// </summary>
    protected void GetData()
    {
        tb_SA.Clear();
        for (int i = 0; i < GridView3.Rows.Count; i++)
        {
            DataRow row = tb_SA.NewRow();
         
            //row["rkey"] = 0;
            row["sn_ptr"] = did;
            row["custCode"] = ((TextBox)GridView3.Rows[i].FindControl("tb_custCode")).Text.Trim();
            row["custName"] = ((TextBox)GridView3.Rows[i].FindControl("tb_custName")).Text.Trim();
            try { row["recordDateTime"] = ((TextBox)GridView3.Rows[i].FindControl("tb_recordDateTime")).Text.Trim(); }
            catch { }
            row["founderMaterilNo"] = ((TextBox)GridView3.Rows[i].FindControl("tb_founderMaterilNo")).Text.Trim();
            row["custPartNo"] = ((TextBox)GridView3.Rows[i].FindControl("tb_custPartNo")).Text.Trim();
            row["cycleValue"] = ((TextBox)GridView3.Rows[i].FindControl("tb_cycleValue")).Text.Trim();
            row["happenAddress"] = ((TextBox)GridView3.Rows[i].FindControl("tb_happenAddress")).Text.Trim();
            row["LOT"] = ((TextBox)GridView3.Rows[i].FindControl("tb_LOT")).Text.Trim();
            row["ET"] = ((TextBox)GridView3.Rows[i].FindControl("tb_ET")).Text.Trim();
            row["T"] = ((TextBox)GridView3.Rows[i].FindControl("tb_T")).Text.Trim();
            row["reason"] = ((DropDownList)GridView3.Rows[i].FindControl("ddl_reason")).SelectedItem.Text;
            row["mateialType"] = ((DropDownList)GridView3.Rows[i].FindControl("ddl_mateialType")).SelectedItem.Text;
            //row["results"] = ((DropDownList)GridView3.Rows[i].FindControl("ddl_results")).SelectedItem.Text;
            row["results"] = "";
            try{ row["quantity"] = ((TextBox)GridView3.Rows[i].FindControl("tb_quantity")).Text.Trim();}
            catch { row["quantity"] = DBNull.Value; }
            try { row["signDate"] = ((TextBox)GridView3.Rows[i].FindControl("tb_signDate")).Text.Trim(); }
            catch { row["signDate"] = DBNull.Value; }
            row["signingPerson"] = ((TextBox)GridView3.Rows[i].FindControl("tb_signingPerson")).Text.Trim();
            row["factoryName"] = ((DropDownList)GridView3.Rows[i].FindControl("ddl_factoryName")).SelectedItem.Text;
            try { row["discountPrice"] = ((TextBox)GridView3.Rows[i].FindControl("tb_discountPrice")).Text.Trim(); }
            catch { row["discountPrice"] = DBNull.Value; }
            try { row["discountAmount"] = ((TextBox)GridView3.Rows[i].FindControl("tb_discountAmount")).Text.Trim(); }
            catch { row["discountAmount"] = DBNull.Value; }

            tb_SA.Rows.Add(row);
        }
        for (int j = 0; j < row_Number - tb_SA.Rows.Count; )
        {
            DataRow row = tb_SA.NewRow();
            for (int k = 0; k < tb_SA.Columns.Count; k++)
            {
                row[k] = DBNull.Value;
            }
            tb_SA.Rows.Add(row);
        }
    }
    protected void CheckData()
    {
        foreach (DataRow row in tb_SA.Rows)
        {
            if (!string.IsNullOrEmpty(row["custCode"].ToString().Trim()) && !string.IsNullOrEmpty(row["custName"].ToString().Trim()))
            {
                if (string.IsNullOrEmpty(row["founderMaterilNo"].ToString().Trim()))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('请补齐 Founder料号！');</script>");
                    return;
                }
                if (string.IsNullOrEmpty(row["custPartNo"].ToString().Trim()))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('请补齐 客户机种！');</script>");
                    return;
                }
                if (string.IsNullOrEmpty(row["cycleValue"].ToString().Trim()))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('请补齐 周期！');</script>");
                    return;
                }
                if (string.IsNullOrEmpty(row["happenAddress"].ToString().Trim()))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('请补齐 上件点！');</script>");
                    return;
                }
                if (string.IsNullOrEmpty(row["quantity"].ToString().Trim()))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('请补齐 数量！');</script>");
                    return;
                }
                if (string.IsNullOrEmpty(row["signDate"].ToString().Trim()))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('请补齐 签单日期！');</script>");
                    return;
                }
                if (string.IsNullOrEmpty(row["signingPerson"].ToString().Trim()))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('请补齐 签单人！');</script>");
                    return;
                }
            }
        }
    }
}
