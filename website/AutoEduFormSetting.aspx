<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AutoEduFormSetting.aspx.cs" Inherits="AutoEduFormSetting" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<%@ Register src="TreeViewComboBox.ascx" tagname="TreeViewComboBox" tagprefix="uc1" %>

<%@ Register src="UserControls/EduTermSelect.ascx" tagname="EduTermSelect" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
.RadInput_Default{font:12px "segoe ui",arial,sans-serif}.RadInput{vertical-align:middle}.RadInput_Default{font:12px "segoe ui",arial,sans-serif}.RadInput{vertical-align:middle}.RadInput_Default{font:12px "segoe ui",arial,sans-serif}.RadInput{vertical-align:middle}.RadInput_Default{font:12px "segoe ui",arial,sans-serif}.RadInput{vertical-align:middle}.RadInput .riTextBox{height:17px}.RadInput .riTextBox{height:17px}.RadInput .riTextBox{height:17px}.RadInput .riTextBox{height:17px}
        .RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default .rcbReadOnly .rcbInputCellLeft{background-position:0 -88px}.RadComboBox_Default .rcbReadOnly .rcbInputCellLeft{background-position:0 -88px}.RadComboBox_Default .rcbReadOnly .rcbInputCellLeft{background-position:0 -88px}.RadComboBox_Default .rcbReadOnly .rcbInputCellLeft{background-position:0 -88px}.RadComboBox_Default .rcbReadOnly .rcbInputCellLeft{background-position:0 -88px}.RadComboBox_Default .rcbReadOnly .rcbInputCellLeft{background-position:0 -88px}.RadComboBox_Default .rcbReadOnly .rcbInputCellLeft{background-position:0 -88px}.RadComboBox_Default .rcbInputCellLeft{background-position:0 0}.RadComboBox_Default .rcbInputCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbInputCell{width:100%;height:20px;_height:22px;line-height:20px;_line-height:22px;text-align:left;vertical-align:middle}.RadComboBox .rcbInputCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbInputCellLeft{background-position:0 0}.RadComboBox_Default .rcbInputCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbInputCell{width:100%;height:20px;_height:22px;line-height:20px;_line-height:22px;text-align:left;vertical-align:middle}.RadComboBox .rcbInputCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbInputCellLeft{background-position:0 0}.RadComboBox_Default .rcbInputCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbInputCell{width:100%;height:20px;_height:22px;line-height:20px;_line-height:22px;text-align:left;vertical-align:middle}.RadComboBox .rcbInputCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbInputCellLeft{background-position:0 0}.RadComboBox_Default .rcbInputCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbInputCell{width:100%;height:20px;_height:22px;line-height:20px;_line-height:22px;text-align:left;vertical-align:middle}.RadComboBox .rcbInputCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbInputCellLeft{background-position:0 0}.RadComboBox_Default .rcbInputCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbInputCell{width:100%;height:20px;_height:22px;line-height:20px;_line-height:22px;text-align:left;vertical-align:middle}.RadComboBox .rcbInputCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbInputCellLeft{background-position:0 0}.RadComboBox_Default .rcbInputCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbInputCell{width:100%;height:20px;_height:22px;line-height:20px;_line-height:22px;text-align:left;vertical-align:middle}.RadComboBox .rcbInputCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbInputCellLeft{background-position:0 0}.RadComboBox_Default .rcbInputCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbInputCell{width:100%;height:20px;_height:22px;line-height:20px;_line-height:22px;text-align:left;vertical-align:middle}.RadComboBox .rcbInputCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbReadOnly .rcbArrowCellRight{background-position:-162px -176px}.RadComboBox_Default .rcbReadOnly .rcbArrowCellRight{background-position:-162px -176px}.RadComboBox_Default .rcbReadOnly .rcbArrowCellRight{background-position:-162px -176px}.RadComboBox_Default .rcbReadOnly .rcbArrowCellRight{background-position:-162px -176px}.RadComboBox_Default .rcbReadOnly .rcbArrowCellRight{background-position:-162px -176px}.RadComboBox_Default .rcbReadOnly .rcbArrowCellRight{background-position:-162px -176px}.RadComboBox_Default .rcbReadOnly .rcbArrowCellRight{background-position:-162px -176px}.RadComboBox_Default .rcbArrowCellRight{background-position:-18px -176px}.RadComboBox_Default .rcbArrowCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbArrowCell{width:18px}.RadComboBox .rcbArrowCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbArrowCellRight{background-position:-18px -176px}.RadComboBox_Default .rcbArrowCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbArrowCell{width:18px}.RadComboBox .rcbArrowCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbArrowCellRight{background-position:-18px -176px}.RadComboBox_Default .rcbArrowCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbArrowCell{width:18px}.RadComboBox .rcbArrowCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbArrowCellRight{background-position:-18px -176px}.RadComboBox_Default .rcbArrowCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbArrowCell{width:18px}.RadComboBox .rcbArrowCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbArrowCellRight{background-position:-18px -176px}.RadComboBox_Default .rcbArrowCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbArrowCell{width:18px}.RadComboBox .rcbArrowCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbArrowCellRight{background-position:-18px -176px}.RadComboBox_Default .rcbArrowCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbArrowCell{width:18px}.RadComboBox .rcbArrowCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbArrowCellRight{background-position:-18px -176px}.RadComboBox_Default .rcbArrowCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbArrowCell{width:18px}.RadComboBox .rcbArrowCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}
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
        <telerik:RadTreeView ID="RadTreeView1" Runat="server" Width="100%" AppendDataBoundItems="True" 
            DataFieldID="TEMPLATE_ID" DataFieldParentID="PARENT_TEMPLATE_ID" 
            DataTextField="TEMPLATE_NAME" DataValueField="TEMPLATE_ID" 
            onnodeclick="RadTreeView1_NodeClick" >
        </telerik:RadTreeView>
        <asp:HyperLink ID="btnPreview" runat="server" Target="_blank">預覽表單</asp:HyperLink>
    </div>

        </td>
    <td width="65%" valign="top">
        <asp:Panel ID="Panel5" runat="server" GroupingText="課程學年度">
            <asp:TextBox ID="tbEduYear" runat="server" Width="68px"></asp:TextBox>
            <asp:Label ID="Label28" runat="server" Text="請輸入學年度如103，若不指定學年度則留空白"></asp:Label>
        </asp:Panel>
        <asp:Panel ID="Panel7" runat="server" GroupingText="效期設定">
            <div>
            <asp:Label ID="Label29" runat="server" Text="生效日期："></asp:Label>
            <telerik:RadDatePicker ID="rdpSdate" Runat="server">
            </telerik:RadDatePicker>
                </div>
            <div>

                <asp:Label ID="Label30" runat="server" Text="停用日期："></asp:Label>
                <telerik:RadDatePicker ID="rdpEdate" Runat="server">
                </telerik:RadDatePicker>

            </div>
        </asp:Panel>
        <asp:Panel ID="Panel2" runat="server" GroupingText="課程職稱">
            <uc1:TreeViewComboBox ID="TreeViewComboBox1" runat="server" 
                AllowSelectParent="False" AutoPostBack="False" Enabled="True" 
                TreeDataFieldID="code" TreeDataFieldParentID="ParentCodeRefID" 
                TreeDataSourceID="dsJobCode" TreeDataTextField="Name" Width="200px" />
        </asp:Panel>
        <asp:Panel ID="Panel1" runat="server" GroupingText="設定名稱">
            <asp:TextBox ID="tbName" runat="server" Width="311px"></asp:TextBox>
        </asp:Panel>
        <asp:Panel ID="Panel3" runat="server" GroupingText="發送階層">
            <telerik:RadNumericTextBox ID="rntbSendFloor" Runat="server" MinValue="1" 
                 Width="40px">
                <NegativeStyle Resize="None" />
                <NumberFormat DecimalDigits="0" ZeroPattern="n" />
                <EmptyMessageStyle Resize="None" />
                <ReadOnlyStyle Resize="None" />
                <FocusedStyle Resize="None" />
                <DisabledStyle Resize="None" />
                <InvalidStyle Resize="None" />
                <HoveredStyle Resize="None" />
                <EnabledStyle Resize="None" />
            </telerik:RadNumericTextBox>            
        </asp:Panel>

        <asp:Panel ID="palExeDate" runat="server" GroupingText="發送日">
            <asp:Label ID="Label26" runat="server" Text="課程"></asp:Label>
            <asp:DropDownList ID="ddlShiftDayType" runat="server">
                <asp:ListItem Selected="True" Value="after">開始後</asp:ListItem>
                <asp:ListItem Value="before">結束前</asp:ListItem>
            </asp:DropDownList>
            <telerik:RadNumericTextBox ID="rntbShiftDays" Runat="server" MinValue="0" 
                Value="1" Width="40px">
                <NegativeStyle Resize="None" />
                <NumberFormat DecimalDigits="0" ZeroPattern="n" />
                <EmptyMessageStyle Resize="None" />
                <ReadOnlyStyle Resize="None" />
                <FocusedStyle Resize="None" />
                <DisabledStyle Resize="None" />
                <InvalidStyle Resize="None" />
                <HoveredStyle Resize="None" />
                <EnabledStyle Resize="None" />
            </telerik:RadNumericTextBox>
            <asp:Label ID="Label27" runat="server" Text="日發送"></asp:Label>
        </asp:Panel>
        <asp:Panel ID="palTarget" runat="server" GroupingText="發送對象">
        <asp:Panel ID="palSettingFix" runat="server">
            <table>
                <tr>
                    <td>
            <asp:Label ID="Label23" runat="server" Text="發送教師類型："></asp:Label>
            <asp:DropDownList ID="ddlTeacherType" runat="server">
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
            <asp:CheckBox ID="cbEach" runat="server" Checked="True" Text="每位學員一份" 
                Visible="False" />

                    </td>
                </tr>
            </table>
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
                onitemdatabound="RadGrid1_ItemDataBound" AllowMultiRowSelection="True" 
                onitemcreated="RadGrid1_ItemCreated" OnDeleteCommand="RadGrid1_DeleteCommand">
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
                        <telerik:GridTemplateColumn DataField="ExpireDays" 
                            FilterControlAltText="Filter ExpireDate column" HeaderText="" 
                            UniqueName="ExpireDays">
                   <ItemTemplate>
            <asp:DropDownList ID="ddlExpireDayType" runat="server">
                <asp:ListItem Value="AfterSend">發送後</asp:ListItem>
                <asp:ListItem Value="after">課程開始後</asp:ListItem>
                <asp:ListItem Value="before">課程結束前</asp:ListItem>
                <asp:ListItem Value="AfterCourse">課程結束後</asp:ListItem>
            </asp:DropDownList>
                  <%-- <asp:Label ID="lbexpiredays" runat="server" Text="發送後"></asp:Label>--%>
                   <telerik:RadNumericTextBox ID="rntbExpireDays" Width="45px" runat="server" NumberFormat-DecimalDigits="0" MinValue="0" DbValue='<%# Bind("ExpireDays") %>'>
                   </telerik:RadNumericTextBox>
                   <asp:Label ID="Label1" runat="server" Text="天逾期"></asp:Label>
                    </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn DataField="UDTarget" 
                            FilterControlAltText="Filter ExpireDate column" HeaderText="指定發送對象員編" 
                            UniqueName="UDTarget" Visible="False">
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

        <asp:Panel ID="PanSendMonth" runat="server" GroupingText="發送月份(發送月份依據為課程開始時間之月份)">
            <div>
                <asp:Label ID="Label5" runat="server" Text="月份："></asp:Label>
                <telerik:RadComboBox ID="rcbMonth" Runat="server" Filter="Contains" Culture="zh-TW">
                    <Items>
                        <telerik:RadComboBoxItem runat="server" Text="1" Value="1" />
                        <telerik:RadComboBoxItem runat="server" Text="2" Value="2" />
                        <telerik:RadComboBoxItem runat="server" Text="3" Value="3" />
                        <telerik:RadComboBoxItem runat="server" Text="4" Value="4" />
                        <telerik:RadComboBoxItem runat="server" Text="5" Value="5" />
                        <telerik:RadComboBoxItem runat="server" Text="6" Value="6" />
                        <telerik:RadComboBoxItem runat="server" Text="7" Value="7" />
                        <telerik:RadComboBoxItem runat="server" Text="8" Value="8" />
                        <telerik:RadComboBoxItem runat="server" Text="9" Value="9" />
                        <telerik:RadComboBoxItem runat="server" Text="10" Value="10" />
                        <telerik:RadComboBoxItem runat="server" Text="11" Value="11" />
                        <telerik:RadComboBoxItem runat="server" Text="12" Value="12" />
                    </Items>
                </telerik:RadComboBox>
                &nbsp;
                <asp:ImageButton ID="btnAddSendMonth" runat="server" ImageUrl="~/Images/add.jpg" ToolTip="新增" OnClick="btnAddSendMonth_Click" />
            </div>
            <div>
                <telerik:RadGrid ID="rgSendMonth" runat="server" AllowMultiRowSelection="True" AutoGenerateColumns="False" AutoGenerateDeleteColumn="True" CellSpacing="0" Culture="zh-TW" GridLines="None" OnDeleteCommand="rgSendMonth_DeleteCommand">
                    <ClientSettings AllowDragToGroup="True">
                        <Selecting AllowRowSelect="True" />
                    </ClientSettings>
                    <MasterTableView DataKeyNames="ExceptKey">
                        <Columns>
                            <telerik:GridClientSelectColumn FilterControlAltText="Filter column column" UniqueName="column">
                            </telerik:GridClientSelectColumn>
                            <telerik:GridBoundColumn DataField="ExceptKey" FilterControlAltText="Filter SettingName column" HeaderText="發送月份" ReadOnly="True" UniqueName="ExceptKey">
                            </telerik:GridBoundColumn>
                        </Columns>
                        <EditFormSettings>
                            <EditColumn canceltext="取消" edittext="儲存" FilterControlAltText="Filter EditCommandColumn column" inserttext="儲存" updatetext="儲存">
                            </EditColumn>
                        </EditFormSettings>
                    </MasterTableView>
                </telerik:RadGrid>
            </div>
        </asp:Panel>


        <asp:Panel ID="ExcepDept" runat="server" GroupingText="不發送部門">
            <div>
                <asp:Label ID="Label9" runat="server" Text="部門："></asp:Label>
                <telerik:RadComboBox ID="ddlUnit" Runat="server" Filter="Contains">
                </telerik:RadComboBox>
                &nbsp;
                <asp:ImageButton ID="btnAddExceptDept" runat="server" ImageUrl="~/Images/add.jpg" ToolTip="新增" OnClick="btnAddExceptDept_Click" />
            </div>
            <div>
                <telerik:RadGrid ID="RadGrid2" runat="server" AllowMultiRowSelection="True" AutoGenerateColumns="False" AutoGenerateDeleteColumn="True" CellSpacing="0" Culture="zh-TW" GridLines="None" OnDeleteCommand="RadGrid2_DeleteCommand">
                    <ClientSettings AllowDragToGroup="True">
                        <Selecting AllowRowSelect="True" />
                    </ClientSettings>
                    <MasterTableView DataKeyNames="Code">
                        <Columns>
                            <telerik:GridClientSelectColumn FilterControlAltText="Filter column column" UniqueName="column">
                            </telerik:GridClientSelectColumn>
                            <telerik:GridBoundColumn DataField="Code" FilterControlAltText="Filter SettingName column" HeaderText="代碼" ReadOnly="True" UniqueName="Code">
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
            </div>
        </asp:Panel>
        <asp:Panel ID="SendDept" runat="server" GroupingText="特定發送部門">
            <div>
                <asp:Label ID="Label3" runat="server" Text="部門："></asp:Label>
                <telerik:RadComboBox ID="ddlSendUnit" Runat="server" Filter="Contains">
                </telerik:RadComboBox>
                &nbsp;
                <asp:ImageButton ID="btnAddSendDept" runat="server" ImageUrl="~/Images/add.jpg" ToolTip="新增" OnClick="btnAddSendDept_Click" />
            </div>
            <div>
                <telerik:RadGrid ID="RadGrid3" runat="server" AllowMultiRowSelection="True" AutoGenerateColumns="False" AutoGenerateDeleteColumn="True" CellSpacing="0" Culture="zh-TW" GridLines="None" OnDeleteCommand="RadGrid3_DeleteCommand">
                    <ClientSettings AllowDragToGroup="True">
                        <Selecting AllowRowSelect="True" />
                    </ClientSettings>
                    <MasterTableView DataKeyNames="Code">
                        <Columns>
                            <telerik:GridClientSelectColumn FilterControlAltText="Filter column column" UniqueName="column">
                            </telerik:GridClientSelectColumn>
                            <telerik:GridBoundColumn DataField="Code" FilterControlAltText="Filter SettingName column" HeaderText="代碼" ReadOnly="True" UniqueName="Code">
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
            </div>
        </asp:Panel>
