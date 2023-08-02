using KMU.EduActivity.ApplicationLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class EduPassportTemplateAdd : AuthPage
{
    private EduPassportTemplateDto CurrentTemplate
    {
        get
        {
            return ViewState["CurrentTemplate"] as EduPassportTemplateDto;
        }
        set
        {
            ViewState["CurrentTemplate"] = value;
        }
    }

    private List<EduPassportTemplateItemDto> CurrentItems
    {
        get
        {
            return ViewState["CurrentItems"] as List<EduPassportTemplateItemDto>;
        }
        set
        {
            ViewState["CurrentItems"] = value;
        }
    }


    private string CurrentTemplateID
    {
        get
        {
            if (Request.QueryString["TemplateID"] != null)
            {
                return Request.QueryString["TemplateID"];
            }
            else if (Request.QueryString["CopyTemplateID"] != null)
            {
                return Request.QueryString["CopyTemplateID"];
            }
            else
            {
                return null;
            }
        }
    }

    private List<EduTermDto> CurrentSendTerm
    {
        get
        {
            return ViewState["CurrentSendTerm"] as List<EduTermDto>;
        }
        set
        {
            ViewState["CurrentSendTerm"] = value;
        }
    }

    private bool IsCopyMode
    {
        get
        {
            return Request.QueryString["CopyTemplateID"] != null;
        }
    }



    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDeptment();

            if (Request.QueryString["TemplateID"] != null || Request.QueryString["CopyTemplateID"] != null)
            {
                ReadData();
            }
            else
            {
                CurrentTemplate = new EduPassportTemplateDto();
                CurrentTemplate.EduPassportTemplateItems = new List<EduPassportTemplateItemDto>();
                CurrentTemplate.EduPassportTemplateTargets = new List<EduPassportTemplateTargetDto>();
                CurrentItems = new List<EduPassportTemplateItemDto>();
                CurrentSendTerm = new List<EduTermDto>();
            }
            rgSendTerm.DataSource = CurrentSendTerm;
            rgSendTerm.DataBind();

            rgSDet.DataSource = CurrentItems;
            rgSDet.DataBind();

        }
    }

    private void ReadData()
    {

        EduPassportTemplateDto item = service.GetEduPassportTemplateWithItem(CurrentTemplateID);

        CurrentTemplate = item;

        CurrentItems = item.EduPassportTemplateItems.OrderBy(c => c.Seq).ToList();

        tbName.Text = item.TemplateName;
        rdpSdate.SelectedDate = item.Sdate;
        rdpEdate.SelectedDate = item.Edate;
        reContent.Content = item.TemplateDesc;
        cbAllowAdminConfirm.Checked = item.AllowAdminConfirm;

        foreach (EduPassportTemplateTargetDto target in item.EduPassportTemplateTargets.Where(c => c.TargetType == "dept"))
        {
            foreach(RadComboBoxItem i in ddlUnit.Items)
            {
                if(i.Value == target.TargetID)
                {
                    i.Checked = true;
                }   
            }
        }

        CurrentSendTerm = new List<EduTermDto>();
        foreach (EduPassportTemplateTargetDto target in item.EduPassportTemplateTargets.Where(c => c.TargetType == "eduterm"))
        {
            var eduterm = service.GetEduTermByID(target.TargetID);
            if(eduterm == null)
            {
                continue;
            }
            EduTermDto dto = new EduTermDto();
            dto.EduTermID = target.TargetID;
            dto.Name = service.GetEduTermFullName(dto.EduTermID);
            CurrentSendTerm.Add(dto);
            
        }


        if (IsCopyMode)
        {
            item.TemplateID = null;
            foreach (EduPassportTemplateItemDto det in item.EduPassportTemplateItems)
            {
                det.TemplateID = null;
            }

            foreach (EduPassportTemplateTargetDto target in item.EduPassportTemplateTargets)
            {
                target.TemplateID = null;
            }
        }

        

    }

    private void BindDeptment()
    {
        List<SelectGroupTypeDto> list = service.GetTermUnit("EduAct_Dept");

        ddlUnit.DataValueField = "code";
        ddlUnit.DataTextField = "Name";
        ddlUnit.DataSource = list;
        ddlUnit.DataBind();

        ddlUnit.SelectedIndex = 0;

    }

    private List<EduPassportTemplateItemDto> RefreshSeq(List<EduPassportTemplateItemDto> input)
    {
        int i = 1;
        foreach (EduPassportTemplateItemDto dto in input.OrderBy(c => c.Seq))
        {
            dto.Seq = i;
            i++;
        }

        return input.ToList();

    }

    protected void btnDelete_Click(object sender, ImageClickEventArgs e)
    {
        GridDataItem item = (sender as ImageButton).Parent.Parent as GridDataItem;
        int seq = Convert.ToInt32(item.GetDataKeyValue("seq"));

        CurrentItems.Remove(CurrentItems.Where(c => c.Seq == seq).FirstOrDefault());
        CurrentItems = RefreshSeq(CurrentItems);
        rgSDet.DataSource = CurrentItems;
        rgSDet.DataBind();


    }
    protected void btnExit_Click(object sender, EventArgs e)
    {
        Response.Redirect("EduPassportTemplateManager.aspx");
    }
    protected void btnSAdd_Click(object sender, EventArgs e)
    {
        if(EduPassportItemSelect1.SelectedItems ==  null || EduPassportItemSelect1.SelectedItems.Count == 0)
        {
            ShowMessage("未選擇項目");
        }

        int times = 1;
        if(rntbAddTimes.Value.HasValue)
        {
            times = Convert.ToInt32(rntbAddTimes.Value.Value);
        }
        for (int i = 0; i < times; i++)
        {
            foreach (EduPassportItemDto item in EduPassportItemSelect1.SelectedItems)
            {
                EduPassportTemplateItemDto dto = new EduPassportTemplateItemDto();
                dto.ItemID = item.ItemID;
                dto.ItemName = item.ItemName;
                dto.Title = tbTitle.Text.Trim();

                dto.Seq = CurrentItems.Count + 1;
                CurrentItems.Add(dto);

            }
        }
        rgSDet.DataSource = CurrentItems;
        rgSDet.DataBind();

    }
    
    protected void btnSMoveUp_Click(object sender, EventArgs e)
    {
        if (rgSDet.SelectedItems.Count == 1)
        {
            GridDataItem item = rgSDet.SelectedItems[0] as GridDataItem;
            int seq = Convert.ToInt32(item.GetDataKeyValue("seq"));

            EduPassportTemplateItemDto moveitem = CurrentItems.Where(c => c.Seq == seq).FirstOrDefault();
            EduPassportTemplateItemDto preitem = CurrentItems.Where(c => c.Seq == seq - 1).FirstOrDefault();

            if (preitem != null)
            {

                if (moveitem != null)
                {
                    moveitem.Seq = moveitem.Seq - 1;
                }

                preitem.Seq = seq;

            }
            CurrentItems = CurrentItems.OrderBy(c => c.Seq).ToList();
            rgSDet.DataSource = CurrentItems;
            rgSDet.DataBind();
        }
    }
    protected void btnSMoveDown_Click(object sender, EventArgs e)
    {
        if (rgSDet.SelectedItems.Count == 1)
        {
            GridDataItem item = rgSDet.SelectedItems[0] as GridDataItem;
            int seq = Convert.ToInt32(item.GetDataKeyValue("seq"));

            EduPassportTemplateItemDto moveitem = CurrentItems.Where(c => c.Seq == seq).FirstOrDefault();
            EduPassportTemplateItemDto nextitem = CurrentItems.Where(c => c.Seq == seq + 1).FirstOrDefault();

            if (nextitem != null)
            {

                if (moveitem != null)
                {
                    moveitem.Seq = moveitem.Seq + 1;
                }

                nextitem.Seq = seq;

            }
            CurrentItems = CurrentItems.OrderBy(c => c.Seq).ToList();
            rgSDet.DataSource = CurrentItems;
            rgSDet.DataBind();
        }
    }
    
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if(CurrentTemplateID == null || IsCopyMode)
        {
            CurrentTemplate.Creater = this.EmpCode;
            CurrentTemplate.Createdate = DateTime.Now;
        }
        else
        {
            CurrentTemplate.Modifier = this.EmpCode;
            CurrentTemplate.Modifydate = DateTime.Now;
        }

        CurrentTemplate.TemplateDesc = reContent.Content;

        CurrentTemplate.Sdate = rdpSdate.SelectedDate;
        CurrentTemplate.Edate = rdpEdate.SelectedDate;
        CurrentTemplate.TemplateName = tbName.Text.Trim();
        CurrentTemplate.EduPassportTemplateTargets = new List<EduPassportTemplateTargetDto>();
        CurrentTemplate.AllowAdminConfirm = cbAllowAdminConfirm.Checked;
        if (rddtJobCode.SelectedValue != "")
        {
            foreach(string job in rddtJobCode.SelectedValue.Split(',').ToList())
            {
                EduPassportTemplateTargetDto dto = new EduPassportTemplateTargetDto();
                dto.TargetID = job;
                dto.TargetType = "job";
                CurrentTemplate.EduPassportTemplateTargets.Add(dto);
            }
        }

        foreach (RadComboBoxItem item in ddlUnit.CheckedItems)
        {
            EduPassportTemplateTargetDto dto = new EduPassportTemplateTargetDto();
            dto.TargetID = item.Value;
            dto.TargetType = "dept";
            CurrentTemplate.EduPassportTemplateTargets.Add(dto);
        }

        foreach(EduTermDto term in CurrentSendTerm)
        {
            EduPassportTemplateTargetDto dto = new EduPassportTemplateTargetDto();
            dto.TargetID = term.EduTermID;
            dto.TargetType = "eduterm";
            CurrentTemplate.EduPassportTemplateTargets.Add(dto);
        }


        List<EduPassportTemplateItemDto> detlist = new List<EduPassportTemplateItemDto>();
        detlist.AddRange(CurrentItems);



        CurrentTemplate.EduPassportTemplateItems = detlist;

        if (CurrentTemplateID == null || IsCopyMode)
        {
            CurrentTemplate.Status = "0";
            string msg = service.CreateEduPassportTemplate(CurrentTemplate);
            if(msg!=null)
            {
                ShowMessage("新增失敗:" + msg);

            }
            else
            {
                Response.Redirect("EduPassportTemplateManager.aspx");
            }
        }
        else
        {
            string msg = service.UpdateEduPassportTemplate(CurrentTemplate);
            if (msg != null)
            {
                ShowMessage("更新失敗:" + msg);

            }
            else
            {
                Response.Redirect("EduPassportTemplateManager.aspx");
            }
        }

    }
    protected void rddtJobCode_DataBound(object sender, EventArgs e)
    {
        if (CurrentTemplateID != null)
        {
            string selectedstr = "";
            foreach (EduPassportTemplateTargetDto target in CurrentTemplate.EduPassportTemplateTargets.Where(c => c.TargetType == "job"))
            {
                if (selectedstr != "")
                {
                    selectedstr += ",";
                }
                selectedstr += target.TargetID.ToString();
            }
            rddtJobCode.SelectedValue = selectedstr;
        }
    }

    protected void btnAddSendTerm_Click(object sender, ImageClickEventArgs e)
    {
        List<EduTermDto> list = CurrentSendTerm;

        foreach (EduTermDto selecteditem in EduTermSelect1.SelectedEduTerms)
        {
            if (CurrentSendTerm.Count(c => c.EduTermID == selecteditem.EduTermID) == 0)
            {
                EduTermDto setting = new EduTermDto();
                setting.EduTermID = selecteditem.EduTermID;
                setting.Name = selecteditem.Name;
                list.Add(setting);

                CurrentSendTerm = list;
                rgSendTerm.DataSource = CurrentSendTerm;
                rgSendTerm.DataBind();
            }
        }
    }
    protected void rgSendTerm_DeleteCommand(object sender, GridCommandEventArgs e)
    {
        string code = (e.Item as GridDataItem).GetDataKeyValue("EduTermID").ToString();

        for (int i = 0; i < CurrentSendTerm.Count; i++)
        {
            if (CurrentSendTerm[i].EduTermID == code)
            {
                CurrentSendTerm.RemoveAt(i);
                break;
            }
        }

        rgSendTerm.DataSource = CurrentSendTerm;
        rgSendTerm.DataBind();
    }
}