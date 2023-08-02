<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeFile="EditHtmlForm.aspx.cs" Inherits="_Default" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css">
<script src="//code.jquery.com/jquery-1.10.2.js"></script>
<script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
<script>
    $(function () { $("#adv").accordion({ collapsible: true, active: false }); });
</script>  
<script type="text/javascript">
    function ElementClick(btn, id,hiddenid,postback) {
        var lbtn = document.getElementById(btn);
        if (lbtn != null) {
            theform = document.forms["form1"];
            var hidden = document.getElementById(hiddenid);
            hidden.value = id;

            if(postback)
            {
            lbtn.click();
            }
        }
    }

    function getSelectControls(btn,hiddennameid,hiddenidid) {
        
        var ids = "";
        var names = "";
        var selection = window.getSelection();
        
        var controls = document.getElementsByTagName("input");
        for (var i = 0; i < controls.length ; i++) {
            if (selection.containsNode(controls[i], true)) {
                ids = ids + controls[i].id + ",";
                names = names + controls[i].name + ",";
            }
        }
        var hiddenname = document.getElementById(hiddennameid);
        var hiddenid = document.getElementById(hiddenidid);
        hiddenname.value = names;
        hiddenid.value = ids;

        var lbtn = document.getElementById(btn);
        lbtn.click();
    }

