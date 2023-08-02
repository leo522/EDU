<%@ Control Language="C#" AutoEventWireup="true" CodeFile="跨領域開會紀錄.ascx.cs" Inherits="UserControls_跨領域開會紀錄" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<style type="text/css">

    p.MsoNormal
	{margin-bottom:.0001pt;
	font-size:12.0pt;
	font-family:"Times New Roman","serif";
	    margin-left: 0cm;
        margin-right: 0cm;
        margin-top: 0cm;
    }
 table.MsoNormalTable
	{font-size:10.0pt;
	font-family:"Times New Roman","serif";
    }
    .shape {behavior:url(#default#VML);}
p.MsoFooter
	{margin-bottom:.0001pt;
	tab-stops:center 207.65pt right 415.3pt;
	layout-grid-mode:char;
	font-size:10.0pt;
	font-family:"Times New Roman","serif";
	    margin-left: 0cm;
        margin-right: 0cm;
        margin-top: 0cm;
    }
    .RadPicker{vertical-align:middle}.RadPicker{vertical-align:middle}.rdfd_{position:absolute}.rdfd_{position:absolute}.RadPicker .rcTable{table-layout:auto}.RadPicker .rcTable{table-layout:auto}.RadPicker .RadInput{vertical-align:baseline}.RadPicker .RadInput{vertical-align:baseline}.RadInput_Default{font:12px "segoe ui",arial,sans-serif}.RadInput{vertical-align:middle}.RadInput_Default{font:12px "segoe ui",arial,sans-serif}.RadInput{vertical-align:middle}.RadInput .riTextBox{height:17px}.RadInput .riTextBox{height:17px}.RadPicker_Default .rcCalPopup{background-position:0 0}.RadPicker_Default .rcCalPopup{background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Calendar.sprite.gif')}.RadPicker .rcCalPopup{display:block;overflow:hidden;width:22px;height:22px;background-color:transparent;background-repeat:no-repeat;text-indent:-2222px;text-align:center;-webkit-box-sizing:content-box;-moz-box-sizing:content-box;box-sizing:content-box}.RadPicker_Default .rcCalPopup{background-position:0 0}.RadPicker_Default .rcCalPopup{background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Calendar.sprite.gif')}.RadPicker .rcCalPopup{display:block;overflow:hidden;width:22px;height:22px;background-color:transparent;background-repeat:no-repeat;text-indent:-2222px;text-align:center;-webkit-box-sizing:content-box;-moz-box-sizing:content-box;box-sizing:content-box}.RadPicker td a{position:relative;outline:0;z-index:2;margin:0 2px;text-decoration:none}.RadPicker td a{position:relative;outline:0;z-index:2;margin:0 2px;text-decoration:none}
    div.WordSection1 {
	page: WordSection1;
}
.Default.reWrapper{border:1px solid #828282}.Default.RadEditor{background-color:#eee}.Default.reWrapper{border:1px solid #828282}.Default.RadEditor{background-color:#eee}.RadEditor{box-sizing:content-box;-moz-box-sizing:content-box}.RadEditor{box-sizing:content-box;-moz-box-sizing:content-box}.RadEditor *{box-sizing:content-box;-moz-box-sizing:content-box}.RadEditor *{box-sizing:content-box;-moz-box-sizing:content-box}.reWrapper_corner{font-size:1px;line-height:1px}.reWrapper_corner{font-size:1px;line-height:1px}.reWrapper_center{font-size:1px;line-height:1px}.reWrapper_center{font-size:1px;line-height:1px}.reLeftVerticalSide{padding:1px}.reLeftVerticalSide{font-size:1px;line-height:1px}.reLeftVerticalSide{padding:1px}.reLeftVerticalSide{font-size:1px;line-height:1px}.RadEditor.reWrapper .reToolCell{vertical-align:top;padding-bottom:1px}.RadEditor.reWrapper .reToolCell{vertical-align:top;padding-bottom:1px}.reToolbarWrapper{margin-top:0}.reToolbarWrapper{margin-top:0}.reRightVerticalSide{padding:1px}.reRightVerticalSide{font-size:1px;line-height:1px}.reRightVerticalSide{padding:1px}.reRightVerticalSide{font-size:1px;line-height:1px}.Default.RadEditor .reContentCell{background-color:white}.Default.RadEditor .reContentCell{border:1px solid #828282}.Default.RadEditor .reContentCell{background-color:white}.Default.RadEditor .reContentCell{border:1px solid #828282}.RadEditor .reContentCell{vertical-align:top}.RadEditor .reContentCell{vertical-align:top}.reContentCell{background-color:#fff}.reContentCell{background-color:#fff}.Default.RadEditor .reEditorModes{background-color:#eee}.Default.RadEditor .reEditorModes{background-color:#eee}.reEditorModes{float:left;padding:1px 0!important}.reEditorModes{float:left;padding:1px 0!important}.reBottomZone{text-align:right;vertical-align:bottom}.reBottomZone{text-align:right;vertical-align:bottom}.RadEditor .reResizeCell{vertical-align:bottom;text-align:right}.RadEditor .reResizeCell{vertical-align:bottom;text-align:right}
    .auto-style3 {
        width: 76px;
    }
    div.RadPicker table.rcSingle .rcInputCell{padding-right:0}div.RadPicker table.rcSingle .rcInputCell{padding-right:0}.RadPicker table.rcTable .rcInputCell{padding:0 4px 0 0}.RadPicker table.rcTable .rcInputCell{padding:0 4px 0 0}
    </style>
            <div class="WordSection1" style="-ms-layout-grid: both loose 18pt none;">
                <table border="1" cellpadding="0" cellspacing="0" width="728">

                    <tr>
                        <td colspan="5" valign="top">
                            <p style="text-align: justify; line-height: 15pt; -ms-text-justify: inter-ideograph;">
                                <asp:RadioButton ID="RadioButton1" runat="server" GroupName="meettype1" Text="晨報會" />
                                <asp:RadioButton ID="RadioButton2" runat="server" GroupName="meettype1" Text="臨床研討" />
                                <asp:RadioButton ID="RadioButton3" runat="server" GroupName="meettype1" Text="聯合討論" />
                                <asp:RadioButton ID="RadioButton4" runat="server" GroupName="meettype1" Text="文獻研討" />
                                <asp:RadioButton ID="RadioButton5" runat="server" GroupName="meettype1" Text="影像診療" />
                                <asp:RadioButton ID="RadioButton6" runat="server" GroupName="meettype1" Text="臨床病理" />
                            </p>
                            <p style="text-align: justify; line-height: 15pt; -ms-text-justify: inter-ideograph;">
                                <asp:RadioButton ID="RadioButton7" runat="server" GroupName="meettype1" Text="外科病理" />
                                <asp:RadioButton ID="RadioButton8" runat="server" GroupName="meettype1" Text="死亡及併發症" />
                                <asp:RadioButton ID="RadioButton9" runat="server" GroupName="meettype1" Text="主治醫師教學" />
                                <asp:RadioButton ID="RadioButton10" runat="server" GroupName="meettype1" Text="住院醫師教學" />
                            </p>
                            <p style="text-align: justify; line-height: 15pt; -ms-text-justify: inter-ideograph;">
                                <asp:RadioButton ID="RadioButton11" runat="server" GroupName="meettype1" Text="跨領域團隊會議" />
                                <asp:RadioButton ID="RadioButton12" runat="server" GroupName="meettype1" Text="其他" />
                            </p>
                        </td>
                        <td width="128">
                            <p align="center" style="text-align: center; -ms-layout-grid-mode: char;">
                                <b><span style="font-family: 標楷體; font-size: 14pt;">討論會</span></b></p>
                            <p align="center" style="text-align: center; -ms-layout-grid-mode: char;">
                                <b><span style="font-family: 標楷體; font-size: 14pt;">會議記錄</span></b></p>
                        </td>
                    </tr>
                    <tr>
                        <td width="76">
                            <p align="center" style="text-align: center;">
                                <span style="font-family: 標楷體;">日<span lang="EN-US">&nbsp; </span>期</span></p>
                        </td>
                        <td width="173">
          <telerik:RadDatePicker ID="RadDatePicker1" Runat="server">
          </telerik:RadDatePicker>
                        </td>
                        <td width="58">
                            <p align="center" style="text-align: center;">
                                <span style="font-family: 標楷體;">時間</span></p>
                        </td>
                        <td valign="top" width="172">
                            <table>
                                <tr>
                                    <td><span style="font-family: 標楷體;">起<span lang="EN-US">: </span></span></td>
                                    <td><telerik:RadTimePicker ID="RadTimePicker1" Runat="server" Width="120px">
          </telerik:RadTimePicker></td>
                                </tr>
                                <tr>
                                    <td><span style="font-family: 標楷體;">迄<span lang="EN-US">: </span></span></td>
                                    <td><telerik:RadTimePicker ID="RadTimePicker3" Runat="server" Width="120px">
          </telerik:RadTimePicker></td>
                                </tr>                                
                            </table>
                        </td>
                        <td class="auto-style3">
                            <p align="center" style="text-align: center;">
                                <span style="font-family: 標楷體;">地點</span></p>
                        </td>
                        <td width="195">
          <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="76">
                            <p align="center" style="text-align: center;">
                                <span style="font-family: 標楷體;">主持者</span></p>
                        </td>
                        <td  valign="center" width="173">
          <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                        </td>
                        <td width="58">
                            <p align="center" style="text-align: center;">
                                <span style="font-family: 標楷體;">授課</span></p>
                            <p align="center" style="text-align: center;">
                                <span style="font-family: 標楷體;">講演者</span></p>
                        </td>
                        <td valign="center" width="172">
          <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                        </td>
                        <td class="auto-style3">
                            <p align="center" style="text-align: center;">
                                <span style="font-family: 標楷體;">紀錄人</span></p>
                        </td>
                        <td valign="center" width="195">
          <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="76">
                            <p style="text-align: justify; -ms-text-justify: inter-ideograph;">
                                <span style="color: black; font-family: 標楷體;">其他教師</span></p>
                        </td>
                        <td colspan="5" width="652">
                            <p style="text-align: justify; line-height: 15pt; -ms-text-justify: inter-ideograph;">
                                <asp:CheckBox ID="CheckBox1" runat="server" Text="考評者" />
                                <span style="font-family: &quot;新細明體&quot;,&quot;serif&quot;;">
          <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                                <asp:CheckBox ID="CheckBox2" runat="server" Text="引言者" />
          <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
                                </span></p>
                            <p style="text-align: justify; line-height: 15pt; -ms-text-justify: inter-ideograph;">
                                <span style="font-family: &quot;新細明體&quot;,&quot;serif&quot;;">
                                <asp:CheckBox ID="CheckBox3" runat="server" Text="審查者" />
          <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
                                <asp:CheckBox ID="CheckBox4" runat="server" Text="指導者" />
          <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
                                </span></p>
                        </td>
                    </tr>
                    <tr>
                        <td width="76">
                            <p style="line-height: 14pt;">
                                <span style="font-family: 標楷體;">與會科別</span></p>
                        </td>
                        <td colspan="5" width="652">

            <telerik:RadEditor ID="RadEditor4" Runat="server" EditModes="Design" Height="74px" Width="547px">
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
            </telerik:RadEditor>
                        </td>
                    </tr>
                    <tr>
                        <td width="76">
                            <p align="center" style="text-align: center; line-height: 15pt;">
                                <span lang="EN-US" style="font-family: 標楷體; font-size: 10pt;">1.</span><span style="font-family: 標楷體; font-size: 10pt;">討論主題</span></p>
                            <p align="center" style="text-align: center; line-height: 15pt;">
                                <span lang="EN-US" style="font-family: 標楷體; font-size: 10pt;">2.</span><span style="font-family: 標楷體; font-size: 10pt;">參考文獻</span></p>
                            <p align="center" style="text-align: center; line-height: 15pt;">
                                <span lang="EN-US" style="font-family: 標楷體; font-size: 10pt;">3.</span><span style="background: rgb(217, 217, 217); font-family: 標楷體; font-size: 10pt;">病患資料</span></p>
                        </td>
                        <td colspan="5" width="652">

            <telerik:RadEditor ID="RadEditor3" Runat="server" EditModes="Design" Height="170px" Width="547px">
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
            </telerik:RadEditor>
                        </td>
                    </tr>
                    </table>
                <br clear="all" style="page-break-before: always;" />
                <table border="1" cellpadding="0" cellspacing="0" width="705">
                    <tr>
                        <td colspan="4" valign="top" width="705">
                            <p style="text-align: justify; -ms-text-justify: inter-ideograph;">
                                <span style="font-family: 標楷體;">討論內容摘要：</span></p>

            <telerik:RadEditor ID="RadEditor7" Runat="server" EditModes="Design" Height="170px" Width="547px">
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
            </telerik:RadEditor>
                            <br clear="all" style="page-break-before: always;" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" valign="top" width="705">
                            <p style="text-align: justify; -ms-text-justify: inter-ideograph;">
                                <b><span style="font-family: 標楷體;">關鍵詞：</span><span lang="EN-US">(</span><span style="font-family: 標楷體;">特殊會議才勾選，由會議主持人勾選，可複選</span><span lang="EN-US">)</span></b></p>
                            <p style="text-align: justify; -ms-text-justify: inter-ideograph;">
                                <asp:CheckBox ID="CheckBox5" runat="server" Text="醫療品質" />
                                <asp:CheckBox ID="CheckBox6" runat="server" Text="醫病溝通" />
                                <asp:CheckBox ID="CheckBox7" runat="server" Text="實證醫學" />
                                <asp:CheckBox ID="CheckBox8" runat="server" Text="病歷寫作" />
                                <asp:CheckBox ID="CheckBox9" runat="server" Text="醫學倫理與法律" />
                                <asp:CheckBox ID="CheckBox10" runat="server" Text="感染控制" />
                            </p>
                            <p style="text-align: justify; -ms-text-justify: inter-ideograph;">
                                <asp:CheckBox ID="CheckBox11" runat="server" Text="全人醫療" />
                                <asp:CheckBox ID="CheckBox12" runat="server" Text="病人安全" />
                                <asp:CheckBox ID="CheckBox13" runat="server" Text="病人權利" />
                                <asp:CheckBox ID="CheckBox14" runat="server" Text="基層與社區醫療" />
                                <asp:CheckBox ID="CheckBox15" runat="server" Text="醫學與臨床教育" />
                            </p>
                            <p style="text-align: justify; -ms-text-justify: inter-ideograph;">
                                <asp:CheckBox ID="CheckBox16" runat="server" Text="預防醫學及觀念" />
                                <asp:CheckBox ID="CheckBox17" runat="server" Checked="True" Text="醫療模式及團隊" />
                                <asp:CheckBox ID="CheckBox18" runat="server" Text="危機管理" />
                                <asp:CheckBox ID="CheckBox19" runat="server" Text="其他" />
                                <span style="font-family: &quot;新細明體&quot;,&quot;serif&quot;;">
          <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
                                </span>
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" valign="top" width="705">
                            <p>
                                <span style="font-family: 標楷體;">主席<span lang="EN-US">(</span>主治醫師<span lang="EN-US">)</span>簽註意見：<telerik:RadEditor ID="RadEditor8" Runat="server" EditModes="Design" Height="170px" Width="547px">
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
            </telerik:RadEditor>
                            </span>
                            <p align="right" style="text-align: right; -ms-word-break: break-all;">
                                <span style="font-family: 標楷體;">簽名：<u><span lang="EN-US">&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></u><span lang="EN-US">&nbsp;</span></span></p>
                        </td>
                    </tr>
                    <tr>
                        <td width="69">
                            <p align="center" style="text-align: center;">
                                <span style="font-family: 標楷體;">附<span lang="EN-US">&nbsp; </span>件</span></p>
                        </td>
                        <td width="96">
                            <p style="text-align: justify; -ms-text-justify: inter-ideograph;">
                                <span style="font-family: 標楷體;">
                                <asp:CheckBox ID="CheckBox20" runat="server" Text="書面資料" />
                                </span></p>
                        </td>
                        <td width="291">
                            <p style="text-align: justify; -ms-text-justify: inter-ideograph;">
                                <span style="font-family: 標楷體;">
                                <asp:CheckBox ID="CheckBox21" runat="server" Text="電子檔資料" />
                                <span lang="EN-US">(</span>檔名：<span style="font-family: &quot;新細明體&quot;,&quot;serif&quot;;"><asp:TextBox ID="TextBox11" runat="server" Width="109px"></asp:TextBox>
                                </span><span lang="EN-US">)</span></span></p>
                        </td>
                        <td width="249">
                            <p style="text-align: justify; -ms-text-justify: inter-ideograph;">
                                <span style="font-family: 標楷體;">
                                <asp:CheckBox ID="CheckBox22" runat="server" Text="其他" />
                                ：<span style="font-family: &quot;新細明體&quot;,&quot;serif&quot;;"><asp:TextBox ID="TextBox12" runat="server" Width="109px"></asp:TextBox>
                                </span></span>
                            </p>
                        </td>
                    </tr>
                </table>
                <p style="line-height: 12pt; -ms-layout-grid-mode: char;">
                    <b><span style="font-family: 標楷體;">病人姓名：<span style="font-family: &quot;新細明體&quot;,&quot;serif&quot;;"><asp:TextBox ID="TextBox13" runat="server" Width="109px"></asp:TextBox>
                        </span>性別：<span style="font-family: &quot;新細明體&quot;,&quot;serif&quot;;"><asp:TextBox ID="TextBox14" runat="server" Width="39px"></asp:TextBox>
                        </span>年齡：<span style="font-family: &quot;新細明體&quot;,&quot;serif&quot;;"><asp:TextBox ID="TextBox15" runat="server" Width="29px"></asp:TextBox>
                        </span>床號 ：<span style="font-family: &quot;新細明體&quot;,&quot;serif&quot;;"><asp:TextBox ID="TextBox16" runat="server" Width="29px"></asp:TextBox>
                        </span>病歷號碼：<span style="font-family: &quot;新細明體&quot;,&quot;serif&quot;;"><asp:TextBox ID="TextBox17" runat="server" Width="87px"></asp:TextBox>
                        </span></span></b>
                
                    <table>
                        <tr>
                            <td><p style="line-height: 12pt; -ms-layout-grid-mode: char;"><b><span style="font-family: 標楷體;">開會日期：</span></b></p></td>
                            <td><telerik:RadDatePicker ID="RadDatePicker2" Runat="server"></telerik:RadDatePicker></td>
                        </tr>
                    </table>
                    
          
                        
                <span style="background: rgb(217, 217, 217); font-family: 標楷體;">各醫事職類建議：</span>
                <table border="1" cellpadding="0" cellspacing="0">
                    <tr>
                        <td valign="top" width="684">
                            <p style="line-height: 12pt;">
                                <span style="font-family: 標楷體;">牙醫師：<telerik:RadEditor ID="RadEditor9" Runat="server" EditModes="Design" Height="74px" Width="547px">
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
            </telerik:RadEditor>
                            </span>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" width="684">
                            <p style="line-height: 12pt;">
                                <span style="font-family: 標楷體;">中醫師：<telerik:RadEditor ID="RadEditor10" Runat="server" EditModes="Design" Height="74px" Width="547px">
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
            </telerik:RadEditor>
                            </span>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" width="684">
                            <p style="line-height: 12pt;">
                                <span style="font-family: 標楷體;">護理師：<telerik:RadEditor ID="RadEditor11" Runat="server" EditModes="Design" Height="74px" Width="547px">
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
            </telerik:RadEditor>
                            </span>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" width="684">
                            <p style="line-height: 12pt;">
                                <span style="font-family: 標楷體;">藥師：<telerik:RadEditor ID="RadEditor12" Runat="server" EditModes="Design" Height="74px" Width="547px">
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
            </telerik:RadEditor>
                            </span>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" width="684">
                            <p style="line-height: 12pt;">
                                <span style="font-family: 標楷體;">營養師：<telerik:RadEditor ID="RadEditor13" Runat="server" EditModes="Design" Height="74px" Width="547px">
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
            </telerik:RadEditor>
                            </span>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" width="684">
                            <p style="line-height: 12pt;">
                                <span style="font-family: 標楷體;">檢驗師：<telerik:RadEditor ID="RadEditor14" Runat="server" EditModes="Design" Height="74px" Width="547px">
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
            </telerik:RadEditor>
                            </span>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" width="684">
                            <p style="line-height: 12pt;">
                                <span style="font-family: 標楷體;">放射師：<telerik:RadEditor ID="RadEditor15" Runat="server" EditModes="Design" Height="74px" Width="547px">
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
            </telerik:RadEditor>
                            </span>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" width="684">
                            <p style="line-height: 12pt;">
                                <span style="font-family: 標楷體;">呼吸治療師：<telerik:RadEditor ID="RadEditor16" Runat="server" EditModes="Design" Height="74px" Width="547px">
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
            </telerik:RadEditor>
                            </span>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" width="684">
                            <p style="line-height: 12pt;">
                                <span style="font-family: 標楷體;">臨床心理師：<telerik:RadEditor ID="RadEditor17" Runat="server" EditModes="Design" Height="74px" Width="547px">
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
            </telerik:RadEditor>
                            </span>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" width="684">
                            <p style="line-height: 12pt;">
                                <span style="font-family: 標楷體;">物理治療師：<telerik:RadEditor ID="RadEditor18" Runat="server" EditModes="Design" Height="74px" Width="547px">
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
            </telerik:RadEditor>
                            </span>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" width="684">
                            <p style="line-height: 12pt;">
                                <span style="font-family: 標楷體;">職能治療師：<telerik:RadEditor ID="RadEditor19" Runat="server" EditModes="Design" Height="74px" Width="547px">
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
            </telerik:RadEditor>
                            </span>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" width="684">
                            <p style="line-height: 12pt;">
                                <span style="font-family: 標楷體;">社工師：<telerik:RadEditor ID="RadEditor20" Runat="server" EditModes="Design" Height="74px" Width="547px">
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
            </telerik:RadEditor>
                            </span>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" width="684">
                            <p style="line-height: 12pt;">
                                <span style="font-family: 標楷體;">其他：<telerik:RadEditor ID="RadEditor21" Runat="server" EditModes="Design" Height="74px" Width="547px">
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
            </telerik:RadEditor>
                            </span>
                        </td>
                    </tr>
                </table>
</div>





