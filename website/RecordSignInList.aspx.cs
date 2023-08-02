using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KMU.EduActivity.ApplicationLayer.DTO;
using KMU.EduActivity.ApplicationLayer.Services;

public partial class RecordSignInList : System.Web.UI.Page
{
    protected EduActivityAppService service = new EduActivityAppService();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            ReadData();
            rlvUndoItems.DataBind();
        }
    }

    private void ReadData()
    {
        RecordInstanceDto ins = service.GetRecordInstance(Request.QueryString["InstanceID"]);
        if (ins.Status != "0")
        {
            Timer1.Enabled = false;
        }
        List<RecordInsSignInDto> list = service.GetRecordSignInList(Request.QueryString["InstanceID"]);
        rlvUndoItems.DataSource = list;

    }
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        ReadData();
        rlvUndoItems.DataBind();
    }

    protected void ibtnDel_Click(object sender, ImageClickEventArgs e)
    {
        Label lbEmpCode = ((sender as ImageButton).Parent as Control).FindControl("lbCode") as Label;
        if (lbEmpCode != null)
        {
            string empcode = lbEmpCode.Text;

            service.RemoveRecordSignIn(Request.QueryString["InstanceID"], empcode);
            ReadData();
            rlvUndoItems.DataBind();
        }
    }
}