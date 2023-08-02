<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Member.aspx.cs" Inherits="Member" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register src="TreeViewComboBox.ascx" tagname="TreeViewComboBox" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<script language="javascript" type="text/javascript">
    function showhidediv() {
        try {
            var sbtitle = document.getElementById('importDiv');
            if (sbtitle) {
                if (sbtitle.style.display == 'block') {
                    sbtitle.style.display = 'none';
                } else {
                    sbtitle.style.display = 'block';
                }
            }
        } catch (e) { }
    }
</script>


    <asp:Label ID="Label1" runat="server" Text="位置："></asp:Label>
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx">首頁</asp:HyperLink>
    <asp:Label ID="Label2" runat="server" Text="&gt;"></asp:Label>
    <asp:HyperLink ID="HyperLink2" runat="server">學員管理</asp:HyperLink>
    <asp:Label ID="Label3" runat="server" Text="&gt;學員名單維護"></asp:Label>
    <asp:Panel ID="Panel1" runat="server">
    <table>
    <tr>
    <td align="right">
        <asp:Label ID="Label4" runat="server" Text="職稱："></asp:Label>
        </td>
    <td>
        <telerik:RadComboBox ID="ddlJobCode" Runat="server" CheckBoxes="True" 
            DataSourceID="dsJobCode" DataTextField="Name" DataValueField="Code" 
            EnableCheckAllItemsCheckBox="True" ondatabound="ddlJobCode_DataBound">
            <Localization AllItemsCheckedString="全部" CheckAllString="全部" 
                ItemsCheckedString="項以選擇" />
        </telerik:RadComboBox>
        </td>
    <td align="right">
        <asp:Label ID="Label5" runat="server" Text="學號："></asp:Label>
        </td>
    <td>
        <asp:TextBox ID="tbMemberCode" runat="server"></asp:TextBox>
        </td>
    <td align="right">
        <asp:Label ID="Label17" runat="server" Text="姓名："></asp:Label>
        </td>
    <td>
        <asp:TextBox ID="tbMemberName" runat="server"></asp:TextBox>
        </td>
    <td align="right">
        <asp:Label ID="Label16" runat="server" Text="組別："></asp:Label>
        </td>
    <td>
        <uc1:TreeViewComboBox ID="TreeViewComboBox2" runat="server" 
            AutoPostBack="False" Enabled="True" TreeDataFieldID="EduTeamCode" 
            TreeDataFieldParentID="parentEduTeamCode" TreeDataSourceID="dsTermCode" 
            TreeDataTextField="EduTeamName" />
        </td>
    </tr>
    <tr>
    <td align="right">
        <asp:Label ID="Label6" runat="server" Text="訓練期間："></asp:Label>
        </td>
    <td>
        <telerik:RadDatePicker ID="rdpDateBegin" Runat="server">
        </telerik:RadDatePicker>
        </td>
    <td align="center">
        <asp:Label ID="Label7" runat="server" Text="~"></asp:Label>
        </td>
    <td>
        <telerik:RadDatePicker ID="rdpDateEnd" Runat="server">
        </telerik:RadDatePicker>
        </td>
    <td></td>
    <td>
        <asp:Button ID="btnQuery" runat="server" onclick="btnQuery_Click" Text="查詢" />
        </td>
    <td>
        <asp:Button ID="btnExport" runat="server" OnClick="btnExport_Click" Text="匯出" />
        </td>
    <td>
        &nbsp;</td>
    </tr>
    </table>
        <br />
    </asp:Panel>
    <br />
    <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" CellSpacing="0" 
    Culture="zh-TW" GridLines="None" 
        ondeletecommand="RadGrid1_DeleteCommand" 
        oninsertcommand="RadGrid1_InsertCommand" 
        onneeddatasource="RadGrid1_NeedDataSource" 
        onupdatecommand="RadGrid1_UpdateCommand" 
        onitemcommand="RadGrid1_ItemCommand" AllowMultiRowSelection="True" 
        AllowPaging="True">
<ExportSettings>
<Pdf>
<PageHeader>
<LeftCell Text=""></LeftCell>

