<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="EduMemberTermQuery.aspx.cs" Inherits="EduMemberTermQuery" %>


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
    <asp:Panel ID="panControl" runat="server">

    
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
                        &nbsp;</td>
                    <td class="auto-style6">
                        &nbsp;</td>
                </tr>
              

            </table>
        </div>
    </asp:Panel>
    <div>
        <table>
  <tr>
                    <td class="auto-style11">
                        <asp:Label ID="Label15" runat="server" Text="*實習期間："></asp:Label>
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
                  <td>
                        <asp:Label ID="Label13" runat="server" Text="學員："></asp:Label>
                    </td>                
                    <td colspan="3">

                        <asp:TextBox ID="tbEvalTarget" runat="server"></asp:TextBox>
                        <asp:Label ID="Label14" runat="server" Text="(職編或姓名或身分證字號)"></asp:Label>

                        </td>
  
                </tr>

                <tr>
                    <td class="auto-style11">
                        <asp:Button ID="btnQuery" runat="server" Text="查詢" OnClick="btnQuery_Click" />
                    </td>
                    <td>
                            <asp:Button ID="btnExportList" runat="server" OnClick="btnExportList_Click" Text="匯出" />
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

                        <telerik:RadGrid ID="rgList" runat="server" CellSpacing="0" Culture="zh-TW" GridLines="None" OnNeedDataSource="rgList_NeedDataSource" AllowSorting="True" OnItemCreated="rgList_ItemCreated" AutoGenerateColumns="False">
                            <MasterTableView DataKeyNames="EduTermID,職編">
                                <RowIndicatorColumn Visible="False">
                                </RowIndicatorColumn>
                                <Columns>
                                    <telerik:GridBoundColumn DataField="職編" FilterControlAltText="Filter 職編 column" HeaderText="職編" UniqueName="職編">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="姓名" FilterControlAltText="Filter 姓名 column" HeaderText="姓名" UniqueName="姓名">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="職稱" FilterControlAltText="Filter 職稱 column" HeaderText="職稱" UniqueName="職稱">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="實習單位" FilterControlAltText="Filter 實習單位 column" HeaderText="實習單位" UniqueName="實習單位">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="實習時間" FilterControlAltText="Filter 實習時間 column" HeaderText="實習時間" UniqueName="實習時間">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="課程" FilterControlAltText="Filter 課程 column" HeaderText="課程" UniqueName="課程">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" UniqueName="TemplateColumn">
                                        <ItemTemplate>
                                            <asp:HyperLink runat="server" Target="_blank" ID="hlForm" Text="表單"></asp:HyperLink>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                </Columns>
                            </MasterTableView>
                        </telerik:RadGrid>
    <asp:ObjectDataSource ID="dsJobCode" runat="server" SelectMethod="GetCodeRefsStatic" 
        TypeName="KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService" 
        DataObjectTypeName="KMU.EduActivity.ApplicationLayer.DTO.V_CodeRefDto">
        <SelectParameters>
            <asp:Parameter DefaultValue="EduAct_JobSerial" Name="codetype" />
        </SelectParameters>
    </asp:ObjectDataSource>
    
    
    </div>

</asp:Content>

