<%@ Page Language="C#" AutoEventWireup="true" CodeFile="chart.aspx.cs" Inherits="iKASA_chart" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
body{
    font-family:微軟正黑體!important;
}
        .auto-style1 {
            height: 20px;
        }
    .RadGrid_Default{border:1px solid #828282;background-color:white;color:#333;font-family:"Segoe UI",Arial,Helvetica,sans-serif;font-size:12px;line-height:16px}.RadGrid_Default{border:1px solid #828282;background-color:white;color:#333;font-family:"Segoe UI",Arial,Helvetica,sans-serif;font-size:12px;line-height:16px}
.RadGrid_Default{border:1px solid #828282;background-color:white;color:#333;font-family:"Segoe UI",Arial,Helvetica,sans-serif;font-size:12px;line-height:16px}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
            <Scripts>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js">
                </asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js">
                </asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js">
                </asp:ScriptReference>
            </Scripts>
        </telerik:RadScriptManager>
    <div>
    <table width="100%">
        <tr>

            <td colspan="2" style="background-color:purple; color:white; text-align:center"><b>學習護照狀況</b></td>
        </tr>
        <tr>
            <td colspan="2">
                <telerik:RadGrid ID="rgList" runat="server" AllowSorting="True" AutoGenerateColumns="False" CellSpacing="0" Culture="zh-TW" GridLines="None" OnItemDataBound="rgList_ItemDataBound" Font-Names="微軟正黑體">
                    <ClientSettings>
                        <Selecting AllowRowSelect="True" />
                        <Scrolling AllowScroll="True" ScrollHeight="400px" />
                    </ClientSettings>
                    <AlternatingItemStyle Font-Names="微軟正黑體" Font-Size="Medium" />
                    <MasterTableView DataKeyNames="InstanceID,TemplateID">
                        <Columns>
                            <telerik:GridBoundColumn DataField="TemplateName" FilterControlAltText="Filter DeptName column" HeaderText="護照名稱" UniqueName="TemplateName">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="ThreeStepFinishRateStr" FilterControlAltText="Filter ModifyDate column" HeaderText="完成狀況(已完成/審核中/未完成/總數)" UniqueName="ThreeStepFinishRateStr">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="NecessaryFinishRate" FilterControlAltText="Filter NecessaryFinishRate column" HeaderText="必修完成率" UniqueName="NecessaryFinishRate">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="FinishRate" FilterControlAltText="Filter FinishRate column" HeaderText="總完成率" UniqueName="FinishRate">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="StudentFinishRate" FilterControlAltText="Filter StudentFinishRateStr column" HeaderText="學生完成率" UniqueName="StudentFinishRateStr">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </telerik:GridBoundColumn>
                        </Columns>
                    </MasterTableView>
                    <HeaderStyle Font-Names="微軟正黑體" Font-Size="Medium" />
                    <ItemStyle Font-Names="微軟正黑體" Font-Size="Medium" />
                </telerik:RadGrid>
                <asp:Chart ID="Chart2" runat="server" Height="350px" Width="500px" Visible="False">
                    <Series>
                        <asp:Series ChartType="StackedBar" LegendText="總完成率" Name="Series1" IsValueShownAsLabel="true" Legend="Legend1">
                        </asp:Series>
                        <asp:Series ChartArea="ChartArea1" LegendText="必修完成率" ChartType="StackedBar" Name="Series2" IsValueShownAsLabel="true" Legend="Legend1">
                        </asp:Series>
                        <asp:Series ChartArea="ChartArea1" LegendText="學生完成率" ChartType="StackedBar" Name="Series3" IsValueShownAsLabel="true" Legend="Legend1">
                        </asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1">
                        </asp:ChartArea>
                    </ChartAreas>
                    <Legends>
                        <asp:Legend Docking="Bottom" Name="Legend1">
                        </asp:Legend>
                    </Legends>
                </asp:Chart>
            </td>
        </tr>
        <tr>
            <td style="background-color:red; color:white; text-align:center"><b>教學評量狀況</b></td>
            <td style="background-color:purple; color:white; text-align:center"><b>臨床照顧能力 (Hands On)</b></td>
        </tr>
        <tr>
            <td style="text-align:center">
                <asp:Chart ID="Chart1" runat="server" Width="300px">
                    <Series>
                        <asp:Series ChartType="Pie" Name="Series1">
                        </asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1" >
                        </asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
            </td>
            <td class="auto-style1" style="max-width:500px; vertical-align:top" >

                <telerik:RadGrid ID="RadGrid1" runat="server" Culture="zh-TW" Height="150px" Width="99%" CellSpacing="0" GridLines="None" OnItemDataBound="RadGrid1_ItemDataBound" Skin="Office2007">
                    <ClientSettings>
                        <Scrolling AllowScroll="true" UseStaticHeaders="true" FrozenColumnsCount="1" />
                    </ClientSettings>
                    <AlternatingItemStyle Font-Names="微軟正黑體" Font-Size="Medium" />
                    <HeaderStyle Width="150px" Font-Names="微軟正黑體" Font-Size="Medium" />
                    <ItemStyle Font-Names="微軟正黑體" Font-Size="Medium" />
                </telerik:RadGrid>
                    
            </td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
