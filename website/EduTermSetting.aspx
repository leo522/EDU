<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="EduTermSetting.aspx.cs" Inherits="EduTermSetting" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register src="TreeViewComboBox.ascx" tagname="TreeViewComboBox" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;zoom:1;display:-moz-inline-stack;display:inline-block;display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default .rcbReadOnly .rcbInputCellLeft{background-position:0 -88px}.RadComboBox_Default .rcbReadOnly .rcbInputCellLeft{background-position:0 -88px}.RadComboBox_Default .rcbReadOnly .rcbInputCellLeft{background-position:0 -88px}.RadComboBox_Default .rcbReadOnly .rcbInputCellLeft{background-position:0 -88px}.RadComboBox_Default .rcbInputCellLeft{background-position:0 0}.RadComboBox_Default .rcbInputCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbInputCell{width:100%;height:20px;_height:22px;line-height:20px;_line-height:22px;text-align:left;vertical-align:middle}.RadComboBox .rcbInputCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbInputCellLeft{background-position:0 0}.RadComboBox_Default .rcbInputCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbInputCell{width:100%;height:20px;_height:22px;line-height:20px;_line-height:22px;text-align:left;vertical-align:middle}.RadComboBox .rcbInputCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbInputCellLeft{background-position:0 0}.RadComboBox_Default .rcbInputCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbInputCell{width:100%;height:20px;_height:22px;line-height:20px;_line-height:22px;text-align:left;vertical-align:middle}.RadComboBox .rcbInputCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbInputCellLeft{background-position:0 0}.RadComboBox_Default .rcbInputCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbInputCell{width:100%;height:20px;_height:22px;line-height:20px;_line-height:22px;text-align:left;vertical-align:middle}.RadComboBox .rcbInputCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbReadOnly .rcbArrowCellRight{background-position:-162px -176px}.RadComboBox_Default .rcbReadOnly .rcbArrowCellRight{background-position:-162px -176px}.RadComboBox_Default .rcbReadOnly .rcbArrowCellRight{background-position:-162px -176px}.RadComboBox_Default .rcbReadOnly .rcbArrowCellRight{background-position:-162px -176px}.RadComboBox_Default .rcbArrowCellRight{background-position:-18px -176px}.RadComboBox_Default .rcbArrowCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbArrowCell{width:18px}.RadComboBox .rcbArrowCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbArrowCellRight{background-position:-18px -176px}.RadComboBox_Default .rcbArrowCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbArrowCell{width:18px}.RadComboBox .rcbArrowCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbArrowCellRight{background-position:-18px -176px}.RadComboBox_Default .rcbArrowCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbArrowCell{width:18px}.RadComboBox .rcbArrowCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbArrowCellRight{background-position:-18px -176px}.RadComboBox_Default .rcbArrowCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbArrowCell{width:18px}.RadComboBox .rcbArrowCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <asp:Panel ID="Panel1" runat="server" DefaultButton="btnQuery">
    <table>
    <tr>
    <td align="right">

        <asp:Label ID="Label10" runat="server" Text="學年度："></asp:Label>
        </td>
    <td>
        <asp:TextBox ID="tbEduYear" runat="server"></asp:TextBox>
        </td>
    <td></td>
    <td align="right">
        <asp:Label ID="Label4" runat="server" Text="課程代碼："></asp:Label>
        </td>
    <td>
        <asp:TextBox ID="tbEduStopCode" runat="server"></asp:TextBox>
        </td>
    <td></td>
    <td>
        <asp:Label ID="Label8" runat="server" Text="名稱："></asp:Label>
        </td>
    <td>
        <asp:TextBox ID="tbName" runat="server"></asp:TextBox>
        </td>
    <td></td>
    <td>
        &nbsp;</td>
    <td>
        &nbsp;</td>
    <td></td>
    </tr>
    <tr>
    <td align="right">
        <asp:Label ID="Label5" runat="server" Text="職稱："></asp:Label>
        </td>
    <td colspan="3">
        
        <uc1:TreeViewComboBox ID="TreeViewComboBox1" runat="server" 
            AllowSelectParent="False" AutoPostBack="False" Enabled="True" 
            TreeDataFieldID="code" TreeDataFieldParentID="ParentCodeRefID" 
            TreeDataSourceID="dsJobCode" TreeDataTextField="Name" Width="200px" />
        
        </td>

    <td>
        
        </td>
    <td></td>
    <td>
        
        <asp:Label ID="Label9" runat="server" Text="部門："></asp:Label>
        
        </td>
    <td>
        
        <telerik:RadComboBox ID="ddlUnit" Runat="server" Filter="Contains">
        </telerik:RadComboBox>
        
        </td>
    <td></td>
    <td>
        
        </td>
    <td>
        
        &nbsp;</td>
    <td></td>
    </tr>

    <tr>
    <td>
        <asp:Label ID="Label6" runat="server" Text="訓練日期："></asp:Label>
        </td>
    <td colspan="4">
    <table>
    <tr>
    <td><telerik:RadDatePicker ID="rdpDateBegin" Runat="server">
        </telerik:RadDatePicker></td>
    <td><asp:Label ID="Label7" runat="server" Text="~"></asp:Label></td>
    <td><telerik:RadDatePicker ID="rdpDateEnd" Runat="server">
        </telerik:RadDatePicker></td>
    </tr>
    </table>
        </td>
    <td></td>
    <td colspan="4">
        <asp:CheckBox ID="cbSelf" runat="server" Checked="True" Text="僅顯示自己建立的課程" />
        </td>
        <td>
            <asp:Button ID="btnQuery" runat="server" onclick="btnQuery_Click" Text="查詢" />
        </td>
        <td></td>
    </tr>
    </table>
        <br />
    </asp:Panel>
    <br />
    <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" CellSpacing="0" 
    Culture="zh-TW" GridLines="None" AllowMultiRowSelection="True"
        AllowPaging="False" 
        style="margin-top: 0px"
        AutoGenerateHierarchy="True"
        onneeddatasource="RadGrid1_NeedDataSource" PageSize="20">
        <ClientSettings>
            <Selecting AllowRowSelect="True" />
        </ClientSettings>
