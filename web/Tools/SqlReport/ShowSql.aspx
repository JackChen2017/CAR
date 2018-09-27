<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShowSql.aspx.cs" Inherits="Tools_SQLReport_ShowSql"
    EnableEventValidation="false" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>查询报表</title>
    <link href="../../App_Themes/Default/CSS/gray.css" rel="stylesheet" type="text/css" />
    <link href="../../App_Themes/Default/CSS/Default.css" rel="stylesheet" type="text/css" />
    <link  href="../../App_Themes/Default/CSS/base.css" rel="stylesheet" type="text/css" />
    <link  href="../../App_Themes/Default/CSS/style1.css" rel="stylesheet" type="text/css" />    
    <link  href="../../App_Themes/Default/CSS/style2.css" rel="stylesheet" type="text/css" />      
    <style type="text/css">
.fixed   
  {
 background-color:White;
      position:   relative     ;   
      top:expression(this.offsetParent.scrollTop);   
      left:expression(this.offsetParent.scrollLeft);   
      z-index:2;   
  }
  
  
  /*****另一种样式******/
  .Freezing 
   { 
   
   background-color:#ccccff; 
   position:relative ; 
   table-layout:fixed;
   top:expression(this.offsetParent.scrollTop);   
   z-index: 10;
   } 

.Freezing th{text-overflow:ellipsis;overflow:hidden;white-space: nowrap;padding:2px;}

  
  
</style>

    <script type="text/javascript" language="JavaScript">
    function openpage(htmlurl,width,height) 
    {
    
        var xMax = 640, yMax=480, theWidth=width, theHeight=height; 
        if (document.all) 
        {
            xMax = screen.width; yMax = screen.height;
        }
        else  if (document.layers) 
        {
            xMax = window.outerWidth; yMax = window.outerHeight; 
        }
        
        
        var xOffset = (xMax - 200)/2, yOffset = (yMax - 200)/2; 
        xOffset -= (parseInt(theWidth)/2) -100; yOffset -= (parseInt(theHeight)/2) - 60; 
        
        var newwin=window.open(htmlurl,"newWin","toolbar=no,location=no,directories=no,status=no,scrollbars=no,menubar=no,resizable=yes,top=" + yOffset + ",left=" + xOffset + ",width="+theWidth +",height=" +theHeight);
        newwin.focus();
        return false;
    }

    </script>

</head>
<body>
    <form id="form1" runat="server">
                <asp:Button ID="btnSaveToExcel" runat="server" OnClick="btnSaveToExcel_Click" Text="导出Excel"
                    CausesValidation="False" />
                <asp:Label ID="labelComment" runat="server" ForeColor="#C0C0FF"></asp:Label>
                <table border="1" cellpadding="0" cellspacing="0" width="6800">
                    <tr>
                        <td>
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="width: 120px;">
                                        <strong style="cursor: hand;">
                                            <asp:Button ID="buttonSearch" runat="server" Text="设置搜索条件" OnClick="buttonSearch_Click" /></strong></td>
                                    <td align="left">
                                        当前的筛选条件：<asp:Label ID="labelCurrentSearch" runat="server" ForeColor="Red"></asp:Label></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <strong style="cursor: hand;">
                                <asp:Label ID="labelField" runat="server" Text="选择显示的字段" /></strong><asp:Button ID="buttonChange"
                                    runat="server" Text="确定" OnClick="buttonChange_Click" /><asp:Label ID="label1" runat="server"
                                        Width="400px" Font-Bold="False" ForeColor="Red"></asp:Label>
                            <asp:Label ID="labelTitle" runat="server" Font-Bold="True" Font-Size="15pt"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr valign="top">
                                    <td style="width: 180px;" id="tableOfField">
                                        <asp:CheckBoxList ID="checkBoxListColumn" runat="server" OnSelectedIndexChanged="checkBoxListColumn_SelectedIndexChanged">
                                        </asp:CheckBoxList>
                                    </td>
                                    <td valign="top">
                                        <!--  HeaderStyle-CssClass="Freezing" -->
                                        <asp:GridView Visible="false" ID="GridView1" runat="server" EmptyDataText="无数据" AllowSorting="True"
                                            OnSorting="GridView1_Sorting" BorderStyle="Groove" BorderWidth="2px" OnRowDataBound="GridView1_RowDataBound"
                                            CaptionAlign="Left" ShowFooter="True" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging"
                                            PageSize="22">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex + 1 %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
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
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td valign="top">
                        </td>
                    </tr>
                </table>
        <div style="display: none;">
            <asp:GridView ID="GridViewForDownload" runat="server" OnRowDataBound="GridView1_RowDataBound">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <table border="0" width="100%" runat="server" id="tableForDebugInfo" visible="false">
            <tr>
                <td style="cursor: hand; height: 20px;" onclick="if(trWarming.style.display=='none'){trWarming.style.display='block';}else{trWarming.style.display='none';}">
                    &nbsp;
                </td>
            </tr>
            <tr id="trWarming" style="display: none;">
                <td>
                    当前页面权限为:<%= CurrentUser.CurrentFuctionRightString %><br />
                    当前页面权限为:<%= CurrentUser.FullRightString %><br />
                    用户权限进行了修改情况:<%= ((System.Web.HttpContext.Current.Application[FounderTecInfoSys.Common.ConstForApplication.UserDataChangeFlagTable] == null) || ((System.Collections.Generic.List<string>)System.Web.HttpContext.Current.Application[FounderTecInfoSys.Common.ConstForApplication.UserDataChangeFlagTable]).Count == 0) ? "无" : "共有 <strong>" + ((System.Collections.Generic.List<string>)System.Web.HttpContext.Current.Application[FounderTecInfoSys.Common.ConstForApplication.UserDataChangeFlagTable]).Count.ToString() + "</strong>&nbsp;人,其中第一个人是 <strong>" + ((System.Collections.Generic.List<string>)System.Web.HttpContext.Current.Application[FounderTecInfoSys.Common.ConstForApplication.UserDataChangeFlagTable])[0] + "</strong> "%>
                    <br />
                    <br />
                    <strong>报表执行的SQL代码: </strong><br />
                    <hr />
                    <asp:Label ID="labelSQL" runat="server" Text=""></asp:Label>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
