<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="EduFormManager.aspx.cs" Inherits="EduFormManager" %>

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
        <asp:Label ID="Label6" runat="server" Text="學年度："></asp:Label>
                </td>
                <td class="auto-style6">
                    <asp:TextBox ID="tbEduYear" runat="server" Width="42px"></asp:TextBox>
                </td>
                <td class="auto-style6">
        <asp:Label ID="Label5" runat="server" Text="職稱："></asp:Label>
                </td>
                <td class="auto-style7">
                    <telerik:RadDropDownTree ID="rddtJobCode" runat="server" DataFieldID="Code" DataFieldParentID="ParentCodeRefid" DataSourceID="dsJobCode" DataTextField="name" DataValueField="code" CheckBoxes="CheckChildNodes">
                    </telerik:RadDropDownTree>
                </td>
                <td class="auto-style12">
        <asp:Label ID="Label10" runat="server" Text="部門："></asp:Label>
                </td>
                <td class="auto-style6">
        
        <telerik:RadComboBox ID="ddlUnit" Runat="server" Filter="Contains">
        </telerik:RadComboBox>
        
                </td>
                <td class="auto-style9">
        <asp:Label ID="Label11" runat="server" Text="課程名稱："></asp:Label>
                </td>
                <td class="auto-style6">
                    <asp:TextBox ID="tbEduTermName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style11">
        <asp:Label ID="Label8" runat="server" Text="代碼："></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="tbInstaneID" runat="server" Width="41px"></asp:TextBox>
                </td>
                <td>
        <asp:Label ID="Label7" runat="server" Text="表單："></asp:Label>
                </td>
                <td colspan="3">
                    <telerik:RadComboBox Width="300px" ID="rcbTemplateID" Runat="server" AllowCustomText="True" Filter="Contains">
                    </telerik:RadComboBox>
                </td>
                <td class="auto-style4">
        <asp:Label ID="Label19" runat="server" Text="狀態："></asp:Label>
                </td>
                <td>
                    <telerik:RadComboBox ID="rcbStatus" Runat="server">
                        <Items>
                            <telerik:RadComboBoxItem runat="server" Selected="True" Text="全部" Value="all" />
                            <telerik:RadComboBoxItem runat="server" Text="逾期" Value="expire" />
                            <telerik:RadComboBoxItem runat="server" Text="已完成" Value="complete" />
                            <telerik:RadComboBoxItem runat="server" Text="未完成" Value="notcomplete" />
                        </Items>
                    </telerik:RadComboBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style11">
                    <asp:Label ID="Label15" runat="server" Text="逾期日期："></asp:Label>
                </td>
                <td colspan="3">
                    <table>
                        <tr>
                            <td>                    <telerik:RadDatePicker ID="rdpExpireSDate" Runat="server" Width="150px">
                    </telerik:RadDatePicker></td>
                            <td>~</td>
                            <td>                    <telerik:RadDatePicker ID="rdpExpireEDate" Runat="server" Width="150px">
                    </telerik:RadDatePicker></td>
                        </tr>
                    </table>

                </td>
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
                <td class="auto-style13">
                    <asp:Label ID="Label13" runat="server" Text="考核對象："></asp:Label>
                </td>
                <td colspan="3">
                    <asp:TextBox ID="tbEvalTarget" runat="server"></asp:TextBox>
                    <asp:Label ID="Label14" runat="server" Text="(職編或姓名)"></asp:Label>
                </td>
            </tr>

            <tr>
                <td colspan="3">
                    <asp:CheckBox ID="cbDisplaySelf" runat="server" Text="僅顯示自己建立的表單" />
                </td>
                <td class="auto-style3">
                    <asp:CheckBox ID="cbOverLimit" runat="server" Text="超出警示值" />
                </td>
                <td class="auto-style13"></td>
                <td></td>
                <td class="auto-style4"></td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style11">
                    <asp:Button ID="btnQuery" runat="server" Text="查詢" OnClick="btnQuery_Click" />
                </td>
                <td>
                    <asp:Button ID="btnExport" runat="server" OnClick="btnExport_Click" Text="匯出" />
                </td>
                <td>
                    <asp:Button ID="btnDownload" runat="server" OnClick="btnDownload_Click" Text="下載所有表單" />
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
            <MasterTableView DataKeyNames="INSTANCE_ID,TargetType,TargetID">
                <RowIndicatorColumn Visible="False">
                </RowIndicatorColumn>
                <Columns>
                    <telerik:GridClientSelectColumn FilterControlAltText="Filter column column" UniqueName="column">
                    </telerik:GridClientSelectColumn>
                    <telerik:GridBoundColumn DataField="INSTANCE_ID" FilterControlAltText="Filter INSTANCE_ID column" HeaderText="代碼" UniqueName="INSTANCE_ID">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="EduTermName" FilterControlAltText="Filter EduTermName column" HeaderText="課程" UniqueName="EduTermName">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="INSTANCE_NAME" FilterControlAltText="Filter INSTANCE_NAME column" HeaderText="表單" UniqueName="INSTANCE_NAME">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="TargetName" FilterControlAltText="Filter TargetName column" HeaderText="填寫人" UniqueName="TargetName">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="TargetTypeName" FilterControlAltText="Filter TargetTypeName column" HeaderText="填寫身分" UniqueName="TargetTypeName">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="EvalTargetName" FilterControlAltText="Filter EvalTargetName column" HeaderText="考核對象" UniqueName="EvalTargetName">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="CreateDate" 
                        FilterControlAltText="Filter CreateDate column" HeaderText="發送日" 
                        UniqueName="CreateDate">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="ExpireDate" FilterControlAltText="Filter ExpireDate column" HeaderText="逾期日" UniqueName="ExpireDate">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="StatusName" FilterControlAltText="Filter StatusName column" HeaderText="狀態" UniqueName="StatusName">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="BeforeFormStatus" FilterControlAltText="Filter BeforeFormStatus column" HeaderText="前置表單狀態" UniqueName="BeforeFormStatus">
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
            <table width="100%">
                <tr>
                    <td>
            <asp:Button ID="btnToNotFinish" runat="server" Text="退回表單" OnClick="btnToNotFinish_Click" />
                    </td>
                    </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label17" runat="server" Text="調整逾期日期："></asp:Label>
                        <telerik:RadDatePicker ID="rdpChangeExpireDate" Runat="server">
                        </telerik:RadDatePicker>
                        <asp:Button ID="btnChangeExpireDate" runat="server" Text="設定" OnClick="btnChangeExpireDate_Click" />
                    </td>
                    </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label18" runat="server" Text="修改填寫人："></asp:Label>
                        <uc1:VsSelector ID="VsSelector1" runat="server" />
                    &nbsp;<asp:Button ID="btnChangeTargetID" runat="server" Text="設定" OnClick="btnChangeTargetID_Click" />
                    </td>
                    </tr>
                <tr>
                    <td>

                        <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click"  OnClientClick="if(!confirm('刪除的表單將無法恢復，是否確定執行本動作?')){return false;}" Text="刪除" />

                    </td>
                </tr>
            </table>
</asp:Panel>
        </div>
    <asp:ObjectDataSource ID="dsJobCode" runat="server" SelectMethod="GetCodeRefsStatic" 
        TypeName="KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService" 
        DataObjectTypeName="KMU.EduActivity.ApplicationLayer.DTO.V_CodeRefDto">
        <SelectParameters>
            <asp:Parameter DefaultValue="EduAct_JobSerial" Name="codetype" />
        </SelectParameters>
    </asp:ObjectDataSource>
    
    </div>
</asp:Content>

