<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AvatarEdit.aspx.cs" Inherits="AvatarEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<link href="css/jquery.Jcrop.css" rel="stylesheet" type="text/css" />
<link rel="stylesheet" type="text/css" href="css/imgareaselect-default.css" />

<script type="text/javascript" src="scripts/jquery-1.4.1.min.js"></script>
<script type="text/javascript" src="scripts/jquery.imgareaselect.pack.js"></script>

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
</head>
<body>
<script type="text/javascript">
    $(document).ready(function () {
        $('img#imgCrop').imgAreaSelect({
            aspectRatio: '1:1', 
            handles: true,
            onSelectChange: 
            function (img, selection) {
                $('input[name="X"]').val(selection.x1);
                $('input[name="Y"]').val(selection.y1);
                $('input[name="W"]').val(selection.x2-selection.x1);
                $('input[name="H"]').val(selection.y2-selection.y1);
            }
        });
    });

</script>
    <form id="form1" runat="server">
  <div>
    <asp:Panel ID="pnlUpload" runat="server">

        <asp:Panel ID="Panel1" runat="server" GroupingText="目前頭像">
            <asp:Image ID="imgCurrent" runat="server" />
        </asp:Panel>
        <asp:Panel ID="Panel2" runat="server" GroupingText="更換頭像">

      <asp:FileUpload ID="Upload" runat="server" />

            &nbsp;<asp:Label ID="Label1" runat="server" Font-Size="Small" ForeColor="Red" 
                Text="*圖片將壓縮為320x320大小"></asp:Label>

      <br />

      <asp:Button ID="btnUpload" runat="server" OnClick="btnUpload_Click" Text="上傳圖檔" />
      <asp:Label ID="lblError" runat="server" Visible="false" />        
        </asp:Panel>
        <br />
    </asp:Panel>

    <asp:Panel ID="pnlCrop" runat="server" Visible="false">

      <asp:Image ID="imgCrop" runat="server" />

      <br />

      <asp:HiddenField ID="X" runat="server" />

      <asp:HiddenField ID="Y" runat="server" />

      <asp:HiddenField ID="W" runat="server" />

      <asp:HiddenField ID="H" runat="server" />

      <asp:Button ID="btnCrop" runat="server" Text="剪裁" OnClick="btnCrop_Click" />

    </asp:Panel>

    <asp:Panel ID="pnlCropped" runat="server" Visible="false">

        <asp:Image ID="imgCropped" runat="server" />

        <br />
        <asp:Button ID="btnSave" runat="server" onclick="btnSave_Click" Text="儲存" />

    </asp:Panel>
  </div>
    </form>
</body>
</html>