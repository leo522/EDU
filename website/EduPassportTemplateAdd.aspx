<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="EduPassportTemplateAdd.aspx.cs" Inherits="EduPassportTemplateAdd" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<%@ Register src="UserControls/EduPassportItemControl.ascx" tagname="EduPassportItemControl" tagprefix="uc1" %>

<%@ Register src="UserControls/EduPassportItemSelect.ascx" tagname="EduPassportItemSelect" tagprefix="uc2" %>

<%@ Register src="UserControls/EduTermSelect.ascx" tagname="EduTermSelect" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">

    .RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}
    .RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}
.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}
.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}
.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox_Default .rcbReadOnly .rcbInputCellLeft{background-position:0 -88px}.RadComboBox .rcbInputCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox .rcbInputCell{width:100%;height:20px;_height:22px;line-height:20px;_line-height:22px;text-align:left;vertical-align:middle}.RadComboBox_Default .rcbInputCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox_Default .rcbInputCellLeft{background-position:0 0}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}
    .RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}
    .RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox_Default .rcbReadOnly .rcbArrowCellRight{background-position:-162px -176px}.RadComboBox .rcbArrowCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox .rcbArrowCell{width:18px}.RadComboBox_Default .rcbArrowCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox_Default .rcbArrowCellRight{background-position:-18px -176px}</style>
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
                <asp:Label ID="Label1" runat="server" Text="項目名稱："></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label9" runat="server" Text="樣版生效日："></asp:Label>
            </td>
            <td>
                <telerik:RadDatePicker ID="rdpSdate" Runat="server">
                </telerik:RadDatePicker>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label10" runat="server" Text="樣版停用日："></asp:Label>
            </td>
            <td>
                <telerik:RadDatePicker ID="rdpEdate" Runat="server">
                </telerik:RadDatePicker>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label6" runat="server" Text="允許臨教部審核："></asp:Label>
            </td>
            <td>
                <asp:CheckBox ID="cbAllowAdminConfirm" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="適用職類："></asp:Label>
            </td>
            <td>
                    <telerik:RadDropDownTree ID="rddtJobCode" runat="server" DataFieldID="Code" DataFieldParentID="ParentCodeRefid" DataSourceID="dsJobCode" DataTextField="name" DataValueField="code" CheckBoxes="CheckChildNodes" OnDataBound="rddtJobCode_DataBound">
                    </telerik:RadDropDownTree>
                </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="適用單位："></asp:Label>
            </td>
            <td>
                <telerik:RadComboBox ID="ddlUnit" Runat="server" AllowCustomText="True" Filter="Contains" CheckBoxes="True" Width="250px">
                </telerik:RadComboBox>
            </td>
        </tr>
        <tr>
            <td>

                <asp:Label ID="Label12" runat="server" Text="適用課程："></asp:Label>

            </td>
            <td>

                <uc2:EduTermSelect ID="EduTermSelect1" runat="server" />
                <asp:ImageButton ID="btnAddSendTerm" runat="server" ImageUrl="~/Images/add.jpg" ToolTip="新增" OnClick="btnAddSendTerm_Click" />

            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>

                <telerik:RadGrid ID="rgSendTerm" runat="server" AllowMultiRowSelection="True" AutoGenerateColumns="False" AutoGenerateDeleteColumn="True" CellSpacing="0" Culture="zh-TW" GridLines="None" OnDeleteCommand="rgSendTerm_DeleteCommand">
                    <ClientSettings AllowDragToGroup="True">
                        <Selecting AllowRowSelect="True" />
                    </ClientSettings>
                    <MasterTableView DataKeyNames="EduTermID">
                        <Columns>
                            <telerik:GridClientSelectColumn FilterControlAltText="Filter column column" UniqueName="column">
                            </telerik:GridClientSelectColumn>
                            <telerik:GridBoundColumn DataField="EduTermID" FilterControlAltText="Filter SettingName column" HeaderText="代碼" ReadOnly="True" UniqueName="EduTermID">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Name" FilterControlAltText="Filter DeptName column" HeaderText="名稱" UniqueName="Name">
                            </telerik:GridBoundColumn>
                        </Columns>
                        <EditFormSettings>
                            <EditColumn canceltext="取消" edittext="儲存" FilterControlAltText="Filter EditCommandColumn column" inserttext="儲存" updatetext="儲存">
                            </EditColumn>
                        </EditFormSettings>
                    </MasterTableView>
                </telerik:RadGrid>

            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Text="樣版說明："></asp:Label>
            </td>
            <td>

                            <telerik:RadEditor ID="reContent" Runat="server" Height="177px" Width="688px">
                            </telerik:RadEditor>
                        </td>
        </tr>
    
    </table>
    <table width="90%">
        <tr style="background-color:lightgray">
            <td width="100%"  align="center" style="background-color: #33CCFF">
                <asp:Label ID="Label5" runat="server" Text="樣板項目"></asp:Label>
            </td>
        </tr>
        <tr>
            <td width="100%">
                <table>
                    <tr>
                        <td><asp:Label ID="Label8" runat="server" Text="選擇項目："></asp:Label></td>
                        <td>
                            <uc2:EduPassportItemSelect ID="EduPassportItemSelect1" runat="server" />
                        </td>
                        <td><asp:Label ID="Label7" runat="server" Text="附加標題："></asp:Label></td>
                        <td><asp:TextBox ID="tbTitle" runat="server"></asp:TextBox></td>
                        <td>&nbsp;</td>
                        <td>

                            <asp:Label ID="Label11" runat="server" Text="加入次數："></asp:Label>

                        </td>
                        <td>

                            <telerik:RadNumericTextBox ID="rntbAddTimes" Runat="server" Value="1" Width="40px">
