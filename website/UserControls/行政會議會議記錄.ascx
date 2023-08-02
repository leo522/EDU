<%@ Control Language="C#" AutoEventWireup="true" CodeFile="行政會議會議記錄.ascx.cs" Inherits="UserControls_門診記錄表" %>
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
    <b><span lang="EN-US" style="font-size: 14pt;">壹、<span style="font: 7pt/normal &quot;Times New Roman&quot;; font-size-adjust: none; font-stretch: normal;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span><span style="font-family: 標楷體; font-size: 14pt;">上次會議追蹤<telerik:RadEditor ID="RadEditor5" Runat="server" EditModes="Design" Height="170px" Width="100%">
                    <Tools>
                        <telerik:EditorToolGroup Tag="MainToolbar">
                            
                            <telerik:EditorSeparator />
                            <telerik:EditorSplitButton Name="Undo">
                            </telerik:EditorSplitButton>
                            <telerik:EditorSplitButton Name="Redo">
                            </telerik:EditorSplitButton>
                            <telerik:EditorSeparator />
                            <telerik:EditorTool Name="Cut" />
                            <telerik:EditorTool Name="Copy" />
                            <telerik:EditorTool Name="Paste" ShortCut="CTRL+V" />
                        </telerik:EditorToolGroup>
                        <telerik:EditorToolGroup Tag="Formatting">
                            <telerik:EditorTool Name="Bold" />
                            <telerik:EditorTool Name="Italic" />
                            <telerik:EditorTool Name="Underline" />
                            <telerik:EditorSeparator />
                            <telerik:EditorSplitButton Name="ForeColor">
                            </telerik:EditorSplitButton>
                            <telerik:EditorSplitButton Name="BackColor">
                            </telerik:EditorSplitButton>
                            <telerik:EditorDropDown Name="RealFontSize">
                            </telerik:EditorDropDown>
                            <telerik:EditorSeparator />
                        </telerik:EditorToolGroup>
                    </Tools>
<Content>
    <table border=1 cellspacing=0 cellpadding=0 width=660>
      <thead>
        <tr>
          <td width=123 rowspan=2><p align=center style='text-align:center;line-height:12.0pt'><b><span
   style='font-family:標楷體'>議題</span></b></p></td>
          <td width=77 rowspan=2><p align=center style='text-align:center;line-height:12.0pt'><b><span
   style='font-family:標楷體'>類別</span></b></p></td>
          <td width=395 rowspan=2><p align=center style='text-align:center;line-height:12.0pt'><b><span
   style='font-family:標楷體'>追蹤及改善情形</span></b></p></td>
          <td width=65 colspan=2><p align=center style='text-align:center;line-height:12.0pt'><b><span
   style='font-size:8.0pt;font-family:標楷體'>建議列管別</span></b></p></td>
        </tr>
        <tr>
          <td width=38><p align=center style='text-align:center;line-height:12.0pt'><b><span
   style='font-size:8.0pt;font-family:標楷體'>續管</span></b></p></td>
          <td width=27><p align=center style='text-align:center;line-height:12.0pt'><b><span
   style='font-size:8.0pt;font-family:標楷體'>除管</span></b></p></td>
        </tr>
      </thead>
      <tr>
        <td width=123 rowspan=3>&nbsp;</td>
        <td width=77><p align=center style='text-align:center'><span
  style='font-size:8.0pt;font-family:標楷體'>上次決議事項</span></p></td>
        <td width=395>&nbsp;</td>
        <td width=38 rowspan=3>&nbsp;</td>
        <td width=27 rowspan=3>&nbsp;</td>
      </tr>
      <tr>
        <td width=77><p align=center style='text-align:center'><span
  style='font-size:8.0pt;font-family:標楷體'>辦理情形</span><span lang=EN-US
  style='font-size:8.0pt'>/</span><span style='font-size:8.0pt;font-family:
  標楷體'>說明</span></p></td>
        <td width=395>&nbsp;</td>
      </tr>
      <tr>
        <td width=77><p align=center style='text-align:center'><span
  style='font-size:8.0pt;font-family:標楷體'>本次決議事項</span></p></td>
        <td width=395>&nbsp;</td>
      </tr>
    </table>    


</Content>

<TrackChangesSettings CanAcceptTrackChanges="False"></TrackChangesSettings>
            </telerik:RadEditor>
        </span></b>
