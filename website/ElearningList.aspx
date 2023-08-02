<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ElearningList.aspx.cs" Inherits="ElearningList" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <telerik:RadTabStrip ID="rtsPages" runat="server" MultiPageID="rmpPages" SelectedIndex="0">
        <Tabs>
            <telerik:RadTab runat="server" PageViewID="rpvSelectionClass" Text="課程清單" Selected="True">
            </telerik:RadTab>
            <telerik:RadTab runat="server" PageViewID="rpvMyClass" Text="我的課程">
            </telerik:RadTab>
        </Tabs>
    </telerik:RadTabStrip>
    <telerik:RadMultiPage ID="rmpPages" Runat="server" Width="98%" SelectedIndex="0">
        <telerik:RadPageView ID="rpvSelectionClass" runat="server">
            <table width="100%">
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="課程名稱："></asp:Label>
                        <asp:TextBox ID="tbName" runat="server"></asp:TextBox>
                    </td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td>
                        <asp:Button ID="btnQuery" runat="server" Text="查詢" OnClick="btnQuery_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
            <telerik:RadGrid ID="rgSelection" runat="server" AutoGenerateColumns="False" CellSpacing="0" GridLines="None" OnItemDataBound="rgSelection_ItemDataBound" OnNeedDataSource="rgSelection_NeedDataSource">
                    <MasterTableView DataKeyNames="ClassID">
                        <Columns>
                            <telerik:GridBoundColumn DataField="ClassName" FilterControlAltText="Filter ClassName column" HeaderText="課程名稱" UniqueName="ClassName">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="ClassDateStr" FilterControlAltText="Filter ClassDateStr column" HeaderText="時間範圍" UniqueName="ClassDateStr">
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn FilterControlAltText="Filter colCancel column" UniqueName="colBooking">
                                <ItemTemplate>
                                    <asp:Button ID="btnBooking" runat="server" Text="報名" OnClientClick="if(!confirm('確定報名?')) return false;" OnClick="btnBooking_Click" />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                        </Columns>
                    </MasterTableView>
            </telerik:RadGrid>
                    </td>
                </tr>
            </table>

        </telerik:RadPageView>
        <telerik:RadPageView ID="rpvMyClass" runat="server">
            <asp:Panel ID="panNotFinish" runat="server" GroupingText="未完成">
                <telerik:RadGrid ID="rgNotFinish" runat="server" AutoGenerateColumns="False" CellSpacing="0" GridLines="None" OnNeedDataSource="rgNotFinish_NeedDataSource">
                    <MasterTableView DataKeyNames="ClassID">
                        <Columns>

                            <telerik:GridBoundColumn DataField="ClassName" FilterControlAltText="Filter ClassName column" HeaderText="課程名稱" UniqueName="ClassName">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="ClassDateStr" FilterControlAltText="Filter ClassDateStr column" HeaderText="時間範圍" UniqueName="ClassDateStr">
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn FilterControlAltText="Filter colRead column" UniqueName="colRead">
                                <ItemTemplate>
                                    <asp:Button ID="btnRead" runat="server" Text="課程內容" OnClick="btnRead_Click" />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn FilterControlAltText="Filter colCancel column" UniqueName="colCancel">
                                <ItemTemplate>
                                    <asp:Button ID="btnCancel" runat="server" Text="取消報名" OnClientClick="if(!confirm('取消報名將會刪除該課程已完成內容，確定取消?')) return false;" OnClick="btnCancel_Click" />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>
            </asp:Panel>
            <asp:Panel ID="panFinished" runat="server" GroupingText="已完成">
                <telerik:RadGrid ID="rgFinished" runat="server" AutoGenerateColumns="False" CellSpacing="0" GridLines="None" OnNeedDataSource="rgFinished_NeedDataSource">
                    <MasterTableView DataKeyNames="ClassID">
                        <Columns>
                            <telerik:GridBoundColumn DataField="ClassName" FilterControlAltText="Filter ClassName column" HeaderText="課程名稱" UniqueName="ClassName">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="ClassDateStr" FilterControlAltText="Filter ClassDateStr column" HeaderText="時間範圍" UniqueName="ClassDateStr">
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn FilterControlAltText="Filter colRead column" UniqueName="colRead">
                                <ItemTemplate>
                                    <asp:Button ID="btnRead" runat="server" Text="課程內容" OnClick="btnRead_Click" />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>
            </asp:Panel>
        </telerik:RadPageView>
    </telerik:RadMultiPage>
</asp:Content>

