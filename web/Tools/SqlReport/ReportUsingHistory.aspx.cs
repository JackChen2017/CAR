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


public partial class Tools_SQLReport_ReportUsingHistory : FounderTecInfoSys.Common.PageBase.DomainMasterPage
{
    private int ReportID
    {
        get
        {
            return (int)ViewState["ReportID"];
        }
        set
        {
            ViewState["ReportID"] = value;
        }
    }

    private bool isDetail
    {
        set
        {
            ViewState["isDetail"] = value;
        }
        get
        {
            if (null == ViewState["isDetail"])
            {
                ViewState["isDetail"] = false;
            }
            return (bool)ViewState["isDetail"];
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (string.IsNullOrEmpty(Request.QueryString["ID"]))
            {
                FounderTecInfoSys.Common.PageGeneralAction.GoBackShowWarmingWindow("报表未找到或已经被删除");
                Response.End();
            }

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

            ReportID = Convert.ToInt32(Request.QueryString["ID"]);
            sumDataBinding();
        }
    }


    private void sumDataBinding()
    {
        GridView1.DataSource = new SQLReportUsingHistoryViewTableAdapter().GetSumDataByReportID(ReportID);
        GridView1.DataBind();
    }

    private void detailDataBinding()
    {
        GridView1.DataSource = new SQLReportUsingHistoryViewTableAdapter().GetDetailDataByReportID(ReportID);
        GridView1.DataBind();
    }

    protected void linkButtonDetailInfo_Click(object sender, EventArgs e)
    {
        isDetail = true;

        linkButtonDetailInfo.Enabled = false;
        linkButtonSumInfo.Enabled = true;
        LinkButtonPersonSumInfo.Enabled = true;

        GridView1.PageIndex = 0;
        GridView1.Visible = true;
        divSpan.Visible = false;

        detailDataBinding();
    }
    protected void linkButtonSumInfo_Click(object sender, EventArgs e)
    {
        isDetail = false;

        linkButtonDetailInfo.Enabled = true;
        linkButtonSumInfo.Enabled = false;
        LinkButtonPersonSumInfo.Enabled = true;

        GridView1.PageIndex = 0;
        GridView1.Visible = true;
        divSpan.Visible = false;
        sumDataBinding();
    }
    protected void LinkButtonPersonSumInfo_Click(object sender, EventArgs e)
    {
        GridView2.PageIndex = 0;

        linkButtonDetailInfo.Enabled = true;
        linkButtonSumInfo.Enabled = true;
        LinkButtonPersonSumInfo.Enabled = false;

        GridView1.Visible = false;
        divSpan.Visible = true;
        
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridView1.Visible = false;
        divSpan.Visible = true;
        if (DropDownList1.SelectedIndex > 0)
        {
            textBoxUserName.Text = DropDownList1.SelectedItem.Text;
        }
    }
    protected void buttonSearch_Click(object sender, EventArgs e)
    {
        string strUserName = textBoxUserName.Text.Trim().ToLower();
        if (!strUserName.Contains("\\") || !strUserName.StartsWith("founderpcb\\"))
        {
            strUserName = "founderpcb\\" + strUserName;
            textBoxUserName.Text = strUserName;
        }
        for (int i = 0; i < DropDownList1.Items.Count; i++)
        {
            ListItem item = DropDownList1.Items[i];
            item.Selected = false;
            if (
                strUserName.Equals(item.Text.Trim().ToLower()) ||
                strUserName.Equals(item.Value.Trim().ToLower()) ||
                item.Text.TrimEnd().ToLower().EndsWith(strUserName) || 
                item.Value.TrimEnd().ToLower().EndsWith(strUserName)
               )
            {
                item.Selected = true;
                textBoxUserName.Text = item.Text;
                break;
            }
        }
    }
    protected void DropDownList1_DataBound(object sender, EventArgs e)
    {
        if (!DropDownList1.Items[0].Text.Equals("请选择用户"))
        {
            DropDownList1.Items.Insert(0, new ListItem("请选择用户"));
        }
    }
    protected void DropDownList1_DataBinding(object sender, EventArgs e)
    {
        

    }
    protected void LinkButtonShowReportInfo_Click(object sender, EventArgs e)
    {
        Response.Redirect("ReportInfo.aspx", true);
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        if (isDetail)
        {
            detailDataBinding();
        }
        else
        {
            sumDataBinding();
        }
    }
    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView2.PageIndex = e.NewPageIndex;
    }
    protected void buttonToExcel_Click(object sender, EventArgs e)
    {
        Response.Charset = "UTF-7";
        Response.Buffer = true;
        Response.ContentEncoding = System.Text.Encoding.Default;
        Response.ContentType = "application/ms-excel";
        Response.AddHeader("content-disposition:attachment", "inline;filename=" + HttpUtility.UrlEncode(dropDownListFactory.SelectedItem.Text + "报表使用情况统计" + ".xls"));

        divToolBarTop.Visible = false;

        if (divSpan.Visible)
        {
            divToolBar.Visible = false;
            GridView2.AllowPaging = false;
            GridView2.AllowSorting = false;
            sumDataBinding();
        }
        else if (GridView1.Visible)
        {
            GridView1.AllowPaging = false;
            GridView1.AllowSorting = false;
            detailDataBinding();
        }
        

    }
}
