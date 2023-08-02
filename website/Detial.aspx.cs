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
using KMU.EduActivity.ApplicationLayer.DTO;

public partial class _Default : AuthPage
{
    private HtmlFormUtility.Components.ViewComponent vc = new HtmlFormUtility.Components.ViewComponent();

    private string EduTermID
    {
        get
        {
            return Request.QueryString["edutermid"];
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

            if (!IsPostBack)
            {
                if (Session["template_id"] != null || Request.QueryString["template_id"] != null)
                {
                    int templateid = Session["template_id"] == null ? Convert.ToInt32(Request.QueryString["template_id"]) : Convert.ToInt32(Session["template_id"]);
                    HtmlFormUtility.Components.HtmlForm htmlform = new HtmlFormUtility.Components.HtmlForm();
                    htmlform.SqlParameterCollection.Add("@test", "wahaha");
                    htmlform.ParameterCollection.Add("EduTermID", "20131009000000000000");
                    htmlform.EditRole.Add("VS");
                    htmlform.Create(templateid);
                    //htmlform.Submit(htmlform.InstanceHtml, this.EmpCode);
                    htmlContent.InnerHtml = htmlform.InstanceDocument.DocumentNode.InnerHtml;

                    //ViewState["Instant_ID"] = htmlform.InstanceID;
                    //HtmlFormUtility.FORM_TEMPLATES template = vc.SelectFormTemplate(templateid);
                    //ViewState["Instant_Name"] = template.TEMPLATE_NAME;

                    Session["htmlform"] = htmlform;
                    //(this.Master.FindControl("form1") as HtmlForm).Action = "Detial.aspx?Instant_ID=" + ViewState["Instant_ID"] + "&Instant_Name=" + ViewState["Instant_Name"];
                }
                else if (Request.QueryString["instance_id"] != null)
                {
                    int instant_id = Convert.ToInt32(Request.QueryString["instance_id"]);
                    HtmlFormUtility.Components.HtmlForm htmlform = new HtmlFormUtility.Components.HtmlForm();
                    //htmlform.Query(Convert.ToInt32(Request.QueryString["Instant_ID"]));
                    htmlform.Query(instant_id);
                    //htmlform.ReadOnly = true;

   

                    //將分數帶入testarea
                    //htmlform.InstanceDocument.GetNodesByName("ta01")[0].InnerHtml = form.Score[0].EXPRESSION_VALUE.ToString();

                    Session["htmlform"] = htmlform;
                    htmlContent.InnerHtml = htmlform.InstanceDocument.DocumentNode.InnerHtml;
                    //btn_submit.Enabled = false;
                }
            }
            else
            {

                if (Request.QueryString["instance_id"] != null)
                {
                    int instant_id = Convert.ToInt32(Request.QueryString["instance_id"]);
                    HtmlFormUtility.Components.HtmlForm htmlform = new HtmlFormUtility.Components.HtmlForm();
                    //htmlform.Query(Convert.ToInt32(Request.QueryString["Instant_ID"]));
                    htmlform.Query(instant_id);
                    //htmlform.ReadOnly = true;

   

                    //將分數帶入testarea
                    //htmlform.InstanceDocument.GetNodesByName("ta01")[0].InnerHtml = form.Score[0].EXPRESSION_VALUE.ToString();

                    Session["htmlform"] = htmlform;
                    htmlContent.InnerHtml = htmlform.InstanceDocument.DocumentNode.InnerHtml;
                    //btn_submit.Enabled = false;
                }
            }
        

    }
    protected void btn_submit_Click(object sender, EventArgs e)
    {

        //if ((Request.QueryString["Instant_ID"] != null) && (Request.QueryString["Instant_Name"] != null))
        //{
        try
        {
            HtmlFormUtility.Components.HtmlForm form = Session["htmlform"] as HtmlFormUtility.Components.HtmlForm;
            form.Submit(Request.Form, this.EmpCode, true, null);
            int instant_id = form.InstanceID;
            HtmlFormUtility.Components.HtmlForm htmlform = new HtmlFormUtility.Components.HtmlForm();
            //htmlform.Query(Convert.ToInt32(Request.QueryString["Instant_ID"]));
            htmlform.Query(instant_id);
            htmlform.ReadOnly = true;

            if (EduTermID != null)
            {
                service.InsertEduTermFormInstance(EduTermID, instant_id);
            }

            //將分數帶入testarea
            //htmlform.InstanceDocument.GetNodesByName("ta01")[0].InnerHtml = form.Score[0].EXPRESSION_VALUE.ToString();

            Session["htmlform"] = htmlform;
            htmlContent.InnerHtml = htmlform.InstanceDocument.DocumentNode.InnerHtml;
            btn_submit.Enabled = false;
        }
        catch
        {
            Response.Write("<script>alert('壞去啦~~~');location.href('HtmlAgilityAdmin.aspx');</script>");
        }
        //}
    }

}

