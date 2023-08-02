<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="EduPassportItemAdd.aspx.cs" Inherits="EduPassportItemAdd" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<%@ Register src="UserControls/EduPassportItemControl.ascx" tagname="EduPassportItemControl" tagprefix="uc1" %>

<%@ Register src="TreeViewComboBox.ascx" tagname="TreeViewComboBox" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">

    .RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}
    .RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}
.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}
.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}
.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox_Default .rcbReadOnly .rcbInputCellLeft{background-position:0 -88px}.RadComboBox .rcbInputCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox .rcbInputCell{width:100%;height:20px;_height:22px;line-height:20px;_line-height:22px;text-align:left;vertical-align:middle}.RadComboBox_Default .rcbInputCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox_Default .rcbInputCellLeft{background-position:0 0}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}
    .RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}
    .RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox_Default .rcbReadOnly .rcbArrowCellRight{background-position:-162px -176px}.RadComboBox .rcbArrowCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox .rcbArrowCell{width:18px}.RadComboBox_Default .rcbArrowCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox_Default .rcbArrowCellRight{background-position:-18px -176px}
        .auto-style1 {
            height: 21px;
        }
        .auto-style2 {
            height: 23px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
            <asp:ObjectDataSource ID="dsJobCode" runat="server" DataObjectTypeName="KMU.EduActivity.ApplicationLayer.DTO.V_CodeRefDto" SelectMethod="GetCodeRefsStatic" TypeName="KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService">
                <SelectParameters>
                    <asp:Parameter DefaultValue="EduAct_JobSerial" Name="codetype" />
                </SelectParameters>
            </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="dsTermCode" runat="server" SelectMethod="GetEduTeams" 
        TypeName="KMU.EduActivity.ApplicationLayer.DTO.EduTeamDto">
    </asp:ObjectDataSource>
    
    <table>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="項目名稱："></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbName" runat="server"></asp:TextBox>
            </td>
            <td rowspan="5" valign="top">
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="Label12" runat="server" Text="臨床分級組別："></asp:Label>
                        </td>
                        <td>
        <uc1:TreeViewComboBox ID="TreeViewComboBox2" runat="server" 
            AutoPostBack="True" Enabled="True" TreeDataFieldID="EduTeamCode" 
            TreeDataFieldParentID="parentEduTeamCode" TreeDataSourceID="dsTermCode" 
            TreeDataTextField="EduTeamName" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label11" runat="server" Text="對應臨床分級："></asp:Label>
                        </td>
                        <td>
                            <telerik:RadComboBox ID="rcbCheckItem" Runat="server" Width="300px">
                            </telerik:RadComboBox>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <asp:Button ID="btnAddPRef" runat="server" Text="加入" OnClick="btnAddPRef_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <telerik:RadGrid ID="rgPRef" runat="server" AutoGenerateColumns="False" CellSpacing="0" Culture="zh-TW" GridLines="None" OnItemCommand="rgPRef_ItemCommand">
                                <ClientSettings>
                                    <Selecting AllowRowSelect="True" />
                                </ClientSettings>
                                <MasterTableView DataKeyNames="ID">
                                    <Columns>
                                        <telerik:GridBoundColumn DataField="itemName" FilterControlAltText="Filter FieldDesc column" HeaderText="臨床分級項目" UniqueName="itemName">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" UniqueName="TemplateColumn">
                                            <ItemTemplate>
                                                <asp:ImageButton ImageUrl="~/Images/delete.gif" ID="btnDelete1" runat="server" OnClick="btnDelete1_Click" Text="刪除" OnClientClick="javascript:return confirm('是否確定刪除?')" />
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
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
                <asp:Label ID="Label2" runat="server" Text="適用職類："></asp:Label>
            </td>
            <td>
                    <telerik:RadDropDownTree ID="rddtJobCode" runat="server" DataFieldID="Code" DataFieldParentID="ParentCodeRefid" DataSourceID="dsJobCode" DataTextField="name" DataValueField="code" CheckBoxes="CheckChildNodes" OnDataBound="rddtJobCode_DataBound">
                    </telerik:RadDropDownTree>
                </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="適用單位："></asp:Label>
            </td>
            <td>
                <telerik:RadComboBox ID="ddlUnit" Runat="server" AllowCustomText="True" Filter="Contains" CheckBoxes="True" Width="250px" AutoPostBack="True">
                </telerik:RadComboBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Label ID="Label4" runat="server" Text="備註："></asp:Label>
            </td>
            <td class="auto-style2">
                <asp:TextBox ID="tbRemark" runat="server" Width="240px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:CheckBox ID="cbNecessary" runat="server" Text="必修課程" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label13" runat="server" Text="項目說明(學生看的到)："></asp:Label>
            </td>
            <td colspan="2">
                <telerik:RadEditor ID="reDesc" Runat="server" Height="221px" Language="zh-TW">
                    <Tools>
                        <telerik:EditorToolGroup Tag="MainToolbar">
                            <telerik:EditorTool Name="FindAndReplace" />
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
                            <telerik:EditorSeparator />
                            <telerik:EditorDropDown Name="FontName">
                            </telerik:EditorDropDown>
                            <telerik:EditorDropDown Name="RealFontSize">
                            </telerik:EditorDropDown>
                        </telerik:EditorToolGroup>
                    </Tools>
                    <Content>
</Content>

<TrackChangesSettings CanAcceptTrackChanges="False"></TrackChangesSettings>
                </telerik:RadEditor>
            </td>
        </tr>
    </table>
    <table width="90%">
        <tr style="background-color:lightgray">
            <td width="50%"  align="center" style="background-color: #33CCFF">
                <asp:Label ID="Label5" runat="server" Text="學生填寫項目"></asp:Label>
            </td>
            <td width="50%" align="center" style="background-color: #33CCFF">
                <asp:Label ID="Label6" runat="server" Text="教師填寫項目"></asp:Label>
            </td>
        </tr>
        <tr>
            <td width="50%">
                <table width="100%">
                    <tr>
                        <td><asp:Label ID="Label7" runat="server" Text="項目名稱："></asp:Label></td>
                        <td><asp:TextBox ID="tbSFieldName" runat="server"></asp:TextBox></td>


                        
                    </tr>
                    <tr>
                        <td colspan="2"><asp:RadioButtonList ID="rblSFieldType" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Selected="True" Value="單行">單行</asp:ListItem>
                            <asp:ListItem>單行(數字)</asp:ListItem>
                    <asp:ListItem Value="多行">多行</asp:ListItem>
                    <asp:ListItem Value="日期">日期</asp:ListItem>
                    <asp:ListItem Value="單選">單選</asp:ListItem>
                    <asp:ListItem Value="多選">多選</asp:ListItem>
                </asp:RadioButtonList></td>
                    </tr>
                    <tr>
                        <td class="auto-style1"><asp:Label ID="Label9" runat="server" Text="選項(每項以逗點分隔)："></asp:Label></td>
                        <td class="auto-style1">
                            <asp:TextBox ID="tbSOptions" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>

                        <td colspan="2" width="100%" align="center">
                            <asp:Button ID="btnSAdd" runat="server" Text="加入" OnClick="btnSAdd_Click" />
                        </td>                    

                    </tr>
                </table>
                
                
                
            </td>
            <td width="50%">
                <table width="100%">
                    <tr>
                        <td><asp:Label ID="Label8" runat="server" Text="項目名稱："></asp:Label></td>
                        <td><asp:TextBox ID="tbTFieldName" runat="server"></asp:TextBox></td>


                        
                    </tr>
                    <tr>
                        <td colspan="2"><asp:RadioButtonList ID="rblTFieldType" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Selected="True" Value="單行">單行</asp:ListItem>
                            <asp:ListItem>單行(數字)</asp:ListItem>
                    <asp:ListItem Value="多行">多行</asp:ListItem>
                    <asp:ListItem Value="日期">日期</asp:ListItem>
                    <asp:ListItem Value="單選">單選</asp:ListItem>
                    <asp:ListItem Value="多選">多選</asp:ListItem>
                </asp:RadioButtonList></td>
                    </tr>
                    <tr>
                        <td class="auto-style1"><asp:Label ID="Label10" runat="server" Text="選項(每項以逗點分隔)："></asp:Label></td>
                        <td class="auto-style1">
                            <asp:TextBox ID="tbTOptions" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <asp:Button ID="btnTAdd" runat="server" Text="加入" OnClick="btnTAdd_Click" />
                        </td>
                    </tr>
                </table>

            </td>
        </tr>
        <tr>
            <td width="50%">
                <table width="100%">
                    <tr>
                        <td>
                            <telerik:RadGrid ID="rgSDet" runat="server" AutoGenerateColumns="False" CellSpacing="0" Culture="zh-TW" GridLines="None">
                                <ClientSettings>
                                    <Selecting AllowRowSelect="True" />
                                </ClientSettings>
                                <MasterTableView DataKeyNames="seq">
                                    <Columns>
                                        <telerik:GridBoundColumn DataField="FieldDesc" FilterControlAltText="Filter FieldDesc column" HeaderText="欄位名稱" UniqueName="FieldDesc">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="FieldType" FilterControlAltText="Filter FieldType column" HeaderText="類別" UniqueName="FieldType">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" UniqueName="TemplateColumn">
                                            <ItemTemplate>
                                                <asp:ImageButton ImageUrl="~/Images/delete.gif" ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="刪除" OnClientClick="javascript:return confirm('是否確定刪除?')" />
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                    </Columns>
                                </MasterTableView>
                            </telerik:RadGrid>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:Button ID="btnSMoveUp" runat="server" Text="上移" OnClick="btnSMoveUp_Click" />
                            &nbsp;
                            <asp:Button ID="btnSMoveDown" runat="server" Text="下移" OnClick="btnSMoveDown_Click" />
                        </td>
                    </tr>
                </table>
            </td>
            <td width="50%">
                <table width="100%">
                    <tr>
                        <td>
                            <telerik:RadGrid ID="rgTDet" runat="server" AutoGenerateColumns="False" CellSpacing="0" Culture="zh-TW" GridLines="None">
                                <ClientSettings>
                                    <Selecting AllowRowSelect="True" />
                                </ClientSettings>
                                <MasterTableView DataKeyNames="seq">
                                    <Columns>
                                        <telerik:GridBoundColumn DataField="FieldDesc" FilterControlAltText="Filter FieldDesc column" HeaderText="欄位名稱" UniqueName="FieldDesc">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="FieldType" FilterControlAltText="Filter FieldType column" HeaderText="類別" UniqueName="FieldType">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" UniqueName="TemplateColumn">
                                            <ItemTemplate>
                                                <asp:ImageButton ImageUrl="~/Images/delete.gif" ID="btnDelete0" runat="server" OnClick="btnDelete0_Click" Text="刪除" OnClientClick="javascript:return confirm('是否確定刪除?')" />
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                    </Columns>
                                </MasterTableView>
                            </telerik:RadGrid>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:Button ID="btnTMoveUp" runat="server" Text="上移" OnClick="btnTMoveUp_Click" />
                            &nbsp;
                            <asp:Button ID="btnTMoveDown" runat="server" Text="下移" OnClick="btnTMoveDown_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            
            <td width="50%" align="center" valign="top">
                <div>
                    <asp:Panel ID="Panel1" Enabled ="false" runat="server" BorderColor="Black" GroupingText="預覽">
                        <uc1:EduPassportItemControl ID="preControlS" runat="server" DisplayOnly="False" TargetType="S" />
                    </asp:Panel>
                    </div>
            </td>
            <td width="50%" align="center" valign="top">

                <div>
                    <asp:Panel ID="Panel2" Enabled ="false" runat="server" BorderColor="Black" GroupingText="預覽">
                        <uc1:EduPassportItemControl ID="preControlT" runat="server" DisplayOnly="False" TargetType="T" />
                    </asp:Panel>
                    </div>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">

                <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="儲存" />
&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnExit" runat="server" OnClick="btnExit_Click" Text="取消" />

            </td>
        </tr>
    </table>
</asp:Content>

