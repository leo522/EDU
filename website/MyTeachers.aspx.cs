using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KMU.EduActivity.ApplicationLayer.DTO;

public partial class MyTeachers : AuthPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            ReadData();

        }
    }

    private void ReadData()
    {
        List<EduTeacherData> list = service.GetTeacherData(this.EmpCode);
        if (list.Count > 0)
        {
            lbNoData.Visible = false;
            foreach (EduTeacherData data in list)
            {
                UserControl_EduTeacherInfo uc = LoadControl("~/UserControls/EduTeacherInfo.ascx") as UserControl_EduTeacherInfo;
                uc.DataSource = data;
                uc.ReadData();
                panTeacherInfos.Controls.Add(uc);
            }
        }
        else
        {
            lbNoData.Visible = true;
        }
    }
}