<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="TeacherSetting.aspx.cs" Inherits="TeacherSetting" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register src="VsSelector.ascx" tagname="VsSelector" tagprefix="uc1" %>
<%@ Register src="TreeViewComboBox.ascx" tagname="TreeViewComboBox" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}
.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif;
            margin-top: 32;
        }.RadComboBox_Default .rcbReadOnly .rcbInputCellLeft{background-position:0 -88px}.RadComboBox_Default .rcbReadOnly .rcbInputCellLeft{background-position:0 -88px}.RadComboBox_Default .rcbReadOnly .rcbInputCellLeft{background-position:0 -88px}.RadComboBox_Default .rcbInputCellLeft{background-position:0 0}.RadComboBox_Default .rcbInputCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbInputCell{width:100%;height:20px;_height:22px;line-height:20px;_line-height:22px;text-align:left;vertical-align:middle}.RadComboBox .rcbInputCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox .rcbInputCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox .rcbInputCell{width:100%;height:20px;_height:22px;line-height:20px;_line-height:22px;text-align:left;vertical-align:middle}.RadComboBox_Default .rcbInputCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox_Default .rcbInputCellLeft{background-position:0 0}.RadComboBox .rcbInputCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox .rcbInputCell{width:100%;height:20px;_height:22px;line-height:20px;_line-height:22px;text-align:left;vertical-align:middle}.RadComboBox_Default .rcbInputCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox_Default .rcbInputCellLeft{background-position:0 0}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox_Default .rcbReadOnly .rcbArrowCellRight{background-position:-162px -176px}.RadComboBox_Default .rcbReadOnly .rcbArrowCellRight{background-position:-162px -176px}.RadComboBox_Default .rcbReadOnly .rcbArrowCellRight{background-position:-162px -176px}.RadComboBox_Default .rcbArrowCellRight{background-position:-18px -176px}.RadComboBox_Default .rcbArrowCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbArrowCell{width:18px}.RadComboBox .rcbArrowCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox .rcbArrowCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}
        .RadComboBox .rcbArrowCell{width:18px}.RadComboBox_Default .rcbArrowCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox_Default .rcbArrowCellRight{background-position:-18px -176px}.RadComboBox .rcbArrowCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox .rcbArrowCell{width:18px}.RadComboBox_Default .rcbArrowCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox_Default .rcbArrowCellRight{background-position:-18px -176px}</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server">
    </telerik:RadStyleSheetManager>
   <script type="text/javascript">
        //<![CDATA[


       function openTermWin(id) {
           var oWnd = radopen("EduTermTeacherSetting.aspx?EduTermID=" + id, "rwOpenBig");
       }

       function openMemberWin(id) {
           var oWnd = radopen("EduMemberTeacherSetting.aspx?EduTermID=" + id, "rwOpenBig");
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
    <asp:Label ID="Label3" runat="server" Text="&gt;訓練課程維護"></asp:Label>

    <asp:Panel ID="Panel1" runat="server">
    <table>
    <tr>
    <td>
        <asp:Label ID="Label10" runat="server" Text="學年度："></asp:Label>
        </td>
    <td>
        <asp:TextBox ID="tbEduYear" runat="server"></asp:TextBox>
        </td>
    <td>
        <asp:Label ID="Label4" runat="server" Text="課程代碼："></asp:Label>
        </td>
    <td>
        <asp:TextBox ID="tbEduStopCode" runat="server"></asp:TextBox>
        </td>
    <td>
        <asp:Label ID="Label8" runat="server" Text="名稱："></asp:Label>
        </td>
    <td>
        <asp:TextBox ID="tbName" runat="server"></asp:TextBox>
        </td>
    <td>
        &nbsp;</td>
    <td>
        &nbsp;</td>
    <td>
        <asp:Button ID="btnQuery" runat="server" onclick="btnQuery_Click" Text="查詢" />
        </td>
    </tr>
    <tr>
    <td>
        <asp:Label ID="Label6" runat="server" Text="訓練日期："></asp:Label>
        </td>
    <td>
        <telerik:RadDatePicker ID="rdpDateBegin" Runat="server">
        </telerik:RadDatePicker>
        </td>
    <td>
        <asp:Label ID="Label7" runat="server" Text="~"></asp:Label>
        </td>
    <td>
        <telerik:RadDatePicker ID="rdpDateEnd" Runat="server">
        </telerik:RadDatePicker>
        </td>
    <td>
        <asp:Label ID="Label9" runat="server" Text="部門："></asp:Label>
        </td>
    <td>
        <telerik:RadComboBox ID="ddlUnit" Runat="server" Filter="Contains">
        </telerik:RadComboBox>
        </td>
    <td></td>
    <td></td>
    <td></td>
    </tr>
        <tr>
            <td>
                <asp:Label ID="Label5" runat="server" Text="職稱："></asp:Label>
            </td>
            <td colspan="2">
                <uc1:TreeViewComboBox ID="TreeViewComboBox1" runat="server" AllowSelectParent="False" AutoPostBack="False" Enabled="True" TreeDataFieldID="code" TreeDataFieldParentID="ParentCodeRefID" TreeDataSourceID="dsJobCode" TreeDataTextField="Name" Width="200px" />
            </td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
        </tr>
    </table>
        <br />
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server" GroupingText="批次設定課程教師">
    <table width="97%">
    <tr>
    <td width="35%">
        <asp:Label ID="Label14" runat="server" Text="設定教師類型："></asp:Label>
        </td>
    <td width="65%">
        <asp:Label ID="Label15" runat="server" Text="選擇教師："></asp:Label>
        </td>
    </tr>
    <tr>
    <td>
        <telerik:RadComboBox ID="rcbTeacherType" Runat="server" AutoPostBack="false">
        </telerik:RadComboBox></td>
    <td><uc1:VsSelector ID="rcbVs" runat="server" /></td>
    </tr>
    <tr>
    <td>
        <asp:CheckBox ID="cbAll" runat="server" Checked="True" Text="設定所有輪訓課程" />
        </td>
    <td>
        <asp:Button ID="btnSet" runat="server" onclick="btnSet_Click" Text="批次設定老師" />
        </td>
    </tr>
    </table>
    </asp:Panel>
    <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" CellSpacing="0" 
    Culture="zh-TW" GridLines="None" 
        ondeletecommand="RadGrid1_DeleteCommand"
        
        onitemcommand="RadGrid1_ItemCommand" AllowMultiRowSelection="True" 
        style="margin-top: 0px" onitemcreated="RadGrid1_ItemCreated" 
        AutoGenerateHierarchy="True" onprerender="RadGrid1_PreRender" 
        onitemdatabound="RadGrid1_ItemDataBound" 
        ondetailtabledatabind="RadGrid1_DetailTableDataBind1" 
        onneeddatasource="RadGrid1_NeedDataSource1">
        <ClientSettings>
            <Selecting AllowRowSelect="True" />
<Selecting AllowRowSelect="True"></Selecting>
        </ClientSettings>
<MasterTableView  commanditemdisplay="Top" nomasterrecordstext="目前沒有資料" 
            NoDetailRecordsText="" EditMode="PopUp" 
            DataKeyNames="RoundCode,EduStopCode,EduTermID" 
            HierarchyDefaultExpanded="True" ClientDataKeyNames="RoundCode,EduStopCode,EduTermID"
            HierarchyLoadMode="Client"  GroupLoadMode="Client" DataSourceID="dsLv0">
    <DetailTables>
        <telerik:GridTableView AllowPaging="False" runat="server" DataKeyNames="RoundCode,EduStopCode,EduTermID" ClientDataKeyNames="RoundCode,EduStopCode,EduTermID" 
            HierarchyLoadMode="Client" Name="Child1" DataSourceID = "dsLv1" ShowHeadersWhenNoRecords="false" NoMasterRecordsText="" 
            NoDetailRecordsText=""  GroupLoadMode="Client" GroupsDefaultExpanded="false">
            

            <GroupByExpressions>

                <telerik:GridGroupByExpression>

                    <SelectFields>

                        <telerik:GridGroupByField FieldAlias="UnitStr" FieldName="UnitStr"></telerik:GridGroupByField>

                    </SelectFields>

                    <GroupByFields>

                        <telerik:GridGroupByField FieldName="UnitStr"></telerik:GridGroupByField>

                    </GroupByFields>

                </telerik:GridGroupByExpression>

            </GroupByExpressions>
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
            UniqueName="DateFromToStr" ReadOnly="True">
        </telerik:GridBoundColumn>
        <telerik:GridDateTimeColumn DataField="DateFrom" 
            FilterControlAltText="Filter DateFrom column" HeaderText="訓練開始日期" 
            UniqueName="DateFrom" Visible="False">
        </telerik:GridDateTimeColumn>
        <telerik:GridDateTimeColumn DataField="DateTo" 
            FilterControlAltText="Filter DateTo column" HeaderText="訓練結束日期" UniqueName="DateTo" 
            Visible="False">
        </telerik:GridDateTimeColumn>
        <telerik:GridBoundColumn DataField="UnitStr" 
            FilterControlAltText="Filter UnitStr column" HeaderText="單位" 
            UniqueName="UnitStr">
        </telerik:GridBoundColumn>
        <telerik:GridNumericColumn DataField="Capacity" DecimalDigits="2" 
            FilterControlAltText="Filter Capacity column" HeaderText="訓練人數" 
            UniqueName="Capacity">
        </telerik:GridNumericColumn>
<telerik:GridBoundColumn DataField="Status" HeaderText="狀態" UniqueName="Status" 
            FilterControlAltText="Filter Status column"></telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="Des" 
            FilterControlAltText="Filter Des column" HeaderText="備註" UniqueName="Des">
        </telerik:GridBoundColumn>
        <telerik:GridTemplateColumn Visible="false"
            FilterControlAltText="Filter EduTeamStopID column" 
            UniqueName="TermTeacherSetting">
            <ItemTemplate>
                <asp:LinkButton ID="lbtnTermTeacherSetting" runat="server"  Text="課程老師設定"></asp:LinkButton>            
            </ItemTemplate>
        </telerik:GridTemplateColumn>
        <telerik:GridTemplateColumn 
            FilterControlAltText="Filter EduTeamStopID column" 
            UniqueName="MemberTeacherSetting">
            <ItemTemplate>
                <asp:LinkButton ID="lbtnMemberTeacherSetting" runat="server"  Text="學員老師設定"></asp:LinkButton>            
            </ItemTemplate>
        </telerik:GridTemplateColumn>

    </Columns>

            <DetailTables>
                <telerik:GridTableView AllowPaging="False" runat="server" HierarchyLoadMode="Client" NoMasterRecordsText="" NoDetailRecordsText=""  ShowHeadersWhenNoRecords="false" DataSourceID="dsLv2" Name="Child2" DataKeyNames="RoundCode,EduStopCode,EduTermID" ClientDataKeyNames="RoundCode,EduStopCode,EduTermID">
                    <CommandItemSettings ExportToPdfText="Export to PDF" />
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
            UniqueName="DateFromToStr" ReadOnly="True">
        </telerik:GridBoundColumn>
        <telerik:GridDateTimeColumn DataField="DateFrom" 
            FilterControlAltText="Filter DateFrom column" HeaderText="訓練開始日期" 
            UniqueName="DateFrom" Visible="False">
        </telerik:GridDateTimeColumn>
        <telerik:GridDateTimeColumn DataField="DateTo" 
            FilterControlAltText="Filter DateTo column" HeaderText="訓練結束日期" UniqueName="DateTo" 
            Visible="False">
        </telerik:GridDateTimeColumn>
        <telerik:GridBoundColumn DataField="UnitStr" 
            FilterControlAltText="Filter UnitStr column" HeaderText="單位" 
            UniqueName="UnitStr">
        </telerik:GridBoundColumn>
        <telerik:GridNumericColumn DataField="Capacity" DecimalDigits="2" 
            FilterControlAltText="Filter Capacity column" HeaderText="訓練人數" 
            UniqueName="Capacity">
        </telerik:GridNumericColumn>
<telerik:GridBoundColumn DataField="Status" HeaderText="狀態" UniqueName="Status" 
            FilterControlAltText="Filter Status column"></telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="Des" 
            FilterControlAltText="Filter Des column" HeaderText="備註" UniqueName="Des">
        </telerik:GridBoundColumn>
        <telerik:GridTemplateColumn Visible="false"
            FilterControlAltText="Filter EduTeamStopID column" 
            UniqueName="TermTeacherSetting">
            <ItemTemplate>
                <asp:LinkButton ID="lbtnTermTeacherSetting" runat="server"  Text="課程老師設定"></asp:LinkButton>            
            </ItemTemplate>
        </telerik:GridTemplateColumn>
        <telerik:GridTemplateColumn 
            FilterControlAltText="Filter EduTeamStopID column" 
            UniqueName="MemberTeacherSetting">
            <ItemTemplate>
                <asp:LinkButton ID="lbtnMemberTeacherSetting" runat="server"  Text="學員老師設定"></asp:LinkButton>            
            </ItemTemplate>
        </telerik:GridTemplateColumn>

    </Columns>

                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" 
                        Visible="True">
                        <HeaderStyle Width="20px" />
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" 
                        Visible="True">
                        <HeaderStyle Width="20px" />
                    </ExpandCollapseColumn>
                    <EditFormSettings>
                        <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                        </EditColumn>
                    </EditFormSettings>
            <ParentTableRelation>
                <telerik:GridRelationFields DetailKeyField="ParentEduTermID" 
                    MasterKeyField="EduTermID" />
            </ParentTableRelation>
                </telerik:GridTableView>
            </DetailTables>
                    <ParentTableRelation>
                        <telerik:GridRelationFields DetailKeyField="ParentEduTermID" 
                            MasterKeyField="EduTermID" />
                    </ParentTableRelation>
            <CommandItemSettings ExportToPdfText="Export to PDF" />
            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" 
                Visible="True">
                <HeaderStyle Width="20px" />
            </RowIndicatorColumn>
            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" 
                Visible="True">
                <HeaderStyle Width="20px" />
            </ExpandCollapseColumn>
            <EditFormSettings>
                <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                </EditColumn>
            </EditFormSettings>
        </telerik:GridTableView>
    </DetailTables>
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
        <telerik:GridBoundColumn DataField="EduStopCode" 
            FilterControlAltText="Filter EduStopCode column" HeaderText="課程代碼" 
            UniqueName="EduStopCode">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="Name" 
            FilterControlAltText="Filter Name column" HeaderText="名稱" UniqueName="Name">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="DateFromToStr" 
            FilterControlAltText="Filter EduTeamCode column" HeaderText="訓練起訖日期" 
            UniqueName="DateFromToStr" ReadOnly="True">
        </telerik:GridBoundColumn>
        <telerik:GridDateTimeColumn DataField="DateFrom" 
            FilterControlAltText="Filter DateFrom column" HeaderText="訓練開始日期" 
            UniqueName="DateFrom" Visible="False">
        </telerik:GridDateTimeColumn>
        <telerik:GridDateTimeColumn DataField="DateTo" 
            FilterControlAltText="Filter DateTo column" HeaderText="訓練結束日期" UniqueName="DateTo" 
            Visible="False">
        </telerik:GridDateTimeColumn>
        <telerik:GridBoundColumn DataField="UnitStr" 
            FilterControlAltText="Filter UnitStr column" HeaderText="單位" 
            UniqueName="UnitStr">
        </telerik:GridBoundColumn>
        <telerik:GridNumericColumn DataField="Capacity" DecimalDigits="2" 
            FilterControlAltText="Filter Capacity column" HeaderText="訓練人數" 
            UniqueName="Capacity">
        </telerik:GridNumericColumn>
<telerik:GridBoundColumn DataField="Status" HeaderText="狀態" UniqueName="Status" 
            FilterControlAltText="Filter Status column"></telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="Des" 
            FilterControlAltText="Filter Des column" HeaderText="備註" UniqueName="Des">
        </telerik:GridBoundColumn>
        <telerik:GridTemplateColumn Visible="false"
            FilterControlAltText="Filter EduTeamStopID column" 
            UniqueName="TermTeacherSetting">
            <ItemTemplate>
                <asp:LinkButton ID="lbtnTermTeacherSetting" runat="server"  Text="課程老師設定"></asp:LinkButton>            
            </ItemTemplate>
        </telerik:GridTemplateColumn>
        <telerik:GridTemplateColumn 
            FilterControlAltText="Filter EduTeamStopID column" 
            UniqueName="MemberTeacherSetting">
            <ItemTemplate>
                <asp:LinkButton ID="lbtnMemberTeacherSetting" runat="server"  Text="設定個別學員老師"></asp:LinkButton>            
            </ItemTemplate>
        </telerik:GridTemplateColumn>

    </Columns>

<CommandItemTemplate>

</CommandItemTemplate>        
<EditFormSettings>
<EditColumn FilterControlAltText="Filter EditCommandColumn column" canceltext="取消" 
        edittext="儲存" inserttext="儲存" updatetext="儲存"></EditColumn>
    <PopUpSettings Modal="True" ScrollBars="Auto" Width="600px" />

<PopUpSettings ScrollBars="Auto" Modal="True" Width="600px"></PopUpSettings>
</EditFormSettings>
</MasterTableView>

        <PagerStyle FirstPageToolTip="第一頁" LastPageToolTip="最末頁" NextPageToolTip="下一頁" 
            PagerTextFormat="跳至第: {4} &amp;nbsp;頁 &lt;strong&gt;{0}&lt;/strong&gt; / &lt;strong&gt;{1}&lt;/strong&gt;, 項目 &lt;strong&gt;{2}&lt;/strong&gt; - &lt;strong&gt;{3}&lt;/strong&gt; / &lt;strong&gt;{5}&lt;/strong&gt;." 
            PageSizeLabelText="每頁筆數:" PrevPagesToolTip="上一頁" PrevPageToolTip="上一頁" />

<FilterMenu EnableImageSprites="False"></FilterMenu>
</telerik:RadGrid>
    <asp:ObjectDataSource ID="dsTermCode" runat="server" SelectMethod="GetEduTeams" 
        TypeName="KMU.EduActivity.ApplicationLayer.DTO.EduTermCodeDto">
    </asp:ObjectDataSource>
    
    <asp:ObjectDataSource ID="dsLv0" runat="server" SelectMethod="GetEduTermsLv0" 
        TypeName="KMU.EduActivity.ApplicationLayer.DTO.EduTermDto" 
        onselecting="dsLv0_Selecting">
    </asp:ObjectDataSource>
    
    <asp:ObjectDataSource ID="dsJobCode" runat="server" SelectMethod="GetCodeRefsStatic" 
        TypeName="KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService" 
        DataObjectTypeName="KMU.EduActivity.ApplicationLayer.DTO.V_CodeRefDto">
        <SelectParameters>
            <asp:Parameter DefaultValue="EduAct_JobSerial" Name="codetype" />
        </SelectParameters>
    </asp:ObjectDataSource>
    
    <asp:ObjectDataSource ID="dsLv2" runat="server" SelectMethod="GetEduTermsLv1" 
        TypeName="KMU.EduActivity.ApplicationLayer.DTO.EduTermDto">
        <SelectParameters>
            <asp:Parameter Name="ParentEduTermID" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="dsLv1" runat="server" SelectMethod="GetEduTermsLv1" 
        TypeName="KMU.EduActivity.ApplicationLayer.DTO.EduTermDto">
        <SelectParameters>
            <asp:Parameter Name="ParentEduTermID" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsVs" runat="server" 
        DataObjectTypeName="KMU.EduActivity.ApplicationLayer.DTO.SelectKmuVsDto" 
        SelectMethod="GetKmuVsWithEmpty" 
        TypeName="KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService" 
        onselecting="odsVs_Selecting">
    </asp:ObjectDataSource>
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server" Modal="True" 
        onclientclose="OnClientClose" ShowContentDuringLoad="False" 
        VisibleStatusbar="False">
        <Windows>
            <telerik:RadWindow ID="rwOpen" runat="server" Width="500" Height="380px" 
                style="display:none; z-index: 1000000;" ReloadOnShow="True">
            </telerik:RadWindow>
            <telerik:RadWindow ID="rwOpenBig" runat="server" Modal="True" Width="950px" Height = "600"
                style="display:none; z-index: 1000000;" ReloadOnShow="True">
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
    <br />
    <asp:Label ID="lblMsg" runat="server"></asp:Label>
</asp:Content>

