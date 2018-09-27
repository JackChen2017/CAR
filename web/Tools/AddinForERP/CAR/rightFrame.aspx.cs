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

public partial class rightFrame : FounderTecInfoSys.Common.PageBase.DomainMasterPage 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //for (int i = 0; i < TreeView1.Nodes.Count; i++)
            //{
            //    for (int j = 0; j < TreeView1.Nodes[i].ChildNodes.Count; j++)
            //    {
            //        TreeView1.Nodes[i].ChildNodes[j].NavigateUrl = TreeView1.Nodes[i].ChildNodes[j].NavigateUrl + "?FID=" + CurrentFactoryID.ToString();
            //    }
            //}
            foreach(TreeNode node in TreeView1.Nodes)
            {
                foreach (TreeNode childnode in node.ChildNodes)
                {
                    childnode.NavigateUrl = childnode.NavigateUrl + "?FID=" + CurrentFactoryID.ToString();
                }
            }
        }
    }
}
