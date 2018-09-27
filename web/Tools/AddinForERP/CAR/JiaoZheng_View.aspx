<%@ Page Language="C#" AutoEventWireup="true" CodeFile="JiaoZheng_View.aspx.cs" Inherits="JiaoZheng_Show" %>
<%@ Register Assembly="CuteEditor" Namespace="CuteEditor" TagPrefix="CE" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>异常矫正 查看/审批页面</title>
    <link href="CSS/Style.css" type="text/css" rel="stylesheet"/>
    <script language="javascript" type="text/javascript" src="images/JS/My97DatePicker/WdatePicker.js"></script>
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
            if(me.id == "SOP_Status_ck_1")
            {
                $["SOP_Name"].value = "";
                $["SOP_Name"].diabled = true;
            }
            else if(me.id == "SOP_Status_ck_2")
            {
                $["SOP_Name"].diabled = false;
            }
        }
    }
    </script>
    <meta http-equiv="pragma" content="no-cache" />
    <base target="_self" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="top">异常矫正通知单 详细信息</div>
        <table cellspacing="0" cellpadding="0" width="100%" class="TbsWhl">
            <tr><td colspan="4" class="FieldTop" >基本信息</td>
            </tr>
            <tr>
                <td class="FieldTitle" style="width: 16%">
                    发生日期</td>
                <td class="FieldText">
                    <asp:TextBox ID="Happen_Date" runat="server" Text=""></asp:TextBox></td>
                <td class="FieldTitle">
                    编号(类型)</td>
                <td class="FieldText">
                    <asp:TextBox ID="Serial_No" runat="server" Text="" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="FieldTitle" style="width: 16%">
                    要求回复日期</td>
                <td class="FieldText">
                    <asp:TextBox ID="Required_Date" runat="server" Text="" ></asp:TextBox></td>
                <td class="FieldTitle">
                    异常料号/名称</td>
                <td class="FieldText">
                    <asp:TextBox ID="CAR_Part_Num" runat="server"></asp:TextBox></td>
            </tr>
                <tr>
                <td class="FieldTitle" style="height: 20px; width: 16%;" >
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
                <td class="FieldTitle" style="height: 20px; width: 16%;">
             类别</td>
                <td class="FieldText" colspan="1" style="height: 20px">
                    <asp:CheckBox ID="HSF_Happen_Type_1" runat="server"  Text="矫正措施" onclick="ChangeCheck(this)" />&nbsp;&nbsp;&nbsp;&nbsp; 
                    <asp:CheckBox ID="HSF_Happen_Type_2" runat="server" Text="预防措施" onclick="ChangeCheck(this)" />          
               </td>
                <td class="FieldTitle" style="height: 20px" >
                    报告者</td>
                <td class="FieldText"  colspan="1">
                <asp:TextBox ID="Issued_User" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="FieldTitle" style="height: 20px; width: 16%;">
                    签收者</td>
                <td class="FieldText"  colspan="1">
                <asp:TextBox ID="Received_User" runat="server"></asp:TextBox>
                </td>
                <td class="FieldTitle" style="height: 20px" >
                    主管</td>
                <td class="FieldText"  colspan="1">
                <asp:TextBox ID="Issued_APP" runat="server"></asp:TextBox>
                 </td>         
               </tr>
            <tr>
             <td class="FieldTitle" style="width: 16%" >
                        问题描述：</td>
                    <td class="FieldText" colspan="3">
                        <CE:Editor ID="CAR_Content" runat="server" AutoConfigure="Minimal" SecurityPolicyFile="Guest.config" Height="240px">
                            <FrameStyle BackColor="White" BorderColor="#DDDDDD" BorderStyle="Solid" BorderWidth="1px"
                                CssClass="CuteEditorFrame" Height="100%" Width="100%" />
                        </CE:Editor>
                       </td>
            </tr>    
            <tr>
             <td class="FieldTitle" style="width: 16%; height: 20px;" >
                        异常数据：</td>
                    <td class="FieldText" colspan="3" style="height: 20px">            
                        批量：<asp:TextBox ID="batch" CssClass="txtbox" runat="server"></asp:TextBox>PNL/pcs；
                        不良数：<asp:TextBox ID="badness_Num" CssClass="txtbox" runat="server"></asp:TextBox>PNL/pcs；<br />
                        不良处理状况：&nbsp;&nbsp;重工：<asp:TextBox ID="ReWork" CssClass="txtbox" runat="server"></asp:TextBox>PNL/pcs；
                        报废：<asp:TextBox ID="Reject" CssClass="txtbox" runat="server"></asp:TextBox>；
                        不处理下送：<asp:TextBox ID="NoWork" CssClass="txtbox" runat="server"></asp:TextBox>PNL/pcs；
                       </td>
            </tr>
            <tr>
                <td class="FieldTitle" style="width: 16%" >造成原因：</td>
                <td class="FieldText" colspan="4">
                    <CE:Editor ID="Info_Content" runat="server" AutoConfigure="Minimal" SecurityPolicyFile="Guest.config" Height="240px">
                        <FrameStyle BackColor="White" BorderColor="#DDDDDD" BorderStyle="Solid" BorderWidth="1px"
                            CssClass="CuteEditorFrame" Height="100%" Width="100%" />
                    </CE:Editor>
                </td>
            </tr>
            <tr>
                <td class="FieldTitle" style="width: 16%" rowspan="2" >临时对策：</td>
                <td class="FieldText" colspan="4">
                    <CE:Editor ID="Interim_Action" runat="server" AutoConfigure="Minimal" SecurityPolicyFile="Guest.config" Height="240px">
                        <FrameStyle BackColor="White" BorderColor="#DDDDDD" BorderStyle="Solid" BorderWidth="1px"
                            CssClass="CuteEditorFrame" Height="100%" Width="100%" />
                    </CE:Editor>
                </td>
            </tr>
            <tr>
                            <td class="FieldText" colspan="3">
                                主管:<asp:TextBox ID="IA_APP" runat="server" Width="80px" CssClass="txtbox" ></asp:TextBox>
                                下对策者:<asp:TextBox ID="IA_User" runat="server" Width="80px" CssClass="txtbox" ></asp:TextBox>
                                改善时间:<asp:TextBox ID="IA_Date" runat="server" Width="80px" CssClass="txtbox" class="Wdate" onfocus="new WdatePicker(this,null,false,'whyGreen')" ></asp:TextBox>
                            </td>
                        </tr>
            <tr>
                <td class="FieldTitle" style="width: 16%" rowspan="2" >永久对策：</td>
                <td class="FieldText" colspan="4">
                    <CE:Editor ID="IPCA" runat="server" AutoConfigure="Minimal" SecurityPolicyFile="Guest.config" Height="240px">
                        <FrameStyle BackColor="White" BorderColor="#DDDDDD" BorderStyle="Solid" BorderWidth="1px"
                            CssClass="CuteEditorFrame" Height="100%" Width="100%" />
                    </CE:Editor>
                </td>
            </tr>
            <tr>
                            <td class="FieldText" colspan="3">
                                主管:<asp:TextBox ID="IPCA_APP" runat="server" Width="80px" CssClass="txtbox" ></asp:TextBox>
                                下对策者:<asp:TextBox ID="IPCA_User" runat="server" Width="80px" CssClass="txtbox" ></asp:TextBox>
                                改善时间:<asp:TextBox ID="IPCA_Date" runat="server" Width="80px" CssClass="txtbox" class="Wdate" onfocus="new WdatePicker(this,null,false,'whyGreen')" ></asp:TextBox>
                            </td>
                        </tr>
            <tr>
                <td class="FieldTitle" style="width: 16%" >水平展开</td>
                <td class="FieldText" colspan="4">
                    <asp:TextBox ID="Levels" runat="server" Width="100%" Height="62px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="FieldTitle" style="width: 16%">
                    标准化</td>
                <td class="FieldText" colspan="3" style="vertical-align: middle">
                    是否修改SOP&nbsp;
                    <asp:CheckBox ID="SOP_Status_ck_1" runat="server" Text="否" onclick="ChangeCheck(this)"/>&nbsp;
                    <asp:CheckBox ID="SOP_Status_ck_2" runat="server" Text="是"  onclick="ChangeCheck(this)"/>
                    &nbsp; &nbsp; &nbsp; &nbsp;原因:
                    <asp:TextBox ID="SOP_Content" runat="server" Text="" CssClass="txtbox"></asp:TextBox>
                    SOP编号:
                    <asp:TextBox ID="SOP_Name" runat="server" CssClass="txtbox"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="FieldTitle" style="width: 16%" >相关单位会签</td>
                <td class="FieldText" colspan="4">
                    <asp:TextBox ID="Other_Together_Write" runat="server" Width="100%" Height="50px"></asp:TextBox>
                </td>
            </tr>
        </table>
        <div id="div_center" runat="server">
        <table>
            <tr>
                <td class="FieldTitle" style="width: 16%" >效果确认</td>
                <td class="FieldText" colspan="4">
                    <CE:Editor ID="CONF_Content" runat="server" AutoConfigure="Minimal" SecurityPolicyFile="Guest.config" Height="240px">
                        <FrameStyle BackColor="White" BorderColor="#DDDDDD" BorderStyle="Solid" BorderWidth="1px"
                            CssClass="CuteEditorFrame" Height="100%" Width="100%" />
                    </CE:Editor>
                </td>
            </tr>
            <tr>
                <td class="FieldTitle">预定结案日:</td>
                <td class="FieldText" >
                    <asp:TextBox ID="Pre_Date" runat="server" CssClass="txtbox" class="Wdate" onfocus="new WdatePicker(this,null,false,'whyGreen')"></asp:TextBox>
                </td>
                <td class="FieldTitle">实际结案日:</td>
                <td class="FieldText" >
                    <asp:TextBox ID="END_Date" runat="server" CssClass="txtbox" class="Wdate" onfocus="new WdatePicker(this,null,false,'whyGreen')"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="FieldTitle">主管:</td>
                <td class="FieldText" >
                    <asp:TextBox ID="CONF_APP" runat="server" CssClass="txtbox"></asp:TextBox>
                </td>
                <td class="FieldTitle">确认者:</td>
                <td class="FieldText" >
                    <asp:TextBox ID="CONF_User" runat="server" CssClass="txtbox"></asp:TextBox>
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
        
    </form>
</body>
</html>
