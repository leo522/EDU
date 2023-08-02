using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KMU.EduActivity.ApplicationLayer.DTO;
using EduActivity.Report;
using Telerik.Reporting;

public partial class ReportManage : AuthPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AddPostbackControl(btnQuery);
        AddPostbackControl(ReportViewer1);
        AddPostbackControl(RadioButtonList1);
    }
    protected void btnQuery_Click(object sender, EventArgs e)
    {
        List<CourseReportDto>[] data = service.GetCourseReportData(tbEduYear.Text, tvbcTeamInternCourse.SelectedValue);
        InternCourseReport rep = new InternCourseReport();
        rep.ReportParameters["TeamName"].Value = tvbcTeamInternCourse.SelectedText;
        rep.ReportParameters["PrintDate"].Value = (DateTime.Now.Year - 1911).ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString();
        rep.ReportParameters["EduYear"].Value = tbEduYear.Text + "學年度";
        rep.DataSource = data[0];
        (rep.Items.Find("crosstab1", true)[0] as Crosstab).DataSource = data[1];
        InstanceReportSource source = new InstanceReportSource();
        source.ReportDocument = rep;
        ReportViewer1.ReportSource = source;
        ReportViewer1.DataBind();

    }
    private void SwitchOption(string id)
    {
        foreach (Control  pan in panControlOptions.Controls)
        {
            if (pan is System.Web.UI.WebControls.Panel)
            {
                if (pan.ID == id)
                {
                    pan.Visible = true;
                }
                else
                {
                    pan.Visible = false;
                }
            }
        }
    }

    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        switch (RadioButtonList1.SelectedValue)
        {
            case "課程總表":
                SwitchOption("panInternCourseReport");
                break;
        }
    }
}