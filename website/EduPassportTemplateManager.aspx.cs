using KMU.EduActivity.ApplicationLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class EduPassportTemplateManager : AuthPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            BindDeptment();
        }
    }
    private void BindDeptment()
    {
        List<SelectGroupTypeDto> list = service.GetTermUnit("EduAct_Dept");

        SelectGroupTypeDto dtoall = new SelectGroupTypeDto();
        dtoall.code = "";
        dtoall.name = "全部";
        list.Insert(0, dtoall);

        ddlUnit.DataValueField = "code";
        ddlUnit.DataTextField = "Name";
        ddlUnit.DataSource = list;
        ddlUnit.DataBind();

        ddlUnit.SelectedIndex = 0;
        
    }

    private void ReadData()
    {
        List<EduPassportTemplateDto> list = service.GetEduPassportTemplates(tbKeyWord.Text.Trim(), rddtJobCode.SelectedValue, ddlUnit.SelectedValue);
        rgList.DataSource = list;


    }

    protected void rgList_ItemCreated(object sender, Telerik.Web.UI.GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            string id = (e.Item as GridDataItem).GetDataKeyValue("TemplateID").ToString();
            HyperLink btnEdit = e.Item.FindControl("btnEdit") as HyperLink;
            if (btnEdit != null)
            {
                btnEdit.NavigateUrl = "EduPassportTemplateAdd.aspx?TemplateID=" + id;
            }

            HyperLink btnCopy = e.Item.FindControl("btnCopy") as HyperLink;
            if (btnCopy != null)
            {
                btnCopy.NavigateUrl = "EduPassportTemplateAdd.aspx?CopyTemplateID=" + id;
            }


            Button btnUpdateStatus = e.Item.FindControl("btnUpdateStatus") as Button;
            string status = (e.Item as GridDataItem).GetDataKeyValue("Status").ToString();

            switch(status)
            {
                case "0":
                    btnUpdateStatus.Text = "發佈";
                    break;
                case "V":
                    btnUpdateStatus.Text = "取消發佈";
                    break;
            }
        }
    }
    protected void btnQuery_Click(object sender, EventArgs e)
    {
        ReadData();
        rgList.DataBind();
    }
    protected void rgList_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        ReadData();
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("EduPassportTemplateAdd.aspx");
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        GridDataItem item = (sender as Button).Parent.Parent as GridDataItem;
        string id = item.GetDataKeyValue("TemplateID").ToString();

        service.DeleteEduPassportTemplate(id, this.EmpCode);
        ReadData();
        rgList.DataBind();
    }
    protected void btnUpdateStatus_Click(object sender, EventArgs e)
    {
        GridDataItem item = (sender as Button).Parent.Parent as GridDataItem;
        string id = item.GetDataKeyValue("TemplateID").ToString();



        Button btnUpdateStatus = item.FindControl("btnUpdateStatus") as Button;
        string status = item.GetDataKeyValue("Status").ToString();

        string msg = null;
        switch (status)
        {
            case "0":
                msg = service.UpdateEduPassportTemplateStatus(id, "V");
                break;
            case "V":
                msg = service.UpdateEduPassportTemplateStatus(id, "0");
                break;
        }

        if (msg == null)
        {
            ReadData();
            rgList.DataBind();
        }
        else
        {
            ShowMessage("更新失敗:" + msg);
        }
    }
}