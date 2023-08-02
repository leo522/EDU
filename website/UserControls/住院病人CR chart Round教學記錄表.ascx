<%@ Control Language="C#" AutoEventWireup="true" CodeFile="住院病人CR chart Round教學記錄表.ascx.cs" Inherits="UserControls_住院病人CR_chart_Round教學記錄表" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>



<table border="1" cellpadding="0" cellspacing="0" width="98%">
    <tr>
        <td colspan="6">
            <p align="center" style="text-align: center; line-height: 22pt;">
                <b><span style="font-family: 標楷體; font-size: 15pt;">住院病人</span><span lang="EN-US" style="font-size: 15pt;">CR chart Round</span><span style="font-family: 標楷體; font-size: 15pt;">教學記錄表</span></b></p>
        </td>
    </tr>
    <tr>
        <td colspan="2" rowspan="3" >
            <table>
                <tr>
                    <td class="auto-style4"><span style="font-family: 標楷體; font-size: 14pt;">查核日期：</span></td>
                    <td> <telerik:RadDatePicker ID="RadDatePicker1" Runat="server">
          </telerik:RadDatePicker></td>
                </tr>
                <tr>
                    <td><span style="font-family: 標楷體; font-size: 14pt;">查核醫師：</span></td>
                    <td><asp:TextBox ID="TextBox3" runat="server" Width="122px"></asp:TextBox></td>
                </tr>
            </table>


                 
          
                
            
        </td>
        <td class="auto-style5" >
            &nbsp;</td>
        <td>
            <telerik:RadDatePicker ID="RadDatePicker2" Runat="server" Visible="false">
          </telerik:RadDatePicker>
        </td>
    </tr>
    <tr>
        <td class="auto-style5">
            <p align="center" style="text-align: center;">
                &nbsp;</p>
        </td>
        <td>
                            <table>
                                <tr>
                                    <td><span style="font-family: 標楷體;">起<span lang="EN-US">: </span></span></td>
                                    <td><telerik:RadTimePicker ID="RadTimePicker1" Visible="false" Runat="server" Width="120px">
          </telerik:RadTimePicker></td>
                                </tr>
                                <tr>
                                    <td><span style="font-family: 標楷體;">迄<span lang="EN-US">: </span></span></td>
                                    <td><telerik:RadTimePicker ID="RadTimePicker3" Visible="false" Runat="server" Width="120px">
          </telerik:RadTimePicker></td>
                                </tr>                                
                            </table>
        </td>
    </tr>
    <tr>
        <td class="auto-style5">
            <p align="center" style="text-align: center;">
                <span style="font-family: 標楷體;">地 點</span></p>
        </td>
        <td>
          <asp:TextBox ID="TextBox2" runat="server" Width="259px"></asp:TextBox>
                        </td>
    </tr>
    <tr>
        <td class="auto-style6">&nbsp;</td>
        <td class="auto-style7">
            <p align="center" style="text-align: center;">
                <span style="font-family: 標楷體;">姓名</span></p>
            <p align="center" style="text-align: center;">
                <span style="font-family: 標楷體;">病歷號碼</span></p>
        </td>
        <td class="auto-style5">
            <p align="center" style="text-align: center;">
                <span style="font-family: 標楷體;">診斷與建議</span></p>
        </td>
        <td class="auto-style3">
            <p align="center" style="text-align: center;">
                <span style="font-family: 標楷體;">是否符合</span></p>
            <p align="center" style="text-align: center;">
                <span style="font-family: 標楷體;">病歷建議事項</span></p>
        </td>
    </tr>
    <tr>
        <td rowspan="5" class="auto-style6">
            <p align="center" style="text-align: center;">
                <span style="font-family: 標楷體; font-size: 16pt;">病</span></p>
            <p align="center" style="text-align: center;">
                <span style="font-family: 標楷體; font-size: 16pt;">例</span></p>
            <p align="center" style="text-align: center;">
                <span style="font-family: 標楷體; font-size: 16pt;">照</span></p>
            <p align="center" style="text-align: center;">
                <span style="font-family: 標楷體; font-size: 16pt;">護</span></p>
            <p align="center" style="text-align: center;">
                <span style="font-family: 標楷體; font-size: 16pt;">需</span></p>
            <p align="center" style="text-align: center;">
                <span style="font-family: 標楷體; font-size: 16pt;">注</span></p>
            <p align="center" style="text-align: center;">
                <span style="font-family: 標楷體; font-size: 16pt;">意</span></p>
            <p align="center" style="text-align: center;">
                <span style="font-family: 標楷體; font-size: 16pt;">重</span></p>
            <p align="center" style="text-align: center;">
                <span style="font-family: 標楷體; font-size: 16pt;">點</span></p>
        </td>
        <td class="auto-style7">
            <span style="font-family: 標楷體;">姓名：<asp:TextBox ID="TextBox14" runat="server" Width="122px"></asp:TextBox>
            <br />
            病歷號：<asp:TextBox ID="TextBox1" runat="server" Width="122px"></asp:TextBox>
            <br />
            主治醫師：<asp:TextBox ID="TextBox4" runat="server" Width="122px"></asp:TextBox></span>
        </td>
        <td  valign="center" class="auto-style5">
                <b><span