<MiddleCell Text=""></MiddleCell>

<RightCell Text=""></RightCell>
</PageHeader>

<PageFooter>
<LeftCell Text=""></LeftCell>

<MiddleCell Text=""></MiddleCell>

<RightCell Text=""></RightCell>
</PageFooter>
</Pdf>
</ExportSettings>

        <ClientSettings>
            <Selecting AllowRowSelect="True" />
        </ClientSettings>
<MasterTableView commanditemdisplay="Top" nomasterrecordstext="目前沒有資料" EditMode="PopUp" 
            InsertItemPageIndexAction="ShowItemOnCurrentPage">
<CommandItemSettings ExportToPdfText="Export to PDF" addnewrecordtext="新增" 
        showrefreshbutton="False"></CommandItemSettings>

<RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
<HeaderStyle Width="20px"></HeaderStyle>
</RowIndicatorColumn>

<ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
<HeaderStyle Width="20px"></HeaderStyle>
</ExpandCollapseColumn>

    <Columns>
        <telerik:GridClientSelectColumn FilterControlAltText="Filter column column" 
            UniqueName="column">
        </telerik:GridClientSelectColumn>
        <telerik:GridBoundColumn DataField="MemberCode" 
            FilterControlAltText="Filter EduTeamCode column" HeaderText="學號" 
            UniqueName="MemberCode" 
            EditFormHeaderTextFormat="&lt;div style=&quot;text-align:right;&quot;&gt;{0}:&lt;/div&gt;">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="Name" 
            FilterControlAltText="Filter Name column" HeaderText="姓名" 
            UniqueName="Name" 
            EditFormHeaderTextFormat="&lt;div style=&quot;text-align:right;&quot;&gt;{0}:&lt;/div&gt;">
        </telerik:GridBoundColumn>
        <telerik:GridDropDownColumn DataField="MemberType" DataSourceID="dsJobCode" 
            FilterControlAltText="Filter MemberType column" HeaderText="職稱" 
            ListTextField="Name" ListValueField="Code" UniqueName="MemberType" 
            EditFormHeaderTextFormat="&lt;div style=&quot;text-align:right;&quot;&gt;{0}:&lt;/div&gt;">
        </telerik:GridDropDownColumn>
        <telerik:GridBoundColumn DataField="isHospMember" 
            FilterControlAltText="Filter isHospMember column" HeaderText="員工編號" 
            UniqueName="isHospMember">
        </telerik:GridBoundColumn>
        <telerik:GridDateTimeColumn DataField="DateFrom" 
            DataFormatString="{0: yyyy.MM.dd}" 
            FilterControlAltText="Filter DateFrom column" HeaderText="訓練起始日" 
            UniqueName="DateFrom" 
            EditFormHeaderTextFormat="&lt;div style=&quot;text-align:right;&quot;&gt;{0}:&lt;/div&gt;" MaxDate="9999-12-31">
        </telerik:GridDateTimeColumn>
        <telerik:GridDateTimeColumn DataField="DateTo" 
            DataFormatString="{0: yyyy.MM.dd}" FilterControlAltText="Filter DateTo column" 
            HeaderText="訓練結束日" UniqueName="DateTo" 
            EditFormHeaderTextFormat="&lt;div style=&quot;text-align:right;&quot;&gt;{0}:&lt;/div&gt;" MaxDate="9999-12-31">
        </telerik:GridDateTimeColumn>
        <telerik:GridBoundColumn DataField="StatusName" 
            FilterControlAltText="Filter StatusName column" HeaderText="狀態" 
            UniqueName="StatusName" ReadOnly="True" 
            EditFormHeaderTextFormat="&lt;div style=&quot;text-align:right;&quot;&gt;{0}:&lt;/div&gt;">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="TrainingProcess" FilterControlAltText="Filter TrainingProcess column" HeaderText="訓練階段" UniqueName="TrainingProcess">
        </telerik:GridBoundColumn>
        <telerik:GridDropDownColumn DataField="EduTeamCode" 
            FilterControlAltText="Filter EduTeamCode column" HeaderText="組別" 
            UniqueName="EduTeamCode" DataSourceID="dsTermCode" 
            ListTextField="EduTeamName" ListValueField="EduTeamCode"
            EditFormHeaderTextFormat="&lt;div style=&quot;text-align:right;&quot;&gt;{0}:&lt;/div&gt;">
        </telerik:GridDropDownColumn>
        <telerik:GridButtonColumn ButtonType="ImageButton" CommandName="Edit" Text="編輯"
                    UniqueName="EditColumn">
                    <ItemStyle HorizontalAlign="Center" CssClass="MyImageButton"></ItemStyle>
        </telerik:GridButtonColumn>
        <telerik:GridButtonColumn ConfirmText="是否確定刪除?" ConfirmDialogType="RadWindow"
                    ConfirmTitle="Delete" ButtonType="ImageButton" CommandName="Delete" Text="刪除"
                    UniqueName="DeleteColumn">
                    <ItemStyle HorizontalAlign="Center" CssClass="MyImageButton"></ItemStyle>
        </telerik:GridButtonColumn>
        <telerik:GridBoundColumn DataField="isHospMember" 
            FilterControlAltText="Filter isHospMember column" HeaderText="院內員工碼" 
            UniqueName="isHospMember" Visible="False" 
            EditFormHeaderTextFormat="&lt;div style=&quot;text-align:right;&quot;&gt;{0}:&lt;/div&gt;">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="Des" 
            FilterControlAltText="Filter Des column" HeaderText="說明" UniqueName="Des" 
            Visible="False" 
            EditFormHeaderTextFormat="&lt;div style=&quot;text-align:right;&quot;&gt;{0}:&lt;/div&gt;">
        </telerik:GridBoundColumn>
    </Columns>

