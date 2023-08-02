<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="RecordActAdd.aspx.cs" Inherits="RecordActAdd" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div>
    <asp:Panel ID="Panel1" runat="server" GroupingText="建立會議記錄">
        <asp:Label ID="Label1" runat="server" Text="選擇會議記錄類別："></asp:Label>
        <telerik:RadComboBox ID="rcbRecordTemplate" Runat="server" Width="300px">
        </telerik:RadComboBox>
        <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="建立會議記錄" />
    </asp:Panel>
        </div>
    <div>

        <asp:Panel ID="Panel2" runat="server" GroupingText="我已建立的會議記錄">
            <telerik:RadGrid ID="rgMyList" runat="server" AutoGenerateColumns="False" CellSpacing="0" Culture="zh-TW" GridLines="None" OnNeedDataSource="rgMyList_NeedDataSource" OnItemDataBound="rgMyList_ItemDataBound">
                <MasterTableView DataKeyNames="InstanceID">
                    <Columns>
                        <telerik:GridBoundColumn FilterControlAltText="Filter column3 column" HeaderText="記錄類別" UniqueName="TemplateName" DataField="TemplateName">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn FilterControlAltText="Filter column column" HeaderText="會議主題" UniqueName="Title" DataField="Title">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn FilterControlAltText="Filter column1 column" HeaderText="會議時間" UniqueName="RecordTime" DataField="RecordTime">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn FilterControlAltText="Filter column2 column" HeaderText="狀態" UniqueName="StatusName" DataField ="StatusName">
                        </telerik:GridBoundColumn>
                        <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" UniqueName="TemplateColumn">
                            <ItemTemplate>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:ImageButton ID="btnEdit" ImageUrl="~/Images/edit-3.gif" runat="server" ToolTip="編輯" OnClick="btnEdit_Click" />
                                        </td>
                                        <td>
                                            <asp:ImageButton ID="btnDel" OnClientClick="if(!confirm('確定刪除該筆會議記錄?')){return false;}" ImageUrl="~/Images/delete.gif" runat="server" ToolTip="刪除" OnClick="btnDel_Click" />
                                        </td>
                                        <td>

                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                    </Columns>
                </MasterTableView>
            </telerik:RadGrid>
        </asp:Panel>

    </div>
</asp:Content>

