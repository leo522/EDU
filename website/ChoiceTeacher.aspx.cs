using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KMU.EduActivity.ApplicationLayer.DTO;
using Telerik.Web.UI;

public partial class ChoiceTeacher : AuthPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["instance_id"] == null)
            {
                ShowMessageAndGoBack("參數傳遞錯誤");
                return;
            }

            if (Request.QueryString["edutermid"] == null)
            {
                ShowMessageAndGoBack("參數傳遞錯誤");
                return;
            }

            BindDept();
            EduTermDto term = service.GetEduTermByID(Request.QueryString["edutermid"]);
            if (term != null)
            {
                ddlUnit.SelectedValue = term.Department;
            }
        }

    }


    private void BindDept()
    {
        List<SelectGroupTypeDto> list = service.GetTermUnit("EduAct_Dept");
        ddlUnit.DataValueField = "code";
        ddlUnit.DataTextField = "Name";
        ddlUnit.DataSource = list;
        ddlUnit.DataBind();
    }

    protected void ddlUnit_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        List<V_KmuEmpDto> emplist = service.GetDeptEmp(ddlUnit.SelectedValue, null).OrderBy(c => c.Empcode).ToList();
        foreach (V_KmuEmpDto emp in emplist)
        {
            emp.Empname = emp.Empcode + "-" + emp.Empname;
        }
        ddlEmpByDept.DataSource = emplist;
        ddlEmpByDept.DataBind();
    }


    protected void btnSelect_Click(object sender, EventArgs e)
    {
        string teacherid = "";
        if (rbByDept.Checked)
        {
            if (ddlEmpByDept.SelectedValue == "" || ddlEmpByDept.SelectedValue == null)
            {
                ShowMessage("請選擇老師");
                return;
            }

            teacherid = ddlEmpByDept.SelectedValue;
        }
        if (rbByCode.Checked)
        {
            if (VsSelector1.SelectedValue == "" || VsSelector1.SelectedValue == null)
            {
                ShowMessage("請選擇老師");
                return;
            }
            teacherid = VsSelector1.SelectedValue;
        }

        string result = service.SetMyChoiceTeacher(Convert.ToInt32(Request.QueryString["instance_id"]),teacherid);

        if (result != null)
        {
            ShowMessage("設定失敗：" + result);
        }
        else
        {
            ShowMessageAndGo("設定完成", "ToDoList.aspx");
        }
    }
}