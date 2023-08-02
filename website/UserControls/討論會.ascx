<%@ Control Language="C#" AutoEventWireup="true" CodeFile="討論會.ascx.cs" Inherits="UserControls_討論會" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

            <style type="text/css">
                .auto-style1 {
                    height: 25px;
                }
            </style>

            <table border=1 cellspacing=0 cellpadding=0 width="90%">
    <tr>
      <td colspan=12><p style='line-height:15.0pt'><span style='font-size:13.0pt;font-family:
  標楷體'>
          <table>
              <tr>
                  <td>
                      <asp:CheckBox ID="RadioButton1" runat="server" Text="晨報會" />
                      <asp:CheckBox ID="RadioButton2" runat="server" Text="臨床研討" />
                      <asp:CheckBox ID="RadioButton3" runat="server" Text="聯合討論" />
                      <asp:CheckBox ID="RadioButton4" runat="server" Text="文獻研討" />
                      <asp:CheckBox ID="RadioButton5" runat="server" Text="影像診療" />
                      <asp:CheckBox ID="RadioButton6" runat="server" Text="臨床病理" />
                      <asp:CheckBox ID="RadioButton7" runat="server" Text="死亡及併發症" />



                  </td>
              </tr>
              <tr>
                  <td>

                      <span
  style='font-size:13.0pt;font-family:標楷體'>
          <asp:CheckBox ID="RadioButton8" runat="server" Text="主治醫師教學" />
          <asp:CheckBox ID="RadioButton9" runat="server" Text="住院醫師教學" />
          </span><span style='font-size:13.0pt;
  font-family:標楷體'>
          <asp:CheckBox ID="RadioButton10" runat="server" Text="醫療品質檢討會議" />
          </span><span style='font-size:13.0pt;font-family:
  標楷體'>
                      <span style='font-size:13.0pt;font-family:
  標楷體'>
                      <span style='font-size:13.0pt;
  font-family:標楷體'>
          <asp:CheckBox ID="RadioButton20" runat="server" Text="專題討論" />
          </span>
          
          </span>
          <asp:CheckBox ID="RadioButton11" runat="server" Text="其他" />
          </span><span style='font-size:13.0pt;font-family:
  標楷體'>
          ：<asp:TextBox ID="TextBox1" runat="server" Width="99px"></asp:TextBox>
          </span>

                  </td>
              </tr>
          </table>
          
          </span>
          </p></td>
 
      <td colspan=2><p align=center style='text-align:center;layout-grid-mode:
  char'><b><span style='font-size:14.0pt;font-family:標楷體'>討論會</span></b></p>
        <p align=center style='text-align:center;layout-grid-mode:
  char'><b><span style='font-size:14.0pt;font-family:標楷體'>會議記錄</span></b></p></td>
    </tr>

    <tr>
      <td colspan=2><p align=center style='text-align:center'><span
  style='font-family:標楷體'>地點</span></p></td>
      <td colspan=3>
          <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </td>
      <td><p align=center style='text-align:center'>&nbsp;</p></td>
      <td colspan=4 valign=top>
          <table>
              <tr>
                  <td>
&nbsp;</td>
                  <td>
<telerik:RadTimePicker ID="RadTimePicker1" Runat="server" Width="120px" Visible="false">
          </telerik:RadTimePicker>
                  </td>
              </tr>
              <tr>
                  <td>
&nbsp;</td>
                  <td>
          <telerik:RadTimePicker ID="RadTimePicker2" Runat="server" Width="120px" Visible="false">
          </telerik:RadTimePicker>
                  </td>
              </tr>
          </table>
