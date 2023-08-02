<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ReportManage.aspx.cs" Inherits="ReportManage" %>

<%@ Register src="TreeViewComboBox.ascx" tagname="TreeViewComboBox" tagprefix="uc1" %>

<%@ Register Assembly="Telerik.ReportViewer.WebForms, Version=7.2.13.1016, Culture=neutral, PublicKeyToken=a9d7983dfcc261be" Namespace="Telerik.ReportViewer.WebForms" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
.RadGrid_Default{border:1px solid #828282;background-color:white;color:#333;font-family:"Segoe UI",Arial,Helvetica,sans-serif;font-size:12px;line-height:16px}.RadGrid_Default{border:1px solid #828282;background-color:white;color:#333;font-family:"Segoe UI",Arial,Helvetica,sans-serif;font-size:12px;line-height:16px}.RadGrid_Default .rgMasterTable{font-family:"Segoe UI",Arial,Helvetica,sans-serif;font-size:12px;line-height:16px}.RadGrid .rgMasterTable{border-collapse:separate;border-spacing:0}.RadGrid_Default .rgMasterTable{font-family:"Segoe UI",Arial,Helvetica,sans-serif;font-size:12px;line-height:16px}.RadGrid .rgMasterTable{border-collapse:separate;border-spacing:0}.RadGrid table.rgMasterTable tr .rgExpandCol{padding-left:0;padding-right:0;text-align:center}.RadGrid table.rgMasterTable tr .rgExpandCol{padding-left:0;padding-right:0;text-align:center}.RadGrid_Default .rgHeader{color:#333}.RadGrid_Default .rgHeader{border:0;border-bottom:1px solid #828282;background:#eaeaea 0 -2300px repeat-x url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Grid.sprite.gif')}.RadGrid .rgHeader{padding-top:5px;padding-bottom:4px;text-align:left;font-weight:normal}.RadGrid .rgHeader{padding-left:7px;padding-right:7px}.RadGrid .rgHeader{cursor:default}.RadGrid_Default .rgHeader{color:#333}.RadGrid_Default .rgHeader{border:0;border-bottom:1px solid #828282;background:#eaeaea 0 -2300px repeat-x url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Grid.sprite.gif')}.RadGrid .rgHeader{padding-top:5px;padding-bottom:4px;text-align:left;font-weight:normal}.RadGrid .rgHeader{padding-left:7px;padding-right:7px}.RadGrid .rgHeader{cursor:default}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <div>

        <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" 
            onselectedindexchanged="RadioButtonList1_SelectedIndexChanged">
            <asp:ListItem>課程總表</asp:ListItem>
        </asp:RadioButtonList>
    
    </div>
    <br />
    <div>
    <asp:Panel ID="panControlOptions" runat="server" Visible = "true">
        <asp:Panel ID="panInternCourseReport" runat="server" Visible="False">
            <asp:Label ID="Label2" runat="server" Text="學年度："></asp:Label>
            <asp:TextBox ID="tbEduYear" runat="server"></asp:TextBox>
            <asp:Label ID="Label1" runat="server" Text="組別："></asp:Label>
            <uc1:TreeViewComboBox ID="tvbcTeamInternCourse" runat="server" 
                AllowSelectParent="True" AutoPostBack="False" Enabled="True" 
                TreeDataFieldID="EduTeamCode" TreeDataFieldParentID="parentEduTeamCode" 
                TreeDataSourceID="dsTeamCode" TreeDataTextField="EduTeamName" />
        </asp:Panel>
        </asp:Panel>
    </div>
    <br />
    <asp:ObjectDataSource ID="dsTeamCode" runat="server" SelectMethod="GetEduTeams" 
        TypeName="KMU.EduActivity.ApplicationLayer.DTO.EduTeamDto">
    </asp:ObjectDataSource>


    <div>
        <asp:Button ID="btnQuery" runat="server" Text="查詢" onclick="btnQuery_Click" />
    </div>
    <div>
        <telerik:ReportViewer ID="ReportViewer1" runat="server" Width="100%" 
            Height="500px" ShowHistoryButtons="False" ShowParametersButton="False" 
            ShowRefreshButton="False"></telerik:ReportViewer>
    </div>



    
</asp:Content>
