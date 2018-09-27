<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Base_Container.aspx.cs" Inherits="Base_Container" %>

<%@ Register Assembly="CuteEditor" Namespace="CuteEditor" TagPrefix="CE" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="100%" style="height:100%">
            <tr style="width:100%; height:100%">
                <td style="width:100%; height:100%">
                    <CE:Editor ID="Content" runat="server" SecurityPolicyFile="Guest.config" ShowBottomBar="false" ActiveTab="View" AutoConfigure="None">
                        <FrameStyle BackColor="White" BorderColor="#DDDDDD" BorderStyle="Solid" BorderWidth="1px"
                            CssClass="CuteEditorFrame" Height="100%" Width="100%" />
                    </CE:Editor>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
