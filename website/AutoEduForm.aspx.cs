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



public partial class AutoEduForm : AuthPage
{
    private List<AutoEduFormTemplateListDto> CurrentList
    {
        get
        {
            return ViewState["AutoEduFormTemplateListDtoList"] as List<AutoEduFormTemplateListDto>;
        }
        set
        {
            ViewState["AutoEduFormTemplateListDtoList"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //RadGrid1.DataSource = new List<AutoEduFormTemplateListDto>();
            //RadGrid1.DataBind();
            BindDept();
        }

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

    private void ReadData()
    {
        RadGrid1.DataSource = null;
        RadGrid1.MasterTableView.DataKeyNames = new string[] { "AutoFTListID" };
        List<string> jobcodes = new List<string>();
        foreach(var item in TreeViewComboBox2.TreeView.CheckedNodes)
        {
            jobcodes.Add(item.Value);
        }


        //List<AutoEduFormTemplateListDto> list = service.GetAutoEduFormTemplateLists(TreeViewComboBox2.SelectedValue);
        List<AutoEduFormTemplateListDto> list = service.GetAutoEduFormTemplateList(jobcodes, ddlUnit.SelectedValue, cbEnable.Checked, this.HospCode);
        CurrentList = list;
        RadGrid1.DataSource = list;
    }
    protected void RadGrid1_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        //if (IsPostBack)
        //{
            ReadData();
        //}
    }

    protected void RadGrid1_DeleteCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
    {
        if (e.CommandName != RadGrid.DeleteSelectedCommandName)
        {
            GridDataItem item = e.Item as GridDataItem;
            string id = null;
            if (item.GetDataKeyValue("AutoFTListID") != null)
            {
                id = item.GetDataKeyValue("AutoFTListID").ToString();
            }

            service.DeleteAutoEduFormSetting(id);
        }
    }

    protected void btnQuery_Click(object sender, EventArgs e)
    {
        ReadData();
        RadGrid1.DataBind();
    }

    protected void RadGrid1_ItemCommand(object sender, GridCommandEventArgs e)
    {
        if (e.CommandName == RadGrid.DeleteSelectedCommandName)
        {
            foreach (GridDataItem item in RadGrid1.SelectedItems)
            {

                string id = null;
                if (item.GetDataKeyValue("AutoFTListID") != null)
                {
                    id = item.GetDataKeyValue("AutoFTListID").ToString();
                }

                service.DeleteAutoEduFormSetting(id);
            }
        }
    }

    protected void RadGrid1_ItemCreated(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            GridDataItem item = e.Item as GridDataItem;
            string id = null;
            if (item.GetDataKeyValue("AutoFTListID") != null)
            {
                id = item.GetDataKeyValue("AutoFTListID").ToString();
            }

            if (id != null)
            {
                LinkButton lbtnEditTerm = e.Item.FindControl("lbtnEditSetting") as LinkButton;
                if (lbtnEditTerm != null)
                {
                    lbtnEditTerm.OnClientClick = "openEditFormSettingWin('" + id + "');return false;";
                }
                
            }
        }
    }

    protected void dsJobCode_Selected(object sender, ObjectDataSourceStatusEventArgs e)
    {
        Session["CurrentJobCode"] = e.ReturnValue as List<V_CodeRefDto>;
    }
}