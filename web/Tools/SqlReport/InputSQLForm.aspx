<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InputSQLForm.aspx.cs" Inherits="Tools_SQLReport_InputSQLForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>报表录入管理</title>
<link href="../../App_Themes/Default/CSS/gray.css" rel="stylesheet" type="text/css" />
<link href="../../App_Themes/Default/CSS/Default.css" rel="stylesheet" type="text/css" />
<link  href="../../App_Themes/Default/CSS/base.css" rel="stylesheet" type="text/css" />
<link  href="../../App_Themes/Default/CSS/style1.css" rel="stylesheet" type="text/css" />    
<link  href="../../App_Themes/Default/CSS/style2.css" rel="stylesheet" type="text/css" />      
</head>
<body  style="text-align: center; width:100%">
    <form id="form1" runat="server">
        <div style="text-align: left;">
            <asp:LinkButton ID="LinkButton1" PostBackUrl="" runat="server" Text="新增报表" OnClick="LinkButton1_Click" />
        </div>
        <br />
        <table cellspacing="0" rules="all" border="1" id="ctl00_ContentPlaceHolder1_DetailsView1"
            style="text-align: right; height: 50px; width: 637px; border-collapse: collapse;">
            <caption>
                <asp:Label ID="labelTitle" runat="server" Text="新增查询报表" Font-Bold="True"></asp:Label>
            </caption>
            <tr>
                <td style="width: 112px">
                    报表名称</td>
                <td align="left">
                    <asp:TextBox ID="textBoxReportName" runat="server" Width="504px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 112px">
                    所属模块</td>
                <td align="left">
                    <asp:DropDownList ID="dropDownListFactory" runat="server" AutoPostBack="True" OnSelectedIndexChanged="dropDownListFactory_SelectedIndexChanged"
                        ToolTip="选择工厂">
                    </asp:DropDownList>&nbsp;
                    <asp:DropDownList ID="dropDownListReportCate" runat="server">
                    </asp:DropDownList>
                    <span style="width: 260px; text-align: right;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;显示顺序</span><asp:TextBox
                        ID="textBoxSortIndex" runat="server" onkeypress="return (/[\d]/.test(String.fromCharCode(event.keyCode)))"
                        Style="ime-mode: Disabled" Text="1000" Width="30px"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox
                            ID="checkBoxIsLimited" runat="server" Checked="true" Text="启用3000条限制" ToolTip="如非必要,请不要关闭此选项" />
                </td>
            </tr>
            <tr style="display: none;">
                <td style="width: 112px">
                    附属模块</td>
                <td align="left">
                    <asp:CheckBoxList ID="checkBoxListReportCate" runat="server" RepeatColumns="9" RepeatDirection="Horizontal">
                    </asp:CheckBoxList>
                </td>
            </tr>
            <tr>
                <td style="width: 112px; height: 26px;">
                    SQL语句：</td>
                <td align="left" style="height: 26px">
                    <asp:TextBox ID="textBoxSQLCommand" runat="server" Width="504px" Height="106px" TextMode="MultiLine"></asp:TextBox>&nbsp;
                </td>
            </tr>
            <tr>
                <td style="width: 112px">
                    查询条件</td>
                <td align="left">
                    <asp:TextBox ID="textBoxSQLSQLWhere" runat="server" Width="504px" Height="56px" TextMode="MultiLine"></asp:TextBox>
                    <asp:Label ID="Label2" runat="server" Text="说明： 此处的条件为可以被用户替换的条件语句    格式： 中文字段1=X ..."
                        ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 112px">
                    排序方式</td>
                <td align="left">
                    <asp:TextBox ID="textBoxSQLOrder" runat="server" Width="504px" TextMode="MultiLine"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 112px">
                    特殊字段</td>
                <td align="left">
                    <asp:TextBox ID="textBoxSpecialField" runat="server" Width="504px" TextMode="MultiLine"></asp:TextBox>
                    <asp:Label ID="Label3" runat="server" Text="说明： 需要进行授权的字段如金额，面积等(字段之间以逗号分隔)     格式： 中文字段1,中文字段2..."
                        ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 112px">
                    汇总字段</td>
                <td align="left">
                    <asp:TextBox ID="textBoxCalculateField" runat="server" Width="504px" TextMode="MultiLine"></asp:TextBox>
                    <asp:Label ID="Label1" runat="server" Text="说明： 需要进行汇总计算的字段(字段之间以逗号分隔)    格式： 中文字段1,中文字段2..."
                        ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 112px">
                    显示页面</td>
                <td align="left">
                    <asp:TextBox ID="textBoxShowURL" runat="server" Width="504px" TextMode="MultiLine"></asp:TextBox>
                    <asp:Label ID="Label4" runat="server" Text="说明： 此字段可以为空，有特殊页面显示的在此录入页面地址" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 112px">
                    报表备注</td>
                <td align="left">
                    <asp:TextBox ID="textBoxComment" runat="server" Width="504px" TextMode="MultiLine"
                        Text="此查询一次最多显示3000条记录，后面的数据可以设置查询条件获取"></asp:TextBox>
                    <asp:Label ID="Label5" runat="server" Text="说明： 显示在报表显示顶部的文字" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 112px">
                    报表状态</td>
                <td align="left">
                    <asp:RadioButtonList ID="radioButtonListReportStatus" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Value="0" Selected="True" title="[正常] 可以使用的报表">正常</asp:ListItem>
                        <asp:ListItem Value="1" title="[停用] 普通用户不可见,仅管理员可以看">停用</asp:ListItem>
                        <asp:ListItem Value="2" title="[公用] 同[正常]且公共平台可见">公用</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td style="width: 112px">
                    特殊功能</td>
                <td align="left">
                    <asp:RadioButtonList ID="radioButtonListFucCode" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Value="0" Selected="True">正常</asp:ListItem>
                        <asp:ListItem Value="1">取消报表首列重复项不显示</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Button ID="buttonCopy" runat="server" Text="复制" ToolTip="复制当前报表资料,生成新报表" CausesValidation="False"
                        OnClick="buttonCopy_Click" /></td>
                <td align="center">
                    <asp:Button ID="buttonSave" runat="server" Text="提交" OnClick="buttonSave_Click" OnClientClick="if(textBoxReportName.value.length==0){alert('报表名称不能为空');textBoxReportName.focus();return false;} if(textBoxSortIndex.value.length==0){alert('显示顺序不能为空,已重置为默认值99');textBoxSortIndex.value='99';textBoxSortIndex.focus();return false;}"
                        CausesValidation="False" />
                    <asp:Button ID="buttonDelete" runat="server" Text="删除" CausesValidation="False" OnClick="buttonDelete_Click"
                        OnClientClick="if(confirm('真的要删除吗？数据删除后将不可恢复')) {return true;}else{return false;}" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
