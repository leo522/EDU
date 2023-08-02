<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ElearningContent.aspx.cs" Inherits="ElearningContent" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <telerik:RadGrid ID="rgContent" runat="server" AutoGenerateColumns="False" CellSpacing="0" GridLines="None" OnItemDataBound="rgContent_ItemDataBound" OnNeedDataSource="rgContent_NeedDataSource">
        <MasterTableView DataKeyNames="ItemID">
            <Columns>
                <telerik:GridBoundColumn DataField="ItemName" FilterControlAltText="Filter ItemName column" HeaderText="項目" UniqueName="ItemName">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="ItemType" FilterControlAltText="Filter ItemType column" HeaderText="類別" UniqueName="ItemType">
                    <HeaderStyle Width="80px" />
                </telerik:GridBoundColumn>
                <telerik:GridCheckBoxColumn DataField="isFinished" DataType="System.Boolean" FilterControlAltText="Filter isFinished column" HeaderText="已完成" UniqueName="isFinished">
                    <HeaderStyle Width="50px" />
                </telerik:GridCheckBoxColumn>
                <telerik:GridTemplateColumn FilterControlAltText="Filter colGo column" UniqueName="colGo">
                    <HeaderStyle Width="80px" />
                    <ItemTemplate>
                        <asp:Button ID="btnGo" runat="server" Text="" OnClick="btnGo_Click" />
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
            </Columns>
        </MasterTableView>
    </telerik:RadGrid>
</asp:Content>

