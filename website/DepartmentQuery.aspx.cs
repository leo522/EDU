using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KMU.EduActivity.ApplicationLayer.DTO;

public partial class DepartmentQuery : AuthPage
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

        List<SelectGroupTypeDto> list = service.GetTermUnit("EduAct_Dept");
        GridView1.DataSource = list;
        GridView1.DataBind();
    }
}