</td>
      <td>&nbsp;</td>
      <td colspan=3 valign=top>
          <telerik:RadDatePicker ID="RadDatePicker1" Runat="server" Visible="false">
          </telerik:RadDatePicker>
        </td>
    </tr>
    <tr>
      <td colspan=2><p align=center style='text-align:center'><span
  style='font-family:標楷體'>主持者</span></p></td>
      <td colspan=3 valign=top>
          <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        </td>
      <td colspan=2><p align=center style='text-align:center'><span
  style='font-size:11.0pt;font-family:標楷體'>報告者<span lang=EN-US>/</span></span></p>
        <p align=center style='text-align:center'><span
  style='font-size:11.0pt;font-family:標楷體'>授課、講演者</span></p></td>
      <td colspan=3>
          <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        </td>
      <td><p align=center style='text-align:center'><span
  style='font-family:標楷體'>紀錄人</span></p></td>
      <td colspan=3 valign=top>
          <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
      <td colspan=2><p style='line-height:14.0pt'><span style='font-family:標楷體'>與會科別</span></p></td>
      <td colspan=12 valign=top>
          <asp:TextBox ID="TextBox10" runat="server" Width="552px"></asp:TextBox>
          <span style='font-size:11.0pt;font-family:標楷體'>
          <asp:CheckBox ID="CheckBox1" runat="server" Text="引言者" Visible="False" />
          <asp:TextBox ID="TextBox6" runat="server" Width="91px" Visible="False"></asp:TextBox>
          </span><span style='font-size:11.0pt;font-family:標楷體'>
          <asp:CheckBox ID="CheckBox2" runat="server" Text="考評者" Visible="False" />
          <asp:TextBox ID="TextBox7" runat="server" Width="91px" Visible="False"></asp:TextBox>
          </span><span style='font-size:10.0pt;font-family:標楷體;
  letter-spacing:-.6pt'><span style='font-size:11.0pt;font-family:標楷體'>
          <asp:CheckBox ID="CheckBox3" runat="server" Text="審查者" Visible="False" />
          <asp:TextBox ID="TextBox8" runat="server" Width="91px" Visible="False"></asp:TextBox>
          </span></span><span style='font-size:10.0pt;
  font-family:標楷體;letter-spacing:-.6pt'><span style='font-size:10.0pt;font-family:標楷體;
  letter-spacing:-.6pt'><span style='font-size:11.0pt;font-family:標楷體'>
          <asp:CheckBox ID="CheckBox4" runat="server" Text="指導者" Visible="False" />
          <asp:TextBox ID="TextBox9" runat="server" Width="91px" Visible="False"></asp:TextBox>
          </span></span></span>
        </td>
    </tr>
    <tr>
      <td colspan=2><p align=center style='text-align:center;line-height:17.0pt'><span
  lang=EN-US style='font-size:10.0pt;font-family:標楷體'>1.</span><span
  style='font-size:10.0pt;font-family:標楷體'>討論主題</span></p>
        <p align=center style='text-align:center;line-height:17.0pt'><span
  lang=EN-US style='font-size:10.0pt;font-family:標楷體'>2.</span><span
  style='font-size:10.0pt;font-family:標楷體'>參考文獻</span></p>
        <p align=center style='text-align:center;line-height:17.0pt'><span
  lang=EN-US style='font-size:10.0pt;font-family:標楷體'>3.</span><span
  style='font-size:10.0pt;font-family:標楷體'>病患資料</span></p></td>
      <td colspan=12 valign=top>

            <telerik:RadEditor ID="RadEditor3" Runat="server" EditModes="Design" Height="170px" Width="675px">
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
      <td colspan=14 valign=top><p style='text-align:justify;text-justify:inter-ideograph'><span
  style='font-family:標楷體'>討論內容摘要：</span> 
        
            <telerik:RadEditor ID="RadEditor4" Runat="server" EditModes="Design" Height="273px" Width="730px">
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
      <td colspan=14 valign=top><p style='text-align:justify;text-justify:inter-ideograph;
  line-height:15.0pt'><b><span style='font-family:標楷體'>關鍵詞：</span></b><b><span
  lang=EN-US>(</span></b><b><span style='font-family:標楷體'>特殊會議才勾選，由會議主持人勾選，可複選</span></b><b><span
  lang=EN-US>)</span></b></p>
        <p style='text-align:justify;text-justify:inter-ideograph;
  line-height:15.0pt'><span
  style='font-family:標楷體;color:black'>
            <asp:CheckBox ID="CheckBox5" runat="server" Text="醫療品質" />
            </span><span lang=EN-US style='font-family:Wingdings;
  color:black'><span
  style='font-family:標楷體;color:black'>
            <asp:CheckBox ID="CheckBox6" runat="server" Text="醫病溝通" />
            </span></span><span
  lang=EN-US style='color:black'><span lang=EN-US style='font-family:Wingdings;
  color:black'><span
  style='font-family:標楷體;color:black'>
            <asp:CheckBox ID="CheckBox7" runat="server" Text="實證醫學" />
            <span
  lang=EN-US style='color:black'>
            <asp:CheckBox ID="CheckBox8" runat="server" Text="病歷寫作" />
            <asp:CheckBox ID="CheckBox9" runat="server" Text="醫學倫理與法律" />
            <asp:CheckBox ID="CheckBox10" runat="server" Text="感染控制" />
            </span></span></span> </span></p>
        <p style='text-align:justify;text-justify:inter-ideograph;
  line-height:15.0pt'><span lang=EN-US style='font-family:Wingdings;color:black'><span
  style='font-family:標楷體;color:black'>
            <asp:CheckBox ID="CheckBox11" runat="server" Text="全人醫療" />
            <asp:CheckBox ID="CheckBox12" runat="server" Text="病人安全" />
            <asp:CheckBox ID="CheckBox13" runat="server" Text="病人權利" />
            <asp:CheckBox ID="CheckBox14" runat="server" Text="基層與社區醫療" />
            <asp:CheckBox ID="CheckBox15" runat="server" Text="醫學與臨床教育" />
            </span></span></p>
        <p style='text-align:justify;text-justify:inter-ideograph;
  line-height:15.0pt'><span lang=EN-US style='font-family:Wingdings;color:black'><span
  style='font-family:標楷體;color:black'>
            <asp:CheckBox ID="CheckBox16" runat="server" Text="預防醫學及觀念" />
            <asp:CheckBox ID="CheckBox17" runat="server" Text="醫療模式及團隊" />
            <asp:CheckBox ID="CheckBox18" runat="server" Text="危機管理" />
            <asp:CheckBox ID="CheckBox19" runat="server" Text="其他" />
            </span></span><u><span lang=EN-US style='color:black'>&nbsp;<asp:TextBox ID="TextBox11" runat="server"></asp:TextBox>
            </span></u></p></td>
    </tr>
    <tr>
      <td colspan=3 rowspan=3><p align=center style='text-align:center;line-height:16.0pt'><span
  style='font-size:11.0pt;font-family:標楷體'>列入下次會議追蹤事項</span></p>
        <p align=center style='text-align:center;line-height:16.0pt'>
            <asp:RadioButton ID="RadioButton12" runat="server" GroupName="下次追" Text="無" />
            <asp:RadioButton ID="RadioButton13" runat="server" GroupName="下次追" Text="有" />
          </p></td>
      <td colspan=5 bgcolor="#D9D9D9"><p align=center style='text-align:center'><span
  style='font-family:標楷體'>議題</span></p></td>
      <td colspan=6 bgcolor="#D9D9D9"><p align=center style='text-align:center'><span
  style='font-family:標楷體'>預計辦理方式（例：建議提交<asp:TextBox ID="TextBox16" runat="server" Width="90px"></asp:TextBox>
          會議討論）</span></p></td>
    </tr>
    <tr>
      <td colspan=5 class="auto-style1">
          <table>
              <tr>
                  <td>1.</td>
                  <td><asp:TextBox ID="TextBox12" runat="server" Width="270px"></asp:TextBox></td>
              </tr>
          </table></td>
      <td colspan=6>
          <asp:TextBox ID="TextBox14" runat="server" Width="272px"></asp:TextBox>
        </td>
    </tr>
    <tr>
      <td colspan=5 class="auto-style1">
          <table>
              <tr>
                  <td>
                      2.
                  </td>
                  <td>
