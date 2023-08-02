<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TreeViewComboBox.ascx.cs" Inherits="TreeViewComboBox" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

            <telerik:RadDropDownTree ID="RadDropDownTree1" runat="server" DefaultMessage="請選擇項目" OnDataBinding="RadDropDownTree1_DataBinding" Culture="zh-TW">
</telerik:RadDropDownTree>
<asp:Label ID="Label1" 
    runat="server" Text="X" BorderColor="Black" BorderWidth="1px" ToolTip="清除選取" Visible = "false"></asp:Label>

            <asp:Button ID="btnClear" runat="server" Text="X" ToolTip="清除選取" />



