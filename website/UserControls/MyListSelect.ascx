<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MyListSelect.ascx.cs" Inherits="UserControls_MyListSelect" %>
   <%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:TextBox ID="tbSelect" runat="server" ReadOnly="True" Width="199px">未選擇名單</asp:TextBox>
<asp:Button ID="btnFind" runat="server" Text="選擇" OnClick="btnFind_Click" />
<asp:LinkButton ID="lbtnRefresh" runat="server" OnClick="lbtnRefresh_Click"></asp:LinkButton>
    
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server" Modal="True"
        onclientclose="OnClientClose" ShowContentDuringLoad="False" ReloadOnShow ="false">
        <Windows>
            <telerik:RadWindow ID="rwOpenBig" runat="server" Modal="True" Width="950px" Height = "450px" ReloadOnShow="false"
                style="display:none; z-index: 1000000;">
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
<input type="hidden" id="hidMyListID" runat="server" />
<input type="hidden" id="hidMyListName" runat="server" />
<input type="hidden" id="hidCodes" runat="server" />
<input type="hidden" id="hidNames" runat="server" />

