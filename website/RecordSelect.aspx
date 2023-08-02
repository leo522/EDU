<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="RecordSelect.aspx.cs" Inherits="RecordSelect" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<%@ Register src="DeptSelector.ascx" tagname="DeptSelector" tagprefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div>
        <asp:Panel ID="panExists" runat="server" GroupingText="已連結會議記錄">
            <div>
                <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="新增本活動會議記錄" Visible="False" />
            </div>
            <telerik:RadGrid ID="rgExistList" runat="server" AutoGenerateColumns="False" CellSpacing="0" Culture="zh-TW" GridLines="None" OnNeedDataSource="rgExistList_NeedDataSource" OnItemDataBound="rgExistList_ItemDataBound">
                <ClientSettings>
                    <Selecting AllowRowSelect="False" />
                </ClientSettings>
                <MasterTableView DataKeyNames="InstanceID">
                    <Columns>
                        <telerik:GridBoundColumn FilterControlAltText="Filter column3 column" HeaderText="記錄類別" UniqueName="TemplateName" DataField="TemplateName">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn FilterControlAltText="Filter column column" HeaderText="會議主題" UniqueName="Title" DataField="Title">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn FilterControlAltText="Filter column1 column" HeaderText="會議時間" UniqueName="RecordTime" DataField="RecordTime">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn FilterControlAltText="Filter column2 column" HeaderText="狀態" UniqueName="StatusName" DataField ="StatusName">
                        </telerik:GridBoundColumn>
                        <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn1 column" HeaderText="已連結" UniqueName="TemplateColumn1">
                            <ItemTemplate>
                                <asp:ImageButton ID="btnDisconn0" BorderWidth="0" ImageUrl="~/Images/disconn.png" runat="server" ToolTip="斷開" OnClientClick="if(!confirm('確定解除該筆會議記錄跟活動的連結?')){return false;}" OnClick="btnDisconn_Click" />
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" UniqueName="TemplateColumn">
                            <ItemTemplate>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:ImageButton ID="btnEdit0" BorderWidth="0" ImageUrl="~/Images/edit-3.gif" runat="server" ToolTip="編輯" OnClick="btnEdit_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                    </Columns>
                </MasterTableView>
            </telerik:RadGrid>

        </asp:Panel>
        <asp:Panel ID="panSearch" runat="server" GroupingText="選擇會議記錄">
            <div>

                <asp:Button ID="btnSelect" runat="server" OnClick="btnSelect_Click" Text="帶入選取的會議記錄" />

                &nbsp;&nbsp;&nbsp;&nbsp;
                
            </div>
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
                        <td colspan="7">

                            <asp:Button ID="btnQuery" runat="server" OnClick="btnQuery_Click" Text="查詢" />

                        </td>
                    </tr>
                </table>
            </div>
            <div>

            
            <telerik:RadGrid ID="rgMyList" runat="server" AutoGenerateColumns="False" CellSpacing="0" Culture="zh-TW" GridLines="None" OnNeedDataSource="rgMyList_NeedDataSource" OnItemDataBound="rgMyList_ItemDataBound" AllowMultiRowSelection="True">
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
                                        <td>
                                            <asp:Button ID="btnDelete" runat="server" Text="刪除" OnClientClick="if(!confirm('確定刪除該筆資料?')){return false;}" OnClick="btnDelete_Click" />
                                        </td>
                                        <td>
                                            <asp:Button ID="btnReturnStatus" runat="server" Text="退回" OnClientClick="if(!confirm('確定將該筆資料退回上一階段?')){return false;}" OnClick="btnReturnStatus_Click" />
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

    </div>
    <div>

                <asp:Button ID="btnReturn" runat="server" OnClick="btnReturn_Click" Text="回行事曆" />

    </div>
    <div>

        <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
        </telerik:RadWindowManager>

    </div>
</asp:Content>

