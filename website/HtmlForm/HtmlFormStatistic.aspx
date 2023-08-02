<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeFile="HtmlFormStatistic.aspx.cs" Inherits="_Default" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

    <script type="text/javascript">
    function ElementClick(btn, id,hiddenid,ispostback) {
        var lbtn = document.getElementById(btn);
        if (lbtn != null) {
            theform = document.forms["form1"];
            var hidden = document.getElementById(hiddenid);
            hidden.value = id;
            if (ispostback == true) {
                lbtn.click();
            }
        }
    }
</script>


    <telerik:RadTabStrip ID="RadTabStrip1" runat="server" MultiPageID="RadMultiPage1" 
            SelectedIndex="0" Skin="WebBlue">
        <Tabs>
            <telerik:RadTab runat="server" PageViewID="RadPageView1" Selected="True" 
                Text="統計設定">
            </telerik:RadTab>
            <telerik:RadTab runat="server" PageViewID="RadPageView2" Text="統計結果">
            </telerik:RadTab>
        </Tabs>
    </telerik:RadTabStrip>
    <telerik:RadMultiPage ID="RadMultiPage1" Runat="server" BorderColor="Black" 
            BorderStyle="Solid" BorderWidth="1px" SelectedIndex="0" Width="100%">
        <telerik:RadPageView ID="RadPageView1" runat="server" Selected="True">

    <table>
    <tr>
    <td>

        <asp:Label ID="Label1" runat="server" Text="統計名稱："></asp:Label></td>
    <td>
        <asp:TextBox ID="tbTitle" runat="server" Width="203px"></asp:TextBox>
        </td>
    </tr>
    <tr>
    <td><asp:Label ID="Label2" runat="server" Text="統計項目："></asp:Label></td>
    <td>
        <asp:ListBox ID="ListBox1" runat="server" Height="139px" Width="255px" 
            onselectedindexchanged="ListBox1_SelectedIndexChanged" AutoPostBack="True">
        </asp:ListBox>
        </td>
    </tr>
    <tr>
    <td colspan="2">
    
        <asp:Button ID="btnRemove" runat="server" onclick="btnRemove_Click" Text="刪除" />
    
    </td>
    </tr>
    <tr>
    <td colspan="2">
        <asp:TextBox ID="tbItemName" runat="server" Visible="False"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="修改項目名稱" onclick="Button1_Click" 
            Visible="False" />
    </td>
    </tr>
    </table>   


        <asp:Button ID="btnStatistic" runat="server" onclick="btnStatistic_Click" 
            Text="統計" />
         
    <div id="htmlContent" runat="server">
    

    
    </div>
        </telerik:RadPageView>
        <telerik:RadPageView ID="RadPageView2" runat="server" Width="100%">
        <table>
        <tr>
        <td>
            <asp:Label ID="Label3" runat="server" Text="有效樣本數："></asp:Label>
            <asp:Label ID="lblCount" runat="server"></asp:Label>
            <br />
            <asp:Label ID="lblData" runat="server"></asp:Label>
            <br />
            <asp:Chart ID="barChart" runat="server" Width="753px">
                <series>
                    <asp:Series Name="Series1">
                    </asp:Series>
                </series>
                <chartareas>
                    <asp:ChartArea Name="ChartArea1">
                    </asp:ChartArea>
                </chartareas>
                <Titles>
                    <asp:Title Name="Title1">
                    </asp:Title>
                </Titles>
            </asp:Chart>
            </td>
        </tr>
        <tr>
        <td>
            <asp:Chart ID="pieChart" runat="server" Height="363px" Width="745px">
                <series>
                    <asp:Series ChartType="Pie" Name="Series1" Legend="Legend1">
                    </asp:Series>
                </series>
                <chartareas>
                    <asp:ChartArea Name="ChartArea1">
                    </asp:ChartArea>
                </chartareas>
                <Legends>
                    <asp:Legend Name="Legend1">
                    </asp:Legend>
                </Legends>
                <Titles>
                    <asp:Title Name="Title1">
                    </asp:Title>
                </Titles>
            </asp:Chart>
        </td>
        </tr>
        </table>

        </telerik:RadPageView>
    </telerik:RadMultiPage>






    &nbsp;
        <!--
    <input type="button" id="cancel" value="取消" name="cancel" onclick="location.href='HtmlAgilityAdmin.aspx';"/>
    -->

    <asp:LinkButton ID="lbtnPostBack" runat="server" onclick="lbtnPostBack_Click"></asp:LinkButton>


    <input id="HiddenID" runat="server" type="hidden" />
    <input id="HiddenName" runat="server" type="hidden" />
    <input id="HiddenDisplayName" runat="server" type="hidden" />



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