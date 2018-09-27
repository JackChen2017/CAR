using System;
using System.Data;
using System.Text;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.DirectoryServices;
using System.Collections;
using System.Text.RegularExpressions;



/// <summary>
/// DomainUser 的摘要说明
/// </summary>
public class DomainUser
{
    public DomainUser()
    {
 
    }
    public static string GetUserCompany(string LoginName)
    {
        return GetCurrentUserProperty(LoginName, "Company");
    }

    public static string GetUserDepartment(string LoginName)
    {
        return GetCurrentUserProperty(LoginName, "Department");
    }

    public static string GetCurrentUserName(string LoginName)
    {
        return GetCurrentUserProperty(LoginName, "Name");
    }

    public static string GetCurrentUserEName(string CName)
    {
        return GetCurrentUserEnameProperty(CName, "samaccountname");//samaccountname
    }

    public static string GetCurrentUserProperty(string LoginName, string UserPropertyName)
    {
        if (string.IsNullOrEmpty(LoginName) || string.IsNullOrEmpty(UserPropertyName))
        {
            return string.Empty;
        }
        
        string strReturn = "";
        System.DirectoryServices.DirectoryEntry entry = new System.DirectoryServices.DirectoryEntry(ConfigurationManager.AppSettings["DomainName"].ToString(), ConfigurationManager.AppSettings["NameOfLoginAD"].ToString(), ConfigurationManager.AppSettings["PWDofLoginAD"].ToString());
        try
        {

            if (LoginName.IndexOf("\\") > 0)
            {
                LoginName = LoginName.Substring(LoginName.IndexOf("\\") + 1);
            }
            System.DirectoryServices.DirectorySearcher mySearcher = new System.DirectoryServices.DirectorySearcher(entry);
            //mySearcher.Filter = ("(&(objectClass=User)(cn=" + LoginName + "))");//filte the objectClass type
            mySearcher.Filter = ("(samaccountname=" + LoginName + ")");//filte the objectClass type
            foreach (System.DirectoryServices.SearchResult resEnt in mySearcher.FindAll())
            {
                System.DirectoryServices.DirectoryEntry de = resEnt.GetDirectoryEntry();

                if (null != de.Properties[UserPropertyName].Value)
                {
                    strReturn = de.Properties[UserPropertyName].Value.ToString();
                    break;
                }
            }
        }
        catch (Exception)
        {
        }
        finally
        {
            entry.Close();
        }
        return strReturn;
    }

    public static string GetCurrentUserEnameProperty(string LoginName, string UserPropertyName)
    {
        if (string.IsNullOrEmpty(LoginName) || string.IsNullOrEmpty(UserPropertyName))
        {
            return string.Empty;
        }

        string strReturn = "";
        System.DirectoryServices.DirectoryEntry entry = new System.DirectoryServices.DirectoryEntry(ConfigurationManager.AppSettings["DomainName"].ToString(), ConfigurationManager.AppSettings["NameOfLoginAD"].ToString(), ConfigurationManager.AppSettings["PWDofLoginAD"].ToString());
        try
        {

            if (LoginName.IndexOf("\\") > 0)
            {
                LoginName = LoginName.Substring(LoginName.IndexOf("\\") + 1);
            }
            System.DirectoryServices.DirectorySearcher mySearcher = new System.DirectoryServices.DirectorySearcher(entry);
            //mySearcher.Filter = ("(&(objectClass=User)(cn=" + LoginName + "))");//filte the objectClass type
            mySearcher.Filter = ("(Name=" + LoginName + ")");//filte the objectClass type
            foreach (System.DirectoryServices.SearchResult resEnt in mySearcher.FindAll())
            {
                System.DirectoryServices.DirectoryEntry de = resEnt.GetDirectoryEntry();

                if (null != de.Properties[UserPropertyName].Value)
                {
                    strReturn = @"founderpcb\" +  de.Properties[UserPropertyName].Value.ToString();
                    break;
                }
            }
        }
        catch (Exception)
        {
        }
        finally
        {
            entry.Close();
        }
        return strReturn;
    }

    #region 生成AD的树形控件

