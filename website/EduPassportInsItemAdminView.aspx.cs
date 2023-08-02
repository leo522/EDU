using KMU.EduActivity.ApplicationLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class EduPassportInsItemTeacherView : AuthPage
{
    private List<EduPassportInsItemDto> CurrentInstanceItems
    {
        get
        {
            return ViewState["CurrentInstanceItems"] as List<EduPassportInsItemDto>;
        }
        set
        {
            ViewState["CurrentInstanceItems"] = value;
        }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            ReadData();
            rgList.DataBind();

        }
    }


    private void ReadData()
    {

        List<EduPassportInsItemDto> items = service.GetEduPassportInsItemsAdmin();
        CurrentInstanceItems = items;

        rgList.DataSource = CurrentInstanceItems;

    }

    protected void rgList_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        ReadData();
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        GridDataItem item = (sender as ImageButton).Parent.Parent as GridDataItem;
        string id = item.GetDataKeyValue("IItemID").ToString();

        Response.Redirect("EduPassportInsItemEdit.aspx?ID=" + id);
    }

    protected void btnConfirmAll_Click(object sender, EventArgs e)
    {
        List<string> iitemids = new List<string>();

        foreach(GridDataItem item in rgList.SelectedItems)
        {
            string id = item.GetDataKeyValue("IItemID").ToString();
            iitemids.Add(id);
        }

        string result = service.AdminConfirmAllPassportInsItem(iitemids, this.EmpCode);

        if(result == null)
        {
            ShowMessage("審核完成");
            ReadData();
            rgList.DataBind();
        }
        else
        {
            ShowMessage("審核失敗:" + result);
        }
    }
}