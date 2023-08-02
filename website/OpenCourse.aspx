<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OpenCourse.aspx.cs" Inherits="OpenCourse" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 116px;
        }
    </style>
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
    <div>
    <table width="100%">
    <tr>
    <td class="style1" align="right">
        <asp:Label ID="Label1" runat="server" Text="課程代碼："></asp:Label>
    </td>
    <td>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    </td>
    </tr>
    <tr>
    <td class="style1" align="right">
        <asp:Label ID="Label2" runat="server" Text="名稱："></asp:Label>
    </td>
    <td>
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    </td>
    </tr>
    <tr>
    <td class="style1" align="right">
        <asp:Label ID="Label3" runat="server" Text="課程日期："></asp:Label>
    </td>
    <td>
        <telerik:RadDatePicker ID="RadDatePicker1" Runat="server">
        </telerik:RadDatePicker>
        ~<telerik:RadDatePicker ID="RadDatePicker2" Runat="server">
        </telerik:RadDatePicker>
    </td>
    </tr>
    <tr>
    <td class="style1" align="right">
        <asp:Label ID="Label4" runat="server" Text="歸屬類別："></asp:Label>
    </td>
    <td>
        <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
            RepeatDirection="Horizontal">
            <asp:ListItem>科別</asp:ListItem>
            <asp:ListItem>護士站</asp:ListItem>
            <asp:ListItem>醫師</asp:ListItem>
        </asp:RadioButtonList>
    </td>
    </tr>
    <tr>
    <td class="style1" align="right">
        <asp:Label ID="Label5" runat="server" Text="單位/VS："></asp:Label>
    </td>
    <td>
        <asp:DropDownList ID="DropDownList1" runat="server">
        </asp:DropDownList>
    </td>
    </tr>
    <tr>
    <td class="style1" align="right">
        <asp:Label ID="Label6" runat="server" Text="人數："></asp:Label>
    </td>
    <td>
        <telerik:RadNumericTextBox ID="RadNumericTextBox1" Runat="server">
        </telerik:RadNumericTextBox>
    </td>
    </tr>
    <tr>
    <td class="style1" align="right">
        <asp:Label ID="Label7" runat="server" Text="說明："></asp:Label>
    </td>
    <td>
        <asp:TextBox ID="TextBox3" runat="server" Width="452px"></asp:TextBox>
    </td>
    </tr>
    <tr>
    <td class="style1" align="right">
    </td>
    <td>
    </td>
    </tr>
    <tr>
    <td class="style1" align="right">
    </td>
    <td>
        <asp:Button ID="Button1" runat="server" Text="儲存" Width="60px" 
            onclick="Button1_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" Text="取消" Width="54px" 
            onclientclick="CloseWindow(false);" />
    </td>
    </tr>
    </table>
    </div>
    <telerik:RadScriptManager ID="RadScriptManager1" Runat="server">
    </telerik:RadScriptManager>
    </form>
</body>
</html>
