<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SA_New.aspx.cs" EnableEventValidation="false" Inherits="Tools_AddinForERP_CAR_SA_New" %>
<%@ Register Assembly="CuteEditor" Namespace="CuteEditor" TagPrefix="CE" %>

<%@ Register Src="CustomerControl/DomainUserTreeControl.ascx" TagName="DomainUserTreeControl"  TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>不良品确认</title>
     <link href="CSS/Style.css" type="text/css" rel="stylesheet"/>
     <link href="" rel="stylesheet" type="text/css" runat ="server" id ="lnk_CSS"  />
    <script language="javascript" type="text/javascript" src="images/JS/My97DatePicker/WdatePicker.js"></script> 
    <script type="text/javascript">
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
    function Open(l_row)
    {
    
        var url  = "Base_Customer.aspx?row=" + l_row+"&FID=<%= CurrentFactoryID.ToString() %>";
        var chlWin=window.showModalDialog(url,"modalDialog","dialogWidth:640px;dialogHeight:515px;status:no;resizable:no;");
        
        if(chlWin!=null)
           SetValue(chlWin, l_row);
               
        //this.location = this.location; 
    }  
    /// 为子窗体提供方法调用 设置值
    function SetValue(chlWin, l_row)
    {
        var AbsenseType;
        var args=chlWin.split("@@");
         
        var crkey     = args[0];
        var ccode     = args[1];  
        var cname = args[2];
        var gv = document.getElementById("<%=GridView3.ClientID%>");
        if(gv != null)
        { 
            gv.rows[l_row + 1].cells[3].childNodes[0].value = ccode;
            gv.rows[l_row + 1].cells[4].childNodes[0].value = cname;
        }
    }
    var $=document.all;
    function ChangeCheck(me)
    {
        var temp = me.id.substring(0,me.id.length - 1);
        for(var i=1;i<= 10;i++)
        {
            if(i == me.id.substring(me.id.length-1))
            {
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
    
    </script>  
</head>
<body>
    <form id="form1" runat="server">
    <div class="top">
        不良品确认 页面</div>
         <div><hr /></div>
         <div id="Div1" runat="server" >
            <table cellspacing="0" cellpadding="0" width="100%" class="TbsWhl">
                <tr>
                    <td class="FieldTop">
                        <div style=" text-align:center">处理结果</div>
                    </td>
                </tr>
            </table>
            <div style="OVERFLOW:auto;WIDTH:100%;HEIGHT:305px;border:1px solid #335D55;" >
                <asp:GridView ID="GridView3" Width="1546" runat="server" OnRowDeleting="GridView3_RowDeleting" OnRowDataBound="GridView3_RowDataBound" AutoGenerateColumns="False">
                    <Columns>
                        <asp:CommandField ShowDeleteButton="True" >
                            <ItemStyle Width="40px" />
                        </asp:CommandField>
                        <asp:TemplateField HeaderText="NO">
                            <ItemTemplate>
                                <asp:TextBox ID="tb_NO" Text=<%#Container.DataItemIndex + 1%>  runat="server" BorderWidth="0px" Width="100%" ReadOnly="true"></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle Width="25px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="记录日期">
                            <ItemTemplate>
                                <asp:TextBox ID="tb_recordDateTime" runat="server" BorderWidth="0px" Width="100%" Text=<%# Eval("recordDateTime") %>  class="Wdate" onfocus="new WdatePicker(this,null,false,'whyGreen')"></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle Width="90px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="代码">
                            <ItemTemplate>
                                <asp:TextBox ID="tb_custCode" runat="server" BorderWidth="0px" Width="100%" Text=<%# Eval("custCode") %> ></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle Width="40px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="客户">
                            <ItemTemplate>
                                <asp:TextBox ID="tb_custName" runat="server" BorderWidth="0px" Width="100%" Text=<%# Eval("custName") %>></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle Width="160px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Founder料号">
                            <ItemTemplate>
                                <asp:TextBox ID="tb_founderMaterilNo" runat="server" BorderWidth="0px" Width="100%" Text=<%# Eval("founderMaterilNo") %>></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle Width="80px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="客户料号机种">
                            <ItemTemplate>
                                <asp:TextBox ID="tb_custPartNo" runat="server" BorderWidth="0px" Width="100%" Text=<%# Eval("custPartNo") %>></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle Width="160px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="周期D/C">
                            <ItemTemplate>
                                <asp:TextBox ID="tb_cycleValue" runat="server" BorderWidth="0px" Width="100%" Text=<%# Eval("cycleValue") %>></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle Width="80px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="上件点">
                            <ItemTemplate>
                                <asp:TextBox ID="tb_happenAddress" runat="server" BorderWidth="0px" Width="100%" Text=<%# Eval("happenAddress") %>></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle Width="150px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="LOT">
                            <ItemTemplate>
                                <asp:TextBox ID="tb_LOT" runat="server" BorderWidth="0px" Width="100%" Text=<%# Eval("LOT") %>></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle Width="80px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ET章">
                            <ItemTemplate>
                                <asp:TextBox ID="tb_ET" runat="server" BorderWidth="0px" Width="100%" Text=<%# Eval("ET") %>></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle Width="80px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="T章">
                            <ItemTemplate>
                                <asp:TextBox ID="tb_T" runat="server" BorderWidth="0px" Width="100%" Text=<%# Eval("T") %>></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle Width="80px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="不良原因">
                            <ItemTemplate>
                                <asp:DropDownList ID="ddl_reason" runat="server" BorderWidth="0px" Width="100%"></asp:DropDownList>
                            </ItemTemplate>
                            <ItemStyle Width="120px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="板子种类">
                            <ItemTemplate>
                                <asp:DropDownList ID="ddl_mateialType" runat="server" BorderWidth="0px" Width="100%"></asp:DropDownList>
                            </ItemTemplate>
                            <ItemStyle Width="110px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="处理结果" Visible="false">
                            <ItemTemplate>
                                <asp:DropDownList ID="ddl_results" runat="server" BorderWidth="0px" Width="100%"></asp:DropDownList>
                            </ItemTemplate>
                            <ItemStyle Width="90px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="数量" >
                            <ItemTemplate>
                                <asp:TextBox ID="tb_quantity" runat="server" BorderWidth="0px" Width="100%" Text=<%# Eval("quantity") %> onblur="checkQty(this)"></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle Width="80px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="签单日期">
                            <ItemTemplate>
                                <asp:TextBox ID="tb_signDate" runat="server" BorderWidth="0px" Width="100%" Text=<%# Eval("signDate") %> class="Wdate" onfocus="new WdatePicker(this,null,false,'whyGreen')"></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle Width="90px" />
                        </asp:TemplateField>
                        <asp:TemplateField  HeaderText="签单人">
                            <ItemTemplate>
                                <asp:TextBox ID="tb_signingPerson" runat="server" BorderWidth="0px" Width="100%" Text=<%# Eval("signingPerson") %>></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle Width="80px" />
                        </asp:TemplateField>
                        <asp:TemplateField  HeaderText="责任厂别">
                            <ItemTemplate>
                                <asp:DropDownList ID="ddl_factoryName" runat="server" BorderWidth="0px" Width="80px"></asp:DropDownList>
                            </ItemTemplate>
                            <ItemStyle Width="80px" />
                        </asp:TemplateField>
                        <asp:TemplateField  HeaderText="折让单价(USD)">
                            <ItemTemplate>
                                <asp:TextBox ID="tb_discountPrice" runat="server" BorderWidth="0px" Width="100%" Text=<%# Eval("discountPrice") %> onblur="checkQty(this)"></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle Width="80px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="折让金额(USD)">
                            <ItemTemplate>
                                <asp:TextBox ID="tb_discountAmount" runat="server" BorderWidth="0px" Width="100%" Text=<%# Eval("discountAmount") %> onblur="checkQty(this)"></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle Width="80px" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
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
            <table cellspacing="0" cellpadding="0" width="100%" class="TbsWhl">
                        <tr>
                            <td class="FieldTitle" style="width: 7%">
                            审批人：</td>
                            <td class="FieldText" colspan="3">
                                <div runat="server" id="div_AppListEdit">
                                <div>
                                    <asp:RadioButton ID="RadioButton1" Text="固定审批流" runat="server" Checked="True" OnCheckedChanged="RadioButton1_CheckedChanged" AutoPostBack="true" />
                                    <asp:RadioButton ID="RadioButton2" Text="自定义审批流" runat="server" OnCheckedChanged="RadioButton2_CheckedChanged" AutoPostBack="true" />            
                                </div>
                                <div id="ViewShenPi" runat="server" visible="true">
                                    <asp:Button ID="Button2" runat="server" Text="查看固定审批流" OnClick="Button2_Click" />
                                </div>
                                <div id="SetShenPi" runat="server" visible="false">
                                第<asp:Label ID="lableStepNum" runat="server" Text="1" />步，审批者：<input  id="textApprovalUserNameList" runat="server" />
                                    <img src="images/workflow_member.gif" width="16" height="18" alt="选择用户 - 请点击" onclick="if(side.style.display=='none') {SelectChecked(textApprovalUserNameList.value);side.style.left=event.x;side.style.top=event.y;  side.style.display='block';}else{side.style.display='none';}" style=" border-width:0px; cursor:pointer;" />
                                <asp:Button ID="Button1" runat="server" Text="确定并添加" OnClientClick="if(textApprovalUserNameList.value=='') { alert('请添加审批人');return false;} else {return true;}" OnClick="Button1_Click" />
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
                            </td>
                        </tr>   
                    </table>
                    <table cellspacing="0" cellpadding="0" width="100%" class="TbsWhl">
                        <tr>
                            <td align="right" style="width: 50%; height: 24px;">
                                <asp:ImageButton ID="sendApproval" runat="server" ImageUrl="Images/button-send.gif" OnClick="sendApproval_Click"   />&nbsp;
                            </td>
                            <td align="left" style="height: 24px">
                                <asp:ImageButton ID="ibtn_Save" runat="server" ImageUrl="Images/button-save.gif" OnClick="ibtn_Save_Click"  />
                                <asp:ImageButton ID="ibtn_Cancel" runat="server" ImageUrl="Images/button-cancel.gif" OnClick="ibtn_Cancel_Click"  />&nbsp;
                            </td>
                        </tr>
                    </table>
    
    </div>
    <!--start 用户组树 -->
    <div id="side" style=" border-color:Gray; border-width:1px; border-style:dashed; display:none; background-color:#ededed; position:absolute; width: 350px; padding: 2px;
        height: 320px; z-index: 99; left: 800px; top: 800px;">
            <div style=" text-align:right" >
<%--                <strong><a href="javascript:void(0);" onclick="SelectAll()">全选</a></strong>--%>
                <strong><a href="javascript:void(0);" onclick="UnSelectAll()">清除</a></strong>
                <strong><asp:LinkButton ID="linkButton1" runat="server" OnClick="linkButtonAddUser_Click">确定</asp:LinkButton></strong>
                <strong><a href="javascript:void(0);" onclick="side.style.display='none'">关闭</a></strong>
                &nbsp;&nbsp;&nbsp;&nbsp;
            </div>
            <div style=" text-align:left; vertical-align:bottom; overflow:scroll;width: 350px;height: 310px;">
                <uc1:DomainUserTreeControl ID="DomainUserTreeControl1" runat="server" EnableTheming="false" />
            </div>
            <div style=" text-align:left" >
<%--                <strong><a href="javascript:void(0);" onclick="SelectAll()">全选</a></strong>--%>
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