    public static TreeNode GenDomainUserTreeControl()
    {
        //TreeView treeViewDomain = new TreeView();
        TreeNode root = new TreeNode();
        DirectoryEntry rootEntry = new DirectoryEntry(ConfigurationManager.AppSettings["DomainName"].ToString(), ConfigurationManager.AppSettings["NameOfLoginAD"].ToString(), ConfigurationManager.AppSettings["PWDofLoginAD"].ToString());
        try
        {
            if (null != rootEntry)
            {
                root = new TreeNode(rootEntry.Properties["Name"].Value.ToString());
                root.NavigateUrl = "javascript:void(0);";
                foreach (DirectoryEntry subEntry in rootEntry.Children)
                {
                    if (subEntry.SchemaClassName.Equals("organizationalUnit"))
                    {
                        TreeNode subNode = new TreeNode(subEntry.Properties["Name"].Value.ToString());
                        subNode = retrieveNode(subNode, subEntry.Children);
                        subNode.NavigateUrl = "javascript:void(0);";
                        if (subNode.ChildNodes.Count > 0)
                        {
                            root.ChildNodes.Add(subNode);
                        }
                    }
                }

                //treeViewDomain.Nodes.Add(root);
            }

            //return treeViewDomain;        
        }
        catch (Exception)
        {
        }
        finally
        {
            rootEntry.Close();
        }
        //DirectoryEntry rootEntry = new DirectoryEntry("LDAP://DC=founderpcb,DC=com", ConfigurationManager.AppSettings["NameOfLoginAD"].ToString(), ConfigurationManager.AppSettings["PWDofLoginAD"].ToString());

        return root;
    }

    private static TreeNode retrieveNode(TreeNode parentNode, DirectoryEntries childDir)
    { 
        foreach (DirectoryEntry subEntry in childDir)
        {
            if (subEntry.Properties["Name"].Value.ToString().Equals("群组"))
            {
                int i=1;
            }
            switch (subEntry.SchemaClassName)
            {
                case "user":
                    parentNode.ChildNodes.Add(new TreeNode(subEntry.Properties["Name"].Value.ToString(), @"founderpcb\" + subEntry.Properties["sAmAccountName"].Value.ToString(), "", "javascript:void(0);", "_self"));
                    break;
                case "group":
                case "organizationalUnit":
                    TreeNode newNode = new TreeNode(subEntry.Properties["Name"].Value.ToString(), @"[" + subEntry.Properties["Name"].Value.ToString());
                    newNode.NavigateUrl = "javascript:void(0);";
                    newNode = retrieveNode(newNode, subEntry.Children);
                    //if (newNode.ChildNodes.Count > 0)
                    {
                        parentNode.ChildNodes.Add(newNode);
                    }
                    break;
            }
        }

        return parentNode;
    }

    #endregion

    #region 给一个域组，得到该域组中的所有用户清单
  
    public static string GetGroupUsers(string GroupName)
    {
        DirectoryEntry rootEntry = GetDirectoryEntryOfGroup(GroupName.Substring(1));
        string strUserlist = "";
        string strTemplist = "";

        foreach (Object member in (IEnumerable)rootEntry.Invoke("Members"))
        {
            System.DirectoryServices.DirectoryEntry dirmem = new System.DirectoryServices.DirectoryEntry(member);

            strTemplist = dirmem.Properties["sAMAccountName"].Value.ToString();

            if (dirmem.SchemaClassName.ToString() != "user")
            {
                strUserlist = strUserlist + GetGroupUsers("[" + strTemplist);                

            }
            else
            {
                strUserlist = strUserlist + @"founderpcb\" + strTemplist + ",";
            }

        }

        return strUserlist;

    }

    public static string GetGroupEmail(string GroupName)
    {
        DirectoryEntry rootEntry = GetDirectoryEntryOfGroup(GroupName.Substring(1));

        string strUserlist = rootEntry.Properties["mail"].Value.ToString();

        strUserlist = @"founderpcb\" + strUserlist.Substring(0, strUserlist.IndexOf("@")) + ",";

        return strUserlist;

    }

    public static bool IsChineseWords(string strGroup)
    {
        return Regex.IsMatch(strGroup, @"[\u4e00-\u9fa5]");
    }



    public static DirectoryEntry GetDirectoryEntryOfGroup(string groupName)
    {
        DirectoryEntry de = new DirectoryEntry(ConfigurationManager.AppSettings["DomainName"].ToString(), ConfigurationManager.AppSettings["NameOfLoginAD"].ToString(), ConfigurationManager.AppSettings["PWDofLoginAD"].ToString());

        DirectorySearcher deSearch = new DirectorySearcher(de);

        deSearch.Filter = "(&(objectClass=group)(cn=" + groupName + "))";

        deSearch.SearchScope = SearchScope.Subtree;

        try
        {

            SearchResult result = deSearch.FindOne();

            de = new DirectoryEntry(result.Path);

            return de;

        }

        catch
        {

            return null;

        }

    }
    #endregion

}
