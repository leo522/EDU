<%@ Page Language="C#" AutoEventWireup="true" CodeFile="scheduler.aspx.cs" Inherits="iKASA_scheduler" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register src="~/DeptSelector.ascx" tagname="DeptSelector" tagprefix="uc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

    <script src="//code.jquery.com/jquery-1.10.2.js"></script>

</head>
<body>
    <style>
body{
    font-family:微軟正黑體!important;
}
    </style>
    <form id="form1" runat="server">

<div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:Panel ID="panDept" runat="server">
            <asp:Label ID="Label29" runat="server" Text="部門："></asp:Label>
            <uc1:DeptSelector ID="DeptSelector1" runat="server" />
            &nbsp;&nbsp;<asp:Button ID="btnQuery" runat="server" onclick="btnQuery_Click" Text="查詢" />
            &nbsp;</asp:Panel>
</div>
<asp:Panel ID="palRadScheduler" runat="server">
<div style="z-index:1;">

    
        <telerik:RadScheduler ID="rsList" runat="server" AllowDelete="False" 
            AllowEdit="False" AllowInsert="False" Culture="zh-TW" 
            EnableRecurrenceSupport="False" Height="" 
            onappointmentcreated="rsList_AppointmentCreated" 
            onnavigationcomplete="rsList_NavigationComplete" 
            DataStartField ="TimeFrom"
            DataEndField = "TimeTo"
            DataKeyField = "EduStopActScheduleID"
            DataDescriptionField = "Des"
            DataSubjectField = "ActName"
            ontimeslotcreated="rsList_TimeSlotCreated" OverflowBehavior="Expand" 
            RowHeight="" SelectedView="MonthView" Skin="Simple" 
            StartEditingInAdvancedForm="False">
            <AdvancedForm DateFormat="yyyy/MM/dd" Modal="True" TimeFormat="HH:mm" />
            <Localization AdvancedAllDayEvent="全天" AdvancedCalendarCancel="取消" 
                AdvancedCalendarOK="確定" AdvancedCalendarToday="今天" AdvancedClose="" 
                AdvancedDaily="每日" AdvancedDay="日" AdvancedDays="日" AdvancedDescription="內容" 
                AdvancedDone="完成" AdvancedEditAppointment="編輯行事曆" AdvancedFrom="開始時間" 
                AdvancedNewAppointment="新增行事曆" AdvancedSubject="主旨" AdvancedTo="結束時間" 
                Cancel="取消" ConfirmCancel="取消" ConfirmDeleteText="確定刪除本項行程?" 
                ConfirmDeleteTitle="確定刪除" ContextMenuAddAppointment="新增行事曆" 
                ContextMenuDelete="刪除" ContextMenuEdit="編輯" HeaderToday="今天" Save="儲存" 
                ShowAdvancedForm="細項設定" />
            <TimelineView UserSelectable="False" />
            <WeekView UserSelectable="False" />
            <DayView UserSelectable="False" />
            <MonthView VisibleAppointmentsPerDay="500" />
            <AppointmentTemplate>
                <div>
                    <%# Convert.ToDateTime(Eval("Start")).ToString("HH:mm") %>~<%# Convert.ToDateTime(Eval("End")).ToString("HH:mm") %></div>
                <div>
                    <asp:HyperLink ID="lbtnSubject" Target="_blank" runat="server" Text='<%# Eval("Subject")%>'></asp:HyperLink>
                </div>
            </AppointmentTemplate>
        </telerik:RadScheduler>
    
</div>



</asp:Panel>

    </form>
</body>
</html>
