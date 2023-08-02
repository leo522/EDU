<%@ Page Language="C#"  MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="BatchEduFormSetting.aspx.cs" Inherits="BatchEduFormSetting" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register src="TreeViewComboBox.ascx" tagname="TreeViewComboBox" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;zoom:1;display:-moz-inline-stack;display:inline-block;display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default .rcbReadOnly .rcbInputCellLeft{background-position:0 -88px}.RadComboBox_Default .rcbReadOnly .rcbInputCellLeft{background-position:0 -88px}.RadComboBox_Default .rcbReadOnly .rcbInputCellLeft{background-position:0 -88px}.RadComboBox_Default .rcbReadOnly .rcbInputCellLeft{background-position:0 -88px}.RadComboBox_Default .rcbInputCellLeft{background-position:0 0}.RadComboBox_Default .rcbInputCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbInputCell{width:100%;height:20px;_height:22px;line-height:20px;_line-height:22px;text-align:left;vertical-align:middle}.RadComboBox .rcbInputCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbInputCellLeft{background-position:0 0}.RadComboBox_Default .rcbInputCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbInputCell{width:100%;height:20px;_height:22px;line-height:20px;_line-height:22px;text-align:left;vertical-align:middle}.RadComboBox .rcbInputCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbInputCellLeft{background-position:0 0}.RadComboBox_Default .rcbInputCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbInputCell{width:100%;height:20px;_height:22px;line-height:20px;_line-height:22px;text-align:left;vertical-align:middle}.RadComboBox .rcbInputCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbInputCellLeft{background-position:0 0}.RadComboBox_Default .rcbInputCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbInputCell{width:100%;height:20px;_height:22px;line-height:20px;_line-height:22px;text-align:left;vertical-align:middle}.RadComboBox .rcbInputCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbReadOnly .rcbArrowCellRight{background-position:-162px -176px}.RadComboBox_Default .rcbReadOnly .rcbArrowCellRight{background-position:-162px -176px}.RadComboBox_Default .rcbReadOnly .rcbArrowCellRight{background-position:-162px -176px}.RadComboBox_Default .rcbReadOnly .rcbArrowCellRight{background-position:-162px -176px}.RadComboBox_Default .rcbArrowCellRight{background-position:-18px -176px}.RadComboBox_Default .rcbArrowCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbArrowCell{width:18px}.RadComboBox .rcbArrowCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbArrowCellRight{background-position:-18px -176px}.RadComboBox_Default .rcbArrowCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbArrowCell{width:18px}.RadComboBox .rcbArrowCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbArrowCellRight{background-position:-18px -176px}.RadComboBox_Default .rcbArrowCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbArrowCell{width:18px}.RadComboBox .rcbArrowCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbArrowCellRight{background-position:-18px -176px}.RadComboBox_Default .rcbArrowCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbArrowCell{width:18px}.RadComboBox .rcbArrowCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">


    <input type="hidden" runat="server" id="hiddenKey" />

        <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
            <AjaxSettings>
                <telerik:AjaxSetting AjaxControlID="RadGrid1">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="RadGrid1" UpdatePanelCssClass="" />
                    </UpdatedControls>
                </telerik:AjaxSetting>

                <telerik:AjaxSetting AjaxControlID="btnSetExpireDate">
                </telerik:AjaxSetting>
            </AjaxSettings>
    </telerik:RadAjaxManager>


        <div>
    <table width="100%">
    <tr>
    <td width="35%" valign="top">
    <div>
    <table>
    <tr>
    <td>
        <asp:Label ID="Label4" runat="server" Text="職稱："></asp:Label>
        </td>
    <td>
        <uc1:TreeViewComboBox ID="TreeViewComboBox2" runat="server" 
            AllowSelectParent="False" AutoPostBack="True" Enabled="True" 
            TreeDataFieldID="code" TreeDataFieldParentID="ParentCodeRefID" 
            TreeDataSourceID="dsJobCode" TreeDataTextField="Name" />
        </td>
    </tr>
    </table>
    </div>
    <div>
        <telerik:RadTreeView ID="RadTreeView1" Runat="server" Width="100%" AppendDataBoundItems="True" 
            DataFieldID="TEMPLATE_ID" DataFieldParentID="PARENT_TEMPLATE_ID" 
            DataTextField="TEMPLATE_NAME" DataValueField="TEMPLATE_ID" 
            onnodeclick="RadTreeView1_NodeClick" >
        </telerik:RadTreeView>
        <asp:HyperLink ID="btnPreview" runat="server" Target="_blank">預覽表單</asp:HyperLink>
    </div>

        </td>
    <td width="65%" valign="top">
    <telerik:RadMultiPage ID="RadMultiPage1" Runat="server" BorderColor="Black" 
            BorderStyle="Solid" BorderWidth="1px" SelectedIndex="0" Width="100%">
        <telerik:RadPageView ID="RadPageView1" runat="server" Selected="True">

        <asp:Panel ID="Panel1" runat="server" GroupingText="設定名稱">
            <asp:TextBox ID="tbName" runat="server" Width="311px"></asp:TextBox>
        </asp:Panel>
        <asp:Panel ID="palExeDate" runat="server" GroupingText="發送日">
            <asp:RadioButton ID="rbSetDate" runat="server" Text="預約發送" Checked="True" 
                GroupName="SendSetting" />
            <telerik:RadDatePicker ID="rdpExecuteDate" Runat="server">
            </telerik:RadDatePicker>
            <asp:RadioButton ID="rbNow" runat="server" Text="儲存後立刻發送" 
                GroupName="SendSetting" />
        </asp:Panel>
        <asp:Panel ID="palFreq" runat="server"  GroupingText="重複頻率" Visible="False">
            <asp:RadioButton ID="rbNone" runat="server" Checked="True" Text="不重複" 
                                        GroupName="rbCycle" />
            <br />
            <asp:RadioButton ID="rbDay" runat="server" Text="每天" GroupName="rbCycle" />
            <br />
            <asp:RadioButton ID="rbMonth" runat="server" Text="每月" GroupName="rbCycle" />
            <telerik:RadNumericTextBox ID="rntbDay" Runat="server" Culture="zh-TW" 
                                        DbValueFactor="1" LabelWidth="64px" MaxValue="31" 
                MinValue="1" Value="1" 
                                        Width="30px">
                <NumberFormat DecimalDigits="0" ZeroPattern="n" />
            </telerik:RadNumericTextBox>
            <asp:Label ID="Label20" runat="server" Text="日"></asp:Label>
            <br />
            <asp:RadioButton ID="rbWeek" runat="server" Text="每個星期的" GroupName="rbCycle" />
            <br />
            &nbsp;&nbsp;&nbsp;
            <asp:CheckBox ID="cb7" runat="server" Text="日" />
            <asp:CheckBox ID="cb1" runat="server" Text="一" />
            <asp:CheckBox ID="cb2" runat="server" Text="二" />
            <asp:CheckBox ID="cb3" runat="server" Text="三" />
            <asp:CheckBox ID="cb4" runat="server" Text="四" />
            <asp:CheckBox ID="cb5" runat="server" Text="五" />
            <asp:CheckBox ID="cb6" runat="server" Text="六" />
            <br />
            <asp:RadioButton ID="rbSpecDay" runat="server" Text="每個月的第" 
                                        GroupName="rbCycle" />
            <asp:DropDownList ID="ddlweek" runat="server">
                <asp:ListItem Selected="True">1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
                <asp:ListItem>5</asp:ListItem>
                <asp:ListItem>6</asp:ListItem>
            </asp:DropDownList>
            <asp:Label ID="Label19" runat="server" Text="週的星期"></asp:Label>
            <asp:DropDownList ID="ddlspecweekday" runat="server">
                <asp:ListItem Selected="True" Value="7">日</asp:ListItem>
                <asp:ListItem Value="1">一</asp:ListItem>
                <asp:ListItem Value="2">二</asp:ListItem>
                <asp:ListItem Value="3">三</asp:ListItem>
                <asp:ListItem Value="4">四</asp:ListItem>
                <asp:ListItem Value="5">五</asp:ListItem>
                <asp:ListItem Value="6">六</asp:ListItem>
            </asp:DropDownList>
        </asp:Panel>
        <asp:Panel ID="palTarget" runat="server" GroupingText="發送對象">
        <asp:Panel ID="palSettingFix" runat="server">
            <asp:Label ID="Label23" runat="server" Text="發送教師類型："></asp:Label>
            <asp:DropDownList ID="ddlTeacherType" runat="server" AutoPostBack="True" 
                onselectedindexchanged="ddlTeacherType_SelectedIndexChanged">
            </asp:DropDownList>
            <asp:CheckBox ID="cbEach" runat="server" Checked="True" Text="每位學員一份" 
                Visible="False" />
            <asp:Panel ID="panUserDefine" runat="server" Visible="false">
            <table>
            <tr>
            <td>
                <asp:Label ID="Label25" runat="server" Text="員編："></asp:Label>
                <asp:TextBox ID="tbTeacherEmpCode" runat="server"></asp:TextBox>
                <asp:Button ID="btnAddTeacher" runat="server" Text="加入" 
                    onclick="btnAddTeacher_Click" />            
            </td>
            </tr>
            <tr>
            <td>
            <asp:ListBox ID="lbTeacher" runat="server" Width="149px"></asp:ListBox>
                <asp:Button ID="btnDelTeacher" runat="server" Text="移除選取" 
                    onclick="btnDelTeacher_Click" />
            </td>
            </tr>
            </table>
            </asp:Panel>
         </asp:Panel>
         <asp:Panel ID="palSettingMultiTarget" runat="server" Visible="False">
             <asp:Label ID="Label24" runat="server" Text="發送對象："></asp:Label>
             <asp:DropDownList ID="ddlSendType" runat="server">
             </asp:DropDownList>
             &nbsp;
             <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/add.jpg" 
                 onclick="ImageButton1_Click" ToolTip="新增" />
         </asp:Panel>
            <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" 
                CellSpacing="0" Culture="zh-TW" GridLines="None" 
                onneeddatasource="RadGrid1_NeedDataSource" 
                onupdatecommand="RadGrid1_UpdateCommand" 
                onitemdatabound="RadGrid1_ItemDataBound" AllowMultiRowSelection="True">
                <ClientSettings AllowDragToGroup="True">
                    <Selecting AllowRowSelect="True" />
                </ClientSettings>
                <MasterTableView>
                    <Columns>
                        <telerik:GridClientSelectColumn FilterControlAltText="Filter column column" 
                            UniqueName="column">
                        </telerik:GridClientSelectColumn>
                        <telerik:GridCheckBoxColumn DataField="IsChecked" DataType="System.Boolean" 
                            FilterControlAltText="Filter IsChecked column" HeaderText="是否填寫" 
                            UniqueName="IsChecked" ReadOnly="True" Visible="False">
                            <HeaderStyle Width="80px" />
                        </telerik:GridCheckBoxColumn>
                        <telerik:GridBoundColumn DataField="SettingName" 
                            FilterControlAltText="Filter SettingName column" HeaderText="角色" 
                            ReadOnly="True" UniqueName="SettingName">
                        </telerik:GridBoundColumn>
                        <telerik:GridTemplateColumn DataField="ExpireDate" 
                            FilterControlAltText="Filter ExpireDate column" HeaderText="逾期日期" 
                            UniqueName="ExpireDate">
                   <ItemTemplate>
                        <telerik:RadDatePicker ID="rdpExpireDate" Runat="server" DbSelectedDate='<%# Bind("ExpireDate") %>'>
                        <DateInput ID="DateInput1" runat="server" DisplayDateFormat="yyyy/MM/dd"></DateInput>
                        </telerik:RadDatePicker>
                    </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn DataField="UDTarget" 
                            FilterControlAltText="Filter ExpireDate column" HeaderText="指定發送對象員編" 
                            UniqueName="UDTarget">
                   <ItemTemplate>
                   <asp:TextBox ID="tbUDTarget" runat="server" Text='<%# Bind("UserDefineTargetID") %>'></asp:TextBox>
                    </ItemTemplate>
                        </telerik:GridTemplateColumn>

                    </Columns>
                    <GroupByExpressions>
                        <telerik:GridGroupByExpression>
                            <SelectFields>
                                   <telerik:GridGroupByField FieldAlias="Group" FieldName="Group" FormatString="{0:D}"
                                    HeaderValueSeparator="-"></telerik:GridGroupByField>
                            </SelectFields>
                            <GroupByFields>
                                <telerik:GridGroupByField FieldName="Group"/>
                            </GroupByFields>
                        </telerik:GridGroupByExpression>
                    </GroupByExpressions>
                    <EditFormSettings>
                        <EditColumn FilterControlAltText="Filter EditCommandColumn column" canceltext="取消" 
                            edittext="儲存" inserttext="儲存" updatetext="儲存">
                        </EditColumn>
                    </EditFormSettings>
                </MasterTableView>
            </telerik:RadGrid>
        </asp:Panel>
        <asp:Button ID="btnSubmit" runat="server" onclick="btnSubmit_Click" Text="發送" />
</telerik:RadPageView>
</telerik:RadMultiPage>
        </td>
    </tr>
    <tr>
    <td colspan="2">
        &nbsp;</td>
    </tr>
    </table>
    </div>


    <asp:ObjectDataSource ID="dsJobCode" runat="server" SelectMethod="GetCodeRefsStatic" 
        TypeName="KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService" 
        DataObjectTypeName="KMU.EduActivity.ApplicationLayer.DTO.V_CodeRefDto">
        <SelectParameters>
            <asp:Parameter DefaultValue="EduAct_JobSerial" Name="codetype" />
        </SelectParameters>
    </asp:ObjectDataSource>

</asp:Content>
