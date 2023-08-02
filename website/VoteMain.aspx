<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="VoteMain.aspx.cs" Inherits="VoteMain" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" CellSpacing="0" Culture="zh-TW" GridLines="None" OnNeedDataSource="RadGrid1_NeedDataSource" OnItemDataBound="RadGrid1_ItemDataBound">
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
                         <asp:Button ID="GoVote" runat="server" OnClick="GoVote_Click" Text="投票" />
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
            </Columns>
        </MasterTableView>
    </telerik:RadGrid>
</asp:Content>

