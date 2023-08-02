<%@ Control Language="C#" AutoEventWireup="true" CodeFile="門診記錄表.ascx.cs" Inherits="UserControls_門診記錄表" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>


            <style type="text/css">
                .auto-style1 {
                    height: 79px;
                }
.RadPicker{vertical-align:middle}.RadPicker{vertical-align:middle}.rdfd_{position:absolute}.rdfd_{position:absolute}.RadPicker .rcTable{table-layout:auto}.RadPicker .rcTable{table-layout:auto}.RadPicker .RadInput{vertical-align:baseline}.RadPicker .RadInput{vertical-align:baseline}.RadInput_Default{font:12px "segoe ui",arial,sans-serif}.RadInput{vertical-align:middle}.RadInput_Default{font:12px "segoe ui",arial,sans-serif}.RadInput{vertical-align:middle}.RadInput .riTextBox{height:17px}.RadInput .riTextBox{height:17px}.RadPicker_Default .rcCalPopup{background-position:0 0}.RadPicker_Default .rcCalPopup{background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Calendar.sprite.gif')}.RadPicker .rcCalPopup{display:block;overflow:hidden;width:22px;height:22px;background-color:transparent;background-repeat:no-repeat;text-indent:-2222px;text-align:center;-webkit-box-sizing:content-box;-moz-box-sizing:content-box;box-sizing:content-box}.RadPicker_Default .rcCalPopup{background-position:0 0}.RadPicker_Default .rcCalPopup{background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Calendar.sprite.gif')}.RadPicker .rcCalPopup{display:block;overflow:hidden;width:22px;height:22px;background-color:transparent;background-repeat:no-repeat;text-indent:-2222px;text-align:center;-webkit-box-sizing:content-box;-moz-box-sizing:content-box;box-sizing:content-box}.RadPicker td a{position:relative;outline:0;z-index:2;margin:0 2px;text-decoration:none}.RadPicker td a{position:relative;outline:0;z-index:2;margin:0 2px;text-decoration:none}
                .auto-style2 {
                    height: 17px;
                }
                .auto-style3 {
                    height: 35px;
                }
            </style>


            <div class=WordSection1 style='layout-grid:18.0pt'>
  <table border=1 cellspacing=0 cellpadding=0 width=688>
    <tr>
      <td width=688 colspan=5 class="auto-style1"><p align=center style='text-align:center;
  line-height:22.0pt'><b><span
  style='font-size:15.0pt;font-family:標楷體'>高雄醫學大學附設中和紀念醫院</span></b><b><span
  style='font-size:15.0pt'> </span></b></p>
        <p align=center style='text-align:center;
  line-height:22.0pt'><b><span style='font-size:15.0pt;
  font-family:標楷體'>門診</span></b><b><span lang=EN-US style='font-size:15.0pt'>/</span></b><b><span
  style='font-size:15.0pt;font-family:標楷體'>診斷</span></b><b><span lang=EN-US
  style='font-size:15.0pt'>/</span></b><b><span style='font-size:15.0pt;
  font-family:標楷體'>手術</span></b><b><span lang=EN-US style='font-size:15.0pt'>/</span></b><b><span
  style='font-size:15.0pt;font-family:標楷體'>麻醉</span><span
  style='font-size:15.0pt'><span lang=EN-US style='font-size:15.0pt'>/</span><span
  style='font-size:15.0pt;font-family:標楷體'>查房</span> </span></b><b><span style='font-size:15.0pt;
  font-family:標楷體'>醫療</span></b><b><span lang=EN-US style='font-size:15.0pt'>/</span></b><b><span
  style='font-size:15.0pt;font-family:標楷體'>教學</span></b><b><span
  style='font-size:15.0pt'> </span></b><b><span style='font-size:15.0pt;
  font-family:標楷體'>記錄表</span></b><b><span style='font-size:15.0pt'> </span></b></p></td>
    </tr>
    <tr>
      <td width=277 colspan=3 rowspan=3><p style='line-height:12.0pt'><span style='font-size:14.0pt;
  font-family:標楷體'>教師職號：<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
          </span></p>
        <p style='line-height:12.0pt'><span style='font-size:14.0pt;
  font-family:標楷體'>教師姓名：<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            </span></p>
        <p style='line-height:13.0pt'><span style='font-size:14.0pt;
  font-family:標楷體'>
            <asp:RadioButton ID="RadioButton1" runat="server" GroupName="rectype" Text="門診" />
            ：</span><span style='font-size:14.0pt;
  font-family:標楷體'><asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            </span></p>
        <p style='line-height:13.0pt'><span style='font-size:14.0pt;
  font-family:標楷體'>
            <asp:RadioButton ID="RadioButton2" runat="server" GroupName="rectype" Text="檢查" />
            </span><span style='font-size:14.0pt;
  font-family:標楷體'>：</span><span style='font-size:14.0pt;
  font-family:標楷體'><asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            </span></p>
        <p style='line-height:13.0pt'><span style='font-size:14.0pt;
  font-family:標楷體'><span style='letter-spacing:-.8pt'><span style='font-size:14.0pt;
  font-family:標楷體'>
            <asp:RadioButton ID="RadioButton3" runat="server" GroupName="rectype" Text="麻醉" />
            </span>：</span></span><span style='font-size:14.0pt;
  font-family:標楷體'><asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
            </span></p>
        <p style='line-height:13.0pt'><span style='font-size:14.0pt;
  font-family:標楷體'><span style='font-size:14.0pt;
  font-family:標楷體'>
            <asp:RadioButton ID="RadioButton4" runat="server" GroupName="rectype" Text="手術" />
            </span>：</span><span style='font-size:14.0pt;
  font-family:標楷體'><asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
            </span></p>
        <p style='line-height:13.0pt'><span style='font-size:14.0pt;
  font-family:標楷體'><span style='font-size:14.0pt;
  font-family:標楷體'>
            <asp:RadioButton ID="RadioButton5" runat="server" GroupName="rectype" Text="查房" />
            </span>：</span><span style='font-size:14.0pt;
  font-family:標楷體'><asp:TextBox ID="TextBox13" runat="server"></asp:TextBox>
            </span></p>

      </td>
      <td width=60 class="auto-style3"><p align=center style='text-align:center'>&nbsp;</p></td>
      <td width=351 class="auto-style3">
          <telerik:RadDatePicker ID="RadDatePicker1" Runat="server" Visible="False">
          </telerik:RadDatePicker>
        </td>
    </tr>
    <tr>
      <td width=60 class="auto-style2"><p align=center style='text-align:center'>&nbsp;</p></td>
      <td width=351 class="auto-style2"><telerik:RadTimePicker ID="RadTimePicker1" Runat="server" Width="120px" Visible="False">
          </telerik:RadTimePicker>
      <br />
          <telerik:RadTimePicker ID="RadTimePicker2" Runat="server" Width="120px" Visible="False">
          </telerik:RadTimePicker>
          </td>
    </tr>
    <tr>
      <td width=60><p align=center style='text-align:center'><span
  style='font-family:標楷體'>地 點</span></p></td>
      <td width=351><span style='font-size:14.0pt;
  font-family:標楷體'><asp:TextBox ID="TextBox7" runat="server" Width="279px"></asp:TextBox>
            </span></td>
    </tr>
    <tr>
      <td width=98 rowspan=6><p align=center style='text-align:center'><span
  style='font-size:11.0pt;font-family:標楷體'>實際教學個案之診斷記錄</span></p>
        <p align=center style='text-align:center'><span
  style='font-family:標楷體'>（最多<span lang=EN-US>5</span>人）</span></p></td>
      <td width=120><p align=center style='text-align:center'><span
  style='font-size:14.0pt;font-family:標楷體'>病歷號碼</span></p></td>
      <td width=470 colspan=3><p align=center style='text-align:center'><span
  style='font-size:14.0pt;font-family:標楷體'>診斷</span></p></td>
    </tr>
    <tr>
      <td width=120><span style='font-size:14.0pt;
  font-family:標楷體'><asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
            </span></td>
      <td width=470 colspan=3>


            <telerik:RadEditor ID="RadEditor3" Runat="server" EditModes="Design" Height="126px" Width="427px">
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
                    <TrackChangesSettings CanAcceptTrackChanges="False" />
            </telerik:RadEditor>
        </td>
    </tr>
    <tr>
      <td width=120><span style='font-size:14.0pt;
  font-family:標楷體'><asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
            </span></td>
      <td width=470 colspan=3>


            <telerik:RadEditor ID="RadEditor4" Runat="server" EditModes="Design" Height="126px" Width="427px">
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
                    <TrackChangesSettings CanAcceptTrackChanges="False" />
            </telerik:RadEditor>
        </td>
    </tr>
    <tr>
      <td width=120><span style='font-size:14.0pt;
  font-family:標楷體'><asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
            </span></td>
      <td width=470 colspan=3>


            <telerik:RadEditor ID="RadEditor5" Runat="server" EditModes="Design" Height="126px" Width="427px">
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
                    <TrackChangesSettings CanAcceptTrackChanges="False" />
            </telerik:RadEditor>
        </td>
    </tr>
    <tr>
      <td width=120><span style='font-size:14.0pt;
  font-family:標楷體'><asp:TextBox ID="TextBox11" runat="server"></asp:TextBox>
            </span></td>
      <td width=470 colspan=3>


            <telerik:RadEditor ID="RadEditor6" Runat="server" EditModes="Design" Height="126px" Width="427px">
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
                    <TrackChangesSettings CanAcceptTrackChanges="False" />
            </telerik:RadEditor>
        </td>
    </tr>
    <tr>
      <td width=120><span style='font-size:14.0pt;
  font-family:標楷體'><asp:TextBox ID="TextBox12" runat="server"></asp:TextBox>
            </span></td>
      <td width=470 colspan=3>


            <telerik:RadEditor ID="RadEditor7" Runat="server" EditModes="Design" Height="126px" Width="427px">
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
                    <TrackChangesSettings CanAcceptTrackChanges="False" />
            </telerik:RadEditor>
        </td>
    </tr>
    <tr height=0>
      <td width=98></td>
      <td width=120></td>
      <td width=59></td>
      <td width=60></td>
      <td width=351></td>
    </tr>
  </table>
</div>
<p>
    <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="Red" Text="*門診/診斷/手術/麻醉/查房 醫療/教學 記錄表 <br>請記得在簽到名單加入老師為主講者，並加入老師做簽核確認"></asp:Label>
</p>
