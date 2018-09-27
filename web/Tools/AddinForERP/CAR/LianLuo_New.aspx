<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LianLuo_New.aspx.cs" Inherits="LianLuo_New" %>

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
                    <asp:Image ID="Image1" runat="server" ImageUrl="images/icon_editobject.gif" />新建 工作联络单 界面
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
                        <tr>
                            <td class="FieldTitle" style=" font-size:12px">
                                受理人：</td>
                            <td class="FieldText" colspan="3">
                                <div runat="server" id="div_AppListEdit">
<%--                                <div>
                                第<asp:Label ID="lableStepNum" runat="server" Text="1"  Font-Size="12px" />个，受理人：<input  id="textApprovalUserNameList" runat="server" />
                                    <img src="images/workflow_member.gif" width="16" height="18" alt="选择用户 - 请点击" onclick="if(side.style.display=='none') {SelectChecked(textApprovalUserNameList.value);side.style.left=event.x;side.style.top=event.y;  side.style.display='block';}else{side.style.display='none';}" style=" border-width:0px; cursor:pointer;" />
                                <asp:Button ID="Button1" runat="server" Text="确定并添加"  Font-Size="12px" OnClientClick="if(textApprovalUserNameList.value=='') { alert('请添加审批人');return false;} else {return true;}" OnClick="Button1_Click" />
                                </div>
                                    <asp:GridView ID="GridView1" runat="server"  OnRowDeleting="GridView1_RowDeleting" AutoGenerateColumns="false">
                                        <Columns>
                                            <asp:CommandField ShowDeleteButton="True" />
                                            <asp:TemplateField HeaderText="步骤">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1%> 
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="受理人" HeaderText="受理人" />
                                            <asp:BoundField DataField="帐号" HeaderText="帐号" />
                                        </Columns>  
                                    </asp:GridView>--%>                               
                                </div>
                            </td>
                        </tr>   
                    </table>
&nbsp;
                    <table cellspacing="0" cellpadding="0" width="100%" class="TbsWhl">
                        <tr>
<%--                            <td align="right" style="width: 50%; height: 24px;">
                                <asp:ImageButton ID="sendApproval" runat="server" ImageUrl="Images/button-send.gif" OnClick="sendApproval_Click" OnClientClick="CheckData()" />&nbsp;
                            </td>
                            <td align="left" style="height: 24px">
                                <asp:ImageButton ID="ibtn_Save" runat="server" ImageUrl="Images/button-save.gif" OnClick="ibtn_Save_Click"  OnClientClick="CheckData()"/>
                                <asp:ImageButton ID="ibtn_Cancel" runat="server" ImageUrl="Images/button-cancel.gif" OnClick="ibtn_Cancel_Click"  />&nbsp;
                            </td>--%>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>  
    </div>
    <!--start 用户组树 -->
    <div id="side" style=" border-color:Gray; border-width:1px; border-style:dashed; display:none; background-color:#ededed; position:absolute; width: 350px; padding: 2px;
        height: 320px; z-index: 99; left: 800px; top: 800px;">
<%--            <div style=" text-align:right" >
                <strong><asp:LinkButton ID="linkButton1" runat="server" OnClick="linkButtonAddUser_Click">确定</asp:LinkButton></strong>
                <strong><a href="javascript:void(0);" onclick="side.style.display='none'">关闭</a></strong>
                &nbsp;&nbsp;&nbsp;&nbsp;
            </div>
            <div style=" text-align:left; vertical-align:bottom; overflow:scroll;width: 350px;height: 310px;">
                <uc1:DomainUserTreeControl ID="DomainUserTreeControl1" runat="server" EnableTheming="false" />
            </div>
            <div style=" text-align:left" >
                <strong><asp:LinkButton ID="linkButtonAddUser" runat="server" OnClick="linkButtonAddUser_Click">确定</asp:LinkButton></strong>
                <strong><a href="javascript:void(0);" onclick="side.style.display='none'">关闭</a></strong>
                &nbsp;&nbsp;&nbsp;&nbsp;
            </div>--%>
        </div>  
    <!--end 用户组树 -->
    </form>
</body>
</html>
