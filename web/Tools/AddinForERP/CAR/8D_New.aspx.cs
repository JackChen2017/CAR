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
 
public partial class _8D : FounderTecInfoSys.Common.PageBase.DomainMasterPage 
{
    private int did
    {
        get
        { 
            if(ViewState["did"] == null)
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
        if (!Page.IsPostBack)
        {
            InitDataTable();
            Initialize();
        }
    }

    #region 初始化
    protected void Initialize()
    {
        #region 判断用户权限
        if (!HasRight(XmlSource.GetRightIndex("BD")))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('你没有权限进入此页面！');</script>");
            Response.End();
            return;
        }
        #endregion
        #region 初始化界面
        Init_Company(1);
        did = String.IsNullOrEmpty(Request.QueryString["did"]) ? 0 : int.Parse(Request.QueryString["did"]);
        if (did > 0)
        {
            dataInfo = new CARDataBLL(CurrentFactoryID).GetByKey(did);
            if (dataInfo.op_type != 1)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('非法访问！');</script>");
                Response.End();
                return;
            }
            if (dataInfo.status == 0 || dataInfo.status == 14)   //未审批、未发启
            {
                div_AppListEdit.Style.Remove("display");
                div_AppListShow.Style.Add("display", "none");
                //div_AppListEdit.Visible = true;
                //div_AppListShow.Visible = false;
                #region 审批信息
                ApprovalTable = new CARLogBLL(CurrentFactoryID).GetDataSet("select sp_step as 步骤,'' as 审批人,sp_user as 帐号 from CAR_Table_LOG where sn_type='' and SN_PTR=" + dataInfo.rkey.ToString() + " order by sp_step");
                GridView1.DataSource = ApprovalTable;
                GridView1.DataBind();
                #endregion
            }
            else                        //已经发送审批,不可更改
            {
                sendApproval.Enabled = false;
                ibtn_Save.Enabled = false;
                //ibtn_Cancel.Enabled = false; 取消按钮不实现任何功能
                div_AppListShow.Style.Remove("display");
                div_AppListEdit.Style.Add("display", "none");
                //div_AppListEdit.Visible = false;
                //div_AppListShow.Visible = true;
                #region 审批信息
                tb_ApprovalInfo = new CARLogBLL(CurrentFactoryID).GetDataSet("select sp_step,sp_user,sp_end_date,status,sp_content from CAR_Table_LOG where SN_PTR=" + dataInfo.rkey.ToString()+" order by sp_step");
                for (int i = 0; i < tb_ApprovalInfo.Rows.Count; i++)
                {
                    tb_ApprovalInfo.Rows[i][1] = GetUserName(tb_ApprovalInfo.Rows[i][1].ToString());
                }
                GridView2.DataSource = tb_ApprovalInfo;
                GridView2.DataBind();
                #endregion
            }
            #region 申请信息
            Required_Date.Text = dataInfo.required_date.ToString();
            try { Serial_No.Items.FindByText(dataInfo.serial_no).Selected = true; }
            catch { }
            Happen_Date.Text = dataInfo.happen_date.ToString();
            From_Comp.Items.FindByText(dataInfo.from_comp).Selected = true;
            CAR_Comp.Items.FindByText(dataInfo.car_comp).Selected = true;
            Issued_User.Text = dataInfo.issued_user;
            Issued_APP.Text = dataInfo.issued_app;
            Received_User.Text = dataInfo.received_user;
            CAR_Content.Text = Server.HtmlDecode(dataInfo.car_content);
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
            if (dataInfo.nowuser != CurrentUser.UserADAcount && !CurrentUser.RightIsAdmin)//如果当前用户不是发启人,就只能查看
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
        nodeList = root.SelectNodes("//configuration/list"+i.ToString().Trim()+"/item");
        foreach (XmlNode nodeitem in nodeList)
        {
            string tmp=nodeitem.Attributes["name"].Value.ToString();
            From_Comp.Items.Add(tmp);
            CAR_Comp.Items.Add(tmp);           
        }

    }
    #endregion

