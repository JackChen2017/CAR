<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QSM_New.aspx.cs" EnableEventValidation="false" Inherits="Tools_AddinForERP_CAR_QSM_New" %>

<%@ Register Assembly="CuteEditor" Namespace="CuteEditor" TagPrefix="CE" %>

<%@ Register Src="CustomerControl/DomainUserTreeControl.ascx" TagName="DomainUserTreeControl"  TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>客户投诉</title>
    <link href="CSS/Style.css" type="text/css" rel="stylesheet"/>   
    <script language="javascript" type="text/javascript" src="images/JS/My97DatePicker/WdatePicker.js"></script> 
    <script type="text/javascript">
    var $=document.all;
    function ChangeCheck(me)
    {
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
        if(me.id == "tijiao_status_ck1")//不需要提交报告
        {
            $["tijiao_type_ck1"].checked = false
            $["tijiao_type_ck1"].disabled = true;
            $["tijiao_type_ck2"].checked = false
            $["tijiao_type_ck2"].disabled = true;
            $["tijiao_type_ck3"].checked = false
            $["tijiao_type_ck3"].disabled = true;
        }
        else if(me.id == "tijiao_status_ck2")//需要提交报告
        {
            $["tijiao_type_ck1"].checked = true
            $["tijiao_type_ck1"].disabled = false;
            $["tijiao_type_ck2"].disabled = false;
            $["tijiao_type_ck2"].checked = false
            $["tijiao_type_ck3"].disabled = false;
            $["tijiao_type_ck3"].checked = false
        }
        else if(me.id == "tuihuo_status_ck1")//无退货
        {
            $["tuihuo_qty"].value = "";
            $["tuihuo_qty"].disabled = true;
        }
        else if(me.id == "tuihuo_status_ck2")//有退货
        {
            $["tuihuo_qty"].disabled = false;
        }
    }
    function GetProportion() //计算比例
    {
        if($["jiancha_qty"].value.replace(" ","") != "" && $["buliang_qty"].value.replace(" ","") != "")
        {
            try
            {
                $["buliangbili"].value = Math.round(parseFloat($["buliang_qty"].value.replace(" ",""))*10000/parseFloat($["jiancha_qty"].value.replace(" ","")))/100 + "%";
            }
            catch(e)
            {
                alert(e.message);
            }
        }
    }
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
        
        if(me.id == "jiancha_qty")
        {
            GetProportion();
        }
        else if(me.id == "buliang_qty")
        {
            GetProportion();
        }
    }
    function SelectAll()
    {
        var objs = document.getElementsByTagName("input");
        for(var i=0; i<objs.length; i++) 
        {
            if(objs[i].type.toLowerCase() == "checkbox" )
            objs[i].checked = true;
        }
    }

    function UnSelectAll()
    { 
        //找所有input控件
        var objs = document.getElementsByTagName("input");
        for(var i=0; i<objs.length; i++) 
        {
            if(objs[i].type.toLowerCase() == "checkbox" )
                //设置找到的CheckBox控件为false
                objs[i].checked = false;
        }
    }
        
    function SelectChecked(strname)
    {
    }
    
    function CheckSubmit()
    {
        var a = document.getElementById("textToUserName").value;
        var b = document.getElementById("textToUser").value;
        var txtToUserName=a.split(",");
        var txtToUser=b.split(",");
        
        if(document.getElementById("textApprovalUserNameList").value != '') 
        { 
            alert('您还有选择的审批人未添加,请点击“确定并添加”按钮');
            return false;
        } 
        
        if(b=='') 
        { 
            alert('收文者还没有校验，请校验后再发起工作流');
            return false;
        } 
        
        if(document.getElementById("textWorkFlowTitle").value=='') 
        { 
            alert('请添加文件标题');
            return false;
        }
        
        if(!confirm("请确认是否无误？若有误,则取消")) 
        {
            return false;
        }
             

        return true;

    }
    function CheckData()
    {
        if($["tuihuo_status_ck1"].checked == false && $["tuihuo_status_ck2"].checked == false)
        {
            alert("请选择有无退货.");
            window.event.returnValue = false;
            return;
        }
        
        if($["tijiao_status_ck1"].checked == false && $["tijiao_status_ck2"].checked == false)
        {
            alert("请选择是否提交报告.");
            window.event.returnValue = false;
            return;
        }
//        if($["Serial_No"].value.replace(" ","") == "")
//        {
//            alert("请输入编号");
//            window.event.returnValue = false;
//            return;
//        }
        if($["Happen_Date"].value.replace(" ","") == "")
        {
            alert("请输入投诉日期");
            window.event.returnValue = false;
            return;
        }
    }
    </script>  
