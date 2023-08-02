using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KMU.EduActivity.ApplicationLayer.DTO;
using Telerik.Web.UI;

public partial class EduFormPersonalList : AuthPage
{

    private string CurrentEduTermID
    {
        get
        {
            return Request.QueryString["EduTermID"];
        
        }

    }

    private string CurrentEmpCode
    {
        get
        {
            return Request.QueryString["EmpCode"];
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            if (CurrentEmpCode == null || CurrentEduTermID == null)
            {
                ShowMessage("參數傳遞錯誤");
                return;
            }

            if(this.AuthRoles.Contains("Student"))
            {
                rgData.MasterTableView.GetColumn("TemplateColumn").Visible = false;
            }

            //ReadData();
            rgData.DataBind();
        }
    }


    private void ReadData()
    {
        List<FORM_DATA> list = service.GetPersonalFormData(CurrentEduTermID, CurrentEmpCode);

        rgData.DataSource = list;
    }

    protected void rgData_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        ReadData();
    }
 
    protected void rgData_ItemCreated(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            string instanceid = (e.Item as GridDataItem).GetDataKeyValue("INSTANCE_ID").ToString();
            HyperLink link = e.Item.FindControl("linkView") as HyperLink;
            if (link != null)
            {
                link.NavigateUrl = "InstanceDetial.aspx?instance_id=" + instanceid + "&mode=v";
                link.Target = "_blank";
            }
        }
    }

    protected void rgData_NeedDataSource1(object sender, GridNeedDataSourceEventArgs e)
    {
        ReadData();
    }
}