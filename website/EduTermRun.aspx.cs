using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KMU.EduActivity.ApplicationLayer.DTO;
using Telerik.Web.UI;
using KMU.EduActivity.ApplicationLayer.Services;

public partial class EduTermRun : AuthPage
{
    private EduTermDto CurrentData
    {
        get
        {
            return ViewState["CurrentOpenCourseEduTerm"] as EduTermDto;
        }
        set
        {
            ViewState["CurrentOpenCourseEduTerm"] = value;
        }
    }

    private List<EduTermDto> CurrentList
    {
        get
        {
            return ViewState["OpenCourseEduTermList"] as List<EduTermDto>;
        }
        set
        {
            ViewState["OpenCourseEduTermList"] = value;
        }
    }

    private List<EduTeamRundownDto> CurrentRundownList
    {
        get
        {
            return ViewState["OpenCourseEduTeamRundownList"] as List<EduTeamRundownDto>;
        }
        set
        {
            ViewState["OpenCourseEduTeamRundownList"] = value;
        }
    }

    private List<EduTeamRundownDto> CurrentInputRundownList
    {
        get
        {
            return ViewState["CurrentInputRundownList"] as List<EduTeamRundownDto>;
        }
        set
        {
            ViewState["CurrentInputRundownList"] = value;
        }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        TreeViewComboBox2.SelectedChanged += new EventHandler(TreeViewComboBox2_SelectedChanged);
        if (!IsPostBack)
        {
            if (Request.QueryString["EduTermID"] != null)
            {
                BindDeptment();
                dsJobCode.Select();
                LoadEduTerm(Request.QueryString["EduTermID"].ToString());
                BindEduTeamRundown();
                rblType.SelectedIndex = 0;
                BindDept();
                BindTeacher();
                BindInputTime();
                rgAddTime.DataBind();
                string id = Request.QueryString["EduTermID"].ToString();
                EduRefTeacherDto deptTeacher = service.GetTermTeacher(id, "DeptTeacher");
                if (deptTeacher != null)
                {
                    ddlTeacher.SelectedValue = deptTeacher.TeacherID;
                }

                EduRefTeacherDto eBMTeacher = service.GetTermTeacher(id, "EBM");
                if (eBMTeacher != null)
                {
                    ddlEBM.SelectedValue = eBMTeacher.TeacherID;
                }
                else
                {
                    ddlEBM.SelectedValue = null;
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

                EduRefTeacherDto projMTeacher = service.GetTermTeacher(id, "ProjM");
                if (projMTeacher != null)
                {
                    rcbProjM.SelectedValue = projMTeacher.TeacherID;
                }
                else
                {
                    rcbProjM.SelectedValue = null;
                }

            }
            else
            {
                ShowMessage("參數錯誤");
                CloseWindow(false);
            }

        }
    }

    private void BindInputTime()
    {
        if(CurrentInputRundownList == null)
        {
            CurrentInputRundownList = new List<EduTeamRundownDto>();
            
        }


        rgAddTime.DataSource = CurrentInputRundownList;
    }

    void TreeViewComboBox2_SelectedChanged(object sender, EventArgs e)
    {
        BindEduTeamRundown();
    }
    private void BindDeptment()
    {
        List<SelectGroupTypeDto> list = service.GetTermUnit("EduAct_Dept");
        ddlDepartment.DataValueField = "code";
        ddlDepartment.DataTextField = "Name";
        ddlDepartment.DataSource = list;
        ddlDepartment.DataBind();
    }

    private void BindEduTeamRundown()
    {

        List<EduTeamRundownDto> list = service.GetEduTeamRundownListByEduTermId(CurrentData, TreeViewComboBox2.SelectedValue);
        CurrentRundownList = list;
        //cblEduTeamRundown.DataTextField = "DateFromToStr";
        //cblEduTeamRundown.DataValueField = "EduTeamStopID";
        //cblEduTeamRundown.DataSource = list;
        //cblEduTeamRundown.DataBind();


        //palEduStopCode.Controls.Clear();
        //foreach (EduTeamRundownDto dto in list)
        //{
            
        //    TextBox tb = new TextBox();
        //    tb.Width = 80;
        //    tb.ID = "tb_"+ dto.EduTeamStopID;
            
        //    palEduStopCode.Controls.Add(tb);
        //}

        RadGrid2.DataSource = list;
        RadGrid2.DataBind();

    }


    private void LoadEduTerm(string id)
    {
        try
        {
            CurrentData = service.GetEduTermByID(id);
            lblEduStopCode.Text = CurrentData.EduStopCode;
            lblName.Text = CurrentData.Name;
            lblDate.Text = CurrentData.DateFromToStr;
            lblMemberCount.Text = CurrentData.Capacity.ToString() + "人";

            if (CurrentData.EduYear != null)
            {
                tbEduYear.Text = CurrentData.EduYear;
            }

            if (CurrentData.JobCode != null)
            {
                TreeViewComboBox1.SelectedValue = CurrentData.JobCode;
                if (ViewState["CurrentJobCode"] != null)
                {
                    TreeViewComboBox1.SelectedText = (ViewState["CurrentJobCode"] as List<V_CodeRefDto>).Where(c => c.Code == CurrentData.JobCode).FirstOrDefault().Name;
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

        bool ischecked = false;

        bool allhasname = true;

        if (rpvSelect.Selected)
        {
            foreach (GridItem item in RadGrid2.SelectedItems)
            {
                ischecked = true;
                if ((item.FindControl("tbEduTermName") as TextBox).Text.Trim() == "")
                {
                    allhasname = false;
                }
            }
        }
        else
        {
            if (CurrentInputRundownList.Count > 0)
            {
                ischecked = true;
            }

            foreach (GridItem item in rgAddTime.Items)
            {
                if (item is GridDataItem)
                {
                    if ((item.FindControl("tbEduTermName0") as TextBox).Text.Trim() == "")
                    {
                        allhasname = false;
                    }
                }
            }
        }


        if (!allhasname)
        {
            if (tbName.Text.Trim() == "")
            {
                ShowMessage("未輸入 課程名稱");
                return false;
            }
        }

        //foreach (ListItem item in cblEduTeamRundown.Items)
        //{
        //    if (item.Selected)
        //    {
        //        ischecked = true;
        //        TextBox tb = null;

        //        //Control ctr = this.FindControl("tb_" + item.Value);

        //        //if (ctr != null)
        //        //{
        //        //    tb = ctr as TextBox;
        //        //}

        //        //if (tb.Text.Trim() == "")
        //        //{
        //        //    ShowMessage("課程日期：" + item.Text + ", 未輸入 課程代碼");
        //        //    return false;
        //        //}

        //        foreach (Control ctr in palEduStopCode.Controls)
        //        {

        //            if (ctr.ID == "tb_" + item.Value)
        //            {
        //                tb = ctr as TextBox;
        //            }
        //            if (tb.Text.Trim() == "")
        //            {
        //                ShowMessage("課程日期：" + item.Text + ", 未輸入 課程代碼");
        //                return false;
        //            }
        //        }
        //    }
        //}

        //foreach (GridItem item in RadGrid2.SelectedItems)
        //{
        //    ischecked = true;
        //    TextBox tb = item.FindControl("tbEduTermCode") as TextBox;

        //    if (tb.Text.Trim() == "")
        //    {
        //        EduTeamRundownDto dto = CurrentRundownList[item.DataSetIndex];
        //        ShowMessage("課程日期：" + dto.DateFromToStr + ", 未輸入 課程代碼");
        //        return false;
        //    }
        //}


        if (!ischecked)
        {
            ShowMessage("未選擇 課程日期");
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


        return true;
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (!CheckInput())
        {
            return;
        }

        if (rpvSelect.Selected)
        {
            foreach (GridItem item in RadGrid2.SelectedItems)
            {
                if (item.Selected)
                {

                    EduTeamRundownDto rundown = CurrentRundownList[item.DataSetIndex];
                    if (rundown != null)
                    {





                        //TextBox tb = item.FindControl("tbEduTermCode") as TextBox;



                        DateTime datefrom = rundown.DateFrom;
                        DateTime dateto = rundown.DateTo;

                        EduTermDto dto = null;
                        dto = new EduTermDto();


                        string deptcode = ddlDepartment.SelectedValue;

                        while (deptcode.Length < 6)
                        {
                            deptcode += "0";
                        }

                        string edustopcode = tbEduYear.Text + TreeViewComboBox1.SelectedValue + ddlHospital.SelectedValue + deptcode;
                        dto.EduStopCode = edustopcode;
                        dto.EduYear = tbEduYear.Text;
                        dto.JobCode = TreeViewComboBox1.SelectedValue;
                        dto.Hospital = ddlHospital.SelectedValue.ToCharArray()[0];
                        dto.Department = ddlDepartment.SelectedValue;


                        //dto.EduStopCode = CurrentData.EduStopCode; //tb.Text;//tbEduStopCode.Text;
                        string setname = (item.FindControl("tbEduTermName") as TextBox).Text.Trim();
                        if (setname == "")
                        {
                            dto.Name = tbName.Text;
                        }
                        else
                        {
                            dto.Name = setname;
                        }
                        dto.DateFrom = datefrom;
                        dto.DateTo = dateto;
                        dto.Des = tbDes.Text;
                        dto.Capacity = Convert.ToInt32(rntbStudentCount.Value.Value);
                        dto.RoundCode = CurrentData.RoundCode + "|" + CurrentData.EduStopCode;//tb.Text;
                        dto.Teacher = ddlTeacher.SelectedValue;
                        dto.CR = rcbCR.SelectedValue;
                        dto.EBM = ddlEBM.SelectedValue;
                        dto.ProjM = rcbProjM.SelectedValue;
                        dto.TMaster = rcbTMaster.SelectedValue;

                        dto.Creater = this.EmpCode;
                        dto.ParentEduTermID = CurrentData.EduTermID;

                        switch (rblType.SelectedIndex)
                        {
                            case 0:
                                dto.DepCode = ddlUnit.SelectedValue;
                                break;
                            case 1:
                                dto.NStation = ddlUnit.SelectedValue;
                                break;
                            case 2:
                                dto.CorchID = rcbVS.SelectedValue;
                                break;
                        }

                        service.InsertEduTerm(dto);
                    }
                }
            }
        }
        else
        {
            foreach (GridDataItem item in rgAddTime.Items)
            {
                DateTime datefrom = Convert.ToDateTime(item.GetDataKeyValue("DateFrom"));
                DateTime dateto = Convert.ToDateTime(item.GetDataKeyValue("DateTo"));

                EduTermDto dto = null;
                dto = new EduTermDto();


                string deptcode = ddlDepartment.SelectedValue;

                while (deptcode.Length < 6)
                {
                    deptcode += "0";
                }

                string edustopcode = tbEduYear.Text + TreeViewComboBox1.SelectedValue + ddlHospital.SelectedValue + deptcode;
                dto.EduStopCode = edustopcode;
                dto.EduYear = tbEduYear.Text;
                dto.JobCode = TreeViewComboBox1.SelectedValue;
                dto.Hospital = ddlHospital.SelectedValue.ToCharArray()[0];
                dto.Department = ddlDepartment.SelectedValue;


                //dto.EduStopCode = CurrentData.EduStopCode; //tb.Text;//tbEduStopCode.Text;
                string setname = (item.FindControl("tbEduTermName0") as TextBox).Text.Trim();
                if (setname == "")
                {
                    dto.Name = tbName.Text;
                }
                else
                {
                    dto.Name = setname;
                }
                dto.DateFrom = datefrom;
                dto.DateTo = dateto;
                dto.Des = tbDes.Text;
                dto.Capacity = Convert.ToInt32(rntbStudentCount.Value.Value);
                dto.RoundCode = CurrentData.RoundCode + "|" + CurrentData.EduStopCode;//tb.Text;
                dto.Teacher = ddlTeacher.SelectedValue;
                dto.CR = rcbCR.SelectedValue;
                dto.EBM = ddlEBM.SelectedValue;
                dto.Creater = this.EmpCode;
                dto.ParentEduTermID = CurrentData.EduTermID;

                switch (rblType.SelectedIndex)
                {
                    case 0:
                        dto.DepCode = ddlUnit.SelectedValue;
                        break;
                    case 1:
                        dto.NStation = ddlUnit.SelectedValue;
                        break;
                    case 2:
                        dto.CorchID = rcbVS.SelectedValue;
                        break;
                }

                service.InsertEduTerm(dto);
            }

        }


        CloseWindow(true);
        //ReadData();
        //RadGrid1.DataBind();

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

    private void BindDept()
    {
        rcbVS.Visible = false;
        divUnit.Attributes.Remove("style");
        //ddlUnit.Visible = false;
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
        //ddlUnit.Enabled = true;
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
        //ddlUnit.Enabled = false;
        //List<SelectKmuVsDto> list = EduActivityAppService.GetKmuVs(CurrentData.DepCode);
        //rcbVS.DataValueField = "code";
        //rcbVS.DataTextField = "Name";
        //rcbVS.DataSource = list;
        //rcbVS.DataBind();
    }
    private void BindTeacher()
    {
        //List<SelectKmuVsDto> list = EduActivityAppService.GetKmuVs(CurrentData.DepCode);
        //SelectKmuVsDto nulldto = new SelectKmuVsDto();
        //nulldto.code = null;
        //nulldto.name = "";
        //list.Insert(0, nulldto);
        //ddlTeacher.DataValueField = "code";
        //ddlTeacher.DataTextField = "Name";
        //ddlTeacher.DataSource = list;
        //ddlTeacher.DataBind();

        //ddlEBM.DataValueField = "code";
        //ddlEBM.DataTextField = "Name";
        //ddlEBM.DataSource = list;
        //ddlEBM.DataBind();

        //rcbCR.DataValueField = "code";
        //rcbCR.DataTextField = "Name";
        //rcbCR.DataSource = list;
        //rcbCR.DataBind();

        
    }

    private void ReadData()
    {
        RadGrid1.DataSource = null;
        RadGrid1.MasterTableView.DataKeyNames = new string[] { "EduTermID" };

        List<EduTermDto> list = service.GetEduTermListByParent(CurrentData.EduTermID);
        CurrentList = list;
        RadGrid1.DataSource = list;
    }
    protected void RadGrid1_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        ReadData();
    }
    protected void dsJobCode_Selected(object sender, ObjectDataSourceStatusEventArgs e)
    {
        ViewState["CurrentJobCode"] = e.ReturnValue as List<V_CodeRefDto>;
    }
    protected void btnAddTime_Click(object sender, EventArgs e)
    {
        if (rdtpSTime.SelectedDate == null || rdtpETime.SelectedDate == null)
        {
            ShowMessage("未輸入開始、結束時間");
            return;
        }

        if (rdtpSTime.SelectedDate.Value > rdtpETime.SelectedDate)
        {
            ShowMessage("開始時間不可晚於結束時間");
            return;
        }
        if (CurrentInputRundownList.Count(c => c.DateFrom == rdtpSTime.SelectedDate.Value && c.DateTo == rdtpETime.SelectedDate.Value) > 0)
        {
            ShowMessage("指定時間已存在");
            return;
        }
        CurrentInputRundownList.Add(new EduTeamRundownDto() { DateFrom = rdtpSTime.SelectedDate.Value, DateTo = rdtpETime.SelectedDate.Value, DateFromToStr = rdtpSTime.SelectedDate.Value.ToString("yyyy/MM/dd HH:mm") + "~" + rdtpETime.SelectedDate.Value.ToString("yyyy/MM/dd HH:mm") });
        rgAddTime.DataSource = CurrentInputRundownList;
        rgAddTime.DataBind();

    }
    protected void rgAddTime_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        rgAddTime.DataSource = CurrentInputRundownList;
    }

    protected void rgAddTime_DeleteCommand(object sender, GridCommandEventArgs e)
    {
        if(e.Item is GridDataItem)
        {
            DateTime stime = Convert.ToDateTime((e.Item as GridDataItem).GetDataKeyValue("DateFrom"));
            DateTime etime = Convert.ToDateTime((e.Item as GridDataItem).GetDataKeyValue("DateTo"));

            CurrentInputRundownList.Remove(CurrentInputRundownList.Where(c => c.DateFrom == stime && c.DateTo == etime).FirstOrDefault());
            rgAddTime.DataSource = CurrentInputRundownList;
            rgAddTime.DataBind();
            
        }
    }
}