</script>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="Panel1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="btnSaveTemplateSetting" />
                    <telerik:AjaxUpdatedControl ControlID="btnSaveTemplatePermission" />
                    <telerik:AjaxUpdatedControl ControlID="Label1" />
                    <telerik:AjaxUpdatedControl ControlID="lblID" />
                    <telerik:AjaxUpdatedControl ControlID="Label2" />
                    <telerik:AjaxUpdatedControl ControlID="tbName" />
                    <telerik:AjaxUpdatedControl ControlID="lblControl" />
                    <telerik:AjaxUpdatedControl ControlID="tbScore" />
                    <telerik:AjaxUpdatedControl ControlID="tbMaxScore" />
                    <telerik:AjaxUpdatedControl ControlID="lblControl0" />
                    <telerik:AjaxUpdatedControl ControlID="tbDisplayName" />
                    <telerik:AjaxUpdatedControl ControlID="cbHide" />
                    <telerik:AjaxUpdatedControl ControlID="tbBindValue" />
                    <telerik:AjaxUpdatedControl ControlID="tbPage1SelectedNames" />
                    <telerik:AjaxUpdatedControl ControlID="btnAddNecessary" />
                    <telerik:AjaxUpdatedControl ControlID="btnRemoveNecessary" />
                    <telerik:AjaxUpdatedControl ControlID="lbNecessary" />
                    <telerik:AjaxUpdatedControl ControlID="btnSetScore" />
                    <telerik:AjaxUpdatedControl ControlID="tbMinTextCount" />
                    <telerik:AjaxUpdatedControl ControlID="tbMaxTextCount" />
                    <telerik:AjaxUpdatedControl ControlID="Label3" />
                    <telerik:AjaxUpdatedControl ControlID="tbExpName" UpdatePanelCssClass="" />
                    <telerik:AjaxUpdatedControl ControlID="Label4" UpdatePanelCssClass="" />
                    <telerik:AjaxUpdatedControl ControlID="tbExpression" />
                    <telerik:AjaxUpdatedControl ControlID="Label5" />
                    <telerik:AjaxUpdatedControl ControlID="tbExpExecuteOrder" />
                    <telerik:AjaxUpdatedControl ControlID="Panel3" />
                    <telerik:AjaxUpdatedControl ControlID="rgExpressions" />
                    <telerik:AjaxUpdatedControl ControlID="rgGroup" UpdatePanelCssClass="" />
                    <telerik:AjaxUpdatedControl ControlID="Label7" UpdatePanelCssClass="" />
                    <telerik:AjaxUpdatedControl ControlID="lbControls" UpdatePanelCssClass="" />
                    <telerik:AjaxUpdatedControl ControlID="Panel2" UpdatePanelCssClass="" />
                    <telerik:AjaxUpdatedControl ControlID="Label8" UpdatePanelCssClass="" />
                    <telerik:AjaxUpdatedControl ControlID="tbSingle" />
                    <telerik:AjaxUpdatedControl ControlID="btnAddSingle" UpdatePanelCssClass="" />
                    <telerik:AjaxUpdatedControl ControlID="btnRemoveSingle" UpdatePanelCssClass="" />
                    <telerik:AjaxUpdatedControl ControlID="lbSingleSetting" />
                    <telerik:AjaxUpdatedControl ControlID="lbtnPostBack" />
                    <telerik:AjaxUpdatedControl ControlID="HiddenID" UpdatePanelCssClass="" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadTabStrip ID="RadTabStrip1" runat="server" MultiPageID="RadMultiPage1" 
            SelectedIndex="0" Skin="WebBlue">
        <Tabs>
            <telerik:RadTab runat="server" PageViewID="RadPageView1" Selected="True" 
                Text="編輯選項">
            </telerik:RadTab>
            <telerik:RadTab runat="server" PageViewID="RadPageView2" Text="編輯公式">
            </telerik:RadTab>
            <telerik:RadTab runat="server" Text="設定統計群組" PageViewID="RadPageView3">
            </telerik:RadTab>
            <telerik:RadTab runat="server" PageViewID="RadPageView4" Text="設定單選">
            </telerik:RadTab>
        </Tabs>
    </telerik:RadTabStrip>
    <telerik:RadMultiPage ID="RadMultiPage1" Runat="server" BorderColor="Black" 
            BorderStyle="Solid" BorderWidth="1px" SelectedIndex="0" Width="90%">
        <telerik:RadPageView ID="RadPageView1" runat="server" Selected="True">
        <table width="100%">
            <tr>
                <td colspan="3" >
                    <asp:Panel ID="Panel5" runat="server" GroupingText="表單設定">
                    <asp:CheckBox ID="cbUserDefine" runat="server" Text="此表單為自訂角色表單" />
                    <asp:CheckBox ID="cbNeedPass" runat="server" Text="此表單需指定是否通過" />
                    <asp:CheckBox ID="cbAllowTakeBack" runat="server" Text="送出後可收回" />
                    <asp:CheckBox ID="cbAllowReturn" runat="server" Text="填寫者可退回上階" />
                    <asp:CheckBox ID="cbDisplayToEvaltarget" runat="server" Text="此表單內容可完整顯示給評估對象查閱" />
                    <br />
                    <asp:CheckBox ID="cbChoiceTeacher" runat="server" Text="此表單可由上一位填寫者自選老師" />
                    <asp:CheckBox ID="cbQueryEvalTarget" runat="server" Text="填寫者可查看考核對象歷程" />
                    <br />
                    <asp:Button ID="btnSaveTemplateSetting" runat="server" OnClick="btnSaveTemplateSetting_Click" Text="儲存" />
                        </asp:Panel>
                </td>
            </tr>
            <tr>
                <td colspan="3">

                    <asp:Panel ID="Panel4" runat="server" GroupingText="可使用院區">
                        <asp:CheckBoxList ID="cblPermissionHosp" runat="server" RepeatDirection="Horizontal">
                        </asp:CheckBoxList>
                        <asp:Button ID="btnSaveTemplatePermission" runat="server" Text="儲存" OnClick="btnSaveTemplatePermission_Click" />
                    </asp:Panel>

                </td>
            </tr>
        <tr>
        <td>
            <table>
    <tr>
    <td><asp:Label ID="Label1" runat="server" Text="ID："></asp:Label></td>
    <td><asp:Label ID="lblID" runat="server"></asp:Label></td>
    </tr>
    <tr>
    <td><asp:Label ID="Label2" runat="server" Text="Name："></asp:Label></td>
    <td><asp:TextBox ID="tbName" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
    <td><asp:Label ID="lblControl" runat="server" Text="分數："></asp:Label></td>
    <td>    <telerik:RadNumericTextBox ID="tbScore" Runat="server" Width="60px">
<NumberFormat ZeroPattern="n" decimaldigits="0"></NumberFormat>
    </telerik:RadNumericTextBox></td>
    </tr>
    <tr>
    <td><asp:Label ID="Label6" runat="server" Text="分數上限："></asp:Label></td>
    <td>    <telerik:RadNumericTextBox ID="tbMaxScore" Runat="server" Width="60px">
