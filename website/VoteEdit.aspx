<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="VoteEdit.aspx.cs" Inherits="VoteEdit" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            height: 362px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table>
        <tr>
            <td>

                <asp:Label ID="Label1" runat="server" Text="投票項目："></asp:Label>

            </td>
            <td>

                <asp:TextBox ID="tbVoteName" runat="server" Width="236px"></asp:TextBox>

            </td>

        </tr>
        <tr>
            <td>

                <asp:Label ID="Label2" runat="server" Text="開始日期："></asp:Label>

            </td>
            <td>

                <telerik:RadDatePicker ID="rdpSdate" Runat="server">
                </telerik:RadDatePicker>

            </td>

        </tr>
        <tr>
            <td>

                <asp:Label ID="Label3" runat="server" Text="結束日期："></asp:Label>

            </td>
            <td>

                <telerik:RadDatePicker ID="rdpEdate" Runat="server">
                </telerik:RadDatePicker>

            </td>

        </tr>
        <tr>
            <td class="auto-style1">

                <asp:Label ID="Label4" runat="server" Text="票選注意事項："></asp:Label>

            </td>
            <td class="auto-style1">

                <telerik:RadEditor ID="reHeader" Runat="server" Height="356px" Width="751px">
                </telerik:RadEditor>

            </td>

        </tr>
        <tr>
            <td>

                <asp:Label ID="Label5" runat="server" Text="票數設定："></asp:Label>

            </td>
            <td>
                <telerik:RadGrid ID="rgGroups" runat="server" AutoGenerateColumns="False" CellSpacing="0" Culture="zh-TW" GridLines="None" OnItemDataBound="rgGroups_ItemDataBound" OnNeedDataSource="rgGroups_NeedDataSource">
                    <MasterTableView DataKeyNames="GroupName">
                        <Columns>
                            <telerik:GridBoundColumn DataField="GroupName" FilterControlAltText="Filter GroupName column" HeaderText="項目" UniqueName="GroupName">
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" HeaderText="設定" UniqueName="TemplateColumn">
                                <ItemTemplate>
                                    <table>
                                        <tr>
                                            <td><asp:RadioButton runat="server" ID="rbChoiceTypeRate" Text="比例" GroupName="ChoiceType" /></td>
                                            <td>
                                                <telerik:RadNumericTextBox runat="server" ID="rntbChoiceRate"></telerik:RadNumericTextBox>
                                            </td>
                                            <td><asp:RadioButton runat="server" ID="rbChoiceTypeNum" Text="票數" GroupName="ChoiceType" /></td>
                                            <td>
                                                <telerik:RadNumericTextBox runat="server" ID="rntbChoiceNum">
                                                    <NumberFormat DecimalDigits="0" />
                                                </telerik:RadNumericTextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>
            </td>
        </tr>

        <tr>
            <td>

            </td>
            <td>
                <table>
                    <tr>
                        <td>

                            <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" style="height: 21px" Text="儲存" />

                        </td>
                        <td>

                        </td>
                        <td>

                            <asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click" Text="回上一頁" />

                        </td>
                    </tr>
                </table>
            </td>

        </tr>
    </table>
</asp:Content>

