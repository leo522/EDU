﻿<%@ Page Language="C#" MasterPageFile="~/Empty.master" AutoEventWireup="true" CodeFile="InstanceAttachment.aspx.cs" Inherits="InstanceAttachment" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
.RadGrid_Default{border:1px solid #828282;background-color:white;color:#333;font-family:"Segoe UI",Arial,Helvetica,sans-serif;font-size:12px;line-height:16px}.RadGrid_Default{border:1px solid #828282;background-color:white;color:#333;font-family:"Segoe UI",Arial,Helvetica,sans-serif;font-size:12px;line-height:16px}.RadGrid_Default .rgMasterTable{font-family:"Segoe UI",Arial,Helvetica,sans-serif;font-size:12px;line-height:16px}.RadGrid .rgMasterTable{border-collapse:separate;border-spacing:0}.RadGrid_Default .rgMasterTable{font-family:"Segoe UI",Arial,Helvetica,sans-serif;font-size:12px;line-height:16px}.RadGrid .rgMasterTable{border-collapse:separate;border-spacing:0}.RadGrid table.rgMasterTable tr .rgExpandCol{padding-left:0;padding-right:0;text-align:center}.RadGrid table.rgMasterTable tr .rgExpandCol{padding-left:0;padding-right:0;text-align:center}.RadGrid_Default .rgHeader{color:#333}.RadGrid_Default .rgHeader{border:0;border-bottom:1px solid #828282;background:#eaeaea 0 -2300px repeat-x url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Grid.sprite.gif')}.RadGrid .rgHeader{padding-top:5px;padding-bottom:4px;text-align:left;font-weight:normal}.RadGrid .rgHeader{padding-left:7px;padding-right:7px}.RadGrid .rgHeader{cursor:default}.RadGrid_Default .rgHeader{color:#333}.RadGrid_Default .rgHeader{border:0;border-bottom:1px solid #828282;background:#eaeaea 0 -2300px repeat-x url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Grid.sprite.gif')}.RadGrid .rgHeader{padding-top:5px;padding-bottom:4px;text-align:left;font-weight:normal}.RadGrid .rgHeader{padding-left:7px;padding-right:7px}.RadGrid .rgHeader{cursor:default}
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div>
    
    <asp:Panel ID="panAttachment" runat="server" Visible="False">
        <asp:Panel ID="panAddAttach" runat="server" Visible="False">
            <asp:Label ID="Label2" runat="server" Text="選擇附件(最大10mb)："></asp:Label>
            <telerik:RadAsyncUpload ID="ruploadAttachment" runat="server" MaxFileSize="10240000">
                <Localization Cancel="取消" DropZone="請將檔案拖曳至此" Remove="移除" Select="瀏覽" />
            </telerik:RadAsyncUpload>
            <asp:Label ID="Label1" runat="server" Text="附件名稱："></asp:Label>
            <asp:TextBox ID="tbAttachmentName" runat="server" Width="323px"></asp:TextBox>
            <br />
        <asp:Button ID="btnUpload" runat="server" Text="新增附件" 
        onclick="btnUpload_Click" />
        </asp:Panel>

        <telerik:RadGrid ID="rgAttachment" 
        runat="server" AutoGenerateColumns="False" 
                                        CellSpacing="0" Culture="zh-TW" GridLines="None" 
                                        AutoGenerateDeleteColumn="True" 
                                        ondeletecommand="rgAttachment_DeleteCommand" 
             ViewStateMode="Enabled"
                                        
        onitemdatabound="rgAttachment_ItemDataBound" OnNeedDataSource="rgAttachment_NeedDataSource">
            <ClientSettings>
                <Selecting AllowRowSelect="True" />
            </ClientSettings>
            <MasterTableView DataKeyNames="ATTACHMENT_ID" 
                                            NoMasterRecordsText="沒有附件">
                <CommandItemSettings ExportToPdfText="Export to PDF" />
                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" 
                                                Visible="False">
                </RowIndicatorColumn>
                <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" 
                                                Visible="True" Created="True">
                </ExpandCollapseColumn>
                <Columns>
                    <telerik:GridAttachmentColumn AttachmentDataField="ATTACHMENT" 
                                                    AttachmentKeyFields="ATTACHMENT_ID" DataSourceID="odsAttachment" 
                                                    DataTextField="Name" FileNameTextField="FileName" 
                        FilterControlAltText="Filter attachment column" HeaderText="附件" 
                                                    MaxFileSize="65535" UniqueName="attachment" Visible="False" >
                    </telerik:GridAttachmentColumn>
                    <telerik:GridTemplateColumn DataField="ATTACHMENT_ID" FilterControlAltText="Filter Att column" HeaderText="附件" UniqueName="Att">
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

    </div>

    <asp:ObjectDataSource ID="odsAttachment" runat="server" 
        DataObjectTypeName="KMU.EduActivity.ApplicationLayer.DTO.FORM_INSTANCE_ATTACHMENTDto" 
        SelectMethod="GetFormAttachments" 
        TypeName="KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService" 
        onselecting="odsAttachment_Selecting">
    </asp:ObjectDataSource>
    
</asp:Content>