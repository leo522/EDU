<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="EduPassportTemplateManager.aspx.cs" Inherits="EduPassportTemplateManager" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}
.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}
.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}
    .RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default .rcbReadOnly .rcbInputCellLeft{background-position:0 -88px}.RadComboBox_Default .rcbInputCellLeft{background-position:0 0}.RadComboBox_Default .rcbInputCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbInputCell{width:100%;height:20px;_height:22px;line-height:20px;_line-height:22px;text-align:left;vertical-align:middle}.RadComboBox .rcbInputCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}
    .RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbReadOnly .rcbArrowCellRight{background-position:-162px -176px}.RadComboBox_Default .rcbArrowCellRight{background-position:-18px -176px}.RadComboBox_Default .rcbArrowCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbArrowCell{width:18px}.RadComboBox .rcbArrowCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
            <asp:ObjectDataSource ID="dsJobCode" runat="server" DataObjectTypeName="KMU.EduActivity.ApplicationLayer.DTO.V_CodeRefDto" SelectMethod="GetCodeRefsStatic" TypeName="KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService">
                <SelectParameters>
                    <asp:Parameter DefaultValue="EduAct_JobSerial" Name="codetype" />
                </SelectParameters>
            </asp:ObjectDataSource>
    <table>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="適用職類："></asp:Label>
            </td>
            <td>
                    <telerik:RadDropDownTree ID="rddtJobCode" runat="server" DataFieldID="Code" DataFieldParentID="ParentCodeRefid" DataSourceID="dsJobCode" DataTextField="name" DataValueField="code">
                    </telerik:RadDropDownTree>
                </td>
            <td>
                <asp:Label ID="Label2" runat="server" Text="適用單位："></asp:Label>
            </td>
            <td>
                <telerik:RadComboBox ID="ddlUnit" Runat="server" AllowCustomText="True" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:Label ID="Label3" runat="server" Text="樣板名稱："></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbKeyWord" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btnQuery" runat="server" Text="查詢" OnClick="btnQuery_Click" />
            </td>
            <td>
                <asp:Button ID="btnAdd" runat="server" Text="新增" OnClick="btnAdd_Click" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td colspan="7">

                            &nbsp;</td>
        </tr>
    </table>
    <div>

                <telerik:RadGrid ID="rgList" runat="server" AutoGenerateColumns="False" CellSpacing="0" GridLines="None" OnItemCreated="rgList_ItemCreated" Culture="zh-TW" OnNeedDataSource="rgList_NeedDataSource">
                    <MasterTableView DataKeyNames="TemplateID,Status">
                        <Columns>
                            <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" UniqueName="TemplateColumn">
                                <ItemTemplate>
                                    <asp:HyperLink ID="btnEdit" runat="server" Text="編輯" />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn DataField="TemplateName" FilterControlAltText="Filter DeptName column" HeaderText="樣板名稱" UniqueName="TemplateName">
                            </telerik:GridBoundColumn>
                            <telerik:GridDateTimeColumn DataField="sdate" DataFormatString="{0:yyyy/MM/dd}" FilterControlAltText="Filter sdate column" HeaderText="有效起日" UniqueName="sdate">
                            </telerik:GridDateTimeColumn>
                            <telerik:GridDateTimeColumn DataField="edate" DataFormatString="{0:yyyy/MM/dd}" FilterControlAltText="Filter edate column" HeaderText="有效迄日" UniqueName="edate">
                            </telerik:GridDateTimeColumn>
                            <telerik:GridBoundColumn DataField="CreaterName" FilterControlAltText="Filter CreaterName column" HeaderText="建立者" UniqueName="CreaterName">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="ModifierName" FilterControlAltText="Filter ModifierName column" HeaderText="最後修改者" UniqueName="ModifierName">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="ModifyDate" FilterControlAltText="Filter ModifyDate column" HeaderText="修改時間" UniqueName="ModifyDate">
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" UniqueName="CopyColumn">
                                <ItemTemplate>
                                    <asp:HyperLink ID="btnCopy" runat="server" Text="複製" />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" UniqueName="UpdateStatusColumn">
                                <ItemTemplate>
                                    <asp:Button ID="btnUpdateStatus" OnClick="btnUpdateStatus_Click" runat="server" Text="發佈" />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" UniqueName="DeleteColumn">
                                <ItemTemplate>
                                    <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="刪除" OnClientClick="javascript:if(!confirm('是否確定刪除選擇的項目?')) return false;" />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>
    
    </div>

</asp:Content>

