<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EduTermRun.aspx.cs" Inherits="EduTermRun" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>


<%@ Register src="TreeViewComboBox.ascx" tagname="TreeViewComboBox" tagprefix="uc1" %>
<%@ Register src="VsSelector.ascx" tagname="VsSelector" tagprefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 116px;
        }
    .RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default .rcbReadOnly .rcbInputCellLeft{background-position:0 -88px}.RadComboBox_Default .rcbReadOnly .rcbInputCellLeft{background-position:0 -88px}.RadComboBox_Default .rcbReadOnly .rcbInputCellLeft{background-position:0 -88px}.RadComboBox_Default .rcbInputCellLeft{background-position:0 0}.RadComboBox_Default .rcbInputCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbInputCell{width:100%;height:20px;_height:22px;line-height:20px;_line-height:22px;text-align:left;vertical-align:middle}.RadComboBox .rcbInputCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbInputCellLeft{background-position:0 0}.RadComboBox_Default .rcbInputCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbInputCell{width:100%;height:20px;_height:22px;line-height:20px;_line-height:22px;text-align:left;vertical-align:middle}.RadComboBox .rcbInputCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbInputCellLeft{background-position:0 0}.RadComboBox_Default .rcbInputCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbInputCell{width:100%;height:20px;_height:22px;line-height:20px;_line-height:22px;text-align:left;vertical-align:middle}.RadComboBox .rcbInputCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbReadOnly .rcbArrowCellRight{background-position:-162px -176px}.RadComboBox_Default .rcbReadOnly .rcbArrowCellRight{background-position:-162px -176px}.RadComboBox_Default .rcbReadOnly .rcbArrowCellRight{background-position:-162px -176px}.RadComboBox_Default .rcbArrowCellRight{background-position:-18px -176px}.RadComboBox_Default .rcbArrowCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbArrowCell{width:18px}.RadComboBox .rcbArrowCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbArrowCellRight{background-position:-18px -176px}.RadComboBox_Default .rcbArrowCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbArrowCell{width:18px}.RadComboBox .rcbArrowCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbArrowCellRight{background-position:-18px -176px}.RadComboBox_Default .rcbArrowCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbArrowCell{width:18px}.RadComboBox .rcbArrowCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}
    </style>
</head>
<body>
<script type="text/javascript">
    function GetRadWindow() {
        var oWindow = null;
        if (window.radWindow) oWindow = window.radWindow;
        else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow;
        return oWindow;
    }

    function CloseWindow(bool) {
        var oArg = new Object();
        oArg.NeedRefresh = bool;
        var oWnd = GetRadWindow();
        oWnd.close(oArg);
    } 

</script>

    <form id="form1" runat="server">
<div>



    <telerik:RadScriptManager ID="RadScriptManager1" Runat="server">
    </telerik:RadScriptManager>



<asp:Panel ID="CoursePanel" runat="server" GroupingText="課程">
<table width="100%">
<tr>
<td>
    <asp:Label ID="Label9" runat="server" Text="課程代碼："></asp:Label>
    <asp:Label ID="lblEduStopCode" runat="server"></asp:Label>
    </td>
<td>
    <asp:Label ID="Label10" runat="server" Text="名稱："></asp:Label>
    <asp:Label ID="lblName" runat="server"></asp:Label>
    </td>
<td>
    <asp:Label ID="Label11" runat="server" Text="訓練日期："></asp:Label>
    <asp:Label ID="lblDate" runat="server"></asp:Label>
    </td>
<td>
    <asp:Label ID="Label12" runat="server" Text="人數："></asp:Label>
    <asp:Label ID="lblMemberCount" runat="server"></asp:Label>
    </td>
</tr>
</table>

</asp:Panel>
</div>
<div>
<asp:Panel ID="Panel1" runat="server" GroupingText="開課">

