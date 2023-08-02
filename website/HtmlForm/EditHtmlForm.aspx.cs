using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Net;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Collections.Specialized;
using System.Text;
using HtmlAgilityPack;
using Telerik.Web.UI;

public partial class _Default : AuthPage
{
    private HtmlFormUtility.Components.ViewComponent vc = new HtmlFormUtility.Components.ViewComponent();
    private HtmlFormUtility.Components.ProcessComponent pc = new HtmlFormUtility.Components.ProcessComponent();
    private List<HtmlFormUtility.FORM_TEMPLATE_EXPRESSIONS> CurrentExpressionList
    {
        get
        {
            return Cache["editexpressionlist"] as List<HtmlFormUtility.FORM_TEMPLATE_EXPRESSIONS>;
        }
        set
        {
            Cache["editexpressionlist"] = value;
        }
    }

    private List<HtmlFormUtility.FORM_TEMPLATE_GROUPS> CurrentGroupList
    {
        get
        {
            return Cache["editgrouplist"] as List<HtmlFormUtility.FORM_TEMPLATE_GROUPS>;
        }
        set
        {
            Cache["editgrouplist"] = value;
        }
    }

    private bool IsQuestion
    {
        get
        {
            return Convert.ToBoolean(ViewState["IsQuestion"]);
        }
        set
        {
            ViewState["IsQuestion"] = value;
        }
    }

