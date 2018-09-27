<%@ Page Language="C#" AutoEventWireup="true" CodeFile="JiaoZheng_New.aspx.cs" EnableEventValidation="false" Inherits="JiaoZheng" %>
<%@ Register Assembly="CuteEditor" Namespace="CuteEditor" TagPrefix="CE" %>

<%@ Register Src="CustomerControl/DomainUserTreeControl.ascx" TagName="DomainUserTreeControl"  TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
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
    }
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
        if($["Happen_Date"].value.replace(" ","") == "")
        {
            alert('请填写发出日期');
            window.event.returnValue = false;
            return;
        }
        if($["Required_Date"].value.replace(" ","") == "")
        {
            alert('请填写发出日期');
            window.event.returnValue = false;
            return;
        }
    }
    </script>  
</head>
<body>
    <form id="form1" runat="server">
    <div  class="page" id="home">
    <table width="100%">
  <tr>
 <td style="color: #3399ff" class="top">
     <asp:Image ID="Image1" runat="server" ImageUrl="images/icon_editobject.gif" />新建异常矫正通知单</td>  
   </tr>
  </table>
     <table cellspacing="0" cellpadding="0" width="100%" class="TbsWhl">
<tr><td>
<table cellspacing="0" cellpadding="0" width="100%" class="TbsWhl">
<tr><td colspan="4" class="FieldTop" >基本信息</td></tr>
    <tr>
        <td class="FieldTitle" style="font-size:12px">
            发生日期</td>
        <td class="FieldText">
            <asp:TextBox ID="Happen_Date" runat="server" Text="" class="Wdate" onfocus="new WdatePicker(this,null,false,'whyGreen')"></asp:TextBox></td>
        <td class="FieldTitle" style="font-size:12px">
            编号(类型)</td>
        <td class="FieldText">
            <asp:DropDownList ID="Serial_No" runat="server">
                <asp:ListItem Value="1" Text="CON"></asp:ListItem>
                <asp:ListItem Value="2" Text="VEN"></asp:ListItem>
                <asp:ListItem Value="3" Text="QSM"></asp:ListItem>
                <asp:ListItem Value="4" Text="SYS"></asp:ListItem>
                <asp:ListItem Value="5" Text="INT"></asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="FieldTitle" style="font-size:12px">
            要求回复日期</td>
        <td class="FieldText">
            <asp:TextBox ID="Required_Date" runat="server" Text="" class="Wdate" onfocus="new WdatePicker(this,null,false,'whyGreen')"></asp:TextBox></td>
        <td class="FieldTitle" style="font-size:12px">
            异常料号/名称</td>
        <td class="FieldText">
            <asp:TextBox ID="CAR_Part_Num" runat="server"></asp:TextBox></td>
    </tr>
        <tr>
        <td class="FieldTitle" style="height: 20px; font-size:12px" >
            发出单位</td>
        <td class="FieldText" style="height: 20px">
        <asp:DropDownList ID="From_Comp" runat="server">
            </asp:DropDownList>
         </td>
           <td class="FieldTitle" style="height: 20px; font-size:12px">
            异常单位</td>
        <td class="FieldText" style="height: 20px">
            <asp:DropDownList ID="CAR_Comp" runat="server">
            </asp:DropDownList></td>
       </tr>
    <tr>
        <td class="FieldTitle" style="height: 20px; font-size:12px">
     类别</td>
        <td class="FieldText" colspan="1" style="height: 20px">
            <asp:CheckBox ID="HSF_Happen_Type_1" runat="server" Font-Size="12px" Text="矫正措施" onclick="ChangeCheck(this)" />&nbsp;&nbsp;&nbsp;&nbsp; 
            <asp:CheckBox ID="HSF_Happen_Type_2" runat="server" Font-Size="12px" Text="预防措施" onclick="ChangeCheck(this)" />          
       </td>
        <td class="FieldTitle" style="height: 20px; font-size:12px" >
            报告者</td>
        <td class="FieldText"  colspan="1">
        <asp:TextBox ID="Issued_User" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="FieldTitle" style="height: 20px; font-size:12px">
            签收者</td>
        <td class="FieldText"  colspan="1">
        <asp:TextBox ID="Received_User" runat="server"></asp:TextBox>
        </td>
        <td class="FieldTitle" style="height: 20px; font-size:12px" >
            主管</td>
        <td class="FieldText"  colspan="1">
        <asp:TextBox ID="Issued_APP" runat="server"></asp:TextBox>
         </td>         
       </tr>
<tr>
 <td class="FieldTitle"  style="font-size:12px">
            问题描述：</td>
        <td class="FieldText" colspan="3">
            <CE:Editor ID="CAR_Content" runat="server" AutoConfigure="Minimal" SecurityPolicyFile="Guest.config" Height="240px">
                <FrameStyle BackColor="White" BorderColor="#DDDDDD" BorderStyle="Solid" BorderWidth="1px"
                    CssClass="CuteEditorFrame" Height="100%" Width="100%" />
            </CE:Editor>
           </td>
