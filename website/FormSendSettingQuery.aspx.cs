using KMU.EduActivity.ApplicationLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class FormSendSettingQuery : AuthPage
{
    private List<FormSendSettingData> CurrentList
    {
        get
        {
            return ViewState["CurrentList"] as List<FormSendSettingData>;
        }
        set
        {
            ViewState["CurrentList"] = value;
        }

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        AddPostbackControl(btnExport);
        if(!IsPostBack)
        {
            rdpSDate.SelectedDate = new DateTime(DateTime.Now.Date.Year, DateTime.Now.Date.Month, 1);
            rdpEDate.SelectedDate = DateTime.Now.Date.AddDays(1);
        }
    }

    private void ReadData()
    {
        List<string> jobcodes = null;
        if (rddtJobCode.SelectedValue != "")
        {
            jobcodes = rddtJobCode.SelectedValue.Split(',').ToList();
        }

        List<FormSendSettingData> list = service.GetFormSendSettingData(DeptSelector1.SelectDept == null ? null : DeptSelector1.SelectDept.Deptcode, jobcodes, rdpSDate.SelectedDate.Value, rdpEDate.SelectedDate.Value);
        CurrentList = list;
        if (!cbShowAll.Checked)
        {
            list = list.Where(c => c.SettingStatus != "已發送").ToList();
        }
        RadGrid1.DataSource = list;
    }

    protected void btnQuery_Click(object sender, EventArgs e)
    {

        if(rdpSDate.SelectedDate == null|| rdpEDate.SelectedDate == null)
        {
            ShowMessage("請選擇時間範圍");
            return;
        }

        ReadData();

        RadGrid1.DataBind();
    }
    protected void cbShowAll_CheckedChanged(object sender, EventArgs e)
    {
        if (CurrentList != null)
        {
            if (!cbShowAll.Checked)
            {
                RadGrid1.DataSource = CurrentList.Where(c => c.SettingStatus != "已發送").ToList();
                RadGrid1.DataBind();
            }
            else
            {
                RadGrid1.DataSource = CurrentList;
                RadGrid1.DataBind();
            }

        }
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        RadGrid1.ExportSettings.Excel.Format = GridExcelExportFormat.ExcelML;
        RadGrid1.ExportSettings.ExportOnlyData = true;
        RadGrid1.ExportSettings.IgnorePaging = true;
        RadGrid1.ExportSettings.OpenInNewWindow = true;
        RadGrid1.MasterTableView.ExportToExcel();
    }
    protected void RadGrid1_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        if (IsPostBack)
        {
            ReadData();
        }
    }
}