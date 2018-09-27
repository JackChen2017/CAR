<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MainUsingHistory.aspx.cs" Inherits="Tools_SQLReport_MainUsingHistory" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>ERP报表展示平台</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
</head>

<script type="text/javascript" language="javascript">

document.write('<frameset id="main" border="1" frameborder="1" framespacing="5" marginwidth="0" marginheight="0"  leftmargin="0" topmargin="0"  cols="180,*" frameborder="NO" border="0" framespacing="0">');
document.write('<frame name="leftFrame" border="0" frameborder="0" marginheight="0" marginwidth="0" target="masterFrame" style="BORDER-RIGHT: #99ccff 1px solid; BORDER-TOP: #003366 1px solid" leftmargin="0" topmargin="0" scrolling="YES" noresize src="Left.aspx?Type=3" >');
document.write('<frame name="masterFrame" src="ReportInfo.aspx" scrolling="YES" border="0" bordercolor="#6699cc" frameborder="no" style="BORDER-LEFT: #99ccff 2px groove; BORDER-TOP: #003366 1px solid">');
document.write('</frameset>');

</script>

<body>
    <noframes>
    </noframes>
</body>
</html>