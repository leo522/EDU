<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EduTeamQuery.aspx.cs" Inherits="EduTeamQuery" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<%@ Register src="TreeViewComboBox.ascx" tagname="TreeViewComboBox" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>


    <form id="form1" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Assembly="Telerik.Web.UI" 
                Name="Telerik.Web.UI.Common.Core.js">
            </asp:ScriptReference>
            <asp:ScriptReference Assembly="Telerik.Web.UI" 
                Name="Telerik.Web.UI.Common.jQuery.js">
            </asp:ScriptReference>
            <asp:ScriptReference Assembly="Telerik.Web.UI" 
                Name="Telerik.Web.UI.Common.jQueryInclude.js">
            </asp:ScriptReference>
        </Scripts>
    </telerik:RadScriptManager>
    <div>

    <asp:Label ID="Label4" runat="server" Text="篩選組別："></asp:Label>
    <uc1:TreeViewComboBox ID="tvcbQuery" runat="server" AutoPostBack="True" />
    <asp:Button ID="btnClear" runat="server" onclick="btnQuery_Click" 
        Text="清除篩選條件" />
            <telerik:RadTreeView ID="RadTreeView1" Runat="server" >
                <NodeTemplate>
                <table>
                <tr>
                <td><%# Eval("EduTeamName") %></td>
                <td><input type="text" readonly="readonly" value="<%# Eval("EduTeamCode") %>"></td>
                </tr>
                </table>
                </NodeTemplate>
            </telerik:RadTreeView>


    </div>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadTreeView1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="tbCode" UpdatePanelCssClass="" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    </form>
</body>
</html>
