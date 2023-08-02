<%@ Page Title="" Language="C#" MasterPageFile="~/Empty.master" AutoEventWireup="true" CodeFile="RecordSignInList.aspx.cs" Inherits="RecordSignInList" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
                        <asp:Timer ID="Timer1" runat="server" Interval="10000" OnTick="Timer1_Tick" Enabled="False">
    </asp:Timer>       
     <asp:UpdatePanel ID="upPan" runat="server">
            <ContentTemplate>    
    <div>




                        <telerik:RadListView ID="rlvUndoItems" DataKeyNames="EmpCode,InstanceID" AllowPaging="false" runat="server" Width="700px" ItemPlaceholderID="PlaceHolder1" Skin="MetroTouch">
                            <LayoutTemplate>
                            <div style="text-align: center; vertical-align:top;overflow:auto;padding:12px 10px 12px 10px;height:auto;">
                                 <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                            </div>

                            </LayoutTemplate>
                            <ItemTemplate>
                                <div style="float:left;
        width: 90px;
        text-align: center;
        margin-top:1px;
        margin-bottom:1px;
        height:20px;
        ">

                                    <img src="Images/operation_ok.gif" alt="" />
                                    <asp:Label ID="lbName" Font-Size="Medium" runat="server"  Text='<%# Eval("EmpName") %>' ToolTip='<%# Eval("RoleName") %>'></asp:Label>
                                    <asp:Label ID="lbCode" runat="server" Text='<%# Eval("EmpCode") %>' Visible ="false"></asp:Label>
                                    <asp:ImageButton runat="server" OnClientClick="if(!confirm('確認刪除?')){return false;}" ImageUrl="~/Images/delete.gif" ID="ibtnDel" OnClick="ibtnDel_Click"/>
                                </div>
                            </ItemTemplate>
                        </telerik:RadListView>
    </div>
            </ContentTemplate>
        </asp:UpdatePanel>
</asp:Content>

