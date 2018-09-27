<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Base_SetUserRight.aspx.cs" Inherits="SetUserRight" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>权限设置</title>
    <script language="javascript" type="text/javascript">
        function SelectAll(sa)
        {
            ///全选/全消
            var objCheckBox;
            for(var i=0;i<form1.length;i++)
            {
                if(form1.elements[i].type=="checkbox")
                {
                    objCheckBox=form1.elements[i];
                    objCheckBox.checked=sa;
                }
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align:center">
        <table>
            <tr style="background-color:#507CD1">
                <td style="font-size:12px; width:80px;border-bottom-color:#507CD1">
                    域帐号:
                </td>
                <td style="font-size:12px; width:148px; border-bottom-color:#507CD1">
                    <asp:DropDownList ID="ddl_UserAD" runat="server" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="ddl_UserAD_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:TextBox ID="tb_UserAD" runat="server" Width="90%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Font-Size="11px" ShowHeader="false" AutoGenerateColumns="false" OnRowDataBound="GridView1_RowDataBound" ShowFooter="true">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Label ID="lbl_RightName" runat="server"  Text=<%# Eval("rightName") %>></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="80px" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:CheckBox ID="ckb_Right" runat="server" />
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:CheckBox ID="ckb_Footer" runat="server" onclick="SelectAll(this.checked)" />
                                </FooterTemplate>
                                <ItemStyle Width="150px" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:HiddenField ID="hdf_Index" Value=<%# Eval("index") %> runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <RowStyle BackColor="#EFF3FB" Height="18px" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle BackColor="#2461BF" />
                        <AlternatingRowStyle BackColor="White" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="font-size:12px;">
                    <asp:Button ID="btn_Add" runat="server" Text="新增用户" OnClick="btn_Add_Click" />
                    <asp:Button ID="btn_Update" runat="server" Text="修改已有用户" OnClick="btn_Update_Click" Width="89px" />
                    <asp:Button ID="btn_Submit" runat="server" Text="提交" OnClick="btn_Submit_Click" Width="63px" />
                    <asp:Button ID="btn_Delete" runat="server" Text="删除" OnClick="btn_Delete_Click" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