<asp:TextBox ID="TextBox13" runat="server" Width="270px"></asp:TextBox>
                  </td>
              </tr>
          </table></td>
      <td colspan=6>
          <asp:TextBox ID="TextBox15" runat="server" Width="272px"></asp:TextBox>
        </td>
    </tr>
    <tr>
      <td colspan=3 rowspan=4><p align=center style='text-align:center;line-height:16.0pt'><span
  style='font-size:11.0pt;font-family:標楷體'>上次會議</span></p>
        <p align=center style='text-align:center;line-height:16.0pt'><span
  style='font-size:11.0pt;font-family:標楷體'>追蹤事項</span></p>
        <p align=center style='text-align:center;line-height:16.0pt'>
            <asp:RadioButton ID="RadioButton14" runat="server" GroupName="上次追" Text="無" />
            <asp:RadioButton ID="RadioButton15" runat="server" GroupName="上次追" Text="有" />
          </p></td>
      <td colspan=5 rowspan=2 bgcolor="#D9D9D9"><p align=center style='text-align:center;line-height:12.0pt'><span
  style='font-family:標楷體'>議題</span></p></td>
      <td colspan=4 rowspan=2 bgcolor="#D9D9D9"><p align=center style='text-align:center;line-height:12.0pt'><span
  style='font-family:標楷體'>決議、追蹤及改善情形</span></p></td>
      <td colspan=2 bgcolor="#D9D9D9"><p align=center style='text-align:center;line-height:12.0pt'><span
  style='text-fit:50.0pt'><span style='font-size:10.0pt;font-family:標楷體'>建議列管別</span></span></p></td>
    </tr>
    <tr>
      <td bgcolor="#D9D9D9"><p align=center style='text-align:center;line-height:12.0pt'><span
  style='font-size:10.0pt;font-family:標楷體'>續管</span></p></td>
      <td bgcolor="#D9D9D9"><p align=center style='text-align:center;line-height:12.0pt'><span
  style='font-size:10.0pt;font-family:標楷體'>除管</span></p></td>
    </tr>
    <tr>
      <td colspan=5>
          <table>
              <tr>
                  <td>1.</td>
                  <td><asp:TextBox ID="TextBox17" runat="server" Width="272px"></asp:TextBox></td>
              </tr>
          </table></td>
      <td colspan=4><span
  lang=EN-US style='font-size:10.0pt;font-family:標楷體'><asp:TextBox ID="TextBox19" runat="server" Width="272px"></asp:TextBox>
          </span></td>
      <td style="text-align:center;vertical-align:middle">
          <asp:RadioButton ID="RadioButton16" runat="server" GroupName="remove1" />
        </td>
      <td style="text-align:center;vertical-align:middle">
          <asp:RadioButton ID="RadioButton17" runat="server" GroupName="remove1" />
        </td>
    </tr>
    <tr>
      <td colspan=5>
          <table>
              <tr>
                  <td>2.</td>
                  <td><asp:TextBox ID="TextBox18" runat="server" Width="272px"></asp:TextBox></td>
              </tr>
          </table></td>
      <td colspan=4><span
  lang=EN-US style='font-size:10.0pt;font-family:標楷體'><asp:TextBox ID="TextBox20" runat="server" Width="272px"></asp:TextBox>
          </span></td>
      <td style="text-align:center;vertical-align:middle">
          <asp:RadioButton ID="RadioButton18" runat="server" GroupName="remove2" />
        </td>
      <td style="text-align:center;vertical-align:middle">
          <asp:RadioButton ID="RadioButton19" runat="server" GroupName="remove2" />
        </td>
    </tr>
    <tr>
      <td colspan=14 valign=top><p><span style='font-family:標楷體'>主席<span lang=EN-US>(</span>主治醫師<span
  lang=EN-US>)</span>簽註意見：</span><span lang=EN-US style='font-size:10.0pt;
  font-family:標楷體'>(</span><span style='font-size:10.0pt;font-family:標楷體'>請至少書寫兩行以上<span
  lang=EN-US>)</span></span></p>

            <telerik:RadEditor ID="RadEditor5" Runat="server" EditModes="Design" Height="106px" Width="760px">
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
        <p align=center style='text-align:center'><span lang=EN-US
  style='font-family:標楷體'>                                     </span><span
  style='font-family:標楷體'>簽名：</span></p></td>
    </tr>
    <tr>
      <td><p align=center style='text-align:center'><span
  style='font-family:標楷體'>附<span lang=EN-US>  </span>件</span></p></td>
      <td colspan=3><p style='text-align:justify;text-justify:inter-ideograph'><span
  style='font-family:標楷體'>
          <asp:CheckBox ID="CheckBox20" runat="server" Text="書面資料" />
          </span></p></td>
      <td colspan=5><p style='text-align:justify;text-justify:inter-ideograph'><span
  style='font-family:標楷體'>
          <asp:CheckBox ID="CheckBox21" runat="server" Text="電子檔資料" />
          <span lang=EN-US>(</span>檔名：<asp:TextBox ID="TextBox21" runat="server"></asp:TextBox>
          <span lang=EN-US>)</span></span></p></td>
      <td colspan=5><p style='text-align:justify;text-justify:inter-ideograph'><span
  style='font-family:標楷體'><span
  style='font-family:標楷體'>
          <asp:CheckBox ID="CheckBox22" runat="server" Text="其他" />
          </span>：<span
  style='font-family:標楷體'><asp:TextBox ID="TextBox22" runat="server"></asp:TextBox>
          </span></span></p></td>
    </tr>
    </table>