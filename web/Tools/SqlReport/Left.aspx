<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Left.aspx.cs" Inherits="Tools_AddinForERP_Left" Theme=""
    EnableViewState="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>工具栏</title>
<%--    <link href="../../Css/ErpComm.css" rel="stylesheet" type="text/css" />
--%>    <style type="text/css">
    <!--
    html {
	scrollbar-face-color: #D1E7F6;
	scrollbar-highlight-color: #D7DCEC;
	scrollbar-shadow-color: #2587CC;
	scrollbar-3dlight-color: #2587CC;
        FILTER: chroma(COLOR=#eeeeee);
        overflow: auto;
    }

    #div{ 
    FILTER: chroma(COLOR=#eeeeee);
    overflow: auto;}
    
a:hover{benc:expression(this.onmousemove = window.status="ERP SQL报表平台")}

    -->
    </style>
</head>
<body >
    <div id="div">
        <form id="form1" runat="server">
            <table height="100%" align="left" width="160" border="0" cellspacing="0" cellpadding="0">
                <tr>
                <td style="height:5px; background-color:#FFFBD6">
                    <asp:Menu ID="Menu1" runat="server" BackColor="#FFFBD6" DynamicHorizontalOffset="2"
                        Font-Names="Verdana" Font-Size="11px" ForeColor="#990000" MaximumDynamicDisplayLevels="1"
                        Orientation="Horizontal" StaticSubMenuIndent="10px">
                        <StaticSelectedStyle BackColor="#FFCC66" />
                        <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                        <DynamicHoverStyle BackColor="#990000" ForeColor="White" />
                        <DynamicMenuStyle BackColor="#FFFBD6" />
                        <DynamicSelectedStyle BackColor="#FFCC66" />
                        <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                        <StaticHoverStyle BackColor="#990000" ForeColor="White" />
                    </asp:Menu><asp:Menu ID="Menu2" runat="server" BackColor="#FFFBD6" DynamicHorizontalOffset="2"
                        Font-Names="Verdana" Font-Size="11px" ForeColor="#990000" MaximumDynamicDisplayLevels="1"
                        Orientation="Horizontal" StaticSubMenuIndent="10px">
                        <StaticSelectedStyle BackColor="#FFCC66" />
                        <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                        <DynamicHoverStyle BackColor="#990000" ForeColor="White" />
                        <DynamicMenuStyle BackColor="#FFFBD6" />
                        <DynamicSelectedStyle BackColor="#FFCC66" />
                        <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                        <StaticHoverStyle BackColor="#990000" ForeColor="White" />
                    </asp:Menu><asp:Menu ID="Menu3" runat="server" BackColor="#FFFBD6" DynamicHorizontalOffset="2"
                        Font-Names="Verdana" Font-Size="11px" ForeColor="#990000" MaximumDynamicDisplayLevels="1"
                        Orientation="Horizontal" StaticSubMenuIndent="10px">
                        <StaticSelectedStyle BackColor="#FFCC66" />
                        <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                        <DynamicHoverStyle BackColor="#990000" ForeColor="White" />
                        <DynamicMenuStyle BackColor="#FFFBD6" />
                        <DynamicSelectedStyle BackColor="#FFCC66" />
                        <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                        <StaticHoverStyle BackColor="#990000" ForeColor="White" />
                    </asp:Menu>
                </td>
                </tr>
                <tr height="600">
                    <td valign="top" style="width: 163px;">
                        <asp:TreeView ID="TreeView1" runat="server" BorderStyle="None" BorderWidth="0px"
                            ImageSet="Arrows" Target="masterFrame" ExpandDepth="2">
                            <ParentNodeStyle Font-Bold="False" />
                            <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
                            <SelectedNodeStyle Font-Underline="True" HorizontalPadding="0px" VerticalPadding="0px"
                                ForeColor="#5555DD" BackColor="#C0FFFF" />
                            <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px"
                                NodeSpacing="0px" VerticalPadding="0px" />
                        </asp:TreeView>
                        &nbsp;
                    </td>
                </tr>
            </table>
         </form>
    </div>
</body>
</html>
