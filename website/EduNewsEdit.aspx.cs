using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KMU.EduActivity.ApplicationLayer.DTO;
using System.Globalization;
using KMU.EduActivity.ApplicationLayer.Services;
using Telerik.Web.UI;
using System.IO;

public partial class EduNewsEdit : AuthPage
{
    private string CurrentID
    {
        get
        {
            return Request.QueryString["newid"];
        }
    }

    private List<NewsViewTargetDto> CurrentTargets
    {
        get
        {
            return ViewState["CurrentTargets"] as List<NewsViewTargetDto>;
        }
        set
        {
            ViewState["CurrentTargets"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {


        //(Master.FindControl("RadScriptManager1") as RadScriptManager).RegisterPostBackControl(rgAttachment);
        if (!IsPostBack)
        {
            BindJobs();
            BindDept();
            if (Request.QueryString["newid"] != null)
            {
                ReadData();
            }
        }
    }

    private void BindDept()
    {
        List<V_departmentDto> list = service.GetDepts("KMUH");
        ddlDept.DataTextField = "DisplayName";
        ddlDept.DataValueField = "Deptcode";
        ddlDept.DataSource = list;
        ddlDept.DataBind();
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
        NewsDto data = service.GetNewsData(CurrentID);

        
        if (data != null)
        {
            tbTitle.Text = data.TITLE;
            reContent.Content = data.CONTENT;
            rdpSDate.SelectedDate = data.SDATE;
            rdpEDate.SelectedDate = data.EDATE;
            
            List<NewsViewTargetDto> targets = service.GetNewsViewTarget(data.NEWID);

            CurrentTargets = targets;
            rgTargets.DataSource = CurrentTargets;
            rgTargets.DataBind();
        }
    }


    private bool CheckInput()
    {
        if (tbTitle.Text.Trim() == "")
        {
            ShowMessage("未輸入 標題");
            return false;
        }

        if (reContent.Content.Trim() == "")
        {
            ShowMessage("未輸入 內容");
            return false;
        }

        if (rdpSDate.SelectedDate == null)
        {
            ShowMessage("未選擇 消息日期");
            return false;
        }


        return true;
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (!CheckInput())
        {
            return;
        }

        List<News_AttachmentDto> attachments = new List<News_AttachmentDto>();
        foreach (UploadedFile file in rauAttachment.UploadedFiles)
        {
            byte[] bytes = new byte[file.InputStream.Length];
            file.InputStream.Read(bytes, 0, bytes.Length);
            file.InputStream.Seek(0, SeekOrigin.Begin);
            News_AttachmentDto dto = new News_AttachmentDto();
            dto.AttachmentName = file.FileName;
            dto.Attachment = bytes;
            attachments.Add(dto);
        }

        if (CurrentID == null)
        {
            NewsDto dto = new NewsDto();
            dto.TITLE = tbTitle.Text;
            dto.CONTENT = reContent.Content;
            dto.CREATER = this.EmpCode;
            dto.SDATE = rdpSDate.SelectedDate.Value;
            dto.EDATE = rdpEDate.SelectedDate;
            dto.CREATEDATE = DateTime.Now;
            service.InsertNews(dto, attachments, CurrentTargets);
        }
        else
        {
            NewsDto dto = service.GetNewsData(CurrentID);
            dto.TITLE = tbTitle.Text;
            dto.CONTENT = reContent.Content;
            dto.SDATE = rdpSDate.SelectedDate.Value;
            dto.EDATE = rdpEDate.SelectedDate;
            service.UpdateNews(dto, attachments, CurrentTargets);
        }

        Response.Redirect("EduNewsView.aspx");
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("EduNewsView.aspx");
    }
    protected void odsAttachment_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        e.InputParameters["newid"] = CurrentID;
    }
    protected void rgAttachment_DeleteCommand(object sender, GridCommandEventArgs e)
    {
        if (e.CommandName != RadGrid.DeleteSelectedCommandName)
        {
            if (e.Item is GridDataItem)
            {
                if ((e.Item as GridDataItem).GetDataKeyValue("AttachmentID") != null)
                {
                    string id = (e.Item as GridDataItem).GetDataKeyValue("AttachmentID").ToString();

                    service.DeleteNewsAttachment(Convert.ToInt32(id));
                    rgAttachment.DataBind();
                }
            }
        }
    }
    protected void btnAddTeam_Click(object sender, EventArgs e)
    {

        Dictionary<string, string> nvlist = rvcbTeam.CheckedNameValues;
        if (nvlist.Count != 0)
        {
            if (CurrentTargets == null)
            {
                CurrentTargets = new List<NewsViewTargetDto>();
            }
            foreach (string key in nvlist.Keys)
            {
                NewsViewTargetDto newitem = new NewsViewTargetDto();
                newitem.TargetID = key;
                newitem.TargetName = nvlist[key];
                newitem.TargetType = "組別";
                CurrentTargets.Add(newitem);
            }
            rgTargets.DataSource = CurrentTargets;
            rgTargets.DataBind();
        }

    }
    protected void btnAddJob_Click(object sender, EventArgs e)
    {
        if (ddlJobCode.SelectedValue != "" && ddlJobCode.SelectedValue != null)
        {
            if (CurrentTargets == null)
            {
                CurrentTargets = new List<NewsViewTargetDto>();
            }
            if (CurrentTargets.Count(c => c.TargetType == "職稱" && c.TargetID == ddlJobCode.SelectedValue) > 0)
            {
                ShowMessage("已有本項設定");
                return;
            }

            NewsViewTargetDto newitem = new NewsViewTargetDto();
            newitem.TargetID = ddlJobCode.SelectedValue;
            newitem.TargetName = ddlJobCode.Text;
            newitem.TargetType = "職稱";
            CurrentTargets.Add(newitem);
            rgTargets.DataSource = CurrentTargets;
            rgTargets.DataBind();
        }
    }
    protected void rgTargets_DeleteCommand(object sender, GridCommandEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            string tartype = (e.Item as GridDataItem).GetDataKeyValue("TargetType").ToString();
            string tarid = (e.Item as GridDataItem).GetDataKeyValue("TargetID").ToString();

            NewsViewTargetDto deltar = CurrentTargets.Where(c => c.TargetID == tarid && c.TargetType == tartype).FirstOrDefault();
            if (deltar != null)
            {
                CurrentTargets.Remove(deltar);
                rgTargets.DataSource = CurrentTargets;
                rgTargets.DataBind();
            }

        }
    }
    protected void btnAddEmp_Click(object sender, EventArgs e)
    {
        if (VsSelector1.SelectedValue != "" && VsSelector1.SelectedValue != null)
        {
            if (CurrentTargets == null)
            {
                CurrentTargets = new List<NewsViewTargetDto>();
            }
            if (CurrentTargets.Count(c => c.TargetType == "職編" && c.TargetID == VsSelector1.SelectedValue) > 0)
            {
                ShowMessage("已有本項設定");
                return;
            }

            NewsViewTargetDto newitem = new NewsViewTargetDto();
            newitem.TargetID = VsSelector1.SelectedValue;
            newitem.TargetName = VsSelector1.SelectedText;
            newitem.TargetType = "職編";
            CurrentTargets.Add(newitem);
            rgTargets.DataSource = CurrentTargets;
            rgTargets.DataBind();
        }
    }
    protected void btnAddDept_Click(object sender, EventArgs e)
    {
        if (ddlDept.SelectedValue != "" && ddlDept.SelectedValue != null)
        {
            if (CurrentTargets == null)
            {
                CurrentTargets = new List<NewsViewTargetDto>();
            }
            if (CurrentTargets.Count(c => c.TargetType == "部門" && c.TargetID == ddlDept.SelectedValue) > 0)
            {
                ShowMessage("已有本項設定");
                return;
            }

            NewsViewTargetDto newitem = new NewsViewTargetDto();
            newitem.TargetID = ddlDept.SelectedValue;
            newitem.TargetName = ddlDept.Text;
            newitem.TargetType = "部門";
            CurrentTargets.Add(newitem);
            rgTargets.DataSource = CurrentTargets;
            rgTargets.DataBind();
        }
    }
}