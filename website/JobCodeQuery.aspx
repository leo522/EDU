<%@ Page Language="C#" AutoEventWireup="true" CodeFile="JobCodeQuery.aspx.cs" Inherits="JobCodeQuery" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

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

            <telerik:RadTreeView ID="RadTreeView1" Runat="server" DataSourceID="dsJobCode" >
                <NodeTemplate>
                <table>
                <tr>
                <td><%# Eval("Name") %></td>
                <td><input type="text" readonly="readonly" value="<%# Eval("Code") %>"></td>
                </tr>
                </table>
                </NodeTemplate>
            </telerik:RadTreeView>


    </div>
    
    <asp:ObjectDataSource ID="dsJobCode" runat="server" SelectMethod="GetJobCodes" 
        TypeName="KMU.EduActivity.ApplicationLayer.DTO.SelectEduActJobCodeDto">
    </asp:ObjectDataSource>

    </form>
</body>
</html>
