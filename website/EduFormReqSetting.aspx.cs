using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using KMU.EduActivity.ApplicationLayer.DTO;
using KMU.EduActivity.DomainModel.Entities;

public partial class EduFormReqSetting : AuthPage
{
    private HtmlFormUtility.Components.ViewComponent vc = new HtmlFormUtility.Components.ViewComponent();

    private List<EduTermFormReqDto> CurrentSetting
    {
        get
        {
            List<EduTermFormReqDto> sett = ViewState["currnetsetting"] as List<EduTermFormReqDto>;
            if(sett == null)
            {
                sett = new List<EduTermFormReqDto>();
            }
            return sett;
        }
        set
        {
            ViewState["currnetsetting"] = value;
        }
    }

    private string EduTermID
    {
        get
        {
            if (Request.QueryString["EduTermID"] == null)
            {
                return "20131011000000000032";
            }
            else
            {
                return Request.QueryString["EduTermID"];
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ReadReqType();
            ReadCurrentSetting();
            RadGrid1.DataBind();
        }

    }

    private void ReadCurrentSetting()
    {
        var sett = service.GetEduTermFromReq(EduTermID);
        CurrentSetting = sett;
        
    }

    private void ReadReqType()
    {
        var reqtype = service.GetEduTermFormReqType();
        reqtype.Add(new V_CodeRefDto() { Code = "template", Name = "樣版" });
        rblReqType.DataValueField = "Code";
        rblReqType.DataTextField = "Name";
        rblReqType.DataSource = reqtype;

        rblReqType.DataBind();
    }

    private void RefreshReqItem(string reqtype)
    {
        rcbItem.Text = null;
        switch(reqtype)
        {
            case "Form":
                
                var list_form = service.GetRootTemplates(this.HospCode);
                rcbItem.DataValueField = "TEMPLATE_ID";
                rcbItem.DataTextField = "TEMPLATE_NAME";
                rcbItem.DataSource = list_form;
                rcbItem.DataBind();
                panAdd.Visible = true;
                btnSet.Visible = false;
                break;
            case "Category":
                var list_cate = service.GetFormCategory();
                rcbItem.DataValueField = "ID";
                rcbItem.DataTextField = "CategoryName";
                rcbItem.DataSource = list_cate;
                rcbItem.DataBind();
                panAdd.Visible = true;
                btnSet.Visible = false;

                break;
            case "template":
                var list_template = service.GetFormReqTemplates(this.EmpCode);
                rcbItem.DataValueField = "TemplateID";
                rcbItem.DataTextField = "TemplateName";
                rcbItem.DataSource = list_template;
                rcbItem.DataBind();
                panAdd.Visible = false;
                btnSet.Visible = true;
                break;
            default:
                rcbItem.DataSource = null;
                rcbItem.DataBind();
                panAdd.Visible = false;
                btnSet.Visible = false;
                break;
        }
    }

    protected void rblReqType_SelectedIndexChanged(object sender, EventArgs e)
    {
        RefreshReqItem(rblReqType.SelectedValue);
    }
    protected void RadGrid1_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        RadGrid1.DataSource = CurrentSetting;
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        CloseWindow(false);
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        
        
        if(rcbItem.SelectedValue == null)
        {
            ShowMessage("請選擇需求項目");
            return;
        }

        if(rntbReqCount.Value == null)
        {
            ShowMessage("請設定需完成次數");
            return;
        }

        int reqid = Convert.ToInt32(rcbItem.SelectedValue);
        if (CurrentSetting.Count(c => c.ReqID == reqid && c.ReqType == rblReqType.SelectedValue) > 0)
        {
            ShowMessage("選擇的需求項目已經存在");
            return;
        }

        EduTermFormReqDto newitem = new EduTermFormReqDto();
        newitem.CreateDate = DateTime.Now;
        newitem.Creater = this.EmpCode;
        newitem.EduTermID = EduTermID;
        newitem.NeedPass = cbNeedPass.Checked;
        newitem.ReqCount = Convert.ToInt32(rntbReqCount.Value);
        newitem.ReqID = reqid;
        newitem.ReqName = rcbItem.Text;
        newitem.ReqType = rblReqType.SelectedValue;
        newitem.ReqTypeName = rblReqType.SelectedItem.Text;
        var slist = CurrentSetting;
        slist.Add(newitem);
        CurrentSetting = slist;
        RadGrid1.DataSource = CurrentSetting;
        RadGrid1.DataBind();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (cbSaveTemplate.Checked)
        {
            if (tbTemplateName.Text.Trim() == "")
            {
                ShowMessage("請設定樣版名稱");
                return;
            }

            if (!service.CheckTemplateName(tbTemplateName.Text.Trim(), this.EmpCode))
            {
                ShowMessage("樣版名稱已存在");
                return;
            }
        }

        List<EduTermFormReqDto> list = CurrentSetting;

        foreach (var item in list)
        {
            item.Creater = this.EmpCode;
            item.CreateDate = DateTime.Now;
            item.EduTermID = EduTermID;
        }


        var result = service.CreateEduTermFormReq(EduTermID, list, cbSaveTemplate.Checked ? tbTemplateName.Text : null);
        if (result.Success)
        {
            CloseWindow(false);
        }
        else
        {
            ShowMessage("儲存失敗:" + result.Message);
            return;
        }
    }
    protected void btnSet_Click(object sender, EventArgs e)
    {
        if (rcbItem.SelectedValue == null)
        {
            ShowMessage("請選擇樣版");
            return;
        }

        var templatelist = service.GetEduTermFromReqTemplateDet(Convert.ToInt32(rcbItem.SelectedValue));

        var slist = CurrentSetting;

        slist = new List<EduTermFormReqDto>();

        foreach(var itm in templatelist)
        {
            EduTermFormReqDto newitem = new EduTermFormReqDto();
            newitem.CreateDate = DateTime.Now;
            newitem.Creater = this.EmpCode;
            newitem.EduTermID = EduTermID;
            newitem.NeedPass = itm.NeedPass;
            newitem.ReqCount = itm.ReqCount;
            newitem.ReqID = itm.ReqID;
            newitem.ReqName = itm.ReqName;
            newitem.ReqType = itm.ReqType;
            newitem.ReqTypeName = itm.ReqTypeName;
            slist.Add(newitem);
        }
        CurrentSetting = slist;
        RadGrid1.DataSource = CurrentSetting;
        RadGrid1.DataBind();


    }
    protected void RadGrid1_DeleteCommand(object sender, GridCommandEventArgs e)
    {
        var item = e.Item as GridDataItem;
        string reqtype = item.GetDataKeyValue("ReqType").ToString();
        int reqid = Convert.ToInt32(item.GetDataKeyValue("ReqID").ToString());

        var slist = CurrentSetting;
        var delitem = slist.Where(c => c.ReqType == reqtype && c.ReqID == reqid).FirstOrDefault();
        slist.Remove(delitem);
        CurrentSetting = slist;


    }
}