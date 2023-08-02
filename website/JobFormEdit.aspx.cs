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

public partial class JobFormEdit : AuthPage
{
    private int CurrentSettingID
    {
        get
        {
            return Convert.ToInt32(Request.QueryString["SettingID"]);
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            dsJobCode.Select();
            BindTemplate();
            if (Request.QueryString["SettingID"] != null)
            {
                ReadData();
            }
        }
    }

    private void ReadData()
    {
        JobFormSettingDto data = service.GetJobFormSetting(CurrentSettingID);
        if (data != null)
        {
            TreeViewComboBox1.SelectedValue = data.JobCode;
            TreeViewComboBox1.SelectedText = data.JobName;
            cbTemplate.SelectedValue = data.TEMPLATE_ID.ToString();
        }
    }

    private void BindTemplate()
    {
        List<HtmlFormUtility.FORM_TEMPLATES> list = service.GetRootTemplateList(this.HospCode);
        cbTemplate.DataTextField = "TEMPLATE_NAME";
        cbTemplate.DataValueField = "TEMPLATE_ID";
        cbTemplate.DataSource = list;
        cbTemplate.DataBind();
    }

    private bool CheckInput()
    {
        if (TreeViewComboBox1.SelectedValue == null || TreeViewComboBox1.SelectedValue == "")
        {
            ShowMessage("未選擇 職稱");
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

        JobFormSettingDto dto = new JobFormSettingDto();
        dto.JobCode = TreeViewComboBox1.SelectedValue;
        dto.TEMPLATE_ID = Convert.ToInt32( cbTemplate.SelectedValue);
        if (Request.QueryString["SettingID"] == null)
        {
            service.InsertJobFormSetting(dto);
        }
        else
        {
            service.DeleteJobFormSetting(CurrentSettingID);
            service.InsertJobFormSetting(dto);
        }

        CloseWindow(true);
    }
}