</head>
<body >
    <form id="form1" runat="server">
   <div  class="page" id="home">
        <table width="100%">
            <tr>
                <td style="color: #3399ff" class="top">
                    <asp:Image ID="Image1" runat="server" ImageUrl="images/icon_editobject.gif" />新建 客户投诉 界面
                </td>  
            </tr>
        </table>
        <table cellspacing="0" cellpadding="0" width="100%" class="TbsWhl" style="font-size:12px">
            <tr>
                <td>
                    <table cellspacing="0" cellpadding="0" width="100%" class="TbsWhl">
                        <tr>
                            <td class="FieldTitle" style="width: 15%">
                                <span style="font-size: 10pt; color: black; font-family: 宋体; mso-bidi-font-size: 12.0pt;
                                    mso-ascii-font-family: 'Times New Roman'; mso-hansi-font-family: 'Times New Roman';
                                    mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US;
                                    mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">编号：</span></td>
                            <td class="FieldText" colspan="3">
                                <asp:TextBox ID="Serial_No" runat="server" ReadOnly="true" ></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="FieldTitle" style="width: 15%">
                                <span style="font-size: 10pt; color: black; font-family: 宋体; mso-bidi-font-size: 12.0pt;
                                    mso-ascii-font-family: 'Times New Roman'; mso-hansi-font-family: 'Times New Roman';
                                    mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US;
                                    mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">客户名称</span></td>
                            <td class="FieldText">
                                <asp:TextBox ID="CustName" runat="server" OnClick="SetCustomer()"></asp:TextBox>
                                <%--<asp:TextBox ID="CustCode" runat="server" BorderWidth="0px"></asp:TextBox>--%>
                                <asp:HiddenField ID="CustCode" runat="server" />
                            </td>
                            <td class="FieldTitle">
                                <span style="font-size: 10pt; color: black; font-family: 宋体; mso-bidi-font-size: 12.0pt;
                                    mso-ascii-font-family: 'Times New Roman'; mso-hansi-font-family: 'Times New Roman';
                                    mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US;
                                    mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">制造工厂</span></td>
                            <td class="FieldText">
                                <asp:DropDownList ID="factoryList" runat="server" Width="156px" >
                                  <asp:ListItem Value="1">珠海富山</asp:ListItem>
                                  <asp:ListItem Value="2">珠海多层</asp:ListItem>
                                  <asp:ListItem Value="3">珠海越亚</asp:ListItem>
                                  <asp:ListItem Value="4">杭州速能</asp:ListItem>
                                  <asp:ListItem Value="5">重庆高密</asp:ListItem>
                                  <asp:ListItem Value="6">珠海高密</asp:ListItem>
                                  <asp:ListItem Value="7">销售外包</asp:ListItem>
                                  <asp:ListItem Value="8">其他</asp:ListItem>
                                  </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="FieldTitle" style="width: 15%">
                                <span style="font-size: 10pt; color: black; font-family: 宋体; mso-bidi-font-size: 12.0pt;
                                    mso-ascii-font-family: 'Times New Roman'; mso-hansi-font-family: 'Times New Roman';
                                    mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US;
                                    mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">投诉日期</span></td>
                            <td class="FieldText">
                                <asp:TextBox ID="Happen_Date" runat="server" Height="23px" Text="" class="Wdate" onfocus="new WdatePicker(this,null,false,'whyGreen')"></asp:TextBox></td>
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
                                <asp:TextBox ID="require_Date" runat="server" Height="23px" Text="" class="Wdate" onfocus="new WdatePicker(this,null,false,'whyGreen')" ></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="FieldTitle" style="width: 15%">
                                <span style="font-size: 10pt; color: black; font-family: 宋体; mso-bidi-font-size: 12.0pt;
                                    mso-ascii-font-family: 'Times New Roman'; mso-hansi-font-family: 'Times New Roman';
                                    mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US;
                                    mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">投诉等级</span></td>
                            <td class="FieldText">
                                <asp:DropDownList ID="tousu_level" runat="server" Width="156px" >
                                    <asp:ListItem Value="1">普通投诉</asp:ListItem>
                                    <asp:ListItem Value="2">重大投诉</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td class="FieldTitle">
                                <span style="font-size: 10pt; color: black; font-family: 宋体; mso-bidi-font-size: 12.0pt;
                                    mso-ascii-font-family: 'Times New Roman'; mso-hansi-font-family: 'Times New Roman';
                                    mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US;
                                    mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">投诉类型</span></td>
                            <td class="FieldText">
                                <asp:DropDownList ID="tousu_type" runat="server" Width="156px" >
                                    <asp:ListItem Value="1">外观不良</asp:ListItem>
                                    <asp:ListItem Value="2">功能不良</asp:ListItem>
                                    <asp:ListItem Value="3">工程问题</asp:ListItem>
                                    <asp:ListItem Value="4">包装问题</asp:ListItem>
                                    <asp:ListItem Value="5">其他</asp:ListItem>
                                </asp:DropDownList>
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
                                            <asp:RadioButton ID="tijiao_type_ck3" runat="server" Text="Founder PPT" onclick="ChangeCheck(this)" />)</span></span></td>
                        </tr>
                        <tr>
                            <td class="FieldTitle" style="font-size: 12px; height: 20px; width: 15%;">
                                备注</td>
                            <td class="FieldText" colspan="3" style="font-size: 12px; height: 20px">
                                <asp:TextBox ID="notes" runat="server" Rows="3" TextMode="MultiLine" Width="481px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="FieldTitle" style=" font-size:12px; width: 15%;">
                            审批人：</td>
                            <td class="FieldText" colspan="3">
                                <div runat="server" id="div_AppListEdit">
                                <div>
                                    <asp:RadioButton ID="RadioButton1" Text="固定审批流" runat="server" Checked="True" OnCheckedChanged="RadioButton1_CheckedChanged" AutoPostBack="true" Font-Size="12px" />
                                    <asp:RadioButton ID="RadioButton2" Text="自定义审批流" runat="server" OnCheckedChanged="RadioButton2_CheckedChanged" AutoPostBack="true"  Font-Size="12px"/>            
                                </div>
                                <div id="ViewShenPi" runat="server" visible="true">
                                    <asp:Button ID="Button2" runat="server" Text="查看固定审批流" OnClick="Button2_Click"  Font-Size="12px" />
                                </div>
                                <div id="SetShenPi" runat="server" visible="false">
                                第<asp:Label ID="lableStepNum" runat="server" Text="1"  Font-Size="12px" />步，审批者：<input  id="textApprovalUserNameList" runat="server" />
                                    <img src="images/workflow_member.gif" width="16" height="18" alt="选择用户 - 请点击" onclick="if(side.style.display=='none') {SelectChecked(textApprovalUserNameList.value);side.style.left=event.x;side.style.top=event.y;  side.style.display='block';}else{side.style.display='none';}" style=" border-width:0px; cursor:pointer;" />
                                <asp:Button ID="Button1" runat="server" Text="确定并添加"  Font-Size="12px" OnClientClick="if(textApprovalUserNameList.value=='') { alert('请添加审批人');return false;} else {return true;}" OnClick="Button1_Click" />
                                </div>
                                    <asp:GridView ID="GridView1" runat="server"  OnRowDeleting="GridView1_RowDeleting" AutoGenerateColumns="false" Font-Size="12px">
                                        <Columns>
                                            <asp:CommandField ShowDeleteButton="True" />
                                            <asp:TemplateField HeaderText="步骤">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1%> 
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="审批人" HeaderText="审批人" />
                                            <asp:BoundField DataField="帐号" HeaderText="帐号" />
                                        </Columns>  
                                    </asp:GridView>                               
                                </div>
                                <div runat="server" id="div_AppListShow">
                                <asp:GridView ID="GridView2" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="false" Font-Size="12px" OnRowDataBound="GridView2_RowDataBound">
                                    <Columns>
                                        <asp:BoundField HeaderText="步骤" DataField="sp_step" />
                                        <asp:BoundField HeaderText="审批人" DataField="sp_user" />
                                        <asp:BoundField HeaderText="处理时间" DataField="sp_end_date" />
                                        <asp:BoundField HeaderText="状态" />
                                        <asp:BoundField HeaderText="备注" DataField="sp_content" >
                                        </asp:BoundField>
                                    </Columns>
                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <RowStyle BackColor="#EFF3FB" />
                                    <EditRowStyle BackColor="#2461BF" />
                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <AlternatingRowStyle BackColor="White" />
                                </asp:GridView>
                                </div>
                            </td>
                        </tr>   
                    </table>
