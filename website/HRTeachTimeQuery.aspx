<%@ Page Title="" Language="C#" MasterPageFile="~/Empty.master" AutoEventWireup="true" CodeFile="HRTeachTimeQuery.aspx.cs" Inherits="HRTeachTimeQuery" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default .rcbReadOnly .rcbInputCellLeft{background-position:0 -88px}.RadComboBox_Default .rcbReadOnly .rcbInputCellLeft{background-position:0 -88px}.RadComboBox_Default .rcbReadOnly .rcbInputCellLeft{background-position:0 -88px}.RadComboBox_Default .rcbReadOnly .rcbInputCellLeft{background-position:0 -88px}.RadComboBox_Default .rcbReadOnly .rcbInputCellLeft{background-position:0 -88px}.RadComboBox_Default .rcbReadOnly .rcbInputCellLeft{background-position:0 -88px}.RadComboBox_Default .rcbReadOnly .rcbInputCellLeft{background-position:0 -88px}.RadComboBox_Default .rcbReadOnly .rcbInputCellLeft{background-position:0 -88px}.RadComboBox_Default .rcbInputCellLeft{background-position:0 0}.RadComboBox_Default .rcbInputCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbInputCell{width:100%;height:20px;_height:22px;line-height:20px;_line-height:22px;text-align:left;vertical-align:middle}.RadComboBox .rcbInputCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbInputCellLeft{background-position:0 0}.RadComboBox_Default .rcbInputCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbInputCell{width:100%;height:20px;_height:22px;line-height:20px;_line-height:22px;text-align:left;vertical-align:middle}.RadComboBox .rcbInputCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbInputCellLeft{background-position:0 0}.RadComboBox_Default .rcbInputCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbInputCell{width:100%;height:20px;_height:22px;line-height:20px;_line-height:22px;text-align:left;vertical-align:middle}.RadComboBox .rcbInputCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbInputCellLeft{background-position:0 0}.RadComboBox_Default .rcbInputCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbInputCell{width:100%;height:20px;_height:22px;line-height:20px;_line-height:22px;text-align:left;vertical-align:middle}.RadComboBox .rcbInputCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbInputCellLeft{background-position:0 0}.RadComboBox_Default .rcbInputCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbInputCell{width:100%;height:20px;_height:22px;line-height:20px;_line-height:22px;text-align:left;vertical-align:middle}.RadComboBox .rcbInputCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbInputCellLeft{background-position:0 0}.RadComboBox_Default .rcbInputCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbInputCell{width:100%;height:20px;_height:22px;line-height:20px;_line-height:22px;text-align:left;vertical-align:middle}.RadComboBox .rcbInputCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbInputCellLeft{background-position:0 0}.RadComboBox_Default .rcbInputCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbInputCell{width:100%;height:20px;_height:22px;line-height:20px;_line-height:22px;text-align:left;vertical-align:middle}.RadComboBox .rcbInputCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbInputCellLeft{background-position:0 0}.RadComboBox_Default .rcbInputCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbInputCell{width:100%;height:20px;_height:22px;line-height:20px;_line-height:22px;text-align:left;vertical-align:middle}.RadComboBox .rcbInputCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;-webkit-appearance:none}.RadComboBox input{height:auto;box-shadow:none;outline:0}.RadComboBox input{height:auto;box-shadow:none;outline:0}.RadComboBox input{height:auto;box-shadow:none;outline:0}.RadComboBox input{height:auto;box-shadow:none;outline:0}.RadComboBox input{height:auto;box-shadow:none;outline:0}.RadComboBox input{height:auto;box-shadow:none;outline:0}.RadComboBox input{height:auto;box-shadow:none;outline:0}.RadComboBox input{height:auto;box-shadow:none;outline:0}.RadComboBox_Default .rcbReadOnly .rcbArrowCellRight{background-position:-162px -176px}.RadComboBox_Default .rcbReadOnly .rcbArrowCellRight{background-position:-162px -176px}.RadComboBox_Default .rcbReadOnly .rcbArrowCellRight{background-position:-162px -176px}.RadComboBox_Default .rcbReadOnly .rcbArrowCellRight{background-position:-162px -176px}.RadComboBox_Default .rcbReadOnly .rcbArrowCellRight{background-position:-162px -176px}.RadComboBox_Default .rcbReadOnly .rcbArrowCellRight{background-position:-162px -176px}.RadComboBox_Default .rcbReadOnly .rcbArrowCellRight{background-position:-162px -176px}.RadComboBox_Default .rcbReadOnly .rcbArrowCellRight{background-position:-162px -176px}.RadComboBox_Default .rcbArrowCellRight{background-position:-18px -176px}.RadComboBox_Default .rcbArrowCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbArrowCell{width:18px}.RadComboBox .rcbArrowCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbArrowCellRight{background-position:-18px -176px}.RadComboBox_Default .rcbArrowCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbArrowCell{width:18px}.RadComboBox .rcbArrowCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbArrowCellRight{background-position:-18px -176px}.RadComboBox_Default .rcbArrowCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbArrowCell{width:18px}.RadComboBox .rcbArrowCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbArrowCellRight{background-position:-18px -176px}.RadComboBox_Default .rcbArrowCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbArrowCell{width:18px}.RadComboBox .rcbArrowCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbArrowCellRight{background-position:-18px -176px}.RadComboBox_Default .rcbArrowCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbArrowCell{width:18px}.RadComboBox .rcbArrowCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbArrowCellRight{background-position:-18px -176px}.RadComboBox_Default .rcbArrowCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbArrowCell{width:18px}.RadComboBox .rcbArrowCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbArrowCellRight{background-position:-18px -176px}.RadComboBox_Default .rcbArrowCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbArrowCell{width:18px}.RadComboBox .rcbArrowCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbArrowCellRight{background-position:-18px -176px}.RadComboBox_Default .rcbArrowCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbArrowCell{width:18px}.RadComboBox .rcbArrowCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}
        .RadPicker{vertical-align:middle}.RadPicker{vertical-align:middle}.RadPicker{vertical-align:middle}.RadPicker{vertical-align:middle}.RadPicker{vertical-align:middle}.rdfd_{position:absolute}.rdfd_{position:absolute}.rdfd_{position:absolute}.rdfd_{position:absolute}.rdfd_{position:absolute}.rdfd_{position:absolute}.RadPicker .RadInput{vertical-align:baseline}.RadPicker .RadInput{vertical-align:baseline}.RadPicker .RadInput{vertical-align:baseline}.RadPicker .RadInput{vertical-align:baseline}.RadPicker .RadInput{vertical-align:baseline}.RadInput_Default{font:12px "segoe ui",arial,sans-serif}.RadInput{vertical-align:middle}.RadInput_Default{font:12px "segoe ui",arial,sans-serif}.RadInput{vertical-align:middle}.RadInput_Default{font:12px "segoe ui",arial,sans-serif}.RadInput{vertical-align:middle}.RadInput_Default{font:12px "segoe ui",arial,sans-serif}.RadInput{vertical-align:middle}.RadInput_Default{font:12px "segoe ui",arial,sans-serif}.RadInput{vertical-align:middle}.RadInput_Default{font:12px "segoe ui",arial,sans-serif}.RadInput{vertical-align:middle}.RadInput .riTextBox{height:17px}.RadInput .riTextBox{height:17px}.RadInput .riTextBox{height:17px}.RadInput .riTextBox{height:17px}.RadInput .riTextBox{height:17px}.RadInput .riTextBox{height:17px}
        .auto-style2
        {
            height: 24px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <br />
    <asp:Label ID="lbEmpData" runat="server"></asp:Label>
    <br />

<telerik:RadMultiPage ID="RadMultiPage1" Runat="server" Width="100%">
    <telerik:RadPageView ID="rpvNonDoctor" runat="server" Visible="False">
    <table>
        <tr>
            <td><asp:Label
                                        ID="Label12" runat="server" Font-Bold="True" Text="舉辦日期："></asp:Label>
                                </td>
            <td colspan="4">
                <table>
                                    <tr>
                                        <td>
                                            <asp:RadioButton ID="rbByEduYear" runat="server" Checked="True" GroupName="DateType" Text="依學年" />
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlEduYear" runat="server">
                                            </asp:DropDownList>
                                            <asp:Label ID="Label8" runat="server" Text="學年度"></asp:Label>
                                        </td>
                                        <td></td>
                                        <td>
                                            <asp:DropDownList ID="ddlEduYearSession" runat="server">
                                                <asp:ListItem Value="0">上學期</asp:ListItem>
                                                <asp:ListItem Value="1">下學期</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                    <tr>
                                        <td>
                                            <asp:RadioButton ID="rbByDate" runat="server" GroupName="DateType" Text="依日期" />
                                        </td>
                        <td>                                                <telerik:RadDatePicker ID="rdpDateBegin" runat="server"
                                                    Width="130px">
                                                    <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False">
                                                    </Calendar>
                                                    <DateInput DateFormat="yyyy/M/d" DisplayDateFormat="yyyy/M/d"
                                                        LabelWidth="40%">
                                                        <EmptyMessageStyle Resize="None" />
                                                        <ReadOnlyStyle Resize="None" />
                                                        <FocusedStyle Resize="None" />
                                                        <DisabledStyle Resize="None" />
                                                        <InvalidStyle Resize="None" />
                                                        <HoveredStyle Resize="None" />
                                                        <EnabledStyle Resize="None" />
                                                    </DateInput><DatePopupButton HoverImageUrl="" ImageUrl="" />
                                                </telerik:RadDatePicker></td>
                        <td>~</td>
                        <td><telerik:RadDatePicker ID="rdpDateEnd" runat="server" Width="130px">
                                                </telerik:RadDatePicker></td>
                    </tr>

                </table>

            </td>
        </tr>
        <tr>
            <td><asp:Label
                                        ID="Label20" runat="server" Font-Bold="True" Text="計算時機："></asp:Label>
                                </td>
            <td colspan ="4">
                            <telerik:RadComboBox Width="350px" OnDataBound="rcbRole_DataBound" ID="rcbSettingType" Runat="server" DataTextField="SettingType" DataValueField="SettingType" AllowCustomText="True" Filter="Contains" OnSelectedIndexChanged="rcbSettingType_SelectedIndexChanged" AutoPostBack="True">
                            </telerik:RadComboBox>
                        </td>
        </tr>
        <tr>
            <td><asp:Label
                                        ID="Label4" runat="server" Font-Bold="True" Text="活動類型：" Visible="False"></asp:Label>
                                </td>
            <td>
                                                <telerik:RadComboBox ID="rcbType1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rcbType1_SelectedIndexChanged"
                                                    NoWrap="True" Visible="False">
                                                </telerik:RadComboBox>
                                            </td>
            <td>
                                                <telerik:RadComboBox ID="rcbType2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rcbType2_SelectedIndexChanged"
                                                    NoWrap="True" Visible="False">
                                                </telerik:RadComboBox>
                                            </td>
            <td>
                                                <telerik:RadComboBox ID="rcbType3" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rcbType3_SelectedIndexChanged"
                                                    NoWrap="True" Visible="False">
                                                </telerik:RadComboBox>
                                            </td>
            <td>
                                                <telerik:RadComboBox ID="rcbType4" runat="server" NoWrap="True" Visible="False">
                                                </telerik:RadComboBox>
                                            </td>
        </tr>
        </table>
    <div id="divhide" runat="server">
    <table>
        <tr>
            <td colspan="5">
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="Label14" runat="server" Text="課程權重："></asp:Label>
                        </td>
                        <td>
                            <telerik:RadNumericTextBox ID="rntbActRate1" Runat="server" Value="1" Width="30px" Visible="False">
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
                        </td>
                        <td>
                            <asp:Label ID="Label15" runat="server" Text=":" Visible="False"></asp:Label>
                        </td>
                        <td>
                            <telerik:RadNumericTextBox ID="rntbActRate2" Runat="server" Value="1" Width="30px" Visible="False">
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
                        </td>
                        <td>
             <asp:ImageButton ID="ibtnAddActRate" runat="server" ImageUrl="~/Images/add.jpg" 
                 onclick="ImageButton1_Click" ToolTip="新增" Visible="False" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="5">
<telerik:RadGrid ID="rgActRate" runat="server" AutoGenerateColumns="False" CellSpacing="0" GridLines="None" OnDeleteCommand="rgActRate_DeleteCommand" OnNeedDataSource="rgActRate_NeedDataSource" Culture="zh-TW">
                    <MasterTableView DataKeyNames="acttype">
                        <RowIndicatorColumn Visible="False">
                        </RowIndicatorColumn>
                        <ExpandCollapseColumn Created="True">
                        </ExpandCollapseColumn>
                        <Columns>
                            <telerik:GridBoundColumn DataField="acttypename" FilterControlAltText="Filter SetName column" UniqueName="acttypename" HeaderText="活動類型">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="actratestr" FilterControlAltText="Filter RateStr column" UniqueName="actratestr" HeaderText="課程權重">
                            </telerik:GridBoundColumn>
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>

                        </td>
                    </tr>
                </table>
                
            </td>
        </tr>

                    <tr>
                        <td><asp:Label
                                        ID="Label13" runat="server" Font-Bold="True" Text="角色：" Visible="False"></asp:Label>
                                </td>
                        <td>
                            <telerik:RadComboBox OnDataBound="rcbRole_DataBound" ID="rcbRole" Runat="server" DataSourceID="dsRoleType" DataTextField="name" DataValueField="code" Visible="False">
                            </telerik:RadComboBox>
                        </td>
                        <td></td>
                        <td></td>
                        <td></td>
                    </tr>
        <tr>
            <td colspan="5">
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="身分權重："></asp:Label>
                        </td>
                        <td>
                            <telerik:RadNumericTextBox ID="rntbRoleRate1" Runat="server" Value="1" Width="30px" Visible="False">
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
                        </td>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text=":" Visible="False"></asp:Label>
                        </td>
                        <td>
                            <telerik:RadNumericTextBox ID="rntbRoleRate2" Runat="server" Value="1" Width="30px" Visible="False">
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
                        </td>
                        <td>
             <asp:ImageButton ID="ibtnAddRole" runat="server" ImageUrl="~/Images/add.jpg" 
                 onclick="ibtnAddRole_Click" ToolTip="新增" Visible="False" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="5">
<telerik:RadGrid ID="rgRoleRate" runat="server" AutoGenerateColumns="False" CellSpacing="0" GridLines="None" OnDeleteCommand="rgRoleRate_DeleteCommand" OnNeedDataSource="rgRoleRate_NeedDataSource">
                    <MasterTableView DataKeyNames="roletype">
                        <RowIndicatorColumn Visible="False">
                        </RowIndicatorColumn>
                        <ExpandCollapseColumn Created="True">
                        </ExpandCollapseColumn>
                        <Columns>
                            <telerik:GridBoundColumn DataField="roletypename" FilterControlAltText="Filter SetName column" UniqueName="roletypename" HeaderText="角色">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="roleratestr" FilterControlAltText="Filter RateStr column" UniqueName="roleratestr" HeaderText="身分權重">
                            </telerik:GridBoundColumn>
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>

                        </td>
                    </tr>
                </table>
                

            </td>
        </tr>

<tr>
            <td colspan="5">
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="Label5" runat="server" Text="複合條件權重："></asp:Label>
                        </td>
                        <td>
                            <telerik:RadNumericTextBox ID="rntbMixRate1" Runat="server" Value="1" Width="30px" Visible="False">
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
                        </td>
                        <td>
                            <asp:Label ID="Label6" runat="server" Text=":" Visible="False"></asp:Label>
                        </td>
                        <td>
                            <telerik:RadNumericTextBox ID="rntbMixRate2" Runat="server" Value="1" Width="30px" Visible="False">
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
                        </td>
                        <td>

                            <asp:Label ID="Label22" runat="server" Text="單位：" Visible="False"></asp:Label>

                        </td>
                        <td>

                            <asp:DropDownList ID="ddlUnit" runat="server" Visible="False">
                                <asp:ListItem>次</asp:ListItem>
                                <asp:ListItem Value="hr">小時</asp:ListItem>
                            </asp:DropDownList>

                        </td>
                        <td>
             <asp:ImageButton ID="ibtnAddBoth" runat="server" ImageUrl="~/Images/add.jpg" ToolTip="新增" Visible="False" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="7">
<telerik:RadGrid ID="rgMixRate" runat="server" AutoGenerateColumns="False" CellSpacing="0" GridLines="None" OnDeleteCommand="rgRoleRate_DeleteCommand" OnNeedDataSource="rgRoleRate_NeedDataSource" Culture="zh-TW">
                    <MasterTableView DataKeyNames="roletype">
                        <RowIndicatorColumn Visible="False">
                        </RowIndicatorColumn>
                        <ExpandCollapseColumn Created="True">
                        </ExpandCollapseColumn>
                        <Columns>
                            <telerik:GridBoundColumn DataField="acttypename" FilterControlAltText="Filter acttypename column" HeaderText="活動類型" UniqueName="acttypename">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="roletypename" FilterControlAltText="Filter SetName column" UniqueName="roletypename" HeaderText="角色">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="mixratestr" FilterControlAltText="Filter RateStr column" UniqueName="mixratestr" HeaderText="權重">
                            </telerik:GridBoundColumn>
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>

                        </td>
                    </tr>
                </table>
                

            </td>
        </tr>


        <tr>
            <td class="auto-style2"><asp:Label
                                        ID="Label16" runat="server" Font-Bold="True" Text="出席人員："></asp:Label>
                                </td>
            <td class="auto-style2">
                            <asp:CheckBox ID="cbNeedStudent" runat="server" Text="需有出席人員" Checked="True" />
                        </td>
            <td class="auto-style2"></td>
            <td class="auto-style2"></td>
            <td class="auto-style2"></td>
        </tr>
        <tr>
            <td colspan="5">
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="Label17" runat="server" Text="必要職稱："></asp:Label>
                        </td>
                        <td>
                            <telerik:RadComboBox Width="350px" OnDataBound="rcbRole_DataBound" ID="rcbJobCode" Runat="server" DataTextField="name" DataValueField="code" AllowCustomText="True" Filter="Contains" MaxHeight="300px">
                            </telerik:RadComboBox>
                        </td>
                        <td>
             <asp:ImageButton ID="ibtnAddJobCode" runat="server" ImageUrl="~/Images/add.jpg" 
                 onclick="ibtnAddJobCode_Click" ToolTip="新增" />
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="5">
<telerik:RadGrid ID="rgJobCode" runat="server" AutoGenerateColumns="False" CellSpacing="0" GridLines="None" OnDeleteCommand="rgJobCode_DeleteCommand" OnNeedDataSource="rgJobCode_NeedDataSource" AutoGenerateDeleteColumn="True">
                    <MasterTableView DataKeyNames="JOB_CODE_X">
                        <RowIndicatorColumn Visible="False">
                        </RowIndicatorColumn>
                        <ExpandCollapseColumn Created="True">
                        </ExpandCollapseColumn>
                        <Columns>
                            <telerik:GridBoundColumn DataField="Job_Name" FilterControlAltText="Filter SetName column" UniqueName="Job_Name" HeaderText="必要職稱">
                            </telerik:GridBoundColumn>
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>

                        </td>
                    </tr>
                </table>
                

            </td>
        </tr>
        <tr>
            <td>
                            <asp:CheckBox ID="cbNeedAtt" runat="server" Text="需有附件" Checked="True" />
                        </td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td><asp:Label
                                        ID="Label3" runat="server" Font-Bold="True" Text="指定職稱："></asp:Label>
                                </td>
            <td colspan="4">
                            <telerik:RadComboBox Width="350px" OnDataBound="rcbRole_DataBound" ID="rcbFilterJob" Runat="server" DataTextField="name" DataValueField="code" AllowCustomText="True" Filter="Contains" MaxHeight="300px" CheckBoxes="True">
                            </telerik:RadComboBox>
            </td>
        </tr>

        <tr>
            <td><asp:Label
                                        ID="Label18" runat="server" Font-Bold="True" Text="指定員工資料："></asp:Label>
                                </td>
            <td colspan="4">
                <asp:TextBox ID="tbEmpCodes" runat="server" Width="317px"></asp:TextBox>
                <asp:Label ID="Label19" runat="server" Text="職編不加0，多人請以逗點分隔"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label
                                        ID="Label21" runat="server" Font-Bold="True" Text="指定院區："></asp:Label>
            </td>
            <td colspan="4">

                <asp:CheckBoxList ID="cblHospital" runat="server" RepeatDirection="Horizontal">
                </asp:CheckBoxList>

            </td>
        </tr>
        <tr>
            <td>
                <asp:Label
                                        ID="Label7" runat="server" Font-Bold="True" Text="計算mini-CEX、DOPS、CbD："></asp:Label>
            </td>
            <td colspan="4">

                            <asp:CheckBox ID="cbLoadForm" runat="server" />

            </td>
        </tr>
        <tr>
            <td colspan="5">
                <asp:Panel ID="Panel1" runat="server" GroupingText="醫療教學並行">
                    <table>
                        <tr>
                            <td>
                                
                                <asp:CheckBoxList ID="rblHealTeachTimeTargetType" runat="server" RepeatDirection="Horizontal">
                                </asp:CheckBoxList>
                                
                            </td>
                            <td>

                                &nbsp;</td>
                        </tr>

                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="5">

                <asp:CheckBox ID="cbShowActData" runat="server" Checked="True" Text="顯示活動計算資料" />
                <asp:CheckBox ID="cbShowHealthTeach" runat="server" Checked="True" Text="顯示醫療教學並行資料" />

            </td>
        </tr>
        </table>
</div>
    <table>
        <tr>
            <td>
                <asp:Button ID="btnQuery" runat="server" OnClick="btnQuery_Click" Text="匯出明細" />
            </td>
            <td>
                <asp:Button ID="btnQuerySum" runat="server" Text="匯出分項總計" OnClick="btnQuerySum_Click" />
            &nbsp;&nbsp;
                <asp:Button ID="btnQueryPersonalSum" runat="server" Text="匯出個人總計" OnClick="btnQueryPersonalSum_Click" />
            </td>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="btnToKPI" runat="server" Text="匯出貢獻度格式檔" Visible="False" />
            </td>
            <td></td>
        </tr>
    </table>


    <div>
                    <asp:ObjectDataSource ID="dsRoleType" runat="server" 
                        DataObjectTypeName="KMU.EduActivity.ApplicationLayer.DTO.V_CodeRefDto" 
                        SelectMethod="GetCodeRefsStatic" 
                        TypeName="KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="EduAct_ActRoleType" Name="codetype" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    </div>
    </telerik:RadPageView>
    <telerik:RadPageView ID="rpvDoctor" runat="server" Visible="False">

        <asp:Literal ID="liTeachData" runat="server"></asp:Literal>
        <br />
        <asp:Literal ID="liTeachData2" runat="server"></asp:Literal>
        <br />
        <br />

    </telerik:RadPageView>

</telerik:RadMultiPage>


</asp:Content>

