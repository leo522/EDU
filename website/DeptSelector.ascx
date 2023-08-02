<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DeptSelector.ascx.cs" Inherits="DeptSelector" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<telerik:RadComboBox ID="rcbHosp" Runat="server" AutoPostBack="True" OnSelectedIndexChanged="rcbHosp_SelectedIndexChanged" Width="150px">
</telerik:RadComboBox>
                                    <telerik:RadComboBox ID="ddlUnit" runat="server"
                                        AllowCustomText="True" MarkFirstMatch="True" Width="250px" Filter="Contains">
                                    </telerik:RadComboBox>
                                    