<table width="100%">
<tr>
<td width="35%" valign="top">
    <div>
        <telerik:RadTabStrip ID="RadTabStrip1" runat="server" SelectedIndex="0" MultiPageID="RadMultiPage1">
            <Tabs>
                <telerik:RadTab runat="server" Selected="True" Text="選擇日期" PageViewID="rpvSelect">
                </telerik:RadTab>
                <telerik:RadTab runat="server" Text="自訂日期" PageViewID="rpvInput">
                </telerik:RadTab>
            </Tabs>
        </telerik:RadTabStrip>
        <telerik:RadMultiPage ID="RadMultiPage1" Runat="server" SelectedIndex="0">
            <telerik:RadPageView ID="rpvSelect" runat="server">
<table width="100%" heigh="100%">
<tr>
<td valign="top" align="right" width="80px">
    <asp:Label ID="Label8" runat="server" Text="課程日期："></asp:Label>
    </td>
<td valign="top" rowspan="2">
    <asp:Label ID="Label19" runat="server" Text="組別："></asp:Label>
    <uc1:TreeViewComboBox ID="TreeViewComboBox2" runat="server" AutoPostBack="True" 
        Enabled="True" TreeDataFieldID="EduTeamCode" 
        TreeDataFieldParentID="parentEduTeamCode" TreeDataSourceID="dsTermCode" 
        TreeDataTextField="EduTeamName" />
    <asp:ObjectDataSource ID="dsTermCode" runat="server" SelectMethod="GetEduTeams" 
        TypeName="KMU.EduActivity.ApplicationLayer.DTO.EduTeamDto">
    </asp:ObjectDataSource>
    <telerik:RadGrid ID="RadGrid2" runat="server" AllowMultiRowSelection="True" 
        AutoGenerateColumns="False" CellSpacing="0" Culture="zh-TW" 
        GridLines="None" onneeddatasource="RadGrid1_NeedDataSource" 
        style="margin-top: 0px" BorderStyle="None">
        <ClientSettings>
            <Selecting AllowRowSelect="True" />
        </ClientSettings>
        <MasterTableView commanditemdisplay="None" EditMode="PopUp" 
            nomasterrecordstext="目前沒有資料">
            <CommandItemSettings ExportToPdfText="Export to PDF" />
            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" 
                Visible="True">
                <HeaderStyle Width="20px" />
            </RowIndicatorColumn>
            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" 
                Visible="True">
                <HeaderStyle Width="20px" />
            </ExpandCollapseColumn>
            <Columns>
                <telerik:GridClientSelectColumn FilterControlAltText="Filter column column" 
                    UniqueName="column" HeaderText="全選">
                </telerik:GridClientSelectColumn>
                <telerik:GridBoundColumn DataField="DateFromToStr" HeaderText="時間"
                    FilterControlAltText="Filter EduStopCode column" 
                    UniqueName="DateFromToStr">
                </telerik:GridBoundColumn>
                <telerik:GridTemplateColumn FilterControlAltText="Filter tbColumn column" 
                    UniqueName="tbColumn" HeaderText="課程名稱">
                    <ItemTemplate>
                    <asp:TextBox ID="tbEduTermName" runat="server" Width="80px"></asp:TextBox>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
            </Columns>
            <EditFormSettings>
                <EditColumn canceltext="取消" edittext="儲存" 
                    FilterControlAltText="Filter EditCommandColumn column" inserttext="儲存" 
                    updatetext="儲存">
                </EditColumn>
                <PopUpSettings Modal="True" ScrollBars="Auto" Width="600px" />
            </EditFormSettings>
        </MasterTableView>
        <PagerStyle FirstPageToolTip="第一頁" LastPageToolTip="最末頁" NextPageToolTip="下一頁" 
            PagerTextFormat="跳至第: {4} &amp;nbsp;頁 &lt;strong&gt;{0}&lt;/strong&gt; / &lt;strong&gt;{1}&lt;/strong&gt;, 項目 &lt;strong&gt;{2}&lt;/strong&gt; - &lt;strong&gt;{3}&lt;/strong&gt; / &lt;strong&gt;{5}&lt;/strong&gt;." 
            PageSizeLabelText="每頁筆數:" PrevPagesToolTip="上一頁" PrevPageToolTip="上一頁" />
        <FilterMenu EnableImageSprites="False">
        </FilterMenu>
    </telerik:RadGrid>    
    </td>
