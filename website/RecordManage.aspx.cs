using KMU.EduActivity.ApplicationLayer.DTO;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class RecordManage : AuthPage
{

    private string CurrentEduStopActScheduleID
    {
        get
        {
            return Request.QueryString["ScheduleID"];
        }
    }

    private EduStopActScheduleDto CurrentEduStopAct
    {
        get
        {
            return ViewState["CurrentEduStopAct"] as EduStopActScheduleDto;
        }
        set
        {
            ViewState["CurrentEduStopAct"] = value;
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
    private List<RecordInstanceDto> CurrentRecInstanceList2
    {
        get
        {
            return ViewState["CurrentRecInstanceList2"] as List<RecordInstanceDto>;

        }
        set
        {
            ViewState["CurrentRecInstanceList2"] = value;
        }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        AddPostbackControl(btnQuery);
        AddPostbackControl(rgMyList);
        AddPostbackControl(rgMyList0);
        if(!IsPostBack)
        {
            
            if (CurrentEduStopActScheduleID == null)
            {
                btnSelect.Visible = false;

            }
            else
            {




                RecordInstanceDto existrec = service.GetActRefRecord(CurrentEduStopActScheduleID).Where(c => c.Creater == this.EmpCode).FirstOrDefault();
                if (existrec != null)
                {
                    Response.Redirect("RecordEdit.aspx?InstanceID=" + existrec.InstanceID + "&EmpCode=" + this.EmpCode);
                    return;
                }
                else
                {
                    if (CurrentEduStopActScheduleID != null)
                    {
                        EduStopActScheduleDto sche = service.GetEduStopActSchedulerByID(CurrentEduStopActScheduleID);
                        CurrentEduStopAct = sche;
                        if (CurrentEduStopAct != null && CurrentEduStopAct.RecTemplateID != null)
                        {
                            string instanceid = service.CreateRecordInstance(CurrentEduStopAct.RecTemplateID.Value, this.EmpCode, CurrentEduStopActScheduleID);
                            if (instanceid != null)
                            {
                                Response.Redirect("RecordEdit.aspx?InstanceID=" + instanceid + "&EmpCode=" + this.EmpCode + "&ScheduleID=" + CurrentEduStopActScheduleID);
                                return;
                            }
                        }

                    }
                }
                btnSelect.Visible = true;
            }



            rdpRecdate.SelectedDate = DateTime.Now.Date.AddMonths(-2) ;


            rdpRecdateEnd.SelectedDate = DateTime.Now.Date;


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

        if (CurrentEduStopAct != null && list.Count(c => c.TemplateID == CurrentEduStopAct.RecTemplateID.Value) > 0)
        {
            rcbRecordTemplate.SelectedValue = CurrentEduStopAct.RecTemplateID.Value.ToString();
        }

        rcbRecordTemplate0.DataValueField = "TemplateID";
        rcbRecordTemplate0.DataTextField = "TemplateName";
        rcbRecordTemplate0.DataSource = list;
        rcbRecordTemplate0.DataBind();
    }
    
    private void ReadRecordData()
    {
        List<RecordInstanceDto> list = service.GetMyRecordInstances(this.EmpCode).OrderBy(c => c.Sdate).ToList();
        CurrentRecInstanceList = list;
        rgMyList.DataSource = CurrentRecInstanceList;


    }

    private void ReadRecordData2()
    {
        int? templateid = null;
        if (rcbRecordTemplate0.SelectedValue != "" && rcbRecordTemplate0.SelectedValue != null)
        {
            templateid = Convert.ToInt32(rcbRecordTemplate0.SelectedValue);
        }
        string signer = "";
        if(cbMySign.Checked)
        {
            signer = this.EmpCode;
        }

        string joiner = "";
        if(cbMyJoin.Checked)
        {
            joiner = this.EmpCode;
        }

        List<RecordInstanceDto> list = service.PersonalSearchRecordInstances(tbEmpCodeName.Text.Trim(), rdpRecdate.SelectedDate, rdpRecdateEnd.SelectedDate, tbKeyword.Text.Trim(), templateid, DeptSelector1.SelectDept == null ? "" : DeptSelector1.SelectDept.Hospcode, DeptSelector1.SelectDept == null ? "" : DeptSelector1.SelectDept.Deptcode, signer,joiner, "V", this.EmpCode).OrderBy(c => c.Sdate).ToList();
        CurrentRecInstanceList2 = list;
        rgMyList0.DataSource = CurrentRecInstanceList2;

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
        string url ="RecordEdit.aspx?InstanceID=" + instanceid + "&EmpCode=" + this.EmpCode;

        OpenNewWindow(url);

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
            ImageButton btnAct = e.Item.FindControl("btnAct") as ImageButton;
            ImageButton btnGetBack = e.Item.FindControl("btnGetBack") as ImageButton;
            ImageButton btnDisconn = e.Item.FindControl("btnDisconn") as ImageButton;

            if (ins.RecordEduActRefs != null && ins.RecordEduActRefs.Count > 0)
            {
                btnAct.Visible = true;
                btnDisconn.Visible = true;
            }
            else
            {
                btnAct.Visible = false;
                btnDisconn.Visible = false;
            }

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

            if(ins.AllowGetBack)
            {
                btnGetBack.Visible = true;
            }
            else
            {
                btnGetBack.Visible = false;
            }

        }
    }
    protected void rgMyList0_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            string instanceid = (e.Item as GridDataItem).GetDataKeyValue("InstanceID").ToString();
            RecordInstanceDto ins = CurrentRecInstanceList.Where(c => c.InstanceID == instanceid).FirstOrDefault();
            ImageButton btnEdit = e.Item.FindControl("btnEdit") as ImageButton;

            GridDataItem dataBoundItem = e.Item as GridDataItem;
            switch (dataBoundItem["StatusName"].Text)
            {
                case "已完成未送審":
                    dataBoundItem["StatusName"].ForeColor = System.Drawing.Color.Red;
                    break;
                case "審核中":
                    dataBoundItem["StatusName"].ForeColor = System.Drawing.Color.Blue;
                    break;
                case "審核完成":
                    dataBoundItem["StatusName"].ForeColor = System.Drawing.Color.Green;
                    break;
            }

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

        GridDataItem item = rgMyList.SelectedItems[0] as GridDataItem;

        string instanceid = item.GetDataKeyValue("InstanceID").ToString();
        RecordInstanceDto ins = CurrentRecInstanceList.Where(c => c.InstanceID == instanceid).FirstOrDefault();

        if(ins.RecordEduActRefs.Count>0)
        {
            ShowMessage("選取的會議記錄已經連結至其他活動了，請選擇其他會議記錄");
            return;
        }

        string msg = service.CreateRecordActRef(instanceid, CurrentEduStopActScheduleID, this.EmpCode);
        if (msg != null)
        {
            ShowMessage("建立關連失敗:" + msg);
            return;
        }
        else
        {
            ShowMessageAndGo("設定完成", "ToDoList.aspx");
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
        RecordInstanceDto ins = CurrentRecInstanceList.Where(c => c.InstanceID == instanceid).FirstOrDefault();
        string actid = ins.RecordEduActRefs.FirstOrDefault().EduStopActScheduleID;

        string msg = service.DeleteRecordActRef(instanceid, actid, this.EmpCode);
        if(msg != null)
        {
            ShowMessage("取消連結失敗:" + msg);
        }
        ReadRecordData();
        rgMyList.DataBind();
    }
    protected void btnQuery_Click(object sender, EventArgs e)
    {
        if(tbEmpCodeName.Text.Trim() == "" && !cbMyJoin.Checked && !cbMySign.Checked)
        {
            ShowMessage("我簽核過、我出席過、撰寫人請至少設定一項查詢條件");
            return;
        }

        if (rdpRecdate.SelectedDate == null)
        {
            ShowMessage("請選擇查詢會議日期範圍");
            return;
        }

        if (rdpRecdateEnd.SelectedDate == null)
        {
            ShowMessage("請選擇查詢會議日期範圍");
            return;
        }

        ReadRecordData2();
        rgMyList0.DataBind();
    }
    protected void btnGetBack_Click(object sender, ImageClickEventArgs e)
    {
        string instanceid = ((sender as ImageButton).Parent.Parent as GridDataItem).GetDataKeyValue("InstanceID").ToString();
        string msg = service.GetBackMyRecordInstances(instanceid);
        if(msg!= null)
        {
            ShowMessage("終止失敗:" + msg);
        }
        ReadRecordData();
        rgMyList.DataBind();

    }
}