style='font-size:18.0pt;font-family:標楷體'>
            <telerik:RadEditor ID="RadEditor4" Runat="server" EditModes="Design" Height="148px" Width="280px">
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
                </span></b>
        </td>
        <td class="auto-style3">
            <p style="line-height: 14pt;">
                <asp:CheckBox ID="CheckBox1" runat="server" Text="符合SOAP" />
            </p>
            <p style="line-height: 14pt;">
                <asp:CheckBox ID="CheckBox2" runat="server" Text="有VS 親簽及Comment" />
            </p>
            <p style="line-height: 14pt;">
                <asp:CheckBox ID="CheckBox3" runat="server" Text="有VS病歷" />
            </p>
            <p style="line-height: 14pt;">
                <asp:CheckBox ID="CheckBox4" runat="server" Text="TPR記載詳實" />
            </p>
            <p style="line-height: 14pt;">
                <asp:CheckBox ID="CheckBox5" runat="server" Text="其他" />
            <span style="font-family: 標楷體;"><asp:TextBox ID="TextBox9" runat="server" Width="147px"></asp:TextBox></span>
            </p>
        </td>
    </tr>
    <tr>
        <td class="auto-style7">
            <span style="font-family: 標楷體;">姓名：<asp:TextBox ID="TextBox5" runat="server" Width="122px"></asp:TextBox>
            <br />
            病歷號：<asp:TextBox ID="TextBox15" runat="server" Width="122px"></asp:TextBox>
            <br />
            主治醫師：<asp:TextBox ID="TextBox16" runat="server" Width="122px"></asp:TextBox></span>
        </td>
        <td valign="center" class="auto-style5">
                <b><span
style='font-size:18.0pt;font-family:標楷體'>
            <telerik:RadEditor ID="RadEditor5" Runat="server" EditModes="Design" Height="148px" Width="280px">
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
                </span></b>
        </td>
        <td class="auto-style3">
            <p style="line-height: 14pt;">
                <asp:CheckBox ID="CheckBox6" runat="server" Text="符合SOAP" />
            </p>
            <p style="line-height: 14pt;">
                <asp:CheckBox ID="CheckBox7" runat="server" Text="有VS 親簽及Comment" />
            </p>
            <p style="line-height: 14pt;">
                <asp:CheckBox ID="CheckBox8" runat="server" Text="有VS病歷" />
            </p>
            <p style="line-height: 14pt;">
                <asp:CheckBox ID="CheckBox9" runat="server" Text="TPR記載詳實" />
            </p>
            <p style="line-height: 14pt;">
                <asp:CheckBox ID="CheckBox10" runat="server" Text="其他" />
            <span style="font-family: 標楷體;"><asp:TextBox ID="TextBox10" runat="server" Width="147px"></asp:TextBox></span>
            </p>
        </td>
    </tr>
    <tr>
        <td class="auto-style7">
            <span style="font-family: 標楷體;">姓名：<asp:TextBox ID="TextBox6" runat="server" Width="122px"></asp:TextBox>
            <br />
            病歷號：<asp:TextBox ID="TextBox17" runat="server" Width="122px"></asp:TextBox>
            <br />
            主治醫師：<asp:TextBox ID="TextBox18" runat="server" Width="122px"></asp:TextBox></span>
        </td>
        <td valign="center" class="auto-style5">
                <b><span