</tr>
<tr>
<td></td>
</tr>
</table>

            </telerik:RadPageView>
            <telerik:RadPageView ID="rpvInput" runat="server">
                <table width="100%">
                    <tr>
                        <td>
                            <asp:Label ID="Label20" runat="server" Text="開始時間:"></asp:Label>
                        </td>
                        <td>
                            <telerik:RadDateTimePicker ID="rdtpSTime" Runat="server" Culture="en-US">
                                <TimeView CellSpacing="-1">
                                </TimeView>
                                <TimePopupButton HoverImageUrl="" ImageUrl="" />
                                <Calendar EnableWeekends="True" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False">
                                </Calendar>
                                <DateInput DateFormat="M/d/yyyy" DisplayDateFormat="M/d/yyyy" LabelWidth="40%">
                                    <EmptyMessageStyle Resize="None" />
                                    <ReadOnlyStyle Resize="None" />
                                    <FocusedStyle Resize="None" />
                                    <DisabledStyle Resize="None" />
                                    <InvalidStyle Resize="None" />
                                    <HoveredStyle Resize="None" />
                                    <EnabledStyle Resize="None" />
                                </DateInput>
                                <DatePopupButton HoverImageUrl="" ImageUrl="" />
                            </telerik:RadDateTimePicker>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label21" runat="server" Text="結束時間:"></asp:Label>
                        </td>
                        <td>
                            <telerik:RadDateTimePicker ID="rdtpETime" Runat="server" Culture="en-US">
                                <TimeView CellSpacing="-1">
                                </TimeView>
                                <TimePopupButton HoverImageUrl="" ImageUrl="" />
                                <Calendar EnableWeekends="True" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False">
                                </Calendar>
                                <DateInput DateFormat="M/d/yyyy" DisplayDateFormat="M/d/yyyy" LabelWidth="40%">
                                    <EmptyMessageStyle Resize="None" />
                                    <ReadOnlyStyle Resize="None" />
                                    <FocusedStyle Resize="None" />
                                    <DisabledStyle Resize="None" />
                                    <InvalidStyle Resize="None" />
                                    <HoveredStyle Resize="None" />
                                    <EnabledStyle Resize="None" />
                                </DateInput>
                                <DatePopupButton HoverImageUrl="" ImageUrl="" />
                            </telerik:RadDateTimePicker>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td align="right">
                            <asp:Button ID="btnAddTime" runat="server" Text="加入" OnClick="btnAddTime_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <telerik:RadGrid ID="rgAddTime" runat="server" AllowMultiRowSelection="True" AutoGenerateColumns="False" AutoGenerateDeleteColumn="True" BorderStyle="None" CellSpacing="0" Culture="zh-TW" GridLines="None" onneeddatasource="rgAddTime_NeedDataSource" style="margin-top: 0px" OnDeleteCommand="rgAddTime_DeleteCommand">
                                <MasterTableView commanditemdisplay="None" EditMode="PopUp" nomasterrecordstext="目前沒有資料" DataKeyNames="DateFrom,DateTo">
                                    <CommandItemSettings ExportToPdfText="Export to PDF" />
                                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="True">
                                        <HeaderStyle Width="20px" />
                                    </RowIndicatorColumn>
                                    <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" Visible="True">
                                        <HeaderStyle Width="20px" />
                                    </ExpandCollapseColumn>
                                    <Columns>
                                        <telerik:GridBoundColumn DataField="DateFromToStr" FilterControlAltText="Filter EduStopCode column" HeaderText="時間" UniqueName="DateFromToStr">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridTemplateColumn FilterControlAltText="Filter tbColumn column" HeaderText="課程名稱" UniqueName="tbColumn">
                                            <ItemTemplate>
                                                <asp:TextBox ID="tbEduTermName0" runat="server" Width="80px"></asp:TextBox>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                    </Columns>
                                    <EditFormSettings>
                                        <EditColumn canceltext="取消" edittext="儲存" FilterControlAltText="Filter EditCommandColumn column" inserttext="儲存" updatetext="儲存">
                                        </EditColumn>
                                        <PopUpSettings Modal="True" ScrollBars="Auto" Width="600px" />
                                    </EditFormSettings>
                                </MasterTableView>
                                <PagerStyle FirstPageToolTip="第一頁" LastPageToolTip="最末頁" NextPageToolTip="下一頁" PagerTextFormat="跳至第: {4} &amp;nbsp;頁 &lt;strong&gt;{0}&lt;/strong&gt; / &lt;strong&gt;{1}&lt;/strong&gt;, 項目 &lt;strong&gt;{2}&lt;/strong&gt; - &lt;strong&gt;{3}&lt;/strong&gt; / &lt;strong&gt;{5}&lt;/strong&gt;." PageSizeLabelText="每頁筆數:" PrevPagesToolTip="上一頁" PrevPageToolTip="上一頁" />
                                <FilterMenu EnableImageSprites="False">
                                </FilterMenu>
                            </telerik:RadGrid>
                        </td>
                    </tr>
                </table>
            </telerik:RadPageView>
        </telerik:RadMultiPage>
    </div>

