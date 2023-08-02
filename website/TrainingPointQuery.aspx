<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="TrainingPointQuery.aspx.cs" Inherits="TrainingPointQuery" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}
.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}
.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}
    .RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default .rcbReadOnly .rcbInputCellLeft{background-position:0 -88px}.RadComboBox_Default .rcbInputCellLeft{background-position:0 0}.RadComboBox_Default .rcbInputCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbInputCell{width:100%;height:20px;_height:22px;line-height:20px;_line-height:22px;text-align:left;vertical-align:middle}.RadComboBox .rcbInputCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}
    .RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbReadOnly .rcbArrowCellRight{background-position:-162px -176px}.RadComboBox_Default .rcbArrowCellRight{background-position:-18px -176px}.RadComboBox_Default .rcbArrowCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbArrowCell{width:18px}.RadComboBox .rcbArrowCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadPicker{vertical-align:middle}.rdfd_{position:absolute}.RadPicker .rcTable{table-layout:auto}.RadPicker .RadInput{vertical-align:baseline}.RadInput_Default{font:12px "segoe ui",arial,sans-serif}.RadInput{vertical-align:middle}.RadInput .riTextBox{height:17px}
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
                <div>
                    <table width="100%">
                        <tr>
                            <td colspan="2">
                <font color="red" style="font-size:medium"><b>
                <pre>
●教學點數：
   -主治醫師教學點數：近三年教學點數達到30點，且每年不得低於8點，或最近三年之教學點數達35點，且每年不得低於6點。
   -總住院醫師教學點數：具有教學點數每年至少4點。
●訓練時數：
   -主治醫師訓練時數：近三年教師成長教育訓練時數達到15小時，且每年不得低於3小時。
  - 總住院醫師訓練時數：每年教師成長教育訓練時數至少5小時。
●教學時數：本校醫學院教師擔任附屬機構各醫療單位主治醫師身分者，每週基本授課時數以4小時為原則。
</pre></b></font>

                            </td>
                        </tr>
                        <tr>
                            <td width="80px">

                                <asp:Label ID="Label21" runat="server" Text="訓練日期："></asp:Label>

                            </td>
                            <td>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:RadioButton ID="rbByEduYear" runat="server" Checked="True" GroupName="DateType" Text="依學年" />
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlEduYear" runat="server">
                                            </asp:DropDownList>
                                            <asp:Label ID="Label22" runat="server" Text="學年度"></asp:Label>
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
                                        <td>
                                <telerik:RadDatePicker ID="rdpSdate" Runat="server">
                                </telerik:RadDatePicker>
                                        </td>
                                        <td>
                                            ~
                                        </td>
                                        <td>
                                <telerik:RadDatePicker ID="rdpEdate" Runat="server">
                                </telerik:RadDatePicker>
                                        </td>
                                    </tr>
                                </table>


                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Panel runat="server" ID="panManager">
                                    <table>
                                        <tr>
                                            <td><asp:Label ID="lbEmpCode" runat="server" Text="員工編號(多人以逗點分隔)："></asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="tbEmpCode" runat="server" Width="429px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td><asp:Label ID="Label1" runat="server" Text="指定職稱："></asp:Label></td>
                                            <td>
                                                
                                                <telerik:RadComboBox ID="rcbFilterJob" Runat="server" AllowCustomText="True" CheckBoxes="True" DataTextField="name" DataValueField="code" Filter="Contains" MaxHeight="300px" Width="350px">
                                                </telerik:RadComboBox>
                                                
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>

                        </tr>
                        <tr>
                            <td>

                                <asp:Button ID="btnQuery" runat="server" OnClick="btnQuery_Click" Text="查詢" />
                            </td>
                            <td>
                                <asp:Button ID="btnExport" runat="server" OnClick="btnExport_Click" Text="匯出" />
                            </td>

                        </tr>
                    </table>
                </div>
                <div>

                    <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" CellSpacing="0" Culture="zh-TW" GridLines="None" OnNeedDataSource="RadGrid1_NeedDataSource">
                        <ClientSettings>
                            <Selecting AllowRowSelect="True" />
                        </ClientSettings>
                        <MasterTableView DataKeyNames="ID">
                            <Columns>
                                <telerik:GridBoundColumn DataField="EduYear" FilterControlAltText="Filter EduYear column" HeaderText="學年度" UniqueName="EduYear">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="semester" FilterControlAltText="Filter semester column" HeaderText="學期" UniqueName="semester">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Hospital" FilterControlAltText="Filter Hospital column" HeaderText="地點" UniqueName="Hospital">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="empcode" FilterControlAltText="Filter empcode column" HeaderText="職員編號" UniqueName="empcode">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="empname" FilterControlAltText="Filter empname column" HeaderText="姓名" UniqueName="empname">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="depname" FilterControlAltText="Filter depname column" HeaderText="單位" UniqueName="depname">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="titlename" FilterControlAltText="Filter titlename column" HeaderText="職稱" UniqueName="titlename">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="role" FilterControlAltText="Filter role column" HeaderText="角色" UniqueName="role">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="trainingtime1" FilterControlAltText="Filter trainingtime1 column" HeaderText="日期" UniqueName="trainingtime1">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="timehour" FilterControlAltText="Filter timehour column" HeaderText="時數" UniqueName="timehour">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="classname" FilterControlAltText="Filter classname column" HeaderText="課程說明" UniqueName="classname">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="classtype" FilterControlAltText="Filter classtype column" HeaderText="課程性質" UniqueName="classtype">
                                </telerik:GridBoundColumn>
                                <telerik:GridDateTimeColumn DataField="CreateTime" FilterControlAltText="Filter CreateTime column" HeaderText="上傳時間" UniqueName="CreateTime">
                                </telerik:GridDateTimeColumn>
                            </Columns>
                        </MasterTableView>
                    </telerik:RadGrid>

                </div>   

</asp:Content>

