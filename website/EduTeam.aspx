<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="EduTeam.aspx.cs" Inherits="EduTeam" MaintainScrollPositionOnPostback="true" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<%@ Register src="TreeViewComboBox.ascx" tagname="TreeViewComboBox" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <script type="text/javascript">
    String.prototype.Trim = function () { return this.replace(/(^\s*)|(\s*$)/g, ""); }
    function onClicking(sender, eventArgs) {
        var item = eventArgs.get_menuItem();
        if (item._element.innerText.Trim() == "刪除") {
            var proceed = confirm("確定刪除?");
            if (!proceed) {
                eventArgs.set_cancel(true);
            }
        }
    }

    function editNode() {
            var tree = $find("<%= RadTreeView1.ClientID %>");
            if (tree.get_selectedNode() != null) {
                tree.get_selectedNode().startEdit();
            }
        }

        function onClientContextMenuItemClicking(sender, args)
{
    if (args.get_menuItem().get_value() == 'Edit') {
        editNode();
        
    }
       
 }

</script>
    <asp:Label ID="Label1" runat="server" Text="位置："></asp:Label>
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx">首頁</asp:HyperLink>
    <asp:Label ID="Label2" runat="server" Text="&gt;"></asp:Label>
    <asp:HyperLink ID="HyperLink2" runat="server">學員管理</asp:HyperLink>
    <asp:Label ID="Label3" runat="server" Text="&gt;組別設定"></asp:Label>
    <br />
    <asp:Label ID="Label4" runat="server" Text="篩選組別："></asp:Label>
    <uc1:TreeViewComboBox ID="tvcbQuery" runat="server" AutoPostBack="True" />
    <asp:Button ID="btnClear" runat="server" onclick="btnQuery_Click" 
        Text="清除篩選條件" />
    <br />
<br />
    <asp:Label ID="Label5" runat="server" Text="欲新增組別名稱："></asp:Label>
    <asp:TextBox ID="tbTeamName" runat="server"></asp:TextBox>
    <br />
    <asp:Button ID="btnAdd" runat="server" onclick="btnAdd_Click" Text="新增" />
    &nbsp;&nbsp;
    <asp:Button ID="btnAddRoot" runat="server" onclick="btnAddRoot_Click" 
        Text="新增為根組別" />
    <br />
    <input id="btnEdit" type="button" value="編輯" onclick="editNode();" />
    &nbsp;&nbsp;
    <asp:Button ID="btnDelete" runat="server" onclick="btnDelete_Click" Text="刪除" />
    <telerik:RadTreeView ID="RadTreeView1" Runat="server" AllowNodeEditing="True" 
        EnableDragAndDrop="True" EnableDragAndDropBetweenNodes="True" 
    oncontextmenuitemclick="RadTreeView1_ContextMenuItemClick" 
    onnodeedit="RadTreeView1_NodeEdit" onnodedrop="RadTreeView1_NodeDrop" OnClientContextMenuItemClicking="onClientContextMenuItemClicking" >
        <ContextMenus>
            <telerik:RadTreeViewContextMenu ID="RadTreeViewContextMenu1" runat="server">
                <Items>
                    <telerik:RadMenuItem runat="server" Text="新增">
                    </telerik:RadMenuItem>
                    <telerik:RadMenuItem runat="server" PostBack="false" Value="Edit" Text="編輯">
                    </telerik:RadMenuItem>
                    <telerik:RadMenuItem runat="server" Text="刪除">
                    </telerik:RadMenuItem>
                </Items>
            </telerik:RadTreeViewContextMenu>
        </ContextMenus>
    </telerik:RadTreeView>
    <br />
    <br />
</asp:Content>