</td>
<td width="65%" valign="top">
<table width = 100%>
<tr>
<td>
<asp:UpdatePanel runat="server" ID="UpdatePanel1">
<ContentTemplate>
    <table width="100%">
<%--    <tr>
    <td class="style1" align="right">
        &nbsp;</td>
    <td>
        <asp:TextBox ID="tbEduStopCode" runat="server"></asp:TextBox>
    </td>
    </tr>--%>

                    <tr>
                        <td class="style1" align="right">
                            <asp:Label ID="Label14" runat="server" Text="學年度："></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="tbEduYear" runat="server" MaxLength="3"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style1" align="right">
                            <asp:Label ID="Label15" runat="server" Text="職稱："></asp:Label>
                        </td>
                        <td>

                            <uc1:TreeViewComboBox ID="TreeViewComboBox1" runat="server" 
                                AllowSelectParent="False" AutoPostBack="False" Enabled="True" 
                                TreeDataFieldID="code" TreeDataFieldParentID="ParentCodeRefID" 
                                TreeDataSourceID="dsJobCode" TreeDataTextField="Name" />

                        </td>
                    </tr>
                    <tr>
                        <td class="style1" align="right">
                            <asp:Label ID="Label16" runat="server" Text="院區："></asp:Label>
                        </td>
                        <td>

                            <telerik:RadComboBox ID="ddlHospital" Runat="server" DataSourceID="dsHospital" 
                                DataTextField="name" DataValueField="code" Filter="Contains">
                            </telerik:RadComboBox>

                        </td>
                    </tr>
                    <tr>
                        <td class="style1" align="right">
                            <asp:Label ID="Label17" runat="server" Text="部門："></asp:Label>
                        </td>
                        <td>
  
                            <telerik:RadComboBox ID="ddlDepartment" Runat="server" Filter="Contains">
                            </telerik:RadComboBox>
  
                        </td>
                    </tr>
    <tr>
    <td class="style1" align="right">
        <asp:Label ID="Label2" runat="server" Text="名稱："></asp:Label>
    </td>
    <td>
        <asp:TextBox ID="tbName" runat="server"></asp:TextBox>
    </td>
    </tr>
    <tr>
    <td class="style1" align="right">
        <asp:Label ID="Label4" runat="server" Text="歸屬類別："></asp:Label>
    </td>
    <td>
        <asp:RadioButtonList ID="rblType" runat="server" 
            RepeatDirection="Horizontal" 
            onselectedindexchanged="rblType_SelectedIndexChanged" AutoPostBack="True">
            <asp:ListItem>科別</asp:ListItem>
            <asp:ListItem>護士站</asp:ListItem>
            <asp:ListItem>醫師</asp:ListItem>
        </asp:RadioButtonList>
    </td>
    </tr>
    <tr>
    <td class="style1" align="right">
        <asp:Label ID="Label5" runat="server" Text="單位/VS："></asp:Label>
    </td>
    <td>
          <uc2:VsSelector ID="rcbVS" runat="server" />
          <div runat="server" id="divUnit">
                <telerik:RadComboBox ID="ddlUnit" Runat="server" Filter="Contains">
                </telerik:RadComboBox>
          </div>
    </td>
    </tr>
    <tr>
    <td class="style1" align="right">
        <asp:Label ID="Label1" runat="server" Text="科導師："></asp:Label>
    </td>
    <td>

        <uc2:VsSelector ID="ddlTeacher" runat="server" />

    </td>
    </tr>
    <tr>
    <td class="style1" align="right">
        <asp:Label ID="Label13" runat="server" Text="總醫師："></asp:Label>
    </td>
    <td>
        <uc2:VsSelector ID="rcbCR" runat="server" />
    </td>
    </tr>
    <tr>
    <td class="style1" align="right">
        <asp:Label ID="Label3" runat="server" Text="EBM窗口老師："></asp:Label>
    </td>
    <td>

        <uc2:VsSelector ID="ddlEBM" runat="server" />

    </td>
    </tr>

    <tr>
    <td class="style1" align="right">
        <asp:Label ID="Label18" runat="server" Text="計劃主持人："></asp:Label>
    </td>
    <td>

        <uc2:VsSelector ID="rcbProjM" runat="server" />

    </td>
    </tr>

    <tr>
    <td class="style1" align="right">
        <asp:Label ID="Label22" runat="server" Text="教學長："></asp:Label>
    </td>
    <td>

        <uc2:VsSelector ID="rcbTMaster" runat="server" />

    </td>
    </tr>

    <tr>
    <td class="style1" align="right">
        <asp:Label ID="Label6" runat="server" Text="人數："></asp:Label>
    </td>
    <td>
        <telerik:RadNumericTextBox ID="rntbStudentCount" Runat="server" Height="21px" 
            Width="49px" MinValue="0">
            <NumberFormat DecimalDigits="0" ZeroPattern="n" />
        </telerik:RadNumericTextBox>
    </td>
    </tr>
    <tr>
    <td class="style1" align="right">
        <asp:Label ID="Label7" runat="server" Text="說明："></asp:Label>
    </td>
    <td>
        <asp:TextBox ID="tbDes" runat="server" Width="336px"></asp:TextBox>
    </td>
    </tr>
    <tr>
    <td class="style1" align="right">
    </td>
    <td>
    </td>
    </tr>
    </table>