<NumberFormat ZeroPattern="n" decimaldigits="0"></NumberFormat>
    </telerik:RadNumericTextBox></td>
    </tr>
    <tr>
    <td>
        <asp:Label ID="lblControl0" runat="server" Text="顯示名稱："></asp:Label>
        </td>
    <td>
        <asp:TextBox ID="tbDisplayName" runat="server"></asp:TextBox>
        </td>
    </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblControl1" runat="server" Text="隱藏欄位："></asp:Label>
                    </td>
                    <td>
                        <asp:CheckBox ID="cbHide" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label9" runat="server" Text="綁定值："></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="tbBindValue" runat="server"></asp:TextBox>
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/docs/綁定值對照表.xlsx">綁定值對照表</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label10" runat="server" Text="選取值："></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="tbPage1SelectedNames" runat="server"></asp:TextBox>
                    </td>
                </tr>
    <tr>
    <td>    
        <asp:Label ID="Label13" runat="server" Text="最少字數："></asp:Label>
        </td>
    <td>
        <telerik:RadNumericTextBox ID="tbMinTextCount" Runat="server" MinValue="0" Width="60px">
            <NumberFormat decimaldigits="0" ZeroPattern="n" />
        </telerik:RadNumericTextBox>
        </td>
    </tr>

    <tr>
    <td>    
        <asp:Label ID="Label14" runat="server" Text="最多字數："></asp:Label>
        </td>
    <td>
        <telerik:RadNumericTextBox ID="tbMaxTextCount" Runat="server" MinValue="0" Width="60px">
            <NumberFormat decimaldigits="0" ZeroPattern="n" />
        </telerik:RadNumericTextBox>
        </td>
    </tr>


    <tr>
    <td>    
        &nbsp;</td>
    <td>
        &nbsp;</td>
    </tr>
    </table>   
        </td>
        <td>
        <table>
        <tr><td>
            <asp:Button ID="btnAddNecessary" runat="server" onclick="btnAddNecessary_Click" 
                Text="加入必填" />
            </td></tr>
        <tr><td>
            <asp:Button ID="btnRemoveNecessary" runat="server" 
                onclick="btnRemoveNecessary_Click" Text="移除必填" />
            </td></tr>
        </table>
        </td>
        <td>
            <asp:ListBox ID="lbNecessary" runat="server" DataTextField="name" 
                DataValueField="name" Height="150px" Width="150px"></asp:ListBox>
            </td>
        </tr>
            <tr>
                    <td colspan="3"> 
    <div id="adv">
        <h3><asp:Label ID="Label12" runat="server" Font-Bold="True" Font-Size="Medium" Text="編輯內容"></asp:Label></h3>
        <div>
            <asp:Button ID="btnSaveContent" runat="server" OnClick="btnSaveContent_Click" Text="儲存內容" />
            <telerik:RadEditor ID="reContent" Runat="server" Width="100%" ContentFilters="None">
                <CssFiles>
                    <telerik:EditorCssFile Value="" />
                </CssFiles>
                <Content>
