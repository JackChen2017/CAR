<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HSF_View.aspx.cs" Inherits="HSF_Show" %>
<%@ Register Assembly="CuteEditor" Namespace="CuteEditor" TagPrefix="CE" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>HSF 查看/审批页面</title>
    <%--<link href="CSS/Style.css" type="text/css" rel="stylesheet"/>--%>
    <%--<script language="javascript" type="text/javascript" src="images/JS/My97DatePicker/WdatePicker.js"></script>
    <script language="javascript" type="text/javascript">
    function ChangeCheck(me)
    {
        var $=document.all;
        var temp = me.id.substring(0,me.id.length - 1);
        for(var i=1;i<= 10;i++)
        {
            if(i == me.id.substring(me.id.length-1))
            {
                $[temp+i].checked = true;
                continue;
            }
            try
            {
                $[temp+i].checked = false;
            }
            catch(e)
            {}
        }
        if(me.id == "SOP_Status_1")
        {
            $["SOP_Name"].value = "";
            $["SOP_Name"].disabled = true;
        }
        else if(me.id == "SOP_Status_2")
        {
            $["SOP_Name"].disabled = false;
        }
    }
    </script>--%>
    <meta http-equiv="pragma" content="no-cache" />
    <base target="_self" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="top">HSF异常处理通知单 查看/审批页面</div>
     <div><hr /></div><div>
   <table cellspacing="0" cellpadding="0" width="100%" class="TbsWhl">
<tr><td>
<table cellspacing="0" cellpadding="0" width="100%" class="TbsWhl" style="height: 1680px">
<tr><td colspan="4" class="FieldTop" >基本信息</td></tr>
    <tr>
        <td class="FieldTitle" style="width: 17%">
             发生日期</td>
        <td class="FieldText" colspan="1">
            <asp:TextBox ID="happen_date" runat="server" Text="" class="Wdate" onfocus="new WdatePicker(this,null,false,'whyGreen')"></asp:TextBox></td>
        <td class="FieldTitle" style="height: 20px" >
            报告者</td>
        <td class="FieldText"  colspan="1">
        <asp:TextBox ID="Issued_User" runat="server"></asp:TextBox>
         </td>
    </tr>
    <tr>
        <td class="FieldTitle" style="width: 17%">
             要求回复日期</td>
        <td class="FieldText">
            <asp:TextBox ID="Required_Date" runat="server" Text="" class="Wdate" onfocus="new WdatePicker(this,null,false,'whyGreen')"></asp:TextBox></td>
        <td class="FieldTitle">
           异常料号/名称</td>
        <td class="FieldText">
            <asp:TextBox ID="CAR_Part_Num" runat="server"></asp:TextBox></td>
    </tr>
        <tr>
        <td class="FieldTitle" style="height: 20px; width: 17%;" >
            发出单位</td>
        <td class="FieldText" style="height: 20px">
        <asp:DropDownList ID="From_Comp" runat="server">
            </asp:DropDownList>
         </td>
           <td class="FieldTitle" style="height: 20px">
            异常单位</td>
        <td class="FieldText" style="height: 20px">
            <asp:DropDownList ID="CAR_Comp" runat="server">
            </asp:DropDownList></td>
       </tr>
    <tr>
        <td class="FieldTitle" style="width: 17%">
     异常发生类别</td>
        <td class="FieldText" colspan="1">
            <asp:CheckBox ID="HSF_Happen_Type_1" runat="server"  Text="制品" onclick="ChangeCheck(this)"/>&nbsp;&nbsp;
            <asp:CheckBox ID="HSF_Happen_Type_2" runat="server" Text="制程"  onclick="ChangeCheck(this)"/>&nbsp;&nbsp;
            <asp:CheckBox ID="HSF_Happen_Type_3" runat="server"  Text="外包" onclick="ChangeCheck(this)"/>&nbsp;&nbsp;
            <asp:CheckBox ID="HSF_Happen_Type_4" runat="server"  Text="原物料" onclick="ChangeCheck(this)" />&nbsp;&nbsp;
            <asp:CheckBox ID="HSF_Happen_Type_5" runat="server" Text="其他" onclick="ChangeCheck(this)"/></td>
        <td class="FieldTitle" style="height: 20px" >
            编号:</td>
        <td class="FieldText"  colspan="1">
        <asp:TextBox ID="Serial_No" runat="server" Text="" ></asp:TextBox>
         </td>
    </tr>
    <tr>
        <td class="FieldTitle" style="height: 20px; width: 17%;" >
            主管</td>
        <td class="FieldText"  colspan="1">
        <asp:TextBox ID="Issued_APP" runat="server"></asp:TextBox>
         </td>
        <td class="FieldTitle" style="height: 20px" >
            签收者</td>
        <td class="FieldText"  colspan="1">
        <asp:TextBox ID="Received_User" runat="server"></asp:TextBox>
         </td>
    </tr>
