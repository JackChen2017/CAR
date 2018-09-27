using System;
using System.Data;
using System.Text;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Tools_SQLReport_SearchCondition : FounderTecInfoSys.Common.PageBase.DomainMasterPage
{


    protected void Page_Load(object sender, EventArgs e)
    {
        if (null == Session["TableColumn"])
        {
            Response.Write("<script>alert('参数错误');window.close();</script>");
            Response.End();
        }
    }

    protected string HtmlFieldControl()
    {
        string valReturn = "";
        if (null != Session["TableColumn"])
        {
            List<string> listColumn = (List<string>)Session["TableColumn"];

            StringBuilder sbControlText = new StringBuilder();

            foreach (string str in listColumn)
            {
                sbControlText.AppendFormat("<option value=\"{0}\">{0}</option>", str);

            }
            valReturn = "<select name=\"searchField\">" + sbControlText.ToString() + "</select>";
        }

        return valReturn;
    }
}
