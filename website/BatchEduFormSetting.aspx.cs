using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using KMU.EduActivity.ApplicationLayer.DTO;
using KMU.EduActivity.DomainModel.Entities;

public partial class BatchEduFormSetting : AuthPage
{
    private HtmlFormUtility.Components.ViewComponent vc = new HtmlFormUtility.Components.ViewComponent();

    private List<string> EduTermID
    {
        get
        {
            return ViewState["BatchEduFormSettingCurrentEduTermIDs"] as List<string>;
        }
        set
        {
            ViewState["BatchEduFormSettingCurrentEduTermIDs"] = value;
        }
    }

    private List<EduTermDto> CurrentEduTerms
    {
        get
        {
            return ViewState["BatchEduFormSettingCurrentEduTerm"] as List<EduTermDto>;
        }
        set
        {
            ViewState["BatchEduFormSettingCurrentEduTerm"] = value;
        }
    }

    private List<FORM_TEMPLATEDto> CurrentTemplateList
    {
        get
        {
            return Session["BatchFormSettingTemplateList"] as List<FORM_TEMPLATEDto>;
        }
        set
        {
            Session["BatchFormSettingTemplateList"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        TreeViewComboBox2.SelectedChanged += new EventHandler(TreeViewComboBox2_SelectedChanged);
        if (!IsPostBack)
        {
            if (Session["BatchEduFormSettingCurrentEduTerm"] != null)
            {
                EduTermID = Session["BatchEduFormSettingCurrentEduTerm"] as List<string>;
                Session["BatchEduFormSettingCurrentEduTerm"] = null;
            }

            if (EduTermID.Count == 0)
            {
                ShowMessageAndGo("資料傳遞錯誤!", "EduTerm.aspx");
                return;
            }

            LoadEduTerm();
            BindTeacherType();
            ReloadList();
            ClearFields();

        }

    }

    private void LoadEduTerm()
    {
        if (EduTermID.Count > 0)
        {
            EduTermDto dto = service.ReadEduTermById(EduTermID[0]);

            TreeViewComboBox2.SelectedValue = dto.JobCode;

            TreeViewComboBox2.SelectedText = service.GetCodeRefs("EduAct_JobSerial").Where(c => c.Code == dto.JobCode).FirstOrDefault().Name;
        }

    }

    protected void TreeViewComboBox2_SelectedChanged(object sender, EventArgs e)
    {
        ReloadList();
        ClearFields();
        RefreshRoleSetting();
        RadGrid1.DataBind();

        btnPreview.NavigateUrl = "";
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
        List<FORM_TEMPLATEDto> list = service.GetFormTemplatesByJobCode(TreeViewComboBox2.SelectedValue, this.HospCode);
            //vc.ListFormTemplatesByCategory("EduActivity").OrderByDescending(c => c.TEMPLATE_NAME).ToList();

        CurrentTemplateList = list;
        RadTreeView1.Nodes.Clear();
        RadTreeView1.DataSource = null;


        RadTreeView1.DataSource = list;

        RadTreeView1.DataBind();

        //RadTreeView1.ExpandAllNodes();
    }

    private List<FormTargetSetting> CurrentSetting
    {
        get
        {
            return Session["CurrentSetting"] as List<FormTargetSetting>;
        }
        set
        {
            Session["CurrentSetting"] = value;
        }
    }

    private void ClearFields()
    {
        tbName.Text = "";
        rdpExecuteDate.MinDate = DateTime.Now.AddDays(1).Date;
        rdpExecuteDate.SelectedDate = null;
        rbNone.Checked = true;
        rntbDay.Value = null;
        cb1.Checked = false;
        cb2.Checked = false;
        cb3.Checked = false;
        cb4.Checked = false;
        cb5.Checked = false;
        cb6.Checked = false;
        cb7.Checked = false;
        ddlweek.SelectedIndex = 0;
        ddlspecweekday.SelectedIndex = 0;
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
        if (rbSetDate.Checked && rdpExecuteDate.SelectedDate == null)
        {
            ShowMessage("未輸入執行日期!");
            return false;
        }

        if (rbMonth.Checked && rntbDay.Value == null)
        {
            ShowMessage("未設定每月日期");
            return false;
        }

        if (rbWeek.Checked && (!cb1.Checked && !cb2.Checked && !cb3.Checked && !cb4.Checked && !cb5.Checked && !cb6.Checked && !cb7.Checked))
        {
            ShowMessage("未選擇星期");
            return false;
        }

        if (CurrentSetting == null || CurrentSetting.Count == 0)
        {
            ShowMessage("未設定發送對象");
            return false;
        }

        if (CurrentParentNode.Nodes.Count == 0 && RadGrid1.SelectedItems.Count == 0)
        {
            ShowMessage("未選擇發送對象");
            return false;
        }

        return true;
    }


    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (CurrentParentNode != null)
        {
            if (!CheckInput())
            {
                return;
            }

            foreach (string edutermid in EduTermID)
            {

                int templateId = Convert.ToInt32(CurrentParentNode.Value);
                string name = CurrentParentNode.Text;
                string listid = service.GetSerialNo("EduAct_EduFTListID");
                EduFormTemplateListDto dto = new EduFormTemplateListDto();
                dto.FTListID = listid;
                if (rbSetDate.Checked)
                {
                    dto.ExecuteDate = rdpExecuteDate.SelectedDate.Value;
                }
                else
                {
                    dto.ExecuteDate = DateTime.Now;
                }
                dto.TEMPLATE_ID = templateId;
                dto.EduTermID = edutermid;
                dto.Name = tbName.Text;
                dto.Creater = this.EmpCode;
                //TempoType 
                //0 : 不重複
                //1 : 每日
                //2 : 每月__日
                //3 : 每星期__
                //4 : 每月第__週星期__

                if (rbNone.Checked)
                {
                    dto.TempoType = "0";
                }
                if (rbDay.Checked)
                {
                    dto.TempoType = "1";
                }
                if (rbMonth.Checked)
                {
                    dto.TempoType = "2";
                    dto.TempoSettings = rntbDay.Value.Value.ToString();
                }
                if (rbWeek.Checked)
                {
                    dto.TempoType = "3";
                    string weekstr = "";
                    if (cb1.Checked)
                    {
                        weekstr += "1,";
                    }
                    if (cb2.Checked)
                    {
                        weekstr += "2,";
                    }
                    if (cb3.Checked)
                    {
                        weekstr += "3,";
                    }
                    if (cb4.Checked)
                    {
                        weekstr += "4,";
                    }
                    if (cb5.Checked)
                    {
                        weekstr += "5,";
                    }
                    if (cb6.Checked)
                    {
                        weekstr += "6,";
                    }
                    if (cb7.Checked)
                    {
                        weekstr += "7,";
                    }
                    dto.TempoSettings = weekstr.Substring(0, weekstr.Length - 1);
                }
                if (rbSpecDay.Checked)
                {
                    dto.TempoType = "4";
                    dto.TempoSettings = ddlweek.SelectedValue;
                    dto.TempoSettings += "," + ddlspecweekday.SelectedValue;
                }
                AutoEduFormTemplateListDto atdto = new AutoEduFormTemplateListDto();
                atdto.Creater = this.EmpCode;
                atdto.MultiTarget = palSettingMultiTarget.Visible;
                atdto.TeacherType = ddlTeacherType.SelectedValue;
                atdto.TEMPLATE_ID = templateId;
                atdto.EachStudent = cbEach.Checked;
                List<AutoEduFormTemplateTargetDto> attdtolist = new List<AutoEduFormTemplateTargetDto>();

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

                foreach (GridDataItem item in coll)
                {
                    FormTargetSetting setting = CurrentSetting[item.DataSetIndex];
                    AutoEduFormTemplateTargetDto tdto = new AutoEduFormTemplateTargetDto();

                    RadDatePicker picker = item.FindControl("rdpExpireDate") as RadDatePicker;
                    TextBox tbtarget = item.FindControl("tbUDTarget") as TextBox;


                    tdto.AutoFTListID = listid;
                    if (picker.SelectedDate.HasValue)
                    {
                        TimeSpan ts = picker.SelectedDate.Value - dto.ExecuteDate;
                        tdto.ExpireDays = Convert.ToInt32(ts.TotalDays);
                        tdto.ExpireDaysType = "AfterSend";
                    }
                    tdto.RoleType = setting.SettingCode;
                    tdto.SubTEMPLATE_ID = setting.TemplateID;
                    tdto.UserDefineTargetID = tbtarget.Text.Trim() == "" ? null : tbtarget.Text.Trim();

                    if (setting.SettingCode == "T")
                    {
                        tdto.TeacherType = ddlTeacherType.SelectedValue;
                    }
                    attdtolist.Add(tdto);
                }

                EduTermDto currentEduTerm = service.ReadEduTermById(edutermid);
                dto.CreateSQL = service.GenerateSql(listid, dto.ExecuteDate, currentEduTerm, atdto, attdtolist);//GenerateSql(listid);
                if (rbNow.Checked)
                {
                    dto.Status = 'V';
                }

                List<EduFormTemplateTargetDto> tlist = new List<EduFormTemplateTargetDto>();


                coll = new GridItemCollection();
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

                foreach (GridDataItem item in coll)
                {
                    string targetid = service.GetSerialNo("EduAct_EduFTTargetID");
                    FormTargetSetting setting = CurrentSetting[item.DataSetIndex];
                    EduFormTemplateTargetDto tdto = new EduFormTemplateTargetDto();

                    RadDatePicker picker = item.FindControl("rdpExpireDate") as RadDatePicker;
                    TextBox tbtarget = item.FindControl("tbUDTarget") as TextBox;

                    tdto.FTTargetID = targetid;
                    tdto.FTListID = listid;
                    tdto.ExpireDate = picker.SelectedDate;//setting.ExpireDate;
                    tdto.RoleType = setting.SettingCode;
                    tdto.SubTEMPLATE_ID = setting.TemplateID;
                    tdto.UserDefineTargetID = tbtarget.Text.Trim() == "" ? null : tbtarget.Text.Trim();
                    if (setting.SettingCode == "T")
                    {
                        tdto.TeacherType = ddlTeacherType.SelectedValue;
                    }
                    tlist.Add(tdto);
                }


                string msg = service.SaveEduFormSetting(dto, tlist, rbNow.Checked);
                ShowMessageAndGo("發送完成", "EduTerm.aspx");
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
            }
            else
            {
                palSettingMultiTarget.Visible = false;
                palSettingFix.Visible = true;

                if (cnode.Nodes.Count > 0)
                {
                    RadGrid1.Columns[0].Visible = false;
                    foreach (RadTreeNode node in coll)
                    {
                        if (cnode.Nodes[0].Text.Contains("老師"))
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

                    }
                    cbEach.Visible = false;
                }
                else
                {
                    RadGrid1.Columns[0].Visible = true;
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
        else
        {
            List<FormTargetSetting> list = new List<FormTargetSetting>();
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
    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        e.InputParameters["category"] = "EduActivity";
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        List<FormTargetSetting> list = CurrentSetting;

        FormTargetSetting setting = new FormTargetSetting();
        setting.Group = CurrentParentNode.Text;
        setting.SettingCode = ddlSendType.SelectedValue;
        setting.SettingName = ddlSendType.SelectedItem.Text;
        setting.TemplateID = Convert.ToInt32(CurrentParentNode.Value);
        list.Add(setting);

        CurrentSetting = list;
        RadGrid1.DataSource = CurrentSetting;
        RadGrid1.DataBind();
    }

    protected void btnAddTeacher_Click(object sender, EventArgs e)
    {
        SelectVKmuempData emp = service.ReadVKmuempData(tbTeacherEmpCode.Text);
        if (emp != null)
        {
            lbTeacher.Items.Add(new ListItem(emp.empname, emp.empcode));
            tbTeacherEmpCode.Text = "";
        }
        else
        {
            ShowMessage("員工編號錯誤");
        }
    }
    protected void ddlTeacherType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlTeacherType.SelectedValue == "xxx")
        {
            panUserDefine.Visible = true;
            lbTeacher.Items.Clear();
            tbTeacherEmpCode.Text = "";
        }
        else
        {
            panUserDefine.Visible = false;
        }
    }
    protected void btnDelTeacher_Click(object sender, EventArgs e)
    {
        if (lbTeacher.SelectedItem != null)
        {
            lbTeacher.Items.Remove(lbTeacher.SelectedItem);
        }
    }
    protected void RadGrid2_ItemCreated(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            GridDataItem item = e.Item as GridDataItem;
            string id = null;
            if (item.GetDataKeyValue("AutoFTListID") != null)
            {
                id = item.GetDataKeyValue("AutoFTListID").ToString();
            }

            if (id != null)
            {
                LinkButton lbtnEditTerm = e.Item.FindControl("lbtnEditSetting") as LinkButton;
                if (lbtnEditTerm != null)
                {
                    lbtnEditTerm.OnClientClick = "openEditFormSettingWin('" + id + "');return false;";
                }

            }
        }
    }


}