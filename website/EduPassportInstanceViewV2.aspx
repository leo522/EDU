<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="EduPassportInstanceViewV2.aspx.cs" Inherits="EduPassportInstanceViewV2" %>

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
<link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css">
<script src="//code.jquery.com/jquery-1.10.2.js"></script>
<script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
<script>
    $(function () { $("#adv").accordion({ collapsible: true, active: false }); });
</script>    
    
    <style type="text/css">  
        .RadMenu_Default .rmText  
        {  
            font-size:medium !important;  
        }  
        .auto-style1 {
            width: 84px;
        }

    .WrappingItem 
    { 
      white-space: normal; 
    } 

    </style> 

    <div>
        
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Blue" Text="護照名稱："></asp:Label>
        <asp:Label ID="lbPassportName" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Blue"></asp:Label>

    </div>
    <div>
        <table>
            <tr>
                <td>
                    <asp:Panel ID="Panel1" runat="server" GroupingText="必修" Width="200px">
                        <table width="100%">
                            <tr>
                                <td>

                                    <asp:Label ID="Label6" runat="server" Text="完成"></asp:Label>

                                </td>
                                <td>

                                    <asp:Label ID="lbNecessaryFinishRate" runat="server" ForeColor="Blue"></asp:Label>

                                </td>
                            </tr>
                            <tr>
                                <td>

                                    <asp:Label ID="Label7" runat="server" Text="未完成"></asp:Label>

                                </td>
                                <td>

                                    <asp:Label ID="lbNecessaryNotFinishRate" runat="server" ForeColor="Blue"></asp:Label>

                                </td>
                            </tr>
                            <tr>
                                <td>

                                    <asp:Label ID="Label8" runat="server" Text="待審"></asp:Label>

                                </td>
                                <td>

                                    <asp:Label ID="lbNecessaryWaitingRate" runat="server" ForeColor="Blue"></asp:Label>

                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
                <td>
                    <asp:Panel ID="Panel2" runat="server" GroupingText="選修" Width="200px">
                        <table width="100%">
                            <tr>
                                <td>

                                    <asp:Label ID="Label9" runat="server" Text="完成"></asp:Label>

                                </td>
                                <td>

                                    <asp:Label ID="lbNonNecessaryFinishRate" runat="server" ForeColor="Blue"></asp:Label>

                                </td>
                            </tr>
                            <tr>
                                <td>

                                    <asp:Label ID="Label10" runat="server" Text="未完成"></asp:Label>

                                </td>
                                <td>

                                    <asp:Label ID="lbNonNecessaryNotFinishRate" runat="server" ForeColor="Blue"></asp:Label>

                                </td>
                            </tr>
                            <tr>
                                <td>

                                    <asp:Label ID="Label11" runat="server" Text="待審"></asp:Label>

                                </td>
                                <td>

                                    <asp:Label ID="lbNonNecessaryWaitingRate" runat="server" ForeColor="Blue"></asp:Label>

                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
        </table>
        <div style="display:none">
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="必修完成度：" ForeColor="Blue"></asp:Label>
                </td>
                <td>

                                    <asp:Label ID="lbNecessaryRate" runat="server" ForeColor="Blue"></asp:Label>

                                </td>
                <td width="10px"></td>
                <td class="auto-style1">
                    <asp:Label ID="Label3" runat="server" Text="選修完成度：" ForeColor="Blue"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lbChoiceRate" runat="server" ForeColor="Blue"></asp:Label>
                </td>
                <td width="10px"></td>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="整體完成率：" ForeColor="Blue"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lbAllRate" runat="server" ForeColor="Blue"></asp:Label>
                </td>
            </tr>
        </table>
            </div>
    </div>
    <div id="adv">
        <h3><asp:Label ID="Label12" runat="server" Font-Bold="True" Font-Size="Large" Text="護照說明"></asp:Label></h3>
        <div>
            <asp:Literal ID="liDesc" runat="server"></asp:Literal>
        </div>

    </div>
    <div>
        <table>
            <tr>
                <td valign="top" style="max-width:250px">
                    <telerik:RadMenu  ID="rmGroups" Runat="server" Flow="Vertical" OnItemClick="RadMenu1_ItemClick" Width="250px" Skin="Telerik" CssClass="WrappingItem">
                    </telerik:RadMenu>
                </td>
                <td>
                    <asp:Panel runat="server" ID ="panUndo" Width="700px" GroupingText="未完成">
                    
                        <telerik:RadListView ID="rlvUndoItems" DataKeyNames="IItemID" AllowPaging="false" runat="server" Width="700px" ItemPlaceholderID="PlaceHolder1" OnItemDataBound="rlvItems_ItemDataBound" Skin="MetroTouch">
                            <LayoutTemplate>
                            <div style="text-align: center; vertical-align:top;overflow:auto;padding:12px 10px 12px 10px;height:auto;">
                                 <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                            </div>

                            </LayoutTemplate>
                            <ItemTemplate>
                                <div style="float:left;
        width: 120px;
        text-align: center;
        margin-top:20px;
        margin-bottom:20px;
        height:60px;
        ">
                                    <asp:ImageButton Width="45px" ID="btnEdit" ImageUrl="~/Images/edit.gif" ToolTip="填寫" runat="server" Text="填寫" OnClick="btnEdit_Click" />
                                    <br />
                                    <asp:Label ID="lbItemName" Font-Size="Medium" runat="server"  Text='<%# Eval("ItemName") %>' ToolTip='<%# Eval("ItemName") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </telerik:RadListView>
                    </asp:Panel>

                    <asp:Panel runat="server" ID ="panWaiting" Width="700px" GroupingText="等待審核中">
                    
                        <telerik:RadListView ID="rlvWaitingItems" DataKeyNames="IItemID" AllowPaging="false" runat="server" Width="700px" ItemPlaceholderID="PlaceHolder1" OnItemDataBound="rlvItems_ItemDataBound" Skin="MetroTouch">
                            <LayoutTemplate>
                            <div style="text-align: center; vertical-align:top;overflow:auto;padding:12px 10px 12px 10px;height:auto;">
                                 <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                            </div>

                            </LayoutTemplate>
                            <ItemTemplate>
                                <div style="float:left;
        width: 120px;
        text-align: center;
        margin-top:20px;
        margin-bottom:20px;
        height:60px;
        ">
                                    <asp:ImageButton Width="45px" ID="btnEdit" ImageUrl="~/Images/edit.gif" ToolTip="填寫" runat="server" Text="填寫" OnClick="btnEdit_Click" />
                                    <br />
                                    <asp:Label ID="lbItemName" Font-Size="Medium" runat="server"  Text='<%# Eval("ItemName") %>' ToolTip='<%# Eval("ItemName") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </telerik:RadListView>
                    </asp:Panel>

                   <asp:Panel runat="server" ID ="panDone" Width="700px" GroupingText="已完成">
                    
                        <telerik:RadListView ID="rlvDoneItems" DataKeyNames="IItemID" AllowPaging="false" runat="server" Width="700px" ItemPlaceholderID="PlaceHolder1" OnItemDataBound="rlvItems_ItemDataBound" Skin="MetroTouch">
                            <LayoutTemplate>
                            <div style="text-align: center; vertical-align:top;overflow:auto;padding:12px 10px 12px 10px;height:auto;">
                                 <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                            </div>

                            </LayoutTemplate>
                            <ItemTemplate>
                                <div style="float:left;
        width: 120px;
        text-align: center;
        margin-top:20px;
        margin-bottom:20px;
        height:60px;
        ">
                                    <asp:ImageButton Width="45px" ID="btnEdit" ImageUrl="~/Images/edit.gif" ToolTip="填寫" runat="server" Text="填寫" OnClick="btnEdit_Click" />
                                    <br />
                                    <asp:Label ID="lbItemName" Font-Size="Medium" runat="server"  Text='<%# Eval("ItemName") %>' ToolTip='<%# Eval("ItemName") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </telerik:RadListView>
                    </asp:Panel>

                </td>
            </tr>
        </table>
    </div>
</asp:Content>

