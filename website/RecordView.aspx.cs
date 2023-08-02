using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KMU.EduActivity.ApplicationLayer.DTO;
using KMU.EduActivity.ApplicationLayer.Services;
using ZXing;
using ZXing.QrCode;
using System.Drawing;
using Telerik.Web.UI;
using System.IO;
using System.Data;

public partial class RecordView : System.Web.UI.Page
{
    protected EduActivityAppService service = new EduActivityAppService();
    private string CurrentInstanceID
    {
        get
        {
            return "20170810000000000025";
            return Request.QueryString["InstanceID"];
        }
    }

    private string CurrentEmpCode
    {
        get
        {
            return Request.QueryString["EmpCode"];
        }
    }


    private RecordInstanceDto CurrentIns
    {
        get
        {
            return ViewState["CurrentIns"] as RecordInstanceDto;
        }
        set
        {
            ViewState["CurrentIns"] = value;
        }
    }

    private RecordInsViewerDto CurrentViewer
    {
        get
        {
            int minorder = CurrentIns.RecordInsViewers.Where(c => c.ViewStatus == null).Min(c => c.ViewOrder);
            return CurrentIns.RecordInsViewers.Where(c => c.ViewOrder == minorder).FirstOrDefault();
        }
    }

    const string TemplatePath = "~/UserControls/{0}.ascx";
    const string SignInUrl = "http://www.kmuh.org.tw/web/eduactivity/RecordSignIn.aspx?InstanceID={0}";

    protected override void OnInit(EventArgs e)
    {
        if (CurrentInstanceID == null || CurrentInstanceID == "")
        {
            
            return;
        }

        try
        {

            RecordInstanceDto ins = service.GetRecordInstance(CurrentInstanceID);
            CurrentIns = ins;


            Control ctr = LoadControl(string.Format(TemplatePath, CurrentIns.RecordTemplate.ClassName));
            (ctr as IRecordBase).CurrentRecordIns = ins;
            (ctr as IRecordBase).SetControlValues(ins.DetNameValueData);
            (ctr as IRecordBase).SetReadOnly(true);
            

            foreach (Control c in ctr.Controls)
            {
                if (c is RadEditor)
                {
                    Literal li = new Literal();
                    li.Text = (c as RadEditor).Content;
                    c.Parent.Controls.Add(li);
                    c.Parent.Controls.Remove(c);
                    
                }
            }

            PlaceHolder1.Controls.Add(ctr);
            base.OnInit(e);
        }
        catch (Exception ex)
        {
            
            return;
        }

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            string url = string.Format(SignInUrl, CurrentInstanceID);


            tbTitle.Text = CurrentIns.Title;
            
            if (CurrentIns.HospCode != null)
            {
                DeptSelector1.Select(CurrentIns.HospCode, CurrentIns.DeptCode);
            }
            else
            {
                DeptSelector1.Select("KMUH", "");
            }

            lbDept.Text = DeptSelector1.SelectDeptName;

            if (CurrentIns.Sdate != null)
            {
                lbSdate.Text = CurrentIns.Sdate.Value.ToString("yyyy/MM/dd HH:mm");
            }
            if (CurrentIns.Edate != null)
            {
                lbEdate.Text = CurrentIns.Edate.Value.ToString("yyyy/MM/dd HH:mm");
            }

            ReadSignIn();

            rgSign.DataSource = CurrentIns.RecordInsViewers;
            rgSign.DataBind();

        }
    }
    private void ReadSignIn()
    {
        List<RecordInsSignInDto> list = service.GetRecordSignInList(CurrentInstanceID);
        rgTarget.DataSource = list;
        rgTarget.DataBind();

    }
}