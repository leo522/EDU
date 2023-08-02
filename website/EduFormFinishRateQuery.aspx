<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="EduFormFinishRateQuery.aspx.cs" Inherits="EduFormFinishRateQuery" %>

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
        .auto-style7
        {
            width: 148px;
            height: 26px;
        }
        .auto-style9
        {
            width: 83px;
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
        .auto-style12
        {
            width: 106px;
            height: 26px;
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
        <asp:Label ID="Label5" runat="server" Text="課程職稱："></asp:Label>
                </td>
                <td class="auto-style6">
                    <telerik:RadDropDownTree ID="rddtJobCode" runat="server" DataFieldID="Code" DataFieldParentID="ParentCodeRefid" DataSourceID="dsJobCode" DataTextField="name" DataValueField="code" CheckBoxes="CheckChildNodes">
                    </telerik:RadDropDownTree>
                </td>
                <td class="auto-style6">
        <asp:Label ID="Label10" runat="server" Text="課程部門："></asp:Label>
                </td>
                <td class="auto-style7">
        
        <telerik:RadComboBox ID="ddlUnit" Runat="server" Filter="Contains">
        </telerik:RadComboBox>
        
                </td>
                <td class="auto-style12">
                    &nbsp;</td>
                <td class="auto-style6">
        
                    &nbsp;</td>
                <td class="auto-style9">
                    &nbsp;</td>
                <td class="auto-style6">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style11">
        <asp:Label ID="Label7" runat="server" Text="表單："></asp:Label>
                </td>
                <td>
                    <telerik:RadComboBox Width="300px" ID="rcbTemplateID" Runat="server" AllowCustomText="True" Filter="Contains">
                    </telerik:RadComboBox>
                </td>
                <td>
                    <asp:Label ID="Label16" runat="server" Text="*發送日期："></asp:Label>
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
                <td class="auto-style4">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style11">
        <asp:Label ID="Label9" runat="server" Text="填寫人："></asp:Label>
                </td>
                <td colspan="3">
                    <table>
                        <tr>
                            <td>                    
                    <asp:TextBox ID="tbTarget" runat="server"></asp:TextBox>
                            </td>
                            <td>
                    <asp:Label ID="Label12" runat="server" Text="(職編或姓名)"></asp:Label>
<asp:CheckBox ID="cbExNotFinish" runat="server" Text="包含上一位填寫者未完成表單" />
                            </td>
                        </tr>
                    </table>

                </td>
                <td colspan="4" class="auto-style13">
        <asp:Label ID="Label18" runat="server" Text="填寫人部門："></asp:Label>
        
        <telerik:RadComboBox ID="ddlUnit0" Runat="server" Filter="Contains">
        </telerik:RadComboBox>
        
                </td>

            </tr>
            <tr>
                <td>

        <asp:Label ID="Label17" runat="server" Text="填寫人職稱："></asp:Label>

                </td>
                <td colspan="3">

                    <telerik:RadComboBox ID="ddlJobCode" Runat="server" Filter="Contains" 
                        Width="400px" ViewStateMode="Enabled" CheckBoxes="True">
                    </telerik:RadComboBox>

                </td>
                <td>

                </td>
                <td>

                </td>
                <td>

                </td>
                <td>

                </td>
            </tr>
            <tr>
                <td class="auto-style11">
                    <asp:Button ID="btnQuery" runat="server" Text="查詢" OnClick="btnQuery_Click" />
                </td>
                <td>
                    <asp:Button ID="btnExport" runat="server" OnClick="btnExport_Click" Text="匯出" />
                </td>
                <td></td>
                <td class="auto-style3"></td>
                <td class="auto-style13"></td>
                <td></td>
                <td class="auto-style4"></td>
                <td></td>
            </tr>
        </table>
    </div>
    <div>

        <telerik:RadGrid ID="rgData" runat="server" AutoGenerateColumns="False" 
            CellSpacing="0" GridLines="None" AllowMultiRowSelection="True" Culture="zh-TW" OnItemCreated="rgData_ItemCreated" OnNeedDataSource="rgData_NeedDataSource">
            <ClientSettings>
                <Selecting AllowRowSelect="True" />
            </ClientSettings>
            <MasterTableView DataKeyNames="SeqNo">
                <RowIndicatorColumn Visible="False">
                </RowIndicatorColumn>
                <Columns>
                    <telerik:GridBoundColumn DataField="EmpCode" FilterControlAltText="Filter EmpCode column" HeaderText="職編" UniqueName="EmpCode">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="EmpName" FilterControlAltText="Filter TargetName column" HeaderText="姓名" UniqueName="EmpName">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="AllCount" FilterControlAltText="Filter AllCount column" HeaderText="總表單數" UniqueName="AllCount">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="FinishCount" FilterControlAltText="Filter FinishCount column" HeaderText="完成表單數" UniqueName="FinishCount">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="NotFinishCount" FilterControlAltText="Filter NotFinishCount column" HeaderText="未完成表單數" UniqueName="NotFinishCount">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="FinishRate" FilterControlAltText="Filter FinishRate column" HeaderText="完成率" UniqueName="FinishRate">
                    </telerik:GridBoundColumn>
                    <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" UniqueName="TemplateColumn">
                        <ItemTemplate>
                            <asp:Button ID="btnExportDet" runat="server" Text="匯出明細" OnClick="btnExportDet_Click"></asp:Button>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                </Columns>
            </MasterTableView>
        </telerik:RadGrid>
        <div>

        </div>
    <asp:ObjectDataSource ID="dsJobCode" runat="server" SelectMethod="GetCodeRefsStatic" 
        TypeName="KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService" 
        DataObjectTypeName="KMU.EduActivity.ApplicationLayer.DTO.V_CodeRefDto">
        <SelectParameters>
            <asp:Parameter DefaultValue="EduAct_JobSerial" Name="codetype" />
        </SelectParameters>
    </asp:ObjectDataSource>
    
        <br />
    
    </div>
</asp:Content>

