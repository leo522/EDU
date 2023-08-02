using KMU.EduActivity.ApplicationLayer.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class iKASA_termquery : iKASAPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ReadData();
        }
    }

    private void ReadData()
    {
        var data = service.QueryEduMemberTermWithPass(this.CurrentPersonInfo.empcode, false, null);

        foreach (var d in data)
        {
            d.UDLinkTemplate = "<a onclick=\"ReadIns('{0}'); return false;\" href='InstanceDetial.aspx?edutermid={1}&mode=v'  >{2}</a>";
        }

        ViewState["currentdata"] = data;
        RadTreeList1.DataSource = data;
        try
        {
            RadTreeList1.DataBind();
            RadTreeList1.ExpandAllItems();
        }
        catch (Exception ex)
        {

        }
    }

    protected void RadTreeList1_NeedDataSource(object sender, TreeListNeedDataSourceEventArgs e)
    {
        RadTreeList1.DataSource = ViewState["currentdata"];
    }

    protected void btnInsReturnMain_Click(object sender, EventArgs e)
    {
        rmp.SelectedIndex = 0;
    }

    protected void lbPostBack_Click(object sender, EventArgs e)
    {
        ReadForm();
        rmp.SelectedIndex = 1;
    }

    private void ReadForm()
    {
        if (hdInsID.Value != null && hdInsID.Value != "")
        {
            ViewState["CurrentInstanceID"] = hdInsID.Value;
            int instanceid = Convert.ToInt32(hdInsID.Value);
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
                btnAttachment.OnClientClick = "javascript:window.open('InstanceAttachment.aspx?id=" + htmlform.BeforeInstances.Where(c => c.FORM_TEMPLATES.ALLOW_ATTACHMENT == "U").FirstOrDefault().INSTANCE_ID.ToString() + "&auth=" + currentinstance.FORM_TEMPLATES.ALLOW_ATTACHMENT + "', '附件管理', config='height=300,width=500');return false;";
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
}