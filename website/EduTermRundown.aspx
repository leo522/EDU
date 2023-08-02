<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="EduTermRundown.aspx.cs" Inherits="EduTermRundown" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register src="TreeViewComboBox.ascx" tagname="TreeViewComboBox" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server">
    </telerik:RadStyleSheetManager>
   <script type="text/javascript">
        //<![CDATA[

       function openWin(args) {
           var oWnd = radopen("EduTermEdit.aspx" + args, "rwOpen");
       }

       function OnClientClose(oWnd, args) {
       try
       {
           if (args._argument.NeedRefresh) {
               var btn = document.getElementById('<%=btnQuery.ClientID %>');
               if (btn) btn.click();
           }
           }
           catch(e)
           {
           }
       }
        //]]>
    </script>

    <asp:Label ID="Label1" runat="server" Text="位置："></asp:Label>
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx">首頁</asp:HyperLink>
    <asp:Label ID="Label2" runat="server" Text="&gt;"></asp:Label>
    <asp:HyperLink ID="HyperLink2" runat="server">課程管理</asp:HyperLink>
    <asp:Label ID="Label3" runat="server" Text="&gt;訓練時間設定"></asp:Label>
    <asp:Panel ID="Panel1" runat="server">
        <asp:Label ID="Label6" runat="server" Text="課程日期："></asp:Label>
        <telerik:RadDatePicker ID="rdpDateBegin" Runat="server">
        </telerik:RadDatePicker>
        <asp:Label ID="Label7" runat="server" Text="~"></asp:Label>
        <telerik:RadDatePicker ID="rdpDateEnd" Runat="server">
        </telerik:RadDatePicker>
        <asp:Label ID="Label4" runat="server" Text="職稱：" Visible="False"></asp:Label>
        <telerik:RadComboBox ID="ddlJobCode" Runat="server" CheckBoxes="True" 
            DataSourceID="dsJobCode" DataTextField="Name" DataValueField="Code" 
            EnableCheckAllItemsCheckBox="True" ondatabound="ddlJobCode_DataBound" 
            Visible="False">
            <Localization AllItemsCheckedString="全部" CheckAllString="全部" 
                ItemsCheckedString="項以選擇" />
        </telerik:RadComboBox>
        <asp:Button ID="btnQuery" runat="server" onclick="btnQuery_Click" Text="查詢" />
    </asp:Panel>
    <br />
    <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" CellSpacing="0" 
    Culture="zh-TW" GridLines="None" 
        ondeletecommand="RadGrid1_DeleteCommand" 
        oninsertcommand="RadGrid1_InsertCommand" 
        onneeddatasource="RadGrid1_NeedDataSource" 
        onupdatecommand="RadGrid1_UpdateCommand" 
        onitemcommand="RadGrid1_ItemCommand" AllowMultiRowSelection="True" 
        AllowPaging="True" onitemcreated="RadGrid1_ItemCreated" 
        style="margin-top: 0px" onitemdatabound="RadGrid1_ItemDataBound">
        <ClientSettings>
            <Selecting AllowRowSelect="True" />
        </ClientSettings>
