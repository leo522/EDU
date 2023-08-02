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
using System.Data;

public partial class EduStopActScheduleTarget : AuthPage
{
    private string ScheduleID
    {
        get
        {
            return Request.QueryString["ID"];
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
            //lbTotalCount.Text = value.Count.ToString();
            ViewState["EduActTargetList"] = value;
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


    private DateTime SelectTimeFrom
    {
        get
        {
            return new DateTime(CurrentSchedule.TimeFrom.Year, CurrentSchedule.TimeFrom.Month, CurrentSchedule.TimeFrom.Day, rdtpTimeBegin.SelectedDate.Value.Hour, rdtpTimeBegin.SelectedDate.Value.Minute, rdtpTimeBegin.SelectedDate.Value.Second);
        }
    }

    private DateTime SelectTimeTo
    {
        get
        {
            return new DateTime(CurrentSchedule.TimeFrom.Year, CurrentSchedule.TimeFrom.Month, CurrentSchedule.TimeFrom.Day, rdtpTimeEnd.SelectedDate.Value.Hour, rdtpTimeEnd.SelectedDate.Value.Minute, rdtpTimeEnd.SelectedDate.Value.Second);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.AddPostbackControl(btnUpload);
        this.AddPostbackControl(btnExport);
        
        this.AddPostbackControl(lbRoleTypeList);
        if (!IsPostBack)
        {
            if (ScheduleID != null)
            {
                BindDept();
                
                ddlUnit.SelectedValue = this.DeptCode;
                ddlUnit_SelectedIndexChanged(ddlUnit, null);
                ReadSchedule();
                BindRoles();
                rdtpTimeBegin.SelectedDate = CurrentSchedule.TimeFrom;
                rdtpTimeEnd.SelectedDate = CurrentSchedule.TimeTo;
            }
            else
            {
                ShowMessageAndGo("參數傳遞錯誤!", "EduStopActScheduleCalendar.aspx");
                return;
            }
            if (this.AuthRoles != null && (this.AuthRoles.Contains("DepSec") || this.AuthRoles.Contains("Teacher") || this.AuthRoles.Contains("Admin") || this.AuthRoles.Contains("ActWriter")))
            {
                List<string> childdepts = service.GetChildDepts(this.DeptCode);

                if (childdepts.Contains(CurrentSchedule.DeptCode))
                {
                    ViewState["AllowEdit"] = "Y";
                }
            }


            if (CurrentSchedule.Creater != this.EmpCode && (this.AuthRoles != null && !this.AuthRoles.Contains("Admin") && !this.AuthRoles.Contains("DepSec")) && (ViewState["AllowEdit"] == null || ViewState["AllowEdit"].ToString() != "Y"))
            {
                EditPanel.Enabled = false;
                btnSave.Enabled = false;
            }
            else
            {
                EditPanel.Enabled = true;
                btnSave.Enabled = true;
                dsTargetType.Select();
                dsTermCode.Select();
            }
        }
        else
        {
            if (PostBackControl != btnImportRegistList)
            {
                lbImportMsg.Text = "";
            }
            switch (rblTargetType.SelectedValue)
            {
                case "EmpCode":
                    palEmp.Visible = true;
                    divTeam.Style.Clear();
                    divTeam.Style.Add("display", "none");
                    //palTeam.Visible = false;
                    break;
                case "TeamCode":
                    palEmp.Visible = false;
                    divTeam.Style.Clear();
                    //palTeam.Visible = false;
                    break;
            }
        }
    }

    private void BindRoles()
    {
        List<V_CodeRefDto> list = service.GetRoleList(CurrentSchedule.EduStopActScheduleID, CurrentSchedule.TimeFrom.Date);
        rcbRole.DataSource = list;
        rcbRole.DataBind();
    }

    private void BindDept()
    {
        List<SelectGroupTypeDto> list = service.GetTermUnit("EduAct_Dept");
        ddlUnit.DataValueField = "code";
        ddlUnit.DataTextField = "Name";
        ddlUnit.DataSource = list;
        ddlUnit.DataBind();
    }

    private void ReadSchedule()
    {
        EduStopActScheduleDto sche = service.GetEduStopActSchedulerByID(ScheduleID);
        CurrentSchedule = sche;

        Dictionary<int, EduActTypeDto> acttypes = service.GetActTypeWithParent(Convert.ToInt32(sche.ActType));

        if (acttypes.ContainsKey(0))
        {
            lbActType.Text += acttypes[0].CLS_NAME;
        }

        if (acttypes.ContainsKey(1))
        {
            lbActType.Text += " - " + acttypes[1].CLS_NAME;
        }

        if (acttypes.ContainsKey(2))
        {
            lbActType.Text += " - " + acttypes[2].CLS_NAME;
        }

        if (acttypes.ContainsKey(3))
        {
            lbActType.Text += " - " + acttypes[3].CLS_NAME;
        }

        lbActName.Text = sche.ActName;
        lbActDate.Text = sche.TimeFrom.ToString("yyyy/MM/dd HH:mm") + "~" + sche.TimeTo.ToString("yyyy/MM/dd HH:mm");
        
        lbActLocation.Text = sche.Location;
        string teacher = "";
        CurrentTargetList = service.GetEduActTargets(ScheduleID).OrderBy(c => c.TimeFrom).ToList();
        foreach (EduActTargetDto target in CurrentTargetList)
        {
            if (target.RoleType == "teacher" || target.RoleType == "005")
            {
                teacher += target.RoleName + "　";
            }
        }

        rgTarget.DataSource = CurrentTargetList;
        cbOutSide.Checked = CurrentSchedule.HasOutSideStudent;

        lbTotalCount.Text = CurrentTargetList.Count.ToString();

        if(CurrentSchedule.AllowBooking)
        {
            btnImportRegistList.Visible = true;
        }
        else
        {
            btnImportRegistList.Visible = false;
        }
    }


    protected void odsAttachment_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        e.InputParameters["eduStopActScheduleID"] = ScheduleID;
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        Response.Redirect("EduStopActScheduleAdd.aspx?id=" + ScheduleID);
    }
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        switch (rblTargetType.SelectedValue)
        {
            case "EmpCode":
                palEmp.Visible = true;
                divTeam.Style.Clear();
                divTeam.Style.Add("display", "none");
                //palTeam.Visible = false;
                break;
            case "TeamCode":
                palEmp.Visible = false;
                divTeam.Style.Clear();
                //palTeam.Visible = false;
                break;
        }
    }
   
    protected void btnAddTarget_Click(object sender, EventArgs e)
    {
        if (rdtpTimeBegin.SelectedTime != null && rdtpTimeBegin.SelectedTime.Value < CurrentSchedule.TimeFrom.TimeOfDay)
        {
            ShowMessage("選擇時間超出活動範圍");
            return;
        }

        if (rdtpTimeEnd.SelectedTime != null && rdtpTimeEnd.SelectedTime.Value > CurrentSchedule.TimeTo.TimeOfDay)
        {
            ShowMessage("選擇時間超出活動範圍");
            return;
        }

        if (rcbRole.SelectedValue == null || rcbRole.SelectedValue == "")
        {
            ShowMessage("未選擇角色");
            return;
        }
        string empcode = "";


        if (sender == btnAddTargetEmp)
        {
            empcode = VsSelector1.SelectedValue;
        }

        if (sender == btnAddTarget)
        {
            empcode = ddlEmpByDept.SelectedValue;

        }

        if (CurrentTargetList.Count(c => c.TargetID == empcode && c.TimeFrom == SelectTimeFrom && c.TimeTo == SelectTimeTo ) > 0)
        {
            ShowMessage("指定人員已存在");
            return;
        }
        string checkresult =service.CheckExistsActTarget(empcode, SelectTimeFrom, SelectTimeTo, CurrentSchedule.EduStopActScheduleID);
        if (checkresult != null)
        {
            ShowMessage("員工編號:" + empcode + " 同時段已出席其他活動 " + checkresult);
            return;
        }


        List<EduActTargetDto> addlist = new List<EduActTargetDto>();
        try
        {

            switch (rblTargetType.SelectedValue)
            {
                case "EmpCode":

                    EduActTargetDto dto = new EduActTargetDto();
                    dto.TargetType = rblTargetType.SelectedValue;
                    dto.TargetID = empcode;
                    dto.RoleType = rcbRole.SelectedValue;
                    KMU.EduActivity.DomainModel.Entities.SelectVKmuempData empdata = service.ReadVKmuempData(empcode);
                    dto.TargetJob = empdata.jobcode;
                    dto.TargetJobName = empdata.jobname;
                    if (palTimeRange.Visible)
                    {
                        string check = CheckTargetTimeRange();
                        if (check != null)
                        {
                            ShowMessage(check);
                            return;
                        }
                        dto.TimeFrom = SelectTimeFrom;
                        dto.TimeTo = SelectTimeTo;
                    }
                    dto = service.FillEduActTargetName(dto);
                    addlist.Add(dto);

                    break;
                case "TeamCode":
                    EduActTargetDto tdto = new EduActTargetDto();
                    tdto.TargetType = rblTargetType.SelectedValue;
                    tdto.TargetID = TreeViewComboBox1.SelectedValue;
                    tdto = service.FillEduActTargetName(tdto);
                    addlist.Add(tdto);
                    break;
            }




            CurrentTargetList.AddRange(addlist);//.Add(dto);



            CurrentTargetList = CurrentTargetList.OrderBy(c => c.TimeFrom).ToList();

            service.InsertEduActTargets(CurrentSchedule.EduStopActScheduleID, CurrentTargetList);

            rgTarget.DataSource = CurrentTargetList;
            rgTarget.DataBind();
            lbTotalCount.Text = CurrentTargetList.Count.ToString();
            VsSelector1.Clear();
            
        }
        catch (Exception ex)
        {
            ShowMessage("新增資料失敗:" + ex.Message);
        }
    }

    private string CheckTargetTimeRange()
    {
        if (rdtpTimeBegin.SelectedDate == null || rdtpTimeEnd.SelectedDate == null)
        {
            return "尚未設定時段";
        }


        return null;
    }

    private string CheckTargetData()
    {
    //    foreach (EduActTargetDto dto in CurrentTargetList)
    //    {
    //        if (CurrentTargetList.Count(c => c.TargetID == dto.TargetID 
    //&&
    //(
    //(c.TimeFrom.TimeOfDay >= dto.TimeFrom.TimeOfDay && c.TimeFrom.TimeOfDay <= dto.TimeTo.TimeOfDay)
    //|| (c.TimeTo.TimeOfDay >= dto.TimeFrom.TimeOfDay && c.TimeTo.TimeOfDay <= dto.TimeTo.TimeOfDay)
    //|| (c.TimeFrom.TimeOfDay <= dto.TimeFrom.TimeOfDay && c.TimeTo.TimeOfDay >= dto.TimeTo.TimeOfDay)
    //)
    //) > 1)
    //        {
    //            return "員工編號" + dto.TargetID + "，存在同時段重複身分資料";
    //        }
    //    }


        return null;
    }

    protected void rgTarget_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        rgTarget.DataSource = CurrentTargetList;
    }
    protected void rgTarget_ItemCommand(object sender, GridCommandEventArgs e)
    {
        if (e.CommandName == RadGrid.DeleteSelectedCommandName)
        {
            foreach (GridDataItem item in rgTarget.SelectedItems)
            {
                //RoleType,TargetID,TargetType,TimeFrom,TimeTo
                string RoleType = item.GetDataKeyValue("RoleType").ToString();
                string TargetID = item.GetDataKeyValue("TargetID").ToString();
                string TargetType = item.GetDataKeyValue("TargetType").ToString();
                DateTime? TimeFrom = null;
                if(item.GetDataKeyValue("TimeFrom")!=null)
                {
                    TimeFrom = Convert.ToDateTime(item.GetDataKeyValue("TimeFrom"));
                }

                DateTime? TimeTo = null;
                if(item.GetDataKeyValue("TimeTo")!=null)
                {
                    TimeTo = Convert.ToDateTime(item.GetDataKeyValue("TimeTo"));
                }

                EduActTargetDto dto = CurrentTargetList.Where(c => c.RoleType == RoleType && c.TargetID == TargetID && c.TargetType == TargetType && c.TimeFrom == TimeFrom && c.TimeTo == TimeTo).FirstOrDefault();
                if (dto != null)
                {
                    CurrentTargetList.Remove(dto);
                }
            }

            rgTarget.DataSource = CurrentTargetList;
            rgTarget.DataBind();
        }
        lbTotalCount.Text = CurrentTargetList.Count.ToString();

        service.InsertEduActTargets(CurrentSchedule.EduStopActScheduleID, CurrentTargetList);
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string result = CheckTargetData();
        if (result != null)
        {
            ShowMessage(result);
            return;
        }


        service.InsertEduActTargets(CurrentSchedule.EduStopActScheduleID, CurrentTargetList);
    }
    protected void rgTarget_DeleteCommand(object sender, GridCommandEventArgs e)
    {

    }
    protected void RadGrid1_NeedDataSource1(object sender, GridNeedDataSourceEventArgs e)
    {

    }

