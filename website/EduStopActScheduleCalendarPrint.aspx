<%@ Page Title="" Language="C#" MasterPageFile="~/Empty.master" AutoEventWireup="true" CodeFile="EduStopActScheduleCalendarPrint.aspx.cs" Inherits="EduStopActScheduleCalendarPrint" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <script language="javascript" type="text/javascript">
        window.onload = function ()
        {
            //window.print();
            //window.close();
        }

        function printpage(myDiv) {

            //var newstr = document.all.item(myDiv).innerHTML;
            var newstr = document.getElementById(myDiv).innerHTML;
            
            var oldstr = document.body.innerHTML;
            document.body.innerHTML = newstr;
            window.print();
            document.body.innerHTML = oldstr;
            return false;
        }
    </script>
<table width="100%">
    <tr>
        <td>
            <input type="button" value="列印" onclick="printpage('htmlContent');" />
        </td>
    </tr>
<tr>
<td>
    <div id="htmlContent">
        <div align="right">科別：<asp:Label ID="lbDept" runat="server"></asp:Label>
        </div>
        <telerik:RadScheduler ID="rsList" runat="server" Culture="zh-TW" 
            EnableRecurrenceSupport="False" SelectedView="MonthView" 
            StartEditingInAdvancedForm="False" 
            onnavigationcomplete="rsList_NavigationComplete" OverflowBehavior="Expand" 
            Height="" RowHeight="" ontimeslotcreated="rsList_TimeSlotCreated" 
            AllowDelete="False" AllowEdit="False" AllowInsert="False" 
            onappointmentcreated="rsList_AppointmentCreated" Skin="Simple">
<ExportSettings>
<Pdf PageTopMargin="1in" PageBottomMargin="1in" PageLeftMargin="1in" PageRightMargin="1in"></Pdf>
</ExportSettings>

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
            <WeekView DayEndTime="23:59:59" DayStartTime="00:00:00" WorkDayEndTime="23:59:59" WorkDayStartTime="00:00:00" />
            <DayView UserSelectable="False" />
            <MonthView VisibleAppointmentsPerDay="500" />
            <AppointmentTemplate>
                <div style="font-size:medium; line-height:normal"><%# Convert.ToDateTime(Eval("Start")).ToString("HH:mm") %>~<%# Convert.ToDateTime(Eval("End")).ToString("HH:mm") %></div>
                <div style="font-size:medium; line-height:normal"><asp:Label ID="lbSubject" runat="server" Text= <%# Eval("Subject")%>></asp:Label></div>
            </AppointmentTemplate>
        </telerik:RadScheduler>
</div>
    <br />
    </td>
</tr>
</table>

</asp:Content>

