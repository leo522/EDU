using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KMU.EduActivity.ApplicationLayer.DTO;
using System.Globalization;
using KMU.EduActivity.ApplicationLayer.Services;

public partial class EduTermEdit : AuthPage
{
    private EduTermDto CurrentData
    {
        get
        {
            return ViewState["CurrentEditEduTerm"] as EduTermDto;
        }
        set
        {
            ViewState["CurrentEditEduTerm"] = value;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            BindDeptment();
            BindTeacher();
            dsJobCode.Select();
            if (Request.QueryString["EduTermID"] != null)
            {
                LoadEduTerm(Request.QueryString["EduTermID"].ToString());
                //tbEduStopCode.Enabled = false;
            }
            else
            {
                CurrentData = null;
                BindDept();
            }


            IFormatProvider yyyymmddFormat = new CultureInfo(String.Empty, false);

            if (Request.QueryString["sdate"] != null)
                rdpDateFrom.SelectedDate = DateTime.ParseExact(Request.QueryString["sdate"], "yyyyMMdd", yyyymmddFormat);
            if (Request.QueryString["edate"] != null)
                rdpDateTo.SelectedDate = DateTime.ParseExact(Request.QueryString["edate"], "yyyyMMdd", yyyymmddFormat);

            if (!this.AuthRoles.Contains("Admin"))
            {
                tbEduYear.Enabled = false;
                TreeViewComboBox1.Enabled = false;
                ddlHospital.Enabled = false;
                ddlDepartment.Enabled = false;
                tbEduStopCode.Enabled = false;
                tbName.Enabled = false;
                rdpDateFrom.Enabled = false;
                rdpDateTo.Enabled = false;
                rblType.Enabled = false;
                rntbStudentCount.Enabled = false;
                tbDes.Enabled = false;
            }
        }
    }
    private void LoadEduTerm(string id)
    {
        try
        {
            CurrentData = service.GetEduTermByID(id);

            tbEduStopCode.Text = CurrentData.EduStopCode;
            tbName.Text = CurrentData.Name;
            tbDes.Text = CurrentData.Des;
            if (CurrentData.DepCode != null)
            {
                rblType.SelectedIndex = 0;
                BindDept();
                ddlUnit.SelectedValue = CurrentData.DepCode;
            }
            if (CurrentData.NStation != null)
            {
                rblType.SelectedIndex = 1;
                BindNstation();
                ddlUnit.SelectedValue = CurrentData.NStation;
            }
            if (CurrentData.CorchID != null)
            {
                rblType.SelectedIndex = 2;
                BindCorch();
                //ddlUnit.SelectedValue = CurrentData.CorchID;
                rcbVS.SelectedValue = CurrentData.CorchID;
            }

            if (CurrentData.EduYear != null)
            {
                tbEduYear.Text = CurrentData.EduYear;
            }

            if (CurrentData.JobCode != null)
            {
                TreeViewComboBox1.SelectedValue = CurrentData.JobCode;
                if (ViewState["CurrentJobCode"] != null)
                {
                    if ((ViewState["CurrentJobCode"] as List<V_CodeRefDto>).Where(c => c.Code == CurrentData.JobCode).FirstOrDefault() != null)
                    {
                        TreeViewComboBox1.SelectedText = (ViewState["CurrentJobCode"] as List<V_CodeRefDto>).Where(c => c.Code == CurrentData.JobCode).FirstOrDefault().Name;
                    }
                }
                
            }

            if (CurrentData.Hospital != null)
            {
                ddlHospital.SelectedValue = CurrentData.Hospital.Value.ToString();
            }

            if (CurrentData.Department != null)
            {
                ddlDepartment.SelectedValue = CurrentData.Department;
            }


            if (CurrentData.DateFrom != Convert.ToDateTime(null))
            {
                rdpDateFrom.SelectedDate = CurrentData.DateFrom;
            }

            if (CurrentData.DateTo != Convert.ToDateTime(null))
            {
                rdpDateTo.SelectedDate = CurrentData.DateTo;
            }
            
            rntbStudentCount.Value = CurrentData.Capacity;

            EduRefTeacherDto deptTeacher = service.GetTermTeacher(id, "DeptTeacher");
            if (deptTeacher != null)
            {
                rcbTeacher.SelectedValue = deptTeacher.TeacherID;
            }
            else
            {
                rcbTeacher.SelectedValue = null;
            }

            EduRefTeacherDto eBMTeacher = service.GetTermTeacher(id, "EBM");
            if (eBMTeacher != null)
            {
                rcbEBM.SelectedValue = eBMTeacher.TeacherID;
            }
            else
            {
                rcbEBM.SelectedValue = null;
            }

            EduRefTeacherDto cRTeacher = service.GetTermTeacher(id, "CR");
            if (cRTeacher != null)
            {
                rcbCR.SelectedValue = cRTeacher.TeacherID;
            }
            else
            {
                rcbCR.SelectedValue = null;
            }

            EduRefTeacherDto tMasterTeacher = service.GetTermTeacher(id, "TMaster");
            if (tMasterTeacher != null)
            {
                rcbTMaster.SelectedValue = tMasterTeacher.TeacherID;
            }
            else
            {
                rcbTMaster.SelectedValue = null;
            }

            EduRefTeacherDto nurseDTeacher = service.GetTermTeacher(id, "NURSED");
            if (nurseDTeacher != null)
            {
                rcbNurseD.SelectedValue = nurseDTeacher.TeacherID;
            }
            else
            {
                rcbNurseD.SelectedValue = null;
            }

            EduRefTeacherDto projMTeacher = service.GetTermTeacher(id, "ProjM");
            if (projMTeacher != null)
            {
                rcbProjM.SelectedValue = projMTeacher.TeacherID;
            }
            else
            {
                rcbProjM.SelectedValue = null;
            }


            tbSchoolSeq1.Text = CurrentData.SchoolSeqNo1;
            tbSchoolSeq2.Text = CurrentData.SchoolSeqNo2;

        }
        catch (Exception ex)
        {
            ShowMessage("資料錯誤:" + ex.Message);
            CloseWindow(false);
        }
    }
    private bool CheckInput()
    {
        //if (tbEduStopCode.Text.Trim() == "")
        //{
        //    ShowMessage("未輸入課程代碼");
        //    return false;
        //}

        if (tbName.Text.Trim() == "")
        {
            ShowMessage("未輸入 課程名稱");
            return false;
        }
        if (rdpDateFrom.SelectedDate == null)
        {
            ShowMessage("未選擇 課程日期");
            return false;
        }
        if (rdpDateTo.SelectedDate == null)
        {
            ShowMessage("未選擇 課程日期");
            return false;
        }

        if (rdpDateFrom.SelectedDate.Value > rdpDateTo.SelectedDate)
        {
            ShowMessage("課程日期設定錯誤");
            return false;
        }

        if (ddlUnit.SelectedValue == null || ddlUnit.SelectedValue == "")
        {
            ShowMessage("未選擇 單位/VS");
            return false;
        }
        if (rntbStudentCount.Value == null)
        {
            ShowMessage("未輸入 人數");
            return false;
        }

        try
        {
            int year = Convert.ToInt32(tbEduYear.Text);
            tbEduYear.Text = year.ToString("000");
        }
        catch
        {
            ShowMessage("年度 格式錯誤");
            return false;
        }


        if (tbEduYear.Text.Length != 3)
        {
            ShowMessage("請輸入年度(三碼)");
            return false;
        }



        if (TreeViewComboBox1.SelectedValue == null || TreeViewComboBox1.SelectedValue == "")
        {
            ShowMessage("未選擇 職稱");
            return false;
        }

        if (ddlHospital.SelectedValue == null || ddlHospital.SelectedValue == "")
        {
            ShowMessage("未選擇 院區");
            return false;
        }

        if (ddlDepartment.SelectedValue == null || ddlDepartment.SelectedValue == "")
        {
            ShowMessage("未選擇 部門");
            return false;
        }

        //if (ddlTeacher.SelectedValue == "" || ddlTeacher.SelectedValue == null)
        //{
        //    ShowMessage("未選擇科導師");
        //    return false;
        //}


        return true;
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (!CheckInput())
        {
            return;
        }

        EduTermDto dto = null;
        if (CurrentData != null)
        {
            dto = CurrentData;
        }
        else
        {
            dto = new EduTermDto();
        }

        string deptcode = ddlDepartment.SelectedValue;

        while (deptcode.Length < 6)
        {
            deptcode += "0";
        }

        tbEduStopCode.Text = tbEduYear.Text + TreeViewComboBox1.SelectedValue + ddlHospital.SelectedValue + deptcode;
        dto.EduStopCode = tbEduStopCode.Text;
        dto.EduYear = tbEduYear.Text;
        dto.JobCode = TreeViewComboBox1.SelectedValue;
        dto.Hospital = ddlHospital.SelectedValue.ToCharArray()[0];
        dto.Department = ddlDepartment.SelectedValue;

        dto.Name = tbName.Text;
        dto.DateFrom = rdpDateFrom.SelectedDate.Value;
        dto.DateTo = rdpDateTo.SelectedDate.Value;
        dto.Des = tbDes.Text;
        dto.Capacity = Convert.ToInt32(rntbStudentCount.Value.Value);
        dto.SchoolSeqNo1 = tbSchoolSeq1.Text.Trim();
        dto.SchoolSeqNo2 = tbSchoolSeq2.Text.Trim();

        if (dto.RoundCode == null)
        {
            dto.RoundCode = tbEduStopCode.Text;
        }
        dto.EBM = rcbEBM.SelectedValue;

        dto.CR = rcbCR.SelectedValue;

        dto.ProjM = rcbProjM.SelectedValue;
        dto.TMaster = rcbTMaster.SelectedValue;
        dto.NurseD = rcbNurseD.SelectedValue;

        switch (rblType.SelectedIndex)
        {
            case 0:
                dto.DepCode = ddlUnit.SelectedValue;
                dto.NStation = null;
                dto.CorchID = null;
                break;
            case 1:
                dto.DepCode = null;
                dto.NStation = ddlUnit.SelectedValue;
                dto.CorchID = null;
                break;
            case 2:
                dto.DepCode = null;
                dto.NStation = null;
                dto.CorchID = rcbVS.SelectedValue;
                break;
        }

        dto.Teacher = rcbTeacher.SelectedValue;

        if (CurrentData != null)
        {
            service.UpdateEduTerm(dto);
        }
        else
        {
            dto.Creater = this.EmpCode;
            service.InsertEduTerm(dto);
        }

        CloseWindow(false);
    }
    protected void rblType_SelectedIndexChanged(object sender, EventArgs e)
    {
        switch (rblType.SelectedIndex)
        {
            case 0:
                BindDept();
                break;
            case 1:
                BindNstation();
                break;
            case 2:
                BindCorch();
                break;
        }
    }