<asp:Panel ID="Panel4" runat="server" GroupingText="指定發送課程(若指定課程後則本設定將會忽略其他條件發送至清單中的課程)">
            <div>
                <asp:Label ID="Label2" runat="server" Text="課程："></asp:Label>
                &nbsp;<uc2:EduTermSelect ID="EduTermSelect1" runat="server" />
&nbsp;<asp:ImageButton ID="btnAddSendTerm" runat="server" ImageUrl="~/Images/add.jpg" ToolTip="新增" OnClick="btnAddSendTerm_Click" />
            </div>
            <div>
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
            </div>
        </asp:Panel>

<asp:Panel ID="Panel6" runat="server" GroupingText="不發送課程">
            <div>
                <asp:Label ID="Label4" runat="server" Text="課程："></asp:Label>
                &nbsp;<uc2:EduTermSelect ID="EduTermSelect2" runat="server" />
&nbsp;<asp:ImageButton ID="btnAddNoSendTerm" runat="server" ImageUrl="~/Images/add.jpg" ToolTip="新增" OnClick="btnAddNoSendTerm_Click" />
            </div>
            <div>
                <telerik:RadGrid ID="rgNoSendTerm" runat="server" AllowMultiRowSelection="True" AutoGenerateColumns="False" AutoGenerateDeleteColumn="True" CellSpacing="0" Culture="zh-TW" GridLines="None" OnDeleteCommand="rgNoSendTerm_DeleteCommand">
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
            </div>
        </asp:Panel>


        <asp:Button ID="btnSubmit" runat="server" onclick="btnSubmit_Click" Text="儲存" />
        <asp:Button ID="btnSaveAs" runat="server" OnClick="btnSaveAs_Click" Text="另存設定" />
        </td>
    </tr>
    <tr>
    <td colspan="2">
    <div>
        &nbsp;
        </div>    
    
    </td>
    </tr>
    </table>

    <asp:ObjectDataSource ID="dsJobCode" runat="server" SelectMethod="GetCodeRefsStatic" 
        TypeName="KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService" 
        DataObjectTypeName="KMU.EduActivity.ApplicationLayer.DTO.V_CodeRefDto" 
        onselected="dsJobCode_Selected">
        <SelectParameters>
            <asp:Parameter DefaultValue="EduAct_JobSerial" Name="codetype" />
        </SelectParameters>
    </asp:ObjectDataSource>
    
    </div>


    </form>
</body>
</html>
