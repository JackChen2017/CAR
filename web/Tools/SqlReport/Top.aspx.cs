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

public partial class Tools_SQLReport_Top : FounderTecInfoSys.Common.PageBase.DomainMasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        setNav();
    }


    private void setNav()
    {

        divToolBarForReportManage.Visible = false;
        divToolBarForUserManage.Visible = false;
        divToolBarForUsingHistory.Visible = false;



        if (CurrentUser.RightIsAdmin || CurrentUser.HasFactoryAdminRole())
        {
            divToolBarForReportManage.Visible = true;
            divToolBarForUserManage.Visible = true;
            divToolBarForUsingHistory.Visible = true;
        }
        else if(CurrentUser.HasAddinAdminRole())
        {
            divToolBarForUserManage.Visible = true;
        }
    }
}
