﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="EduStopActScheduleDoc.aspx.cs" Inherits="EduStopActScheduleDoc" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
.RadGrid_Default{border:1px solid #828282;background-color:white;color:#333;font-family:"Segoe UI",Arial,Helvetica,sans-serif;font-size:12px;line-height:16px}.RadGrid_Default{border:1px solid #828282;background-color:white;color:#333;font-family:"Segoe UI",Arial,Helvetica,sans-serif;font-size:12px;line-height:16px}.RadGrid_Default .rgMasterTable{font-family:"Segoe UI",Arial,Helvetica,sans-serif;font-size:12px;line-height:16px}.RadGrid .rgMasterTable{border-collapse:separate;border-spacing:0}.RadGrid_Default .rgMasterTable{font-family:"Segoe UI",Arial,Helvetica,sans-serif;font-size:12px;line-height:16px}.RadGrid .rgMasterTable{border-collapse:separate;border-spacing:0}.RadGrid table.rgMasterTable tr .rgExpandCol{padding-left:0;padding-right:0;text-align:center}.RadGrid table.rgMasterTable tr .rgExpandCol{padding-left:0;padding-right:0;text-align:center}.RadGrid_Default .rgHeader{color:#333}.RadGrid_Default .rgHeader{border:0;border-bottom:1px solid #828282;background:#eaeaea 0 -2300px repeat-x url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Grid.sprite.gif')}.RadGrid .rgHeader{padding-top:5px;padding-bottom:4px;text-align:left;font-weight:normal}.RadGrid .rgHeader{padding-left:7px;padding-right:7px}.RadGrid .rgHeader{cursor:default}.RadGrid_Default .rgHeader{color:#333}.RadGrid_Default .rgHeader{border:0;border-bottom:1px solid #828282;background:#eaeaea 0 -2300px repeat-x url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Grid.sprite.gif')}.RadGrid .rgHeader{padding-top:5px;padding-bottom:4px;text-align:left;font-weight:normal}.RadGrid .rgHeader{padding-left:7px;padding-right:7px}.RadGrid .rgHeader{cursor:default}
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<table width="100%">
<tr>
<td>

    <table width="100%">
<tr>
<td width="10%" bgcolor="#DEDEE9" align="right">
    <asp:Label ID="Label5" runat="server" Font-Bold="False" ForeColor="Red" 
        Text="*"></asp:Label>
    <asp:Label ID="Label6" runat="server" Font-Bold="True" Text="活動主題："></asp:Label>
</td>
<td width="90%" align="left">
    <asp:Label ID="lbActName" runat="server"></asp:Label>
</td>
</tr>
<tr>
<td width="10%" bgcolor="#DEDEE9" align="right">
    <asp:Label ID="Label11" runat="server" Font-Bold="False" ForeColor="Red" 
        Text="*"></asp:Label>
    <asp:Label ID="Label12" runat="server" Font-Bold="True" Text="舉辦日期："></asp:Label>
</td>
<td width="90%" align="left">
    <asp:Label ID="lbActDate" runat="server"></asp:Label>                           
</td>
</tr>

<tr>
<td width="10%" bgcolor="#DEDEE9" align="right">
    <asp:Label ID="Label9" runat="server" Font-Bold="True" Text="附件檔案："></asp:Label>
</td>
<td width="90%" align="left">
    <telerik:RadAsyncUpload ID="ruploadAttachment" 
                                        runat="server">
                                        <Localization Cancel="取消" DropZone="請將檔案拖曳至此" Remove="移除" Select="瀏覽" />
                                    </telerik:RadAsyncUpload>
<asp:Panel ID="panEditAttachment" runat="server" Visible = "false">
    <asp:Button ID="btnUpload" runat="server" Text="新增附件" 
        onclick="btnUpload_Click" />
                                
                                    <telerik:RadGrid ID="rgAttachment" 
        runat="server" AutoGenerateColumns="False" 
                                        CellSpacing="0" Culture="zh-TW" GridLines="None" 
                                        AutoGenerateDeleteColumn="True" 
                                        ondeletecommand="rgAttachment_DeleteCommand" 
                                        
        onitemdatabound="rgAttachment_ItemDataBound" OnNeedDataSource="rgAttachment_NeedDataSource">
                                        <ClientSettings>
                                            <Selecting AllowRowSelect="True" />
                                        </ClientSettings>
                                        <MasterTableView DataKeyNames="ActAttachmentID" 
                                            NoMasterRecordsText="沒有附件">
                                            <CommandItemSettings ExportToPdfText="Export to PDF" />
                                            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" 
                                                Visible="False">
                                            </RowIndicatorColumn>
                                            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" 
                                                Visible="True" Created="True">
                                            </ExpandCollapseColumn>
                                            <Columns>
 
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
</asp:Panel>

                                
</td>
</tr>
<tr>
<td colspan="2">
    
    <asp:ObjectDataSource ID="odsAttachment" runat="server" 
        DataObjectTypeName="KMU.EduActivity.ApplicationLayer.DTO.EduStopActAttachmentDto" 
        SelectMethod="GetActAttachments" 
        TypeName="KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService" 
        onselecting="odsAttachment_Selecting">
    </asp:ObjectDataSource>
    
                    <asp:Button ID="btnReturn" runat="server" onclick="btnReturn_Click" 
                        Text="返回行事曆" />                
    
    </td>
</tr>
</table></td>
</tr>
</table>

</asp:Content>
