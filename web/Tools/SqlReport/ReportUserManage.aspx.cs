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

public partial class Tools_SQLReport_ReportUserManage : FounderTecInfoSys.Common.PageBase.DomainMasterPage
{

    private string strJSForRefresh = "<script>window.location='ReportUserManage.aspx';window.parent.leftFrame.document.location.reload();</script>";
    private int UserID
    {
        set
        {
            ViewState["userID"] = value;
        }
        get
        {
            if (null == ViewState["userID"])
            {
                ViewState["userID"] = 0;
            }
            return (int)ViewState["userID"];
        }
    }

    protected int iIndex = 0;
    protected string strFucID = "";

    protected string DepartmentList
    {
        get
        {
            return (null == ViewState["DepartmentList"]) ? "" : ViewState["DepartmentList"].ToString();
        }
        set
        {
            ViewState["DepartmentList"] = value;
        }
    }

    protected List<string> RightList
    {
        get
        {
            return (null == ViewState["RightList"]) ? new List<string>() : (List<string>)ViewState["RightList"];
        }
        set
        {
            ViewState["RightList"] = value;
        }
    }


    protected List<string> AddinIDList
    {
        get
        {
            return (null == ViewState["AddinIDList"]) ? new List<string>() : (List<string>)ViewState["AddinIDList"];
        }
        set
        {
            ViewState["AddinIDList"] = value;
        }
    }


