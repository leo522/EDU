using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KMU.EduActivity.ApplicationLayer.DTO;
using Telerik.Web.UI;


public partial class ElearningList : AuthPage
{
    private List<ElearningClassDto> CurrentUnFinishClasses
    {
        get
        {
            return ViewState["CurrentUnFinishClasses"] as List<ElearningClassDto>;
        }
        set
        {
            ViewState["CurrentUnFinishClasses"] = value;
        }
    }

    private List<ElearningClassDto> CurrentFinishedClasses
    {
        get
        {
            return ViewState["CurrentFinishedClasses"] as List<ElearningClassDto>;
        }
        set
        {
            ViewState["CurrentFinishedClasses"] = value;
        }
    }

    private List<ElearningClassDto> CurrentSelectionClasses
    {
        get
        {
            return ViewState["CurrentSelectionClasses"] as List<ElearningClassDto>;
        }
        set
        {
            ViewState["CurrentSelectionClasses"] = value;
        }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            rgFinished.DataBind();
            rgNotFinish.DataBind();
            
        }
    }


    private void ReadUnFinishClass()
    {
        CurrentUnFinishClasses = service.GetMyUnFinishClass(this.EmpCode);
        rgNotFinish.DataSource = CurrentUnFinishClasses;
    }

    private void ReadFinishedClass()
    {
        CurrentFinishedClasses = service.GetMyFinishedClass(this.EmpCode);
        rgFinished.DataSource = CurrentFinishedClasses;
    }

    private void ReadSelectionClass()
    {
        CurrentSelectionClasses = service.GetSelectionClass(tbName.Text.Trim(), this.EmpCode);
        rgSelection.DataSource = CurrentSelectionClasses;

    }
    protected void rgNotFinish_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        ReadUnFinishClass();
    }
    protected void rgFinished_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        ReadFinishedClass();
    }
    protected void btnQuery_Click(object sender, EventArgs e)
    {
        ReadSelectionClass();
        rgSelection.DataBind();
    }
    protected void rgSelection_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        rgSelection.DataSource = CurrentSelectionClasses;
    }
    protected void rgSelection_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
    {

    }
    protected void btnBooking_Click(object sender, EventArgs e)
    {
        GridDataItem item = (sender as Button).Parent.Parent as GridDataItem;
        string id = item.GetDataKeyValue("ClassID").ToString();
        string result = service.BookClass(id, this.EmpCode);
        if (result == null)
        {
            ReadSelectionClass();
            rgSelection.DataBind();
            ReadUnFinishClass();
            rgNotFinish.DataBind();
        }
        else
        {
            ShowMessage("報名失敗：" + result);
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        GridDataItem item = (sender as Button).Parent.Parent as GridDataItem;
        string id = item.GetDataKeyValue("ClassID").ToString();
        string result = service.UnBookClass(id, this.EmpCode);
        if (result == null)
        {
            ReadSelectionClass();
            rgSelection.DataBind();
            ReadUnFinishClass();
            rgNotFinish.DataBind();
        }
        else
        {
            ShowMessage("取消報名失敗：" + result);
        }
    }
    protected void btnRead_Click(object sender, EventArgs e)
    {
        GridDataItem item = (sender as Button).Parent.Parent as GridDataItem;
        string id = item.GetDataKeyValue("ClassID").ToString();
        Response.Redirect("ElearningContent.aspx?ClassID=" + id);
    }
}