style='font-size:18.0pt;font-family:標楷體'>
            <telerik:RadEditor ID="RadEditor6" Runat="server" EditModes="Design" Height="148px" Width="280px">
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
                </span></b>
        </td>
        <td class="auto-style3">
            <p style="line-height: 14pt;">
                <asp:CheckBox ID="CheckBox11" runat="server" Text="符合SOAP" />
            </p>
            <p style="line-height: 14pt;">
                <asp:CheckBox ID="CheckBox12" runat="server" Text="有VS 親簽及Comment" />
            </p>
            <p style="line-height: 14pt;">
                <asp:CheckBox ID="CheckBox13" runat="server" Text="有VS病歷" />
            </p>
            <p style="line-height: 14pt;">
                <asp:CheckBox ID="CheckBox14" runat="server" Text="TPR記載詳實" />
            </p>
            <p style="line-height: 14pt;">
                <asp:CheckBox ID="CheckBox15" runat="server" Text="其他" />
            <span style="font-family: 標楷體;"><asp:TextBox ID="TextBox11" runat="server" Width="147px"></asp:TextBox></span>
            </p>
        </td>
    </tr>
    <tr>
        <td class="auto-style7">
            <span style="font-family: 標楷體;">姓名：<asp:TextBox ID="TextBox7" runat="server" Width="122px"></asp:TextBox>
            <br />
            病歷號：<asp:TextBox ID="TextBox19" runat="server" Width="122px"></asp:TextBox>
            <br />
            主治醫師：<asp:TextBox ID="TextBox20" runat="server" Width="122px"></asp:TextBox></span>
        </td>
        <td valign="center" class="auto-style5">
                <b><span
style='font-size:18.0pt;font-family:標楷體'>
            <telerik:RadEditor ID="RadEditor7" Runat="server" EditModes="Design" Height="148px" Width="280px">
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
                </span></b>
        </td>
        <td class="auto-style3">
            <p style="line-height: 14pt;">
                <asp:CheckBox ID="CheckBox16" runat="server" Text="符合SOAP" />
            </p>
            <p style="line-height: 14pt;">
                <asp:CheckBox ID="CheckBox17" runat="server" Text="有VS 親簽及Comment" />
            </p>
            <p style="line-height: 14pt;">
                <asp:CheckBox ID="CheckBox18" runat="server" Text="有VS病歷" />
            </p>
            <p style="line-height: 14pt;">
                <asp:CheckBox ID="CheckBox19" runat="server" Text="TPR記載詳實" />
            </p>
            <p style="line-height: 14pt;">
                <asp:CheckBox ID="CheckBox20" runat="server" Text="其他" />
            <span style="font-family: 標楷體;"><asp:TextBox ID="TextBox12" runat="server" Width="147px"></asp:TextBox></span>
            </p>
        </td>
    </tr>
    <tr>
        <td class="auto-style7">
             <span style="font-family: 標楷體;">姓名：<asp:TextBox ID="TextBox8" runat="server" Width="122px"></asp:TextBox>
            <br />
            病歷號：<asp:TextBox ID="TextBox21" runat="server" Width="122px"></asp:TextBox>
            <br />
            主治醫師：<asp:TextBox ID="TextBox22" runat="server" Width="122px"></asp:TextBox></span>
        </td>
        <td valign="center" class="auto-style5">
                <b><span
