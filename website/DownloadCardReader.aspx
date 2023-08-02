<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DownloadCardReader.aspx.cs" Inherits="DownloadCardReader" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        1. 下載刷卡簽到管理程式 
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/CardReader/CardReader.exe">下載</asp:HyperLink>
        <br />
        2. 執行下載的安裝檔 <br />
        <asp:Image ID="Image1" runat="server" ImageUrl="~/CardReader/1.png" />
        <br />
        3. 安裝畫面中點選解壓縮<br />
        <asp:Image ID="Image2" runat="server" ImageUrl="~/CardReader/2.png" />
        <br />
        4.安裝完成後桌面上會自動建立捷徑<br />
        <asp:Image ID="Image3" runat="server" ImageUrl="~/CardReader/3.png" />
        <br />
        5.刷卡管理系統操作手冊 
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/CardReader/刷卡程式操作手冊.pdf">下載</asp:HyperLink>
    
    </div>
    </form>
</body>
</html>
