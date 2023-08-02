<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="EduStopActScheduleTarget.aspx.cs" Inherits="EduStopActScheduleTarget" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register src="TreeViewComboBox.ascx" tagname="TreeViewComboBox" tagprefix="uc1" %>

<%@ Register src="VsSelector.ascx" tagname="VsSelector" tagprefix="uc2" %>

<%@ Register src="UserControls/MyListSelect.ascx" tagname="MyListSelect" tagprefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
.RadGrid_Default{border:1px solid #828282;background-color:white;color:#333;font-family:"Segoe UI",Arial,Helvetica,sans-serif;font-size:12px;line-height:16px}.RadGrid_Default{border:1px solid #828282;background-color:white;color:#333;font-family:"Segoe UI",Arial,Helvetica,sans-serif;font-size:12px;line-height:16px}.RadGrid_Default .rgMasterTable{font-family:"Segoe UI",Arial,Helvetica,sans-serif;font-size:12px;line-height:16px}.RadGrid .rgMasterTable{border-collapse:separate;border-spacing:0}.RadGrid_Default .rgMasterTable{font-family:"Segoe UI",Arial,Helvetica,sans-serif;font-size:12px;line-height:16px}.RadGrid .rgMasterTable{border-collapse:separate;border-spacing:0}.RadGrid table.rgMasterTable tr .rgExpandCol{padding-left:0;padding-right:0;text-align:center}.RadGrid table.rgMasterTable tr .rgExpandCol{padding-left:0;padding-right:0;text-align:center}.RadGrid_Default .rgHeader{color:#333}.RadGrid_Default .rgHeader{border:0;border-bottom:1px solid #828282;background:#eaeaea 0 -2300px repeat-x url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Grid.sprite.gif')}.RadGrid .rgHeader{padding-top:5px;padding-bottom:4px;text-align:left;font-weight:normal}.RadGrid .rgHeader{padding-left:7px;padding-right:7px}.RadGrid .rgHeader{cursor:default}.RadGrid_Default .rgHeader{color:#333}.RadGrid_Default .rgHeader{border:0;border-bottom:1px solid #828282;background:#eaeaea 0 -2300px repeat-x url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Grid.sprite.gif')}.RadGrid .rgHeader{padding-top:5px;padding-bottom:4px;text-align:left;font-weight:normal}.RadGrid .rgHeader{padding-left:7px;padding-right:7px}.RadGrid .rgHeader{cursor:default}
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <table width="100%">
<tr>
<td width="10%" bgcolor="#DEDEE9" align="right">
    <asp:Label ID="Label3" runat="server" Font-Bold="False" ForeColor="Red" 
        Text="*"></asp:Label>
    <asp:Label ID="Label4" runat="server" Font-Bold="True" Text="公告類型："></asp:Label>
</td>
<td width="90%" align="left">
<asp:Label ID="lbActType" runat="server"></asp:Label>
</td>
</tr>
<tr>
<td width="10%" bgcolor="#DEDEE9" align="right">
    <asp:Label ID="Label5" runat="server" Font-Bold="False" ForeColor="Red" 
        Text="*"></asp:Label>
    <asp:Label ID="Label6" runat="server" Font-Bold="True" Text="公告主題："></asp:Label>
</td>
<td width="90%" align="left">
    <asp:Label ID="lbActName" runat="server"></asp:Label>
</td>
</tr>
<tr>
<td width="10%" bgcolor="#DEDEE9" align="right">
    <asp:Label ID="Label11" runat="server" Font-Bold="False" ForeColor="Red" 
        Text="*"></asp:Label>
    <asp:Label ID="Label12" runat="server" Font-Bold="True" Text="舉辦日期："></asp:Label>
</td>
<td width="90%" align="left">
    <asp:Label ID="lbActDate" runat="server"></asp:Label>
                                
                                
                                
                                
</td>
</tr>
<tr>
<td width="10%" bgcolor="#DEDEE9" align="right">
    <asp:Label ID="Label14" runat="server" Font-Bold="True" Text="舉辦地點："></asp:Label>
</td>
<td width="90%" align="left">
<asp:Panel ID="panLocation" runat="server">
    <asp:Label ID="lbActLocation" runat="server"></asp:Label>
</asp:Panel>
</td>
</tr>

<tr>
<td colspan="2">
<asp:Panel ID="EditPanel" runat="server">

<telerik:RadTabStrip ID="RadTabStrip1" runat="server" MultiPageID="RadMultiPage1" 
            SelectedIndex="0" Skin="WebBlue">
        <Tabs>
            <telerik:RadTab runat="server" PageViewID="RadPageView1" 
                Text="新增對象" Selected="True">
            </telerik:RadTab>
            <telerik:RadTab runat="server" PageViewID="RadPageView2" Text="出席者上傳">
            </telerik:RadTab>
        </Tabs>
    </telerik:RadTabStrip>

<telerik:RadMultiPage ID="RadMultiPage1" Runat="server" BorderColor="Black" 
            BorderStyle="Solid" BorderWidth="1px" SelectedIndex="0" Width="98%">
        <telerik:RadPageView ID="RadPageView1" runat="server" Selected="True">

            <div style="vertical-align:top">
                <asp:Panel ID="Panel1" runat="server" GroupingText="對象類型">
                    <asp:RadioButtonList ID="rblTargetType" runat="server" AutoPostBack="True" 
                        DataTextField="name" DataValueField="code" 
                        onselectedindexchanged="RadioButtonList1_SelectedIndexChanged" 
                        RepeatDirection="Horizontal" ondatabound="rblTargetType_DataBound" 
                        Visible="False">
                        <asp:ListItem Selected="True" Value="EmpCode">個人</asp:ListItem>
                        <asp:ListItem Value="JobCode">本科職類名單</asp:ListItem>
                        <asp:ListItem Value="MyList">常用名單</asp:ListItem>
                    </asp:RadioButtonList>
                    <div ID="divTeam" runat="server" style="display:none">
                        <asp:Panel ID="palTeam" runat="server">
                            <asp:Label ID="Label28" runat="server" Text="組別："></asp:Label>
                            <uc1:TreeViewComboBox id="TreeViewComboBox1" runat="server" 
                                allowselectparent="False" autopostback="False" enabled="True" 
                                treedatafieldid="EduTeamCode" treedatafieldparentid="parentEduTeamCode" 
                                treedatasourceid="dsTermCode" treedatatextfield="EduTeamName" width="350px" />
                        </asp:Panel>
                    </div>
                    <asp:Panel ID="palEmp" runat="server" Visible="true">
                        <div>
                            <asp:RadioButton ID="rbByDept" runat="server" Checked="True" GroupName="AddEmp" Text="依部門：" Visible="False" />
                            <asp:Label ID="Label32" runat="server" Text="依部門："></asp:Label>
                            <telerik:RadComboBox ID="ddlUnit" Runat="server" AutoPostBack="true" Filter="Contains" OnSelectedIndexChanged="ddlUnit_SelectedIndexChanged">
                            </telerik:RadComboBox>
                            <telerik:RadComboBox ID="ddlEmpByDept" Runat="server" DataTextField="empname" DataValueField="empcode" Filter="Contains">
                            </telerik:RadComboBox>
                            <asp:Button ID="btnAddTarget" runat="server" onclick="btnAddTarget_Click" Text="新增" />
                        </div>
                        <div>
                        <asp:RadioButton ID="rbByCode" runat="server" Text="依職編：" GroupName="AddEmp" Visible="False" />
                            <asp:Label ID="Label33" runat="server" Text="依職編："></asp:Label>
                        <uc2:VsSelector ID="VsSelector1" runat="server" />
                            <asp:Button ID="btnAddTargetEmp" runat="server" onclick="btnAddTarget_Click" Text="新增" />
                            </div>
                        <div>
                            <table>
                                <tr>
                                    <td>
<asp:Label ID="Label34" runat="server" Text="在本科人員職稱&lt;br&gt;(依活動日期判定)："></asp:Label>
                                    </td>
                                    <td>
                            <telerik:RadDropDownTree ID="rddtJobCode" runat="server" DataFieldID="Code" DataFieldParentID="ParentCodeRefid" DataSourceID="dsJobCode" DataTextField="name" DataValueField="code">
                            </telerik:RadDropDownTree>
                                    </td>
                                    <td>

                                        <asp:Button ID="btnAddJobCode" runat="server" onclick="btnAddJobCode_Click" Text="新增" />

                                    </td>
                                </tr>
                            </table>
                            


                        </div>
                        <div>
                            <table>
                                <tr>
                                    <td>

                                        <asp:Label ID="Label35" runat="server" Text="常用名單："></asp:Label>

                                    </td>
                                    <td>

                                        <uc3:MyListSelect ID="MyListSelect1" runat="server" />

                                    </td>
                                    <td>

                                        <asp:Button ID="btnAddMyList" runat="server" onclick="btnAddMyList_Click" Text="新增" />

                                    </td>
                                    <td>

                                        &nbsp;</td>
                                </tr>
                            </table>
                        </div>
                        <div>
                            <asp:Button ID="btnImportRegistList" runat="server" Text="匯入報名人員" Visible ="False" OnClick="btnImportRegistList_Click" />
                            <br />
                            <asp:Button ID="btnImportRegistList0" runat="server" OnClick="btnImportRegistList0_Click" Text="匯入會議記錄簽到名單" />
                            <br />
                            <asp:Label ID="lbImportMsg" runat="server" ForeColor="Red"></asp:Label>
                        </div>
                    
                        <asp:Label ID="Label24" runat="server" Text="角色："></asp:Label>
                        <asp:RadioButtonList ID="rcbRole" runat="server" DataTextField="Name" DataValueField="Code" 
                            onselectedindexchanged="rcbRole_SelectedIndexChanged1" 
                            RepeatDirection="Horizontal">
                        </asp:RadioButtonList>
                        <asp:Panel ID="palTimeRange" runat="server">
                        <table>
                        <tr>
                        <td>
                            <asp:Label ID="Label26" runat="server" Text="時段："></asp:Label>
                            </td>
                        <td>
                            <telerik:RadTimePicker ID="rdtpTimeBegin" Runat="server" Culture="zh-TW">
                                <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False">
                                </Calendar>
                                <DatePopupButton CssClass="" HoverImageUrl="" ImageUrl="" Visible="False" />
                                <TimeView CellSpacing="-1" Interval="00:30:00" TimeFormat="HH:mm">
                                </TimeView>
                                <TimePopupButton CssClass="" HoverImageUrl="" ImageUrl="" />
                                <DateInput DateFormat="HH:mm" DisplayDateFormat="HH:mm" LabelWidth="64px" 
                                    Width="">
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
                        <td>
                            <asp:Label ID="Label27" runat="server" Text="~"></asp:Label>
                            </td>
                        <td>
                            <telerik:RadTimePicker ID="rdtpTimeEnd" Runat="server" Culture="zh-TW">
                                <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False">
                                </Calendar>
                                <DatePopupButton CssClass="" HoverImageUrl="" ImageUrl="" Visible="False" />
                                <TimeView CellSpacing="-1" Interval="00:30:00" TimeFormat="HH:mm">
                                </TimeView>
                                <TimePopupButton CssClass="" HoverImageUrl="" ImageUrl="" />
                                <DateInput DateFormat="HH:mm" DisplayDateFormat="HH:mm" LabelWidth="64px" 
                                    Width="">
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
                        </table>
                        </asp:Panel>
                    </asp:Panel>
                </asp:Panel>
            </div>
            <asp:Button ID="btnUpdate" runat="server" onclick="btnUpdate_Click" 
                Text="更新選取資料" />
            <br />
            <asp:Label ID="Label31" runat="server" Text="總人數："></asp:Label>
            <asp:Label ID="lbTotalCount" runat="server" Text="0"></asp:Label>
</telerik:RadPageView>
        <telerik:RadPageView ID="RadPageView2" runat="server" Selected="false">
            <asp:HyperLink ID="HyperLink1" runat="server" Font-Size="Medium" 
                NavigateUrl="~/sample.xls">範例下載</asp:HyperLink>
            &nbsp;
            <asp:LinkButton ID="lbRoleTypeList" runat="server" OnClick="lbRoleTypeList_Click">角色代碼表</asp:LinkButton>
            <br />
            <br />
            <asp:Label ID="Label30" runat="server" Text="選擇檔案："></asp:Label>
            <br />
            <asp:FileUpload ID="FileUpload1" runat="server" ViewStateMode="Enabled" />
            <br />
            <asp:Button ID="btnUpload" runat="server" onclick="btnUpload_Click" Text="上傳" />
            <br />
            <asp:Label ID="lblMsg" runat="server"></asp:Label>
        </telerik:RadPageView>
        </telerik:RadMultiPage>

            <div>


                <asp:Panel ID="Panel3" runat="server">
                    <telerik:RadGrid ID="rgTarget" runat="server" AllowMultiRowSelection="True" AutoGenerateColumns="False" CellSpacing="0" Culture="zh-TW" 
                        GridLines="None" onitemcommand="rgTarget_ItemCommand" 
                        onneeddatasource="rgTarget_NeedDataSource" style="margin-top: 0px" 
                        ondeletecommand="rgTarget_DeleteCommand">
                        <ClientSettings>
                            <Selecting AllowRowSelect="True" />
                        </ClientSettings>
                        <MasterTableView commanditemdisplay="Top" EditMode="PopUp" DataKeyNames="RoleType,TargetID,TargetType,TimeFrom,TimeTo"
                            nomasterrecordstext="目前沒有資料">
                            <CommandItemSettings addnewrecordtext="新增" ExportToPdfText="Export to PDF" 
                                showrefreshbutton="False" />
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
                                <telerik:GridBoundColumn DataField="TargetTypeName" 
                                    FilterControlAltText="Filter TargetTypeName column" HeaderText="類別" 
                                    UniqueName="TargetTypeName">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="TargetID" 
                                    FilterControlAltText="Filter TargetName column" HeaderText="編號" 
                                    UniqueName="TargetID">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="TargetName" 
                                    FilterControlAltText="Filter TargetName column" HeaderText="對象" 
                                    UniqueName="TargetName">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="TargetJobName" 
                                    FilterControlAltText="Filter roleName column" HeaderText="職稱" 
                                    UniqueName="TargetJobName">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="roleName" 
                                    FilterControlAltText="Filter roleName column" HeaderText="角色" 
                                    UniqueName="roleName">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="TimeRangeStr" 
                                    FilterControlAltText="Filter TimeRangeStr column" HeaderText="時段" 
                                    UniqueName="TimeRangeStr">
                                </telerik:GridBoundColumn>
                            </Columns>
                            <CommandItemTemplate>
                                <asp:LinkButton ID="lbtnDelete" runat="server" CommandName="DeleteSelected" 
                                    OnClientClick="javascript:return confirm('是否確定刪除所有選擇的項目?')"><img style="border:0px" alt="" src="Images/delete.gif" /> 刪除</asp:LinkButton>
                            </CommandItemTemplate>
                            <EditFormSettings EditFormType="AutoGenerated">
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
                    <asp:CheckBox ID="cbOutSide" AutoPostBack="true" runat="server" OnCheckedChanged="cbOutSide_CheckedChanged" Text="本活動有外校學生或其他醫事職類學生" />
                    <br />

                    <asp:ObjectDataSource ID="dsTargetType" runat="server" 
                        DataObjectTypeName="KMU.EduActivity.ApplicationLayer.DTO.V_CodeRefDto" 
                        SelectMethod="GetCodeRefsStatic" 
                        TypeName="KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="EduAct_ActTargetType" Name="codetype" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="dsTermCode" runat="server" SelectMethod="GetEduTeams" 
                        TypeName="KMU.EduActivity.ApplicationLayer.DTO.EduTeamDto">
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="dsJobCode" runat="server" DataObjectTypeName="KMU.EduActivity.ApplicationLayer.DTO.V_CodeRefDto" SelectMethod="GetCodeRefsStatic" TypeName="KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="EduAct_JobSerial" Name="codetype" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </asp:Panel>

            </div>
</asp:Panel>
                <div>
                    <asp:Button ID="btnSave" runat="server" onclick="btnSave_Click" Text="儲存設定" Visible="False" />
                    &nbsp;<asp:Button ID="btnExport" runat="server" OnClick="btnExport_Click" Text="匯出清單" />
                    &nbsp;&nbsp;
                    <asp:Button ID="btnReturn" runat="server" onclick="btnReturn_Click" 
                        Text="返回行事曆" />                
                </div>
    </td>
</tr>
</table>


</asp:Content>