</Content>
                <TrackChangesSettings CanAcceptTrackChanges="False" />
            </telerik:RadEditor>
        </div>

    </div>

                    </td>
                </tr>
            <tr>
                <td colspan="3">

                    <asp:Button ID="btnSetScore" runat="server" Enabled="false" onclick="btnSetScore_Click" Text="儲存" />

                </td>
            </tr>   
        </table>
         
        </telerik:RadPageView>
        <telerik:RadPageView ID="RadPageView2" runat="server" Width="100%">
        <table>
        <tr>
        <td><asp:Label ID="Label3" runat="server" Text="公式名稱："></asp:Label></td>
        <td><asp:TextBox ID="tbExpName" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
        <td><asp:Label ID="Label4" runat="server" Text="公式："></asp:Label></td>
        <td>
            <telerik:RadTextBox ID="tbExpression" Runat="server" Height="82px" Rows="10" 
                SelectionOnFocus="CaretToEnd" TextMode="MultiLine" Width="480px">
            </telerik:RadTextBox>
            </td>
        </tr>
        <tr>
        <td><asp:Label ID="Label5" runat="server" Text="執行順序"></asp:Label></td>
        <td><telerik:RadNumericTextBox ID="tbExpExecuteOrder" Runat="server" Width="60px">
            <NegativeStyle Resize="None" />
            <NumberFormat DecimalDigits="0" ZeroPattern="n" />
            <EmptyMessageStyle Resize="None" />
            <ReadOnlyStyle Resize="None" />
            <FocusedStyle Resize="None" />
            <DisabledStyle Resize="None" />
            <InvalidStyle Resize="None" />
            <HoveredStyle Resize="None" />
            <EnabledStyle Resize="None" />
            </telerik:RadNumericTextBox></td>
        </tr>
        <tr>
        <td>&nbsp;</td>
        <td>

            <asp:Panel ID="Panel3" runat="server">
            <asp:Button ID="btnAddExp" runat="server" onclick="btnAddExp_Click" Text="新增" />
            &nbsp;&nbsp;
            <asp:Button ID="btnEditExp" runat="server" onclick="btnEditExp_Click" 
                Text="修改" />
            &nbsp;&nbsp;
            <asp:Button ID="btnDelExp" runat="server" onclick="btnDelExp_Click" Text="刪除" />
            </asp:Panel>
            </td>
        </tr>    
             
        </table>

            <telerik:RadGrid ID="rgExpressions" runat="server" AutoGenerateColumns="False" 
                CellSpacing="0" Culture="zh-TW" GridLines="None" 
                onitemcommand="rgExpressions_ItemCommand" 
                onneeddatasource="rgExpressions_NeedDataSource">
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
                <ClientSettings EnablePostBackOnRowClick="True">
                    <Selecting AllowRowSelect="True" />
                </ClientSettings>
                <MasterTableView TableLayout="Fixed">
                    <CommandItemSettings ExportToPdfText="Export to PDF" />
                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                        <HeaderStyle Width="20px" />
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" 
                        Visible="True">
                        <HeaderStyle Width="20px" />
                    </ExpandCollapseColumn>
                    <Columns>
                        <telerik:GridBoundColumn DataField="TEMPLATE_EXPRESSION_NAME" 
                            FilterControlAltText="Filter TEMPLATE_EXPRESSION_NAME column" HeaderText="公式名稱" 
                            UniqueName="TEMPLATE_EXPRESSION_NAME">
                            <HeaderStyle Width="120px" />
                            <ItemStyle Width="120px" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="EXPRESSION" 
                            FilterControlAltText="Filter EXPRESSION column" HeaderText="公式" 
                            UniqueName="EXPRESSION">
                            <HeaderStyle Wrap="True" />
                            <ItemStyle Wrap="False" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="EXECUTE_ORDER" 
                            FilterControlAltText="Filter EXECUTE_ORDER column" HeaderText="執行順序" 
                            UniqueName="EXECUTE_ORDER">
                            <HeaderStyle Width="70px" />
                            <ItemStyle Width="70px" />
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
            </telerik:RadGrid>

        </telerik:RadPageView>
        <telerik:RadPageView ID="RadPageView3" runat="server">
    <table>
    <tr>
    <td colspan="2">
    <asp:Panel ID="panGroup" runat="server" ScrollBars="Auto" Height="300px">
        <telerik:RadGrid ID="rgGroup" runat="server" AutoGenerateColumns="False" 
            AutoGenerateDeleteColumn="True" AutoGenerateEditColumn="True" CellSpacing="0" 
            Culture="zh-TW" GridLines="None" onitemcommand="rgGroup_ItemCommand" 
            onneeddatasource="rgGroup_NeedDataSource" 
            oninsertcommand="rgGroup_InsertCommand" onupdatecommand="rgGroup_UpdateCommand" OnDeleteCommand="rgGroup_DeleteCommand">
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
            <ClientSettings EnablePostBackOnRowClick="True">
                <Selecting AllowRowSelect="True" />
            </ClientSettings>
            <MasterTableView TableLayout="Fixed" commanditemdisplay="Top" >
                <CommandItemSettings ExportToPdfText="Export to PDF" />
                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                    <HeaderStyle Width="20px" />
                </RowIndicatorColumn>
                <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" 
                    Visible="True">
                    <HeaderStyle Width="20px" />
                </ExpandCollapseColumn>
                <Columns>
                    <telerik:GridBoundColumn DataField="GROUP_NAME" 
                        FilterControlAltText="Filter TEMPLATE_EXPRESSION_NAME column" HeaderText="群組名稱" 
                        UniqueName="GROUP_NAME">
                        <HeaderStyle Width="120px" />
                        <ItemStyle Width="120px" />
                    </telerik:GridBoundColumn>
                    <telerik:GridNumericColumn DataField="DISPLAY_ORDER" DecimalDigits="0" 
                        FilterControlAltText="Filter DISPLAY_ORDER column" HeaderText="顯示順序" 
                        UniqueName="DISPLAY_ORDER">
                    </telerik:GridNumericColumn>
                    <telerik:GridCheckBoxColumn DataField="to_evaltarget" DataType="System.Boolean" FilterControlAltText="Filter to_evaltarget column" HeaderText="顯示回饋內容" UniqueName="to_evaltarget">
                    </telerik:GridCheckBoxColumn>
                </Columns>
                <EditFormSettings>
