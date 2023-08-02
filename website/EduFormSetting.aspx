<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EduFormSetting.aspx.cs" Inherits="EduFormSetting" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register src="TreeViewComboBox.ascx" tagname="TreeViewComboBox" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
.RadInput_Default{font:12px "segoe ui",arial,sans-serif}.RadInput{vertical-align:middle}.RadInput_Default{font:12px "segoe ui",arial,sans-serif}.RadInput{vertical-align:middle}.RadInput_Default{font:12px "segoe ui",arial,sans-serif}.RadInput{vertical-align:middle}.RadInput_Default{font:12px "segoe ui",arial,sans-serif}.RadInput{vertical-align:middle}.RadInput .riTextBox{height:17px}.RadInput .riTextBox{height:17px}.RadInput .riTextBox{height:17px}.RadInput .riTextBox{height:17px}
        .RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}
.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox_Default .rcbReadOnly .rcbInputCellLeft{background-position:0 -88px}.RadComboBox_Default .rcbReadOnly .rcbInputCellLeft{background-position:0 -88px}.RadComboBox_Default .rcbReadOnly .rcbInputCellLeft{background-position:0 -88px}.RadComboBox_Default .rcbReadOnly .rcbInputCellLeft{background-position:0 -88px}.RadComboBox_Default .rcbReadOnly .rcbInputCellLeft{background-position:0 -88px}.RadComboBox_Default .rcbReadOnly .rcbInputCellLeft{background-position:0 -88px}.RadComboBox_Default .rcbReadOnly .rcbInputCellLeft{background-position:0 -88px}.RadComboBox .rcbInputCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox .rcbInputCell{width:100%;height:20px;_height:22px;line-height:20px;_line-height:22px;text-align:left;vertical-align:middle}.RadComboBox_Default .rcbInputCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox_Default .rcbInputCellLeft{background-position:0 0}.RadComboBox .rcbInputCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox .rcbInputCell{width:100%;height:20px;_height:22px;line-height:20px;_line-height:22px;text-align:left;vertical-align:middle}.RadComboBox_Default .rcbInputCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox_Default .rcbInputCellLeft{background-position:0 0}.RadComboBox .rcbInputCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox .rcbInputCell{width:100%;height:20px;_height:22px;line-height:20px;_line-height:22px;text-align:left;vertical-align:middle}.RadComboBox_Default .rcbInputCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox_Default .rcbInputCellLeft{background-position:0 0}.RadComboBox .rcbInputCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox .rcbInputCell{width:100%;height:20px;_height:22px;line-height:20px;_line-height:22px;text-align:left;vertical-align:middle}.RadComboBox_Default .rcbInputCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox_Default .rcbInputCellLeft{background-position:0 0}.RadComboBox .rcbInputCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox .rcbInputCell{width:100%;height:20px;_height:22px;line-height:20px;_line-height:22px;text-align:left;vertical-align:middle}.RadComboBox_Default .rcbInputCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox_Default .rcbInputCellLeft{background-position:0 0}.RadComboBox .rcbInputCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox .rcbInputCell{width:100%;height:20px;_height:22px;line-height:20px;_line-height:22px;text-align:left;vertical-align:middle}.RadComboBox_Default .rcbInputCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox_Default .rcbInputCellLeft{background-position:0 0}.RadComboBox .rcbInputCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox .rcbInputCell{width:100%;height:20px;_height:22px;line-height:20px;_line-height:22px;text-align:left;vertical-align:middle}.RadComboBox_Default .rcbInputCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox_Default .rcbInputCellLeft{background-position:0 0}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox_Default .rcbReadOnly .rcbArrowCellRight{background-position:-162px -176px}.RadComboBox_Default .rcbReadOnly .rcbArrowCellRight{background-position:-162px -176px}.RadComboBox_Default .rcbReadOnly .rcbArrowCellRight{background-position:-162px -176px}.RadComboBox_Default .rcbReadOnly .rcbArrowCellRight{background-position:-162px -176px}.RadComboBox_Default .rcbReadOnly .rcbArrowCellRight{background-position:-162px -176px}.RadComboBox_Default .rcbReadOnly .rcbArrowCellRight{background-position:-162px -176px}.RadComboBox_Default .rcbReadOnly .rcbArrowCellRight{background-position:-162px -176px}.RadComboBox .rcbArrowCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}
    .RadComboBox .rcbArrowCell{width:18px}.RadComboBox_Default .rcbArrowCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox_Default .rcbArrowCellRight{background-position:-18px -176px}.RadComboBox .rcbArrowCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox .rcbArrowCell{width:18px}.RadComboBox_Default .rcbArrowCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox_Default .rcbArrowCellRight{background-position:-18px -176px}.RadComboBox .rcbArrowCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox .rcbArrowCell{width:18px}.RadComboBox_Default .rcbArrowCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox_Default .rcbArrowCellRight{background-position:-18px -176px}.RadComboBox .rcbArrowCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox .rcbArrowCell{width:18px}.RadComboBox_Default .rcbArrowCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox_Default .rcbArrowCellRight{background-position:-18px -176px}.RadComboBox .rcbArrowCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox .rcbArrowCell{width:18px}.RadComboBox_Default .rcbArrowCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox_Default .rcbArrowCellRight{background-position:-18px -176px}.RadComboBox .rcbArrowCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox .rcbArrowCell{width:18px}.RadComboBox_Default .rcbArrowCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox_Default .rcbArrowCellRight{background-position:-18px -176px}.RadComboBox .rcbArrowCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox .rcbArrowCell{width:18px}.RadComboBox_Default .rcbArrowCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox_Default .rcbArrowCellRight{background-position:-18px -176px}
        </style>
