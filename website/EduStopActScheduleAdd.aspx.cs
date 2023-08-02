using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KMU.EduActivity.ApplicationLayer.DTO;
using System.IO;
using Telerik.Web.UI;
using System.Globalization;

public partial class EduStopActScheduleAdd : AuthPage
{
    private string ScheduleID
    {
        get
        {
            return Request.QueryString["id"];
        }
    }

    private string CopyByScheduleID
    {
        get
        {
            return Request.QueryString["copyby"];
        }
    }
    private List<EduActViewTargetDto> CurrentTargetList
    {
        get
        {
            return ViewState["EduActViewTargetList"] as List<EduActViewTargetDto>;
        }
        set
        {
            ViewState["EduActViewTargetList"] = value;
        }
    }

    private string EduTermID
    {
        get
        {
            return Request.QueryString["edutermid"];
        }
    }

    private List<EduActTypeRefDto> CurrentTypeRef
    {
        get
        {
            if (ViewState["CurrentTypeRefs"] == null)
            {
                ViewState["CurrentTypeRefs"] = new List<EduActTypeRefDto>();
            }
            return ViewState["CurrentTypeRefs"] as List<EduActTypeRefDto>;
        }
        set
        {
            ViewState["CurrentTypeRefs"] = value;
        }
    }

    private EduStopActScheduleDto CurrentSchedule
    {
        get
        {
            return ViewState["EduStopActScheduleAddCurrentSchedule"] as EduStopActScheduleDto;
        }
        set
        {
            ViewState["EduStopActScheduleAddCurrentSchedule"] = value;
        }
    }

    private DateTime SelectDateFrom
    {
        get
        {
            DateTime date = rdpDateBegin.SelectedDate.Value.Date;
            date = date.AddHours(rtpTimeBegin.SelectedDate.Value.Hour);
            date = date.AddMinutes(rtpTimeBegin.SelectedDate.Value.Minute);

            return date;
        }
    }

