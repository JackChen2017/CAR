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

public partial class Tools_SQLReport_InputSQLForm : FounderTecInfoSys.Common.PageBase.DomainMasterPage
{
    private string strJSForRefresh = "<script>window.location='InputSqlForm.aspx';window.parent.leftFrame.document.location.reload();</script>";
    private string actionType
    {
        set
        {
            ViewState["actionType"] = value;
        }
        get
        {
            if (null == ViewState["actionType"])
            {
                ViewState["actionType"] = "normal";
            }

            return ViewState["actionType"].ToString();
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (CurrentUser.RightIsAdmin || CurrentUser.HasFactoryAdminRole())
            {
                if (CurrentUser.RightCanDelete || CurrentUser.RightIsCurrentFactoryAdmin)
                {
                    buttonDelete.Visible = true;
                }
                else
                {
                    buttonDelete.Visible = false;
                }


                DataSet ds = new DataSet();

                #region 工厂数据绑定

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


                if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
                {
                    labelTitle.Text = "修改查询报表";
                    int ID = Convert.ToInt32(Request.QueryString["ID"]);

                    dropDownListFactory.Enabled = false;
                    buttonCopy.Visible = true;

                    InfoSysEntityTableAdapters.SQLReportTableAdapter sqlAdapter = new InfoSysEntityTableAdapters.SQLReportTableAdapter();

                    InfoSysEntity.SQLReportDataTable curTable = sqlAdapter.SelectByID(ID);
                    foreach (InfoSysEntity.SQLReportRow curRow in curTable.Rows)
                    {
                        textBoxReportName.Text = curRow.SQLReportName;
                        textBoxSQLCommand.Text = curRow.SQLReportSqlCommand;
                        textBoxSQLSQLWhere.Text = (curRow.SQLReportSqlWhere.GetType() == typeof(DBNull)) ? "" : curRow.SQLReportSqlWhere;
                        textBoxSQLOrder.Text = (curRow.SQLReportSqlOrder.GetType() == typeof(DBNull)) ? "" : curRow.SQLReportSqlOrder;
                        textBoxSpecialField.Text = (curRow.SQLReportSpecialField.GetType() == typeof(DBNull)) ? "" : curRow.SQLReportSpecialField;
                        textBoxShowURL.Text = (curRow.SQLReportShowURL.GetType() == typeof(DBNull)) ? "" : curRow.SQLReportShowURL;
                        radioButtonListReportStatus.SelectedValue = curRow.SQLReportStatus.ToString();
                        dropDownListReportCate.SelectedValue = curRow.SQLReportCate.ToString();
                        radioButtonListFucCode.SelectedValue = curRow.SQLReportFuncCode.ToString();
                        textBoxComment.Text = curRow.SQLReportComment;
                        textBoxCalculateField.Text = curRow.SQLReportCalculateField;
                        dropDownListFactory.SelectedValue = curRow.SQLReportFactory.ToString();
                        textBoxSortIndex.Text = curRow.SQLReportSortIndex.ToString();
                        checkBoxIsLimited.Checked = curRow.SQLReportIsLimited == 1 ? true : false;

                        string strBelongsTo = curRow.SQLReportBelongsTo.ToString();
                        foreach (string str in strBelongsTo.Split(','))
                        {

                            for (int i = 0; i < checkBoxListReportCate.Items.Count; i++)
                            {
                                ListItem item = checkBoxListReportCate.Items[i];
                                if (item.Value.Equals(str))
                                {
                                    item.Selected = true;
                                }
                            }
                        }

                        break;
                    }

                }
                else
                {
                    buttonCopy.Visible = false;
                }

                departmentDatabinding();

            }
            else
            {
                FounderTecInfoSys.Common.PageGeneralAction.GoBackShowWarmingWindow("您没有权限查看此页面,开通权限请与管理员联系");
                Response.End();
            }
        }
    }

    private void departmentDatabinding()
    {
        #region 部门/附属部门 数据绑定

        DataSet dsDepartment = new DataSet();

        dsDepartment.ReadXml(Server.MapPath("..") + "\\ERPReportCate.xml");

        DataTable dtTmp = dsDepartment.Tables[0].Copy();
        dtTmp.Rows.Clear();
        foreach (DataRow dr in dsDepartment.Tables[0].Select("Factory=" + dropDownListFactory.SelectedValue))
        {

            dtTmp.Rows.Add(dr.ItemArray);
        }



        dropDownListReportCate.DataSource = dtTmp;
        dropDownListReportCate.DataTextField = "Name";
        dropDownListReportCate.DataValueField = "Value";
        dropDownListReportCate.DataBind();

        checkBoxListReportCate.DataSource = dtTmp;
        checkBoxListReportCate.DataTextField = "Name";
        checkBoxListReportCate.DataValueField = "Value";
        checkBoxListReportCate.DataBind();

        #endregion

    }

