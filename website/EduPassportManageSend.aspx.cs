using KMU.EduActivity.ApplicationLayer.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class EduPassportManageSend : AuthPage
{
   

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            BindPassport();
        }
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





    protected void btnToImport_Click(object sender, EventArgs e)
    {
        Response.Redirect("EduPassportManageImport.aspx");
    }
    protected void btnToManage_Click(object sender, EventArgs e)
    {
        Response.Redirect("EduPassportManage.aspx");
    }
    protected void btnImport_Click(object sender, EventArgs e)
    {
        if(rcbTemplateID.SelectedValue == "" || rcbTemplateID.SelectedValue == null)
        {
            ShowMessage("未選擇護照");
            return;
        }

        if(VsSelector1.SelectedValue == "" || VsSelector1.SelectedValue == null)
        {
            ShowMessage("未選擇學員");
            return;
        }

        string msg = service.SendEduPassportInstance(VsSelector1.SelectedValue, rcbTemplateID.SelectedValue);
        if(msg!=null)
        {
            ShowMessage("發送失敗:" + msg);
        }
        else
        {
            ShowMessage("已送出");
        }
    }
}