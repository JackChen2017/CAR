using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using InfoSysEntityTableAdapters;


public partial class Tools_SQLReport_ShowSql : FounderTecInfoSys.Common.PageBase.DomainMasterPage
{
    #region 内部参数

    private string UpRowData
    {
        set
        {
            ViewState["UpRowData"] = value;
        }
        get
        {
            if (null == ViewState["UpRowData"])
            {
                ViewState["UpRowData"] = "";
            }
            return ViewState["UpRowData"].ToString();
        }
    }


    private bool needSetFormat
    {
        set
        {
            ViewState["NeedSetFormat"] = value;
        }
        get
        {
            if (null == ViewState["NeedSetFormat"])
            {
                ViewState["NeedSetFormat"] = true;
            }
            return (bool)ViewState["NeedSetFormat"];
        }
    }

    private bool isShowSpecialField
    {
        get
        {
            return (bool)ViewState["isShowSpecialField"];
        }
        set
        {
            ViewState["isShowSpecialField"] = value;
        }
    }

    private bool isShowOutputButton
    {
        get
        {
            return (bool)ViewState["isShowOutputButton"];
        }
        set
        {
            ViewState["isShowOutputButton"] = value;
        }
    }

    private int reportFuncCode
    {
        get
        {
            if (null == ViewState["reportFuncCode"])
            {
                ViewState["reportFuncCode"] = 0;
            }
            return (int)ViewState["reportFuncCode"];
        }
        set
        {
            ViewState["reportFuncCode"] = value;
        }
    }

    /// <summary>
    /// 报表名称
    /// </summary>
    private string strReportName
    {
        get
        {
            return ViewState["ReportName"].ToString();
        }
        set
        {
            ViewState["ReportName"] = value;
        }
    }


    /// <summary>
    /// SQL命令(正式执行的)
    /// </summary>
    private string strCommandForReal
    {
        get
        {
            return ViewState["realSqlCommand"].ToString();
        }
        set
        {
            ViewState["realSqlCommand"] = value;
        }
    }



    /// <summary>
    /// SQL命令
    /// </summary>
    private string strCommand
    {
        get
        {
            return ViewState["SqlCommand"].ToString();
        }
        set
        {
            ViewState["SqlCommand"] = value;
        }
    }

    /// <summary>
    /// 条件
    /// </summary>
    private string strWhere
    {
        get
        {
            return ViewState["SqlWhere"].ToString();
        }
        set
        {
            ViewState["SqlWhere"] = value;
        }
    }

    /// <summary>
    /// 排序字段
    /// </summary>
    private string strOrder
    {
        get
        {
            return ViewState["SqlOrder"].ToString();
        }
        set
        {
            ViewState["SqlOrder"] = value;
        }
    }

    /// <summary>
    /// 特殊字段
    /// </summary>
    private string strSpecialField
    {
        get
        {
            if (null == ViewState["SqlSpecialField"])
            {
                ViewState["SqlSpecialField"] = "";
            }
            return ViewState["SqlSpecialField"].ToString();
        }
        set
        {
            ViewState["SqlSpecialField"] = value;
        }
    }

    /// <summary>
    /// 报表状态
    /// </summary>
    private int reportStatus
    {
        get
        {
            return (int)ViewState["ReportStatus"];
        }
        set
        {
            ViewState["ReportStatus"] = value;
        }
    }

    /// <summary>
    /// 是否限制显示3000条
    /// </summary>
    private bool isLimited
    {
        get
        {
            if (null == ViewState["isLimited"])
            {
                ViewState["isLimited"] = true;
            }
            return (bool)ViewState["isLimited"];
        }
        set
        {
            ViewState["isLimited"] = value;
        }
    }




    /// <summary>
    /// 原始数据集
    /// </summary>
    private DataSet ds;


    /// <summary>
    /// 实际使用的数据库
    /// </summary>
    private DataSet dsCurrent;
    /// <summary>
    /// 当前排序字段
    /// </summary>
    private string SortField
    {
        get
        {

            return ViewState["SortField"] == null ? "" : ViewState["SortField"].ToString();
        }
        set
        {
            ViewState["SortField"] = value;
        }
    }


