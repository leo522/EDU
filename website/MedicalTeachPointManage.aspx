<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="MedicalTeachPointManage.aspx.cs" Inherits="MedicalTeachPointManage" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <link href="iconPic/all.css" rel="stylesheet" />
    <link href="jquery-ui/jquery-ui.theme.min.css" rel="stylesheet" />
    <script type="text/javascript" src="jQuery/jquery-3.6.4.min.js"></script>
    <script type="text/javascript" src="jquery-ui/jquery-ui.js"></script>
    <link href="bootstrap-5.3.0/css/bootstrap.min.css" rel="stylesheet" />
    <script type="text/javascript" src="bootstrap-5.3.0/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="Sweet/sweetalert2.all.min.js"></script>

    <script runat="server">
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "醫事教師點數管理";
        }
    </script>

    <style type="text/css">
        .nav-tabs .nav-link.active,
        .nav-tabs .nav-item.show .nav-link {
            border: 1px solid #000000;
            background-color: #ccc;
        }
        .nav-link {
            border: 1px solid #000000;
            border-top-left-radius: .25rem;
            border-top-right-radius: .25rem;
            background-color: #fff;
            color: #000000;
        }
        .nav-link.active {
            background-color: #fff;
            color: #333;
            border-bottom-color: transparent;
        }
        .nav-link:not(.active) {
            color: #000000;
        }
        .tab-content {
            border: 1px solid #000000;
            padding: 10px;
        }

    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

<asp:Panel ID="Main_Panel" runat="server">
    <div>
            <hr />
            <asp:Panel ID="Panel5" runat="server" CssClass="my-panel" GroupingText="匯入格式範例"></asp:Panel>       
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/docs/醫事教師教學點數申請表匯入範例.xls">下載</asp:HyperLink>
            <asp:Label ID="Label12" runat="server" Font-Bold="True" ForeColor="Red" Text="*範例檔欄位名稱請勿刪除或修改"></asp:Label>
   </div>

    <div>
            <hr />
            <asp:Panel ID="Panel6" runat="server" CssClass="my-panel" GroupingText="匯入醫事教師教學點數檔案"></asp:Panel>
        <div style="display: flex;">
            <asp:Label ID="DeptCode" runat="server" Text="單位：" style="margin-right: 10px;"></asp:Label>
            <%--<asp:DropDownList ID="ddlDept" runat="server">
                <asp:ListItem Value="0">請選擇</asp:ListItem>
            </asp:DropDownList><br/>--%>
            <asp:TextBox ID="txtDept" runat="server" CssClass="form-control" style="width: 300px;"></asp:TextBox>
            <asp:HiddenField ID="hfDeptCode" runat="server" />
        </div>

            <br />
            <asp:FileUpload ID="ExcelUpload" runat="server" />
            <asp:Button ID="btn_Import" runat="server" Text="匯入" OnClick="btn_Import_Click" />
    </div>
</asp:Panel>

<script type="text/javascript">
    <%--$(document).ready(function () {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "MedicalTeachPointManage.aspx/GetDepartments",
            dataType: "json",
            success: function (data) {
                $('#<%= txtDept.ClientID %>').autocomplete({
                    source: function (request, response) {
                        var term = request.term.toLowerCase();
                        var filteredData = $.grep(data.d, function (item) {
                            return item.toLowerCase().indexOf(term) >= 0;
                        });
                        response(filteredData);
                    },
                    minLength: 0
                }).focus(function () {
                    $(this).autocomplete("search", $(this).val());
                });
            },
            error: function (xhr, status, error) {
                alert(error);
            }
        });
   });--%>
</script>
</asp:Content>