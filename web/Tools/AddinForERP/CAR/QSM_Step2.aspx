<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QSM_Step2.aspx.cs" EnableEventValidation="false" Inherits="QSM_Step2" %>

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
                <td style="color: #3399ff; width: 75%;" class="top">
                    <asp:Image ID="Image1" runat="server" ImageUrl="images/icon_editobject.gif" />新建 客户投诉 界面
                </td>
                <td style="width: 5%">编号:
                </td>
                <td class="FieldText" colspan="3" style="width: 20%">
                    <asp:TextBox ID="Serial_No" runat="server" ReadOnly="true" BorderWidth="0px" ></asp:TextBox>
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
                                    mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">物料编码</span></td>
                            <td class="FieldText">
                                <asp:TextBox ID="cust_PartCode" runat="server" Text=""></asp:TextBox></td>
                            <td class="FieldTitle">
                                <span style="font-size: 10pt; color: black; font-family: 宋体; mso-bidi-font-size: 12.0pt;
                                    mso-ascii-font-family: 'Times New Roman'; mso-hansi-font-family: 'Times New Roman';
                                    mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US;
                                    mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">客户型号</span></td>
                            <td class="FieldText" style="width: 33%"><asp:TextBox ID="cust_MaterialNo" runat="server"></asp:TextBox></td>
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
                            <td class="FieldText" style="height: 20px; width: 33%;">
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
                            <td class="FieldText" style="height: 20px; width: 33%;">
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
                            <td class="FieldText" style="height: 20px; width: 33%;">
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
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td class="FieldTitle" style="height: 20px; width: 15%;">
                                <span style="font-size: 10pt; font-family: 宋体; mso-bidi-font-family: 'Times New Roman';
                                    mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN;
                                    mso-bidi-language: AR-SA">客户端生产状态</span></td>
                            <td class="FieldText" colspan="3" style="height: 20px">
                               <asp:RadioButtonList ID="prod_status" runat="server" RepeatDirection="Horizontal" Font-Size="12px">
                                    <asp:ListItem Value="1">停产</asp:ListItem>
                                    <asp:ListItem Value="2">继续生产</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" class="FieldTop" >问题描述及不良品图片</td>
                        </tr> 
                        <tr>
                            <td class="FieldTitle" style="font-size: 12px; height: 20px; width: 15%;">
                                问题描述:</td>
                            <td class="FieldText" colspan="3" style="font-size: 12px; height: 20px">
                                <asp:TextBox ID="notes" runat="server" Width="770px" Rows="3" TextMode="MultiLine"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="FieldTitle" style="width: 15%" >
                                <span style="font-size: 10pt; color: black; font-family: 宋体; mso-bidi-font-size: 12.0pt;
                                    mso-ascii-font-family: 'Times New Roman'; mso-hansi-font-family: 'Times New Roman';
                                    mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US;
                                    mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">不良品图片：</span></td>
                            <td class="FieldText" colspan="3">
<%--                                <CE:Editor ID="CAR_Content" runat="server" AutoConfigure="Minimal" SecurityPolicyFile="Guest.config" Height="240px">
                                    <FrameStyle BackColor="White" BorderColor="#DDDDDD" BorderStyle="Solid" BorderWidth="1px"
                                        CssClass="CuteEditorFrame" Height="100%" Width="100%" />
                                </CE:Editor>--%>
                                <asp:TextBox ID="car_content" Rows="10" TextMode="MultiLine" runat="server" Width="770px"></asp:TextBox>
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
                                &nbsp;<asp:ImageButton ID="ibtn_Cancel" runat="server" ImageUrl="Images/button-cancel.gif" />&nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>  
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