&nbsp;
                    <table cellspacing="0" cellpadding="0" width="100%" class="TbsWhl">
                        <tr>
                            <td align="right" style="width: 50%; height: 24px;">
                                <asp:ImageButton ID="sendApproval" runat="server" ImageUrl="Images/button-send.gif" OnClick="sendApproval_Click" OnClientClick="CheckData()" />&nbsp;
                            </td>
                            <td align="left" style="height: 24px">
                                <asp:ImageButton ID="ibtn_Save" runat="server" ImageUrl="Images/button-save.gif" OnClick="ibtn_Save_Click"  OnClientClick="CheckData()"/>
                                <asp:ImageButton ID="ibtn_Cancel" runat="server" ImageUrl="Images/button-cancel.gif" OnClick="ibtn_Cancel_Click"  />&nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>  
    </div>
    <!--start 用户组树 -->
    <div id="side" style=" border-color:Gray; border-width:1px; border-style:dashed; display:none; background-color:#ededed; position:absolute; width: 350px; padding: 2px;
        height: 320px; z-index: 99; left: 800px; top: 800px;">
            <div style=" text-align:right" >
                <%--<strong><a href="javascript:void(0);" onclick="SelectAll()">全选</a></strong>--%>
                <%--<strong><a href="javascript:void(0);" onclick="UnSelectAll()">清除</a></strong>--%>
                <strong><asp:LinkButton ID="linkButton1" runat="server" OnClick="linkButtonAddUser_Click">确定</asp:LinkButton></strong>
                <strong><a href="javascript:void(0);" onclick="side.style.display='none'">关闭</a></strong>
                &nbsp;&nbsp;&nbsp;&nbsp;
            </div>
            <div style=" text-align:left; vertical-align:bottom; overflow:scroll;width: 350px;height: 310px;">
                <uc1:DomainUserTreeControl ID="DomainUserTreeControl1" runat="server" EnableTheming="false" />
            </div>
            <div style=" text-align:left" >
                <%--<strong><a href="javascript:void(0);" onclick="SelectAll()">全选</a></strong>--%>
                <%--<strong><a href="javascript:void(0);" onclick="UnSelectAll()">清除</a></strong>--%>
                <strong><asp:LinkButton ID="linkButtonAddUser" runat="server" OnClick="linkButtonAddUser_Click">确定</asp:LinkButton></strong>
                <strong><a href="javascript:void(0);" onclick="side.style.display='none'">关闭</a></strong>
                &nbsp;&nbsp;&nbsp;&nbsp;
            </div>
        </div>  
    <!--end 用户组树 -->
    </form>
    <script language="javascript" type="text/javascript">
        document.all["CustName"].readOnly = true;
        document.all["CustCode"].readOnly = true;
        function SetCustomer()
        {
            var url  = "Base_Customer.aspx??FID=<%= CurrentFactoryID.ToString() %>";
            var chlWin=window.showModalDialog(url,"modalDialog","dialogWidth:640px;dialogHeight:515px;status:no;resizable:no;");
            
            if(chlWin!=null)
            {
                document.all["CustName"].value = chlWin.split('@@')[2];
                document.all["CustCode"].value = chlWin.split('@@')[1];
            }
        }
    </script>
</body>
</html>
