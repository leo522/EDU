using KMU.EduActivity.ApplicationLayer.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class EduMemberTermQueryNew : AuthPage
{
    private DataTable CurrentList
    {
        get
        {
            return ViewState["CurrentList"] as DataTable;
        }
        set
        {
            ViewState["CurrentList"] = value;
        }

    }
    private string CurrentTermID
    {
        get
        {
            return ViewState["CurrentTermID"] as string;
        }
        set
        {
            ViewState["CurrentTermID"] = value;
        }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["empcode"] != null)
            {
                if (Request.QueryString["edutermid"] != null)
                {
                    CurrentTermID = Request.QueryString["edutermid"];
                }
                VsSelector1.SelectedValue = Request.QueryString["empcode"];
                panAdmin.Visible = false;
            }
            else
            {
                VsSelector1.SelectedValue = this.EmpCode;

                if (this.AuthRoles.Contains("SuperAdmin") || this.AuthRoles.Contains("NurseD") || this.AuthRoles.Contains("DepSec") || this.AuthRoles.Contains("Admin"))
                {
                    panAdmin.Visible = true;
                }
                else
                {
                    panAdmin.Visible = false;
                }
            }

            ReadData();

            
        }
    }


    private void ReadData()
    {
        var data = service.QueryEduMemberTermWithPass(VsSelector1.SelectedValue, false, CurrentTermID);


        //        string template = @"
        //    <div id='{0}'>
        //        <h3>{1}</h3>
        //        <ul>
        //            {2}
        //        </ul>
        //    </div>";

        //        string contenttemplate = @"<li>{0}<ul>{1}</ul></li>";
        //        string dettemplate = @"<li><a href='InstanceDetial.aspx?instance_id={0}&edutermid={1}&mode=v' target='_blank'>{2}</a></li>";
        //        string scripttemplate = @"$(function () { $('#{divname}').accordion({ collapsible: true, active: false }); });";

        //        string fullhtml = "";
        //        string fullscript = "";
        //        foreach(var d in data)
        //        {
        //            string edutermid = d.EduTermID;
        //            string eduname = service.GetEduTermFullName(d.EduTermID) + "(" + d.TermRange + ")";
        //            string content = "";
        //            bool isfinish = true;
        //            fullscript += scripttemplate.Replace("{divname}", "div" + edutermid);

        //            foreach (var req in d.TermReqs)
        //            {
        //                string detstr = "";
        //                foreach (var det in req.MemberPassForms)
        //                {
        //                    detstr += string.Format(dettemplate, det.INSTANCE_ID.ToString(), edutermid, det.INSTANCE_NAME);
        //                }

        //                string finishstr = "";
        //                if (req.MemberPassCount >= req.ReqCount)
        //                {
        //                    finishstr = "<font color='blue'>(已完成)</font>";
        //                }
        //                content += string.Format(contenttemplate, "<b>課程需求：" + req.ReqName + "</b> (" + req.MemberPassCount.ToString() + "/" + req.ReqCount.ToString() + ")" + finishstr, detstr);
        //                if (req.MemberPassCount < req.ReqCount)
        //                {
        //                    isfinish = false;
        //                }
        //            }

        //            string odetstr = "";
        //            foreach(var det in d.OtherForms)
        //            {
        //                odetstr += string.Format(dettemplate, det.INSTANCE_ID.ToString(), edutermid, det.INSTANCE_NAME);
        //            }
        //            if(odetstr == "")
        //            {
        //                odetstr = "無";
        //            }
        //            content += string.Format(contenttemplate, "<b>已完成表單</b>", odetstr);

        //            if(isfinish)
        //            {
        //                eduname += " - <font color='blue'>已完成</font>";
        //            }

        //            string html = string.Format(template, "div" + edutermid, eduname, content);
        //            fullhtml += html;
        //        }
        //        ScriptManager objScriptManager = ScriptManager.GetCurrent(this.Page);

        //        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "divscript", fullscript, true);
        //        //lbscript.Text = "<script>" + fullscript + "</script>";
        //        Literal1.Text = fullhtml;
        ViewState["currentdata"] = data;
        RadTreeList1.DataSource = data;
        try
        {
            RadTreeList1.DataBind();
            RadTreeList1.ExpandAllItems();
        }
        catch (Exception ex)
        {

        }
    }



    protected void RadTreeList1_NeedDataSource(object sender, TreeListNeedDataSourceEventArgs e)
    {
        RadTreeList1.DataSource = ViewState["currentdata"];
    }
    protected void btnQuery_Click(object sender, EventArgs e)
    {
        ReadData();

        if (ViewState["currentdata"] != null)
        {

            frmUserInfo.Visible = true;
            frmUserInfo.Attributes.Add("src", "UserInfo.aspx?empcode=" + VsSelector1.SelectedValue);
            frmUserInfo.Attributes["height"] = "210";
        }
        else
        {
            frmUserInfo.Visible = false;
        }

    }
}