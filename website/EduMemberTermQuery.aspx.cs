using KMU.EduActivity.ApplicationLayer.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class EduMemberTermQuery : AuthPage
{
    private DataTable CurrentList
    {
        get
        {
            return ViewState["CurrentList"] as DataTable;
        }
        set
        {
            ViewState["CurrentList"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        AddPostbackControl(btnExportList);
        if (!IsPostBack)
        {
            BindDept();

            tbEduYear.Text = Univar.Storage.Session.Get(this.GetType().Name + "_tbEduYear");
            ddlUnit.SelectedValue = Univar.Storage.Session.Get(this.GetType().Name + "_ddlUnit");

            tbEvalTarget.Text = Univar.Storage.Session.Get(this.GetType().Name + "_tbEvalTarget");
            rdpDateBegin.SelectedDate = Univar.Storage.Session.Get<DateTime?>(this.GetType().Name + "_rdpDateBegin");
            rdpDateEnd.SelectedDate = Univar.Storage.Session.Get<DateTime?>(this.GetType().Name + "_rdpDateEnd");

            if (!this.AuthRoles.Contains("Admin") && !this.AuthRoles.Contains("DepSec"))
            {
                //rgList.MasterTableView.GetColumn("TemplateColumn").Visible = false;

                panControl.Visible = false;
                tbEvalTarget.Text = this.EmpCode;
                tbEvalTarget.Enabled = false;
            }
        }
    }

    private void ReadData()
    {

        DataTable list = service.QueryEduMemberTerm(tbEduYear.Text, rddtJobCode.SelectedValue, ddlUnit.SelectedValue, tbEvalTarget.Text, rdpDateBegin.SelectedDate, rdpDateEnd.SelectedDate);

        rgList.DataSource = list;
        CurrentList = list;
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
    }

    protected void btnQuery_Click(object sender, EventArgs e)
    {

        if (rdpDateBegin.SelectedDate == null || rdpDateEnd.SelectedDate == null)
        {
            ShowMessage("請設定實習期間");
            return;
        }

        ReadData();
        rgList.DataBind();

        Univar.Storage.Session.Set(this.GetType().Name + "_tbEduYear", tbEduYear.Text);
        Univar.Storage.Session.Set(this.GetType().Name + "_ddlUnit", ddlUnit.SelectedValue);
        Univar.Storage.Session.Set(this.GetType().Name + "_rddtJobCode", rddtJobCode.SelectedValue);
        Univar.Storage.Session.Set(this.GetType().Name + "_tbEvalTarget", tbEvalTarget.Text);
        Univar.Storage.Session.Set<DateTime?>(this.GetType().Name + "_rdpDateBegin", rdpDateBegin.SelectedDate);
        Univar.Storage.Session.Set<DateTime?>(this.GetType().Name + "_rdpDateEnd", rdpDateEnd.SelectedDate);




    }
    protected void rgList_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        if (IsPostBack)
        {
            rgList.DataSource = CurrentList;
        }
    }

    protected void rddtJobCode_DataBound(object sender, EventArgs e)
    {
        rddtJobCode.SelectedValue = Univar.Storage.Session.Get(this.GetType().Name + "_rddtJobCode") == null ? "" : Univar.Storage.Session.Get(this.GetType().Name + "_rddtJobCode");
    }

    protected void btnExportList_Click(object sender, EventArgs e)
    {

        rgList.ExportSettings.Excel.Format = GridExcelExportFormat.ExcelML;
        rgList.ExportSettings.ExportOnlyData = true;
        rgList.ExportSettings.IgnorePaging = true;
        rgList.ExportSettings.OpenInNewWindow = true;
        rgList.MasterTableView.ExportToExcel();
    }
    protected void rgList_ItemCreated(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            HyperLink link = e.Item.FindControl("hlForm") as HyperLink;
            string edutermid = (e.Item as GridDataItem).GetDataKeyValue("EduTermID").ToString();
            string empcode = (e.Item as GridDataItem).GetDataKeyValue("職編").ToString();

            //link.NavigateUrl = "EduFormPersonalList.aspx?EduTermID=" + edutermid + "&EmpCode=" + empcode;
            link.NavigateUrl = "EduMemberTermQueryNew.aspx?edutermid=" + edutermid + "&empcode=" + empcode;
            

        }
    }
}