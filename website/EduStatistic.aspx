<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="EduStatistic.aspx.cs" Inherits="EduStatistic" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>


<%@ Register Assembly="Telerik.ReportViewer.WebForms, Version=7.2.13.1016, Culture=neutral, PublicKeyToken=a9d7983dfcc261be" Namespace="Telerik.ReportViewer.WebForms" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
.RadGrid_Default{border:1px solid #828282;background-color:white;color:#333;font-family:"Segoe UI",Arial,Helvetica,sans-serif;font-size:12px;line-height:16px}.RadGrid_Default{border:1px solid #828282;background-color:white;color:#333;font-family:"Segoe UI",Arial,Helvetica,sans-serif;font-size:12px;line-height:16px}.RadGrid_Default .rgMasterTable{font-family:"Segoe UI",Arial,Helvetica,sans-serif;font-size:12px;line-height:16px}.RadGrid .rgMasterTable{border-collapse:separate;border-spacing:0}.RadGrid_Default .rgMasterTable{font-family:"Segoe UI",Arial,Helvetica,sans-serif;font-size:12px;line-height:16px}.RadGrid .rgMasterTable{border-collapse:separate;border-spacing:0}.RadGrid table.rgMasterTable tr .rgExpandCol{padding-left:0;padding-right:0;text-align:center}.RadGrid table.rgMasterTable tr .rgExpandCol{padding-left:0;padding-right:0;text-align:center}.RadGrid_Default .rgHeader{color:#333}.RadGrid_Default .rgHeader{border:0;border-bottom:1px solid #828282;background:#eaeaea 0 -2300px repeat-x url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Grid.sprite.gif')}.RadGrid .rgHeader{padding-top:5px;padding-bottom:4px;text-align:left;font-weight:normal}.RadGrid .rgHeader{padding-left:7px;padding-right:7px}.RadGrid .rgHeader{cursor:default}.RadGrid_Default .rgHeader{color:#333}.RadGrid_Default .rgHeader{border:0;border-bottom:1px solid #828282;background:#eaeaea 0 -2300px repeat-x url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Grid.sprite.gif')}.RadGrid .rgHeader{padding-top:5px;padding-bottom:4px;text-align:left;font-weight:normal}.RadGrid .rgHeader{padding-left:7px;padding-right:7px}.RadGrid .rgHeader{cursor:default}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <telerik:RadTabStrip ID="RadTabStrip1" runat="server" MultiPageID="RadMultiPage1" 
            SelectedIndex="0" Skin="WebBlue">
        <Tabs>
            <telerik:RadTab runat="server" PageViewID="RadPageView1" Selected="True" 
                Text="表單發送清單">
            </telerik:RadTab>
            <telerik:RadTab runat="server" PageViewID="RadPageView2" Text="明細">
            </telerik:RadTab>
        </Tabs>
    </telerik:RadTabStrip>
    <telerik:RadMultiPage ID="RadMultiPage1" Runat="server" BorderColor="Black" 
            BorderStyle="Solid" BorderWidth="1px" SelectedIndex="0" Width="100%">
        <telerik:RadPageView ID="RadPageView1" runat="server" Selected="True">


            <asp:Panel ID="panSearchTerm" runat="server" GroupingText="選擇課程" 
                Visible="False">
                        <asp:Panel ID="Panel2" runat="server">
                            <asp:Label ID="Label29" runat="server" Text="課程代碼："></asp:Label>
                            <asp:TextBox ID="tbEduStopCode" runat="server"></asp:TextBox>
                            <asp:Label ID="Label8" runat="server" Text="名稱："></asp:Label>
                            <asp:TextBox ID="tbEduName" runat="server"></asp:TextBox>
                            <asp:Button ID="btnQuery" runat="server" onclick="btnQuery_Click" Text="查詢課程" />
        <br />
                        </asp:Panel>
    <br />
                        <telerik:RadGrid ID="rgTerm" runat="server" AllowPaging="True" 
                            AutoGenerateColumns="False" AutoGenerateHierarchy="True" CellSpacing="0" 
                            Culture="zh-TW" GridLines="None" 
                            style="margin-top: 0px">
                            <ClientSettings>
                                <Selecting AllowRowSelect="True" />
                                <Selecting AllowRowSelect="True" />
                            </ClientSettings>
                            <MasterTableView ClientDataKeyNames="RoundCode,EduStopCode,EduTermID" 
                                commanditemdisplay="Top" DataKeyNames="RoundCode,EduStopCode,EduTermID" 
                                EditMode="PopUp" GroupLoadMode="Client" HierarchyLoadMode="Client" 
                                NoDetailRecordsText="" nomasterrecordstext="目前沒有資料">
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
                                    <telerik:GridBoundColumn DataField="UnitStr" 
                                        FilterControlAltText="Filter UnitStr column" HeaderText="單位" 
                                        UniqueName="UnitStr">
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
                                <CommandItemTemplate>
                                </CommandItemTemplate>
                                <EditFormSettings>
                                    <EditColumn canceltext="取消" edittext="儲存" 
                                        FilterControlAltText="Filter EditCommandColumn column" inserttext="儲存" 
                                        updatetext="儲存">
                                    </EditColumn>
                                    <PopUpSettings Modal="True" ScrollBars="Auto" Width="600px" />
                                    <PopUpSettings Modal="True" ScrollBars="Auto" Width="600px" />
                                </EditFormSettings>
                            </MasterTableView>
                            <PagerStyle FirstPageToolTip="第一頁" LastPageToolTip="最末頁" NextPageToolTip="下一頁" 
                                PagerTextFormat="跳至第: {4} &amp;nbsp;頁 &lt;strong&gt;{0}&lt;/strong&gt; / &lt;strong&gt;{1}&lt;/strong&gt;, 項目 &lt;strong&gt;{2}&lt;/strong&gt; - &lt;strong&gt;{3}&lt;/strong&gt; / &lt;strong&gt;{5}&lt;/strong&gt;." 
                                PageSizeLabelText="每頁筆數:" PrevPagesToolTip="上一頁" PrevPageToolTip="上一頁" />
                            <FilterMenu EnableImageSprites="False">
                            </FilterMenu>
                        </telerik:RadGrid>
            </asp:Panel>
            <asp:Button ID="btnListQuery" runat="server" onclick="btnListQuery_Click" 
                Text="查詢表單" Visible="False" />
            <br />
            <asp:Panel ID="panList" runat="server" GroupingText="表單清單">
                <telerik:RadGrid ID="rgHistory" runat="server" AllowPaging="True" 
                    AutoGenerateColumns="False" CellSpacing="0" Culture="zh-TW" GridLines="None" 
                    onitemcreated="rgHistory_ItemCreated" 
                    onneeddatasource="rgHistory_NeedDataSource">
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
                    <MasterTableView DataKeyNames="TEMPLATE_ID,FTListID">
                        <CommandItemSettings ExportToPdfText="Export to PDF" />
                        <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" 
                            Visible="False">
                        </RowIndicatorColumn>
                        <ExpandCollapseColumn Created="True" 
                            FilterControlAltText="Filter ExpandColumn column" Visible="True">
                        </ExpandCollapseColumn>
                        <Columns>
                            <telerik:GridClientSelectColumn FilterControlAltText="Filter column column" 
                                UniqueName="column">
                            </telerik:GridClientSelectColumn>
                            <telerik:GridBoundColumn DataField="name" 
                                FilterControlAltText="Filter name column" HeaderText="名稱" UniqueName="name">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="TEMPLATE_NAME" 
                                FilterControlAltText="Filter TEMPLATE_NAME column" HeaderText="表單名稱" 
                                UniqueName="TEMPLATE_NAME">
                            </telerik:GridBoundColumn>
                            <telerik:GridDateTimeColumn DataField="ExecuteDate" 
                                FilterControlAltText="Filter ExecuteDate column" HeaderText="執行日期" 
                                UniqueName="ExecuteDate" Visible="False">
                            </telerik:GridDateTimeColumn>
                            <telerik:GridBoundColumn DataField="FinishRateStr" 
                                FilterControlAltText="Filter FinishRateStr column" HeaderText="完成比" 
                                UniqueName="FinishRateStr" Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridHyperLinkColumn AllowSorting="False" 
                                DataNavigateUrlFields="CompleteDetailUrl" DataTextField="FinishRateStr" 
                                FilterControlAltText="Filter FinishRate column" HeaderText="完成比" 
                                Target="_blank" UniqueName="FinishRate">
                            </telerik:GridHyperLinkColumn>
                            <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" 
                                UniqueName="Query">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnQuery" runat="server" OnClick="lbtnStatistic_Click" 
                                        Text="查詢統計"></asp:LinkButton>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" 
                                UniqueName="Download">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnDownload" runat="server" OnClick="lbtnDownload_Click" 
                                        Text="下載已填表單"></asp:LinkButton>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                        </Columns>
                        <EditFormSettings>
                            <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                            </EditColumn>
                        </EditFormSettings>
                        <BatchEditingSettings EditType="Cell" />
                        <PagerStyle PageSizeControlType="RadComboBox" />
                    </MasterTableView>
                    <PagerStyle PageSizeControlType="RadComboBox" />
                    <FilterMenu EnableImageSprites="False">
                    </FilterMenu>
                </telerik:RadGrid>
            </asp:Panel>


            <asp:Label ID="lbFtlistid" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="lbTemplateid" runat="server" Visible="False"></asp:Label>


</telerik:RadPageView>
        <telerik:RadPageView ID="RadPageView2" runat="server" Selected="False">
        <div>
            <asp:BulletedList ID="BulletedList1" runat="server">
            </asp:BulletedList>
        </div>
        <div style="overflow:auto;">
        <telerik:RadGrid ID="rgDetailList" runat="server" 
                onneeddatasource="rgDetailList_NeedDataSource">
            </telerik:RadGrid>
            <br />
            <asp:Button ID="btnExport" runat="server" onclick="btnExport_Click" 
                Text="匯出Excel" />
            <asp:ObjectDataSource ID="dsTermCode" runat="server" SelectMethod="GetEduTeams" 
                TypeName="KMU.EduActivity.ApplicationLayer.DTO.EduTeamDto">
            </asp:ObjectDataSource>
         </div>
        </telerik:RadPageView>
</telerik:RadMultiPage>
</asp:Content>

