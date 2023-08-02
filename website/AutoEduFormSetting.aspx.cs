using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using KMU.EduActivity.ApplicationLayer.DTO;
using KMU.EduActivity.DomainModel.Entities;

public partial class AutoEduFormSetting : AuthPage
{
    private HtmlFormUtility.Components.ViewComponent vc = new HtmlFormUtility.Components.ViewComponent();

    private string CurrentAutoFTListID
    {
        get
        {
            return Request.QueryString["AutoFTListID"];
        }
    }
    private List<FORM_TEMPLATEDto> CurrentTemplateList
    {
        get
        {
            return ViewState["FormSettingTemplateList"] as List<FORM_TEMPLATEDto>;
        }
        set
        {
            ViewState["FormSettingTemplateList"] = value;
        }
    }


    private List<FormTargetSetting> CurrentSetting
    {
        get
        {
            return ViewState["CurrentSetting"] as List<FormTargetSetting>;
        }
        set
        {
            ViewState["CurrentSetting"] = value;
        }
    }

    private List<SelectGroupTypeDto> CurrentExceptDept
    {
        get
        {
            return ViewState["CurrentExceptDept"] as List<SelectGroupTypeDto>;
        }
        set
        {
            ViewState["CurrentExceptDept"] = value;
        }
    }

    private List<SelectGroupTypeDto> CurrentSendDept
    {
        get
        {
            return ViewState["CurrentSendDept"] as List<SelectGroupTypeDto>;
        }
        set
        {
            ViewState["CurrentSendDept"] = value;
        }
    }

    private List<EduTermDto> CurrentSendTerm
    {
        get
        {
            return ViewState["CurrentSendTerm"] as List<EduTermDto>;
        }
        set
        {
            ViewState["CurrentSendTerm"] = value;
        }
    }

    private List<EduTermDto> CurrentNoSendTerm
    {
        get
        {
            return ViewState["CurrentNoSendTerm"] as List<EduTermDto>;
        }
        set
        {
            ViewState["CurrentNoSendTerm"] = value;
        }
    }