<p>
    <b><span lang="EN-US" style="font-size: 14pt;">貳、<span style="font: 7pt/normal &quot;Times New Roman&quot;; font-size-adjust: none; font-stretch: normal;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span><span style="font-family: 標楷體; font-size: 14pt;">報告事項<telerik:RadEditor ID="RadEditor3" Runat="server" EditModes="Design" Height="170px" Width="100%">
                    <Tools>
                        <telerik:EditorToolGroup Tag="MainToolbar">
                            
                            <telerik:EditorSeparator />
                            <telerik:EditorSplitButton Name="Undo">
                            </telerik:EditorSplitButton>
                            <telerik:EditorSplitButton Name="Redo">
                            </telerik:EditorSplitButton>
                            <telerik:EditorSeparator />
                            <telerik:EditorTool Name="Cut" />
                            <telerik:EditorTool Name="Copy" />
                            <telerik:EditorTool Name="Paste" ShortCut="CTRL+V" />
                        </telerik:EditorToolGroup>
                        <telerik:EditorToolGroup Tag="Formatting">
                            <telerik:EditorTool Name="Bold" />
                            <telerik:EditorTool Name="Italic" />
                            <telerik:EditorTool Name="Underline" />
                            <telerik:EditorSeparator />
                            <telerik:EditorSplitButton Name="ForeColor">
                            </telerik:EditorSplitButton>
                            <telerik:EditorSplitButton Name="BackColor">
                            </telerik:EditorSplitButton>
                            <telerik:EditorDropDown Name="RealFontSize">
                            </telerik:EditorDropDown>
                            <telerik:EditorSeparator />
                        </telerik:EditorToolGroup>
                    </Tools>
<Content>
  <p style='layout-grid-mode:char'><span lang=EN-US style='color:black'>一、<span style='font:7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span><span lang=EN-US>&nbsp;</span></p>
    <p style='line-height:22.0pt;layout-grid-mode:
char'><b><span style='font-family:標楷體'>決議：<span lang=EN-US>1. </span></span></b></p>
  <p style='line-height:
22.0pt;layout-grid-mode:char'><span lang=EN-US style='font-family:標楷體;
color:black'>二、<span style='font:7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp; </span></span><span
lang=EN-US style='font-family:標楷體'>&nbsp;</span></p>
  <p style='line-height:22.0pt;layout-grid-mode:
char'><b><span style='font-family:標楷體'>決議：<span lang=EN-US>1. </span></span></b></p>
  <p style='line-height:22.0pt;layout-grid-mode:
char'><b><span lang=EN-US style='font-family:標楷體'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    2. </span></b></p>
  <p style='line-height:
22.0pt;layout-grid-mode:char'><span lang=EN-US style='font-family:標楷體;
color:black'>三、<span style='font:7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp; </span></span><span
lang=EN-US style='font-family:標楷體'>&nbsp;</span></p>
  <p style='line-height:18.0pt;layout-grid-mode:
char'><b><span style='font-family:標楷體'>決議： </span></b></p>
  <p style='line-height:
18.0pt;layout-grid-mode:char'><span lang=EN-US style='color:black'>四、<span
style='font:7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span><span lang=EN-US>&nbsp;</span></p>
  <p style='line-height:22.0pt'><b><span lang=EN-US
style='font-size:14.0pt'>&nbsp;</span></b><b><span lang=EN-US style='font-family:
標楷體'>&nbsp;&nbsp;</span></b><b><span style='font-family:標楷體'>決議：<span
lang=EN-US> </span></span></b></p>
</Content>

<TrackChangesSettings CanAcceptTrackChanges="False"></TrackChangesSettings>
            </telerik:RadEditor>
        </span></b>

<p>
    <b><span lang="EN-US" style="font-size: 14pt;">參、<span style="font: 7pt/normal &quot;Times New Roman&quot;; font-size-adjust: none; font-stretch: normal;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span><span style="font-family: 標楷體; font-size: 14pt;">提案討論<telerik:RadEditor ID="RadEditor4" Runat="server" EditModes="Design" Height="170px" Width="100%">
                    <Tools>
                        <telerik:EditorToolGroup Tag="MainToolbar">
                            
                            <telerik:EditorSeparator />
                            <telerik:EditorSplitButton Name="Undo">
                            </telerik:EditorSplitButton>
                            <telerik:EditorSplitButton Name="Redo">
                            </telerik:EditorSplitButton>
                            <telerik:EditorSeparator />
                            <telerik:EditorTool Name="Cut" />
                            <telerik:EditorTool Name="Copy" />
                            <telerik:EditorTool Name="Paste" ShortCut="CTRL+V" />
                        </telerik:EditorToolGroup>
                        <telerik:EditorToolGroup Tag="Formatting">
                            <telerik:EditorTool Name="Bold" />
                            <telerik:EditorTool Name="Italic" />
                            <telerik:EditorTool Name="Underline" />
                            <telerik:EditorSeparator />
                            <telerik:EditorSplitButton Name="ForeColor">
                            </telerik:EditorSplitButton>
                            <telerik:EditorSplitButton Name="BackColor">
                            </telerik:EditorSplitButton>
                            <telerik:EditorDropDown Name="RealFontSize">
                            </telerik:EditorDropDown>
                            <telerik:EditorSeparator />
                        </telerik:EditorToolGroup>
                    </Tools>
