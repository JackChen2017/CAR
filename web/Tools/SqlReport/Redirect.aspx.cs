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
using InfoSysEntityTableAdapters;

public partial class Tools_SQLReport_Redirect : FounderTecInfoSys.Common.PageBase.DomainMasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (CurrentFactoryID <= 0 || CurrentFunctionID <= 0)
            {
                FounderTecInfoSys.Common.PageGeneralAction.GoBackShowWarmingWindow("报表未找到或已经被删除");
                Response.End();
            }

            HasRight(1);

            string strURL = "about:blank";
            SQLReportTableAdapter sqlAdapter = new SQLReportTableAdapter();

            InfoSysEntity.SQLReportDataTable curTable = sqlAdapter.GetDataByID(CurrentUser.UserADAcount, Request.UserHostAddress, CurrentFunctionID);
            foreach (InfoSysEntity.SQLReportRow curRow in curTable.Rows)
            {
                strURL = curRow.SQLReportShowURL;
                if (strURL.Contains("?"))
                {
                    strURL += "&FID=" + curRow.SQLReportFactory.ToString() + "&ID=" + curRow.SQLReportID.ToString();
                }
                else
                {
                    strURL += "?FID=" + curRow.SQLReportFactory.ToString() + "&ID=" + curRow.SQLReportID.ToString();
                }
                break;
            }
            //Response.Redirect("http://pcbit-live01/ReportServer", false);
            Response.Redirect(strURL, true);

        }
    }

}
