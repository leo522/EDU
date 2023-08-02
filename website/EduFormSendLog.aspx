<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="EduFormSendLog.aspx.cs" Inherits="EduFormSendLog" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<div>
<table>
<tr>
<td>
        <asp:Label ID="Label29" runat="server" Text="部門："></asp:Label></td>
        <td>
        <telerik:RadComboBox ID="ddlUnit" Runat="server">
        </telerik:RadComboBox></td>
        <td>
            <asp:Label ID="Label30" runat="server" Text="記錄時間範圍："></asp:Label>
    </td>
        <td>
            <telerik:RadDatePicker ID="rdpSdate" Runat="server">
            </telerik:RadDatePicker>
    </td>
        <td>
            <asp:Label ID="Label31" runat="server" Text="~"></asp:Label>
    </td>
        <td>
            <telerik:RadDatePicker ID="rdpEdate" Runat="server">
            </telerik:RadDatePicker>
    </td>
        <td>
    <asp:Button ID="btnQuery" runat="server" onclick="btnQuery_Click" Text="查詢" />
    </td>
</tr>
</table>

</div>
<div>

    <telerik:RadGrid ID="rgContent" runat="server" AutoGenerateColumns="False" 
        CellSpacing="0" Culture="zh-TW" GridLines="None">
        <MasterTableView>
            <Columns>
                <telerik:GridDateTimeColumn DataField="LogTime" 
                    FilterControlAltText="Filter LogTime column" HeaderText="記錄時間" 
                    UniqueName="LogTime">
                    <HeaderStyle Width="200px" />
                </telerik:GridDateTimeColumn>
                <telerik:GridBoundColumn DataField="LogContent" 
                    FilterControlAltText="Filter LogContent column" HeaderText="訊息" 
                    UniqueName="LogContent">
                </telerik:GridBoundColumn>
            </Columns>
        </MasterTableView>
    </telerik:RadGrid>

</div>
</asp:Content>

