<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="VotePage.aspx.cs" Inherits="VotePage" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div>

        <asp:Literal ID="liContent" runat="server"></asp:Literal>

    </div>
    <div align="center">

        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="送出" />
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnCancel" runat="server" Text="取消" OnClick="btnCancel_Click" />

    </div>
    </asp:Content>

