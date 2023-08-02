using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KMU.EduActivity.ApplicationLayer.DTO;
using Telerik.Web.UI;

public partial class ChoiceTeacher : AuthPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["instance_id"] == null)
            {
                lbError.Text = "參數傳遞錯誤";
                panChoice.Visible = false;
                return;
            }

            List<HtmlFormUtility.FORM_INSTANCE_TARGETS> tars = service.GetInstanceTargets(Convert.ToInt32(Request.QueryString["instance_id"]));
            if (tars.Count > 0 && tars[0].TargetID != null && tars[0].TargetID != "")
            {
                VsSelector1.SelectedValue = tars[0].TargetID;
                //btnSelect.Visible = false;
                //VsSelector1.Enabled = false;
            }
        }
    }


    protected void btnSelect_Click(object sender, EventArgs e)
    {
        string teacherid = "";

        if (VsSelector1.SelectedValue == "" || VsSelector1.SelectedValue == null)
        {
            ShowMessage("請選擇老師");
            return;
        }
        teacherid = VsSelector1.SelectedValue;

        string result = service.SetMyChoiceTeacher(Convert.ToInt32(Request.QueryString["instance_id"]), teacherid);

        if (result != null)
        {
            ShowMessage("設定失敗：" + result);
        }
        else
        {
            ShowMessage("設定完成");
            btnSelect.Visible = false;
            VsSelector1.Enabled = false;
            
        }
    }
}