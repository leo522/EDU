using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KMU.EduActivity.ApplicationLayer.DTO;
using Telerik.Web.UI;
using System.Data;

public partial class EduFormFinishRateQuery : AuthPage
{
    private DataTable CurrentFinishRate
    {
        get
        {
            return ViewState["CurrentFinishRate"] as DataTable;
        }
        set
        {
            ViewState["CurrentFinishRate"] = value;
        }
    }

    private Dictionary<string,DataTable> CurrentDetDatas
    {
        get
        {
            return ViewState["CurrentDetDatas"] as Dictionary<string, DataTable>;
        }
        set
        {
            ViewState["CurrentDetDatas"] = value;

        }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        AddPostbackControl(rgData);
        AddPostbackControl(btnExport);
        if (!IsPostBack)
        {
            BindJobs();
            BindDept();
            if (!new string[] { "7102", "7101", "7100" }.Contains(DeptCode))
            {
                ddlUnit.SelectedValue = this.DeptCode;
            }
            else
            {
                ddlUnit.SelectedValue = null;
            }
            BindTemplate();

        }
    }

    private void BindTemplate()
    {
        List<FORM_TEMPLATEDto> list = service.GetTemplates(this.HospCode);

        FORM_TEMPLATEDto nulldto = new FORM_TEMPLATEDto();
        nulldto.TEMPLATE_ID = -1;
        nulldto.TEMPLATE_NAME = "全部";

        list.Insert(0, nulldto);

        rcbTemplateID.DataValueField = "TEMPLATE_ID";
        rcbTemplateID.DataTextField = "TEMPLATE_NAME";
        rcbTemplateID.DataSource = list;
        rcbTemplateID.DataBind();
    }

    private void BindDept()
    {
        List<SelectGroupTypeDto> list = service.GetTermUnit("EduAct_Dept");
        SelectGroupTypeDto nullitem = new SelectGroupTypeDto();
        nullitem.code = null;
        nullitem.name = "";
        list.Insert(0, nullitem);
        ddlUnit.DataValueField = "code";
        ddlUnit.DataTextField = "Name";
        ddlUnit.DataSource = list;
        ddlUnit.DataBind();

        ddlUnit0.DataValueField = "code";
        ddlUnit0.DataTextField = "Name";
        ddlUnit0.DataSource = list;
        ddlUnit0.DataBind();


    }


    private void BindJobs()
    {
        List<V_kmujobDto> list = service.GetJobs();
        ddlJobCode.DataTextField = "DisplayName";
        ddlJobCode.DataValueField = "JOB_CODE_X";
        ddlJobCode.DataSource = list;
        ddlJobCode.DataBind();
    }

    private void ReadData()
    {
        List<string> jobcodes = null;
        if (rddtJobCode.SelectedValue != "")
        {
            jobcodes = rddtJobCode.SelectedValue.Split(',').ToList();
        }
        List<string> empjobcodes = new List<string>();

        foreach (RadComboBoxItem item in ddlJobCode.Items)
        {
            if (item.Checked)
            {
                empjobcodes.Add(item.Value);
            }
        }

        int? templateid = null;
        if (rcbTemplateID.SelectedValue != null && rcbTemplateID.SelectedValue != "-1")
        {
            templateid = Utility.GetNullInt(rcbTemplateID.SelectedValue);
        }

        DataTable dt = new DataTable();
        Dictionary<string, DataTable> list = service.GetEduFormFinishRate(jobcodes, ddlUnit.SelectedValue, templateid, rdpSendSDate.SelectedDate, rdpSendEDate.SelectedDate, tbTarget.Text.Trim(), empjobcodes, cbExNotFinish.Checked, ddlUnit0.SelectedValue, out dt);

        CurrentFinishRate = dt;

        rgData.DataSource = dt;
        CurrentDetDatas = list;
    }

    protected void btnQuery_Click(object sender, EventArgs e)
    {
        if(rdpSendSDate.SelectedDate == null || rdpSendEDate.SelectedDate == null)
        {
            ShowMessage("請選擇發送時間範圍");
            return;
        }
        ReadData();
        rgData.DataBind();
    }
    protected void rgData_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        rgData.DataSource = CurrentFinishRate;
        
    }

    protected void rgData_ItemCreated(object sender, GridItemEventArgs e)
    {

    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        rgData.ExportSettings.Excel.Format = GridExcelExportFormat.ExcelML;
        rgData.ExportSettings.ExportOnlyData = true;
        rgData.ExportSettings.IgnorePaging = true;
        rgData.ExportSettings.OpenInNewWindow = true;
        rgData.MasterTableView.ExportToExcel();
    }

    protected void btnExportDet_Click(object sender, EventArgs e)
    {
        GridDataItem item = (sender as Button).Parent.Parent as GridDataItem;

        string seqno = item.GetDataKeyValue("SeqNo").ToString();

        DataTable dt = CurrentDetDatas[seqno];

        Utility uti = new Utility();

        byte[] bytes = uti.ExportDataTableToExcel(dt);


        HttpResponse response = Response;

        response.Clear();


        response.AddHeader("Content-Type", "binary/octet-stream");

        response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode(seqno) + ".xls" + "; size=" + bytes.Length.ToString());

        response.BinaryWrite(bytes);

        response.Flush();
        response.End();

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
}