    private FounderTecInfoSys.Common.BaseDataModel.Entity.View_EmployeeInfoDataTable empData
    {
        get
        {
            if (null == ViewState["UserInfo"])
            {
                ViewState["UserInfo"] = new FounderTecInfoSys.Common.BaseDataModel.Entity.View_EmployeeInfoDataTable();
            }
            return (FounderTecInfoSys.Common.BaseDataModel.Entity.View_EmployeeInfoDataTable)ViewState["UserInfo"];
        }
        set
        {
            ViewState["UserInfo"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            if (CurrentUser.RightIsAdmin || CurrentUser.HasAddinAdminRole() || CurrentUser.HasFactoryAdminRole())
            {
                #region 工厂数据绑定
                DataSet ds = new DataSet();

                ds.ReadXml(Server.MapPath("..") + "\\ERPReportFactory.xml");
                dropDownListFactory.DataSource = ds;
                dropDownListFactory.DataTextField = "Name";
                dropDownListFactory.DataValueField = "Value";
                dropDownListFactory.DataBind();



                if (dropDownListFactory.Items.Count == 0)
                {
                    dropDownListFactory.Items.Add(new ListItem("暂无工厂", "0"));
                }
                else if (!CurrentUser.RightIsAdmin)
                {
                    for (int i = dropDownListFactory.Items.Count - 1; i >= 0; i--)
                    {
                        int tmpID = Convert.ToInt32(dropDownListFactory.Items[i].Value);
                        if (!CurrentUser.FactoryIDList.Contains(tmpID) || (CurrentUser.FactoryIDList.Contains(tmpID) && CurrentUser.UseTypeList[CurrentUser.FactoryIDList.IndexOf(tmpID)] == 0))
                        {
                            dropDownListFactory.Items.Remove(dropDownListFactory.Items[i]);
                        }
                    }
                }

                dropDownListFactory.SelectedIndex = 0;

                #endregion

                if (!string.IsNullOrEmpty(Request.QueryString["UID"]))
                {
                    UserID = Convert.ToInt32(Request.QueryString["UID"]);
                }


                #region 删除权限控制
                if (UserID > 0 && (CurrentUser.RightCanDelete || CurrentUser.RightIsCurrentFactoryAdmin))
                {
                    buttonDelete.Visible = true;
                }
                else
                {
                    buttonDelete.Visible = false;
                }
                #endregion

                userDataBinding();

                if (!CurrentUser.RightIsAdmin && CurrentUser.HasAddinAdminRole(Convert.ToInt32(dropDownListFactory.SelectedValue)))
                {
                    dropDownListUserType.SelectedValue = "1";
                    dropDownListUserType.Items.RemoveAt(dropDownListUserType.SelectedIndex);
                }

            }
            else
            {
                FounderTecInfoSys.Common.PageGeneralAction.GoBackShowWarmingWindow("您没有权限查看此页面,开通权限请与管理员联系");
                Response.End();
            }

        }
    }

    private void userDataBinding()
    {
        #region 部门数据绑定

        DataSet dsDepartment = new DataSet();
        dsDepartment.ReadXml(Server.MapPath("..") + "\\ERPReportCate.xml");

        dropDownListDepartment.Items.Clear();
        foreach (DataRow dr in dsDepartment.Tables[0].Select("Factory=0 or Factory=" + dropDownListFactory.SelectedValue))
        {
            ListItem item = new ListItem();
            item.Text = dr["Name"].ToString();
            item.Value = dr["Value"].ToString();
            dropDownListDepartment.Items.Add(item);
        }

        if (dropDownListDepartment.Items.Count == 0)
        {
            dropDownListDepartment.Items.Add(new ListItem("暂无部门", "0"));
        }

        #endregion


        if (UserID > 0)
        {
            labelTitle.Text = "用户资料修改";


            InfoSysEntity.SQLReportUserRightDataTable rightTable = new InfoSysEntityTableAdapters.SQLReportUserRightTableAdapter().GetDataByID(UserID);
            if (rightTable.Rows.Count == 0)
            {
                FounderTecInfoSys.Common.PageGeneralAction.GoBackShowWarmingWindow("用户不存在，或已经被删除");
                Response.End();
            }

            InfoSysEntity.SQLReportUserRightRow rightRow = (InfoSysEntity.SQLReportUserRightRow)rightTable.Rows[0];
            textBoxLoginUser.ReadOnly = true;
            textBoxLoginUser.Text = rightRow.LoginUser;
            textBoxLoginUserRealName.Text = rightRow.LoginUserRealName;

            dropDownListUserType.SelectedValue = rightRow.UserType.ToString();
            AddinIDList = new List<string>(rightRow.AddinIDList.Split(','));

            dropDownListFactory.Enabled = false;
            dropDownListFactory.SelectedValue = rightRow.FactoryID.ToString();

            #region 部门数据绑定

            dropDownListDepartment.Items.Clear();
            foreach (DataRow dr in dsDepartment.Tables[0].Select("Factory=0 or Factory=" + dropDownListFactory.SelectedValue))
            {
                ListItem item = new ListItem();
                item.Text = dr["Name"].ToString();
                item.Value = dr["Value"].ToString();
                dropDownListDepartment.Items.Add(item);
            }

            if (dropDownListDepartment.Items.Count == 0)
            {
                dropDownListDepartment.Items.Add(new ListItem("暂无部门", "0"));
            }

            #endregion

            dropDownListDepartment.SelectedValue = rightRow.DepartmentID.ToString();

            DepartmentList = rightRow.DepartmentList + ",";

            RightList = new List<string>(rightRow.SQLReportIDList.Split(','));

            doUserInfoDatabind(rightRow.EmployeeID);

        }

        DataTable dtTmp = dsDepartment.Tables[0].Copy();
        dtTmp.Rows.Clear();
        foreach (DataRow dr in dsDepartment.Tables[0].Select("Factory=" + dropDownListFactory.SelectedValue))
        {
            dtTmp.Rows.Add(dr.ItemArray);
        }



        repeaterReportCate.DataSource = dtTmp;
        repeaterReportCate.DataBind();

        repeaterERPAddin.DataSource = dtTmp;
        repeaterERPAddin.DataBind();

    }

    protected void imageButtonCheckUser_Click(object sender, ImageClickEventArgs e)
    {
        string strLoginUser = textBoxLoginUser.Text.Trim().ToLower();
        if (!strLoginUser.StartsWith("founderpcb\\"))
        {
            strLoginUser = "founderpcb\\" + strLoginUser;
            textBoxLoginUser.Text = strLoginUser;
        }

        textBoxLoginUserRealName.Text = FounderTecInfoSys.Common.CommonFunction.FuncForDomain.GetUserName(
            System.Configuration.ConfigurationManager.AppSettings["DomainName"],
            System.Configuration.ConfigurationManager.AppSettings["NameOfLoginAD"],
            System.Configuration.ConfigurationManager.AppSettings["PWDofLoginAD"],
            strLoginUser
            );

        doUserInfoDatabind("");
    }

    private void doUserInfoDatabind(string EmployeeID)
    {
        if (string.IsNullOrEmpty(EmployeeID))
        {
            empData = FounderTecInfoSys.Common.BaseDataModel.Module.HrEmployeeInfo.GetEmployeeInfo(textBoxLoginUserRealName.Text);
        }
        else
        {
            empData = new FounderTecInfoSys.Common.BaseDataModel.Entity.View_EmployeeInfoDataTable();
            try
            {
                empData.Rows.Add(((DataRow)FounderTecInfoSys.Common.BaseDataModel.Module.HrEmployeeInfo.GetEmployeeInfo(new Guid(EmployeeID))).ItemArray);
            }
            catch (Exception)
            {
            }
        }
        textEmpNum.Value = empData.Rows.Count.ToString();

        if (empData.Rows.Count > 1)
        {
            gridViewForUserInfo.Caption = "请删除多余的人员信息";
            gridViewForUserInfo.AutoGenerateDeleteButton = true;
        }
        else
        {
            gridViewForUserInfo.Caption = "";
            gridViewForUserInfo.AutoGenerateDeleteButton = false;
        }

        gridViewForUserInfo.DataSource = empData;
        gridViewForUserInfo.DataBind();
    }

    protected void repeaterReportCate_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Repeater curRepeater = (Repeater)e.Item.FindControl("repeaterReportList");
            curRepeater.DataSource = new InfoSysEntityTableAdapters.SQLReportNameListTableAdapter().GetDataByReportCate(Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "Value")), Convert.ToInt32(dropDownListFactory.SelectedValue), 0);
            curRepeater.DataBind();
        }

    }
    protected void buttonSubmit_Click(object sender, EventArgs e)
    {

        string strLoginUser = textBoxLoginUser.Text.Trim().ToLower();
        string strLoginUserRealName = textBoxLoginUserRealName.Text;
        string strDepartmentList = FounderTecInfoSys.Common.CommonFunction.FuncForString.removeLastComma(textCate.Value);
        string strSQLReportIDList = FounderTecInfoSys.Common.CommonFunction.FuncForString.removeLastComma(textRightList.Value);
        string strAddinIDList = FounderTecInfoSys.Common.CommonFunction.FuncForString.removeLastComma(textAddinIDList.Value);
        string strEmployeeID = "";
        string strRightsList = "";
        int userType = Convert.ToInt32(dropDownListUserType.SelectedValue);
        int factoryID = Convert.ToInt32(dropDownListFactory.SelectedValue);
        int departmentID = Convert.ToInt32(dropDownListDepartment.SelectedValue);

        if (factoryID == 0)
        {
            FounderTecInfoSys.Common.PageGeneralAction.ShowWarmingWindow("工厂不存在");
            dropDownListFactory.Focus();
            return;
        }

        if (departmentID == 0)
        {
            FounderTecInfoSys.Common.PageGeneralAction.ShowWarmingWindow("部门不存在");
            dropDownListDepartment.Focus();
            return;
        }

        if (strLoginUser.Equals(string.Empty) || strLoginUser.Equals("founderpcb\\"))
        {
            FounderTecInfoSys.Common.PageGeneralAction.ShowWarmingWindow("AD帐号不能为空");
            textBoxLoginUser.Focus();
            return;
        }
        else
        {
            if (!strLoginUser.StartsWith("founderpcb\\"))
            {
                strLoginUser = "founderpcb\\" + strLoginUser;
                textBoxLoginUser.Text = strLoginUser;
            }
        }

        if (strLoginUserRealName.Equals(string.Empty))
        {
            FounderTecInfoSys.Common.PageGeneralAction.ShowWarmingWindow("真实姓名不能为空");
            imageButtonCheckUser.Focus();
            return;
        }

        if (empData.Rows.Count > 1)
        {
            FounderTecInfoSys.Common.PageGeneralAction.ShowWarmingWindow("请删除多余的人员信息");
            gridViewForUserInfo.Focus();
            return;
        }
        else if (empData.Rows.Count == 1)
        {
            strEmployeeID = empData.Rows[0][empData.EmployeeIDColumn.ColumnName].ToString();
        }

        //if (strDepartmentList.Equals(string.Empty))
        //{
        //    FounderTecInfoSys.Common.PageGeneralAction.ShowWarmingWindow("未设置部门权限");
        //    return;
        //}


        int userStatus = 0;

        int iReturn = 0;

        if (UserID > 0)
        {

            iReturn = (int)new InfoSysEntityTableAdapters.SQLReportUserRightTableAdapter().UpdateQuery(
                strLoginUser,
                strLoginUserRealName,
                strDepartmentList,
                strSQLReportIDList,
                strRightsList,
                userStatus,
                factoryID,
                departmentID,
                strEmployeeID,
                userType,
                strAddinIDList,
                UserID
            );
        }
        else
        {
            iReturn = (int)new InfoSysEntityTableAdapters.SQLReportUserRightTableAdapter().CreateNewRow(
                strLoginUser,
                strLoginUserRealName,
                strDepartmentList,
                strSQLReportIDList,
                strRightsList,
                userStatus,
                factoryID,
                departmentID,
                strEmployeeID,
                userType,
                strAddinIDList
            );
        }

        if (iReturn > 0)
        {
            FounderTecInfoSys.Common.BaseDataModel.UserDataChangeFlagTable.Add(strLoginUser);

            Response.Write(strJSForRefresh);
            //Response.Redirect("ReportUserManage.aspx", true);
        }
        else
        {
            if (iReturn == -2)
            {
                FounderTecInfoSys.Common.PageGeneralAction.ShowWarmingWindow("错误：用户已经存在");
            }
            else
            {
                FounderTecInfoSys.Common.PageGeneralAction.ShowWarmingWindow("错误：出现数据库异常，请稍后再试或联系管理员");
            }
        }
    }


    protected string isCheckedDepartment(string strDepartmentID)
    {
        return DepartmentList.Contains(strDepartmentID + ",") ? " checked='checked' " : "";
    }

    protected string isCheckedReport(string strReportID)
    {
        return RightList.Contains(strReportID) ? " checked='checked' " : "";
    }

    protected string showAddin(string strAddinID)
    {
        return (CurrentUser.RightIsAdmin || CurrentUser.RightIsCurrentFactoryAdmin || CurrentUser.AddinIDList[CurrentUser.FactoryIDList.IndexOf(Convert.ToInt32(dropDownListFactory.SelectedValue))].Contains(strAddinID)) ? "block" : "none";
    }

    protected string isCheckedRightOfOutput(string strReportID)
    {
        if (RightList.Contains(strReportID))
        {
            string strTmp = RightList[RightList.IndexOf(strReportID) + 1];
            return (strTmp.StartsWith("0.01") || strTmp.StartsWith("0.11")) ? " checked='checked' " : "";
        }
        return "";
    }

    protected string isCheckedRightOfOutputAll(string strReportID)
    {
        if (RightList.Contains(strReportID))
        {
            string strTmp = RightList[RightList.IndexOf(strReportID) + 1];

            if (strTmp.Length == 5)
            {
                strTmp += ",";

                return strTmp.EndsWith("1,") ? " checked='checked' " : "";
            }
        }
        return "";
    }

    protected string isCheckedAddinRight(string strReportID)
    {
        if (strFucID.Equals(strReportID))
        {
            iIndex++;
        }
        else
        {
            strFucID = strReportID;
            iIndex = 0;
        }
        if (RightList.Contains(strReportID) && RightList[RightList.IndexOf(strReportID) + 1].Length > iIndex + 2)
        {
            return (RightList[RightList.IndexOf(strReportID) + 1][iIndex + 2] == '1') ? " checked='checked' " : "";
        }
        return "";
    }

    protected string isCheckedAddinAdminRight(string strReportID)
    {

        return AddinIDList.Contains(strReportID) ? " checked='checked' " : "";
    }


    protected string isCheckedRightOfShowSpecialField(string strReportID)
    {
        if (RightList.Contains(strReportID))
        {
            return RightList[RightList.IndexOf(strReportID) + 1].StartsWith("0.1") ? " checked='checked' " : "";
        }
        return "";
    }


    protected void linkButtonNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("ReportUserManage.aspx", true);
    }
    protected void dropDownListFactory_SelectedIndexChanged(object sender, EventArgs e)
    {
        userDataBinding();
    }
    protected void buttonDelete_Click(object sender, EventArgs e)
    {
        if (UserID > 0)
        {
            int iReturn = (int)new InfoSysEntityTableAdapters.SQLReportUserRightTableAdapter().DeleteQuery(
                UserID
            );
            if (iReturn > 0)
            {
                Response.Write(strJSForRefresh);
                //Response.Redirect("ReportUserManage.aspx", true);
            }
            else
            {
                FounderTecInfoSys.Common.PageGeneralAction.GoBackShowWarmingWindow("错误：出现数据库异常，请稍后再试或联系管理员");
                return;
            }
        }
        else
        {
            FounderTecInfoSys.Common.PageGeneralAction.GoBackShowWarmingWindow("错误：请先选择要删除的用户");
            return;
        }
    }
    protected void buttonSearch_Click(object sender, EventArgs e)
    {
        string strLoginUser = textBoxLoginUser.Text.Trim().ToLower();
        int factoryID = Convert.ToInt32(dropDownListFactory.SelectedValue);


        if (strLoginUser.Equals(string.Empty) || strLoginUser.Equals("founderpcb\\"))
        {
            FounderTecInfoSys.Common.PageGeneralAction.ShowWarmingWindow("AD帐号不能为空");
            textBoxLoginUser.Focus();
            return;
        }
        else
        {

            if (!strLoginUser.StartsWith("founderpcb\\"))
            {
                strLoginUser = "founderpcb\\" + strLoginUser;
                textBoxLoginUser.Text = strLoginUser;
            }
        }

        InfoSysEntity.SQLReportUserRightViewDataTable curTable = new InfoSysEntityTableAdapters.SQLReportUserRightViewTableAdapter().GetDataByFactoryIDLoginUser(strLoginUser, factoryID);
        if (curTable.Rows.Count > 0)
        {
            Response.Redirect("ReportUserManage.aspx?UID=" + curTable.Rows[0][0].ToString());
        }
        else
        {
            FounderTecInfoSys.Common.PageGeneralAction.ShowWarmingWindow("错误：未找到此用户");
        }
    }
    protected void repeaterERPAddin_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Repeater curRepeater = (Repeater)e.Item.FindControl("repeaterERPAddinList");

            curRepeater.DataSource = new InfoSysEntityTableAdapters.SQLReportNameListTableAdapter().GetDataByReportCate(Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "Value")), Convert.ToInt32(dropDownListFactory.SelectedValue), 1);

            curRepeater.DataBind();
        }
    }

    protected void repeaterERPAddinList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Repeater curRepeater = (Repeater)e.Item.FindControl("repeaterERPAddinRightList");
            curRepeater.DataSource = new InfoSysEntityTableAdapters.ERPAddinRightTableAdapter().GetDataBySQLReportID(Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "SQLReportID")));
            curRepeater.DataBind();
        }
        //System.Web.HttpContext.Current.Request.Url
    }
    protected void gridViewForUserInfo_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        empData.Rows.RemoveAt(e.RowIndex);
        textEmpNum.Value = empData.Rows.Count.ToString();
        gridViewForUserInfo.DataSource = empData;
        gridViewForUserInfo.DataBind();
    }
}
