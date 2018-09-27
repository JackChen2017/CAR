<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LianLuo_View.aspx.cs" Inherits="LianLuo_View" %>

<%@ Register Assembly="CuteEditor" Namespace="CuteEditor" TagPrefix="CE" %>

<%@ Register Src="CustomerControl/DomainUserTreeControl.ascx" TagName="DomainUserTreeControl"  TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>工作联络单</title>
    <link href="CSS/Style.css" type="text/css" rel="stylesheet"/>   
    <script language="javascript" type="text/javascript" src="images/JS/My97DatePicker/WdatePicker.js"></script> 
    <script type="text/javascript">
    var $=document.all;
    function SelectAll()
    {
        //找所有input控件
        var objs = document.getElementsByTagName("input");
        for(var i=0; i<objs.length; i++) 
        {
            if(objs[i].type.toLowerCase() == "checkbox" )

            //设置找到的CheckBox控件为false
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
//        //找所有input控件
//        var objs = document.getElementsByTagName("input");
//       // strname = document.textToUserName.value;        
//        
//        for(var i=0; i<objs.length; i++) 
//        {
//            if(objs[i].type.toLowerCase() == "checkbox" )
//            {
//            //   if (strname=="杨伟明") alert(objs[i].title);
//                // if ( strname.IndexOf(objs[i].type.value) > 0 )
//                if ( strname.indexOf(objs[i].title) >= 0)
//                    //设置找到的CheckBox控件为false
//                  {  objs[i].checked = true;
//                  }
//                else
//                    objs[i].checked = false;
//             }                
//        }
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
//        if($["tuihuo_status_ck1"].checked == false && $["tuihuo_status_ck2"].checked == false)
//        {
//            alert("请选择有无退货.");
//            window.event.returnValue = false;
//            return;
//        }
    }
    </script>  
</head>
<body >
    <form id="form1" runat="server">
   <div  class="page" id="home">
        <table width="100%">
            <tr>
                <td style="color: #3399ff" class="top">
                    <asp:Image ID="Image1" runat="server" ImageUrl="images/icon_editobject.gif" />工作联络单 处理界面
                </td>  
            </tr>
        </table>
        <table cellspacing="0" cellpadding="0" width="100%" class="TbsWhl" style="font-size:12px">
            <tr>
                <td>
                    <table cellspacing="0" cellpadding="0" width="100%" class="TbsWhl">
                        <tr>
                            <td class="FieldTitle">
                                <span style="font-size: 10pt; color: black; font-family: 宋体; mso-bidi-font-size: 12.0pt;
                                    mso-ascii-font-family: 'Times New Roman'; mso-hansi-font-family: 'Times New Roman';
                                    mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US;
                                    mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">编号：</span></td>
                            <td class="FieldText" colspan="3">
                                <asp:TextBox ID="Serial_No" runat="server" Text="" ></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="FieldTitle">
                                <span style="font-size: 10pt; color: black; font-family: 宋体; mso-bidi-font-size: 12.0pt;
                                    mso-ascii-font-family: 'Times New Roman'; mso-hansi-font-family: 'Times New Roman';
                                    mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US;
                                    mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">关联客户</span></td>
                            <td class="FieldText">
                                <asp:TextBox ID="CustName" runat="server"></asp:TextBox></td>
                            <td class="FieldTitle">
                                <span style="font-size: 10pt; color: black; font-family: 宋体; mso-bidi-font-size: 12.0pt;
                                    mso-ascii-font-family: 'Times New Roman'; mso-hansi-font-family: 'Times New Roman';
                                    mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US;
                                    mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">派发单位</span></td>
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
                            <td class="FieldTitle">
                                <span style="font-size: 10pt; color: black; font-family: 宋体; mso-bidi-font-size: 12.0pt;
                                    mso-ascii-font-family: 'Times New Roman'; mso-hansi-font-family: 'Times New Roman';
                                    mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US;
                                    mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">派发时间</span></td>
                            <td class="FieldText">
                                <asp:TextBox ID="Happen_Date" runat="server" Text="" class="Wdate" onfocus="new WdatePicker(this,null,false,'whyGreen')"></asp:TextBox></td>
                            <td class="FieldTitle" style="height: 20px">
                                <span style="font-size: 10pt; color: black; font-family: 宋体; mso-bidi-font-size: 12.0pt;
                                    mso-ascii-font-family: 'Times New Roman'; mso-hansi-font-family: 'Times New Roman';
                                    mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US;
                                    mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">要求回复日期</span></td>
                            <td class="FieldText" style="height: 20px">
                                <asp:TextBox ID="Required_Date" runat="server" Text="" class="Wdate" onfocus="new WdatePicker(this,null,false,'whyGreen')" ></asp:TextBox>
                            </td>
                        </tr> 
                        <tr>
                            <td class="FieldTitle" >
                                <span style="font-size: 10pt; color: black; font-family: 宋体; mso-bidi-font-size: 12.0pt;
                                    mso-ascii-font-family: 'Times New Roman'; mso-hansi-font-family: 'Times New Roman';
                                    mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US;
                                    mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">配合事项：</span></td>
                            <td class="FieldText" colspan="3">
                                <CE:Editor ID="CAR_Content" runat="server" AutoConfigure="Minimal" SecurityPolicyFile="Guest.config" Height="154px">
                                    <FrameStyle BackColor="White" BorderColor="#DDDDDD" BorderStyle="Solid" BorderWidth="1px"
                                        CssClass="CuteEditorFrame" Height="100%" Width="100%" />
                                </CE:Editor>
                            </td>
                        </tr>  
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <table cellspacing="0" cellpadding="0" width="100%" class="TbsWhl">
                        <tr>
                            <td colspan="4" class="FieldTop" >工厂回复</td>
                        </tr>
                        <tr>
                            <td class="FieldTitle" style="width: 6%">工厂回复</td>
                            <td class="FieldText" colspan="3">
                                <CE:Editor ID="Interim_Action" runat="server" AutoConfigure="Minimal" SecurityPolicyFile="Guest.config" Height="200px" Width="740px">
                                    <FrameStyle BackColor="White" BorderColor="#DDDDDD" BorderStyle="Solid" BorderWidth="1px"
                                        CssClass="CuteEditorFrame" Height="100%" Width="100%" />
                                </CE:Editor>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>  
    </div>
    </form>
    </body>
</html>