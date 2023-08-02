<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EduTeamMemberRundown.aspx.cs" Inherits="EduTeamMemberRundown" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register src="TreeViewComboBox.ascx" tagname="TreeViewComboBox" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    </head>
<body>
<script type="text/javascript">
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

    <form id="form1" runat="server">



    <telerik:RadScriptManager ID="RadScriptManager1" Runat="server">
    </telerik:RadScriptManager>

    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
    </telerik:RadAjaxManager>
<div>
<asp:Panel ID="CoursePanel" runat="server" GroupingText="課程">
<table width="100%">
<tr>
<td>
    <asp:Label ID="Label9" runat="server" Text="課程代碼："></asp:Label>
    <asp:Label ID="lblEduStopCode" runat="server"></asp:Label>
    </td>
<td>
    <asp:Label ID="Label10" runat="server" Text="名稱："></asp:Label>
    <asp:Label ID="lblName" runat="server"></asp:Label>
    </td>
<td>
    <asp:Label ID="Label11" runat="server" Text="訓練日期："></asp:Label>
    <asp:Label ID="lblDate" runat="server"></asp:Label>
    </td>
<td>
    <asp:Label ID="Label12" runat="server" Text="人數："></asp:Label>
    <asp:Label ID="lblMemberCount" runat="server"></asp:Label>
    </td>
</tr>
</table>

</asp:Panel>
</div>
<telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server"
        HorizontalAlign="NotSet" LoadingPanelID="RadAjaxLoadingPanel1" width="100%">

<div>
<asp:Panel ID="Panel1" runat="server" GroupingText="學員">
<asp:Panel ID="panControl" runat="server">
<div>
    <asp:Label ID="Label13" runat="server" Text="組別："></asp:Label>
<%--    <asp:DropDownList ID="ddlTeamCdoe" runat="server" DataSourceID="dsTermCode" 
        DataTextField="EduTeamCode" DataValueField="EduTeamCode" 
        AutoPostBack="True" onselectedindexchanged="ddlTeamCdoe_SelectedIndexChanged">
    </asp:DropDownList>--%>
    <uc1:TreeViewComboBox ID="TreeViewComboBox1" runat="server" Enabled="True" 
        TreeDataFieldID="EduTeamCode" TreeDataFieldParentID="parentEduTeamCode" 
        TreeDataSourceID="dsTermCode" TreeDataTextField="EduTeamName" 
        AutoPostBack="True" AllowSelectParent="True" />
    <asp:Label ID="Label16" runat="server" Text="單位："></asp:Label>
    <telerik:RadComboBox ID="ddlDept" Runat="server" AutoPostBack="True" 
        Filter="Contains" onselectedindexchanged="ddlDept_SelectedIndexChanged">
    </telerik:RadComboBox>
    <asp:Label ID="Label14" runat="server" Text="職稱："></asp:Label>


    <telerik:RadComboBox ID="ddlJobCode" Runat="server" AutoPostBack="True" 
        DataSourceID="dsJobCode" DataTextField="Code" DataValueField="Name" 
        Filter="Contains" onselectedindexchanged="ddlDept_SelectedIndexChanged">
    </telerik:RadComboBox>
    </div>
    </asp:Panel>
<div>
<table width = "100%">
<tr>
<td width="45%">
    <asp:ListBox ID="lbSelection" runat="server" Width="100%" Height="350px" 
        SelectionMode="Multiple"></asp:ListBox>
    </td>
<td width="10%" align="center" valign="middle">
    <asp:Button ID="btnAdd" runat="server" Text="&gt;&gt;" onclick="btnAdd_Click" 
        Font-Bold="True" Font-Size="Large" />
    <br /><br />
    <asp:Button ID="btnRemove" runat="server" Text="&lt;&lt;" 
        onclick="btnRemove_Click" Font-Bold="True" Font-Size="Large" />
    </td>
<td width="45%">
    <asp:ListBox ID="lbSelected" runat="server" Width="100%" Height="350px" 
        SelectionMode="Multiple"></asp:ListBox>
    </td>
</tr>
</table>
</div>
<div>
<table width="100%">
<tr>
<td width="80%" align="left">
    &nbsp;
    <asp:Button ID="btnSubmit" runat="server" onclick="btnSubmit_Click" Text="儲存" Width="60px" />
    &nbsp;&nbsp;<asp:Button ID="btnSaveAll" runat="server" Text="儲存至所有輪訓課程" OnClientClick="if(!confirm('儲存將會覆蓋所有原先設定，是否儲存?')){return false;}" OnClick="btnSaveAll_Click" />
&nbsp;
    <asp:Button ID="btnCancel" runat="server" onclientclick="CloseWindow(false);" 
        Text="取消" Width="54px" />
</td>
<td width="20%" align="right">


    <asp:Panel ID="pancount" runat="server">
        <asp:Label ID="Label15" runat="server" Text="已選擇："></asp:Label>
        <asp:Label ID="lblChoiceCount" runat="server"></asp:Label>
    </asp:Panel>


</td>
</tr>
</table>

    </div>

</asp:Panel>
</div>


    </telerik:RadAjaxPanel>



    <asp:ObjectDataSource ID="dsTermCode" runat="server" SelectMethod="GetEduTeams" 
        TypeName="KMU.EduActivity.ApplicationLayer.DTO.EduTeamDto">
    </asp:ObjectDataSource>
    
    <asp:ObjectDataSource ID="dsJobCode" runat="server" SelectMethod="GetJobCodes" 
        TypeName="KMU.EduActivity.ApplicationLayer.DTO.SelectEduActJobCodeDto">
    </asp:ObjectDataSource>
    
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" Runat="server" 
        Skin="Default">
    </telerik:RadAjaxLoadingPanel>
    </form>
</body>
</html>