</ContentTemplate>
</asp:UpdatePanel>

</td>
</tr>
<tr>
<td>        <asp:Button ID="btnSubmit" runat="server" Text="儲存" Width="60px" 
            onclick="btnSubmit_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnCancel" runat="server" Text="取消" Width="54px" 
            onclientclick="CloseWindow(false);" /></td>
</tr>
</table>


</td>
</tr>
<tr>
<td colspan="2">
    <telerik:RadGrid ID="RadGrid1" runat="server" AllowMultiRowSelection="True" 
        AllowPaging="True" AutoGenerateColumns="False" CellSpacing="0" Culture="zh-TW" 
        GridLines="None" onneeddatasource="RadGrid1_NeedDataSource" 
        style="margin-top: 0px">
        <ClientSettings>
            <Selecting AllowRowSelect="True" />
        </ClientSettings>
        <MasterTableView commanditemdisplay="None" EditMode="PopUp" 
            nomasterrecordstext="目前沒有資料">
            <CommandItemSettings ExportToPdfText="Export to PDF" />
            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" 
                Visible="True">
                <HeaderStyle Width="20px" />
            </RowIndicatorColumn>
            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" 
                Visible="True">
                <HeaderStyle Width="20px" />
            </ExpandCollapseColumn>
            <Columns>
                <telerik:GridClientSelectColumn FilterControlAltText="Filter column column" 
                    UniqueName="column">
                </telerik:GridClientSelectColumn>
                <telerik:GridBoundColumn DataField="EduStopCode" 
                    FilterControlAltText="Filter EduStopCode column" HeaderText="課程代碼" 
                    UniqueName="EduStopCode">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Name" 
                    FilterControlAltText="Filter Name column" HeaderText="名稱" UniqueName="Name">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="DateFromToStr" 
                    FilterControlAltText="Filter EduTeamCode column" HeaderText="訓練起訖日期" 
                    ReadOnly="True" UniqueName="DateFromToStr">
                </telerik:GridBoundColumn>
                <telerik:GridDateTimeColumn DataField="DateFrom" 
                    FilterControlAltText="Filter DateFrom column" HeaderText="訓練開始日期" 
                    UniqueName="DateFrom" Visible="False">
                </telerik:GridDateTimeColumn>
                <telerik:GridDateTimeColumn DataField="DateTo" 
                    FilterControlAltText="Filter DateTo column" HeaderText="訓練結束日期" 
                    UniqueName="DateTo" Visible="False">
                </telerik:GridDateTimeColumn>
                <telerik:GridBoundColumn DataField="UnitName" 
                    FilterControlAltText="Filter UnitName column" HeaderText="單位" 
                    UniqueName="UnitName">
                </telerik:GridBoundColumn>
                <telerik:GridNumericColumn DataField="Capacity" DecimalDigits="2" 
                    FilterControlAltText="Filter Capacity column" HeaderText="訓練人數" 
                    UniqueName="Capacity">
                </telerik:GridNumericColumn>
                <telerik:GridBoundColumn DataField="Status" 
                    FilterControlAltText="Filter Status column" HeaderText="狀態" UniqueName="Status">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Des" 
                    FilterControlAltText="Filter Des column" HeaderText="備註" UniqueName="Des">
                </telerik:GridBoundColumn>
            </Columns>
            <EditFormSettings>
                <EditColumn canceltext="取消" edittext="儲存" 
                    FilterControlAltText="Filter EditCommandColumn column" inserttext="儲存" 
                    updatetext="儲存">
                </EditColumn>
                <PopUpSettings Modal="True" ScrollBars="Auto" Width="600px" />
            </EditFormSettings>
        </MasterTableView>
        <PagerStyle FirstPageToolTip="第一頁" LastPageToolTip="最末頁" NextPageToolTip="下一頁" 
            PagerTextFormat="跳至第: {4} &amp;nbsp;頁 &lt;strong&gt;{0}&lt;/strong&gt; / &lt;strong&gt;{1}&lt;/strong&gt;, 項目 &lt;strong&gt;{2}&lt;/strong&gt; - &lt;strong&gt;{3}&lt;/strong&gt; / &lt;strong&gt;{5}&lt;/strong&gt;." 
            PageSizeLabelText="每頁筆數:" PrevPagesToolTip="上一頁" PrevPageToolTip="上一頁" />
        <FilterMenu EnableImageSprites="False">
        </FilterMenu>
    </telerik:RadGrid>
    </td>
</tr>
</table>

</asp:Panel>
</div>



    <asp:ObjectDataSource ID="dsJobCode" runat="server" SelectMethod="GetCodeRefsStatic" 
        TypeName="KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService" 
        DataObjectTypeName="KMU.EduActivity.ApplicationLayer.DTO.V_CodeRefDto" 
        onselected="dsJobCode_Selected">
        <SelectParameters>
            <asp:Parameter DefaultValue="EduAct_JobSerial" Name="codetype" />
        </SelectParameters>
    </asp:ObjectDataSource>
    
    <asp:ObjectDataSource ID="dsHospital" runat="server" SelectMethod="GetCodeRefsStatic" 
        TypeName="KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService" 
        DataObjectTypeName="KMU.EduActivity.ApplicationLayer.DTO.V_CodeRefDto">
        <SelectParameters>
            <asp:Parameter DefaultValue="EduAct_Hospital" Name="codetype" />
        </SelectParameters>
    </asp:ObjectDataSource>
    
    </form>
</body>
</html>
