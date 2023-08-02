<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="OSCEScoreEdit.aspx.cs" Inherits="OSCEScoreEdit" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<%@ Register src="VsSelector.ascx" tagname="VsSelector" tagprefix="uc1" %>

<%@ Register src="TreeViewComboBox.ascx" tagname="TreeViewComboBox" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
.RadGrid_Default{border:1px solid #828282;background-color:white;color:#333;font-family:"Segoe UI",Arial,Helvetica,sans-serif;font-size:12px;line-height:16px}.RadGrid_Default{border:1px solid #828282;background-color:white;color:#333;font-family:"Segoe UI",Arial,Helvetica,sans-serif;font-size:12px;line-height:16px}.RadGrid_Default{border:1px solid #828282;background-color:white;color:#333;font-family:"Segoe UI",Arial,Helvetica,sans-serif;font-size:12px;line-height:16px}.RadGrid_Default{border:1px solid #828282;background-color:white;color:#333;font-family:"Segoe UI",Arial,Helvetica,sans-serif;font-size:12px;line-height:16px}.RadGrid_Default .rgMasterTable{font-family:"Segoe UI",Arial,Helvetica,sans-serif;font-size:12px;line-height:16px}.RadGrid .rgMasterTable{border-collapse:separate;border-spacing:0}.RadGrid_Default .rgMasterTable{font-family:"Segoe UI",Arial,Helvetica,sans-serif;font-size:12px;line-height:16px}.RadGrid .rgMasterTable{border-collapse:separate;border-spacing:0}.RadGrid_Default .rgMasterTable{font-family:"Segoe UI",Arial,Helvetica,sans-serif;font-size:12px;line-height:16px}.RadGrid .rgMasterTable{border-collapse:separate;border-spacing:0}.RadGrid_Default .rgMasterTable{font-family:"Segoe UI",Arial,Helvetica,sans-serif;font-size:12px;line-height:16px}.RadGrid .rgMasterTable{border-collapse:separate;border-spacing:0}.RadGrid table.rgMasterTable tr .rgExpandCol{padding-left:0;padding-right:0;text-align:center}.RadGrid table.rgMasterTable tr .rgExpandCol{padding-left:0;padding-right:0;text-align:center}.RadGrid table.rgMasterTable tr .rgExpandCol{padding-left:0;padding-right:0;text-align:center}.RadGrid table.rgMasterTable tr .rgExpandCol{padding-left:0;padding-right:0;text-align:center}.RadGrid_Default .rgHeader{color:#333}.RadGrid_Default .rgHeader{border:0;border-bottom:1px solid #828282;background:#eaeaea 0 -2300px repeat-x url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Grid.sprite.gif')}.RadGrid .rgHeader{padding-top:5px;padding-bottom:4px;text-align:left;font-weight:normal}.RadGrid .rgHeader{padding-left:7px;padding-right:7px}.RadGrid .rgHeader{cursor:default}.RadGrid_Default .rgHeader{color:#333}.RadGrid_Default .rgHeader{border:0;border-bottom:1px solid #828282;background:#eaeaea 0 -2300px repeat-x url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Grid.sprite.gif')}.RadGrid .rgHeader{padding-top:5px;padding-bottom:4px;text-align:left;font-weight:normal}.RadGrid .rgHeader{padding-left:7px;padding-right:7px}.RadGrid .rgHeader{cursor:default}.RadGrid_Default .rgHeader{color:#333}.RadGrid_Default .rgHeader{border:0;border-bottom:1px solid #828282;background:#eaeaea 0 -2300px repeat-x url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Grid.sprite.gif')}.RadGrid .rgHeader{padding-top:5px;padding-bottom:4px;text-align:left;font-weight:normal}.RadGrid .rgHeader{padding-left:7px;padding-right:7px}.RadGrid .rgHeader{cursor:default}.RadGrid_Default .rgHeader{color:#333}.RadGrid_Default .rgHeader{border:0;border-bottom:1px solid #828282;background:#eaeaea 0 -2300px repeat-x url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Grid.sprite.gif')}.RadGrid .rgHeader{padding-top:5px;padding-bottom:4px;text-align:left;font-weight:normal}.RadGrid .rgHeader{padding-left:7px;padding-right:7px}.RadGrid .rgHeader{cursor:default}
        .style1
        {
            border-color: #d9d9d9;
            background: #d9d9d9;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    
    <div>

                <table width="100%">
                    <tr>
                        <td class="style1" align="right">
                            <asp:Label ID="Label12" runat="server" Text="考試名稱："></asp:Label>
                        </td>
                        <td>

                            <asp:TextBox ID="tbExamName" runat="server" Width="345px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style1" align="right">
                            <asp:Label ID="Label1" runat="server" Text="考試日期："></asp:Label>
                        </td>
                        <td>

                            <telerik:RadDatePicker ID="rdpExamDate" Runat="server">
                            </telerik:RadDatePicker>
                        </td>
                    </tr>
                    <tr>
                        <td class="style1" align="right">
                            <asp:Label ID="Label2" runat="server" Text="及格站數："></asp:Label>
                        </td>
                        <td>

                            <telerik:RadNumericTextBox ID="rntbPassStage" Runat="server" Culture="zh-TW" DbValueFactor="1" LabelWidth="64px" MinValue="0" Width="100px">
<NegativeStyle Resize="None"></NegativeStyle>

<NumberFormat ZeroPattern="n" DecimalDigits="0"></NumberFormat>

<EmptyMessageStyle Resize="None"></EmptyMessageStyle>

<ReadOnlyStyle Resize="None"></ReadOnlyStyle>

<FocusedStyle Resize="None"></FocusedStyle>

<DisabledStyle Resize="None"></DisabledStyle>

<InvalidStyle Resize="None"></InvalidStyle>

<HoveredStyle Resize="None"></HoveredStyle>

<EnabledStyle Resize="None"></EnabledStyle>
                            </telerik:RadNumericTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style1" align="right">
                            <asp:Label ID="Label4" runat="server" Text="考試院區："></asp:Label>
                        </td>
                        <td>

                            <asp:DropDownList ID="ddlHosp" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="style1" align="right">
                            <asp:Label ID="Label23" runat="server" Text="關卡："></asp:Label>
                        </td>
                        <td>

                            <asp:Label ID="Label25" runat="server" Text="關卡順序："></asp:Label>
                            <telerik:RadNumericTextBox ID="rntbStageNo" Runat="server" Culture="zh-TW" DbValueFactor="1" LabelWidth="64px" MinValue="0" Width="100px">
<NegativeStyle Resize="None"></NegativeStyle>

<NumberFormat ZeroPattern="n" DecimalDigits="0"></NumberFormat>

<EmptyMessageStyle Resize="None"></EmptyMessageStyle>

<ReadOnlyStyle Resize="None"></ReadOnlyStyle>

<FocusedStyle Resize="None"></FocusedStyle>

<DisabledStyle Resize="None"></DisabledStyle>

<InvalidStyle Resize="None"></InvalidStyle>

<HoveredStyle Resize="None"></HoveredStyle>

<EnabledStyle Resize="None"></EnabledStyle>
                            </telerik:RadNumericTextBox>
                            <br />
                            <asp:Label ID="Label24" runat="server" Text="關卡名稱："></asp:Label>
                            <asp:TextBox ID="tbStageName" runat="server" Width="242px"></asp:TextBox>
                            <br />
                            <asp:Label ID="Label26" runat="server" Text="及格分數："></asp:Label>
                            <telerik:RadNumericTextBox ID="rntbPassScore" Runat="server" Culture="zh-TW" DbValueFactor="1" LabelWidth="64px" MinValue="0" Width="100px">
<NegativeStyle Resize="None"></NegativeStyle>

<NumberFormat ZeroPattern="n" DecimalDigits="2"></NumberFormat>

<EmptyMessageStyle Resize="None"></EmptyMessageStyle>

<ReadOnlyStyle Resize="None"></ReadOnlyStyle>

<FocusedStyle Resize="None"></FocusedStyle>

<DisabledStyle Resize="None"></DisabledStyle>

<InvalidStyle Resize="None"></InvalidStyle>

<HoveredStyle Resize="None"></HoveredStyle>

<EnabledStyle Resize="None"></EnabledStyle>
                            </telerik:RadNumericTextBox>
                            <br />
                                    <asp:Button ID="btnAddStage" runat="server" OnClick="btnAddStage_Click" Text="加入" />


                                <telerik:RadGrid ID="rgStage" runat="server" AutoGenerateColumns="False" AutoGenerateDeleteColumn="True" CellSpacing="0" GridLines="None" OnDeleteCommand="rgStage_DeleteCommand" Culture="zh-TW">
                                    <MasterTableView DataKeyNames="ExamID,StageNo">
                                        <Columns>
                                            <telerik:GridBoundColumn DataField="StageNo" FilterControlAltText="Filter TargetType column" HeaderText="順序" UniqueName="StageNo">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="StageName" FilterControlAltText="Filter TargetName column" HeaderText="關卡名稱" UniqueName="StageName">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="PassScore" FilterControlAltText="Filter PassScore column" HeaderText="及格分數" UniqueName="PassScore">
                                            </telerik:GridBoundColumn>
                                        </Columns>
                                    </MasterTableView>
                                </telerik:RadGrid>


                            </td>
                    </tr>
                    <tr>
                    <td class="style1" align="right">
                        <asp:Label ID="lbScore" runat="server" Text="成績單：" Visible="False"></asp:Label>
                        </td>
                    <td>
                        <asp:Panel ID="panScore" runat="server" Visible="false">
                            <asp:HyperLink ID="linkSample" runat="server" NavigateUrl="~/docs/OSCE成績上傳範例.xls">上傳檔案範例</asp:HyperLink>
                            <asp:FileUpload ID="FileUpload1" runat="server" />
                            <asp:Button ID="btnUpload" runat="server" OnClick="btnUpload_Click" Text="上傳" />
                            <asp:Label ID="Label27" runat="server" Font-Bold="True" ForeColor="Red" Text="*上傳會直接覆蓋並更新目前的名單"></asp:Label>


                                <telerik:RadGrid ID="rgScore" runat="server" AutoGenerateColumns="False" CellSpacing="0" GridLines="None" Culture="zh-TW">
                                    <MasterTableView DataKeyNames="EmpCode,StageNo,ExamID">
                                        <Columns>
                                            <telerik:GridBoundColumn DataField="EmpCode" FilterControlAltText="Filter TargetType column" HeaderText="職編" UniqueName="EmpCode">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="StageNo" FilterControlAltText="Filter TargetName column" HeaderText="關卡" UniqueName="StageNo">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Score" FilterControlAltText="Filter PassScore column" HeaderText="分數" UniqueName="Score">
                                            </telerik:GridBoundColumn>
                                        </Columns>
                                    </MasterTableView>
                                </telerik:RadGrid>
                            </asp:Panel>

                        </td>
                    </tr>
                    <tr>
                        <td class="style1" align="right">
                        </td>
                        <td>
                            <asp:Button ID="btnSubmit" runat="server" Text="儲存" onclick="btnSubmit_Click" />
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnCancel" runat="server" Text="回清單" onclick="btnCancel_Click" />
                        </td>
                    </tr>
                </table>

    </div>
        </asp:Content>

