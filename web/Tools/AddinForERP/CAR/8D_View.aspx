<%@ Page Language="C#" AutoEventWireup="true" CodeFile="8D_View.aspx.cs" Inherits="_8D_View" %>

<%@ Register Assembly="CuteEditor" Namespace="CuteEditor" TagPrefix="CE" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>8D 查看/审批页面</title>
    <link href="CSS/Style.css" type="text/css" rel="stylesheet"/>
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
        if(me.id == "SOP_Status_ck_1")
        {
            $["SOP_Name"].value = "";
            $["SOP_Name"].disabled = true;
        }
        else if(me.id == "SOP_Status_ck_2")
        {
            $["SOP_Name"].disabled = false;
        }
    }
    </script>
    <meta http-equiv="pragma" content="no-cache" />
    <base target="_self" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="top">（8D）CORRECTIVE ACTION REPORT  查看/审批页面</div>
     <table cellspacing="0" cellpadding="0" width="100%" class="TbsWhl">
            <tr>
                <td>
                    <table cellspacing="0" cellpadding="0" width="100%" class="TbsWhl">
                        <tr>
                            <td colspan="5" class="FieldTop" >基本信息</td>
                        </tr>
                        <tr>
                            <td class="FieldTitle">
                                要求回复日期</td>
                            <td class="FieldText" colspan="2">
                                <asp:TextBox ID="Required_Date" runat="server" Text="" ></asp:TextBox></td>
                            <td class="FieldTitle">
                                编号(类型)</td>
                            <td class="FieldText">
                                <asp:TextBox ID="Serial_No" runat="server" Text="" ></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="FieldTitle">
                                发出日期</td>
                            <td class="FieldText" colspan="2">
                                <asp:TextBox ID="Happen_Date" runat="server" Text=""></asp:TextBox></td>
                            <td class="FieldTitle">
                                发出单位</td>
                            <td class="FieldText">
                                <asp:DropDownList ID="From_Comp" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="FieldTitle" style="height: 20px" >
                               异常单位 </td>
                            <td class="FieldText" style="height: 20px" colspan="2">
                                <asp:DropDownList ID="CAR_Comp" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td class="FieldTitle" style="height: 20px">
                            报告者</td>
                            <td class="FieldText" style="height: 20px">
                                <asp:TextBox ID="Issued_User" runat="server" Text="" ></asp:TextBox>
                            </td>
                        </tr> 
                        <tr>
                            <td class="FieldTitle" style="height: 20px" >
                               主管 </td>
                            <td class="FieldText" style="height: 20px" colspan="2">
                                <asp:TextBox ID="Issued_APP" runat="server" Text="" ></asp:TextBox>
                            </td>
                            <td class="FieldTitle" style="height: 20px">
                            签收者</td>
                            <td class="FieldText" style="height: 20px">
                                <asp:TextBox ID="Received_User" runat="server" Text="" ></asp:TextBox>
                            </td>
                        </tr>    
                        <tr>
                            <td class="FieldTitle" style="width: 34%" >问题描述：</td>
                            <td class="FieldText" colspan="4">
                                <CE:Editor ID="CAR_Content" runat="server" AutoConfigure="Minimal" SecurityPolicyFile="Guest.config" Height="240px">
                                    <FrameStyle BackColor="White" BorderColor="#DDDDDD" BorderStyle="Solid" BorderWidth="1px"
                                        CssClass="CuteEditorFrame" Height="100%" Width="100%" />
                                </CE:Editor>
                            </td>
                        </tr>
                        <tr>
                            <td class="FieldTitle" style="width: 34%" >临时解决对策：</td>
                            <td class="FieldText" colspan="4" style="height: 20px">
                                <CE:Editor ID="Interim_Action" runat="server" AutoConfigure="Minimal" SecurityPolicyFile="Guest.config" Height="240px">
                                    <FrameStyle BackColor="White" BorderColor="#DDDDDD" BorderStyle="Solid" BorderWidth="1px"
                                        CssClass="CuteEditorFrame" Height="100%" Width="100%" />
                                </CE:Editor>
                            </td>
                        </tr>
                        <tr>
                            <td class="FieldTitle">
                                effective date:
                            </td>
                            <td class="FieldText" colspan="4">
                                <asp:TextBox ID="IA_Date" CssClass="txtbox" runat="server" Width="120" class="Wdate" onfocus="new WdatePicker(this,null,false,'whyGreen')"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="FieldTitle" style="width: 34%" >原因分析：</td>
                            <td class="FieldText" colspan="4">
                                <CE:Editor ID="Info_Content" runat="server" AutoConfigure="Minimal" SecurityPolicyFile="Guest.config" Height="240px">
                                    <FrameStyle BackColor="White" BorderColor="#DDDDDD" BorderStyle="Solid" BorderWidth="1px"
                                        CssClass="CuteEditorFrame" Height="100%" Width="100%" />
                                </CE:Editor>
                            </td>
                        </tr>
                        <tr>
                            <td class="FieldTitle">
                                effective date:
                            </td>
                            <td class="FieldText" colspan="4">
                                <asp:TextBox ID="Info_Date" CssClass="txtbox" runat="server" Width="120" class="Wdate" onfocus="new WdatePicker(this,null,false,'whyGreen')"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="FieldTitle" style="width: 34%" >改善对策：</td>
                            <td class="FieldText" colspan="4">
                                <CE:Editor ID="Corrective_Action" runat="server" AutoConfigure="Minimal" SecurityPolicyFile="Guest.config" Height="240px">
                                    <FrameStyle BackColor="White" BorderColor="#DDDDDD" BorderStyle="Solid" BorderWidth="1px"
                                        CssClass="CuteEditorFrame" Height="100%" Width="100%" />
                                </CE:Editor>
                            </td>
                        </tr>
                        <tr>
                            <td class="FieldTitle">
                                effective date:
                            </td>
                            <td class="FieldText" colspan="4">
                                <asp:TextBox ID="CA_Date" CssClass="txtbox" runat="server" Width="120" class="Wdate" onfocus="new WdatePicker(this,null,false,'whyGreen')"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="FieldTitle" style="width: 34%" >长期改善对策：</td>
                            <td class="FieldText" colspan="4">
                                <CE:Editor ID="IPCA" runat="server" AutoConfigure="Minimal" SecurityPolicyFile="Guest.config" Height="240px">
                                    <FrameStyle BackColor="White" BorderColor="#DDDDDD" BorderStyle="Solid" BorderWidth="1px"
                                        CssClass="CuteEditorFrame" Height="100%" Width="100%" />
                                </CE:Editor>
                            </td>
                        </tr>
                        <tr>
                            <td class="FieldTitle">
                                effective date:
                            </td>
                            <td class="FieldText" colspan="4">
                                <asp:TextBox ID="IPCA_Date" CssClass="txtbox" runat="server" Width="120" class="Wdate" onfocus="new WdatePicker(this,null,false,'whyGreen')"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="FieldTitle" style="width: 34%" >防止再发生对策：</td>
                            <td class="FieldText" colspan="4">
                                <CE:Editor ID="ATPR" runat="server" AutoConfigure="Minimal" SecurityPolicyFile="Guest.config" Height="240px">
                                    <FrameStyle BackColor="White" BorderColor="#DDDDDD" BorderStyle="Solid" BorderWidth="1px"
                                        CssClass="CuteEditorFrame" Height="100%" Width="100%" />
                                </CE:Editor>
                            </td>
                        </tr>
                        <tr>
                            <td class="FieldTitle">
                                effective date:
                            </td>
                            <td class="FieldText" colspan="4">
                                <asp:TextBox ID="ATPR_Date" CssClass="txtbox" runat="server" Width="120" class="Wdate" onfocus="new WdatePicker(this,null,false,'whyGreen')"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="FieldText" style="text-align: left; width: 34%;">
                                是否修改SOP<br />
                                名称:<asp:TextBox ID="SOP_Name" CssClass="txtbox" runat="server" Width="95px"></asp:TextBox>
                            </td>
                            <td class="FieldText" style="width: 15%">
                                <asp:CheckBox ID="SOP_Status_ck_1" runat="server" Text="NO 不是"  onclick="ChangeCheck(this)"/><br />
                                <asp:CheckBox ID="SOP_Status_ck_2" runat="server" Text="YES  是"  onclick="ChangeCheck(this)"/>
                            </td>
                            <td class="FieldText">
                                主管:<asp:TextBox ID="Z_APP" CssClass="txtbox" runat="server"></asp:TextBox>
                            </td>
                            <td class="FieldText">
                                下对策者:<asp:TextBox ID="Z_User" CssClass="txtbox" runat="server"></asp:TextBox>
                            </td>
                            <td class="FieldText">
                                改善日期:<asp:TextBox ID="SOP_Date" CssClass="txtbox" runat="server" class="Wdate" onfocus="new WdatePicker(this,null,false,'whyGreen')"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <div id="div_center" runat="server">
                    <table>
                        <tr>
                            <td class="FieldTitle" style="width: 36%" >效果确认：</td>
                            <td class="FieldText" colspan="4">
                                <CE:Editor ID="CONF_Content" runat="server" AutoConfigure="Minimal" SecurityPolicyFile="Guest.config" Height="240px">
                                    <FrameStyle BackColor="White" BorderColor="#DDDDDD" BorderStyle="Solid" BorderWidth="1px"
                                        CssClass="CuteEditorFrame" Height="100%" Width="100%" />
                                </CE:Editor>
                            </td>
                        </tr>
                        <tr>
                            <td class="FieldTitle" style="width: 36%"colspan="2">
                                Verified By/Date
                            </td>
                            <td class="FieldText" >
                                <asp:TextBox ID="CONF_User" CssClass="txtbox" runat="server" Width="78px"></asp:TextBox>
                                <asp:TextBox ID="CONF_User_Date" CssClass="txtbox" runat="server" Width="120" class="Wdate" onfocus="new WdatePicker(this,null,false,'whyGreen')"></asp:TextBox>
                            </td>
                            <td class="FieldTitle">
                                Approval By/Date
                            </td>
                            <td class="FieldText" colspan="1">
                                <asp:TextBox ID="CONF_APP" CssClass="txtbox" runat="server" Width="80px"></asp:TextBox>
                                <asp:TextBox ID="CONF_APP_Date" CssClass="txtbox" runat="server" Width="120" class="Wdate" onfocus="new WdatePicker(this,null,false,'whyGreen')"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    </div>
                    <div id="div_sp" runat="server">
                    <table cellspacing="0" cellpadding="0" width="100%" class="TbsWhl">
                        <tr>
                       <td colspan="4" class="FieldTop" >审批记事本</td>
                       </tr>
                        <tr>
                            <td class="FieldTitle">
                         记事本</td>
                            <td class="FieldText" colspan="3">
                            <asp:TextBox ID="SP_Content" runat="server" Rows="3" TextMode="MultiLine" Width="481px"></asp:TextBox>        
                               </td>       
                        </tr>  
                        
                    </table>
                    <div style="text-align:center;"><asp:ImageButton ID="button_shenpi_yes" runat="server" ImageUrl="Images/button_shenpi_yes.gif" OnClick="button_shenpi_yes_Click"   />&nbsp;&nbsp;&nbsp;&nbsp;<asp:ImageButton ID="button_shenpi_no" runat="server" ImageUrl="Images/button_shenpi_no.gif" OnClick="button_shenpi_no_Click"   /></div> 
                    </div>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
