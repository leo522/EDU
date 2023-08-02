<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="OSCECertManage.aspx.cs" Inherits="OSCECertManage" %>

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

        <telerik:RadTabStrip ID="RadTabStrip1" runat="server" MultiPageID="RadMultiPage1" SelectedIndex="0">
            <Tabs>
                <telerik:RadTab runat="server" Text="資料管理" PageViewID="rpvManage" Selected="True">
                </telerik:RadTab>
                <telerik:RadTab runat="server" Text="資料上傳" PageViewID="rpvImport">
                </telerik:RadTab>
            </Tabs>
        </telerik:RadTabStrip>

    </div>
    <div>

        <telerik:RadMultiPage ID="RadMultiPage1" Runat="server" Width="100%" SelectedIndex="0">
            <telerik:RadPageView ID="rpvManage" runat="server">
                <div>
                    <table width="100%">
                        <tr>
                            <td width="110px">

                                <asp:Label ID="Label19" runat="server" Text="員工(職編,姓名)："></asp:Label>

                            </td>
                            <td colspan="3">

                                <asp:TextBox ID="tbEmpCodeName" runat="server"></asp:TextBox>

                            </td>
                            
                            <td  width="130px">

                                <asp:Label ID="Label20" runat="server" Text="建立者(職編,姓名)："></asp:Label>

                            </td>
                            <td>

                                <asp:TextBox ID="tbCreater" runat="server"></asp:TextBox>

                            </td>
                            <td>

                            </td>
                            <td>

                            </td>
                        </tr>
                        <tr>
                            <td>

                                <asp:Label ID="Label21" runat="server" Text="有效起日："></asp:Label>

                            </td>
                            <td colspan="7">
                                <table>
                                    <tr>
                                        <td>
                                <telerik:RadDatePicker ID="rdpSdate" Runat="server">
                                </telerik:RadDatePicker>
                                        </td>
                                        <td>
                                            ~
                                        </td>
                                        <td>
                                <telerik:RadDatePicker ID="rdpEdate" Runat="server">
                                </telerik:RadDatePicker>
                                        </td>
                                    </tr>
                                </table>


                            </td>
                        </tr>
                        <tr>
                            <td>

                                <asp:Label ID="Label1" runat="server" Text="有效迄日："></asp:Label>

                            </td>
                            <td colspan="7">
                                <table>
                                    <tr>
                                        <td>
                                <telerik:RadDatePicker ID="rdpCreateSdate" Runat="server">
                                </telerik:RadDatePicker>
                                        </td>
                                        <td>
                                            ~
                                        </td>
                                        <td>
                                <telerik:RadDatePicker ID="rdpCreateEdate" Runat="server">
                                </telerik:RadDatePicker>
                                        </td>
                                    </tr>
                                </table>


                            </td>
                        </tr>
                        <tr>
                            <td>

                                <asp:Button ID="btnQuery" runat="server" OnClick="btnQuery_Click" Text="查詢" />

                            </td>
                            <td>
                                <asp:Button ID="btnDelSelect" runat="server" OnClick="btnDelSelect_Click" Text="刪除選取" />
                            </td>
                            <td>

                            </td>
                            <td>

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
                    </table>
                </div>
                <div>

                    <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" AutoGenerateDeleteColumn="True" CellSpacing="0" Culture="zh-TW" GridLines="None" OnDeleteCommand="RadGrid1_DeleteCommand" OnNeedDataSource="RadGrid1_NeedDataSource" AllowMultiRowSelection="True">
                        <ClientSettings>
                            <Selecting AllowRowSelect="True" />
                        </ClientSettings>
                        <MasterTableView DataKeyNames="ID">
                            <Columns>
                                <telerik:GridClientSelectColumn FilterControlAltText="Filter column column" UniqueName="column">
                                </telerik:GridClientSelectColumn>
                                <telerik:GridBoundColumn DataField="empcode" FilterControlAltText="Filter empcode column" HeaderText="職員編號" UniqueName="empcode">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="empname" FilterControlAltText="Filter empname column" HeaderText="姓名" UniqueName="empname">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="sdate" FilterControlAltText="Filter classname column" HeaderText="有效起日" UniqueName="sdate">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="edate" FilterControlAltText="Filter classtype column" HeaderText="有效迄日" UniqueName="edate">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="remark" FilterControlAltText="Filter remark column" HeaderText="註記" UniqueName="remark">
                                </telerik:GridBoundColumn>
                            </Columns>
                        </MasterTableView>
                    </telerik:RadGrid>

                </div>
            </telerik:RadPageView>
            <telerik:RadPageView ID="rpvImport" runat="server">
    <div>

                <asp:Panel ID="Panel2" runat="server" GroupingText="Step1 - 下載匯入格式範例">
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/docs/OSCE認證考官匯入範例.xls">下載</asp:HyperLink>
                    <asp:Label ID="Label17" runat="server" Font-Bold="True" ForeColor="Red" Text="*範例檔第一行欄位名稱請勿刪除或修改"></asp:Label>
                </asp:Panel>
    
    
    </div>
    <div>

        <asp:Panel ID="Panel3" runat="server" GroupingText="Step2 - 匯入編輯後檔案">
            <asp:FileUpload ID="FileUpload1" runat="server" />
            <asp:Button ID="btnImport" runat="server" Text="匯入" OnClick="btnImport_Click" />
        </asp:Panel>

    </div>
    <div>

        <asp:Label ID="lbMsg" runat="server"></asp:Label>

    </div>
            </telerik:RadPageView>
        </telerik:RadMultiPage>

    </div>


</asp:Content>

