using KMU.EduActivity.ApplicationLayer.DTO;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class RecordActAdd : AuthPage
{

    private string CurrentEduStopActScheduleID
    {
        get
        {
            return Request.QueryString["ScheduleID"];
        }
    }


    private List<RecordInstanceDto> CurrentRecInstanceList
    {
        get
        {
            return ViewState["CurrentRecInstanceList"] as List<RecordInstanceDto>;

        }
        set
        {
            ViewState["CurrentRecInstanceList"] = value;
        }
    }



    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {


            BindRecordTemplate();
            ReadRecordData();
            rgMyList.DataBind();
        }
    }

    private void BindRecordTemplate()
    {
        List<RecordTemplateDto> list = service.GetRecordTemplateList();
        rcbRecordTemplate.DataValueField = "TemplateID";
        rcbRecordTemplate.DataTextField = "TemplateName";
        rcbRecordTemplate.DataSource = list;
        rcbRecordTemplate.DataBind();
    }
    
    private void ReadRecordData()
    {
        List<RecordInstanceDto> list = service.GetMyRecordInstances(this.EmpCode);
        CurrentRecInstanceList = list;
        rgMyList.DataSource = CurrentRecInstanceList;


    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if(rcbRecordTemplate.SelectedValue == "" || rcbRecordTemplate.SelectedValue == null)
        {
            ShowMessage("請選擇會議記錄類別");
            return;
        }

        string instanceid = service.CreateRecordInstance(Convert.ToInt32(rcbRecordTemplate.SelectedValue), this.EmpCode, CurrentEduStopActScheduleID);

        if(instanceid!=null)
        {
            Response.Redirect("RecordEdit.aspx?InstanceID=" + instanceid + "&EmpCode=" + this.EmpCode);
        }
        else
        {
            ShowMessage("建立會議記錄失敗，請聯絡系統管理者");
        }

    }
    protected void rgMyList_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        ReadRecordData();
    }


    protected void btnEdit_Click(object sender, ImageClickEventArgs e)
    {
        string instanceid = ((sender as ImageButton).Parent.Parent as GridDataItem).GetDataKeyValue("InstanceID").ToString();
        //RecordInstanceDto ins = CurrentRecInstanceList.Where(c => c.InstanceID == instanceid).FirstOrDefault();

        Response.Redirect("RecordEdit.aspx?InstanceID=" + instanceid + "&EmpCode=" + this.EmpCode);



    }
    protected void btnDel_Click(object sender, ImageClickEventArgs e)
    {
        string instanceid = ((sender as ImageButton).Parent.Parent as GridDataItem).GetDataKeyValue("InstanceID").ToString();
        //RecordInstanceDto ins = CurrentRecInstanceList.Where(c => c.InstanceID == instanceid).FirstOrDefault();
        service.DeleteRecordInstance(instanceid);
        ReadRecordData();
        rgMyList.DataBind();
    }
    protected void rgMyList_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if(e.Item is GridDataItem)
        {
            string instanceid = (e.Item as GridDataItem).GetDataKeyValue("InstanceID").ToString();
            RecordInstanceDto ins = CurrentRecInstanceList.Where(c => c.InstanceID == instanceid).FirstOrDefault();
            ImageButton btnEdit = e.Item.FindControl("btnEdit") as ImageButton;
            ImageButton btnDel = e.Item.FindControl("btnDel") as ImageButton;


            if (ins.Status == "0")
            {
                btnEdit.Visible = true;
                btnDel.Visible = true;
            }
            else
            {
                btnEdit.Visible = false;
                btnDel.Visible = false;
            }

        }
    }
}