    private void BindDeptment()
    {
        List<SelectGroupTypeDto> list = service.GetTermUnit("EduAct_Dept");
        ddlDepartment.DataValueField = "code";
        ddlDepartment.DataTextField = "Name";
        ddlDepartment.DataSource = list;
        ddlDepartment.DataBind();
    }

    private void BindDept()
    {
        rcbVS.Visible = false;
        divUnit.Attributes.Remove("style");
        List<SelectGroupTypeDto> list = service.GetTermUnit("EduAct_Dept");
        ddlUnit.DataValueField = "code";
        ddlUnit.DataTextField = "Name";
        ddlUnit.DataSource = list;
        ddlUnit.DataBind();
    }

    private void BindNstation()
    {
        rcbVS.Visible = false;
        divUnit.Attributes.Remove("style");
        List<SelectGroupTypeDto> list = service.GetTermUnit("EduAct_Station");
        ddlUnit.DataValueField = "code";
        ddlUnit.DataTextField = "Name";
        ddlUnit.DataSource = list;
        ddlUnit.DataBind();
        

    }

    private void BindCorch()
    {
        rcbVS.Visible = true;
        divUnit.Attributes.Add("style", "display:none");
        List<SelectKmuVsDto> list = EduActivityAppService.GetKmuVs(CurrentData.DepCode);
        ddlUnit.DataValueField = "code";
        ddlUnit.DataTextField = "displayname";
        ddlUnit.DataSource = list;
        ddlUnit.DataBind();

        //rcbVS.DataValueField = "code";
        //rcbVS.DataTextField = "displayname";
        //rcbVS.DataSource = list;
        //rcbVS.DataBind();
    }


    private void BindTeacher()
    {
        List<SelectKmuVsDto> list = EduActivityAppService.GetKmuVs(CurrentData == null ? null : CurrentData.DepCode);
        SelectKmuVsDto nulldto = new SelectKmuVsDto();
        nulldto.code = null;
        nulldto.name = "";
        list.Insert(0, nulldto);

        //rcbEBM.DataValueField = "code";
        //rcbEBM.DataTextField = "displayname";
        //rcbEBM.DataSource = list;
        //rcbEBM.DataBind();

        //rcbVS.DataValueField = "code";
        //rcbVS.DataTextField = "displayname";
        //rcbVS.DataSource = list;
        //rcbVS.DataBind();

        //rcbTeacher.DataValueField = "code";
        //rcbTeacher.DataTextField = "displayname";
        //rcbTeacher.DataSource = list;
        //rcbTeacher.DataBind();


        //rcbCR.DataValueField = "code";
        //rcbCR.DataTextField = "displayname";
        //rcbCR.DataSource = list;
        //rcbCR.DataBind();
    }
    protected void dsJobCode_Selected(object sender, ObjectDataSourceStatusEventArgs e)
    {
        ViewState["CurrentJobCode"] = e.ReturnValue as List<V_CodeRefDto>;
    }
}