<BatchEditingSettings EditType="Cell"></BatchEditingSettings>

<PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
<CommandItemTemplate>
    <asp:LinkButton ID="lbtnInsert" runat="server" CommandName="InitInsert" Visible='<%# !RadGrid1.MasterTableView.IsItemInserted %>'><img style="border:0px" alt="" src="Images/add.jpg" /> 新增</asp:LinkButton>
    <img style="border:0px;cursor:pointer" alt="" onclick="showhidediv();return false;"  src="Images/download.gif" /><asp:Label style="cursor:pointer" ID="lbtnImport"  Text=" 匯入" OnClick="showhidediv();return false;" 
        runat="server"></asp:Label>
    <asp:LinkButton ID="lbtnDelete" OnClientClick="javascript:return confirm('是否確定刪除所有選擇的項目?')"
        runat="server" CommandName="DeleteSelected"><img style="border:0px" alt="" src="Images/delete.gif" /> 刪除</asp:LinkButton>
</CommandItemTemplate>        
<EditFormSettings EditFormType="Template">
<FormTemplate>
<table width="100%">
<tr>
<td width = "15%" align="right"><asp:Label runat="server" ID="lb1" Text="學號:"></asp:Label></td>
<td width = "85%" align="left">
<asp:TextBox ID="tbMemberCode" Text='<%# Bind("MemberCode") %>' runat="server"></asp:TextBox>
</td>
</tr>
<tr>
<td align="right"><asp:Label runat="server" ID="Label9" Text="姓名:"></asp:Label></td>
<td align="left">
<asp:TextBox ID="tbName" Text='<%# Bind("Name") %>' runat="server"></asp:TextBox>
</td>
</tr>
<tr>
<td align="right"><asp:Label runat="server" ID="Label10" Text="職稱:"></asp:Label></td>
<td align="left">
        <telerik:RadComboBox ID="ddlJobCode" Runat="server" SelectedValue='<%# Bind("MemberType") %>'
            DataSourceID="dsJobCode" DataTextField="Name" DataValueField="Code" >
        </telerik:RadComboBox>
