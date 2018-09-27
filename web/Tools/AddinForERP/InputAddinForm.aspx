<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InputAddinForm.aspx.cs" Inherits="Tools_AddinForERP_InputAddinForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>����¼�����</title>
<link href="../../App_Themes/Default/CSS/gray.css" rel="stylesheet" type="text/css" />
<link href="../../App_Themes/Default/CSS/Default.css" rel="stylesheet" type="text/css" />
<link  href="../../App_Themes/Default/CSS/base.css" rel="stylesheet" type="text/css" />
<link  href="../../App_Themes/Default/CSS/style1.css" rel="stylesheet" type="text/css" />    
<link  href="../../App_Themes/Default/CSS/style2.css" rel="stylesheet" type="text/css" />      
</head>
<body style="text-align: center; width:100%">
    <form id="form1" runat="server">
        <div style="text-align: left;">
            <asp:LinkButton ID="LinkButton1" PostBackUrl="" runat="server" Text="��������" OnClick="LinkButton1_Click" />
        </div>
        <br />
        <table cellspacing="0" rules="all" border="1" id="ctl00_ContentPlaceHolder1_DetailsView1"
            style="text-align: right; height: 50px; width: 637px; border-collapse: collapse;">
            <caption>
                <asp:Label ID="labelTitle" runat="server" Text="����ERP��������" Font-Bold="True"></asp:Label>
            </caption>
            <tr>
                <td style="width: 112px">
                    ��������</td>
                <td align="left">
                    <asp:TextBox ID="textBoxName" runat="server" Width="504px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 112px">
                    ����ģ��</td>
                <td align="left">
                    <asp:DropDownList ID="dropDownListFactory" runat="server" AutoPostBack="True" OnSelectedIndexChanged="dropDownListFactory_SelectedIndexChanged"
                        ToolTip="ѡ�񹤳�">
                    </asp:DropDownList>&nbsp;
                    <asp:DropDownList ID="dropDownListReportCate" runat="server">
                    </asp:DropDownList>
                    <span style="width: 260px; text-align: right;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;��ʾ˳��</span><asp:TextBox
                        ID="textBoxSortIndex" runat="server" onkeypress="return (/[\d]/.test(String.fromCharCode(event.keyCode)))"
                        Style="ime-mode: Disabled" Text="99" Width="30px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 112px">
                    ��ʾҳ��</td>
                <td align="left">
                    <asp:TextBox ID="textBoxShowURL" runat="server" Width="504px"></asp:TextBox>&nbsp;
                </td>
            </tr>
            <tr>
                <td style="width: 112px">
                    ����״̬</td>
                <td align="left">
                    <asp:RadioButtonList ID="radioButtonListReportStatus" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Value="0" Selected="True" title="[����] ����ʹ�õı���">����</asp:ListItem>
                        <asp:ListItem Value="1" title="[ͣ��] ��ͨ�û����ɼ�,������Ա���Կ�">ͣ��</asp:ListItem>
                        <%--<asp:ListItem Value="2" title="[����] ͬ[����]�ҹ���ƽ̨�ɼ�">����</asp:ListItem>--%>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td style="width: 112px">
                    ����Ȩ���б�:</td>
                <td align="left">
                    <asp:TextBox ID="textBoxRightName" runat="server"></asp:TextBox>&nbsp;
                    <asp:Button ID="buttonAddRight" runat="server" Text="���Ȩ��" OnClientClick="if(textBoxRightName.value.length==0){alert('��������Ȩ������');textBoxRightName.focus();return false;}"
                        OnClick="buttonAddRight_Click" />
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                        ForeColor="#333333" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating"
                        OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Ȩ������">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBoxName" runat="server" Text='<%# Bind("ERPAddinRightName") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("ERPAddinRightName") %>'></asp:Label>
                                </ItemTemplate>
                                <ControlStyle Width="320px" />
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle Width="320px" />
                            </asp:TemplateField>
                            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                        </Columns>
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <RowStyle BackColor="#EFF3FB" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle BackColor="#2461BF" />
                        <AlternatingRowStyle BackColor="White" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Button ID="buttonCopy" runat="server" Text="����" ToolTip="���Ƶ�ǰ��������,�����±���" CausesValidation="False"
                        OnClick="buttonCopy_Click" /></td>
                <td align="center">
                    <asp:Button ID="buttonSave" runat="server" Text="�ύ" OnClick="buttonSave_Click" OnClientClick="if(textBoxName.value.length==0){alert('�������Ʋ���Ϊ��');textBoxName.focus();return false;} if(textBoxSortIndex.value.length==0){alert('��ʾ˳����Ϊ��,������ΪĬ��ֵ99');textBoxSortIndex.value='99';textBoxSortIndex.focus();return false;}"
                        CausesValidation="False" />
                    <asp:Button ID="buttonDelete" runat="server" Text="ɾ��" CausesValidation="False" OnClick="buttonDelete_Click"
                        OnClientClick="if(confirm('���Ҫɾ��������ɾ���󽫲��ɻָ�')) {return true;}else{return false;}" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
