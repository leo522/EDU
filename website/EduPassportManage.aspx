<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="EduPassportManage.aspx.cs" Inherits="EduPassportManage" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}
.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}
.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}
    .RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default .rcbReadOnly .rcbInputCellLeft{background-position:0 -88px}.RadComboBox_Default .rcbInputCellLeft{background-position:0 0}.RadComboBox_Default .rcbInputCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbInputCell{width:100%;height:20px;_height:22px;line-height:20px;_line-height:22px;text-align:left;vertical-align:middle}.RadComboBox .rcbInputCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}
    .RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbReadOnly .rcbArrowCellRight{background-position:-162px -176px}.RadComboBox_Default .rcbArrowCellRight{background-position:-18px -176px}.RadComboBox_Default .rcbArrowCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbArrowCell{width:18px}.RadComboBox .rcbArrowCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadPicker{vertical-align:middle}.rdfd_{position:absolute}.RadPicker .rcTable{table-layout:auto}.RadPicker .RadInput{vertical-align:baseline}.RadInput_Default{font:12px "segoe ui",arial,sans-serif}.RadInput{vertical-align:middle}.RadInput .riTextBox{height:17px}
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div>
        <table>
            <tr>
                <td>

                    <asp:Button ID="btnToSendPassport" runat="server" Text="進入發護照頁面" OnClick="btnToSendPassport_Click" />

                </td>
                <td>

                    <asp:Button ID="btnToImportPassport" runat="server" Text="進入護照資料匯入頁面" OnClick="btnToImportPassport_Click" />

                </td>
            </tr>
         </table>

    </div>
    <div>
       <table width="100%">
            <tr>
                <td class="auto-style10">
        <asp:Label ID="Label6" runat="server" Text="*學年度："></asp:Label>
                </td>
                <td class="auto-style6">
                    <asp:TextBox ID="tbEduYear" runat="server" Width="42px"></asp:TextBox>
                </td>
                <td class="auto-style6">
        <asp:Label ID="Label5" runat="server" Text="職稱："></asp:Label>
                </td>
                <td class="auto-style7">
                    <telerik:RadDropDownTree ID="rddtJobCode" runat="server" DataFieldID="Code" DataFieldParentID="ParentCodeRefid" DataSourceID="dsJobCode" DataTextField="name" DataValueField="code" OnDataBound="rddtJobCode_DataBound">
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
                    <asp:Label ID="Label13" runat="server" Text="學員："></asp:Label>
                </td>
                <td class="auto-style6">
                    <asp:TextBox ID="tbEvalTarget" runat="server"></asp:TextBox>
                    <asp:Label ID="Label14" runat="server" Text="(職編或姓名)"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style11">
        <asp:Label ID="Label7" runat="server" Text="護照："></asp:Label>
                </td>
                <td colspan="3">
                    <telerik:RadComboBox Width="300px" ID="rcbTemplateID" Runat="server" AllowCustomText="True" Filter="Contains" AutoPostBack="True" OnSelectedIndexChanged="rcbTemplateID_SelectedIndexChanged">
                    </telerik:RadComboBox>
                </td>
              <td>
                    <asp:Label ID="Label15" runat="server" Text="實習期間："></asp:Label>
                </td>                
                <td colspan="3">
                    <table>
                        <tr>
                            <td><telerik:RadDatePicker ID="rdpDateBegin" Runat="server">
        </telerik:RadDatePicker></td>
                            <td>~</td>
                            <td><telerik:RadDatePicker ID="rdpDateEnd" Runat="server">
        </telerik:RadDatePicker></td>
                        </tr>
                    </table>
                    </td>
  
            </tr>
   <tr>
       <td colspan="8">

           <asp:Panel ID="panItemFilter" runat="server" Visible="False">
               <table>
                   <tr>
                       <td>
                           <asp:Label ID="Label16" runat="server" Text="護照項目："></asp:Label>
                       </td>
                       <td>
                           <telerik:RadComboBox ID="rcbTemplateItem" Runat="server" AllowCustomText="True" Filter="Contains" Width="263px">
                           </telerik:RadComboBox>
                       </td>
                       <td>
                           <asp:Label ID="Label17" runat="server" Font-Bold="False" Font-Size="Small" ForeColor="Blue" Text="*有選擇護照項目才會列出單項目明細資料"></asp:Label>
                       </td>
                   </tr>
               </table>
           </asp:Panel>

       </td>      
   </tr>

            <tr>
                <td class="auto-style11">
                    <asp:Button ID="btnQuery" runat="server" Text="查詢" OnClick="btnQuery_Click" />
                </td>
                <td>
                    &nbsp;</td>
                <td></td>
                <td class="auto-style3">
                    
                </td>
                <td class="auto-style13"></td>
                <td></td>
                <td class="auto-style4"></td>
                <td></td>
            </tr>
        </table>
    </div>
    <div>

                <telerik:RadTabStrip ID="rtsData" runat="server" MultiPageID="rmpData" SelectedIndex="0">
                    <Tabs>
                        <telerik:RadTab runat="server" PageViewID="rpvInstance" Selected="True" Text="護照查詢">
                        </telerik:RadTab>
                        <telerik:RadTab runat="server" PageViewID="rpvItem" Text="單項目資料查詢">
                        </telerik:RadTab>
                    </Tabs>
                </telerik:RadTabStrip>

                <telerik:RadMultiPage ID="rmpData" Runat="server" Width="98%" SelectedIndex="0">
                    <telerik:RadPageView ID="rpvInstance" runat="server">
                        <asp:Button ID="btnExportList" runat="server" OnClick="btnExportList_Click" Text="匯出清單" />
                        <asp:Button ID="btnDel" runat="server" OnClick="btnDel_Click" OnClientClick="if(!confirm('確定刪除選取的護照?')){return false;}" Text="刪除選取護照" />
                        <telerik:RadGrid ID="rgList" runat="server" AutoGenerateColumns="False" CellSpacing="0" Culture="zh-TW" GridLines="None" OnItemCreated="rgList_ItemCreated" OnNeedDataSource="rgList_NeedDataSource" AllowSorting="True" OnItemDataBound="rgList_ItemDataBound">
                            <ClientSettings>
                                <Selecting AllowRowSelect="True" />
                            </ClientSettings>
                            <MasterTableView DataKeyNames="InstanceID,TemplateID">
                                <Columns>
                                    <telerik:GridClientSelectColumn FilterControlAltText="Filter column column" UniqueName="column">
                                    </telerik:GridClientSelectColumn>
                                    <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" UniqueName="TemplateColumn">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="btnView" runat="server" Target="_blank" Text="查看" />
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridBoundColumn DataField="EmpCode" FilterControlAltText="Filter EmpCode column" HeaderText="職編" UniqueName="EmpCode">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="EmpName" FilterControlAltText="Filter EmpName column" HeaderText="姓名" UniqueName="EmpName">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="TemplateName" FilterControlAltText="Filter DeptName column" HeaderText="護照名稱" UniqueName="TemplateName">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="ThreeStepFinishRateStr" FilterControlAltText="Filter ModifyDate column" HeaderText="完成狀況(已完成/審核中/未完成/總數)" UniqueName="ThreeStepFinishRateStr">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="NecessaryFinishRate" FilterControlAltText="Filter NecessaryFinishRate column" HeaderText="必修完成率" UniqueName="NecessaryFinishRate">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="FinishRate" FilterControlAltText="Filter FinishRate column" HeaderText="總完成率" UniqueName="FinishRate">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="StudentFinishRate" FilterControlAltText="Filter StudentFinishRateStr column" HeaderText="學生完成率" UniqueName="StudentFinishRateStr">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn1 column" UniqueName="TemplateColumn1">
                                        <ItemTemplate>
                                            <asp:Button ID="btnPrint" runat="server" Text="匯出" OnClick="btnPrint_Click" />
                                            <asp:Button ID="btnRefresh" runat="server" Text="更新項目" OnClientClick=" if(!confirm('更新項目將會從目前樣版中加入本護照有缺的項目，確定更新?')){return false;} " OnClick="btnRefresh_Click" />
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                </Columns>
                            </MasterTableView>
                        </telerik:RadGrid>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="rpvItem" runat="server">
                        <asp:Button ID="btnExport" runat="server" OnClick="btnExport_Click" Text="匯出" />
                        <telerik:RadGrid ID="rgItem" runat="server" OnNeedDataSource="rgItem_NeedDataSource">
                        </telerik:RadGrid>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
    <asp:ObjectDataSource ID="dsJobCode" runat="server" SelectMethod="GetCodeRefsStatic" 
        TypeName="KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService" 
        DataObjectTypeName="KMU.EduActivity.ApplicationLayer.DTO.V_CodeRefDto">
        <SelectParameters>
            <asp:Parameter DefaultValue="EduAct_JobSerial" Name="codetype" />
        </SelectParameters>
    </asp:ObjectDataSource>
    
    
    </div>

</asp:Content>

