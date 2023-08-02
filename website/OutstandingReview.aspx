<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="OutstandingReview.aspx.cs" Inherits="OutstandingReview" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <script runat="server">
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "傑出表現資料審查";
        }
    </script>

    <link href="iconPic/all.css" rel="stylesheet" />
    <link href="jquery-ui/jquery-ui.theme.min.css" rel="stylesheet" />
    <script type="text/javascript" src="jQuery/jquery-3.6.4.min.js"></script>
    <script type="text/javascript" src="jquery-ui/jquery-ui.js"></script>
    <link href="bootstrap-5.3.0/css/bootstrap.min.css" rel="stylesheet" />
    <script type="text/javascript" src="bootstrap-5.3.0/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="Sweet/sweetalert2.all.min.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:Label ID="Label1" runat="server" Text="位置"></asp:Label>
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx">首頁</asp:HyperLink>
    <asp:Label ID="Label2" runat="server" Text="&gt;"></asp:Label>
    <asp:HyperLink ID="HyperLink2" runat="server">HyperLink</asp:HyperLink>
    <asp:Label ID="Label3" runat="server" Text="&gt;傑出表現資料審查"></asp:Label>

    <div>

    </div>
</asp:Content>

