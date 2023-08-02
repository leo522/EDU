using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HtmlAgilityPack;
using KMU.EduActivity.ApplicationLayer.DTO;
using Telerik.Web.UI;

public partial class ScoreSettingAdd : AuthPage
{
    private HtmlFormUtility.Components.ViewComponent vc = new HtmlFormUtility.Components.ViewComponent();

    private ScoreSettingDto CurrentSetting
    {
        get
        {
            return ViewState["CurrentSetting"] as ScoreSettingDto;
        }
        set
        {
            ViewState["CurrentSetting"] = value;
        }
    }

    private List<ScoreSettingJobDto> CurrentSettingJob
    {
        get
        {
            return (ViewState["CurrentSetting"] as ScoreSettingDto).ScoreSettingJobs as List<ScoreSettingJobDto>;
        }
        set
        {
            (ViewState["CurrentSetting"] as ScoreSettingDto).ScoreSettingJobs = value;
        }
    }

    private List<ScoreSettingDetailDto> CurrentSettingDetail
    {
        get
        {
            return (ViewState["CurrentSetting"] as ScoreSettingDto).ScoreSettingDetails as List<ScoreSettingDetailDto>;
        }
        set
        {
            (ViewState["CurrentSetting"] as ScoreSettingDto).ScoreSettingDetails = value;
        }
    }

    private List<ScoreSettingDetailDto> CurrentSettingDetail0
    {
        get
        {
            return CurrentSettingDetail.Where(c => c.ScoreType == "臨床科分數").ToList();
        }
    }
    private List<ScoreSettingDetailDto> CurrentSettingDetail1
    {
        get
        {
            return CurrentSettingDetail.Where(c => c.ScoreType == "臨教部分數").ToList();
        }
    }



