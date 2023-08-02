<%@ Control Language="C#" AutoEventWireup="true" CodeFile="VsSelector.ascx.cs" Inherits="VsSelector" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
        <asp:Label ID="Label1" runat="server" Text="員編:"></asp:Label>
        <asp:TextBox ID="tbEmpCode" runat="server" Width="59px" style="width:59px"></asp:TextBox>
        <asp:Label ID="Label2" runat="server" Text="姓名:"></asp:Label>
        <asp:TextBox ID="tbName" runat="server" Width="57px" style="width:57px"></asp:TextBox>
        <asp:Button ID="btnQuery" runat="server" onclick="btnQuery_Click" Text="查詢" />
        &nbsp;
        <telerik:RadComboBox ID="rcbSelection" Runat="server" AllowCustomText="True" 
            Filter="Contains" ViewStateMode="Enabled" >
        </telerik:RadComboBox>
