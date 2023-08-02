using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KMU.EduActivity.ApplicationLayer.DTO;
using KMU.EduActivity.ApplicationLayer.Services;

public partial class PassPortView : Page
{
    
    int checkboxCaseHistoryStatus = 0;


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

    protected void Page_Load(object sender, EventArgs e)
    {
        EduActivityAppService service = new EduActivityAppService();        

        if (!IsPostBack)
        {
            
            if (Request.QueryString["applicationid"] == null)
            {
                ShowMessageAndGo("參數錯誤", "~/ToDoList.aspx");
            }
            else
            {
                var dto = service.GetPassportApplicationItemByID(Convert.ToInt32(Request.QueryString["applicationid"]));
                if (dto != null)
                {
                    lblItemName.Text = dto.ItemName;
                    lbTeacherName.Text = dto.TeacherName;
                    lbImplementTime.Text = dto.ImplementDate.HasValue ? dto.ImplementDate.Value.ToString("yyyy/MM/dd") : "";
                    lbImplementPlace.Text = dto.ImplementPlace;
                    lbImplementObject.Text = dto.ImplementObject;
                    lbImplementChartNo.Text = dto.CaseHistoryNumber;
                    txtRemark.Text = dto.StudentRemark;
                    TeacherRemark.Text = dto.TeacherRemark;



                    List<PassPortStudentApplicationItemFailLogDto> rejectlog = service.GetPassportRejectLog(dto.ApplicationMemberNumber, dto.ItemCode.Value);

                    if (rejectlog.Count > 0)
                    {
                        panRejectLog.Visible = true;

                        string rejecthtml = "";
                        foreach (var log in rejectlog)
                        {

                            rejecthtml += "<b>";
                            if (log.CheckDate.HasValue)
                            {
                                rejecthtml += "(" + log.CheckDate.Value.ToString("yyyy/MM/dd") + ")";
                            }
                            rejecthtml += log.TeacherName + "</b>：<br>";
                            rejecthtml += log.TeacherRemark + "<br><br>";
                        }
                        liRejectLog.Text = rejecthtml;
                    }
                    else
                    {
                        panRejectLog.Visible = false;
                    }
                }
            }
            

        }
    }

}