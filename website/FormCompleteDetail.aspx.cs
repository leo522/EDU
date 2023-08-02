using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KMU.EduActivity.ApplicationLayer.DTO;

public partial class FormCompleteDetail : AuthPage
{
    private string CurrentEduTermID
    {
        get
        {
            return Request.QueryString["edutermid"];
        }
    }
    private string CurrentTemplateID
    {
        get
        {
            return Request.QueryString["templateid"];
        }
    }

    private List<string> CurrentFTListIDs
    {
        get
        {
            return null;
        }
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ReadData();
            RadGrid1.DataBind();
        }
    }

    private void ReadData()
    {
        List<FORM_COMPLETE_STATUS> list = service.GetFormCompleteStatus(CurrentEduTermID, CurrentTemplateID);
        RadGrid1.DataSource = list;

    }

    protected void RadGrid1_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        ReadData();
    }
}