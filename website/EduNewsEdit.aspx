<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="EduNewsEdit.aspx.cs" Inherits="EduNewsEdit" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<%@ Register src="VsSelector.ascx" tagname="VsSelector" tagprefix="uc1" %>

<%@ Register src="TreeViewComboBox.ascx" tagname="TreeViewComboBox" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
.RadGrid_Default{border:1px solid #828282;background-color:white;color:#333;font-family:"Segoe UI",Arial,Helvetica,sans-serif;font-size:12px;line-height:16px}.RadGrid_Default{border:1px solid #828282;background-color:white;color:#333;font-family:"Segoe UI",Arial,Helvetica,sans-serif;font-size:12px;line-height:16px}.RadGrid_Default{border:1px solid #828282;background-color:white;color:#333;font-family:"Segoe UI",Arial,Helvetica,sans-serif;font-size:12px;line-height:16px}.RadGrid_Default{border:1px solid #828282;background-color:white;color:#333;font-family:"Segoe UI",Arial,Helvetica,sans-serif;font-size:12px;line-height:16px}.RadGrid_Default .rgMasterTable{font-family:"Segoe UI",Arial,Helvetica,sans-serif;font-size:12px;line-height:16px}.RadGrid .rgMasterTable{border-collapse:separate;border-spacing:0}.RadGrid_Default .rgMasterTable{font-family:"Segoe UI",Arial,Helvetica,sans-serif;font-size:12px;line-height:16px}.RadGrid .rgMasterTable{border-collapse:separate;border-spacing:0}.RadGrid_Default .rgMasterTable{font-family:"Segoe UI",Arial,Helvetica,sans-serif;font-size:12px;line-height:16px}.RadGrid .rgMasterTable{border-collapse:separate;border-spacing:0}.RadGrid_Default .rgMasterTable{font-family:"Segoe UI",Arial,Helvetica,sans-serif;font-size:12px;line-height:16px}.RadGrid .rgMasterTable{border-collapse:separate;border-spacing:0}.RadGrid table.rgMasterTable tr .rgExpandCol{padding-left:0;padding-right:0;text-align:center}.RadGrid table.rgMasterTable tr .rgExpandCol{padding-left:0;padding-right:0;text-align:center}.RadGrid table.rgMasterTable tr .rgExpandCol{padding-left:0;padding-right:0;text-align:center}.RadGrid table.rgMasterTable tr .rgExpandCol{padding-left:0;padding-right:0;text-align:center}.RadGrid_Default .rgHeader{color:#333}.RadGrid_Default .rgHeader{border:0;border-bottom:1px solid #828282;background:#eaeaea 0 -2300px repeat-x url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Grid.sprite.gif')}.RadGrid .rgHeader{padding-top:5px;padding-bottom:4px;text-align:left;font-weight:normal}.RadGrid .rgHeader{padding-left:7px;padding-right:7px}.RadGrid .rgHeader{cursor:default}.RadGrid_Default .rgHeader{color:#333}.RadGrid_Default .rgHeader{border:0;border-bottom:1px solid #828282;background:#eaeaea 0 -2300px repeat-x url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Grid.sprite.gif')}.RadGrid .rgHeader{padding-top:5px;padding-bottom:4px;text-align:left;font-weight:normal}.RadGrid .rgHeader{padding-left:7px;padding-right:7px}.RadGrid .rgHeader{cursor:default}.RadGrid_Default .rgHeader{color:#333}.RadGrid_Default .rgHeader{border:0;border-bottom:1px solid #828282;background:#eaeaea 0 -2300px repeat-x url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Grid.sprite.gif')}.RadGrid .rgHeader{padding-top:5px;padding-bottom:4px;text-align:left;font-weight:normal}.RadGrid .rgHeader{padding-left:7px;padding-right:7px}.RadGrid .rgHeader{cursor:default}.RadGrid_Default .rgHeader{color:#333}.RadGrid_Default .rgHeader{border:0;border-bottom:1px solid #828282;background:#eaeaea 0 -2300px repeat-x url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Grid.sprite.gif')}.RadGrid .rgHeader{padding-top:5px;padding-bottom:4px;text-align:left;font-weight:normal}.RadGrid .rgHeader{padding-left:7px;padding-right:7px}.RadGrid .rgHeader{cursor:default}
        .style1
        {
            border-color: #d9d9d9;
            background: #d9d9d9;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    
    <asp:ObjectDataSource ID="odsAttachment" runat="server" 
        DataObjectTypeName="KMU.EduActivity.ApplicationLayer.DTO.dbo.News_AttachmentDto" 
        SelectMethod="GetNewsAttachment" 
        TypeName="KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService" 
        onselecting="odsAttachment_Selecting">
    </asp:ObjectDataSource>
    
    <div>

                <table width="100%">
                    <tr>
                        <td class="style1" align="right">
                            <asp:Label ID="Label12" runat="server" Text="標題："></asp:Label>
                        </td>
                        <td>

                            <asp:TextBox ID="tbTitle" runat="server" Width="345px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style1" align="right">
                            <asp:Label ID="Label13" runat="server" Text="消息內容："></asp:Label>
                        </td>
                        <td>

                            <telerik:RadEditor ID="reContent" Runat="server" Height="370px" Width="747px">
                                <Content>
</Content>

                                <ImageManager 
                                    DeletePaths="~/Images/NewsImage" 
                                    EnableAsyncUpload="True" 
                                    UploadPaths="~/Images/NewsImage" 
                                    ViewPaths="~/Images/NewsImage"
                                    SearchPatterns="*.jpeg,*.jpg,*.png,*.gif,*.bmp"
                                     />

<TrackChangesSettings CanAcceptTrackChanges="False"></TrackChangesSettings>
                            </telerik:RadEditor>
                        </td>
                    </tr>
                    <tr>
                        <td class="style1" align="right">
                            <asp:Label ID="Label1" runat="server" Text="消息日期："></asp:Label>
                        </td>
                        <td>

                            <telerik:RadDatePicker ID="rdpSDate" Runat="server">
                            </telerik:RadDatePicker>
                        </td>
                    </tr>
                    <tr>
                        <td class="style1" align="right">
                            <asp:Label ID="Label2" runat="server" Text="關閉日期："></asp:Label>
                        </td>
                        <td>

                            <telerik:RadDatePicker ID="rdpEDate" Runat="server">
                            </telerik:RadDatePicker>
                        </td>
                    </tr>
                    <tr>
                    <td class="style1" align="right">
                        <asp:Label ID="Label14" runat="server" Text="附件："></asp:Label>
                        </td>
                    <td>
                        <telerik:RadAsyncUpload ID="rauAttachment" runat="server" 
                            MultipleFileSelection="Automatic" PostbackTriggers="btnSubmit">
                            <Localization Cancel="取消" DropZone="請將檔案拖曳至此" Remove="移除" Select="瀏覽" />
                        </telerik:RadAsyncUpload>
                        <telerik:RadGrid ID="rgAttachment" runat="server" AutoGenerateColumns="False" 
                            CellSpacing="0" Culture="zh-TW" DataSourceID="odsAttachment" GridLines="None" 
                            Width="98%" AutoGenerateDeleteColumn="True" 
                            ondeletecommand="rgAttachment_DeleteCommand">
                            <ClientSettings>
                                <Selecting AllowRowSelect="True" />
                            </ClientSettings>
                            <MasterTableView DataKeyNames="AttachmentID" DataSourceID="odsAttachment" 
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
                                        MaxFileSize="65535" UniqueName="attachment">
                                    </telerik:GridAttachmentColumn>
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
                    <tr>
                        <td class="style1" align="right">
                            <asp:Label ID="Label15" runat="server" Text="公告對象："></asp:Label>
                        </td>
                        <td>



                            <telerik:RadTabStrip ID="RadTabStrip1" runat="server" MultiPageID="RadMultiPage1" SelectedIndex="0">
                                <Tabs>
                                    <telerik:RadTab runat="server" PageViewID="RadPageView1" Selected="True" Text="組別">
                                    </telerik:RadTab>
                                    <telerik:RadTab runat="server" PageViewID="RadPageView2" Text="職類">
                                    </telerik:RadTab>
                                    <telerik:RadTab runat="server" PageViewID="RadPageView3" Text="個人">
                                    </telerik:RadTab>
                                    <telerik:RadTab runat="server" PageViewID="RadPageView4" Text="部門">
                                    </telerik:RadTab>
                                </Tabs>
                            </telerik:RadTabStrip>
                            <telerik:RadMultiPage ID="RadMultiPage1" Runat="server" SelectedIndex="0">
                                <telerik:RadPageView ID="RadPageView1" runat="server">
                <asp:Panel ID="palTeam" runat="server">
                    <asp:Label ID="Label3" runat="server" Text="組別："></asp:Label>
                    <uc1:TreeViewComboBox Width="350px" ID="rvcbTeam" runat="server" Enabled="True" 
        TreeDataFieldID="EduTeamCode" TreeDataFieldParentID="parentEduTeamCode" 
        TreeDataSourceID="dsTermCode" TreeDataTextField="EduTeamName" 
        AutoPostBack="False" AllowSelectParent="True" CheckBoxes="CheckChildNodes" />
                    
                    <br />
                    <asp:Button ID="btnAddTeam" runat="server" Text="加入" OnClick="btnAddTeam_Click" />
                    
                </asp:Panel>
                                </telerik:RadPageView>
                                <telerik:RadPageView ID="RadPageView2" runat="server">
<asp:Panel ID="palJobCode" runat="server">
                    <asp:Label ID="Label22" runat="server" Text="職稱："></asp:Label>
                    <telerik:RadComboBox ID="ddlJobCode" Runat="server" Filter="Contains" 
                        Width="400px" ViewStateMode="Enabled">
                    </telerik:RadComboBox>
                    <br />
                    <asp:Button ID="btnAddJob" runat="server" Text="加入" OnClick="btnAddJob_Click" />
                </asp:Panel>
                                </telerik:RadPageView>
                                <telerik:RadPageView ID="RadPageView3" runat="server">
                                    <uc1:VsSelector ID="VsSelector1" runat="server" />
                                    <br />
                                    <asp:Button ID="btnAddEmp" runat="server" OnClick="btnAddEmp_Click" Text="加入" />
                                </telerik:RadPageView>
                                <telerik:RadPageView ID="RadPageView4" runat="server">
                                    <asp:Label ID="Label23" runat="server" Text="部門："></asp:Label>
                                    <telerik:RadComboBox ID="ddlDept" Runat="server" Filter="Contains" ViewStateMode="Enabled" Width="400px">
                                    </telerik:RadComboBox>
                                    <br />
                                    <asp:Button ID="btnAddDept" runat="server" OnClick="btnAddDept_Click" Text="加入" />
                                </telerik:RadPageView>
                            </telerik:RadMultiPage>
                            <div>


                                <telerik:RadGrid ID="rgTargets" runat="server" AutoGenerateColumns="False" AutoGenerateDeleteColumn="True" CellSpacing="0" GridLines="None" OnDeleteCommand="rgTargets_DeleteCommand">
                                    <MasterTableView DataKeyNames="TargetID,TargetType">
                                        <Columns>
                                            <telerik:GridBoundColumn DataField="TargetType" FilterControlAltText="Filter TargetType column" HeaderText="類別" UniqueName="TargetType">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="TargetName" FilterControlAltText="Filter TargetName column" HeaderText="設定值" UniqueName="TargetName">
                                            </telerik:GridBoundColumn>
                                        </Columns>
                                    </MasterTableView>
                                </telerik:RadGrid>


                            </div>

                        </td>
                    </tr>
                    <tr>
                        <td class="style1" align="right">
                        </td>
                        <td>
                            <asp:Button ID="btnSubmit" runat="server" Text="儲存" Width="60px" 
            onclick="btnSubmit_Click" />
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnCancel" runat="server" Text="取消" Width="54px" onclick="btnCancel_Click" />
                        </td>
                    </tr>
                </table>

    </div>
        <asp:ObjectDataSource ID="dsTermCode" runat="server" SelectMethod="GetEduTeams" 
        TypeName="KMU.EduActivity.ApplicationLayer.DTO.EduTeamDto">
    </asp:ObjectDataSource>
    </asp:Content>

