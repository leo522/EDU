using KMU.EduActivity.ApplicationLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class iKASA_scheduler : iKASAPageBase
{

    private List<EduStopActScheduleDto> CurrentActList
    {
        get
        {
            if (ViewState["CurrentActivityList"] == null)
            {

                ReadScheduler(rsList.SelectedDate);
            }
            return ViewState["CurrentActivityList"] as List<EduStopActScheduleDto>;
        }
        set
        {
            ViewState["CurrentActivityList"] = value;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

        }

        //AddPostbackControl(btnQuery);

        //var empdata = service.GetVKmuEmpByEmpCode(CurrentPersonInfo.empcode);
        //DeptSelector1.Select(empdata.Hospcode, empdata.Deptcode);
    }


    private void ReadScheduler(DateTime currentdate)
    {
        var empdata = service.GetVKmuEmpByEmpCode(CurrentPersonInfo.empcode);
        DateTime datebegin = new DateTime(currentdate.AddMonths(-1).Year, currentdate.AddMonths(-1).Month, 1);
        DateTime dateend = datebegin.AddMonths(2);

        List<EduStopActScheduleDto> list = service.GetPersonalActList(empdata.Hospcode, CurrentPersonInfo.empcode, datebegin, dateend, empdata.Deptcode);


        CurrentActList = list;

        foreach (EduStopActScheduleDto dto in list)
        {
            if (dto.TimeFrom > dto.TimeTo)
            {
                dto.TimeTo = dto.TimeFrom;
            }
        }

        rsList.DataSource = CurrentActList;
        rsList.DataBind();
    }
    protected void btnQuery_Click(object sender, EventArgs e)
    {
        ReadScheduler(rsList.SelectedDate);
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
        EduStopActScheduleDto dto = CurrentActList.Where(c => c.EduStopActScheduleID == e.Appointment.ID.ToString()).FirstOrDefault();
        if (dto != null)
        {
            ImageButton ibtnman = e.Container.FindControl("ibtnMan") as ImageButton;
            Button btnman = e.Container.FindControl("btnMan") as Button;
            Button btnAttachment = e.Container.FindControl("btnAttachment") as Button;
            Button btnDelete = e.Container.FindControl("btnDelete") as Button;
            HyperLink lbtnSubject = e.Container.FindControl("lbtnSubject") as HyperLink;
            Button btnbook = e.Container.FindControl("btnBook") as Button;

            if (lbtnSubject != null)
            {
                if (dto.Url != null)
                {
                    lbtnSubject.NavigateUrl = dto.Url;
                }
                else
                {
                    lbtnSubject.NavigateUrl = "EduStopActScheduleView.aspx?id=" + dto.EduStopActScheduleID;
                }
            }

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

            if (btnbook != null)
            {
                if (!dto.AllowBooking)
                {
                    btnbook.Visible = false;
                }
                else
                {
                    btnbook.Visible = true;
                    btnbook.CommandArgument = dto.EduStopActScheduleID;
                    if (dto.BookingID == null)
                    {
                        btnbook.Text = "報名";
                    }
                    else
                    {
                        btnbook.Text = "取消報名";
                    }
                }
            }

        }
    }

}