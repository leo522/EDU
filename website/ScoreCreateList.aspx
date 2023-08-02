<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ScoreCreateList.aspx.cs" Inherits="ScoreCreateList" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .auto-style1
        {
            width: 180px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <telerik:RadTabStrip ID="RadTabStrip1" runat="server" MultiPageID="RadMultiPage1" SelectedIndex="0">
        <Tabs>
            <telerik:RadTab runat="server" PageViewID="pvList" Text="已建立成績清單" Selected="True">
            </telerik:RadTab>
            <telerik:RadTab runat="server" PageViewID="pvScore" Text="成績單內容">
            </telerik:RadTab>
        </Tabs>
    </telerik:RadTabStrip>
    <telerik:RadMultiPage ID="RadMultiPage1" Runat="server" SelectedIndex="0">
        <telerik:RadPageView ID="pvList" runat="server" Selected="True">
            <div>
                <asp:Button ID="btnAddScore" runat="server" OnClick="btnAddScore_Click" Text="新增成績單" />
            </div>
            <div>
            <telerik:RadGrid ID="rgList" runat="server" AutoGenerateColumns="False" CellSpacing="0" GridLines="None">
                <MasterTableView DataKeyNames="InstanceID">
                    <Columns>
                        <telerik:GridBoundColumn DataField="DataSDate" FilterControlAltText="Filter DataSDate column" HeaderText="資料起始日" UniqueName="DataSDate">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="DataEDate" FilterControlAltText="Filter DataEDate column" HeaderText="資料結束日" UniqueName="DataEDate">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="CreaterName" FilterControlAltText="Filter CreaterName column" HeaderText="建立者" UniqueName="CreaterName">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="CreateDate" FilterControlAltText="Filter CreateDate column" HeaderText="建立時間" UniqueName="CreateDate">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="ModifierName" FilterControlAltText="Filter ModifierName column" HeaderText="最後修改人" UniqueName="ModifierName">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="ModifyDate" FilterControlAltText="Filter ModifyDate column" HeaderText="最後修改時間" UniqueName="ModifyDate">
                        </telerik:GridBoundColumn>
                        <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" UniqueName="CreateScore">
                            <ItemTemplate>
                                <asp:Button ID="btnQueryInstance" OnClick="btnQueryInstance_Click" runat="server" Text="查詢" />
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                    </Columns>
                </MasterTableView>
            </telerik:RadGrid>
            </div>
        </telerik:RadPageView>
        <telerik:RadPageView ID="pvScore" runat="server">
            <div>
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="時間範圍："></asp:Label>
                        </td>
                        <td>
                            <telerik:RadDatePicker ID="rdpSDate" Runat="server">
                            </telerik:RadDatePicker>
                        </td>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="~"></asp:Label>
                        </td>
                        <td class="auto-style1">
                            <telerik:RadDatePicker ID="rdpEDate" Runat="server">
                            </telerik:RadDatePicker>
                        </td>
                        <td>
                            <asp:Button ID="btnRefresh" runat="server" Text="刷新" OnClick="btnRefresh_Click" />
                        </td>
                        <td>
                            <asp:Button ID="btnSave" runat="server" Text="儲存" OnClick="btnSave_Click" />
                        </td>
                        <td>
                            <asp:Button ID="btnExport" runat="server" Text="匯出" OnClick="btnExport_Click" />
                        </td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td colspan="12">
                            <asp:Label ID="Label3" runat="server" ForeColor="Blue" Text="*自訂成績輸入後請按儲存鈕進行儲存，系統將自動重新計算平均分數"></asp:Label>
                        </td>
                    </tr>
                </table></div>
            <div>
                <telerik:RadGrid ID="rgScore" runat="server" CellSpacing="0" GridLines="None" AutoGenerateColumns="False" OnItemCreated="rgScore_ItemCreated" OnNeedDataSource="rgScore_NeedDataSource">
                    <MasterTableView DataKeyNames="員工編號"></MasterTableView>
                </telerik:RadGrid>
            </div>
        </telerik:RadPageView>
    </telerik:RadMultiPage>
</asp:Content>

