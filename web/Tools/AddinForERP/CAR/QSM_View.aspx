<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QSM_View.aspx.cs" Inherits="Tools_AddinForERP_CAR_QSM_View" %>

<%@ Register Assembly="CuteEditor" Namespace="CuteEditor" TagPrefix="CE" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>客户投诉通报书 查看/审批页面</title>
    <link href="CSS/Style.css" type="text/css" rel="stylesheet"/>
    <script language="javascript" type="text/javascript" src="images/JS/My97DatePicker/WdatePicker.js"></script>
    <script language ="javascript" type ="text/javascript" >
        function checkQty(me)
        {
           
            if(me.value.replace(" ","")=="" ) return;
            
            try
            {
                var re=/^(-?\d+)(\.\d+)?$/;
                var list=me.value.match(re);
                
                if(list==null)
                {
                    alert("请输入数字!");
                    me.focus();
                }
            }
            catch(e)
            {
              alert(e.message);
            }
        }
         var $=document.all;
         function ChangeCheck1(num)
         {
             switch(num)
             {
                 case 1:
                     $["zaitu_status_ck1"].checked = true;
                     $["zaitu_status_ck2"].checked = false;
                     $["zaitu_qty"].value = "";
                     $["zaitu_qty"].disabled = true;
                     $["chuli_status_ck1"].checked = false;
                     $["chuli_status_ck1"].disabled = true;
                     $["chuli_status_ck2"].checked = false;
                     $["chuli_status_ck2"].disabled = true;
                     $["chuli_status_ck3"].checked = false;
                     $["chuli_status_ck3"].disabled = true;
                     break;
                 case 2:
                     $["zaitu_status_ck1"].checked = false;
                     $["zaitu_status_ck2"].checked = true;
                     $["zaitu_qty"].disabled = false;
                     $["chuli_status_ck1"].checked = true;
                     $["chuli_status_ck1"].disabled = false;
                     $["chuli_status_ck2"].disabled = false;
                     $["chuli_status_ck2"].checked = false;
                     $["chuli_status_ck3"].disabled = false;
                     $["chuli_status_ck3"].checked = false;
                     break;
             }
         }
         function ChangeCheck2(num)
         {
             switch(num)
             {
                 case 1:
                     $["chuli_status_ck1"].checked = true;
                     $["chuli_status_ck2"].checked = false;
                     $["chuli_status_ck3"].checked = false;
                     break;
                 case 2:
                     $["chuli_status_ck1"].checked = false;
                     $["chuli_status_ck2"].checked = true;
                     $["chuli_status_ck3"].checked = false;
                     break;
                 case 3:
                     $["chuli_status_ck1"].checked = false;
                     $["chuli_status_ck2"].checked = false;
                     $["chuli_status_ck3"].checked = true;
                     break;
             }
         }
         function ChangeCheck3(num)
         {
             switch(num)
             {
                 case 1:
                     $["changleikuchun_status_ck1"].checked = true;
                     $["changleikuchun_status_ck2"].checked = false;
                     $["chuli_type_ck1"].checked = false;
                     $["chuli_type_ck1"].disabled = true;
                     $["chuli_type_ck2"].checked = false;
                     $["chuli_type_ck2"].disabled = true;
                     $["chuli_type_ck3"].checked = false;
                     $["chuli_type_ck3"].disabled = true;
                     $["chuli_type_ck4"].checked = false;
                     $["chuli_type_ck4"].disabled = true;
                     break;
                 case 2:
                     $["changleikuchun_status_ck1"].checked = false;
                     $["changleikuchun_status_ck2"].checked = true;
                     $["chuli_type_ck1"].checked = true;
                     $["chuli_type_ck1"].disabled = false;
                     $["chuli_type_ck2"].checked = false;
                     $["chuli_type_ck2"].disabled = false;
                     $["chuli_type_ck3"].checked = false;
                     $["chuli_type_ck3"].disabled = false;
                     $["chuli_type_ck4"].checked = false;
                     $["chuli_type_ck4"].disabled = false;
                     break;
             }
         }
          function ChangeCheck4(num)
         {
             switch(num)
             {
                 case 1:
                     $["chuli_type_ck1"].checked = true;
                     $["chuli_type_ck2"].checked = false;
                     $["chuli_type_ck3"].checked = false;
                     $["chuli_type_ck4"].checked = false;
                     break;
                 case 2:
                     $["chuli_type_ck1"].checked = false;
                     $["chuli_type_ck2"].checked = true;
                     $["chuli_type_ck3"].checked = false;
                     $["chuli_type_ck4"].checked = false;
                     break;
                 case 3:
                     $["chuli_type_ck1"].checked = false;
                     $["chuli_type_ck2"].checked = false;
                     $["chuli_type_ck3"].checked = true;
                     $["chuli_type_ck4"].checked = false;
                     break;
                 case 4:
                     $["chuli_type_ck1"].checked = false;
                     $["chuli_type_ck2"].checked = false;
                     $["chuli_type_ck3"].checked = false;
                     $["chuli_type_ck4"].checked = true;
                     break;
             }
         }
    </script>
    <meta http-equiv="pragma" content="no-cache" />
    <base target="_self" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="top">客户投诉通报书 查看/审批页面</div>
        <hr />
        <div id="Div1" runat="server" >
            <table cellspacing="0" cellpadding="0" width="100%" class="TbsWhl">
                <tr>
                    <td>
                        <div style=" text-align:right">编号：&nbsp;<asp:TextBox ID="Serial_No" runat="server" Text="" ReadOnly="true" BorderWidth="0px"></asp:TextBox></div>
                        <table cellspacing="0" cellpadding="0" width="100%" class="TbsWhl">
                             <tr>
                                <td class="FieldTitle" style="width: 15%">
                                    <span style="font-size: 10pt; color: black; font-family: 宋体; mso-bidi-font-size: 12.0pt;
                                        mso-ascii-font-family: 'Times New Roman'; mso-hansi-font-family: 'Times New Roman';
                                        mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US;
                                        mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">客户名称</span></td>
                                <td class="FieldText">
                                    <asp:TextBox ID="CustName" runat="server"></asp:TextBox></td>
                                <td class="FieldTitle">
                                    <span style="font-size: 10pt; color: black; font-family: 宋体; mso-bidi-font-size: 12.0pt;
                                        mso-ascii-font-family: 'Times New Roman'; mso-hansi-font-family: 'Times New Roman';
                                        mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US;
                                        mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">制造工厂</span></td>
                                <td class="FieldText">
                                    <asp:TextBox ID="FactoryName" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="FieldTitle" style="width: 15%">
                                    <span style="font-size: 10pt; color: black; font-family: 宋体; mso-bidi-font-size: 12.0pt;
                                        mso-ascii-font-family: 'Times New Roman'; mso-hansi-font-family: 'Times New Roman';
                                        mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US;
                                        mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">投诉日期</span></td>
                                <td class="FieldText">
                                    <asp:TextBox ID="Happen_Date" runat="server" Text="" class="Wdate" onfocus="new WdatePicker(this,null,false,'whyGreen')"></asp:TextBox></td>
                                <td class="FieldTitle">
                                    <span style="font-size: 10pt; color: black; font-family: 宋体; mso-bidi-font-size: 12.0pt;
                                        mso-ascii-font-family: 'Times New Roman'; mso-hansi-font-family: 'Times New Roman';
                                        mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US;
                                        mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">客户型号</span></td>
                                <td class="FieldText"><asp:TextBox ID="cust_MaterialNo" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td class="FieldTitle" style="height: 20px; width: 15%;" >
                                    <span style="font-size: 10pt; color: black; font-family: 宋体; mso-bidi-font-size: 12.0pt;
                                        mso-ascii-font-family: 'Times New Roman'; mso-hansi-font-family: 'Times New Roman';
                                        mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US;
                                        mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">工厂型号</span></td>
                                <td class="FieldText" style="height: 20px">
                                    <asp:TextBox ID="interalNo" runat="server"></asp:TextBox></td>
                                <td class="FieldTitle" style="height: 20px">
                                    <span style="font-size: 10pt; color: black; font-family: 宋体; mso-bidi-font-size: 12.0pt;
                                        mso-ascii-font-family: 'Times New Roman'; mso-hansi-font-family: 'Times New Roman';
                                        mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US;
                                        mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">要求回复日期</span></td>
                                <td class="FieldText" style="height: 20px">
                                    <asp:TextBox ID="require_Date" runat="server" Text="" class="Wdate" onfocus="new WdatePicker(this,null,false,'whyGreen')" ></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="FieldTitle" style="width: 15%">
                                    <span style="font-size: 10pt; color: black; font-family: 宋体; mso-bidi-font-size: 12.0pt;
                                        mso-ascii-font-family: 'Times New Roman'; mso-hansi-font-family: 'Times New Roman';
                                        mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US;
                                        mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">投诉等级</span></td>
                                <td class="FieldText">
                                    <asp:TextBox ID="tousu_level" runat="server"></asp:TextBox>
                                </td>
                                <td class="FieldTitle">
                                    <span style="font-size: 10pt; color: black; font-family: 宋体; mso-bidi-font-size: 12.0pt;
                                        mso-ascii-font-family: 'Times New Roman'; mso-hansi-font-family: 'Times New Roman';
                                        mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US;
                                        mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">投诉类型</span></td>
                                <td class="FieldText">
                                    <asp:TextBox ID="tousu_type" runat="server"></asp:TextBox>
                                </td>
                            </tr> 
                            <tr>
                                <td colspan="4" class="FieldTop" >问题描述及不良品图片</td>
                            </tr>   
                            <tr>
                                <td class="FieldTitle" style="width: 15%" >
                                    <span style="font-size: 10pt; color: black; font-family: 宋体; mso-bidi-font-size: 12.0pt;
                                        mso-ascii-font-family: 'Times New Roman'; mso-hansi-font-family: 'Times New Roman';
                                        mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US;
                                        mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">问题描述：</span></td>
                                <td class="FieldText" colspan="3">
                                    <CE:Editor ID="CAR_Content" runat="server" AutoConfigure="Minimal" SecurityPolicyFile="Guest.config" Height="240px">
                                        <FrameStyle BackColor="White" BorderColor="#DDDDDD" BorderStyle="Solid" BorderWidth="1px"
                                            CssClass="CuteEditorFrame" Height="100%" Width="100%" />
                                    </CE:Editor>
                                </td>
                            </tr>  
                            <tr>
                                <td class="FieldTitle" style="height: 20px; width: 15%;" >
                                    <span style="font-size: 10pt; color: black; font-family: 宋体; mso-bidi-font-size: 12.0pt;
                                        mso-ascii-font-family: 'Times New Roman'; mso-hansi-font-family: 'Times New Roman';
                                        mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US;
                                        mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">出货数量</span></td>
                                <td class="FieldText" style="height: 20px">
                                    <asp:TextBox ID="chuhuo_qty" runat="server" onblur="checkQty(this)"></asp:TextBox></td>
                                <td class="FieldTitle" style="height: 20px">
                                    <span style="font-size: 10pt; color: black; font-family: 宋体; mso-bidi-font-size: 12.0pt;
                                        mso-ascii-font-family: 'Times New Roman'; mso-hansi-font-family: 'Times New Roman';
                                        mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US;
                                        mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">检查/上线数量</span> </td>
                                <td class="FieldText" style="height: 20px">
                                    <asp:TextBox ID="jiancha_qty" runat="server" Text=""  onblur="checkQty(this)"></asp:TextBox>
                                </td>
                            </tr>   
                            <tr>
                                <td class="FieldTitle" style="height: 20px; width: 15%;">
                                    <span style="font-size: 10pt; color: black; font-family: 宋体; mso-bidi-font-size: 12.0pt;
                                        mso-ascii-font-family: 'Times New Roman'; mso-hansi-font-family: 'Times New Roman';
                                        mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US;
                                        mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">不良数量</span></td>
                                <td class="FieldText" style="height: 20px">
                                    <asp:TextBox ID="buliang_qty" runat="server" onblur="checkQty(this)"></asp:TextBox></td>
                                <td class="FieldTitle" style="height: 20px">
                                    <span style="font-size: 10pt; color: black; font-family: 宋体; mso-bidi-font-size: 12.0pt;
                                        mso-ascii-font-family: 'Times New Roman'; mso-hansi-font-family: 'Times New Roman';
                                        mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US;
                                        mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">不良比例</span></td>
                                <td class="FieldText" style="height: 20px">
                                    <asp:TextBox ID="buliangbili" runat="server" ></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td class="FieldTitle" style="height: 20px; width: 15%;">
                                    <span style="font-size: 10pt; color: black; font-family: 宋体; mso-bidi-font-size: 12.0pt;
                                        mso-ascii-font-family: 'Times New Roman'; mso-hansi-font-family: 'Times New Roman';
                                        mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US;
                                        mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">不良D/C</span></td>
                                <td class="FieldText" style="height: 20px">
                                    <asp:TextBox ID="buliangDC" runat="server" ></asp:TextBox></td>
                                <td class="FieldTitle" style="height: 20px">
                                    <span style="font-size: 10pt; color: black; font-family: 宋体; mso-bidi-font-size: 12.0pt;
                                        mso-ascii-font-family: 'Times New Roman'; mso-hansi-font-family: 'Times New Roman';
                                        mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US;
                                        mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">客户在线数量</span></td>
                                <td class="FieldText" style="height: 20px">
                                    <asp:TextBox ID="zaixian_qty" runat="server" onblur="checkQty(this)"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td class="FieldTitle" style="height: 20px; font-size:12px; width: 15%;">
                                    <span style="font-size: 10pt; color: black; font-family: 宋体; mso-bidi-font-size: 12.0pt;
                                        mso-ascii-font-family: 'Times New Roman'; mso-hansi-font-family: 'Times New Roman';
                                        mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US;
                                        mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">客户库存数量</span></td>
                                <td class="FieldText" style="height: 20px">
                                    <asp:TextBox ID="kucun_qty" runat="server" onblur="checkQty(this)"></asp:TextBox></td>
                                <td class="FieldTitle" style="height: 20px">
                                    <span lang="ZH-TW" style="font-size: 10pt; font-family: 宋体; mso-bidi-font-family: 'Times New Roman';
                                        mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-TW;
                                        mso-bidi-language: AR-SA">有无退货</span></td>
                                <td class="FieldText" style="height: 20px">
                                    &nbsp;
                                    <asp:CheckBox ID="tuihuo_status_ck1" runat="server" Text="无" onclick="ChangeCheck(this)" Font-Size="12px"/>
                                    <asp:CheckBox ID="tuihuo_status_ck2" runat="server" Text="有" onclick="ChangeCheck(this)" Font-Size="12px"/>
                                    <span lang="ZH-TW" style="font-size: 10pt; font-family: 宋体; mso-bidi-font-family: 'Times New Roman';
                                        mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-TW;
                                        mso-bidi-language: AR-SA">(数量：<asp:TextBox ID="tuihuo_qty" CssClass="txtbox" runat="server" onblur="checkQty(this)"></asp:TextBox>PCS；)</span></td>
                            </tr>
                            <tr>
                                <td class="FieldTitle" style="height: 20px; width: 15%;">
                                    <span style="font-size: 10pt; font-family: 宋体; mso-bidi-font-family: 'Times New Roman';
                                        mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN;
                                        mso-bidi-language: AR-SA">客户端发生场所</span></td>
                                <td class="FieldText" colspan="3" style="height: 20px">
                                   <asp:RadioButtonList ID="happen_address" runat="server" RepeatDirection="Horizontal" Font-Size="12px">
                                        <asp:ListItem Value="1">IQC</asp:ListItem>
                                        <asp:ListItem Value="2">SMT</asp:ListItem>
                                        <asp:ListItem Value="3">测试</asp:ListItem>
                                        <asp:ListItem Value="4">装配</asp:ListItem>
                                        <asp:ListItem Value="5">客户售后</asp:ListItem>
                                    </asp:RadioButtonList></td>
                            </tr>
                            <tr>
                                <td class="FieldTitle" style="height: 20px; font-size:12px; width: 15%;">
                                    <span style="font-size: 10pt; font-family: 宋体; mso-bidi-font-family: 'Times New Roman';
                                        mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN;
                                        mso-bidi-language: AR-SA">是否需要提交报告</span></td>
                                <td class="FieldText" colspan="3" style="height: 20px; font-size:12px">
                                    <asp:CheckBox ID="tijiao_status_ck1" runat="server" Text="否" onclick="ChangeCheck(this)"/>
                                    <asp:CheckBox ID="tijiao_status_ck2" runat="server" Text="是" onclick="ChangeCheck(this)"/>&nbsp;
                                    <span lang="EN-US" style="font-size: 10pt; color: black; font-family: 宋体; mso-bidi-font-family: 'Times New Roman';
                                        mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN;
                                        mso-bidi-language: AR-SA">(</span><span style="font-size: 10pt; color: black; font-family: 宋体;
                                            mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US;
                                            mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">报告格式<span lang="EN-US">:
                                                <asp:RadioButton ID="tijiao_type_ck1" runat="server" Text="客户格式" onclick="ChangeCheck(this)" />
                                                <asp:RadioButton ID="tijiao_type_ck2" runat="server" Text="Founder 8D" onclick="ChangeCheck(this)" />
                                                <asp:RadioButton ID="tijiao_type_ck3" runat="server" Text="Founder PPT" onclick="ChangeCheck(this)" />)</span></span>
                                </td>
                            </tr>
                            <tr>
                                <td class="FieldTitle" style="font-size: 12px; height: 20px; width: 15%;">
                                    备注</td>
                                <td class="FieldText" colspan="3" style="font-size: 12px; height: 20px">
                                    <asp:TextBox ID="notes" runat="server" Rows="3" TextMode="MultiLine" Width="481px"></asp:TextBox></td>
                            </tr>
                        </table>
                        <br />
                        <table cellspacing="0" cellpadding="0" width="100%" class="TbsWhl">
                            <tr>
                                <td colspan="4" class="FieldTop" >工厂回复</td>
                            </tr>
                            <tr>
                                <td  class="FieldTitle" style="width: 6%" >同DC交货总数</td>
                                <td class="FieldText" colspan="3" >
                                    <asp:TextBox ID="dcjiaohuo_qty" CssClass="txtbox" runat="server" onblur="checkQty(this)" Width="109px"></asp:TextBox>PCS
                                </td>   
                            </tr>
                            <tr>
                                <td  class="FieldTitle" style="width: 6%" >有无在途货</td>
                                <td class="FieldText" colspan="3" >
                                    &nbsp;<asp:CheckBox ID="zaitu_status_ck1" runat="server" Text="无" onclick="ChangeCheck1(1)"/>&nbsp;
                                    <asp:CheckBox ID="zaitu_status_ck2" runat="server" Text="有" onclick="ChangeCheck1(2)" /> &nbsp;
                                    数量：<asp:TextBox ID="zaitu_qty" CssClass="txtbox" runat="server" onblur="checkQty(this)"></asp:TextBox>PCS；
                                    (处理意见：<asp:CheckBox ID="chuli_status_ck1" runat="server" Text="召回" onclick="ChangeCheck2(1)"/>&nbsp;
                                    <asp:CheckBox ID="chuli_status_ck2" runat="server" Text="赴客户端处理" onclick="ChangeCheck2(2)" />&nbsp;
                                    <asp:CheckBox ID="chuli_status_ck3" runat="server" Text="返工"  onclick="ChangeCheck2(3)"/>)
                                </td> 
                            </tr>
                            <tr>      
                                <td  class="FieldTitle" style="width: 6%" >厂内仓存板</td>     
                                <td class="FieldText" colspan="3">
                                    &nbsp;<asp:CheckBox ID="changleikuchun_status_ck1" runat="server" Text="无" onclick="ChangeCheck3(1)"/>&nbsp;
                                    <asp:CheckBox ID="changleikuchun_status_ck2" runat="server" Text="有" onclick="ChangeCheck3(2)" /> &nbsp;                                
                                    (处理方法：
                                    <asp:CheckBox ID="chuli_type_ck1" runat="server" Text="全检" onclick="ChangeCheck4(1)"/>&nbsp;
                                    <asp:CheckBox ID="chuli_type_ck2" runat="server" Text="返工" onclick="ChangeCheck4(2)" />&nbsp;
                                    <asp:CheckBox ID="chuli_type_ck3" runat="server" Text="返测" onclick="ChangeCheck4(3)"/>&nbsp;
                                    <asp:CheckBox ID="chuli_type_ck4" runat="server" Text="报废" onclick="ChangeCheck4(4)" />)
                                </td>
                            </tr> 
                            <tr>
                                <td class="FieldTitle" style="width: 6%">提交报告</td>
                                <td class="FieldText" colspan="3">
                                    <CE:Editor ID="Info_Content" runat="server" AutoConfigure="Minimal" SecurityPolicyFile="Guest.config" Height="200px" Width="740px">
                                        <FrameStyle BackColor="White" BorderColor="#DDDDDD" BorderStyle="Solid" BorderWidth="1px"
                                        CssClass="CuteEditorFrame" Height="100%" Width="100%" />
                                    </CE:Editor>
                                </td>
                            </tr>   
                        </table>
                        <br />
                        <div id="div_center" runat="server">
                            <table cellspacing="0" cellpadding="0" width="100%" class="TbsWhl">
                                <tr>
                                    <td colspan="4" class="FieldTop" >中央客服确认</td>
                                </tr>
                                <tr>
                                    <td class="FieldTitle" style="width: 6%">效果确认</td>
                                    <td class="FieldText" colspan="3">
                                        <CE:Editor ID="CONF_Content" runat="server" AutoConfigure="Minimal" SecurityPolicyFile="Guest.config" Height="200px" Width="740px">
                                            <FrameStyle BackColor="White" BorderColor="#DDDDDD" BorderStyle="Solid" BorderWidth="1px"
                                            CssClass="CuteEditorFrame" Height="100%" Width="100%" />
                                        </CE:Editor>
                                    </td>       
                                </tr>  
                            </table>
                        </div>
                    </td>
                </tr>
            </table> 
            <br />
            <div id="div_sp" runat="server">
                <table cellspacing="0" cellpadding="0" width="100%" class="TbsWhl">
                    <tr>
                        <td colspan="4" class="FieldTop" >审批记事本</td>
                    </tr>
                    <tr>
                        <td class="FieldTitle" style="width: 6%">记事本</td>
                        <td class="FieldText" colspan="3">
                            <asp:TextBox ID="SP_Content" runat="server" Rows="3" TextMode="MultiLine" Width="619px"></asp:TextBox>        
                        </td>       
                    </tr>  
                </table>
                <div style="text-align:center;">
                    <asp:ImageButton ID="button_shenpi_yes" runat="server" ImageUrl="Images/button_shenpi_yes.gif" OnClick="button_shenpi_yes_Click"   />&nbsp;&nbsp;&nbsp;&nbsp;<asp:ImageButton ID="button_shenpi_no" runat="server" ImageUrl="Images/button_shenpi_no.gif" OnClick="button_shenpi_no_Click"   />
                </div> 
            </div>
        </div>
    </form>
</body>
</html>
