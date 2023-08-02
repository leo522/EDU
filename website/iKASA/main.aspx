<%@ Page Language="C#" AutoEventWireup="true" CodeFile="main.aspx.cs" Inherits="iKASA_main" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>i-KASA</title>

</head>
<body>

  
<style type="text/css">
body{
    font-family:微軟正黑體!important;
}

.sitebody{
    width:100%;
    margin:0 auto;
    font-size:13px;
}
.header{
background-color:#0096A7;
text-align:left;
color:white;
}

#header{
background-color:#0096A7;
height:85px;
text-align:left;
color:white;
line-height:80px;
}
#sidebar_left{
background-color:#FFECC9;
width:270px;
text-align:left;
float:left;
min-height:470px;
}

#content{
margin-left:270px;
margin-right:0px;
background-color:#FFFFFF;
text-align:center;
min-height:470px;
}
#footer{
clear:both;
background-color:#FFD4D4;
height:20px;
text-align:center;
line-height:20px;
}

.menuitem
{
    min-height:35px;
    line-height:35px;
    font-size:15px;
    font-weight:bold;
    border: outset;
    border-width:thin;
    border-color:white;
}


#loader1 {
    position:absolute;
    left:40%;
    top:35%;
    border-radius:20px;
    padding:25px;
    
    background:#ffffff;
    box-shadow:0px 0px 10px #777777;
}
</style>
    <!--
    <div style="text-align:right;" class="header" runat="server">
                        <form id="formChange" method="post" action="main.aspx" style="height:100%" >
                切換學員，請輸入身分證字號：<input type="text" name ="iKasaIdNo" id="iKasaIdNo" /><input type="submit" id="submitchange" name="submitchange" title="送出" value="送出" >
                            </form>
        </div>-->
        <form id="form1" runat="server">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
            <Scripts>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js">
                </asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js">
                </asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js">
                </asp:ScriptReference>
            </Scripts>
        </telerik:RadScriptManager>



<link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css">
<link rel="stylesheet" href="../Scripts/source/jquery.fancybox.css?v=2.1.7" type="text/css" media="screen" />
<script src="//code.jquery.com/jquery-1.10.2.js"></script>
<script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
<script type="text/javascript" src="../Scripts/lib/jquery.mousewheel-3.0.6.pack.js"></script>
<script type="text/javascript" src="../Scripts/source/jquery.fancybox.pack.js?v=2.1.7"></script>
<script src="../Scripts/source/jquery.fancybox.js"></script>
<script>
    $(function () { $("#adv").accordion({ collapsible: true, active: false }); });

    function resizeIframe(obj) {
        obj.style.height = (obj.contentWindow.document.body.scrollHeight+20) + 'px';
    }

    $(document).ready(function () {
        $('#loader1').show();
        $('#frameContent').on('init', function () {
            $('#loader1').show();
        });
        $('#frameContent').on('load', function () {
            
            resizeIframe(this);
            $('#loader1').hide();
        });
        $("#li_Image1").fancybox({
            openEffect: 'elastic',
            closeEffect: 'elastic',

            helpers: {
                title: {
                    type: 'inside'
                }
            }
        });

    });

    
</script>    

<div id="sitebody">
<div id="header">
<div style="margin-left:20px;">
    <table width="100%">
        <tr>
            <td  style="text-align:left"><a href="main.aspx" style="text-decoration: none;"><img src="../Images/kmuhlogos.gif" height="75" width="75" /><asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="White" Font-Underline="False" Font-Size="X-Large" Text="i-KASA教學儀表板"></asp:Label></a> </td>
            <td style="text-align:right; vertical-align:central">
                
            </td>
            <td style="text-align:right; vertical-align:bottom; color:white" >
<a id="li_Image1" href="../Avatar/no_avatars.jpg" title="個人照片" runat="server">
    <img id="Image1" src="../Avatar/no_avatars.jpg" height="75" width="75" runat="server" alt="" />
</a>
                    
                <!--<telerik:RadBinaryImage ID="RadBinaryImage1" runat="server" Height="75px" ResizeMode="Fit" />-->
                <asp:Label ID="lbEmpCode" runat="server"></asp:Label> - <asp:Label ID="lbName" runat="server"></asp:Label>(<asp:Label ID="lbTrainRange" runat="server"></asp:Label>)　
                <asp:HyperLink ID="HyperLink1" ForeColor="White" runat="server"  NavigateUrl="~\">回教學管理系統</asp:HyperLink>
            </td>
        </tr>
    </table> 
    
</div>
</div>

    <div id="adv" style="display:none">

        <asp:Label ID="lbMemberCode" runat="server"></asp:Label>

        <asp:Label ID="lbJobName" runat="server"></asp:Label>

        <asp:Label ID="lbTeam" runat="server"></asp:Label>

    </div>
<div id="sidebar_left">
    <div class="menuitem">
        <asp:Label ID="Label2" runat="server" Text="學習階段："></asp:Label>
<telerik:RadComboBox ID="rcbRole" Runat="server" RenderMode="Lightweight" DropDownWidth="425" DataTextField="membertypename" EmptyMessage="選擇實習階段" HighlightTemplatedItems="true"
                        EnableLoadOnDemand="true" DataValueField="memberid" Culture="zh-TW" OnItemsRequested="rcbRole_ItemsRequested" AutoPostBack="True" OnSelectedIndexChanged="rcbRole_SelectedIndexChanged" Font-Names="微軟正黑體">
                        <HeaderTemplate>
                            <table style="width: 415px; font-family:微軟正黑體;  cellspacing="0" cellpadding="0">
                                <tr>
                                    <td style="width: 95px;">
                                        學號
                                    </td>
                                    <td style="width: 95px;">
                                        職稱
                                    </td>
                                    <td style="width: 105px;">
                                        組別
                                    </td>
                                    <td style="width: 120px;">
                                        實習期間
                                    </td>
                                </tr>
                            </table>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <table style="width: 415px; font-family:微軟正黑體; " cellspacing="0" cellpadding="0">
                                <tr>
                                    <td style="width: 95px;">
                                        <%# DataBinder.Eval(Container, "Attributes['membercode']")%>
                                    </td>
                                    <td style="width: 95px;">
                                        <%# DataBinder.Eval(Container, "Attributes['membertypename']")%>
                                    </td>
                                    <td style="width: 105px;">
                                        <%# DataBinder.Eval(Container, "Attributes['teamname']")%>
                                    </td>
                                    <td style="width: 120px;">
                                        <%# DataBinder.Eval(Container, "Attributes['daterange']")%>
                                    </td>
                                    
                                </tr>
                            </table>
                        </ItemTemplate>
        </telerik:RadComboBox>

    </div>
    <asp:Literal ID="li_menu" runat="server"></asp:Literal>
</div>
<div id="content">
    <img id="loader1" src="../Images/loading.gif" style="display:none" width="36" height="36" alt="loading.gif"/>
    <iframe id="frameContent" width="100%" frameborder="0" allowtransparency="yes" scrolling="no" runat="server" ></iframe>
</div>
<div id="footer"></div>
</div>
    </form>

</body>
</html>
