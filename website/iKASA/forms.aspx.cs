using KMU.EduActivity.ApplicationLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class iKASA_forms : iKASAPageBase
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

        if (list.Count > 0)
        {
            lbNoData.Visible = false;
            string title = @"  <table width='98%' style='border:1px solid #000; border-collapse:collapse;'>
                        <tr>
                            <th style='  background-color: #009FCC;padding:3px;border:1px solid #000;color:#fff;'>課程</th>
                            <th style='  background-color: #009FCC;padding:3px;border:1px solid #000;color:#fff;'>表單</th>
                            <th style='  background-color: #009FCC;padding:3px;border:1px solid #000;color:#fff;'>時間</th>
                            <th style='  background-color: #009FCC;padding:3px;border:1px solid #000;color:#fff;'></th>
                        </tr>";
            string contenttemplate = @"
                        <tr>
                            <td style=' border:1px solid #000; padding:2px;'>
                                {0}
                            </td>
                            <td style=' border:1px solid #000; padding:2px;'>
                                {1}
                            </td>
                            <td style=' border:1px solid #000; padding:2px;'>
                                {2}
                            </td>
                            <td style=' border:1px solid #000; padding:2px;'>" +
                                "<input type='button' value='查看' onclick=\"QueryForm('{3}');\"> </td>" +
                            @"</td>
                        </tr>";

            string tail = "</table>";

            string html = "";
            foreach(var item in list)
            {
                html += string.Format(contenttemplate, item.INHOSPID, item.INSTANCE_NAME, item.INSTANCE_CREATE_DATETIME.ToString(), item.INSTANCE_ID.ToString());
            }

            html = title + html + tail;
            liTable.Text = html;

        }
        else
        {
            lbNoData.Visible = true;
        }
    }

    private void ReadForm()
    {
        if (hdFileID.Value != null && hdFileID.Value != "")
        {
            ViewState["CurrentInstanceID"] = hdFileID.Value;
            int instanceid = Convert.ToInt32(hdFileID.Value);
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

            rmp.SelectedIndex = 1;
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

    protected void lbPostBack_Click(object sender, EventArgs e)
    {
        string fileid = hdFileID.Value;
        ReadForm();

    }
}