<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DisplayRadEditor.ascx.cs" Inherits="DisplayRadEditor" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<style type="text/css">
.Default.reWrapper{border:1px solid #828282}.Default.RadEditor{background-color:#eee}.Default.reWrapper{border:1px solid #828282}.Default.RadEditor{background-color:#eee}.Default.reWrapper{border:1px solid #828282}.Default.RadEditor{background-color:#eee}.Default.reWrapper{border:1px solid #828282}.Default.RadEditor{background-color:#eee}.Default.RadEditor{background-color:#eee}.Default.reWrapper{border:1px solid #828282}.Default.RadEditor{background-color:#eee}.Default.reWrapper{border:1px solid #828282}.RadEditor{box-sizing:content-box;-moz-box-sizing:content-box}.RadEditor{box-sizing:content-box;-moz-box-sizing:content-box}.RadEditor{box-sizing:content-box;-moz-box-sizing:content-box}.RadEditor{box-sizing:content-box;-moz-box-sizing:content-box}.RadEditor{box-sizing:content-box;-moz-box-sizing:content-box}.RadEditor{box-sizing:content-box;-moz-box-sizing:content-box}.RadEditor *{box-sizing:content-box;-moz-box-sizing:content-box}.RadEditor *{box-sizing:content-box;-moz-box-sizing:content-box}.RadEditor *{box-sizing:content-box;-moz-box-sizing:content-box}.RadEditor *{box-sizing:content-box;-moz-box-sizing:content-box}.RadEditor *{box-sizing:content-box;-moz-box-sizing:content-box}.RadEditor *{box-sizing:content-box;-moz-box-sizing:content-box}.RadEditor table.reLayoutWrapper{border-collapse:collapse;table-layout:auto}.RadEditor table.reLayoutWrapper{border-collapse:collapse;table-layout:auto}.RadEditor table.reLayoutWrapper{border-collapse:collapse;table-layout:auto}.RadEditor table.reLayoutWrapper{border-collapse:collapse;table-layout:auto}.RadEditor table{border:0;padding:0}.RadEditor table{border:0;padding:0}.RadEditor table{border:0;padding:0}.RadEditor table{border:0;padding:0}.RadEditor.reWrapper table td{border:0;padding:0}.RadEditor.reWrapper table td{border:0;padding:0}.RadEditor.reWrapper table td{border:0;padding:0}.RadEditor.reWrapper table td{border:0;padding:0}.reWrapper_corner{font-size:1px;line-height:1px}.reWrapper_corner{font-size:1px;line-height:1px}.reWrapper_corner{font-size:1px;line-height:1px}.reWrapper_corner{font-size:1px;line-height:1px}.reWrapper_corner{font-size:1px;line-height:1px}.reWrapper_corner{font-size:1px;line-height:1px}.reWrapper_center{font-size:1px;line-height:1px}.reWrapper_center{font-size:1px;line-height:1px}.reWrapper_center{font-size:1px;line-height:1px}.reWrapper_center{font-size:1px;line-height:1px}.reWrapper_center{font-size:1px;line-height:1px}.reWrapper_center{font-size:1px;line-height:1px}.reLeftVerticalSide{padding:1px}.reLeftVerticalSide{font-size:1px;line-height:1px}.reLeftVerticalSide{padding:1px}.reLeftVerticalSide{font-size:1px;line-height:1px}.reLeftVerticalSide{padding:1px}.reLeftVerticalSide{font-size:1px;line-height:1px}.reLeftVerticalSide{padding:1px}.reLeftVerticalSide{font-size:1px;line-height:1px}.reLeftVerticalSide{font-size:1px;line-height:1px}.reLeftVerticalSide{padding:1px}.reLeftVerticalSide{font-size:1px;line-height:1px}.reLeftVerticalSide{padding:1px}td.reTlbVertical{vertical-align:top}td.reTlbVertical{vertical-align:top}td.reTlbVertical{vertical-align:top}td.reTlbVertical{vertical-align:top}.RadEditor.reWrapper .reToolCell{vertical-align:top;padding-bottom:1px}.RadEditor.reWrapper .reToolCell{vertical-align:top;padding-bottom:1px}.RadEditor.reWrapper .reToolCell{vertical-align:top;padding-bottom:1px}.RadEditor.reWrapper .reToolCell{vertical-align:top;padding-bottom:1px}.RadEditor.reWrapper .reToolCell{vertical-align:top;padding-bottom:1px}.RadEditor.reWrapper .reToolCell{vertical-align:top;padding-bottom:1px}.reToolbarWrapper{margin-top:0}.reToolbarWrapper{margin-top:0}.reToolbarWrapper{margin-top:0}.reToolbarWrapper{margin-top:0}.reToolbarWrapper{margin-top:0}.reToolbarWrapper{margin-top:0}.reRightVerticalSide{padding:1px}.reRightVerticalSide{font-size:1px;line-height:1px}.reRightVerticalSide{padding:1px}.reRightVerticalSide{font-size:1px;line-height:1px}.reRightVerticalSide{padding:1px}.reRightVerticalSide{font-size:1px;line-height:1px}.reRightVerticalSide{padding:1px}.reRightVerticalSide{font-size:1px;line-height:1px}.reRightVerticalSide{font-size:1px;line-height:1px}.reRightVerticalSide{padding:1px}.reRightVerticalSide{font-size:1px;line-height:1px}.reRightVerticalSide{padding:1px}.Default.RadEditor .reContentCell{background-color:white}.Default.RadEditor .reContentCell{border:1px solid #828282}.Default.RadEditor .reContentCell{background-color:white}.Default.RadEditor .reContentCell{border:1px solid #828282}.Default.RadEditor .reContentCell{background-color:white}.Default.RadEditor .reContentCell{border:1px solid #828282}.Default.RadEditor .reContentCell{background-color:white}.Default.RadEditor .reContentCell{border:1px solid #828282}.Default.RadEditor .reContentCell{border:1px solid #828282}.Default.RadEditor .reContentCell{background-color:white}.Default.RadEditor .reContentCell{border:1px solid #828282}.Default.RadEditor .reContentCell{background-color:white}.RadEditor .reContentCell{vertical-align:top}.RadEditor .reContentCell{vertical-align:top}.RadEditor .reContentCell{vertical-align:top}.RadEditor .reContentCell{vertical-align:top}.RadEditor .reContentCell{vertical-align:top}.RadEditor .reContentCell{vertical-align:top}.reContentCell{background-color:#fff}.reContentCell{background-color:#fff}.reContentCell{background-color:#fff}.reContentCell{background-color:#fff}.reContentCell{background-color:#fff}.reContentCell{background-color:#fff}.RadEditor table.reBottomTable{border-collapse:collapse}.RadEditor table.reBottomTable{border-collapse:collapse}.RadEditor table.reBottomTable{border-collapse:collapse}.RadEditor table.reBottomTable{border-collapse:collapse}.Default.RadEditor .reEditorModes{background-color:#eee}.Default.RadEditor .reEditorModes{background-color:#eee}.Default.RadEditor .reEditorModes{background-color:#eee}.Default.RadEditor .reEditorModes{background-color:#eee}.Default.RadEditor .reEditorModes{background-color:#eee}.Default.RadEditor .reEditorModes{background-color:#eee}.reEditorModes{float:left;padding:1px 0!important}.reEditorModes{float:left;padding:1px 0!important}.reEditorModes{float:left;padding:1px 0!important}.reEditorModes{float:left;padding:1px 0!important}.reEditorModes{float:left;padding:1px 0!important}.reEditorModes{float:left;padding:1px 0!important}.reBottomZone{text-align:right;vertical-align:bottom}.reBottomZone{text-align:right;vertical-align:bottom}.reBottomZone{text-align:right;vertical-align:bottom}.reBottomZone{text-align:right;vertical-align:bottom}.reBottomZone{text-align:right;vertical-align:bottom}.reBottomZone{text-align:right;vertical-align:bottom}.RadEditor .reResizeCell{vertical-align:bottom;text-align:right}.RadEditor .reResizeCell{vertical-align:bottom;text-align:right}.RadEditor .reResizeCell{vertical-align:bottom;text-align:right}.RadEditor .reResizeCell{vertical-align:bottom;text-align:right}.RadEditor .reResizeCell{vertical-align:bottom;text-align:right}
                .RadEditor .reResizeCell{vertical-align:bottom;text-align:right}.Default .reResizeCell div{background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Editor.ToolbarSprites.gif')}.Default .reResizeCell div{background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Editor.ToolbarSprites.gif')}.Default .reResizeCell div{background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Editor.ToolbarSprites.gif')}.Default .reResizeCell div{background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Editor.ToolbarSprites.gif')}.reResizeCell div{background-repeat:no-repeat;background-position:center -301px;height:17px;width:16px}.reResizeCell div{background-repeat:no-repeat;background-position:center -301px;height:17px;width:16px}.reResizeCell div{background-repeat:no-repeat;background-position:center -301px;height:17px;width:16px}.reResizeCell div{background-repeat:no-repeat;background-position:center -301px;height:17px;width:16px}</style>
    <b><span style="font-family: 標楷體; font-size: 14pt;"><telerik:RadEditor ID="reEditor" Runat="server" EditModes="Design" Height="170px" Width="100%">
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

<asp:Literal ID="lbDisplay" runat="server" Visible="False"></asp:Literal>

