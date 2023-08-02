<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AvatarCopy.aspx.cs" Inherits="AvatarCopy" %>

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

  </div>

    </form>
</body>
</html>
