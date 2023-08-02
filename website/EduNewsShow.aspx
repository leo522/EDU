<%@ Page Language="C#" MasterPageFile="~/Empty.master" AutoEventWireup="true" CodeFile="EduNewsShow.aspx.cs" Inherits="EduNewsShow" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<%@ Register src="VsSelector.ascx" tagname="VsSelector" tagprefix="uc1" %>

<%@ Register src="TreeViewComboBox.ascx" tagname="TreeViewComboBox" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<style>
table{
  border: 0px solid black;
  border-spacing: 0px;
}

table thead tr{
  font-family: Arial, monospace;
  font-size: 14px;
}

table thead tr th{
  border-bottom: 2px solid black;
  border-top: 1px solid black;
  margin: 0px;
  padding: 2px;
  background-color: #cccccc;
}

table tr {
  font-family: arial, monospace;
  color: black;
  font-size:12px;
  background-color: white;
}

table tr.odd {
  background-color: #AAAAAA;
}

table tr td, th{
  border-bottom: 1px solid black;
  padding: 2px;
}

a:link{
  font-family:arial, monospace;
  text-decoration: none;
  color: teal;
}

a:hover{
  text-decoration: underline;
}

a:visited{
  color:black;
  text-decoration: none;
}

.RadGrid_Default{border:1px solid #828282;background-color:white;color:#333;font-family:"Segoe UI",Arial,Helvetica,sans-serif;font-size:12px;line-height:16px}.RadGrid_Default{border:1px solid #828282;background-color:white;color:#333;font-family:"Segoe UI",Arial,Helvetica,sans-serif;font-size:12px;line-height:16px}.RadGrid_Default{border:1px solid #828282;background-color:white;color:#333;font-family:"Segoe UI",Arial,Helvetica,sans-serif;font-size:12px;line-height:16px}
.RadGrid_Default{border:1px solid #828282;background-color:white;color:#333;font-family:"Segoe UI",Arial,Helvetica,sans-serif;font-size:12px;line-height:16px}.RadGrid .rgMasterTable{border-collapse:separate;border-spacing:0}.RadGrid_Default .rgMasterTable{font-family:"Segoe UI",Arial,Helvetica,sans-serif;font-size:12px;line-height:16px}.RadGrid .rgMasterTable{border-collapse:separate;border-spacing:0}.RadGrid_Default .rgMasterTable{font-family:"Segoe UI",Arial,Helvetica,sans-serif;font-size:12px;line-height:16px}.RadGrid .rgMasterTable{border-collapse:separate;border-spacing:0}.RadGrid_Default .rgMasterTable{font-family:"Segoe UI",Arial,Helvetica,sans-serif;font-size:12px;line-height:16px}.RadGrid .rgMasterTable{border-collapse:separate;border-spacing:0}.RadGrid_Default .rgMasterTable{font-family:"Segoe UI",Arial,Helvetica,sans-serif;font-size:12px;line-height:16px}.RadGrid table.rgMasterTable tr .rgExpandCol{padding-left:0;padding-right:0;text-align:center}.RadGrid table.rgMasterTable tr .rgExpandCol{padding-left:0;padding-right:0;text-align:center}.RadGrid table.rgMasterTable tr .rgExpandCol{padding-left:0;padding-right:0;text-align:center}.RadGrid table.rgMasterTable tr .rgExpandCol{padding-left:0;padding-right:0;text-align:center}.RadGrid .rgHeader{cursor:default}
        .RadGrid .rgHeader{padding-left:7px;padding-right:7px}.RadGrid .rgHeader{padding-top:5px;padding-bottom:4px;text-align:left;font-weight:normal}.RadGrid_Default .rgHeader{border:0;border-bottom:1px solid #828282;background:#eaeaea 0 -2300px repeat-x url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Grid.sprite.gif')}.RadGrid_Default .rgHeader{color:#333}.RadGrid .rgHeader{cursor:default}.RadGrid .rgHeader{padding-left:7px;padding-right:7px}.RadGrid .rgHeader{padding-top:5px;padding-bottom:4px;text-align:left;font-weight:normal}.RadGrid_Default .rgHeader{border:0;border-bottom:1px solid #828282;background:#eaeaea 0 -2300px repeat-x url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Grid.sprite.gif')}.RadGrid_Default .rgHeader{color:#333}.RadGrid .rgHeader{cursor:default}.RadGrid .rgHeader{padding-left:7px;padding-right:7px}.RadGrid .rgHeader{padding-top:5px;padding-bottom:4px;text-align:left;font-weight:normal}.RadGrid_Default .rgHeader{border:0;border-bottom:1px solid #828282;background:#eaeaea 0 -2300px repeat-x url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Grid.sprite.gif')}.RadGrid_Default .rgHeader{color:#333}.RadGrid .rgHeader{cursor:default}.RadGrid .rgHeader{padding-left:7px;padding-right:7px}.RadGrid .rgHeader{padding-top:5px;padding-bottom:4px;text-align:left;font-weight:normal}.RadGrid_Default .rgHeader{border:0;border-bottom:1px solid #828282;background:#eaeaea 0 -2300px repeat-x url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Grid.sprite.gif')}.RadGrid_Default .rgHeader{color:#333}

</style>
    <div>
                <table class="thead" width="100%">
                    <tr>
                        <td class="style1" align="right" width="90px">
                            <asp:Label ID="Label12" runat="server" Text="標題：" Font-Bold="True"></asp:Label>
                        </td>
                        <td>

                            <asp:Label ID="lbTitle" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style1" align="right">
                            <asp:Label ID="Label1" runat="server" Text="消息日期：" Font-Bold="True"></asp:Label>
                        </td>
                        <td>

                            <asp:Label ID="lbDate" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style1" align="right">
                            <asp:Label ID="Label13" runat="server" Text="消息內容：" Font-Bold="True"></asp:Label>
                        </td>
                        <td>

                            <asp:Literal ID="liContent" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                    <td colspan="2">
    
                        <telerik:RadGrid ID="rgAttachment" runat="server" AutoGenerateColumns="False" 
                            CellSpacing="0" Culture="zh-TW" GridLines="None" 
                            Width="98%" OnItemDataBound="rgAttachment_ItemDataBound" OnNeedDataSource="rgAttachment_NeedDataSource">
                            <ClientSettings>
                                <Selecting AllowRowSelect="True" />
                            </ClientSettings>
                            <MasterTableView DataKeyNames="AttachmentID" 
                                NoMasterRecordsText="沒有附件">
                                <CommandItemSettings ExportToPdfText="Export to PDF" />
                                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" 
                                    Visible="False">
                                </RowIndicatorColumn>
                                <ExpandCollapseColumn Created="True" 
                                    FilterControlAltText="Filter ExpandColumn column" Visible="True">
                                </ExpandCollapseColumn>
                                <Columns>
                                    <telerik:GridAttachmentColumn AttachmentDataField="Attachment" 
                                        AttachmentKeyFields="AttachmentID" DataSourceID="odsAttachment" 
                                        DataTextField="AttachmentName" FileName="AttachmentName" FileNameTextField="AttachmentName" 
                                        FilterControlAltText="Filter attachment column" HeaderText="附件" 
                                        MaxFileSize="65535" UniqueName="attachment" Visible="False">
                                    </telerik:GridAttachmentColumn>
                                    <telerik:GridTemplateColumn DataField="ActAttachmentID" FilterControlAltText="Filter Att column" HeaderText="附件" UniqueName="Att">
                                        <ItemTemplate>
                                           <asp:LinkButton ID="lbtnAtt" runat="server" OnClick="lbtnAtt_Click"></asp:LinkButton>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                </Columns>
                                <EditFormSettings>
                                    <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                    </EditColumn>
                                </EditFormSettings>
                            </MasterTableView>
                            <FilterMenu EnableImageSprites="False">
                            </FilterMenu>
                        </telerik:RadGrid>
                        </td>
                    </tr>
                </table>
    </div>

    </asp:Content>

