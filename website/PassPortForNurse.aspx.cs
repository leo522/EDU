using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Data;

using KMU.EduActivity.ApplicationLayer.DTO;
using Telerik.Web.UI;

public partial class PassPortForNurse : Page
{


    protected void ShowMessage(string message)
    {
        if (Master != null)
        {
            Label lbl1 = (Label)Master.FindControl("lbErrMsg");
        }
        //lbl1.Text = message;

        System.Web.UI.Page executingPage = HttpContext.Current.Handler as System.Web.UI.Page;
        ScriptManager objScriptManager = ScriptManager.GetCurrent(executingPage);

        string myScript = String.Format("alert('{0}');", JSStringEscape(message, false));

        ScriptManager.RegisterStartupScript(executingPage, executingPage.GetType(), "MessageBox" + new Guid().ToString(), myScript, true);
        //myScript = "<script>" + myScript + "</script>";
        //lbl1.Text = myScript;

    }

    protected void ShowMessageAndGo(string message, string url)
    {
        ShowMessage(message);
        System.Web.UI.Page executingPage = HttpContext.Current.Handler as System.Web.UI.Page;
        ScriptManager objScriptManager = ScriptManager.GetCurrent(executingPage);

        string myScript = String.Format("window.location ='{0}';", url);

        ScriptManager.RegisterStartupScript(executingPage, executingPage.GetType(), "Redirect" + new Guid().ToString(), myScript, true);
    }

    protected void ShowMessageAndGoBack(string message)
    {
        ShowMessage(message);
        System.Web.UI.Page executingPage = HttpContext.Current.Handler as System.Web.UI.Page;
        ScriptManager objScriptManager = ScriptManager.GetCurrent(executingPage);

        string myScript = "window.history.back();";

        ScriptManager.RegisterStartupScript(executingPage, executingPage.GetType(), "Redirect" + new Guid().ToString(), myScript, true);
    }

    protected void JSGoBackPage()
    {

        System.Web.UI.Page executingPage = HttpContext.Current.Handler as System.Web.UI.Page;
        ScriptManager objScriptManager = ScriptManager.GetCurrent(executingPage);

        string myScript = String.Format("window.history.back();");

        ScriptManager.RegisterStartupScript(executingPage, executingPage.GetType(), "GoBack" + new Guid().ToString(), myScript, true);

    }

    /// <returns>置換特殊字元之後的字串</returns>
    /// <remarks></remarks>
    private string JSStringEscape(string raw, bool inHtmlAttribute)
    {
        raw = raw.Replace("\r\n", "\\n").Replace("\r", "").Replace("\n", "\\n");
        if (inHtmlAttribute)
            raw = raw.Replace("\"", "&quot;").Replace("'", "\\'");
        else
            raw = raw.Replace("'", "\\'").Replace("\"", "\\\"");
        return raw;
    }



