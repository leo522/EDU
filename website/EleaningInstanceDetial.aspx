<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" ValidateRequest="false" CodeFile="EleaningInstanceDetial.aspx.cs" Inherits="ElearningInstanceDetial" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
.RadGrid_Default{border:1px solid #828282;background-color:white;color:#333;font-family:"Segoe UI",Arial,Helvetica,sans-serif;font-size:12px;line-height:16px}
.RadGrid_Default{border:1px solid #828282;background-color:white;color:#333;font-family:"Segoe UI",Arial,Helvetica,sans-serif;font-size:12px;line-height:16px}.RadGrid .rgMasterTable{border-collapse:separate;border-spacing:0}.RadGrid_Default .rgMasterTable{font-family:"Segoe UI",Arial,Helvetica,sans-serif;font-size:12px;line-height:16px}.RadGrid .rgMasterTable{border-collapse:separate;border-spacing:0}.RadGrid_Default .rgMasterTable{font-family:"Segoe UI",Arial,Helvetica,sans-serif;font-size:12px;line-height:16px}.RadGrid table.rgMasterTable tr .rgExpandCol{padding-left:0;padding-right:0;text-align:center}.RadGrid table.rgMasterTable tr .rgExpandCol{padding-left:0;padding-right:0;text-align:center}.RadGrid .rgHeader{cursor:default}
        .RadGrid .rgHeader{padding-left:7px;padding-right:7px}.RadGrid .rgHeader{padding-top:5px;padding-bottom:4px;text-align:left;font-weight:normal}.RadGrid_Default .rgHeader{border:0;border-bottom:1px solid #828282;background:#eaeaea 0 -2300px repeat-x url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Grid.sprite.gif')}.RadGrid_Default .rgHeader{color:#333}.RadGrid .rgHeader{cursor:default}.RadGrid .rgHeader{padding-left:7px;padding-right:7px}.RadGrid .rgHeader{padding-top:5px;padding-bottom:4px;text-align:left;font-weight:normal}.RadGrid_Default .rgHeader{border:0;border-bottom:1px solid #828282;background:#eaeaea 0 -2300px repeat-x url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Grid.sprite.gif')}.RadGrid_Default .rgHeader{color:#333}</style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">    
<script language="javascript" type="text/javascript">

    function printDiv() {

        var divToPrint = document.getElementById('<%= htmlContent.ClientID %>');

        var newWin = window.open('about:blank', 'PrintWindow', config = 'width=1024,height=768');

        newWin.document.write('<html><body">' + divToPrint.innerHTML + '</body></html>');

        newWin.document.close();
        newWin.focus();
        newWin.print();
        newWin.close();

        //setTimeout(function () { newWin.close(); }, 10);

    }

</script>

    <div id="htmlContent" runat="server">
    
    </div>
    <div align="center">
        <asp:Button ID="btnAttachment" runat="server" Text="管理附件" Visible="False" />
    </div>
    <br />

    &nbsp;
    <asp:Button ID="btn_submit" runat="server" onclick="btn_submit_Click" 
        Text="送出" />
    <asp:Button ID="btn_presave" Visible="false" runat="server" onclick="btn_submit_Click" 
        Text="暫存" />
    <asp:Button ID="btnPrint" Visible="false" OnClientClick="printDiv();return false;" 
        runat="server" Text="列印" />
    <input type="button" id="cancel" value="回上頁" name="cancel" onclick="window.history.back();"/>

    </asp:Content>