using KMU.EduActivity.ApplicationLayer.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class EduPassportManage : AuthPage
{
    private List<EduPassportInstanceDto> CurrentInstances
    {
        get
        {
            return ViewState["CurrentInstances"] as List<EduPassportInstanceDto>;
        }
        set
        {
            ViewState["CurrentInstances"] = value;
        }

    }

    private DataTable CurrentItemData
    {
        get
        {
            return ViewState["CurrentItemData"] as DataTable;
        }
        set
        {
            ViewState["CurrentItemData"] = value;
        }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        AddPostbackControl(btnExport);
        AddPostbackControl(btnExportList);
        if (!IsPostBack)
        {
            BindDept();
            BindPassport();

            if(this.AuthRoles.Contains("Admin"))
            {
                btnDel.Visible = true;
                btnToImportPassport.Visible = true;
                btnToSendPassport.Visible = true;
                
            }
            else
            {
                btnDel.Visible = false;
                btnToImportPassport.Visible = false;
                btnToSendPassport.Visible = false;
            }


            tbEduYear.Text = Univar.Storage.Session.Get(this.GetType().Name + "_tbEduYear");
            ddlUnit.SelectedValue = Univar.Storage.Session.Get(this.GetType().Name + "_ddlUnit");

            rcbTemplateID.SelectedValue = Univar.Storage.Session.Get(this.GetType().Name + "_rcbTemplateID");
            rcbTemplateID_SelectedIndexChanged(rcbTemplateID, null);

            tbEvalTarget.Text = Univar.Storage.Session.Get(this.GetType().Name + "_tbEvalTarget");
            rdpDateBegin.SelectedDate = Univar.Storage.Session.Get<DateTime?>(this.GetType().Name + "_rdpDateBegin");
            rdpDateEnd.SelectedDate = Univar.Storage.Session.Get<DateTime?>(this.GetType().Name + "_rdpDateEnd");
        }
    }


    private void ReadData()
    {

        DataTable itemdata = null;

        List<EduPassportInstanceDto> list = service.QueryEduPassportInstance(tbEduYear.Text, rddtJobCode.SelectedValue, ddlUnit.SelectedValue, tbEvalTarget.Text, rcbTemplateID.SelectedValue, rdpDateBegin.SelectedDate, rdpDateEnd.SelectedDate, rcbTemplateItem.SelectedValue, ref itemdata).OrderBy(c => c.EmpCode).ToList();



        rgList.DataSource = list;
        CurrentInstances = list;

        CurrentItemData = itemdata;
        rgItem.DataSource = itemdata;


    }

    private void ReadItemData()
    {

    }

    private void BindPassport()
    {
        List<EduPassportTemplateDto> list = service.GetEduPassportTemplates(null, null, null);

        EduPassportTemplateDto empty = new EduPassportTemplateDto();
        empty.TemplateName = "";
        empty.TemplateID = "";
        list.Insert(0, empty);

        rcbTemplateID.DataValueField = "TemplateID";
        rcbTemplateID.DataTextField = "TemplateName";
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
    }

    private void BindTemplateItems()
    {
        rcbTemplateItem.ClearSelection();
        List<EduPassportTemplateItemDto> list = service.GetEduPassportTemplateWithItem(rcbTemplateID.SelectedValue).EduPassportTemplateItems.ToList();

        rcbTemplateItem.DataValueField = "ItemID";
        rcbTemplateItem.DataTextField = "ItemName";
        rcbTemplateItem.DataSource = list;
        rcbTemplateItem.DataBind();
    }

    protected void rgList_ItemCreated(object sender, Telerik.Web.UI.GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            string id = (e.Item as GridDataItem).GetDataKeyValue("InstanceID").ToString();
            string tid = (e.Item as GridDataItem).GetDataKeyValue("TemplateID").ToString();

            EduPassportInstanceDto ins = CurrentInstances.Where(c => c.TemplateID == tid).FirstOrDefault();

            HyperLink btnView = e.Item.FindControl("btnView") as HyperLink;
            if (ins != null)
            {
                btnView.Visible = true;
                btnView.NavigateUrl = "EduPassportInstanceView.aspx?ID=" + id;
            }


            Button btnRefresh = e.Item.FindControl("btnRefresh") as Button;
            if (btnRefresh != null)
            {
                if (this.AuthRoles.Contains("Admin"))
                {
                    btnRefresh.Visible = true;
                }
                else
                {
                    btnRefresh.Visible = false;
                }
            }
        }
    }
    protected void btnQuery_Click(object sender, EventArgs e)
    {
        if (tbEduYear.Text == "")
        {
            ShowMessage("請設定學年度");
            return;
        }
        //if (rddtJobCode.SelectedValue == null || rddtJobCode.SelectedValue == "")
        //{
        //    ShowMessage("請選擇職稱");
        //    return;
        //}

        ReadData();
        rgList.DataBind();
        if (rgItem.DataSource != null)
        {
            rgItem.DataBind();
        }

        Univar.Storage.Session.Set(this.GetType().Name + "_tbEduYear", tbEduYear.Text);
        Univar.Storage.Session.Set(this.GetType().Name + "_ddlUnit", ddlUnit.SelectedValue);
        Univar.Storage.Session.Set(this.GetType().Name + "_rddtJobCode", rddtJobCode.SelectedValue);
        Univar.Storage.Session.Set(this.GetType().Name + "_rcbTemplateID", rcbTemplateID.SelectedValue);
        Univar.Storage.Session.Set(this.GetType().Name + "_tbEvalTarget", tbEvalTarget.Text);
        Univar.Storage.Session.Set<DateTime?>(this.GetType().Name + "_rdpDateBegin", rdpDateBegin.SelectedDate);
        Univar.Storage.Session.Set<DateTime?>(this.GetType().Name + "_rdpDateEnd", rdpDateEnd.SelectedDate);




    }
    protected void rgList_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        if (IsPostBack)
        {
            rgList.DataSource = CurrentInstances;
        }
    }


    protected void btnExport_Click(object sender, EventArgs e)
    {
        rgItem.ExportSettings.Excel.Format = GridExcelExportFormat.ExcelML;
        rgItem.ExportSettings.ExportOnlyData = true;
        rgItem.ExportSettings.IgnorePaging = true;
        rgItem.ExportSettings.OpenInNewWindow = true;
        rgItem.MasterTableView.ExportToExcel();
    }
    protected void rcbTemplateID_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        if (rcbTemplateID.SelectedValue != "")
        {
            panItemFilter.Visible = true;
            BindTemplateItems();
        }
        else
        {
            panItemFilter.Visible = false;
        }
    }
    protected void rddtJobCode_DataBound(object sender, EventArgs e)
    {
        rddtJobCode.SelectedValue = Univar.Storage.Session.Get(this.GetType().Name + "_rddtJobCode") == null ? "" : Univar.Storage.Session.Get(this.GetType().Name + "_rddtJobCode");
    }
    protected void rgItem_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        rgItem.DataSource = CurrentItemData;
    }
    protected void btnExportList_Click(object sender, EventArgs e)
    {

        rgList.ExportSettings.Excel.Format = GridExcelExportFormat.ExcelML;
        rgList.ExportSettings.ExportOnlyData = true;
        rgList.ExportSettings.IgnorePaging = true;
        rgList.ExportSettings.OpenInNewWindow = true;
        rgList.MasterTableView.ExportToExcel();
    }
    protected void btnToImportPassport_Click(object sender, EventArgs e)
    {
        Response.Redirect("EduPassportManageImport.aspx");
    }
    protected void btnToSendPassport_Click(object sender, EventArgs e)
    {
        Response.Redirect("EduPassportManageSend.aspx");
    }
    protected void btnDel_Click(object sender, EventArgs e)
    {
        foreach (GridDataItem item in rgList.SelectedItems)
        {
            string instanceid = item.GetDataKeyValue("InstanceID").ToString();
            if (instanceid != null)
            {
                string msg = service.DeleteEduPassportInstance(instanceid);
                if (msg != null)
                {
                    ShowMessage(msg);
                }
                else
                {
                    btnQuery_Click(btnQuery, null);
                }
            }

        }
    }


    protected void btnPrint_Click(object sender, EventArgs e)
    {
        GridDataItem item = (sender as Button).Parent.Parent as GridDataItem;
        string id = item.GetDataKeyValue("InstanceID").ToString();
        
        Response.Redirect("EduPassportInstancePrint.aspx?ID=" + id);

    }
    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        GridDataItem item = (sender as Button).Parent.Parent as GridDataItem;
        string id = item.GetDataKeyValue("InstanceID").ToString();
        string msg = service.RefreshEduPassportInstance(id);
        if (msg != null)
        {
            ShowMessage("更新失敗:" + msg);
        }
        else
        {
            ReadData();
            rgList.DataBind();
        }
    }
    protected void rgList_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            //5,6,7
            if (e.Item.Cells[8].Text != "100%")
            {
                e.Item.Cells[8].ForeColor = System.Drawing.Color.Red;
            }

            if (e.Item.Cells[9].Text != "100%")
            {
                e.Item.Cells[9].ForeColor = System.Drawing.Color.Red;
            }

            if (e.Item.Cells[10].Text != "100%")
            {
                e.Item.Cells[10].ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}