<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Uploader.aspx.cs" Inherits="Updater" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server" onkeydown="if ((event.which && event.which == 13) || (event.keyCode && event.keyCode == 13)){return false;};">
    <div>

        <asp:Panel ID="panUpload" runat="server">
選擇Template HTML檔<br />
<asp:FileUpload ID="FileUpload1" runat="server" Height="21px" Width="220px" />
        </asp:Panel>
        <asp:Panel ID="panTemplateName" runat="server">
            輸入Template名稱<br /> 
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            輸入表單分類<br /> 
            <asp:TextBox ID="tbCategory" runat="server">EduActivity</asp:TextBox>
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