    private DateTime SelectDateTo
    {
        get
        {
            DateTime date = rdpDateEnd.SelectedDate.Value.Date;
            date = date.AddHours(rtpTimeEnd.SelectedDate.Value.Hour);
            date = date.AddMinutes(rtpTimeEnd.SelectedDate.Value.Minute);

            return date;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        AddPostbackControl(this.ruploadAttachment);
        AddPostbackControl(rgAttachment);
        AddPostbackControl(this.btnSave);
        TreeViewComboBox1.SelectedChanged += new EventHandler(TreeViewComboBox1_SelectedChanged);
        if (!IsPostBack)
        {
            BindDept();
            BindActType1();
            BindActType2();
            BindRecordTemplate();

            if (ScheduleID != null)
            {
                ReadSchedule();
            }
            else
            {
                CurrentTargetList = new List<EduActViewTargetDto>();
            }

            if (CopyByScheduleID != null)
            {
                CopySchedule();
                //CurrentTargetList = new List<EduActViewTargetDto>();
            }
        }
        else
        {
            switch (rblTargetType.SelectedValue)
            {
                case "All":
                    palDept.Visible = false;
                    palEduTerm.Visible = false;
                    palEmp.Visible = false;
                    palJobCode.Visible = false;
                    divTeam.Style.Clear();
                    divTeam.Style.Add("display", "none");
                    panChoiceMember.Visible = false;
                    //palTeam.Visible = false;
                    break;
                case "Dept":
                    palDept.Visible = true;
                    palEduTerm.Visible = false;
                    palEmp.Visible = false;
                    palJobCode.Visible = false;
                    divTeam.Style.Clear();
                    divTeam.Style.Add("display", "none");
                    panChoiceMember.Visible = false;
                    break;
                case "JobCode":
                    palDept.Visible = false;
                    palEduTerm.Visible = false;
                    palEmp.Visible = false;
                    palJobCode.Visible = true;
                    divTeam.Style.Clear();
                    divTeam.Style.Add("display", "none");
                    panChoiceMember.Visible = false;
                    break;
                case "EduTerm":
                    palDept.Visible = false;
                    palEduTerm.Visible = true;
                    palEmp.Visible = false;
                    palJobCode.Visible = false;
                    divTeam.Style.Clear();
                    divTeam.Style.Add("display", "none");
                    panChoiceMember.Visible = true;
                    break;
                case "EmpCode":
                    palDept.Visible = false;
                    palEduTerm.Visible = false;
                    palEmp.Visible = true;
                    palJobCode.Visible = false;
                    divTeam.Style.Clear();
                    divTeam.Style.Add("display", "none");
                    panChoiceMember.Visible = false;
                    break;
                case "TeamCode":
                    palDept.Visible = false;
                    palEduTerm.Visible = false;
                    palEmp.Visible = false;
                    palJobCode.Visible = false;
                    divTeam.Style.Clear();
                    panChoiceMember.Visible = true;
                    break;
            }
        }
    }

    void TreeViewComboBox1_SelectedChanged(object sender, EventArgs e)
    {
        ReadMember();
        RadGrid2.DataBind();
        foreach (GridDataItem item in RadGrid2.Items)
        {
            item.Selected = true;
        }
    }

    private void BindRecordTemplate()
    {
        List<RecordTemplateDto> list = service.GetRecordTemplateList();
        
        rcbRecordTemplate.DataValueField = "TemplateID";
        rcbRecordTemplate.DataTextField = "TemplateName";
        rcbRecordTemplate.DataSource = list;
        rcbRecordTemplate.DataBind();
    }

    private void BindDept()
    {
        List<SelectGroupTypeDto> list = service.GetTermUnit("EduAct_Dept");
        SelectGroupTypeDto nullitem = new SelectGroupTypeDto();


        ddlDepartment.DataValueField = "code";
        ddlDepartment.DataTextField = "Name";
        ddlDepartment.DataSource = list;
        ddlDepartment.DataBind();

        if (list.Count > 0)
        {
            if (this.AuthRoles.Contains("DepSec"))
            {
                DeptSelector1.Select(this.HospCode, this.LocCode);
            }
            else
            {
                DeptSelector1.Select(this.HospCode, this.DeptCode);
            }
            
            ddlDepartment.SelectedValue = this.LocCode;
        }
    }

    private void BindActType1()
    {
        List<EduActTypeDto> list = service.GetEduActType(0, -1);
        ViewState["ActType1"] = list;
        EduActTypeDto nullitem = new EduActTypeDto();
        rcbType1.DataValueField = "CLS_ID";
        rcbType1.DataTextField = "CLS_NAME";
        rcbType1.DataSource = list;
        rcbType1.DataBind();
    }
    private void BindActType2()
    {
        List<EduActTypeDto> list = service.GetEduActType(1, Convert.ToInt32(rcbType1.SelectedValue));
        ViewState["ActType2"] = list;
        EduActTypeDto nullitem = new EduActTypeDto();
        nullitem.CLS_ID = -1;
        nullitem.CLS_NAME = "<不指定類型>";
        list.Insert(0, nullitem);

        rcbType2.DataValueField = "CLS_ID";
        rcbType2.DataTextField = "CLS_NAME";
        rcbType2.DataSource = list;
        rcbType2.DataBind();
    }
    private void BindActType3()
    {
        List<EduActTypeDto> list = service.GetEduActType(2, Convert.ToInt32(rcbType2.SelectedValue));
        ViewState["ActType3"] = list;
        EduActTypeDto parenttype = (ViewState["ActType2"] as List<EduActTypeDto>).Where(c => c.CLS_ID == Convert.ToInt32(rcbType2.SelectedValue)).FirstOrDefault();
        if (parenttype != null && parenttype.CLS_TYPE == "Multi")
        {
            rgActType.Visible = true;
            btnAddType.Visible = true;
        }
        else
        {
            rgActType.Visible = false;
            btnAddType.Visible = false;
        }


        EduActTypeDto nullitem = new EduActTypeDto();
        nullitem.CLS_ID = -1;
        nullitem.CLS_NAME = "<不指定類型>";
        list.Insert(0, nullitem);

        rcbType3.DataValueField = "CLS_ID";
        rcbType3.DataTextField = "CLS_NAME";
        rcbType3.DataSource = list;
        rcbType3.DataBind();
    }
    private void BindActType4()
    {
        List<EduActTypeDto> list = service.GetEduActType(3, Convert.ToInt32(rcbType3.SelectedValue));

        ViewState["ActType4"] = list;
        EduActTypeDto nullitem = new EduActTypeDto();
        nullitem.CLS_ID = -1;
        nullitem.CLS_NAME = "<不指定類型>";
        list.Insert(0, nullitem);

        rcbType4.DataValueField = "CLS_ID";
        rcbType4.DataTextField = "CLS_NAME";
        rcbType4.DataSource = list;
        rcbType4.DataBind();
    }

    private void CopySchedule()
    {
        EduStopActScheduleDto sche = service.GetEduStopActSchedulerByID(CopyByScheduleID);

        DeptSelector1.Select(sche.HospCode, sche.DeptCode);
        

        Dictionary<int, EduActTypeDto> acttypes = service.GetActTypeWithParent(Convert.ToInt32(sche.ActType));

        if (acttypes.ContainsKey(0))
        {
            rcbType1.SelectedValue = acttypes[0].CLS_ID.ToString();
            BindActType2();
        }

        if (acttypes.ContainsKey(1))
        {
            rcbType2.SelectedValue = acttypes[1].CLS_ID.ToString();
            BindActType3();
        }

        if (acttypes.ContainsKey(2))
        {
            rcbType3.SelectedValue = acttypes[2].CLS_ID.ToString();
            BindActType4();
        }

        if (acttypes.ContainsKey(3))
        {
            rcbType4.SelectedValue = acttypes[3].CLS_ID.ToString();
        }



        if (sche.EduActTypeRefs.Count > 1)
        {
            CurrentTypeRef = sche.EduActTypeRefs.ToList();
            rgActType.DataSource = CurrentTypeRef;
            rgActType.DataBind();
            rgActType.Visible = true;
            btnAddType.Visible = true;
        }
        else
        {
            rgActType.Visible = false;
            btnAddType.Visible = false;
        }

        rntbBookingLimit.Value = sche.BookingLimit;

        tbActName.Text = sche.ActName;
        cbAllowBooking.Checked = sche.AllowBooking;
        rdpDisplayTimeFrom.SelectedDate = sche.DisplayTimeFrom;
        rdpDisplayTimeTo.SelectedDate = sche.DisplayTimeTo;

        rblActRange.SelectedValue = sche.ActRange;

        if (sche.PropertyType != null)
        {

            string[] proptypes = sche.PropertyType.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string prop in proptypes)
            {
                foreach (Control ctrl in panProp.Controls)
                {
                    if (ctrl is CheckBox)
                    {
                        if ((ctrl as CheckBox).Text == prop)
                        {
                            (ctrl as CheckBox).Checked = true;
                            continue;
                        }
                    }
                }
                cbPropOther.Checked = true;
                tbPropOther.Text = prop;
            }
        }

        rbNone.Checked = true;
        rdpDateBegin.SelectedDate = sche.TimeFrom;
        rtpTimeBegin.SelectedDate = sche.TimeFrom;
        rdpDateEnd.SelectedDate = sche.TimeTo;
        rtpTimeEnd.SelectedDate = sche.TimeTo;

        bool hadcheck = false;
        foreach (Control rb in panLocation.Controls)
        {
            if (rb is RadioButton)
            {
                if ((rb as RadioButton).Text == sche.Location)
                {
                    (rb as RadioButton).Checked = true;
                    hadcheck = true;
                    break;
                }
            }
        }
        if (!hadcheck)
        {
            rbLocationOther.Checked = true;
            tbLocation.Text = sche.Location;
        }
        tbDes.Text = sche.Des;


        CurrentTargetList = service.GetEduActViewTargets(CopyByScheduleID);
        rgTarget.DataSource = CurrentTargetList;
        rgTarget.DataBind();
    }