<tr>
 <td class="FieldTitle" style="width: 17%" >
            问题描述：</td>
        <td class="FieldText" colspan="3">
            <CE:Editor ID="CAR_Content" runat="server" AutoConfigure="Minimal" SecurityPolicyFile="Guest.config" Height="160px">
                <FrameStyle BackColor="White" BorderColor="#DDDDDD" BorderStyle="Solid" BorderWidth="1px"
                    CssClass="CuteEditorFrame" Height="100%" Width="100%" />
            </CE:Editor>
           </td>
</tr>   
<tr>
 <td class="FieldTitle" style="width: 17%" >
            异常数据：</td>
        <td class="FieldText" colspan="3">
            LOT别：<asp:TextBox ID="LOT" CssClass="txtbox" runat="server"></asp:TextBox>；
            批量：<asp:TextBox ID="batch" CssClass="txtbox" runat="server"></asp:TextBox>PNL/pcs；
            不良数：<asp:TextBox ID="badness_Num" CssClass="txtbox" runat="server"></asp:TextBox>PNL/pcs；<br />
            不良处理状况：&nbsp;&nbsp;重工：<asp:TextBox ID="ReWork" CssClass="txtbox" runat="server"></asp:TextBox>PNL/pcs；
            报废：<asp:TextBox ID="Reject" CssClass="txtbox" runat="server"></asp:TextBox>；
            不处理下送：<asp:TextBox ID="NoWork" CssClass="txtbox" runat="server"></asp:TextBox>PNL/pcs；
           </td>
</tr> 
                        <tr>
                            <td class="FieldTitle" style="width: 17%" rowspan="2" >造成原因：</td>
                            <td class="FieldText" colspan="4">
                                原因归属:
                                <asp:CheckBox ID="Info_Type_1" Text="人员" runat="server" />
                                <asp:CheckBox ID="Info_Type_2" Text="机台" runat="server" />
                                <asp:CheckBox ID="Info_Type_3" Text="物料" runat="server" />
                                <asp:CheckBox ID="Info_Type_4" Text="方法" runat="server" />
                                <asp:CheckBox ID="Info_Type_5" Text="环境" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="FieldText" colspan="4">
                                <CE:Editor ID="Info_Content" runat="server" AutoConfigure="Minimal" SecurityPolicyFile="Guest.config" Height="240px">
                                    <FrameStyle BackColor="White" BorderColor="#DDDDDD" BorderStyle="Solid" BorderWidth="1px"
                                        CssClass="CuteEditorFrame" Height="100%" Width="100%" />
                                </CE:Editor>
                            </td>
                        </tr>
                        <tr>
                            <td class="FieldTitle" style="width: 17%" rowspan="2">应急对策</td>
                            <td class="FieldText" colspan="3">
                                <CE:Editor ID="Interim_Action" runat="server" AutoConfigure="Minimal" SecurityPolicyFile="Guest.config" Height="200px" Width="740px">
                                    <FrameStyle BackColor="White" BorderColor="#DDDDDD" BorderStyle="Solid" BorderWidth="1px"
                                        CssClass="CuteEditorFrame" Height="100%" Width="100%" />
                                </CE:Editor>
                           </td>
                        </tr>
                        <tr>
                            <td class="FieldText" colspan="3">
                                主管:<asp:TextBox ID="IA_APP" runat="server" Width="80px" CssClass="txtbox" ></asp:TextBox>
                                下对策者:<asp:TextBox ID="IA_User" runat="server" Width="80px" CssClass="txtbox" ></asp:TextBox>
                                改善时间:<asp:TextBox ID="IA_Date" runat="server" Width="80px" CssClass="txtbox" class="Wdate" onfocus="new WdatePicker(this,null,false,'whyGreen')"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="FieldTitle" style="width: 17%" rowspan="2">永久对策</td>
                            <td class="FieldText" colspan="3">
                                <CE:Editor ID="IPCA" runat="server" AutoConfigure="Minimal" SecurityPolicyFile="Guest.config" Height="200px" Width="740px">
                                    <FrameStyle BackColor="White" BorderColor="#DDDDDD" BorderStyle="Solid" BorderWidth="1px"
                                        CssClass="CuteEditorFrame" Height="100%" Width="100%" />
                                </CE:Editor>
                           </td>
                        </tr>
                        <tr>
                            <td class="FieldText" colspan="3">
                                主管:<asp:TextBox ID="IPCA_APP" runat="server" Width="80px" CssClass="txtbox" ></asp:TextBox>
                                下对策者:<asp:TextBox ID="IPCA_User" runat="server" Width="80px" CssClass="txtbox" ></asp:TextBox>
                                改善时间:<asp:TextBox ID="IPCA_Date" runat="server" Width="80px" CssClass="txtbox" class="Wdate" onfocus="new WdatePicker(this,null,false,'whyGreen')"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="FieldTitle" style="width: 17%">水平展开</td>
                            <td class="FieldText" colspan="3">
                                <asp:TextBox ID="Levels" runat="server" Width="100%" Height="56px"></asp:TextBox>
                           </td>
                        </tr> 
                        <tr>
                            <td class="FieldTitle" style="width: 17%">标准化</td>
                            <td class="FieldText" colspan="3">
                                是否修改SOP &nbsp;
                                <asp:CheckBox ID="SOP_Status_1" Text="否" runat="server" onclick="ChangeCheck(this)" />
                                           <asp:CheckBox ID="SOP_Status_2" Text="是" runat="server" onclick="ChangeCheck(this)" />&nbsp; &nbsp;
                                &nbsp; &nbsp;原因:<asp:TextBox ID="SOP_Content" runat="server" CssClass="txtbox"></asp:TextBox>
                                SOP编号:<asp:TextBox ID="SOP_Name" runat="server" Width="116px" CssClass="txtbox"></asp:TextBox>
                                <br />
                                完成日期:<asp:TextBox ID="SOP_Date" runat="server" CssClass="txtbox"></asp:TextBox>
                           </td>
                        </tr>  
                        <tr>
                            <td class="FieldTitle" style="width: 17%">会签栏</td>
                            <td class="FieldText" colspan="3">
                                <asp:TextBox ID="Together_Write" runat="server" Width="100%" Height="66px"></asp:TextBox>
                           </td>
                        </tr> 
