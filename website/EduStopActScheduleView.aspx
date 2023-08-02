<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="EduStopActScheduleView.aspx.cs" Inherits="EduStopActScheduleView" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
.RadGrid_Default{border:1px solid #828282;background-color:white;color:#333;font-family:"Segoe UI",Arial,Helvetica,sans-serif;font-size:12px;line-height:16px}.RadGrid_Default{border:1px solid #828282;background-color:white;color:#333;font-family:"Segoe UI",Arial,Helvetica,sans-serif;font-size:12px;line-height:16px}.RadGrid_Default .rgMasterTable{font-family:"Segoe UI",Arial,Helvetica,sans-serif;font-size:12px;line-height:16px}.RadGrid .rgMasterTable{border-collapse:separate;border-spacing:0}.RadGrid_Default .rgMasterTable{font-family:"Segoe UI",Arial,Helvetica,sans-serif;font-size:12px;line-height:16px}.RadGrid .rgMasterTable{border-collapse:separate;border-spacing:0}.RadGrid table.rgMasterTable tr .rgExpandCol{padding-left:0;padding-right:0;text-align:center}.RadGrid table.rgMasterTable tr .rgExpandCol{padding-left:0;padding-right:0;text-align:center}.RadGrid_Default .rgHeader{color:#333}.RadGrid_Default .rgHeader{border:0;border-bottom:1px solid #828282;background:#eaeaea 0 -2300px repeat-x url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Grid.sprite.gif')}.RadGrid .rgHeader{padding-top:5px;padding-bottom:4px;text-align:left;font-weight:normal}.RadGrid .rgHeader{padding-left:7px;padding-right:7px}.RadGrid .rgHeader{cursor:default}.RadGrid_Default .rgHeader{color:#333}.RadGrid_Default .rgHeader{border:0;border-bottom:1px solid #828282;background:#eaeaea 0 -2300px repeat-x url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Grid.sprite.gif')}.RadGrid .rgHeader{padding-top:5px;padding-bottom:4px;text-align:left;font-weight:normal}.RadGrid .rgHeader{padding-left:7px;padding-right:7px}.RadGrid .rgHeader{cursor:default}
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <table width="100%">
<tr>
<td width="15%" bgcolor="#DEDEE9" align="right">
    <asp:Label ID="Label2" runat="server" Font-Bold="False" ForeColor="Red" 
        Text="*"></asp:Label>
    <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="公告科室："></asp:Label>
</td>
<td width="85%" align="left">
    <asp:Label ID="lbDept" runat="server"></asp:Label>
</td>
</tr>
<tr>
<td width="10%" bgcolor="#DEDEE9" align="right">
    <asp:Label ID="Label3" runat="server" Font-Bold="False" ForeColor="Red" 
        Text="*"></asp:Label>
    <asp:Label ID="Label4" runat="server" Font-Bold="True" Text="活動類型："></asp:Label>
</td>
<td width="90%" align="left">
<asp:Label ID="lbActType" runat="server"></asp:Label>
</td>
</tr>
<tr>
<td width="10%" bgcolor="#DEDEE9" align="right">
    <asp:Label ID="Label5" runat="server" Font-Bold="False" ForeColor="Red" 
        Text="*"></asp:Label>
    <asp:Label ID="Label6" runat="server" Font-Bold="True" Text="活動主題："></asp:Label>
</td>
<td width="90%" align="left">
    <asp:Label ID="lbActName" runat="server"></asp:Label>
</td>
</tr>
<tr>
<td width="10%" bgcolor="#DEDEE9" align="right">
    <asp:Label ID="Label10" runat="server" Font-Bold="True" Text="活動規模："></asp:Label>
</td>
<td width="90%" align="left">
    <asp:Label ID="lbActRange" runat="server"></asp:Label>
</td>
</tr>
<tr>
<td width="10%" bgcolor="#DEDEE9" align="right">
    <asp:Label ID="Label11" runat="server" Font-Bold="False" ForeColor="Red" 
        Text="*"></asp:Label>
    <asp:Label ID="Label12" runat="server" Font-Bold="True" Text="舉辦日期："></asp:Label>
</td>
<td width="90%" align="left">
    <asp:Label ID="lbActDate" runat="server"></asp:Label>
                                
                                
                                
                                
</td>
</tr>
<tr>
<td width="10%" bgcolor="#DEDEE9" align="right">
    <asp:Label ID="Label14" runat="server" Font-Bold="True" Text="舉辦地點："></asp:Label>
</td>
<td width="90%" align="left">
<asp:Panel ID="panLocation" runat="server">
    <asp:Label ID="lbActLocation" runat="server"></asp:Label>
</asp:Panel>
</td>
</tr>
<tr>
<td width="10%" bgcolor="#DEDEE9" align="right">
    <asp:Label ID="Label7" runat="server" Font-Bold="True" Text="主持人/主講人："></asp:Label>
</td>
<td width="90%" align="left">
<asp:Panel ID="Panel1" runat="server">
    <asp:Literal ID="liTeacher" runat="server"></asp:Literal>
</asp:Panel>
</td>
</tr>
<tr>
<td width="10%" bgcolor="#DEDEE9" align="right">
    <asp:Label ID="Label8" runat="server" Font-Bold="True" Text="建立者："></asp:Label>
</td>
<td width="90%" align="left">
<asp:Panel ID="Panel2" runat="server">
    <asp:Label ID="lbCreater" runat="server"></asp:Label>
</asp:Panel>
</td>
</tr>
<tr>
<td width="10%" bgcolor="#DEDEE9" align="right">
    <asp:Label ID="Label17" runat="server" Font-Bold="False" ForeColor="Red" 
        Text="*"></asp:Label>
    <asp:Label ID="Label16" runat="server" Font-Bold="True" Text="備註說明："></asp:Label>
</td>
<td width="90%" align="left">
    <asp:TextBox ID="tbDes" runat="server" Height="110px" TextMode="MultiLine" 
        Width="537px" ReadOnly="True"></asp:TextBox>
</td>
</tr>
<tr>
<td width="10%" bgcolor="#DEDEE9" align="right">
    <asp:Label ID="Label9" runat="server" Font-Bold="True" Text="附件檔案："></asp:Label>
</td>
<td width="90%" align="left">
<asp:Panel ID="panEditAttachment" runat="server" Visible = "false">
                                
                                    <telerik:RadGrid ID="rgAttachment" 
        runat="server" AutoGenerateColumns="False" 
                                        CellSpacing="0" Culture="zh-TW" 
        GridLines="None" OnNeedDataSource="rgAttachment_NeedDataSource" OnItemDataBound="rgAttachment_ItemDataBound">
                                        <ClientSettings>
                                            <Selecting AllowRowSelect="True" />
                                        </ClientSettings>
                                        <MasterTableView DataKeyNames="ActAttachmentID" 
                                            NoMasterRecordsText="沒有附件">
                                            <CommandItemSettings ExportToPdfText="Export to PDF" />
                                            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" 
                                                Visible="False">
                                            </RowIndicatorColumn>
                                            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" 
                                                Visible="True" Created="True">
                                            </ExpandCollapseColumn>
                                            <Columns>

                                                    <telerik:GridTemplateColumn DataField="ActAttachmentID" FilterControlAltText="Filter Att column" HeaderText="附件" UniqueName="Att">
                                                        <ItemTemplate>
                                                            <asp:HyperLink Target="_blank" ID="lbtnAtt" Text='<%# Eval("Name")%>' runat="server"></asp:HyperLink></ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                            </Columns>
                                            <EditFormSettings>
                                                <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                                </EditColumn>
                                            </EditFormSettings>
                                        </MasterTableView>
                                        <FilterMenu EnableImageSprites="False">
                                        </FilterMenu>
                                    </telerik:RadGrid>
</asp:Panel>

                                
</td>
</tr>         

<tr>
<td colspan="2">
                    <asp:Button ID="btnReturn" runat="server" onclick="btnReturn_Click" 
                        Text="返回行事曆" Visible="False" />                
                
    
    &nbsp;&nbsp;                
                
    
    <asp:Button ID="btnEdit" runat="server" onclick="btnEdit_Click" Text="編輯公告" 
        Visible="False" />
    
    &nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnCopy" runat="server" onclick="btnCopy_Click" Text="複製公告" Visible="False" />
    
                    <asp:Button ID="btnBooking" runat="server" OnClick="btnBooking_Click" Text="報名" Visible="False" />
                    <asp:Button ID="btnBookingList" runat="server" OnClick="btnBookingList_Click" Text="報名名單" Visible="False" />
    
    </td>
</tr>
</table>


</asp:Content>

