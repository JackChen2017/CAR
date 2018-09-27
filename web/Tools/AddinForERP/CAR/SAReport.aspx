<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SAReport.aspx.cs" Inherits="SAReport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body style="font-size: 12pt">
    <form id="form1" runat="server">
    <div>
        <table width="100%">
            <tr>
                <td style="width: 100%; text-align:center;">
                    <span style="font-size: 16pt; text-align: center">客户投诉信息表</span>
                </td>
            </tr>
            <tr>
                <td>
                    <fieldset>
                        <table width="100%">
                            <tr>
                                <td style=" font-size:12px; width: 54px;">
                                    客户名称:</td>
                                <td style=" font-size:12px; width: 154px;">
                                    <asp:TextBox ID="tb_CustName" runat="server"></asp:TextBox>
                                </td>
                                <td style=" font-size:12px; width: 59px;">
                                    录入日期:</td>
                                <td style=" font-size:12px; width: 120px;">
                                    <asp:TextBox ID="tb_DateStart" runat="server" Width="119px"></asp:TextBox>
                                </td>
                                <td style=" font-size:12px;">至</td>
                                <td style=" font-size:12px; width: 117px;">
                                    <asp:TextBox ID="tb_DateEnd" runat="server" Width="119px"></asp:TextBox>
                                </td>
                                <td style=" font-size:12px; width: 104px;">
                                    <asp:Button ID="btn_Query" runat="server" Text="查询" Width="103px" />
                                </td>
                                <td style=" font-size:12px; width: 30px; text-align:center">
                                    &nbsp;</td>
                                <td style="width: 226px; font-size:13px">
                                    <asp:LinkButton ID="lkbtn_ToExcel" runat="server" Text="导出" Width="40px" OnClick="lkbtn_ToExcel_Click"></asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </td>
            </tr>
            <tr>
                <td>
                    <div style="width:955px; height:425px; overflow:auto">
                        <asp:GridView ID="GridView1" Font-Size="12px" Width="1500px" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDataBound="GridView1_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="序号">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1%> 
                                    </ItemTemplate>
                                    <ItemStyle Width="30px" />
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="编号" DataField="serialNo" >
                                    <ItemStyle Width="100px" HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="状态"  >
                                    <ItemStyle Width="80px" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="记录日期"  >
                                    <ItemStyle Width="70px" HorizontalAlign="Center"/>
                                </asp:BoundField>
                                <asp:BoundField HeaderText="客户" DataField="custName" >
                                    <ItemStyle Width="200px"/>
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Founder料号" DataField="founderMaterilNo" >
                                    <ItemStyle Width="120px" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="客户料号机种" DataField="custPartNo" >
                                    <ItemStyle Width="250px" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="周期 D/C" DataField="cycleValue" >
                                    <ItemStyle Width="60px" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="上件点" DataField="happenAddress" >
                                    <ItemStyle Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Lot" DataField="LOT" >
                                    <ItemStyle Width="50px" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="ET章" DataField="ET" >
                                    <ItemStyle Width="50px" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="F章" DataField="T" >
                                    <ItemStyle Width="50px" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="不良原因" DataField="reason" >
                                    <ItemStyle Width="70px" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="板子种类" DataField="mateialType" >
                                    <ItemStyle Width="70px" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="数量" DataField="quantity" >
                                    <ItemStyle Width="70px" HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="签单日期" >
                                    <ItemStyle Width="70px" HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="签单人" DataField="signingPerson" >
                                    <ItemStyle Width="70px" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="责任厂别" DataField="factoryName" >
                                    <ItemStyle Width="80px" />
                                </asp:BoundField>
                            </Columns>
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <RowStyle BackColor="#EFF3FB" Height="20px" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <EditRowStyle BackColor="#2461BF" />
                            <AlternatingRowStyle BackColor="White" />
                        </asp:GridView>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
