using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KMU.EduActivity.ApplicationLayer.DTO;
using Telerik.Web.UI;
using KMU.EduActivity.ApplicationLayer.Services;
using System.Data;
using System.IO;

public partial class EduMemberTeacherSetting : AuthPage
{
    private EduTermDto CurrentData
    {
        get
        {
            return Session["CurrentTermTeacherSettingEduTerm"] as EduTermDto;
        }
        set
        {
            Session["CurrentTermTeacherSettingEduTerm"] = value;
        }
    }

    private List<EduTeamMemberRundownDto> CurrentMemberList
    {
        get
        {
            return ViewState["CurrentMemberList"] as List<EduTeamMemberRundownDto>;
        }
        set
        {
            ViewState["CurrentMemberList"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            if (Request.QueryString["EduTermID"] != null)
            {
                BindTeacherType();
                LoadEduTerm(Request.QueryString["EduTermID"].ToString());
            }
            else
            {
                ShowMessage("參數錯誤");
                CloseWindow(false);
            }
        }
    }

    private void BindTeacherType()
    {
        List<EduTeacherTypeDto> list = service.GetTeacherTypes();
        rcbTeacherType.DataValueField = "code";
        rcbTeacherType.DataTextField = "name";
        rcbTeacherType.DataSource = list;
        rcbTeacherType.DataBind();
        rcbTeacherType.SelectedIndex = 0;
    }

    private void ReadMembers()
    {
        List<EduTeamMemberRundownDto> list = service.GetEduTermMembersTeacher(CurrentData, rcbTeacherType.SelectedValue);
        RadGrid1.MasterTableView.DataKeyNames = new string[] { "EduTermID", "MemberID" };
        RadGrid1.DataSource = list;
        CurrentMemberList = list;
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
        }
        catch (Exception ex)
        {
            ShowMessage("資料錯誤:" + ex.Message);
            CloseWindow(true);
        }
    }
    protected void RadGrid1_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        ReadMembers();
    }
    protected void btnSet_Click(object sender, EventArgs e)
    {
        if (rcbVs.SelectedValue == "" || rcbVs.SelectedValue == null)
        {
            ShowMessage("未選擇指導老師");
            return;
        }
        List<string> ids = new List<string>();
        foreach (GridDataItem item in RadGrid1.SelectedItems)
        {
            ids.Add(item.GetDataKeyValue("MemberID").ToString());
        }

        if (!service.UpdateMemberRundownCoachID(ids, CurrentData.EduTermID, rcbVs.SelectedValue,rcbTeacherType.SelectedValue,this.EmpCode))
        {
            ShowMessage("更新失敗");
        }
        else
        {
            ReadMembers();
            RadGrid1.DataBind();
        }

    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        List<string> ids = new List<string>();
        foreach (GridDataItem item in RadGrid1.SelectedItems)
        {
            ids.Add(item.GetDataKeyValue("MemberID").ToString());
        }

        if (!service.UpdateMemberRundownCoachID(ids, CurrentData.EduTermID, null,rcbTeacherType.SelectedValue,this.EmpCode))
        {
            ShowMessage("更新失敗");
        }
        else
        {
            ReadMembers();
            RadGrid1.DataBind();
        }
    }

    protected void rcbTeacherType_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ReadMembers();
        RadGrid1.DataBind();
    }
    protected void odsVs_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        e.InputParameters.Add("deptcode", null);
    }

    protected void btnAddTeacher_Click(object sender, EventArgs e)
    {
        if (rcbVs.SelectedValue == "" || rcbVs.SelectedValue == null)
        {
            ShowMessage("未選擇指導老師");
            return;
        }
        List<string> ids = new List<string>();
        foreach (GridDataItem item in RadGrid1.SelectedItems)
        {
            ids.Add(item.GetDataKeyValue("MemberID").ToString());
        }

        if (!service.AddMemberRundownCoachID(ids, CurrentData.EduTermID, rcbVs.SelectedValue, rcbTeacherType.SelectedValue, this.EmpCode))
        {
            ShowMessage("更新失敗");
        }
        else
        {
            ReadMembers();
            RadGrid1.DataBind();
        }
    }
    protected void btnDownloadSample_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("教師類型代碼");
        dt.Columns.Add("教師類型名稱");
        dt.Columns.Add("學生編號");
        dt.Columns.Add("學生職編");
        dt.Columns.Add("學生姓名");
        dt.Columns.Add("教師職編");

        foreach(EduTeamMemberRundownDto dto in CurrentMemberList)
        {
            DataRow dr = dt.NewRow();
            dr["教師類型代碼"] = rcbTeacherType.SelectedValue;
            dr["教師類型名稱"] = rcbTeacherType.Text;
            dr["學生編號"] = dto.MemberID;
            dr["學生職編"] = dto.EmpCode;
            dr["學生姓名"] = dto.MemberName;
            dr["教師職編"] = "";
            dt.Rows.Add(dr);
        }

        Utility util = new Utility();
        byte[] bytes = util.ExportDataTableToExcel(dt);
        HttpResponse response = Response;

        response.Clear();

        //response.AppendCookie(new HttpCookie("fileDownloadToken", download_token_value_id.Value));

        response.AddHeader("Content-Type", "binary/octet-stream");

        response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode(rcbTeacherType.Text + ".xls") + "; size=" + bytes.Length.ToString());

        response.BinaryWrite(bytes);

        response.Flush();
        response.End();

    }
    protected void btnImport_Click(object sender, EventArgs e)
    {
        if (!fuImportFile.HasFile)
        {
            ShowMessage("未選擇檔案");
            return;
        }

        string filepath = Server.MapPath(".") + "\\temp\\";
        string filename = "(" + Guid.NewGuid().ToString() + ")" + fuImportFile.FileName;
        try
        {
            byte[] data = fuImportFile.FileBytes;
            FileStream fs = new FileStream(filepath + filename, FileMode.OpenOrCreate);
            fs.Write(data, 0, data.Length);
            fs.Close();

            DataTable dt = Utility.ReadExcelAsTableNPOI(filepath + filename);

            string success = service.ImportMemberRundownCoachID(dt, Request.QueryString["EduTermID"], this.EmpCode);

            if(success!=null)
            {
                lblMsg.Text += "匯入失敗：" + success;
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = "匯入失敗：" + ex.Message;
        }
        finally
        {
            if (File.Exists(filepath + filename))
            {
                File.Delete(filepath + filename);
            }
            ReadMembers();
            RadGrid1.DataBind();
        }


    }
}