    private string CurrentSettingID
    {
        get
        {
            return Request.QueryString["ID"];
        }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDept();
            BindTemplate();
            if (Request.QueryString["ID"] == null)
            {
                CurrentSetting = new ScoreSettingDto();
                CurrentSettingDetail = new List<ScoreSettingDetailDto>();
                CurrentSettingJob = new List<ScoreSettingJobDto>();
            }
            else
            {
                ReadData();
            }

            rgJob.DataSource = CurrentSettingJob;
            rgJob.DataBind();
            rgFeilds.DataSource = CurrentSettingDetail0;
            rgFeilds.DataBind();
            rgFeilds2.DataSource = CurrentSettingDetail1;
            rgFeilds2.DataBind();
        }
    }

    private void ReadData()
    {
        CurrentSetting = service.GetScoreSetting(CurrentSettingID);
        if (CurrentSetting == null)
        {
            ShowMessageAndGo("資料錯誤，請重試", "ScoreSettingList.aspx");
        }

        tbSettingName.Text = CurrentSetting.SettingName;
        ddlUnit.SelectedValue = CurrentSetting.DeptCode;
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
    private void BindTemplate()
    {
        List<FORM_TEMPLATEDto> list = service.GetTemplates(this.HospCode);

        FORM_TEMPLATEDto nulldto = new FORM_TEMPLATEDto();
        nulldto.TEMPLATE_ID = -1;
        nulldto.TEMPLATE_NAME = "請選擇表單";

        list.Insert(0, nulldto);

        rcbTemplateID.DataValueField = "TEMPLATE_ID";
        rcbTemplateID.DataTextField = "TEMPLATE_NAME";
        rcbTemplateID.DataSource = list;
        rcbTemplateID.DataBind();
    }
    protected void lbtnPostBack_Click(object sender, EventArgs e)
    {
        HtmlFormUtility.FORM_TEMPLATE_ELEMENTS element = vc.SelectFormTemplateElementByID(Convert.ToInt32( rcbTemplateID.SelectedValue), HiddenID.Value);
        if (element != null)
        {
            lbSelectedFormElement.Text = element.ID;
        }
        else
        {
            lbSelectedFormElement.Text = "";
        }
    }
    protected void rcbTemplateID_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        lbSelectedFormElement.Text = "";
        HiddenID.Value = "";
        if (rcbTemplateID.SelectedValue != "" && rcbTemplateID.SelectedValue != null)
        {
            tbValueName.Text = rcbTemplateID.Text;
            HtmlFormUtility.Components.HtmlForm htmlform = new HtmlFormUtility.Components.HtmlForm();
            htmlform.Create(Convert.ToInt32(rcbTemplateID.SelectedValue), true);

            HtmlNodeCollection coll = HtmlUtility.GetAllNodes(htmlform.InstanceDocument);

            if (coll != null)
            {
                foreach (HtmlNode node in coll)
                {
                    string l_type = "";
                    if (node.Attributes.Contains("type"))
                    {
                        l_type = node.Attributes["type"].Value;
                    }
                    else
                    {
                        l_type = node.OriginalName;
                    }

                    node.Attributes.Add("onClick", "ElementClick('" + lbtnPostBack.ClientID + "','" + node.Attributes["id"].Value + "','" + HiddenID.ClientID + "',false);" +
                    "ElementClick('" + lbtnPostBack.ClientID + "','" + node.Attributes["name"].Value + "','" + HiddenName.ClientID + "',false);" +
                    "ElementClick('" + lbtnPostBack.ClientID + "','" + (node.Attributes["displayname"] == null ? "" : node.Attributes["displayname"].Value) + "','" + HiddenDisplayname.ClientID + "',false);" +
                    "ElementClick('" + lbtnPostBack.ClientID + "','" + l_type + "','" + HiddenType.ClientID + "',true);" +
                    "return false;");
                }
            }
            htmlContent.InnerHtml = htmlform.InstanceDocument.DocumentNode.InnerHtml;
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("ScoreSettingList.aspx");
    }
    protected void btnAddJobCode_Click(object sender, ImageClickEventArgs e)
    {
        if (tvcbJobs.SelectedValue == "" || tvcbJobs.SelectedValue == null)
        {
            ShowMessage("未選擇職稱");
            return;
        }
        ScoreSettingJobDto dto = new ScoreSettingJobDto();
        dto.JobCode = tvcbJobs.SelectedValue;
        dto.JobName = tvcbJobs.SelectedText;
        dto.SettingID = CurrentSettingID;
        CurrentSettingJob.Add(dto);
        rgJob.DataSource = CurrentSettingJob;
        rgJob.DataBind();
    }

    protected void rgJob_DeleteCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
    {
        CurrentSettingJob.RemoveAt(e.Item.DataSetIndex);
        rgJob.DataSource = CurrentSettingJob;
        rgJob.DataBind();
    }
    protected void rgFeilds_DeleteCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
    {
        string valuetype = (e.Item as GridDataItem).GetDataKeyValue("ValueType").ToString();
        string valueid = (e.Item as GridDataItem).GetDataKeyValue("ValueID").ToString();
        string valueparameter = (e.Item as GridDataItem).GetDataKeyValue("ValueParameter").ToString();

        CurrentSettingDetail.Remove(CurrentSettingDetail.Where(c => c.ValueType == valuetype && c.ValueID == valueid && c.ValueParameter == valueparameter).FirstOrDefault());

        //CurrentSettingDetail.RemoveAt(e.Item.DataSetIndex);
        rgFeilds.DataSource = CurrentSettingDetail0;
        rgFeilds.DataBind();

        rgFeilds2.DataSource = CurrentSettingDetail1;
        rgFeilds2.DataBind();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (tbSettingName.Text.Trim() == "")
        {
            ShowMessage("未輸入設定名稱");
            return;
        }
        if (ddlUnit.SelectedValue == "" || ddlUnit.SelectedValue == null)
        {
            ShowMessage("未選擇部門");
            return;
        }
        if(rntbPercent0.Value == null)
        {
            ShowMessage("未輸入臨床科分數佔比");
            return;            
        }
        if (rntbPercent1.Value == null)
        {
            ShowMessage("未輸入臨教部分數佔比");
            return;
        }
        if (rntbPercent0.Value.Value + rntbPercent1.Value.Value != 100)
        {
            ShowMessage("臨床科與臨教部分數佔比總和未達100");
            return;
        }


        if (CurrentSettingID == null)
        {
            CurrentSetting.CreateDate = DateTime.Now;
            CurrentSetting.Creater = this.EmpCode;
        }
        else
        {
            CurrentSetting.Modifier = this.EmpCode;
            CurrentSetting.ModifyDate = DateTime.Now;
        }
        List<ScoreSettingScoreTypeDto> typelist = new List<ScoreSettingScoreTypeDto>();
        ScoreSettingScoreTypeDto type1 = new ScoreSettingScoreTypeDto();
        type1.TypeName = "臨床科分數";
        type1.TypePercent = Convert.ToDecimal(rntbPercent0.Value);
        typelist.Add(type1);
        ScoreSettingScoreTypeDto type2 = new ScoreSettingScoreTypeDto();
        type2.TypeName = "臨教部分數";
        type2.TypePercent = Convert.ToDecimal(rntbPercent1.Value);
        typelist.Add(type2);

        CurrentSetting.ScoreSettingScoreTypes = typelist;
        CurrentSetting.DeptCode = ddlUnit.SelectedValue;
        CurrentSetting.SettingName = tbSettingName.Text;
        CurrentSetting.ScoreSettingDetails = CurrentSettingDetail;
        CurrentSetting.ScoreSettingJobs = CurrentSettingJob;


        string msg = null;
        if (CurrentSettingID == null)
        {
            msg = service.InsertScoreSetting(CurrentSetting);
        }
        else
        {
            msg = service.UpdateScoreSetting(CurrentSetting);

        }
        if (msg == null)
        {
            Response.Redirect("ScoreSettingList.aspx");
        }
        else
        {
            ShowMessage(msg);
        }

    }
    protected void btnAdd0_Click(object sender, EventArgs e)
    {
        ScoreSettingDetailDto dto = new ScoreSettingDetailDto();
        if (tbValueName.Text.Trim() == "")
        {
            ShowMessage("未輸入項目名稱");
            return;
        }

        if (rntbPercent.Value == null)
        {
            ShowMessage("未輸入分數比例");
            return;
        }

        if (RadMultiPage1.SelectedPageView == rpvForm)
        {
            if (rcbTemplateID.SelectedValue == "" || rcbTemplateID.SelectedValue == null)
            {
                ShowMessage("未選擇表單");
                return;
            }

            if (HiddenID.Value == null || HiddenID.Value == "")
            {
                ShowMessage("未選擇表單欄位");
                return;
            }

            dto.ValueID = rcbTemplateID.SelectedValue;
            dto.ValueIdName = rcbTemplateID.Text;
            dto.ValueParameter = HiddenID.Value;
            dto.ValueType = "表單";

        }

        if (RadMultiPage1.SelectedPageView == rpvUserDefine)
        {
            dto.ValueID = tbValueName.Text;
            dto.ValueIdName = tbValueName.Text;
            dto.ValueParameter = "";
            dto.ValueType = "自訂分數";
        }

        dto.ScorePercent = Convert.ToDecimal(rntbPercent.Value);
        dto.ValueName = tbValueName.Text;
        dto.SettingID = CurrentSettingID;
        
        
        if(sender == btnAdd0)
        {
            dto.ScoreType = "臨床科分數";
        }

        if (sender == btnAdd1)
        {
            dto.ScoreType = "臨教部分數";
        }

        if (CurrentSettingDetail.Count(c => c.ValueID == dto.ValueID && c.ValueType == dto.ValueType && c.ValueParameter == dto.ValueParameter) > 0)
        {
            ShowMessage("該項設定已存在");
            return;
        }

        CurrentSettingDetail.Add(dto);
        rgFeilds.DataSource = CurrentSettingDetail0;
        rgFeilds.DataBind();

        rgFeilds2.DataSource = CurrentSettingDetail1;
        rgFeilds2.DataBind();
        
    }
}