<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Top.aspx.cs" Inherits="Tools_AddinForERP_Top" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ERP报表查询系统</title>
<link href="../../App_Themes/Default/CSS/gray.css" rel="stylesheet" type="text/css" />
<link href="../../App_Themes/Default/CSS/Default.css" rel="stylesheet" type="text/css" />
<link  href="../../App_Themes/Default/CSS/base.css" rel="stylesheet" type="text/css" />
<link  href="../../App_Themes/Default/CSS/style1.css" rel="stylesheet" type="text/css" />    
<link  href="../../App_Themes/Default/CSS/style2.css" rel="stylesheet" type="text/css" />  
    <style type="text/css">
    <!--
    .STYLE1 {
	    font-size: 18px;
	    font-weight: bold;
    }
    a:hover{benc:expression(this.onmousemove = window.status="ERP 辅助系统")}
    -->
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="z-index: 99; position: absolute; top: 2px; background-color: transparent;
            width: 100%; text-align: right; left: 0px;">

            <script type="text/javascript">
		function time()
		{
			
		//使用new操作符创建时间对象 
		var now=new Date(); 
		var mName=now.getMonth()+1; 
		var dayNr=now.getDate(); 
		var dName=now.getDay(); 
		var hours=now.getHours(); 
		var minutes=((now.getMinutes()<10)?":0":":")+now.getMinutes(); 
		var seconds=((now.getSeconds()<10)?":0":":")+now.getSeconds();
		//判断今天是星期几 
		if(dName==1) Day="周一"; 
		if(dName==2) Day="周二"; 
		if(dName==3) Day="周三"; 
		if(dName==4) Day="周四"; 
		if(dName==5) Day="周五"; 
		if(dName==6) Day="周六"; 
		if(dName==7) Day="周日"; 
		if(document.getElementById("span_time")!=null)
		{
			document.getElementById("span_time").innerHTML=now.getYear() + "年" + mName+"月"+dayNr+"日 "+Day+" "+hours+minutes+seconds + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
		}
		setTimeout("time()",1000); 
		} 
		
            </script>

            <div style="background-color: transparent;">

                <script type="text/javascript">time();</script>

            </div>
            <span>欢迎您,&nbsp;&nbsp;<%=string.IsNullOrEmpty(CurrentUser.EmployeeName) ? CurrentUser.RightIsAdmin ? "超级管理&nbsp;[<strong><font color='Blue'>" + FounderTecInfoSys.Common.CommonFunction.FuncForDomain.GetUserName(
                                                            System.Configuration.ConfigurationManager.AppSettings["DomainName"],
                                                            System.Configuration.ConfigurationManager.AppSettings["NameOfLoginAD"],
                                                            System.Configuration.ConfigurationManager.AppSettings["PWDofLoginAD"],
                                                            CurrentUser.UserADAcount
                                                                                                  ) + "</font></strong>]" : CurrentUser.UserName : CurrentUser.EmployeeUnitName + "&nbsp;&nbsp;&nbsp;<strong><font color='Blue'>" + CurrentUser.EmployeeName + "</font></strong>"%>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;现在是:</span>
            <span id="span_time" style="background-color: transparent;"></span>
        </div>
        <table border="0" cellpadding="0" style="width: 100%;" cellspacing="0" id="logo">
            <tr>
                <td width="202">
                    <a href="#">
                        <img src="../../IMAGES/public_logo.jpg" alt="logo" width="202" height="60" border="0" /></a></td>
                <td background="../../IMAGES/top_bg.jpg">
                    <div style="width: 200px; text-align: right">
                        <span class="STYLE1">ERP 辅助系统</span></div>
                    <div style="text-align: right">
                        <span id="divToolBarForUserManage" visible="false" runat="server"><a href="../SQLReport/mainManageUser.aspx"
                            target="mainFrame" title="用户管理 - ERP报表和辅助系统综合管理">进入用户管理界面</a>&nbsp;&nbsp;&nbsp;&nbsp;
                        </span><span id="divToolBarForAddinReportManage" visible="false" runat="server"><a
                            href="mainManage.aspx" target="mainFrame" title="报表管理"">进入辅助系统管理界面</a>&nbsp;&nbsp;&nbsp;&nbsp;
                        </span><a href="main.aspx" target="mainFrame" title="ERP辅助系统">进入[辅助系统]</a>&nbsp;&nbsp;&nbsp;&nbsp;
                    </div>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
