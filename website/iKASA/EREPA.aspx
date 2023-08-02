<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EREPA.aspx.cs" Inherits="iKASA_EREPA" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<%@ Register src="../VsSelector.ascx" tagname="VsSelector" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

    <script src="//code.jquery.com/jquery-1.10.2.js"></script>

</head>
<body>
    <style>
body{
    font-family:微軟正黑體!important;
}
    .RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox table{margin:0;padding:0;border:0;background:0;display:-moz-inline-stack;display:inline-block;*display:inline;width:100%;border-collapse:collapse;vertical-align:top}.RadComboBox table{margin:0;padding:0;border:0;background:0;display:-moz-inline-stack;display:inline-block;*display:inline;width:100%;border-collapse:collapse;vertical-align:top}.RadComboBox table{margin:0;padding:0;border:0;background:0;display:-moz-inline-stack;display:inline-block;*display:inline;width:100%;border-collapse:collapse;vertical-align:top}.RadComboBox table{margin:0;padding:0;border:0;background:0;display:-moz-inline-stack;display:inline-block;*display:inline;width:100%;border-collapse:collapse;vertical-align:top}.RadComboBox table{margin:0;padding:0;border:0;background:0;display:-moz-inline-stack;display:inline-block;*display:inline;width:100%;border-collapse:collapse;vertical-align:top}.RadComboBox table{margin:0;padding:0;border:0;background:0;display:-moz-inline-stack;display:inline-block;*display:inline;width:100%;border-collapse:collapse;vertical-align:top}.RadComboBox table{margin:0;padding:0;border:0;background:0;display:-moz-inline-stack;display:inline-block;*display:inline;width:100%;border-collapse:collapse;vertical-align:top}.RadComboBox table{margin:0;padding:0;border:0;background:0;display:-moz-inline-stack;display:inline-block;*display:inline;width:100%;border-collapse:collapse;vertical-align:top}.RadComboBox table{margin:0;padding:0;border:0;background:0;display:-moz-inline-stack;display:inline-block;*display:inline;width:100%;border-collapse:collapse;vertical-align:top}.RadComboBox_Default .rcbReadOnly .rcbInputCellLeft{background-position:0 -88px}.RadComboBox_Default .rcbReadOnly .rcbInputCellLeft{background-position:0 -88px}.RadComboBox_Default .rcbReadOnly .rcbInputCellLeft{background-position:0 -88px}.RadComboBox_Default .rcbReadOnly .rcbInputCellLeft{background-position:0 -88px}.RadComboBox_Default .rcbReadOnly .rcbInputCellLeft{background-position:0 -88px}.RadComboBox_Default .rcbReadOnly .rcbInputCellLeft{background-position:0 -88px}.RadComboBox_Default .rcbReadOnly .rcbInputCellLeft{background-position:0 -88px}.RadComboBox_Default .rcbReadOnly .rcbInputCellLeft{background-position:0 -88px}.RadComboBox_Default .rcbReadOnly .rcbInputCellLeft{background-position:0 -88px}.RadComboBox table td.rcbInputCell{padding:0 4px 0 5px;border-width:0}.RadComboBox table td.rcbInputCell{padding:0 4px 0 5px;border-width:0}.RadComboBox table td.rcbInputCell{padding:0 4px 0 5px;border-width:0}.RadComboBox table td.rcbInputCell{padding:0 4px 0 5px;border-width:0}.RadComboBox table td.rcbInputCell{padding:0 4px 0 5px;border-width:0}.RadComboBox table td.rcbInputCell{padding:0 4px 0 5px;border-width:0}.RadComboBox table td.rcbInputCell{padding:0 4px 0 5px;border-width:0}.RadComboBox table td.rcbInputCell{padding:0 4px 0 5px;border-width:0}.RadComboBox table td.rcbInputCell{padding:0 4px 0 5px;border-width:0}.RadComboBox_Default .rcbInputCellLeft{background-position:0 0}.RadComboBox_Default .rcbInputCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbInputCell{width:100%;height:20px;_height:22px;line-height:20px;_line-height:22px;text-align:left;vertical-align:middle}.RadComboBox .rcbInputCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbInputCellLeft{background-position:0 0}.RadComboBox_Default .rcbInputCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbInputCell{width:100%;height:20px;_height:22px;line-height:20px;_line-height:22px;text-align:left;vertical-align:middle}.RadComboBox .rcbInputCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbInputCellLeft{background-position:0 0}.RadComboBox_Default .rcbInputCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbInputCell{width:100%;height:20px;_height:22px;line-height:20px;_line-height:22px;text-align:left;vertical-align:middle}.RadComboBox .rcbInputCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbInputCellLeft{background-position:0 0}.RadComboBox_Default .rcbInputCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbInputCell{width:100%;height:20px;_height:22px;line-height:20px;_line-height:22px;text-align:left;vertical-align:middle}.RadComboBox .rcbInputCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbInputCellLeft{background-position:0 0}.RadComboBox_Default .rcbInputCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbInputCell{width:100%;height:20px;_height:22px;line-height:20px;_line-height:22px;text-align:left;vertical-align:middle}.RadComboBox .rcbInputCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbInputCellLeft{background-position:0 0}.RadComboBox_Default .rcbInputCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbInputCell{width:100%;height:20px;_height:22px;line-height:20px;_line-height:22px;text-align:left;vertical-align:middle}.RadComboBox .rcbInputCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbInputCellLeft{background-position:0 0}.RadComboBox_Default .rcbInputCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbInputCell{width:100%;height:20px;_height:22px;line-height:20px;_line-height:22px;text-align:left;vertical-align:middle}.RadComboBox .rcbInputCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbInputCellLeft{background-position:0 0}.RadComboBox_Default .rcbInputCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbInputCell{width:100%;height:20px;_height:22px;line-height:20px;_line-height:22px;text-align:left;vertical-align:middle}.RadComboBox .rcbInputCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbInputCellLeft{background-position:0 0}.RadComboBox_Default .rcbInputCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbInputCell{width:100%;height:20px;_height:22px;line-height:20px;_line-height:22px;text-align:left;vertical-align:middle}.RadComboBox .rcbInputCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;-webkit-appearance:none}.RadComboBox input{height:auto;box-shadow:none;outline:0}.RadComboBox input{height:auto;box-shadow:none;outline:0}.RadComboBox input{height:auto;box-shadow:none;outline:0}.RadComboBox input{height:auto;box-shadow:none;outline:0}.RadComboBox input{height:auto;box-shadow:none;outline:0}.RadComboBox input{height:auto;box-shadow:none;outline:0}.RadComboBox input{height:auto;box-shadow:none;outline:0}.RadComboBox input{height:auto;box-shadow:none;outline:0}.RadComboBox input{height:auto;box-shadow:none;outline:0}.RadComboBox_Default .rcbReadOnly .rcbArrowCellRight{background-position:-162px -176px}.RadComboBox_Default .rcbReadOnly .rcbArrowCellRight{background-position:-162px -176px}.RadComboBox_Default .rcbReadOnly .rcbArrowCellRight{background-position:-162px -176px}.RadComboBox_Default .rcbReadOnly .rcbArrowCellRight{background-position:-162px -176px}.RadComboBox_Default .rcbReadOnly .rcbArrowCellRight{background-position:-162px -176px}.RadComboBox_Default .rcbReadOnly .rcbArrowCellRight{background-position:-162px -176px}.RadComboBox_Default .rcbReadOnly .rcbArrowCellRight{background-position:-162px -176px}.RadComboBox_Default .rcbReadOnly .rcbArrowCellRight{background-position:-162px -176px}.RadComboBox_Default .rcbReadOnly .rcbArrowCellRight{background-position:-162px -176px}.RadComboBox table td.rcbArrowCell{padding:0;border-width:0}.RadComboBox table td.rcbArrowCell{padding:0;border-width:0}.RadComboBox table td.rcbArrowCell{padding:0;border-width:0}.RadComboBox table td.rcbArrowCell{padding:0;border-width:0}.RadComboBox table td.rcbArrowCell{padding:0;border-width:0}.RadComboBox table td.rcbArrowCell{padding:0;border-width:0}.RadComboBox table td.rcbArrowCell{padding:0;border-width:0}.RadComboBox table td.rcbArrowCell{padding:0;border-width:0}.RadComboBox table td.rcbArrowCell{padding:0;border-width:0}.RadComboBox_Default .rcbArrowCellRight{background-position:-18px -176px}.RadComboBox_Default .rcbArrowCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbArrowCell{width:18px}.RadComboBox .rcbArrowCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbArrowCellRight{background-position:-18px -176px}.RadComboBox_Default .rcbArrowCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbArrowCell{width:18px}.RadComboBox .rcbArrowCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbArrowCellRight{background-position:-18px -176px}.RadComboBox_Default .rcbArrowCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbArrowCell{width:18px}.RadComboBox .rcbArrowCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbArrowCellRight{background-position:-18px -176px}.RadComboBox_Default .rcbArrowCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbArrowCell{width:18px}.RadComboBox .rcbArrowCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbArrowCellRight{background-position:-18px -176px}.RadComboBox_Default .rcbArrowCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbArrowCell{width:18px}.RadComboBox .rcbArrowCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbArrowCellRight{background-position:-18px -176px}.RadComboBox_Default .rcbArrowCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbArrowCell{width:18px}.RadComboBox .rcbArrowCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbArrowCellRight{background-position:-18px -176px}.RadComboBox_Default .rcbArrowCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbArrowCell{width:18px}.RadComboBox .rcbArrowCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbArrowCellRight{background-position:-18px -176px}.RadComboBox_Default .rcbArrowCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbArrowCell{width:18px}.RadComboBox .rcbArrowCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbArrowCellRight{background-position:-18px -176px}.RadComboBox_Default .rcbArrowCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbArrowCell{width:18px}.RadComboBox .rcbArrowCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox .rcbArrowCell a{width:18px;height:22px;position:relative;outline:0;font-size:0;line-height:1px;text-decoration:none;text-indent:9999px;display:block;overflow:hidden;cursor:default;*zoom:1}.RadComboBox .rcbArrowCell a{width:18px;height:22px;position:relative;outline:0;font-size:0;line-height:1px;text-decoration:none;text-indent:9999px;display:block;overflow:hidden;cursor:default;*zoom:1}.RadComboBox .rcbArrowCell a{width:18px;height:22px;position:relative;outline:0;font-size:0;line-height:1px;text-decoration:none;text-indent:9999px;display:block;overflow:hidden;cursor:default;*zoom:1}.RadComboBox .rcbArrowCell a{width:18px;height:22px;position:relative;outline:0;font-size:0;line-height:1px;text-decoration:none;text-indent:9999px;display:block;overflow:hidden;cursor:default;*zoom:1}.RadComboBox .rcbArrowCell a{width:18px;height:22px;position:relative;outline:0;font-size:0;line-height:1px;text-decoration:none;text-indent:9999px;display:block;overflow:hidden;cursor:default;*zoom:1}.RadComboBox .rcbArrowCell a{width:18px;height:22px;position:relative;outline:0;font-size:0;line-height:1px;text-decoration:none;text-indent:9999px;display:block;overflow:hidden;cursor:default;*zoom:1}.RadComboBox .rcbArrowCell a{width:18px;height:22px;position:relative;outline:0;font-size:0;line-height:1px;text-decoration:none;text-indent:9999px;display:block;overflow:hidden;cursor:default;*zoom:1}.RadComboBox .rcbArrowCell a{width:18px;height:22px;position:relative;outline:0;font-size:0;line-height:1px;text-decoration:none;text-indent:9999px;display:block;overflow:hidden;cursor:default;*zoom:1}.RadComboBox .rcbArrowCell a{width:18px;height:22px;position:relative;outline:0;font-size:0;line-height:1px;text-decoration:none;text-indent:9999px;display:block;overflow:hidden;cursor:default;*zoom:1}
        </style>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:Panel ID="panCaseInfo" runat="server" GroupingText="案例資訊">
            <table>
                <tr>
                    <td>日期：</td>
                    <td>
                        <asp:Label ID="lbInDate" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>科別：</td>
                    <td>
                        <asp:Label ID="lbDeptName" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>病歷號：</td>
                    <td>
                        <asp:Label ID="lbChartNo" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>檢傷級數：</td>
                    <td>
                        <asp:Label ID="lbDiseaseClass" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>診斷：</td>
                    <td>
                        <asp:Label ID="lbICDName" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>procedure：</td>
                    <td>
                        <asp:Label ID="lbProcedure" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="panStudent" runat="server">
            <asp:Label ID="Label1" runat="server" Text="選擇審核醫師："></asp:Label>
            <uc1:VsSelector ID="rcbTeacher" runat="server" />
            <asp:Button ID="btnStudentSubmit" runat="server" OnClick="btnStudentSubmit_Click" Text="確認送出" />
        </asp:Panel>
        <asp:Panel ID="PanTeacher" runat="server">
            <table border="1" cellpadding="0" cellspacing="0" class="MsoTableGrid" style="color: rgb(105, 105, 105); font-family: &quot;Helvetica Neue&quot;, &quot;Lucida Grande&quot;, &quot;Segoe UI&quot;, Arial, Helvetica, Verdana, sans-serif; font-size: 12.8px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: start; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial; border-width: medium; border-style: none; border-color: initial; width: 838px; border-collapse: collapse;" width="100%">
                <tr>
                    <td style="border-width: medium 1pt 1pt; border-style: none solid solid; border-top-color: initial; border-right-color: windowtext; width: 142.266px; border-bottom-color: windowtext; padding: 0cm 5.4pt; border-left-color: windowtext;" valign="top" width="18%">
                        <p align="right" class="MsoNormal" style="margin-bottom: 10px; line-height: 1.6em; text-align: right;">
                            <span style="font-size: 14pt; font-family: 標楷體; color: black;">信賴等級<span lang="EN-US"><p></p>
                            </span></span>
                        </p>
                        <p class="MsoNormal" style="margin-bottom: 10px; line-height: 1.6em;">
                            <span lang="EN-US" style="font-size: 14pt; font-family: 標楷體; color: black;">
                            <p>&nbsp;</p>
                            </span>
                        </p>
                        <p class="MsoNormal" style="margin-bottom: 10px; line-height: 1.6em;">
                            <span style="font-size: 14pt; font-family: 標楷體; color: black;">評估項目<span lang="EN-US"><p></p>
                            </span></span>
                        </p>
                    </td>
                    <td style="border-width: medium 1pt 1pt medium; border-style: none solid solid none; border-top-color: initial; border-right-color: windowtext; width: 108.141px; border-bottom-color: windowtext; padding: 0cm 5.4pt; border-left-color: initial;" width="14%">
                        <p align="center" class="MsoNormal" style="margin-bottom: 10px; line-height: 1.6em; text-align: center;">
                            <span style="font-size: 14pt; font-family: 標楷體; color: black;">不足以評估<span lang="EN-US">/</span>未評估<span lang="EN-US">(NA)<p></p>
                            </span></span>
                        </p>
                    </td>
                    <td style="border-width: medium 1pt 1pt medium; border-style: none solid solid none; border-top-color: initial; border-right-color: windowtext; width: 107.969px; border-bottom-color: windowtext; padding: 0cm 5.4pt; border-left-color: initial;" width="14%">
                        <p align="center" class="MsoNormal" style="margin-bottom: 10px; line-height: 1.6em; text-align: center;">
                            <span style="font-size: 14pt; font-family: 標楷體; color: black;">教師在旁逐步共同操作<span lang="EN-US"><p></p>
                            </span></span>
                        </p>
                    </td>
                    <td style="border-width: medium 1pt 1pt medium; border-style: none solid solid none; border-top-color: initial; border-right-color: windowtext; width: 108.141px; border-bottom-color: windowtext; padding: 0cm 5.4pt; border-left-color: initial;" width="14%">
                        <p align="center" class="MsoNormal" style="margin-bottom: 10px; line-height: 1.6em; text-align: center;">
                            <span style="font-size: 14pt; font-family: 標楷體; color: black;">教師在旁必要時協助<span lang="EN-US"><p></p>
                            </span></span>
                        </p>
                    </td>
                    <td style="border-width: medium 1pt 1pt medium; border-style: none solid solid none; border-top-color: initial; border-right-color: windowtext; width: 83.375px; border-bottom-color: windowtext; padding: 0cm 5.4pt; border-left-color: initial;" width="11%">
                        <p align="center" class="MsoNormal" style="margin-bottom: 10px; line-height: 1.6em; text-align: center;">
                            <span style="font-size: 14pt; font-family: 標楷體; color: black;">教師事後重點確認<span lang="EN-US"><p></p>
                            </span></span>
                        </p>
                    </td>
                    <td style="border-width: medium 1pt 1pt medium; border-style: none solid solid none; border-top-color: initial; border-right-color: windowtext; width: 95.75px; border-bottom-color: windowtext; padding: 0cm 5.4pt; border-left-color: initial;" width="13%">
                        <p align="center" class="MsoNormal" style="margin-bottom: 10px; line-height: 1.6em; text-align: center;">
                            <span style="font-size: 14pt; font-family: 標楷體; color: black;">必要時知會教師確認<span lang="EN-US"><p></p>
                            </span></span>
                        </p>
                    </td>
                    <td style="border-width: medium 1pt 1pt medium; border-style: none solid solid none; border-top-color: initial; border-right-color: windowtext; width: 81.2344px; border-bottom-color: windowtext; padding: 0cm 5.4pt; border-left-color: initial;" width="11%">
                        <p align="center" class="MsoNormal" style="margin-bottom: 10px; line-height: 1.6em; text-align: center;">
                            <span style="font-size: 14pt; font-family: 標楷體; color: black;">獨立</span><span style="font-size: 14pt; font-family: 標楷體;">執行</span></p>
                    </td>
                </tr>
                <tr>
                    <td style="border-width: medium 1pt 1pt; border-style: none solid solid; border-top-color: initial; border-right-color: windowtext; width: 142.266px; border-bottom-color: windowtext; padding: 0cm 5.4pt; border-left-color: windowtext;" width="18%"><span style="font-size: 14pt; font-family: 標楷體; color: black;"><span style="text-decoration: underline;">整體評量</span><span lang="EN-US"><p></p>
                        </span></span></td>
                    <td style="border-width: medium 1pt 1pt medium; border-style: none solid solid none; border-top-color: initial; border-right-color: windowtext; width: 108.141px; border-bottom-color: windowtext; padding: 0cm 5.4pt; text-align: center; border-left-color: initial;" width="14%"><span lang="EN-US" style="font-size: 14pt; font-family: 標楷體; color: black;">
                        <p></p>
                        </span></td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-right: none; border-image: initial; border-bottom: 1pt solid ; height: 25.9pt;">
                        <asp:RadioButton ID="rb81" runat="server" GroupName="rb09" />
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-right: none; border-image: initial; border-bottom: 1pt solid ; height: 25.9pt;">
                        <asp:RadioButton ID="rb82" runat="server" GroupName="rb09" />
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-right: none; border-image: initial; border-bottom: 1pt solid ; height: 25.9pt;">
                        <asp:RadioButton ID="rb83" runat="server" GroupName="rb09" />
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-right: none; border-image: initial; border-bottom: 1pt solid ; height: 25.9pt;">
                        <asp:RadioButton ID="rb84" runat="server" GroupName="rb09" />
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-right: none; border-image: initial; border-bottom: 1pt solid ; height: 25.9pt;">
                        <asp:RadioButton ID="rb85" runat="server" GroupName="rb09" />
                    </td>
                </tr>
                <tr>
                    <td colspan="7" style="border-width: medium 1pt 1pt; border-style: none solid solid; border-top-color: initial; border-right-color: windowtext; width: 821px; border-bottom-color: windowtext; padding: 0cm 5.4pt; border-left-color: windowtext;" width="18%"><font face="標楷體" size="5">回饋參考內容</font></td>
                </tr>
                <tr>
                    <td style="border-width: medium 1pt 1pt; border-style: none solid solid; border-top-color: initial; border-right-color: windowtext; width: 142.266px; border-bottom-color: windowtext; padding: 0cm 5.4pt; border-left-color: windowtext;" width="18%">
                        <p class="MsoNormal" style="margin-bottom: 10px; line-height: 1.6em; text-align: justify;">
                            <span lang="EN-US" style="font-size: 14pt; font-family: 標楷體; color: black;">(1)</span><span style="font-size: 14pt; font-family: 標楷體; color: black;">蒐集病史資料<span lang="EN-US"><p></p>
                            </span></span>
                        </p>
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-right: none; border-image: initial; border-bottom: 1pt solid ; height: 25.9pt;">
                        <asp:RadioButton ID="rb1" runat="server" GroupName="rb01" />
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-right: none; border-image: initial; border-bottom: 1pt solid ; height: 25.9pt;">
                        <asp:RadioButton ID="rb2" runat="server" GroupName="rb01" />
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-right: none; border-image: initial; border-bottom: 1pt solid ; height: 25.9pt;">
                        <asp:RadioButton ID="rb3" runat="server" GroupName="rb01" />
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-right: none; border-image: initial; border-bottom: 1pt solid ; height: 25.9pt;">
                        <asp:RadioButton ID="rb4" runat="server" GroupName="rb01" />
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-right: none; border-image: initial; border-bottom: 1pt solid ; height: 25.9pt;">
                        <asp:RadioButton ID="rb5" runat="server" GroupName="rb01" />
                    </td>
                    <td style=" border-image: initial; border-bottom: 1pt solid ; border-left-style: none; border-left-color: inherit; border-left-width: medium; border-right-style: none; border-right-color: inherit; border-right-width: medium; border-top-style: none; border-top-color: inherit; border-top-width: medium;">
                        <asp:RadioButton ID="rb6" runat="server" GroupName="rb01" />
                    </td>
                </tr>
                <tr>
                    <td style="border-width: medium 1pt 1pt; border-style: none solid solid; border-top-color: initial; border-right-color: windowtext; width: 142.266px; border-bottom-color: windowtext; padding: 0cm 5.4pt; border-left-color: windowtext;" width="18%">
                        <p class="MsoNormal" style="margin-bottom: 10px; line-height: 1.6em; text-align: justify;">
                            <span lang="EN-US" style="font-size: 14pt; font-family: 標楷體; color: black;">(2)</span><span style="font-size: 14pt; font-family: 標楷體; color: black;">身體診察<span lang="EN-US"><p></p>
                            </span></span>
                        </p>
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-right: none; border-image: initial; border-bottom: 1pt solid ; height: 25.9pt;">
                        <asp:RadioButton ID="rb11" runat="server" GroupName="rb02" />
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-right: none; border-image: initial; border-bottom: 1pt solid ; height: 25.9pt;">
                        <asp:RadioButton ID="rb12" runat="server" GroupName="rb02" />
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-right: none; border-image: initial; border-bottom: 1pt solid ; height: 25.9pt;">
                        <asp:RadioButton ID="rb13" runat="server" GroupName="rb02" />
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-right: none; border-image: initial; border-bottom: 1pt solid ; height: 25.9pt;">
                        <asp:RadioButton ID="rb14" runat="server" GroupName="rb02" />
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-right: none; border-image: initial; border-bottom: 1pt solid ; height: 25.9pt;">
                        <asp:RadioButton ID="rb15" runat="server" GroupName="rb02" />
                    </td>
                    <td style=" border-image: initial; border-bottom: 1pt solid ; border-left-style: none; border-left-color: inherit; border-left-width: medium; border-right-style: none; border-right-color: inherit; border-right-width: medium; border-top-style: none; border-top-color: inherit; border-top-width: medium;">
                        <asp:RadioButton ID="rb16" runat="server" GroupName="rb02" />
                    </td>
                </tr>
                <tr>
                    <td style="border-width: medium 1pt 1pt; border-style: none solid solid; border-top-color: initial; border-right-color: windowtext; width: 142.266px; border-bottom-color: windowtext; padding: 0cm 5.4pt; border-left-color: windowtext;" width="18%">
                        <p class="MsoNormal" style="margin-bottom: 10px; line-height: 1.6em; text-align: justify;">
                            <span lang="EN-US" style="font-size: 14pt; font-family: 標楷體; color: black;">(3)</span><span style="font-size: 14pt; font-family: 標楷體; color: black;">一般檢驗、檢查的安排與判讀<span lang="EN-US"><p></p>
                            </span></span>
                        </p>
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-right: none; border-image: initial; border-bottom: 1pt solid ; height: 25.9pt;">
                        <asp:RadioButton ID="rb21" runat="server" GroupName="rb03" />
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-right: none; border-image: initial; border-bottom: 1pt solid ; height: 25.9pt;">
                        <asp:RadioButton ID="rb22" runat="server" GroupName="rb03" />
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-right: none; border-image: initial; border-bottom: 1pt solid ; height: 25.9pt;">
                        <asp:RadioButton ID="rb23" runat="server" GroupName="rb03" />
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-right: none; border-image: initial; border-bottom: 1pt solid ; height: 25.9pt;">
                        <asp:RadioButton ID="rb24" runat="server" GroupName="rb03" />
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-right: none; border-image: initial; border-bottom: 1pt solid ; height: 25.9pt;">
                        <asp:RadioButton ID="rb25" runat="server" GroupName="rb03" />
                    </td>
                    <td style=" border-image: initial; border-bottom: 1pt solid ; border-left-style: none; border-left-color: inherit; border-left-width: medium; border-right-style: none; border-right-color: inherit; border-right-width: medium; border-top-style: none; border-top-color: inherit; border-top-width: medium;">
                        <asp:RadioButton ID="rb26" runat="server" GroupName="rb03" />
                    </td>
                </tr>
                <tr style="height: 35.9pt;">
                    <td style="border-width: medium 1pt 1pt; border-style: none solid solid; border-top-color: initial; height: 35.9pt; border-right-color: windowtext; width: 142.266px; border-bottom-color: windowtext; padding: 0cm 5.4pt; border-left-color: windowtext;" width="18%">
                        <p class="MsoNormal" style="margin-bottom: 10px; line-height: 1.6em; text-align: justify;">
                            <span lang="EN-US" style="font-size: 14pt; font-family: 標楷體; color: black;">(4)</span><span style="font-size: 14pt; font-family: 標楷體; color: black;">整合臨床所見排序臨床鑑別診斷<span lang="EN-US"><p></p>
                            </span></span>
                        </p>
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-right: none; border-image: initial; border-bottom: 1pt solid ; height: 25.9pt;">
                        <asp:RadioButton ID="rb31" runat="server" GroupName="rb04" />
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-right: none; border-image: initial; border-bottom: 1pt solid ; height: 25.9pt;">
                        <asp:RadioButton ID="rb32" runat="server" GroupName="rb04" />
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-right: none; border-image: initial; border-bottom: 1pt solid ; height: 25.9pt;">
                        <asp:RadioButton ID="rb33" runat="server" GroupName="rb04" />
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-right: none; border-image: initial; border-bottom: 1pt solid ; height: 25.9pt;">
                        <asp:RadioButton ID="rb34" runat="server" GroupName="rb04" />
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-right: none; border-image: initial; border-bottom: 1pt solid ; height: 25.9pt;">
                        <asp:RadioButton ID="rb35" runat="server" GroupName="rb04" />
                    </td>
                    <td style=" border-image: initial; border-bottom: 1pt solid ; border-left-style: none; border-left-color: inherit; border-left-width: medium; border-right-style: none; border-right-color: inherit; border-right-width: medium; border-top-style: none; border-top-color: inherit; border-top-width: medium;">
                        <asp:RadioButton ID="rb36" runat="server" GroupName="rb04" />
                    </td>
                </tr>
                <tr style="height: 35.9pt;">
                    <td style="border-width: medium 1pt 1pt; border-style: none solid solid; border-top-color: initial; height: 35.9pt; border-right-color: windowtext; width: 142.266px; border-bottom-color: windowtext; padding: 0cm 5.4pt; border-left-color: windowtext;" width="18%">
                        <p class="MsoNormal" style="margin-bottom: 10px; line-height: 1.6em; text-align: justify;">
                            <span lang="EN-US" style="font-size: 14pt; font-family: 標楷體; color: black;">(5)</span><span style="font-size: 14pt; font-family: 標楷體; color: black;">討論及建立醫囑<span lang="EN-US"><p></p>
                            </span></span>
                        </p>
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-right: none; border-image: initial; border-bottom: 1pt solid ; height: 25.9pt;">
                        <asp:RadioButton ID="rb41" runat="server" GroupName="rb05" />
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-right: none; border-image: initial; border-bottom: 1pt solid ; height: 25.9pt;">
                        <asp:RadioButton ID="rb42" runat="server" GroupName="rb05" />
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-right: none; border-image: initial; border-bottom: 1pt solid ; height: 25.9pt;">
                        <asp:RadioButton ID="rb43" runat="server" GroupName="rb05" />
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-right: none; border-image: initial; border-bottom: 1pt solid ; height: 25.9pt;">
                        <asp:RadioButton ID="rb44" runat="server" GroupName="rb05" />
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-right: none; border-image: initial; border-bottom: 1pt solid ; height: 25.9pt;">
                        <asp:RadioButton ID="rb45" runat="server" GroupName="rb05" />
                    </td>
                    <td style=" border-image: initial; border-bottom: 1pt solid ; border-left-style: none; border-left-color: inherit; border-left-width: medium; border-right-style: none; border-right-color: inherit; border-right-width: medium; border-top-style: none; border-top-color: inherit; border-top-width: medium;">
                        <asp:RadioButton ID="rb46" runat="server" GroupName="rb05" />
                    </td>
                </tr>
                <tr style="height: 2.4pt;">
                    <td style="border-width: medium 1pt 1pt; border-style: none solid solid; border-top-color: initial; height: 2.4pt; border-right-color: windowtext; width: 142.266px; border-bottom-color: windowtext; padding: 0cm 5.4pt; border-left-color: windowtext;" width="18%">
                        <p class="MsoNormal" style="margin-bottom: 10px; line-height: 1.6em; text-align: justify;">
                            <span lang="EN-US" style="font-size: 14pt; font-family: 標楷體; color: black;">(6)</span><span style="font-size: 14pt; font-family: 標楷體; color: black;">病歷寫作<span lang="EN-US"><p></p>
                            </span></span>
                        </p>
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-right: none; border-image: initial; border-bottom: 1pt solid ; height: 25.9pt;">
                        <asp:RadioButton ID="rb51" runat="server" GroupName="rb06" />
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-right: none; border-image: initial; border-bottom: 1pt solid ; height: 25.9pt;">
                        <asp:RadioButton ID="rb52" runat="server" GroupName="rb06" />
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-right: none; border-image: initial; border-bottom: 1pt solid ; height: 25.9pt;">
                        <asp:RadioButton ID="rb53" runat="server" GroupName="rb06" />
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-right: none; border-image: initial; border-bottom: 1pt solid ; height: 25.9pt;">
                        <asp:RadioButton ID="rb54" runat="server" GroupName="rb06" />
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-right: none; border-image: initial; border-bottom: 1pt solid ; height: 25.9pt;">
                        <asp:RadioButton ID="rb55" runat="server" GroupName="rb06" />
                    </td>
                    <td style=" border-image: initial; border-bottom: 1pt solid ; border-left-style: none; border-left-color: inherit; border-left-width: medium; border-right-style: none; border-right-color: inherit; border-right-width: medium; border-top-style: none; border-top-color: inherit; border-top-width: medium;">
                        <asp:RadioButton ID="rb56" runat="server" GroupName="rb06" />
                    </td>
                </tr>
                <tr style="height: 35.9pt;">
                    <td style="border-width: medium 1pt 1pt; border-style: none solid solid; border-top-color: initial; height: 35.9pt; border-right-color: windowtext; width: 142.266px; border-bottom-color: windowtext; padding: 0cm 5.4pt; border-left-color: windowtext;" width="18%">
                        <p class="MsoNormal" style="margin-bottom: 10px; line-height: 1.6em; text-align: justify;">
                            <span lang="EN-US" style="font-size: 14pt; font-family: 標楷體; color: black;">(7)</span><span style="font-size: 14pt; font-family: 標楷體; color: black;">解釋病情與治療計畫並取得知情同意<span lang="EN-US"><p></p>
                            </span></span>
                        </p>
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-right: none; border-image: initial; border-bottom: 1pt solid ; height: 25.9pt;">
                        <asp:RadioButton ID="rb61" runat="server" GroupName="rb07" />
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-right: none; border-image: initial; border-bottom: 1pt solid ; height: 25.9pt;">
                        <asp:RadioButton ID="rb62" runat="server" GroupName="rb07" />
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-right: none; border-image: initial; border-bottom: 1pt solid ; height: 25.9pt;">
                        <asp:RadioButton ID="rb63" runat="server" GroupName="rb07" />
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-right: none; border-image: initial; border-bottom: 1pt solid ; height: 25.9pt;">
                        <asp:RadioButton ID="rb64" runat="server" GroupName="rb07" />
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-right: none; border-image: initial; border-bottom: 1pt solid ; height: 25.9pt;">
                        <asp:RadioButton ID="rb65" runat="server" GroupName="rb07" />
                    </td>
                    <td style=" border-image: initial; border-bottom: 1pt solid ; border-left-style: none; border-left-color: inherit; border-left-width: medium; border-right-style: none; border-right-color: inherit; border-right-width: medium; border-top-style: none; border-top-color: inherit; border-top-width: medium;">
                        <asp:RadioButton ID="rb66" runat="server" GroupName="rb07" />
                    </td>
                </tr>
                <tr style="height: 9.35pt;">
                    <td style="border-width: medium 1pt 1pt; border-style: none solid solid; border-top-color: initial; height: 9.35pt; border-right-color: windowtext; width: 142.266px; border-bottom-color: windowtext; padding: 0cm 5.4pt; border-left-color: windowtext;" width="18%">
                        <p class="MsoNormal" style="margin-bottom: 10px; line-height: 1.6em; text-align: justify;">
                            <span lang="EN-US" style="font-size: 14pt; font-family: 標楷體; color: black;">(8)</span><span style="font-size: 14pt; font-family: 標楷體; color: black;">諮商衛教<span lang="EN-US"><p></p>
                            </span></span>
                        </p>
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-right: none; border-image: initial; border-bottom: 1pt solid ; height: 25.9pt;">
                        <asp:RadioButton ID="rb71" runat="server" GroupName="rb08" />
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-right: none; border-image: initial; border-bottom: 1pt solid ; height: 25.9pt;">
                        <asp:RadioButton ID="rb72" runat="server" GroupName="rb08" />
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-right: none; border-image: initial; border-bottom: 1pt solid ; height: 25.9pt;">
                        <asp:RadioButton ID="rb73" runat="server" GroupName="rb08" />
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-right: none; border-image: initial; border-bottom: 1pt solid ; height: 25.9pt;">
                        <asp:RadioButton ID="rb74" runat="server" GroupName="rb08" />
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-right: none; border-image: initial; border-bottom: 1pt solid ; height: 25.9pt;">
                        <asp:RadioButton ID="rb75" runat="server" GroupName="rb08" />
                    </td>
                    <td style=" border-image: initial; border-bottom: 1pt solid ; border-left-style: none; border-left-color: inherit; border-left-width: medium; border-right-style: none; border-right-color: inherit; border-right-width: medium; border-top-style: none; border-top-color: inherit; border-top-width: medium;">
                        <asp:RadioButton ID="rb76" runat="server" GroupName="rb08" />
                    </td>
                </tr>
                <tr>
                    <td colspan="7" style="border-width: medium 1pt 1pt; border-style: none solid solid; border-top-color: initial; border-right-color: windowtext; width: 821px; border-bottom-color: windowtext; padding: 0cm 5.4pt; border-left-color: windowtext;" valign="top" width="100%">
                        <p class="MsoNormal" style="margin-bottom: 10px; line-height: 1.6em;">
                            <span lang="EN-US" style="font-size: 14pt; font-family: 標楷體; color: black;">5.</span><span style="font-size: 14pt; font-family: 標楷體; color: black;">質性回饋</span><span style="font-size: 14pt; font-family: 標楷體;">&nbsp;</span></p>
                        <p class="MsoNormal" style="margin-bottom: 10px; line-height: 1.6em;">
                            <asp:TextBox ID="tbGood" runat="server" Height="123px" TextMode="MultiLine" Width="685px"></asp:TextBox>
                        </p>
                    </td>
                </tr>
            </table>
            <br />

            <asp:Button ID="btnTeacherSubmit" runat="server" Text="確認送出" OnClick="btnTeacherSubmit_Click" />
        </asp:Panel>
    </form>
</body>
</html>
