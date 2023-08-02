<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="MyStudent.aspx.cs" Inherits="MyStudent" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register src="TreeViewComboBox.ascx" tagname="TreeViewComboBox" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server">
    </telerik:RadStyleSheetManager>
   <script type="text/javascript">
        //<![CDATA[

       function post_to_url(path, params, method) {
           method = method || "post"; // Set method to post by default, if not specified.

           // The rest of this code assumes you are not using a library.
           // It can be made less wordy if you use one.
           var form = document.createElement("form");
           form.setAttribute("method", method);
           form.setAttribute("action", path);
           form.setAttribute("target", "_blank");

           for (var key in params) {
               var hiddenField = document.createElement("input");
               hiddenField.setAttribute("type", "hidden");
               hiddenField.setAttribute("name", key);
               hiddenField.setAttribute("value", params[key]);

               form.appendChild(hiddenField);
           }

           document.body.appendChild(form);    // Not entirely sure if this is necessary
           form.submit();
       }

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
            <td>
                <asp:Label ID="Label5" runat="server" Text="職稱："></asp:Label>
            </td>
            <td>
                <uc1:TreeViewComboBox ID="TreeViewComboBox1" runat="server" AllowSelectParent="False" AutoPostBack="False" Enabled="True" TreeDataFieldID="code" TreeDataFieldParentID="ParentCodeRefID" TreeDataSourceID="dsJobCode" TreeDataTextField="Name" Width="200px" />
            </td>
            <td>
                <asp:Label ID="Label10" runat="server" Text="學年度："></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbEduYearS" runat="server" Width="71px"></asp:TextBox>
                ~<asp:TextBox ID="tbEduYearE" runat="server" Width="71px"></asp:TextBox>
            </td>
            <td></td>
            <td></td>
            <td></td>
        </tr>
    <tr>
        <td>

            <asp:Label ID="Label6" runat="server" Text="實習期間："></asp:Label>

        </td>
        <td>

            <telerik:RadDatePicker ID="rdpSDate" Runat="server">
            </telerik:RadDatePicker>

        </td>
    <td>~</td>
    <td>        
        <telerik:RadDatePicker ID="rdpEDate" Runat="server">
        </telerik:RadDatePicker>
        </td>
    <td>        
        &nbsp;</td>
    <td>        
        &nbsp;</td>
    <td>
        <asp:Button ID="btnQuery" runat="server" onclick="btnQuery_Click" Text="查詢" /></td>
    </tr>
    </table>
    </asp:Panel>
    <br />
    <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" CellSpacing="0" 
    Culture="zh-TW" GridLines="None" 
        onneeddatasource="RadGrid1_NeedDataSource" 
        AllowPaging="True"
        style="margin-top: 0px" GroupLoadMode="Client" GroupsDefaultExpanded="true" OnItemDataBound="RadGrid1_ItemDataBound">
        <ClientSettings>
            <Selecting AllowRowSelect="True" />
        </ClientSettings>
<MasterTableView nomasterrecordstext="目前沒有資料" GroupLoadMode="Client"  DataKeyNames="EmpCode,IDNo,EduTermID"  >

<RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
<HeaderStyle Width="20px"></HeaderStyle>
</RowIndicatorColumn>

<ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
<HeaderStyle Width="20px"></HeaderStyle>
</ExpandCollapseColumn>
            <GroupByExpressions>

                <telerik:GridGroupByExpression>

                    <SelectFields>

                        <telerik:GridGroupByField FieldAlias="EduTermName" FieldName="EduTermName"></telerik:GridGroupByField>

                    </SelectFields>

                    <GroupByFields>

                        <telerik:GridGroupByField FieldName="EduTermName"></telerik:GridGroupByField>

                    </GroupByFields>

                </telerik:GridGroupByExpression>

            </GroupByExpressions>
    <Columns>
        <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" UniqueName="TemplateColumn">
            <ItemTemplate>
                <asp:Button ID="btniKasa" runat="server" Text="i-KASA" />
            </ItemTemplate>
        </telerik:GridTemplateColumn>
        <telerik:GridHyperLinkColumn AllowSorting="False" DataNavigateUrlFields="IDNo" DataNavigateUrlFormatString="~/iKASA/Main.aspx?iKasaIdNo={0}" DataTextField="UrlText" FilterControlAltText="Filter IDNo column" UniqueName="IDNo"  Visible="False">
        </telerik:GridHyperLinkColumn>
        <telerik:GridBoundColumn 
            FilterControlAltText="Filter EmpCode column" HeaderText="職編" 
            UniqueName="EmpCode" DataField="EmpCode">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="StudentName" FilterControlAltText="Filter StudentName column" HeaderText="姓名" UniqueName="StudentName">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="MemberCode" FilterControlAltText="Filter MemberCode column" HeaderText="學號" UniqueName="MemberCode">
        </telerik:GridBoundColumn>
    </Columns>
</MasterTableView>

        <PagerStyle FirstPageToolTip="第一頁" LastPageToolTip="最末頁" NextPageToolTip="下一頁" 
            PagerTextFormat="跳至第: {4} &amp;nbsp;頁 &lt;strong&gt;{0}&lt;/strong&gt; / &lt;strong&gt;{1}&lt;/strong&gt;, 項目 &lt;strong&gt;{2}&lt;/strong&gt; - &lt;strong&gt;{3}&lt;/strong&gt; / &lt;strong&gt;{5}&lt;/strong&gt;." 
            PageSizeLabelText="每頁筆數:" PrevPagesToolTip="上一頁" PrevPageToolTip="上一頁" />

<FilterMenu EnableImageSprites="False"></FilterMenu>
</telerik:RadGrid>
    
    <asp:ObjectDataSource ID="dsJobCode" runat="server" SelectMethod="GetCodeRefsStatic" 
        TypeName="KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService" 
        DataObjectTypeName="KMU.EduActivity.ApplicationLayer.DTO.V_CodeRefDto">
        <SelectParameters>
            <asp:Parameter DefaultValue="EduAct_JobSerial" Name="codetype" />
        </SelectParameters>
    </asp:ObjectDataSource>
    
    </asp:Content>

