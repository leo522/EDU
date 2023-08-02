using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KMU.EduActivity.ApplicationLayer.DTO;
using KMU.EduActivity.ApplicationLayer.Services;
using Telerik.Web.UI;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;
using System.Text;

public partial class TeachTimeQuery : AuthPage
{

    protected DataTable CurrentActRate
    {
        get
        {
            return ViewState["CurrentActRate"] as DataTable;
        }
        set
        {
            ViewState["CurrentActRate"] = value;
        }
    }

    protected DataTable CurrentRoleRate
    {
        get
        {
            return ViewState["CurrentRoleRate"] as DataTable;
        }
        set
        {
            ViewState["CurrentRoleRate"] = value;
        }
    }

    protected DataTable CurrentMixRate
    {
        get
        {
            return ViewState["CurrentMixRate"] as DataTable;
        }
        set
        {
            ViewState["CurrentMixRate"] = value;
        }
    }


    protected DataTable CurrentJobCode
    {
        get
        {
            return ViewState["CurrentJobCode"] as DataTable;
        }
        set
        {
            ViewState["CurrentJobCode"] = value;
        }
    }

    protected IEnumerable<TeachTimeTypeDto> CurrentTeachTimeTypes
    {
        get
        {
            return ViewState["CurrentTeachTimeTypes"] as IEnumerable<TeachTimeTypeDto>;
        }
        set
        {
            ViewState["CurrentTeachTimeTypes"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        AddPostbackControl(btnQuery);
        AddPostbackControl(btnQuerySum);
        AddPostbackControl(btnQueryPersonalSum);
        AddPostbackControl(btnToKPI);
        if (!IsPostBack)
        {
            ReadTeachTimeType();
            BindActType1();
            BindJobCode();
            BindHospital();
            rcbType1_SelectedIndexChanged(rcbType1, null);
            if (this.AuthRoles.Contains("Admin") || this.AuthRoles.Contains("DepSec"))
            {
                tbEmpCodes.Enabled = true;
                tbEmpCodes.Text = "";
            }
            else
            {
                tbEmpCodes.Enabled = false;
                tbEmpCodes.Text = this.EmpCode;
                cbNeedStudent.Checked = true;
                cbNeedAtt.Checked = true;
                divhide.Attributes.Add("style", "display:none");
            }
            ReadHealTeachTimeTargetType();


            int cyear = DateTime.Now.Year - 1911;

            for (int i = 0; i < 10; i++)
            {
                ddlEduYear.Items.Add(new ListItem((cyear - i).ToString(), (cyear - i).ToString()));
            }
        }

    }

    private void BindHospital()
    {
        List<HospDto> hosps = service.GetHosp();
        cblHospital.DataValueField = "HospCode";
        cblHospital.DataTextField = "HospName";
        cblHospital.DataSource = hosps;
        cblHospital.DataBind();

        foreach (ListItem item in cblHospital.Items)
        {
            item.Selected = true;
        }

    }

    private void ReadHealTeachTimeTargetType()
    {
        List<V_CodeRefDto> list = service.GetHealTeachTimeTargetType();
        //V_CodeRefDto alldto = new V_CodeRefDto();
        //alldto.Code = null;
        //alldto.Name = "全部";
        //list.Insert(0, alldto);
        rblHealTeachTimeTargetType.DataTextField = "Name";
        rblHealTeachTimeTargetType.DataValueField = "Code";
        
        rblHealTeachTimeTargetType.DataSource = list;
        rblHealTeachTimeTargetType.DataBind();

        foreach (ListItem item in rblHealTeachTimeTargetType.Items)
        {
            item.Selected = true;
        }
    }


    private void ReadTeachTimeType()
    {
        IEnumerable<TeachTimeTypeDto> list = service.GetTeachTimeType();
        CurrentTeachTimeTypes = list;
        rcbSettingType.DataSource = list;
        rcbSettingType.DataBind();
    }

    private void BindJobCode()
    {
        List<V_kmujobDto> list = service.GetJobs().OrderBy(c => c.DisplayName).ToList();


        rcbJobCode.DataValueField = "JOB_CODE_X";
        rcbJobCode.DataTextField = "DisplayName";



        rcbJobCode.DataSource = list;
        rcbJobCode.DataBind();


        V_kmujobDto emptydto = new V_kmujobDto();
        emptydto.JOB_CODE_X = "";
        emptydto.JOB_NAME = "";
        list.Insert(0, emptydto);
        rcbFilterJob.DataValueField = "JOB_CODE_X";
        rcbFilterJob.DataTextField = "DisplayName";



        rcbFilterJob.DataSource = list;
        rcbFilterJob.DataBind();

        

    }

    private void BindActType1()
    {
        List<EduActTypeDto> list = service.GetEduActType(0, -1);
        EduActTypeDto nullitem = new EduActTypeDto();
        rcbType1.DataValueField = "CLS_ID";
        rcbType1.DataTextField = "CLS_NAME";
        rcbType1.DataSource = list;
        rcbType1.DataBind();
    }
    private void BindActType2()
    {
        List<EduActTypeDto> list = service.GetEduActType(1, Convert.ToInt32(rcbType1.SelectedValue));
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
        EduActTypeDto nullitem = new EduActTypeDto();
        nullitem.CLS_ID = -1;
        nullitem.CLS_NAME = "<不指定類型>";
        list.Insert(0, nullitem);

        rcbType4.DataValueField = "CLS_ID";
        rcbType4.DataTextField = "CLS_NAME";
        rcbType4.DataSource = list;
        rcbType4.DataBind();
    }

    protected void rcbType1_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        BindActType2();
        BindActType3();
        BindActType4();
    }
    protected void rcbType2_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        BindActType3();
        BindActType4();
    }
    protected void rcbType3_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        BindActType4();
    }
    protected void btnQuery_Click(object sender, EventArgs e)
    {
        if (rbByEduYear.Checked && (ddlEduYear.SelectedValue == null || ddlEduYear.SelectedValue == "" || ddlEduYearSession.SelectedValue == null || ddlEduYearSession.SelectedValue == ""))
        {
            ShowMessage("請選擇學年度與學期");
            return;
        }
        if (rbByDate.Checked && rdpDateBegin.SelectedDate == null)
        {
            ShowMessage("未選擇舉辦日期(起)");
            return;
        }

        if (rbByDate.Checked && rdpDateEnd.SelectedDate == null)
        {
            ShowMessage("未選擇舉辦日期(迄)");
            return;
        }

        if (!cbShowActData.Checked && !cbShowHealthTeach.Checked)
        {
            ShowMessage("請至少選擇一項匯出資料類別");
            return;
        }

        if(rcbSettingType.SelectedValue == null || rcbSettingType.SelectedValue == "")
        {
            ShowMessage("請選擇計算時機");
            return;
        }

        List<string> htTargetType = new List<string>();
        foreach (ListItem item in rblHealTeachTimeTargetType.Items)
        {
            if (item.Selected)
            {
                htTargetType.Add(item.Value);
            }
        }

        List<string> filterjob = new List<string>();
        foreach (RadComboBoxItem item in rcbFilterJob.Items)
        {
            if (item.Checked)
            {
                filterjob.Add(item.Value);
            }
        }

        List<string> filterhosp = new List<string>();
        foreach (ListItem item in cblHospital.Items)
        {
            if (item.Selected)
            {
                filterhosp.Add(item.Value);
            }
        }

        DateTime? sdate = null;
        DateTime? edate = null;
        if (rbByDate.Checked)
        {
            sdate = rdpDateBegin.SelectedDate;
            edate = rdpDateEnd.SelectedDate;
        }
        else
        {
            int cyear = Convert.ToInt32(ddlEduYear.SelectedValue);
            int session = Convert.ToInt32(ddlEduYearSession.SelectedValue);
            sdate = new DateTime(1911 + cyear, 8, 1).AddMonths(session * 6);
            edate = sdate.Value.AddMonths(6).AddDays(-1);
        }

        DataTable dt = service.GetTeachTimeListData(sdate.Value, edate.Value, CurrentActRate, CurrentRoleRate, CurrentMixRate, rcbSettingType.SelectedValue, CurrentJobCode, cbNeedStudent.Checked, cbNeedAtt.Checked, tbEmpCodes.Text, filterjob, filterhosp, htTargetType, cbShowActData.Checked, cbShowHealthTeach.Checked, null, cbLoadForm.Checked, true);

        Utility uti = new Utility();

        byte[] bytes = uti.ExportDataTableToExcel(dt);


        HttpResponse response = Response;

        response.Clear();

        //response.AppendCookie(new HttpCookie("fileDownloadToken", download_token_value_id.Value));

        response.AddHeader("Content-Type", "binary/octet-stream");

        response.AddHeader("Content-Disposition", "attachment; filename=data.xls" + "; size=" + bytes.Length.ToString());

        response.BinaryWrite(bytes);

        response.Flush();
        response.End();

    }
    protected void rcbRole_DataBound(object sender, EventArgs e)
    {
        foreach (RadComboBoxItem item in rcbRole.Items)
        {
            item.Checked = true;
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        if (rntbActRate1.Value == null || rntbActRate2.Value == null)
        {
            ShowMessage("未設定權重");
            return;
        }

        string acttypename = "";
        string acttype = "";
        if (rcbType4.Items.Count > 0 && rcbType4.SelectedValue != "-1")
        {
            acttype = rcbType4.SelectedValue;
            acttypename = rcbType4.Text;
        }
        else
        {
            if (rcbType3.Items.Count > 0 && rcbType3.SelectedValue != "-1")
            {
                acttype = rcbType3.SelectedValue;
                acttypename = rcbType3.Text;
            }
            else
            {
                if (rcbType2.Items.Count > 0 && rcbType2.SelectedValue != "-1")
                {
                    acttype = rcbType2.SelectedValue;
                    acttypename = rcbType2.Text;
                }
                else
                {
                    if (rcbType1.Items.Count > 0 && rcbType1.SelectedValue != "-1")
                    {
                        acttype = rcbType1.SelectedValue;
                        acttypename = rcbType1.Text;
                    }
                }
            }
        }

        if (CurrentActRate == null)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("acttype");
            dt.Columns.Add("acttypename");
            dt.Columns.Add("actrate1");
            dt.Columns.Add("actrate2");
            dt.Columns.Add("actratestr");
            CurrentActRate = dt;
        }

        if (CurrentActRate.Select("acttype = '" + acttype + "'").Length > 0)
        {
            ShowMessage("設定已存在");
            return;
        }

        DataRow dr = CurrentActRate.NewRow();
        dr["acttype"] = acttype;
        dr["acttypename"] = acttypename;
        dr["actrate1"] = rntbActRate1.Value;
        dr["actrate2"] = rntbActRate2.Value;
        dr["actratestr"] = rntbActRate1.Value.ToString() + ":" + rntbActRate2.Value.ToString();
        CurrentActRate.Rows.Add(dr);
        rgActRate.DataSource = CurrentActRate;
        rgActRate.DataBind();
    }
    protected void ibtnAddRole_Click(object sender, ImageClickEventArgs e)
    {
        if (rcbRole.SelectedValue == "" || rcbRole.SelectedValue == null)
        {
            ShowMessage("未選擇角色");
            return;
        }
        if (rntbRoleRate1.Value == null || rntbRoleRate2.Value == null)
        {
            ShowMessage("未設定權重");
            return;
        }


        if (CurrentRoleRate == null)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("roletype");
            dt.Columns.Add("roletypename");
            dt.Columns.Add("rolerate1");
            dt.Columns.Add("rolerate2");
            dt.Columns.Add("roleratestr");
            CurrentRoleRate = dt;
        }

        if (CurrentRoleRate.Select("roletype = '" + rcbRole.SelectedValue + "'").Length > 0)
        {
            ShowMessage("設定已存在");
            return;
        }

        DataRow dr = CurrentRoleRate.NewRow();
        dr["roletype"] = rcbRole.SelectedValue;
        dr["roletypename"] = rcbRole.Text;
        dr["rolerate1"] = rntbRoleRate1.Value;
        dr["rolerate2"] = rntbRoleRate2.Value;
        dr["roleratestr"] = rntbRoleRate1.Value.ToString() + ":" + rntbRoleRate2.Value.ToString();
        CurrentRoleRate.Rows.Add(dr);
        rgRoleRate.DataSource = CurrentRoleRate;
        rgRoleRate.DataBind();
    }
    protected void ibtnAddJobCode_Click(object sender, ImageClickEventArgs e)
    {
        if (CurrentJobCode == null)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("JOB_CODE_X");
            dt.Columns.Add("JOB_NAME");
            CurrentJobCode = dt;
        }


        DataRow dr = CurrentJobCode.NewRow();
        dr["JOB_CODE_X"] = rcbJobCode.SelectedValue;
        dr["JOB_NAME"] = rcbJobCode.Text;
        CurrentJobCode.Rows.Add(dr);


        rgJobCode.DataSource = CurrentJobCode;
        rgJobCode.DataBind();
    }

    protected void rgActRate_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        rgActRate.DataSource = CurrentActRate;
    }
    protected void rgRoleRate_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        rgRoleRate.DataSource = CurrentRoleRate;
    }
    protected void rgJobCode_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        rgJobCode.DataSource = CurrentJobCode;
    }

    protected void rgActRate_DeleteCommand(object sender, GridCommandEventArgs e)
    {
        string key = (e.Item as GridDataItem).GetDataKeyValue("acttype").ToString();
        DataRow dr = CurrentActRate.Select("acttype='" + key + "'")[0];
        CurrentActRate.Rows.Remove(dr);
        rgActRate.DataBind();
    }
    protected void rgRoleRate_DeleteCommand(object sender, GridCommandEventArgs e)
    {
        string key = (e.Item as GridDataItem).GetDataKeyValue("roletype").ToString();
        DataRow dr = CurrentRoleRate.Select("roletype='" + key + "'")[0];
        CurrentRoleRate.Rows.Remove(dr);
        rgRoleRate.DataBind();
    }
    protected void rgJobCode_DeleteCommand(object sender, GridCommandEventArgs e)
    {
        string key = (e.Item as GridDataItem).GetDataKeyValue("JOB_CODE_X").ToString();
        DataRow dr = CurrentJobCode.Select("JOB_CODE_X='" + key + "'")[0];
        CurrentJobCode.Rows.Remove(dr);
        rgJobCode.DataBind();
    }
    protected void btnQuerySum_Click(object sender, EventArgs e)
    {
        if (rbByEduYear.Checked && (ddlEduYear.SelectedValue == null || ddlEduYear.SelectedValue == "" || ddlEduYearSession.SelectedValue == null || ddlEduYearSession.SelectedValue == ""))
        {
            ShowMessage("請選擇學年度與學期");
            return;
        }
        if (rbByDate.Checked && rdpDateBegin.SelectedDate == null)
        {
            ShowMessage("未選擇舉辦日期(起)");
            return;
        }

        if (rbByDate.Checked && rdpDateEnd.SelectedDate == null)
        {
            ShowMessage("未選擇舉辦日期(迄)");
            return;
        }


        if (!cbShowActData.Checked && !cbShowHealthTeach.Checked)
        {
            ShowMessage("請至少選擇一項匯出資料類別");
            return;
        }


        if (rcbSettingType.SelectedValue == null || rcbSettingType.SelectedValue == "")
        {
            ShowMessage("請選擇計算時機");
            return;
        }

        List<string> htTargetType = new List<string>();
        foreach (ListItem item in rblHealTeachTimeTargetType.Items)
        {
            if (item.Selected)
            {
                htTargetType.Add(item.Value);
            }
        }

        List<string> filterjob = new List<string>();
        foreach (RadComboBoxItem item in rcbFilterJob.Items)
        {
            if (item.Checked)
            {
                filterjob.Add(item.Value);
            }
        }

        List<string> filterhosp = new List<string>();
        foreach (ListItem item in cblHospital.Items)
        {
            if (item.Selected)
            {
                filterhosp.Add(item.Value);
            }
        }

        DateTime? sdate = null;
        DateTime? edate = null;
        if (rbByDate.Checked)
        {
            sdate = rdpDateBegin.SelectedDate;
            edate = rdpDateEnd.SelectedDate;
        }
        else
        {
            int cyear = Convert.ToInt32(ddlEduYear.SelectedValue);
            int session = Convert.ToInt32(ddlEduYearSession.SelectedValue);
            sdate = new DateTime(1911 + cyear, 8, 1).AddMonths(session * 6);
            edate = sdate.Value.AddMonths(6).AddDays(-1);
        }


        DataTable dt = service.GetTeachTimeSumData(sdate.Value, edate.Value, CurrentActRate, CurrentRoleRate, CurrentMixRate, rcbSettingType.SelectedValue, CurrentJobCode, cbNeedStudent.Checked, cbNeedAtt.Checked, tbEmpCodes.Text, filterjob, filterhosp, htTargetType, cbShowActData.Checked, cbShowHealthTeach.Checked, cbLoadForm.Checked);

        Utility uti = new Utility();

        byte[] bytes = uti.ExportDataTableToExcel(dt);


        HttpResponse response = Response;

        response.Clear();

        //response.AppendCookie(new HttpCookie("fileDownloadToken", download_token_value_id.Value));

        response.AddHeader("Content-Type", "binary/octet-stream");

        response.AddHeader("Content-Disposition", "attachment; filename=data.xls" + "; size=" + bytes.Length.ToString());

        response.BinaryWrite(bytes);

        response.Flush();
        response.End();

    }
    protected void rcbSettingType_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        TeachTimeTypeDto selected = CurrentTeachTimeTypes.Where(c => c.SettingType == rcbSettingType.SelectedValue).FirstOrDefault();
        if (selected != null)
        {
            if(selected.AllowKPI)
            {
                btnToKPI.Visible = true;
            }
            else
            {
                btnToKPI.Visible = false;
            }
            cbNeedAtt.Checked = selected.NeedAttachment;
            cbNeedStudent.Checked = selected.NeedMember;
            cbLoadForm.Checked = selected.LoadFormData;

            IEnumerable<TeachTimeRateDto> list = service.GetTeachTimeRate(rcbSettingType.SelectedValue);


            DataTable dt = new DataTable();
            dt.Columns.Add("acttype");
            dt.Columns.Add("acttypename");
            dt.Columns.Add("actrate1");
            dt.Columns.Add("actrate2");
            dt.Columns.Add("actratestr");
            CurrentActRate = dt;

            foreach (TeachTimeRateDto rate in list.Where(c => c.CodeType == "acttype"))
            {
                string acttypename = "";
                string acttype = rate.SettingCode;
                EduActTypeDto acttypedto = service.GetActTypeById(Convert.ToInt32(acttype));
                if (acttypedto != null)
                {
                    acttypename = acttypedto.CLS_NAME;
                }

                DataRow dr = CurrentActRate.NewRow();
                dr["acttype"] = acttype;
                dr["acttypename"] = acttypename;
                dr["actrate1"] = rate.Rate1;
                dr["actrate2"] = rate.Rate2;
                dr["actratestr"] = rate.Rate1.ToString() + ":" + rate.Rate2.ToString();
                CurrentActRate.Rows.Add(dr);

            }
            rgActRate.DataSource = CurrentActRate;
            rgActRate.DataBind();

            DataTable dtrole = new DataTable();
            dtrole.Columns.Add("roletype");
            dtrole.Columns.Add("roletypename");
            dtrole.Columns.Add("rolerate1");
            dtrole.Columns.Add("rolerate2");
            dtrole.Columns.Add("roleratestr");
            CurrentRoleRate = dtrole;

            List<V_CodeRefDto> roles = service.GetCodeRefs("EduAct_ActRoleType");

            foreach (TeachTimeRateDto rate in list.Where(c => c.CodeType == "roletype"))
            {
                DataRow dr = CurrentRoleRate.NewRow();
                dr["roletype"] = rate.SettingCode;
                V_CodeRefDto role = roles.Where(c => c.Code == rate.SettingCode).FirstOrDefault();

                if (role != null)
                {

                    dr["roletypename"] = role.Name;
                }


                dr["rolerate1"] = rate.Rate1;
                dr["rolerate2"] = rate.Rate2;
                dr["roleratestr"] = rate.Rate1.ToString() + ":" + rate.Rate2.ToString();
                CurrentRoleRate.Rows.Add(dr);

            }
            rgRoleRate.DataSource = CurrentRoleRate;
            rgRoleRate.DataBind();



            DataTable dtmix = new DataTable();
            dtmix.Columns.Add("acttype");
            dtmix.Columns.Add("acttypename");
            dtmix.Columns.Add("roletype");
            dtmix.Columns.Add("roletypename");
            dtmix.Columns.Add("mixrate1");
            dtmix.Columns.Add("mixrate2");
            dtmix.Columns.Add("mixratestr");
            dtmix.Columns.Add("unit");
            CurrentMixRate = dtmix;

            foreach (TeachTimeRateDto rate in list.Where(c => c.CodeType == "refroletype"))
            {
                DataRow dr = CurrentMixRate.NewRow();
                dr["roletype"] = rate.SettingCode;
                V_CodeRefDto role = roles.Where(c => c.Code == rate.SettingCode).FirstOrDefault();

                if (role != null)
                {

                    dr["roletypename"] = role.Name;
                }

                TeachTimeRateDto actdto = list.Where(c => c.SettingID == rate.RefID).FirstOrDefault();
                if (actdto != null)
                {
                    dr["acttype"] = actdto.SettingCode;
                    EduActTypeDto acttypedto = service.GetActTypeById(Convert.ToInt32(actdto.SettingCode));
                    if (acttypedto != null)
                    {
                        dr["acttypename"] = acttypedto.CLS_NAME;
                    }
                }


                dr["mixrate1"] = rate.Rate1;
                dr["mixrate2"] = rate.Rate2;
                dr["mixratestr"] = rate.Rate1.ToString() + ":" + rate.Rate2.ToString() + (rate.Unit == null ? "" : rate.Unit);
                dr["unit"] = (rate.Unit == null ? "" : rate.Unit);
                CurrentMixRate.Rows.Add(dr);

            }
            rgMixRate.DataSource = CurrentMixRate;
            rgMixRate.DataBind();

            DataTable dtjob = new DataTable();
            dtjob.Columns.Add("JOB_CODE_X");
            dtjob.Columns.Add("JOB_NAME");
            CurrentJobCode = dtjob;


            foreach (TeachTimeRateDto rate in list.Where(c => c.CodeType == "jobcode"))
            {
                DataRow dr = CurrentJobCode.NewRow();
                dr["JOB_CODE_X"] = rate.SettingCode;
                foreach (RadComboBoxItem i in rcbJobCode.Items)
                {
                    if (i.Value == rate.SettingCode)
                    {
                        dr["JOB_NAME"] = i.Text;
                    }
                }
                CurrentJobCode.Rows.Add(dr);
            }
            rgJobCode.DataSource = CurrentJobCode;
            rgJobCode.DataBind();


            if (list.Count(c => c.CodeType == "httargettype") > 0)
            {
                foreach (ListItem item in rblHealTeachTimeTargetType.Items)
                {
                    if(list.Count(c=> c.CodeType == "httargettype" && c.SettingCode == item.Value)>0)
                    {
                        item.Selected = true;
                    }
                    else
                    {
                        item.Selected = false;
                    }

                }
            }



        }
    }
    protected void btnQueryPersonalSum_Click(object sender, EventArgs e)
    {
        if (rbByEduYear.Checked && (ddlEduYear.SelectedValue == null || ddlEduYear.SelectedValue == "" || ddlEduYearSession.SelectedValue == null || ddlEduYearSession.SelectedValue == ""))
        {
            ShowMessage("請選擇學年度與學期");
            return;
        }
        if (rbByDate.Checked && rdpDateBegin.SelectedDate == null)
        {
            ShowMessage("未選擇舉辦日期(起)");
            return;
        }

        if (rbByDate.Checked && rdpDateEnd.SelectedDate == null)
        {
            ShowMessage("未選擇舉辦日期(迄)");
            return;
        }

        if(!cbShowActData.Checked&& !cbShowHealthTeach.Checked)
        {
            ShowMessage("請至少選擇一項匯出資料類別");
            return;
        }

        if (rcbSettingType.SelectedValue == null || rcbSettingType.SelectedValue == "")
        {
            ShowMessage("請選擇計算時機");
            return;
        }

        List<string> htTargetType = new List<string>();
        foreach (ListItem item in rblHealTeachTimeTargetType.Items)
        {
            if (item.Selected)
            {
                htTargetType.Add(item.Value);
            }
        }

        List<string> filterjob = new List<string>();
        foreach (RadComboBoxItem item in rcbFilterJob.Items)
        {
            if (item.Checked)
            {
                filterjob.Add(item.Value);
            }
        }

        List<string> filterhosp = new List<string>();
        foreach (ListItem item in cblHospital.Items)
        {
            if (item.Selected)
            {
                filterhosp.Add(item.Value);
            }
        }

        DateTime? sdate = null;
        DateTime? edate = null;
        if (rbByDate.Checked)
        {
            sdate = rdpDateBegin.SelectedDate;
            edate = rdpDateEnd.SelectedDate;
        }
        else
        {
            int cyear = Convert.ToInt32(ddlEduYear.SelectedValue);
            int session = Convert.ToInt32(ddlEduYearSession.SelectedValue);
            sdate = new DateTime(1911 + cyear, 8, 1).AddMonths(session * 6);
            edate = sdate.Value.AddMonths(6).AddDays(-1);
        }

        DataTable dt = service.GetTeachTimePersonalSumData(sdate.Value, edate.Value, CurrentActRate, CurrentRoleRate, CurrentMixRate, rcbSettingType.SelectedValue, CurrentJobCode, cbNeedStudent.Checked, cbNeedAtt.Checked, tbEmpCodes.Text, filterjob, filterhosp, htTargetType, cbShowActData.Checked, cbShowHealthTeach.Checked, cbLoadForm.Checked);

        Utility uti = new Utility();

        byte[] bytes = uti.ExportDataTableToExcel(dt);


        HttpResponse response = Response;

        response.Clear();

        //response.AppendCookie(new HttpCookie("fileDownloadToken", download_token_value_id.Value));

        response.AddHeader("Content-Type", "binary/octet-stream");

        response.AddHeader("Content-Disposition", "attachment; filename=data.xls" + "; size=" + bytes.Length.ToString());

        response.BinaryWrite(bytes);

        response.Flush();
        response.End();
    }
    protected void btnToKPI_Click(object sender, EventArgs e)
    {
        if (rbByEduYear.Checked && (ddlEduYear.SelectedValue == null || ddlEduYear.SelectedValue == "" || ddlEduYearSession.SelectedValue == null || ddlEduYearSession.SelectedValue == ""))
        {
            ShowMessage("請選擇學年度與學期");
            return;
        }
        if (rbByDate.Checked && rdpDateBegin.SelectedDate == null)
        {
            ShowMessage("未選擇舉辦日期(起)");
            return;
        }

        if (rbByDate.Checked && rdpDateEnd.SelectedDate == null)
        {
            ShowMessage("未選擇舉辦日期(迄)");
            return;
        }

        if (!cbShowActData.Checked && !cbShowHealthTeach.Checked)
        {
            ShowMessage("請至少選擇一項匯出資料類別");
            return;
        }

        if (rcbSettingType.SelectedValue == null || rcbSettingType.SelectedValue == "")
        {
            ShowMessage("請選擇計算時機");
            return;
        }

        List<string> htTargetType = new List<string>();
        foreach (ListItem item in rblHealTeachTimeTargetType.Items)
        {
            if (item.Selected)
            {
                htTargetType.Add(item.Value);
            }
        }

        List<string> filterjob = new List<string>();
        foreach (RadComboBoxItem item in rcbFilterJob.Items)
        {
            if (item.Checked)
            {
                filterjob.Add(item.Value);
            }
        }

        List<string> filterhosp = new List<string>();
        foreach (ListItem item in cblHospital.Items)
        {
            if (item.Selected)
            {
                filterhosp.Add(item.Value);
            }
        }

        DateTime? sdate = null;
        DateTime? edate = null;
        if (rbByDate.Checked)
        {
            sdate = rdpDateBegin.SelectedDate;
            edate = rdpDateEnd.SelectedDate;
        }
        else
        {
            int cyear = Convert.ToInt32(ddlEduYear.SelectedValue);
            int session = Convert.ToInt32(ddlEduYearSession.SelectedValue);
            sdate = new DateTime(1911 + cyear, 8, 1).AddMonths(session * 6);
            edate = sdate.Value.AddMonths(6).AddDays(-1);
        }

        DataTable dt = service.GetTeachTimeListData(sdate.Value, edate.Value, CurrentActRate, CurrentRoleRate, CurrentMixRate, rcbSettingType.SelectedValue, CurrentJobCode, cbNeedStudent.Checked, cbNeedAtt.Checked, tbEmpCodes.Text, filterjob, filterhosp, htTargetType, cbShowActData.Checked, cbShowHealthTeach.Checked, null, cbLoadForm.Checked, true);

        DataSet ds = service.GetKPIImportData(dt);



        MemoryStream output = new MemoryStream();
        ZipOutputStream stream = new ZipOutputStream(output);
        stream.SetLevel(3);
        
        foreach (DataTable kdt in ds.Tables)
        {

            byte[] binaryData = System.Text.Encoding.Default.GetBytes(DTToCSV(kdt));


            stream.PutNextEntry(new ZipEntry(kdt.TableName + ".csv"));

            stream.Write(binaryData, 0, binaryData.Length);
        }
        stream.Finish();
        stream.Close();


        Response.Clear();
        Response.AddHeader("Content-Length", output.ToArray().Length.ToString());
        Response.ContentType = "application/octet-stream";
        Response.AddHeader("content-disposition", "attachment; filename=output.zip");
        Response.OutputStream.Write(output.ToArray(), 0, output.ToArray().Length);

        Response.Flush();
        Response.End();



    }


    public string DTToCSV(DataTable table)
    {
        var result = new StringBuilder();
        for (int i = 0; i < table.Columns.Count; i++)
        {
            result.Append(table.Columns[i].ColumnName);
            result.Append(i == table.Columns.Count - 1 ? "\n" : ",");
        }

        foreach (DataRow row in table.Rows)
        {
            for (int i = 0; i < table.Columns.Count; i++)
            {
                result.Append(row[i].ToString());
                result.Append(i == table.Columns.Count - 1 ? "\n" : ",");
            }
        }

        return result.ToString();
    }
}