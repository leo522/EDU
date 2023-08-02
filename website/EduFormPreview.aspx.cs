using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KMU.EduActivity.ApplicationLayer.DTO;

public partial class EduFormPreview : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["template_id"] != null || Request.QueryString["template_id"] != null)
            {
                int templateid = Session["template_id"] == null ? Convert.ToInt32(Request.QueryString["template_id"]) : Convert.ToInt32(Session["template_id"]);
                using (KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService service = new KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService())
                {
                    List<int> childlist = service.GetChildTemplateIDs(templateid);
                    if (childlist.Count > 0)
                    {
                        foreach (int i in childlist)
                        {
                            HtmlFormUtility.Components.HtmlForm htmlform = new HtmlFormUtility.Components.HtmlForm();
                            htmlform.Create(i);


                            htmlContent.InnerHtml += htmlform.InstanceDocument.DocumentNode.InnerHtml;
                        }
                    }
                    else
                    {

                        HtmlFormUtility.Components.HtmlForm htmlform = new HtmlFormUtility.Components.HtmlForm();
                        htmlform.Create(templateid);


                        htmlContent.InnerHtml = htmlform.InstanceDocument.DocumentNode.InnerHtml;
                    }
                }
            }
        }
        else
        {


        }

    }

}