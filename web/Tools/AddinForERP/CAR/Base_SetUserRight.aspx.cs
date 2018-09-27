using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Text;
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

public partial class SetUserRight : FounderTecInfoSys.Common.PageBase.DomainMasterPage
{
    protected DataTable tb
    {
        get
        {
            if (ViewState["tb"] == null)
            {
                ViewState["tb"] = new DataTable();
            }
            return (DataTable)ViewState["tb"];
        }
        set
        {
            ViewState["tb"] = value;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!CurrentUser.RightIsAdmin)
            {
                Response.Clear();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('对不起，你没有权限访问此页面！');</script>");
                Response.End();
            }
            InitTable();
            InitWebElement();
        }
    }
    protected void InitTable()
    {
        if (!tb.Columns.Contains("index"))
        {
            tb.Columns.Add(new DataColumn("index", typeof(string)));
        }
        if (!tb.Columns.Contains("rightName"))
        {
            tb.Columns.Add(new DataColumn("rightName", typeof(string)));
        }
        if (!tb.Columns.Contains("hasRight"))
        {
            tb.Columns.Add(new DataColumn("hasRight", typeof(string)));
        }
        tb.Clear();
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(XmlSource.userRightFileName);

        XmlNode node = xmlDoc.SelectSingleNode("RightList");
        foreach (XmlNode childNode in node.ChildNodes)
        {
            DataRow row = tb.NewRow();
            row["rightName"] = childNode.Name;
            row["index"] = childNode.Attributes["index"].Value;
            row["hasRight"] = "0";

            tb.Rows.Add(row);
        }
        DataView dv = new DataView(tb);
        dv.Sort = "index";
        tb = dv.ToTable();
    }
    protected void InitWebElement()
    {
        btn_Update.Visible = false;
        tb_UserAD.Visible = false;

        #region 用户下拉列表
        InitDropDownList();
        ddl_UserAD.Items.FindByValue("-1").Selected = true;
        #endregion

        GridView1.DataSource = tb;
        GridView1.DataBind();
    }
    protected void InitDropDownList()
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(XmlSource.userConfigFileName);

        XmlNode node = xmlDoc.SelectSingleNode("UserConfig");
        ddl_UserAD.Items.Add(new ListItem("--", "-1"));
        DataTable tb_ddl = new DataTable();
        tb_ddl.Columns.Add(new DataColumn("value"));
        tb_ddl.Columns.Add(new DataColumn("text"));
        DataRow row_temp = tb_ddl.NewRow();
        row_temp["value"] = "-1";
        row_temp["text"] = " ";
        tb_ddl.Rows.Add(row_temp);
        for (int i = 0; i < node.ChildNodes.Count; i++)
        {
            DataRow row = tb_ddl.NewRow();
            row["value"] = i.ToString();
            row["text"] = node.ChildNodes[i].Attributes["UserAD"].Value;
            tb_ddl.Rows.Add(row);
        }
        DataView dv = new DataView(tb_ddl);
        dv.Sort = "text";
        tb_ddl = dv.ToTable();
        ddl_UserAD.DataValueField = "value";
        ddl_UserAD.DataTextField = "text";
        ddl_UserAD.DataSource = tb_ddl;
        ddl_UserAD.DataBind();
    }
    protected void BindData(string userAD)
    {
        string config = XmlSource.GetUserConfig(userAD);
        InitTable();
        for (int i = 1; i <= config.Length - 1; i++)
        { 
            DataRow[] rows = tb.Select("index="+i.ToString());
            foreach (DataRow row in rows)
            {
                row["hasRight"] = config.Substring(i, 1);
            }
        }

        GridView1.DataSource = tb;
        GridView1.DataBind();
    }
    protected void btn_Add_Click(object sender, EventArgs e)
    {
        btn_Add.Visible = false;
        btn_Update.Visible = true;
        btn_Delete.Visible = false;
        tb_UserAD.Visible = true;
        tb_UserAD.Text = "";
        ddl_UserAD.Visible = false;
        BindData("");
    }
    protected void btn_Update_Click(object sender, EventArgs e)
    {
        btn_Add.Visible = true;
        btn_Update.Visible = false;
        btn_Delete.Visible = true;
        ddl_UserAD.Visible = true;
        tb_UserAD.Visible = false;

        #region 用户下拉列表
        InitDropDownList();
        try
        {
            ddl_UserAD.SelectedItem.Selected = false;
        }
        catch { }
        ddl_UserAD.Items.FindByValue("-1").Selected = true;
        #endregion

        BindData("");
    }
    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        string userAD;
        if (tb_UserAD.Visible == true)
        {
            if (tb_UserAD.Text.Trim() == "" || !tb_UserAD.Text.ToLower().StartsWith("founderpcb\\"))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('域帐号格式有误!');</script>");
                return;
            }
            userAD = tb_UserAD.Text.Trim();
        }
        else
        {
            if (ddl_UserAD.SelectedValue == "-1")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('请选择用户!');</script>");
                return;
            }
            userAD = ddl_UserAD.SelectedItem.Text;
        }
        
        int count = int.Parse(((HiddenField)GridView1.Rows[GridView1.Rows.Count - 1].Cells[2].FindControl("hdf_Index")).Value);
        StringBuilder config = new StringBuilder();
        for (int i = 1; i <= count + 1; i++)
        {
            config.Append("0");
        }
        for (int j = 0; j < GridView1.Rows.Count; j++)
        {
            CheckBox cb = (CheckBox)GridView1.Rows[j].Cells[1].FindControl("ckb_Right");
            if (cb.Checked)
            {
                config.Remove(int.Parse(((HiddenField)GridView1.Rows[j].Cells[2].FindControl("hdf_Index")).Value), 1);
                config.Insert(int.Parse(((HiddenField)GridView1.Rows[j].Cells[2].FindControl("hdf_Index")).Value), "1");
            }
        }

        int a = XmlSource.SetUserConfig(userAD, config.ToString());
        if (a == -1)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('保存失败！');</script>");
        }
        else if (a == 0)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('保存成功！');</script>");
        }
    }
    protected void ddl_UserAD_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindData(ddl_UserAD.SelectedItem.Text);
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
            {
                CheckBox cb = (CheckBox)e.Row.Cells[1].FindControl("ckb_Right");
                if (DataBinder.Eval(e.Row.DataItem, "hasRight").ToString() == "1")
                {
                    cb.Checked = true;
                }
                else
                {
                    cb.Checked = false;
                }
            }
        }
        else if (e.Row.RowType == DataControlRowType.Footer)
        {
            if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
            {
                e.Row.Cells[0].Text = "全选/全不选";
            }
        }
    }
    protected void btn_Delete_Click(object sender, EventArgs e)
    {
        if (ddl_UserAD.SelectedValue == "-1")
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('请选择用户!');</script>");
            return;
        }

        int a = XmlSource.DeleteUserConfig(ddl_UserAD.SelectedItem.Text);
        if (a == -1)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('保存失败！');</script>");
        }
        else if (a == 0)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('保存成功！');</script>");

            #region 用户下拉列表
            InitDropDownList();
            try
            {
                ddl_UserAD.SelectedItem.Selected = false;
            }
            catch { }
            finally
            {
                ddl_UserAD.Items.FindByValue("-1").Selected = true;
                BindData("");
            }
            #endregion
        }
    }
}
