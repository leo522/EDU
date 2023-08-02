using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KMU.EduActivity.ApplicationLayer.DTO;
using System.Text;
using Telerik.Web.UI;
using System.Drawing;
using System.Globalization;

public partial class ToDoList : AuthPage
{
    private List<ToDoListDto> CurrentToDoList
    {
        get
        {
            return ViewState["CurrentToDoList"] as List<ToDoListDto>;
        }
        set
        {
            ViewState["CurrentToDoList"] = value;
        }
    }

    private List<ToDoListDto> CurrentExCanWriteList
    {
        get
        {
            return ViewState["CurrentExCanWriteList"] as List<ToDoListDto>;
        }
        set
        {
            ViewState["CurrentExCanWriteList"] = value;
        }
    }

    private List<ToDoListDto> CurrentExpireList
    {
        get
        {
            return ViewState["CurrentExpireList"] as List<ToDoListDto>;
        }
        set
        {
            ViewState["CurrentExpireList"] = value;
        }
    }

    private List<ToDoListDto> CurrentDoneList
    {
        get
        {
            return ViewState["CurrentDoneList"] as List<ToDoListDto>;
        }
        set
        {
            ViewState["CurrentDoneList"] = value;
        }
    }


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

    private List<EduActTargetDto> CurrentTargetList
    {
        get
        {
            return ViewState["EduActTargetList"] as List<EduActTargetDto>;
        }
        set
        {
            ViewState["EduActTargetList"] = value;
        }
    }

    private List<Color> ColorList;

    private int? ColorCount = null;

    private List<string> EduTermColl = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        AddPostbackControl(rsList);
        AddPostbackControl(rtsMenu);
        AddPostbackControl(btnQuery);
        rsList.DataStartField = "TimeFrom";
        rsList.DataEndField = "TimeTo";
        rsList.DataKeyField = "EduStopActScheduleID";
        rsList.DataDescriptionField = "Des";
        rsList.DataSubjectField = "ActName";


