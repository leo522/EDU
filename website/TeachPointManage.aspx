<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="TeachPointManage.aspx.cs" Inherits="TeachPointManage" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}
.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}
.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}
    .RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default .rcbReadOnly .rcbInputCellLeft{background-position:0 -88px}.RadComboBox_Default .rcbInputCellLeft{background-position:0 0}.RadComboBox_Default .rcbInputCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbInputCell{width:100%;height:20px;_height:22px;line-height:20px;_line-height:22px;text-align:left;vertical-align:middle}.RadComboBox .rcbInputCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}
    .RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbReadOnly .rcbArrowCellRight{background-position:-162px -176px}.RadComboBox_Default .rcbArrowCellRight{background-position:-18px -176px}.RadComboBox_Default .rcbArrowCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbArrowCell{width:18px}.RadComboBox .rcbArrowCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadPicker{vertical-align:middle}.rdfd_{position:absolute}.RadPicker .rcTable{table-layout:auto}.RadPicker .RadInput{vertical-align:baseline}.RadInput_Default{font:12px "segoe ui",arial,sans-serif}.RadInput{vertical-align:middle}.RadInput .riTextBox{height:17px}
        .auto-style1 {
            height: 21px;
        }
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
                            <td class="auto-style1">

                                <asp:Label ID="Label18" runat="server" Text="*上傳項目："></asp:Label>

                            </td>
                            <td colspan="7" class="auto-style1">

                                <telerik:RadComboBox ID="rcbCalcTypeQuery" Runat="server" AutoPostBack="True" OnSelectedIndexChanged="rcbCalcTypeQuery_SelectedIndexChanged" Width="200px">
                                </telerik:RadComboBox>

                                <telerik:RadComboBox ID="rcbItemQuery" Runat="server" AllowCustomText="True" AutoPostBack="True" Filter="Contains" Width="500px">
                                </telerik:RadComboBox>

                            </td>
                            
                        </tr>
                        <tr>
                            <td>

                                <asp:Label ID="Label19" runat="server" Text="得分者(職編,姓名)："></asp:Label>

                            </td>
                            <td colspan="3">

                                <asp:TextBox ID="tbEmpCodeName" runat="server"></asp:TextBox>

                            </td>
                            
                            <td>

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

                                <asp:Label ID="Label21" runat="server" Text="發生日期："></asp:Label>

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

                                <asp:Button ID="btnQuery" runat="server" OnClick="btnQuery_Click" Text="查詢" />

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
                            <td>

                            </td>
                        </tr>
                    </table>
                </div>
                <div>

                    <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" AutoGenerateDeleteColumn="True" CellSpacing="0" Culture="zh-TW" GridLines="None" OnDeleteCommand="RadGrid1_DeleteCommand" OnNeedDataSource="RadGrid1_NeedDataSource">
                        <MasterTableView DataKeyNames="ID">
                            <Columns>
                                <telerik:GridBoundColumn DataField="EmpCode" FilterControlAltText="Filter EmpCode column" HeaderText="得分者職編" UniqueName="EmpCode">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="EmpName" FilterControlAltText="Filter EmpName column" HeaderText="得分者姓名" UniqueName="EmpName">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="OccurDate" DataFormatString="{0:yyyy/MM/dd}" FilterControlAltText="Filter OccurDate column" HeaderText="發生時間" UniqueName="OccurDate">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="ItemName" FilterControlAltText="Filter ItemName column" HeaderText="項目" UniqueName="ItemName">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="ItemCount" FilterControlAltText="Filter ItemCount column" HeaderText="次數" UniqueName="ItemCount">
                                </telerik:GridBoundColumn>
                            </Columns>
                        </MasterTableView>
                    </telerik:RadGrid>

                </div>
            </telerik:RadPageView>
            <telerik:RadPageView ID="rpvImport" runat="server">

    <div>
        <asp:Panel ID="Panel1" runat="server" GroupingText="Step1 - 項目">
       <table width="100%">
            <tr>
                <td class="auto-style11">
                    
        <asp:Label ID="Label7" runat="server" Text="上傳項目："></asp:Label>
                </td>
                <td colspan="3">
                    <telerik:RadComboBox ID="rcbCalcType" Runat="server" AutoPostBack="True" OnSelectedIndexChanged="rcbCalcType_SelectedIndexChanged" Width="200px">
                    </telerik:RadComboBox>
                    <telerik:RadComboBox Width="500px" ID="rcbItem" Runat="server" AllowCustomText="True" Filter="Contains" AutoPostBack="True">
                    </telerik:RadComboBox>
                </td>

  
            </tr>


        </table>
        </asp:Panel>

    </div>
    <div>

                <asp:Panel ID="Panel2" runat="server" GroupingText="Step2 - 下載匯入格式範例">
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/docs/教學點數匯入範例.xls">下載</asp:HyperLink>
                    <asp:Label ID="Label17" runat="server" Font-Bold="True" ForeColor="Red" Text="*範例檔第一行欄位名稱請勿刪除或修改"></asp:Label>
                </asp:Panel>
    
    
    </div>
    <div>

        <asp:Panel ID="Panel3" runat="server" GroupingText="Step3 - 匯入編輯後檔案">
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

