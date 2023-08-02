<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="EditLibrary.aspx.cs" Inherits="EditLibrary" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
    </telerik:RadAjaxManager>
   <script type="text/javascript">
        //<![CDATA[

       function openWin(args) {
           var oWnd = radopen("EditLibraryOption.aspx" + args, "rwOpen");
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

    <asp:Panel ID="Panel1" runat="server">
        <asp:Label ID="Label14" runat="server" Text="關鍵字："></asp:Label>
        <asp:TextBox ID="tbKeyWord" runat="server" Width="303px"></asp:TextBox>
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
        style="margin-top: 0px">
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
<MasterTableView commanditemdisplay="Top" nomasterrecordstext="目前沒有資料" EditMode="EditForms">
<CommandItemSettings ExportToPdfText="Export to PDF" addnewrecordtext="新增" 
        showrefreshbutton="False"></CommandItemSettings>

<RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
<HeaderStyle Width="20px"></HeaderStyle>
</RowIndicatorColumn>

<ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
<HeaderStyle Width="20px"></HeaderStyle>
</ExpandCollapseColumn>

    <Columns>
        <telerik:GridClientSelectColumn FilterControlAltText="Filter column column" 
            UniqueName="column">
        </telerik:GridClientSelectColumn>
        <telerik:GridHTMLEditorColumn DataField="QUESTION_CONTENT" 
            FilterControlAltText="Filter QUESTION_CONTENT column" HeaderText="問題內容" 
            UniqueName="QUESTION_CONTENT">
        </telerik:GridHTMLEditorColumn>

        <telerik:GridTemplateColumn 
            FilterControlAltText="Filter EduTeamStopID column" 
            UniqueName="DisplayControl" ReadOnly="True" DataField="DISPLAY">
            <ItemTemplate>
                <asp:Button runat="server" CommandName="Display" Text='<%# ((bool)Eval("DISPLAY"))?"不顯示":"顯示" %>' />
            </ItemTemplate>
        </telerik:GridTemplateColumn>

        <telerik:GridButtonColumn CommandName="Edit" Text="編輯"
                    UniqueName="EditColumn">
                    <ItemStyle HorizontalAlign="Center" CssClass="MyImageButton"></ItemStyle>
        </telerik:GridButtonColumn>
        <telerik:GridTemplateColumn 
            FilterControlAltText="Filter EduTeamStopID column" 
            UniqueName="EduTeamStopID" ReadOnly="True">
            <ItemTemplate>
                <asp:LinkButton ID="lbtnOpenCourse" runat="server"  Text="設定選項"></asp:LinkButton>            
            </ItemTemplate>
        </telerik:GridTemplateColumn>
    </Columns>

<BatchEditingSettings EditType="Cell"></BatchEditingSettings>

<PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>

<CommandItemTemplate>
    <asp:LinkButton ID="lbtnInsert" runat="server" CommandName="InitInsert" Visible='<%# !RadGrid1.MasterTableView.IsItemInserted %>'><img style="border:0px" alt="" src="../Images/add.jpg" /> 新增</asp:LinkButton>
    <asp:LinkButton ID="lbtnDelete" OnClientClick="javascript:return confirm('是否確定刪除所有選擇的項目?')"
        runat="server" CommandName="DeleteSelected"><img style="border:0px" alt="" src="../Images/delete.gif" /> 刪除</asp:LinkButton>
</CommandItemTemplate>        
<EditFormSettings>
<%--<FormTemplate>

<table width="100%">
<tr>
<td width="15%" align="right"><asp:Label runat="server" ID="Label11" Text="問題內容:"></asp:Label></td>
<td width="85%" align="left">
    <asp:TextBox ID="tbQuestion" runat="server" Height="100px" Width="350px" Text='<%# Bind("QUESTION_CONTENT") %>'></asp:TextBox>
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
</FormTemplate>--%>
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
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server" Modal="True" 
        InitialBehaviors="Maximize" InitialBehavior="Maximize" 
        DestroyOnClose="False" ShowContentDuringLoad="False" VisibleStatusbar="False">
        <Windows>
            <telerik:RadWindow ID="rwOpen" runat="server" 
                style="display:none;" OnClientClose="OnClientClose" 
                ShowContentDuringLoad="False">
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
    <br />
    <asp:Label ID="lblMsg" runat="server"></asp:Label>
</asp:Content>

