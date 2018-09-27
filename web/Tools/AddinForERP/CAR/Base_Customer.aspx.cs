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
using System.DirectoryServices;
using System.Data.SqlClient;
using System.Xml;
using WM.Utils;
using WM.Data;
using FounderTecInfoSys.Addin.CAR;
using FounderTecInfoSys.Addin.CAR.Model;
using FounderTecInfoSys.Addin.CAR.BLL;
public partial class Base_Customer : FounderTecInfoSys.Common.PageBase.DomainMasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }
    }

    protected void BindData()
    {
        int factoryID = 97;
        try
        {
            factoryID = int.Parse(Request.QueryString["FID"].ToString());
        }
        catch { }
        DataTable tb = new DataTable();
        CARDataBLL dataBll = new CARDataBLL(factoryID);
        string sql = "select rkey,cust_code,customer_name from data0010 where 1=1";
        if (textBox_Customer.Text.Trim() != "")
        {
            sql += " and cust_code like '%" + textBox_Customer.Text.Trim() + "%' or customer_name like '%" + textBox_Customer.Text.Trim() + "%'";
        }
        tb = dataBll.GetDataSet(sql);
        repeater_Customer.DataSource = tb;
        repeater_Customer.DataBind();
    }
    protected void btn_Button_Click(object sender, EventArgs e)
    {
        BindData();
    }
}
