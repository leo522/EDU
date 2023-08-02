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

public partial class RecordAdminManage : AuthPage
{

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
        AddPostbackControl(rgMyList);
        
        if (!IsPostBack)
        {
            BindRecordTemplate();
            DeptSelector1.Select(this.HospCode, this.LocCode);
        }
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
        List<RecordInstanceDto> list = service.SearchRecordInstances(tbEmpCodeName.Text.Trim(), rdpRecdate.SelectedDate, rdpRecdateEnd.SelectedDate, tbKeyword.Text.Trim(), templateid, DeptSelector1.SelectDept == null ? "" : DeptSelector1.SelectDept.Hospcode, DeptSelector1.SelectDept == null ? "" : DeptSelector1.SelectDept.Deptcode, tbSigner.Text, rcb_status.SelectedValue, true).OrderBy(c => c.Sdate).ToList();
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
        string url = "RecordEdit.aspx?InstanceID=" + instanceid + "&EmpCode=" + this.EmpCode;
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

            ImageButton btnAct = e.Item.FindControl("btnAct") as ImageButton;

            if (ins.RecordEduActRefs != null && ins.RecordEduActRefs.Count > 0)
            {
                btnAct.Visible = true;
            }
            else
            {
                btnAct.Visible = false;
            }
            GridDataItem dataBoundItem = e.Item as GridDataItem;
            switch(dataBoundItem["StatusName"].Text)
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
    
    protected void btnAct_Click(object sender, ImageClickEventArgs e)
    {
        string instanceid = ((sender as ImageButton).Parent.Parent as GridDataItem).GetDataKeyValue("InstanceID").ToString();
        RecordInstanceDto ins = CurrentRecInstanceList.Where(c => c.InstanceID == instanceid).FirstOrDefault();
        if(ins.RecordEduActRefs.Count>0)
        {
            OpenNewWindow("EduStopActScheduleView.aspx?id=" + ins.RecordEduActRefs.FirstOrDefault().EduStopActScheduleID);
        }
        
    }

    protected void btnQuery_Click(object sender, EventArgs e)
    {
        ReadRecordData();
        rgMyList.DataBind();
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

        if(ins.Status == "V")
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
    protected void btnNextStatus_Click(object sender, EventArgs e)
    {
        string instanceid = ((sender as Button).Parent.Parent as GridDataItem).GetDataKeyValue("InstanceID").ToString();
        RecordInstanceDto ins = CurrentRecInstanceList.Where(c => c.InstanceID == instanceid).FirstOrDefault();

        if (ins.Status == "V")
        {
            ins.Status = "3";
        }

        int status = Convert.ToInt32(ins.Status);
        if (status != 3)
        {
            status = status + 1;

            string msg = service.UpdateRecordInstanceStatus(ins, status == 3 ? "V" : status.ToString(), this.EmpCode, true);

            
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
    protected void btnReject_Click(object sender, EventArgs e)
    {
        string allmsg = "";
        foreach (GridDataItem item in rgMyList.SelectedItems)
        {
            string instanceid = item.GetDataKeyValue("InstanceID").ToString();
            RecordInstanceDto ins = CurrentRecInstanceList.Where(c => c.InstanceID == instanceid).FirstOrDefault();

            if (ins.Status == "V")
            {
                ins.Status = "3";
            }

            int status = Convert.ToInt32(ins.Status);
            if (status != 0)
            {
                status = status - 1;


                string msg = service.UpdateRecordInstanceStatus(ins, status.ToString(), this.EmpCode, true, tbRejectReason.Text);

                if (msg == "" || msg == null)
                {
                    //ReadRecordData();
                    //rgMyList.DataBind();
                }
                else
                {
                    allmsg += "更新失敗:" + msg + "/r/n";
                    //ShowMessage("更新失敗:" + msg);
                }
            }
        }

        if(allmsg!="")
        {
            ShowMessage(allmsg);
        }
        else
        {
            ReadRecordData();
            rgMyList.DataBind();
        }

    }
}