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

public partial class Tools_AddinForERP_InputAddinForm : FounderTecInfoSys.Common.PageBase.DomainMasterPage
{
    private string strJSForRefresh = "<script>window.location='InputAddinForm.aspx';window.parent.leftFrame.document.location.reload();</script>";
    private InfoSysEntity.ERPAddinRightDataTable rightTable
    {
        get
        {
            if (null == ViewState["rightTable"])
            {
                ViewState["rightTable"] = new InfoSysEntity.ERPAddinRightDataTable();
            }
            return (InfoSysEntity.ERPAddinRightDataTable)ViewState["rightTable"];
        }
        set
        {
            ViewState["rightTable"] = value;
        }
    }

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
                        if(!CurrentUser.FactoryIDList.Contains(tmpID) || (CurrentUser.FactoryIDList.Contains(tmpID) && CurrentUser.UseTypeList[CurrentUser.FactoryIDList.IndexOf(tmpID)] == 0))
                        {
                            dropDownListFactory.Items.Remove(dropDownListFactory.Items[i]);
                        }
                    }
                }

                dropDownListFactory.SelectedIndex = 0;

                #endregion


                if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
                {
                    labelTitle.Text = "修改ERP辅助功能";
                    int ID = Convert.ToInt32(Request.QueryString["ID"]);

                    dropDownListFactory.Enabled = false;
                    buttonCopy.Visible = true;

                    InfoSysEntityTableAdapters.SQLReportTableAdapter sqlAdapter = new InfoSysEntityTableAdapters.SQLReportTableAdapter();

                    InfoSysEntity.SQLReportDataTable curTable = sqlAdapter.SelectByID(ID);
                    foreach (InfoSysEntity.SQLReportRow curRow in curTable.Rows)
                    {
                        textBoxName.Text = curRow.SQLReportName;
                        textBoxShowURL.Text = (curRow.SQLReportShowURL.GetType() == typeof(DBNull)) ? "" : curRow.SQLReportShowURL;
                        dropDownListReportCate.SelectedValue = curRow.SQLReportCate.ToString();
                        dropDownListFactory.SelectedValue = curRow.SQLReportFactory.ToString();
                        textBoxSortIndex.Text = curRow.SQLReportSortIndex.ToString();

                        rightTable = new InfoSysEntityTableAdapters.ERPAddinRightTableAdapter().GetDataBySQLReportID(curRow.SQLReportID);

                        break;
                    }

                }
                else
                {
                    buttonCopy.Visible = false;
                    buttonDelete.Visible = false;
                }

                departmentDatabinding();
                rightTableDataBing();

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

        #endregion

    }

    protected void buttonSave_Click(object sender, EventArgs e)
    {
        string strReportName = textBoxName.Text.Trim();
        string strShowURL = textBoxShowURL.Text.Trim();

        if (strReportName.Equals(string.Empty))
        {
            FounderTecInfoSys.Common.PageGeneralAction.ShowWarmingWindow("功能名称不能为空");
            textBoxName.Focus();
            return;
        }



        int sortIndex = Convert.ToInt32(textBoxSortIndex.Text);
        int factoryID = Convert.ToInt32(dropDownListFactory.SelectedValue);
        int reportCate = Convert.ToInt32(dropDownListReportCate.SelectedValue);


        string strCreator = System.Web.HttpContext.Current.User.Identity.Name.Trim();

        DateTime dtTime = DateTime.Now;

        int reportStatus = Convert.ToInt32(radioButtonListReportStatus.SelectedValue);

        InfoSysEntityTableAdapters.ERPAddinRightTableAdapter rightAdapter = new InfoSysEntityTableAdapters.ERPAddinRightTableAdapter();
        int ID = 0;

        if (actionType.ToLower().Trim().Equals("normal") && !string.IsNullOrEmpty(Request.QueryString["ID"]))
        {
            ID = Convert.ToInt32(Request.QueryString["ID"]);
            
            if (new InfoSysEntityTableAdapters.SQLReportTableAdapter().UpdateQuery(strReportName, reportCate, "", "", "", "", strShowURL, reportStatus, strCreator, dtTime, "", "", 0, "", factoryID, sortIndex, 1, ID) > 0)
            {
                rightAdapter.DeleteQuery(ID);

                //Response.Redirect("InputAddinForm.aspx", true);
            }
            else
            {
                FounderTecInfoSys.Common.PageGeneralAction.ShowWarmingWindow("操作出现异常, 请稍后再试");
                return;
            }

        }
        else
        {
            ID = Convert.ToInt32(new InfoSysEntityTableAdapters.SQLReportTableAdapter().InsertQuery(strReportName, reportCate, "", "", "", "", strShowURL, reportStatus, strCreator, strCreator, dtTime, dtTime, "", "", 0, 0, "", factoryID, sortIndex, 1, 1));
            if (ID > 0)
            {

                Response.Write(strJSForRefresh);
                //Response.Redirect("InputAddinForm.aspx", true);
            }
            else
            {
                FounderTecInfoSys.Common.PageGeneralAction.ShowWarmingWindow("操作出现异常, 请稍后再试");
                return;
            }
        }

        if (ID > 0)
        {

            foreach (InfoSysEntity.ERPAddinRightRow curRow in rightTable.Rows)
            {
                rightAdapter.InsertQuery(ID, curRow.ERPAddinRightName, strCreator);
            }

            Response.Write(strJSForRefresh);
        }
        else
        {
            FounderTecInfoSys.Common.PageGeneralAction.ShowWarmingWindow("操作出现异常, 请稍后再试");
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("InputAddinForm.aspx", true);
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
        labelTitle.Text = "新增ERP辅助功能";
    }

    private void rightTableDataBing()
    {
        GridView1.DataSource = rightTable;
        GridView1.DataBind();
    }

    protected void buttonAddRight_Click(object sender, EventArgs e)
    {
        InfoSysEntity.ERPAddinRightRow newRow = rightTable.NewERPAddinRightRow();
        newRow.ERPAddinRightName = textBoxRightName.Text.Trim();

        rightTable.AddERPAddinRightRow(newRow);

        rightTableDataBing();

    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        rightTableDataBing();
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        rightTable.Rows[e.RowIndex][rightTable.ERPAddinRightNameColumn.ColumnName] = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBoxName")).Text.Trim();
        GridView1.EditIndex = -1;
        rightTableDataBing();

    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        rightTable.Rows.RemoveAt(e.RowIndex);
        rightTableDataBing();
    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        rightTableDataBing();
    }
}
