<%@ Page Language="C#" AutoEventWireup="true" CodeFile="JiaoZheng_List.aspx.cs" Inherits="JiaoZheng_List" %>

<%@ Register Assembly="Infragistics2.WebUI.UltraWebGrid.v8.1, Version=8.1.20081.1000, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebGrid" TagPrefix="igtbl" %>
    
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>异常矫正 列表</title>
    <link href="CSS/Style.css" type="text/css" rel="stylesheet"/>
    <script language="javascript" type="text/javascript" src="images/JS/My97DatePicker/WdatePicker.js"></script> 
     <script language="javascript" type="text/javascript">
     function linkFrames(link1)
     {
        //window.open(link1,"","","");
        window.showModalDialog(link1,"","dialogHeight:700px;dialogWidth:1024px");
        //window.open(link1,Target='mainFrame');
     }
     function Show(link1)
     {
        //window.open(link1,"","","");
        window.showModalDialog(link1,"","dialogHeight:300px;dialogWidth:600px");
     }
     </script>
</head>
<body>
    <form id="form1" runat="server">
   <div>
    <div class="top">
       异常矫正－－信息列表</div>
     <div><hr /></div>

     <table width="100%" style="height:100%">
        <tr>
            <td style="width: 199px">投诉日期：<asp:TextBox ID="Happen_Date_Start" runat="server" Text="" Width="113px" class="Wdate" onfocus="new WdatePicker(this,null,false,'whyGreen')"></asp:TextBox>&nbsp;</td>
            <td style="width: 155px">
                至<asp:TextBox ID="Happen_Date_End" runat="server" Text="" Width="120px" class="Wdate" onfocus="new WdatePicker(this,null,false,'whyGreen')"></asp:TextBox>&nbsp;</td>
            <td style="width: 71px"><asp:ImageButton ID="btn_search" ImageUrl="images/search.gif" runat="server" OnClick="btn_search_Click" />         </td>
            <td></td>
        </tr>
        <tr>
            <td colspan="5">
                &nbsp;<igtbl:UltraWebGrid ID="UltraWebGrid1" runat="server" Height="100%" Width="100%" OnInitializeRow="UltraWebGrid1_InitializeRow">
                    <Bands>
                        <igtbl:UltraGridBand>
                            <AddNewRow View="NotSet" Visible="NotSet">
                            </AddNewRow>
                            <Columns>
                                <igtbl:TemplatedColumn Width="30px">
                                    <Header Caption="查看">
                                    </Header>
                                    <CellTemplate>
                                        <a href="javascript:void(0)"  onclick="linkFrames('8D_View.aspx?FID=<%= CurrentFactoryID.ToString() %>&did=<%#DataBinder.Eval(Container.DataItem,"rkey") %>&type=view')">查看</a>
                                    </CellTemplate>
                                </igtbl:TemplatedColumn>
                                <igtbl:UltraGridColumn BaseColumnName="FilmApplyID"  Width="1px" Hidden="True">
                                    <Header Caption="">
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Footer>
                                </igtbl:UltraGridColumn>
                                <igtbl:UltraGridColumn BaseColumnName="Serial_No"  Width="95px">
                                    <Header Caption="编号">
                                        <RowLayoutColumnInfo OriginX="2" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="2" />
                                    </Footer>
                                </igtbl:UltraGridColumn>
                                <igtbl:UltraGridColumn BaseColumnName="Happen_Date" Width="60px">
                                    <Header Caption="发生日期">
                                        <RowLayoutColumnInfo OriginX="3" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="3" />
                                    </Footer>
                                </igtbl:UltraGridColumn>
                                <igtbl:UltraGridColumn  BaseColumnName="required_date" Width="70px">
                                    <Header Caption="要求回复日期">
                                        <RowLayoutColumnInfo OriginX="4" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="4" />
                                    </Footer>
                                </igtbl:UltraGridColumn>
                                <igtbl:UltraGridColumn  BaseColumnName="car_part_num" Width="100px">
                                    <Header Caption="异常料号/名称">
                                        <RowLayoutColumnInfo OriginX="5" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="5" />
                                    </Footer>
                                </igtbl:UltraGridColumn>
                                <igtbl:UltraGridColumn  BaseColumnName="from_comp" Width="100px">
                                    <Header Caption="发出单位">
                                        <RowLayoutColumnInfo OriginX="6" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="6" />
                                    </Footer>
                                </igtbl:UltraGridColumn>
                                <igtbl:UltraGridColumn BaseColumnName="car_comp" Width="50px">
                                    <Header Caption="异常单位">
                                        <RowLayoutColumnInfo OriginX="7" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="7" />
                                    </Footer>
                                </igtbl:UltraGridColumn>
                                <igtbl:UltraGridColumn  Width="95px">
                                    <Header Caption="类别">
                                        <RowLayoutColumnInfo OriginX="8" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="8" />
                                    </Footer>
                                </igtbl:UltraGridColumn>
                                <igtbl:UltraGridColumn  Width="95px">
                                    <Header Caption="状态">
                                        <RowLayoutColumnInfo OriginX="9" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="9" />
                                    </Footer>
                                </igtbl:UltraGridColumn>
                                <igtbl:TemplatedColumn Width="50px">
                                    <Header Caption="审批记录">
                                    </Header>
                                    <CellTemplate>
                                        <a href="javascript:void(0)" onclick="Show('ApprovalDetail.aspx?FID=<%= CurrentFactoryID.ToString() %>&did=<%#DataBinder.Eval(Container.DataItem,"rkey") %>')">点击查看</a>
                                    </CellTemplate>
                                </igtbl:TemplatedColumn>
                            </Columns>
                        </igtbl:UltraGridBand>
                    </Bands>
                    <DisplayLayout AutoGenerateColumns="False" AllowColSizingDefault="Free" AllowSortingDefault="OnClient" BorderCollapseDefault="Separate"
                        HeaderClickActionDefault="SortSingle" Name="UltraWebGrid1" RowHeightDefault="20px"
                        RowSelectorsDefault="No" StationaryMargins="Header" StationaryMarginsOutlookGroupBy="True"
                        TableLayout="Fixed" Version="4.00">
                        <GroupByBox>
                            <BoxStyle BackColor="ActiveBorder" BorderColor="Window">
                            </BoxStyle>
                        </GroupByBox>
                        <GroupByRowStyleDefault BackColor="Control" BorderColor="Window">
                        </GroupByRowStyleDefault>
                        <ActivationObject BorderColor="" BorderWidth="">
                        </ActivationObject>
                        <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                            <BorderDetails ColorLeft="White" ColorTop="White" WidthLeft="1px" WidthTop="1px" />
                        </FooterStyleDefault>
                        <RowStyleDefault BackColor="Window" BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px"
                            Font-Names="Microsoft Sans Serif" Font-Size="8.25pt">
                            <BorderDetails ColorLeft="Window" ColorTop="Window" />
                            <Padding Left="3px" />
                        </RowStyleDefault>
                        <FilterOptionsDefault>
                            <FilterOperandDropDownStyle BackColor="White" BorderColor="Silver" BorderStyle="Solid"
                                BorderWidth="1px" CustomRules="overflow:auto;" Font-Names="Verdana,Arial,Helvetica,sans-serif"
                                Font-Size="11px">
                                <Padding Left="2px" />
                            </FilterOperandDropDownStyle>
                            <FilterHighlightRowStyle BackColor="#151C55" ForeColor="White">
                            </FilterHighlightRowStyle>
                            <FilterDropDownStyle BackColor="White" BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px"
                                CustomRules="overflow:auto;" Font-Names="Verdana,Arial,Helvetica,sans-serif"
                                Font-Size="11px" Height="300px" Width="200px">
                                <Padding Left="2px" />
                            </FilterDropDownStyle>
                        </FilterOptionsDefault>
                        <HeaderStyleDefault BackColor="LightGray" BorderStyle="Solid" HorizontalAlign="Left">
                            <BorderDetails ColorLeft="White" ColorTop="White" WidthLeft="1px" WidthTop="1px" />
                        </HeaderStyleDefault>
                        <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                        </EditCellStyleDefault>
                        <FrameStyle BackColor="Window" BorderColor="InactiveCaption" BorderStyle="Solid"
                            BorderWidth="1px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="100%"
                            Width="100%">
                        </FrameStyle>
                        <Pager MinimumPagesForDisplay="2">
                            <PagerStyle BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                <BorderDetails ColorLeft="White" ColorTop="White" WidthLeft="1px" WidthTop="1px" />
                            </PagerStyle>
                        </Pager>
                        <AddNewBox>
                            <BoxStyle BackColor="Window" BorderColor="InactiveCaption" BorderStyle="Solid" BorderWidth="1px">
                                <BorderDetails ColorLeft="White" ColorTop="White" WidthLeft="1px" WidthTop="1px" />
                            </BoxStyle>
                        </AddNewBox>
                    </DisplayLayout>
                </igtbl:UltraWebGrid></td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>