<MasterTableView commanditemdisplay="None" nomasterrecordstext="目前沒有資料" 
            NoDetailRecordsText="" EditMode="PopUp"
            DataKeyNames="EduTermID,Name" 
            HierarchyDefaultExpanded="True" ClientDataKeyNames="EduTermID,Name"
            HierarchyLoadMode="Client"  GroupLoadMode="Client">
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
            <ItemStyle ForeColor="Blue" />
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="Name" 
            FilterControlAltText="Filter Name column" HeaderText="名稱" UniqueName="Name">
            <ItemStyle ForeColor="Blue" />
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="DateFromToStr" 
            FilterControlAltText="Filter EduTeamCode column" HeaderText="訓練起訖日期" 
            UniqueName="DateFromToStr" ReadOnly="True">
            <ItemStyle ForeColor="Blue" />
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
            <ItemStyle ForeColor="Blue" />
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

    </Columns>
    
<EditFormSettings>
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
    <asp:Label ID="Label11" runat="server" Text="醫學系開課序號："></asp:Label>
    <asp:TextBox ID="tbSchoolSeq1" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label12" runat="server" Text="後醫系開課序號："></asp:Label>
    <asp:TextBox ID="tbSchoolSeq2" runat="server"></asp:TextBox>
    <br />
    <asp:Button ID="btnConfirm" runat="server" OnClick="btnConfirm_Click" Text="設定" />
    <asp:ObjectDataSource ID="dsTermCode" runat="server" SelectMethod="GetEduTeams" 
        TypeName="KMU.EduActivity.ApplicationLayer.DTO.EduTermCodeDto">
    </asp:ObjectDataSource>
    
    <asp:ObjectDataSource ID="dsJobCode" runat="server" SelectMethod="GetCodeRefsStatic" 
        TypeName="KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService" 
        DataObjectTypeName="KMU.EduActivity.ApplicationLayer.DTO.V_CodeRefDto">
        <SelectParameters>
            <asp:Parameter DefaultValue="EduAct_JobSerial" Name="codetype" />
        </SelectParameters>
    </asp:ObjectDataSource>
    
    <br />
    <asp:Label ID="lblMsg" runat="server"></asp:Label>
</asp:Content>