<EditColumn FilterControlAltText="Filter EditCommandColumn column" canceltext="取消" 
        edittext="儲存" inserttext="儲存" updatetext="儲存"></EditColumn>
                </EditFormSettings>
<CommandItemTemplate>
    <asp:LinkButton ID="lbtnInsert" runat="server" CommandName="InitInsert" Visible='<%# !rgGroup.MasterTableView.IsItemInserted %>'><img style="border:0px" alt="" src="../Images/add.jpg" /> 新增</asp:LinkButton>
</CommandItemTemplate>  
                <BatchEditingSettings EditType="Cell" />
                <PagerStyle PageSizeControlType="RadComboBox" />
            </MasterTableView>
            <PagerStyle PageSizeControlType="RadComboBox" />
        </telerik:RadGrid>
    </asp:Panel>
    </td>
    </tr>
    <tr>
    <td><asp:Label ID="Label7" runat="server" Text="群組項目："></asp:Label></td>
    <td>
        <asp:ListBox ID="lbControls" runat="server" Height="51px" Width="255px" 
            AutoPostBack="True">
        </asp:ListBox>
        </td>
    </tr>
    <tr>
    <td colspan="2">

    
        <asp:Panel ID="Panel2" runat="server">    
        <asp:Button ID="btnDeleteGroup" runat="server" onclick="btnDeleteGroup_Click" 
            Text="刪除" />
    
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnSaveGroup" runat="server" onclick="btnSaveGroup_Click" 
            Text="儲存" />
        </asp:Panel>
    
    </td>
    </tr>
    </table>   
        </telerik:RadPageView>
        <telerik:RadPageView ID="RadPageView4" runat="server">
            <table>
                <tr>
                    <td>

                        <asp:Label ID="Label8" runat="server" Text="選取內容:"></asp:Label>
                        <br />
                        <asp:TextBox ID="tbSingle" runat="server" Width="284px"></asp:TextBox>

                    </td>
                    <td>

                        <asp:Button ID="btnAddSingle" runat="server" OnClick="btnAddSingle_Click" Text="加入" />
                        <br />
                        <asp:Button ID="btnRemoveSingle" runat="server" OnClick="btnRemoveSingle_Click" Text="移除" />
                    </td>
                    <td>

                        <asp:ListBox ID="lbSingleSetting" runat="server" DataTextField="IDs" DataValueField="IDs" Height="112px" Width="345px"></asp:ListBox>

                    </td>
                </tr>
                <tr>
                    <td colspan="3">

                        &nbsp;</td>
                </tr>
            </table>
        </telerik:RadPageView>
    </telerik:RadMultiPage>
    <div>
        <asp:LinkButton ID="lbtnSelectionPostBack" Text ="範圍選取" runat="server"></asp:LinkButton>
    </div>
    <asp:Panel ID="Panel1" runat="server" Height="300" ScrollBars="Auto" Width="90%">

    <div id="htmlContent" runat="server">
    </div>
    </asp:Panel>

    <br />

    &nbsp;
        <!--
    <input type="button" id="cancel" value="取消" name="cancel" onclick="location.href='HtmlAgilityAdmin.aspx';"/>
    -->

    <asp:LinkButton ID="lbtnPostBack" runat="server" onclick="lbtnPostBack_Click"></asp:LinkButton>

    


    <input id="HiddenID" runat="server" type="hidden" />
   
    <input id="HiddenName" runat="server" type="hidden" />

    <input id="HiddenType" runat="server" type="hidden" />

    <input id="HiddenDisplayname" runat="server" type="hidden" />
    
    <input id="HiddenScore" runat="server" type="hidden" />
    

</asp:Content>

<%--
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server" method="post" onkeydown="if ((event.which && event.which == 13) || (event.keyCode && event.keyCode == 13)){return false;};">
</form>
    
</body>
</html>
--%>