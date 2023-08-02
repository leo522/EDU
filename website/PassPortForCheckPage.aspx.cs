using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KMU.EduActivity.ApplicationLayer.DTO;
using KMU.EduActivity.ApplicationLayer.Services;

public partial class PassPortForCheckPage : AuthPage
{
    
    int checkboxCaseHistoryStatus = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        lblHistoryNumber.Visible = false;
        txtCaseHistoryNumber.Visible = false;
        hfJobCode.Value = this.JobCode;
        if (!IsPostBack)
        {
            
            if (string.IsNullOrEmpty(Session["page1times"].ToString()) || string.IsNullOrEmpty(Session["page1itemName"].ToString()) || string.IsNullOrEmpty(Session["page1itemCode"].ToString()))
            {
                ShowMessage("Error");
                Response.Redirect("~/PassPortDetailPageCopy.aspx");
            }
            else
            {
                lblCheckTimes.Text = Session["page1times"].ToString();
                lblItemName.Text = Session["page1itemName"].ToString();
                lblItemCode.Text = Session["page1itemCode"].ToString();
                lblCheckStatus.Text = Session["page1checkStatus"].ToString();
                lblApplicationMemberNumber.Text = this.EmpCode;
                lblApplicationDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                
            }
            //if (lblCheckTimes.Text == "3")
            //{
            //    rCBTeacherName.DataSourceID = "dsVS";
            //}
            //else
            //{
                rCBTeacherName.DataSourceID = "dsHigher";
            //}

            rCBHosp.SelectedValue = this.HospCode;

            List<PassPortStudentApplicationItemFailLogDto> rejectlog = service.GetPassportRejectLog(lblApplicationMemberNumber.Text, Convert.ToInt32(lblItemCode.Text));

            if(rejectlog.Count>0)
            {
                panRejectLog.Visible = true;

                string rejecthtml = "";
                foreach(var log in rejectlog)
                {
                    
                    rejecthtml += "<b>";
                    if (log.CheckDate.HasValue)
                    {
                        rejecthtml += "(" + log.CheckDate.Value.ToString("yyyy/MM/dd") + ")";
                    }
                    rejecthtml += log.TeacherName + "</b>：<br>";
                    rejecthtml += log.TeacherRemark+"<br><br>";
                }
                liRejectLog.Text = rejecthtml;
            }
            else
            {
                panRejectLog.Visible = false;
            }

        }
    }

    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        if (rdBtnImplementObject1.Checked == true || (rdBtnImplementObject2.Checked == true && !string.IsNullOrEmpty(txtCaseHistoryNumber.Text)))
        {
            checkboxCaseHistoryStatus = 1;
            if (rdBtnImplementObject1.Checked == true)
            {
                lblImplementModel.Text = rdBtnImplementObject1.Text;
            }
            else if (rdBtnImplementObject2.Checked == true)
            {
                lblImplementModel.Text = rdBtnImplementObject2.Text;
                lblCaseHistoryNumber.Text = txtCaseHistoryNumber.Text;
            }
        }

        if (rCBHosp.SelectedItem != null && rCBTeacherName.SelectedItem != null && rDPImplementDate.SelectedDate != null && !string.IsNullOrEmpty(rtxtImplementPlace.Text) && checkboxCaseHistoryStatus == 1)
        {
            hfJobCode.Value = this.JobCode;
            System.Web.UI.Page executingPage = HttpContext.Current.Handler as System.Web.UI.Page;
            ScriptManager objScriptManager = ScriptManager.GetCurrent(executingPage);
            string myScript = "alert('送出審核訊息成功');";
            ScriptManager.RegisterStartupScript(executingPage, executingPage.GetType(), "MessageBox" + new Guid().ToString(), myScript, true);
            try
            {
                SqlDataSource4.Insert();
            }
            catch (Exception ex)
            {

            }

            Response.Redirect("~/PassPortDetailPageCopy.aspx");

        }
        else
        {
            System.Web.UI.Page executingPage = HttpContext.Current.Handler as System.Web.UI.Page;
            ScriptManager objScriptManager = ScriptManager.GetCurrent(executingPage);
            string myScript = "alert('資料尚未完成');";
            ScriptManager.RegisterStartupScript(executingPage, executingPage.GetType(), "MessageBox" + new Guid().ToString(), myScript, true);
        }
    }
    protected void btnBackPage_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/PassPortDetailPageCopy.aspx");
    }
    protected void rdBtnImplementObject2_CheckedChanged(object sender, EventArgs e)
    {
        lblHistoryNumber.Visible = true;
        txtCaseHistoryNumber.Visible = true;
    }
    protected void rdBtnImplementObject1_CheckedChanged(object sender, EventArgs e)
    {
        lblHistoryNumber.Visible = false;
        txtCaseHistoryNumber.Visible = false;
    }
}