<MasterTableView commanditemdisplay="Top" nomasterrecordstext="目前沒有資料" EditMode="PopUp">
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
        <telerik:GridDateTimeColumn DataField="DateFrom" 
            FilterControlAltText="Filter DateFrom column" HeaderText="課程起始日期" 
            UniqueName="DateFrom" Visible="False" 
            EditFormHeaderTextFormat="&lt;div style=&quot;text-align:right;&quot;&gt;{0}:&lt;/div&gt;">
        </telerik:GridDateTimeColumn>
        <telerik:GridDateTimeColumn DataField="DateTo" 
            FilterControlAltText="Filter DateTo column" HeaderText="課程結束日期" UniqueName="DateTo" 
            Visible="False" 
            EditFormHeaderTextFormat="&lt;div style=&quot;text-align:right;&quot;&gt;{0}:&lt;/div&gt;">
        </telerik:GridDateTimeColumn>
        <telerik:GridBoundColumn DataField="DateFromToStr" 
            FilterControlAltText="Filter EduTeamCode column" HeaderText="課程日期" 
            UniqueName="DateFromToStr" ReadOnly="True" 
            EditFormHeaderTextFormat="&lt;div style=&quot;text-align:right;&quot;&gt;{0}:&lt;/div&gt;">
        </telerik:GridBoundColumn>
        <telerik:GridDropDownColumn DataSourceID="dsJobCode" 
            FilterControlAltText="Filter MemberType column" HeaderText="職稱" 
            ListTextField="Name" ListValueField="Code" UniqueName="JobCode" 
            
            EditFormHeaderTextFormat="&lt;div style=&quot;text-align:right;&quot;&gt;{0}:&lt;/div&gt;" 
            ReadOnly="True" Visible="False">
        </telerik:GridDropDownColumn>
        <telerik:GridDropDownColumn DataField="EduTeamCode" 
            FilterControlAltText="Filter EduTeamCode column" HeaderText="組別" 
            UniqueName="EduTeamCode" DataSourceID="dsTermCode" 
            ListTextField="EduTeamName" ListValueField="EduTeamCode" 
            EditFormHeaderTextFormat="&lt;div style=&quot;text-align:right;&quot;&gt;{0}:&lt;/div&gt;">
        </telerik:GridDropDownColumn>
        <telerik:GridButtonColumn CommandName="Edit" Text="編輯"
                    UniqueName="EditColumn">
                    <ItemStyle HorizontalAlign="Center" CssClass="MyImageButton"></ItemStyle>
        </telerik:GridButtonColumn>
        <telerik:GridTemplateColumn 
            FilterControlAltText="Filter EduTeamStopID column" 
            UniqueName="EduTeamStopID">
            <ItemTemplate>
                <asp:LinkButton ID="lbtnOpenCourse" runat="server"  Text="輪訓"></asp:LinkButton>            
            </ItemTemplate>
        </telerik:GridTemplateColumn>
    </Columns>

<CommandItemTemplate>
    <asp:LinkButton ID="lbtnInsert" runat="server" CommandName="InitInsert"><img style="border:0px" alt="" src="Images/add.jpg" /> 新增</asp:LinkButton>
    <asp:LinkButton ID="lbtnDelete" OnClientClick="javascript:return confirm('是否確定刪除所有選擇的項目?')"
        runat="server" CommandName="DeleteSelected"><img style="border:0px" alt="" src="Images/delete.gif" /> 刪除</asp:LinkButton>
</CommandItemTemplate>        
<EditFormSettings EditFormType="Template">
<FormTemplate>

<table width="100%">
<tr>
<td width="15%" align="right"><asp:Label runat="server" ID="Label11" Text="課程起始日:"></asp:Label></td>
<td width="85%" align="left">
        <telerik:RadDateTimePicker ID="rdpEditDateBegin" Width="200px"  Culture="en-US" Runat="server" DbSelectedDate='<%# Bind("DateFrom") %>'>
                                <TimeView CellSpacing="-1" Culture="en-US">
                                </TimeView>
        </telerik:RadDateTimePicker>
</td>
</tr>
<tr>
<td align="right"><asp:Label runat="server" ID="Label12" Text="課程結束日:"></asp:Label></td>
<td align="left">
        <telerik:RadDateTimePicker ID="rdpEditDateEnd" Width="200px"  Culture="en-US" Runat="server" DbSelectedDate='<%# Bind("DateTo") %>'>
                                <TimeView CellSpacing="-1" Culture="en-US">
                                </TimeView>
        </telerik:RadDateTimePicker>
</td>
</tr>
<tr>
<td align="right"><asp:Label runat="server" ID="Label13" Text="組別:"></asp:Label></td>
<td align="left">
    <uc1:TreeViewComboBox ID="TreeViewComboBox1" runat="server" Enabled="True" 
        TreeDataFieldID="EduTeamCode" TreeDataFieldParentID="parentEduTeamCode"
        TreeDataSourceID="dsTermCode" TreeDataTextField="EduTeamName" SelectedValue='<%# Bind("EduTeamCode") %>' />
</td>
</tr>
<tr>
<td colspan="2" align="left">
<asp:Button ID="btnUpdate" Text="儲存" runat="server" CommandName='<%# (Container is GridEditFormInsertItem) ? "PerformInsert" : "Update" %>'>
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
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server" Modal="True">
        <Windows>
            <telerik:RadWindow ID="rwOpen" runat="server" Width="650" Height="350" 
                style="display:none;" OnClientClose="OnClientClose">
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
    <br />
    <asp:Label ID="lblMsg" runat="server"></asp:Label>
</asp:Content>

