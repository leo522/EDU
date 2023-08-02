using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using KMU.EduActivity.ApplicationLayer.DTO;

public partial class EduStopActScheduleCalendar : AuthPage
{
    private List<EduStopActScheduleDto> CurrentActList
    {
        get
        {
            if (Session["CurrentActList"] == null)
            {
                ReadScheduler(rsList.SelectedDate);
            }
            return Session["CurrentActList"] as List<EduStopActScheduleDto>;
        }
        set
        {
            Session["CurrentActList"] = value;
        }
    }

    private string EduTermID
    {
        get
        {
            return Request.QueryString["edutermid"];
        }
    }

    private List<string> ChildDepts
    {
        get
        {
            return ViewState["ChildDepts"] as List<string>;
        }
        set
        {
            ViewState["ChildDepts"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        AddPostbackControl(btnPrint);
        AddPostbackControl(Button1);


        if (!IsPostBack)
        {
            rsList.DataStartField = "TimeFrom";
            rsList.DataEndField = "TimeTo";
            rsList.DataKeyField = "EduStopActScheduleID";
            rsList.DataDescriptionField = "Des";
            rsList.DataSubjectField = "ActName";

            if (EduTermID == null)
            {
                BindDeptment();
            }
            else
            {
                panDept.Visible = false;
                btnAdd.PostBackUrl = "~/EduStopActScheduleAdd.aspx?edutermid=" + EduTermID;
            }            
        }


        if (!IsPostBack)
        {
            if (Session["EduStopActScheduleCalendarCurrentDept"] != null)
            {
                V_departmentDto cdtp = Session["EduStopActScheduleCalendarCurrentDept"] as V_departmentDto;
                DeptSelector1.Select(cdtp.Hospcode, cdtp.Deptcode);
            }

            if (Session["EduStopActScheduleCalendarCurrentDate"] != null)
            {
                rsList.SelectedDate = Convert.ToDateTime(Session["EduStopActScheduleCalendarCurrentDate"]);
            }

        }
        if (ChildDepts == null)
        {
            List<string> childdepts = service.GetChildDepts(this.DeptCode);
            ChildDepts = childdepts;
        }
        if (ChildDepts.Contains(DeptSelector1.SelectDept.Deptcode))
        {
            ViewState["AllowEdit"] = "Y";
        }

        if(!IsPostBack)
        {
            ReadScheduler(rsList.SelectedDate);
        }

    }

    protected void btnQuery_Click(object sender, EventArgs e)
    {
        if (ChildDepts.Contains(DeptSelector1.SelectDept.Deptcode))
        {
            ViewState["AllowEdit"] = "Y";
        }
        else
        {
            ViewState["AllowEdit"] = "N";
        }
        ReadScheduler(rsList.SelectedDate);
    }


    private void ReadScheduler(DateTime currentdate)
    {
        Session["EduStopActScheduleCalendarCurrentDept"] = DeptSelector1.SelectDept;
        Session["EduStopActScheduleCalendarCurrentDate"] = currentdate;

        DateTime sdate = new DateTime(currentdate.Year, currentdate.Month, 1);
        DateTime edate = sdate.AddMonths(1).AddDays(-1);

        List<EduStopActScheduleDto> list = service.GetActList(DeptSelector1.SelectDept.Hospcode, DeptSelector1.SelectDept.Deptcode, EduTermID, sdate, edate, cbShowAll.Checked);

        lbDept.Text = DeptSelector1.SelectDept.DisplayName;
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

    private void BindDeptment()
    {
        if (this.AuthRoles.Contains("DepSec"))
        {
            DeptSelector1.Select(this.HospCode, this.LocCode);
        }
        else
        {
            DeptSelector1.Select(this.HospCode, this.DeptCode);
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
            ImageButton ibtnAttachment = e.Container.FindControl("ibtnAttachment") as ImageButton;
            Button btnAttachment = e.Container.FindControl("btnAttachment") as Button;

            ImageButton ibtnRecord = e.Container.FindControl("ibtnRecord") as ImageButton;
            Button btnRecord = e.Container.FindControl("btnRecord") as Button;

            Button btnDelete = e.Container.FindControl("btnDelete") as Button;
            LinkButton lbtnSubject = e.Container.FindControl("lbtnSubject") as LinkButton;
            Label lbDept = e.Container.FindControl("lbDept") as Label;

            if (lbDept != null)
            {
                if (cbShowAll.Checked)
                {
                    string deptname = "";
                    deptname = DeptSelector1.GetDeptName(dto.DeptCode);

                    lbDept.Text = deptname;
                }
                else
                {
                    lbDept.Text = "";
                }
            }

            if (lbtnSubject != null)
            {
                lbtnSubject.PostBackUrl = "EduStopActScheduleView.aspx?id=" + dto.EduStopActScheduleID;
            }

            if (dto.EduStopActScheduleID == "201911060055")
            {

            }


            btnAttachment.CommandArgument = dto.EduStopActScheduleID;
            btnAttachment.Click += new EventHandler(btnAttachment_Click);
            ibtnAttachment.CommandArgument = dto.EduStopActScheduleID;
            ibtnAttachment.Click += new ImageClickEventHandler(ibtnAttachment_Click);

            btnRecord.CommandArgument = dto.EduStopActScheduleID;
            btnRecord.Click += btnRecord_Click;
            ibtnRecord.CommandArgument = dto.EduStopActScheduleID;
            ibtnRecord.Click += ibtnRecord_Click;


            btnDelete.CommandArgument = dto.EduStopActScheduleID;
            btnDelete.Click += new EventHandler(btnDelete_Click);

            ibtnman.CommandArgument = dto.EduStopActScheduleID;
            ibtnman.Click += new ImageClickEventHandler(ibtnman_Click);
            btnman.CommandArgument = dto.EduStopActScheduleID;
            btnman.Click += new EventHandler(btnman_Click);


            if (dto.Creater != this.EmpCode && (this.AuthRoles != null && !this.AuthRoles.Contains("Admin")) && (ViewState["AllowEdit"] == null || ViewState["AllowEdit"].ToString() != "Y"))
            {
                if (btnman != null)
                {
                    btnman.Visible = false;
                }

                //if (btnAttachment != null)
                //{
                //    btnAttachment.Visible = false;
                //}

                if (dto.HasAttachment)
                {
                    btnAttachment.Visible = false;
                    ibtnAttachment.Visible = true;
                }
                else
                {
                    btnAttachment.Visible = true;
                    ibtnAttachment.Visible = false;
                }

                if (btnDelete != null)
                {
                    btnDelete.Visible = false;
                }

                if (ibtnman != null)
                {
                    ibtnman.Visible = false;
                }

                //if (ibtnAttachment != null)
                //{
                //    ibtnAttachment.Visible = false;
                //}

                //if (ibtnRecord != null)
                //{
                //    ibtnRecord.Visible = false;
                //}

                //if (btnRecord != null)
                //{
                //    btnRecord.Visible = false;
                //}
                if (dto.RecordInstanceID != null)
                {
                    btnRecord.Visible = false;
                    ibtnRecord.Visible = true;

                    switch (dto.RecordInstanceStatus)
                    {
                        case "1":
                            ibtnRecord.ImageUrl = "~/Images/edit-1_2.gif";
                            break;
                        case "2":
                            ibtnRecord.ImageUrl = "~/Images/edit-2_2.gif";
                            break;
                        case "V":
                            ibtnRecord.ImageUrl = "~/Images/edit-V_2.gif";
                            break;
                    }

                }
                else
                {
                    btnRecord.Visible = true;
                    ibtnRecord.Visible = false;
                }

            }
            else
            {
                if (dto.Creater != this.EmpCode)
                {
                    btnDelete.Visible = false;
                }


                if (dto.HasAttachment)
                {
                    btnAttachment.Visible = false;
                    ibtnAttachment.Visible = true;
                }
                else
                {
                    btnAttachment.Visible = true;
                    ibtnAttachment.Visible = false;
                }



                //if (this.AuthRoles.Contains("Admin"))
                //{

                if (dto.RecordInstanceID != null)
                {
                    btnRecord.Visible = false;
                    ibtnRecord.Visible = true;
                    
                    switch(dto.RecordInstanceStatus)
                    {
                        case "1":
                            ibtnRecord.ImageUrl = "~/Images/edit-1_2.gif";
                            break;
                        case "2":
                            ibtnRecord.ImageUrl = "~/Images/edit-2_2.gif";
                            break;
                        case "V":
                            ibtnRecord.ImageUrl = "~/Images/edit-V_2.gif";
                            break;
                    }

                }
                else
                {
                    btnRecord.Visible = true;
                    ibtnRecord.Visible = false;
                }
                //}
                //else
                //{
                //    btnRecord.Visible = false;
                //    ibtnRecord.Visible = false;
                //}


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

    void ibtnRecord_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("RecordSelect.aspx?ScheduleID=" + (sender as ImageButton).CommandArgument);
    }

    void btnRecord_Click(object sender, EventArgs e)
    {
        Response.Redirect("RecordSelect.aspx?ScheduleID=" + (sender as Button).CommandArgument);
    }



    void ibtnAttachment_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("EduStopActScheduleDoc.aspx?id=" + (sender as ImageButton).CommandArgument);
    }

    void btnAttachment_Click(object sender, EventArgs e)
    {
        Response.Redirect("EduStopActScheduleDoc.aspx?id=" + (sender as Button).CommandArgument);
    }

    void btnman_Click(object sender, EventArgs e)
    {
        Response.Redirect("EduStopActScheduleTarget.aspx?id=" + (sender as Button).CommandArgument);
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
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        rsList.ExportToPdf();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

    }
}