<%@ Page Language="C#" Theme="" AutoEventWireup="true" CodeFile="SearchCondition.aspx.cs" Inherits="Tools_SQLReport_SearchCondition" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1">
    <title>查询条件</title>
    <script type="text/javascript" language="JavaScript">
var iRow = 1;
function addRow() 
{ 
var newTr = tableOfWhere.insertRow(); 

var newTd0 = newTr.insertCell(); 
var newTd1 = newTr.insertCell(); 
var newTd2 = newTr.insertCell(); 
var newTd3 = newTr.insertCell(); 
var newTd4 = newTr.insertCell(); 
var newTd5 = newTr.insertCell(); 
var newTd6 = newTr.insertCell(); 

newTd0.innerHTML= ' '; 
newTd1.innerHTML= '<%=HtmlFieldControl() %>'; 
newTd2.innerHTML = '<select name="searchMath"><option value=">">大于</option><option value=">=">大于等于</option><option value="=">等于</option><option value="<">小于</option><option value="<=">小于等于</option><option value="<>">不等于</option><option value="Like">Like</option><option value="Not Like">Not Like</option><option value="IS">IS</option></select>'; 
newTd3.innerHTML= '<input name="searchValue" type="text" style="width:120px">'; 
newTd4.innerHTML= '<select name="searchAndOr" ><option value="0" selected="selected">  </option><option value=")">)</option><option value="AND">并且</option><option value=") AND">) 并且</option><option value="AND (">并且 (</option><option value=") AND (">) 并且 (</option><option value="OR">或者</option><option value=") OR">) 或者</option><option value="OR (">或者 (</option><option value=") OR (">) 或者 (</option></select>'; 
newTd5.innerHTML= '<input id="Button1" type="button" value="添加新条件" onclick="addRow();" />'; 
newTd6.innerHTML= '<input id="Button1" type="button" value="删除当前行" onclick="delRow()" />'; 
} 

function delRow()
{
    event.srcElement.parentElement.parentElement.parentElement.deleteRow(event.srcElement.parentElement.parentElement.rowIndex);
}


    </script>

</head>
<body>
    <form name="form1" method ="post" action ="ShowSql.aspx?ID=<%=CurrentFunctionID %>&FID=<%=CurrentFactoryID %> " target="masterFrame">
        <input id="Submit1" type="submit" value="提交" />
        <asp:Label ID="Label1" runat="server" Text="PS：如果将多次使用查询，请不要关闭此窗口。" ForeColor="Red"></asp:Label><br />
        <hr />
        <table id="tableOfWhere" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    <select name="searchSplit">
                        <option value=""></option>
                        <option value="(">(</option>
                    </select>
                </td>
                <td>
                    <%= HtmlFieldControl() %>
                </td>
                <td>
                    <select name="searchMath">
                        <option value=">">大于</option>
                        <option value=">=">大于等于</option>
                        <option value="=">等于</option>
                        <option value="<">小于</option>
                        <option value="<=">小于等于</option>
                        <option value="<>">不等于</option>
                        <option value="Like">Like</option>
                        <option value="Not Like">Not Like</option>
                        <option value="IS">IS</option>
                    </select>
                </td>
                <td>
                    <input name="searchValue" type="text" style="width: 120px">
                </td>
                <td>
                    <select name="searchAndOr">
                        <option value="0" selected="selected"></option>
                        <option value=")">)</option>
                        <option value="AND">并且</option>
                        <option value=") AND">) 并且</option>
                        <option value="AND (">并且 (</option>
                        <option value=") AND (">) 并且 (</option>
                        <option value="OR">或者</option>
                        <option value=") OR">) 或者</option>
                        <option value="OR (">或者 (</option>
                        <option value=") OR (">) 或者 (</option>
                    </select>
                </td>
                <td>
                    <input id="Button1" type="button" value="添加新条件" onclick="addRow();" />
                </td>
                <td>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
