<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="RecordAdminManage.aspx.cs" Inherits="RecordAdminManage" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<%@ Register src="DeptSelector.ascx" tagname="DeptSelector" tagprefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div>
            <div>
                <table>
                    <tr>
                        <td>

                            <asp:Label ID="Label1" runat="server" Text="撰寫人(職編或姓名):"></asp:Label>

                        </td>
                        <td>

                            <asp:TextBox ID="tbEmpCodeName" runat="server" Width="98px"></asp:TextBox>

                        </td>
                        <td>

                            <asp:Label ID="Label2" runat="server" Text="會議日期:"></asp:Label>

                        </td>
                        <td>

                            <telerik:RadDatePicker ID="rdpRecdate" Runat="server">
                            </telerik:RadDatePicker>

                            ~<telerik:RadDatePicker ID="rdpRecdateEnd" Runat="server">
                            </telerik:RadDatePicker>

                        </td>
                        <td>

                            &nbsp;</td>
                        <td>

                            &nbsp;</td>
                        <td>

                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>

                            <asp:Label ID="Label5" runat="server" Text="會議科別:"></asp:Label>

                        </td>
                        <td colspan="6">

                            <uc3:DeptSelector ID="DeptSelector1" runat="server" WithEmptyDept="true" />

                        </td>
                        
                    </tr>
                    <tr>
                        <td>

                            <asp:Label ID="Label4" runat="server" Text="選擇會議記錄類別："></asp:Label>

                        </td>
                        <td colspan="6">
                            <table>
                                <tr>
                                    <td>
                            <telerik:RadComboBox ID="rcbRecordTemplate" Runat="server" Width="300px">
                            </telerik:RadComboBox>
                                    </td>
                                    <td>

                                        <asp:Label ID="Label3" runat="server" Text="會議主題:"></asp:Label>

                                    </td>
                                    <td>

                                        <asp:TextBox ID="tbKeyword" runat="server"></asp:TextBox>

                                    </td>
                                </tr>
                            </table>


                        </td>

                    </tr>
<tr>
                        <td>

                            <asp:Label ID="Label6" runat="server" Text="簽核人(職編或姓名):"></asp:Label>

                        </td>
                        <td>

                            <asp:TextBox ID="tbSigner" runat="server" Width="98px"></asp:TextBox>

                        </td>
                        <td>

                            <asp:Label ID="Label7" runat="server" Text="狀態:"></asp:Label>

                        </td>
                        <td>

                            <telerik:RadComboBox ID="rcb_status" Runat="server" Culture="zh-TW">
                                <Items>
                                    <telerik:RadComboBoxItem runat="server" Text="所有狀態" />
                                    <telerik:RadComboBoxItem runat="server" Text="暫存未送出" Value="0" />
                                    <telerik:RadComboBoxItem runat="server" Text="已完成未送審" Value="1" />
                                    <telerik:RadComboBoxItem runat="server" Text="審核中" Value="2" />
                                    <telerik:RadComboBoxItem runat="server" Text="審核完成" Value="V" />
                                </Items>
                            </telerik:RadComboBox>

                        </td>
                        <td>

                            &nbsp;</td>
                        <td>

                            &nbsp;</td>
                        <td>

                            &nbsp;</td>
                    </tr>

                    <tr>
                        <td colspan="7">

                            <asp:Button ID="btnQuery" runat="server" OnClick="btnQuery_Click" Text="查詢" />

                        </td>
                    </tr>
                </table>
            </div>
            <div>

            
            <telerik:RadGrid ID="rgMyList" runat="server" AutoGenerateColumns="False" CellSpacing="0" Culture="zh-TW" GridLines="None" OnNeedDataSource="rgMyList_NeedDataSource" OnItemDataBound="rgMyList_ItemDataBound">
                <ClientSettings>
                    <Selecting AllowRowSelect="True" />
                </ClientSettings>
                <MasterTableView DataKeyNames="InstanceID">
                    <Columns>
                        <telerik:GridClientSelectColumn FilterControlAltText="Filter column column" UniqueName="column">
                        </telerik:GridClientSelectColumn>
                        <telerik:GridBoundColumn FilterControlAltText="Filter column3 column" HeaderText="記錄類別" UniqueName="TemplateName" DataField="TemplateName">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn FilterControlAltText="Filter column column" HeaderText="會議主題" UniqueName="Title" DataField="Title">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn FilterControlAltText="Filter column1 column" HeaderText="會議時間" UniqueName="RecordTime" DataField="RecordTime">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="deptname" FilterControlAltText="Filter deptname column" HeaderText="部門" UniqueName="deptname">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="CreaterName" FilterControlAltText="Filter CreaterName column" HeaderText="建立者" UniqueName="CreaterName">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn FilterControlAltText="Filter column2 column" HeaderText="狀態" UniqueName="StatusName" DataField ="StatusName">
                        </telerik:GridBoundColumn>
                        <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" UniqueName="TemplateColumn">
                            <ItemTemplate>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:ImageButton ID="btnEdit" BorderWidth="0" ImageUrl="~/Images/Query.gif" runat="server" ToolTip="查看" OnClick="btnEdit_Click" />
                                        </td>
                                        <td width="20px">
                                            <asp:ImageButton ID="btnAct" BorderWidth="0" ImageUrl="~/Images/t_calendar.gif" runat="server" ToolTip="活動" OnClick="btnAct_Click" />
                                        </td>
                                        <td>
                                            <asp:Button ID="btnDelete" runat="server" Text="刪除" OnClientClick="if(!confirm('確定刪除該筆資料?')){return false;}" OnClick="btnDelete_Click" />
                                        </td>
                                        <td>
                                            <asp:Button ID="btnReturnStatus" Visible ="false" runat="server" Text="退回" OnClientClick="if(!confirm('確定將該筆資料退回上一階段?')){return false;}" OnClick="btnReturnStatus_Click" />
                                        </td>
                                        <td>
                                            <asp:Button ID="btnNextStatus" runat="server" Text="進下一階段" OnClientClick="if(!confirm('確定將該筆資料進入下一階段?')){return false;}" OnClick="btnNextStatus_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                    </Columns>
                </MasterTableView>
            </telerik:RadGrid>
                </div>

    </div>
    <div>
        <table>
            <tr>
                <td>

                    <asp:Label ID="Label8" runat="server" Text="退回原因："></asp:Label>

                </td>
                <td>

                    <asp:TextBox ID="tbRejectReason" runat="server" Width="334px"></asp:TextBox>

                </td>
                <td>

                    <asp:Button ID="btnReject" runat="server" OnClientClick="if(!confirm('確定將勾選的資料退回上一階段?')){return false;}" OnClick="btnReject_Click" Text="退回勾選項目" />

                </td>
            </tr>
        </table>
    </div>
    <div>

        <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
        </telerik:RadWindowManager>

    </div>
</asp:Content>

