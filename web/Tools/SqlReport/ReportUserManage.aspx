<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReportUserManage.aspx.cs"
    EnableEventValidation="false" Inherits="Tools_SQLReport_ReportUserManage" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>用户管理</title>
<link href="../../App_Themes/Default/CSS/gray.css" rel="stylesheet" type="text/css" />
<link href="../../App_Themes/Default/CSS/Default.css" rel="stylesheet" type="text/css" />
<link  href="../../App_Themes/Default/CSS/base.css" rel="stylesheet" type="text/css" />
<link  href="../../App_Themes/Default/CSS/style1.css" rel="stylesheet" type="text/css" />    
<link  href="../../App_Themes/Default/CSS/style2.css" rel="stylesheet" type="text/css" />  
    <script type="text/javascript">
        function docheck(value)
        {
            
            var objs = event.srcElement.parentElement.parentElement.parentElement.getElementsByTagName('input');
            
            for(var i=0; i<objs.length; i++) 
            {
                if(objs[i].type.toLowerCase() == "checkbox" && objs[i].id.toLowerCase().indexOf(event.srcElement.id.toLowerCase()) > 0)

                //设置找到的CheckBox控件为false
                objs[i].checked = value;
            }
            
        }
    
    
        function saveValue()
        {
            var ojbCate = document.getElementsByName('checkBoxReportCate');
            var objReport = document.getElementsByName('checkBoxReport');
            var objField = document.getElementsByName('checkBoxShowSpecialField');
            var objOutput = document.getElementsByName('checkBoxShowOutput');
            var objOutputAll = document.getElementsByName('checkBoxShowOutputAll');            
            var objAddin = document.getElementsByName('checkBoxAddin');
            var objAddinAdmin = document.getElementsByName('checkBoxAddinAdmin');
            
            var strValue = '';
            
            form1.textCate.value = '';
            
            form1.textAddinIDList.value = '';
            for(var i=0;i<objAddinAdmin.length;i++)
            {
                if(objAddinAdmin[i].checked)
                {
                    form1.textAddinIDList.value += objAddinAdmin[i].value + ',';
                }
            }
            
            for(var i=0;i<ojbCate.length;i++)
            {
                if(ojbCate[i].checked)
                {
                    form1.textCate.value += ojbCate[i].value + ',';
                }
            }
            
            for(var i=0;i<objReport.length;i++)
            {
                if(objReport[i].checked == true)
                {
                    strValue += objReport[i].value + ',0.';
                                       
                    if(objField[i].checked == true)
                    {
                        strValue += '1';
                    }
                    else
                    {
                        strValue += '0';
                    }
                    
                    if(objOutput[i].checked == true)
                    {
                        strValue += '1';
                    }
                    else
                    {
                        strValue += '0';
                    }
                    
                    if(objOutputAll[i].checked == true)
                    {
                        strValue += '1,';
                    }
                    else
                    {
                        strValue += '0,';
                    }
                }
            }
            
            for(var i=0;i<objAddin.length;i++)
            {
//                alert('total=' + objAddin.length + ' current=' + i + ' id='+objAddin[i].value + 'checked=' + objAddin[i].checked);
                if(objAddin[i].checked == true)
                {
                    strValue += objAddin[i].value + ',0.';
                   
                    var objAddinRight = document.getElementsByName('checkBoxAddinRight'+objAddin[i].value);
                    for(var j=0;j<objAddinRight.length;j++)
                    {
//                        alert('totalRight=' + objAddinRight.length + ' current=' + j + ' id='+objAddinRight[j].value + 'checked=' + objAddinRight[j].checked);
                        if(objAddinRight[j].checked == true)
                        {
                            strValue +=  '1';
                        }
                        else
                        {
                            strValue +=  '0';
                        }
                    }
                    strValue += ',';
                }
            }            
            
            form1.textRightList.value = strValue;
            //alert(strValue + '  --  ' + form1.textCate.value);
                        
        }    
    </script>

