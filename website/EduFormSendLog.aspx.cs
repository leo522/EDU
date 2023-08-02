using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KMU.EduActivity.ApplicationLayer.DTO;

public partial class EduFormSendLog : AuthPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDeptment();
            rdpEdate.SelectedDate = DateTime.Now;
            rdpSdate.SelectedDate = DateTime.Now.AddDays(-2);
        }
    }


    private void BindDeptment()
    {
        List<SelectGroupTypeDto> list = service.GetTermUnit("EduAct_Dept");

        ddlUnit.DataValueField = "code";
        ddlUnit.DataTextField = "Name";
        ddlUnit.DataSource = list;
        ddlUnit.DataBind();

        if (list.Count(c => c.code == this.DeptCode) > 0)
        {
            ddlUnit.SelectedValue = this.DeptCode;
        }

    }
    protected void btnQuery_Click(object sender, EventArgs e)
    {
        DateTime sdate = rdpSdate.SelectedDate.Value.Date;
        DateTime edate = rdpEdate.SelectedDate.Value.Date.AddDays(1).AddSeconds(-1);

        List<SchedulerLogDto> list = service.GetSchedulerLog(sdate, edate, this.DeptCode, this.HospCode);

        rgContent.DataSource = list;
        rgContent.DataBind();

    }
}