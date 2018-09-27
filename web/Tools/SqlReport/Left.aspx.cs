using System;
using System.Data;
using System.Collections.Generic;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using InfoSysEntityTableAdapters;

public partial class Tools_AddinForERP_Left : FounderTecInfoSys.Common.PageBase.DomainMasterPage
{
    private int SQLReportType = 1;

    private const string URLStringForShowReport = "ShowSql.aspx?ID={0}&FID={1}";
    private const string URLStringForManageReport = "InputAddinForm.aspx?ID=";
    private const string URLStringForOtherPlatform = "Redirect.aspx?ID={0}&FID={1}";
    private const string URLStringForReportUsingHistory = "../Sqlreport/ReportUsingHistory.aspx?ID=";

    private List<string> factoryList
    {
        set
        {
            ViewState["factoryList"] = value;
        }

        get
        {
            if (null == ViewState["factoryList"])
            {
                ViewState["factoryList"] = new List<string>();
            }
            return (List<string>)ViewState["factoryList"];
        }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int factoryID = 1;

            if (!string.IsNullOrEmpty(Request.QueryString["FID"]))
            {
                factoryID = Convert.ToInt32(Request.QueryString["FID"]);
            }
            else
            {
                if (CurrentUser.FactoryIDList.Count > 0 && CurrentUser.HasFactoryAdminRole())
                {
                    factoryID = CurrentUser.FactoryIDList[CurrentUser.UseTypeList.IndexOf(1)];
                    Response.Redirect("Left.aspx?FID=" + factoryID.ToString());
                    return;
                }
            }

            string strType = "";
            if (!string.IsNullOrEmpty(Request.QueryString["Type"]))
            {
                strType = Request.QueryString["Type"];
            }




            TreeView1.Nodes.Clear();
            DataSet ds = new DataSet();

            #region 工厂菜单


            ds.ReadXml(Server.MapPath("..") + "\\ERPReportFactory.xml");
            int tmpCount = 0;
            bool realFactory = false;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                MenuItem item = new MenuItem();
                item.Text = dr["Name"].ToString();
                item.NavigateUrl = "Left.aspx?Type=" + strType + "&FID=" + dr["Value"].ToString();
                item.ToolTip = "展开 [" + dr["Name"].ToString() + "] 报表列表";
                item.Value = dr["Value"].ToString();

                if (CurrentUser.RightIsAdmin || CurrentUser.FactoryIDList.Contains(Convert.ToInt32(item.Value)))
                {
                    if (factoryID.ToString().Equals(dr["Value"].ToString()))
                    {
                        realFactory = true;
                        item.Selected = true;
                    }

                    /***2009-3-4 袁明胜修改  start******/
                    ///增加了,Menu3

                    tmpCount++;
                    if (tmpCount > 6)
                    {
                        Menu3.Items.Add(item);
                    }
                    else if (tmpCount > 3)
                    {
                        Menu2.Items.Add(item);
                    }
                    else
                    {
                        Menu1.Items.Add(item);
                    }

                    /********** end *************/
                }

            }
            if (!realFactory)
            {
                if (CurrentUser.FactoryIDList.Count > 0)
                {
                    factoryID = CurrentUser.FactoryIDList[0];
                }
                else
                {
                    FounderTecInfoSys.Common.PageGeneralAction.ShowWarmingWindow("您没有权限访问此页面");
                    return;
                }
            }


            #endregion

            if (strType.Equals("2"))
            {
                Menu1.Attributes.Add("onclick", "parent.document.frames.masterFrame.document.location='InputAddinForm.aspx';");
                Menu2.Attributes.Add("onclick", "parent.document.frames.masterFrame.document.location='InputAddinForm.aspx';");
            }
            else
            {
                if (!strType.Equals("3"))
                {
                    #region 返回 [报表平台]

                    MenuItem itemTmp = new MenuItem();
                    itemTmp.Text = "返回[报表平台]";
                    itemTmp.NavigateUrl = "../SQLReport";
                    itemTmp.Target = "_top";
                    itemTmp.ToolTip = "查看报表 ";

                    /***2009-3-4 袁明胜修改  start******/
                    ///增加了,Menu3
                    if (tmpCount >= 6)
                    {
                        Menu3.Items.Add(itemTmp);
                    }
                    else if (tmpCount >= 3)
                    {
                        Menu2.Items.Add(itemTmp);
                    }
                    else
                    {
                        Menu1.Items.Add(itemTmp);
                    }
                    /**************** end ********************/
                    #endregion
                }

                Menu1.Attributes.Add("onclick", "parent.document.frames.masterFrame.document.location='about:blank';");
                Menu2.Attributes.Add("onclick", "parent.document.frames.masterFrame.document.location='about:blank';");
            }
            #region 部门列表
            ds = new DataSet();
            ds.ReadXml(Server.MapPath("..") + "\\ERPReportCate.xml");