</head>
<body style="text-align: center; width: 100%">
    <form id="form1" runat="server">
        <div style="text-align: left;">
            <asp:LinkButton ID="linkButtonNew" runat="server" Text="新增人员" OnClick="linkButtonNew_Click"></asp:LinkButton></div>
        <br />
        <table cellspacing="0" rules="all" border="1" id="ctl00_ContentPlaceHolder1_DetailsView1"
            style="text-align: right; height: 50px; width: 600px; border-collapse: collapse;">
            <caption>
                <asp:Label ID="labelTitle" runat="server" Text="添加人员" Font-Bold="True"></asp:Label>
            </caption>
            <tr>
                <td style="width: 112px">
                    所属工厂：</td>
                <td align="left">
                    <asp:DropDownList ID="dropDownListFactory" runat="server" AutoPostBack="True" OnSelectedIndexChanged="dropDownListFactory_SelectedIndexChanged"
                        ToolTip="选择工厂">
                    </asp:DropDownList>&nbsp;
                    <asp:DropDownList ID="dropDownListDepartment" runat="server" ToolTip="选择部门">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width: 112px">
                    AD帐号：</td>
                <td align="left">
                    <asp:TextBox ID="textBoxLoginUser" runat="server">founderpcb\</asp:TextBox>
                    <asp:ImageButton ID="imageButtonCheckUser" runat="server" ImageUrl="~/IMAGES/checknames.gif"
                        OnClick="imageButtonCheckUser_Click" ToolTip="获取中文姓名" OnClientClick="if(textBoxLoginUser.value.length==0 || textBoxLoginUser.value=='founderpcb\\'){alert('AD帐号不能为空');textBoxLoginUser.focus;return false;} " />
                    <asp:Button ID="buttonSearch" runat="server" Text="搜索用户" OnClick="buttonSearch_Click"
                        OnClientClick="if(textBoxLoginUser.value.length==0 || textBoxLoginUser.value=='founderpcb\\'){alert('AD帐号不能为空');textBoxLoginUser.focus;return false;} " /></td>
            </tr>
            <tr>
                <td style="width: 112px">
                    真实姓名：</td>
                <td align="left" style="width: 488px;">
                    <asp:TextBox ID="textBoxLoginUserRealName" runat="server" ReadOnly="True"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;用户类型:<asp:DropDownList ID="dropDownListUserType"
                        runat="server">
                        <asp:ListItem Value="0">普通用户</asp:ListItem>
                        <asp:ListItem Value="1">工厂管理员</asp:ListItem>
                        <asp:ListItem Value="2">辅助系统管理员</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:GridView ID="gridViewForUserInfo" runat="server" AutoGenerateColumns="False"
                        HorizontalAlign="left" HeaderStyle-HorizontalAlign="left" CellPadding="4" ForeColor="#333333"
                        GridLines="None" OnRowDeleting="gridViewForUserInfo_RowDeleting" AutoGenerateDeleteButton="True"
                        CaptionAlign="Left">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="EmployeeName" HeaderText="姓名" ItemStyle-HorizontalAlign="Left" />
                            <asp:BoundField DataField="EmployeeWorkNumber" HeaderText="工号" ItemStyle-HorizontalAlign="Left" />
                            <asp:BoundField DataField="UnitFullName" HeaderText="公司部门" ItemStyle-ForeColor="Red"
                                ItemStyle-HorizontalAlign="Left"></asp:BoundField>
                            <asp:BoundField DataField="JobName" HeaderText="职务" ItemStyle-HorizontalAlign="Left">
                            </asp:BoundField>
                        </Columns>
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle BackColor="#999999" />
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    </asp:GridView>
                </td>
            </tr>
        </table>
        <br />
        <table cellspacing="0" rules="all" border="1" id="Table1" style="text-align: right;
            height: 50px; width: 680px; border-collapse: collapse;">
            <tr  onclick="if(trReport.style.display=='none'){trReport.style.display='block';document.getElementById('spanReport').innerHTML='<<点击这里关闭';}else{trReport.style.display='none';document.getElementById('spanReport').innerHTML='<<点击这里展开';}"
                style="cursor: hand; text-align: left; font-weight: bold; display:<%= (CurrentUser.RightIsAdmin || CurrentUser.HasFactoryAdminRole(Convert.ToInt32(dropDownListFactory.SelectedValue))) ? "block" : "none" %>" title="报表权限 点击开展/收拢">
                <td colspan="2">
                    报表权限<span id="spanReport">>>点击这里打开</span></td>
            </tr>
            <tr id="trReport" style="display: none;">
                <td colspan="2" align="left">
                    <asp:Repeater ID="repeaterReportCate" runat="server" OnItemDataBound="repeaterReportCate_ItemDataBound">
                        <HeaderTemplate>
                            <table style="width: 100%">
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr bgcolor="#ccccff" onmouseover="this.bgColor='#3366ff'" onmouseout="this.bgColor='#ccccff'">
                                <td style="width: 10px;">
                                    <input id="checkBoxReportCate" type="checkbox" value="<%#Eval("Value") %>" <%# isCheckedDepartment(Eval("Value").ToString()) %> /></td>
                                <td align="left" onclick="if(tr<%#Eval("Value") %>.style.display=='none'){tr<%#Eval("Value") %>.style.display='block';}else{tr<%#Eval("Value") %>.style.display='none';}"
                                    style="cursor: hand;">
                                    <%#Eval("Name")%>
                                </td>
                            </tr>
                            <tr id="tr<%#Eval("Value") %>" style="display: none;">
                                <td>
                                </td>
                                <td>
                                    <table style="width: 100%">
                                        <tr bgcolor="#f0f8ff">
                                            <td style="width: 30px; border-bottom-width: thin; border-bottom-style: solid;">
                                                &nbsp;</td>
                                            <td style="border-bottom-width: thin; border-bottom-style: solid;">
                                                <input id="Report" type="checkbox" onclick="if(this.checked){docheck(true);}else{docheck(false);}" />全选</td>
                                            <td style="border-bottom-width: thin; border-bottom-style: solid;">
                                                <input id="SpecialField" type="checkbox" onclick="if(this.checked){docheck(true);}else{docheck(false);}" />全选</td>
                                            <td style="border-bottom-width: thin; border-bottom-style: solid;">
                                                <input id="Output" type="checkbox" onclick="if(this.checked){docheck(true);}else{docheck(false);}" title="不可导出特殊字段" />全选</td>
                                            <td style="border-bottom-width: thin; border-bottom-style: solid;" title="特殊权限&#10;可导出特殊字段&#10;必须有[显示特殊字段]权限才生效">
                                                <input id="OutputAll" type="checkbox" onclick="if(this.checked){docheck(true);}else{docheck(false);}" /><strong>全选(<font color='red'>*</font>)</strong></td>
                                        </tr>
                                        <asp:Repeater ID="repeaterReportList" runat="server">
                                            <ItemTemplate>
                                                <tr title="<%# Eval("SQLReportStatus").ToString().Trim().Equals("1") ? "此报表已经停用" : "" %>"
                                                    style="<%# Eval("SQLReportStatus").ToString().Trim().Equals("1") ? "background-color:Red": "" %>">
                                                    <td align="center" style="width: 30px; border-bottom-width: thin; border-bottom-style: solid;">
                                                        <%# Container.ItemIndex + 1 %>
                                                    </td>
                                                    <td align="left" style="width: 60%; border-bottom-width: thin; border-bottom-style: solid;"
                                                        bgcolor="#ffffff" onmouseover="this.bgColor='#eaeaea'" onmouseout="this.bgColor='#FFFFFF'">
                                                        <input id="checkBoxReport" type="checkbox" value="<%#Eval("SQLReportID") %>" <%# isCheckedReport(Eval("SQLReportID").ToString()) %> /><%#Eval("SQLReportName")%></td>
                                                    <td bgcolor="#ffffff" style="border-bottom-width: thin; border-bottom-style: solid;"
                                                        onmouseover="this.bgColor='#eaeaea'" onmouseout="this.bgColor='#FFFFFF'">
                                                        <input id="checkBoxShowSpecialField" type="checkbox" value="" <%# isCheckedRightOfShowSpecialField(Eval("SQLReportID").ToString()) %> />显示特殊字段</td>
                                                    <td bgcolor="#ffffff" style="border-bottom-width: thin; border-bottom-style: solid;"
                                                        onmouseover="this.bgColor='#eaeaea'" onmouseout="this.bgColor='#FFFFFF'"  title="不可导出特殊字段">
                                                        <input id="checkBoxShowOutput" type="checkbox" value="" <%# isCheckedRightOfOutput(Eval("SQLReportID").ToString()) %> />受限导出</td>
                                                    <td bgcolor="#ffffff" style="border-bottom-width: thin; border-bottom-style: solid;"
                                                        onmouseover="this.bgColor='#eaeaea'" onmouseout="this.bgColor='#FFFFFF'" title="特殊权限&#10;可导出特殊字段&#10;必须有[显示特殊字段]权限才生效">
                                                        <input id="checkBoxShowOutputAll" type="checkbox" value="" <%# isCheckedRightOfOutputAll(Eval("SQLReportID").ToString()) %> />全导出</td>
                                                </tr>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                            </FooterTemplate>
                                        </asp:Repeater>
                                    </table>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </td>
            </tr>
            <tr onclick="if(trERPAddin.style.display=='none'){trERPAddin.style.display='block';document.getElementById('spanAddin').innerHTML='<<点击这里关闭';}else{trERPAddin.style.display='none';document.getElementById('spanAddin').innerHTML='<<点击这里展开';}"
                style="cursor: hand; color:White; background-color:Red; text-align: left; font-weight: bold;" title="ERP辅助系统 点击开展/收拢">
                <td colspan="2">
                    ERP辅助系统<span id="spanAddin">>>点击这里打开</span></td>
            </tr>
            <tr id="trERPAddin" style="display: none;">
                <td colspan="2" align="left">
                    <asp:Repeater ID="repeaterERPAddin" runat="server" OnItemDataBound="repeaterERPAddin_ItemDataBound">
                        <HeaderTemplate>
                            <table style="width: 100%">
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr bgcolor="#ccccff" onmouseover="this.bgColor='#3366ff'" onmouseout="this.bgColor='#ccccff'">
                                <td style="width: 10px;">
                                    &nbsp;&gt;&gt;
                                </td>
                                <td align="left" onclick="if(trAddinD<%#Eval("Value") %>.style.display=='none'){trAddinD<%#Eval("Value") %>.style.display='block';}else{trAddinD<%#Eval("Value") %>.style.display='none';}"
                                    style="cursor: hand;">
                                    <%#Eval("Name")%>
                                </td>
                            </tr>
                            <tr id="trAddinD<%#Eval("Value") %>" style="display: none;">
                                <td style="width: 10px;">
                                </td>
                                <td>
                                    <asp:Repeater ID="repeaterERPAddinList" runat="server" OnItemDataBound="repeaterERPAddinList_ItemDataBound">
                                        <HeaderTemplate>
                                            <table style="width: 100%">
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr title="<%# Eval("SQLReportStatus").ToString().Trim().Equals("1") ? "[此功能已经停用] - 点击查看权限" : "点击查看权限" %>"
                                                style="cursor: hand; display:<%# showAddin(Eval("SQLReportID").ToString()) %>">
                                                <td align="center" style="width: 30px; font-weight: bolder; border-bottom-width: thin;
                                                    border-bottom-style: solid; <%# Eval("SQLReportStatus").ToString().Trim().Equals("1") ? "background-color:Red": "" %>;">
                                                    <input id="checkBoxAddin" name="checkBoxAddin" type="checkbox" value="<%#Eval("SQLReportID") %>"
                                                        <%# isCheckedReport(Eval("SQLReportID").ToString()) %> />
                                                </td>
                                                <td align="left" style="border-bottom-width: thin; border-bottom-style: solid;" bgcolor="#f0f0ff"
                                                    onmouseover="this.bgColor='#aaaaff'" onmouseout="this.bgColor='#f0f0ff'" onclick="if(trAddin<%#Eval("SQLReportID") %>.style.display=='none'){trAddin<%#Eval("SQLReportID") %>.style.display='block';}else{trAddin<%#Eval("SQLReportID") %>.style.display='none';}">
                                                    <%#Eval("SQLReportName")%>
                                                </td>
                                                <td align="center" style="width: 80px; font-weight: bolder; border-bottom-width: thin;
                                                    border-bottom-style: solid;" bgcolor="#f0f0ff" onmouseover="this.bgColor='#aaaaff'" onmouseout="this.bgColor='#f0f0ff'" >
                                                    <input id="checkBoxAddinAdmin" name="checkBoxAddinAdmin" type="checkbox" value="<%#Eval("SQLReportID") %>"
                                                        <%# isCheckedAddinAdminRight(Eval("SQLReportID").ToString()) %> />管理员
                                                </td>
                                            </tr>
                                            <tr id="trAddin<%#Eval("SQLReportID") %>" style="display: none;">
                                                <td>
                                                </td>
                                                <td>
                                                    <asp:Repeater ID="repeaterERPAddinRightList" runat="server">
                                                        <HeaderTemplate>
                                                            <table style="width: 100%;" border="0">
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <tr>
                                                                <td align="center" style="width: 30px; border-bottom-width: thin; border-bottom-style: solid;">
                                                                    <%# Container.ItemIndex + 1 %>
                                                                </td>
                                                                <td align="left" style="width: 100%; border-bottom-width: thin; border-bottom-style: solid;"
                                                                    bgcolor="#ffffff" onmouseover="this.bgColor='#eaeaea'" onmouseout="this.bgColor='#FFFFFF'">
                                                                    <input id="checkBoxAddinRight<%#Eval("SQLReportID") %>" name="checkBoxAddinRight<%#Eval("SQLReportID") %>"
                                                                        type="checkbox" value="<%#Eval("SQLReportID") %>" <%# isCheckedAddinRight(Eval("SQLReportID").ToString()) %> /><%#Eval("ERPAddinRightName")%></td>
                                                            </tr>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            </table>
                                                        </FooterTemplate>
                                                    </asp:Repeater>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            </table>
                                        </FooterTemplate>
                                    </asp:Repeater>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </td>
            </tr>
            <tr>
                <td style="height: 27px">
                    <input id="textEmpNum" type="hidden" value="" runat="server" size="1" />
                    <input id="textAddinIDList" type="hidden" value="" runat="server" size="1" />
                    <input id="textRightList" type="hidden" value="" runat="server" size="1" /><input
                        id="textCate" type="hidden" value="" runat="server" size="1" />
                </td>
                <td align="left" style="height: 27px">
                    <asp:Button ID="buttonSubmit" runat="server" Text="确定" OnClick="buttonSubmit_Click"
                        OnClientClick="saveValue();" />&nbsp;
                    <asp:Button ID="buttonDelete" runat="server" Text="删除" OnClientClick="if(confirm('真的要删除吗？数据删除后将不可恢复')) {return true;}else{return false;}"
                        OnClick="buttonDelete_Click" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
