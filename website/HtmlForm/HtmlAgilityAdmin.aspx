<%@ Page Language="C#" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" MasterPageFile="~/Site.master" CodeFile="HtmlAgilityAdmin.aspx.cs" Inherits="List" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

<script type="text/javascript">
    String.prototype.Trim = function () { return this.replace(/(^\s*)|(\s*$)/g, ""); }
    function onClicking(sender, eventArgs) {
        var item = eventArgs.get_menuItem();
        if (item._element.innerText.Trim() == "刪除") {
            var proceed = confirm("刪除template將會刪除該template所有記錄，確定刪除?");
            if (!proceed) {
                eventArgs.set_cancel(true);
            }
        }
    }

    $telerik.getViewPortSize = function () {
        var width = 0;
        var height = 0;

        var canvas = document.body;

        if ((!$telerik.quirksMode && !$telerik.isSafari && !Telerik.Web.Browser.edge) ||
            (Telerik.Web.Browser.chrome && Telerik.Web.Browser.version >= 61)) {
            canvas = document.documentElement;
        }

        if (window.innerWidth) {
            // Seems there's no completely reliable way to get the viewport size in Gecko, this should be the best one
            // Check https://bugzilla.mozilla.org/show_bug.cgi?id=189112#c7
            width = Math.max(document.documentElement.clientWidth, document.body.clientWidth);
            height = Math.max(document.documentElement.clientHeight, document.body.clientHeight);

            if (width > window.innerWidth)
                width = document.documentElement.clientWidth;
            if (height > window.innerHeight)
                height = document.documentElement.clientHeight;
        }
        else {
            width = canvas.clientWidth;
            height = canvas.clientHeight;
        }

        width += canvas.scrollLeft;
        height += canvas.scrollTop;

        if ($telerik.isMobileSafari) {
            width += window.pageXOffset;
            height += window.pageYOffset;
        }

        return { width: width - 6, height: height - 6 };
    }
</script>


    <div>
        <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
        </telerik:RadWindowManager>
        &nbsp;<asp:TextBox ID="TextBox1" runat="server" Visible="False"></asp:TextBox>


        <asp:Button ID="btnDownload" runat="server" onclick="btnDownload_Click" 
            Text="下載HTML" />


    </div>
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server"
        width="300px" LoadingPanelID="RadAjaxLoadingPanel2">
    <table>
<tr>
<td>
    <asp:Button ID="btnAddRoot" runat="server" Text="上傳Template" 
        onclick="btnAddRoot_Click" />
<asp:Button ID="MoveToTop" runat="server" Text="移至最上層" Enabled="false" 
        onclick="MoveToTop_Click" Visible="False"/>
        <asp:Button ID="btnAddLibraryTemplate" runat="server" 
        onclick="btnAddLibraryTemplate_Click" Text="新增題庫表單" />
    

    <asp:CheckBox ID="cbDisplayDisable" runat="server" AutoPostBack="True" OnCheckedChanged="cbDisplayDisable_CheckedChanged" Text="顯示停用表單" />
    

</td>
</tr>
<tr>
<td>
        <telerik:RadTreeView ID="RadTreeView1" Runat="server" 
            oncontextmenuitemclick="RadTreeView1_ContextMenuItemClick" 
             OnClientContextMenuItemClicking="onClicking" AllowNodeEditing="True" 
            onnodedrop="RadTreeView1_NodeDrop" onnodeedit="RadTreeView1_NodeEdit" 
            onnodedatabound="RadTreeView1_NodeDataBound" 
            >
            <ContextMenus>
                <telerik:RadTreeViewContextMenu ID="RadTreeViewContextMenu1"  runat="server" RenderMode="Lightweight">
                    <Items>
                        <telerik:RadMenuItem runat="server" Text="更新表單">
                        </telerik:RadMenuItem>
                        <telerik:RadMenuItem runat="server" Text="新增子表">
                        </telerik:RadMenuItem>
                        <telerik:RadMenuItem runat="server" Text="維護" Target="_blank">
                        </telerik:RadMenuItem>
                        <telerik:RadMenuItem runat="server" Text="複製">
                        </telerik:RadMenuItem>
                        <telerik:RadMenuItem runat="server" Text="填寫">
                        </telerik:RadMenuItem>
                        <telerik:RadMenuItem runat="server" Text="停用">
                        </telerik:RadMenuItem>
                        <telerik:RadMenuItem runat="server" Text="啟用">
                        </telerik:RadMenuItem>
                        <telerik:RadMenuItem runat="server" Text="維護題庫">
                        </telerik:RadMenuItem>
                        <telerik:RadMenuItem runat="server" Text="統計">
                        </telerik:RadMenuItem>
                        <telerik:RadMenuItem runat="server" Text="刪除">
                        </telerik:RadMenuItem>
                    </Items>
                </telerik:RadTreeViewContextMenu>
            </ContextMenus>
        </telerik:RadTreeView>
</td>
</tr>

</table>
    </telerik:RadAjaxPanel>
    <telerik:RadTreeView ID="RadTreeView2" Runat="server">
    </telerik:RadTreeView>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel2" Runat="server" Skin="Default">
    </telerik:RadAjaxLoadingPanel>
</asp:Content>


