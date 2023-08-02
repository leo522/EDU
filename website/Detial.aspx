<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeFile="Detial.aspx.cs" Inherits="_Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div id="EditedTitle" runat="server" visible="false">
    已填寫過，可進行編輯
    </div>
    
    <div id="htmlContent" runat="server">
    
    </div>

    <br />

    &nbsp;
    <asp:Button ID="btn_submit" runat="server" onclick="btn_submit_Click" 
        Text="送出" OnClientClick="return checkInput();" />
    <input type="button" id="cancel" value="取消" name="cancel" onclick="window.history.back();"/>


</asp:Content>

<%--
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server" method="post" onkeydown="if ((event.which && event.which == 13) || (event.keyCode && event.keyCode == 13)){return false;};">
</form>
    
</body>
</html>
--%>