using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KMU.EduActivity.ApplicationLayer.DTO;
using Telerik.Web.UI;
using KMU.EduActivity.ApplicationLayer.Services;

public partial class EduTermTeacherSetting : AuthPage
{
    private EduTermDto CurrentData
    {
        get
        {
            return Session["CurrentTermTeacherSettingEduTerm"] as EduTermDto;
        }
        set
        {
            Session["CurrentTermTeacherSettingEduTerm"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            if (Request.QueryString["EduTermID"] != null)
            {
                BindTeacherType();
                LoadEduTerm(Request.QueryString["EduTermID"].ToString());
            }
            else
            {
                ShowMessage("參數錯誤");
                CloseWindow(false);
            }
        }
    }

    private void BindTeacherType()
    {
        List<EduTeacherTypeDto> list = service.GetTeacherTypes();
        rcbTeacherType.DataValueField = "code";
        rcbTeacherType.DataTextField = "name";
        rcbTeacherType.DataSource = list;
        rcbTeacherType.DataBind();
        rcbTeacherType.SelectedIndex = 0;
    }

    private void ReadMembers()
    {
        EduRefTeacherDto dto = service.GetTermTeacher(CurrentData.EduTermID, rcbTeacherType.SelectedValue);
        if (dto != null)
        {
            rcbVs.SelectedValue = dto.TeacherID;
        }
        else
        {
            rcbVs.SelectedValue = null;
        }
        
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

    protected void btnSet_Click(object sender, EventArgs e)
    {
        if (rcbVs.SelectedValue == "" || rcbVs.SelectedValue == null)
        {
            ShowMessage("未選擇指導老師");
            return;
        }

        if (!service.UpdateTermTeacher(CurrentData.EduTermID, rcbTeacherType.SelectedValue, rcbVs.SelectedValue, this.EmpCode))
        {
            ShowMessage("更新失敗");
        }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        if (!service.UpdateTermTeacher(CurrentData.EduTermID, rcbTeacherType.SelectedValue, null, this.EmpCode))
        {
            ShowMessage("更新失敗");
        }
    }

    protected void rcbTeacherType_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ReadMembers();
    }
    protected void odsVs_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        e.InputParameters.Add("deptcode", null);
    }
}