using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Data.SqlClient;

public partial class PassPortDetailPage : AuthPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (this.JobCode.ToUpper() == "CLERK" || this.JobCode.ToUpper() == "R(PGY)" || this.JobCode.ToUpper() == "GCLERK")
            {
                string j =  service.GetCurrentMemeberTypeByEmpCode(this.EmpCode);
                lblObject.Text = j;
                lblObject2.Text = j;
                hfJobcode.Value = j;
            }
            else
            {
                lblObject.Text = this.JobCode;
                lblObject2.Text = this.JobCode;
                hfJobcode.Value = this.JobCode;
            }
            hfEmpcode.Value = this.EmpCode;
            hfTeamcode.Value = service.GetCurrentEduTeamCode(this.EmpCode);

            if (this.EmpCode == "1020640")
            {
                hfJobcode.Value = "CKAC";
                hfTeamcode.Value = "Western";
            }
            try
            {
                List<string> result = service.GetPassportFinishRate(this.EmpCode, hfJobcode.Value, hfTeamcode.Value);
                lbNotComplete.Text = result[0];
                lbWait.Text = result[1];
                lbComplete.Text = result[2];
            }
            catch(Exception ex)
            {

            }

        }
    }
    protected void gvPassPortDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            Label lblCheckStatus = e.Row.FindControl("lblCheckStatus") as Label;
            Label lblCheckStatus1 = e.Row.FindControl("lblCheckStatus1") as Label;
            Label lblCheckStatus2 = e.Row.FindControl("lblCheckStatus2") as Label;


            Label lblCheckDate = e.Row.FindControl("lblCheckDate") as Label;
            Label lblCheckDate1 = e.Row.FindControl("lblCheckDate1") as Label;
            Label lblCheckDate2 = e.Row.FindControl("lblCheckDate2") as Label;


            Label lblCheckResult = e.Row.FindControl("lblCheckResult") as Label;
            Label lblCheckResult1 = e.Row.FindControl("lblCheckResult1") as Label;
            Label lblCheckResult2 = e.Row.FindControl("lblCheckResult2") as Label;

            Button btnSendCehck1 = e.Row.FindControl("btnSendCheck1") as Button;
            Button btnSendCehck2 = e.Row.FindControl("btnSendCheck2") as Button;
            Button btnSendCehck3 = e.Row.FindControl("btnSendCheck3") as Button;

            HiddenField hfbtnshow1 = e.Row.FindControl("hfbtnShow1") as HiddenField;
            HiddenField hfbtnshow2 = e.Row.FindControl("hfbtnShow2") as HiddenField;
            HiddenField hfbtnshow3 = e.Row.FindControl("hfbtnShow3") as HiddenField;


            Label lblDesignationTeacherNumber = e.Row.FindControl("lblDesignationTeacherNumber") as Label;
            Label lblDesignationTeacherNumber1 = e.Row.FindControl("lblDesignationTeacherNumber1") as Label;
            Label lblDesignationTeacherNumber2 = e.Row.FindControl("lblDesignationTeacherNumber2") as Label;
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
                    lblCheckStatus.Visible = true;
                    btnSendCehck1.Visible = true;
                    //lblDesignationTeacherNumber.Text = "";
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
                else if (lblCheckStatus.Text.Equals("N/A"))
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
                    btnSendCehck1.Visible = true;
                }
                else
                {
                    btnSendCehck1.Visible = false;
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
                    lblCheckStatus1.Visible = true;
                    btnSendCehck2.Visible = true;
                    //lblDesignationTeacherNumber1.Text = "";
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
                    btnSendCehck2.Visible = true;
                }
                else
                {
                    btnSendCehck2.Visible = false;
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
                    lblCheckStatus2.Visible = true;
                    btnSendCehck3.Visible = true;
                    //lblDesignationTeacherNumber2.Text = "";
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
                    btnSendCehck3.Visible = true;
                }
                else
                {
                    btnSendCehck3.Visible = false;
                    lblCheckStatus2.Visible = false;
                }
            }
        }
    }
    protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {

    }

    protected void gvPassPortDetail_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (sender is Button)
        {
            GridViewRow myRow = (GridViewRow)((Button)sender).NamingContainer;
            int index = myRow.RowIndex;
            GridView gv = myRow.Parent.Parent as GridView;
            GridViewRow selectedRow = gv.Rows[index];

            if (e.CommandName == "getDataRow")
            {
                Label lblItemCode = (Label)(selectedRow.FindControl("lblItemCode"));
                Label lblItemName = (Label)(selectedRow.FindControl("lblItemName"));

                Label lblCheckResult = (Label)(selectedRow.FindControl("lblCheckResult"));
                Label lblCheckResult1 = (Label)(selectedRow.FindControl("lblCheckResult1"));
                Label lblCheckResult2 = (Label)(selectedRow.FindControl("lblCheckResult2"));

                Label lblCheckStatus = (Label)(selectedRow.FindControl("lblCheckStatus"));
                Label lblCheckStatus1 = (Label)(selectedRow.FindControl("lblCheckStatus1"));
                Label lblCheckStatus2 = (Label)(selectedRow.FindControl("lblCheckStatus2"));

                Button btnSendCehck1 = selectedRow.FindControl("btnSendCheck1") as Button;
                Button btnSendCehck2 = selectedRow.FindControl("btnSendCheck2") as Button;
                Button btnSendCehck3 = selectedRow.FindControl("btnSendCheck3") as Button;

                int times = 0;

                if (sender == btnSendCehck1)
                {
                    //times = 5;
                    times = 1;
                }
                if (sender == btnSendCehck2)
                {
                    //times = 5;
                    times = 2;
                }
                if (sender == btnSendCehck3)
                {
                    //times = 5;
                    times = 3;
                }


                else if (lblCheckResult.Text == "" && lblCheckResult1.Text == "" && lblCheckResult2.Text == "")
                {
                    times = 1;

                }
                else if ((lblCheckResult.Text.Equals("通過") || lblCheckResult.Text.Equals("未通過")) && lblCheckResult1.Text == "" && lblCheckResult2.Text == "")
                {
                    times = 2;
                }
                else if ((lblCheckResult.Text.Equals("通過") || lblCheckResult.Text.Equals("未通過")) && (lblCheckResult1.Text.Equals("通過") || lblCheckResult1.Text.Equals("未通過")) && lblCheckResult2.Text == "")
                {
                    times = 3;
                }
                else if ((lblCheckResult.Text.Equals("通過") || lblCheckResult.Text.Equals("未通過")) && (lblCheckResult1.Text.Equals("通過") || lblCheckResult1.Text.Equals("未通過")) || (lblCheckResult2.Text.Equals("通過") || lblCheckResult2.Text.Equals("未通過")))
                {
                    times = 4;
                }




                if (times != 0)
                {
                    if (times == 4)
                    {
                        ShowMessage("已經完成所有考核");
                    }

                    //else if (times == 5)
                    //{
                    //    ShowMessage("尚有考核未完成審核，請等候審核通過後，再繼續下個階段考核申請，謝謝。");
                    //}

                    else
                    {
                        
                        Session["page1times"] = times;
                        Session["page1itemName"] = lblItemName.Text;
                        Session["page1itemCode"] = lblItemCode.Text;
                        Session["page1checkStatus"] = 1;
                        Response.Redirect("~/PassPortForCheckPage.aspx");
                    }
                }

            }
        }
    }
    protected void btnSendCheck3_Click(object sender, EventArgs e)
    {
        GridViewRow myRow = (GridViewRow)((Button)sender).NamingContainer;
        int index = myRow.RowIndex;
        GridView gv = myRow.Parent.Parent as GridView;
        GridViewRow selectedRow = gv.Rows[index];


        Label lblItemCode = (Label)(selectedRow.FindControl("lblItemCode"));
        Label lblItemName = (Label)(selectedRow.FindControl("lblItemName"));

        Label lblCheckResult = (Label)(selectedRow.FindControl("lblCheckResult"));
        Label lblCheckResult1 = (Label)(selectedRow.FindControl("lblCheckResult1"));
        Label lblCheckResult2 = (Label)(selectedRow.FindControl("lblCheckResult2"));

        Label lblCheckStatus = (Label)(selectedRow.FindControl("lblCheckStatus"));
        Label lblCheckStatus1 = (Label)(selectedRow.FindControl("lblCheckStatus1"));
        Label lblCheckStatus2 = (Label)(selectedRow.FindControl("lblCheckStatus2"));

        Button btnSendCehck1 = selectedRow.FindControl("btnSendCheck1") as Button;
        Button btnSendCehck2 = selectedRow.FindControl("btnSendCheck2") as Button;
        Button btnSendCehck3 = selectedRow.FindControl("btnSendCheck3") as Button;

        int times = 0;

        if (sender == btnSendCehck1)
        {
            //times = 5;
            times = 1;
        }
        if (sender == btnSendCehck2)
        {
            //times = 5;
            times = 2;
        }
        if (sender == btnSendCehck3)
        {
            //times = 5;
            times = 3;
        }

        else if (lblCheckResult.Text == "" && lblCheckResult1.Text == "" && lblCheckResult2.Text == "")
        {
            times = 1;

        }
        else if ((lblCheckResult.Text.Equals("通過") || lblCheckResult.Text.Equals("未通過")) && lblCheckResult1.Text == "" && lblCheckResult2.Text == "")
        {
            times = 2;
        }
        else if ((lblCheckResult.Text.Equals("通過") || lblCheckResult.Text.Equals("未通過")) && (lblCheckResult1.Text.Equals("通過") || lblCheckResult1.Text.Equals("未通過")) && lblCheckResult2.Text == "")
        {
            times = 3;
        }
        else if ((lblCheckResult.Text.Equals("通過") || lblCheckResult.Text.Equals("未通過")) && (lblCheckResult1.Text.Equals("通過") || lblCheckResult1.Text.Equals("未通過")) || (lblCheckResult2.Text.Equals("通過") || lblCheckResult2.Text.Equals("未通過")))
        {
            times = 4;
        }




        if (times != 0)
        {
            if (times == 4)
            {
                ShowMessage("已經完成所有考核");
            }

            //else if (times == 5)
            //{
            //    ShowMessage("尚有考核未完成審核，請等候審核通過後，再繼續下個階段考核申請，謝謝。");
            //}

            else
            {
                Session["page1times"] = times;
                Session["page1itemName"] = lblItemName.Text;
                Session["page1itemCode"] = lblItemCode.Text;
                Session["page1checkStatus"] = 1;
                Response.Redirect("~/PassPortForCheckPage.aspx");
            }
        }


    }
}