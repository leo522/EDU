using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KMU.EduActivity.ApplicationLayer.DTO;
using Telerik.Web.UI;
using KMU.EduActivity.ApplicationLayer.Services;

public partial class EduTermCorchSetting : AuthPage
{
    private EduTermDto CurrentData
    {
        get
        {
            return Session["CurrentCorchSettingEduTerm"] as EduTermDto;
        }
        set
        {
            Session["CurrentCorchSettingEduTerm"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            if (Request.QueryString["EduTermID"] != null)
            {
                LoadEduTerm(Request.QueryString["EduTermID"].ToString());
            }
            else
            {
                ShowMessage("參數錯誤");
                CloseWindow(false);
            }
        }
    }

    private void ReadMembers()
    {
        List<EduTeamMemberRundownDto> list = service.GetEduTermMembersTeacher(CurrentData, "Coach");
        RadGrid1.MasterTableView.DataKeyNames = new string[] { "EduTermID", "MemberID" };
        RadGrid1.DataSource = list;
    }

    private void LoadEduTerm(string id)
    {
        try
        {
            CurrentData = service.GetEduTermByID(id);
            lblEduStopCode.Text = CurrentData.EduStopCode;
            lblName.Text = CurrentData.Name;
            lblDate.Text = CurrentData.DateFromToStr;
            lblMemberCount.Text = CurrentData.Capacity.ToString() + "人";
        }
        catch (Exception ex)
        {
            ShowMessage("資料錯誤:" + ex.Message);
            CloseWindow(true);
        }
    }
    protected void RadGrid1_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        ReadMembers();
    }
    protected void btnSet_Click(object sender, EventArgs e)
    {
        if (rcbVs.SelectedValue == "" || rcbVs.SelectedValue == null)
        {
            ShowMessage("未選擇指導老師");
            return;
        }
        List<string> ids = new List<string>();
        foreach (GridDataItem item in RadGrid1.SelectedItems)
        {
            ids.Add(item.GetDataKeyValue("MemberID").ToString());
        }

        if (!service.UpdateMemberRundownCoachID(ids, CurrentData.EduTermID, rcbVs.SelectedValue, "Coach",this.EmpCode))
        {
            ShowMessage("更新失敗");
        }
        else
        {
            ReadMembers();
            RadGrid1.DataBind();
        }

    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        List<string> ids = new List<string>();
        foreach (GridDataItem item in RadGrid1.SelectedItems)
        {
            ids.Add(item.GetDataKeyValue("MemberID").ToString());
        }

        if (!service.UpdateMemberRundownCoachID(ids, CurrentData.EduTermID, null, "Coach",this.EmpCode))
        {
            ShowMessage("更新失敗");
        }
        else
        {
            ReadMembers();
            RadGrid1.DataBind();
        }
    }

    protected void odsVs_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        e.InputParameters.Add("deptcode", CurrentData.DepCode);
    }
}