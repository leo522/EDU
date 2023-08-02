<%@ Page Language="C#" AutoEventWireup="true" CodeFile="passport.aspx.cs" Inherits="iKASA_passport" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register src="~/UserControls/EduPassportInsItemControl.ascx" tagname="EduPassportInsItemControl" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
body{
    font-family:微軟正黑體!important;
}
.RadGrid_Default{border:1px solid #828282;background-color:white;color:#333;font-family:"Segoe UI",Arial,Helvetica,sans-serif;font-size:12px;line-height:16px}.RadGrid_Default .rgMasterTable{font-family:"Segoe UI",Arial,Helvetica,sans-serif;font-size:12px;line-height:16px}.RadGrid .rgMasterTable{border-collapse:separate;border-spacing:0}.RadGrid table.rgMasterTable tr .rgExpandCol{padding-left:0;padding-right:0;text-align:center}.RadGrid_Default .rgHeader{color:#333}.RadGrid_Default .rgHeader{border:0;border-bottom:1px solid #828282;background:#eaeaea 0 -2300px repeat-x url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Grid.sprite.gif')}.RadGrid .rgHeader{padding-top:5px;padding-bottom:4px;text-align:left;font-weight:normal}.RadGrid .rgHeader{padding-left:7px;padding-right:7px}.RadGrid .rgHeader{cursor:default}.RadGrid_Default .rgHeader a{color:#333}.RadGrid .rgHeader a{text-decoration:none}

a:link, a:visited
{
    color: #034af3;
}

        .auto-style1 {
            border-color: #d9d9d9;
            background: #d9d9d9;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <telerik:RadScriptManager ID="RadScriptManager1" Runat="server">
        </telerik:RadScriptManager>
    
        <telerik:RadMultiPage ID="rmp" Runat="server" Width="99%">
            <telerik:RadPageView ID="rpvList" runat="server" Selected ="true">
                <telerik:RadGrid ID="rgList" runat="server" AllowSorting="True" AutoGenerateColumns="False" CellSpacing="0" Culture="zh-TW" GridLines="None" OnItemDataBound="rgList_ItemDataBound" OnNeedDataSource="rgList_NeedDataSource" Font-Names="微軟正黑體">
                    <ClientSettings>
                        <Selecting AllowRowSelect="True" />
                    </ClientSettings>
                    <AlternatingItemStyle Font-Names="微軟正黑體" Font-Size="Medium" />
                    <MasterTableView DataKeyNames="InstanceID,TemplateID">
                        <Columns>
                            <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" UniqueName="TemplateColumn">
                                <ItemTemplate>
                                    <asp:Button ID="btnView" OnClick="btnView_Click" runat="server" Text="查看" Font-Names="微軟正黑體" Font-Size="Medium" />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn DataField="EmpCode" FilterControlAltText="Filter EmpCode column" HeaderText="職編" UniqueName="EmpCode">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="EmpName" FilterControlAltText="Filter EmpName column" HeaderText="姓名" UniqueName="EmpName">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="TemplateName" FilterControlAltText="Filter DeptName column" HeaderText="護照名稱" UniqueName="TemplateName">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="ThreeStepFinishRateStr" FilterControlAltText="Filter ModifyDate column" HeaderText="完成狀況(已完成/審核中/未完成/總數)" UniqueName="ThreeStepFinishRateStr">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="NecessaryFinishRate" FilterControlAltText="Filter NecessaryFinishRate column" HeaderText="必修完成率" UniqueName="NecessaryFinishRate">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="FinishRate" FilterControlAltText="Filter FinishRate column" HeaderText="總完成率" UniqueName="FinishRate">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="StudentFinishRate" FilterControlAltText="Filter StudentFinishRateStr column" HeaderText="學生完成率" UniqueName="StudentFinishRateStr">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </telerik:GridBoundColumn>
                        </Columns>
                    </MasterTableView>
                    <HeaderStyle Font-Names="微軟正黑體" Font-Size="Medium" />
                    <ItemStyle Font-Names="微軟正黑體" Font-Size="Medium" />
                </telerik:RadGrid>
</telerik:RadPageView>
            <telerik:RadPageView ID="rpvItems" runat="server">
                <table width="100%">
                    <tr>
                        <td align="left">

    <div>

        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Blue" Text="護照名稱："></asp:Label>
        <asp:Label ID="lbPassportName" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Blue"></asp:Label>

    </div>
                        </td>
                        <td align="right">
    <div><asp:Button ID="btnInsReturnMain" runat="server" Text="回清單" Font-Names="微軟正黑體" Font-Size="Medium" OnClick="btnInsReturnMain_Click" /></div>
                        </td>
                    </tr>
                </table>

    <div>

        <asp:CheckBox ID="cbDisplayFinished" runat="server" AutoPostBack="True" Checked="True" OnCheckedChanged="cbDisplayFinished_CheckedChanged" Text="顯示已完成項目" Visible="False" />

    </div>
    <div>
        </div>
                <telerik:RadGrid ID="rgInstance" runat="server" AutoGenerateColumns="False" CellSpacing="0" GridLines="None" OnItemCreated="rgInstance_ItemCreated" Culture="zh-TW" OnNeedDataSource="rgInstance_NeedDataSource" OnPreRender="rgInstance_PreRender" EnableGroupsExpandAll="True" OnItemDataBound="rgInstance_ItemDataBound">
                    <AlternatingItemStyle Font-Size="Medium" />
                    <GroupHeaderItemStyle Font-Bold="True" Font-Size="Medium" />
                    <MasterTableView DataKeyNames="IItemID" EnableGroupsExpandAll="True">
                        <Columns>
                            <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" UniqueName="TemplateColumn">
                                <HeaderStyle Width="50px" />
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnEdit" ImageUrl="~/Images/edit.gif" ToolTip="填寫" runat="server" Text="填寫" OnClick="btnEdit_Click" />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn DataField="ItemName" FilterControlAltText="Filter DeptName column" HeaderText="項目" UniqueName="ItemName">
                                <HeaderStyle Width="500px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="TeacherName" FilterControlAltText="Filter TeacherName column" HeaderText="審核老師" UniqueName="TeacherName">
                            </telerik:GridBoundColumn>
                            <telerik:GridDateTimeColumn DataField="modifydate" FilterControlAltText="Filter createdate column" HeaderText="完成時間" UniqueName="modifydate" DataFormatString="{0:yyyy/MM/dd HH:mm}">
                            </telerik:GridDateTimeColumn>
                        </Columns>
                    </MasterTableView>
                    <HeaderStyle Font-Size="Medium" Font-Names="微軟正黑體" />
                    <FilterItemStyle Font-Size="Medium" />
                    <ActiveItemStyle Font-Names="微軟正黑體" Font-Size="Medium" />
                    <ItemStyle Font-Size="Medium" Font-Names="微軟正黑體" />
                </telerik:RadGrid>


            </telerik:RadPageView>
            <telerik:RadPageView ID="rpvDetail" runat="server">
<div>
        <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Blue" Text="護照名稱："></asp:Label>
        <asp:Label ID="lbPassportName2" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Blue"></asp:Label>
</div>
    <div>
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Blue" Text="項目："></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lbItemName" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Blue"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <div>
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Blue" Text="項目說明："></asp:Label>
                </td>
                <td>

                    <asp:Literal ID="liDesc" runat="server"></asp:Literal>

                </td>
            </tr>
        </table>
        
        
    </div>
    <div>
        <asp:Panel ID="panDisplayTeacher" runat="server">
            <div>
            <asp:Label ID="Label8" runat="server" Text="送審時間："></asp:Label>
            <asp:Label ID="lbSubmitTime" runat="server"></asp:Label>
            </div>

            <div>
            <asp:Label ID="Label9" runat="server" Text="審核老師："></asp:Label>
            <asp:Label ID="lbTeacherName" runat="server"></asp:Label>
                </div>
            <div>
            <asp:Label ID="Label10" runat="server" Text="目前狀態："></asp:Label>
            <asp:Label ID="lbCurrentStatus" runat="server"></asp:Label>
            </div>
            <div>
            <asp:Label ID="Label11" runat="server" Text="審核日期："></asp:Label>
            <asp:Label ID="lbModifyDate" runat="server"></asp:Label>
            </div>
        </asp:Panel>
    </div>
    <table width="98%">
        <tr>
            <td>
    <div>
                <uc1:EduPassportInsItemControl ID="EditContrlS" runat="server" DisplayOnly="False" />
    </div>
    <div>

                <uc1:EduPassportInsItemControl ID="EditContrlT" runat="server" DisplayOnly="False" />

    </div>
    <div>
         <asp:Button ID="btnDetReturnIns" runat="server" OnClick="btnDetReturnIns_Click" Text="回上一頁"  Font-Names="微軟正黑體" Font-Size="Medium"/>
    </div>
            </td>
            <td align="right" valign="top">

                <asp:Panel ID="panRejectHistory" runat="server" Visible="false">
                    <table width="100%">
                        <tr>
                            <td align="center" style="background-color:blue; color:white">
                                <b>駁回紀錄</b>
                            </td>
                        </tr>
                        <tr>
                            <td>

                                <telerik:RadGrid ID="rgRejectReason" runat="server" AutoGenerateColumns="False" CellSpacing="0" Culture="zh-TW" GridLines="None">
                                    <MasterTableView>
                                        <Columns>
                                            <telerik:GridBoundColumn DataField="RejectTime" FilterControlAltText="Filter RejectTime column" HeaderText="駁回時間" UniqueName="RejectTime">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="EmpName" FilterControlAltText="Filter EmpName column" HeaderText="駁回者" UniqueName="EmpName">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Reason" FilterControlAltText="Filter Reason column" HeaderText="駁回原因" UniqueName="Reason">
                                            </telerik:GridBoundColumn>
                                        </Columns>
                                    </MasterTableView>
                                </telerik:RadGrid>

                            </td>
                        </tr>
                    </table>
                </asp:Panel>

            </td>
        </tr>
    </table>

            </telerik:RadPageView>

        </telerik:RadMultiPage>
    
    </div>
    </form>
</body>
</html>
