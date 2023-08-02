<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="PassPortView.aspx.cs" Inherits="PassPortView" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<%@ Register Src="DeptSelector.ascx" TagName="DeptSelector" TagPrefix="uc1" %>

<%@ Register Src="DeptSelectorForPassPort.ascx" TagName="DeptSelectorForPassPort" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style type="text/css">
        
        .auto-style4 {
            height: 31px;
        }

        .auto-style5 {
            height: 20px;
        }

        .auto-style6 {
            height: 21px;
        }

        .auto-style7 {
            height: 29px;
        }

        .auto-style9 {
            font-weight: bold;
            font-size: large;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <table style="width: 100%;">
        <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Style="font-size: large; font-weight: 700; font-family: 微軟正黑體" Text="技術名稱:"></asp:Label>
                <asp:Label ID="lblItemName" runat="server" Style="font-size: large; font-weight: 700; font-family: 微軟正黑體; color: #0000FF"></asp:Label>
            </td>
            <td rowspan="13" align="left" valign="top">
                <asp:Panel runat="server" ID="panRejectLog">
                <div style="width:220px; height:auto">
                    <h2>駁回記錄</h2>
                </div>
                    
                <div><asp:Literal ID="liRejectLog" runat="server"></asp:Literal></div>
                </asp:Panel>

            </td>
        </tr>
        <tr>
            <td class="auto-style6"></td>
        </tr>
        <tr>
            <td class="auto-style5">
                <asp:Label ID="Label7" runat="server" Style="font-size: large; font-weight: 700" Text="考核導師:"></asp:Label>
                <asp:Label ID="lbTeacherName" runat="server" Style="font-size: large; font-weight: 700; font-family: 微軟正黑體; color: #0000FF"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style6"></td>
        </tr>
        <tr>
            <td class="auto-style4">
                <asp:Label ID="Label2" runat="server" Style="font-size: large; font-weight: 700" Text="實作日期:"></asp:Label>
                <asp:Label ID="lbImplementTime" runat="server" Style="font-size: large; font-weight: 700; font-family: 微軟正黑體; color: #0000FF"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style6"></td>
        </tr>
        <tr>
            <td class="auto-style7">
                <asp:Label ID="Label6" runat="server" Style="font-size: large; font-weight: 700" Text="實作地點:"></asp:Label>
                <asp:Label ID="lbImplementPlace" runat="server" Style="font-size: large; font-weight: 700; font-family: 微軟正黑體; color: #0000FF"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <div style="float: left;">
                    <asp:Label ID="Label8" runat="server" Style="font-family: 微軟正黑體;" Text="施作對象:" Height="25px" CssClass="auto-style9"></asp:Label>
                </div>

                
                    <span class="auto-style9">&nbsp;<asp:Label ID="lbImplementObject" runat="server" Style="font-size: large; font-weight: 700; font-family: 微軟正黑體; color: #0000FF"></asp:Label>
                    </span>
                
                
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblHistoryNumber" runat="server" Style="font-size: large; font-weight: 700" Text="病歷號碼:"></asp:Label>

                
                    <span class="auto-style9">
                <asp:Label ID="lbImplementChartNo" runat="server" Style="font-size: large; font-weight: 700; font-family: 微軟正黑體; color: #0000FF"></asp:Label>
                    </span>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="Label3" runat="server" Style="font-size: large; font-weight: 700" Text="意見與回饋:"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:TextBox ID="txtRemark" runat="server" Height="117px" Style="font-size: medium; font-weight: 700; font-family: 微軟正黑體;" TextMode="MultiLine" Width="650px" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="Label1" runat="server" Style="font-size: large; font-weight: 700" Text="教師回饋:"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:TextBox ID="TeacherRemark" runat="server" Height="117px" Style="font-size: medium; font-weight: 700; font-family: 微軟正黑體;" TextMode="MultiLine" Width="650px" ReadOnly="True"></asp:TextBox>                

            </td>
        </tr>
        <tr>
            <td colspan="2">
                <hr />
            </td>
        </tr>
        </table>
</asp:Content>

