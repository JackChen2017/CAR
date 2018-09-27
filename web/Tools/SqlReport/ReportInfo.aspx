<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReportInfo.aspx.cs" Inherits="Tools_SQLReport_ReportInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>报表信息列表</title>
<link href="../App_Themes/Default/CSS/gray.css" rel="stylesheet" type="text/css" />
<link href="../App_Themes/Default/CSS/Default.css" rel="stylesheet" type="text/css" />
<link  href="../App_Themes/Default/CSS/base.css" rel="stylesheet" type="text/css" />
<link  href="../App_Themes/Default/CSS/style1.css" rel="stylesheet" type="text/css" />    
<link  href="../App_Themes/Default/CSS/style2.css" rel="stylesheet" type="text/css" />      
</head>
<body>
    <form id="form1" runat="server">
        <div id="divToolBar" runat="server">
            <%--<a href="#" onclick="history.go(-1)">返回上一页</a>&nbsp;&nbsp;--%>
            <br />
            <asp:Label ID="Label1" runat="server" Text="报表使用情况统计" Font-Bold="True"></asp:Label>
            <hr />
            选择工厂:&nbsp;<asp:DropDownList ID="dropDownListFactory" runat="server" AutoPostBack="True"
                OnSelectedIndexChanged="dropDownListFactory_SelectedIndexChanged" ToolTip="选择工厂">
            </asp:DropDownList>
            <asp:DropDownList ID="DropDownListDeparment" Visible="false" runat="server">
            </asp:DropDownList>
            <asp:DropDownList ID="DropDownListType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownListType_SelectedIndexChanged">
                <asp:ListItem Value="0">报表</asp:ListItem>
                <asp:ListItem Value="1">辅助系统</asp:ListItem>
            </asp:DropDownList>
            <asp:Button ID="buttonToExcel" runat="server" Text="导出至Excel" OnClick="buttonToExcel_Click" />
        </div>
        <asp:GridView ID="gridViewReportList" Width="100%" runat="server" AutoGenerateColumns="False"
            DataSourceID="sqlDataSourceForReportList" AllowSorting="True" AllowPaging="True"
            CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanging="gridViewReportList_PageIndexChanging"
            EmptyDataText="无数据" PageSize="18">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <%# Container.DataItemIndex + 1 %>
                    </ItemTemplate>
                    <ItemStyle Width="20px" />
                </asp:TemplateField>
                <asp:BoundField DataField="SQLReportTypeName" HeaderText="类型" SortExpression="SQLReportName" />
                <asp:BoundField DataField="SQLReportName" HeaderText="名称" SortExpression="SQLReportName" />
                <asp:TemplateField HeaderText="所属部门" SortExpression="SQLReportCate">
                    <ItemTemplate>
                        <%# DropDownListDeparment.Items.FindByValue(Eval("SQLReportCate").ToString()) == null ? "" : DropDownListDeparment.Items.FindByValue(Eval("SQLReportCate").ToString()).Text %>
                    </ItemTemplate>
                    <ItemStyle Width="100px" />
                </asp:TemplateField>
                <asp:BoundField DataField="HitCount" HeaderText="总使用次数" SortExpression="HitCount">
                    <ItemStyle Width="80px" />
                </asp:BoundField>
            </Columns>
            <PagerTemplate>
                <span style="color: #3366ff">当前页:</span><asp:Label ID="LabelCurrentPage" runat="server"
                    Text="<%# ((GridView)Container.NamingContainer).PageIndex + 1 %>" ForeColor="Red"></asp:Label>&nbsp;/&nbsp;<asp:Label
                        ID="LabelPageCount" runat="server" Text="<%# ((GridView)Container.NamingContainer).PageCount %>"
                        ForeColor="Red"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp; [
                <asp:LinkButton ID="LinkButtonFirstPage" ToolTip="点击稍候显示首页" runat="server" CommandArgument="First"
                    CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>">首页</asp:LinkButton>
                <asp:LinkButton ID="LinkButtonPreviousPage" runat="server" CommandArgument="Prev"
                    CommandName="Page" ToolTip="点击稍候显示上一页" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>">上一页</asp:LinkButton>
                <asp:LinkButton ID="LinkButtonNextPage" runat="server" ToolTip="点击稍候显示下一页" CommandArgument="Next"
                    CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>">下一页</asp:LinkButton>
                <asp:LinkButton ID="LinkButtonLastPage" runat="server" ToolTip="点击稍候显示最后一页" CommandArgument="Last"
                    CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>">尾页</asp:LinkButton>
                ]
                <%--&nbsp;&nbsp;&nbsp;&nbsp;<input id="textPageNumber" title="指定将要跳转的页码" onkeypress="return (/[\d]/.test(String.fromCharCode(event.keyCode)))" style=" border-width:thin; height:17px; width:40px; ime-mode:Disabled" maxlength="4"  />
                            <input id="ButtonPageChange" type="button" value="跳转" style=" height:17px;" title="跳转到指定页" onclick="javascript:var page=document.getElementById('textPageNumber').value;javascript:__doPostBack('GridView1','Page$'+page);" />--%>
            </PagerTemplate>
            <PagerStyle BackColor="#C0C0FF" ForeColor="White" HorizontalAlign="Left" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#5D7B9D" HorizontalAlign="Left" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#999999" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <EmptyDataRowStyle BackColor="#FFE0C0" BorderColor="#80FFFF" />
        </asp:GridView>
        <asp:SqlDataSource ID="sqlDataSourceForReportList" runat="server" ConnectionString="<%$ ConnectionStrings:FIDataConnectionString %>"
            SelectCommand="SELECT SQLReportName, SQLReportCate, HitCount, CASE SQLReportType WHEN 0 THEN '报表' WHEN 1 THEN '辅助系统' END AS SQLReportTypeName FROM SQLReportNameList WHERE (SQLReportFactory = @SQLReportFactory) AND (SQLReportType = @SQLReportType) ORDER BY SQLReportType, HitCount DESC">
            <SelectParameters>
                <asp:ControlParameter ControlID="dropDownListFactory" Name="SQLReportFactory" PropertyName="SelectedValue"
                    Type="Int32" />
                <asp:ControlParameter ControlID="DropDownListType" Name="SQLReportType" PropertyName="SelectedValue" />
            </SelectParameters>
        </asp:SqlDataSource>
        &nbsp;
    </form>
</body>
</html>