style='font-size:18.0pt;font-family:標楷體'>
            <telerik:RadEditor ID="RadEditor8" Runat="server" EditModes="Design" Height="148px" Width="280px">
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
                </span></b>
        </td>
        <td class="auto-style3">
            <p style="line-height: 14pt;">
                <asp:CheckBox ID="CheckBox21" runat="server" Text="符合SOAP" />
            </p>
            <p style="line-height: 14pt;">
                <asp:CheckBox ID="CheckBox22" runat="server" Text="有VS 親簽及Comment" />
            </p>
            <p style="line-height: 14pt;">
                <asp:CheckBox ID="CheckBox23" runat="server" Text="有VS病歷" />
            </p>
            <p style="line-height: 14pt;">
                <asp:CheckBox ID="CheckBox24" runat="server" Text="TPR記載詳實" />
            </p>
            <p style="line-height: 14pt;">
                <asp:CheckBox ID="CheckBox25" runat="server" Text="其他" />
            <span style="font-family: 標楷體;"><asp:TextBox ID="TextBox13" runat="server" Width="147px"></asp:TextBox></span>
            </p>
        </td>
    </tr>
    <tr>
        <td colspan="6">
            <table border="1" cellpadding="0" cellspacing="0" width="686">
                <tr>
                    <td valign="top" width="686">
                        <p style="text-align: justify; -ms-text-justify: inter-ideograph;">
                            <span style="font-family: 標楷體; font-size: 13pt;">病歷書寫注意事項</span></p>
                    </td>
                </tr>
                <tr>
                    <td valign="top" width="196">
                        <p style="text-align: justify; line-height: 12pt; -ms-text-justify: inter-ideograph;">
                            <span style="font-family: 標楷體;">符合</span><span lang="EN-US">SOAP</span></p>
                    </td>
                    <td valign="top" width="490">
                        <p style="text-align: justify; -ms-text-justify: inter-ideograph;">
                            <span lang="EN-US">1.</span><span style="font-family: 標楷體;">至少一個重點需以</span><span lang="EN-US">SOAP</span><span style="font-family: 標楷體;">方式記載病歷</span></p>
                    </td>
                </tr>
                <tr>
                    <td valign="top" width="196">
                        <p style="text-align: justify; line-height: 12pt; -ms-text-justify: inter-ideograph;">
                            <span style="font-family: 標楷體;">有</span><span lang="EN-US">VS </span><span style="font-family: 標楷體;">親簽及</span><span lang="EN-US">comment</span></p>
                    </td>
                    <td valign="top" width="490">
                        <p style="text-align: justify; -ms-text-justify: inter-ideograph;">
                            <span lang="EN-US">1.VS</span><span style="font-family: 標楷體;">每天親自簽名；</span></p>
                        <p style="text-align: justify; -ms-text-justify: inter-ideograph;">
                            <span lang="EN-US">2.VS</span><span style="font-family: 標楷體;">至少二天一次對</span><span lang="EN-US">R</span><span style="font-family: 標楷體;">、</span><span lang="EN-US">Intern</span><span style="font-family: 標楷體;">病歷的處置合理性及適當性作指正</span></p>
                    </td>
                </tr>
                <tr>
                    <td valign="top" width="196">
                        <p style="text-align: justify; line-height: 12pt; -ms-text-justify: inter-ideograph;">
                            <span style="font-family: 標楷體;">有</span><span lang="EN-US">VS</span><span style="font-family: 標楷體;">病歷</span></p>
                    </td>
                    <td valign="top" width="490">
                        <p style="text-align: justify; -ms-text-justify: inter-ideograph;">
                            <span lang="EN-US">1.VS</span><span style="font-family: 標楷體;">親自寫病歷（至少一次）</span> <span style="font-family: 標楷體;">或</span></p>
                        <p style="text-align: justify; -ms-text-justify: inter-ideograph;">
                            <span lang="EN-US">2.VS</span><span style="font-family: 標楷體;">口述，</span><span lang="EN-US">recorded by R</span><span style="font-family: 標楷體;">，</span><span lang="EN-US">VS</span><span style="font-family: 標楷體;">簽名</span></p>
                    </td>
                </tr>
                <tr>
                    <td valign="top" width="196">
                        <p style="text-align: justify; line-height: 12pt; -ms-text-justify: inter-ideograph;">
                            <span lang="EN-US">TPR</span><span style="font-family: 標楷體;">記載詳實</span></p>
                    </td>
                    <td valign="top" width="490">
                        <p style="text-align: justify; -ms-text-justify: inter-ideograph;">
                            <span style="font-family: 標楷體;">重要檢查、藥物、手術需紀錄於</span><span lang="EN-US">TPR sheet</span><span style="font-family: 標楷體;">中</span></p>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>