</head>
<body>
<script type="text/javascript">
    function GetRadWindow() {
        var oWindow = null;
        if (window.radWindow) oWindow = window.radWindow;
        else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow;
        return oWindow;
    }

    function CloseWindow(bool) {
        var oArg = new Object();
        oArg.NeedRefresh = bool;
        var oWnd = GetRadWindow();
        oWnd.close(oArg);
    }

</script>
    <script type="text/javascript">
        //<![CDATA[
        function openFormSettingWin() {
            var oWnd = radopen("AutoEduFormSetting.aspx", "rwOpenBig");
        }
        function openEditFormSettingWin(id) {
            var oWnd = radopen("AutoEduFormSetting.aspx?Query=1&AutoFTListID=" + id, "rwOpenBig");
        }
        function OnClientClose(oWnd, args) {
            try {
                if (args._argument.NeedRefresh) {

                }
            }
            catch (e) {
            }
        }
        //]]>
    </script>
    <form id="form1" runat="server">
    <input type="hidden" runat="server" id="hiddenKey" />
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Assembly="Telerik.Web.UI" 
                Name="Telerik.Web.UI.Common.Core.js">
            </asp:ScriptReference>
            <asp:ScriptReference Assembly="Telerik.Web.UI" 
                Name="Telerik.Web.UI.Common.jQuery.js">
            </asp:ScriptReference>
            <asp:ScriptReference Assembly="Telerik.Web.UI" 
                Name="Telerik.Web.UI.Common.jQueryInclude.js">
            </asp:ScriptReference>
        </Scripts>
    </telerik:RadScriptManager>

        <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
            <AjaxSettings>
                <telerik:AjaxSetting AjaxControlID="RadGrid1">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="RadGrid1" UpdatePanelCssClass="" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="btnSubmit">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="Panel1" UpdatePanelCssClass="" />
                        <telerik:AjaxUpdatedControl ControlID="palExeDate" />
                        <telerik:AjaxUpdatedControl ControlID="palFreq" />
                        <telerik:AjaxUpdatedControl ControlID="palTarget" />
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
<telerik:RadTabStrip ID="RadTabStrip1" runat="server" MultiPageID="RadMultiPage1" 
            SelectedIndex="0" Skin="WebBlue">
        <Tabs>
            <telerik:RadTab runat="server" PageViewID="RadPageView1" 
                Text="表單發送" Selected="True">
            </telerik:RadTab>
            <telerik:RadTab runat="server" PageViewID="RadPageView2" Text="逾期表單維護">
            </telerik:RadTab>
        </Tabs>
    </telerik:RadTabStrip>
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
            <table>
                <tr>
                    <td>
            <asp:Label ID="Label23" runat="server" Text="發送教師類型："></asp:Label>
            <asp:DropDownList ID="ddlTeacherType" runat="server" AutoPostBack="True" 
                onselectedindexchanged="ddlTeacherType_SelectedIndexChanged">
            </asp:DropDownList>
                    </td>
                    <td>
             <asp:RadioButtonList ID="rbSendOrderSetting" runat="server" RepeatDirection="Horizontal">
                 <asp:ListItem Selected="True" Value="first">第一位教師</asp:ListItem>
                 <asp:ListItem Value="after1">第一位教師除外</asp:ListItem>
                 <asp:ListItem Value="all">全部</asp:ListItem>
             </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">

                    </td>
                </tr>
            </table>


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
                        <asp:Panel ID="panEach" runat="server" Visible="false">
            <asp:CheckBox ID="cbEach" runat="server" Checked="True" Text="每位學員一份" />
                            <asp:Label ID="Label27" runat="server" Text="　送指定學員:"></asp:Label>
                            <asp:TextBox ID="tbUDStudent" runat="server"></asp:TextBox>
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
                onitemdatabound="RadGrid1_ItemDataBound" AllowMultiRowSelection="True" OnDeleteCommand="RadGrid1_DeleteCommand">
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
                        <telerik:GridButtonColumn CommandName="Delete" FilterControlAltText="Filter delColumn column" Text="刪除" UniqueName="delColumn">
                        </telerik:GridButtonColumn>

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
        <asp:Button ID="btnSubmit" runat="server" onclick="btnSubmit_Click" OnClientClick="if(!confirm('確定發送?')){return false;} else {document.getElementById('btnSubmit').style.display='none';}" Text="發送" />
            <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="儲存" Visible="False" />