    private int TemplateID
    {
        get
        {
            return Convert.ToInt32(Request.QueryString["template_id"]);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (Session["template_id"] != null || Request.QueryString["template_id"] != null)
        {
            if (!IsPostBack)
            {
                HtmlFormUtility.Components.HtmlForm htmlform = new HtmlFormUtility.Components.HtmlForm();
                htmlform.Create(TemplateID, true);
                lbtnSelectionPostBack.OnClientClick = "getSelectControls('" + lbtnPostBack.ClientID + "','" + HiddenName.ClientID + "','" + HiddenID.ClientID + "');return false;";
                IsQuestion = (htmlform.CurrentTemplate.TEMPLATE_TYPE == "Library");
                cbUserDefine.Checked = htmlform.CurrentTemplate.IS_USER_DEFINE_TARGET;
                cbNeedPass.Checked = htmlform.CurrentTemplate.NEEDPASS;
                cbAllowTakeBack.Checked = htmlform.CurrentTemplate.ALLOW_TAKEBACK;
                cbDisplayToEvaltarget.Checked = htmlform.CurrentTemplate.DISPLAY_TO_EVALTARGET == null ? true : htmlform.CurrentTemplate.DISPLAY_TO_EVALTARGET.Value;
                cbAllowReturn.Checked = htmlform.CurrentTemplate.ALLOW_RETURN;
                cbChoiceTeacher.Checked = htmlform.CurrentTemplate.TEMPLATE_REMARK == "C";
                cbQueryEvalTarget.Checked = htmlform.CurrentTemplate.ALLOW_VIEW_EVALTARGETDATA;
                HtmlNodeCollection coll =HtmlUtility.GetAllNodes(htmlform.InstanceDocument);//.DocumentNode.SelectNodes("//input");
                
                if (coll != null)
                {
                    foreach (HtmlNode node in coll)
                    {
                        string l_type = "";
                        if (node.Attributes.Contains("type"))
                        {
                            l_type = node.Attributes["type"].Value;
                        }
                        else
                        {
                            l_type = node.OriginalName;
                        }
                        if (node.Attributes.Contains("OnClick"))
                        {
                            node.Attributes.Remove("OnClick");
                        }
                        node.Attributes.Add("onClick", "ElementClick('" + lbtnPostBack.ClientID + "','" + node.Attributes["id"].Value + "','" + HiddenID.ClientID + "',false);" +
                        "ElementClick('" + lbtnPostBack.ClientID + "','" + node.Attributes["name"].Value + "','" + HiddenName.ClientID + "',false);" +
                        "ElementClick('" + lbtnPostBack.ClientID + "','" + (node.Attributes["displayname"] == null ? "" : node.Attributes["displayname"].Value) + "','" + HiddenDisplayname.ClientID + "',false);" +
                        "ElementClick('" + lbtnPostBack.ClientID + "','" + (node.Attributes["score"] == null ? "" : node.Attributes["score"].Value) + "','" + HiddenScore.ClientID + "',false);" +
                        "ElementClick('" + lbtnPostBack.ClientID + "','" + l_type + "','" + HiddenType.ClientID + "',true);" +
                        "return false;");
                        
                    }
                }
                ReadContent();
                ReadNecessary();
                ReadSingle();
                //htmlform.Submit(htmlform.InstanceHtml, this.EmpCode);
                htmlContent.InnerHtml = htmlform.InstanceDocument.DocumentNode.InnerHtml;

                //ViewState["Instant_ID"] = htmlform.InstanceID;
                //HtmlFormUtility.FORM_TEMPLATES template = vc.SelectFormTemplate(templateid);
                //ViewState["Instant_Name"] = template.TEMPLATE_NAME;

                Cache["htmlform"] = htmlform;

                string path = "~/UserImages/HtmlForm/" + this.EmpCode;
                if (!Directory.Exists(Server.MapPath(path)))
                {
                    Directory.CreateDirectory(Server.MapPath(path));
                }

                reContent.ImageManager.ViewPaths = new string[] { path };
                reContent.ImageManager.UploadPaths = new string[] { path };
                reContent.ImageManager.DeletePaths = new string[] { path };
                reContent.ImageManager.EnableAsyncUpload = true;
                reContent.ImageManager.MaxUploadFileSize = 10240000;
                reContent.ImageManager.SearchPatterns = new string[] { "*.jpeg", "*.jpg", "*.png", "*.gif", "*.bmp" };
                reContent.AutoResizeHeight = true;

                BindHospList();

                BindPermission();

                //rgExpressions.DataBind();
                //(this.Master.FindControl("form1") as HtmlForm).Action = "Detial.aspx?Instant_ID=" + ViewState["Instant_ID"] + "&Instant_Name=" + ViewState["Instant_Name"];
            }
            else
            {


            }
        }

    }

    private void BindPermission()
    {
        var permission = vc.GetTemplatePermission(TemplateID);
        foreach (ListItem item in cblPermissionHosp.Items)
        {
            if (permission.Count(c => c.HOSPCODE == item.Value) > 0)
            {
                item.Selected = true;
            }
        }
    }

    private void BindHospList()
    {
        var hosplist = service.GetHosp();
        cblPermissionHosp.DataValueField = "HospCode";
        cblPermissionHosp.DataTextField = "HospName";
        cblPermissionHosp.DataSource = hosplist;
        cblPermissionHosp.DataBind();
    }

    private void ReadContent()
    {
        HtmlFormUtility.Components.ViewComponent vc = new HtmlFormUtility.Components.ViewComponent();
        HtmlFormUtility.FORM_TEMPLATES temp = vc.GetFormTemplateById(TemplateID);
        reContent.Content = temp.TEMPLATE_CONTENT;
        reContent.DataBind();
    }

    private void ReadExpressions()
    {
        HtmlFormUtility.Components.ViewComponent vc = new HtmlFormUtility.Components.ViewComponent();
        List<HtmlFormUtility.FORM_TEMPLATE_EXPRESSIONS> explist = vc.ListFormTemplateExpressions(TemplateID);
        CurrentExpressionList = explist;
        

        rgExpressions.DataSource = explist;
    }


    protected void lbtnPostBack_Click(object sender, EventArgs e)
    {
        if (RadPageView1.Selected)
        {
            string[] ids = HiddenID.Value.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);


            HtmlFormUtility.FORM_TEMPLATE_ELEMENTS element = vc.SelectFormTemplateElementByID(TemplateID, HiddenID.Value);
            if (element != null)
            {
                lblID.Text = element.ID;
                tbName.Text = HiddenName.Value;
                tbScore.Value = element.POINTS;
                tbMaxScore.Value = element.MAXPOINT;
                tbMinTextCount.Value = element.MinTextCount;
                tbMaxTextCount.Value = element.MaxTextCount;
                tbDisplayName.Text = element.DISPLAY_NAME;
                cbHide.Checked = element.ISHIDE;
                tbBindValue.Text = element.BINDVALUE;
                btnSetScore.Enabled = true;
            }
            else
            {
                lblID.Text = HiddenID.Value;
                tbName.Text = HiddenName.Value;
                if (HiddenScore.Value == "")
                {
                    tbScore.Value = null;
                }
                else
                {
                    tbScore.Value = double.Parse(HiddenScore.Value);
                }
                tbMaxScore.Value = null;
                tbMaxTextCount.Value = null;
                tbMinTextCount.Value = null;
                tbDisplayName.Text = HiddenDisplayname.Value;
                tbBindValue.Text = "";
                btnSetScore.Enabled = true;
            }
            tbPage1SelectedNames.Text = HiddenName.Value;
        }
        if (RadPageView2.Selected)
        {
            tbExpression.Text += HiddenID.Value;
            tbExpression.Focus();
            tbExpression.Focus();
        }


        if (RadPageView3.Selected)
        {
            string[] ids = HiddenID.Value.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string id in ids)
            {

                HtmlFormUtility.FORM_TEMPLATE_ELEMENTS element = vc.SelectFormTemplateElementByID(TemplateID, id);
                if (element != null)
                {
                    //if (IsQuestion)
                    //{
                    //    element.DISPLAY_NAME = HiddenDisplayname.Value;
                    //    if (HiddenScore.Value != "")
                    //    {
                    //        element.POINTS = double.Parse(HiddenScore.Value);
                    //    }
                    //    pc.UpdateTemplateElementsScore(element);
                    //}
                    

                    lbControls.Items.Add(new ListItem(id + "-" + element.DISPLAY_NAME, element.TEMPLATE_ELEMENT_ID));
                }
                else
                {
                    if (IsQuestion)
                    {
                        HtmlFormUtility.FORM_TEMPLATE_ELEMENTS addelement = new HtmlFormUtility.FORM_TEMPLATE_ELEMENTS();
                        addelement.ID = HiddenID.Value;
                        addelement.TEMPLATE_ID = TemplateID;
                        addelement.NAME = HiddenName.Value;
                        addelement.POINTS = null;
                        addelement.MAXPOINT = null;
                        addelement.DISPLAY_NAME = HiddenDisplayname.Value;
                        addelement.CONTROL_TYPE = HiddenType.Value;
                        addelement.BINDVALUE = null;
                        pc.UpdateTemplateElementsScore(addelement);
                    }
                    lbControls.Items.Add(new ListItem(id + "-" + "", TemplateID.ToString() + "_" + id));
                }
            }
        }
        if (RadPageView4.Selected)
        {
            tbSingle.Text = HiddenID.Value;

        }

    }
    protected void btnSetScore_Click(object sender, EventArgs e)
    {
        HtmlFormUtility.FORM_TEMPLATE_ELEMENTS element = new HtmlFormUtility.FORM_TEMPLATE_ELEMENTS();
        element.ID = HiddenID.Value;
        element.TEMPLATE_ID = TemplateID;
        element.NAME = tbName.Text;
        element.POINTS = tbScore.Value;
        element.MAXPOINT = tbMaxScore.Value;
        element.DISPLAY_NAME = tbDisplayName.Text;
        element.CONTROL_TYPE = HiddenType.Value;
        element.BINDVALUE = tbBindValue.Text;
        if (tbMinTextCount.Value.HasValue)
        {
            element.MinTextCount = Convert.ToInt32(tbMinTextCount.Value);
        }
        else
        {
            element.MinTextCount = null;
        }
        if (tbMaxTextCount.Value.HasValue)
        {
            element.MaxTextCount = Convert.ToInt32(tbMaxTextCount.Value);
        }
        else
        {
            element.MaxTextCount = null;
        }

        if (element.CONTROL_TYPE == "text" || element.CONTROL_TYPE == "textarea")
        {
            element.ISHIDE = cbHide.Checked;
        }
        pc.UpdateTemplateElementsScore(element);
    }
    protected void rgExpressions_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        ReadExpressions();
        //rgExpressions.DataBind();
    }

    protected void rgExpressions_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
    {
        if (e.CommandName == "RowClick")
        {
            if (e.Item != null && e.Item is GridDataItem)
            {
                tbExpName.Text = CurrentExpressionList[e.Item.DataSetIndex].TEMPLATE_EXPRESSION_NAME;
                tbExpression.Text = CurrentExpressionList[e.Item.DataSetIndex].EXPRESSION;
                tbExpExecuteOrder.Value = CurrentExpressionList[e.Item.DataSetIndex].EXECUTE_ORDER;
            }
        }
    }
    protected void btnAddExp_Click(object sender, EventArgs e)
    {
        HtmlFormUtility.FORM_TEMPLATE_EXPRESSIONS exp = new HtmlFormUtility.FORM_TEMPLATE_EXPRESSIONS();
        exp.EXECUTE_ORDER = Convert.ToInt32(tbExpExecuteOrder.Value);
        exp.EXPRESSION = tbExpression.Text;
        exp.TEMPLATE_EXPRESSION_NAME = tbExpName.Text;
        exp.TEMPLATE_ID = TemplateID;
        HtmlFormUtility.Components.ProcessComponent pc = new HtmlFormUtility.Components.ProcessComponent();
        pc.InsertFormTemplateExpression(exp);
        ReadExpressions();
        rgExpressions.DataBind();
        tbExpExecuteOrder.Value = null;
        tbExpName.Text = "";
        tbExpression.Text = "";
    }
    protected void btnEditExp_Click(object sender, EventArgs e)
    {
        HtmlFormUtility.FORM_TEMPLATE_EXPRESSIONS exp = CurrentExpressionList[rgExpressions.SelectedItems[0].DataSetIndex];
        exp.EXECUTE_ORDER = Convert.ToInt32(tbExpExecuteOrder.Value);
        exp.EXPRESSION = tbExpression.Text;
        exp.TEMPLATE_EXPRESSION_NAME = tbExpName.Text;
        HtmlFormUtility.Components.ProcessComponent pc = new HtmlFormUtility.Components.ProcessComponent();
        pc.UpdateFormTemplateExpression(exp);
        ReadExpressions();
        rgExpressions.DataBind();
        tbExpExecuteOrder.Value = null;
        tbExpName.Text = "";
        tbExpression.Text = "";


    }
    protected void btnDelExp_Click(object sender, EventArgs e)
    {
        HtmlFormUtility.FORM_TEMPLATE_EXPRESSIONS exp = CurrentExpressionList[rgExpressions.SelectedItems[0].DataSetIndex];
        pc.DeleteFromTemplateExpression(exp);
        ReadExpressions();
        rgExpressions.DataBind();
        tbExpExecuteOrder.Value = null;
        tbExpName.Text = "";
        tbExpression.Text = "";
    }


    private void ReadGroups()
    {
        List<HtmlFormUtility.FORM_TEMPLATE_GROUPS> grouplist = vc.GetTemplateGroups(TemplateID);
        CurrentGroupList = grouplist;


        rgGroup.DataSource = grouplist;
    }

    protected void rgGroup_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        ReadGroups();
    }
    protected void btnSaveGroup_Click(object sender, EventArgs e)
    {
        if (rgGroup.SelectedItems.Count > 0)
        {
            int groupid = CurrentGroupList[rgGroup.SelectedItems[0].DataSetIndex].GROUP_ID;
            List<string> elements = new List<string>();
            foreach (ListItem item in lbControls.Items)
            {
                elements.Add(item.Value);
            }
            pc.SaveTemplateGroup(groupid, elements);
        }
    }
    protected void rgGroup_ItemCommand(object sender, GridCommandEventArgs e)
    {
        if (e.CommandName == "RowClick")
        {
            if (e.Item != null && e.Item is GridDataItem)
            {
                lbControls.Items.Clear();
                List<HtmlFormUtility.FORM_TEMPLATE_ELEMENTS> list = vc.GetGroupElements(CurrentGroupList[e.Item.DataSetIndex].GROUP_ID);
                foreach (HtmlFormUtility.FORM_TEMPLATE_ELEMENTS element in list)
                {
                    lbControls.Items.Add(new ListItem(element.ID + "-" + element.DISPLAY_NAME, element.TEMPLATE_ELEMENT_ID));
                }
            }
        }
    }
    protected void btnDeleteGroup_Click(object sender, EventArgs e)
    {
        if (lbControls.SelectedItem != null)
        {
            pc.DeleteTemplateGroup(lbControls.SelectedItem.Value);
            lbControls.Items.Remove(lbControls.SelectedItem);
        }
    }
    protected void rgGroup_InsertCommand(object sender, GridCommandEventArgs e)
    {
        GridEditableItem editedItem = e.Item as GridEditableItem;
        Dictionary<string, object> newValues = new Dictionary<string, object>();
        e.Item.OwnerTableView.ExtractValuesFromItem(newValues, editedItem);
        string groupname = newValues["GROUP_NAME"].ToString();

        int? displayorder = null;
        if (newValues["DISPLAY_ORDER"] != null)
        {
            displayorder = Convert.ToInt32(newValues["DISPLAY_ORDER"]);
        }

        bool to_evaltarget = false;
        if (newValues["to_evaltarget"]!=null)
        {
            to_evaltarget = Convert.ToBoolean(newValues["to_evaltarget"]);
        }

        pc.InsertTemplateGroup(TemplateID, groupname, displayorder, to_evaltarget);

        lbControls.Items.Clear();
        ReadGroups();
        
        rgGroup.DataBind();
        
    }

    protected void rgGroup_UpdateCommand(object sender, GridCommandEventArgs e)
    {
        int groupid = CurrentGroupList[e.Item.DataSetIndex].GROUP_ID;

        GridEditableItem editedItem = e.Item as GridEditableItem;
        Dictionary<string, object> newValues = new Dictionary<string, object>();
        e.Item.OwnerTableView.ExtractValuesFromItem(newValues, editedItem);
        string groupname = newValues["GROUP_NAME"].ToString();

        int? displayorder = null;
        if (newValues["DISPLAY_ORDER"] != null)
        {
            displayorder = Convert.ToInt32(newValues["DISPLAY_ORDER"]);
        }

        bool to_evaltarget = false;
        if (newValues["to_evaltarget"] != null)
        {
            to_evaltarget = Convert.ToBoolean(newValues["to_evaltarget"]);
        }


        pc.UpdateTemplateGroup(groupid, groupname, displayorder, to_evaltarget);
        lbControls.Items.Clear();
        ReadGroups();
        rgGroup.DataBind();
    }
    private void ReadNecessary()
    {
        List<HtmlFormUtility.FORM_TEMPLATE_NECESSARY> list = vc.GetTemplateNecessary(TemplateID);
        lbNecessary.DataSource = list;
        lbNecessary.DataBind();
    }

    private void ReadSingle()
    {
        List<HtmlFormUtility.FORM_TEMPLATE_SINGLE> list = vc.GetTemplateSingle(TemplateID);
        lbSingleSetting.DataSource = list;
        lbSingleSetting.DataBind();
    }

    protected void btnAddNecessary_Click(object sender, EventArgs e)
    {
        if (tbName.Text != "")
        {
            pc.AddFormTemplateNecessary(TemplateID, tbName.Text, "尚未填寫完成所有項目");
        }
        else
        {
            if (tbPage1SelectedNames.Text != "")
            {
                pc.AddFormTemplateNecessary(TemplateID, tbPage1SelectedNames.Text, "尚未填寫完成所有項目");
            }
        }
        ReadNecessary();
    }
    protected void btnRemoveNecessary_Click(object sender, EventArgs e)
    {
        if (lbNecessary.SelectedValue != null)
        {
            pc.RemoveFormTemplateNecessary(TemplateID, lbNecessary.SelectedValue);
        }
        ReadNecessary();
    }

    protected void btnAddSingle_Click(object sender, EventArgs e)
    {
        if (tbSingle.Text.Trim() != "")
        {
            pc.AddFormTemplateSingle(TemplateID, tbSingle.Text);
        }
        ReadSingle();
    }
    protected void btnRemoveSingle_Click(object sender, EventArgs e)
    {
        if (lbSingleSetting.SelectedValue != null)
        {
            pc.RemoveFormTemplateSingle(TemplateID, lbSingleSetting.SelectedValue);
        }
        ReadSingle();
    }
    protected void btnSaveContent_Click(object sender, EventArgs e)
    {
        pc.AdminSaveTemplateContent(TemplateID, reContent.Content.Replace("style=\"overflow: hidden;\"",""));

        Response.Redirect(Request.Url.AbsoluteUri);
    }
    protected void rgGroup_DeleteCommand(object sender, GridCommandEventArgs e)
    {
        int groupid = CurrentGroupList[e.Item.DataSetIndex].GROUP_ID;


        pc.RemoveTemplateGroup(groupid);
        lbControls.Items.Clear();
        ReadGroups();
        rgGroup.DataBind();
    }
    protected void btnSaveTemplateSetting_Click(object sender, EventArgs e)
    {
        pc.UpdateTemplateUserDefine(TemplateID, cbUserDefine.Checked);
        pc.UpdateTemplateNeedPass(TemplateID, cbNeedPass.Checked, cbAllowReturn.Checked, cbAllowTakeBack.Checked, cbDisplayToEvaltarget.Checked, cbChoiceTeacher.Checked ? "C" : "", cbQueryEvalTarget.Checked);
    }
    protected void btnSaveTemplatePermission_Click(object sender, EventArgs e)
    {
        List<string> hospcodes = new List<string>();
        foreach(ListItem item in cblPermissionHosp.Items)
        {
            if(item.Selected)
            {
                hospcodes.Add(item.Value);
            }
        }
        if(hospcodes.Count == 0)
        {
            hospcodes.Add(this.HospCode);
        }
        pc.UpdateTemplatePermission(TemplateID, hospcodes, this.EmpCode);
    }
}

