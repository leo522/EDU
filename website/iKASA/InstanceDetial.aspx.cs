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

public partial class InstanceDetial : AuthPage
{
    private HtmlFormUtility.Components.ViewComponent vc = new HtmlFormUtility.Components.ViewComponent();

    protected void Page_Load(object sender, EventArgs e)
    {
        this.AddPostbackControl(btn_submit);
        this.AddPostbackControl(btn_presave);
        this.AddPostbackControl(btnReturn);
        this.AddPostbackControl(btnReturnToFirst);
        this.AddPostbackControl(btnTakeBack);

        if (!IsPostBack)
        {
            if (Request.QueryString["instance_id"] != null)
            {
                ViewState["CurrentInstanceID"] = Request.QueryString["instance_id"];
                int instanceid = Convert.ToInt32(Request.QueryString["instance_id"]);
                HtmlFormUtility.Components.HtmlForm htmlform = new HtmlFormUtility.Components.HtmlForm();
                HtmlFormUtility.Components.ViewComponent vc = new HtmlFormUtility.Components.ViewComponent();
                HtmlFormUtility.FORM_INSTANCES currentinstance = vc.SelectFormInstance(instanceid);

                List<FORM_INSTANCE_RETURN_LOGDto> retlogs = service.GetFormReturnLog(instanceid);
                if(retlogs.Count >0)
                {
                    panReturnLog.Visible = true;
                    rgReturnLog.DataSource = retlogs;
                    rgReturnLog.DataBind();


                }

                if (Request.QueryString["mode"] == "v")
                {
                    htmlform.ReadOnly = true;
                    btn_submit.Visible = false;
                    btn_presave.Visible = false;
                }

                //if (currentinstance.expireDate != null && currentinstance.expireDate.Value.Date < DateTime.Now.Date)
                //{
                //    if (Request.QueryString["mode"] != "v")
                //    {
                //        ShowMessageAndGo("本表單已經逾期無法進行填寫", "ToDoList.aspx");
                //        return;
                //    }
                //}

                if (currentinstance.FORM_INSTANCE_TARGETS.Count == 1 && (currentinstance.FORM_INSTANCE_TARGETS.Count(c => c.TargetID.ToUpper() == this.EmpCode.ToUpper()) == 0) && Request.QueryString["mode"] != "v" && Request.QueryString["mode"] != "i")
                {
                    ShowMessageAndGo("您非本表單的填寫人，無法進行填寫", "ToDoList.aspx");
                    return;
                }

                if(currentinstance.FORM_TEMPLATES.ALLOW_RETURN && btn_submit.Visible)
                {
                    btnReturn.Visible = true;
                    btnReturnToFirst.Visible = true;
                    lbReturn.Visible = true;
                    tbReturnReason.Visible = true;
                }



                //外帶填寫者姓名
                htmlform.ParameterCollection.Add("UserName", this.EmpName);
                //外帶現在日期
                htmlform.ParameterCollection.Add("NowDate", DateTime.Now.ToString("yyyy/MM/dd"));
                htmlform.ParameterCollection.Add("NowDateY", DateTime.Now.ToString("yyyy"));
                htmlform.ParameterCollection.Add("NowDateM", DateTime.Now.ToString("MM"));
                htmlform.ParameterCollection.Add("NowDateD", DateTime.Now.ToString("dd"));
                
                //外帶instanceid
                htmlform.ParameterCollection.Add("instance_id", instanceid.ToString());

                string edutermid = currentinstance.INHOSPID;
                if (edutermid != null)
                {
                    //外帶課程資訊
                    EduTermDto eduterm = service.ReadEduTermById(edutermid);
                    if (eduterm != null)
                    {
                        htmlform.ParameterCollection.Add("EduTermID", edutermid);
                        htmlform.ParameterCollection.Add("EduTeamDateFromYear", eduterm.DateFrom.ToString("yyyy"));
                        htmlform.ParameterCollection.Add("EduTeamDateFromMonth", eduterm.DateFrom.ToString("MM"));
                        htmlform.ParameterCollection.Add("EduTeamDateFromDay", eduterm.DateFrom.ToString("dd"));
                        htmlform.ParameterCollection.Add("EduTeamDateToYear", eduterm.DateTo.ToString("yyyy"));
                        htmlform.ParameterCollection.Add("EduTeamDateToMonth", eduterm.DateTo.ToString("MM"));
                        htmlform.ParameterCollection.Add("EduTeamDateToDay", eduterm.DateTo.ToString("dd"));
                        
                        //外帶課程職類參數
                        htmlform.ParameterCollection.Add("JobCode",eduterm.JobCode);
                        
                        if (eduterm.DepCode != null)
                        {
                            htmlform.ParameterCollection.Add("dept", eduterm.DepCode);
                            V_departmentDto dep = service.GetDepartment(this.HospCode, eduterm.DepCode);
                            if (dep != null)
                            {
                                htmlform.ParameterCollection.Add("DepName", dep.Deptname);
                            }
                        }
                        htmlform.ParameterCollection.Add("TimeRange", eduterm.DateFrom.ToString("yyyy/MM/dd") + "~" + eduterm.DateTo.ToString("yyyy/MM/dd"));
                        htmlform.ParameterCollection.Add("EduTermDateYYMM",eduterm.DateFrom.ToString("yyyy/MM"));
                        htmlform.ParameterCollection.Add("EduTermDateYY", eduterm.DateFrom.ToString("yyyy"));
                        htmlform.ParameterCollection.Add("EduTermDateMM", eduterm.DateFrom.ToString("MM"));
                        htmlform.ParameterCollection.Add("EduTermDateToMM", eduterm.DateTo.ToString("MM"));
                        //外帶編輯腳色資訊
                        List<HtmlFormUtility.FORM_INSTANCE_TARGETS> targets = vc.GetInstanceTargetsByTargetID(instanceid, this.EmpCode);
                        foreach (HtmlFormUtility.FORM_INSTANCE_TARGETS target in targets)
                        {
                            htmlform.EditRole.Add(target.TargetType);
                        }
                        
                        //List<EduRefTeacherDto> refteachers = service.GetUserRolesInEduTerm(eduterm.EduTermID, this.EmpCode, currentinstance.EvalTargetID);
                        //foreach (EduRefTeacherDto refteacher in refteachers)
                        //{
                            //htmlform.EditRole.Add(refteacher.TeacherType);
                        //}
                        

                        if (eduterm.Hospital.HasValue)
                        {
                            V_CodeRefDto hosp = service.GetCodeRefs("EduAct_Hospital").Where(c => c.Code == eduterm.Hospital.Value.ToString()).FirstOrDefault();
                            if (hosp != null)
                            {
                                htmlform.ParameterCollection.Add("Hospital", hosp.Name);
                            }
                        }
                    }
                }

                
                V_KmuEmpDto taremp = service.GetVKmuEmpByEmpCode(currentinstance.TargetID);
                if (taremp != null)
                {
                    htmlform.ParameterCollection.Add("TargetName", taremp.Empname);
                    htmlform.ParameterCollection.Add("TargetID", taremp.Empcode);
                    if(taremp.SEX == 'F')
                    {
                        htmlform.ParameterCollection.Add("TargetSex", "女");
                    }
                    else if (taremp.SEX == 'M')
                    {
                        htmlform.ParameterCollection.Add("TargetSex", "男");
                    }
                    else
                    {
                        htmlform.ParameterCollection.Add("TargetSex", "");
                    }
                }
                else
                {
                    htmlform.ParameterCollection.Add("TargetName", "");
                    htmlform.ParameterCollection.Add("TargetID", "");
                }
            
//http://www2.kmuh.org.tw/Web/EduActivity/InstanceDetial.aspx?instance_id=381921
                //外帶會員資訊
                MemberDto dto = service.ReadMemberByEmpCode(this.EmpCode);
                if (dto != null)
                {
                    htmlform.ParameterCollection.Add("MemberName", dto.Name);
                    htmlform.ParameterCollection.Add("MemberCode", dto.MemberCode);
                    htmlform.ParameterCollection.Add("EduTeamName", dto.EduTeamName);
                    
                    //htmlform.ParameterCollection.Add("TimeRange", dto.DateFrom.ToString("yyyy/MM/dd") + "~" + dto.DateTo.ToString("yyyy/MM/dd"));
                    htmlform.ParameterCollection.Add("JobCode", dto.MemberType);
                    EduTeamMemberRundownDto rundown = service.GetEduTeamMemberRundownByMemberAndEduTerm(edutermid, dto.MemberID);
                    if (rundown != null)
                    {
                        
                        htmlform.ParameterCollection.Add("CoachName", rundown.CoachName);
                    }
                }

                //外帶評估對象資訊
                if (currentinstance.EvalTargetID != null)
                {
                    string evaltargetid = "";
                    if (currentinstance.EvalTargetID == null || currentinstance.EvalTargetID == "")
                    {
                        if (CurrentMember != null)
                        {
                            evaltargetid = CurrentMember.MemberID;
                        }
                    }
                    else
                    {
                        evaltargetid = currentinstance.EvalTargetID;
                    }
                    MemberDto evalmember = service.ReadMember(evaltargetid);
                    htmlform.ParameterCollection.Add("EvalMemberName", evalmember.Name);
                    htmlform.ParameterCollection.Add("EvalMemberCode", evalmember.MemberCode);
                    htmlform.ParameterCollection.Add("EvalEmpCode", evalmember.IsHospMember);
                    htmlform.ParameterCollection.Add("EvalJobCode", evalmember.MemberType);
                    htmlform.ParameterCollection.Add("EvalEduTeamName", evalmember.EduTeamName);
                    htmlform.ParameterCollection.Add("EvalTimeRange", evalmember.DateFrom.ToString("yyyy/MM/dd") + "~" + evalmember.DateTo.ToString("yyyy/MM/dd"));
                    htmlform.ParameterCollection.Add("EvalTimeRangeMD", evalmember.DateFrom.ToString("MM月dd日") + "~" + evalmember.DateTo.ToString("MM月dd日"));


                    V_KmuEmpDto evaltaremp = service.GetVKmuEmpByEmpCode(evalmember.IsHospMember);
                    if (evaltaremp != null)
                    {

                        if (evaltaremp.SEX == 'F')
                        {
                            htmlform.ParameterCollection.Add("EvalTargetSex", "女");
                        }
                        else if (evaltaremp.SEX == 'M')
                        {
                            htmlform.ParameterCollection.Add("EvalTargetSex", "男");
                        }
                        else
                        {
                            htmlform.ParameterCollection.Add("EvalTargetSex", "");
                        }
                        btnQueryEvalTarget.NavigateUrl = "EduMemberTermQueryNew.aspx?empcode=" + evaltaremp.Empcode;
                    }


                    frmUserInfo.Attributes.Add("src", "UserInfo.aspx?empcode=" + evalmember.IsHospMember);
                    frmUserInfo.Attributes["height"] = "210";

                    

                    if(currentinstance.FORM_TEMPLATES.ALLOW_VIEW_EVALTARGETDATA)
                    {
                        btnQueryEvalTarget.Visible = true;
                    }
                    else
                    {
                        btnQueryEvalTarget.Visible = true;
                    }

                }
                else
                {
                    frmUserInfo.Visible = false;
                }


                htmlform.ParameterCollection.Add("EmpCode", this.EmpCode);
                htmlform.ParameterCollection.Add("EmpName", this.EmpName);



                List<HtmlFormUtility.Components.HtmlForm> list = htmlform.Query(instanceid, true, true, false);

                foreach (HtmlFormUtility.Components.HtmlForm beforeform in htmlform.BeforeForms)
                {
                    if (beforeform.HasHindField)
                    {
                        frmUserInfo.Visible = false;
                        break;
                    }

                }
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

                        if (emp.SEX == 'F')
                        {
                            htmlform.ParameterCollection.Add("NextTargetSex", "女");
                        }
                        else if (emp.SEX == 'M')
                        {
                            htmlform.ParameterCollection.Add("NextTargetSex", "男");
                        }
                        else
                        {
                            htmlform.ParameterCollection.Add("NextTargetSex", "");
                        }
                    }

                    if (htmlform.AfterInstances[0].FORM_TEMPLATES.TEMPLATE_REMARK == "C")
                    {
                        panChoiceTeacher.Visible = true;
                        frameChoiceTeacher.Attributes.Add("src", "ChoiceTeacherInForm.aspx?instance_id=" + htmlform.AfterInstances[0].INSTANCE_ID.ToString());
                    }
                }


                Session[ViewState["CurrentInstanceID"] + "htmlform"] = htmlform;
                rblIsPass.Visible = htmlform.CurrentInstance.FORM_TEMPLATES.NEEDPASS;

                if (htmlform.CurrentInstance.TargetID == this.EmpCode && htmlform.CurrentInstance.FORM_TEMPLATES.ALLOW_TAKEBACK && 
				(htmlform.AfterInstances.OrderBy(c => c.TEMPLATE_ID).FirstOrDefault() != null &&  htmlform.AfterInstances.OrderBy(c => c.TEMPLATE_ID).FirstOrDefault().Status == "0")
				//(htmlform.AfterInstances.OrderBy(c => c.TEMPLATE_ID).FirstOrDefault() == null || (htmlform.AfterInstances.OrderBy(c => c.TEMPLATE_ID).FirstOrDefault() != null &&  htmlform.AfterInstances.OrderBy(c => c.TEMPLATE_ID).FirstOrDefault().Status == "0")) 
				&& htmlform.CurrentInstance.Status != "0")
                {
                    btnTakeBack.Visible = true;
                }


                if(htmlform.CurrentInstance.IsPass!=null)
                {
                    rblIsPass.SelectedValue = htmlform.CurrentInstance.IsPass.Value.ToString().ToLower();
                }
                else
                {
                    rblIsPass.SelectedValue = null;
                }
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
            //if (form == null)
            //{
            //    form = new HtmlFormUtility.Components.HtmlForm();
            //    form.Query(Convert.ToInt32(ViewState["CurrentInstanceID"]), true, true, false);
            //    Session[ViewState["CurrentInstanceID"] + "htmlform"] = form;
            //}

            HtmlFormUtility.FORM_INSTANCE_TARGETS tar = form.CurrentInstance.FORM_INSTANCE_TARGETS.Where(c => c.TargetID.ToUpper() == this.EmpCode).FirstOrDefault();
            if(tar == null)
            {
                tar = form.CurrentInstance.FORM_INSTANCE_TARGETS.FirstOrDefault();
            }
            string status = tar.Status;

            bool? ispass = null;

            if (rblIsPass.Visible)
            {
                if (rblIsPass.SelectedValue != null && rblIsPass.SelectedValue != "")
                {
                    ispass = Convert.ToBoolean(rblIsPass.SelectedValue);
                }
            }



            if (sender == btn_submit)
            {
                if (form.CurrentInstance.FORM_TEMPLATES.NEEDPASS)
                {
                    if (rblIsPass.SelectedValue == null || rblIsPass.SelectedValue == "")
                    {
                        throw new Exception("請選擇是否通過");
                    }
                }

                form.Submit(Request.Form, this.EmpCode, true, ispass);
            }

            if (sender == btn_presave)
            {
                form.PreSave(Request.Form, this.EmpCode, ispass);

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

                Response.Redirect("ToDoList.aspx");
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
            if(form.ReadOnly)
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

        //bool check = false;
        //foreach (HtmlFormUtility.FORM_INSTANCES ins in htmlform.AfterInstances)
        //{
        //    if (ins.Status != "0")
        //    {
        //        check = true;
        //    }
        //}

        //if (check)
        //    htmlform.ReadOnly = true;

        html += htmlform.InstanceDocument.DocumentNode.InnerHtml;

        //if (check)
        //{
        //    foreach (HtmlFormUtility.Components.HtmlForm afterform in htmlform.AfterForms)
        //    {
        //        if (afterform.CurrentInstance.Status != "0" && afterform.CurrentInstance.FORM_TEMPLATES.DISPLAY_TO_EVALTARGET == true)
        //        {
        //            afterform.ReadOnly = true;
        //            html += afterform.InstanceDocument.DocumentNode.InnerHtml;
        //        }
        //    }
        //}


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

    protected void btnReturn_Click(object sender, EventArgs e)
    {
        HtmlFormUtility.Components.HtmlForm htmlform = Session[ViewState["CurrentInstanceID"] + "htmlform"] as HtmlFormUtility.Components.HtmlForm;
        var lastinstance = htmlform.BeforeInstances.OrderBy(c=> c.TEMPLATE_ID).LastOrDefault();
        if(lastinstance == null)
        {
            ShowMessage("退回失敗：沒有上位填寫者");
            return;
        }
        int instanceid = htmlform.BeforeInstances.OrderBy(c=> c.TEMPLATE_ID).LastOrDefault().INSTANCE_ID;
        if(tbReturnReason.Text.Trim() == "")
        {
            ShowMessage("請輸入退回原因");
            return;
        }
        bool success = service.WriteReturnLog(instanceid, this.EmpCode, tbReturnReason.Text);
        if(!success)
        {
            ShowMessage("儲存退回原因失敗，請重試");
            return;
        }


        success = service.ReturnFormInstanceTargetStatus(instanceid);
        
        if (!success)
        {
            ShowMessage("退回失敗,請重試");
            return;
        }
        else
        {
            Response.Redirect("ToDoList.aspx");
        }
    }


    protected void btnReturnToFirst_Click(object sender, EventArgs e)
    {
        HtmlFormUtility.Components.HtmlForm htmlform = Session[ViewState["CurrentInstanceID"] + "htmlform"] as HtmlFormUtility.Components.HtmlForm;
        var lastinstance = htmlform.BeforeInstances.OrderBy(c => c.TEMPLATE_ID).LastOrDefault();
        if (lastinstance == null)
        {
            ShowMessage("退回失敗：沒有上位填寫者");
            return;
        }

        if (tbReturnReason.Text.Trim() == "")
        {
            ShowMessage("請輸入退回原因");
            return;
        }


        bool success = false;

        foreach (var bins in htmlform.BeforeInstances.OrderByDescending(c => c.TEMPLATE_ID))
        {
            int instanceid = bins.INSTANCE_ID;

            success = service.WriteReturnLog(instanceid, this.EmpCode, tbReturnReason.Text);
            if (!success)
            {
                break;
            }

            success = service.ReturnFormInstanceTargetStatus(instanceid);

            if (!success)
            {
                break;
            }
        }




        if (!success)
        {
            ShowMessage("退回失敗,請重試");
            return;
        }
        else
        {
            Response.Redirect("ToDoList.aspx");
        }
    }

    protected void btnTakeBack_Click(object sender, EventArgs e)
    {
        HtmlFormUtility.Components.HtmlForm htmlform = Session[ViewState["CurrentInstanceID"] + "htmlform"] as HtmlFormUtility.Components.HtmlForm;
        
        int instanceid = htmlform.CurrentInstance.INSTANCE_ID;

        bool success = service.ReturnFormInstanceTargetStatus(instanceid);
        if (!success)
        {
            ShowMessage("取消失敗,請重試");
            return;
        }
        else
        {
            Response.Redirect("InstanceDetial.aspx?instance_id=" + Request.QueryString["instance_id"] + "&edutermid=" + Request.QueryString["edutermid"]);
        }
    }
}