    //DataView dv = SqlDataSource1.Select(new DataSourceSelectArguments()) as DataView;
    //Label1.Text = dv[0][1].ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        (Master.FindControl("RadScriptManager1") as RadScriptManager).RegisterPostBackControl(btnSearch);
        (Master.FindControl("RadScriptManager1") as RadScriptManager).RegisterPostBackControl(ddlMultiEmp);
        if (IsPostBack) {

        } else {
        
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {

        if (!string.IsNullOrEmpty(txtSearchEmpCode.Text))
        {
            KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService service = new KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService();
            List<V_KmuEmpDto> list = service.SerachEmp(txtSearchEmpCode.Text.Trim());
            ddlMultiEmp.DataValueField = "Empcode";
            ddlMultiEmp.DataTextField = "DisplayName";
            ddlMultiEmp.DataSource = list;
            ddlMultiEmp.DataBind();

            if (list.Count == 0)
            {
                ddlMultiEmp.SelectedValue = null;
                panMultiEmp.Visible = false;
            }
            else if (list.Count > 1)
            {
                panMultiEmp.Visible = true;
                ddlMultiEmp.SelectedIndex = 0;
                if (list[0].Jobcode.ToUpper() == "CLERK" || list[0].Jobcode.ToUpper() == "R(PGY)" || list[0].Jobcode.ToUpper() == "GCLERK")
                {
                    string j = service.GetCurrentMemeberTypeByEmpCode(ddlMultiEmp.SelectedValue);
                    hfJobcode.Value = j;
                }
                else
                {
                    hfJobcode.Value = list[0].Jobcode;
                }
            }
            else
            {
                ddlMultiEmp.SelectedIndex = 0;
                panMultiEmp.Visible = false;
                if (list[0].Jobcode.ToUpper() == "CLERK" || list[0].Jobcode.ToUpper() == "R(PGY)" || list[0].Jobcode.ToUpper() == "GCLERK")
                {
                    string j = service.GetCurrentMemeberTypeByEmpCode(txtSearchEmpCode.Text.Trim());
                    hfJobcode.Value = j;
                }
                else
                {
                    hfJobcode.Value = list[0].Jobcode;
                }
            }
            ReadPassportData();

        }
        else
        {
            ShowMessage("資料尚未輸入完成，煩請確認，謝謝。");
        }

    }

    private void ReadPassportData()
    {
        
        KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService service = new KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService();

        hfTeamcode.Value = service.GetCurrentEduTeamCode(ddlMultiEmp.SelectedValue);
        if (ddlMultiEmp.SelectedValue == "1020640")
        {
            hfTeamcode.Value = "Western";
        }
        try
        {
            SqlDataSource2.DataBind();
            SqlDataSource3.DataBind();

            gvCheckForNurse.DataBind();
            GridView1.DataBind();
        }
        catch(Exception ex)
        {

        }
    }

    protected void btnResetText_Click(object sender, EventArgs e)
    {
        txtSearchEmpCode.Text = "";
        ddlMultiEmp.DataSource = null;
        ddlMultiEmp.DataBind();
        ddlJobCode.ClearSelection();
    }

    protected void gvCheckForNurse_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            try
            {
                Label lblCheckStatus = e.Row.FindControl("lblCheckStatus") as Label;
                Label lblCheckStatus1 = e.Row.FindControl("lblCheckStatus1") as Label;
                Label lblCheckStatus2 = e.Row.FindControl("lblCheckStatus2") as Label;
                lblCheckStatus.Style.Add("TEXT-ALIGN", "center");
                lblCheckStatus1.Style.Add("TEXT-ALIGN", "center");
                lblCheckStatus2.Style.Add("TEXT-ALIGN", "center");

                Label lblCheckDate = e.Row.FindControl("lblCheckDate") as Label;
                Label lblCheckDate1 = e.Row.FindControl("lblCheckDate1") as Label;
                Label lblCheckDate2 = e.Row.FindControl("lblCheckDate2") as Label;


                Label lblCheckResult = e.Row.FindControl("lblCheckResult") as Label;
                Label lblCheckResult1 = e.Row.FindControl("lblCheckResult1") as Label;
                Label lblCheckResult2 = e.Row.FindControl("lblCheckResult2") as Label;


                HiddenField hfbtnshow1 = e.Row.FindControl("hfbtnShow1") as HiddenField;
                HiddenField hfbtnshow2 = e.Row.FindControl("hfbtnShow2") as HiddenField;
                HiddenField hfbtnshow3 = e.Row.FindControl("hfbtnShow3") as HiddenField;

                HiddenField hfIsDisplay = e.Row.FindControl("hfIsDisplay") as HiddenField;

                Label lblDesignationTeacherNumber = e.Row.FindControl("lblCheckTeacher") as Label;
                Label lblDesignationTeacherNumber1 = e.Row.FindControl("lblCheckTeacher1") as Label;
                Label lblDesignationTeacherNumber2 = e.Row.FindControl("lblCheckTeacher2") as Label;

                HyperLink vdata1 = e.Row.FindControl("viewData1") as HyperLink;
                HyperLink vdata2 = e.Row.FindControl("viewData2") as HyperLink;
                HyperLink vdata3 = e.Row.FindControl("viewData3") as HyperLink;
                vdata1.Visible = false;
                vdata2.Visible = false;
                vdata3.Visible = false;
                if (!string.IsNullOrEmpty(lblCheckStatus.Text))
                {
                    if (lblCheckStatus.Text.Equals("1"))
                    {
                        lblCheckStatus.Text = "審核中";
                        lblCheckStatus.ForeColor = Color.Blue;
                        lblCheckDate.Text = "";
                        lblCheckResult.Text = "";
                        lblDesignationTeacherNumber.Text = "";
                    }
                    else if (lblCheckStatus.Text.Equals("2"))
                    {
                        lblCheckStatus.Visible = false;
                        lblCheckResult.Text = (lblCheckResult.Text.Equals("True")) ? "通過" : "未通過";
                        if (lblCheckResult.Text.Equals("通過"))
                        {
                            lblCheckDate.ForeColor = Color.Green;
                            lblCheckResult.ForeColor = Color.Green;
                            lblDesignationTeacherNumber.ForeColor = Color.Green;
                        }
                        else
                        {
                            lblCheckDate.ForeColor = Color.Red;
                            lblCheckResult.ForeColor = Color.Red;
                            lblDesignationTeacherNumber.ForeColor = Color.Red;
                        }
                        vdata1.Visible = true;
                    }
                    else if(lblCheckStatus.Text.Equals("N/A"))
                    {
                        lblCheckStatus.Text = "";
                        lblCheckResult.Text = "";
                        lblCheckDate.Text = "";
                        lblDesignationTeacherNumber.Text = "";
                    }
                }
                else
                {
                    lblCheckStatus.Text = "未考核";
                    lblCheckStatus.ForeColor = Color.Gray;
                    if (hfbtnshow1.Value == "1")
                    {
                    }
                    else
                    {
                        lblCheckStatus.Visible = false;
                    }

                }

                if (!string.IsNullOrEmpty(lblCheckStatus1.Text))
                {
                    if (lblCheckStatus1.Text.Equals("1"))
                    {
                        lblCheckStatus1.Text = "審核中";
                        lblCheckStatus1.ForeColor = Color.Blue;
                        lblCheckDate1.Text = "";
                        lblCheckResult1.Text = "";
                        lblDesignationTeacherNumber1.Text = "";
                    }
                    else if (lblCheckStatus1.Text.Equals("2"))
                    {
                        lblCheckStatus1.Visible = false;
                        lblCheckResult1.Text = (lblCheckResult1.Text.Equals("True")) ? "通過" : "未通過";
                        if (lblCheckResult1.Text.Equals("通過"))
                        {
                            lblCheckDate1.ForeColor = Color.Green;
                            lblCheckResult1.ForeColor = Color.Green;
                            lblDesignationTeacherNumber1.ForeColor = Color.Green;
                        }
                        else
                        {
                            lblCheckDate1.ForeColor = Color.Red;
                            lblCheckResult1.ForeColor = Color.Red;
                            lblDesignationTeacherNumber1.ForeColor = Color.Red;
                        }
                        vdata2.Visible = true;
                    }
                    else if (lblCheckStatus1.Text.Equals("N/A"))
                    {
                        lblCheckStatus1.Text = "";
                        lblCheckResult1.Text = "";
                        lblCheckDate1.Text = "";
                        lblDesignationTeacherNumber1.Text = "";
                    }
                }
                else
                {
                    lblCheckStatus1.Text = "未考核";
                    lblCheckStatus1.ForeColor = Color.Gray;
                    if (hfbtnshow2.Value == "1")
                    {
                    }
                    else
                    {
                        lblCheckStatus1.Visible = false;
                    }
                }

                if (!string.IsNullOrEmpty(lblCheckStatus2.Text))
                {
                    if (lblCheckStatus2.Text.Equals("1"))
                    {
                        lblCheckStatus2.Text = "審核中";
                        lblCheckStatus2.ForeColor = Color.Blue;
                        lblCheckDate2.Text = "";
                        lblCheckResult2.Text = "";
                        lblDesignationTeacherNumber2.Text = "";
                    }
                    else if (lblCheckStatus2.Text.Equals("2"))
                    {
                        lblCheckStatus2.Visible = false;
                        lblCheckResult2.Text = (lblCheckResult2.Text.Equals("True")) ? "通過" : "未通過";
                        if (lblCheckResult2.Text.Equals("通過"))
                        {
                            lblCheckDate2.ForeColor = Color.Green;
                            lblCheckResult2.ForeColor = Color.Green;
                            lblDesignationTeacherNumber2.ForeColor = Color.Green;
                        }
                        else
                        {
                            lblCheckDate2.ForeColor = Color.Red;
                            lblCheckResult2.ForeColor = Color.Red;
                            lblDesignationTeacherNumber2.ForeColor = Color.Red;
                        }
                        vdata3.Visible = true;
                    }
                    else if (lblCheckStatus2.Text.Equals("N/A"))
                    {
                        lblCheckStatus2.Text = "";
                        lblCheckResult2.Text = "";
                        lblCheckDate2.Text = "";
                        lblDesignationTeacherNumber2.Text = "";
                    }
                }
                else
                {
                    lblCheckStatus2.Text = "未考核";
                    lblCheckStatus2.ForeColor = Color.Gray;
                    if (hfbtnshow3.Value == "1")
                    {
                    }
                    else
                    {
                        lblCheckStatus2.Visible = false;
                    }
                }


                //Label lbjob = FormView2.FindControl("jobcodeLabel") as Label;
                //if (lbjob != null)
                //{
                //    if (hfIsDisplay.Value == "0" && lbjob.Text != "INT")
                //    {
                //        lblCheckStatus.Visible = false;
                //        lblCheckStatus1.Visible = false;
                //        lblCheckStatus2.Visible = false;


                //        lblCheckDate.Visible = false;
                //        lblCheckDate1.Visible = false;
                //        lblCheckDate2.Visible = false;


                //        lblCheckResult.Visible = false;
                //        lblCheckResult1.Visible = false;
                //        lblCheckResult2.Visible = false;

                //        lblDesignationTeacherNumber.Visible = false;
                //        lblDesignationTeacherNumber1.Visible = false;
                //        lblDesignationTeacherNumber2.Visible = false;
                //    }
                //}

            }
            catch(Exception ex)
            {
                ShowMessage(ex.Message);
            }

        }
    }
    protected void ddlJobCode_DataBound(object sender, EventArgs e)
    {
        
    }
    protected void ddlMultiEmp_SelectedIndexChanged(object sender, EventArgs e)
    {
        KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService service = new KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService();
        V_KmuEmpDto list = service.SerachEmp(ddlMultiEmp.SelectedValue).FirstOrDefault();

        if (list != null)
        {

            if (list.Jobcode.ToUpper() == "CLERK" || list.Jobcode.ToUpper() == "R(PGY)" || list.Jobcode.ToUpper() == "GCLERK")
            {
                string j = service.GetCurrentMemeberTypeByEmpCode(ddlMultiEmp.SelectedValue);
                hfJobcode.Value = j;
            }
            else
            {
                hfJobcode.Value = list.Jobcode;
                if(list.Jobcode == "")
                {
                    hfJobcode.Value = " ";
                }
                

            }
        }


        ReadPassportData();
    }
    protected void SqlDataSource2_DataBinding(object sender, EventArgs e)
    {

    }
}