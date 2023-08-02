using KMU.EduActivity.ApplicationLayer.DTO;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class RecordSelect : AuthPage
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

    private List<RecordInstanceDto> CurrentExistRecInstanceList
    {
        get
        {
            return ViewState["CurrentExistRecInstanceList"] as List<RecordInstanceDto>;

        }
        set
        {
            ViewState["CurrentExistRecInstanceList"] = value;
        }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        AddPostbackControl(rgExistList);
        AddPostbackControl(rgMyList);
        if(!IsPostBack)
        {
            
            if (CurrentEduStopActScheduleID == null)
            {
                ShowMessageAndGoBack("參數傳遞錯誤");
                return;

            }
            else
            {
                BindRecordTemplate();
                ReadSchedule();

                ReadExistRecData();
                if(CurrentExistRecInstanceList.Count>0)
                {
                    rgExistList.DataBind();
                    //panSearch.Visible = false;
                    //panExists.Visible = true;
                }
                else
                {
                    //panExists.Visible = false;
                    //panSearch.Visible = true;
                }
                ReadRecordData();
            }
        }
    }


    private void ReadSchedule()
    {
        EduStopActScheduleDto sche = service.GetEduStopActSchedulerByID(CurrentEduStopActScheduleID);
        rdpRecdate.SelectedDate = sche.TimeFrom.Date;
        rdpRecdateEnd.SelectedDate = sche.TimeFrom.Date;
        if (sche.RecTemplateID != null)
        {
            rcbRecordTemplate.SelectedValue = sche.RecTemplateID.ToString();
        }

        if (sche.HospCode != null)
        {
            DeptSelector1.Select(sche.HospCode, sche.DeptCode);
        }
    }


    private void ReadExistRecData()
    {
        List<RecordInstanceDto> existrec = service.GetActRefRecord(CurrentEduStopActScheduleID);
        CurrentExistRecInstanceList = existrec;


        rgExistList.DataSource = CurrentExistRecInstanceList;
    }



    private void BindRecordTemplate()
    {
        List<RecordTemplateDto> list = service.GetRecordTemplateList(true);
        rcbRecordTemplate.DataValueField = "TemplateID";
        rcbRecordTemplate.DataTextField = "TemplateName";
        rcbRecordTemplate.DataSource = list;
        rcbRecordTemplate.DataBind();

    }

    private void ReadRecordData()
    {
        int? templateid = null;
        if(rcbRecordTemplate.SelectedValue != "" && rcbRecordTemplate.SelectedValue != null)
        {
            templateid = Convert.ToInt32(rcbRecordTemplate.SelectedValue);
        }
        List<RecordInstanceDto> list = service.SearchRecordInstances(tbEmpCodeName.Text.Trim(), rdpRecdate.SelectedDate, rdpRecdateEnd.SelectedDate, tbKeyword.Text.Trim(), templateid, DeptSelector1.SelectDept == null ? "" : DeptSelector1.SelectDept.Hospcode, DeptSelector1.SelectDept == null ? "" : DeptSelector1.SelectDept.Deptcode, "", "").OrderBy(c => c.Sdate).ToList();
        CurrentRecInstanceList = list;
        rgMyList.DataSource = CurrentRecInstanceList;

    }


    protected void rgMyList_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        
    }


    protected void btnEdit_Click(object sender, ImageClickEventArgs e)
    {
        string instanceid = ((sender as ImageButton).Parent.Parent as GridDataItem).GetDataKeyValue("InstanceID").ToString();
        //RecordInstanceDto ins = CurrentRecInstanceList.Where(c => c.InstanceID == instanceid).FirstOrDefault();
        OpenNewWindow("RecordEdit.aspx?InstanceID=" + instanceid + "&EmpCode=" + this.EmpCode);
        

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
           

            //if (ins.Status == "0")
            //{
            //    btnEdit.Visible = true;
            //}
            //else
            //{
            //    btnEdit.Visible = false;
            //}

        }
    }
    protected void btnSelect_Click(object sender, EventArgs e)
    {
        if(rgMyList.SelectedItems.Count == 0)
        {
            ShowMessage("未選擇資料");
            return;
        }
        string errmsg = "";
        foreach (GridDataItem item in rgMyList.SelectedItems)
        {
            string instanceid = item.GetDataKeyValue("InstanceID").ToString();
            RecordInstanceDto ins = CurrentRecInstanceList.Where(c => c.InstanceID == instanceid).FirstOrDefault();

            if (ins.RecordEduActRefs.Count > 0)
            {
                errmsg += ins.Sdate.Value.ToString("yyyy/MM/dd") + ins.Title + " : 已經連結至其他活動了，請選擇其他會議記錄\r\n";

            }

            string msg = service.CreateRecordActRef(instanceid, CurrentEduStopActScheduleID, this.EmpCode);
            if (msg != null)
            {
                errmsg += ins.Sdate.Value.ToString("yyyy/MM/dd") + ins.Title + " : 建立關連失敗->" + msg + "\r\n";
            }
        }

        if (errmsg != null && errmsg != "")
        {
            ShowMessage(errmsg);
        }
        else
        {
            Response.Redirect(Request.Url.ToString());
            //ShowMessageAndGo("設定完成", "EduStopActScheduleCalendar.aspx");
            return;
        }
    }
    protected void btnAct_Click(object sender, ImageClickEventArgs e)
    {
        string instanceid = ((sender as ImageButton).Parent.Parent as GridDataItem).GetDataKeyValue("InstanceID").ToString();
        RecordInstanceDto ins = CurrentRecInstanceList.Where(c => c.InstanceID == instanceid).FirstOrDefault();
        if(ins.RecordEduActRefs.Count>0)
        {
            OpenNewWindow("EduStopActScheduleView.aspx?id=" + ins.RecordEduActRefs.FirstOrDefault().EduStopActScheduleID);
        }
        
    }
    protected void btnDisconn_Click(object sender, ImageClickEventArgs e)
    {
        string instanceid = ((sender as ImageButton).Parent.Parent as GridDataItem).GetDataKeyValue("InstanceID").ToString();
        RecordInstanceDto ins = CurrentExistRecInstanceList.Where(c => c.InstanceID == instanceid).FirstOrDefault();
        string actid = CurrentEduStopActScheduleID;

        string msg = service.DeleteRecordActRef(instanceid, actid, this.EmpCode);
        if(msg != null)
        {
            ShowMessage("取消連結失敗:" + msg);
        }
        Response.Redirect(Request.Url.ToString());
    }
    protected void btnQuery_Click(object sender, EventArgs e)
    {
        ReadRecordData();
        rgMyList.DataBind();
    }
    protected void rgExistList_ItemDataBound(object sender, GridItemEventArgs e)
    {
      
    }
    protected void rgExistList_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        ReadExistRecData();
    }
    protected void btnReturn_Click(object sender, EventArgs e)
    {
        Response.Redirect("EduStopActScheduleCalendar.aspx");
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        string instanceid = ((sender as Button).Parent.Parent as GridDataItem).GetDataKeyValue("InstanceID").ToString();
        //RecordInstanceDto ins = CurrentRecInstanceList.Where(c => c.InstanceID == instanceid).FirstOrDefault();
        service.DeleteRecordInstance(instanceid);
        ReadRecordData();
        rgMyList.DataBind();
    }

    protected void btnReturnStatus_Click(object sender, EventArgs e)
    {
        string instanceid = ((sender as Button).Parent.Parent as GridDataItem).GetDataKeyValue("InstanceID").ToString();
        RecordInstanceDto ins = CurrentRecInstanceList.Where(c => c.InstanceID == instanceid).FirstOrDefault();

        if (ins.Status == "V")
        {
            ins.Status = "3";
        }

        int status = Convert.ToInt32(ins.Status);
        if (status != 0)
        {
            status = status - 1;


            string msg = service.UpdateRecordInstanceStatus(ins, status.ToString(), this.EmpCode);

            if (msg == "" || msg == null)
            {
                ReadRecordData();
                rgMyList.DataBind();
            }
            else
            {
                ShowMessage("更新失敗:" + msg);
            }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        EduStopActScheduleDto sche = service.GetEduStopActSchedulerByID(CurrentEduStopActScheduleID);
        if (sche != null && sche.RecTemplateID != null)
        {
            string instanceid = service.CreateRecordInstance(sche.RecTemplateID.Value, this.EmpCode, CurrentEduStopActScheduleID);
            if (instanceid != null)
            {
                Response.Redirect("RecordEdit.aspx?InstanceID=" + instanceid + "&EmpCode=" + this.EmpCode + "&ScheduleID=" + CurrentEduStopActScheduleID);
                return;
            }
        }
    }
}