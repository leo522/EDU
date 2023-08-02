<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserInfo.aspx.cs" Inherits="UserInfo" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Panel ID="panInfo" runat="server">
    <table width="100%">
    <tr>
    <td width="200px" align="center" valign="middle">
        <telerik:RadBinaryImage ID="RadBinaryImage1" runat="server" Height="200px" ResizeMode="Fit" />
        </td>
    <td valign="top">
    <table width="100%">
    <tr>
    <td width="80px" align="right">姓名：</td>
    <td>
        <asp:Label ID="lbName" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
    <td width="80px" align="right">員工編號：</td>
    <td>
        <asp:Label ID="lbEmpCode" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
    <td width="80px" align="right">組別：</td>
    <td>
        <asp:Label ID="lbTeam" runat="server"></asp:Label>
        </td>
    </tr>
    </table>
    </td>
    </tr>
    </table>
    </asp:Panel>
    </div>
    </form>
</body>
</html>
