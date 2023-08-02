<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="MyTeachers.aspx.cs" Inherits="MyTeachers" %>
<%@ Register src="~/UserControls/EduTeacherInfo.ascx" 
    tagname="EduTeacherInfo" tagprefix="EduTeacherInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <b><asp:Label ID="lbNoData" runat="server" Text="您目前沒有課程教師資料" Font-Size="Large" Visible="False"></asp:Label></b>
    <asp:Panel ID="panTeacherInfos" runat="server">
    </asp:Panel>
</asp:Content>

