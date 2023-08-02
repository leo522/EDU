<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="VoteManage.aspx.cs" Inherits="VoteManage" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:Panel ID="Panel1" runat="server">
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="投票開始日期："></asp:Label>
                </td>
                <td>
                    <telerik:RadDatePicker ID="rdpSdateS" Runat="server">
                    </telerik:RadDatePicker>
                </td>
                <td>~</td>
                <td>
                    <telerik:RadDatePicker ID="rdpSdateE" Runat="server">
                    </telerik:RadDatePicker>
                </td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="投票項目："></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="tbKeyWord" runat="server"></asp:TextBox>
                </td>
                <td></td>
                <td>
                    <asp:Button ID="btnQuery" runat="server" OnClick="btnQuery_Click" Text="查詢" />
                </td>
                <td></td>
                <td></td>
            </tr>
        </table>
    </asp:Panel>
    <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" CellSpacing="0" Culture="zh-TW" GridLines="None" OnNeedDataSource="RadGrid1_NeedDataSource">
        <MasterTableView DataKeyNames="ID">
            <Columns>
                <telerik:GridBoundColumn DataField="VoteName" FilterControlAltText="Filter VoteName column" HeaderText="投票項目" UniqueName="VoteName">
                </telerik:GridBoundColumn>
                <telerik:GridDateTimeColumn DataField="Sdate" FilterControlAltText="Filter Sdate column" HeaderText="開始日期" UniqueName="Sdate" DataFormatString="{0:yyyy/MM/dd}">
                    <HeaderStyle Width="100px" />
                </telerik:GridDateTimeColumn>
                <telerik:GridDateTimeColumn DataField="Edate" FilterControlAltText="Filter Edate column" HeaderText="結束日期" UniqueName="Edate" DataFormatString="{0:yyyy/MM/dd}">
                    <HeaderStyle Width="100px" />
                </telerik:GridDateTimeColumn>
                <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" UniqueName="TemplateColumn">
                    <HeaderStyle Width="60px" />
                    <ItemTemplate>
                        <table>
                            <tr>
                                <td><asp:Button ID="btnEdit" runat="server" OnClick="btnEdit_Click" Text="編輯" /> </td>
                                <td><asp:Button ID="btnVoteStastic" runat="server" OnClick="btnVoteStastic_Click" Text="統計" /></td>
                                <td><asp:Button ID="btnVoteList" runat="server" OnClick="btnVoteList_Click" Text="即時清單" /> </td>
                                <td><asp:Button ID="btnCopy" runat="server" OnClick="btnCopy_Click" Text="複製投票" /> </td>
                                <td><asp:Button ID="btnView" runat="server" OnClick="btnView_Click" Text="預覽" /> </td>
                            </tr>
                        </table>
                         
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
            </Columns>
        </MasterTableView>
    </telerik:RadGrid>
</asp:Content>

