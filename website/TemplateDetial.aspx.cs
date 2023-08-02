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
using System.Data.SqlClient;
using Telerik.Web.UI;

public partial class TemplateDetial : AuthPage
{
    private HtmlFormUtility.Components.ViewComponent vc = new HtmlFormUtility.Components.ViewComponent();

    protected void Page_Load(object sender, EventArgs e)
    {
        this.AddPostbackControl(btn_submit);

        if (!IsPostBack)
        {
            if (Request.QueryString["template_id"] != null)
            {
                ViewState["CurrentTemplateID"] = Request.QueryString["template_id"];
                int templateid = Convert.ToInt32(Request.QueryString["template_id"]);
                HtmlFormUtility.Components.HtmlForm htmlform = new HtmlFormUtility.Components.HtmlForm();
                HtmlFormUtility.Components.ViewComponent vc = new HtmlFormUtility.Components.ViewComponent();
                htmlform.Create(templateid);
                Session[ViewState["CurrentTemplateID"] + "htmlform"] = htmlform;
                SetHtmlContent();
            }

            if (Request.QueryString["qid"] != null)
            {
                EduQuestionDto dto = service.GetEduQuestionByID(Convert.ToInt32(Request.QueryString["qid"]));
                lbTitle.Text = dto.QuestionTitle;
            }

        }
        else
        {


        }


    }
    protected void btn_submit_Click(object sender, EventArgs e)
    {
        try
        {

            HtmlFormUtility.Components.HtmlForm form = Session[ViewState["CurrentTemplateID"] + "htmlform"] as HtmlFormUtility.Components.HtmlForm;


            form.Submit(Request.Form, this.EmpCode, true, null);

            if (!form.SubmitSuccess)
            {
                if (form.SubmitMessage != null)
                {
                    ShowMessage(form.SubmitMessage);
                }
                Session[ViewState["CurrentTemplateID"] + "htmlform"] = form;
                SetHtmlContent();
                return;
            }

            //Response.Write("<script language='javascript'>window.close();</" + "script>");
            Response.Redirect("ToDoList.aspx");

        }
        catch (Exception ex)
        {
            ShowMessage("傳送失敗：" + ex.Message);
        }
    }

    private void SetHtmlContent()
    {
        HtmlFormUtility.Components.HtmlForm htmlform = Session[ViewState["CurrentTemplateID"] + "htmlform"] as HtmlFormUtility.Components.HtmlForm;
        List<HtmlFormUtility.Components.HtmlForm> list = htmlform.BeforeForms;
        
        string html = "";
        foreach (HtmlFormUtility.Components.HtmlForm form in list)
        {
            html += form.InstanceDocument.DocumentNode.InnerHtml;
        }

        bool check = false;
        foreach (HtmlFormUtility.FORM_INSTANCES ins in htmlform.AfterInstances)
        {
            if (ins.Status != "0")
            {
                check = true;
            }
        }

        if (check)
            htmlform.ReadOnly = true;

        html += htmlform.InstanceDocument.DocumentNode.InnerHtml;

        if (check)
        {
            foreach (HtmlFormUtility.Components.HtmlForm afterform in htmlform.AfterForms)
            {
                if (afterform.CurrentInstance.Status != "0")
                {
                    afterform.ReadOnly = true;
                    html += afterform.InstanceDocument.DocumentNode.InnerHtml;
                }
            }
        }
        //if (html.Contains("function checkInput()"))
        //{
        //    btn_submit.OnClientClick = "javascript:if(!checkInput()){return false;}";
        //}
        //else
        //{
        //    btn_submit.OnClientClick = "";
        //}
        htmlContent.InnerHtml = html;
    }

}

