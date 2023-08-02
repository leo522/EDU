<%@ Control Language="C#" AutoEventWireup="true" CodeFile="醫學倫理法律討論記錄.ascx.cs" Inherits="UserControls_醫學倫理法律討論記錄" %>
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
    .auto-style1 {
        width: 312px;
    }
</style>
            <div class=WordSection1 style='layout-grid:18.0pt'>
  <p align=center style='text-align:center;layout-grid-mode:char'><b><span
style='font-size:18.0pt;font-family:標楷體'>醫學倫理法律討論紀錄</span></b></p>
  <table border=1 cellspacing=0 cellpadding=0>
    <tr>
      <td width=619 colspan=6 valign=top bgcolor="#E6E6E6"><p align=center style='text-align:center;layout-grid-mode:
  char'><b><span style='font-size:16.0pt;font-family:標楷體'>個案基本資料</span></b></p></td>
    </tr>
    <tr>
      <td width=115 valign=top><p align=center style='text-align:center;line-height:150%'><b><span
  style='font-size:14.0pt;line-height:150%;font-family:標楷體'>姓<span lang=EN-US>    </span>名</span></b></p></td>
      <td width=130 valign=top>
          <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </td>
      <td width=64 valign=top><p align=center style='text-align:center;line-height:150%'><b><span
  style='font-size:14.0pt;line-height:150%;font-family:標楷體'>年齡</span></b></p></td>
      <td width=82 valign=top>
          <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </td>
      <td width=101 valign=top><p align=center style='text-align:center;line-height:150%'><b><span
  style='font-size:14.0pt;line-height:150%;font-family:標楷體'>床<span lang=EN-US>    </span>號</span></b></p></td>
      <td width=127 valign=top>
          <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
      <td width=115 valign=top><p align=center style='text-align:center;line-height:150%'><b><span
  style='font-size:14.0pt;line-height:150%;font-family:標楷體'>病歷號碼</span></b></p></td>
      <td width=130 valign=top>
          <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        </td>
      <td width=64 valign=top><p align=center style='text-align:center;line-height:150%'><b><span
  style='font-size:14.0pt;line-height:150%;font-family:標楷體'>性別</span></b></p></td>
      <td width=82 valign=top>
          <asp:RadioButton ID="RadioButton1" runat="server" GroupName="sex" Text="男" />
          <asp:RadioButton ID="RadioButton2" runat="server" GroupName="sex" Text="女" />
        </td>
      <td width=101 valign=top><p align=center style='text-align:center;line-height:150%'><b><span
  style='font-size:14.0pt;line-height:150%;font-family:標楷體'>入院日期</span></b></p></td>
      <td width=127 valign=top>
          <telerik:RadDatePicker ID="RadDatePicker1" Runat="server">
          </telerik:RadDatePicker>
        </td>
    </tr>
    <tr>
      <td width=115 valign=top><p align=center style='text-align:center;layout-grid-mode:
  char'><b><span style='font-size:14.0pt;font-family:標楷體'>本次入院</span></b></p>
        <p align=center style='text-align:center;layout-grid-mode:
  char'><b><span style='font-size:14.0pt;font-family:標楷體'>主要問題</span></b></p></td>
      <td width=504 colspan=5 valign=top>
            <telerik:RadEditor ID="RadEditor2" Runat="server" EditModes="Design" Height="119px" Width="739px">
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
  <table border=1 cellspacing=0 cellpadding=0>
    <tr>
      <td width=619 colspan=2 valign=top bgcolor="#E6E6E6"><p align=center style='text-align:center;layout-grid-mode:
  char'><b><span style='font-size:14.0pt;font-family:標楷體'>討論主題</span></b></p></td>
    </tr>
    <tr>
      <td width=619 colspan=2 valign=top>
            <telerik:RadEditor ID="RadEditor3" Runat="server" EditModes="Design" Height="113px" Width="875px">
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
      <td width=619 colspan=2 valign=top bgcolor="#E6E6E6"><p align=center style='text-align:center;layout-grid-mode:
  char'><b><span style='font-size:14.0pt;font-family:標楷體'>醫療現狀<span lang=EN-US> (Medical indications for intervention)</span></span></b></p></td>
    </tr>
    <tr>
      <td valign=top class="auto-style1"><p style='text-align:justify;text-justify:
  inter-ideograph;'><span lang=EN-US style='font-size:10.0pt;
  font-family:&quot;新細明體&quot;,&quot;serif&quot;;color:black'>1.<span style='font:7.0pt "Times New Roman"'>&nbsp; </span></span><span style='font-size:10.0pt;font-family:&quot;新細明體&quot;,&quot;serif&quot;;
  color:black'>病人的病史、現在主要問題、診斷及預後？</span></p>
        <p style='text-align:justify;text-justify:
  inter-ideograph;'><span lang=EN-US style='font-size:10.0pt;
  font-family:&quot;新細明體&quot;,&quot;serif&quot;;color:black'>2.<span style='font:7.0pt "Times New Roman"'>&nbsp; </span></span><span style='font-size:10.0pt;font-family:&quot;新細明體&quot;,&quot;serif&quot;;
  color:black'>問題是急性或是慢性？是緊急的？重要的？是否可能回復？</span></p>
        <p style='text-align:justify;text-justify:
  inter-ideograph;'><span lang=EN-US style='font-size:10.0pt;
  font-family:&quot;新細明體&quot;,&quot;serif&quot;;color:black'>3.<span style='font:7.0pt "Times New Roman"'>&nbsp; </span></span><span style='font-size:10.0pt;font-family:&quot;新細明體&quot;,&quot;serif&quot;;
  color:black'>治療的目標何在？</span></p>
        <p style='text-align:justify;text-justify:
  inter-ideograph;'><span lang=EN-US style='font-size:10.0pt;
  font-family:&quot;新細明體&quot;,&quot;serif&quot;;color:black'>4.<span style='font:7.0pt "Times New Roman"'>&nbsp; </span></span><span style='font-size:10.0pt;font-family:&quot;新細明體&quot;,&quot;serif&quot;;
  color:black'>治療成功的可能性為何？</span></p>
        <p style='text-align:justify;text-justify:
  inter-ideograph;'><span lang=EN-US style='font-size:10.0pt;
  font-family:&quot;新細明體&quot;,&quot;serif&quot;;color:black'>5.<span style='font:7.0pt "Times New Roman"'>&nbsp; </span></span><span style='font-size:10.0pt;font-family:&quot;新細明體&quot;,&quot;serif&quot;;
  color:black'>如果治療失敗，有任何應變之計畫否？</span></p>
        <p style='text-align:justify;text-justify:
  inter-ideograph;'><span lang=EN-US style='font-size:9.0pt;
  font-family:標楷體'>6.</span><span style='font-size:10.0pt;
  font-family:&quot;新細明體&quot;,&quot;serif&quot;;color:black'>總而言之，病人如何由醫療及護理照顧而獲益，如何去避免對病人之傷害？</span></p></td>
      <td width=347 valign=top>
            <telerik:RadEditor ID="RadEditor4" Runat="server" EditModes="Design" Height="199px" Width="565px">
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
      <td width=619 colspan=2 valign=top bgcolor="#E6E6E6"><p align=center style='text-align:center;layout-grid-mode:
  char'><b><span style='font-size:14.0pt;font-family:標楷體'>病人抉擇<span lang=EN-US> (Preference of the patient) </span></span></b></p></td>
    </tr>
    <tr>
      <td valign=top class="auto-style1"><p style='text-align:justify;text-justify:
  inter-ideograph;'><span lang=EN-US style='font-size:10.0pt;
  font-family:&quot;新細明體&quot;,&quot;serif&quot;;color:black'>1.<span style='font:7.0pt "Times New Roman"'>&nbsp; </span></span><span style='font-size:10.0pt;font-family:&quot;新細明體&quot;,&quot;serif&quot;;
  color:black'>病人是否心智未失能且在法律上有行為能力？是否有行為能加缺失之證據？</span></p>
        <p style='text-align:justify;text-justify:
  inter-ideograph;'><span lang=EN-US style='font-size:10.0pt;
  font-family:&quot;新細明體&quot;,&quot;serif&quot;;color:black'>2.<span style='font:7.0pt "Times New Roman"'>&nbsp; </span></span><span style='font-size:10.0pt;font-family:&quot;新細明體&quot;,&quot;serif&quot;;
  color:black'>如果病人具行為能力，他對治療之抉擇為何？</span></p>
        <p style='text-align:justify;text-justify:
  inter-ideograph;'><span lang=EN-US style='font-size:10.0pt;
  font-family:&quot;新細明體&quot;,&quot;serif&quot;;color:black'>3.<span style='font:7.0pt "Times New Roman"'>&nbsp; </span></span><span style='font-size:10.0pt;font-family:&quot;新細明體&quot;,&quot;serif&quot;;
  color:black'>病人是否被告知治療之好處及危險，能了解資訊，並給予同意？</span></p>
        <p style='text-align:justify;text-justify:
  inter-ideograph;'><span lang=EN-US style='font-size:10.0pt;
  font-family:&quot;新細明體&quot;,&quot;serif&quot;;color:black'>4.<span style='font:7.0pt "Times New Roman"'>&nbsp; </span></span><span style='font-size:10.0pt;font-family:&quot;新細明體&quot;,&quot;serif&quot;;
  color:black'>如果病人無行為能力，則誰是合適之法定代理人？此代理者是否以合宜之標準作決定？</span></p>
        <p style='text-align:justify;text-justify:
  inter-ideograph;'><span lang=EN-US style='font-size:10.0pt;
  font-family:&quot;新細明體&quot;,&quot;serif&quot;;color:black'>5.<span style='font:7.0pt "Times New Roman"'>&nbsp; </span></span><span style='font-size:10.0pt;font-family:&quot;新細明體&quot;,&quot;serif&quot;;
  color:black'>病人在前是否表示過其喜好？如預留醫囑？</span></p>
        <p style='text-align:justify;text-justify:
  inter-ideograph;'><span lang=EN-US style='font-size:10.0pt;
  color:black'>6.<span style='font:7.0pt "Times New Roman"'> </span></span><span
  style='font-size:10.0pt;font-family:"新細明體","serif";color:black'>病人是否無意或無法配合進行醫囑？為什麼會這樣？總而言之，病人選擇之權益是否在法律及倫理上之最大可能範圍內受到傷害？</span></p></td>
      <td width=347 valign=top>
            <telerik:RadEditor ID="RadEditor5" Runat="server" EditModes="Design" Height="238px" Width="565px">
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
      <td width=619 colspan=2 valign=top bgcolor="#E6E6E6"><p align=center style='text-align:center;layout-grid-mode:
  char'><b><span style='font-size:14.0pt;font-family:標楷體'>生命品質<span lang=EN-US> (Quality of life)</span></span></b></p></td>
    </tr>
    <tr>
      <td valign=top class="auto-style1"><p style='text-align:justify;text-justify:
  inter-ideograph;'><span lang=EN-US style='font-size:10.0pt;
  font-family:&quot;新細明體&quot;,&quot;serif&quot;;color:black'>1.<span style='font:7.0pt "Times New Roman"'>&nbsp; </span></span><span style='font-size:10.0pt;font-family:&quot;新細明體&quot;,&quot;serif&quot;;
  color:black'>治療和不治療，其恢復正常生活之機率為何？</span></p>
        <p style='text-align:justify;text-justify:
  inter-ideograph;'><span lang=EN-US style='font-size:10.0pt;
  font-family:&quot;新細明體&quot;,&quot;serif&quot;;color:black'>2.<span style='font:7.0pt "Times New Roman"'>&nbsp; </span></span><span style='font-size:10.0pt;font-family:&quot;新細明體&quot;,&quot;serif&quot;;
  color:black'>如果治療成功，病人會承受何種身體、心理及社會上之缺失？</span></p>
        <p style='text-align:justify;text-justify:
  inter-ideograph;'><span lang=EN-US style='font-size:10.0pt;
  font-family:&quot;新細明體&quot;,&quot;serif&quot;;color:black'>3.<span style='font:7.0pt "Times New Roman"'>&nbsp; </span></span><span style='font-size:10.0pt;font-family:&quot;新細明體&quot;,&quot;serif&quot;;
  color:black'>是否有任何偏見，可能誤導醫療提供者對病人生活品質之判定？</span></p>
        <p style='text-align:justify;text-justify:
  inter-ideograph;'><span lang=EN-US style='font-size:10.0pt;
  font-family:&quot;新細明體&quot;,&quot;serif&quot;;color:black'>4.<span style='font:7.0pt "Times New Roman"'>&nbsp; </span></span><span style='font-size:10.0pt;font-family:&quot;新細明體&quot;,&quot;serif&quot;;
  color:black'>病人目前和以後之情況，如果他的生活延續下去，是否可能被判定是病人不願意去過的？</span></p>
        <p style='text-align:justify;text-justify:
  inter-ideograph;'><span lang=EN-US style='font-size:10.0pt;
  font-family:&quot;新細明體&quot;,&quot;serif&quot;;color:black'>5.<span style='font:7.0pt "Times New Roman"'>&nbsp; </span></span><span style='font-size:10.0pt;font-family:&quot;新細明體&quot;,&quot;serif&quot;;
  color:black'>對上述情況，有無任何之學理根據或計畫去進行治療？</span></p>
        <p style='text-align:justify;text-justify:
  inter-ideograph;'><span lang=EN-US style='font-size:9.0pt;
  font-family:標楷體;color:black'>6.</span><span style='font-size:10.0pt;
  font-family:&quot;新細明體&quot;,&quot;serif&quot;;color:black'>是否有令病人較舒服或安寧療護之治療計畫？</span></p></td>
      <td width=347 valign=top>
            <telerik:RadEditor ID="RadEditor6" Runat="server" EditModes="Design" Height="258px" Width="564px">
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
      <td width=619 colspan=2 valign=top bgcolor="#E6E6E6"><p align=center style='text-align:center;layout-grid-mode:
  char'><b><span style='font-size:14.0pt;font-family:標楷體'>社會脈絡<span lang=EN-US> (Contextual issues)</span></span></b></p></td>
    </tr>
    <tr>
      <td valign=top class="auto-style1"><p style='text-align:justify;text-justify:
  inter-ideograph;'><span lang=EN-US style='font-size:10.0pt;
  font-family:&quot;新細明體&quot;,&quot;serif&quot;;color:black'>1.<span style='font:7.0pt "Times New Roman"'>&nbsp; </span></span><span style='font-size:10.0pt;font-family:&quot;新細明體&quot;,&quot;serif&quot;;
  color:black'>是否有家庭或家族因素可能影響治療？</span></p>
        <p style='text-align:justify;text-justify:
  inter-ideograph;'><span lang=EN-US style='font-size:10.0pt;
  font-family:&quot;新細明體&quot;,&quot;serif&quot;;color:black'>2.<span style='font:7.0pt "Times New Roman"'>&nbsp; </span></span><span style='font-size:10.0pt;font-family:&quot;新細明體&quot;,&quot;serif&quot;;
  color:black'>是否有醫療提供者（醫護人員）的因素可能影響治療之決定？</span></p>
        <p style='text-align:justify;text-justify:
  inter-ideograph;'><span lang=EN-US style='font-size:10.0pt;
  font-family:&quot;新細明體&quot;,&quot;serif&quot;;color:black'>3.<span style='font:7.0pt "Times New Roman"'>&nbsp; </span></span><span style='font-size:10.0pt;font-family:&quot;新細明體&quot;,&quot;serif&quot;;
  color:black'>是否有經濟上之問題？</span></p>
        <p style='text-align:justify;text-justify:
  inter-ideograph;'><span lang=EN-US style='font-size:10.0pt;
  font-family:&quot;新細明體&quot;,&quot;serif&quot;;color:black'>4.<span style='font:7.0pt "Times New Roman"'>&nbsp; </span></span><span style='font-size:10.0pt;font-family:&quot;新細明體&quot;,&quot;serif&quot;;
  color:black'>是否有宗教或文化上之因素？</span></p>
        <p style='text-align:justify;text-justify:
  inter-ideograph;'><span lang=EN-US style='font-size:10.0pt;
  font-family:&quot;新細明體&quot;,&quot;serif&quot;;color:black'>5.<span style='font:7.0pt "Times New Roman"'>&nbsp; </span></span><span style='font-size:10.0pt;font-family:&quot;新細明體&quot;,&quot;serif&quot;;
  color:black'>是否對其資料有保密措施？</span></p>
        <p style='text-align:justify;text-justify:
  inter-ideograph;'><span lang=EN-US style='font-size:10.0pt;
  font-family:&quot;新細明體&quot;,&quot;serif&quot;;color:black'>6.<span style='font:7.0pt "Times New Roman"'>&nbsp; </span></span><span style='font-size:10.0pt;font-family:&quot;新細明體&quot;,&quot;serif&quot;;
  color:black'>在分配社會資源上是否有困難？</span></p>
        <p style='text-align:justify;text-justify:
  inter-ideograph;'><span lang=EN-US style='font-size:10.0pt;
  font-family:&quot;新細明體&quot;,&quot;serif&quot;;color:black'>7.<span style='font:7.0pt "Times New Roman"'>&nbsp; </span></span><span style='font-size:10.0pt;font-family:&quot;新細明體&quot;,&quot;serif&quot;;
  color:black'>法律上對治療之影響為何？</span></p>
        <p style='text-align:justify;text-justify:
  inter-ideograph;'><span lang=EN-US style='font-size:10.0pt;
  font-family:&quot;新細明體&quot;,&quot;serif&quot;;color:black'>8.<span style='font:7.0pt "Times New Roman"'>&nbsp; </span></span><span style='font-size:10.0pt;font-family:&quot;新細明體&quot;,&quot;serif&quot;;
  color:black'>是否涉及臨床研究及教學？</span></p>
        <p style='text-align:justify;text-justify:
  inter-ideograph;'><span lang=EN-US style='font-size:9.0pt;
  color:black'>9.<span style='font:7.0pt "Times New Roman"'>&nbsp; </span></span><span
  style='font-size:10.0pt;font-family:"新細明體","serif";color:black'>對提供醫療服務之人員或機構，是否有利益衝突須迴避者？</span></p></td>
      <td width=347 valign=top>
            <telerik:RadEditor ID="RadEditor7" Runat="server" EditModes="Design" Height="291px" Width="565px">
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
      <td width=619 colspan=2 valign=top bgcolor="#E6E6E6"><p align=center style='text-align:center;layout-grid-mode:
  char'><b><span style='font-size:14.0pt;font-family:標楷體'>結論<span lang=EN-US> (Summary)</span></span></b></p></td>
    </tr>
    <tr>
      <td width=619 colspan=2 valign=top>
            <telerik:RadEditor ID="RadEditor8" Runat="server" EditModes="Design" Height="113px" Width="875px">
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
</div>


