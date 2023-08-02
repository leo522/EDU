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

public partial class EduTermMemberSetting : AuthPage
{
    System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();//引用stopwatch物件

    private List<EduTeamDto> CurrentSelectTeam
    {
        get
        {
            return ViewState["CurrentSelectTeam"] as List<EduTeamDto>;
        }
        set
        {
            ViewState["CurrentSelectTeam"] = value;
        }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        //AddPostbackControl(RadGrid1);
        if (!IsPostBack)
        {
            if (DateTime.Now.Month >= 6)
            {
                tbEduYear.Text = (DateTime.Now.Year - 1911).ToString("000");
            }
            else
            {
                tbEduYear.Text = (DateTime.Now.Year - 1911 - 1).ToString("000");
            }
            
            BindDept();
            if (!new string[] { "7102", "7101", "7100" }.Contains(DeptCode))
            {
                ddlUnit.SelectedValue = this.DeptCode;
                cbSelf.Checked = false;
            }
            else
            {
                ddlUnit.SelectedValue = null;
                cbSelf.Checked = true;
            }

        }
        lblMsg.Text = "";
    }


    private void ReadData()
    {
        List<EduTermDto> list = service.FindEduTerms(tbEduStopCode.Text == "" ? null : tbEduStopCode.Text,
            tbName.Text == "" ? null : tbName.Text,
            rdpDateBegin.SelectedDate,
            rdpDateEnd.SelectedDate,
            cbSelf.Checked ? this.EmpCode : null,
            ddlUnit.SelectedValue,
            tbEduYear.Text,
            TreeViewComboBox1.SelectedValue);

        RadGrid1.DataSource = list;


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

    protected void RadGrid1_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        //ReadData();
    }


    protected void btnQuery_Click(object sender, EventArgs e)
    {
        if (TreeViewComboBox1.SelectedValue == null || TreeViewComboBox1.SelectedValue == "")
        {
            ShowMessage("請選擇職稱");
            return;
        }
        if (rdpDateBegin.SelectedDate == null || rdpDateEnd.SelectedDate == null)
        {
            ShowMessage("請選擇時間範圍");
            return;
        }

        ReadData();

        List<EduTeamDto> teamlist = service.GetEduTeamsByJobCode(TreeViewComboBox1.SelectedValue);
        EduTeamDto emptydto = new EduTeamDto();
        emptydto.EduTeamCode = "";
        emptydto.EduTeamName = "--";
        teamlist.Insert(0, emptydto);

        CurrentSelectTeam = teamlist;
        RadGrid1.DataBind();

        

    }

    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        Dictionary<string, string> updatelist = new Dictionary<string, string>();
        foreach (GridDataItem item in RadGrid1.Items)
        {
            RadDropDownTree RadDropDownTree1 = item.FindControl("RadDropDownTree1") as RadDropDownTree;
            string id = item.GetDataKeyValue("EduTermID").ToString();
            if(RadDropDownTree1.SelectedValue!="" && RadDropDownTree1.SelectedValue !=null)
            {
                updatelist.Add(id, RadDropDownTree1.SelectedValue);
            }
        }

        string result = service.UpdateEduTeamMember(updatelist);
        if (result != null)
        {
            ShowMessage("更新失敗:" + result);
        }
        else
        {
            ShowMessageAndGo("更新完成", "EduTermMemberSetting.aspx");
        }
    }
    protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            RadDropDownTree RadDropDownTree1 = e.Item.FindControl("RadDropDownTree1") as RadDropDownTree;
            if (RadDropDownTree1.DataSource == null)
            {
                RadDropDownTree1.DataSource = CurrentSelectTeam;
                RadDropDownTree1.DataBind();
            }
        }
    }

}