<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="EditLibraryOption.aspx.cs" Inherits="EditLibraryOption" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server" onkeydown="if ((event.which && event.which == 13) || (event.keyCode && event.keyCode == 13)){return false;};">
    <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server">
    </telerik:RadStyleSheetManager>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
    </telerik:RadAjaxManager>

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
        <telerik:GridBoundColumn DataField="OPTION_NAME" 
            FilterControlAltText="Filter OPTION_NAME column" HeaderText="類別" 
            UniqueName="OPTION_NAME">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="OPTION_TEXT" 
            FilterControlAltText="Filter EduTeamCode column" HeaderText="問題內容" 
            UniqueName="OPTION_TEXT" 
            
            
            
            
            EditFormHeaderTextFormat="&lt;div style=&quot;text-align:right;&quot;&gt;{0}:&lt;/div&gt;">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="OPTION_POINTS" 
            FilterControlAltText="Filter OPTION_POINTS column" HeaderText="分數" 
            UniqueName="OPTION_POINTS">
        </telerik:GridBoundColumn>
        <telerik:GridButtonColumn CommandName="Edit" Text="編輯"
                    UniqueName="EditColumn">
                    <ItemStyle HorizontalAlign="Center" CssClass="MyImageButton"></ItemStyle>
        </telerik:GridButtonColumn>
    </Columns>

<BatchEditingSettings EditType="Cell"></BatchEditingSettings>

<PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>

<CommandItemTemplate>
    <asp:LinkButton ID="lbtnInsert" runat="server" CommandName="InitInsert" Visible='<%# !RadGrid1.MasterTableView.IsItemInserted %>'><img style="border:0px" alt="" src="../Images/add.jpg" /> 新增</asp:LinkButton>
    <asp:LinkButton ID="lbtnDelete" OnClientClick="javascript:return confirm('是否確定刪除所有選擇的項目?')"
        runat="server" CommandName="DeleteSelected"><img style="border:0px" alt="" src="../Images/delete.gif" /> 刪除</asp:LinkButton>
</CommandItemTemplate>        
<EditFormSettings EditFormType="Template">
<FormTemplate>

<table width="100%">
<tr>
<td width="15%" align="right"><asp:Label runat="server" ID="Label11" Text="類型:"></asp:Label></td>
<td width="85%" align="left">

    <asp:DropDownList ID="ddlType" runat="server" Width="100px" 
        DataSourceID="dsOptionType" DataTextField="NAME" DataValueField="CODE">
    </asp:DropDownList>

</td>
</tr>
<tr>
<td width="15%" align="right"><asp:Label runat="server" ID="Label1" Text="文字:"></asp:Label></td>
<td width="85%" align="left">
    <asp:TextBox ID="tbText" runat="server" Height="40px" TextMode="MultiLine" 
        Width="350px" Text='<%# Bind("OPTION_TEXT") %>'></asp:TextBox>

</td>
</tr>
<tr>
<td width="15%" align="right"><asp:Label runat="server" ID="Label2" Text="分數:"></asp:Label></td>
<td width="85%" align="left">

    <telerik:RadNumericTextBox ID="rntbPoint" Runat="server">
    </telerik:RadNumericTextBox>

</td>
</tr>
<tr>
<td width="15%" align="right"><asp:Label runat="server" ID="Label3" Text="顯示順序:"></asp:Label></td>
<td width="85%" align="left">

    <telerik:RadNumericTextBox ID="rntbOrder" Runat="server">
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

</td>
</tr>

<tr>
<td width="15%" align="right"><asp:Label runat="server" ID="Label4"></asp:Label></td>
<td width="85%" align="left">

    <asp:CheckBox ID="cbAnswer" runat="server" Text="是否為正確解答" />

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
    <telerik:RadScriptManager ID="RadScriptManager1" Runat="server">
    </telerik:RadScriptManager>
    <asp:ObjectDataSource ID="dsOptionType" runat="server" SelectMethod="GetOptionType" 
        TypeName="HtmlFormUtility.FORM_OPTION_TYPE">
    </asp:ObjectDataSource>
    
    <br />
    <asp:Label ID="lblMsg" runat="server"></asp:Label>
    </form>
</body>
</html>

