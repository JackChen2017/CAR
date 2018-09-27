<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReportUsingHistory.aspx.cs"
    Inherits="Tools_SQLReport_ReportUsingHistory" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ERP报表使用率统计平台</title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="divToolBarTop" runat="server">
            <br />
            <asp:LinkButton ID="linkButtonSumInfo" runat="server" Enabled="false" OnClick="linkButtonSumInfo_Click">汇总信息</asp:LinkButton>
            <asp:LinkButton ID="linkButtonDetailInfo" runat="server" OnClick="linkButtonDetailInfo_Click">明细信息</asp:LinkButton>&nbsp;
            <asp:LinkButton ID="LinkButtonPersonSumInfo" runat="server" OnClick="LinkButtonPersonSumInfo_Click">人员访问报表统计信息</asp:LinkButton>
            <asp:LinkButton ID="LinkButtonShowReportInfo" runat="server" OnClick="LinkButtonShowReportInfo_Click"
                ToolTip="点击查看当前系统中所有报表清单">报表详细信息</asp:LinkButton>
            <asp:DropDownList ID="dropDownListFactory" runat="server" Visible="false">
            </asp:DropDownList>
            <asp:Button ID="buttonToExcel" runat="server" Text="导出至Excel" OnClick="buttonToExcel_Click" /><br />
            <hr />
            <br />
        </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
            ForeColor="#333333" GridLines="None" EmptyDataText="无数据" AllowPaging="True" PageSize="18"
            OnPageIndexChanging="GridView1_PageIndexChanging">
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <%# Container.DataItemIndex + 1 %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="CreateTime" DataFormatString="{0:d}" HeaderText="登录时间" />
                <asp:BoundField DataField="LoginUser" HeaderText="使用者AD帐号" />
                <asp:BoundField DataField="LoginUserRealName" HeaderText="使用者姓名">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="IP" HeaderText="登录机器IP" />
                <asp:BoundField DataField="HitNum" HeaderText="使用次数">
                    <ItemStyle HorizontalAlign="Center" />
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
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <EditRowStyle BackColor="#999999" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:GridView>
        <div id="divSpan" runat="server" visible="false">
            <div id="divToolBar" runat="server">
                使用报表人员列表：<asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSourceSQLReportUser"
                    DataTextField="LoginUserRealName" DataValueField="LoginUser" AutoPostBack="True"
                    OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" OnDataBinding="DropDownList1_DataBinding"
                    OnDataBound="DropDownList1_DataBound">
                </asp:DropDownList>
                <asp:TextBox ID="textBoxUserName" runat="server"></asp:TextBox>
                <asp:Button ID="buttonSearch" runat="server" Text="搜索" OnClick="buttonSearch_Click" /><br />
            </div>
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="4"
                ForeColor="#333333" GridLines="None" DataSourceID="ObjectDataSourcePeronalUserSumInfo"
                EmptyDataText="无数据" AllowPaging="True" PageSize="18" OnPageIndexChanging="GridView2_PageIndexChanging">
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="CreateTime" DataFormatString="{0:d}" HeaderText="登录时间" />
                    <asp:BoundField DataField="LoginUser" HeaderText="使用者AD帐号" />
                    <asp:BoundField DataField="LoginUserRealName" HeaderText="使用者姓名">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="IP" HeaderText="登录机器IP" />
                    <asp:TemplateField HeaderText="所属工厂">
                        <ItemTemplate>
                            <%# dropDownListFactory.Items.FindByValue(Eval("SQLReportFactory").ToString()) == null ? "" : dropDownListFactory.Items.FindByValue(Eval("SQLReportFactory").ToString()).Text %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="类型">
                        <ItemTemplate>
                            <%# Eval("SQLReportType").ToString() == "0" ? "报表" : "辅助系统" %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="SQLReportName" HeaderText="报表名称" />
                    <asp:BoundField DataField="HitNum" HeaderText="使用次数">
                        <ItemStyle HorizontalAlign="Center" />
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
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <EditRowStyle BackColor="#999999" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            </asp:GridView>
            <asp:ObjectDataSource ID="ObjectDataSourceSQLReportUser" runat="server" OldValuesParameterFormatString="original_{0}"
                SelectMethod="GetData" TypeName="InfoSysEntityTableAdapters.SQLReportUserRightTableAdapter">
            </asp:ObjectDataSource>
            <asp:SqlDataSource ID="SqlDataSourceSQLReportUser" runat="server" ConnectionString="<%$ ConnectionStrings:FIDataConnectionString %>"
                SelectCommand="SELECT DISTINCT LoginUser, LoginUserRealName FROM SQLReportUserRight ORDER BY LoginUserRealName">
            </asp:SqlDataSource>
            <asp:ObjectDataSource ID="ObjectDataSourcePeronalUserSumInfo" runat="server" OldValuesParameterFormatString="original_{0}"
                SelectMethod="GetPeronalSumData" TypeName="InfoSysEntityTableAdapters.SQLReportUsingHistoryViewTableAdapter">
                <SelectParameters>
                    <asp:ControlParameter ControlID="textBoxUserName" Name="LoginUser" PropertyName="Text"
                        Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
            &nbsp;
        </div>
    </form>
</body>
</html>
