<%@ Page Language="C#" AutoEventWireup="true" CodeFile="forms.aspx.cs" Inherits="iKASA_forms" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

    <script src="//code.jquery.com/jquery-1.10.2.js"></script>

</head>
<body>
    <script>
        function QueryForm(fileid) {
            $('#<%=hdFileID.ClientID %>').val(fileid);
            __doPostBack('lbPostBack', '');
        }

        function ReturnPage() {
            var multiPage = $find("<%=rmp.ClientID %>");
                    multiPage.set_selectedIndex(0);
                }
    </script>
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
                    <asp:LinkButton ID="lbPostBack" runat="server" OnClick="lbPostBack_Click"></asp:LinkButton>
                    <asp:HiddenField ID="hdFileID" runat="server" />

        <div>
            <telerik:RadMultiPage ID="rmp" Runat="server" Width="90%" SelectedIndex="0">
                <telerik:RadPageView ID="rpvList" runat="server" Width="90%">
                    
<asp:Label ID="lbNoData" runat="server" Text="查無相關資料" Font-Bold="True" Font-Size="Large" Visible="False"></asp:Label>
                    <asp:Literal ID="liTable" runat="server" Text=""></asp:Literal>
                </telerik:RadPageView>
                <telerik:RadPageView ID="rpvForm" runat="server">
                    <asp:Button ID="btnReturn" runat="server" Text="回上一頁" OnClientClick="ReturnPage();return false;" />
        <div id="htmlContent" runat="server">
    
        </div>
        <div align="center">
            <asp:Button ID="btnAttachment" runat="server" Text="表單附件" Visible="False" />
        </div>

                </telerik:RadPageView>
            </telerik:RadMultiPage>
            <br />
            <br />

        </div>

    </form>
</body>
</html>
