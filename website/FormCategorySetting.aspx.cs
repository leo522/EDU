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



public partial class FormCategorySetting : AuthPage
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
            BindTemplate();
            rgCategory.DataBind();
        }

    }

    private void BindTemplate()
    {
        List<HtmlFormUtility.FORM_TEMPLATES> list = service.GetRootTemplateList(this.HospCode).Where(c => c.ENABLED).OrderBy(c => c.TEMPLATE_NAME).ToList();

        rcbTemplateID.DataTextField = "TEMPLATE_NAME";
        rcbTemplateID.DataValueField = "TEMPLATE_ID";
        rcbTemplateID.DataSource = list;
        rcbTemplateID.DataBind();
    }

    private void ReadData()
    {
        if (rcbTemplateID.SelectedValue == null || rcbTemplateID.SelectedValue == "")
        {
            ShowMessage("未選擇樣板");
            return;
        }
        List<FormCategoryDto> list = service.GetFormCategoryList(Convert.ToInt32(rcbTemplateID.SelectedValue));


        cblCategory.DataTextField = "CategoryName";
        cblCategory.DataValueField = "ID";
        cblCategory.DataSource = list;
        cblCategory.DataBind();

        foreach (ListItem item in cblCategory.Items)
        {
            if (list.Where(c => c.ID.ToString() == item.Value).FirstOrDefault().IsRel)
            {
                item.Selected = true;
            }
            else
            {
                item.Selected = false;
            }
        }

    }

    private void ReadCategoryData()
    {
        List<FormCategoryDto> list = service.GetFormCategory();

        rgCategory.DataSource = list;

    }
    

    protected void btnQuery_Click(object sender, EventArgs e)
    {
        ReadData();
    }


    protected void dsJobCode_Selected(object sender, ObjectDataSourceStatusEventArgs e)
    {

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (rcbTemplateID.SelectedValue == null || rcbTemplateID.SelectedValue == "")
        {
            ShowMessage("未選擇樣板");
            return;
        }
        List<int> temps = new List<int>();
        foreach (ListItem item in cblCategory.Items)
        {
            if (item.Selected)
            {
                temps.Add(Convert.ToInt32(item.Value));
            }
        }
        service.SaveFormCategoryRef(Convert.ToInt32(rcbTemplateID.SelectedValue), temps);

    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if(tbAddCategory.Text.Trim() == "")
        {
            ShowMessage("未輸入類別名稱");
            return;
        }

        string result = service.AddFormCategory(tbAddCategory.Text.Trim(), this.EmpCode);
        if (result != null)
        {
            ShowMessage(result);
            return;
        }
        ReadCategoryData();
        rgCategory.DataBind();

    }
    protected void rgCategory_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        ReadCategoryData();
    }
    protected void rgCategory_DeleteCommand(object sender, GridCommandEventArgs e)
    {
        if (e.CommandName == RadGrid.DeleteCommandName)
        {
            int id = Convert.ToInt32((e.Item as GridDataItem).GetDataKeyValue("ID"));
            

            string msg = service.DeleteFormCategory(id);

            if(msg == null)
            {
                rgCategory.DataBind();
            }
            else
            {
                ShowMessage("刪除失敗:" + msg);
            }
        }
    }
    protected void rgCategory_UpdateCommand(object sender, GridCommandEventArgs e)
    {
        if (e.CommandName == RadGrid.UpdateCommandName)
        {
            GridEditableItem editedItem = e.Item as GridEditableItem;
            int id = Convert.ToInt32(editedItem.GetDataKeyValue("ID"));

            string name = (editedItem["CategoryName"].Controls[0] as TextBox).Text;
            string msg = service.UpdateFormCategory(id, name);

            if (msg == null)
            {
                rgCategory.DataBind();
            }
            else
            {
                ShowMessage("修改失敗:" + msg);
            }
        }
    }

}