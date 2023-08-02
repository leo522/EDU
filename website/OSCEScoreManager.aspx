﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="OSCEScoreManager.aspx.cs" Inherits="OSCEScoreManager" %>
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

    <asp:Panel ID="Panel1" runat="server">
    <table>
    <tr>
    <td><asp:Label ID="Label6" runat="server" Text="考試日期："></asp:Label></td>
    <td>        <telerik:RadDatePicker ID="rdpExamDate" Runat="server">
        </telerik:RadDatePicker></td>
    <td>        
        <asp:Label ID="Label7" runat="server" Text="考試名稱："></asp:Label>
        </td>
    <td>        
        <asp:TextBox ID="tbExamName" runat="server"></asp:TextBox>
        </td>
    <td>
        <asp:Button ID="btnQuery" runat="server" onclick="btnQuery_Click" Text="查詢" /></td>
    </tr>
    </table>
    </asp:Panel>
    <br />
    <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" CellSpacing="0" 
    Culture="zh-TW" GridLines="None" 
        ondeletecommand="RadGrid1_DeleteCommand" 
        onneeddatasource="RadGrid1_NeedDataSource" 
        onitemcommand="RadGrid1_ItemCommand" AllowMultiRowSelection="True" 
        AllowPaging="True" onitemcreated="RadGrid1_ItemCreated" 
        style="margin-top: 0px" AutoGenerateDeleteColumn="True">
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
            UniqueName="column" Visible="False">
        </telerik:GridClientSelectColumn>
        <telerik:GridDateTimeColumn DataField="ExamDate" 
            FilterControlAltText="Filter DateFrom column" HeaderText="考試日期" 
            UniqueName="ExamDate" 
            
            EditFormHeaderTextFormat="&lt;div style=&quot;text-align:right;&quot;&gt;{0}:&lt;/div&gt;" DataFormatString="{0:yyyy/MM/dd}">
        </telerik:GridDateTimeColumn>
        <telerik:GridBoundColumn DataField="ExamName" 
            FilterControlAltText="Filter EduTeamCode column" HeaderText="考試名稱" 
            UniqueName="ExamName" ReadOnly="True" 
            
            EditFormHeaderTextFormat="&lt;div style=&quot;text-align:right;&quot;&gt;{0}:&lt;/div&gt;">
        </telerik:GridBoundColumn>
        <telerik:GridTemplateColumn 
            FilterControlAltText="Filter EduTeamStopID column" 
            UniqueName="Edit">
            <ItemTemplate>
                <asp:LinkButton ID="lbtnEdit" runat="server"  Text="編輯"></asp:LinkButton>            
            </ItemTemplate>
        </telerik:GridTemplateColumn>
    </Columns>

<CommandItemTemplate>
    <asp:LinkButton ID="lbtnInsert" runat="server" OnClientClick="javascript:location.href='OSCEScoreEdit.aspx';return false;"><img style="border:0px" alt="" src="Images/add.jpg" /> 新增</asp:LinkButton>

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
    </asp:Content>

