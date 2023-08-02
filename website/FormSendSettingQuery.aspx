<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="FormSendSettingQuery.aspx.cs" Inherits="FormSendSettingQuery" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<%@ Register src="DeptSelector.ascx" tagname="DeptSelector" tagprefix="uc1" %>

<%@ Register src="TreeViewComboBox.ascx" tagname="TreeViewComboBox" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}
.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div>

        <asp:Label ID="Label29" runat="server" Text="部門："></asp:Label>
        <uc1:DeptSelector ID="DeptSelector1" runat="server" />

    </div>
    <div>
        <asp:Label ID="Label5" runat="server" Text="職稱："></asp:Label>
                    <telerik:RadDropDownTree ID="rddtJobCode" runat="server" DataFieldID="Code" DataFieldParentID="ParentCodeRefid" DataSourceID="dsJobCode" DataTextField="name" DataValueField="code" CheckBoxes="CheckChildNodes">
                    </telerik:RadDropDownTree>
                </div>
    <div>
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label30" runat="server" Text="時間範圍："></asp:Label>
                </td>
                <td>
                    <telerik:RadDatePicker ID="rdpSDate" Runat="server">
                    </telerik:RadDatePicker>
                </td>
                <td>~</td>
                <td>
                    <telerik:RadDatePicker ID="rdpEDate" Runat="server">
                    </telerik:RadDatePicker>
                </td>
                <td>
                    <asp:Button ID="btnQuery" runat="server" OnClick="btnQuery_Click" Text="查詢" />
                </td>
                <td>

                    <asp:Button ID="btnExport" runat="server" OnClick="btnExport_Click" Text="匯出" />

                </td>
            </tr>
        </table>
    </div>
    <div>
        <asp:CheckBox ID="cbShowAll" runat="server" AutoPostBack="True" OnCheckedChanged="cbShowAll_CheckedChanged" Text="顯示已發送設定" />
    </div>
    <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" CellSpacing="0" Culture="zh-TW" GridLines="None" OnNeedDataSource="RadGrid1_NeedDataSource">
        <MasterTableView>
            <Columns>
                <telerik:GridBoundColumn DataField="EduTermName" FilterControlAltText="Filter EduTermName column" HeaderText="課程" UniqueName="EduTermName">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="EduTermDate" FilterControlAltText="Filter EduTermDate column" HeaderText="課程時間" UniqueName="EduTermDate">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="DeptName" FilterControlAltText="Filter DeptName column" HeaderText="科別" UniqueName="DeptName">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="SettingName" FilterControlAltText="Filter SettingName column" HeaderText="設定名稱" UniqueName="SettingName">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="TEMPLATE_NAME" FilterControlAltText="Filter TEMPLATE_NAME column" HeaderText="表單" UniqueName="TEMPLATE_NAME">
                </telerik:GridBoundColumn>
                <telerik:GridDateTimeColumn DataField="ExecuteDate" FilterControlAltText="Filter ExecuteDate column" HeaderText="應發送日" UniqueName="ExecuteDate">
                </telerik:GridDateTimeColumn>
                <telerik:GridBoundColumn DataField="SettingStatus" FilterControlAltText="Filter SettingStatus column" HeaderText="設定狀況" UniqueName="SettingStatus">
                </telerik:GridBoundColumn>
            </Columns>
        </MasterTableView>
    </telerik:RadGrid>
    <br />
            <asp:ObjectDataSource ID="dsJobCode" runat="server" DataObjectTypeName="KMU.EduActivity.ApplicationLayer.DTO.V_CodeRefDto" SelectMethod="GetCodeRefsStatic" TypeName="KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService">
                <SelectParameters>
                    <asp:Parameter DefaultValue="EduAct_JobSerial" Name="codetype" />
                </SelectParameters>
            </asp:ObjectDataSource>
         </asp:Content>

