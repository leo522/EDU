using KMU.EduActivity.ApplicationLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class EduPassportItemManager : AuthPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            BindDeptment();
            BindJobCode();
            if (!IsPostBack)
            {
                tbKeyWord.Text = Univar.Storage.Session.Get(this.GetType().Name + "_tbKeyWord");
                ddlUnit.SelectedValue = Univar.Storage.Session.Get(this.GetType().Name + "_ddlUnit");
                rddtJobCode.SelectedValue = Univar.Storage.Session.Get(this.GetType().Name + "_rddtJobCode") == null ? "" : Univar.Storage.Session.Get(this.GetType().Name + "_rddtJobCode");
                tbCreater.Text = Univar.Storage.Session.Get(this.GetType().Name + "_tbCreater");
                if (tbCreater.Text == "")
                {
                    tbCreater.Text = this.EmpCode;
                }
            }
        }
    }

    private void BindJobCode()
    {
        List<V_CodeRefDto> list = service.GetCodeRefs("EduAct_JobSerial");
        rddtJobCode.DataSource = list;
        rddtJobCode.DataBind();
        
    }

    private void BindDeptment()
    {
        List<SelectGroupTypeDto> list = service.GetTermUnit("EduAct_Dept");

        SelectGroupTypeDto dtoall = new SelectGroupTypeDto();
        dtoall.code = "";
        dtoall.name = "全部";
        list.Insert(0, dtoall);

        ddlUnit.DataValueField = "code";
        ddlUnit.DataTextField = "Name";
        ddlUnit.DataSource = list;
        ddlUnit.DataBind();

        ddlUnit.SelectedIndex = 0;
        
    }

    private void ReadData()
    {


        List<EduPassportItemDto> list = service.GetEduPassportItems(tbKeyWord.Text.Trim(), rddtJobCode.SelectedValue, ddlUnit.SelectedValue, tbCreater.Text.Trim());
        rgList.DataSource = list;


    }

    protected void rgList_ItemCreated(object sender, Telerik.Web.UI.GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            string id = (e.Item as GridDataItem).GetDataKeyValue("ItemID").ToString();
            HyperLink btnEdit = e.Item.FindControl("btnEdit") as HyperLink;
            if (btnEdit != null)
            {
                btnEdit.NavigateUrl = "EduPassportItemAdd.aspx?ItemID=" + id;
            }

            HyperLink btnCopy = e.Item.FindControl("btnCopy") as HyperLink;
            if (btnCopy != null)
            {
                btnCopy.NavigateUrl = "EduPassportItemAdd.aspx?CopyItemID=" + id;
            }
        }
    }

    

    protected void btnQuery_Click(object sender, EventArgs e)
    {
        Univar.Storage.Session.Set(this.GetType().Name + "_tbKeyWord", tbKeyWord.Text.Trim());
        Univar.Storage.Session.Set(this.GetType().Name + "_rddtJobCode", rddtJobCode.SelectedValue);
        Univar.Storage.Session.Set(this.GetType().Name + "_ddlUnit", ddlUnit.SelectedValue);
        Univar.Storage.Session.Set(this.GetType().Name + "_tbCreater", tbCreater.Text.Trim());


        ReadData();
        rgList.DataBind();
    }
    protected void rgList_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        ReadData();
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("EduPassportItemAdd.aspx");
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        GridDataItem item = (sender as Button).Parent.Parent as GridDataItem;
        string id = item.GetDataKeyValue("ItemID").ToString();

        service.DeleteEduPassportItem(id, this.EmpCode);
        ReadData();
        rgList.DataBind();
    }
    protected void rddtJobCode_DataBound(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
        }
    }
}