using KMU.EduActivity.ApplicationLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class iKASA_formsOld : iKASAPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ReadFormList();
        }


    }

    private void ReadFormList()
    {
        string groupid = this.FuncParams["groupid"];

        List<FORM_INSTANCEDto> list = service.GetiKasaMemberFormList(this.CurrentPersonInfo.memberid, groupid);

        rcbFormList.DataValueField = "INSTANCE_ID";
        rcbFormList.DataTextField = "INSTANCE_NAME";
        rcbFormList.DataSource = list;
        rcbFormList.DataBind();

        if(list.Count >0)
        {
            rcbFormList.SelectedIndex = 0;
            ReadForm();
            lbNoData.Visible = false;
        }
        else
        {
            lbNoData.Visible = true;
        }
    }

    private void ReadForm()
    {
        if (rcbFormList.SelectedValue != null && rcbFormList.SelectedValue != "")
        {
            ViewState["CurrentInstanceID"] = rcbFormList.SelectedValue;
            int instanceid = Convert.ToInt32(rcbFormList.SelectedValue);
            HtmlFormUtility.Components.HtmlForm htmlform = new HtmlFormUtility.Components.HtmlForm();
            HtmlFormUtility.Components.ViewComponent vc = new HtmlFormUtility.Components.ViewComponent();
            HtmlFormUtility.FORM_INSTANCES currentinstance = vc.SelectFormInstance(instanceid);
            htmlform.ReadOnly = true;

            //外帶instanceid
            htmlform.ParameterCollection.Add("instance_id", instanceid.ToString());

            string edutermid = currentinstance.INHOSPID;


            List<HtmlFormUtility.Components.HtmlForm> list = htmlform.Query(instanceid, true, true, false);



            Session[ViewState["CurrentInstanceID"] + "htmlform"] = htmlform;


            SetHtmlContent();

            if (currentinstance.FORM_TEMPLATES.ALLOW_ATTACHMENT != null)
            {
                btnAttachment.Visible = true;

                btnAttachment.Text = "查閱附件";
                btnAttachment.OnClientClick = "javascript:window.open('../InstanceAttachment.aspx?id=" + htmlform.BeforeInstances.Where(c => c.FORM_TEMPLATES.ALLOW_ATTACHMENT == "U").FirstOrDefault().INSTANCE_ID.ToString() + "&auth=" + currentinstance.FORM_TEMPLATES.ALLOW_ATTACHMENT + "', '附件管理', config='height=300,width=500');return false;";
            }
        }
    }


    private void SetHtmlContent()
    {
        HtmlFormUtility.Components.HtmlForm htmlform = Session[ViewState["CurrentInstanceID"] + "htmlform"] as HtmlFormUtility.Components.HtmlForm;
        List<HtmlFormUtility.Components.HtmlForm> list = htmlform.BeforeForms;

        string html = "";
        foreach (HtmlFormUtility.Components.HtmlForm form in list)
        {
            if (form.ReadOnly)
            {
                var elements = form.InstanceDocument.DocumentNode.SelectNodes("//*");

                if (elements != null)
                {
                    foreach (var element in elements)
                    {
                        element.Attributes.Remove("name");
                    }
                }
            }
            html += form.InstanceDocument.DocumentNode.InnerHtml;
        }

        html += htmlform.InstanceDocument.DocumentNode.InnerHtml;

        htmlContent.InnerHtml = html;
    }
    protected void rcbFormList_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ReadForm();
    }
}