<NegativeStyle Resize="None"></NegativeStyle>

<NumberFormat ZeroPattern="n" DecimalDigits="0"></NumberFormat>

<EmptyMessageStyle Resize="None"></EmptyMessageStyle>

<ReadOnlyStyle Resize="None"></ReadOnlyStyle>

<FocusedStyle Resize="None"></FocusedStyle>

<DisabledStyle Resize="None"></DisabledStyle>

<InvalidStyle Resize="None"></InvalidStyle>

<HoveredStyle Resize="None"></HoveredStyle>

<EnabledStyle Resize="None"></EnabledStyle>
                            </telerik:RadNumericTextBox>

                        </td>
                        <td>
                            <asp:Button ID="btnSAdd" runat="server" Text="加入" OnClick="btnSAdd_Click" />
                        </td>
                        
                    </tr>
                </table>
                
                
                
            </td>
        </tr>
        <tr>
            <td width="100%">
                <table width="100%">
                    <tr>
                        <td>
                            <telerik:RadGrid ID="rgSDet" runat="server" AutoGenerateColumns="False" CellSpacing="0" Culture="zh-TW" GridLines="None">
                                <ClientSettings>
                                    <Selecting AllowRowSelect="True" />
                                </ClientSettings>
                                <MasterTableView DataKeyNames="seq">
                                    <Columns>
                                        <telerik:GridBoundColumn DataField="Seq" FilterControlAltText="Filter FieldDesc column" HeaderText="順序" UniqueName="Seq">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="ItemName" FilterControlAltText="Filter FieldType column" HeaderText="項目名稱" UniqueName="ItemName">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Title" FilterControlAltText="Filter Title column" HeaderText="附加標題" UniqueName="Title">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" UniqueName="TemplateColumn">
                                            <ItemTemplate>
                                                <asp:ImageButton ImageUrl="~/Images/delete.gif" ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="刪除" OnClientClick="javascript:return confirm('是否確定刪除?')" />
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                    </Columns>
                                </MasterTableView>
                            </telerik:RadGrid>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:Button ID="btnSMoveUp" runat="server" Text="上移" OnClick="btnSMoveUp_Click" />
                            &nbsp;
                            &nbsp;
                            <asp:Button ID="btnSMoveDown" runat="server" Text="下移" OnClick="btnSMoveDown_Click" />
                        </td>
                    </tr>
                </table>
            </td>

        </tr>

        <tr>
            <td colspan="2" align="center">

                <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="儲存" />
                &nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnExit" runat="server" OnClick="btnExit_Click" Text="取消" />

            </td>
        </tr>
    </table>
</asp:Content>

