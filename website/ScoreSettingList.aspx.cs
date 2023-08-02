using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KMU.EduActivity.ApplicationLayer.DTO;
using Telerik.Web.UI;

public partial class ScoreSettingList : AuthPage
{
    private List<ScoreSettingDto> CurrentList
    {
        get
        {
            return ViewState["CurrentList"] as List<ScoreSettingDto>;
        }
        set
        {
            ViewState["CurrentList"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDept();
        }
    }


    private void BindDept()
    {
        List<SelectGroupTypeDto> list = service.GetTermUnit("EduAct_Dept");

        if (!this.AuthRoles.Contains("Admin"))
        {
            list = list.Where(c => this.DeptSecDep.Contains(c.code)).ToList();
        }

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
        List<ScoreSettingDto> list = service.GetScoreSettings(ddlUnit.SelectedValue, tvcbJob.SelectedValue);
        CurrentList = list;
        rgList.DataSource = CurrentList;
    }


    protected void btnQuery_Click(object sender, EventArgs e)
    {
        ReadData();
        rgList.DataBind();
    }
    protected void rgList_ItemCreated(object sender, Telerik.Web.UI.GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            string id = (e.Item as GridDataItem).GetDataKeyValue("SettingID").ToString();
            HyperLink btnEdit = e.Item.FindControl("btnEdit") as HyperLink;
            if (btnEdit != null)
            {
                btnEdit.NavigateUrl = "ScoreSettingAdd.aspx?ID=" + id;
            }

            HyperLink btnCreateScore = e.Item.FindControl("btnCreateScore") as HyperLink;
            if (btnCreateScore != null)
            {
                btnCreateScore.NavigateUrl = "ScoreCreateList.aspx?ID=" + id;
            }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("ScoreSettingAdd.aspx");
    }
}