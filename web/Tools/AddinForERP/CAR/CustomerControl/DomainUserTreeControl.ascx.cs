using System;
using System.Text;
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

public partial class CustomerControl_DomainUserTreeControl : System.Web.UI.UserControl
{

    public string GetUserList
    {
        get
        {
            return retreiveTree(tvDomain.Nodes);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            try
            {
                tvDomain.Nodes.Add(((TreeNode)Application["DomainTreeControl"]));
                //tvDomain.Nodes.Add(((TreeView)Application["DomainTreeControl"]));
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('程序出现异常，请关闭当前窗口再试! <br/> 详细错误如下：" + ex.Message +  "');window.close();</script>");
            }
        }
    }

    private string retreiveTree(TreeNodeCollection nodeCollection)
    {
        StringBuilder sbReturnValue = new StringBuilder();
        StringBuilder sbReturnName = new StringBuilder();
        foreach (TreeNode subNode in nodeCollection)
        {
            if (subNode.Checked)
            {
                sbReturnName.AppendFormat("{0},", subNode.Text);
                sbReturnValue.AppendFormat("{0},", subNode.Value);
            }
            else if (subNode.ChildNodes.Count > 0)
            {
                string strReturn = retreiveTree(subNode.ChildNodes);
                if (!strReturn.Trim().Equals(string.Empty))
                {
                    string[] strList = strReturn.Split('*');

                    sbReturnName.AppendFormat("{0}", strList[0]);
                    sbReturnValue.AppendFormat("{0}", strList[1]);
                }
            }
        }

        //sbReturnName = sbReturnName.Remove(sbReturnName.Length - 1, 1);
        //sbReturnValue = sbReturnValue.Remove(sbReturnValue.Length - 1, 1);

        return sbReturnName.ToString() + "*" + sbReturnValue.ToString();

    }

}