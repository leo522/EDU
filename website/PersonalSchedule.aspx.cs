using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KMU.EduActivity.ApplicationLayer.DTO;
using Telerik.Web.UI;
using System.Globalization;
using System.Text;
using System.Drawing;

public partial class PersonalSchedule : AuthPage
{
    protected override void OnPreInit(EventArgs e)
    {
        base.OnPreInit(e);
    }


    private List<EduStopActScheduleDto> CurrentActList
    {
        get
        {
            if (Session["CurrentActivityList"] == null)
            {
                ReadScheduler(rsList.SelectedDate);
            }
            return Session["CurrentActivityList"] as List<EduStopActScheduleDto>;
        }
        set
        {
            Session["CurrentActivityList"] = value;
        }
    }

    private List<Color> ColorList;

    private int? ColorCount = null;

    private List<string> EduTermColl = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        ColorList = new List<Color>();
        ColorList.Add(Color.AliceBlue);
        ColorList.Add(Color.AntiqueWhite);
        ColorList.Add(Color.Aqua);
        ColorList.Add(Color.BurlyWood);
        ColorList.Add(Color.Chartreuse);
        ColorList.Add(Color.Coral);
        ColorList.Add(Color.Cyan);
        ColorList.Add(Color.DarkGray);
        ColorList.Add(Color.DarkSeaGreen);
        ColorList.Add(Color.Fuchsia);
        ColorList.Add(Color.GreenYellow);
        ColorList.Add(Color.Khaki);
        ColorList.Add(Color.PaleGreen);
        ColorList.Add(Color.Violet);
        ColorList.Add(Color.WhiteSmoke);

        Menu menu = (Master.FindControl("NavigationMenu") as Menu);
        menu.Style["z-index"] = "50000";
        menu.Style["position"] = "relative";

        rsList.Style["z-index"] = "1";
        rsList.Style["position"] = "relative";
        

        if (!IsPostBack)
        {
            rsList.DataStartField = "TimeFrom";
            rsList.DataEndField = "TimeTo";
            rsList.DataKeyField = "EduStopActScheduleID";
            rsList.DataDescriptionField = "Des";
            rsList.DataSubjectField = "ActName";

            
            ReadScheduler(rsList.SelectedDate);

        }
    }

    private void ReadScheduler(DateTime currentdate)
    {
        DateTime datebegin = new DateTime(currentdate.Year, currentdate.Month, 1);
        DateTime dateend = datebegin.AddMonths(1).AddDays(-1);

        List<EduStopActScheduleDto> list = service.GetPersonalActList(this.HospCode, this.EmpCode, datebegin, dateend, "");
        CurrentActList = list;

        rsList.DataSource = CurrentActList;
        rsList.DataBind();
    }


    public List<DateTime> GetTargetDate(DateTime startDate, DateTime endDate, int weekInterval, DayOfWeek dayOfWeek)
    { 
        List<DateTime> result = new List<DateTime>(); 
        CultureInfo info = CultureInfo.CurrentCulture;
        DateTime firstDate = DateTime.MinValue;
        DateTime firstDateInMonth = DateTime.MinValue;
        DateTime targetDate = DateTime.MinValue;
        int startMonth = 0;
        int endMonth = 0;
        int firstWeekNumber = 0;
        int targetWeekNumber = 0;
        int startweekday = 0;
        for (int x = startDate.Year; x <= endDate.Year; x++) 
        { 
            startMonth = (x > startDate.Year) ? 1 : startDate.Month;
            endMonth = (x < endDate.Year) ? 12 : endDate.Month;
            for (int i = startMonth; i <= endMonth; i++)
            {
                firstDateInMonth = new DateTime(x, i, 1);
                firstDate = new DateTime(firstDateInMonth.Year, 1, 1);
                startweekday = Convert.ToInt32(firstDate.DayOfWeek);
                firstWeekNumber = info.Calendar.GetWeekOfYear(firstDateInMonth, CalendarWeekRule.FirstDay, DayOfWeek.Sunday);
                targetWeekNumber = firstWeekNumber + (weekInterval - 1);
                //targetWeekNumber = firstWeekNumber + weekInterval;
                targetDate = firstDate.AddDays((targetWeekNumber - 1) * 7);
                while (targetDate.DayOfWeek != dayOfWeek)
                {
                    targetDate = targetDate.AddDays(-1);
                }
                if (targetDate >= startDate && targetDate <= endDate)
                {
                    result.Add(targetDate);
                }
            }
        }
        return result; 
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
        EduStopActScheduleDto dto = CurrentActList.Where(c => c.EduStopActScheduleID == e.Appointment.ID.ToString()).FirstOrDefault();
        if (dto != null)
        {
            ImageButton ibtnman = e.Container.FindControl("ibtnMan") as ImageButton;
            Button btnman = e.Container.FindControl("btnMan") as Button;
            Button btnAttachment = e.Container.FindControl("btnAttachment") as Button;
            Button btnDelete = e.Container.FindControl("btnDelete") as Button;
            LinkButton lbtnSubject = e.Container.FindControl("lbtnSubject") as LinkButton;

            if (lbtnSubject != null)
            {
                lbtnSubject.PostBackUrl = "EduStopActScheduleView.aspx?id=" + dto.EduStopActScheduleID;
            }

            if (dto.Creater != this.EmpCode)
            {
                if (btnman != null)
                {
                    btnman.Visible = false;
                }

                if (btnAttachment != null)
                {
                    btnAttachment.Visible = false;
                }

                if (btnDelete != null)
                {
                    btnDelete.Visible = false;
                }

                if (ibtnman != null)
                {
                    ibtnman.Visible = false;
                }
            }
            else
            {
                btnDelete.CommandArgument = dto.EduStopActScheduleID;
                btnDelete.Click += new EventHandler(btnDelete_Click);

                ibtnman.CommandArgument = dto.EduStopActScheduleID;
                ibtnman.Click += new ImageClickEventHandler(ibtnman_Click);
                btnman.Click += new EventHandler(btnman_Click);
                if (dto.HasTarget)
                {
                    ibtnman.Visible = true;
                    btnman.Visible = false;

                }
                else
                {
                    ibtnman.Visible = false;
                    btnman.Visible = true;
                }
            }
        }
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


    void btnman_Click(object sender, EventArgs e)
    {
        Response.Redirect("EduStopActScheduleTarget.aspx?id=" + (sender as ImageButton).CommandArgument);
    }

    void ibtnman_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("EduStopActScheduleTarget.aspx?id=" + (sender as ImageButton).CommandArgument);
    }

    void btnDelete_Click(object sender, EventArgs e)
    {
        Button btn = sender as Button;
        EduStopActScheduleDto dto = CurrentActList.Where(c => c.EduStopActScheduleID == btn.CommandArgument).FirstOrDefault();
        if (dto != null)
        {
            service.DeleteEduStopActSchedule(new List<EduStopActScheduleDto>() { dto });
        }

        ReadScheduler(rsList.SelectedDate);
    }
}