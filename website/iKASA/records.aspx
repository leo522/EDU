<%@ Page Language="C#" AutoEventWireup="true" CodeFile="records.aspx.cs" Inherits="iKASA_records" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<%@ Register src="~/DeptSelector.ascx" tagname="DeptSelector" tagprefix="uc3" %>

<%@ Register src="~/VsSelector.ascx" tagname="VsSelector" tagprefix="uc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
<style>
body{
    font-family:微軟正黑體!important;
}
</style>
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
        <div>

            <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="紀錄清單："></asp:Label>
            <telerik:RadComboBox ID="rcbFormList" Runat="server" AutoPostBack="True" Culture="zh-TW" OnSelectedIndexChanged="rcbFormList_SelectedIndexChanged" Width="350px">
            </telerik:RadComboBox>

            

        </div>
        <asp:Label ID="lbNoData" runat="server" Text="查無相關資料" Font-Bold="True" Font-Size="Large" Visible="False"></asp:Label>
<div>
    <table width="100%">
<tr>
<td>
    <div id="htmlContent">


    <asp:Panel ID="panAll" runat="server">

    
    <table width="100%">
        <tr>
            <td valign="top">
                <asp:Panel ID="panMain" runat="server">
    <table>
        <tr>
            <td class="auto-style1">

                <asp:Label ID="Label3" runat="server" Text="會議主題："></asp:Label>

            </td>
            <td class="auto-style1">

                <asp:Label ID="tbTitle" runat="server"></asp:Label>

            </td>
            <td class="auto-style1">

                &nbsp;</td>
            <td class="auto-style1">

            </td>

        </tr>
        <tr>
            <td>

                <asp:Label ID="Label5" runat="server" Text="會議科別"></asp:Label>

            </td>
            <td colspan="3">
                                    <asp:Label ID="DeptSelector1" runat="server"></asp:Label>
                                    </td>
        </tr>
        <tr>
            <td>

                <asp:Label ID="Label4" runat="server" Text="會議時間："></asp:Label>

            </td>
            <td colspan="3">
                <table>
                    <tr>
                        <td>
                            
                            <asp:Label ID="rdtpSdate" runat="server"></asp:Label>
                            
                        </td>
                        <td>
                            ~
                        </td>
                        <td>

                            <asp:Label ID="rdtpEdate" runat="server"></asp:Label>

                        </td>
                    </tr>
                </table>
            </td>
            
        </tr>

    </table>
                    </asp:Panel>
            </td>
            <td align="right">
                <table>
                    <tr>
                        <td align="center" valign="bottom">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td align="center" valign="top">
                             &nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>

    <div>

        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>

    </div>
    <div>
        <asp:Panel GroupingText="簽到名單" runat="server" ID="panSignIn">
            <telerik:RadGrid ID="rgSignIn" runat="server" AutoGenerateColumns="False" CellSpacing="0" Culture="zh-TW" GridLines="None">
                <ClientSettings>
                    <Selecting AllowRowSelect="True" />
                </ClientSettings>
                <MasterTableView DataKeyNames="InstanceID,EmpCode">
                    <Columns>
                        <telerik:GridBoundColumn DataField="EmpName" FilterControlAltText="Filter EmpName column" HeaderText="姓名" UniqueName="EmpName">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="SignTime" FilterControlAltText="Filter SignTime column" HeaderText="簽到時間" UniqueName="SignTime">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="RoleName" FilterControlAltText="Filter RoleName column" HeaderText="身分" UniqueName="RoleName">
                        </telerik:GridBoundColumn>
                    </Columns>
                </MasterTableView>
            </telerik:RadGrid>
        </asp:Panel>
    </div>
        <div>
            <asp:Panel runat="server" ID="panSign" GroupingText="簽核">
                <div>

                    <telerik:RadGrid ID="rgSign" runat="server" AutoGenerateColumns="False" CellSpacing="0" Culture="zh-TW" GridLines="None">
                        <ClientSettings>
                            <Selecting AllowRowSelect="True" />
                        </ClientSettings>
                        <MasterTableView DataKeyNames="InstanceID,ViewOrder">
                            <Columns>
                                <telerik:GridBoundColumn DataField="ViewOrder" FilterControlAltText="Filter ViewOrder column" HeaderText="順序" UniqueName="ViewOrder">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="EmpName" FilterControlAltText="Filter EmpName column" HeaderText="簽核人" UniqueName="EmpName">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="ViewStatus" FilterControlAltText="Filter ViewStatus column" HeaderText="簽核狀態" UniqueName="ViewStatus">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="ViewTime" FilterControlAltText="Filter ViewTime column" HeaderText="簽核時間" UniqueName="ViewTime">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="ViewMemo" FilterControlAltText="Filter ViewMemo column" HeaderText="備註" UniqueName="ViewMemo">
                                </telerik:GridBoundColumn>
                            </Columns>
                        </MasterTableView>
                    </telerik:RadGrid>

                </div>
            </asp:Panel>
        </div>
        </asp:Panel>
</div>
    <br />
    </td>
</tr>
</table>


</div>
    </form>
</body>
</html>
