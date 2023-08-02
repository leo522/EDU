<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"  CodeFile="ClinicalInstructorCertificate.aspx.cs" Inherits="ClinicalInstructorCertificate" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <%--<link href="iconPic/all.css" rel="stylesheet" />--%>
    <link href="iconPic/css/all.css" rel="stylesheet" />
    <script type="text/javascript" src="iconPic/js/all.js"></script>

    <script type="text/javascript" src="jQuery/jquery-3.6.4.min.js"></script>
    <link href="bootstrap-5.3.0/css/bootstrap.min.css" rel="stylesheet" />
    <script type="text/javascript" src="bootstrap-5.3.0/js/bootstrap.min.js"></script>

    <script type="text/javascript" src="Sweet/sweetalert2.all.min.js"></script>
        <script runat="server">
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "臨床指導教師證";
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:Label ID="Label1" runat="server" Text="位置："></asp:Label>
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx">首頁</asp:HyperLink>
    <asp:Label ID="Label2" runat="server" Text="&gt;"></asp:Label>
    <asp:HyperLink ID="HyperLink2" runat="server">個人專區</asp:HyperLink>
    <asp:Label ID="Label3" runat="server" Text="&gt;我的臨床指導教師證"></asp:Label>

    <asp:Panel ID="panClinicalInfos" runat="server">
        <br />

    </asp:Panel>
            <div class="loginInfo">
            <div style="display:none">
                <asp:Label ID="Label4" runat="server" Text="姓名："></asp:Label>
                <input id="CName" name="CIC_Name" type="text" placeholder="請輸入姓名" />
                <asp:Button ID="btn_Search" runat="server" Text="查詢" OnClick="btn_Search_Click" />
            </div>
            
            <div style="display:none">
                <asp:FileUpload ID="FileUpload" runat="server" />
                <asp:Button ID="btnUpload" runat="server" Text="匯入" OnClick="btnUpload_Click" />
            </div>

            <div>
                <asp:Button ID="btn_DownLoad" runat="server" Text="下載" OnClick="btn_DownLoad_Click"/>
            </div>
            <br />
            <div id="CIC_Image">
                <asp:Image ID="CIC_ImagePreview" runat="server" Height="272px" Width="483px" ImageUrl="~/Images/CIC_Pic.jpg" />
            </div>
        </div>
</asp:Content>