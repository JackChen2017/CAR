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

public partial class Tools_SQLReport_ReportInfo : FounderTecInfoSys.Common.PageBase.DomainMasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           
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

            #endregion


            ds = new DataSet();
            ds.ReadXml(Server.MapPath("..") + "\\ERPReportCate.xml");

            #region 部门数据绑定

            DataTable dtTmp = ds.Tables[0].Copy();
            dtTmp.Rows.Clear();
            foreach (DataRow dr in ds.Tables[0].Select("Factory=" + dropDownListFactory.SelectedValue))
            {

                dtTmp.Rows.Add(dr.ItemArray);
            }


            DropDownListDeparment.DataSource = dtTmp;
            DropDownListDeparment.DataTextField = "Name";
            DropDownListDeparment.DataValueField = "Value";
            DropDownListDeparment.DataBind();
            #endregion


        }
    }
    protected void dropDownListFactory_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void gridViewReportList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gridViewReportList.PageIndex = e.NewPageIndex;
    }
    protected void DropDownListType_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void buttonToExcel_Click(object sender, EventArgs e)
    {
        Response.Charset = "UTF-7";
        Response.Buffer = true;
        Response.ContentEncoding = System.Text.Encoding.Default;
        Response.ContentType = "application/ms-excel";
        Response.AddHeader("content-disposition:attachment", "inline;filename=" + HttpUtility.UrlEncode(dropDownListFactory.SelectedItem.Text + "报表使用情况统计" + ".xls"));

        divToolBar.Visible = false;
        gridViewReportList.AllowPaging = false;
        gridViewReportList.AllowSorting = false;
        //gridViewReportList.DataBind();

        //FounderTecInfoSys.Common.CommonFunction.OutputFunction.ToExecl(gridViewReportList, dropDownListFactory.SelectedItem.Text + "报表使用情况统计");

        //gridViewReportList.AllowPaging = true;
        //gridViewReportList.DataBind();
    }
}
