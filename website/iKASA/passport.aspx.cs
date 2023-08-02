using KMU.EduActivity.ApplicationLayer.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class iKASA_passport : iKASAPageBase
{
    private List<EduPassportInstanceDto> CurrentInstances
    {
        get
        {
            return ViewState["CurrentInstances"] as List<EduPassportInstanceDto>;
        }
        set
        {
            ViewState["CurrentInstances"] = value;
        }

    }

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
            if (ViewState["CurrentInstanceID"] == null)
            {
                return null;
            }
            return ViewState["CurrentInstanceID"].ToString();
        }
        set
        {
            ViewState["CurrentInstanceID"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            ReadListData();
    }

    private void ReadListData()
    {
        DataTable itemdata = null;
        string empcode = CurrentPersonInfo.empcode;
        //empcode = "1020640";
        List<EduPassportInstanceDto> list = service.QueryEduPassportInstance(null, null, null, empcode, null, this.CurrentPersonInfo.dateform ,this.CurrentPersonInfo.dateto, null, ref itemdata).OrderBy(c => c.CreateDate).ToList();

        rgList.DataSource = list;
        CurrentInstances = list;

    }

    protected void btnView_Click(object sender, EventArgs e)
    {
        string instanceid = ((sender as Button).Parent.Parent as GridDataItem).GetDataKeyValue("InstanceID").ToString();
        CurrentInstanceID = instanceid;
        ReadInstanceData();
        rgInstance.DataBind();
        rmp.SelectedIndex = 1;
    }

    protected void rgList_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        if (IsPostBack)
        {
            rgList.DataSource = CurrentInstances;
        }
    }

    protected void rgList_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            if (e.Item.Cells[7].Text != "100%")
            {
                e.Item.Cells[7].ForeColor = System.Drawing.Color.Red;
            }

            if (e.Item.Cells[8].Text != "100%")
            {
                e.Item.Cells[8].ForeColor = System.Drawing.Color.Red;
            }

            if (e.Item.Cells[9].Text != "100%")
            {
                e.Item.Cells[9].ForeColor = System.Drawing.Color.Red;
            }
        }
    }

    private void ReadInstanceData()
    {
        if (CurrentInstanceID == null)
        {
            ShowMessage("參數傳遞錯誤");
            rmp.SelectedIndex = 0;
            return;
        }

        EduPassportInstanceDto ins = service.GetEduPassportInstanceByID(CurrentInstanceID);

        CurrentInstance = ins;
        lbPassportName.Text = ins.TemplateName;
        lbPassportName2.Text = ins.TemplateName;

        if (cbDisplayFinished.Checked)
        {
            rgInstance.DataSource = CurrentInstanceItems;
        }
        else
        {
            rgInstance.DataSource = CurrentInstanceItems.Where(c => c.Status != "V");
        }
    }

    protected void rgInstance_ItemCreated(object sender, Telerik.Web.UI.GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            string id = (e.Item as GridDataItem).GetDataKeyValue("IItemID").ToString();

            EduPassportInsItemDto iitem = CurrentInstanceItems.Where(c => c.IItemID == id).FirstOrDefault();

            ImageButton btnEdit = e.Item.FindControl("btnEdit") as ImageButton;

            if (iitem != null)
            {
                string importantimgtag = "";


                if (iitem.IsNecessary)
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

    protected void rgInstance_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        if (CurrentInstanceID != null)
        {
            ReadInstanceData();
        }
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        GridDataItem item = (sender as ImageButton).Parent.Parent as GridDataItem;
        string id = item.GetDataKeyValue("IItemID").ToString();
        CurrentIItemID = id;
        ReadDetData();
        rmp.SelectedIndex = 2;
    }

    protected void cbDisplayFinished_CheckedChanged(object sender, EventArgs e)
    {
        ReadInstanceData();
        rgInstance.DataBind();
    }

    protected void rgInstance_PreRender(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GridGroupByField field = new GridGroupByField();
            field.FieldName = "類別";
            field.HeaderText = "類別";
            GridGroupByExpression ex = new GridGroupByExpression();
            ex.GroupByFields.Add(field);
            ex.SelectFields.Add(field);
            rgInstance.MasterTableView.GroupByExpressions.Add(ex);
            rgInstance.Rebind();
        }
    }

    protected void rgInstance_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridGroupHeaderItem)
        {

            (e.Item as GridGroupHeaderItem).DataCell.Text = (e.Item as GridGroupHeaderItem).DataCell.Text.Substring((e.Item as GridGroupHeaderItem).DataCell.Text.IndexOf(":") + 1);

        }
    }

    protected void btnInsReturnMain_Click(object sender, EventArgs e)
    {
        rmp.SelectedIndex = 0;
    }

    private EduPassportInsItemDto CurrentInstanceItem
    {
        get
        {
            return ViewState["CurrentInstanceItem"] as EduPassportInsItemDto;
        }
        set
        {
            ViewState["CurrentInstanceItem"] = value;
        }
    }

    private List<EduPassportInsItemDetDto> CurrentInsItemDets                                  
    {
        get
        {
            return CurrentInstanceItem.EduPassportInsItemDets.ToList();
        }
    }

    private List<EduPassportInsItemDetDto> CurrentSInsItemDets
    {
        get
        {
            return CurrentInstanceItem.EduPassportInsItemDets.Where(c => c.FieldTarget == "S").ToList();
        }
    }

    private List<EduPassportInsItemDetDto> CurrentTInsItemDets
    {
        get
        {
            return CurrentInstanceItem.EduPassportInsItemDets.Where(c => c.FieldTarget == "T").ToList();
        }
    }

    private string CurrentIItemID
    {
        get
        {
            return ViewState["CurrentIItemID"] as string;
        }
        set
        {
            ViewState["CurrentIItemID"] = value;
        }
    }

    private void ReadDetData()
    {
        if (CurrentIItemID == null)
        {
            ShowMessage("參數傳遞錯誤");
            rmp.SelectedIndex = 1;
            return;
        }

        EduPassportInsItemDto iitem = service.GetEduPassportInsItemByID(CurrentIItemID);

        CurrentInstanceItem = iitem;

        if (CurrentInstanceItem.SubmitDate.HasValue)
        {
            lbSubmitTime.Text = CurrentInstanceItem.SubmitDate.Value.ToString("yyyy/MM/dd HH:mm");
        }
        else
        {
            lbSubmitTime.Text = "";
        }
        lbPassportName.Text = CurrentInstance.TemplateName;
        lbItemName.Text = CurrentInstanceItem.ItemName;
        lbTeacherName.Text = CurrentInstanceItem.TeacherName;
        lbCurrentStatus.Text = CurrentInstanceItem.StatusName;
        if (CurrentInstanceItem.ModifyDate.HasValue)
        {
            lbModifyDate.Text = CurrentInstanceItem.ModifyDate.Value.ToString("yyyy/MM/dd HH:mm");
        }
        else
        {
            lbModifyDate.Text = "";
        }

        EduPassportItemDto item = service.GetEduPassportItemWithDet(iitem.ItemID);
        if (item != null)
        {
            liDesc.Text = item.ItemDesc;
        }

        EditContrlS.Visible = true;
        EditContrlS.DisplayOnly = true;
        EditContrlT.Visible = true;
        EditContrlT.DisplayOnly = true;
        panDisplayTeacher.Visible = true;
        EditContrlT.DataSource = CurrentTInsItemDets;

        EditContrlS.DataSource = CurrentSInsItemDets;

        List<EduPassportInsItemRejectHiDto> rejecthis = service.GetRejectHistory(CurrentIItemID);
        if (rejecthis.Count > 0)
        {
            panRejectHistory.Visible = true;
            rgRejectReason.DataSource = rejecthis;
            rgRejectReason.DataBind();
        }
    }

    protected void btnDetReturnIns_Click(object sender, EventArgs e)
    {
        rmp.SelectedIndex = 1;
    }
}