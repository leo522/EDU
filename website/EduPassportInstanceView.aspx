<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="EduPassportInstanceView.aspx.cs" Inherits="EduPassportInstanceView" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}
.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}
.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}
    .RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default .rcbReadOnly .rcbInputCellLeft{background-position:0 -88px}.RadComboBox_Default .rcbInputCellLeft{background-position:0 0}.RadComboBox_Default .rcbInputCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbInputCell{width:100%;height:20px;_height:22px;line-height:20px;_line-height:22px;text-align:left;vertical-align:middle}.RadComboBox .rcbInputCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}
    .RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbReadOnly .rcbArrowCellRight{background-position:-162px -176px}.RadComboBox_Default .rcbArrowCellRight{background-position:-18px -176px}.RadComboBox_Default .rcbArrowCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbArrowCell{width:18px}.RadComboBox .rcbArrowCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div>

        <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Blue" Text="學生職編："></asp:Label>
        <asp:Label ID="lbEmpCode" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Blue"></asp:Label>

    </div>
    <div>

        <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Blue" Text="學生姓名："></asp:Label>
        <asp:Label ID="lbEmpName" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Blue"></asp:Label>

    </div>

    <div>

        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Blue" Text="護照名稱："></asp:Label>
        <asp:Label ID="lbPassportName" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Blue"></asp:Label>

    </div>
    <div>

        <asp:CheckBox ID="cbDisplayFinished" runat="server" AutoPostBack="True" Checked="True" OnCheckedChanged="cbDisplayFinished_CheckedChanged" Text="顯示已完成項目" />

    </div>
    <div>

                <telerik:RadGrid ID="rgList" runat="server" AutoGenerateColumns="False" CellSpacing="0" GridLines="None" OnItemCreated="rgList_ItemCreated" Culture="zh-TW" OnNeedDataSource="rgList_NeedDataSource" OnPreRender="rgList_PreRender" EnableGroupsExpandAll="True" OnItemDataBound="rgList_ItemDataBound">
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
                            <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" UniqueName="TemplateColumn">
                                <HeaderStyle Width="50px" />
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnReturnEmpty" ImageUrl="~/Images/getback.jpg" ToolTip="退回" runat="server" Text="退回" OnClick="btnReturnEmpty_Click" />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                        </Columns>
                    </MasterTableView>
                    <HeaderStyle Font-Size="Medium" />
                    <FilterItemStyle Font-Size="Medium" />
                    <ItemStyle Font-Size="Medium" />
                </telerik:RadGrid>
    
    </div>

</asp:Content>

