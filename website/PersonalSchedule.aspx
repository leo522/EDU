<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="PersonalSchedule.aspx.cs" Inherits="PersonalSchedule" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server">
    </telerik:RadStyleSheetManager>
    <script type="text/javascript">
    function GetRadWindow() {
        var oWindow = null;
        if (window.radWindow) oWindow = window.radWindow;
        else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow;
        return oWindow;
    }

    function CloseWindow(bool) {
        var oArg = new Object();
        oArg.NeedRefresh = bool;
        var oWnd = GetRadWindow();
        oWnd.close(oArg);
    }



</script>

<div>



</div>
<div>

    
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
                <div><%# Convert.ToDateTime(Eval("Start")).ToString("HH:mm") %>~<%# Convert.ToDateTime(Eval("End")).ToString("HH:mm") %></div>
                <div><asp:Button ID="btnMan" runat="server" Text="人" /><asp:ImageButton ID="ibtnMan" runat="server" ImageUrl="~/Images/operation_ok.gif" />&nbsp;<asp:Button ID="btnAttachment" Visible="false" runat="server" Text="文" />&nbsp;<asp:Button ID="btnDelete" runat="server" Text="消" OnClientClick="javascript:if(!confirm('是否確定刪除該筆公告?')) return false;" /></div>
                <div><asp:LinkButton ID="lbtnSubject" runat="server" Text= <%# Eval("Subject")%>></asp:LinkButton></div>
            </AppointmentTemplate>
        </telerik:RadScheduler>
    
</div>



    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="ddlTeamCdoe">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="lbSelection" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="ddlJobCode">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="lbSelection" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnAdd">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="lbSelection" />
                    <telerik:AjaxUpdatedControl ControlID="lbSelected" />
                    <telerik:AjaxUpdatedControl ControlID="CoursePanel" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnRemove">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="lbSelection" />
                    <telerik:AjaxUpdatedControl ControlID="lbSelected" />
                    <telerik:AjaxUpdatedControl ControlID="CoursePanel" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    
    <asp:ObjectDataSource ID="dsJobCode" runat="server" SelectMethod="GetJobCodes" 
        TypeName="KMU.EduActivity.ApplicationLayer.DTO.SelectEduActJobCodeDto">
    </asp:ObjectDataSource>

</asp:Content>

