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

public partial class RecordPrint : System.Web.UI.Page
{
    protected EduActivityAppService service = new EduActivityAppService();

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
            return CurrentIns.RecordInsViewers.Where(c => c.ViewOrder == minorder).FirstOrDefault();
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
            RecordInstanceDto ins = service.GetRecordInstance(CurrentInstanceID);
            CurrentIns = ins;

            Control ctr = LoadControl(string.Format(TemplatePath, CurrentIns.RecordTemplate.ClassName + "_p"));
            (ctr as IRecordBase).CurrentRecordIns = ins;
            (ctr as IRecordBase).SetControlValues(ins.DetNameValueData);

            (ctr as IRecordBase).SettingEditor(this.CurrentEmpCode);

            List<AccountRoleDto> roles = service.GetAuthRole(CurrentEmpCode);
            (ctr as IRecordBase).SetReadOnly(true);

            PlaceHolder1.Controls.Add(ctr);
            base.OnInit(e);
        }
        catch (Exception ex)
        {
            ShowMessageAndGo("載入會議記錄格式失敗，請聯絡系統管理員", "RecordManage.aspx");
            return;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        (Master.FindControl("RadScriptManager1") as RadScriptManager).RegisterPostBackControl(btnAddSign);
        (Master.FindControl("RadScriptManager1") as RadScriptManager).RegisterPostBackControl(btnSignAgree);
        (Master.FindControl("RadScriptManager1") as RadScriptManager).RegisterPostBackControl(btnSignReject);
        (Master.FindControl("RadScriptManager1") as RadScriptManager).RegisterPostBackControl(btnUpload);
        (Master.FindControl("RadScriptManager1") as RadScriptManager).RegisterPostBackControl(lbRoleTypeList);
        if (!IsPostBack)
        {
            //(Master.FindControl("RadScriptManager1") as RadScriptManager).RegisterPostBackControl(FileUpload1);

            string url = string.Format(SignInUrl, CurrentInstanceID);

            BarcodeWriter bw = new BarcodeWriter();
            bw.Format = BarcodeFormat.QR_CODE;
            bw.Options.Width = 120;
            bw.Options.Height = 120;
            bw.Options.Margin = 0;
            Bitmap bitmap = bw.Write(url);
            bitmap.Save(Server.MapPath("temp/QR_" + CurrentInstanceID + ".jpg"));

            imgSignIn.ImageUrl = "~/temp/QR_" + CurrentInstanceID + ".jpg";

            tbTitle.Text = CurrentIns.Title;

            DeptSelector1.Text = CurrentIns.DeptName;          

            rdtpSdate.Text = CurrentIns.Sdate.HasValue ? CurrentIns.Sdate.Value.ToString("yyyy/MM/dd HH:mm") : "";
            rdtpEdate.Text = CurrentIns.Edate.HasValue ? CurrentIns.Edate.Value.ToString("yyyy/MM/dd HH:mm") : "";

            BindRoles();

            if (CurrentEduStopActScheduleID != null)
            {
                ReadSchedule();
            }

            rgSign.DataSource = CurrentIns.RecordInsViewers;
            rgSign.DataBind();

            panMain.Enabled = false;

            panAddSignIn.Visible = false;
            Label6.Visible = false;
            imgSignIn.Visible = false;

            frameSignIn.Attributes.Add("src", "RecordSignInList.aspx?InstanceID=" + CurrentInstanceID);
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

    private void BindRoles()
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

    private void RefreshViewer()
    {
        for (int i = 0; i < CurrentIns.RecordInsViewers.Count; i++)
        {
            CurrentIns.RecordInsViewers[i].ViewOrder = i + 1;
        }

        service.UpdateRecordInsViewer(CurrentIns.InstanceID, CurrentIns.RecordInsViewers.ToList());
        CurrentIns.RecordInsViewers = service.GetRecordInsViewer(CurrentIns.InstanceID);
        rgSign.DataSource = CurrentIns.RecordInsViewers;
    }

    protected void btnAddSign_Click(object sender, EventArgs e)
    {
        if (VsSelector1.SelectedValue == null || VsSelector1.SelectedValue == "")
        {
            ShowMessage("未選擇人員");
            return;
        }

        RecordInsViewerDto dto = new RecordInsViewerDto();
        dto.InstanceID = CurrentInstanceID;
        dto.Viewer = VsSelector1.SelectedValue;

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

        int order = Convert.ToInt32((rgSign.SelectedItems[0] as GridDataItem).GetDataKeyValue("ViewOrder"));

        RecordInsViewerDto dto = CurrentIns.RecordInsViewers.Where(c => c.ViewOrder == order).FirstOrDefault();
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
    
    protected void btnSignReject_Click(object sender, EventArgs e)
    {
        CurrentViewer.ViewMemo = tbSignMemo.Text;
        CurrentViewer.ViewTime = DateTime.Now;

        CurrentViewer.ViewStatus = "駁回";
        RefreshViewer();
        rgSign.DataBind();

        Response.Redirect("ToDoList.aspx");
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
        lbSigninMsg.Text = service.SignInRecordIns(CurrentInstanceID, empSelectorSignIn.SelectedValue, rcbRole.SelectedValue, "UserAdd");

    }
    
    protected void btnCancel_Click(object sender, EventArgs e)
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
}