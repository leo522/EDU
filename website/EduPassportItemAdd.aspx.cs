using KMU.EduActivity.ApplicationLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class EduPassportItemAdd : AuthPage
{
    private EduPassportItemDto CurrentItem
    {
        get
        {
            return ViewState["CurrentItem"] as EduPassportItemDto;
        }
        set
        {
            ViewState["CurrentItem"] = value;
        }
    }

    private List<EduPassportItemDetDto> CurrentSDet
    {
        get
        {
            return ViewState["CurrentSDet"] as List<EduPassportItemDetDto>;
        }
        set
        {
            ViewState["CurrentSDet"] = value;
            preControlS.DataSource = value;
        }
    }

    private List<EduPassportItemDetDto> CurrentTDet
    {
        get
        {
            return ViewState["CurrentTDet"] as List<EduPassportItemDetDto>;
        }
        set
        {
            ViewState["CurrentTDet"] = value;
            preControlT.DataSource = value;
        }
    }

    private List<EduPassportPRefDto> CurrentPRef
    {
        get
        {
            return ViewState["CurrentPRef"] as List<EduPassportPRefDto>;
        }
        set
        {
            ViewState["CurrentPRef"] = value;
        }
    }

    private string CurrentItemID
    {
        get
        {
            if (Request.QueryString["ItemID"] != null)
            {
                return Request.QueryString["ItemID"];
            }
            else if(Request.QueryString["CopyItemID"] != null)
            {
                return Request.QueryString["CopyItemID"];
            }
            else
            {
                return null;
            }
        }
    }

    private bool IsCopyMode
    {
        get
        {
            return Request.QueryString["CopyItemID"] != null;
        }
    }



    protected void Page_Load(object sender, EventArgs e)
    {
        TreeViewComboBox2.SelectedChanged += tvcbQuery_SelectedChanged;

        if (!IsPostBack)
        {
            BindDeptment();

            if (Request.QueryString["ItemID"] != null || Request.QueryString["CopyItemID"] != null)
            {
                ReadData();
            }
            else
            {
                CurrentItem = new EduPassportItemDto();
                CurrentItem.EduPassportItemDets = new List<EduPassportItemDetDto>();
                CurrentItem.EduPassportItemTargets = new List<EduPassportItemTargetDto>();
                CurrentSDet = new List<EduPassportItemDetDto>();
                CurrentTDet = new List<EduPassportItemDetDto>();
                CurrentPRef = new List<EduPassportPRefDto>();
            }

            rgSDet.DataSource = CurrentSDet;
            rgSDet.DataBind();

            rgTDet.DataSource = CurrentTDet;
            rgTDet.DataBind();

            rgPRef.DataSource = CurrentPRef;
            rgPRef.DataBind();
        }
    }

    void tvcbQuery_SelectedChanged(object sender, EventArgs e)
    {
        ReadPassPortCheckItem();
    }


    private void ReadPassPortCheckItem()
    {
        List<PassPortCheckItemDto> list = service.GetPassPortCheckItemRef(TreeViewComboBox2.SelectedValue);
        PassPortCheckItemDto emptyitem = new PassPortCheckItemDto();
        emptyitem.ItemCode = -1;
        emptyitem.ItemName = "無";
        list.Insert(0,emptyitem);
        rcbCheckItem.ClearSelection();
        rcbCheckItem.DataValueField = "itemCode";
        rcbCheckItem.DataTextField = "itemName";
        rcbCheckItem.DataSource = list;
        rcbCheckItem.DataBind();

    }

    private void ReadData()
    {

        EduPassportItemDto item = service.GetEduPassportItemWithDet(CurrentItemID);
        tbName.Text = item.ItemName;
        tbRemark.Text = item.Remark;
        cbNecessary.Checked = item.IsNecessary;
        reDesc.Content = item.ItemDesc;
        
        foreach (EduPassportItemTargetDto target in item.EduPassportItemTargets.Where(c => c.TargetType == "dept"))
        {
            foreach(RadComboBoxItem i in ddlUnit.Items)
            {
                if(i.Value == target.TargetID)
                {
                    i.Checked = true;
                }   
            }
        }


        if (IsCopyMode)
        {
            item.ItemID = null;
            foreach (EduPassportItemDetDto det in item.EduPassportItemDets)
            {
                det.ItemID = null;
            }

            foreach (EduPassportItemTargetDto target in item.EduPassportItemTargets)
            {
                target.ItemID = null;
            }
        }
        CurrentItem = item;
        CurrentSDet = item.EduPassportItemDets.Where(c => c.FieldTarget == "S").OrderBy(c => c.Seq).ToList();
        CurrentTDet = item.EduPassportItemDets.Where(c => c.FieldTarget == "T").OrderBy(c => c.Seq).ToList();
        CurrentPRef = item.EduPassportPRefs.ToList();
        //if(item.EduPassportPRefs.Count>0)
        //{
        //    rcbCheckItem.SelectedValue = item.EduPassportPRefs.FirstOrDefault().ItemCode.ToString();
        //}

    }

    private void BindDeptment()
    {
        List<SelectGroupTypeDto> list = service.GetTermUnit("EduAct_Dept");

        ddlUnit.DataValueField = "code";
        ddlUnit.DataTextField = "Name";
        ddlUnit.DataSource = list;
        ddlUnit.DataBind();

        ddlUnit.SelectedIndex = 0;

    }

    private List<EduPassportItemDetDto> RefreshSeq(List<EduPassportItemDetDto> input)
    {
        int i = 1;
        foreach(EduPassportItemDetDto dto in input.OrderBy(c=> c.Seq))
        {
            dto.Seq = i;
            i++;
        }

        return input.ToList();

    }

    protected void btnDelete0_Click(object sender, ImageClickEventArgs e)
    {

        GridDataItem item = (sender as ImageButton).Parent.Parent as GridDataItem;
        int seq = Convert.ToInt32(item.GetDataKeyValue("seq"));

        CurrentTDet.Remove(CurrentTDet.Where(c => c.Seq == seq).FirstOrDefault());
        CurrentTDet = RefreshSeq(CurrentTDet);
        rgTDet.DataSource = CurrentTDet;
        rgTDet.DataBind();

    }
    protected void btnDelete_Click(object sender, ImageClickEventArgs e)
    {
        GridDataItem item = (sender as ImageButton).Parent.Parent as GridDataItem;
        int seq = Convert.ToInt32(item.GetDataKeyValue("seq"));

        CurrentSDet.Remove(CurrentSDet.Where(c => c.Seq == seq).FirstOrDefault());
        CurrentSDet = RefreshSeq(CurrentSDet);
        rgSDet.DataSource = CurrentSDet;
        rgSDet.DataBind();


    }
    protected void btnExit_Click(object sender, EventArgs e)
    {
        Response.Redirect("EduPassportItemManager.aspx");
    }
    protected void btnSAdd_Click(object sender, EventArgs e)
    {
        if(rblSFieldType.SelectedValue == "單選"|| rblSFieldType.SelectedValue == "多選")
        {
            if(tbSOptions.Text.Trim() == "")
            {
                ShowMessage("未輸入選項");
                return;
            }
        }

        if(tbSFieldName.Text.Trim() == "")
        {
            ShowMessage("未輸入項目名稱");
            return;
        }

        EduPassportItemDetDto dto = new EduPassportItemDetDto();
        dto.FieldDesc = tbSFieldName.Text;
        dto.FieldTarget = "S";
        dto.FieldType = rblSFieldType.SelectedValue;
        dto.Seq = CurrentSDet.Count + 1;
        if (rblSFieldType.SelectedValue == "單選" || rblSFieldType.SelectedValue == "多選")
        {
            dto.SelectOptions = tbSOptions.Text;
        }
        CurrentSDet.Add(dto);
        CurrentSDet = CurrentSDet;
        rgSDet.DataSource = CurrentSDet;
        rgSDet.DataBind();
    }
    protected void btnTAdd_Click(object sender, EventArgs e)
    {
        if (rblTFieldType.SelectedValue == "單選" || rblTFieldType.SelectedValue == "多選")
        {
            if (tbTOptions.Text.Trim() == "")
            {
                ShowMessage("未輸入選項");
                return;
            }
        }
        if (tbTFieldName.Text.Trim() == "")
        {
            ShowMessage("未輸入項目名稱");
            return;
        }

        EduPassportItemDetDto dto = new EduPassportItemDetDto();
        dto.FieldDesc = tbTFieldName.Text;
        dto.FieldTarget = "T";
        dto.FieldType = rblTFieldType.SelectedValue;
        dto.Seq = CurrentTDet.Count + 1;
        if (rblTFieldType.SelectedValue == "單選" || rblTFieldType.SelectedValue == "多選")
        {
            dto.SelectOptions = tbTOptions.Text;
        }

        CurrentTDet.Add(dto);
        CurrentTDet = CurrentTDet;
        rgTDet.DataSource = CurrentTDet;
        rgTDet.DataBind();
    }
    protected void btnSMoveUp_Click(object sender, EventArgs e)
    {
        if (rgSDet.SelectedItems.Count == 1)
        {
            GridDataItem item = rgSDet.SelectedItems[0] as GridDataItem;
            int seq = Convert.ToInt32(item.GetDataKeyValue("seq"));

            EduPassportItemDetDto moveitem = CurrentSDet.Where(c => c.Seq == seq).FirstOrDefault();
            EduPassportItemDetDto preitem = CurrentSDet.Where(c => c.Seq == seq - 1).FirstOrDefault();

            if (preitem != null)
            {

                if (moveitem != null)
                {
                    moveitem.Seq = moveitem.Seq - 1;
                }

                preitem.Seq = seq;

            }
            CurrentSDet = CurrentSDet.OrderBy(c => c.Seq).ToList();
            rgSDet.DataSource = CurrentSDet;
            rgSDet.DataBind();
        }
    }
    protected void btnSMoveDown_Click(object sender, EventArgs e)
    {
        if (rgSDet.SelectedItems.Count == 1)
        {
            GridDataItem item = rgSDet.SelectedItems[0] as GridDataItem;
            int seq = Convert.ToInt32(item.GetDataKeyValue("seq"));

            EduPassportItemDetDto moveitem = CurrentSDet.Where(c => c.Seq == seq).FirstOrDefault();
            EduPassportItemDetDto nextitem = CurrentSDet.Where(c => c.Seq == seq + 1).FirstOrDefault();

            if (nextitem != null)
            {

                if (moveitem != null)
                {
                    moveitem.Seq = moveitem.Seq + 1;
                }

                nextitem.Seq = seq;

            }
            CurrentSDet = CurrentSDet.OrderBy(c => c.Seq).ToList();
            rgSDet.DataSource = CurrentSDet;
            rgSDet.DataBind();
        }
    }
    protected void btnTMoveUp_Click(object sender, EventArgs e)
    {
        if (rgTDet.SelectedItems.Count == 1)
        {
            GridDataItem item = rgTDet.SelectedItems[0] as GridDataItem;
            int seq = Convert.ToInt32(item.GetDataKeyValue("seq"));

            EduPassportItemDetDto moveitem = CurrentTDet.Where(c => c.Seq == seq).FirstOrDefault();
            EduPassportItemDetDto preitem = CurrentTDet.Where(c => c.Seq == seq - 1).FirstOrDefault();

            if (preitem != null)
            {

                if (moveitem != null)
                {
                    moveitem.Seq = moveitem.Seq - 1;
                }

                preitem.Seq = seq;

            }
            CurrentTDet = CurrentTDet.OrderBy(c => c.Seq).ToList();
            rgTDet.DataSource = CurrentTDet;
            rgTDet.DataBind();
        }
    }
    protected void btnTMoveDown_Click(object sender, EventArgs e)
    {
        if (rgTDet.SelectedItems.Count == 1)
        {
            GridDataItem item = rgTDet.SelectedItems[0] as GridDataItem;
            int seq = Convert.ToInt32(item.GetDataKeyValue("seq"));

            EduPassportItemDetDto moveitem = CurrentTDet.Where(c => c.Seq == seq).FirstOrDefault();
            EduPassportItemDetDto nextitem = CurrentTDet.Where(c => c.Seq == seq + 1).FirstOrDefault();

            if (nextitem != null)
            {

                if (moveitem != null)
                {
                    moveitem.Seq = moveitem.Seq + 1;
                }

                nextitem.Seq = seq;

            }
            CurrentTDet = CurrentTDet.OrderBy(c => c.Seq).ToList();
            rgTDet.DataSource = CurrentTDet;
            rgTDet.DataBind();
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if(CurrentItemID == null || IsCopyMode)
        {
            CurrentItem.Creater = this.EmpCode;
            CurrentItem.Createdate = DateTime.Now;
        }
        else
        {
            CurrentItem.Modifier = this.EmpCode;
            CurrentItem.Modifydate = DateTime.Now;
        }
        CurrentItem.ItemName = tbName.Text.Trim();
        CurrentItem.Remark = tbRemark.Text.Trim();
        CurrentItem.Status = "V";
        CurrentItem.EduPassportItemTargets = new List<EduPassportItemTargetDto>();
        CurrentItem.IsNecessary = cbNecessary.Checked;
        CurrentItem.ItemDesc = reDesc.Content;
        if (rddtJobCode.SelectedValue != "")
        {
            foreach(string job in rddtJobCode.SelectedValue.Split(',').ToList())
            {
                EduPassportItemTargetDto dto = new EduPassportItemTargetDto();
                dto.TargetID = job;
                dto.TargetType = "job";
                CurrentItem.EduPassportItemTargets.Add(dto);
            }
        }

        foreach (RadComboBoxItem item in ddlUnit.CheckedItems)
        {
            EduPassportItemTargetDto dto = new EduPassportItemTargetDto();
            dto.TargetID = item.Value;
            dto.TargetType = "dept";
            CurrentItem.EduPassportItemTargets.Add(dto);
        }

        List<EduPassportItemDetDto> detlist = new List<EduPassportItemDetDto>();
        detlist.AddRange(CurrentSDet);
        detlist.AddRange(CurrentTDet);



        CurrentItem.EduPassportItemDets = detlist;

        CurrentItem.EduPassportPRefs = CurrentPRef;

        if (CurrentItemID == null || IsCopyMode)
        {
            string msg = service.CreateEduPassportItem(CurrentItem);
            if(msg!=null)
            {
                ShowMessage("新增失敗:" + msg);

            }
            else
            {
                Response.Redirect("EduPassportItemManager.aspx");
            }
        }
        else
        {
            string msg = service.UpdateEduPassportItem(CurrentItem);
            if (msg != null)
            {
                ShowMessage("更新失敗:" + msg);

            }
            else
            {
                Response.Redirect("EduPassportItemManager.aspx");
            }
        }

    }
    protected void rddtJobCode_DataBound(object sender, EventArgs e)
    {
        if (CurrentItemID != null)
        {
            string selectedstr = "";
            foreach (EduPassportItemTargetDto target in CurrentItem.EduPassportItemTargets.Where(c => c.TargetType == "job"))
            {
                if (selectedstr != "")
                {
                    selectedstr += ",";
                }
                selectedstr += target.TargetID.ToString();
            }
            rddtJobCode.SelectedValue = selectedstr;
            ReadPassPortCheckItem();
        }
    }
    protected void btnPreviewS_Click(object sender, EventArgs e)
    {
        preControlS.DataSource = CurrentSDet;

    }
    protected void btnPreviewT_Click(object sender, EventArgs e)
    {
        preControlT.DataSource = CurrentTDet;
    }
    protected void btnDelete1_Click(object sender, ImageClickEventArgs e)
    {

        GridDataItem item = (sender as ImageButton).Parent.Parent as GridDataItem;
        int seq = Convert.ToInt32(item.GetDataKeyValue("ID"));

        CurrentPRef.Remove(CurrentPRef.Where(c => c.ID == seq).FirstOrDefault());

        rgPRef.DataSource = CurrentPRef;
        rgPRef.DataBind();
    }
    protected void btnAddPRef_Click(object sender, EventArgs e)
    {
        if (rcbCheckItem.SelectedValue == "" || rcbCheckItem.SelectedValue == null || rcbCheckItem.SelectedValue == "-1")
        {
            ShowMessage("未選擇項目");
            return;
        }


        EduPassportPRefDto dto = new EduPassportPRefDto();
        dto.ItemCode = Convert.ToInt32(rcbCheckItem.SelectedValue);
        dto.itemName = rcbCheckItem.Text;
        dto.ItemID = CurrentItemID;

        CurrentPRef.Add(dto);
        CurrentPRef = CurrentPRef;

        rgPRef.DataSource = CurrentPRef;
        rgPRef.DataBind();
    }
    protected void rgPRef_ItemCommand(object sender, GridCommandEventArgs e)
    {

    }
}