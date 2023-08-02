using KMU.EduActivity.ApplicationLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class EduPassportInstanceView : AuthPage
{
    private EduPassportInstanceDto CurrentInstance
    {
        get
        {
            return ViewState["CurrentInstance"] as EduPassportInstanceDto;
        }
        set
        {
            ViewState["CurrentInstance"] = value;
        }
    }

    private List<EduPassportInsItemDto> CurrentInstanceItems
    {
        get
        {
            return CurrentInstance.EduPassportInsItems.ToList();
        }
    }

    private string CurrentInstanceID
    {
        get
        {
            return Request.QueryString["ID"];
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
        if (CurrentInstanceID == null)
        {
            ShowMessageAndGo("參數傳遞錯誤", "EduPassportInstanceList.aspx");
            return;
        }

        EduPassportInstanceDto ins = service.GetEduPassportInstanceByID(CurrentInstanceID);

        CurrentInstance = ins;
        lbPassportName.Text = ins.TemplateName;
        lbEmpCode.Text = ins.EmpCode;
        lbEmpName.Text = ins.EmpName;

        if (cbDisplayFinished.Checked)
        {
            rgList.DataSource = CurrentInstanceItems;
        }
        else
        {
            rgList.DataSource = CurrentInstanceItems.Where(c => c.Status != "V");
        }
    }

    protected void rgList_ItemCreated(object sender, Telerik.Web.UI.GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            string id = (e.Item as GridDataItem).GetDataKeyValue("IItemID").ToString();

            EduPassportInsItemDto iitem = CurrentInstanceItems.Where(c => c.IItemID == id).FirstOrDefault();

            ImageButton btnEdit = e.Item.FindControl("btnEdit") as ImageButton;
            ImageButton btnReturnEmpty = e.Item.FindControl("btnReturnEmpty") as ImageButton;
            
            if (iitem != null)
            {
                string importantimgtag = "";

                if (this.AuthRoles.Contains("PPManager"))
                {
                    btnReturnEmpty.Visible = true;
                }
                else
                {
                    btnReturnEmpty.Visible = false;
                }

                if(iitem.IsNecessary)
                {
                    importantimgtag = "_i";
                }
                switch (iitem.Status)
                {
                    case "0":
                        btnEdit.ToolTip = "填寫";
                        btnEdit.ImageUrl = "~/Images/edit" + importantimgtag + ".gif";
                        break;
                    case "1":
                        btnEdit.ToolTip = "等待審核中";
                        btnEdit.ImageUrl = "~/Images/Wait" + importantimgtag + ".png";
                        break;
                    case "V":
                        btnEdit.ToolTip = "已完成";
                        btnEdit.ImageUrl = "~/Images/fin" + importantimgtag + ".png";
                        break;
                }
            }


        }
    }

    protected void rgList_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        ReadData();
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        GridDataItem item = (sender as ImageButton).Parent.Parent as GridDataItem;
        string id = item.GetDataKeyValue("IItemID").ToString();

        Response.Redirect("EduPassportInsItemEdit.aspx?ID=" + id + "&mode=View");
    }

    protected void cbDisplayFinished_CheckedChanged(object sender, EventArgs e)
    {
        ReadData();
        rgList.DataBind();
    }

    protected void rgList_PreRender(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GridGroupByField field = new GridGroupByField();
            field.FieldName = "類別";
            field.HeaderText = "類別";
            GridGroupByExpression ex = new GridGroupByExpression();
            ex.GroupByFields.Add(field);
            ex.SelectFields.Add(field);
            rgList.MasterTableView.GroupByExpressions.Add(ex);
            rgList.Rebind();
        }
    }
    protected void rgList_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridGroupHeaderItem)
        {

            (e.Item as GridGroupHeaderItem).DataCell.Text = (e.Item as GridGroupHeaderItem).DataCell.Text.Substring((e.Item as GridGroupHeaderItem).DataCell.Text.IndexOf(":") + 1);

        }
    }
    protected void btnReturnEmpty_Click(object sender, ImageClickEventArgs e)
    {
        GridDataItem item = (sender as ImageButton).Parent.Parent as GridDataItem;
        string id = item.GetDataKeyValue("IItemID").ToString();
        var rejinsitem = service.GetEduPassportInsItemByID(id);

        string msg = service.RejectEduPassportInsItem(rejinsitem, "", this.EmpCode);
        if (msg != null)
        {
            ShowMessage("取消失敗:" + msg);
        }
        else
        {
            ReadData();
            rgList.DataBind();
        }
    }
}