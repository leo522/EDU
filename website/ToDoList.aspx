<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ToDoList.aspx.cs" Inherits="ToDoList" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register src="DeptSelector.ascx" tagname="DeptSelector" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style>
        .iKasa{
            font-size:20px;
    background-color: #329bd8;      /* changed background color to a nice blue */
    text-transform: uppercase;      /* made the text uppercase */
    font-weight: bold;              /* gave the text a bold look */
}
 
.iKasa:hover {
    border: 0.15em #329bd8 solid;   /* set a border to a blue color */
    color: #329bd8;                 /* set a text color to the same color */
}
 
.iKasa:active {
    background-color: transparent;  
    border: 0.15em #5e8ca5 solid;   
    color: #5e8ca5;                 /* minor text color change in a deeper blue */
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server">
    </telerik:RadStyleSheetManager>
    <asp:Label ID="Label1" runat="server" Text="位置："></asp:Label>
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx">首頁</asp:HyperLink>
    <asp:Label ID="Label2" runat="server" Text="&gt;個人首頁"></asp:Label>



    <script type="text/javascript">

        $(document).ready(function () {


            $("#ToiKasa").click(function () {

                var form = document.createElement("form");
                form.setAttribute("method", "post");
                form.setAttribute("action", "iKASA/main.aspx");
                form.setAttribute("target", "_blank");

                var hiddenField = document.createElement("input");
                hiddenField.setAttribute("type", "hidden");
                hiddenField.setAttribute("name", "iKasaIdNo");
                hiddenField.setAttribute("value", '<%=(Session["EduAct_Idno"] == null ? "":Session["EduAct_Idno"].ToString()) %>');

                form.appendChild(hiddenField);


                document.body.appendChild(form);    // Not entirely sure if this is necessary
                form.submit();
            }
            );
        });


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

<br />
<div>
    <telerik:RadTabStrip ID="rtsMenu" runat="server" MultiPageID="rmpMain" SelectedIndex="1" OnTabClick="rtsMenu_TabClick">
        <Tabs>
            <telerik:RadTab runat="server" PageViewID="viewToDo" Text="個人主頁">
            </telerik:RadTab>
            <telerik:RadTab runat="server" PageViewID="viewScheduler" Text="行事曆" Selected="True">
            </telerik:RadTab>
        </Tabs>
    </telerik:RadTabStrip>
    <telerik:RadMultiPage ID="rmpMain" Runat="server" Width="100%" SelectedIndex="1">
        <telerik:RadPageView ID="viewToDo" runat="server">
            <div style="text-align:right">
            <asp:Panel ID="panQuery" runat="server" DefaultButton="btnFuncQuery">


            <asp:Label ID="Label6" runat="server" Text="站內功能搜尋："></asp:Label>
            <asp:TextBox ID="tbFuncQuery" runat="server"></asp:TextBox>
            <asp:Button ID="btnFuncQuery" runat="server" OnClick="btnFuncQuery_Click" Text="搜尋" />

            </asp:Panel>
            </div>
            <div id="word" style="color:brown"  >
醫學院-專業素養、宏觀視野、關懷鄉土、服務社會<br />
 醫學系-樂學至上、服務貢獻<br />
 後醫系-尊重生命、人文關懷、專業素養<br />
 附設醫院-以學習者為中心的典範跨領域教學            
                </div>
<%--                            <span id="ToiKasa" value="開啟教學儀錶板" class="iKasa" >
                            開啟教學儀錶板
                            </span>--%>
            
                <asp:Panel ID="panTeachData" runat="server">

        <asp:Label ID="lbTeachData" runat="server" Text="教學工作評估" Font-Bold="True" 
            ForeColor="#336600"></asp:Label>
                <asp:Literal ID="liTeachData" runat="server"></asp:Literal>

                </asp:Panel>
            <div>
                <blink>
                <asp:HyperLink ID="hlPassPortCheckItem" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Blue">[hlPassPortCheckItem]</asp:HyperLink>
                    </blink>
            </div>
            <asp:UpdatePanel ID ="pan1" runat="server">
                <ContentTemplate>

    <asp:Panel ID="Panel1" runat="server">
        
        <telerik:RadTabStrip ID="rtsList" runat="server" MultiPageID="rmpList" SelectedIndex="0" AutoPostBack="True" OnTabClick="rtsList_TabClick">
            <Tabs>
                <telerik:RadTab runat="server" PageViewID="vToDo" Selected="True" Text="待填表格" ForeColor="Blue">
                </telerik:RadTab>
                <telerik:RadTab runat="server" PageViewID="vCanWriteEx" Selected="True" Text="可代填表格" ForeColor="Blue">
                </telerik:RadTab>
                <telerik:RadTab runat="server" PageViewID="vExpire" Text="已逾期" ForeColor="Red" Visible="False">
                </telerik:RadTab>
                <telerik:RadTab runat="server" PageViewID="vDone" Text="已完成">
                </telerik:RadTab>
            </Tabs>
        </telerik:RadTabStrip>
        <telerik:RadMultiPage ID="rmpList" Runat="server" SelectedIndex="0" Width="100%">
            <telerik:RadPageView ID="vToDo" runat="server">
                <asp:Label ID="Label3" runat="server" Font-Bold="True" ForeColor="#336600" Text="待填表格"></asp:Label>
                
                <asp:Label ID="Label24" runat="server" Text="*已逾期表單可直接點選進入填寫" Font-Bold="True" ForeColor="Red"></asp:Label>
                
                <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" CellSpacing="0" Culture="zh-TW" GridLines="None" onneeddatasource="RadGrid1_NeedDataSource" AllowFilteringByColumn="True">
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
                    <MasterTableView>
                        <CommandItemSettings ExportToPdfText="Export to PDF" />
                        <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                            <HeaderStyle Width="20px" />
                        </RowIndicatorColumn>
                        <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" Visible="True">
                            <HeaderStyle Width="20px" />
                        </ExpandCollapseColumn>
                        <Columns>
                            <telerik:GridBoundColumn DataField="INSTANCE_ID" FilterControlAltText="Filter INSTANCE_ID column" HeaderText="代碼" UniqueName="INSTANCE_ID" AutoPostBackOnFilter="True" CurrentFilterFunction="Contains" ShowFilterIcon="False" Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="EduTermName" FilterControlAltText="Filter EduTermName column" HeaderText="課程名稱" UniqueName="EduTermName" AutoPostBackOnFilter="True" CurrentFilterFunction="Contains" ShowFilterIcon="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="DeptName" FilterControlAltText="Filter DeptName column" HeaderText="科別" UniqueName="DeptName" AutoPostBackOnFilter="True" CurrentFilterFunction="Contains" ShowFilterIcon="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="TemplateName" FilterControlAltText="Filter TemplateName column" HeaderText="表單名稱" UniqueName="TemplateName" AutoPostBackOnFilter="True" CurrentFilterFunction="Contains" ShowFilterIcon="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="ExTargetName" FilterControlAltText="Filter ExTargetName column" HeaderText="上位填寫人" UniqueName="ExTargetName" Visible="False" ShowFilterIcon="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="EvalTargetName" FilterControlAltText="Filter EvalTargetName column" HeaderText="考核對象" UniqueName="EvalTargetName" AutoPostBackOnFilter="True" CurrentFilterFunction="Contains" ShowFilterIcon="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="NextTargetName" FilterControlAltText="Filter NextTargetName column" HeaderText="考核老師" UniqueName="NextTargetName" AutoPostBackOnFilter="True" CurrentFilterFunction="Contains" ShowFilterIcon="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="DateStr" FilterControlAltText="Filter DateStr column" HeaderText="填寫期間" UniqueName="DateStr" AutoPostBackOnFilter="True" CurrentFilterFunction="Contains" ShowFilterIcon="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridHyperLinkColumn AllowSorting="False" Target="" DataNavigateUrlFields="ActionUrl" DataTextField="ActionName" FilterControlAltText="Filter Action column" UniqueName="Action">
                            </telerik:GridHyperLinkColumn>
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
                <asp:LinkButton ID="lbtnDisplayAll" runat="server" OnClick="lbtnDisplayAll_Click">顯示全部...</asp:LinkButton>
            </telerik:RadPageView>
            <telerik:RadPageView ID="vCanWriteEx" runat="server">
                <asp:Label ID="Label8" runat="server" Font-Bold="True" ForeColor="#336600" Text="可代填"></asp:Label>
                
                <telerik:RadGrid ID="rgCanWriteEx" runat="server" AutoGenerateColumns="False" CellSpacing="0" Culture="zh-TW" GridLines="None" onneeddatasource="rgCanWriteEx_NeedDataSource" AllowFilteringByColumn="True">
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
                    <MasterTableView>
                        <CommandItemSettings ExportToPdfText="Export to PDF" />
                        <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                            <HeaderStyle Width="20px" />
                        </RowIndicatorColumn>
                        <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" Visible="True">
                            <HeaderStyle Width="20px" />
                        </ExpandCollapseColumn>
                        <Columns>
                            <telerik:GridBoundColumn DataField="INSTANCE_ID" FilterControlAltText="Filter INSTANCE_ID column" HeaderText="代碼" UniqueName="INSTANCE_ID" AutoPostBackOnFilter="True" CurrentFilterFunction="Contains" ShowFilterIcon="False" Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="EduTermName" FilterControlAltText="Filter EduTermName column" HeaderText="課程名稱" UniqueName="EduTermName" AutoPostBackOnFilter="True" CurrentFilterFunction="Contains" ShowFilterIcon="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="DeptName" FilterControlAltText="Filter DeptName column" HeaderText="科別" UniqueName="DeptName" AutoPostBackOnFilter="True" CurrentFilterFunction="Contains" ShowFilterIcon="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="TemplateName" FilterControlAltText="Filter TemplateName column" HeaderText="表單名稱" UniqueName="TemplateName" AutoPostBackOnFilter="True" CurrentFilterFunction="Contains" ShowFilterIcon="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="ExTargetName" FilterControlAltText="Filter ExTargetName column" HeaderText="上位填寫人" UniqueName="ExTargetName" Visible="False" ShowFilterIcon="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="EvalTargetName" FilterControlAltText="Filter EvalTargetName column" HeaderText="原填寫人" UniqueName="EvalTargetName" AutoPostBackOnFilter="True" CurrentFilterFunction="Contains" ShowFilterIcon="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="DateStr" FilterControlAltText="Filter DateStr column" HeaderText="填寫期間" UniqueName="DateStr" AutoPostBackOnFilter="True" CurrentFilterFunction="Contains" ShowFilterIcon="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridHyperLinkColumn AllowSorting="False" DataNavigateUrlFields="ActionUrl" DataTextField="ActionName" FilterControlAltText="Filter Action column" UniqueName="Action">
                            </telerik:GridHyperLinkColumn>
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
                <asp:LinkButton ID="lbCanWriteExDisplayAll" runat="server" OnClick="lbCanWriteExDisplayAll_Click">顯示全部...</asp:LinkButton>
            </telerik:RadPageView>
            <telerik:RadPageView ID="vExpire" runat="server">
                <asp:Label ID="Label5" runat="server" Font-Bold="True" ForeColor="#336600" Text="已逾期(已逾期表單可請各科科秘進行填寫期間延展)"></asp:Label>
                <telerik:RadGrid ID="rgExpire" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellSpacing="0" Culture="zh-TW" GridLines="None" onneeddatasource="rgExpire_NeedDataSource" AllowFilteringByColumn="True">
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
                    <MasterTableView>
                        <CommandItemSettings ExportToPdfText="Export to PDF" />
                        <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                            <HeaderStyle Width="20px" />
                        </RowIndicatorColumn>
                        <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" Visible="True">
                            <HeaderStyle Width="20px" />
                        </ExpandCollapseColumn>
                        <Columns>
                            <telerik:GridBoundColumn DataField="INSTANCE_ID" FilterControlAltText="Filter INSTANCE_ID column" HeaderText="代碼" UniqueName="INSTANCE_ID" AutoPostBackOnFilter="True" CurrentFilterFunction="Contains" ShowFilterIcon="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="EduTermName" FilterControlAltText="Filter EduTermName column" HeaderText="課程名稱" UniqueName="EduTermName" AutoPostBackOnFilter="True" CurrentFilterFunction="Contains" ShowFilterIcon="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="DeptName" FilterControlAltText="Filter DeptName column" HeaderText="科別" UniqueName="DeptName" AutoPostBackOnFilter="True" CurrentFilterFunction="Contains" ShowFilterIcon="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="TemplateName" FilterControlAltText="Filter TemplateName column" HeaderText="表單名稱" UniqueName="TemplateName" AutoPostBackOnFilter="True" CurrentFilterFunction="Contains" ShowFilterIcon="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="ExTargetName" FilterControlAltText="Filter ExTargetName column" HeaderText="上位填寫人" UniqueName="ExTargetName" Visible="False" AutoPostBackOnFilter="True" CurrentFilterFunction="Contains" ShowFilterIcon="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="EvalTargetName" FilterControlAltText="Filter EvalTargetName column" HeaderText="考核對象" UniqueName="EvalTargetName" AutoPostBackOnFilter="True" CurrentFilterFunction="Contains" ShowFilterIcon="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="DateStr" FilterControlAltText="Filter DateStr column" HeaderText="填寫期間" UniqueName="DateStr" AutoPostBackOnFilter="True" CurrentFilterFunction="Contains" ShowFilterIcon="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridHyperLinkColumn AllowSorting="False" DataNavigateUrlFields="ActionUrl" DataTextField="ActionName" FilterControlAltText="Filter Action column" UniqueName="Action">
                            </telerik:GridHyperLinkColumn>
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
            </telerik:RadPageView>
            <telerik:RadPageView ID="vDone" runat="server">
                <asp:Label ID="Label4" runat="server" Font-Bold="True" ForeColor="#336600" Text="已填寫或已結束"></asp:Label><br />
<asp:Label ID="Label22" runat="server" Text="顯示近"></asp:Label>
        <asp:DropDownList ID="ddlMonth" runat="server">
            <asp:ListItem>1</asp:ListItem>
            <asp:ListItem>2</asp:ListItem>
            <asp:ListItem>3</asp:ListItem>
            <asp:ListItem>4</asp:ListItem>
            <asp:ListItem>5</asp:ListItem>
            <asp:ListItem>6</asp:ListItem>
            <asp:ListItem>7</asp:ListItem>
            <asp:ListItem>8</asp:ListItem>
            <asp:ListItem>9</asp:ListItem>
            <asp:ListItem>10</asp:ListItem>
            <asp:ListItem>11</asp:ListItem>
            <asp:ListItem>12</asp:ListItem>
            <asp:ListItem Value="0">全部</asp:ListItem>
        </asp:DropDownList>
        <asp:Label ID="Label23" runat="server" Text="個月資料"></asp:Label>
        <asp:Button ID="btnQueryHistory" runat="server" OnClick="btnQueryHistory_Click" Text="查詢" />
        <telerik:RadGrid ID="RadGrid2" runat="server" AutoGenerateColumns="False" 
            CellSpacing="0" Culture="zh-TW" GridLines="None" 
            onneeddatasource="RadGrid2_NeedDataSource">
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
            <MasterTableView>
                <CommandItemSettings ExportToPdfText="Export to PDF" />
                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                    <HeaderStyle Width="20px" />
                </RowIndicatorColumn>
                <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" 
                    Visible="True">
                    <HeaderStyle Width="20px" />
                </ExpandCollapseColumn>
                <Columns>
                            <telerik:GridBoundColumn DataField="INSTANCE_ID" FilterControlAltText="Filter INSTANCE_ID column" HeaderText="代碼" UniqueName="INSTANCE_ID" AutoPostBackOnFilter="True" CurrentFilterFunction="Contains" ShowFilterIcon="False" Visible="False">
                            </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="EduTermName" 
                        FilterControlAltText="Filter EduTermName column" HeaderText="課程名稱" 
                        UniqueName="EduTermName">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="DeptName" 
                        FilterControlAltText="Filter DeptName column" HeaderText="科別" 
                        UniqueName="DeptName">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="TemplateName" 
                        FilterControlAltText="Filter TemplateName column" HeaderText="表單名稱" 
                        UniqueName="TemplateName">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="ExTargetName" 
                        FilterControlAltText="Filter ExTargetName column" HeaderText="上位填寫人" 
                        UniqueName="ExTargetName" Visible="False">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="EvalTargetName" 
                        FilterControlAltText="Filter EvalTargetName column" HeaderText="考核對象" 
                        UniqueName="EvalTargetName">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="DateStr" 
                        FilterControlAltText="Filter DateStr column" HeaderText="填寫期間" 
                        UniqueName="DateStr">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="FinalScore" FilterControlAltText="Filter FinalScore column" HeaderText="成績" UniqueName="FinalScore" DataFormatString="{0:0.00}">
                    </telerik:GridBoundColumn>
                    <telerik:GridHyperLinkColumn AllowSorting="False" 
                        DataNavigateUrlFields="ActionUrl" DataTextField="ActionName" 
                        FilterControlAltText="Filter Action column" UniqueName="Action">
                    </telerik:GridHyperLinkColumn>
                    <telerik:GridBoundColumn DataField="HaveRead" FilterControlAltText="Filter HaveRead column" HeaderText="狀態" UniqueName="HaveRead">
                    </telerik:GridBoundColumn>
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
            </telerik:RadPageView>
        </telerik:RadMultiPage>
        <br />
        <br />
        <div style="display:none">
        <asp:Label ID="Label7" runat="server" Text="等待上一位填寫表格" Font-Bold="True" 
            ForeColor="#336600"></asp:Label>
        <br />
        <telerik:RadGrid ID="rgWaitBefore" runat="server" AutoGenerateColumns="False" 
            CellSpacing="0" Culture="zh-TW" GridLines="None" 
            onneeddatasource="rgWaitBefore_NeedDataSource" OnItemCommand="rgWaitBefore_ItemCommand" AllowPaging="True">
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
            <MasterTableView DataKeyNames="INSTANCE_ID">
                <CommandItemSettings ExportToPdfText="Export to PDF" />
                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                    <HeaderStyle Width="20px" />
                </RowIndicatorColumn>
                <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" 
                    Visible="True">
                    <HeaderStyle Width="20px" />
                </ExpandCollapseColumn>
                <Columns>
                    <telerik:GridBoundColumn DataField="EduTermName" 
                        FilterControlAltText="Filter EduTermName column" HeaderText="課程名稱" 
                        UniqueName="EduTermName">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="DeptName" 
                        FilterControlAltText="Filter DeptName column" HeaderText="科別" 
                        UniqueName="DeptName">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="TemplateName" 
                        FilterControlAltText="Filter TemplateName column" HeaderText="表單名稱" 
                        UniqueName="TemplateName">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="ExTargetName" 
                        FilterControlAltText="Filter ExTargetName column" HeaderText="上位填寫人" 
                        UniqueName="ExTargetName">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="EvalTargetName" 
                        FilterControlAltText="Filter EvalTargetName column" HeaderText="考核對象" 
                        UniqueName="EvalTargetName" Visible="False">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="NextTargetName" 
                        FilterControlAltText="Filter NextTargetName column" HeaderText="考核老師" 
                        UniqueName="NextTargetName" Visible="False">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="DateStr" 
                        FilterControlAltText="Filter DateStr column" HeaderText="填寫期間" 
                        UniqueName="DateStr">
                    </telerik:GridBoundColumn>
                    <telerik:GridHyperLinkColumn AllowSorting="False" 
                        DataNavigateUrlFields="ActionUrl" DataTextField="ActionName" 
                        FilterControlAltText="Filter Action column" UniqueName="Action" Visible="False">
                    </telerik:GridHyperLinkColumn>
                    <telerik:GridButtonColumn CommandName="SendAlert" DataTextField="ActionName" FilterControlAltText="Filter AlertColumn column" UniqueName="AlertColumn">
                    </telerik:GridButtonColumn>
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
            </div>
    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
                <asp:Panel ID="Panel2" runat="server">
<div>
        <asp:Label ID="Label9" runat="server" Text="公佈欄" Font-Bold="True" 
            ForeColor="#336600"></asp:Label>
<br />
</div>            
<div>
    <telerik:RadGrid ID="rgNews" runat="server" AutoGenerateColumns="False" CellSpacing="0" 
    Culture="zh-TW" GridLines="None" 
        onneeddatasource="rgNews_NeedDataSource" 
        AllowPaging="True" 
        style="margin-top: 0px" onitemcreated="rgNews_ItemCreated">
<MasterTableView commanditemdisplay="Top" nomasterrecordstext="目前沒有資料" EditMode="PopUp">
<CommandItemSettings ExportToPdfText="Export to PDF" addnewrecordtext="新增" 
        showrefreshbutton="False"></CommandItemSettings>

<RowIndicatorColumn Visible="False" 
        FilterControlAltText="Filter RowIndicator column">
</RowIndicatorColumn>

    <Columns>
        <telerik:GridDateTimeColumn DataField="SDate" 
            FilterControlAltText="Filter DateFrom column" HeaderText="日期" 
            UniqueName="SDate" Visible="True" 
            
            
            
            EditFormHeaderTextFormat="&lt;div style=&quot;text-align:right;&quot;&gt;{0}:&lt;/div&gt;" 
            DataFormatString="{0:yyyy/MM/dd}">
            <HeaderStyle Width="150px" />
        </telerik:GridDateTimeColumn>
        <telerik:GridTemplateColumn DataField="Title" 
            FilterControlAltText="Filter TemplateColumn column" HeaderText="標題" 
            UniqueName="TemplateColumn">
            <ItemTemplate>
                 <asp:LinkButton ID="lbtnShowNews" runat="server"  Text='<%# Bind("Title") %>'></asp:LinkButton>
            </ItemTemplate>
        </telerik:GridTemplateColumn>
    </Columns>

<CommandItemTemplate>
</CommandItemTemplate>        
<EditFormSettings EditFormType="Template">
<FormTemplate>

</FormTemplate>
<EditColumn FilterControlAltText="Filter EditCommandColumn column" canceltext="取消" 
        edittext="儲存" inserttext="儲存" updatetext="儲存"></EditColumn>
    <PopUpSettings Modal="True" ScrollBars="Auto" Width="600px" />
</EditFormSettings>
</MasterTableView>

        <PagerStyle FirstPageToolTip="第一頁" LastPageToolTip="最末頁" NextPageToolTip="下一頁" 
            PagerTextFormat="跳至第: {4} &amp;nbsp;頁 &lt;strong&gt;{0}&lt;/strong&gt; / &lt;strong&gt;{1}&lt;/strong&gt;, 項目 &lt;strong&gt;{2}&lt;/strong&gt; - &lt;strong&gt;{3}&lt;/strong&gt; / &lt;strong&gt;{5}&lt;/strong&gt;." 
            PageSizeLabelText="每頁筆數:" PrevPagesToolTip="上一頁" PrevPageToolTip="上一頁" />

<FilterMenu EnableImageSprites="False"></FilterMenu>
</telerik:RadGrid>
</div>


                </asp:Panel>


        </telerik:RadPageView>
        <telerik:RadPageView ID="viewScheduler" runat="server">

<div>
        <asp:Label ID="Label21" runat="server" Text="個人行事曆" Font-Bold="True" 
            ForeColor="#336600"></asp:Label>
        <asp:Panel ID="panDept" runat="server">
            <asp:Label ID="Label29" runat="server" Text="部門："></asp:Label>
            <uc1:DeptSelector ID="DeptSelector1" runat="server" />
            &nbsp;&nbsp;<asp:Button ID="btnQuery" runat="server" onclick="btnQuery_Click" Text="查詢" />
            &nbsp;</asp:Panel>
</div>
<asp:Panel ID="palRadScheduler" runat="server">
<div style="z-index:1;">

    
        <telerik:RadScheduler ID="rsList" runat="server" AllowDelete="False" 
            AllowEdit="False" AllowInsert="False" Culture="zh-TW" 
            EnableRecurrenceSupport="False" Height="" 
            onappointmentcreated="rsList_AppointmentCreated" 
            onnavigationcomplete="rsList_NavigationComplete" 
            ontimeslotcreated="rsList_TimeSlotCreated" OverflowBehavior="Expand" 
            RowHeight="" SelectedView="MonthView" Skin="Simple" 
            StartEditingInAdvancedForm="False">
            <AdvancedForm DateFormat="yyyy/MM/dd" Modal="True" TimeFormat="HH:mm" />
            <Localization AdvancedAllDayEvent="全天" AdvancedCalendarCancel="取消" 
                AdvancedCalendarOK="確定" AdvancedCalendarToday="今天" AdvancedClose="" 
                AdvancedDaily="每日" AdvancedDay="日" AdvancedDays="日" AdvancedDescription="內容" 
                AdvancedDone="完成" AdvancedEditAppointment="編輯行事曆" AdvancedFrom="開始時間" 
                AdvancedNewAppointment="新增行事曆" AdvancedSubject="主旨" AdvancedTo="結束時間" 
                Cancel="取消" ConfirmCancel="取消" ConfirmDeleteText="確定刪除本項行程?" 
                ConfirmDeleteTitle="確定刪除" ContextMenuAddAppointment="新增行事曆" 
                ContextMenuDelete="刪除" ContextMenuEdit="編輯" HeaderToday="今天" Save="儲存" 
                ShowAdvancedForm="細項設定" />
            <TimelineView UserSelectable="False" />
            <WeekView UserSelectable="False" />
            <DayView UserSelectable="False" />
            <MonthView VisibleAppointmentsPerDay="500" />
            <AppointmentTemplate>
                <div>
                    <%# Convert.ToDateTime(Eval("Start")).ToString("HH:mm") %>~<%# Convert.ToDateTime(Eval("End")).ToString("HH:mm") %></div>
                <div>
                    <asp:Button ID="btnBook" runat="server" Text="報名" OnClick="btnBook_Click" />
                    <asp:Button ID="btnMan" runat="server" Text="人" />
                    <asp:ImageButton ID="ibtnMan" runat="server" 
                        ImageUrl="~/Images/operation_ok.gif" />
                    &nbsp;<asp:Button ID="btnAttachment" runat="server" Text="文" Visible="false" />
                    &nbsp;<asp:Button ID="btnDelete" runat="server" 
                        OnClientClick="javascript:if(!confirm('是否確定刪除該筆公告?')) return false;" Text="消" />
                </div>
                <div>
                    <asp:HyperLink ID="lbtnSubject" Target="_blank" runat="server" Text='<%# Eval("Subject")%>'></asp:HyperLink>
                    
                </div>
            </AppointmentTemplate>
        </telerik:RadScheduler>
    
</div>

</asp:Panel>
        </telerik:RadPageView>
    </telerik:RadMultiPage>

</div>
    <asp:ObjectDataSource ID="dsJobCode" runat="server" SelectMethod="GetJobCodes" 
        TypeName="KMU.EduActivity.ApplicationLayer.DTO.SelectEduActJobCodeDto">
    </asp:ObjectDataSource>
    </asp:Content>