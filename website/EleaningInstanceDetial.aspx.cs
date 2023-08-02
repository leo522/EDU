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

public partial class ElearningInstanceDetial : AuthPage
{
    private HtmlFormUtility.Components.ViewComponent vc = new HtmlFormUtility.Components.ViewComponent();

    protected void Page_Load(object sender, EventArgs e)
    {
        this.AddPostbackControl(btn_submit);
        this.AddPostbackControl(btn_presave);

        if (!IsPostBack)
        {
            if (Request.QueryString["template_id"] != null && Request.QueryString["itemid"] != null && Request.QueryString["ClassID"] != null)
            {
                ViewState["CurrentTemplateID"] = Request.QueryString["template_id"];
                int templateid = Convert.ToInt32(Request.QueryString["template_id"]);
                HtmlFormUtility.Components.HtmlForm htmlform = new HtmlFormUtility.Components.HtmlForm();
                HtmlFormUtility.Components.ViewComponent vc = new HtmlFormUtility.Components.ViewComponent();

                int? cinstanceid = service.CheckCreateClassInstance(Request.QueryString["itemid"], this.EmpCode, templateid);

                if (cinstanceid == null)
                {
                    ShowMessageAndGoBack("測驗建立失敗，請重試");
                    return;
                }

                if (Request.QueryString["mode"] == "v")
                {
                    htmlform.ReadOnly = true;
                    btn_submit.Visible = false;
                    btn_presave.Visible = false;
                }

                int instanceid = cinstanceid.Value;

                HtmlFormUtility.FORM_INSTANCES currentinstance = vc.SelectFormInstance(instanceid);

                if (currentinstance.expireDate != null && currentinstance.expireDate.Value.Date < DateTime.Now.Date)
                {
                    if (Request.QueryString["mode"] != "v")
                    {
                        ShowMessageAndGo("本表單已經逾期無法進行填寫", "ToDoList.aspx");
                        return;
                    }
                }

                //外帶填寫者姓名
                htmlform.ParameterCollection.Add("UserName", this.EmpName);
                //外帶現在日期
                htmlform.ParameterCollection.Add("NowDate", DateTime.Now.ToString("yyyy/MM/dd"));

                //外帶instanceid
                htmlform.ParameterCollection.Add("instance_id", instanceid.ToString());


                //外帶會員資訊
                MemberDto dto = service.ReadMemberByEmpCode(this.EmpCode);
                if (dto != null)
                {
                    htmlform.ParameterCollection.Add("MemberName", dto.Name);
                    htmlform.ParameterCollection.Add("MemberCode", dto.MemberCode);
                    htmlform.ParameterCollection.Add("EduTeamName", dto.EduTeamName);

                    htmlform.ParameterCollection.Add("JobCode", dto.MemberType);
                }


                htmlform.ParameterCollection.Add("EmpCode", this.EmpCode);
                htmlform.ParameterCollection.Add("EmpName", this.EmpName);



                List<HtmlFormUtility.Components.HtmlForm> list = htmlform.Query(instanceid, true, true, false);
                
                foreach (HtmlFormUtility.FORM_INSTANCES form in htmlform.BeforeInstances)
                {
                    if (form.Status == "0")
                    {
                        if (!form.expireDate.HasValue || (form.expireDate.HasValue && form.expireDate.Value < DateTime.Now))
                        {
                            ShowMessage("上位填寫者尚未完成填寫");
                            JSGoBackPage();
                            return;
                        }
                    }
                }

                if (htmlform.AfterInstances != null && htmlform.AfterInstances.Count > 0)
                {
                    V_KmuEmpDto emp = service.GetVKmuEmpByEmpCode(htmlform.AfterInstances[0].TargetID);
                    if (emp != null)
                    {
                        htmlform.ParameterCollection.Add("NextName", emp.Empname);
                    }
                }


                Session[ViewState["CurrentInstanceID"] + "htmlform"] = htmlform;
                SetHtmlContent();

                if (currentinstance.FORM_TEMPLATES.ALLOW_ATTACHMENT != null)
                {
                    btnAttachment.Visible = true;
                    if (currentinstance.FORM_TEMPLATES.ALLOW_ATTACHMENT == "U")
                    {
                        btnAttachment.Text = "管理附件";
                        btnAttachment.OnClientClick = "javascript:window.open('InstanceAttachment.aspx?id=" + instanceid.ToString() + "&auth=" + currentinstance.FORM_TEMPLATES.ALLOW_ATTACHMENT + "', '附件管理', config='height=300,width=500');return false;";
                    }
                    else
                    {
                        btnAttachment.Text = "查閱附件";
                        btnAttachment.OnClientClick = "javascript:window.open('InstanceAttachment.aspx?id=" + htmlform.BeforeInstances.Where(c => c.FORM_TEMPLATES.ALLOW_ATTACHMENT == "U").FirstOrDefault().INSTANCE_ID.ToString() + "&auth=" + currentinstance.FORM_TEMPLATES.ALLOW_ATTACHMENT + "', '附件管理', config='height=300,width=500');return false;";
                    }

                }
            }
            else
            {
                ShowMessageAndGoBack("參數傳遞錯誤");
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

            HtmlFormUtility.Components.HtmlForm form = Session[ViewState["CurrentInstanceID"] + "htmlform"] as HtmlFormUtility.Components.HtmlForm;
            string status = form.CurrentInstance.FORM_INSTANCE_TARGETS.Where(c => c.TargetID == this.EmpCode).FirstOrDefault().Status;


            if (sender == btn_submit)
            {
                form.Submit(Request.Form, this.EmpCode, true, null);
            }

            if (sender == btn_presave)
            {
                form.PreSave(Request.Form, this.EmpCode, null);

                Session[ViewState["CurrentInstanceID"] + "htmlform"] = form;
                SetHtmlContent();
                Response.Redirect(Request.Url.AbsoluteUri);
                return;
            }

            if ((!form.SubmitSuccess) && (sender != btn_presave))
            {
                if (form.SubmitMessage != null)
                {
                    ShowMessage(form.SubmitMessage);
                }
                Session[ViewState["CurrentInstanceID"] + "htmlform"] = form;
                SetHtmlContent();
                return;
            }

            if (sender == btn_submit)
            {

                if (status == "0")
                {

                    foreach (SqlCommand cmd in form.SubmitSQL)
                    {
                        if (cmd.Connection.State != ConnectionState.Open)
                        {
                            cmd.Connection.Open();
                        }
                        cmd.ExecuteNonQuery();
                    }

                }

                service.SetClassExamItemFinish(Request.QueryString["itemid"], this.EmpCode, form.InstanceID.ToString());

                Response.Redirect("ElearningContent.aspx?ClassID=" + Request.QueryString["ClassID"]);
            }

            //int instant_id = form.InstanceID;


            //HtmlFormUtility.Components.HtmlForm htmlform = new HtmlFormUtility.Components.HtmlForm();



            //htmlform.ParameterCollection.Add("EmpName", this.EmpName);

            //htmlform.Query(instant_id);
            //htmlform.ReadOnly = true;

            //Session["htmlform"] = htmlform;

            //SetHtmlContent();

            //btn_submit.Enabled = false;
        }
        catch (Exception ex)
        {
            ShowMessage("傳送失敗：" + ex.Message);
        }
    }

    private void SetHtmlContent()
    {
        HtmlFormUtility.Components.HtmlForm htmlform = Session[ViewState["CurrentInstanceID"] + "htmlform"] as HtmlFormUtility.Components.HtmlForm;
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

