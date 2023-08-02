<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="MessageBoardShow.aspx.cs" Inherits="MessageBoardShow" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<script type="text/javascript">
    function DeleteBtnClick(id, postback) {
        if (confirm('確定刪除資料?')) {
            var lbtn = document.getElementById('<%=lbtnDel.ClientID %>');
            if (lbtn != null) {

                var hidden = document.getElementById('<%=hidMessageID.ClientID %>');
                hidden.value = id;

                if (postback) {
                    lbtn.click();
                }
            }
        }
    }
</script>
    <input type="hidden" id="hidMessageID" runat="server" />
    <div><asp:Literal ID="liMainThread" runat="server"></asp:Literal></div>
    <div><asp:Literal ID="liReplies" runat="server"></asp:Literal></div>
    <div>
    <asp:Panel ID="Panel1" runat="server" GroupingText="回應主題">
        <table>
            <tr>
                <td>
                    <a name="ReplyMessage"></a>
                    <asp:Label ID="Label2" runat="server" Text="內容："></asp:Label>
                </td>
                <td>
                    <telerik:RadEditor ID="reContent" Runat="server" EditModes="Design" Height="134px" Width="581px">
                        <Tools>
                            <telerik:EditorToolGroup Tag="MainToolbar">
                                <telerik:EditorTool Name="FindAndReplace" />
                                <telerik:EditorSeparator />
                                <telerik:EditorSplitButton Name="Undo">
                                </telerik:EditorSplitButton>
                                <telerik:EditorSplitButton Name="Redo">
                                </telerik:EditorSplitButton>
                                <telerik:EditorSeparator />
                                <telerik:EditorTool Name="Cut" />
                                <telerik:EditorTool Name="Copy" />
                                <telerik:EditorTool Name="Paste" ShortCut="CTRL+V" />
                            </telerik:EditorToolGroup>
                        </Tools>
                        <Content>
</Content>
                        <TrackChangesSettings CanAcceptTrackChanges="False" />
                    </telerik:RadEditor>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td align="right">

                    <asp:CheckBox ID="cbClose" runat="server" Text="結案" />

                    <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="送出" />

                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:LinkButton ID="lbtnDel" runat="server" OnClick="lbtnDel_Click"></asp:LinkButton>
                </td>
            </tr>


        </table>
    </asp:Panel>
    </div>
</asp:Content>

