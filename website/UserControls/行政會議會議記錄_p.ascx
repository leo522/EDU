<%@ Control Language="C#" AutoEventWireup="true" CodeFile="行政會議會議記錄_p.ascx.cs" Inherits="UserControls_行政會議會議記錄_p" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>


            <style type="text/css">
                .RadPicker{vertical-align:middle}.RadPicker{vertical-align:middle}.rdfd_{position:absolute}.rdfd_{position:absolute}.RadPicker .rcTable{table-layout:auto}.RadPicker .rcTable{table-layout:auto}.RadPicker .RadInput{vertical-align:baseline}.RadPicker .RadInput{vertical-align:baseline}.RadInput_Default{font:12px "segoe ui",arial,sans-serif}.RadInput{vertical-align:middle}.RadInput_Default{font:12px "segoe ui",arial,sans-serif}.RadInput{vertical-align:middle}.RadInput .riTextBox{height:17px}.RadInput .riTextBox{height:17px}.RadPicker_Default .rcCalPopup{background-position:0 0}.RadPicker_Default .rcCalPopup{background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Calendar.sprite.gif')}.RadPicker .rcCalPopup{display:block;overflow:hidden;width:22px;height:22px;background-color:transparent;background-repeat:no-repeat;text-indent:-2222px;text-align:center;-webkit-box-sizing:content-box;-moz-box-sizing:content-box;box-sizing:content-box}.RadPicker_Default .rcCalPopup{background-position:0 0}.RadPicker_Default .rcCalPopup{background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Calendar.sprite.gif')}.RadPicker .rcCalPopup{display:block;overflow:hidden;width:22px;height:22px;background-color:transparent;background-repeat:no-repeat;text-indent:-2222px;text-align:center;-webkit-box-sizing:content-box;-moz-box-sizing:content-box;box-sizing:content-box}.RadPicker td a{position:relative;outline:0;z-index:2;margin:0 2px;text-decoration:none}.RadPicker td a{position:relative;outline:0;z-index:2;margin:0 2px;text-decoration:none}