</telerik:RadPageView>
        <telerik:RadPageView ID="RadPageView2" runat="server" Selected="false">

            <telerik:RadGrid ID="rgExpireData" runat="server" AllowMultiRowSelection="True" 
                AutoGenerateColumns="False" CellSpacing="0" Culture="zh-TW" GridLines="None" 
                onneeddatasource="rgHistory0_NeedDataSource">
                <ExportSettings>
                    <Pdf>
                        <PageHeader>
                            <LeftCell Text="" />
                            <MiddleCell Text="" />
                            <RightCell Text="" />
                        </PageHeader>
                        <PageFooter>
                            <LeftCell Text="" />
                            <MiddleCell Text="" />
                            <RightCell Text="" />
                        </PageFooter>
                    </Pdf>
                </ExportSettings>
                <ClientSettings>
                    <Selecting AllowRowSelect="True" />
                </ClientSettings>
                <MasterTableView DataKeyNames="INSTANCE_ID">
                    <CommandItemSettings ExportToPdfText="Export to PDF" />
                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" 
                        Visible="False">
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn Created="True" 
                        FilterControlAltText="Filter ExpandColumn column" Visible="True">
                    </ExpandCollapseColumn>
                    <Columns>
                        <telerik:GridClientSelectColumn FilterControlAltText="Filter column column" 
                            UniqueName="column">
                        </telerik:GridClientSelectColumn>
                        <telerik:GridDateTimeColumn DataField="INSTANCE_CREATE_DATETIME" 
                            FilterControlAltText="Filter INSTANCE_CREATE_DATETIME column" HeaderText="建立時間" 
                            UniqueName="INSTANCE_CREATE_DATETIME">
                        </telerik:GridDateTimeColumn>
                        <telerik:GridBoundColumn DataField="membername" 
                            FilterControlAltText="Filter membername column" HeaderText="填寫人" 
                            UniqueName="membername">
                        </telerik:GridBoundColumn>
                        <telerik:GridDateTimeColumn DataField="expireDate" 
                            FilterControlAltText="Filter expireDate column" HeaderText="逾期日" 
                            UniqueName="expireDate">
                        </telerik:GridDateTimeColumn>
                    </Columns>
                    <EditFormSettings>
                        <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                        </EditColumn>
                    </EditFormSettings>
                    <BatchEditingSettings EditType="Cell" />
                    <PagerStyle PageSizeControlType="RadComboBox" />
                </MasterTableView>
                <PagerStyle PageSizeControlType="RadComboBox" />
                <FilterMenu EnableImageSprites="False">
                </FilterMenu>
            </telerik:RadGrid>
            <br />
            <asp:Label ID="Label21" runat="server" Text="調整逾期日期："></asp:Label>
            <telerik:RadDatePicker ID="rdpExpireDate" Runat="server">
            </telerik:RadDatePicker>
            <asp:Button ID="btnSetExpireDate" runat="server" 
                onclick="btnSetExpireDate_Click" Text="設定" />

</telerik:RadPageView>
</telerik:RadMultiPage>
        </td>
    </tr>
    <tr>
    <td colspan="2">
    <div>
        <asp:Label ID="Label22" runat="server" Text="執行紀錄："></asp:Label>
        <asp:Button ID="btnDelHistory" runat="server" onclick="btnDelHistory_Click" OnClientClick="if(!confirm('刪除記錄會連同已發送的表單也刪除，是否確定執行本動作?')){return false;}"
            Text="刪除選取" />
        &nbsp;
        <asp:Button ID="btnQueryHistory" runat="server" onclick="btnQueryHistory_Click" 
            Text="查詢設定" />
        &nbsp;
        <asp:Button ID="btnReSend" runat="server" onclick="btnReSend_Click" OnClientClick="if(!confirm('補發送僅針對新增入課程人員補送，先前送過的表單不會重複發送，是否確定執行本動作?')){return false;}"
            Text="補發送選取設定" />
        <telerik:RadGrid ID="rgHistory" runat="server" AutoGenerateColumns="False" 
            CellSpacing="0" Culture="zh-TW" GridLines="None" 
            onneeddatasource="rgHistory_NeedDataSource">
