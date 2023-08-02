using KMU.EduActivity.ApplicationLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class EduPassportItemFinder : AuthPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            tbCreater.Text = this.EmpCode;
            BindDeptment();
        }
    }

    protected void CloseWindow()
    {
        string codes = "";
        string names = "";
        foreach (GridDataItem item in rgList.SelectedItems)
        {
            string id = item.GetDataKeyValue("ItemID").ToString();
            string name = item.GetDataKeyValue("ItemName").ToString();

            codes += id + "#spilter#";
            names += name.Replace("'", "’") + "#spilter#";

        }

        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), this.ClientID + "RunOpenWin", @"
var oWindow = null;
            if (window.radWindow) oWindow = window.radWindow;
            else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow;
            var oArg = new Object();
            oArg.SelectItemIDs = '" + codes + @"';
            oArg.SelectItemNames = '" + names + @"';
            oWindow.close(oArg);", true);
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
    protected void btnSelect_Click(object sender, EventArgs e)
    {
        CloseWindow();
    }
}