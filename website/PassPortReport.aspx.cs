using KMU.EduActivity.ApplicationLayer.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class PassPortReport : AuthPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AddPostbackControl(btnExportData);
        AddPostbackControl(btnExportStatus);
        AddPostbackControl(btnExportOrderStatusData);
        if (!IsPostBack)
        {
            BindJobs();
        }
    }

    private void BindJobs()
    {
        List<V_kmujobDto> list = service.GetPassPortJobCodes();
        ddlJobCode.DataTextField = "DisplayName";
        ddlJobCode.DataValueField = "JOB_CODE_X";
        ddlJobCode.DataSource = list;
        ddlJobCode.DataBind();
    }
    protected void ddlJobCode_DataBound(object sender, EventArgs e)
    {
        if (ddlJobCode.Items.Count > 0)
        {
            ddlJobCode.SelectedIndex = 0;
            foreach (RadComboBoxItem item in ddlJobCode.Items)
            {
                item.Checked = false;
            }
        }
    }


    protected void btnExportData_Click(object sender, EventArgs e)
    {
        List<string> jobcodes = new List<string>();
        foreach (RadComboBoxItem item in ddlJobCode.Items)
        {
            if (item.Checked)
            {
                jobcodes.Add(item.Value);

            }
        }

        List<string> jobserials = null;
        if (rddtJobCode.SelectedValue != "")
        {
            jobserials = rddtJobCode.SelectedValue.Split(',').ToList();
        }

        DataTable dt = service.GetPassPortData(jobcodes, tbEmpCode.Text, rdpSdate.SelectedDate, rdpEdate.SelectedDate, jobserials);

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


    protected void btnExportStatus_Click(object sender, EventArgs e)
    {

        List<string> jobcodes = new List<string>();
        foreach (RadComboBoxItem item in ddlJobCode.Items)
        {
            if (item.Checked)
            {
                jobcodes.Add(item.Value);

            }
        }

        List<string> jobserials = null;
        if (rddtJobCode.SelectedValue != "")
        {
            jobserials = rddtJobCode.SelectedValue.Split(',').ToList();
        }

        DataTable dt = service.GetPassPortRateData(jobcodes, rdpSdate.SelectedDate, rdpEdate.SelectedDate, jobserials);

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
    protected void btnExportOrderStatusData_Click(object sender, EventArgs e)
    {

        List<string> jobcodes = new List<string>();
        foreach (RadComboBoxItem item in ddlJobCode.Items)
        {
            if (item.Checked)
            {
                jobcodes.Add(item.Value);

            }
        }
        List<string> jobserials = null;
        if (rddtJobCode.SelectedValue != "")
        {
            jobserials = rddtJobCode.SelectedValue.Split(',').ToList();
        }

        DataTable dt = service.GetPassPortOrderRateData(jobcodes, rdpSdate.SelectedDate, rdpEdate.SelectedDate, jobserials);

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
}