<ExportSettings>
<Pdf>
<PageHeader>
<LeftCell Text=""></LeftCell>

<MiddleCell Text=""></MiddleCell>

<RightCell Text=""></RightCell>
</PageHeader>

<PageFooter>
<LeftCell Text=""></LeftCell>

<MiddleCell Text=""></MiddleCell>

<RightCell Text=""></RightCell>
</PageFooter>
</Pdf>
</ExportSettings>

            <ClientSettings>
                <Selecting AllowRowSelect="True" />
            </ClientSettings>

<MasterTableView DataKeyNames="FTListID">
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

<RowIndicatorColumn Visible="False" 
        FilterControlAltText="Filter RowIndicator column">
</RowIndicatorColumn>

<ExpandCollapseColumn Visible="True" 
        FilterControlAltText="Filter ExpandColumn column" Created="True">
</ExpandCollapseColumn>

    <Columns>
        <telerik:GridClientSelectColumn FilterControlAltText="Filter column column" 
            UniqueName="column">
        </telerik:GridClientSelectColumn>
        <telerik:GridBoundColumn DataField="name" 
            FilterControlAltText="Filter name column" HeaderText="名稱" UniqueName="name">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="TEMPLATE_NAME" 
            FilterControlAltText="Filter TEMPLATE_NAME column" HeaderText="表單" 
            UniqueName="TEMPLATE_NAME">
        </telerik:GridBoundColumn>
        <telerik:GridDateTimeColumn DataField="ExecuteDate" 
            FilterControlAltText="Filter ExecuteDate column" HeaderText="預定執行日期" 
            UniqueName="ExecuteDate">
        </telerik:GridDateTimeColumn>
        <telerik:GridBoundColumn DataField="Status" FilterControlAltText="Filter Status column" HeaderText="已執行" UniqueName="Status">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="CreaterName" FilterControlAltText="Filter CreaterName column" HeaderText="發送人" UniqueName="CreaterName">
        </telerik:GridBoundColumn>
    </Columns>

<EditFormSettings>
<EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
</EditFormSettings>

<BatchEditingSettings EditType="Cell"></BatchEditingSettings>

<PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
</MasterTableView>

<PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>

<FilterMenu EnableImageSprites="False"></FilterMenu>
        </telerik:RadGrid>
        <br />
        <asp:Label ID="Label26" runat="server" Text="自動發送設定："></asp:Label>
        <asp:Button ID="btnNeedSend" runat="server" OnClick="btnNeedSend_Click" Text="選取的不要送" />
        <asp:Button ID="btnDontSend" runat="server" Text="選取的要送" OnClick="btnDontSend_Click" />
        <br />
    <telerik:RadGrid ID="RadGrid2" runat="server" AutoGenerateColumns="False" CellSpacing="0" 
    Culture="zh-TW" GridLines="None" 
        onneeddatasource="RadGrid2_NeedDataSource" 
        AllowPaging="True" onitemcreated="RadGrid2_ItemCreated" AllowMultiRowSelection="True">
<ExportSettings>
<Pdf>
<PageHeader>
<LeftCell Text=""></LeftCell>

<MiddleCell Text=""></MiddleCell>

<RightCell Text=""></RightCell>
</PageHeader>

<PageFooter>
<LeftCell Text=""></LeftCell>

<MiddleCell Text=""></MiddleCell>

<RightCell Text=""></RightCell>
</PageFooter>
</Pdf>
</ExportSettings>

        <ClientSettings>
            <Selecting AllowRowSelect="True" />
        </ClientSettings>
<MasterTableView commanditemdisplay="None" nomasterrecordstext="目前沒有資料" EditMode="PopUp" 
            InsertItemPageIndexAction="ShowItemOnCurrentPage" DataKeyNames="AutoFTListID">
<CommandItemSettings ExportToPdfText="Export to PDF" addnewrecordtext="新增" 
        showrefreshbutton="False"></CommandItemSettings>

<RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
<HeaderStyle Width="20px"></HeaderStyle>
</RowIndicatorColumn>

<ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
<HeaderStyle Width="20px"></HeaderStyle>
</ExpandCollapseColumn>

    <Columns>
        <telerik:GridClientSelectColumn FilterControlAltText="Filter column column" 
            UniqueName="column">
        </telerik:GridClientSelectColumn>
        <telerik:GridBoundColumn DataField="SettingName" 
            FilterControlAltText="Filter SettingName column" HeaderText="設定名稱" 
            UniqueName="SettingName">
        </telerik:GridBoundColumn>
        <telerik:GridDropDownColumn DataField="JobCode" DataSourceID="dsJobCode" 
            FilterControlAltText="Filter MemberType column" HeaderText="職稱" 
            ListTextField="Name" ListValueField="Code" UniqueName="JobCode" 
            
            EditFormHeaderTextFormat="&lt;div style=&quot;text-align:right;&quot;&gt;{0}:&lt;/div&gt;">
        </telerik:GridDropDownColumn>
        <telerik:GridBoundColumn DataField="TemplateName" 
            FilterControlAltText="Filter isHospMember column" HeaderText="表單" 
            UniqueName="TemplateName">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="ShiftStr" 
            FilterControlAltText="Filter Des column" HeaderText="發送時間" 
            UniqueName="ShiftStr" 
            
            EditFormHeaderTextFormat="&lt;div style=&quot;text-align:right;&quot;&gt;{0}:&lt;/div&gt;" 
            Visible="False">
        </telerik:GridBoundColumn>
        <telerik:GridCheckBoxColumn DataField="IsSend" DataType="System.Boolean" FilterControlAltText="Filter IsSend column" HeaderText="在本輪訓發送" UniqueName="IsSend" Visible="False">
        </telerik:GridCheckBoxColumn>
        <telerik:GridTemplateColumn 
            FilterControlAltText="Filter EditSetting column" 
            UniqueName="EditSetting">
            <ItemTemplate>
                <asp:LinkButton ID="lbtnEditSetting" runat="server"  Text="細項設定"></asp:LinkButton>            
            </ItemTemplate>
        </telerik:GridTemplateColumn>
    </Columns>

<BatchEditingSettings EditType="Cell"></BatchEditingSettings>

<PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>      
<EditFormSettings EditFormType="AutoGenerated">

<EditColumn FilterControlAltText="Filter EditCommandColumn column" canceltext="取消" 
        edittext="儲存" inserttext="儲存" updatetext="儲存"></EditColumn>
    <PopUpSettings Modal="True" ScrollBars="Auto" Width="600px" />
</EditFormSettings>
</MasterTableView>

        <PagerStyle FirstPageToolTip="第一頁" LastPageToolTip="最末頁" NextPageToolTip="下一頁" 
            PagerTextFormat="跳至第: {4} &amp;nbsp;頁 &lt;strong&gt;{0}&lt;/strong&gt; / &lt;strong&gt;{1}&lt;/strong&gt;, 項目 &lt;strong&gt;{2}&lt;/strong&gt; - &lt;strong&gt;{3}&lt;/strong&gt; / &lt;strong&gt;{5}&lt;/strong&gt;." 
            PageSizeLabelText="每頁筆數:" PrevPagesToolTip="上一頁" PrevPageToolTip="上一頁" />

<FilterMenu EnableImageSprites="False"></FilterMenu>
</telerik:RadGrid>
    
    </div>    
    
    </td>
    </tr>
    </table>
    </div>


    <asp:Button ID="btnCancel" runat="server" onclick="btnCancel_Click" Text="離開" />


    <asp:ObjectDataSource ID="dsJobCode" runat="server" SelectMethod="GetCodeRefsStatic" 
        TypeName="KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService" 
        DataObjectTypeName="KMU.EduActivity.ApplicationLayer.DTO.V_CodeRefDto">
        <SelectParameters>
            <asp:Parameter DefaultValue="EduAct_JobSerial" Name="codetype" />
        </SelectParameters>
    </asp:ObjectDataSource>
    

    <telerik:RadWindowManager ID="RadWindowManager1" runat="server" Modal="True" 
        onclientclose="OnClientClose" ShowContentDuringLoad="False" 
        VisibleStatusbar="False">
        <Windows>
            <telerik:RadWindow ID="rwOpen" runat="server" Width="430px" Height="300px" 
                style="display:none; z-index: 1000000;" ReloadOnShow="True">
            </telerik:RadWindow>
            <telerik:RadWindow ID="rwOpenBig" runat="server" Modal="True" Width="650px" Height = "350px"
                style="display:none; z-index: 1000000;" ReloadOnShow="True">
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
        

    </form>
</body>
</html>