            List<string> curList = new List<string>();
            
            foreach (DataRow dr in ds.Tables[0].Select("Factory=" + factoryID.ToString()))
            {

                TreeNode curNode = new TreeNode();
                curNode.Text = dr["Name"].ToString();
                curNode.Value = dr["Value"].ToString();
                
                
                curNode.SelectAction = TreeNodeSelectAction.Expand;

                //if (isAdmin || (null != rightRow && rightRow.DepartmentList.Contains(curNode.Value + ",")))
                //{
                //    curList.Add(curNode.Value);
                //    TreeView1.Nodes.Add(curNode);
                //}

                curList.Add(curNode.Value);
                TreeView1.Nodes.Add(curNode);

            }

            #endregion

           

            SQLReportNameListTableAdapter sqlAdapter = new SQLReportNameListTableAdapter();
            InfoSysEntity.SQLReportNameListDataTable curTable;

            if (CurrentUser.RightIsAdmin || CurrentUser.RightIsCurrentFactoryAdmin)
            {

                curTable = sqlAdapter.GetDataByFactoryID(factoryID, SQLReportType);
            }
            else
            {
                if (CurrentUser.FactoryIDList.Contains(factoryID) && (CurrentUser.FullRightList[CurrentUser.FactoryIDList.IndexOf(factoryID)].Length > 0))
                {
                    curTable = sqlAdapter.GetDataByIDList(factoryID, CurrentUser.FullRightList[CurrentUser.FactoryIDList.IndexOf(factoryID)], SQLReportType);
                }
                else
                {
                    curTable = new InfoSysEntity.SQLReportNameListDataTable();
                }
            }

            foreach (InfoSysEntity.SQLReportNameListRow curRow in curTable.Rows)
            {
                
                TreeNode curNode = new TreeNode();
                curNode.Text = curRow.SQLReportName;
                if (curRow.SQLReportStatus.ToString().Trim().Equals("1"))
                {
                    curNode.Text = "[已停用] - " + curNode.Text;
                }
                curNode.Value = curRow.SQLReportID.ToString();
                curNode.ToolTip = curRow.SQLReportName;
                curNode.Target = "masterFrame";
                
                if (string.IsNullOrEmpty(Request.QueryString["Type"]) || Request.QueryString["Type"].Equals("1"))
                {
                    if (curRow.SQLReportShowURL.Trim().Equals(""))
                    {
                        break;
                    }
                    else
                    {
                        curNode.NavigateUrl = string.Format(URLStringForOtherPlatform, curNode.Value, factoryID.ToString());
                    }
                }
                else if(Request.QueryString["Type"].Equals("2"))
                {
                    curNode.NavigateUrl = URLStringForManageReport + curNode.Value;
                }
                else if (Request.QueryString["Type"].Equals("3"))
                {
                    curNode.NavigateUrl = URLStringForReportUsingHistory + curNode.Value;
                }

               

                if (curList.Contains(curRow.SQLReportCate.ToString()))
                {
                    TreeView1.Nodes[curList.IndexOf(curRow.SQLReportCate.ToString())].ChildNodes.Add(curNode);
                }
                else
                {
                    int iIndex = FounderTecInfoSys.Common.CommonFunction.FuncForString.GetListIndex(curList, curRow.SQLReportBelongsTo);
                    if (iIndex >= 0)
                    {
                        TreeView1.Nodes[iIndex].ChildNodes.Add(curNode);
                    }
                }
            }

            for (int i = TreeView1.Nodes.Count - 1; i >= 0; i--)
            {
                TreeNode node = TreeView1.Nodes[i];
                if (node.ChildNodes.Count <= 0)
                {
                    TreeView1.Nodes.Remove(node);
                }
            }

            TreeView1.CollapseAll();
            if (TreeView1.Nodes.Count > 0)
            {
                TreeView1.Nodes[0].Expand();
            }
        }
    }
}
