<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SA_View.aspx.cs" Inherits="Tools_AddinForERP_CAR_SA_View" %>
<%@ Register Assembly="CuteEditor" Namespace="CuteEditor" TagPrefix="CE" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
     <title>客户投诉－－查看/审批页面</title>
    <link href="CSS/Style.css" type="text/css" rel="stylesheet"/>
    <script language="javascript" type="text/javascript" src="images/JS/My97DatePicker/WdatePicker.js"></script> 
    <meta http-equiv="pragma" content="no-cache" />
    <base target="_self" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="top">
        不良品确认 查看/审批页面</div>
    <div><hr /></div>
    <div id="Div1" runat="server" >

                <div style=" text-align:left">编号：&nbsp;<asp:TextBox ID="Serial_No" runat="server" Text="" ReadOnly="true" ></asp:TextBox></div>
                <table cellspacing="0" cellpadding="0" width="100%" class="TbsWhl">
                    <tr>
                        <td colspan="4" class="FieldTop" style="width: 100%" >
                        处理结果</td>
                    </tr>
                </table>

                <div style="OVERFLOW:auto;WIDTH:100%;HEIGHT:305px;border:1px solid #335D55;" >
                <asp:GridView ID="GridView3" Width="2000" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:TemplateField HeaderText="NO">
                            <ItemTemplate>
                                <asp:TextBox ID="tb_NO" ReadOnly="true" Text=<%#Container.DataItemIndex + 1%>  runat="server" BorderWidth="0px" Width="100%" ></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle Width="25px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="记录日期">
                            <ItemTemplate>
                                <asp:TextBox ID="tb_recordDateTime" ReadOnly="true" runat="server" BorderWidth="0px" Width="100%" Text=<%# Eval("recordDateTime") %> ></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle Width="110px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="代码">
                            <ItemTemplate>
                                <asp:TextBox ID="tb_custCode" ReadOnly="true" runat="server" BorderWidth="0px" Width="100%" Text=<%# Eval("custCode") %> ></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle Width="40px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="客户">
                            <ItemTemplate>
                                <asp:TextBox ID="tb_custName" ReadOnly="true" runat="server" BorderWidth="0px" Width="100%" Text=<%# Eval("custName") %>></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle Width="160px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Founder料号">
                            <ItemTemplate>
                                <asp:TextBox ID="tb_founderMaterilNo" ReadOnly="true" runat="server" BorderWidth="0px" Width="100%" Text=<%# Eval("founderMaterilNo") %>></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle Width="80px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="客户料号机种">
                            <ItemTemplate>
                                <asp:TextBox ID="tb_custPartNo" ReadOnly="true" runat="server" BorderWidth="0px" Width="100%" Text=<%# Eval("custPartNo") %>></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle Width="160px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="周期D/C">
                            <ItemTemplate>
                                <asp:TextBox ID="tb_cycleValue" ReadOnly="true" runat="server" BorderWidth="0px" Width="100%" Text=<%# Eval("cycleValue") %>></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle Width="80px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="上件点">
                            <ItemTemplate>
                                <asp:TextBox ID="tb_happenAddress" ReadOnly="true" runat="server" BorderWidth="0px" Width="100%" Text=<%# Eval("happenAddress") %>></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle Width="150px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="LOT">
                            <ItemTemplate>
                                <asp:TextBox ID="tb_LOT" ReadOnly="true" runat="server" BorderWidth="0px" Width="100%" Text=<%# Eval("LOT") %>></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle Width="80px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ET章">
                            <ItemTemplate>
                                <asp:TextBox ID="tb_ET" ReadOnly="true" runat="server" BorderWidth="0px" Width="100%" Text=<%# Eval("ET") %>></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle Width="80px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="T章">
                            <ItemTemplate>
                                <asp:TextBox ID="tb_T" ReadOnly="true" runat="server" BorderWidth="0px" Width="100%" Text=<%# Eval("T") %>></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle Width="80px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="不良原因">
                            <ItemTemplate>
                                <asp:TextBox ID="tb_reason" ReadOnly="true" runat="server" BorderWidth="0px" Width="100%"  Text=<%# Eval("reason") %>></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle Width="120px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="板子种类">
                            <ItemTemplate>
                                <asp:TextBox ID="tb_mateialType" ReadOnly="true" runat="server" BorderWidth="0px" Width="100%"  Text=<%# Eval("mateialType") %>></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle Width="110px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="处理结果" Visible="false">
                            <ItemTemplate>
                                <asp:TextBox ID="tb_results" ReadOnly="true" runat="server" BorderWidth="0px" Width="100%"  Text=<%# Eval("results") %>></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle Width="90px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="数量" >
                            <ItemTemplate>
                                <asp:TextBox ID="tb_quantity" ReadOnly="true" runat="server" BorderWidth="0px" Width="100%" Text=<%# Eval("quantity") %> onblur="checkQty(this)"></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle Width="80px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="签单日期">
                            <ItemTemplate>
                                <asp:TextBox ID="tb_signDate" ReadOnly="true" runat="server" BorderWidth="0px" Width="100%" Text=<%# Eval("signDate") %> ></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle Width="110px" />
                        </asp:TemplateField>
                        <asp:TemplateField  HeaderText="签单人">
                            <ItemTemplate>
                                <asp:TextBox ID="tb_signingPerson" ReadOnly="true" runat="server" BorderWidth="0px" Width="100%" Text=<%# Eval("signingPerson") %>></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle Width="80px" />
                        </asp:TemplateField>
                        <asp:TemplateField  HeaderText="责任厂别">
                            <ItemTemplate>
                                <asp:TextBox ID="tb_factoryName" ReadOnly="true" runat="server" BorderWidth="0px" Width="100%"  Text=<%# Eval("factoryName") %>></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle Width="80px" />
                        </asp:TemplateField>
                        <asp:TemplateField  HeaderText="折让单价(USD)">
                            <ItemTemplate>
                                <asp:TextBox ID="tb_discountPrice" ReadOnly="true" runat="server" BorderWidth="0px" Width="100%" Text=<%# Eval("discountPrice") %> onblur="checkQty(this)"></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle Width="80px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="折让金额(USD)">
                            <ItemTemplate>
                                <asp:TextBox ID="tb_discountAmount" ReadOnly="true" runat="server" BorderWidth="0px" Width="100%" Text=<%# Eval("discountAmount") %> onblur="checkQty(this)"></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle Width="80px" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
                 <br />

                <div id="div_center" runat="server">
                    <table cellspacing="0" cellpadding="0" width="100%" class="TbsWhl">
                        <tr>
                            <td colspan="4" class="FieldTop" >
                                描述</td>
                        </tr>
                        <tr>
                            <td class="FieldTitle" style="width: 6%">
                                备注</td>
                            <td class="FieldText" colspan="3">
                                <CE:Editor ID="CAR_Content" runat="server" AutoConfigure="Minimal" SecurityPolicyFile="Guest.config" Height="200px" Width="740px">
                                    <FrameStyle BackColor="White" BorderColor="#DDDDDD" BorderStyle="Solid" BorderWidth="1px"
                                    CssClass="CuteEditorFrame" Height="100%" Width="100%" />
                                </CE:Editor>
                            </td>       
                        </tr>  

                    </table>
                </div>

        <br />
    <div id="div_sp" runat="server">
    <table cellspacing="0" cellpadding="0" width="100%" class="TbsWhl">
        <tr>
            <td colspan="4" class="FieldTop" >审批记事本</td>
        </tr>
        <tr>
            <td class="FieldTitle" style="width: 6%">
            记事本</td>
            <td class="FieldText" colspan="3">
            <asp:TextBox ID="SP_Content" runat="server" Rows="3" TextMode="MultiLine" Width="603px"></asp:TextBox>        
           </td>       
        </tr>  
    </table>&nbsp;
    <div style="text-align:center;"><asp:ImageButton ID="button_shenpi_yes" runat="server" ImageUrl="Images/button_shenpi_yes.gif" OnClick="button_shenpi_yes_Click"   />&nbsp;&nbsp;&nbsp;&nbsp;<asp:ImageButton ID="button_shenpi_no" runat="server" ImageUrl="Images/button_shenpi_no.gif" OnClick="button_shenpi_no_Click"   /></div> 
    </div>
    </div>
    </form>
</body>
</html>
