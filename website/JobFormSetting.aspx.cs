using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KMU.EduActivity.ApplicationLayer.DTO;
using Telerik.Web.UI;
using System.IO;
using System.Data.OleDb;
using System.Data;
using System.Data.OracleClient;
using NPOI.HSSF.UserModel;



public partial class JobFormSetting : AuthPage
{
    private List<JobFormSettingDto> CurrentList
    {
        get
        {
            return ViewState["JobFormSettingDtoList"] as List<JobFormSettingDto>;
        }
        set
        {
            ViewState["JobFormSettingDtoList"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //BindTemplate();
        }

    }

    private void BindTemplate()
    {
        List<HtmlFormUtility.FORM_TEMPLATES> list = service.GetRootTemplateList(this.HospCode);
        
        cblTemplate.DataTextField = "TEMPLATE_NAME";
        cblTemplate.DataValueField = "TEMPLATE_ID";
        cblTemplate.DataSource = list;
        cblTemplate.DataBind();
    }

    private void ReadData()
    {
        BindTemplate();
        List<JobFormSettingDto> list = service.GetJobFormSettings(TreeViewComboBox2.SelectedValue);
        foreach (ListItem item in cblTemplate.Items)
        {
            if (list.Count(c => c.TEMPLATE_ID.ToString() == item.Value) == 0)
            {
                item.Selected = false;
            }
            else
            {
                item.Selected = true;
            }
        }
        
        CurrentList = list;
    }
    

    protected void btnQuery_Click(object sender, EventArgs e)
    {
        if (TreeViewComboBox2.SelectedValue == null || TreeViewComboBox2.SelectedValue == "")
        {
            ShowMessage("未選擇職稱");
            return;
        }
        ReadData();
    }


    protected void dsJobCode_Selected(object sender, ObjectDataSourceStatusEventArgs e)
    {

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (TreeViewComboBox2.SelectedValue == null || TreeViewComboBox2.SelectedValue == "")
        {
            ShowMessage("未選擇職稱");
            return;
        }
        List<int> alltemps = new List<int>();
        List<int> temps = new List<int>();
        foreach (ListItem item in cblTemplate.Items)
        {
            alltemps.Add(Convert.ToInt32(item.Value));
            if (item.Selected)
            {
                temps.Add(Convert.ToInt32(item.Value));
            }
        }
        service.SaveJobFormSetting(TreeViewComboBox2.SelectedValue, temps, alltemps);
    }
}