<Content>
  <p style='layout-grid-mode:
char'><span lang=EN-US style='color:black'>一、<span style='font:7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span><span lang=EN-US>&nbsp;</span></p>
  <p style='layout-grid-mode:
char'><span style='font-family:標楷體'>說明：</span> </p>
  <p style='layout-grid-mode:char'><b><span
style='font-family:標楷體'>決議：</span></b><b> </b></p>

</Content>

<TrackChangesSettings CanAcceptTrackChanges="False"></TrackChangesSettings>
            </telerik:RadEditor>
        </span></b>


<p style="line-height: 22pt;">
    <b><span lang="EN-US" style="font-size: 14pt;">肆、<span style="font: 7pt/normal &quot;Times New Roman&quot;; font-size-adjust: none; font-stretch: normal;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span><span style="font-family: 標楷體; font-size: 14pt;">臨時動議<telerik:RadEditor ID="RadEditor6" Runat="server" EditModes="Design" Height="170px" Width="100%">
                    <Tools>
                        <telerik:EditorToolGroup Tag="MainToolbar">
                            
                            <telerik:EditorSeparator />
                            <telerik:EditorSplitButton Name="Undo">
                            </telerik:EditorSplitButton>
                            <telerik:EditorSplitButton Name="Redo">
                            </telerik:EditorSplitButton>
                            <telerik:EditorSeparator />
                            <telerik:EditorTool Name="Cut" />
                            <telerik:EditorTool Name="Copy" />
                            <telerik:EditorTool Name="Paste" ShortCut="CTRL+V" />
                        </telerik:EditorToolGroup>
                        <telerik:EditorToolGroup Tag="Formatting">
                            <telerik:EditorTool Name="Bold" />
                            <telerik:EditorTool Name="Italic" />
                            <telerik:EditorTool Name="Underline" />
                            <telerik:EditorSeparator />
                            <telerik:EditorSplitButton Name="ForeColor">
                            </telerik:EditorSplitButton>
                            <telerik:EditorSplitButton Name="BackColor">
                            </telerik:EditorSplitButton>
                            <telerik:EditorDropDown Name="RealFontSize">
                            </telerik:EditorDropDown>
                            <telerik:EditorSeparator />
                        </telerik:EditorToolGroup>
                    </Tools>
<Content>
    
</Content>

<TrackChangesSettings CanAcceptTrackChanges="False"></TrackChangesSettings>
            </telerik:RadEditor>
        </span></b>
<p style="line-height: 22pt;">
    <b><span lang="EN-US" style="font-size: 14pt;">伍、<span style="font: 7pt/normal &quot;Times New Roman&quot;; font-size-adjust: none; font-stretch: normal;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span><span style="font-family: 標楷體; font-size: 14pt;">下次會議追蹤事項<telerik:RadEditor ID="RadEditor7" Runat="server" EditModes="Design" Height="170px" Width="100%">
                    <Tools>
                        <telerik:EditorToolGroup Tag="MainToolbar">
                            
                            <telerik:EditorSeparator />
                            <telerik:EditorSplitButton Name="Undo">
                            </telerik:EditorSplitButton>
                            <telerik:EditorSplitButton Name="Redo">
                            </telerik:EditorSplitButton>
                            <telerik:EditorSeparator />
                            <telerik:EditorTool Name="Cut" />
                            <telerik:EditorTool Name="Copy" />
                            <telerik:EditorTool Name="Paste" ShortCut="CTRL+V" />
                        </telerik:EditorToolGroup>
                        <telerik:EditorToolGroup Tag="Formatting">
                            <telerik:EditorTool Name="Bold" />
                            <telerik:EditorTool Name="Italic" />
                            <telerik:EditorTool Name="Underline" />
                            <telerik:EditorSeparator />
                            <telerik:EditorSplitButton Name="ForeColor">
                            </telerik:EditorSplitButton>
                            <telerik:EditorSplitButton Name="BackColor">
                            </telerik:EditorSplitButton>
                            <telerik:EditorDropDown Name="RealFontSize">
                            </telerik:EditorDropDown>
                            <telerik:EditorSeparator />
                        </telerik:EditorToolGroup>
                    </Tools>
<Content>
    
</Content>

<TrackChangesSettings CanAcceptTrackChanges="False"></TrackChangesSettings>
            </telerik:RadEditor>
        </span></b>
