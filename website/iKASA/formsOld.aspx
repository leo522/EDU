<%@ Page Language="C#" AutoEventWireup="true" CodeFile="formsOld.aspx.cs" Inherits="iKASA_formsOld
    " %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

    <script src="//code.jquery.com/jquery-1.10.2.js"></script>

</head>
<body>
    <style>
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
        <div>

            <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="表單清單："></asp:Label>
            <telerik:RadComboBox ID="rcbFormList" Runat="server" AutoPostBack="True" Culture="zh-TW" OnSelectedIndexChanged="rcbFormList_SelectedIndexChanged" Width="350px">
            </telerik:RadComboBox>

        </div>
<asp:Label ID="lbNoData" runat="server" Text="查無相關資料" Font-Bold="True" Font-Size="Large" Visible="False"></asp:Label>
        <div id="htmlContent" runat="server">
    
        </div>
        <div align="center">
            <asp:Button ID="btnAttachment" runat="server" Text="表單附件" Visible="False" />
        </div>
    </form>
</body>
</html>