    //固定审批流
    protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
    {       
        RadioButton1.Checked = true;
        RadioButton2.Checked = false;
        ViewShenPi.Visible = true;
        SetShenPi.Visible = false;
        if (GridView1.Rows.Count<1)
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

    private void BindGrid()
    {
        GridView1.DataSource = ApprovalTable;
        GridView1.DataBind();

        int currentStep = GridView1.Rows.Count + 1;
        lableStepNum.Text = currentStep.ToString();
        textApprovalUserNameList.Value = "";
        sendApproval.Enabled = true;
    }

    protected void Button1_Click(object sender, EventArgs e)  //确定并添加
    {
        DataRow dr = ApprovalTable.NewRow();
        //dr.ItemArray = new object[] { lableStepNum.Text, textApprovalUserNameList.Value };
        dr[0] = lableStepNum.Text;
        dr[1] = textApprovalUserNameList.Value.Split('(')[0];
        dr[2] = textApprovalUserNameList.Value.Trim().Remove(textApprovalUserNameList.Value.Trim().Length - 1).Split('(')[1];
        ApprovalTable.Rows.Add(dr);
        BindGrid();
    }

    #region 将信息写入库
    /// <summary>
    /// 将信息写入库
    /// </summary>
    private int Writedata(int status)
    {
        CARDataBLL dataBll = new CARDataBLL(CurrentFactoryID);
        DataInfo info = new DataInfo();
        if (did == 0)
        {
            info.rkey = 0;
            info.FactoryID = decimal.Parse(CurrentFactoryID.ToString());
            info.serial_no = Serial_No.SelectedItem.Text;
        }
        else
        {
            info = dataBll.GetByKey(did);
            if (info.status == 14)
            {
                decimal fid = decimal.Parse(info.FactoryID.ToString());
                string strTemp = info.serial_no;
                info = new DataInfo();
                info.rkey = did;
                info.FactoryID = fid;
                info.serial_no = strTemp;
            }
        }
        info.required_date = Convert.ToDateTime(Required_Date.Text);
        info.happen_date = DateTime.Parse(Happen_Date.Text);
        info.issued_date = DateTime.Now;
        info.from_comp = From_Comp.Text;
        info.car_comp = CAR_Comp.Text;
        info.issued_user = Issued_User.Text;
        info.issued_app = Issued_APP.Text;
        info.received_user = Received_User.Text;
        info.car_content = CAR_Content.Text;
        info.op_type = 1;
        info.status = status;
        info.nowuser = CurrentUser.UserADAcount;//发起人

        int a = 0;
        if (did == 0)
        {
            a = dataBll.AddData(info);
        }
        else
        {
            a = dataBll.UpdateData(info);
        }
        if (a != 0)
        {
            return -1;
        }
        return int.Parse(info.rkey.ToString());    
    }

    private int Writelog(int sn_ptr)
    {
        CARLogBLL logBll = new CARLogBLL(CurrentFactoryID);
        DataTable tb_temp = new DataTable();
        tb_temp = logBll.GetDataSet("select rkey from CAR_Table_LOG where SN_PTR = " + sn_ptr.ToString());
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
                logInfo.sn_type = "";
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

    protected void sendApproval_Click(object sender, ImageClickEventArgs e)
    {
        if (ApprovalTable.Rows.Count < 2)
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
        string subject = "8D Form 有新的审批。";
        string url = System.Configuration.ConfigurationManager.AppSettings["url"].ToString();
        string body = url;
        XmlSource.SendEmail(sp_user, subject, body);
        #endregion
        Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('发送成功！');</script>");
        ibtn_Save.Enabled = false;
        sendApproval.Enabled = false;
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

    public string ReadApprovalUserList(int i, string XName)
    {
        XmlDocument xmDoc = new XmlDocument();
        xmDoc.Load(Server.MapPath(".") + @"\Configuration\SelfApprovalUserList.xml");

        XmlNode rightList = xmDoc.SelectSingleNode("configuration");

        XmlNode rightItem = rightList.SelectSingleNode("list" + i.ToString());

        XmlNode Item = rightItem.SelectSingleNode(XName);

        return Item.Attributes["index"].Value;
    }
  
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {        
        ApprovalTable.Rows.RemoveAt(e.RowIndex);
        BindGrid();
    }
    /// <summary>
    /// 保存(未发送审批)
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
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
        Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('保存成功！');</script>");
        ibtn_Save.Enabled = false;
        sendApproval.Enabled = false;
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
}
