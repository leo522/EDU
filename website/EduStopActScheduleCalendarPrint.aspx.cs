using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using KMU.EduActivity.ApplicationLayer.DTO;

public partial class EduStopActScheduleCalendarPrint : AuthPage
{
    private List<EduStopActScheduleDto> CurrentActList
    {
        get
        {
            return Session["CurrentActList"] as List<EduStopActScheduleDto>;
        }
        set
        {
            Session["CurrentActList"] = value;
        }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            rsList.DataStartField = "TimeFrom";
            rsList.DataEndField = "TimeTo";
            rsList.DataKeyField = "EduStopActScheduleID";
            rsList.DataDescriptionField = "Des";
            rsList.DataSubjectField = "ActName";
            ReadScheduler(rsList.SelectedDate);
            lbDept.Text = Request.QueryString["Dept"];
            if (Session["EduStopActScheduleCalendarCurrentDate"] != null)
            {
                rsList.SelectedDate = Convert.ToDateTime(Session["EduStopActScheduleCalendarCurrentDate"]);
            }
        }

    }


    private void ReadScheduler(DateTime currentdate)
    {
        rsList.DataSource = CurrentActList;
        rsList.DataBind();
    }


    protected void rsList_TimeSlotCreated(object sender, Telerik.Web.UI.TimeSlotCreatedEventArgs e)
    {
        if (rsList.SelectedView == SchedulerViewType.MonthView)
        {

            String month = rsList.SelectedDate.Month.ToString();

            if (e.TimeSlot.Start.Date.Month.ToString() != month)
            {

                e.TimeSlot.Control.Controls.Clear();

            }

        }
    }
    protected void rsList_NavigationComplete(object sender, SchedulerNavigationCompleteEventArgs e)
    {
        if (e.Command == SchedulerNavigationCommand.NavigateToPreviousPeriod
            || e.Command == SchedulerNavigationCommand.NavigateToNextPeriod
            || e.Command == SchedulerNavigationCommand.NavigateToSelectedDate
            || e.Command == SchedulerNavigationCommand.SwitchToSelectedDay
            )
        {
            ReadScheduler(rsList.SelectedDate);
        }
    }

    protected void rsList_AppointmentCreated(object sender, AppointmentCreatedEventArgs e)
    {

    }

}