    protected void buttonSave_Click(object sender, EventArgs e)
    {
        string strReportName = textBoxReportName.Text.Trim();
        string strSqlCommand = textBoxSQLCommand.Text.Trim();
        string strSqlWhere = textBoxSQLSQLWhere.Text.Trim();
        string strSqlOrder = textBoxSQLOrder.Text.Trim();
        string strShowURL = textBoxShowURL.Text.Trim();
        string strComment = textBoxComment.Text.Trim();
        string strCalculateField = textBoxCalculateField.Text.Trim();
        int sortIndex = Convert.ToInt32(textBoxSortIndex.Text);

        if (strReportName.Equals(string.Empty))
        {
            FounderTecInfoSys.Common.PageGeneralAction.ShowWarmingWindow("报表名称不能为空");
            textBoxReportName.Focus();
            return;
        }



        string strBelongsTo = "";
        foreach (ListItem item in checkBoxListReportCate.Items)
        {
            if (item.Selected)
            {
                strBelongsTo += item.Value + ",";
            }
        }

        int factoryID = Convert.ToInt32(dropDownListFactory.SelectedValue);
        int reportCate = Convert.ToInt32(dropDownListReportCate.SelectedValue);


        string strCreator = System.Web.HttpContext.Current.User.Identity.Name.Trim();

        DateTime dtTime = DateTime.Now;

        string strSpecialField = textBoxSpecialField.Text.Trim();
        int reportStatus = Convert.ToInt32(radioButtonListReportStatus.SelectedValue);
        int reportFuncCode = Convert.ToInt32(radioButtonListFucCode.SelectedValue);
        int isLimited = checkBoxIsLimited.Checked ? 1 : 0;


        int ID = 0;
        if (actionType.ToLower().Trim().Equals("normal") && !string.IsNullOrEmpty(Request.QueryString["ID"]))
        {
            ID = Convert.ToInt32(Request.QueryString["ID"]);
            
            if (new InfoSysEntityTableAdapters.SQLReportTableAdapter().UpdateQuery(strReportName, reportCate, strSqlCommand, strSqlWhere, strSqlOrder, strSpecialField, strShowURL, reportStatus, strCreator, dtTime, strComment, strBelongsTo, reportFuncCode, strCalculateField, factoryID, sortIndex, isLimited, ID) > 0)
            {
                Response.Write(strJSForRefresh);
                //Response.Redirect("InputSqlForm.aspx", true);
            }
            else
            {
                FounderTecInfoSys.Common.PageGeneralAction.ShowWarmingWindow("操作出现异常, 请稍后再试");
            }

        }
        else
        {
            ID = Convert.ToInt32(new InfoSysEntityTableAdapters.SQLReportTableAdapter().InsertQuery(strReportName, reportCate, strSqlCommand, strSqlWhere, strSqlOrder, strSpecialField, strShowURL, reportStatus, strCreator, strCreator, dtTime, dtTime, strComment, strBelongsTo, 0, reportFuncCode, strCalculateField, factoryID, sortIndex, 0, isLimited));
            if (ID > 0)
            {
                Response.Write(strJSForRefresh);
                //Response.Redirect("InputSqlForm.aspx", true);
            }
            else
            {
                FounderTecInfoSys.Common.PageGeneralAction.ShowWarmingWindow("操作出现异常, 请稍后再试");
            }
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("InputSqlForm.aspx", true);
    }
    protected void buttonDelete_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
        {
            int ID = Convert.ToInt32(Request.QueryString["ID"]);
            new InfoSysEntityTableAdapters.SQLReportTableAdapter().DeleteQuery(ID);
            Response.Write(strJSForRefresh);
        }
        else
        {
            FounderTecInfoSys.Common.PageGeneralAction.ShowWarmingWindow("非法操作");
            //FounderTecInfoSys.Common.PageGeneralAction.RefreshSelf();
        }
    }
    protected void dropDownListFactory_SelectedIndexChanged(object sender, EventArgs e)
    {
        departmentDatabinding();
    }
    protected void buttonCopy_Click(object sender, EventArgs e)
    {
        actionType = "COPY";
        dropDownListFactory.Enabled = true;
        labelTitle.Text = "新增查询报表";

    }
}