</table>
&nbsp;
<div id="div_center" runat="server">
    <table cellspacing="0" cellpadding="0" width="100%" class="TbsWhl">
    <tr>
   <td colspan="4" class="FieldTop" >
       效果确认</td>
   </tr>
    <tr>
        <td class="FieldTitle" style="width: 7%" rowspan="2">
     效果确认</td>
     <td style="height: 20px">
        <asp:CheckBox ID="CONF_Status_1" runat="server" Text="未改善"  onclick="ChangeCheck(this)"/>
        <asp:CheckBox ID="CONF_Status_2" runat="server" Text="改善进行中" onclick="ChangeCheck(this)" />
        <asp:CheckBox ID="CONF_Status_3" runat="server" Text="改善完成" onclick="ChangeCheck(this)" />
     </td>
   </tr>
   <tr>
        <td class="FieldText" colspan="3">
        <CE:Editor ID="CONF_Content" runat="server" AutoConfigure="Minimal" SecurityPolicyFile="Guest.config" Height="200px" Width="740px">
                <FrameStyle BackColor="White" BorderColor="#DDDDDD" BorderStyle="Solid" BorderWidth="1px"
                    CssClass="CuteEditorFrame" Height="100%" Width="100%" />
            </CE:Editor>
           </td>       
    </tr>  
    
</table>
</div>
</td></tr></table> <br />
<div id="div_sp" runat="server">
<table cellspacing="0" cellpadding="0" width="100%" class="TbsWhl">
    <tr>
   <td colspan="4" class="FieldTop" >审批记事本</td>
   </tr>
    <tr>
        <td class="FieldTitle" style="width: 7%">
     记事本</td>
        <td class="FieldText" colspan="3">
        <asp:TextBox ID="SP_Content" runat="server" Rows="3" TextMode="MultiLine" Width="604px"></asp:TextBox>        
           </td>       
    </tr>  
    
</table>
<div style="text-align:center;"><asp:ImageButton ID="button_shenpi_yes" runat="server" ImageUrl="Images/button_shenpi_yes.gif" OnClick="button_shenpi_yes_Click"   />&nbsp;&nbsp;&nbsp;&nbsp;<asp:ImageButton ID="button_shenpi_no" runat="server" ImageUrl="Images/button_shenpi_no.gif" OnClick="button_shenpi_no_Click"   /></div> 
</div>
    </form>
</body>
</html>