</tr>    
<tr>
 <td class="FieldTitle"  style="font-size:12px">
            异常数据：</td>
        <td class="FieldText" colspan="3"  style="font-size:12px">            
            批量：<asp:TextBox ID="batch" CssClass="txtbox" runat="server" onblur="checkQty(this)"></asp:TextBox>PNL/pcs；
            不良数：<asp:TextBox ID="badness_Num" CssClass="txtbox" runat="server" onblur="checkQty(this)"></asp:TextBox>PNL/pcs；<br />
            不良处理状况：&nbsp;&nbsp;重工：<asp:TextBox ID="ReWork" CssClass="txtbox" runat="server" onblur="checkQty(this)"></asp:TextBox>PNL/pcs；
            报废：<asp:TextBox ID="Reject" CssClass="txtbox" runat="server" onblur="checkQty(this)"></asp:TextBox>；
            不处理下送：<asp:TextBox ID="NoWork" CssClass="txtbox" runat="server" onblur="checkQty(this)"></asp:TextBox>PNL/pcs；
           </td>
</tr> 
                        <tr>
                            <td class="FieldTitle" style="font-size:12px">
                            审批人：</td>
                            <td class="FieldText" colspan="3" style="font-size:12px">
                                <div runat="server" id="div_AppListEdit">
                                <div>
                                    <asp:RadioButton ID="RadioButton1" Font-Size="12px" Text="固定审批流" runat="server" Checked="True" OnCheckedChanged="RadioButton1_CheckedChanged" AutoPostBack="true" />
                                    <asp:RadioButton ID="RadioButton2" Font-Size="12px" Text="自定义审批流" runat="server" OnCheckedChanged="RadioButton2_CheckedChanged" AutoPostBack="true" />            
                                </div>
                                <div id="ViewShenPi" runat="server" visible="true">
                                    <asp:Button ID="Button2" runat="server" Font-Size="12px" Text="查看固定审批流" OnClick="Button2_Click" />
                                </div>
                                <div id="SetShenPi" runat="server" visible="false">
                                第<asp:Label ID="lableStepNum" runat="server" Text="1" />步，审批者：<input  id="textApprovalUserNameList" runat="server" />
                                    <img src="images/workflow_member.gif" width="16" height="18" alt="选择用户 - 请点击" onclick="if(side.style.display=='none') {SelectChecked(textApprovalUserNameList.value);side.style.left=event.x;side.style.top=event.y;  side.style.display='block';}else{side.style.display='none';}" style=" border-width:0px; cursor:pointer;" />
                                <asp:Button ID="Button1" runat="server" Font-Size="12px" Text="确定并添加" OnClientClick="if(textApprovalUserNameList.value=='') { alert('请添加审批人');return false;} else {return true;}" OnClick="Button1_Click" />
                                </div>
                                    <asp:GridView ID="GridView1" runat="server"  OnRowDeleting="GridView1_RowDeleting" AutoGenerateColumns="false">
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
                                    &nbsp;</div>
                            </td>
                        </tr>   
</table>
&nbsp;
<table cellspacing="0" cellpadding="0" width="100%" class="TbsWhl">
  <tr><td align="right" style="width: 50%; height: 24px;">
  <asp:ImageButton ID="sendApproval" runat="server" ImageUrl="Images/button-send.gif" OnClick="sendApproval_Click" OnClientClick="CheckData()" />
    <asp:ImageButton ID="ibtn_Save" runat="server" ImageUrl="Images/button-save.gif" OnClick="ibtn_Save_Click"  OnClientClick="CheckData()"  />&nbsp;</td>
      <td align="left" style="height: 24px">
        <asp:ImageButton ID="ibtn_Cancel" runat="server" ImageUrl="Images/button-cancel.gif"  />&nbsp;</td>
        </tr></table>
     </td></tr></table>  
    </div>
    
    
    <!--start 用户组树 -->
    <div id="side" style=" border-color:Gray; border-width:1px; border-style:dashed; display:none; background-color:#ededed; position:absolute; width: 350px; padding: 2px;
        height: 320px; z-index: 99; left: 800px; top: 800px;">
            <div style=" text-align:right" >
                <%--<strong><a href="javascript:void(0);" onclick="SelectAll()">全选</a></strong>--%>
                <strong><a href="javascript:void(0);" onclick="UnSelectAll()">清除</a></strong>
                <strong><asp:LinkButton ID="linkButton1" runat="server" OnClick="linkButtonAddUser_Click">确定</asp:LinkButton></strong>
                <strong><a href="javascript:void(0);" onclick="side.style.display='none'">关闭</a></strong>
                &nbsp;&nbsp;&nbsp;&nbsp;
            </div>
            <div style=" text-align:left; vertical-align:bottom; overflow:scroll;width: 350px;height: 310px;">
                <uc1:DomainUserTreeControl ID="DomainUserTreeControl1" runat="server" EnableTheming="false" />
            </div>
            <div style=" text-align:left" >
                <%--<strong><a href="javascript:void(0);" onclick="SelectAll()">全选</a></strong>--%>
                <strong><a href="javascript:void(0);" onclick="UnSelectAll()">清除</a></strong>
                <strong><asp:LinkButton ID="linkButtonAddUser" runat="server" OnClick="linkButtonAddUser_Click">确定</asp:LinkButton></strong>
                <strong><a href="javascript:void(0);" onclick="side.style.display='none'">关闭</a></strong>
                &nbsp;&nbsp;&nbsp;&nbsp;
            </div>
        </div>  
    <!--end 用户组树 -->
    </form>
</body>
</html>