        if (!IsPostBack)
        {
            ddlMonth.SelectedValue = Univar.Storage.Session.Get<string>(this.GetType().Name + "_ddlMonth");
            int checkcount = service.CheckHasPassPortUnChecked(this.EmpCode);
            if (checkcount > 0)
            {
                hlPassPortCheckItem.Visible = true;
                hlPassPortCheckItem.Text = "您有" + checkcount.ToString() + "筆待審核的學習護照資料，點我立即前往審核";
                hlPassPortCheckItem.NavigateUrl = "PassPortCheckForTeacherCopy.aspx";
            }
            else
            {
                hlPassPortCheckItem.Visible = false;
            }

            if (AuthRoles.Contains("Teacher") || AuthRoles.Contains("DepSec") || AuthRoles.Contains("Admin"))
            {
                GridColumn col = RadGrid2.MasterTableView.GetColumn("FinalScore");
                if (col != null)
                {
                    col.Visible = true;
                }
            }
            else
            {
                GridColumn col = RadGrid2.MasterTableView.GetColumn("FinalScore");
                if (col != null)
                {
                    col.Visible = false;
                }
            }
            rtsMenu.SelectedIndex = 0;
            rmpMain.SelectedIndex = 0;
            ViewState["CurrentActivityList"] = null;

            //rgExpire.DataBind();
            ReadToDoData();
            ReadTeachData();
            CheckQuestion();
            //ReadTodoCount();
            //ReadExpireCount();

            DeptSelector1.Select(this.HospCode, this.DeptCode);
        }
    }

    private void ReadTeachData()
    {
        string htmlcontent = @"
<table width='100%'>
<tr>
<td>
{0}
您於<font color='blue'> {1}~{2} </font>之教學工作評估，如下：<br>
<table align='left' border='1' cellspacing='0'>
<tr  style='background-color:aqua'>
<td>教學工作評估</td>
<td>計算時機</td>
<td>時數(點數)</td>
</tr>
<tr>
<td>教學時數</td>
<td>{9}</td>
<td>{3}小時</td>
</tr>
<tr>
<td>教學點數</td>
<td>主治醫師教學記錄(106 學年度(含)起)</td>
<td>{4}點</td>
</tr>
<tr>
<td>教師成長訓練時數</td>
<td></td>
<td>{5}小時</td>
</tr>
<tr>
<td rowspan='4'>OSCE認證</td>
<td>{11}</td>
<td>{6}</td>
</tr>
<tr>
<td>學校BLOCK整合課程</td>
<td>{10}小時</td>
</tr>
<tr>
<td>OSCE時數(考官+SP)</td>
<td>{7}小時</td>
</tr>
<tr>
<td>OSCE教案/高階擬真教案撰寫</td>
<td>{8}篇
{12}
</td>
</tr>
</table>
</td>
<td width='5%'>
</td>
<td>
                <font color='red' style='font-size:medium'><b>
                <pre>
●教學點數：
   -主治醫師教學點數：近三年教學點數達到30點，且每年不得低於8
    點，或最近三年之教學點數達35點，且每年不得低於6點。
   -總住院醫師教學點數：具有教學點數每年至少4點。
●訓練時數：
   -主治醫師訓練時數：近三年教師成長教育訓練時數達到15小時，且
    每年不得低於3小時。
  - 總住院醫師訓練時數：每年教師成長教育訓練時數至少5小時。
●教學時數：本校醫學院教師擔任附屬機構各醫療單位主治醫師身分者，
          每週基本授課時數以4小時為原則。
●符合學會認證考官之證明；並具備下列要求之一者：
  (一)近三學年度擔任下列活動 OSCE 考官：學校 BLOCK 整合課程、 
      醫院臨床教育訓練部或學會舉辦之考試或標準化病人訓練，其
      時數合計 18 小時以上。
  (二)近三學年度撰寫 OSCE 教案一篇以上之證明。
</pre></b></font>
<b><a href='TeachDataRule.html' target='_blank'>●相關法規</a></b>
</td>
</tr>
</table>
<br>
";
        MonthlyTeachPointCalcDatumDto dto = service.GetPersonalMonthlyTeachPoint(this.EmpCode);
        if(dto != null)
        {
            panTeachData.Visible = true;
            liTeachData.Text = string.Format(htmlcontent, "更新日期：" + dto.CalDate.ToString("yyyy/MM/dd") + "<br>", dto.Param1, dto.Param2, dto.Param3, dto.Param4, dto.Param5, dto.Param6, dto.Param7, dto.Param8, dto.Param9, dto.Param10, dto.Param11, dto.Param12);
        }
        else
        {
            panTeachData.Visible = false;
        }
    }

    private void ReadTodoCount()
    {
        int count = service.GetToDoCount(this.EmpCode);

        foreach (RadTab tab in rtsList.Tabs)
        {
            if (tab.PageViewID == "vToDo")
            {
                tab.Text += "(" + count.ToString() + ")";
            }
        }
    }


    private void ReadExpireCount()
    {
        int count = service.GetExpireListCount(this.EmpCode);

        foreach(RadTab tab in rtsList.Tabs)
        {
            if(tab.PageViewID == "vExpire")
            {
                tab.Text += "(" + count.ToString() + ")";
            }
        }

    }


    private void CheckQuestion()
    {
        List<EduQuestionDto> list = service.GetNotFinishQuestion(this.EmpCode, this.AuthRoles);

        foreach(EduQuestionDto dto in list)
        {
            if (dto.IsForce)
            {
                Response.Redirect("TemplateDetial.aspx?template_id=" + dto.TEMPLATE_ID.ToString() + "&qid=" + dto.ID.ToString());
            }
            else
            {
                OpenNewWindow("TemplateDetial.aspx?template_id=" + dto.TEMPLATE_ID.ToString() + "&qid=" + dto.ID.ToString());
            }
        }
    }

    protected void RadGrid1_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        RadGrid1.DataSource = CurrentToDoList;
        //ReadToDoData();

    }
    protected void RadGrid2_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        RadGrid2.DataSource = CurrentDoneList;
        //ReadDoneData();
    }

    protected void rgExpire_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        rgExpire.DataSource = CurrentExpireList;
        //ReadExpireData();
    }

    protected void rgWaitBefore_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        //ReadWaitData();
    }

    private void ReadToDoData()
    {

        List<ToDoListDto> list = service.GetToDoList(this.EmpCode, !lbtnDisplayAll.Visible).ToList();
        CurrentToDoList = list;

        RadGrid1.DataSource = CurrentToDoList;
    }


    private void ReadCanWriteExData()
    {

        List<ToDoListDto> list = service.GetCanWriteExFormList(this.EmpCode, !lbtnDisplayAll.Visible).ToList();
        CurrentExCanWriteList = list;

        rgCanWriteEx.DataSource = CurrentExCanWriteList;
    }

    private void ReadExpireData()
    {
        if (CurrentExpireList == null)
        {
            List<ToDoListDto> list = service.GetExpireList(this.EmpCode).ToList();
            CurrentExpireList = list;
        }
        rgExpire.DataSource = CurrentExpireList;
    }

    private void ReadDoneData()
    {
        List<ToDoListDto> list = service.GetDoneList(this.EmpCode, Convert.ToInt32(ddlMonth.SelectedValue)).OrderByDescending(c => c.INSTANCE_ID).ToList();
        CurrentDoneList = list;
        RadGrid2.DataSource = list;
    }


    private void ReadWaitData()
    {
        List<ToDoListDto> list = service.GetWaitList(this.EmpCode).ToList();
        rgWaitBefore.DataSource = list;
    }


    private void ReadScheduler(DateTime currentdate)
    {
        DateTime datebegin = new DateTime(currentdate.AddMonths(-1).Year, currentdate.AddMonths(-1).Month, 1);
        DateTime dateend = datebegin.AddMonths(2);

        List<EduStopActScheduleDto> list = service.GetPersonalActList(this.HospCode, this.EmpCode, datebegin, dateend, (DeptSelector1.SelectDept == null ? "" : DeptSelector1.SelectDept.Deptcode));
        //CurrentToDoList = service.GetToDoList(this.EmpCode, true);
        //List<ToDoListDto> formlist = CurrentToDoList;

        //foreach (ToDoListDto dto in formlist)
        //{
        //    EduStopActScheduleDto newitem = new EduStopActScheduleDto();
        //    newitem.ActType = "Form";
        //    newitem.ActTypeName = "表單填寫";
        //    newitem.Des = "填寫時間:" + dto.DateStr;
        //    newitem.EduActTopicCode = dto.EduTermID + dto.TemplateID;
        //    newitem.EduActTopicID = dto.EduTermID + dto.TemplateID;
        //    newitem.ActName = dto.EduTermName + "-" + dto.TemplateName;
        //    newitem.EduActTopicName = dto.EduTermName + "-" + dto.TemplateName;
        //    newitem.EduStopActScheduleID = dto.EduTermID + dto.TemplateID;
        //    newitem.EduTermID = dto.EduTermID;
        //    newitem.EduTermName = dto.EduTermName;
        //    newitem.TimeFrom = dto.BeginTime.Date;
        //    newitem.TimeTo = dto.BeginTime.Date.AddDays(1).AddSeconds(-1);
        //    newitem.AllowBooking = false;
            
        //    list.Add(newitem);

        //}

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

    protected void rgNews_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        ReadNewsData();
    }

    private void ReadNewsData()
    {
        rgNews.DataSource = null;
        rgNews.MasterTableView.DataKeyNames = new string[] { "NEWID" };


        List<NewsDto> list = service.GetNewsToShow//(DateTime.Now.AddDays(-20), DateTime.Now.Date.AddDays(1).AddSeconds(-1), this.JobCode, this.EmpCode);
            (null, DateTime.Now.Date.AddDays(1).AddSeconds(-1), this.JobCode, this.EmpCode, this.AuthRoles);
        rgNews.DataSource = list;
    }

    protected void btnFuncQuery_Click(object sender, EventArgs e)
    {
        Response.Redirect("FuncQuery.aspx?keyword=" + tbFuncQuery.Text);
    }
    protected void rgNews_ItemCreated(object sender, GridItemEventArgs e)
    {
        LinkButton lbtn = e.Item.FindControl("lbtnShowNews") as LinkButton;
        if (lbtn != null)
        {
            if ((e.Item as GridDataItem).GetDataKeyValue("NEWID") != null)
            {
                string newid = (e.Item as GridDataItem).GetDataKeyValue("NEWID").ToString();
                lbtn.OnClientClick = "window.open('EduNewsShow.aspx?newid=" + newid + "','公佈欄',config='height=500px,width=700px');return false";
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
                if(!dto.AllowBooking)
                {
                    btnbook.Visible = false;
                }
                else
                {
                    btnbook.Visible = true;
                    btnbook.CommandArgument = dto.EduStopActScheduleID;
                    if(dto.BookingID == null)
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
    protected void rtsMenu_TabClick(object sender, RadTabStripEventArgs e)
    {
        if (CurrentActList == null && rtsMenu.SelectedTab.PageViewID == "viewScheduler")
        {
            if (ViewState["CurrentActivityList"] == null)
            {
                ReadScheduler(rsList.SelectedDate);
            }
        }
    }

    protected void btnQueryHistory_Click(object sender, EventArgs e)
    {
        
        Univar.Storage.Session.Set<string>(this.GetType().Name + "_ddlMonth", ddlMonth.SelectedValue);
        ReadDoneData();
        RadGrid2.DataBind();
    }


    protected void rgWaitBefore_ItemCommand(object sender, GridCommandEventArgs e)
    {
        if(e.CommandName == "SendAlert")
        {
            int instanceid = Convert.ToInt32((e.Item as GridDataItem).GetDataKeyValue("INSTANCE_ID"));

            string result = service.AlertBeforeInstance(instanceid);

            if(result!=null)
            {
                ShowMessage("發送提醒通知失敗:" + result);
            }
            else
            {
                ShowMessage("已發送提醒通知");
            }
        }
    }
    protected void btnBook_Click(object sender, EventArgs e)
    {
        Button btnbook = sender as Button;
        if (btnbook.Text == "報名")
        {
            string msg = service.BookEduAct(this.EmpCode, btnbook.CommandArgument);
            if (msg != null)
            {
                ShowMessage(msg);
                
            }
            else
            {
                btnbook.Text = "取消報名";
                ReadScheduler(rsList.SelectedDate);
            }
        }
        else
        {
            bool success = service.UnBookEduAct(this.EmpCode, btnbook.CommandArgument);
            if (success)
            {
                btnbook.Text = "報名";
                ReadScheduler(rsList.SelectedDate);
            }
            else
            {
                ShowMessage("取消報名失敗");
            }
        }
    }
    protected void rtsList_TabClick(object sender, RadTabStripEventArgs e)
    {
        if(e.Tab.PageViewID == "vToDo")
        {
            if(CurrentToDoList == null)
            {
                ReadToDoData();
                RadGrid1.DataBind();
            }
        }

        if (e.Tab.PageViewID == "vCanWriteEx")
        {
            if (CurrentExCanWriteList == null)
            {
                ReadCanWriteExData(); 
                rgCanWriteEx.DataBind();
            }
        }

        if (e.Tab.PageViewID == "vExpire")
        {
            if (CurrentExpireList == null)
            {
                ReadExpireData();
                rgExpire.DataBind();
            }
        }

        if (e.Tab.PageViewID == "vDone")
        {
            if (CurrentDoneList == null)
            {
                ReadDoneData();
                RadGrid2.DataBind();
            }
        }
    }
    protected void lbtnDisplayAll_Click(object sender, EventArgs e)
    {
        lbtnDisplayAll.Visible = false;
        ReadToDoData();
        RadGrid1.DataBind();
    }
    protected void rgCanWriteEx_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        rgCanWriteEx.DataSource = CurrentExCanWriteList;

    }
    protected void lbCanWriteExDisplayAll_Click(object sender, EventArgs e)
    {
        lbCanWriteExDisplayAll.Visible = false;
        ReadCanWriteExData();
        rgCanWriteEx.DataBind();
        
    }
    protected void btnQuery_Click(object sender, EventArgs e)
    {
        ReadScheduler(rsList.SelectedDate);
    }


    [System.Web.Services.WebMethod(EnableSession = true)]
    public static string ReadMySentenceData()
    {
        if (HttpContext.Current.Session["EduAct_EmpCode"] == null)
        {
            return "<div></div>";
        }

        using (KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService service = new KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService())
        {

            string empcode = HttpContext.Current.Session["EduAct_EmpCode"].ToString();
            List<EduSentenceDto> mysen = service.GetMySentences(empcode);

            string myhtml = "";
           
            foreach (var mys in mysen)
            {
                myhtml += "<div title=\"點擊進行複製\" onClick=\"copyToClipboard(this);\" style=\"border-width:3px;border-style:dashed;border-color:#FFAC55;padding:5px;\">";

                myhtml += mys.Sentence;

                myhtml += "</div>";
            }

            if(myhtml == "")
            {
                myhtml = "<div></div>";
            }

            return myhtml;
        }
    }



    [System.Web.Services.WebMethod(EnableSession = true)]
    public static string ReadPubSentenceData()
    {
        if (HttpContext.Current.Session["EduAct_EmpCode"] == null)
        {
            return "<div></div>";
        }

        using (KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService service = new KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService())
        {
            string empcode = HttpContext.Current.Session["EduAct_EmpCode"].ToString();
            List<EduSentenceDto> pubsen = service.GetPublicSentences(empcode);

            string pubhtml = "";


            foreach (var pubs in pubsen)
            {

                pubhtml += "<div title=\"點擊進行複製\" onClick=\"copyToClipboard(this);\" style=\"border-width:3px;border-style:dashed;border-color:#FFAC55;padding:5px;\">";

                pubhtml += pubs.Sentence;

                pubhtml += "</div>";


            }

            if(pubhtml == "")
            {
                pubhtml = "<div></div>";
            }

            return pubhtml;
        }
    }

}