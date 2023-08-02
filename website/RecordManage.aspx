<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="RecordManage.aspx.cs" Inherits="RecordManage" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register src="DeptSelector.ascx" tagname="DeptSelector" tagprefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div>
    <asp:Panel ID="Panel1" runat="server" GroupingText="建立會議記錄">
        <asp:Label ID="Label2" runat="server" Font-Bold="True" ForeColor="Red" Text="106年11月起不在使用門診/診斷/手術/麻醉/查房 醫療/教學 記錄表，不在自動列入醫療與教學並行時數計算"></asp:Label>
        <br />
        <asp:Label ID="Label1" runat="server" Text="選擇會議記錄類別："></asp:Label>
        <telerik:RadComboBox ID="rcbRecordTemplate" Runat="server" Width="300px">
        </telerik:RadComboBox>
        <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="建立會議記錄" />
    </asp:Panel>
        </div>
    <div>
        <telerik:RadTabStrip ID="RadTabStrip1" runat="server" MultiPageID="RadMultiPage1" SelectedIndex="0">
            <Tabs>
                <telerik:RadTab runat="server" Text="我建立的會議記錄" PageViewID="RadPageView1" Selected="True">
                </telerik:RadTab>
                <telerik:RadTab runat="server" Text="會議記錄查詢" PageViewID="RadPageView2">
                </telerik:RadTab>
            </Tabs>
</telerik:RadTabStrip>
        <telerik:RadMultiPage ID="RadMultiPage1" Runat="server" SelectedIndex="0" Width="98%">
            <telerik:RadPageView ID="RadPageView1" runat="server">
<asp:Panel ID="Panel2" runat="server" GroupingText="我已建立的會議記錄">
            <div>

                <asp:Button ID="btnSelect" runat="server" OnClick="btnSelect_Click" Text="帶入選取的會議記錄" />

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
                        <telerik:GridBoundColumn DataField="DeptName" FilterControlAltText="Filter DeptName column" HeaderText="部門" UniqueName="DeptName">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn FilterControlAltText="Filter column2 column" HeaderText="狀態" UniqueName="StatusName" DataField ="StatusName">
                        </telerik:GridBoundColumn>
                        <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn1 column" HeaderText="已連結活動" UniqueName="TemplateColumn1">
                            <ItemTemplate>
                                <asp:ImageButton ID="btnAct" BorderWidth="0" ImageUrl="~/Images/t_calendar.gif" runat="server" ToolTip="活動" OnClick="btnAct_Click" />
                                <asp:ImageButton ID="btnDisconn" BorderWidth="0" ImageUrl="~/Images/disconn.png" runat="server" ToolTip="斷開" OnClientClick="if(!confirm('確定解除該筆會議記錄跟活動的連結?')){return false;}" OnClick="btnDisconn_Click" />
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" UniqueName="TemplateColumn">
                            <ItemTemplate>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:ImageButton ID="btnGetBack" BorderWidth="0" ImageUrl="~/Images/getback.jpg" runat="server" ToolTip="終止審核" OnClick="btnGetBack_Click" />
                                        </td>
                                        <td>
                                            <asp:ImageButton ID="btnEdit" BorderWidth="0" ImageUrl="~/Images/edit-3.gif" runat="server" ToolTip="編輯" OnClick="btnEdit_Click" />
                                        </td>
                                        <td>
                                            <asp:ImageButton ID="btnDel" BorderWidth="0" OnClientClick="if(!confirm('確定刪除該筆會議記錄?')){return false;}" ImageUrl="~/Images/delete.gif" runat="server" ToolTip="刪除" OnClick="btnDel_Click" />
                                        </td>

                                    </tr>
                                </table>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                    </Columns>
                </MasterTableView>
            </telerik:RadGrid>
                </div>
        </asp:Panel>
            </telerik:RadPageView>
            <telerik:RadPageView ID="RadPageView2" runat="server">
    <asp:Panel ID="Panel3" runat="server" GroupingText="會議記錄查詢">
        <div>
            <div>
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="Label9" runat="server" Text="*會議日期:"></asp:Label>
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
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
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
                                        <telerik:RadComboBox ID="rcbRecordTemplate0" Runat="server" Width="300px">
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
                            <asp:CheckBox ID="cbMySign" runat="server" Text="我簽過的記錄" />
                        </td>
                        <td>
                            <asp:CheckBox ID="cbMyJoin" runat="server" Text="我出席過的會議(含補閱)紀錄" />
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            <asp:Label ID="Label8" runat="server" Text="撰寫人(職編或姓名):"></asp:Label>
                            <asp:TextBox ID="tbEmpCodeName" runat="server" Width="98px"></asp:TextBox>
                        </td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="7">
                            <asp:Button ID="btnQuery" runat="server" OnClick="btnQuery_Click" Text="查詢" />
                        </td>
                    </tr>
                </table>
            </div>
            <div>
                <telerik:RadGrid ID="rgMyList0" runat="server" AutoGenerateColumns="False" CellSpacing="0" Culture="zh-TW" GridLines="None" OnItemDataBound="rgMyList0_ItemDataBound" >
                    <ClientSettings>
                        <Selecting AllowRowSelect="True" />
                    </ClientSettings>
                    <MasterTableView DataKeyNames="InstanceID">
                        <Columns>
                            <telerik:GridClientSelectColumn FilterControlAltText="Filter column column" UniqueName="column">
                            </telerik:GridClientSelectColumn>
                            <telerik:GridBoundColumn DataField="TemplateName" FilterControlAltText="Filter column3 column" HeaderText="記錄類別" UniqueName="TemplateName">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Title" FilterControlAltText="Filter column column" HeaderText="會議主題" UniqueName="Title">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="RecordTime" FilterControlAltText="Filter column1 column" HeaderText="會議時間" UniqueName="RecordTime">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="deptname" FilterControlAltText="Filter deptname column" HeaderText="部門" UniqueName="deptname">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="CreaterName" FilterControlAltText="Filter CreaterName column" HeaderText="建立者" UniqueName="CreaterName">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="StatusName" FilterControlAltText="Filter column2 column" HeaderText="狀態" UniqueName="StatusName">
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" UniqueName="TemplateColumn">
                                <ItemTemplate>
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:ImageButton ID="btnEdit0" runat="server" BorderWidth="0" ImageUrl="~/Images/Query.gif" OnClick="btnEdit_Click" ToolTip="查看" />
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
    </asp:Panel>
            </telerik:RadPageView>
        </telerik:RadMultiPage>

        

    </div>
    <div>

        <telerik:RadWindowManager ID="RadWindowManager1" runat="server">

        </telerik:RadWindowManager>

    </div>
</asp:Content>

