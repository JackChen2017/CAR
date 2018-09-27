<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Base_Customer.aspx.cs" Inherits="Base_Customer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>客户</title>
    <base target ="_self" />
    <script language ="javascript" type ="text/javascript"  >
    function Choose(returnStr)
    {
        window.returnValue=returnStr;
        window.close();
    }
    </script>     
</head>
<body style="width:99%; height:100%">
    <form id="form1" runat="server">
    <div>
        <table style ="font-size :smaller ;">
            <tr>
                <td>请选择客户:</td>
                <td><asp:TextBox ID="textBox_Customer" runat ="server" Width ="200px" BorderStyle ="groove" Text ="%" ></asp:TextBox></td>
                <td><asp:Button ID="btn_Button" runat ="server" Width ="80px" Text ="查询" OnClick="btn_Button_Click" ></asp:Button></td>
                <td>默认取前100个,如果不是你想要的信息,请查询</td>
            </tr>
        </table>     
        <div style ="overflow :scroll; width :99%;height:420px;" >
        <table width ="100%"  style ="font-size :smaller; border-style:groove; border-collapse :collapse ;" border ="1px" cellspacing ="0" cellpadding ="1px">
            <tr>
                <td style="height :20px; background-color: menu;">ID</td>
                <td style="height: 20px; background-color: menu">选择</td>
                <td style="height: 20px; background-color: menu">客户代码</td>
                <td style="height: 20px; background-color: menu">客户名称</td>
            </tr>
            <asp:Repeater ID="repeater_Customer" runat ="server" >
            <ItemTemplate >
                <tr>
                    <td  style ="height :20px;"><%# Container.ItemIndex +1 %></td>
                    <td ><a href ="" onclick ="Choose('<%# Eval("rkey") %>@@<%# Eval("cust_code") %>@@<%# Eval("customer_name") %>')">选择</a></td>
                    <td><%# Eval("cust_code")%></td>
                    <td><%# Eval("customer_name")%></td>
                </tr>
            </ItemTemplate>
            </asp:Repeater>
        </table>            
        </div>
     </div> 
    </form>
</body>
</html>
