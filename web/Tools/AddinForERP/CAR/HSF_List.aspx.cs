﻿using System;
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

public partial class HSF_List : FounderTecInfoSys.Common.PageBase.DomainMasterPage 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Happen_Date_Start.Text = DateTime.Now.AddDays(-10).ToShortDateString();
            Happen_Date_End.Text = DateTime.Now.ToShortDateString();
            if (!HasRight(XmlSource.GetRightIndex("HSF")) || !HasRight(XmlSource.GetRightIndex("VIEW")))
            {
                Response.Write("<script>alert('你没有权限进入此页面!');</script>");
                Response.End();
            }
        }
    }
    protected void btn_search_Click(object sender, ImageClickEventArgs e)
    {
        string sql = @"select rkey,Serial_No,convert(char(10),Happen_Date,20) as Happen_Date,
                       convert(char(10),Required_date,20) as required_date,from_comp,car_comp,car_part_num,status,
                       HSF_Happen_Type from CAR_Table_Data01 where op_type=2 ";
        if (Happen_Date_Start.Text != "")
        {
            sql += " and datediff(d,Happen_Date,'" + Happen_Date_Start.Text + "') <= 0 ";
        }
        if (Happen_Date_End.Text != "")
        {
            sql += " and datediff(d,Happen_Date,'" + Happen_Date_End.Text + "') >= 0";
        }
        DataTable tb = new DataTable();
        CARDataBLL dataBll = new CARDataBLL(CurrentFactoryID);
        tb = dataBll.GetDataSet(sql);
        UltraWebGrid1.DataSource = tb;
        UltraWebGrid1.DataBind();
    }
    protected void UltraWebGrid1_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        switch (DataBinder.Eval(e.Data, "status").ToString())
        {
            case "0": e.Row.Cells[9].Value = "未提交审批"; break;
            case "1": e.Row.Cells[9].Value = "审批完成"; break;
            case "14": e.Row.Cells[9].Value = "审批拒绝"; break;
            default: e.Row.Cells[9].Value = "审批中"; break;
        }
        switch (DataBinder.Eval(e.Data, "HSF_Happen_Type").ToString())
        {
            case "1": e.Row.Cells[8].Value = "制品"; break;
            case "2": e.Row.Cells[8].Value = "制程"; break;
            case "3": e.Row.Cells[8].Value = "外包"; break;
            case "4": e.Row.Cells[8].Value = "原物料"; break;
            case "5": e.Row.Cells[8].Value = "其他"; break;
            default: e.Row.Cells[8].Value = ""; break;
        }
    }
}
