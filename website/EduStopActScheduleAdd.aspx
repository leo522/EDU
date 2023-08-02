<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="EduStopActScheduleAdd.aspx.cs" Inherits="EduStopActScheduleAdd" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="TreeViewComboBox.ascx" TagName="TreeViewComboBox" TagPrefix="uc1" %>
<%@ Register Src="VsSelector.ascx" TagName="VsSelector" TagPrefix="uc2" %>
<%@ Register src="DeptSelector.ascx" tagname="DeptSelector" tagprefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style type="text/css">
        .RadGrid_Default
        {
            border: 1px solid #828282;
            background-color: white;
            color: #333;
            font-family: "Segoe UI",Arial,Helvetica,sans-serif;
            font-size: 12px;
            line-height: 16px;
        }

        .RadGrid_Default
        {
            border: 1px solid #828282;
            background-color: white;
            color: #333;
            font-family: "Segoe UI",Arial,Helvetica,sans-serif;
            font-size: 12px;
            line-height: 16px;
        }

            .RadGrid_Default .rgMasterTable
            {
                font-family: "Segoe UI",Arial,Helvetica,sans-serif;
                font-size: 12px;
                line-height: 16px;
            }

        .RadGrid .rgMasterTable
        {
            border-collapse: separate;
            border-spacing: 0;
        }

        .RadGrid_Default .rgMasterTable
        {
            font-family: "Segoe UI",Arial,Helvetica,sans-serif;
            font-size: 12px;
            line-height: 16px;
        }

        .RadGrid .rgMasterTable
        {
            border-collapse: separate;
            border-spacing: 0;
        }

        .RadGrid table.rgMasterTable tr .rgExpandCol
        {
            padding-left: 0;
            padding-right: 0;
            text-align: center;
        }

        .RadGrid table.rgMasterTable tr .rgExpandCol
        {
            padding-left: 0;
            padding-right: 0;
            text-align: center;
        }

        .RadGrid_Default .rgHeader
        {
            color: #333;
        }

        .RadGrid_Default .rgHeader
        {
            border: 0;
            border-bottom: 1px solid #828282;
            background: #eaeaea 0 -2300px repeat-x url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Grid.sprite.gif');
        }

        .RadGrid .rgHeader
        {
            padding-top: 5px;
            padding-bottom: 4px;
            text-align: left;
            font-weight: normal;
        }

        .RadGrid .rgHeader
        {
            padding-left: 7px;
            padding-right: 7px;
        }

        .RadGrid .rgHeader
        {
            cursor: default;
        }

        .RadGrid_Default .rgHeader
        {
            color: #333;
        }

        .RadGrid_Default .rgHeader
        {
            border: 0;
            border-bottom: 1px solid #828282;
            background: #eaeaea 0 -2300px repeat-x url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Grid.sprite.gif');
        }

        .RadGrid .rgHeader
        {
            padding-top: 5px;
            padding-bottom: 4px;
            text-align: left;
            font-weight: normal;
        }

        .RadGrid .rgHeader
        {
            padding-left: 7px;
            padding-right: 7px;
        }

        .RadGrid .rgHeader
        {
            cursor: default;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <table width="100%">
        <tr>
            <td width="100px" align="center" valign="top" style="min-width: 100px">
                <table width="80%">
                    <tr>
                        <td style="background-color: Aqua">&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:LinkButton ID="btnAdd" runat="server" PostBackUrl="~/EduStopActScheduleAdd.aspx">新增活動</asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:LinkButton ID="btnCalendar" runat="server" PostBackUrl="~/EduStopActScheduleCalendar.aspx">行事曆</asp:LinkButton>
                            <asp:ObjectDataSource ID="dsTargetType" runat="server" SelectMethod="GetCodeRefsStatic"
                                TypeName="KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService" DataObjectTypeName="KMU.EduActivity.ApplicationLayer.DTO.V_CodeRefDto">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="EduAct_ActTargetType" Name="codetype" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                            <asp:ObjectDataSource ID="dsRoleType" runat="server" SelectMethod="GetCodeRefsStatic"
                                TypeName="KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService" DataObjectTypeName="KMU.EduActivity.ApplicationLayer.DTO.V_CodeRefDto">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="EduAct_ActRoleType" Name="codetype" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                            <asp:ObjectDataSource ID="dsTermCode" runat="server" SelectMethod="GetEduTeams" TypeName="KMU.EduActivity.ApplicationLayer.DTO.EduTeamDto"></asp:ObjectDataSource>
                            <asp:ObjectDataSource ID="dsJobCode" runat="server" SelectMethod="GetJobCodes" TypeName="KMU.EduActivity.ApplicationLayer.DTO.SelectEduActJobCodeDto"></asp:ObjectDataSource>
                        </td>
                    </tr>
                </table>
            </td>
            <td>
                <telerik:RadTabStrip ID="RadTabStrip1" runat="server" MultiPageID="RadMultiPage1"
                    SelectedIndex="0" Skin="WebBlue">
                    <Tabs>
                        <telerik:RadTab runat="server" PageViewID="RadPageView1" Text="活動內容" Selected="True">
                        </telerik:RadTab>
                        <telerik:RadTab runat="server" PageViewID="RadPageView2" Text="活動對象">
                        </telerik:RadTab>
                    </Tabs>
                </telerik:RadTabStrip>
                <telerik:RadMultiPage ID="RadMultiPage1" runat="server" BorderColor="Black" BorderStyle="Solid"
                    BorderWidth="1px" SelectedIndex="0" Width="98%">
                    <telerik:RadPageView ID="RadPageView1" runat="server" Selected="True">
                        <table width="100%">
                            <tr>
                                <td width="10%" bgcolor="#DEDEE9" align="right">
                                    <asp:Label ID="Label2" runat="server" Font-Bold="False" ForeColor="Red" Text="*"></asp:Label><asp:Label
                                        ID="Label1" runat="server" Font-Bold="True" Text="公告科室："></asp:Label></td>
                                <td width="90%" align="left">
                                    <uc3:DeptSelector ID="DeptSelector1" runat="server" WithEmptyDept="true" />
                                    &nbsp;&nbsp;<asp:CheckBox ID="cbAll" runat="server" Text="全院公告" Visible="False" /></td>
                            </tr>
                            <tr>
                                <td width="10%" bgcolor="#DEDEE9" align="right">
                                    <asp:Label ID="Label3" runat="server" Font-Bold="False" ForeColor="Red" Text="*"></asp:Label><asp:Label
                                        ID="Label4" runat="server" Font-Bold="True" Text="活動類型："></asp:Label></td>
                                <td width="90%" align="left">
                                    <table>
                                        <tr>
                                            <td>
                                                <telerik:RadComboBox ID="rcbType1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rcbType1_SelectedIndexChanged"
                                                    NoWrap="True">
                                                </telerik:RadComboBox>
                                            </td>
                                            <td>
                                                <telerik:RadComboBox ID="rcbType2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rcbType2_SelectedIndexChanged"
                                                    NoWrap="True">
                                                </telerik:RadComboBox>
                                            </td>
                                            <td>
                                                <telerik:RadComboBox ID="rcbType3" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rcbType3_SelectedIndexChanged"
                                                    NoWrap="True">
                                                </telerik:RadComboBox>
                                            </td>
                                            <td>
                                                <telerik:RadComboBox ID="rcbType4" runat="server" NoWrap="True"></telerik:RadComboBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" align="center">
                                                <asp:Button ID="btnAddType" runat="server" Visible="false" Text="加入類別" OnClick="btnAddType_Click" />
                                            </td>

                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <telerik:RadGrid ID="rgActType" runat="server" Visible="false" AutoGenerateColumns="False" AutoGenerateDeleteColumn="True" CellSpacing="0" GridLines="None" OnDeleteCommand="rgActType_DeleteCommand" OnNeedDataSource="rgActType_NeedDataSource">
                                                    <MasterTableView DataKeyNames="CLS_ID">
                                                        <Columns>
                                                            <telerik:GridBoundColumn DataField="CLS_NAME" FilterControlAltText="Filter CLS_NAME column" HeaderText="活動類型" UniqueName="CLS_NAME">
                                                            </telerik:GridBoundColumn>
                                                        </Columns>
                                                    </MasterTableView>
                                                </telerik:RadGrid>
                                            </td>

                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td width="10%" bgcolor="#DEDEE9" align="right">
                                    <asp:Label ID="Label5" runat="server" Font-Bold="False" ForeColor="Red" Text="*"></asp:Label><asp:Label
                                        ID="Label6" runat="server" Font-Bold="True" Text="活動主題："></asp:Label></td>
                                <td width="90%" align="left">
                                    <asp:TextBox ID="tbActName" runat="server" Width="363px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td width="10%" bgcolor="#DEDEE9" align="right">
                                    <asp:Label ID="Label8" runat="server" Font-Bold="True" Text="有效日期："></asp:Label></td>
                                <td width="90%" align="left">
                                    <table>
                                        <tr>
                                            <td>
                                                <telerik:RadDatePicker ID="rdpDisplayTimeFrom" runat="server"></telerik:RadDatePicker>
                                            </td>
                                            <td>~ </td>
                                            <td>
                                                <telerik:RadDatePicker ID="rdpDisplayTimeTo" runat="server"></telerik:RadDatePicker>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label18" runat="server" ForeColor="Red" Text="* 日期一到自動自公告地點撤除"></asp:Label></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td width="10%" bgcolor="#DEDEE9" align="right">
                                    <asp:Label ID="Label10" runat="server" Font-Bold="True" Text="活動規模："></asp:Label></td>
                                <td width="90%" align="left">
                                    <asp:RadioButtonList ID="rblActRange" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Selected="True">科內</asp:ListItem>
                                        <asp:ListItem>跨科</asp:ListItem>
                                        <asp:ListItem>全院性</asp:ListItem>
                                        <asp:ListItem>院際性(含院外人士)</asp:ListItem>
                                        <asp:ListItem>院外舉辦</asp:ListItem>
                                    </asp:RadioButtonList></td>
                            </tr>
                            <tr>
                                <td width="10%" bgcolor="#DEDEE9" align="right">
                                    <asp:Label ID="Label24" runat="server" Font-Bold="True" Text="記錄類別："></asp:Label></td>
                                <td width="90%" align="left">

                                    <telerik:RadComboBox ID="rcbRecordTemplate" Runat="server" Width="300px">
                                    </telerik:RadComboBox>

                                </td>
                            </tr>
                            <tr>
                                <td width="10%" bgcolor="#DEDEE9" align="right">
                                    <asp:Label ID="Label17" runat="server" Font-Bold="True" Text="是否開放報名："></asp:Label></td>
                                <td width="90%" align="left">

                                    <asp:CheckBox ID="cbAllowBooking" runat="server" />

                                    &nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="Label221" runat="server" Text="限制報名人數："></asp:Label>
                                    <telerik:RadNumericTextBox ID="rntbBookingLimit" Runat="server" MinValue="0" Width="60px">
                                        <NegativeStyle Resize="None" />
                                        <NumberFormat DecimalDigits="0" ZeroPattern="n" />
                                        <EmptyMessageStyle Resize="None" />
                                        <ReadOnlyStyle Resize="None" />
                                        <FocusedStyle Resize="None" />
                                        <DisabledStyle Resize="None" />
                                        <InvalidStyle Resize="None" />
                                        <HoveredStyle Resize="None" />
                                        <EnabledStyle Resize="None" />
                                    </telerik:RadNumericTextBox>
                                    <asp:Label ID="Label222" runat="server" Text="(0或不輸入代表無限制)"></asp:Label>

                                </td>
                            </tr>
                            <tr>
                                <td width="10%" bgcolor="#DEDEE9" align="right">
                                    <asp:Label ID="Label7" runat="server" Font-Bold="True" Text="類別屬性："></asp:Label></td>
                                <td width="90%" align="left">
                                    <asp:Panel ID="panProp" runat="server">
                                        <asp:CheckBox ID="cbProp1" runat="server" Text="醫學與臨床教育" Checked="True" />
                                        <asp:CheckBox ID="cbProp2" runat="server" Text="訓練計畫" />
                                        <asp:CheckBox ID="cbProp3" runat="server" Text="教學檢討" />
                                        <asp:CheckBox ID="cbProp4" runat="server" Text="訓練成效" />
                                        <asp:CheckBox ID="cbProp5" runat="server" Text="醫師考照及格率" />
                                        <asp:CheckBox ID="cbProp6" runat="server" Text="工時" />
                                        <asp:CheckBox ID="cbProp7" runat="server" Text="值班工時" />
                                        <asp:CheckBox ID="cbProp8" runat="server" Text="與合作醫院溝通檢討" />
                                    </asp:Panel>
                                    <asp:CheckBox ID="cbPropOther" runat="server" Text="其他" /><asp:TextBox ID="tbPropOther"
                                        runat="server" Width="185px"></asp:TextBox><asp:Label ID="Label21" runat="server"
                                            ForeColor="Red" Text="* 可複選"></asp:Label></td>
                            </tr>
                            <tr>
                                <td width="10%" bgcolor="#DEDEE9" align="right">
                                    <asp:Label ID="Label11" runat="server" Font-Bold="False" ForeColor="Red" Text="*"></asp:Label><asp:Label
                                        ID="Label12" runat="server" Font-Bold="True" Text="舉辦日期："></asp:Label></td>
                                <td width="90%" align="left">
                                    <table>
                                        <tr>
                                            <td>
                                                <telerik:RadDatePicker ID="rdpDateBegin" runat="server" AutoPostBack="True" OnSelectedDateChanged="rdpDateBegin_SelectedDateChanged"
                                                    Width="130px">
                                                    <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"></Calendar>
                                                    <DateInput AutoPostBack="True" DateFormat="yyyy/M/d" DisplayDateFormat="yyyy/M/d"
                                                        LabelWidth="40%">
                                                        <EmptyMessageStyle Resize="None" />
                                                        <ReadOnlyStyle Resize="None" />
                                                        <FocusedStyle Resize="None" />
                                                        <DisabledStyle Resize="None" />
                                                        <InvalidStyle Resize="None" />
                                                        <HoveredStyle Resize="None" />
                                                        <EnabledStyle Resize="None" />
                                                    </DateInput><DatePopupButton HoverImageUrl="" ImageUrl="" />
                                                </telerik:RadDatePicker>
                                            </td>
                                            <td>
                                                <telerik:RadTimePicker ID="rtpTimeBegin" runat="server" Culture="zh-TW" Width="100px">
                                                    <Calendar runat="server" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"></Calendar>
                                                    <DatePopupButton CssClass="" HoverImageUrl="" ImageUrl="" Visible="False" />
                                                    <TimeView CellSpacing="-1" Culture="zh-TW" TimeFormat="HH:mm"
                                                        Interval="00:30:00">
                                                    </TimeView>
                                                    <TimePopupButton CssClass="" HoverImageUrl="" ImageUrl="" />
                                                    <DateInput DateFormat="HH:mm" DisplayDateFormat="HH:mm" LabelWidth="64px" Width="">
                                                        <EmptyMessageStyle Resize="None" />
                                                        <ReadOnlyStyle Resize="None" />
                                                        <FocusedStyle Resize="None" />
                                                        <DisabledStyle Resize="None" />
                                                        <InvalidStyle Resize="None" />
                                                        <HoveredStyle Resize="None" />
                                                        <EnabledStyle Resize="None" />
                                                    </DateInput>
                                                </telerik:RadTimePicker>
                                            </td>
                                            <td>~ </td>
                                            <td>
                                                <telerik:RadDatePicker ID="rdpDateEnd" runat="server" Width="130px"></telerik:RadDatePicker>
                                            </td>
                                            <td>
                                                <telerik:RadTimePicker ID="rtpTimeEnd" runat="server" Culture="zh-TW" Width="100px">
                                                    <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"></Calendar>
                                                    <DatePopupButton CssClass="" HoverImageUrl="" ImageUrl="" Visible="False" />
                                                    <TimeView CellSpacing="-1" Culture="zh-TW" TimeFormat="HH:mm"
                                                        Interval="00:30:00">
                                                    </TimeView>
                                                    <TimePopupButton CssClass="" HoverImageUrl="" ImageUrl="" />
                                                    <DateInput DateFormat="HH:mm" DisplayDateFormat="HH:mm" LabelWidth="64px" Width="">
                                                        <EmptyMessageStyle Resize="None" />
                                                        <ReadOnlyStyle Resize="None" />
                                                        <FocusedStyle Resize="None" />
                                                        <DisabledStyle Resize="None" />
                                                        <InvalidStyle Resize="None" />
                                                        <HoveredStyle Resize="None" />
                                                        <EnabledStyle Resize="None" />
                                                    </DateInput>
                                                </telerik:RadTimePicker>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="5">
                                                <asp:Panel ID="RepeatPanel" runat="server">
                                                    <asp:RadioButton ID="rbNone" runat="server" Checked="True" Text="不重複" GroupName="rbCycle" /><br />
                                                    <asp:RadioButton ID="rbDay" runat="server" Text="每天" GroupName="rbCycle" /><br />
                                                    <asp:RadioButton ID="rbMonth" runat="server" Text="每月" GroupName="rbCycle" /><telerik:RadNumericTextBox
                                                        ID="rntbDay" runat="server" Culture="zh-TW" DbValueFactor="1" LabelWidth="64px"
                                                        MaxValue="31" MinValue="1" Value="1" Width="30px">
                                                        <NumberFormat DecimalDigits="0" ZeroPattern="n" />
                                                    </telerik:RadNumericTextBox><asp:Label ID="Label20" runat="server" Text="日"></asp:Label><br />
                                                    <asp:RadioButton ID="rbWeek" runat="server" Text="每個星期的" GroupName="rbCycle" /><br />
                                                    &#160;&#160;&#160;
                                                    <asp:CheckBox ID="cb7" runat="server" Text="日" /><asp:CheckBox ID="cb1" runat="server"
                                                        Text="一" /><asp:CheckBox ID="cb2" runat="server" Text="二" /><asp:CheckBox ID="cb3"
                                                            runat="server" Text="三" /><asp:CheckBox ID="cb4" runat="server" Text="四" /><asp:CheckBox
                                                                ID="cb5" runat="server" Text="五" /><asp:CheckBox ID="cb6" runat="server" Text="六" /><br />
                                                    <asp:RadioButton ID="rbSpecDay" runat="server" Text="每個月的第" GroupName="rbCycle" /><asp:DropDownList
                                                        ID="ddlweek" runat="server">
                                                        <asp:ListItem Selected="True">1</asp:ListItem>
                                                        <asp:ListItem>2</asp:ListItem>
                                                        <asp:ListItem>3</asp:ListItem>
                                                        <asp:ListItem>4</asp:ListItem>
                                                        <asp:ListItem>5</asp:ListItem>
                                                        <asp:ListItem>6</asp:ListItem>
                                                    </asp:DropDownList><asp:Label ID="Label19" runat="server" Text="個星期"></asp:Label><asp:DropDownList
                                                        ID="ddlspecweekday" runat="server">
                                                        <asp:ListItem Selected="True" Value="0">日</asp:ListItem>
                                                        <asp:ListItem Value="1">一</asp:ListItem>
                                                        <asp:ListItem Value="2">二</asp:ListItem>
                                                        <asp:ListItem Value="3">三</asp:ListItem>
                                                        <asp:ListItem Value="4">四</asp:ListItem>
                                                        <asp:ListItem Value="5">五</asp:ListItem>
                                                        <asp:ListItem Value="6">六</asp:ListItem>
                                                    </asp:DropDownList>
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td width="10%" bgcolor="#DEDEE9" align="right">
                                    <asp:Label ID="Label14" runat="server" Font-Bold="True" Text="舉辦地點："></asp:Label></td>
                                <td width="90%" align="left">
                                    <asp:Panel ID="panLocation" runat="server">
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:RadioButton GroupName="rbLocations" ID="rbLocation1" runat="server" Text="第一講堂(300人)" /></td>
                                                <td>
                                                    <asp:RadioButton GroupName="rbLocations" ID="rbLocation2" runat="server" Text="第二講堂(200人)" /></td>
                                                <td>
                                                    <asp:RadioButton GroupName="rbLocations" ID="rbLocation3" runat="server" Text="第三講堂(150人)" /></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:RadioButton GroupName="rbLocations" ID="rbLocation4" runat="server" Text="第一會議室(100人)" /></td>
                                                <td>
                                                    <asp:RadioButton GroupName="rbLocations" ID="rbLocation5" runat="server" Text="第一討論室(20人)" /></td>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                    <asp:RadioButton GroupName="rbLocations" ID="rbLocationOther" runat="server" Text="其他" /><asp:TextBox
                                                        ID="tbLocation" runat="server" Width="221px"></asp:TextBox></td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td width="10%" bgcolor="#DEDEE9" align="right">
                                    <asp:Label
                                        ID="Label16" runat="server" Font-Bold="True" Text="備註說明："></asp:Label></td>
                                <td width="90%" align="left">
                                    <asp:TextBox ID="tbDes" runat="server" Height="110px" TextMode="MultiLine" Width="537px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td width="10%" bgcolor="#DEDEE9" align="right">
                                    <asp:Label ID="Label9" runat="server" Font-Bold="True" Text="附件檔案："></asp:Label></td>
                                <td width="90%" align="left">
                                    <telerik:RadAsyncUpload ID="ruploadAttachment" runat="server">
                                        <Localization Cancel="取消" DropZone="請將檔案拖曳至此" Remove="移除" Select="瀏覽" />
                                    </telerik:RadAsyncUpload>
                                    <asp:Panel ID="panEditAttachment" runat="server" Visible="false">
                                        <asp:Button ID="btnUpload" runat="server" Text="新增附件" OnClick="btnUpload_Click" /><telerik:RadGrid
                                            ID="rgAttachment" runat="server" AutoGenerateColumns="False" CellSpacing="0"
                                            Culture="zh-TW" GridLines="None" AutoGenerateDeleteColumn="True"
                                            OnDeleteCommand="rgAttachment_DeleteCommand" OnItemDataBound="rgAttachment_ItemDataBound" OnNeedDataSource="rgAttachment_NeedDataSource">
                                            <ClientSettings>
                                                <Selecting AllowRowSelect="True" />
                                            </ClientSettings>
                                            <MasterTableView DataKeyNames="ActAttachmentID" NoMasterRecordsText="沒有附件">
                                                <CommandItemSettings ExportToPdfText="Export to PDF" />
                                                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="False"></RowIndicatorColumn>
                                                <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" Visible="True"
                                                    Created="True">
                                                </ExpandCollapseColumn>
                                                <Columns>
                                                    <telerik:GridAttachmentColumn Visible="false" AttachmentDataField="Attachment" AttachmentKeyFields="ActAttachmentID"
                                                        DataSourceID="odsAttachment" DataTextField="Name" FileNameTextField="Name" FilterControlAltText="Filter attachment column"
                                                        HeaderText="附件" MaxFileSize="65535" UniqueName="attachment" FileName="Name">
                                                    </telerik:GridAttachmentColumn>
                                                    <telerik:GridTemplateColumn DataField="ActAttachmentID" FilterControlAltText="Filter Att column" HeaderText="附件" UniqueName="Att">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lbtnAtt" runat="server" OnClick="lbtnAtt_Click"></asp:LinkButton></ItemTemplate>
                                                    </telerik:GridTemplateColumn>

                                                </Columns>
                                                <EditFormSettings>
                                                    <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                                                </EditFormSettings>
                                            </MasterTableView><FilterMenu EnableImageSprites="False"></FilterMenu>
                                        </telerik:RadGrid>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">

                                    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
                                        <AjaxSettings>
                                            <telerik:AjaxSetting AjaxControlID="rcbType1">
                                                <UpdatedControls>
                                                    <telerik:AjaxUpdatedControl ControlID="rcbType2" UpdatePanelCssClass="" />
                                                    <telerik:AjaxUpdatedControl ControlID="rcbType3" UpdatePanelCssClass="" />
                                                    <telerik:AjaxUpdatedControl ControlID="rcbType4" UpdatePanelCssClass="" />
                                                    <telerik:AjaxUpdatedControl ControlID="btnAddType" UpdatePanelCssClass="" />
                                                    <telerik:AjaxUpdatedControl ControlID="rgActType" UpdatePanelCssClass="" />
                                                </UpdatedControls>
                                            </telerik:AjaxSetting>
                                            <telerik:AjaxSetting AjaxControlID="rcbType2">
                                                <UpdatedControls>
                                                    <telerik:AjaxUpdatedControl ControlID="rcbType3" UpdatePanelCssClass="" />
                                                    <telerik:AjaxUpdatedControl ControlID="rcbType4" UpdatePanelCssClass="" />
                                                    <telerik:AjaxUpdatedControl ControlID="btnAddType" UpdatePanelCssClass="" />
                                                    <telerik:AjaxUpdatedControl ControlID="rgActType" UpdatePanelCssClass="" />
                                                </UpdatedControls>
                                            </telerik:AjaxSetting>
                                            <telerik:AjaxSetting AjaxControlID="rcbType3">
                                                <UpdatedControls>
                                                    <telerik:AjaxUpdatedControl ControlID="rcbType4" UpdatePanelCssClass="" />
                                                </UpdatedControls>
                                            </telerik:AjaxSetting>
                                            <telerik:AjaxSetting AjaxControlID="btnAddType">
                                                <UpdatedControls>
                                                    <telerik:AjaxUpdatedControl ControlID="rgActType" UpdatePanelCssClass="" />
                                                </UpdatedControls>
                                            </telerik:AjaxSetting>
                                        </AjaxSettings>
                                    </telerik:RadAjaxManager>
                                    <asp:ObjectDataSource
                                        ID="odsAttachment" runat="server" DataObjectTypeName="KMU.EduActivity.ApplicationLayer.DTO.EduStopActAttachmentDto"
                                        SelectMethod="GetActAttachments" TypeName="KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService"
                                        OnSelecting="odsAttachment_Selecting"></asp:ObjectDataSource>
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="RadPageView2" runat="server" Selected="false">
                        <div style="vertical-align: top">
                            <asp:Panel ID="Panel1" runat="server" GroupingText="對象類型">
                                <asp:RadioButtonList ID="rblTargetType" runat="server" RepeatDirection="Horizontal"
                                    AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged"
                                    DataSourceID="dsTargetType" DataTextField="name" DataValueField="code">
                                </asp:RadioButtonList><div id="divTeam" runat="server" style="display: none">
                                    <asp:Panel ID="palTeam" runat="server">
                                        <asp:Label ID="Label13" runat="server" Text="組別："></asp:Label><uc1:TreeViewComboBox
                                            Width="350px" ID="TreeViewComboBox1" runat="server" Enabled="True" TreeDataFieldID="EduTeamCode"
                                            TreeDataFieldParentID="parentEduTeamCode" TreeDataSourceID="dsTermCode" TreeDataTextField="EduTeamName"
                                            AutoPostBack="True" AllowSelectParent="True" />
                                    </asp:Panel>
                                </div>
                                <asp:Panel ID="palDept" runat="server" Visible="False">
                                    <asp:Label ID="Label15" runat="server" Text="部門別："></asp:Label><telerik:RadComboBox
                                        ID="ddlDepartment" runat="server" Filter="Contains" ViewStateMode="Enabled">
                                    </telerik:RadComboBox>
                                </asp:Panel>
                                <asp:Panel ID="palJobCode" runat="server" Visible="False">
                                    <asp:Label ID="Label220" runat="server" Text="職稱："></asp:Label><telerik:RadComboBox
                                        ID="ddlJobCode" runat="server" CheckBoxes="True" DataSourceID="dsJobCode" DataTextField="Name"
                                        DataValueField="Code" EnableCheckAllItemsCheckBox="True" OnDataBound="ddlJobCode_DataBound">
                                        <Localization AllItemsCheckedString="全部" CheckAllString="全部" ItemsCheckedString="項以選擇" />
                                    </telerik:RadComboBox>
                                </asp:Panel>
                                <asp:Panel ID="palEduTerm" runat="server" Visible="False">
                                    <asp:Panel ID="Panel2" runat="server">
                                        <asp:Label ID="Label22" runat="server" Text="課程代碼："></asp:Label><asp:TextBox ID="tbEduStopCode"
                                            runat="server"></asp:TextBox><asp:Label ID="Label23" runat="server" Text="名稱："></asp:Label><asp:TextBox
                                                ID="tbEduName" runat="server"></asp:TextBox><asp:Button ID="btnQuery" runat="server"
                                                    OnClick="btnQuery_Click" Text="查詢" /><br />
                                    </asp:Panel>
                                    <br />
                                    <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" CellSpacing="0"
                                        Culture="zh-TW" GridLines="None" AllowPaging="True" Style="margin-top: 0px" AutoGenerateHierarchy="True"
                                        OnPreRender="RadGrid1_PreRender" OnNeedDataSource="RadGrid1_NeedDataSource1"
                                        OnSelectedIndexChanged="RadGrid1_SelectedIndexChanged">
                                        <ClientSettings EnablePostBackOnRowClick="True">
                                            <Selecting AllowRowSelect="True" />
                                            <Selecting AllowRowSelect="True"></Selecting>
                                        </ClientSettings>
                                        <MasterTableView CommandItemDisplay="Top" NoMasterRecordsText="目前沒有資料" NoDetailRecordsText=""
                                            EditMode="PopUp" DataKeyNames="RoundCode,EduStopCode,EduTermID" ClientDataKeyNames="RoundCode,EduStopCode,EduTermID"
                                            HierarchyLoadMode="Client" GroupLoadMode="Client">
                                            <CommandItemSettings ExportToPdfText="Export to PDF" AddNewRecordText="新增" ShowRefreshButton="False"></CommandItemSettings>
                                            <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                                                <HeaderStyle Width="20px"></HeaderStyle>
                                            </RowIndicatorColumn>
                                            <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                                                <HeaderStyle Width="20px"></HeaderStyle>
                                            </ExpandCollapseColumn>
                                            <Columns>
                                                <telerik:GridClientSelectColumn FilterControlAltText="Filter column column" UniqueName="column"
                                                    Visible="False">
                                                </telerik:GridClientSelectColumn>
                                                <telerik:GridBoundColumn DataField="EduStopCode" FilterControlAltText="Filter EduStopCode column"
                                                    HeaderText="課程代碼" UniqueName="EduStopCode">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Name" FilterControlAltText="Filter Name column"
                                                    HeaderText="名稱" UniqueName="Name">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="DateFromToStr" FilterControlAltText="Filter EduTeamCode column"
                                                    HeaderText="訓練起訖日期" UniqueName="DateFromToStr" ReadOnly="True">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridDateTimeColumn DataField="DateFrom" FilterControlAltText="Filter DateFrom column"
                                                    HeaderText="訓練開始日期" UniqueName="DateFrom" Visible="False">
                                                </telerik:GridDateTimeColumn>
                                                <telerik:GridDateTimeColumn DataField="DateTo" FilterControlAltText="Filter DateTo column"
                                                    HeaderText="訓練結束日期" UniqueName="DateTo" Visible="False">
                                                </telerik:GridDateTimeColumn>
                                                <telerik:GridBoundColumn DataField="UnitStr" FilterControlAltText="Filter UnitStr column"
                                                    HeaderText="單位" UniqueName="UnitStr">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridNumericColumn DataField="Capacity" DecimalDigits="2" FilterControlAltText="Filter Capacity column"
                                                    HeaderText="訓練人數" UniqueName="Capacity">
                                                </telerik:GridNumericColumn>
                                                <telerik:GridBoundColumn DataField="Status" HeaderText="狀態" UniqueName="Status" FilterControlAltText="Filter Status column"></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Des" FilterControlAltText="Filter Des column"
                                                    HeaderText="備註" UniqueName="Des">
                                                </telerik:GridBoundColumn>
                                            </Columns>
                                            <CommandItemTemplate></CommandItemTemplate>
                                            <EditFormSettings>
                                                <EditColumn FilterControlAltText="Filter EditCommandColumn column" CancelText="取消"
                                                    EditText="儲存" InsertText="儲存" UpdateText="儲存">
                                                </EditColumn>
                                                <PopUpSettings Modal="True" ScrollBars="Auto" Width="600px" />
                                                <PopUpSettings ScrollBars="Auto" Modal="True" Width="600px"></PopUpSettings>
                                            </EditFormSettings>
                                        </MasterTableView><PagerStyle FirstPageToolTip="第一頁" LastPageToolTip="最末頁" NextPageToolTip="下一頁"
                                            PagerTextFormat="跳至第: {4} &amp;nbsp;頁 &lt;strong&gt;{0}&lt;/strong&gt; / &lt;strong&gt;{1}&lt;/strong&gt;, 項目 &lt;strong&gt;{2}&lt;/strong&gt; - &lt;strong&gt;{3}&lt;/strong&gt; / &lt;strong&gt;{5}&lt;/strong&gt;."
                                            PageSizeLabelText="每頁筆數:" PrevPagesToolTip="上一頁" PrevPageToolTip="上一頁" />
                                        <FilterMenu EnableImageSprites="False"></FilterMenu>
                                    </telerik:RadGrid>
                                </asp:Panel>
                                <asp:Panel ID="palEmp" Visible="true" runat="server">
                                    <uc2:VsSelector ID="VsSelector1" runat="server" />
                                    <br />
                                </asp:Panel>
                                <asp:Panel ID="panChoiceMember" runat="server">
                                    <asp:Label ID="Label30" runat="server" Text="成員名單："></asp:Label><br />
                                    <telerik:RadGrid ID="RadGrid2" runat="server" AllowMultiRowSelection="True" AutoGenerateColumns="False"
                                        CellSpacing="0" Culture="zh-TW" GridLines="None">
                                        <ExportSettings>
                                            <Pdf>
                                                <PageHeader>
                                                    <LeftCell Text="" />
                                                    <MiddleCell Text="" />
                                                    <RightCell Text="" />
                                                </PageHeader>
                                                <PageFooter>
                                                    <LeftCell Text="" />
                                                    <MiddleCell Text="" />
                                                    <RightCell Text="" />
                                                </PageFooter>
                                            </Pdf>
                                        </ExportSettings>
                                        <ClientSettings>
                                            <Selecting AllowRowSelect="True" />
                                        </ClientSettings>
                                        <MasterTableView CommandItemDisplay="Top" EditMode="PopUp" InsertItemPageIndexAction="ShowItemOnCurrentPage"
                                            NoMasterRecordsText="目前沒有資料" DataKeyNames="isHospMember">
                                            <CommandItemSettings AddNewRecordText="新增" ExportToPdfText="Export to PDF" ShowRefreshButton="False" />
                                            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="True">
                                                <HeaderStyle Width="20px" />
                                            </RowIndicatorColumn>
                                            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" Visible="True">
                                                <HeaderStyle Width="20px" />
                                            </ExpandCollapseColumn>
                                            <Columns>
                                                <telerik:GridClientSelectColumn FilterControlAltText="Filter column column" UniqueName="column"></telerik:GridClientSelectColumn>
                                                <telerik:GridBoundColumn DataField="MemberCode" EditFormHeaderTextFormat="&lt;div style=&quot;text-align:right;&quot;&gt;{0}:&lt;/div&gt;"
                                                    FilterControlAltText="Filter EduTeamCode column" HeaderText="學號" UniqueName="MemberCode">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Name" EditFormHeaderTextFormat="&lt;div style=&quot;text-align:right;&quot;&gt;{0}:&lt;/div&gt;"
                                                    FilterControlAltText="Filter Name column" HeaderText="姓名" UniqueName="Name">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridDropDownColumn DataField="MemberType" DataSourceID="dsJobCode" EditFormHeaderTextFormat="&lt;div style=&quot;text-align:right;&quot;&gt;{0}:&lt;/div&gt;"
                                                    FilterControlAltText="Filter MemberType column" HeaderText="職稱" ListTextField="Name"
                                                    ListValueField="Code" UniqueName="MemberType">
                                                </telerik:GridDropDownColumn>
                                                <telerik:GridBoundColumn DataField="isHospMember" FilterControlAltText="Filter isHospMember column"
                                                    HeaderText="員工編號" UniqueName="isHospMember">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridDateTimeColumn DataField="DateFrom" DataFormatString="{0: yyyy.MM.dd}"
                                                    EditFormHeaderTextFormat="&lt;div style=&quot;text-align:right;&quot;&gt;{0}:&lt;/div&gt;"
                                                    FilterControlAltText="Filter DateFrom column" HeaderText="訓練起始日" UniqueName="DateFrom">
                                                </telerik:GridDateTimeColumn>
                                                <telerik:GridDateTimeColumn DataField="DateTo" DataFormatString="{0: yyyy.MM.dd}"
                                                    EditFormHeaderTextFormat="&lt;div style=&quot;text-align:right;&quot;&gt;{0}:&lt;/div&gt;"
                                                    FilterControlAltText="Filter DateTo column" HeaderText="訓練結束日" UniqueName="DateTo">
                                                </telerik:GridDateTimeColumn>
                                                <telerik:GridBoundColumn DataField="StatusName" EditFormHeaderTextFormat="&lt;div style=&quot;text-align:right;&quot;&gt;{0}:&lt;/div&gt;"
                                                    FilterControlAltText="Filter StatusName column" HeaderText="狀態" ReadOnly="True"
                                                    UniqueName="StatusName">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridDropDownColumn DataField="EduTeamCode" DataSourceID="dsTermCode" EditFormHeaderTextFormat="&lt;div style=&quot;text-align:right;&quot;&gt;{0}:&lt;/div&gt;"
                                                    FilterControlAltText="Filter EduTeamCode column" HeaderText="組別" ListTextField="EduTeamName"
                                                    ListValueField="EduTeamCode" UniqueName="EduTeamCode">
                                                </telerik:GridDropDownColumn>
                                                <telerik:GridButtonColumn ButtonType="ImageButton" CommandName="Edit" Text="編輯" UniqueName="EditColumn">
                                                    <ItemStyle CssClass="MyImageButton" HorizontalAlign="Center" />
                                                </telerik:GridButtonColumn>
                                                <telerik:GridButtonColumn ButtonType="ImageButton" CommandName="Delete" ConfirmDialogType="RadWindow"
                                                    ConfirmText="是否確定刪除?" ConfirmTitle="Delete" Text="刪除" UniqueName="DeleteColumn">
                                                    <ItemStyle CssClass="MyImageButton" HorizontalAlign="Center" />
                                                </telerik:GridButtonColumn>
                                                <telerik:GridBoundColumn DataField="isHospMember" EditFormHeaderTextFormat="&lt;div style=&quot;text-align:right;&quot;&gt;{0}:&lt;/div&gt;"
                                                    FilterControlAltText="Filter isHospMember column" HeaderText="院內員工碼" UniqueName="isHospMember"
                                                    Visible="False">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Des" EditFormHeaderTextFormat="&lt;div style=&quot;text-align:right;&quot;&gt;{0}:&lt;/div&gt;"
                                                    FilterControlAltText="Filter Des column" HeaderText="說明" UniqueName="Des" Visible="False">
                                                </telerik:GridBoundColumn>
                                            </Columns>
                                            <BatchEditingSettings EditType="Cell" />
                                            <PagerStyle PageSizeControlType="RadComboBox" />
                                            <CommandItemTemplate></CommandItemTemplate>
                                            <EditFormSettings EditFormType="Template">
                                                <FormTemplate>
                                                    <table width="100%">
                                                        <tr>
                                                            <td align="right" width="15%">
                                                                <asp:Label ID="lb1" runat="server" Text="學號:"></asp:Label></td>
                                                            <td align="left" width="85%">
                                                                <asp:TextBox ID="tbMemberCode" runat="server" Text='<%# Bind("MemberCode") %>'></asp:TextBox></td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:Label ID="Label31" runat="server" Text="姓名:"></asp:Label></td>
                                                            <td align="left">
                                                                <asp:TextBox ID="tbName0" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox></td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:Label ID="Label32" runat="server" Text="職稱:"></asp:Label></td>
                                                            <td align="left">
                                                                <telerik:RadComboBox ID="ddlJobCode0" runat="server" DataSourceID="dsJobCode" DataTextField="Name"
                                                                    DataValueField="Code" SelectedValue='<%# Bind("MemberType") %>'>
                                                                </telerik:RadComboBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:Label ID="Label33" runat="server" Text="訓練起始日:"></asp:Label></td>
                                                            <td align="left">
                                                                <telerik:RadDatePicker ID="rdpEditDateBegin" runat="server" DbSelectedDate='<%# Bind("DateFrom") %>'></telerik:RadDatePicker>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:Label ID="Label34" runat="server" Text="訓練結束日:"></asp:Label></td>
                                                            <td align="left">
                                                                <telerik:RadDatePicker ID="rdpEditDateEnd" runat="server" DbSelectedDate='<%# Bind("DateTo") %>'></telerik:RadDatePicker>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:Label ID="Label35" runat="server" Text="組別:"></asp:Label></td>
                                                            <td align="left">
                                                                <uc1:TreeViewComboBox ID="TreeViewComboBox2" runat="server" Enabled="True" SelectedText='<%# Bind("EduTeamName") %>'
                                                                    SelectedValue='<%# Bind("EduTeamCode") %>' TreeDataFieldID="EduTeamCode" TreeDataFieldParentID="parentEduTeamCode"
                                                                    TreeDataSourceID="dsTermCode" TreeDataTextField="EduTeamName" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:Label ID="Label36" runat="server" Text="院內員工碼:"></asp:Label></td>
                                                            <td align="left">
                                                                <asp:TextBox ID="tbisHospMember" runat="server" Text='<%# Bind("isHospMember") %>'></asp:TextBox></td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:Label ID="Label37" runat="server" Text="說明:"></asp:Label></td>
                                                            <td align="left">
                                                                <asp:TextBox ID="tbDes0" runat="server" Text='<%# Bind("Des") %>'></asp:TextBox></td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" colspan="2">
                                                                <asp:Button ID="btnUpdate" runat="server" CommandName='<%# (Container is GridEditFormInsertItem) ? "PerformInsert" : "Update" %>'
                                                                    Text="儲存" />&#160;&nbsp;<asp:Button ID="btnCancel" runat="server" CausesValidation="False"
                                                                        CommandName="Cancel" Text="取消" /></td>
                                                        </tr>
                                                    </table>
                                                </FormTemplate>
                                                <EditColumn CancelText="取消" EditText="儲存" FilterControlAltText="Filter EditCommandColumn column"
                                                    InsertText="儲存" UpdateText="儲存">
                                                </EditColumn>
                                                <PopUpSettings Modal="True" ScrollBars="Auto" Width="600px" />
                                            </EditFormSettings>
                                        </MasterTableView><PagerStyle FirstPageToolTip="第一頁" LastPageToolTip="最末頁" NextPageToolTip="下一頁"
                                            PagerTextFormat="跳至第: {4} &amp;nbsp;頁 &lt;strong&gt;{0}&lt;/strong&gt; / &lt;strong&gt;{1}&lt;/strong&gt;, 項目 &lt;strong&gt;{2}&lt;/strong&gt; - &lt;strong&gt;{3}&lt;/strong&gt; / &lt;strong&gt;{5}&lt;/strong&gt;."
                                            PageSizeLabelText="每頁筆數:" PrevPagesToolTip="上一頁" PrevPageToolTip="上一頁" />
                                        <FilterMenu EnableImageSprites="False"></FilterMenu>
                                    </telerik:RadGrid>
                                </asp:Panel>
                            </asp:Panel>
                        </div>
                        <div>
                            <asp:Button ID="btnAddTarget" runat="server" Text="新增" OnClick="btnAddTarget_Click" /><asp:Panel
                                ID="Panel3" runat="server">
                                <telerik:RadGrid ID="rgTarget" runat="server" AutoGenerateColumns="False" CellSpacing="0"
                                    Culture="zh-TW" GridLines="None" AllowMultiRowSelection="True" AllowPaging="True"
                                    Style="margin-top: 0px" OnItemCommand="rgTarget_ItemCommand" OnNeedDataSource="rgTarget_NeedDataSource">
                                    <ClientSettings>
                                        <Selecting AllowRowSelect="True" />
                                    </ClientSettings>
                                    <MasterTableView CommandItemDisplay="Top" NoMasterRecordsText="目前沒有資料" EditMode="PopUp">
                                        <CommandItemSettings ExportToPdfText="Export to PDF" AddNewRecordText="新增" ShowRefreshButton="False"></CommandItemSettings>
                                        <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                                            <HeaderStyle Width="20px"></HeaderStyle>
                                        </RowIndicatorColumn>
                                        <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                                            <HeaderStyle Width="20px"></HeaderStyle>
                                        </ExpandCollapseColumn>
                                        <Columns>
                                            <telerik:GridClientSelectColumn FilterControlAltText="Filter column column" UniqueName="column"></telerik:GridClientSelectColumn>
                                            <telerik:GridBoundColumn DataField="TargetTypeName" FilterControlAltText="Filter TargetTypeName column"
                                                UniqueName="TargetTypeName" HeaderText="類別">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn FilterControlAltText="Filter TargetName column" HeaderText="對象"
                                                UniqueName="TargetName" DataField="TargetName">
                                            </telerik:GridBoundColumn>
                                        </Columns>
                                        <CommandItemTemplate>
                                            <asp:LinkButton ID="lbtnDelete" OnClientClick="javascript:return confirm('是否確定刪除所有選擇的項目?')"
                                                runat="server" CommandName="DeleteSelected"><img style="border:0px" alt="" src="Images/delete.gif" /> 刪除</asp:LinkButton>
                                        </CommandItemTemplate>
                                        <EditFormSettings EditFormType="AutoGenerated">
                                            <EditColumn FilterControlAltText="Filter EditCommandColumn column" CancelText="取消"
                                                EditText="儲存" InsertText="儲存" UpdateText="儲存">
                                            </EditColumn>
                                            <PopUpSettings Modal="True" ScrollBars="Auto" Width="600px" />
                                        </EditFormSettings>
                                    </MasterTableView><PagerStyle FirstPageToolTip="第一頁" LastPageToolTip="最末頁" NextPageToolTip="下一頁"
                                        PagerTextFormat="跳至第: {4} &amp;nbsp;頁 &lt;strong&gt;{0}&lt;/strong&gt; / &lt;strong&gt;{1}&lt;/strong&gt;, 項目 &lt;strong&gt;{2}&lt;/strong&gt; - &lt;strong&gt;{3}&lt;/strong&gt; / &lt;strong&gt;{5}&lt;/strong&gt;."
                                        PageSizeLabelText="每頁筆數:" PrevPagesToolTip="上一頁" PrevPageToolTip="上一頁" />
                                    <FilterMenu EnableImageSprites="False"></FilterMenu>
                                </telerik:RadGrid>
                            </asp:Panel>
                        </div>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>

            </td>
        </tr>
        <tr>
            <td></td>
            <td>                                    <asp:Button ID="btnSave" runat="server" Text="儲存" OnClick="btnSave_Click" /></td>
        </tr>
    </table>
</asp:Content>
