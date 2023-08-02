using KMU.EduActivity.ApplicationLayer.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class TrainingPointQuery : AuthPage
{
    private List<TrainingTimeDto> CurrentData
    {
        get
        {
            return ViewState["CurrentData"] as List<TrainingTimeDto>;
        }
        set
        {
            ViewState["CurrentData"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        AddPostbackControl(btnExport);
        if(!IsPostBack)
        {
            BindJobCode();
            if (this.AuthRoles.Contains("Admin") || this.AuthRoles.Contains("DepSec"))
            {
                panManager.Visible = true;
            }
            else
            {
                panManager.Visible = false;
                tbEmpCode.Text = this.EmpCode;
            }

            int cyear = DateTime.Now.Year - 1911;

            for (int i = 0; i < 10; i++)
            {
                ddlEduYear.Items.Add(new ListItem((cyear - i).ToString(), (cyear - i).ToString()));
            }

        }
    }

    private void ReadData()
    {
        List<string> filterjob = new List<string>();
        foreach (RadComboBoxItem item in rcbFilterJob.Items)
        {
            if (item.Checked)
            {
                filterjob.Add(item.Value);
            }
        }
        DateTime? sdate = null;
        DateTime? edate = null;
        if(rbByDate.Checked)
        {
            sdate = rdpSdate.SelectedDate;
            edate = rdpEdate.SelectedDate;
        }else
        {
            int cyear = Convert.ToInt32(ddlEduYear.SelectedValue);
            int session = Convert.ToInt32(ddlEduYearSession.SelectedValue);
            sdate = new DateTime(1911 + cyear, 8, 1).AddMonths(session * 6);
            edate = sdate.Value.AddMonths(6).AddDays(-1);
        }


        List<TrainingTimeDto> data = service.QueryTrainingTimeEmpItemData(tbEmpCode.Text, null, sdate, edate, null, null, filterjob);
        CurrentData = data;
        RadGrid1.DataSource = data;
        RadGrid1.DataBind();
    }

    private void BindJobCode()
    {
        List<V_kmujobDto> list = service.GetJobs().OrderBy(c => c.DisplayName).ToList();

        V_kmujobDto emptydto = new V_kmujobDto();
        emptydto.JOB_CODE_X = "";
        emptydto.JOB_NAME = "";
        list.Insert(0, emptydto);
        rcbFilterJob.DataValueField = "JOB_CODE_X";
        rcbFilterJob.DataTextField = "DisplayName";

        rcbFilterJob.DataSource = list;
        rcbFilterJob.DataBind();

    }

    protected void btnQuery_Click(object sender, EventArgs e)
    {
        if(rbByEduYear.Checked && (ddlEduYear.SelectedValue == null ||ddlEduYear.SelectedValue == "" || ddlEduYearSession.SelectedValue == null || ddlEduYearSession.SelectedValue == "" ))
        {
            ShowMessage("請選擇學年度與學期");
            return;
        }

        if(rbByDate.Checked && rdpSdate.SelectedDate == null)
        {
            ShowMessage("請選擇開始時間");
            return;
        }

        if (rbByDate.Checked && rdpEdate.SelectedDate == null)
        {
            ShowMessage("請選擇結束時間");
            return;
        }

        ReadData();
    }

    protected void RadGrid1_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        RadGrid1.DataSource = CurrentData;
    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        if (CurrentData != null)
        {
            RadGrid1.ExportSettings.Excel.Format = GridExcelExportFormat.ExcelML;
            RadGrid1.ExportSettings.ExportOnlyData = true;
            RadGrid1.ExportSettings.IgnorePaging = true;
            RadGrid1.ExportSettings.OpenInNewWindow = true;
            RadGrid1.MasterTableView.ExportToExcel();
        }
    }
}