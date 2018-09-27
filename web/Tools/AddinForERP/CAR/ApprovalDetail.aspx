<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ApprovalDetail.aspx.cs" Inherits="Tools_AddinForERP_CAR_ApprovalDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <meta http-equiv="pragma" content="no-cache" />
</head>
<body style="width:100%; height:100%; font-size:12px">
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="GridView1" Width="100%" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDataBound="GridView1_RowDataBound" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField HeaderText="步骤" DataField="SP_Step">
                    <ItemStyle Width="20px" />
                </asp:BoundField>
                <asp:BoundField HeaderText="审批人" DataField="SP_User">
                    <ItemStyle Width="50px" />
                </asp:BoundField>
                <asp:BoundField HeaderText="状态" DataField="Status">
                    <ItemStyle Width="50px" />
                </asp:BoundField>
                <asp:BoundField HeaderText="备注" DataField="SP_Content">
                    <ItemStyle Width="280px" />
                </asp:BoundField>
            </Columns>
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <EditRowStyle BackColor="#999999" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
