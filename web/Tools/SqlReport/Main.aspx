<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Main.aspx.cs" Inherits="Tools_SQLReport_Main" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ERP报表展示平台</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
</head>

<script type="text/javascript" language="javascript">

document.write('<frameset id="main" border="0" frameborder="0" framespacing="0" marginwidth="0" marginheight="0"  leftmargin="0" topmargin="0"  cols="180,8,*" frameborder="NO" border="0" framespacing="0">');
document.write('<frame name="leftFrame" border="0" frameborder="0" marginheight="0" marginwidth="0" target="masterFrame"  leftmargin="0" topmargin="0" scrolling="YES" src="Left.aspx?Type=1" >');
document.write('<frame name="midFrame" border="0" frameborder="0" marginheight="0" marginwidth="0" leftmargin="0" topmargin="0" noresize src="Center.html" >');
document.write('<frame name="masterFrame" src="about:blank" scrolling="YES" border="0" bordercolor="#6699cc" frameborder="no" >');
document.write('</frameset>');

</script>

<body>
    <noframes>
    </noframes>
</body>
</html>
