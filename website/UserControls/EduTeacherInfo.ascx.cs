using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KMU.EduActivity.ApplicationLayer.DTO;


public partial class UserControl_EduTeacherInfo : System.Web.UI.UserControl
{

    public EduTeacherData DataSource
    {
        get;
        set;
    }

    public void ReadData()
    {
        //lbCourseName.Text = this.DataSource.EduTermName;
        //RadGrid1.DataSource = DataSource.TeacherInfo;
        //RadGrid1.DataBind();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (this.DataSource != null)
        //{
        //    lbCourseName.Text = this.DataSource.EduTermName;
        //    RadGrid1.DataSource = DataSource.TeacherInfo;
        //    RadGrid1.DataBind();
        //}
    }
    protected void RadGrid1_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        if (this.DataSource != null)
        {
            lbCourseName.Text = this.DataSource.EduTermName;
            RadGrid1.DataSource = DataSource.TeacherInfo;
            
        }
    }
}
