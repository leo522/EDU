<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ERDOPS.aspx.cs" Inherits="iKASA_ERDOPS" %>

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
            <br />
            <table border="1"  style="border: none; " >
                <tr >
                    <td rowspan="2" style=" border-width: 1.5pt 1pt 1pt 1.5pt; border-style: solid;  background: rgb(230, 230, 230); height: 8.65pt;">
                        <p align="center"  style=" font-size: 12pt;  text-align: center; ">
                            <span style="font-size: 14pt; font-family: 標楷體;">評估項目</span></p>
                    </td>
                    <td colspan="3" style=" border-top: 1.5pt solid ; border-left: none; width: 3cm; border-bottom: 1pt solid ; border-right: 1pt solid ; background: white; height: 8.65pt;">
                        <p align="center"  style=" font-size: 12pt;  text-align: center; ">
                            <span style="font-size: 13pt; font-family: 標楷體;">未達預期標準</span></p>
                    </td>
                    <td colspan="3" style=" border-top: 1.5pt solid ; border-bottom: 1pt solid ; border-right: 1pt solid ; background: white; height: 8.65pt; border-left-style: none; border-left-color: inherit; border-left-width: medium;" valign="top">
                        <p align="center"  style=" font-size: 12pt;  text-align: center; ">
                            <span style="font-size: 13pt; font-family: 標楷體;">符合預期標準</span></p>
                    </td>
                    <td colspan="3" style=" border-top: 1.5pt solid ; border-left: none; width: 3cm; border-bottom: 1pt solid ; border-right: 1pt solid ; background: white; height: 8.65pt;" valign="top">
                        <p align="center"  style=" font-size: 12pt;  text-align: center; ">
                            <span style="font-size: 13pt; font-family: 標楷體;">高於預期標準</span></p>
                    </td>
                    <td rowspan="2" style=" border-top: 1.5pt solid ; border-left: none; width: 1cm; border-bottom: 1pt solid ; border-right: 1.5pt solid ; background: rgb(230, 230, 230); height: 8.65pt;">
                        <p align="center"  style=" font-size: 12pt;  text-align: center; ">
                            <span style="font-size: 13pt; font-family: 標楷體;">未</span></p>
                        <p align="center"  style=" font-size: 12pt;  text-align: center; ">
                            <span style="font-size: 13pt; font-family: 標楷體;">評</span></p>
                        <p align="center"  style=" font-size: 12pt;  text-align: center; ">
                            <span style="font-size: 13pt; font-family: 標楷體;">估</span></p>
                    </td>
                </tr>
                <tr style="height: 4.75pt;">
                    <td style=" border-top: none; border-left: none; width: 1cm; border-bottom: 1pt solid ; border-right: 1pt solid ; background: rgb(230, 230, 230); height: 4.75pt;">
                        <p align="center"  style=" font-size: 12pt;  text-align: center; ">
                            <span lang="EN-US" style="font-size: 13pt;">1</span></p>
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-bottom: 1pt solid ; border-right: 1pt solid ; background: rgb(230, 230, 230); height: 4.75pt;">
                        <p align="center"  style=" font-size: 12pt;  text-align: center; ">
                            <span lang="EN-US" style="font-size: 13pt;">2</span></p>
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-bottom: 1pt solid ; border-right: 1pt solid ; background: rgb(230, 230, 230); height: 4.75pt;">
                        <p align="center"  style=" font-size: 12pt;  text-align: center; ">
                            <span lang="EN-US" style="font-size: 13pt;">3</span></p>
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-bottom: 1pt solid ; border-right: 1pt solid ; background: rgb(230, 230, 230); height: 4.75pt;">
                        <p align="center"  style=" font-size: 12pt;  text-align: center; ">
                            <span lang="EN-US" style="font-size: 13pt;">4</span></p>
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-bottom: 1pt solid ; border-right: 1pt solid ; background: rgb(230, 230, 230); height: 4.75pt;">
                        <p align="center"  style=" font-size: 12pt;  text-align: center; ">
                            <span lang="EN-US" style="font-size: 13pt;">5</span></p>
                    </td>
                    <td  style=" border-bottom: 1pt solid ; border-right: 1pt solid ; background: rgb(230, 230, 230); border-left-style: none; border-left-color: inherit; border-left-width: medium; border-top-style: none; border-top-color: inherit; border-top-width: medium;">
                        <p align="center"  style=" font-size: 12pt;  text-align: center; ">
                            <span lang="EN-US" style="font-size: 13pt;">6</span></p>
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-bottom: 1pt solid ; border-right: 1pt solid ; background: rgb(230, 230, 230); height: 4.75pt;">
                        <p align="center"  style=" font-size: 12pt;  text-align: center; ">
                            <span lang="EN-US" style="font-size: 13pt;">7</span></p>
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-bottom: 1pt solid ; border-right: 1pt solid ; background: rgb(230, 230, 230); height: 4.75pt;">
                        <p align="center"  style=" font-size: 12pt;  text-align: center; ">
                            <span lang="EN-US" style="font-size: 13pt;">8</span></p>
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-bottom: 1pt solid ; border-right: 1pt solid ; background: rgb(230, 230, 230); height: 4.75pt;">
                        <p align="center"  style=" font-size: 12pt;  text-align: center; ">
                            <span lang="EN-US" style="font-size: 13pt;">9</span></p>
                    </td>
                </tr>
                <tr style="height: 25.9pt;">
                    <td style=" border-top: none; border-left: 1.5pt solid ; border-bottom: 1pt solid ; border-right: none; height: 25.9pt;">
                        <p  style=" font-size: 12pt;  text-align: justify; ">
                            <span lang="EN-US" style="font-size: 14pt; font-family: 標楷體;">1.</span><span style="font-size: 14pt; font-family: 標楷體;">對該臨床技能之適應症、相關解剖結構的了解及步驟之熟練度<span lang="EN-US">…………</span></span></p>
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
                    <td  style=" border-image: initial; border-bottom: 1pt solid ; border-left-style: none; border-left-color: inherit; border-left-width: medium; border-right-style: none; border-right-color: inherit; border-right-width: medium; border-top-style: none; border-top-color: inherit; border-top-width: medium;">
                        <asp:RadioButton ID="rb6" runat="server" GroupName="rb01" />
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-right: none; border-image: initial; border-bottom: 1pt solid ; height: 25.9pt;">
                        <asp:RadioButton ID="rb7" runat="server" GroupName="rb01" />
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-right: none; border-image: initial; border-bottom: 1pt solid ; height: 25.9pt;">
                        <asp:RadioButton ID="rb8" runat="server" GroupName="rb01" />
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-right: none; border-image: initial; border-bottom: 1pt solid ; height: 25.9pt;">
                        <asp:RadioButton ID="rb9" runat="server" GroupName="rb01" />
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-bottom: 1pt solid ; border-right: 1.5pt solid ; height: 25.9pt;">
                        <asp:RadioButton ID="rb10" runat="server" GroupName="rb01" />
                    </td>
                </tr>
                <tr style="height: 3pt;">
                    <td style=" border-top: none; border-left: 1.5pt solid ; border-bottom: 1pt solid ; border-right: none; height: 3pt;">
                        <p  style=" font-size: 12pt;  text-align: justify; ">
                            <span lang="EN-US" style="font-size: 14pt; font-family: 標楷體;">2.</span><span style="font-size: 14pt; font-family: 標楷體;">詳細告知病人並取得同意書<span lang="EN-US">………</span></span></p>
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
                    <td  style=" border-image: initial; border-bottom: 1pt solid ; border-left-style: none; border-left-color: inherit; border-left-width: medium; border-right-style: none; border-right-color: inherit; border-right-width: medium; border-top-style: none; border-top-color: inherit; border-top-width: medium;">
                        <asp:RadioButton ID="rb16" runat="server" GroupName="rb02" />
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-right: none; border-image: initial; border-bottom: 1pt solid ; height: 25.9pt;">
                        <asp:RadioButton ID="rb17" runat="server" GroupName="rb02" />
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-right: none; border-image: initial; border-bottom: 1pt solid ; height: 25.9pt;">
                        <asp:RadioButton ID="rb18" runat="server" GroupName="rb02" />
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-right: none; border-image: initial; border-bottom: 1pt solid ; height: 25.9pt;">
                        <asp:RadioButton ID="rb19" runat="server" GroupName="rb02" />
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-bottom: 1pt solid ; border-right: 1.5pt solid ; height: 25.9pt;">
                        <asp:RadioButton ID="rb20" runat="server" GroupName="rb02" />
                    </td>
                </tr>
                <tr style="height: 3pt;">
                    <td style=" border-top: none; border-left: 1.5pt solid ; border-bottom: 1pt solid ; border-right: none; height: 3pt;">
                        <p  style=" font-size: 12pt;  text-align: justify; ">
                            <span lang="EN-US" style="font-size: 14pt; font-family: 標楷體;">3.</span><span style="font-size: 14pt; font-family: 標楷體;">執行適當的術前準備工作<span lang="EN-US">…………</span></span></p>
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
                    <td  style=" border-image: initial; border-bottom: 1pt solid ; border-left-style: none; border-left-color: inherit; border-left-width: medium; border-right-style: none; border-right-color: inherit; border-right-width: medium; border-top-style: none; border-top-color: inherit; border-top-width: medium;">
                        <asp:RadioButton ID="rb26" runat="server" GroupName="rb03" />
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-right: none; border-image: initial; border-bottom: 1pt solid ; height: 25.9pt;">
                        <asp:RadioButton ID="rb27" runat="server" GroupName="rb03" />
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-right: none; border-image: initial; border-bottom: 1pt solid ; height: 25.9pt;">
                        <asp:RadioButton ID="rb28" runat="server" GroupName="rb03" />
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-right: none; border-image: initial; border-bottom: 1pt solid ; height: 25.9pt;">
                        <asp:RadioButton ID="rb29" runat="server" GroupName="rb03" />
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-bottom: 1pt solid ; border-right: 1.5pt solid ; height: 25.9pt;">
                        <asp:RadioButton ID="rb30" runat="server" GroupName="rb03" />
                    </td>
                </tr>
                <tr style="height: 13.8pt;">
                    <td style=" border-top: none; border-left: 1.5pt solid ; border-bottom: 1pt solid ; border-right: none; height: 13.8pt;">
                        <p  style=" font-size: 12pt;  text-align: justify; ">
                            <span lang="EN-US" style="font-size: 14pt; font-family: 標楷體;">4.</span><span style="font-size: 14pt; font-family: 標楷體;">適當止痛及安全的鎮靜<span lang="EN-US">……………</span></span></p>
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
                    <td  style=" border-image: initial; border-bottom: 1pt solid ; border-left-style: none; border-left-color: inherit; border-left-width: medium; border-right-style: none; border-right-color: inherit; border-right-width: medium; border-top-style: none; border-top-color: inherit; border-top-width: medium;">
                        <asp:RadioButton ID="rb36" runat="server" GroupName="rb04" />
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-right: none; border-image: initial; border-bottom: 1pt solid ; height: 25.9pt;">
                        <asp:RadioButton ID="rb37" runat="server" GroupName="rb04" />
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-right: none; border-image: initial; border-bottom: 1pt solid ; height: 25.9pt;">
                        <asp:RadioButton ID="rb38" runat="server" GroupName="rb04" />
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-right: none; border-image: initial; border-bottom: 1pt solid ; height: 25.9pt;">
                        <asp:RadioButton ID="rb39" runat="server" GroupName="rb04" />
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-bottom: 1pt solid ; border-right: 1.5pt solid ; height: 25.9pt;">
                        <asp:RadioButton ID="rb40" runat="server" GroupName="rb04" />
                    </td>
                </tr>
                <tr>
                    <td style=" border-left: 1.5pt solid ; border-bottom: 1pt solid ; border-right-style: none; border-right-color: inherit; border-right-width: medium; border-top-style: none; border-top-color: inherit; border-top-width: medium;">
                        <p  style=" font-size: 12pt;  text-align: justify; ">
                            <span lang="EN-US" style="font-size: 14pt; font-family: 標楷體;">5.</span><span style="font-size: 14pt; font-family: 標楷體;">執行臨床技能之技術能力<span lang="EN-US">…………</span></span></p>
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
                    <td  style=" border-image: initial; border-bottom: 1pt solid ; border-left-style: none; border-left-color: inherit; border-left-width: medium; border-right-style: none; border-right-color: inherit; border-right-width: medium; border-top-style: none; border-top-color: inherit; border-top-width: medium;">
                        <asp:RadioButton ID="rb46" runat="server" GroupName="rb05" />
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-right: none; border-image: initial; border-bottom: 1pt solid ; height: 25.9pt;">
                        <asp:RadioButton ID="rb47" runat="server" GroupName="rb05" />
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-right: none; border-image: initial; border-bottom: 1pt solid ; height: 25.9pt;">
                        <asp:RadioButton ID="rb48" runat="server" GroupName="rb05" />
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-right: none; border-image: initial; border-bottom: 1pt solid ; height: 25.9pt;">
                        <asp:RadioButton ID="rb49" runat="server" GroupName="rb05" />
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-bottom: 1pt solid ; border-right: 1.5pt solid ; height: 25.9pt;">
                        <asp:RadioButton ID="rb50" runat="server" GroupName="rb05" />
                    </td>
                </tr>
                <tr style="height: 16.2pt;">
                    <td style=" border-top: none; border-left: 1.5pt solid ; border-bottom: 1pt solid ; border-right: none; height: 16.2pt;">
                        <p  style=" font-size: 12pt;  text-align: justify; ">
                            <span lang="EN-US" style="font-size: 14pt; font-family: 標楷體;">6.</span><span style="font-size: 14pt; font-family: 標楷體;">無菌技術<span lang="EN-US">……………………………</span></span></p>
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
                    <td  style=" border-image: initial; border-bottom: 1pt solid ; border-left-style: none; border-left-color: inherit; border-left-width: medium; border-right-style: none; border-right-color: inherit; border-right-width: medium; border-top-style: none; border-top-color: inherit; border-top-width: medium;">
                        <asp:RadioButton ID="rb56" runat="server" GroupName="rb06" />
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-right: none; border-image: initial; border-bottom: 1pt solid ; height: 25.9pt;">
                        <asp:RadioButton ID="rb57" runat="server" GroupName="rb06" />
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-right: none; border-image: initial; border-bottom: 1pt solid ; height: 25.9pt;">
                        <asp:RadioButton ID="rb58" runat="server" GroupName="rb06" />
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-right: none; border-image: initial; border-bottom: 1pt solid ; height: 25.9pt;">
                        <asp:RadioButton ID="rb59" runat="server" GroupName="rb06" />
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-bottom: 1pt solid ; border-right: 1.5pt solid ; height: 25.9pt;">
                        <asp:RadioButton ID="rb60" runat="server" GroupName="rb06" />
                    </td>
                </tr>
                <tr style="height: 3pt;">
                    <td style=" border-top: none; border-left: 1.5pt solid ; border-bottom: 1pt solid ; border-right: none; height: 3pt;">
                        <p  style=" font-size: 12pt;  text-align: justify; ">
                            <span lang="EN-US" style="font-size: 14pt; font-family: 標楷體;">7.</span><span style="font-size: 14pt; font-family: 標楷體;">視需要尋求協助<span lang="EN-US">……………………</span></span></p>
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
                    <td  style=" border-image: initial; border-bottom: 1pt solid ; border-left-style: none; border-left-color: inherit; border-left-width: medium; border-right-style: none; border-right-color: inherit; border-right-width: medium; border-top-style: none; border-top-color: inherit; border-top-width: medium;">
                        <asp:RadioButton ID="rb66" runat="server" GroupName="rb07" />
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-right: none; border-image: initial; border-bottom: 1pt solid ; height: 25.9pt;">
                        <asp:RadioButton ID="rb67" runat="server" GroupName="rb07" />
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-right: none; border-image: initial; border-bottom: 1pt solid ; height: 25.9pt;">
                        <asp:RadioButton ID="rb68" runat="server" GroupName="rb07" />
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-right: none; border-image: initial; border-bottom: 1pt solid ; height: 25.9pt;">
                        <asp:RadioButton ID="rb69" runat="server" GroupName="rb07" />
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-bottom: 1pt solid ; border-right: 1.5pt solid ; height: 25.9pt;">
                        <asp:RadioButton ID="rb70" runat="server" GroupName="rb07" />
                    </td>
                </tr>
                <tr style="height: 6.1pt;">
                    <td style=" border-top: none; border-left: 1.5pt solid ; border-bottom: 1pt solid ; border-right: none; height: 6.1pt;">
                        <p  style=" font-size: 12pt;  text-align: justify; ">
                            <span lang="EN-US" style="font-size: 14pt; font-family: 標楷體;">8.</span><span style="font-size: 14pt; font-family: 標楷體;">術後之相關處置<span lang="EN-US">……………………</span></span></p>
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
                    <td  style=" border-image: initial; border-bottom: 1pt solid ; border-left-style: none; border-left-color: inherit; border-left-width: medium; border-right-style: none; border-right-color: inherit; border-right-width: medium; border-top-style: none; border-top-color: inherit; border-top-width: medium;">
                        <asp:RadioButton ID="rb76" runat="server" GroupName="rb08" />
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-right: none; border-image: initial; border-bottom: 1pt solid ; height: 25.9pt;">
                        <asp:RadioButton ID="rb77" runat="server" GroupName="rb08" />
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-right: none; border-image: initial; border-bottom: 1pt solid ; height: 25.9pt;">
                        <asp:RadioButton ID="rb78" runat="server" GroupName="rb08" />
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-right: none; border-image: initial; border-bottom: 1pt solid ; height: 25.9pt;">
                        <asp:RadioButton ID="rb79" runat="server" GroupName="rb08" />
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-bottom: 1pt solid ; border-right: 1.5pt solid ; height: 25.9pt;">
                        <asp:RadioButton ID="rb80" runat="server" GroupName="rb08" />
                    </td>
                </tr>
                <tr style="height: 6.1pt;">
                    <td style=" border-top: none; border-left: 1.5pt solid ; border-bottom: 1pt solid ; border-right: none; height: 6.1pt;">
                        <p  style=" font-size: 12pt;  text-align: justify; ">
                            <span lang="EN-US" style="font-size: 14pt; font-family: 標楷體;">9.</span><span style="font-size: 14pt; font-family: 標楷體;">與病人溝通之技巧<span lang="EN-US">…………………</span></span></p>
                    </td>
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
                    <td  style=" border-image: initial; border-bottom: 1pt solid ; border-left-style: none; border-left-color: inherit; border-left-width: medium; border-right-style: none; border-right-color: inherit; border-right-width: medium; border-top-style: none; border-top-color: inherit; border-top-width: medium;">
                        <asp:RadioButton ID="rb86" runat="server" GroupName="rb09" />
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-right: none; border-image: initial; border-bottom: 1pt solid ; height: 25.9pt;">
                        <asp:RadioButton ID="rb87" runat="server" GroupName="rb09" />
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-right: none; border-image: initial; border-bottom: 1pt solid ; height: 25.9pt;">
                        <asp:RadioButton ID="rb88" runat="server" GroupName="rb09" />
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-right: none; border-image: initial; border-bottom: 1pt solid ; height: 25.9pt;">
                        <asp:RadioButton ID="rb89" runat="server" GroupName="rb09" />
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-bottom: 1pt solid ; border-right: 1.5pt solid ; height: 25.9pt;">
                        <asp:RadioButton ID="rb90" runat="server" GroupName="rb09" />
                    </td>
                </tr>
                <tr style="height: 6.1pt;">
                    <td style=" border-top: none; border-left: 1.5pt solid ; border-bottom: 1pt solid ; border-right: none; height: 6.1pt;">
                        <p  style=" font-size: 12pt;  text-align: justify; ">
                            <span lang="EN-US" style="font-size: 14pt; font-family: 標楷體;">10.</span><span style="font-size: 14pt; font-family: 標楷體;">顧及病人感受<span lang="EN-US">/</span>專業素養<span lang="EN-US">…………</span></span></p>
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-right: none; border-image: initial; border-bottom: 1pt solid ; height: 25.9pt;">
                        <asp:RadioButton ID="rb91" runat="server" GroupName="rb10" />
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-right: none; border-image: initial; border-bottom: 1pt solid ; height: 25.9pt;">
                        <asp:RadioButton ID="rb92" runat="server" GroupName="rb10" />
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-right: none; border-image: initial; border-bottom: 1pt solid ; height: 25.9pt;">
                        <asp:RadioButton ID="rb93" runat="server" GroupName="rb10" />
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-right: none; border-image: initial; border-bottom: 1pt solid ; height: 25.9pt;">
                        <asp:RadioButton ID="rb94" runat="server" GroupName="rb10" />
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-right: none; border-image: initial; border-bottom: 1pt solid ; height: 25.9pt;">
                        <asp:RadioButton ID="rb95" runat="server" GroupName="rb10" />
                    </td>
                    <td  style=" border-image: initial; border-bottom: 1pt solid ; border-left-style: none; border-left-color: inherit; border-left-width: medium; border-right-style: none; border-right-color: inherit; border-right-width: medium; border-top-style: none; border-top-color: inherit; border-top-width: medium;">
                        <asp:RadioButton ID="rb96" runat="server" GroupName="rb10" />
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-right: none; border-image: initial; border-bottom: 1pt solid ; height: 25.9pt;">
                        <asp:RadioButton ID="rb97" runat="server" GroupName="rb10" />
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-right: none; border-image: initial; border-bottom: 1pt solid ; height: 25.9pt;">
                        <asp:RadioButton ID="rb98" runat="server" GroupName="rb10" />
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-right: none; border-image: initial; border-bottom: 1pt solid ; height: 25.9pt;">
                        <asp:RadioButton ID="rb99" runat="server" GroupName="rb10" />
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-bottom: 1pt solid ; border-right: 1.5pt solid ; height: 25.9pt;">
                        <asp:RadioButton ID="rb100" runat="server" GroupName="rb10" />
                    </td>
                </tr>
                <tr style="height: 6.1pt;">
                    <td style=" border-top: none; border-left: 1.5pt solid ; border-bottom: 1.5pt solid ; border-right: none; height: 6.1pt;">
                        <p  style=" font-size: 12pt;  text-align: justify; ">
                            <span lang="EN-US" style="font-size: 14pt; font-family: 標楷體;">11.</span><span style="font-size: 14pt; font-family: 標楷體;">執行臨床技能之整體表現<span lang="EN-US">…………</span></span></p>
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-right: none; border-image: initial; border-bottom: 1pt solid ; height: 25.9pt;">
                        <asp:RadioButton ID="rb101" runat="server" GroupName="rb11" />
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-right: none; border-image: initial; border-bottom: 1pt solid ; height: 25.9pt;">
                        <asp:RadioButton ID="rb102" runat="server" GroupName="rb11" />
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-right: none; border-image: initial; border-bottom: 1pt solid ; height: 25.9pt;">
                        <asp:RadioButton ID="rb103" runat="server" GroupName="rb11" />
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-right: none; border-image: initial; border-bottom: 1pt solid ; height: 25.9pt;">
                        <asp:RadioButton ID="rb104" runat="server" GroupName="rb11" />
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-right: none; border-image: initial; border-bottom: 1pt solid ; height: 25.9pt;">
                        <asp:RadioButton ID="rb105" runat="server" GroupName="rb11" />
                    </td>
                    <td  style=" border-image: initial; border-bottom: 1pt solid ; border-left-style: none; border-left-color: inherit; border-left-width: medium; border-right-style: none; border-right-color: inherit; border-right-width: medium; border-top-style: none; border-top-color: inherit; border-top-width: medium;">
                        <asp:RadioButton ID="rb106" runat="server" GroupName="rb11" />
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-right: none; border-image: initial; border-bottom: 1pt solid ; height: 25.9pt;">
                        <asp:RadioButton ID="rb107" runat="server" GroupName="rb11" />
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-right: none; border-image: initial; border-bottom: 1pt solid ; height: 25.9pt;">
                        <asp:RadioButton ID="rb108" runat="server" GroupName="rb11" />
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-right: none; border-image: initial; border-bottom: 1pt solid ; height: 25.9pt;">
                        <asp:RadioButton ID="rb109" runat="server" GroupName="rb11" />
                    </td>
                    <td style=" border-top: none; border-left: none; width: 1cm; border-bottom: 1pt solid ; border-right: 1.5pt solid ; height: 25.9pt;">
                        <asp:RadioButton ID="rb110" runat="server" GroupName="rb11" />
                    </td>
                </tr>
            </table>