    private void ReadSchedule()
    {
        EduStopActScheduleDto sche = service.GetEduStopActSchedulerByID(ScheduleID);
        CurrentSchedule = sche;

        DeptSelector1.Select(sche.HospCode, sche.DeptCode);
        

        Dictionary<int, EduActTypeDto> acttypes = service.GetActTypeWithParent(Convert.ToInt32(sche.ActType));

        if (acttypes.ContainsKey(0))
        {
            rcbType1.SelectedValue = acttypes[0].CLS_ID.ToString();
            BindActType2();
        }

        if (acttypes.ContainsKey(1))
        {
            rcbType2.SelectedValue = acttypes[1].CLS_ID.ToString();
            BindActType3();
        }

        if (acttypes.ContainsKey(2))
        {
            rcbType3.SelectedValue = acttypes[2].CLS_ID.ToString();
            BindActType4();
        }

        if (acttypes.ContainsKey(3))
        {
            rcbType4.SelectedValue = acttypes[3].CLS_ID.ToString();
        }

        if (rgActType.Visible == true)
        {
            CurrentTypeRef = sche.EduActTypeRefs.ToList();
            rgActType.DataSource = CurrentTypeRef;
            rgActType.DataBind();
        }



        if (sche.EduActTypeRefs.Count > 1)
        {
            CurrentTypeRef = sche.EduActTypeRefs.ToList();
            rgActType.DataSource = CurrentTypeRef;
            rgActType.DataBind();
            //rgActType.Visible = true;
            //btnAddType.Visible = true;
        }
        else
        {
            //rgActType.Visible = false;
            //btnAddType.Visible = false;
        }

        rntbBookingLimit.Value = sche.BookingLimit;
        tbActName.Text = sche.ActName;
        cbAllowBooking.Checked = sche.AllowBooking;
        rdpDisplayTimeFrom.SelectedDate = sche.DisplayTimeFrom;
        rdpDisplayTimeTo.SelectedDate = sche.DisplayTimeTo;
        rcbRecordTemplate.SelectedValue = sche.RecTemplateID == null ? "" : sche.RecTemplateID.Value.ToString();
        rblActRange.SelectedValue = sche.ActRange;

        if (sche.PropertyType != null)
        {

            string[] proptypes = sche.PropertyType.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string prop in proptypes)
            {
                bool hascb = false;
                foreach (Control ctrl in panProp.Controls)
                {
                    if (ctrl is CheckBox)
                    {
                        if ((ctrl as CheckBox).Text == prop)
                        {
                            (ctrl as CheckBox).Checked = true;
                            hascb = true;
                            continue;
                        }
                    }
                }
                if (!hascb)
                {
                    cbPropOther.Checked = true;
                    tbPropOther.Text = prop;
                }
            }
        }

        RepeatPanel.Visible = false;
        rbNone.Checked = true;
        rdpDateBegin.SelectedDate = sche.TimeFrom;
        rtpTimeBegin.SelectedDate = sche.TimeFrom;
        rdpDateEnd.SelectedDate = sche.TimeTo;
        rtpTimeEnd.SelectedDate = sche.TimeTo;

        bool hadcheck = false;
        foreach (Control rb in panLocation.Controls)
        {
            if (rb is RadioButton)
            {
                if ((rb as RadioButton).Text == sche.Location)
                {
                    (rb as RadioButton).Checked = true;
                    hadcheck = true;
                    break;
                }
            }
        }
        if (!hadcheck)
        {
            rbLocationOther.Checked = true;
            tbLocation.Text = sche.Location;
        }
        tbDes.Text = sche.Des;


        panEditAttachment.Visible = true;
        //odsAttachment.Select();
        ReadAttachment();
        rgAttachment.DataBind();

