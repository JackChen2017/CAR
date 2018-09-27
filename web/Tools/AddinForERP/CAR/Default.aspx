<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>


<html xml:lang="zh-CN" lang="zh-CN" xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>CAR</title>
    <meta http-equiv="Content-Type" content="text/html; charset=GB2312" />
    <link href="CSS/Style.css" type="text/css" rel="stylesheet"/>
   <style type="text/css">
   .navPoint {
     CURSOR: hand;
}
</style>
</head>
<script type="text/javascript">
var status = 1;
function switchSysBar(){
     if (1 == window.status){
		  window.status = 0;
          switchPoint.innerHTML = '<img src="images/left.gif">';
          document.all("frmTitle").style.display="none"
     }
     else{
		  window.status = 1;
          switchPoint.innerHTML = '<img src="images/right.gif">';
          document.all("frmTitle").style.display=""
     }
}
</script>


<body  scroll="no" style="MARGIN: 1px" >
    <table border="0" cellpadding="0" cellspacing="0" style="height:100%" width="100%" id="Table1">
        <tbody>
            <tr>
                <td style="WIDTH: 100%" >
                    <iframe  frameborder="0" id="mainFrame" name="mainFrame" scrolling="yes" src="MyWork.aspx?FID=<%= CurrentFactoryID %>" style="HEIGHT: 100%; VISIBILITY: inherit; WIDTH: 100%; Z-INDEX: 1"></iframe>
                </td>
                <td bgcolor="#337ABB" width="31">
                    <table border="0" cellpadding="0" cellspacing="0" style="height:100%" id="Table2">
                        <tbody>
                            <tr>
                                <td onclick="switchSysBar()" >
                                    <br /><br /><br /><br /><br /><br /><br /><br />
                                    <span class="navPoint" id="switchPoint" title="关闭/打开右栏" style="HEIGHT: 100%"><img alt="" src="images/right.gif" /></span>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
                <td align="middle" id="frmTitle" nowrap valign="top" name="fmTitle">
                    <iframe frameborder="0" id="right" name="left" src="rightFrame.aspx?FID=<%= CurrentFactoryID %>" scrolling="no" style="HEIGHT: 100%; VISIBILITY: inherit; WIDTH: 130px; Z-INDEX: 2"></iframe>
                </td>
            </tr>
        </tbody>
    </table>
</body>
</html>
