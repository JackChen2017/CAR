<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InputSQLForm.aspx.cs" Inherits="Tools_SQLReport_InputSQLForm" %>

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
<body  style="text-align: center; width:100%">
    <form id="form1" runat="server">
        <div style="text-align: left;">
            <asp:LinkButton ID="LinkButton1" PostBackUrl="" runat="server" Text="��������" OnClick="LinkButton1_Click" />
        </div>
        <br />
        <table cellspacing="0" rules="all" border="1" id="ctl00_ContentPlaceHolder1_DetailsView1"
            style="text-align: right; height: 50px; width: 637px; border-collapse: collapse;">
            <caption>
                <asp:Label ID="labelTitle" runat="server" Text="������ѯ����" Font-Bold="True"></asp:Label>
            </caption>
            <tr>
                <td style="width: 112px">
                    ��������</td>
                <td align="left">
                    <asp:TextBox ID="textBoxReportName" runat="server" Width="504px"></asp:TextBox></td>
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
                        Style="ime-mode: Disabled" Text="1000" Width="30px"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox
                            ID="checkBoxIsLimited" runat="server" Checked="true" Text="����3000������" ToolTip="��Ǳ�Ҫ,�벻Ҫ�رմ�ѡ��" />
                </td>
            </tr>
            <tr style="display: none;">
                <td style="width: 112px">
                    ����ģ��</td>
                <td align="left">
                    <asp:CheckBoxList ID="checkBoxListReportCate" runat="server" RepeatColumns="9" RepeatDirection="Horizontal">
                    </asp:CheckBoxList>
                </td>
            </tr>
            <tr>
                <td style="width: 112px; height: 26px;">
                    SQL��䣺</td>
                <td align="left" style="height: 26px">
                    <asp:TextBox ID="textBoxSQLCommand" runat="server" Width="504px" Height="106px" TextMode="MultiLine"></asp:TextBox>&nbsp;
                </td>
            </tr>
            <tr>
                <td style="width: 112px">
                    ��ѯ����</td>
                <td align="left">
                    <asp:TextBox ID="textBoxSQLSQLWhere" runat="server" Width="504px" Height="56px" TextMode="MultiLine"></asp:TextBox>
                    <asp:Label ID="Label2" runat="server" Text="˵���� �˴�������Ϊ���Ա��û��滻���������    ��ʽ�� �����ֶ�1=X ..."
                        ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 112px">
                    ����ʽ</td>
                <td align="left">
                    <asp:TextBox ID="textBoxSQLOrder" runat="server" Width="504px" TextMode="MultiLine"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 112px">
                    �����ֶ�</td>
                <td align="left">
                    <asp:TextBox ID="textBoxSpecialField" runat="server" Width="504px" TextMode="MultiLine"></asp:TextBox>
                    <asp:Label ID="Label3" runat="server" Text="˵���� ��Ҫ������Ȩ���ֶ���������(�ֶ�֮���Զ��ŷָ�)     ��ʽ�� �����ֶ�1,�����ֶ�2..."
                        ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 112px">
                    �����ֶ�</td>
                <td align="left">
                    <asp:TextBox ID="textBoxCalculateField" runat="server" Width="504px" TextMode="MultiLine"></asp:TextBox>
                    <asp:Label ID="Label1" runat="server" Text="˵���� ��Ҫ���л��ܼ�����ֶ�(�ֶ�֮���Զ��ŷָ�)    ��ʽ�� �����ֶ�1,�����ֶ�2..."
                        ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 112px">
                    ��ʾҳ��</td>
                <td align="left">
                    <asp:TextBox ID="textBoxShowURL" runat="server" Width="504px" TextMode="MultiLine"></asp:TextBox>
                    <asp:Label ID="Label4" runat="server" Text="˵���� ���ֶο���Ϊ�գ�������ҳ����ʾ���ڴ�¼��ҳ���ַ" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 112px">
                    ����ע</td>
                <td align="left">
                    <asp:TextBox ID="textBoxComment" runat="server" Width="504px" TextMode="MultiLine"
                        Text="�˲�ѯһ�������ʾ3000����¼����������ݿ������ò�ѯ������ȡ"></asp:TextBox>
                    <asp:Label ID="Label5" runat="server" Text="˵���� ��ʾ�ڱ�����ʾ����������" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 112px">
                    ����״̬</td>
                <td align="left">
                    <asp:RadioButtonList ID="radioButtonListReportStatus" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Value="0" Selected="True" title="[����] ����ʹ�õı���">����</asp:ListItem>
                        <asp:ListItem Value="1" title="[ͣ��] ��ͨ�û����ɼ�,������Ա���Կ�">ͣ��</asp:ListItem>
                        <asp:ListItem Value="2" title="[����] ͬ[����]�ҹ���ƽ̨�ɼ�">����</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td style="width: 112px">
                    ���⹦��</td>
                <td align="left">
                    <asp:RadioButtonList ID="radioButtonListFucCode" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Value="0" Selected="True">����</asp:ListItem>
                        <asp:ListItem Value="1">ȡ�����������ظ����ʾ</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Button ID="buttonCopy" runat="server" Text="����" ToolTip="���Ƶ�ǰ��������,�����±���" CausesValidation="False"
                        OnClick="buttonCopy_Click" /></td>
                <td align="center">
                    <asp:Button ID="buttonSave" runat="server" Text="�ύ" OnClick="buttonSave_Click" OnClientClick="if(textBoxReportName.value.length==0){alert('�������Ʋ���Ϊ��');textBoxReportName.focus();return false;} if(textBoxSortIndex.value.length==0){alert('��ʾ˳����Ϊ��,������ΪĬ��ֵ99');textBoxSortIndex.value='99';textBoxSortIndex.focus();return false;}"
                        CausesValidation="False" />
                    <asp:Button ID="buttonDelete" runat="server" Text="ɾ��" CausesValidation="False" OnClick="buttonDelete_Click"
                        OnClientClick="if(confirm('���Ҫɾ��������ɾ���󽫲��ɻָ�')) {return true;}else{return false;}" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
