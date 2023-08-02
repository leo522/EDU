﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="StudyTaskQuery.aspx.cs" Inherits="StudyTaskQuery" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<%@ Register src="VsSelector.ascx" tagname="VsSelector" tagprefix="uc1" %>

<%@ Register src="UserControls/EduTermSelect.ascx" tagname="EduTermSelect" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .auto-style3
        {
            width: 148px;
        }
        .auto-style4
        {
            width: 83px;
        }
        .auto-style6
        {
            height: 26px;
        }
        .auto-style10
        {
            width: 98px;
            height: 26px;
        }
        .auto-style11
        {
            width: 98px;
        }
        .auto-style13
        {
            width: 106px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div>
        <table width="100%">
            <tr>
                <td class="auto-style10">
        <asp:Label ID="Label6" runat="server" Text="學年度："></asp:Label>
                </td>
                <td class="auto-style6">
                    <asp:TextBox ID="tbEduYear" runat="server" Width="42px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style13">
                    <asp:Label ID="Label16" runat="server" Text="發送日期："></asp:Label>
                </td>
                <td colspan="3">
                    <table>
                        <tr>
                            <td>                    <telerik:RadDatePicker ID="rdpSendSDate" Runat="server" Width="150px">
                    </telerik:RadDatePicker></td>
                            <td>~</td>
                            <td>                    <telerik:RadDatePicker ID="rdpSendEDate" Runat="server" Width="150px">
                    </telerik:RadDatePicker></td>
                        </tr>
                    </table>

                </td>
            </tr>
            <tr>
                <td class="auto-style11">
        <asp:Label ID="Label9" runat="server" Text="填寫人："></asp:Label>
                </td>
                <td colspan="3">
                    <asp:TextBox ID="tbTarget" runat="server"></asp:TextBox>
                    <asp:Label ID="Label12" runat="server" Text="(職編或姓名)"></asp:Label>
                </td>
            </tr>

            <tr>
                <td class="auto-style11">
                    <asp:Button ID="btnQuery" runat="server" Text="查詢" OnClick="btnQuery_Click" />
                </td>
                <td>
                    <asp:Button ID="btnExport" runat="server" OnClick="btnExport_Click" Text="匯出" />
                </td>
                <td>
                    <asp:Button ID="btnDownload" runat="server" OnClick="btnDownload_Click" Text="下載所有表單" Visible="False" />
                </td>
                <td class="auto-style3">&nbsp;&nbsp;</td>
                <td class="auto-style13"></td>
                <td></td>
                <td class="auto-style4"></td>
                <td></td>
            </tr>
        </table>
    </div>
    <div>

        <telerik:RadGrid ID="rgData" runat="server" AutoGenerateColumns="False" 
            CellSpacing="0" GridLines="None" AllowMultiRowSelection="True" Culture="zh-TW" OnItemCreated="rgData_ItemCreated" OnNeedDataSource="rgData_NeedDataSource1">
            <ClientSettings>
                <Selecting AllowRowSelect="True" />
            </ClientSettings>
            <MasterTableView DataKeyNames="INSTANCE_ID,TargetType,TargetID,PARENT_INSTANCE_ID">
                <RowIndicatorColumn Visible="False">
                </RowIndicatorColumn>
                <Columns>
                    <telerik:GridClientSelectColumn FilterControlAltText="Filter column column" UniqueName="column">
                    </telerik:GridClientSelectColumn>
                    <telerik:GridBoundColumn DataField="INSTANCE_ID" FilterControlAltText="Filter INSTANCE_ID column" HeaderText="代碼" UniqueName="INSTANCE_ID">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="INSTANCE_NAME" FilterControlAltText="Filter INSTANCE_NAME column" HeaderText="表單" UniqueName="INSTANCE_NAME">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="CreateDate" 
                        FilterControlAltText="Filter CreateDate column" HeaderText="發送日" 
                        UniqueName="CreateDate">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="StatusName" FilterControlAltText="Filter StatusName column" HeaderText="狀態" UniqueName="StatusName">
                    </telerik:GridBoundColumn>
                    <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" UniqueName="TemplateColumn">
                        <ItemTemplate>
                            <asp:HyperLink ID="linkView" runat="server" Text="查看"></asp:HyperLink>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                </Columns>
            </MasterTableView>
        </telerik:RadGrid>
        <div>
        <asp:Panel ID="panAdmin" runat="server">
</asp:Panel>
        </div>
    
    </div>
</asp:Content>

