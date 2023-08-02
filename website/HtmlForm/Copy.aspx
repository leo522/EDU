<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Copy.aspx.cs" Inherits="Copy" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server" onkeydown="if ((event.which && event.which == 13) || (event.keyCode && event.keyCode == 13)){return false;};">
    <div>

        <asp:Panel ID="panTemplateName" runat="server">
            輸入Template名稱<br /> 
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:Label ID="lbMsg" runat="server"></asp:Label>
            <br />
        </asp:Panel>
<p>
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="確認" />
&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="取消" />
</p>    
    </div>
    </form>
</body>
</html>
