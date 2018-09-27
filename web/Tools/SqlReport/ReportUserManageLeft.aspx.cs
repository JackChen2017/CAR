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

public partial class Tools_SQLReport_ReportUserManageLeft : FounderTecInfoSys.Common.PageBase.DomainMasterPage
{
    private string URLString = "ReportUserManage.aspx?UID=";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int facotryID = 1;
            if (CurrentUser.FactoryIDList.Count > 0 && CurrentUser.HasFactoryAdminRole())
            {
                facotryID = CurrentUser.FactoryIDList[CurrentUser.UseTypeList.IndexOf(1)];
            }
            if (!string.IsNullOrEmpty(Request.QueryString["FID"]))
            {
                facotryID = Convert.ToInt32(Request.QueryString["FID"]);
            }

            TreeView1.Nodes.Clear();
            DataSet ds = new DataSet();

            ds.ReadXml(Server.MapPath("..") + "\\ERPReportFactory.xml");
            int tmpCount = 0;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (CurrentUser.RightIsAdmin || CurrentUser.FactoryIDList.Contains(Convert.ToInt32(dr["Value"])))
                {
                    MenuItem item = new MenuItem();
                    item.Text = dr["Name"].ToString();
                    item.NavigateUrl = "ReportUserManageLeft.aspx?FID=" + dr["Value"].ToString();
                    item.ToolTip = "展开 [" + dr["Name"].ToString() + "] 用户列表";
                    item.Value = dr["Value"].ToString();
                    if (facotryID.ToString().Equals(dr["Value"].ToString()))
                    {
                        item.Selected = true;
                    }
                    if (tmpCount++ > 3)
                    {
                        Menu2.Items.Add(item);
                    }
                    else
                    {
                        Menu1.Items.Add(item);
                    }
                }
            }

            if (Menu1.Items.Count > 0)
            {


                Menu1.Attributes.Add("onclick", "parent.document.frames.masterFrame.document.location='ReportUserManage.aspx';");
                Menu2.Attributes.Add("onclick", "parent.document.frames.masterFrame.document.location='ReportUserManage.aspx';");



                ds = new DataSet();
                ds.ReadXml(Server.MapPath("..") + "\\ERPReportCate.xml");
                List<string> curList = new List<string>();

                foreach (DataRow dr in ds.Tables[0].Select("Factory=0 or Factory=" + facotryID.ToString()))
                {
                    TreeNode curNode = new TreeNode();
                    curNode.Text = dr["Name"].ToString();
                    curNode.Value = dr["Value"].ToString();
                    curNode.SelectAction = TreeNodeSelectAction.Expand;

                    curList.Add(curNode.Value);

                    TreeView1.Nodes.Add(curNode);
                }

                SQLReportUserRightViewTableAdapter sqlAdapter = new SQLReportUserRightViewTableAdapter();


                InfoSysEntity.SQLReportUserRightViewDataTable curTable = sqlAdapter.GetDataByFactoryID(facotryID);
                foreach (InfoSysEntity.SQLReportUserRightViewRow curRow in curTable.Rows)
                {

                    TreeNode curNode = new TreeNode();
                    curNode.Text = curRow.LoginUserRealName + " (" + curRow.LoginUser + ")";
                    curNode.Value = curRow.SQLReportUserRightID.ToString();
                    curNode.ToolTip = curNode.Text;
                    curNode.Target = "masterFrame";
                    curNode.NavigateUrl = URLString + curNode.Value;

                    if (curList.IndexOf(curRow.DepartmentID.ToString()) >= 0)
                    {
                        TreeView1.Nodes[curList.IndexOf(curRow.DepartmentID.ToString())].ChildNodes.Add(curNode);
                    }
                }

                TreeView1.CollapseAll();
            }
        }
    }
}