    private List<AutoEduFormTemplateExceptDto> CurrentSendMonth
    {
        get
        {
            return ViewState["CurrentSendMonth"] as List<AutoEduFormTemplateExceptDto>;
        }
        set
        {
            ViewState["CurrentSendMonth"] = value;
        }

    }


    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["Query"] == "1")
        {
            btnSubmit.Visible = false;
        }
        if (!IsPostBack)
        {
            CurrentExceptDept = new List<SelectGroupTypeDto>();
            CurrentSendDept = new List<SelectGroupTypeDto>();
            CurrentSendTerm = new List<EduTermDto>();
            CurrentSendMonth = new List<AutoEduFormTemplateExceptDto>();
            CurrentNoSendTerm = new List<EduTermDto>();
            BindTeacherType();
            ReloadList();
            ClearFields();
            BindDept();
            if (CurrentAutoFTListID != null)
            {
                ReadSetting();
                ReadExcept();
                ReadSendDept();
                ReadSendTerm();
                ReadNoSendTerm();
                ReadSendMonth();
            }
        }

    }

    private void ReadExcept()
    {
        List<AutoEduFormTemplateExceptDto> list = service.GetAutoEduFormSettingExceptListDept(CurrentAutoFTListID);
        List<SelectGroupTypeDto> tlist = new List<SelectGroupTypeDto>();
        foreach (AutoEduFormTemplateExceptDto dto in list)
        {
            SelectGroupTypeDto newitem = new SelectGroupTypeDto();
            newitem.code = dto.ExceptKey;
            newitem.name = dto.ExceptName;
            tlist.Add(newitem);
        }

        CurrentExceptDept = tlist;
        RadGrid2.DataSource = CurrentExceptDept;
        RadGrid2.DataBind();
    }

    private void ReadSendMonth()
    {
        List<AutoEduFormTemplateExceptDto> list = service.GetAutoEduFormSettingSendMonth(CurrentAutoFTListID);
        
        CurrentSendMonth = list;
        rgSendMonth.DataSource = CurrentSendMonth;
        rgSendMonth.DataBind();
    }

    private void ReadSendDept()
    {
        List<AutoEduFormTemplateExceptDto> list = service.GetAutoEduFormSettingSendDept(CurrentAutoFTListID);
        List<SelectGroupTypeDto> tlist = new List<SelectGroupTypeDto>();
        foreach (AutoEduFormTemplateExceptDto dto in list)
        {
            SelectGroupTypeDto newitem = new SelectGroupTypeDto();
            newitem.code = dto.ExceptKey;
            newitem.name = dto.ExceptName;
            tlist.Add(newitem);
        }

        CurrentSendDept = tlist;
        RadGrid3.DataSource = CurrentSendDept;
        RadGrid3.DataBind();
    }


    private void ReadSendTerm()
    {
        
        List<AutoEduFormTemplateExceptDto> list = service.GetAutoEduFormSettingSendTermList(CurrentAutoFTListID);
        List<EduTermDto> tlist = new List<EduTermDto>();
        foreach (AutoEduFormTemplateExceptDto dto in list)
        {
            EduTermDto newitem = new EduTermDto();
            newitem.EduTermID = dto.ExceptKey;
            newitem.Name = dto.ExceptName;
            tlist.Add(newitem);
        }

        CurrentSendTerm = tlist;
        rgSendTerm.DataSource = CurrentSendTerm;
        rgSendTerm.DataBind();
    }

    private void ReadNoSendTerm()
    {

        List<AutoEduFormTemplateExceptDto> list = service.GetAutoEduFormSettingNoSendTermList(CurrentAutoFTListID);
        List<EduTermDto> tlist = new List<EduTermDto>();
        foreach (AutoEduFormTemplateExceptDto dto in list)
        {
            EduTermDto newitem = new EduTermDto();
            newitem.EduTermID = dto.ExceptKey;
            newitem.Name = dto.ExceptName;
            tlist.Add(newitem);
        }

        CurrentNoSendTerm = tlist;
        rgNoSendTerm.DataSource = CurrentNoSendTerm;
        rgNoSendTerm.DataBind();
    }

    private void BindDept()
    {
        List<SelectGroupTypeDto> list = service.GetTermUnit("EduAct_Dept");
        ddlUnit.DataValueField = "code";
        ddlUnit.DataTextField = "Name";
        ddlUnit.DataSource = list;
        ddlUnit.DataBind();
        ddlSendUnit.DataValueField = "code";
        ddlSendUnit.DataTextField = "Name";
        ddlSendUnit.DataSource = list;
        ddlSendUnit.DataBind();
    }

    private void ReadSetting()
    {
        AutoEduFormTemplateListDto setting = service.GetAutoEduFormTemplateList(CurrentAutoFTListID);

        foreach (RadTreeNode node in RadTreeView1.GetAllNodes())
        {
            if (node.Value == setting.TEMPLATE_ID.ToString())
            {
                node.Selected = true;
                ClearFields();
                RefreshRoleSetting();
                RadGrid1.DataBind();

                btnPreview.NavigateUrl = "EduFormPreview.aspx?template_id=" + node.Value;

                break;
            }
        }
        TreeViewComboBox1.SelectedValue = setting.JobCode;
        TreeViewComboBox1.SelectedText = setting.JobName;
        tbEduYear.Text = setting.EduYear;
        tbName.Text = setting.SettingName;
        rntbSendFloor.Value = setting.SendFloor;

        ddlShiftDayType.SelectedValue = setting.DateShiftType;
        rntbShiftDays.Value = setting.DateShift;
        cbEach.Checked = setting.EachStudent.Value;
        rbSendOrderSetting.SelectedValue = setting.SendOrderSetting;
        rdpSdate.SelectedDate = setting.Sdate;
        rdpEdate.SelectedDate = setting.Edate;
        
        List<AutoEduFormTemplateTargetDto> list = service.GetAutoEduFormTemplateTargets(CurrentAutoFTListID);


        foreach (AutoEduFormTemplateTargetDto dto in list)
        {
            if (dto.RoleType == "T" && dto.TeacherType != null)
            {
                ddlTeacherType.SelectedValue = dto.TeacherType;
            }
            if (palSettingFix.Visible)
            {
                foreach (FormTargetSetting set in CurrentSetting)
                {
                    if (set.SettingCode == dto.RoleType)
                    {
                        set.UserDefineTargetID = dto.UserDefineTargetID;
                        set.ExpireDays = dto.ExpireDays;
                        set.ExpireDaysType = dto.ExpireDaysType;
                    }

                }
            }
            else
            {

                FormTargetSetting set = new FormTargetSetting();
                set.ExpireDays = dto.ExpireDays;
                set.SettingCode = dto.RoleType;
                foreach (ListItem sendtype in ddlSendType.Items)
                {
                    if (sendtype.Value == set.SettingCode)
                    {
                        set.SettingName = sendtype.Text;
                    }
                }
                set.Group = CurrentParentNode.Text;
                set.TemplateID = dto.SubTEMPLATE_ID;
                set.UserDefineTargetID = dto.UserDefineTargetID;
                set.ExpireDaysType = dto.ExpireDaysType;
                CurrentSetting.Add(set);
            }

        }
        RadGrid1.DataBind();

        if (palSettingFix.Visible)
        {
            foreach (AutoEduFormTemplateTargetDto dto in list)
            {
                foreach (GridDataItem item in RadGrid1.Items)
                {
                    if (CurrentSetting[item.DataSetIndex].SettingCode == dto.RoleType)
                    {
                        item.Selected = true;
                    }
                }
            }
        }

    }

    private void BindTeacherType()
    {
        List<EduTeacherTypeDto> list = service.GetTeacherTypes();
        ddlTeacherType.DataValueField = "code";
        ddlTeacherType.DataTextField = "name";
        ddlTeacherType.DataSource = list;
        ddlTeacherType.DataBind();
        ddlTeacherType.SelectedIndex = 0;

        EduTeacherTypeDto newitem = new EduTeacherTypeDto();
        newitem.Code = "S";
        newitem.Name = "學員";
        list.Add(newitem);

        ddlSendType.DataValueField = "code";
        ddlSendType.DataTextField = "name";
        ddlSendType.DataSource = list;
        ddlSendType.DataBind();
        ddlSendType.SelectedIndex = 0;
    }

    protected void ReloadList()
    {
        //BSC固定用EduActivity分類
        List<FORM_TEMPLATEDto> list = service.GetFormTemplatesByJobCode(null, this.HospCode);
        //List<HtmlFormUtility.FORM_TEMPLATES> list = vc.ListFormTemplatesByCategory("EduActivity", this.HospCode).OrderBy(c => c.TEMPLATE_ID).ToList();

        CurrentTemplateList = list;

        RadTreeView1.DataSource = list;

        RadTreeView1.DataBind();

        //RadTreeView1.ExpandAllNodes();
    }


    private void ClearFields()
    {
        //tbName.Text = "";
        //ddlShiftDayType.SelectedIndex = 0;
        //rntbShiftDays.Value = 0;
        CurrentSetting = new List<FormTargetSetting>();
        RadGrid1.DataSource = null;
        RadGrid1.DataBind();
    }

    protected void RadTreeView1_NodeClick(object sender, Telerik.Web.UI.RadTreeNodeEventArgs e)
    {
        ClearFields();
        RefreshRoleSetting();
        RadGrid1.DataBind();

        btnPreview.NavigateUrl = "EduFormPreview.aspx?template_id=" + e.Node.Value;
    }


    private bool CheckInput()
    {
        if (TreeViewComboBox1.SelectedValue == null || TreeViewComboBox1.SelectedValue == "")
        {
            ShowMessage("未選擇職稱!");
            return false;
        }

        if (rntbShiftDays.Value == null)
        {
            ShowMessage("未設定發送日!");
            return false;
        }

        if (CurrentSetting == null || CurrentSetting.Count == 0)
        {
            ShowMessage("未設定發送對象!");
            return false;
        }

        if (CurrentParentNode.Nodes.Count > 0 && CurrentSetting.Count != CurrentParentNode.Nodes.Count)
        {
            ShowMessage("設定發送對象數與子表單數不符");
            return false;
        }

        return true;
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string listid = "";
        if (CurrentAutoFTListID == null)
        {
            listid = service.GetSerialNo("EduAct_AutoEduFTListID");
        }
        else
        {
            listid = CurrentAutoFTListID;
        }

        if (CurrentParentNode != null)
        {
            if (!CheckInput())
            {
                return;
            }

            int templateId = Convert.ToInt32(CurrentParentNode.Value);
            string name = CurrentParentNode.Text;
            FORM_TEMPLATEDto temp = CurrentTemplateList.Where(c => c.TEMPLATE_ID == templateId).FirstOrDefault();
            AutoEduFormTemplateListDto dto = new AutoEduFormTemplateListDto();
            dto.AutoFTListID = listid;
            int? sendfloor = null;
            if (rntbSendFloor.Value != null)
            {
                sendfloor = Convert.ToInt32(rntbSendFloor.Value);
            }
            else
            {
                sendfloor = null;
            }
            dto.EduYear = tbEduYear.Text;
            dto.SendFloor = sendfloor;
            dto.TEMPLATE_ID = templateId;
            dto.SettingName = tbName.Text;
            dto.DateShift = Convert.ToInt32(rntbShiftDays.Value);
            dto.DateShiftType = ddlShiftDayType.SelectedValue;
            dto.EachStudent = cbEach.Checked;
            dto.JobCode = TreeViewComboBox1.SelectedValue.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList().FirstOrDefault();
            dto.MultiTarget = palSettingMultiTarget.Visible;
            dto.TeacherType = ddlTeacherType.SelectedValue;
            dto.Creater = this.EmpCode;
            dto.SendOrderSetting = rbSendOrderSetting.SelectedValue;
            dto.Sdate = rdpSdate.SelectedDate;
            dto.Edate = rdpEdate.SelectedDate;


            List<AutoEduFormTemplateTargetDto> tlist = new List<AutoEduFormTemplateTargetDto>();


            GridItemCollection coll = new GridItemCollection();
            if (palSettingFix.Visible)
            {
                if (CurrentParentNode.Nodes.Count == 0)
                {
                    coll = RadGrid1.SelectedItems;
                }
                else
                {
                    coll = RadGrid1.Items;
                }
            }
            else
            {
                coll = RadGrid1.Items;
            }

            int settingcount = 0;
            foreach (GridDataItem item in coll)
            {
                string targetid = service.GetSerialNo("EduAct_AutoEduFTTargetID");
                FormTargetSetting setting = CurrentSetting[item.DataSetIndex];
                AutoEduFormTemplateTargetDto tdto = new AutoEduFormTemplateTargetDto();

                RadNumericTextBox expireday = item.FindControl("rntbExpireDays") as RadNumericTextBox;
                TextBox tbtarget = item.FindControl("tbUDTarget") as TextBox;
                DropDownList expiredaytype = item.FindControl("ddlExpireDayType") as DropDownList;

                tdto.AutoFTTargetID = targetid;
                tdto.AutoFTListID = listid;
                tdto.ExpireDays = Convert.ToInt32(expireday.Value);
                tdto.RoleType = setting.SettingCode;
                if ((CurrentParentNode.Nodes.Count > 2 || temp.IS_USER_DEFINE_TARGET) && CurrentParentNode.Nodes.Count > 0)
                {
                    tdto.SubTEMPLATE_ID = Convert.ToInt32(CurrentParentNode.Nodes[settingcount].Value);
                }
                else
                {
                    tdto.SubTEMPLATE_ID = setting.TemplateID;
                }
                
                tdto.UserDefineTargetID = tbtarget.Text.Trim() == "" ? null : tbtarget.Text.Trim();
                tdto.ExpireDaysType = expiredaytype.SelectedValue;
                if (setting.SettingCode == "T")
                {
                    tdto.TeacherType = ddlTeacherType.SelectedValue;
                }
                tlist.Add(tdto);
                settingcount++;
            }


            string msg = service.SaveAutoEduFormSetting(dto, tlist);
            service.SaveAutoEduFormSettingExceptList(dto.AutoFTListID, CurrentExceptDept);
            service.SaveAutoEduFormSettingSendDeptList(dto.AutoFTListID, CurrentSendDept);
            service.SaveAutoEduFormSettingSendTermList(dto.AutoFTListID, CurrentSendTerm);
            service.SaveAutoEduFormSettingNoSendTermList(dto.AutoFTListID, CurrentNoSendTerm);
            service.SaveAutoEduFormSettingSendMonthList(dto.AutoFTListID, CurrentSendMonth);


            if (msg != null)
            {
                ShowMessage(msg);
            }
            else
            {

                CloseWindow(false);
            }
        }

    }

    private RadTreeNode CurrentParentNode
    {
        get
        {
            RadTreeNode cnode = null;

            if (RadTreeView1.SelectedNode == null)
            {
                return cnode;
            }

            if (RadTreeView1.SelectedNode.ParentNode != null)
            {
                cnode = RadTreeView1.SelectedNode.ParentNode;
            }
            else
            {
                cnode = RadTreeView1.SelectedNode;
            }
            return cnode;
        }
    }

    private void RefreshRoleSetting()
    {
        if (RadTreeView1.SelectedNode != null)
        {
            RadTreeNode cnode = CurrentParentNode;

            List<RadTreeNode> coll = new List<RadTreeNode>();
            coll.Add(cnode.Clone());

            List<FormTargetSetting> list = new List<FormTargetSetting>();

            FORM_TEMPLATEDto temp = CurrentTemplateList.Where(c => c.TEMPLATE_ID == Convert.ToInt32(cnode.Value)).FirstOrDefault();

            if (temp.IsMultiTargetForm)
            {
                palSettingMultiTarget.Visible = true;
                palSettingFix.Visible = false;
                RadGrid1.Columns[0].Visible = false;
                RadGrid1.Columns[5].Visible = true;
            }
            else
            {
                palSettingMultiTarget.Visible = false;
                palSettingFix.Visible = true;
                
                if (cnode.Nodes.Count > 0)
                {
                    if (temp.IS_USER_DEFINE_TARGET || cnode.Nodes.Count >2)
                    {
                        palSettingMultiTarget.Visible = true;
                        palSettingFix.Visible = false;
                        RadGrid1.Columns[0].Visible = false;
                        RadGrid1.Columns[5].Visible = true;
                    }
                    else
                    {
                        RadGrid1.Columns[0].Visible = false;
                        RadGrid1.Columns[5].Visible = false;
                        foreach (RadTreeNode node in coll)
                        {
                            if (cnode.Nodes[0].Text.EndsWith("老師") || cnode.Nodes[0].Text.EndsWith("教師"))
                            {
                                FormTargetSetting setting = new FormTargetSetting();
                                setting.Group = node.Text;
                                setting.SettingCode = "T";
                                setting.SettingName = "教師";
                                setting.TemplateID = Convert.ToInt32(node.Nodes[0].Value);
                                list.Add(setting);
                                setting = new FormTargetSetting();
                                setting.Group = node.Text;
                                setting.SettingCode = "S";
                                setting.SettingName = "學生";
                                setting.TemplateID = Convert.ToInt32(node.Nodes[1].Value);
                                list.Add(setting);
                            }
                            else
                            {
                                FormTargetSetting setting = new FormTargetSetting();
                                setting.Group = node.Text;
                                setting.SettingCode = "S";
                                setting.SettingName = "學員";
                                setting.TemplateID = Convert.ToInt32(node.Nodes[0].Value);
                                list.Add(setting);
                                setting = new FormTargetSetting();
                                setting.Group = node.Text;
                                setting.SettingCode = "T";
                                setting.SettingName = "教師";
                                setting.TemplateID = Convert.ToInt32(node.Nodes[1].Value);
                                list.Add(setting);
                            }

                            //FormTargetSetting setting = new FormTargetSetting();
                            //setting.Group = node.Text;
                            //setting.SettingCode = "S";
                            //setting.SettingName = "學員";
                            //setting.TemplateID = Convert.ToInt32(node.Nodes[0].Value);
                            //list.Add(setting);
                            //setting = new FormTargetSetting();
                            //setting.Group = node.Text;
                            //setting.SettingCode = "T";
                            //setting.SettingName = "教師";
                            //setting.TemplateID = Convert.ToInt32(node.Nodes[1].Value);
                            //list.Add(setting);
                        }
                        
                    }
                    cbEach.Visible = false;
                }
                else
                {
                    RadGrid1.Columns[0].Visible = true;
                    RadGrid1.Columns[5].Visible = false;
                    foreach (RadTreeNode node in coll)
                    {

                        FormTargetSetting setting = new FormTargetSetting();
                        setting.Group = node.Text;
                        setting.SettingCode = "S";
                        setting.SettingName = "學員";
                        setting.TemplateID = Convert.ToInt32(node.Value);
                        list.Add(setting);
                        setting = new FormTargetSetting();
                        setting.Group = node.Text;
                        setting.SettingCode = "T";
                        setting.SettingName = "教師";
                        setting.TemplateID = Convert.ToInt32(node.Value);
                        list.Add(setting);
                    }
                    cbEach.Visible = true;
                }


            }

            CurrentSetting = list;

            RadGrid1.DataSource = CurrentSetting;
        }
    }

    protected void RadGrid1_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        RadGrid1.MasterTableView.DataKeyNames = new string[] { "SettingCode", "Group" };
        RadGrid1.DataSource = CurrentSetting;

    }

    protected void RadGrid1_UpdateCommand(object sender, GridCommandEventArgs e)
    {
        FormTargetSetting setting = CurrentSetting[e.Item.DataSetIndex];

        GridEditableItem editedItem = e.Item as GridEditableItem;
        Dictionary<string, object> newValues = new Dictionary<string, object>();
        e.Item.OwnerTableView.ExtractValuesFromItem(newValues, editedItem);

        List<FormTargetSetting> list = CurrentSetting;

        string setcode = e.Item.OwnerTableView.Items[e.Item.DataSetIndex].GetDataKeyValue("SettingCode").ToString();
        string group = e.Item.OwnerTableView.Items[e.Item.DataSetIndex].GetDataKeyValue("Group").ToString();

        if (palSettingFix.Visible)
        {

            FormTargetSetting sett = list.Where(c => c.SettingCode == setcode && c.Group == group).FirstOrDefault();
            if (sett != null)
            {
                //sett.IsChecked = Convert.ToBoolean(newValues["IsChecked"]);
                if (newValues["ExpireDate"] == null)
                {
                    sett.ExpireDate = null;
                }
                else
                {
                    sett.ExpireDate = Convert.ToDateTime(newValues["ExpireDate"]);
                }

                CurrentSetting = list;
                RadGrid1.DataSource = CurrentSetting;
                RadGrid1.DataBind();
            }
        }
        else
        {
            foreach (FormTargetSetting sett in list)
            {
                //sett.IsChecked = Convert.ToBoolean(newValues["IsChecked"]);
                if (newValues["ExpireDate"] == null)
                {
                    sett.ExpireDate = null;
                }
                else
                {
                    sett.ExpireDate = Convert.ToDateTime(newValues["ExpireDate"]);
                }
            }

            CurrentSetting = list;
            RadGrid1.DataSource = CurrentSetting;
            RadGrid1.DataBind();
        }
    }
        //修改group header

    protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridGroupHeaderItem)
        {
            (e.Item as GridGroupHeaderItem).DataCell.Text = (e.Item as GridGroupHeaderItem).DataCell.Text.Substring((e.Item as GridGroupHeaderItem).DataCell.Text.IndexOf("-") + 1);
        }
    }

    protected void lbtnNodeClick_Click(object sender, EventArgs e)
    {
        ClearFields();
        RefreshRoleSetting();
        RadGrid1.DataBind();
    }
    

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        List<FormTargetSetting> list = CurrentSetting;

        FormTargetSetting setting = new FormTargetSetting();
        setting.Group = CurrentParentNode.Text;
        setting.SettingCode = ddlSendType.SelectedValue;
        setting.SettingName = ddlSendType.SelectedItem.Text;

        if (CurrentParentNode.Nodes.Count > 0 && CurrentSetting.Count >= CurrentParentNode.Nodes.Count)
        {
            ShowMessage("設定發送對象數量超過表單數");
            return;
        }

        setting.TemplateID = Convert.ToInt32(CurrentParentNode.Value);
        list.Add(setting);

        CurrentSetting = list;
        RadGrid1.DataSource = CurrentSetting;
        RadGrid1.DataBind();
    }

    protected void dsJobCode_Selected(object sender, ObjectDataSourceStatusEventArgs e)
    {
        ViewState["CurrentJobCode"] = e.ReturnValue as List<V_CodeRefDto>;
    }
    protected void RadGrid1_ItemCreated(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            FormTargetSetting sett = CurrentSetting[e.Item.DataSetIndex];

            DropDownList list = e.Item.FindControl("ddlExpireDayType") as DropDownList;
            list.SelectedValue = sett.ExpireDaysType;
        }
        //e.Item.
    }
    protected void btnSaveAs_Click(object sender, EventArgs e)
    {
        string listid = "";
        listid = service.GetSerialNo("EduAct_AutoEduFTListID");
        
        
        if (CurrentParentNode != null)
        {
            if (!CheckInput())
            {
                return;
            }

            int templateId = Convert.ToInt32(CurrentParentNode.Value);
            string name = CurrentParentNode.Text;

            AutoEduFormTemplateListDto dto = new AutoEduFormTemplateListDto();
            dto.AutoFTListID = listid;
            int? sendfloor = null;
            if (rntbSendFloor.Value != null)
            {
                sendfloor = Convert.ToInt32(rntbSendFloor.Value);
            }
            else
            {
                sendfloor = null;
            }
            dto.EduYear = tbEduYear.Text;
            dto.SendFloor = sendfloor;
            dto.TEMPLATE_ID = templateId;
            dto.SettingName = tbName.Text;
            dto.DateShift = Convert.ToInt32(rntbShiftDays.Value);
            dto.DateShiftType = ddlShiftDayType.SelectedValue;
            dto.EachStudent = cbEach.Checked;
            dto.JobCode = TreeViewComboBox1.SelectedValue;
            dto.MultiTarget = palSettingMultiTarget.Visible;
            dto.TeacherType = ddlTeacherType.SelectedValue;
            dto.Creater = this.EmpCode;
            dto.SendOrderSetting = rbSendOrderSetting.SelectedValue;
            dto.Sdate = rdpSdate.SelectedDate;
            dto.Edate = rdpEdate.SelectedDate;


            List<AutoEduFormTemplateTargetDto> tlist = new List<AutoEduFormTemplateTargetDto>();


            GridItemCollection coll = new GridItemCollection();
            if (palSettingFix.Visible)
            {
                if (CurrentParentNode.Nodes.Count == 0)
                {
                    coll = RadGrid1.SelectedItems;
                }
                else
                {
                    coll = RadGrid1.Items;
                }
            }
            else
            {
                coll = RadGrid1.Items;
            }

            int settingcount = 0;

            foreach (GridDataItem item in coll)
            {
                string targetid = service.GetSerialNo("EduAct_AutoEduFTTargetID");
                FormTargetSetting setting = CurrentSetting[item.DataSetIndex];
                AutoEduFormTemplateTargetDto tdto = new AutoEduFormTemplateTargetDto();

                RadNumericTextBox expireday = item.FindControl("rntbExpireDays") as RadNumericTextBox;
                TextBox tbtarget = item.FindControl("tbUDTarget") as TextBox;
                DropDownList expiredaytype = item.FindControl("ddlExpireDayType") as DropDownList;

                tdto.AutoFTTargetID = targetid;
                tdto.AutoFTListID = listid;
                tdto.ExpireDays = Convert.ToInt32(expireday.Value);
                tdto.RoleType = setting.SettingCode;
                if (CurrentParentNode.Nodes.Count > 2)
                {
                    tdto.SubTEMPLATE_ID = Convert.ToInt32(CurrentParentNode.Nodes[settingcount].Value);
                }
                else
                {
                    tdto.SubTEMPLATE_ID = setting.TemplateID;
                }
                tdto.UserDefineTargetID = tbtarget.Text.Trim() == "" ? null : tbtarget.Text.Trim();
                tdto.ExpireDaysType = expiredaytype.SelectedValue;
                if (setting.SettingCode == "T")
                {
                    tdto.TeacherType = ddlTeacherType.SelectedValue;
                }
                tlist.Add(tdto);
                settingcount++;
            }


            string msg = service.SaveAutoEduFormSetting(dto, tlist);

            service.SaveAutoEduFormSettingExceptList(dto.AutoFTListID, CurrentExceptDept);
            service.SaveAutoEduFormSettingSendTermList(dto.AutoFTListID, CurrentSendTerm);
            service.SaveAutoEduFormSettingSendDeptList(dto.AutoFTListID, CurrentSendDept);
            service.SaveAutoEduFormSettingNoSendTermList(dto.AutoFTListID, CurrentNoSendTerm);
            service.SaveAutoEduFormSettingSendMonthList(dto.AutoFTListID, CurrentSendMonth);

            if (msg != null)
            {
                ShowMessage(msg);
            }
            else
            {

                CloseWindow(false);
            }
        }
    }
    protected void RadGrid2_DeleteCommand(object sender, GridCommandEventArgs e)
    {
        string code = (e.Item as GridDataItem).GetDataKeyValue("Code").ToString();

        for (int i = 0; i < CurrentExceptDept.Count; i++)
        {
            if (CurrentExceptDept[i].code == code)
            {
                CurrentExceptDept.RemoveAt(i);
                break;
            }
        }

        RadGrid2.DataSource = CurrentExceptDept;
        RadGrid2.DataBind();

    }
    protected void btnAddExceptDept_Click(object sender, ImageClickEventArgs e)
    {
        List<SelectGroupTypeDto> list = CurrentExceptDept;

        if (CurrentExceptDept.Count(c => c.code == ddlUnit.SelectedValue) == 0)
        {
            SelectGroupTypeDto setting = new SelectGroupTypeDto();
            setting.code = ddlUnit.SelectedValue;
            setting.name = ddlUnit.SelectedItem.Text;
            list.Add(setting);

            CurrentExceptDept = list;
            RadGrid2.DataSource = CurrentExceptDept;
            RadGrid2.DataBind();
        }
    }
    protected void btnAddSendTerm_Click(object sender, ImageClickEventArgs e)
    {
        List<EduTermDto> list = CurrentSendTerm;

        foreach (EduTermDto selecteditem in EduTermSelect1.SelectedEduTerms)
        {
            if (CurrentSendTerm.Count(c => c.EduTermID == selecteditem.EduTermID) == 0)
            {
                EduTermDto setting = new EduTermDto();
                setting.EduTermID = selecteditem.EduTermID;
                setting.Name = selecteditem.Name;
                list.Add(setting);

                CurrentSendTerm = list;
                rgSendTerm.DataSource = CurrentSendTerm;
                rgSendTerm.DataBind();
            }
        }
    }
    protected void rgSendTerm_DeleteCommand(object sender, GridCommandEventArgs e)
    {
        string code = (e.Item as GridDataItem).GetDataKeyValue("EduTermID").ToString();

        for (int i = 0; i < CurrentSendTerm.Count; i++)
        {
            if (CurrentSendTerm[i].EduTermID == code)
            {
                CurrentSendTerm.RemoveAt(i);
                break;
            }
        }

        rgSendTerm.DataSource = CurrentSendTerm;
        rgSendTerm.DataBind();
    }
    protected void btnAddSendDept_Click(object sender, ImageClickEventArgs e)
    {
        List<SelectGroupTypeDto> list = CurrentSendDept;

        if (CurrentSendDept.Count(c => c.code == ddlSendUnit.SelectedValue) == 0)
        {
            SelectGroupTypeDto setting = new SelectGroupTypeDto();
            setting.code = ddlSendUnit.SelectedValue;
            setting.name = ddlSendUnit.SelectedItem.Text;
            list.Add(setting);

            CurrentSendDept = list;
            RadGrid3.DataSource = CurrentSendDept;
            RadGrid3.DataBind();
        }
    }
    protected void RadGrid3_DeleteCommand(object sender, GridCommandEventArgs e)
    {
        string code = (e.Item as GridDataItem).GetDataKeyValue("Code").ToString();

        for (int i = 0; i < CurrentSendDept.Count; i++)
        {
            if (CurrentSendDept[i].code == code)
            {
                CurrentSendDept.RemoveAt(i);
                break;
            }
        }

        RadGrid3.DataSource = CurrentSendDept;
        RadGrid3.DataBind();
    }
    protected void rgNoSendTerm_DeleteCommand(object sender, GridCommandEventArgs e)
    {
        string code = (e.Item as GridDataItem).GetDataKeyValue("EduTermID").ToString();

        for (int i = 0; i < CurrentNoSendTerm.Count; i++)
        {
            if (CurrentNoSendTerm[i].EduTermID == code)
            {
                CurrentNoSendTerm.RemoveAt(i);
                break;
            }
        }

        rgNoSendTerm.DataSource = CurrentNoSendTerm;
        rgNoSendTerm.DataBind();
    }
    protected void btnAddNoSendTerm_Click(object sender, ImageClickEventArgs e)
    {
        List<EduTermDto> list = CurrentNoSendTerm;

        foreach (EduTermDto selecteditem in EduTermSelect2.SelectedEduTerms)
        {
            if (CurrentExceptDept.Count(c => c.code == selecteditem.EduTermID) == 0)
            {
                EduTermDto setting = new EduTermDto();
                setting.EduTermID = selecteditem.EduTermID;
                setting.Name = selecteditem.Name;
                list.Add(setting);

                CurrentNoSendTerm = list;
                rgNoSendTerm.DataSource = CurrentNoSendTerm;
                rgNoSendTerm.DataBind();
            }
        }
    }
    protected void rgSendMonth_DeleteCommand(object sender, GridCommandEventArgs e)
    {
        string code = (e.Item as GridDataItem).GetDataKeyValue("ExceptKey").ToString();

        for (int i = 0; i < CurrentSendMonth.Count; i++)
        {
            if (CurrentSendMonth[i].ExceptKey == code)
            {
                CurrentSendMonth.RemoveAt(i);
                break;
            }
        }

        rgSendMonth.DataSource = CurrentSendMonth;
        rgSendMonth.DataBind();
    }
    protected void btnAddSendMonth_Click(object sender, ImageClickEventArgs e)
    {
        List<AutoEduFormTemplateExceptDto> list = CurrentSendMonth;

        if (CurrentSendMonth.Count(c => c.ExceptKey == rcbMonth.SelectedValue) == 0)
        {
            AutoEduFormTemplateExceptDto setting = new AutoEduFormTemplateExceptDto();
            setting.ExceptKey = rcbMonth.SelectedValue;
            list.Add(setting);

            CurrentSendMonth = list;
            rgSendMonth.DataSource = CurrentSendMonth;
            rgSendMonth.DataBind();
        }
    }
    protected void RadGrid1_DeleteCommand(object sender, GridCommandEventArgs e)
    {

        List<FormTargetSetting> list = CurrentSetting;

        list.RemoveAt(e.Item.ItemIndex);
        
        CurrentSetting = list;
        RadGrid1.DataSource = CurrentSetting;
        RadGrid1.DataBind();
    }
}