</td>
</tr>
<tr>
<td align="right"><asp:Label runat="server" ID="Label11" Text="訓練起始日:"></asp:Label></td>
<td align="left">
        <telerik:RadDatePicker ID="rdpEditDateBegin" Runat="server" DbSelectedDate='<%# Bind("DateFrom") %>' MaxDate="9999-12-31">
        </telerik:RadDatePicker>
</td>
</tr>
<tr>
<td align="right"><asp:Label runat="server" ID="Label12" Text="訓練結束日:"></asp:Label></td>
<td align="left">
        <telerik:RadDatePicker ID="rdpEditDateEnd" Runat="server" DbSelectedDate='<%# Bind("DateTo") %>' MaxDate="9999-12-31">
        </telerik:RadDatePicker>
</td>
</tr>
<tr>
<td align="right"><asp:Label runat="server" ID="Label13" Text="組別:"></asp:Label></td>
<td align="left">
    <uc1:TreeViewComboBox ID="TreeViewComboBox1" runat="server" Enabled="True" 
        TreeDataFieldID="EduTeamCode" TreeDataFieldParentID="parentEduTeamCode" 
        TreeDataSourceID="dsTermCode" TreeDataTextField="EduTeamName" SelectedValue='<%# Bind("EduTeamCode") %>' SelectedText='<%# Bind("EduTeamName") %>' />
</td>
</tr>
<tr>
<td align="right"><asp:Label runat="server" ID="Label14" Text="院內員工碼:"></asp:Label></td>
<td align="left">
<asp:TextBox ID="tbisHospMember" Text='<%# Bind("isHospMember") %>' runat="server"></asp:TextBox>
</td>
</tr>
<tr>
<td align="right"><asp:Label runat="server" ID="Label15" Text="說明:"></asp:Label></td>
<td align="left">
<asp:TextBox ID="tbDes" Text='<%# Bind("Des") %>' runat="server"></asp:TextBox>
</td>
</tr>
<tr>
<td align="right"><asp:Label runat="server" ID="Label18" Text="訓練階段:"></asp:Label></td>
<td align="left">
<asp:TextBox ID="tbTrainingProcess" Text='<%# Bind("TrainingProcess") %>' runat="server"></asp:TextBox>
</td>
</tr>

<tr>
<td colspan="2" align="left">
<asp:Button ID="btnUpdate" Text="儲存"
runat="server" CommandName='<%# (Container is GridEditFormInsertItem) ? "PerformInsert" : "Update" %>'>
</asp:Button>&nbsp;
<asp:Button ID="btnCancel" Text="取消" runat="server" CausesValidation="False" CommandName="Cancel"></asp:Button>
</td>
</tr>
</table>
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
    <asp:ObjectDataSource ID="dsTermCode" runat="server" SelectMethod="GetEduTeams" 
        TypeName="KMU.EduActivity.ApplicationLayer.DTO.EduTeamDto">
    </asp:ObjectDataSource>
    
    <asp:ObjectDataSource ID="dsJobCode" runat="server" SelectMethod="GetJobCodes" 
        TypeName="KMU.EduActivity.ApplicationLayer.DTO.SelectEduActJobCodeDto">
    </asp:ObjectDataSource>

    <br />

<div id="importDiv" style="display:none;">
    <asp:Label ID="Label8" runat="server" Text="匯入學員資料："></asp:Label>
    <asp:FileUpload ID="FileUpload1" runat="server" />
    <asp:Button ID="btnImport" runat="server" onclick="btnImport_Click" Text="匯入" />
    <br /><br />
    匯入說明：<br />
    1. 格式為.csv或excel檔<br />
    2. 格式：[學號][姓名]<font color="red">[職稱]</font>[訓練結束日期]<font color="red">[組別]</font>[說明][員工編號][訓練階段]<br />
    3. 職稱及組別請填寫代碼 <a href="JobCodeQuery.aspx" target="_blank">職稱代碼查詢</a> <a href="EduTeamQuery.aspx" target="_blank">組別代碼查詢</a><br />
    4. 範例 <a href="docs/sample.xls">下載</a>
</div>
    <asp:Label ID="lblMsg" runat="server"></asp:Label>
    </asp:Content>

