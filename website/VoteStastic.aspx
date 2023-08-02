<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="VoteStastic.aspx.cs" Inherits="VoteStastic" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:Panel ID="Panel1" runat="server">
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="投票項目："></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lbVoteName" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="時間範圍："></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lbVoteRange" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="投票人數："></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lbVoteCount" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnExport" runat="server" Text="匯出" OnClick="btnExport_Click" />
                </td>
                <td>
                    <asp:Button ID="btnReturn" runat="server" OnClick="btnReturn_Click" Text="返回" />
                </td>
            </tr>


        </table>
    </asp:Panel>
    <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" CellSpacing="0" Culture="zh-TW" GridLines="None" OnNeedDataSource="RadGrid1_NeedDataSource">
        <MasterTableView GroupLoadMode="Client" GroupsDefaultExpanded="true">

            <GroupByExpressions>

                <telerik:GridGroupByExpression>

                    <SelectFields>

                        <telerik:GridGroupByField FieldAlias="GroupName" FieldName="GroupName"></telerik:GridGroupByField>

                    </SelectFields>

                    <GroupByFields>

                        <telerik:GridGroupByField FieldName="GroupName"></telerik:GridGroupByField>

                    </GroupByFields>

                </telerik:GridGroupByExpression>

            </GroupByExpressions>
            <Columns>
                <telerik:GridBoundColumn DataField="ItemValue" FilterControlAltText="Filter ItemValue column" HeaderText="代碼" UniqueName="ItemValue">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="ItemName" FilterControlAltText="Filter VoteName column" HeaderText="項目" UniqueName="ItemName">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="DataCount" FilterControlAltText="Filter DataCount column" HeaderText="票數" UniqueName="DataCount">
                </telerik:GridBoundColumn>
            </Columns>
        </MasterTableView>
    </telerik:RadGrid>
</asp:Content>

