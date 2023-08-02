<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="SixCoreCompetences.aspx.cs" Inherits="SixCoreCompetences" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
        <link href="iconPic/all.css" rel="stylesheet" />
    <link href="css/Outstanding.css" rel="stylesheet" />
    <link href="jquery-ui/jquery-ui.theme.min.css" rel="stylesheet" />
    <script type="text/javascript" src="jQuery/jquery-3.6.4.min.js"></script>
    <script type="text/javascript" src="jquery-ui/jquery-ui.js"></script>
    <link href="bootstrap-5.3.0/css/bootstrap.min.css" rel="stylesheet" />
    <script type="text/javascript" src="bootstrap-5.3.0/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="Sweet/sweetalert2.all.min.js"></script>
    <script type="text/javascript" src="Sweet/sweetalert2.all.min.js"></script>

    <script runat="server">
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "六大核心能力";
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
</asp:Content>

