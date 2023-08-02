using KMU.EduActivity.ApplicationLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class iKASA_records : iKASAPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ReadFormList();
        }
    }

    private void ReadFormList()
    {
        string groupid = this.FuncParams["groupid"];
        List<string> gids = groupid.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries).ToList();
        List<RecordInstanceDto> list = service.GetiKasaMemberRecordInstance(this.CurrentPersonInfo.empcode, gids);

        rcbFormList.DataValueField = "INSTANCEID";
        rcbFormList.DataTextField = "title";
        rcbFormList.DataSource = list;
        rcbFormList.DataBind();

        if(list.Count >0)
        {
            rcbFormList.SelectedIndex = 0;
            ReadRecord();
        }
        else
        {
            lbNoData.Visible = true;
            panAll.Visible = false;
        }
    }

    protected void rcbFormList_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ReadRecord();
    }

    private string CurrentInstanceID
    {
        get
        {
            return rcbFormList.SelectedValue;
        }
    }

    private string CurrentEmpCode
    {
        get
        {
            return Request.QueryString["EmpCode"];
        }
    }

    private string CurrentEduStopActScheduleID
    {
        get
        {
            return Request.QueryString["ScheduleID"];
        }
    }

    private EduStopActScheduleDto CurrentSchedule
    {
        get
        {
            return ViewState["CurrentSchedule"] as EduStopActScheduleDto;
        }
        set
        {
            ViewState["CurrentSchedule"] = value;
        }
    }


    private RecordInstanceDto CurrentIns
    {
        get
        {
            return ViewState["CurrentIns"] as RecordInstanceDto;
        }
        set
        {
            ViewState["CurrentIns"] = value;
        }
    }

    private RecordInsViewerDto CurrentViewer //讀取簽核人員
    {
        get
        {
            int minorder = CurrentIns.RecordInsViewers.Where(c => c.ViewStatus == null).Min(c => c.ViewOrder);
            return CurrentIns.RecordInsViewers.Where(c => c.ViewOrder == minorder).FirstOrDefault();
        }
    }

    const string TemplatePath = "~/UserControls/{0}.ascx";

    protected void ReadRecord() //讀取會議記錄
    {
        if (CurrentInstanceID == null || CurrentInstanceID == "")
        {
            ShowMessage("查無紀錄資料");
            return;
        }

        try
        {
            RecordInstanceDto ins = service.GetRecordInstance(CurrentInstanceID);
            CurrentIns = ins;

            Control ctr = LoadControl(string.Format(TemplatePath, CurrentIns.RecordTemplate.ClassName + "_p"));
            (ctr as IRecordBase).CurrentRecordIns = ins;
            (ctr as IRecordBase).SetControlValues(ins.DetNameValueData);

            (ctr as IRecordBase).SettingEditor(this.CurrentEmpCode);

            List<AccountRoleDto> roles = service.GetAuthRole(CurrentEmpCode);
            (ctr as IRecordBase).SetReadOnly(true);

            PlaceHolder1.Controls.Add(ctr);

            tbTitle.Text = CurrentIns.Title;

            DeptSelector1.Text = CurrentIns.DeptName;


            rdtpSdate.Text = CurrentIns.Sdate.HasValue ? CurrentIns.Sdate.Value.ToString("yyyy/MM/dd HH:mm") : "";
            rdtpEdate.Text = CurrentIns.Edate.HasValue ? CurrentIns.Edate.Value.ToString("yyyy/MM/dd HH:mm") : "";


            if (CurrentEduStopActScheduleID != null)
            {
                ReadSchedule();
            }
            
            rgSign.DataSource = CurrentIns.RecordInsViewers; //簽核人員
            rgSign.DataBind();
            panMain.Enabled = false;

            List<RecordInsSignInDto> list = service.GetRecordSignInList(CurrentIns.InstanceID);

            rgSignIn.DataSource = list; //簽到人員名單
            rgSignIn.DataBind();
        }
        catch (Exception ex)
        {
            ShowMessage("載入會議記錄格式失敗，請聯絡系統管理員");
            return;
        }
    }

    private void ReadSchedule()
    {
        EduStopActScheduleDto sche = service.GetEduStopActSchedulerByID(CurrentEduStopActScheduleID);
        CurrentSchedule = sche;
        if (tbTitle.Text == "")
        {
            tbTitle.Text = sche.ActName;
        }
        rdtpSdate.Text = sche.TimeFrom.ToString("yyyy/MM/dd HH:mm");
        rdtpEdate.Text = sche.TimeTo.ToString("yyyy/MM/dd HH:mm");
    }
}