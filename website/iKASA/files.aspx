<%@ Page Language="C#" AutoEventWireup="true" CodeFile="files.aspx.cs" Inherits="iKASA_files" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<%@ Register src="~/DeptSelector.ascx" tagname="DeptSelector" tagprefix="uc3" %>

<%@ Register src="~/VsSelector.ascx" tagname="VsSelector" tagprefix="uc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
<style>

	.tab_css{display:flex;flex-wrap:wrap;justify-content:center;}
	.tab_css input{display:none}
	.tab_css label{margin: 0 5px 5px 0; padding: 10px 16px; cursor: pointer; border-radius: 5px; background: #999; color: #fff; opacity: 0.5;}
	.tab_content{order:1;display: none; width:100%; border-bottom: 3px solid #ddd; line-height: 1.6; font-size: .9em; padding: 15px; border: 1px solid #ddd; border-radius: 5px;}
	.tab_css input:checked + label, .tab_css label:hover{opacity: 1; font-weight:bold;}
	.tab_css input:checked + label + .tab_content{display: initial;}

body{
    font-family:微軟正黑體!important;
}
</style>
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
        <asp:Panel ID="panAdmin" runat="server" Visible="false" GroupingText="新增檔案">
            <asp:Label ID="Label1" runat="server" Text="顯示標題："></asp:Label>
            <asp:TextBox ID="tbTitle" runat="server" Width="202px"></asp:TextBox>
            <asp:Label ID="Label2" runat="server" Text="檔案說明："></asp:Label>
            <asp:TextBox ID="tbDescription" runat="server" Width="402px"></asp:TextBox>
            <br />
            <asp:Label ID="Label3" runat="server" Text="選擇檔案："></asp:Label>
            <asp:FileUpload ID="fu_file" runat="server" />
            <br />
            <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="新增" />
        </asp:Panel>

        <div>
            <table width="100%">
                <tr>
                    <td>
                        <div id="htmlContent">



                            <asp:Literal ID="liContent" runat="server"></asp:Literal>



                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
