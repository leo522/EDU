<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DeptSelectorForPassPort.ascx.cs" Inherits="DeptSelector" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<telerik:RadComboBox ID="rCBHosp" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rcbHosp_SelectedIndexChanged" Width="100px" Skin="Sunset">
</telerik:RadComboBox>
<telerik:RadComboBox ID="rCBDept" runat="server" AllowCustomText="True" Width="300px" Skin="Sunset" OnSelectedIndexChanged="rCBDept_SelectedIndexChanged">
</telerik:RadComboBox>
<telerik:RadComboBox ID="rCBTeacherName" runat="server" Skin="Sunset" AllowCustomText="True" Width="100px">
</telerik:RadComboBox>