    protected void btnReturn_Click(object sender, EventArgs e)
    {
        Response.Redirect("EduStopActScheduleCalendar.aspx");
    }
    protected void rblTargetType_DataBound(object sender, EventArgs e)
    {
        if (rblTargetType.Items.Count > 0)
        {
            rblTargetType.Items[0].Selected = true;
        }
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            string filepath = Server.MapPath(".") + "\\temp\\";
            string filename = "(" + Guid.NewGuid().ToString() + ")" + FileUpload1.FileName;
            try
            {
                byte[] data = FileUpload1.FileBytes;
                FileStream fs = new FileStream(filepath + filename, FileMode.OpenOrCreate);
                fs.Write(data, 0, data.Length);
                fs.Close();

                DataTable dt = null;

                if (filename.ToLower().EndsWith(".dat"))
                {
                    //小白機
                    dt = Utility.ReadDatToDataTable(filepath + filename);
                    foreach (DataRow dr in dt.Rows)
                    {
                        dr[0] = service.GetCardEmpCode(dr[0].ToString());
                    }
                }
                else
                {
                    dt = Utility.ReadExcelAsTableNPOI(filepath + filename);
                }

                foreach (DataRow dr in dt.Rows)
                {
                    if (dr[0].ToString().Trim() != "")
                    {
                        string empcode = dr[0].ToString();
                        if(empcode.Length == 7 && empcode.StartsWith("0"))
                        {
                            empcode = empcode.Substring(1);
                        }
                        if (CurrentTargetList.Count(c => c.TargetID == dr[0].ToString()) == 0)
                        {
                            EduActTargetDto dto = new EduActTargetDto();
                            if (dt.Columns.Contains("roleid"))
                            {
                                try
                                {
                                    dto.RoleType = dr["roleid"].ToString();
                                }
                                catch (Exception ex)
                                {
                                    dto.RoleType = "Student";
                                }
                            }
                            else
                            {
                                dto.RoleType = "Student";
                            }
                            dto.TargetID = empcode;
                            dto.TargetType = "EmpCode";
                            dto.TimeFrom = CurrentSchedule.TimeFrom;
                            dto.TimeTo = CurrentSchedule.TimeTo;
                            dto = service.FillEduActTargetName(dto);
                            if (dt.Columns.Contains("CheckInTime"))
                            {
                                if (dr["CheckInTime"] != null && dr["CheckInTime"] != DBNull.Value && dr["CheckInTime"] != "")
                                {
                                    dto.CheckInTime = Convert.ToDateTime(dr["CheckInTime"]);
                                }
                            }
                            CurrentTargetList.Add(dto);
                        }
                    }
                }

                CurrentTargetList = CurrentTargetList.OrderBy(c => c.TimeFrom).ToList();
                //List<string> result = service.ImportTargets(ScheduleID, dt);

                //foreach (string msg in result)
                //{
                //    lblMsg.Text += msg + "<br />";
                //}


            }
            catch (Exception ex)
            {
                lblMsg.Text = "匯入失敗：" + ex.Message;
            }
            finally
            {
                try
                {
                    if (File.Exists(filepath + filename))
                    {
                        File.Delete(filepath + filename);
                    }
                }
                catch (Exception ex)
                {
                }

                //ReadSchedule();
                rgTarget.DataSource = CurrentTargetList;
                rgTarget.DataBind();
                lbTotalCount.Text = CurrentTargetList.Count.ToString();
                string msg = service.InsertEduActTargets(CurrentSchedule.EduStopActScheduleID, CurrentTargetList);
                if (msg != "")
                {
                    lblMsg.Text = msg;
                }
            }
        }
    }
    protected void rcbRole_SelectedIndexChanged1(object sender, EventArgs e)
    {
        //if (rcbRole.SelectedValue == "Teacher")
        //{
        //    palTimeRange.Visible = true;
        //}
        //else
        //{
        //    palTimeRange.Visible = false;
        //}
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        foreach (GridDataItem item in rgTarget.SelectedItems)
        {
            if (rcbRole.SelectedValue != "" && rcbRole.SelectedValue != null)
            {
                CurrentTargetList[item.DataSetIndex].RoleType = rcbRole.SelectedValue;
            }
            CurrentTargetList[item.DataSetIndex].TimeFrom = new DateTime(CurrentSchedule.TimeFrom.Year, CurrentSchedule.TimeFrom.Month, CurrentSchedule.TimeFrom.Day, rdtpTimeBegin.SelectedDate.Value.Hour, rdtpTimeBegin.SelectedDate.Value.Minute, rdtpTimeBegin.SelectedDate.Value.Second);
            CurrentTargetList[item.DataSetIndex].TimeTo = new DateTime(CurrentSchedule.TimeFrom.Year, CurrentSchedule.TimeFrom.Month, CurrentSchedule.TimeFrom.Day, rdtpTimeEnd.SelectedDate.Value.Hour, rdtpTimeEnd.SelectedDate.Value.Minute, rdtpTimeEnd.SelectedDate.Value.Second);
            CurrentTargetList[item.DataSetIndex] = service.FillEduActTargetName(CurrentTargetList[item.DataSetIndex]);
        }
        service.InsertEduActTargets(CurrentSchedule.EduStopActScheduleID, CurrentTargetList);
        rgTarget.DataSource = CurrentTargetList;
        rgTarget.DataBind();
        
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        DataTable dt = service.GetEduActTargetExportData(CurrentSchedule.EduStopActScheduleID);
        
        Utility util = new Utility();
        byte[] data = util.ExportDataTableToExcel(dt, CurrentSchedule.ActName + "(" + CurrentSchedule.TimeFrom.ToString() + "~" + CurrentSchedule.TimeTo.ToString() + ")");

        Response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode("data.xls", System.Text.Encoding.UTF8));
        Response.BinaryWrite(data);
        Response.Flush();
        Response.End();

    }
    protected void ddlUnit_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        List<V_KmuEmpDto> emplist = service.GetDeptEmp(ddlUnit.SelectedValue, null).OrderBy(c => c.Empcode).ToList();
        foreach (V_KmuEmpDto emp in emplist)
        {
            emp.Empname = emp.Empcode + "-" + emp.Empname;
        }
        ddlEmpByDept.DataSource = emplist;
        ddlEmpByDept.DataBind();
    }
    protected void lbRoleTypeList_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("代碼");
        dt.Columns.Add("角色名稱");
        dt.TableName = "角色代碼表";
        foreach (ListItem item in rcbRole.Items)
        {
            DataRow dr = dt.NewRow();
            dr["代碼"] = item.Value;
            dr["角色名稱"] = item.Text;
            dt.Rows.Add(dr);
        }

        Utility util = new Utility();
        byte[] data = util.ExportDataTableToExcel(dt);

        Response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode("roles.xls", System.Text.Encoding.UTF8));
        Response.BinaryWrite(data);
        Response.Flush();
        Response.End();
    }
    protected void cbOutSide_CheckedChanged(object sender, EventArgs e)
    {
        bool success = service.UpdateEduStopActSchedulerOutSideSetting(CurrentSchedule.EduStopActScheduleID, cbOutSide.Checked);
        if(!success)
        {
            ShowMessage("更新失敗");
            cbOutSide.Checked = CurrentSchedule.HasOutSideStudent;
        }
    }
    protected void btnImportRegistList_Click(object sender, EventArgs e)
    {
        if (rdtpTimeBegin.SelectedTime != null && rdtpTimeBegin.SelectedTime.Value < CurrentSchedule.TimeFrom.TimeOfDay)
        {
            ShowMessage("選擇時間超出活動範圍");
            return;
        }

        if (rdtpTimeEnd.SelectedTime != null && rdtpTimeEnd.SelectedTime.Value > CurrentSchedule.TimeTo.TimeOfDay)
        {
            ShowMessage("選擇時間超出活動範圍");
            return;
        }

        if (rcbRole.SelectedValue == null || rcbRole.SelectedValue == "")
        {
            ShowMessage("未選擇角色");
            return;
        }
        List<EduActBookingDto> bookingList = service.GetBookingList(CurrentSchedule.EduStopActScheduleID);


        List<EduActTargetDto> addlist = new List<EduActTargetDto>();
        string msg = "";
        try
        {
            foreach (EduActBookingDto book in bookingList)
            {
                if (CurrentTargetList.Count(c => c.TargetID == book.EmpCode && c.TimeFrom == SelectTimeFrom && c.TimeTo == SelectTimeTo) > 0)
                {
                    msg += "員工編號:" + book.EmpCode + " 已在清單中<br>";
                    continue;
                }

                string checkexist = service.CheckExistsActTarget(book.EmpCode, SelectTimeFrom, SelectTimeTo, CurrentSchedule.EduStopActScheduleID);

                if(checkexist!=null)
                {
                    msg += "員工編號:" + book.EmpCode + " 同時段已出席其他活動:" + checkexist + "<br>";
                    continue;
                }


                EduActTargetDto dto = new EduActTargetDto();
                dto.TargetType = rblTargetType.SelectedValue;
                dto.TargetID = book.EmpCode;
                dto.RoleType = rcbRole.SelectedValue;
                KMU.EduActivity.DomainModel.Entities.SelectVKmuempData empdata = service.ReadVKmuempData(book.EmpCode);
                dto.TargetJob = empdata.jobcode;
                dto.TargetJobName = empdata.jobname;
                if (palTimeRange.Visible)
                {
                    string check = CheckTargetTimeRange();
                    if (check != null)
                    {
                        ShowMessage(check);
                        msg += "員工編號:" + book.EmpCode + " " + check + "<br>";
                        continue;
                    }
                    dto.TimeFrom = rdtpTimeBegin.SelectedDate.Value;
                    dto.TimeTo = rdtpTimeEnd.SelectedDate.Value;
                }
                dto = service.FillEduActTargetName(dto);
                addlist.Add(dto);

            }

            CurrentTargetList.AddRange(addlist);//.Add(dto);



            CurrentTargetList = CurrentTargetList.OrderBy(c => c.TimeFrom).ToList();

            service.InsertEduActTargets(CurrentSchedule.EduStopActScheduleID, CurrentTargetList);

            rgTarget.DataSource = CurrentTargetList;
            rgTarget.DataBind();
            lbTotalCount.Text = CurrentTargetList.Count.ToString();
            lbImportMsg.Text = msg;
        }
        catch (Exception ex)
        {
            ShowMessage("新增資料失敗:" + ex.Message);
        }
    }
    protected void btnAddJobCode_Click(object sender, EventArgs e)
    {
        if (rdtpTimeBegin.SelectedTime != null && rdtpTimeBegin.SelectedTime.Value < CurrentSchedule.TimeFrom.TimeOfDay)
        {
            ShowMessage("選擇時間超出活動範圍");
            return;
        }

        if (rdtpTimeEnd.SelectedTime != null && rdtpTimeEnd.SelectedTime.Value > CurrentSchedule.TimeTo.TimeOfDay)
        {
            ShowMessage("選擇時間超出活動範圍");
            return;
        }

        if (rcbRole.SelectedValue == null || rcbRole.SelectedValue == "")
        {
            ShowMessage("未選擇角色");
            return;
        }

        if(rddtJobCode.SelectedValue == "" || rddtJobCode.SelectedValue == null)
        {
            ShowMessage("未選擇職稱");
            return;
        }

        List<MemberDto> jobcodelist = service.GetTermJobMembers(rddtJobCode.SelectedValue, CurrentSchedule.TimeFrom.Date, CurrentSchedule.DeptCode);

        List<string> empcodes = jobcodelist.Select(c => c.IsHospMember).Distinct().ToList();
        
        List<EduActTargetDto> addlist = new List<EduActTargetDto>();
        string msg = "";
        try
        {
            foreach (string emp in empcodes)
            {
                if (CurrentTargetList.Count(c => c.TargetID == emp && c.TimeFrom == SelectTimeFrom && c.TimeTo == SelectTimeTo) > 0)
                {
                    msg += "員工編號:" + emp + " 已在清單中<br>";
                    continue;
                }
                string checkresult = service.CheckExistsActTarget(emp, SelectTimeFrom, SelectTimeTo, CurrentSchedule.EduStopActScheduleID);
                if (checkresult != null)
                {
                    msg += "員工編號:" + emp + " 同時段已出席其他活動 " + checkresult + "<br>";
                    continue;
                }

                EduActTargetDto dto = new EduActTargetDto();
                dto.TargetType = rblTargetType.SelectedValue;
                dto.TargetID = emp;
                dto.RoleType = rcbRole.SelectedValue;
                KMU.EduActivity.DomainModel.Entities.SelectVKmuempData empdata = service.ReadVKmuempData(emp);
                dto.TargetJob = empdata.jobcode;
                dto.TargetJobName = empdata.jobname;
                if (palTimeRange.Visible)
                {
                    string check = CheckTargetTimeRange();
                    if (check != null)
                    {
                        ShowMessage(check);
                        msg += "員工編號:" + emp + " " + check + "<br>";
                        continue;
                    }
                    dto.TimeFrom = rdtpTimeBegin.SelectedDate.Value;
                    dto.TimeTo = rdtpTimeEnd.SelectedDate.Value;
                }
                dto = service.FillEduActTargetName(dto);
                addlist.Add(dto);

            }

            CurrentTargetList.AddRange(addlist);//.Add(dto);



            CurrentTargetList = CurrentTargetList.OrderBy(c => c.TimeFrom).ToList();

            service.InsertEduActTargets(CurrentSchedule.EduStopActScheduleID, CurrentTargetList);

            rgTarget.DataSource = CurrentTargetList;
            rgTarget.DataBind();
            lbTotalCount.Text = CurrentTargetList.Count.ToString();
            lbImportMsg.Text = msg;
        }
        catch (Exception ex)
        {
            ShowMessage("新增資料失敗:" + ex.Message);
        }
    }
    protected void btnAddMyList_Click(object sender, EventArgs e)
    {
        if (rdtpTimeBegin.SelectedTime != null && rdtpTimeBegin.SelectedTime.Value < CurrentSchedule.TimeFrom.TimeOfDay)
        {
            ShowMessage("選擇時間超出活動範圍");
            return;
        }

        if (rdtpTimeEnd.SelectedTime != null && rdtpTimeEnd.SelectedTime.Value > CurrentSchedule.TimeTo.TimeOfDay)
        {
            ShowMessage("選擇時間超出活動範圍");
            return;
        }

        if (rcbRole.SelectedValue == null || rcbRole.SelectedValue == "")
        {
            ShowMessage("未選擇角色");
            return;
        }

        if(MyListSelect1.SelectedMyListID == null || MyListSelect1.SelectedMyListID == "")
        {
            ShowMessage("未選擇名單");
            return;
        }

        if (MyListSelect1.SelectedCodes == null || MyListSelect1.SelectedCodes.Count==0)
        {
            ShowMessage("所選取的名單中沒有人員");
            return;
        }


        List<string> empcodes = MyListSelect1.SelectedCodes;

        List<EduActTargetDto> addlist = new List<EduActTargetDto>();
        string msg = "";
        try
        {
            foreach (string emp in empcodes)
            {
                if (CurrentTargetList.Count(c => c.TargetID == emp && c.TimeFrom == SelectTimeFrom && c.TimeTo == SelectTimeTo) > 0)
                {
                    msg += "員工編號:" + emp + " 已在清單中<br>";
                    continue;
                }
                string checkresult = service.CheckExistsActTarget(emp, SelectTimeFrom, SelectTimeTo, CurrentSchedule.EduStopActScheduleID);
                if (checkresult!=null)
                {
                    msg += "員工編號:" + emp + " 同時段已出席其他活動 " + checkresult + "<br>";
                    continue;
                }
                EduActTargetDto dto = new EduActTargetDto();
                dto.TargetType = rblTargetType.SelectedValue;
                dto.TargetID = emp;
                dto.RoleType = rcbRole.SelectedValue;
                KMU.EduActivity.DomainModel.Entities.SelectVKmuempData empdata = service.ReadVKmuempData(emp);
                dto.TargetJob = empdata.jobcode;
                dto.TargetJobName = empdata.jobname;
                if (palTimeRange.Visible)
                {
                    string check = CheckTargetTimeRange();
                    if (check != null)
                    {
                        ShowMessage(check);
                        msg += "員工編號:" + emp + " " + check + "<br>";
                        continue;   
                    }
                    dto.TimeFrom = SelectTimeFrom;
                    dto.TimeTo = SelectTimeTo;
                }
                dto = service.FillEduActTargetName(dto);
                addlist.Add(dto);

            }

            CurrentTargetList.AddRange(addlist);//.Add(dto);



            CurrentTargetList = CurrentTargetList.OrderBy(c => c.TimeFrom).ToList();

            service.InsertEduActTargets(CurrentSchedule.EduStopActScheduleID, CurrentTargetList);

            rgTarget.DataSource = CurrentTargetList;
            rgTarget.DataBind();
            lbTotalCount.Text = CurrentTargetList.Count.ToString();
            lbImportMsg.Text = msg;
        }
        catch (Exception ex)
        {
            ShowMessage("新增資料失敗:" + ex.Message);
        }
    }
    protected void btnImportRegistList0_Click(object sender, EventArgs e)
    {
        string msg = service.ImportRecordSignIn(CurrentSchedule.EduStopActScheduleID);
        if(msg!=null)
        {
            ShowMessage("匯入失敗:" + msg);
            return;
        }

        ReadSchedule();
        rgTarget.DataSource = CurrentTargetList;
        rgTarget.DataBind();
    }
}