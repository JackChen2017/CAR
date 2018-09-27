<%@ Page Language="C#" AutoEventWireup="true" CodeFile="rightFrame.aspx.cs" Inherits="rightFrame" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>menu</title>
    <link href="CSS/Style.css" type="text/css" rel="stylesheet"/>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TreeView ID="TreeView1" runat="server">
            <Nodes>
                <asp:TreeNode Text="我的任务" Value="我的任务"  Checked="True" Expanded="True">
                    <asp:TreeNode Text="已发启" Value="已发启" NavigateUrl="MyWork.aspx" Target="mainFrame"></asp:TreeNode>
                    <asp:TreeNode Text="待审批" Value="待审批" NavigateUrl="MyShenPi.aspx" Target="mainFrame"></asp:TreeNode>
                    <asp:TreeNode Text="未发启" Value="未发启" NavigateUrl="MyAction.aspx" Target="mainFrame"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Text="客户投诉" Value="客户投诉" Expanded="False">
                    <asp:TreeNode Text="新增" Value="新增" NavigateUrl="QSM_New.aspx" Target="mainFrame" ToolTip="新增客户投诉页面"></asp:TreeNode>
                    <asp:TreeNode Text="查看" Value="查看" NavigateUrl="QSM_List.aspx" Target="mainFrame"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Text="不良品确认" Value="不良品确认" Expanded="False">
                    <asp:TreeNode Text="新增" Value="新增" NavigateUrl="SA_New.aspx" Target="_blank"></asp:TreeNode>
                    <asp:TreeNode Text="查看" Value="查看" NavigateUrl="SA_List.aspx" Target="mainFrame"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Text="8D Form" Value="8D Form"   Expanded="False">
                    <asp:TreeNode Text="新增" Value="新增" NavigateUrl="8D_New.aspx" Target="mainFrame" ToolTip="新增8D Form页面"></asp:TreeNode>
                    <asp:TreeNode Text="查看" Value="查看" NavigateUrl="8D_List.aspx" Target="mainFrame"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Text="HSF异常处理" Value="HSF异常处理" Expanded="False">
                    <asp:TreeNode Text="新增" Value="新增" NavigateUrl="HSF_New.aspx" Target="mainFrame"></asp:TreeNode>
                    <asp:TreeNode Text="查看" Value="查看" NavigateUrl="HSF_List.aspx" Target="mainFrame"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Text="异常矫正" Value="异常矫正" Expanded="False">
                    <asp:TreeNode Text="新增" Value="新增" NavigateUrl="JiaoZheng_New.aspx" Target="mainFrame"></asp:TreeNode>
                    <asp:TreeNode Text="查看" Value="查看" NavigateUrl="JiaoZheng_List.aspx" Target="mainFrame"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Text="相关报表" Value="相关报表" Expanded="False" >
                    <asp:TreeNode Text="客户投诉信息" Value="客户投诉信息" NavigateUrl="QSMReport.aspx" Target="mainFrame"></asp:TreeNode>
                    <asp:TreeNode Text="不良品信息" Value="不良品信息" NavigateUrl="SAReport.aspx" Target="mainFrame"></asp:TreeNode>
                </asp:TreeNode>
            </Nodes>
        </asp:TreeView>
        &nbsp;</div>
    </form>
</body>
</html>