p {
	font-size: 12.0pt;
	font-family: "新細明體", "serif";
}
div.RadPicker table.rcSingle .rcInputCell{padding-right:0}div.RadPicker table.rcSingle .rcInputCell{padding-right:0}.RadPicker table.rcTable .rcInputCell{padding:0 4px 0 0}.RadPicker table.rcTable .rcInputCell{padding:0 4px 0 0}.Default.reWrapper{border:1px solid #828282}.Default.RadEditor{background-color:#eee}.Default.reWrapper{border:1px solid #828282}.Default.RadEditor{background-color:#eee}.RadEditor{box-sizing:content-box;-moz-box-sizing:content-box}.RadEditor{box-sizing:content-box;-moz-box-sizing:content-box}.RadEditor *{box-sizing:content-box;-moz-box-sizing:content-box}.RadEditor *{box-sizing:content-box;-moz-box-sizing:content-box}.reWrapper_corner{font-size:1px;line-height:1px}.reWrapper_corner{font-size:1px;line-height:1px}.reWrapper_center{font-size:1px;line-height:1px}.reWrapper_center{font-size:1px;line-height:1px}.reLeftVerticalSide{padding:1px}.reLeftVerticalSide{font-size:1px;line-height:1px}.reLeftVerticalSide{padding:1px}.reLeftVerticalSide{font-size:1px;line-height:1px}.RadEditor.reWrapper .reToolCell{vertical-align:top;padding-bottom:1px}.RadEditor.reWrapper .reToolCell{vertical-align:top;padding-bottom:1px}.reToolbarWrapper{margin-top:0}.reToolbarWrapper{margin-top:0}.reRightVerticalSide{padding:1px}.reRightVerticalSide{font-size:1px;line-height:1px}.reRightVerticalSide{padding:1px}.reRightVerticalSide{font-size:1px;line-height:1px}.Default.RadEditor .reContentCell{background-color:white}.Default.RadEditor .reContentCell{border:1px solid #828282}.Default.RadEditor .reContentCell{background-color:white}.Default.RadEditor .reContentCell{border:1px solid #828282}.RadEditor .reContentCell{vertical-align:top}.RadEditor .reContentCell{vertical-align:top}.reContentCell{background-color:#fff}.reContentCell{background-color:#fff}.Default.RadEditor .reEditorModes{background-color:#eee}.Default.RadEditor .reEditorModes{background-color:#eee}.reEditorModes{float:left;padding:1px 0!important}.reEditorModes{float:left;padding:1px 0!important}.reBottomZone{text-align:right;vertical-align:bottom}.reBottomZone{text-align:right;vertical-align:bottom}.RadEditor .reResizeCell{vertical-align:bottom;text-align:right}.RadEditor .reResizeCell{vertical-align:bottom;text-align:right}
                .auto-style8 {
                    width: 258px;
                }
                .auto-style10 {
                    width: 78px;
                }
                .auto-style11 {
                    width: 281px;
                }
                </style>


            <p align="center" style="text-align: center; line-height: 26pt;">
                <span style="font-family: 標楷體; font-size: 16pt;">教學檢討會議</span><span style="font-size: 16pt;"> </span><span style="font-family: 標楷體; font-size: 16pt;">會議記錄</span></p>
<table border="1" cellpadding="0" cellspacing="0" width="98%">
    <tr>
        <td class="auto-style8">
            <p align="center" style="text-align: center; line-height: 19pt;">
                <b><span style="font-family: 標楷體; font-size: 14pt;">主</span><span lang="EN-US" style="font-size: 14pt;">&nbsp;&nbsp;&nbsp; </span><span style="font-family: 標楷體; font-size: 14pt;">席</span></b></p>
        </td>
        <td class="auto-style10">
          <asp:TextBox ID="TextBox3" runat="server" Width="104px"></asp:TextBox>
          <telerik:RadDatePicker ID="RadDatePicker1" Runat="server" Visible="False">
          </telerik:RadDatePicker>
        </td>
        <td class="auto-style11">
            <p align="center" style="text-align: center; line-height: 19pt;">
                <b><span style="font-family: 標楷體; font-size: 14pt;">紀</span><span lang="EN-US" style="font-size: 14pt;">&nbsp;&nbsp;&nbsp; </span><span style="font-family: 標楷體; font-size: 14pt;">錄</span></b></p>
        </td>
        <td width="83">
          <asp:TextBox ID="TextBox4" runat="server" Width="110px"></asp:TextBox>
          <asp:TextBox ID="TextBox2" runat="server" Visible="False"></asp:TextBox>
        </td>
    </tr>
</table>

<p style="line-height: 12pt;">
    <b><span lang="EN-US" style="font-size: 14pt;">壹、<span style="font: 7pt/normal &quot;Times New Roman&quot;; font-size-adjust: none; font-stretch: normal;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span><span style="font-family: 標楷體; font-size: 14pt;">上次會議追蹤<asp:Literal ID="RadEditor5" runat="server"></asp:Literal>
        </span></b>
<p>
    <b><span lang="EN-US" style="font-size: 14pt;">貳、<span style="font: 7pt/normal &quot;Times New Roman&quot;; font-size-adjust: none; font-stretch: normal;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span><span style="font-family: 標楷體; font-size: 14pt;">報告事項<asp:Literal ID="RadEditor3" runat="server"></asp:Literal>
        </span></b>

<p>
    <b><span lang="EN-US" style="font-size: 14pt;">參、<span style="font: 7pt/normal &quot;Times New Roman&quot;; font-size-adjust: none; font-stretch: normal;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span><span style="font-family: 標楷體; font-size: 14pt;">提案討論<asp:Literal ID="RadEditor4" runat="server"></asp:Literal>
        </span></b>
<p style="line-height: 22pt;">
    <b><span lang="EN-US" style="font-size: 14pt;">伍、<span style="font: 7pt/normal &quot;Times New Roman&quot;; font-size-adjust: none; font-stretch: normal;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span><span style="font-family: 標楷體; font-size: 14pt;">下次會議追蹤事項<asp:Literal ID="RadEditor7" runat="server"></asp:Literal>
        </span></b>