        CurrentTargetList = service.GetEduActViewTargets(ScheduleID);
        rgTarget.DataSource = CurrentTargetList;
        rgTarget.DataBind();
    }



    public List<DateTime> GetTargetDate(DateTime startDate, DateTime endDate, int weekInterval, DayOfWeek dayOfWeek)
    {
        List<DateTime> result = new List<DateTime>();

        DateTime begindate = new DateTime(startDate.Year, startDate.Month, 1);
        int currentmonth = 0;
        int currentweek = 0;
        while (begindate <= endDate.Date)
        {
            if (currentmonth != begindate.Month)
            {
                currentmonth = begindate.Month;
                currentweek = 0;
            }
            if(begindate.DayOfWeek == dayOfWeek)
            {
                currentweek++;
            }

            if (begindate >= startDate && begindate <= endDate && currentweek == weekInterval && begindate.DayOfWeek == dayOfWeek)
            {
                result.Add(begindate);
            }
            begindate = begindate.AddDays(1);

        }


        //CultureInfo info = CultureInfo.CurrentCulture;
        //DateTime firstDate = DateTime.MinValue;
        //DateTime firstDateInMonth = DateTime.MinValue;
        //DateTime targetDate = DateTime.MinValue;
        //int startMonth = 0;
        //int endMonth = 0;
        //int firstWeekNumber = 0;
        //int targetWeekNumber = 0;
        //int startweekday = 0;
        //for (int x = startDate.Year; x <= endDate.Year; x++)
        //{
        //    startMonth = (x > startDate.Year) ? 1 : startDate.Month;
        //    endMonth = (x < endDate.Year) ? 12 : endDate.Month;
        //    for (int i = startMonth; i <= endMonth; i++)
        //    {
        //        firstDateInMonth = new DateTime(x, i, 1);
        //        firstDate = new DateTime(firstDateInMonth.Year, 1, 1);
        //        startweekday = Convert.ToInt32(firstDate.DayOfWeek);
        //        firstWeekNumber = info.Calendar.GetWeekOfYear(firstDateInMonth, CalendarWeekRule.FirstDay, DayOfWeek.Sunday);
        //        targetWeekNumber = firstWeekNumber + (weekInterval - 1);
        //        //targetWeekNumber = firstWeekNumber + weekInterval;
        //        targetDate = firstDate.AddDays((targetWeekNumber - 1) * 7);
        //        while (targetDate.DayOfWeek != dayOfWeek)
        //        {
        //            targetDate = targetDate.AddDays(-1);
        //        }
        //        if (targetDate >= startDate && targetDate <= endDate)
        //        {
        //            result.Add(targetDate);
        //        }
        //    }
        //}
        return result;
    }

    private EduActTypeDto CurrentSelectType
    {
        get
        {
            EduActTypeDto typedto = new EduActTypeDto();
            if (rcbType4.Items.Count > 0 && rcbType4.SelectedValue != "-1")
            {
                typedto.CLS_ID = Convert.ToInt32(rcbType4.SelectedValue);
                typedto.CLS_NAME = rcbType4.Text;
                return typedto;
            }
            else
            {
                if (rcbType3.Items.Count > 0 && rcbType3.SelectedValue != "-1")
                {
                    typedto.CLS_ID = Convert.ToInt32(rcbType3.SelectedValue);
                    typedto.CLS_NAME = rcbType3.Text;
                    return typedto;
                }
                else
                {
                    if (rcbType2.Items.Count > 0 && rcbType2.SelectedValue != "-1")
                    {
                        typedto.CLS_ID = Convert.ToInt32(rcbType2.SelectedValue);
                        typedto.CLS_NAME = rcbType2.Text;
                        return typedto;
                    }
                    else
                    {
                        if (rcbType1.Items.Count > 0 && rcbType1.SelectedValue != "-1")
                        {
                            typedto.CLS_ID = Convert.ToInt32(rcbType1.SelectedValue);
                            typedto.CLS_NAME = rcbType1.Text;
                            return typedto;
                        }
                    }
                }
            }
            return null;
        }
    }


    private bool CreateSchedule()
    {
        bool success = true;

        try
        {
            DateTime datefrom;
            DateTime dateto;

            DateTime datetoadd;

            List<DateTime[]> datelist = new List<DateTime[]>();
            if (rbNone.Checked)
            {
                datelist.Add(new DateTime[] { SelectDateFrom, SelectDateTo });
            }

            if (rbDay.Checked)
            {
                datetoadd = SelectDateFrom.Date;
                while (datetoadd <= SelectDateTo.Date)
                {
                    datelist.Add(new DateTime[] { datetoadd, datetoadd });
                    datetoadd = datetoadd.AddDays(1);
                }
            }

            if (rbMonth.Checked)
            {
                datetoadd = new DateTime(SelectDateFrom.Date.Year, SelectDateFrom.Date.Month, Convert.ToInt32(rntbDay.Value.Value));
                while (datetoadd <= SelectDateTo.Date)
                {
                    datelist.Add(new DateTime[] { datetoadd, datetoadd });
                    datetoadd = datetoadd.AddMonths(1);
                }
            }

            if (rbWeek.Checked)
            {
                List<DayOfWeek> checklist = new List<DayOfWeek>();
                if (cb7.Checked)
                {
                    checklist.Add(DayOfWeek.Sunday);
                }
                if (cb1.Checked)
                {
                    checklist.Add(DayOfWeek.Monday);
                }
                if (cb2.Checked)
                {
                    checklist.Add(DayOfWeek.Tuesday);
                }
                if (cb3.Checked)
                {
                    checklist.Add(DayOfWeek.Wednesday);
                }
                if (cb4.Checked)
                {
                    checklist.Add(DayOfWeek.Thursday);
                }
                if (cb5.Checked)
                {
                    checklist.Add(DayOfWeek.Friday);
                }
                if (cb6.Checked)
                {
                    checklist.Add(DayOfWeek.Saturday);
                }

                datetoadd = SelectDateFrom.Date;
                while (datetoadd <= SelectDateTo.Date)
                {
                    if (checklist.Contains(datetoadd.DayOfWeek))
                    {
                        datelist.Add(new DateTime[] { datetoadd, datetoadd });
                    }
                    datetoadd = datetoadd.AddDays(1);
                }
            }

            if (rbSpecDay.Checked)
            {
                DayOfWeek specweekday;
                switch (ddlspecweekday.SelectedValue)
                {
                    case "0":
                        specweekday = DayOfWeek.Sunday;
                        break;
                    case "1":
                        specweekday = DayOfWeek.Monday;
                        break;
                    case "2":
                        specweekday = DayOfWeek.Tuesday;
                        break;
                    case "3":
                        specweekday = DayOfWeek.Wednesday;
                        break;
                    case "4":
                        specweekday = DayOfWeek.Thursday;
                        break;
                    case "5":
                        specweekday = DayOfWeek.Friday;
                        break;
                    case "6":
                        specweekday = DayOfWeek.Saturday;
                        break;
                    default:
                        specweekday = DayOfWeek.Sunday;
                        break;
                }

                List<DateTime> specdaylist = GetTargetDate(SelectDateFrom.Date, SelectDateTo.Date, Convert.ToInt32(ddlweek.SelectedValue), specweekday);

                foreach (DateTime adddate in specdaylist)
                {

                    datelist.Add(new DateTime[] { adddate.Date, adddate.Date });
                }
            }



            foreach (DateTime[] datearray in datelist)
            {
                datefrom = datearray[0].Date.AddHours(SelectDateFrom.Hour).AddMinutes(SelectDateFrom.Minute).AddSeconds(SelectDateFrom.Second);
                dateto = datearray[1].Date.AddHours(SelectDateTo.Hour).AddMinutes(SelectDateTo.Minute).AddSeconds(SelectDateTo.Second);
                EduStopActScheduleDto newappointment = new EduStopActScheduleDto();
                newappointment.HospCode = DeptSelector1.SelectDept.Hospcode;
                newappointment.EduStopActScheduleID = service.GetSerialNo("EduAct_StopActScheduleID");
                newappointment.DeptCode = DeptSelector1.SelectDept.Deptcode;
                if (rntbBookingLimit.Value != null)
                {
                    newappointment.BookingLimit = Convert.ToInt32(rntbBookingLimit.Value);
                }
                newappointment.EduActTypeRefs = new List<EduActTypeRefDto>();

                if (rgActType.Visible)
                {
                    newappointment.ActType = CurrentSelectType.CLS_ID.ToString();
                    foreach (GridDataItem item in rgActType.Items)
                    {
                        int id = Convert.ToInt32(item.GetDataKeyValue("CLS_ID"));
                        EduActTypeRefDto dto = new EduActTypeRefDto();
                        dto.CLS_ID = id;
                        dto.EduStopActScheduleID = newappointment.EduStopActScheduleID;
                        newappointment.EduActTypeRefs.Add(dto);
                    }
                }
                else
                {
                    if (CurrentSelectType != null)
                    {
                        newappointment.ActType = CurrentSelectType.CLS_ID.ToString();
                        EduActTypeRefDto dto = new EduActTypeRefDto();
                        dto.CLS_ID = CurrentSelectType.CLS_ID;
                        dto.EduStopActScheduleID = newappointment.EduStopActScheduleID;
                        newappointment.EduActTypeRefs.Add(dto);
                    }
                }
                
                if(rcbRecordTemplate.SelectedValue == null || rcbRecordTemplate.SelectedValue == "")
                {
                    newappointment.RecTemplateID = null;
                }
                else
                {
                    newappointment.RecTemplateID = Convert.ToInt32(rcbRecordTemplate.SelectedValue);
                }

                newappointment.ActName = tbActName.Text;


                newappointment.DisplayTimeFrom = rdpDisplayTimeFrom.SelectedDate;

                newappointment.DisplayTimeTo = rdpDisplayTimeTo.SelectedDate;

                newappointment.ActRange = rblActRange.SelectedValue;

                newappointment.AllowBooking = cbAllowBooking.Checked;

                string proptype = "";
                foreach (Control ctrl in panProp.Controls)
                {
                    if (ctrl is CheckBox)
                    {
                        if ((ctrl as CheckBox).Checked)
                        {
                            proptype += (ctrl as CheckBox).Text + "|";
                        }
                    }
                }
                if (cbPropOther.Checked)
                {
                    proptype += tbPropOther.Text;
                }
                newappointment.PropertyType = proptype;

                newappointment.TimeTo = dateto;
                newappointment.TimeFrom = datefrom;

                string location = "";
                foreach (Control ctr in panLocation.Controls)
                {
                    if (ctr is RadioButton)
                    {
                        if ((ctr as RadioButton).Checked)
                        {
                            location = (ctr as RadioButton).Text;
                            break;
                        }
                    }
                }

                if (rbLocationOther.Checked)
                {
                    location = tbLocation.Text;
                }
                newappointment.Location = location;


                newappointment.Des = tbDes.Text;

                newappointment.Creater = this.EmpCode;
                newappointment.LastModifier = this.EmpCode;

                //List<EduActTargetDto> targetlist = new List<EduActTargetDto>(); ;

                //if (EduTermID != null)
                //{
                //    EduActTargetDto newtarget = new EduActTargetDto();
                //    newtarget.EduStopActScheduleID = newappointment.EduStopActScheduleID;
                //    newtarget.TargetID = EduTermID;
                //    newtarget.TargetType = "EduTerm";
                //    targetlist.Add(newtarget);
                //}

                //if (cbAll.Checked)
                //{
                //    EduActTargetDto newtarget = new EduActTargetDto();
                //    newtarget.EduStopActScheduleID = newappointment.EduStopActScheduleID;
                //    newtarget.TargetType = "All";
                //    targetlist.Add(newtarget);                    
                //}

                //insert data to database

                //if(AuthRoles.Contains("Admin"))
                //{
                    newappointment.EnableRec = true;
                //}

                service.InsertEduStopActSchedule(newappointment, CurrentTargetList, null);

                foreach (UploadedFile file in ruploadAttachment.UploadedFiles)
                {
                    byte[] bytes = new byte[file.InputStream.Length];
                    file.InputStream.Read(bytes, 0, bytes.Length);
                    file.InputStream.Seek(0, SeekOrigin.Begin);
                    service.InsertActAttachment(newappointment.EduStopActScheduleID, file.FileName.Substring(file.FileName.LastIndexOf(@"\") + 1), bytes, true);
                }

                ruploadAttachment.UploadedFiles.Clear();
            }
        }
        catch (Exception ex)
        {
            ShowMessage("新增失敗:" + ex.Message);
            success = false;
        }


        return success;
    }

    private bool EditSchedule()
    {

        bool success = true;
        try
        {
            CurrentSchedule.HospCode = DeptSelector1.SelectDept.Hospcode;
            CurrentSchedule.DeptCode = DeptSelector1.SelectDept.Deptcode;

            CurrentSchedule.EduActTypeRefs = new List<EduActTypeRefDto>();

            if (rgActType.Visible)
            {
                CurrentSchedule.ActType = CurrentSelectType.CLS_ID.ToString();
                foreach (GridDataItem item in rgActType.Items)
                {
                    int id = Convert.ToInt32(item.GetDataKeyValue("CLS_ID"));
                    EduActTypeRefDto dto = new EduActTypeRefDto();
                    dto.CLS_ID = id;
                    dto.EduStopActScheduleID = CurrentSchedule.EduStopActScheduleID;
                    CurrentSchedule.EduActTypeRefs.Add(dto);
                }
            }
            else
            {
                if (CurrentSelectType != null)
                {
                    CurrentSchedule.ActType = CurrentSelectType.CLS_ID.ToString();
                    EduActTypeRefDto dto = new EduActTypeRefDto();
                    dto.CLS_ID = CurrentSelectType.CLS_ID;
                    dto.EduStopActScheduleID = CurrentSchedule.EduStopActScheduleID;
                    CurrentSchedule.EduActTypeRefs.Add(dto);
                }
            }

            if (rntbBookingLimit.Value != null)
            {
                CurrentSchedule.BookingLimit = Convert.ToInt32(rntbBookingLimit.Value);
            }
            CurrentSchedule.ActName = tbActName.Text;
            CurrentSchedule.AllowBooking = cbAllowBooking.Checked;

            CurrentSchedule.DisplayTimeFrom = rdpDisplayTimeFrom.SelectedDate;

            CurrentSchedule.DisplayTimeTo = rdpDisplayTimeTo.SelectedDate;

            CurrentSchedule.ActRange = rblActRange.SelectedValue;

            if (rcbRecordTemplate.SelectedValue == null || rcbRecordTemplate.SelectedValue == "")
            {
                CurrentSchedule.RecTemplateID = null;
            }
            else
            {
                CurrentSchedule.RecTemplateID = Convert.ToInt32(rcbRecordTemplate.SelectedValue);
            }


            string proptype = "";
            foreach (Control ctrl in panProp.Controls)
            {
                if (ctrl is CheckBox)
                {
                    if ((ctrl as CheckBox).Checked)
                    {
                        proptype += (ctrl as CheckBox).Text + "|";
                    }
                }
            }
            if (cbPropOther.Checked)
            {
                proptype += tbPropOther.Text;
            }
            CurrentSchedule.PropertyType = proptype;


            CurrentSchedule.TimeTo = SelectDateTo;
            CurrentSchedule.TimeFrom = SelectDateFrom;

            string location = "";
            foreach (Control ctr in panLocation.Controls)
            {
                if (ctr is RadioButton)
                {
                    if ((ctr as RadioButton).Checked)
                    {
                        location = (ctr as RadioButton).Text;
                        break;
                    }
                }
            }

            if (rbLocationOther.Checked)
            {
                location = tbLocation.Text;
            }
            CurrentSchedule.Location = location;

            CurrentSchedule.Des = tbDes.Text;

            CurrentSchedule.LastModifier = this.EmpCode;

            //List<EduActTargetDto> targetlist = service.GetEduActTargets(CurrentSchedule.EduStopActScheduleID);

            //全部
            //EduActTargetDto dto = targetlist.Where(c => c.TargetType == "All").FirstOrDefault();
            //if (cbAll.Checked)
            //{
            //    if (dto == null)
            //    {
            //        EduActTargetDto newtarget = new EduActTargetDto();
            //        newtarget.EduStopActScheduleID = CurrentSchedule.EduStopActScheduleID;
            //        newtarget.TargetType = "All";
            //        targetlist.Add(newtarget);  
            //    }
            //}
            //else
            //{
            //    if (dto != null)
            //    {
            //        targetlist.Remove(dto);
            //    }
            //}

            //update data to database
            service.UpdateEduStopActSchedule(CurrentSchedule, CurrentTargetList, null);

        }
        catch (Exception ex)
        {
            ShowMessage("更新失敗:" + ex.Message);
            success = false;
        }

        return success;
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {

        bool success = true;

        if (DeptSelector1.SelectDept == null)
        {
            ShowMessage("未選擇公告科室!");
            return;
        }

        if (rcbType1.SelectedValue == "-1")
        {
            ShowMessage("至少選擇一個公告類型!");
            return;
        }

        if (tbActName.Text.Trim() == "")
        {
            ShowMessage("未輸入公告主題!");
            return;
        }

        if (rdpDateBegin.SelectedDate == null || rdpDateEnd.SelectedDate == null || rtpTimeBegin.SelectedDate == null || rtpTimeEnd.SelectedDate == null)
        {
            ShowMessage("請輸入活動日期");
            return;
        }

        if (rbNone.Checked && (rdpDateBegin.SelectedDate.Value.Date != rdpDateEnd.SelectedDate.Value.Date))
        {
            ShowMessage("跨日活動請於每日分別建立");
            return;
        }


        if (rtpTimeBegin.SelectedTime.Value.TotalSeconds > rtpTimeEnd.SelectedTime.Value.TotalSeconds)
        {
            ShowMessage("結束活動時間(時間部分)應晚於開始活動時間");
            return;
        }

        if (rgActType.Visible)
        {
            if(rgActType.Items.Count == 0)
            {
                ShowMessage("請至少加入一個活動類別");
                return;
            }

        }



        if (ScheduleID == null)
        {
            success = CreateSchedule();
        }
        else
        {
            success = EditSchedule();
        }


        if (success)
        {
            string msg = "";
            string url = "";
            if (ScheduleID != null)
            {
                msg = "儲存完成";
                url = "EduStopActScheduleCalendar.aspx";
            }
            else
            {
                msg = "新增完成";
                url = "EduStopActScheduleCalendar.aspx";
                //if (EduTermID != null)
                //{
                    //url += "?edutermid=" + EduTermID;
                //}
            }


            ShowMessageAndGo(msg, url);
        }

    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        foreach (UploadedFile file in ruploadAttachment.UploadedFiles)
        {
            byte[] bytes = new byte[file.InputStream.Length];
            file.InputStream.Read(bytes, 0, bytes.Length);
            file.InputStream.Seek(0, SeekOrigin.Begin);
            service.InsertActAttachment(ScheduleID, file.FileName.Substring(file.FileName.LastIndexOf(@"\") + 1), bytes, true);
        }
        ruploadAttachment.UploadedFiles.Clear();
        //odsAttachment.Select();
        ReadAttachment();
        rgAttachment.DataBind();
    }
    protected void odsAttachment_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        e.InputParameters["eduStopActScheduleID"] = ScheduleID;
        e.InputParameters["isPublic"] = true;
    }
    protected void rcbType1_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        BindActType2();
    }
    protected void rcbType2_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        BindActType3();
    }
    protected void rcbType3_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        BindActType4();
    }
    protected void rdpDateBegin_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
    {
        if ((rbNone.Checked) || (rdpDateEnd.SelectedDate < rdpDateBegin.SelectedDate))
        {
            rdpDateEnd.SelectedDate = rdpDateBegin.SelectedDate;
        }
    }
    protected void rgAttachment_DeleteCommand(object sender, GridCommandEventArgs e)
    {
        string attachmentid = (e.Item as GridDataItem).GetDataKeyValue("ActAttachmentID").ToString();
        service.DeleteActAttachment(attachmentid);
        //odsAttachment.Select();
        ReadAttachment();
        rgAttachment.DataBind();
    }
    protected void rgAttachment_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            if (ViewState["CurrentEduAtt"] != null)
            {
                if (e.Item is GridDataItem)
                {
                    GridDataItem item = (GridDataItem)e.Item;

                    string id = item.GetDataKeyValue("ActAttachmentID").ToString();

                    List<EduStopActAttachmentDto> list = ViewState["CurrentEduAtt"] as List<EduStopActAttachmentDto>;

                    EduStopActAttachmentDto att = list.Where(c => c.ActAttachmentID == id).FirstOrDefault();

                    LinkButton lbtn = item.FindControl("lbtnAtt") as LinkButton;

                    lbtn.Text = att.Name;

                    try
                    {
                        ((LinkButton)item["AutoGeneratedDeleteColumn"].Controls[0]).Text = "刪除";
                    }
                    catch
                    {
                    }
                }
            }

        }  
    }
    protected void lbtnAtt_Click(object sender, EventArgs e)
    {
        GridDataItem item = (sender as LinkButton).Parent.Parent as GridDataItem;
        string id = item.GetDataKeyValue("ActAttachmentID").ToString();

        List<EduStopActAttachmentDto> list = ViewState["CurrentEduAtt"] as List<EduStopActAttachmentDto>;

        EduStopActAttachmentDto att = list.Where(c => c.ActAttachmentID == id).FirstOrDefault();

        byte[] bytes = att.Attachment;


        HttpResponse response = Response;

        response.Clear();
        

        //response.AppendCookie(new HttpCookie("fileDownloadToken", download_token_value_id.Value));

        response.AddHeader("Content-Type", "binary/octet-stream");
        response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.HtmlEncode(att.FileName) + "; size=" + bytes.Length.ToString());

        response.BinaryWrite(bytes);

        response.Flush();
        response.End();
    }

    protected void btnAddTarget_Click(object sender, EventArgs e)
    {
        EduActViewTargetDto dto = new EduActViewTargetDto();
        dto.TargetType = rblTargetType.SelectedValue;
        switch (rblTargetType.SelectedValue)
        {
            case "All":
                dto = service.FillEduActViewTargetName(dto);
                dto.TargetID = "All";
                CurrentTargetList.Add(dto);
                break;
            case "Dept":
                dto.TargetID = ddlDepartment.SelectedValue;
                dto = service.FillEduActViewTargetName(dto);
                CurrentTargetList.Add(dto);
                break;
            case "JobCode":
                foreach (RadComboBoxItem item in ddlJobCode.Items)
                {
                    if (item.Checked)
                    {
                        EduActViewTargetDto dtoj = new EduActViewTargetDto();
                        dtoj.TargetType = "JobCode";
                        dtoj.TargetID = item.Value;
                        dtoj.TargetName = item.Text;
                        CurrentTargetList.Add(dtoj);
                    }
                }
                break;
            case "EmpCode":
                dto.TargetID = VsSelector1.SelectedValue;
                dto = service.FillEduActViewTargetName(dto);
                CurrentTargetList.Add(dto);
                break;
            case "TeamCode":
            case "EduTerm":
                foreach (GridDataItem item in RadGrid2.SelectedItems)
                {
                    EduActViewTargetDto dtoe = new EduActViewTargetDto();
                    dtoe.TargetType = "EmpCode";
                    string empcode = item.GetDataKeyValue("isHospMember").ToString();
                    dtoe.TargetID = empcode;
                    dtoe = service.FillEduActViewTargetName(dtoe);
                    CurrentTargetList.Add(dtoe);
                }
                break;
        }


        rgTarget.DataSource = CurrentTargetList;
        rgTarget.DataBind();
    }
    protected void rgTarget_ItemCommand(object sender, GridCommandEventArgs e)
    {
        if (e.CommandName == RadGrid.DeleteSelectedCommandName)
        {

            List<int> removelist = new List<int>();
            foreach (GridDataItem item in rgTarget.SelectedItems)
            {
                removelist.Add(item.DataSetIndex);
            }

            for (int i = 0; i < removelist.Count; i++)
            {
                CurrentTargetList.RemoveAt(removelist[i]);
                removelist.RemoveAt(i);
                i--;
            }

            rgTarget.DataSource = CurrentTargetList;
            rgTarget.DataBind();
        }
    }
    protected void rgTarget_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        rgTarget.DataSource = CurrentTargetList;
    }
    protected void btnQuery_Click(object sender, EventArgs e)
    {
        ReadData();
        RadGrid1.DataBind();
    }
    private void ReadData()
    {
        List<EduTermDto> list = service.GetEduTerms(tbEduStopCode.Text, tbEduName.Text);
        RadGrid1.DataSource = list;
    }
    protected void RadGrid1_NeedDataSource1(object sender, GridNeedDataSourceEventArgs e)
    {
        ReadData();
    }
    protected void ddlJobCode_DataBound(object sender, EventArgs e)
    {
        if (ddlJobCode.Items.Count > 0)
        {
            ddlJobCode.SelectedIndex = 0;
            foreach (RadComboBoxItem item in ddlJobCode.Items)
            {
                item.Checked = false;
            }
        }
    }
    protected void RadGrid1_PreRender(object sender, EventArgs e)
    {
        HideExpandColumnRecursive(RadGrid1.MasterTableView);
    }
    public void HideExpandColumnRecursive(GridTableView tableView)
    {
        GridItem[] nestedViewItems = tableView.GetItems(GridItemType.NestedView);
        foreach (GridNestedViewItem nestedViewItem in nestedViewItems)
        {
            foreach (GridTableView nestedView in nestedViewItem.NestedTableViews)
            {
                if (nestedView.Items.Count == 0)
                {
                    TableCell cell = nestedView.ParentItem["ExpandColumn"];
                    cell.Controls[0].Visible = false;
                    cell.Text = " ";
                    nestedViewItem.Visible = false;
                }
                if (nestedView.HasDetailTables)
                {
                    HideExpandColumnRecursive(nestedView);
                }
            }
        }
    }
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        RadGrid2.DataSource = null;
        RadGrid2.DataBind();
    }

    private void ReadMember()
    {
        switch (rblTargetType.SelectedValue)
        {
            case "All":
            case "Dept":
            case "JobCode":
            case "EmpCode":
                RadGrid2.DataSource = null;
                break;
            case "EduTerm":
                if (RadGrid1.SelectedItems.Count > 0)
                {
                    GridDataItem item = RadGrid1.SelectedItems[0] as GridDataItem;
                    string id = item.GetDataKeyValue("EduTermID").ToString();
                    List<MemberDto> list = service.GetMembersByTerm(id);
                    RadGrid2.DataSource = list;
                }
                else
                {
                    RadGrid2.DataSource = null;
                }
                break;
            case "TeamCode":
                if (TreeViewComboBox1.SelectedValue != null && TreeViewComboBox1.SelectedValue != "")
                {
                    List<MemberDto> list = service.GetMembersByTeam(TreeViewComboBox1.SelectedValue, rdpDateBegin.SelectedDate);
                    RadGrid2.DataSource = list;
                }
                else
                {
                    RadGrid2.DataSource = null;
                }
                break;
        }
    }

    protected void RadGrid1_SelectedIndexChanged(object sender, EventArgs e)
    {
        ReadMember();
        RadGrid2.DataBind();
        foreach (GridDataItem item in RadGrid2.Items)
        {
            item.Selected = true;
        }
    }
    private void ReadAttachment()
    {
        List<EduStopActAttachmentDto> list = service.GetEduActAttachments(ScheduleID, true);
        ViewState["CurrentEduAtt"] = list;
        rgAttachment.DataSource = list;
    }
    protected void rgAttachment_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        ReadAttachment();
    }
    protected void btnAddType_Click(object sender, EventArgs e)
    {
        if (rcbType3.SelectedValue != "-1")
        {
            if (CurrentTypeRef.Exists(c => c.CLS_ID == Convert.ToInt32(rcbType3.SelectedValue)))
            {
                ShowMessage("類別已存在");
                return;
            }
            else
            {
                EduActTypeRefDto newtype = new EduActTypeRefDto();
                newtype.CLS_ID = Convert.ToInt32(rcbType3.SelectedValue);
                newtype.CLS_NAME = rcbType3.Text;
                CurrentTypeRef.Add(newtype);
                rgActType.DataSource = CurrentTypeRef;
                rgActType.DataBind();
            }

        }
        else
        {
            ShowMessage("未選擇類別");
        }
    }
    protected void rgActType_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        if (rgActType.Visible)
        {
            rgActType.DataSource = CurrentTypeRef;
        }
    }
    protected void rgActType_DeleteCommand(object sender, GridCommandEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            int clsid = Convert.ToInt32((e.Item as GridDataItem).GetDataKeyValue("CLS_ID"));

            CurrentTypeRef.Remove(CurrentTypeRef.Where(c => c.CLS_ID == clsid).FirstOrDefault());
            rgActType.DataBind();

        }
    }
}