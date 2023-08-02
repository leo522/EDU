using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KMU.EduActivity.ApplicationLayer.DTO;
using KMU.EduActivity.ApplicationLayer.Services;
using ZXing;
using ZXing.QrCode;
using System.Drawing;
using Telerik.Web.UI;
using System.IO;
using System.Data;

public partial class RecordEdit : System.Web.UI.Page
{
    //protected EduActivityAppService service = new EduActivityAppService();
    private string CurrentInstanceID
    {
        get
        {
            return Request.QueryString["InstanceID"];
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

    private RecordInsViewerDto CurrentViewer
    {
        get
        {
            int minorder = CurrentIns.RecordInsViewers.Where(c => c.ViewStatus == null).Min(c => c.ViewOrder);
            return CurrentIns.RecordInsViewers.Where(c => c.ViewOrder == minorder && c.Viewer == CurrentEmpCode).FirstOrDefault();
        }
    }

    const string TemplatePath = "~/UserControls/{0}.ascx";
    const string SignInUrl = "http://www.kmuh.org.tw/web/eduactivity/RecordSignIn.aspx?InstanceID={0}";

    protected override void OnInit(EventArgs e)
    {
        if (CurrentInstanceID == null || CurrentInstanceID == "")
        {
            ShowMessageAndGo("參數傳遞錯誤，請重試", "RecordManage.aspx");
            return;
        }

        try
        {
            using (EduActivityAppService service = new EduActivityAppService())
            {
                RecordInstanceDto ins = service.GetRecordInstance(CurrentInstanceID);
                CurrentIns = ins;
                lbID.Text = CurrentInstanceID;

                Control ctr = LoadControl(string.Format(TemplatePath, CurrentIns.RecordTemplate.ClassName));
                (ctr as IRecordBase).CurrentRecordIns = ins;
                (ctr as IRecordBase).SetControlValues(ins.DetNameValueData);

                (ctr as IRecordBase).SettingEditor(this.CurrentEmpCode);

                RadioButtonList2.SelectedValue = CurrentIns.SignMethod;

                List<AccountRoleDto> roles = service.GetAuthRole(CurrentEmpCode);
                //開放科秘、管理者 修改內容
                if (ins.Status == "0")
                {
                    (ctr as IRecordBase).SetReadOnly(false);
                }
                else if ((CurrentIns.Status == "1" || CurrentIns.Status == "2") && CurrentEmpCode != null)
                {
                    if (roles.Count(c => c.RoleID == "DepSec" || c.RoleID == "Admin" || c.RoleID == "ActWriter" || c.RoleID == "NurseD") > 0)
                    {
                        (ctr as IRecordBase).SetReadOnly(false);
                    }
                    else
                    {
                        (ctr as IRecordBase).SetReadOnly(true);
                    }
                }
                else
                {
                    if (roles.Count(c => c.RoleID == "Admin") > 0)
                    {
                        (ctr as IRecordBase).SetReadOnly(false);
                    }
                    else
                    {
                        (ctr as IRecordBase).SetReadOnly(true);
                    }
                }

                //簽核者可以改
                if (CurrentIns.Status == "2"
                    && CurrentEmpCode != null
                    && CurrentIns.RecordInsViewers.Count(c => c.Viewer == CurrentEmpCode
                        && CurrentIns.RecordInsViewers.Count(d => d.ViewOrder < c.ViewOrder && d.ViewStatus == null) == 0
                        && CurrentIns.RecordInsViewers.Count(d => d.Viewer != CurrentEmpCode && d.ViewOrder == c.ViewOrder) == 0
                        ) > 0

                    )
                {
                    (ctr as IRecordBase).SetReadOnly(false);
                }

                //if(CurrentIns.SignMethod=="1" && CurrentIns.Status == "2")
                //{
                //    (ctr as IRecordBase).SetReadOnly(true);
                //}
                PlaceHolder1.Controls.Add(ctr);
            }
            




            
            base.OnInit(e);
        }
        catch (Exception ex)
        {
            CurrentIns = new RecordInstanceDto();
            ShowMessageAndGo("載入會議記錄格式失敗，請聯絡系統管理員", "RecordManage.aspx");
            return;
        }

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        //(Master.FindControl("RadScriptManager1") as RadScriptManager).RegisterPostBackControl(btnAddSign);
        (Master.FindControl("RadScriptManager1") as RadScriptManager).RegisterPostBackControl(btnPreSave);
        (Master.FindControl("RadScriptManager1") as RadScriptManager).RegisterPostBackControl(btnSubmit);
        (Master.FindControl("RadScriptManager1") as RadScriptManager).RegisterPostBackControl(btnSignAgree);
        (Master.FindControl("RadScriptManager1") as RadScriptManager).RegisterPostBackControl(btnSignReject);
        (Master.FindControl("RadScriptManager1") as RadScriptManager).RegisterPostBackControl(btnUpload);
        (Master.FindControl("RadScriptManager1") as RadScriptManager).RegisterPostBackControl(lbRoleTypeList);
        (Master.FindControl("RadScriptManager1") as RadScriptManager).RegisterPostBackControl(DeptSelector1);
        
        if (!IsPostBack)
        {

            using (EduActivityAppService service = new EduActivityAppService())
            {

                //(Master.FindControl("RadScriptManager1") as RadScriptManager).RegisterPostBackControl(FileUpload1);

                string url = string.Format(SignInUrl, CurrentInstanceID);

                /*
                BarcodeWriter bw = new BarcodeWriter();
                bw.Format = BarcodeFormat.QR_CODE;
                bw.Options.Width = 120;
                bw.Options.Height = 120;
                bw.Options.Margin = 0;
                Bitmap bitmap = bw.Write(url);
                bitmap.Save(Server.MapPath("temp/QR_" + CurrentInstanceID + ".jpg"));
            
                imgSignIn.ImageUrl = "~/temp/QR_" + CurrentInstanceID + ".jpg";
                */

                tbTitle.Text = CurrentIns.Title;


                var rejectlogs = service.GetRecordInsRejectLog(CurrentInstanceID);
                if (rejectlogs.Count > 0)
                {
                    panRejectLog.Visible = true;
                    rgReject.DataSource = rejectlogs;
                    rgReject.DataBind();
                }
                else
                {
                    panRejectLog.Visible = false;
                }

                if (CurrentIns.HospCode != null)
                {
                    DeptSelector1.Select(CurrentIns.HospCode, CurrentIns.DeptCode);
                }
                else
                {
                    DeptSelector1.Select("KMUH", "");
                }

                rdtpSdate.SelectedDate = CurrentIns.Sdate;
                rdtpEdate.SelectedDate = CurrentIns.Edate;
                cbIsPublic.Checked = CurrentIns.IsPublic;

                BindRoles();

                if (CurrentEduStopActScheduleID != null)
                {
                    ReadSchedule();
                }

                rgRead.DataSource = CurrentIns.RecordInsReaders;
                rgRead.DataBind();

                rgSign.DataSource = CurrentIns.RecordInsViewers;
                rgSign.DataBind();

                if (CurrentIns.Status != "0" || CurrentEmpCode == null || (this.CurrentEmpCode != CurrentIns.Creater && this.CurrentEmpCode != CurrentIns.Viewer && CurrentEduStopActScheduleID == null))
                {
                    btnPreSave.Visible = false;
                    btnSubmit.Visible = false;
                    panMain.Enabled = false;

                }


                //if (!CurrentIns.RecordTemplate.BindAct && CurrentIns.Status == "0")
                if (CurrentIns.Status == "0" && CurrentEmpCode == CurrentIns.Creater)
                {
                    panAddSign.Visible = true;
                    btnCancel.Visible = true;
                }

                if (CurrentIns.Status != "0" && CurrentIns.Status != "1")
                {
                    panAddSignIn.Visible = false;
                    //panAddRead.Visible = false;
                    Label6.Visible = false;
                    imgSignIn.Visible = false;
                }

                List<AccountRoleDto> roles = service.GetAuthRole(CurrentEmpCode);
                if (CurrentIns.Status == "1" && CurrentEmpCode != null)
                {

                    if (roles.Count(c => c.RoleID == "DepSec" || c.RoleID == "Admin" || c.RoleID == "ActWriter" || c.RoleID == "NurseD" || c.RoleID == "Teacher") > 0)
                    {
                        btnSendSign.Visible = true;
                        panAddSign.Visible = true;
                        btnPreSave.Visible = true;
                        panMain.Enabled = true;
                    }
                }

                if (roles.Count(c => c.RoleID == "DepSec" || c.RoleID == "Admin" || c.RoleID == "ActWriter" || c.RoleID == "NurseD" || c.RoleID == "Teacher") > 0)
                {
                    btnPreSave.Visible = true;
                    panMain.Enabled = true;
                }

                if (CurrentIns.Status == "2" && CurrentEmpCode != null && CurrentIns.RecordInsViewers.Count(c => c.Viewer == CurrentEmpCode && CurrentIns.RecordInsViewers.Count(d => d.ViewOrder < c.ViewOrder && d.ViewStatus == null) == 0) > 0)
                {
                    panViewerSign.Visible = true;
                    panMain.Enabled = true;
                }


                frameSignIn.Attributes.Add("src", "RecordSignInList.aspx?InstanceID=" + CurrentInstanceID);
            }


        }
    }


    private void ReadSchedule()
    {
        using (EduActivityAppService service = new EduActivityAppService())
        {
            EduStopActScheduleDto sche = service.GetEduStopActSchedulerByID(CurrentEduStopActScheduleID);
            CurrentSchedule = sche;
            if (tbTitle.Text == "")
            {
                tbTitle.Text = sche.ActName;
            }

            DeptSelector1.Select(sche.HospCode, sche.DeptCode);
            rdtpSdate.SelectedDate = sche.TimeFrom;
            rdtpEdate.SelectedDate = sche.TimeTo;
        }



    }

    private void BindRoles()
    {
        using (EduActivityAppService service = new EduActivityAppService())
        {
            if (CurrentEduStopActScheduleID == null)
            {
                lbActType.Visible = true;
                rblActType.Visible = true;
                List<V_CodeRefDto> list = service.GetRoleListByType(new List<int> { Convert.ToInt32(rblActType.SelectedValue) }, CurrentSchedule == null ? DateTime.Now.Date : CurrentSchedule.TimeFrom.Date);
                rcbRole.DataSource = list;
                rcbRole.DataBind();

            }
            else
            {
                lbActType.Visible = false;
                rblActType.Visible = false;
                List<V_CodeRefDto> list = service.GetRoleList(CurrentEduStopActScheduleID, CurrentSchedule == null ? DateTime.Now.Date : CurrentSchedule.TimeFrom.Date);
                rcbRole.DataSource = list;
                rcbRole.DataBind();
            }

        }


    }


    protected void ShowMessage(string message)
    {
        if (Master != null)
        {
            Label lbl1 = (Label)Master.FindControl("lbErrMsg");
        }
        //lbl1.Text = message;

        System.Web.UI.Page executingPage = HttpContext.Current.Handler as System.Web.UI.Page;
        ScriptManager objScriptManager = ScriptManager.GetCurrent(executingPage);

        string myScript = String.Format("alert('{0}');", JSStringEscape(message, false));

        ScriptManager.RegisterStartupScript(executingPage, executingPage.GetType(), "MessageBox" + new Guid().ToString(), myScript, true);
        //myScript = "<script>" + myScript + "</script>";
        //lbl1.Text = myScript;

    }

    protected void ShowMessageAndGo(string message, string url)
    {
        ShowMessage(message);
        System.Web.UI.Page executingPage = HttpContext.Current.Handler as System.Web.UI.Page;
        ScriptManager objScriptManager = ScriptManager.GetCurrent(executingPage);

        string myScript = String.Format("window.location ='{0}';", url);

        ScriptManager.RegisterStartupScript(executingPage, executingPage.GetType(), "Redirect" + new Guid().ToString(), myScript, true);
    }

    protected void ShowMessageAndGoBack(string message)
    {
        ShowMessage(message);
        System.Web.UI.Page executingPage = HttpContext.Current.Handler as System.Web.UI.Page;
        ScriptManager objScriptManager = ScriptManager.GetCurrent(executingPage);

        string myScript = "window.history.back();";

        ScriptManager.RegisterStartupScript(executingPage, executingPage.GetType(), "Redirect" + new Guid().ToString(), myScript, true);
    }
    /// <returns>置換特殊字元之後的字串</returns>
    /// <remarks></remarks>
    private string JSStringEscape(string raw, bool inHtmlAttribute)
    {
        raw = raw.Replace("\r\n", "\\n").Replace("\r", "").Replace("\n", "\\n");
        if (inHtmlAttribute)
            raw = raw.Replace("\"", "&quot;").Replace("'", "\\'");
        else
            raw = raw.Replace("'", "\\'").Replace("\"", "\\\"");
        return raw;
    }


    protected void btnPreSave_Click(object sender, EventArgs e)
    {
        if (rdtpSdate.SelectedDate == null || rdtpEdate.SelectedDate == null)
        {
            ShowMessage("未選擇會議日期");
            return;
        }

        if (tbTitle.Text.Trim() == "")
        {
            ShowMessage("未輸入會議主題");
            return;
        }

        if (DeptSelector1.SelectDept == null)
        {
            ShowMessage("未選擇科別");
            return;
        }

        SaveRec();
    }

    private void SaveRec()
    {
        using (EduActivityAppService service = new EduActivityAppService())
        {
            NameValueCollection coll = (PlaceHolder1.Controls[0] as IRecordBase).GetControlValues();
            CurrentIns.DetNameValueData = coll;
            CurrentIns.Sdate = rdtpSdate.SelectedDate.Value;
            CurrentIns.Edate = rdtpEdate.SelectedDate.Value;
            CurrentIns.HospCode = DeptSelector1.SelectDept.Hospcode;
            CurrentIns.DeptCode = DeptSelector1.SelectDept.Deptcode;
            CurrentIns.Title = tbTitle.Text.Trim();
            CurrentIns.IsPublic = cbIsPublic.Checked;
            CurrentIns.SignMethod = RadioButtonList2.SelectedValue;
            service.UpdateRecordInstance(CurrentIns, CurrentEmpCode);
        }



    }

    private void RefreshViewer()
    {
        using (EduActivityAppService service = new EduActivityAppService())
        {

            //if (RadioButtonList2.SelectedValue == "0")
            //{
            //    for (int i = 0; i < CurrentIns.RecordInsViewers.Count; i++)
            //    {
            //        CurrentIns.RecordInsViewers[i].ViewOrder = i + 1;
            //    }
            //}
            //else
            //{
            //    for (int i = 0; i < CurrentIns.RecordInsViewers.Count; i++)
            //    {
            //        CurrentIns.RecordInsViewers[i].ViewOrder = 0;
            //    }
            //}

            service.UpdateRecordInsViewer(CurrentIns.InstanceID, CurrentIns.RecordInsViewers.ToList());
            CurrentIns.RecordInsViewers = service.GetRecordInsViewer(CurrentIns.InstanceID);
            rgSign.DataSource = CurrentIns.RecordInsViewers;
            rgSign.DataBind();
        }


    }


    private void RefreshReader()
    {

        using (EduActivityAppService service = new EduActivityAppService())
        {
            service.UpdateRecordInsReader(CurrentIns.InstanceID, CurrentIns.RecordInsReaders.ToList());
            CurrentIns.RecordInsReaders = service.GetRecordInsReader(CurrentIns.InstanceID);
            rgRead.DataSource = CurrentIns.RecordInsReaders;
            try
            {
                rgRead.DataBind();
            }
            catch (Exception ex)
            {

            }
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (rdtpSdate.SelectedDate == null || rdtpEdate.SelectedDate == null)
        {
            ShowMessage("未選擇會議日期");
            return;
        }

        if (tbTitle.Text.Trim() == "")
        {
            ShowMessage("未輸入會議主題");
            return;
        }

        if (DeptSelector1.SelectDept == null)
        {
            ShowMessage("未選擇科別");
            return;
        }

        using (EduActivityAppService service = new EduActivityAppService())
        {
            if (service.GetRecordSignInList(CurrentIns.InstanceID).Count == 0)
            {
                ShowMessage("未設定簽到名單");
                return;
            }
            if (!CurrentIns.RecordTemplate.BindAct)
            {
                if (CurrentIns.RecordInsViewers.Count == 0)
                {
                    ShowMessage("未設定簽核人");
                    return;
                }
                else
                {
                    CurrentIns.Status = "2";
                }
            }
            else
            {
                CurrentIns.Status = "1";
            }
        }


        SaveRec();
        Response.Redirect("RecordManage.aspx");
    }
    protected void btnSendSign_Click(object sender, EventArgs e)
    {
        if (rdtpSdate.SelectedDate == null || rdtpEdate.SelectedDate == null)
        {
            ShowMessage("未選擇會議日期");
            return;
        }

        if (tbTitle.Text.Trim() == "")
        {
            ShowMessage("未輸入會議主題");
            return;
        }

        if (DeptSelector1.SelectDept == null)
        {
            ShowMessage("未選擇科別");
            return;
        }

        using (EduActivityAppService service = new EduActivityAppService())
        {
            if (service.GetRecordSignInList(CurrentIns.InstanceID).Count == 0)
            {
                ShowMessage("未設定簽到名單");
                return;
            }
        }


        if (CurrentIns.RecordInsViewers.Count == 0)
        {
            ShowMessage("未設定簽核人");
            return;
        }
        else
        {
            CurrentIns.Status = "2";
        }

        SaveRec();
        ShowMessageAndGoBack("送審完成");

    }
    protected void btnAddSign_Click(object sender, EventArgs e)
    {
        if (VsSelector1.SelectedValue == null || VsSelector1.SelectedValue == "")
        {
            ShowMessage("未選擇人員");
            return;
        }
        if(RadNumericTextBox1.Value == null)
        {
            ShowMessage("未設定簽核次序");
            return;
        }

        RecordInsViewerDto dto = new RecordInsViewerDto();
        dto.InstanceID = CurrentInstanceID;
        dto.Viewer = VsSelector1.SelectedValue;
        dto.ViewOrder = Convert.ToInt32(RadNumericTextBox1.Value);

        CurrentIns.RecordInsViewers.Add(dto);
        RefreshViewer();

        rgSign.DataBind();



    }

    protected void btnRemoveSign_Click(object sender, EventArgs e)
    {
        if (rgSign.SelectedItems.Count == 0)
        {
            ShowMessage("未選擇欲刪除的簽核人員");
            return;
        }


        int order = Convert.ToInt32((rgSign.SelectedItems[0] as GridDataItem).GetDataKeyValue("SN"));



        RecordInsViewerDto dto = CurrentIns.RecordInsViewers.Where(c => c.SN == order).FirstOrDefault();
        if (dto != null)
        {
            CurrentIns.RecordInsViewers.Remove(dto);

            RefreshViewer();

            rgSign.DataBind();
        }
    }
    protected void btnMoveUp_Click(object sender, EventArgs e)
    {
        if (rgSign.SelectedItems.Count == 0)
        {
            ShowMessage("未選擇欲移動的簽核人員");
            return;
        }


        int order = Convert.ToInt32((rgSign.SelectedItems[0] as GridDataItem).GetDataKeyValue("ViewOrder"));



        RecordInsViewerDto dto = CurrentIns.RecordInsViewers.Where(c => c.ViewOrder == order).FirstOrDefault();
        if (dto != null)
        {
            RecordInsViewerDto updto = CurrentIns.RecordInsViewers.Where(c => c.ViewOrder == order - 1).FirstOrDefault();

            dto.ViewOrder = order - 1;
            if (updto != null)
            {
                updto.ViewOrder = order;
            }

            RefreshViewer();

            rgSign.DataBind();
        }
    }
    protected void btnMoveDown_Click(object sender, EventArgs e)
    {
        if (rgSign.SelectedItems.Count == 0)
        {
            ShowMessage("未選擇欲移動的簽核人員");
            return;
        }


        int order = Convert.ToInt32((rgSign.SelectedItems[0] as GridDataItem).GetDataKeyValue("ViewOrder"));



        RecordInsViewerDto dto = CurrentIns.RecordInsViewers.Where(c => c.ViewOrder == order).FirstOrDefault();
        if (dto != null)
        {
            RecordInsViewerDto updto = CurrentIns.RecordInsViewers.Where(c => c.ViewOrder == order + 1).FirstOrDefault();

            dto.ViewOrder = order + 1;
            if (updto != null)
            {
                updto.ViewOrder = order;
            }

            RefreshViewer();

            rgSign.DataBind();
        }
    }
    protected void btnSignAgree_Click(object sender, EventArgs e)
    {
        if (CurrentViewer != null)
        {
            if (CurrentViewer.ViewOrder == CurrentIns.RecordInsViewers.Max(c => c.ViewOrder) && CurrentIns.RecordInsViewers.Count(c => c.Viewer != CurrentEmpCode && c.ViewOrder == CurrentViewer.ViewOrder && c.ViewStatus == null) == 0)
            {
                CurrentIns.Status = "V";
            }

            CurrentViewer.ViewMemo = tbSignMemo.Text;
            CurrentViewer.ViewTime = DateTime.Now;

            CurrentViewer.ViewStatus = "同意";


            SaveRec();

            RefreshViewer();
            rgSign.DataBind();

            Response.Redirect("ToDoList.aspx");
        }
    }
    protected void btnSignReject_Click(object sender, EventArgs e)
    {

        using (EduActivityAppService service = new EduActivityAppService())
        {

            string instanceid = CurrentIns.InstanceID;
            RecordInstanceDto ins = CurrentIns;

            if (ins.Status == "V")
            {
                ins.Status = "3";
            }

            int status = Convert.ToInt32(ins.Status);
            if (status != 0)
            {
                status = 0;
                //if (ins.RecordTemplate.BindAct)
                //{
                //    status = status - 1;
                //}
                //else
                //{
                //    status = status - 2;
                //}


                string msg = service.UpdateRecordInstanceStatus(ins, status.ToString(), CurrentEmpCode, true, tbSignMemo.Text);
                CurrentIns.RecordInsViewers = service.GetRecordInsViewer(CurrentIns.InstanceID);
                if (msg == "" || msg == null)
                {
                    RefreshViewer();
                    rgSign.DataBind();

                    Response.Redirect("ToDoList.aspx");
                }
                else
                {
                    ShowMessage("更新失敗:" + msg);
                }
            }


            //CurrentViewer.ViewMemo = tbSignMemo.Text;
            //CurrentViewer.ViewTime = DateTime.Now;

            //CurrentViewer.ViewStatus = "駁回";
            //RefreshViewer();
            //rgSign.DataBind();

            //Response.Redirect("ToDoList.aspx");
        }
    }
    protected void btnAddTargetEmp_Click(object sender, EventArgs e)
    {
        if (rcbRole.SelectedValue == "" || rcbRole.SelectedValue == null)
        {
            ShowMessage("未選擇角色");
            return;
        }

        if (empSelectorSignIn.SelectedValue == null || empSelectorSignIn.SelectedValue == "")
        {
            ShowMessage("未選擇人員");
            return;
        }
        using (EduActivityAppService service = new EduActivityAppService())
        {
            lbSigninMsg.Text = service.SignInRecordIns(CurrentInstanceID, empSelectorSignIn.SelectedValue, rcbRole.SelectedValue, "UserAdd");

            frameSignIn.Attributes["src"] = "RecordSignInList.aspx?InstanceID=" + CurrentInstanceID;
        }


    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {

        using (EduActivityAppService service = new EduActivityAppService())
        {
            string msg = service.DeleteRecordInstance(CurrentInstanceID);
            if (msg == null)
            {
                Response.Redirect("RecordManage.aspx");
            }
            else
            {
                ShowMessage("刪除失敗:" + msg);
            }
        }

    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            using (EduActivityAppService service = new EduActivityAppService())
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

                    string importmsg = "";



                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr[0].ToString().Trim() != "")
                        {
                            string empcode = dr[0].ToString();
                            if (empcode.Length == 7 && empcode.StartsWith("0"))
                            {
                                empcode = empcode.Substring(1);
                            }

                            string rolesid = "Student";
                            if (dt.Columns.Contains("roleid"))
                            {
                                try
                                {
                                    rolesid = dr["roleid"].ToString();
                                }
                                catch (Exception ex)
                                {
                                }
                            }
                            string msg = service.SignInRecordIns(CurrentInstanceID, empcode, rolesid, "UserAdd");
                            if (msg != "簽到完成")
                            {
                                importmsg += empcode + ":" + msg + "  ";
                            }
                        }
                    }

                    if (importmsg != "")
                    {
                        lblMsg.Text = importmsg;
                    }
                    frameSignIn.Attributes["src"] = "RecordSignInList.aspx?InstanceID=" + CurrentInstanceID;
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

                }
            }

        }
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
    protected void rblActType_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindRoles();
    }
    protected void RadioButtonList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        RefreshViewer();
    }
    protected void btnAddRead_Click(object sender, EventArgs e)
    {
        if (VsSelector2.SelectedValue == null || VsSelector2.SelectedValue == "")
        {
            ShowMessage("未選擇人員");
            return;
        }

        if (CurrentIns.RecordInsReaders.Count(c => c.Reader == VsSelector2.SelectedValue) > 0)
        {
            ShowMessage("該人員已在名單中");
            return;
        }

        RecordInsReaderDto dto = new RecordInsReaderDto();
        dto.InstanceID = CurrentInstanceID;
        dto.Reader = VsSelector2.SelectedValue;

        CurrentIns.RecordInsReaders.Add(dto);
        RefreshReader();

        rgRead.DataBind();
    }
    protected void btnRemoveRead_Click(object sender, EventArgs e)
    {
        if (rgRead.SelectedItems.Count == 0)
        {
            ShowMessage("未選擇欲刪除的人員");
            return;
        }


        string reader = (rgRead.SelectedItems[0] as GridDataItem).GetDataKeyValue("Reader").ToString();



        RecordInsReaderDto dto = CurrentIns.RecordInsReaders.Where(c => c.Reader == reader).FirstOrDefault();
        if (dto != null)
        {
            CurrentIns.RecordInsReaders.Remove(dto);

            RefreshReader();

            rgRead.DataBind();
        }
    }
}