    private List<string> listCalculateField
    {
        set
        {
            ViewState["listCalculateField"] = value;
        }
        get
        {
            if (null == ViewState["listCalculateField"])
            {
                ViewState["listCalculateField"] = new List<string>();
            }

            return (List<string>)ViewState["listCalculateField"];
        }
    }

    #endregion

    private List<string> listFootSum = new List<string>();

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {

            //listFootSum.Add("合计:");
            if (null == Request.UrlReferrer || (!Request.UrlReferrer.ToString().ToLower().Contains("left.aspx") && !Request.UrlReferrer.ToString().ToLower().Contains("searchcondition.aspx")))
            {
                FounderTecInfoSys.Common.PageGeneralAction.GoBackShowWarmingWindow("警告，你的操作属于非法操作！");
                Response.End();
            }
            labelField.Attributes.Add("onclick", "if(tableOfField.style.display=='none') {tableOfField.style.display='block';} else {tableOfField.style.display='none';} ");


            if (CurrentFactoryID <= 0 || CurrentFunctionID <= 0)
            {
                FounderTecInfoSys.Common.PageGeneralAction.GoBackShowWarmingWindow("报表未找到或已经被删除");
                Response.End();
            }


            #region 调试辅助系统
            if (CurrentUser.RightIsAdmin)
            {
                tableForDebugInfo.Visible = true;
            }
            else
            {
                tableForDebugInfo.Visible = false;
            }
            #endregion


            SQLReportTableAdapter sqlAdapter = new SQLReportTableAdapter();

            InfoSysEntity.SQLReportDataTable curTable = sqlAdapter.GetDataByID(CurrentUser.UserADAcount, Request.UserHostAddress, CurrentFunctionID);
            foreach (InfoSysEntity.SQLReportRow curRow in curTable.Rows)
            {
                // 权限

                if (HasRight(1))  // 特殊字段
                {
                    isShowSpecialField = true;
                }
                else
                {
                    isShowSpecialField = false;
                }

                if (HasRight(2) || HasRight(3) || curRow.SQLReportType == 2) // 导出功能
                {
                    isShowOutputButton = true;
                }
                else
                {
                    isShowOutputButton = false;
                }



                strReportName = curRow.SQLReportName;
                labelTitle.Text = strReportName;

                if (curRow.SQLReportIsLimited == 1)
                {
                    strCommand = "select top 3000 * from ( " + curRow.SQLReportSqlCommand + " ) as tmp where 1=1 ";
                }
                else
                {
                    isLimited = false;
                    strCommand = "select * from ( " + curRow.SQLReportSqlCommand + " ) as tmp where 1=1 ";
                }
                strWhere = Convert.IsDBNull(curRow.SQLReportSqlWhere) ? "" : curRow.SQLReportSqlWhere;
                strOrder = Convert.IsDBNull(curRow.SQLReportSqlOrder) ? "" : curRow.SQLReportSqlOrder;
                strSpecialField = Convert.IsDBNull(curRow.SQLReportSpecialField) ? "" : curRow.SQLReportSpecialField;
                reportStatus = curRow.SQLReportStatus;
                labelComment.Text = curRow.SQLReportComment;


                string strCalField = curRow.SQLReportCalculateField;

                string[] str = strCalField.Split(',');
                for (int i = 0; i < str.Length; i++)
                {
                    str[i] = str[i].Trim();
                    if (!str[i].Equals(string.Empty) && !listCalculateField.Contains(str[i]))
                    {
                        if (
                            isShowSpecialField
                            ||
                            string.IsNullOrEmpty(strSpecialField) || (!FounderTecInfoSys.Common.CommonFunction.FuncForString.isContain(strSpecialField, str[i], ','))
                            )
                        {
                            listCalculateField.Add(str[i]);
                        }
                    }
                }


                reportFuncCode = curRow.SQLReportFuncCode;

                break;
            }

            btnSaveToExcel.Visible = isShowOutputButton;


            if (listCalculateField.Count > 0)
            {
                GridView1.ShowFooter = true;
            }
            else
            {
                GridView1.ShowFooter = false;
            }

            showSearchData();


        }
    }


    private void showSearchData()
    {
        buttonSearch.Enabled = true;
        labelCurrentSearch.Text = "";
        if (!string.IsNullOrEmpty(Request.Params["searchValue"]))
        {
            buttonSearch.Enabled = false;
            string strSearchSplit = Request.Params["searchSplit"].ToString().Trim();
            string[] strSearchField = Request.Params["searchField"].Split(',');
            string[] strSearchMath = Request.Params["searchMath"].Split(',');
            string[] strSearchValue = FounderTecInfoSys.Common.CommonFunction.FuncForString.removeLastComma(Request.Params["searchValue"]).Split(',');
            string[] strSearchAndOr = Request.Params["searchAndOr"].Split(',');

            for (int i = 0; i < strSearchValue.Length; i++)
            {
                if (strSearchMath[i].ToUpper().Equals("LIKE"))
                {
                    strSearchValue[i] = "'" + strSearchValue[i] + "%'";
                }
                else
                {
                    if (!strSearchMath[i].ToUpper().Equals("IS"))
                    //if (tmpDS.Tables[0].Columns[strSearchField[i]].DataType == typeof(string) ||
                    //    tmpDS.Tables[0].Columns[strSearchField[i]].DataType == typeof(DateTime)
                    //    )
                    {
                        strSearchValue[i] = "'" + strSearchValue[i] + "'";
                    }
                }
                labelCurrentSearch.Text += string.Format(" {0} {1} {2} {3}", new string[] { 
                strSearchField[i] ,
                strSearchMath[i] ,
                strSearchValue[i] ,
                (strSearchAndOr[i].Equals("0") ? "" : strSearchAndOr[i])});
            }

            labelCurrentSearch.Text = strSearchSplit + labelCurrentSearch.Text;

            if (labelCurrentSearch.Text.Length > 0)
            {
                strWhere = " ( " + labelCurrentSearch.Text + " ) ";
            }

            labelCurrentSearch.Text = labelCurrentSearch.Text.Replace("AND", "并且").Replace("OR", "或者");

        }

        showData();
    }


    private void showData()
    {
        #region 生成SQL语句
        strCommandForReal = strCommand;

        if (!string.IsNullOrEmpty(strWhere))
        {
            strCommandForReal += " And ( " + strWhere + " )";
        }

        strCommandForReal = strCommandForReal.Replace("ORDER BY", "order by");

        if (!string.IsNullOrEmpty(strOrder))
        {
            strCommandForReal += "     ORDER BY   " + strOrder;
            //strCommandForReal += "     order BY   " + strOrder;
        }

        checkBoxListColumn.Items.Clear();
        checkBoxListColumn.Items.Clear();

        #region 条数限定提示
        if (isLimited)
        {
            string strCommandForCount = strCommandForReal.Replace("select top 3000 * from (", "select count(*) from (");
            if (strCommandForCount.Contains("ORDER BY"))
            {
                strCommandForCount = strCommandForCount.Remove(strCommandForCount.IndexOf(" ORDER BY ") - 1);
            }

            strCommandForReal += "    " + strCommandForCount;
        }
        #endregion
        #endregion

        showData(strCommandForReal, true);
    }


    private void showData(string strSQL, bool isFirst)
    {
        try
        {
            if (CurrentUser.RightIsAdmin)
            {
                string strConn = System.Configuration.ConfigurationManager.ConnectionStrings[CurrentFactoryID.ToString()].ToString();
                if (!strConn.Trim().Equals(string.Empty))
                {
                    strConn = strConn.Substring(0, strConn.ToLower().IndexOf("user"));
                    label1.Text = "" + strConn.Replace(" ", "").Replace(";", "").Replace("DataSource=", "服务器：").Replace("InitialCatalog=", "  数据库：");
                }
            }

            SqlCommand command = new SqlCommand();
            command.CommandTimeout = 60;
            command.CommandText = strSQL;

            labelSQL.Text = command.CommandText;

            command.Connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[CurrentFactoryID.ToString()].ToString());
            // 返回DataSet数据集
            ds = FounderTecInfoSys.Common.SQLBase.ERPSQLManager.GetInstance().GetSQL(command);
            // 返回DataTable
            DataTable dt = new DataTable();
            FounderTecInfoSys.Common.SQLBase.ERPSQLManager.GetInstance().GetSQL(dt, command);

            if (ds.Tables.Count == 0)
            {
                buttonChange.Enabled = false;
                buttonSearch.Enabled = false;

                string strWarming = @"<br/><br/><br/><strong>错误提示：</strong> <br/> 1. 您的添加的查询条件不成立,或其中有错误的操作符；<br/> 2. 报表读取出现异常，请与管理员联系一下，我们会尽快解决。<br/>";
                if (CurrentUser.RightIsAdmin)
                {
                    strWarming += "3. SQL语句出现问题，请跟踪一下SQL语句的执行情况";

                    if (null != Session[FounderTecInfoSys.Common.ConstForSession.ErrorMessage])
                    {
                        strWarming += "<br/><br/><div style='background-color:#efefef'><br/><strong><font color=red>SQL执行器捕获的错误为:</font></strong><br/>&nbsp;&nbsp;&nbsp;&nbsp;" + Session[FounderTecInfoSys.Common.ConstForSession.ErrorMessage].ToString() + "<br/><br/></div>";
                    }
                }
                strWarming += @"<br/><br/><br/><br/><br/>";
                Response.Write(strWarming);
                return;
            }

            if (isFirst)
            {
                checkBoxListColumn.Items.Clear();

                for (int i = ds.Tables[0].Columns.Count - 1; i >= 0; i--)
                {
                    DataColumn dc = ds.Tables[0].Columns[i];
                    if (!isShowSpecialField)
                    {
                        if (!string.IsNullOrEmpty(strSpecialField) && FounderTecInfoSys.Common.CommonFunction.FuncForString.isContain(strSpecialField, dc.ColumnName, ','))
                        {
                            ds.Tables[0].Columns.Remove(dc);
                            continue;
                        }
                    }

                    ListItem item = new ListItem(dc.ColumnName);

                    item.Selected = true;
                    checkBoxListColumn.Items.Insert(0, item);
                }
            }

            for (int i = ds.Tables[0].Columns.Count - 1; i >= 0; i--)
            {
                DataColumn dc = ds.Tables[0].Columns[i];
                // 特殊字段显示与否
                if (!isShowSpecialField)
                {
                    if (!string.IsNullOrEmpty(strSpecialField) && FounderTecInfoSys.Common.CommonFunction.FuncForString.isContain(strSpecialField, dc.ColumnName, ','))
                    {
                        ds.Tables[0].Columns.Remove(dc);
                        continue;
                    }
                }
            }

            dsCurrent = ds.Copy();

            if (!isFirst)
            {
                foreach (ListItem item in checkBoxListColumn.Items)
                {
                    if (!item.Selected)
                    {
                        if (dsCurrent.Tables[0].Columns.Contains(item.Text))
                        {
                            dsCurrent.Tables[0].Columns.Remove(item.Text);
                        }
                    }
                }
            }



            gridDataBinding();

            buttonChange.Enabled = true;

            #region 条数限定提示
            if (isLimited && isFirst)
            {
                int totalCount = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
                if (totalCount > 3000)
                {
                    FounderTecInfoSys.Common.PageGeneralAction.ShowWarmingWindow("查询的记录总数为: [" + totalCount.ToString() + "]  当前显示的条件为: [ 3000 ]");
                }
            }
            #endregion


        }
        catch (Exception ex)
        {
            buttonChange.Enabled = false;
            buttonSearch.Enabled = false;
            string strWarming = @"<strong>出现错误：</strong>请与管理员联系！<br>";
            if (CurrentUser.RightIsAdmin)
            {
                strWarming += "详细错误信息如下：<br/>" + ex.Message + "<br /><br />错误来源：" + ex.Source;

            }
            Response.Write(strWarming);
        }

    }

    private void gridDataBinding()
    {
        GridView1.Visible = true;
        //GridView1.Caption = strReportName;

        if (SortField.Length > 0)
        {
            dsCurrent.Tables[0].DefaultView.Sort = SortField;
        }

        GridView1.DataSource = dsCurrent.Tables[0].DefaultView;
        GridView1.DataBind();
    }

    protected void buttonChange_Click(object sender, EventArgs e)
    {
        showData(strCommandForReal, false);
    }
    protected void btnSaveToExcel_Click(object sender, EventArgs e)
    {
        showData(strCommandForReal, false);



        if (!CurrentUser.RightIsAdmin && !CurrentUser.RightIsCurrentFactoryAdmin)
        {
            //  无"全导出"权限时,屏蔽[特殊字段]的导出
            // 有"受限导出"权限时,屏蔽[特殊字段]的导出
            // 以上两种情况有一种成立即不能导出[特殊字段]
            if (HasRight(2) || !HasRight(3))
            {
                if (strSpecialField.Length > 0)
                {
                    for (int i = dsCurrent.Tables[0].Columns.Count - 1; i >= 0; i--)
                    {
                        DataColumn dc = dsCurrent.Tables[0].Columns[i];
                        if (FounderTecInfoSys.Common.CommonFunction.FuncForString.isContain(strSpecialField, dc.ColumnName, ','))
                        {
                            dsCurrent.Tables[0].Columns.Remove(dc);
                        }
                    }
                }
            }
        }

        GridViewForDownload.DataSource = dsCurrent.Tables[0].DefaultView;
        GridViewForDownload.DataBind();
        FounderTecInfoSys.Common.CommonFunction.OutputFunction.ToExecl(GridViewForDownload, "NewReport");
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control); 
    }

    protected void checkBoxListColumn_SelectedIndexChanged(object sender, EventArgs e)
    {
        showData(strCommandForReal, false);
    }
    protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (SortField != e.SortExpression)
            SortField = e.SortExpression;
        else
            SortField = e.SortExpression + " DESC";

        UpRowData = "";
        needSetFormat = true;

        showData(strCommandForReal, false);

    }
    protected void dropDownListField_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void buttonSearch_Click(object sender, EventArgs e)
    {
        buttonSearch.Enabled = false;
        List<string> listColumn = new List<string>();
        foreach (ListItem item in checkBoxListColumn.Items)
        {
            listColumn.Add(item.Text);
        }
        Session["TableColumn"] = listColumn;
        ScriptManager.RegisterStartupScript(this, this.GetType(), "12", "openpage('SearchCondition.aspx?ID=" + CurrentFunctionID + "&FID=" + CurrentFactoryID + "', 580,400);", true);
    }


    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            //e.Row.Attributes.Add("onmouseout", "if(this.style.backgroundColor='Gray') {this.style.backgroundColor=\"" + e.Row.Style["BACKGROUND-COLOR"] + "\";}");
            //e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor=\"" + "Gray" + "\"");
            e.Row.Style.Add(HtmlTextWriterStyle.Cursor, "hand");
            e.Row.ToolTip = "点击一次，可以变色";
            e.Row.Attributes.Add("onclick", "if(this.style.backgroundColor==''){this.style.backgroundColor='#eaeaea';this.title='再点一次，可以去色';}else{this.style.backgroundColor='';this.title='点击一次，可以变色';}");
            DataRowView drv = (DataRowView)e.Row.DataItem;
            for (int i = 0; i < drv.DataView.Table.Columns.Count; i++)
            {
                if (listFootSum.Count <= i)
                {
                    listFootSum.Add("");
                }
                if (drv[i].GetType() == typeof(DateTime))
                {
                    DateTime dtTime = Convert.ToDateTime(drv[i]);
                    if (dtTime.Hour == 0 && dtTime.Minute == 0 && dtTime.Second == 0)
                    {
                        e.Row.Cells[i + 1].Text = Convert.ToDateTime(drv[i]).ToString("yyyy-MM-dd");
                    }
                }
                else if (drv[i].GetType() != typeof(string))
                {
                    e.Row.Cells[i + 1].Text = ChangeDataFormat(e.Row.Cells[i + 1].Text);
                    e.Row.Cells[i + 1].CssClass = "fontForRight";
                    if (null == drv[i])
                    {
                        drv[i] = 0;
                    }

                    if (string.IsNullOrEmpty(listFootSum[i]))
                    {
                        listFootSum[i] = "";
                    }

                    if (
                        drv[i].GetType() == typeof(int) || drv[i].GetType() == typeof(float) ||
                        drv[i].GetType() == typeof(decimal) || drv[i].GetType() == typeof(double)
                        )
                    {
                        e.Row.Cells[i + 1].Text = ChangeDataFormat(e.Row.Cells[i + 1].Text);

                        if (listCalculateField.Contains(drv.Row.Table.Columns[i].ColumnName.Trim()))
                        {
                            if (string.IsNullOrEmpty(listFootSum[i]))
                            {
                                listFootSum[i] = "0";
                            }
                            double tmpValue = Convert.ToDouble(drv[i]) + Convert.ToDouble(listFootSum[i]);
                            listFootSum[i] = tmpValue.ToString();
                        }
                    }
                }

                if (
                    (e.Row.Cells[i].Text.Trim().StartsWith("-") && e.Row.Cells[i].Text.Trim().LastIndexOf("-") > 0)
                    ||
                    (e.Row.Cells[i].Text.Trim().StartsWith("0") && !e.Row.Cells[i].Text.Trim().StartsWith("0.") && e.Row.Cells[i].Text.Trim().Length > 3)
                   )
                {

                    e.Row.Cells[i].Text = "'" + e.Row.Cells[i].Text;
                }
                else if (e.Row.Cells[i].Text.Trim().StartsWith(@"\\") || e.Row.Cells[i].Text.Trim().ToLower().StartsWith(@"http:\\"))
                {
                    string strPath = e.Row.Cells[i].Text.Trim();
                    e.Row.Cells[i].Text = string.Format("<a href='{0}'>{1}</a>", strPath, strPath.Substring(strPath.LastIndexOf("\\") + 1));
                }

                #region 功能控制

                // 1. 首行重复项是否不显
                if (reportFuncCode != 1)
                {
                    if (i == 1)
                    {
                        if (UpRowData == e.Row.Cells[1].Text)
                        {
                            e.Row.Cells[1].Text = "";
                        }
                        else
                        {
                            UpRowData = e.Row.Cells[1].Text;
                        }
                    }

                }

                #endregion
            }

            needSetFormat = false;
        }
        else if (e.Row.RowType == DataControlRowType.Footer)
        {
            //if (isShowFoot)
            {
                TableCellCollection tcFoot = e.Row.Cells;
                tcFoot.Clear();

                tcFoot.Add(new TableHeaderCell());
                tcFoot[0].Text = "合计";
                tcFoot[0].CssClass = "strongFont";
                tcFoot[0].Attributes.Add("colspan", "2");

                //DataRowView drv = (DataRowView)e.Row.DataItem;
                //for (int i = 1; i < drv.Row.Table.Columns.Count; i++)
                //{
                //    tcFoot.Add(new TableHeaderCell());
                //    tcFoot[i].CssClass = "fontForRight";
                //    if (drv[i].GetType() == typeof(int) || drv[i].GetType() == typeof(decimal) ||
                //        drv[i].GetType() == typeof(float) || drv[i].GetType() == typeof(double))
                //    {
                //        tcFoot[i].Text = dsCurrent.Tables[0].Compute("SUM(" + drv.Row.Table.Columns[i].ColumnName + ")", drv.Row.Table.Columns[i].ColumnName + " is not null and " + drv.Row.Table.Columns[i].ColumnName + ">0").ToString();
                //    }
                //    else
                //    {
                //        tcFoot[i].Text = "";
                //    }
                //}

                for (int i = 1; i < listFootSum.Count; i++)
                {
                    tcFoot.Add(new TableHeaderCell());
                    tcFoot[i].Text = listFootSum[i];
                    tcFoot[i].CssClass = "fontForRight";
                    tcFoot[i].Text = ChangeDataFormat(tcFoot[i].Text);
                }
            }
        }
    }

    private string ChangeDataFormat(string tmpValue)
    {
        if (string.IsNullOrEmpty(tmpValue) || tmpValue.Contains("&") || tmpValue.Contains(";"))
        {
            return tmpValue;
        }
        string strReturn = "";



        if (tmpValue.Contains("."))
        {
            string[] strList = tmpValue.Split('.');
            if (strList[0].Length == 0)
            {
                strList[0] = "0";

            }
            else if (strList[0].StartsWith("-"))
            {
                if (strList[0].Length == 1 || (Convert.ToDouble(strList[0]) == 0))
                {
                    strList[0] = "0";
                    strReturn = "-";
                }
            }
            strReturn += Convert.ToDouble(strList[0]).ToString("N0") + "." + strList[1];
        }
        else
        {
            strReturn = Convert.ToDouble(tmpValue).ToString("N0");
        }



        return strReturn;
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;

        showData(strCommandForReal, false);
    }
}
