using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PassPortCheckForTeacher : AuthPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblEmpCode.Text = this.EmpCode;
        lblDataCount.Text = gvCheckForTeacher.Rows.Count.ToString();
    }

    protected void gvCheckForTeacher_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        GridViewRow selectedRow = gvCheckForTeacher.Rows[index];
        string checkDate = DateTime.Now.ToString("yyyy-MM-dd");       

        if (e.CommandName=="submitResult")
        {
            string checkResult;
            Label lblApplicationIDAuto = (Label)(selectedRow.FindControl("lblApplicationIDAuto"));

            lblApplicationID.Text = lblApplicationIDAuto.Text;

            RadioButton rdBtnPass = (RadioButton)(selectedRow.FindControl("rdBtnPass"));
            RadioButton rdBtnFail = (RadioButton)(selectedRow.FindControl("rdBtnFail"));
            if (rdBtnPass.Checked==true&&rdBtnFail.Checked==false)
            {
                checkResult =  "True";
                lblCheckResult.Text = checkResult;
                lblCheckStatus.Text = "2";
                lblCheckDate.Text = checkDate;
                SqlDataSource2.Update();
                ShowMessage("送出成功");
                Response.Redirect("~/PassPortCheckForTeacher.aspx");
            }
            else if (rdBtnPass.Checked==false&&rdBtnFail.Checked==true)
            {
                checkResult = "False";
                lblCheckResult.Text = checkResult;
                lblCheckStatus.Text = "2";
                lblCheckDate.Text = checkDate;
                SqlDataSource2.Update();
                ShowMessage("送出成功");
                Response.Redirect("~/PassPortCheckForTeacher.aspx");
            }
            else
            {
                ShowMessage("考核結果還沒有選取喔!!");
            }
        }
    }
}