<table>
    <tr>
        <td colspan="2">導老師回饋/評語</td>
    </tr>
    <tr>
        <td width="50%"><span style="color: rgb(105, 105, 105); font-family: 標楷體; font-size: 18.6667px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: center; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(230, 230, 230); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">表現良好項目</span></td>
        <td width="50%"><span style="color: rgb(105, 105, 105); font-family: 標楷體; font-size: 18.6667px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: center; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(230, 230, 230); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">待加強改善項目</span><span lang="EN-US" style="color: rgb(105, 105, 105); font-family: 標楷體; font-size: 18.6667px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: center; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(230, 230, 230); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial;">/</span><span style="color: rgb(105, 105, 105); font-family: 標楷體; font-size: 18.6667px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: center; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(230, 230, 230); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">建議</span></td>
    </tr>
    <tr>
        <td>
            <asp:TextBox ID="tbGood" runat="server" Height="123px" TextMode="MultiLine" Width="467px"></asp:TextBox>
        </td>
        <td>
            <asp:TextBox ID="tbSuggest" runat="server" Height="123px" TextMode="MultiLine" Width="467px"></asp:TextBox>
        </td>
    </tr>
</table>
            <asp:Button ID="btnTeacherSubmit" runat="server" Text="確認送出" OnClick="btnTeacherSubmit_Click" />
        </asp:Panel>
    </form>
</body>
</html>
