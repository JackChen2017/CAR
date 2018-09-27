<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QSMReport.aspx.cs" Inherits="QSMReport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>客户投诉信息表</title>
    <script language="javascript" type="text/javascript" src="images/JS/My97DatePicker/WdatePicker.js"></script> 
    <script language="javascript" type="text/javascript">
     function linkFrames(link1)
     {
        //window.open(link1,"","","");
        window.showModalDialog(link1,"","dialogHeight:390px;dialogWidth:790px");
        //window.open(link1);
     }
     function Show(link1)
     {
        //window.open(link1,"","","");
        window.showModalDialog(link1,"","dialogHeight:300px;dialogWidth:600px");
     }
     </script>
</head>
<body>
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
                            <tr style="width:100%">
                                <td style=" font-size:12px; width: 54px;">
                                    客户名称:</td>
                                <td style=" font-size:12px; width: 154px;">
                                    <asp:TextBox ID="tb_CustName" runat="server"></asp:TextBox>
                                </td>
                                <td style=" font-size:12px; width: 59px;">
                                    录入日期:</td>
                                <td style=" font-size:12px; width: 120px;">
                                    <asp:TextBox ID="tb_DateStart" runat="server" Width="119px" class="Wdate" onfocus="new WdatePicker(this,null,false,'whyGreen')"></asp:TextBox>
                                </td>
                                <td style=" font-size:12px; width:20px">至</td>
                                <td style=" font-size:12px; width: 117px;">
                                    <asp:TextBox ID="tb_DateEnd" runat="server" Width="119px" class="Wdate" onfocus="new WdatePicker(this,null,false,'whyGreen')"></asp:TextBox>
                                </td>
                                <td style=" font-size:12px; width: 104px;">
                                    <asp:Button ID="btn_Query" runat="server" Text="查询" Width="103px" OnClick="btn_Query_Click" />
                                </td>
                                <td style="width:auto; font-size:12px; text-align:center">
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
                        <asp:GridView ID="GridView1" runat="server" Width="3200px" AutoGenerateColumns="False" Font-Size="12px" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDataBound="GridView1_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="序号">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1%> 
                                    </ItemTemplate>
                                    <ItemStyle Width="30px" />
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="客户投诉书编号" DataField="serialNo" >
                                    <HeaderStyle Width="110px" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="状态" >
                                    <ItemStyle Width="60px" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="要求回复日期" >
                                    <HeaderStyle Width="100px" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="投诉等级" DataField="tousu_level" >
                                    <HeaderStyle Width="80px" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="投诉类型" DataField="tousu_type">
                                    <HeaderStyle Width="80px" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="客户" DataField="cust_name">
                                    <HeaderStyle Width="200px" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="责任单位" DataField="factory_name">
                                    <HeaderStyle Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="生产部件料号" DataField="interalNo">
                                    <HeaderStyle Width="150px" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="客户料号" DataField="cust_materialNo">
                                    <HeaderStyle Width="250px" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="投诉内容" >
                                    <HeaderStyle Width="1200px" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="问题描述">
                                    <ItemTemplate>
                                        <a href="javascript:void(0)"  onclick="linkFrames('Base_Container.aspx?type=QSM&FID=<%= CurrentFactoryID.ToString() %>&rkey=<%#DataBinder.Eval(Container.DataItem,"rkey") %>&id=1')">查看</a>
                                    </ItemTemplate>
                                    <ItemStyle Width="50px" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="处理状况" >
                                    <HeaderStyle Width="600px" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="调查与改善报告">
                                    <ItemTemplate>
                                        <a href="javascript:void(0)"  onclick="linkFrames('Base_Container.aspx?type=QSM&FID=<%= CurrentFactoryID.ToString() %>&rkey=<%#DataBinder.Eval(Container.DataItem,"rkey") %>&id=2')">查看</a>
                                    </ItemTemplate>
                                    <ItemStyle Width="80px"  HorizontalAlign="Center"/>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="改善报告最终回复日期" >
                                    <HeaderStyle Width="150px" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="中央客服关闭日期" >
                                    <HeaderStyle Width="120px" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="效果确认">
                                    <ItemTemplate>
                                        <a href="javascript:void(0)"  onclick="linkFrames('Base_Container.aspx?type=QSM&FID=<%= CurrentFactoryID.ToString() %>&rkey=<%#DataBinder.Eval(Container.DataItem,"rkey") %>&id=3')">查看</a>
                                    </ItemTemplate>
                                    <ItemStyle Width="50px" HorizontalAlign="Center"/>
                                </asp:TemplateField>
                            </Columns>
                            <RowStyle Height="20px" BackColor="#EFF3FB" />
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
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
