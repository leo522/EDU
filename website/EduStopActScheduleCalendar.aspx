<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="EduStopActScheduleCalendar.aspx.cs" Inherits="EduStopActScheduleCalendar" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<%@ Register src="DeptSelector.ascx" tagname="DeptSelector" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

<script language="javascript" type="text/javascript">

    function printDiv() {

        var divToPrint = document.getElementById('<%= htmlContent.ClientID %>');
        var lb = document.getElementById('<%= lbDept.ClientID%>');
        var newWin = window.open('EduStopActScheduleCalendarPrint.aspx?Dept=' + lb.innerText, 'PrintWindow', config = 'width=1024,height=768');

        //newWin.focus();
        //newWin.print();
        //newWin.close();

        //setTimeout(function () { newWin.close(); }, 30);

    }

</script>

<table width="100%">
<tr>
<td width="100px" align="center" valign="top" style="min-width:100px">
<table width="80%">
<tr>
<td style="background-color:Aqua">&nbsp;</td>
</tr>
<tr>
<td align="left">
    <asp:LinkButton ID="btnAdd" runat="server" 
        PostBackUrl="~/EduStopActScheduleAdd.aspx">新增活動</asp:LinkButton>
    </td>
</tr>
<tr>
<td align="left">
    <asp:LinkButton ID="btnCalendar" runat="server" 
        PostBackUrl="~/EduStopActScheduleCalendar.aspx">行事曆</asp:LinkButton>
    </td>
</tr>
</table>
</td>
<td>
<asp:Panel ID="panDept" runat="server">
        <asp:Label ID="Label29" runat="server" Text="部門："></asp:Label>
        <uc1:DeptSelector ID="DeptSelector1" runat="server" />
        &nbsp;<asp:CheckBox ID="cbShowAll" runat="server" Text="顯示所有子部門資料" />
&nbsp;<asp:Button ID="btnQuery" runat="server" onclick="btnQuery_Click" Text="查詢" />
        &nbsp;
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" OnClientClick="printDiv();return false;" Text="列印" />
</asp:Panel>
    <asp:Label ID="Label30" runat="server" Text="記錄圖示說明："></asp:Label>
    <asp:Image ID="Image4" runat="server" ImageUrl="~/Images/edit-3.gif" />
    <asp:Label ID="Label34" runat="server" Text="未完成"></asp:Label>
    <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/edit-1_2.gif" />
    <asp:Label ID="Label31" runat="server" Text="未送審"></asp:Label>
    <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/edit-2_2.gif" />
    <asp:Label ID="Label32" runat="server" Text="審核中"></asp:Label>
    <asp:Image ID="Image3" runat="server" ImageUrl="~/Images/edit-V_2.gif" />
    <asp:Label ID="Label33" runat="server" Text="已完成審核"></asp:Label>
    <br />
    <div id="htmlContent" runat="server">
        <div align="right">科別：<asp:Label ID="lbDept" runat="server"></asp:Label>
        </div>
        <telerik:RadScheduler ID="rsList" runat="server" Culture="zh-TW" 
            EnableRecurrenceSupport="False" SelectedView="MonthView" 
            StartEditingInAdvancedForm="False" 
            onnavigationcomplete="rsList_NavigationComplete" OverflowBehavior="Expand" 
            Height="" RowHeight="" ontimeslotcreated="rsList_TimeSlotCreated" 
            AllowDelete="False" AllowEdit="False" AllowInsert="False" 
            onappointmentcreated="rsList_AppointmentCreated" Skin="Simple">
            <AdvancedForm DateFormat="yyyy/MM/dd" TimeFormat="HH:mm" Modal="True" />
            <Localization AdvancedAllDayEvent="全天" AdvancedCalendarCancel="取消" 
                AdvancedCalendarOK="確定" AdvancedCalendarToday="今天" AdvancedClose="" 
                AdvancedDaily="每日" AdvancedDay="日" AdvancedDays="日" AdvancedDescription="內容" 
                AdvancedDone="完成" AdvancedEditAppointment="編輯行事曆" AdvancedFrom="開始時間" 
                AdvancedNewAppointment="新增行事曆" AdvancedTo="結束時間" 
                ContextMenuAddAppointment="新增行事曆" ContextMenuDelete="刪除" 
                ContextMenuEdit="編輯" AdvancedSubject="主旨" Cancel="取消" ConfirmCancel="取消" 
                ConfirmDeleteText="確定刪除本項行程?" ConfirmDeleteTitle="確定刪除" HeaderToday="今天" 
                Save="儲存" ShowAdvancedForm="細項設定" />
            <TimelineView UserSelectable="False" />
            <WeekView UserSelectable="False" />
            <DayView UserSelectable="False" />
            <MonthView VisibleAppointmentsPerDay="500" />
            <AppointmentTemplate>
                <asp:Label ID="lbDept" runat="server"></asp:Label>
                <div><%# Convert.ToDateTime(Eval("Start")).ToString("HH:mm") %>~<%# Convert.ToDateTime(Eval("End")).ToString("HH:mm") %></div>
                <div>
                    <asp:Button ID="btnMan" runat="server" Text="人" />
                    <asp:ImageButton ID="ibtnMan" runat="server" ImageUrl="~/Images/operation_ok.gif" />
                    &nbsp;
                    <asp:Button ID="btnAttachment" Visible="false" runat="server" Text="文" />
                    <asp:ImageButton ID="ibtnAttachment" runat="server" ImageUrl="~/Images/cabinet16.gif" />
                    &nbsp;
                    <asp:Button ID="btnRecord" Visible="false" runat="server" Text="記" />
                    <asp:ImageButton ID="ibtnRecord" runat="server" ImageUrl="~/Images/edit-3.gif" />
                    &nbsp;
                    <asp:Button ID="btnDelete" runat="server" Text="消" OnClientClick="javascript:if(!confirm('是否確定刪除該筆公告?')) return false;" />
                </div>
                <div><asp:LinkButton ID="lbtnSubject" runat="server" Text= <%# Eval("Subject")%>></asp:LinkButton></div>
                
            </AppointmentTemplate>
        </telerik:RadScheduler>
</div>
    <asp:Button ID="btnPrint" runat="server" onclick="btnPrint_Click" 
        Text="匯出行事曆" Visible="False" />
    <br />
    </td>
</tr>
</table>

</asp:Content>

