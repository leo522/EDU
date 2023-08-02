using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RecordSignIn : AuthPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            lbMsg.Text = service.SignInRecordIns(Request.QueryString["InstanceID"], this.EmpCode, null, "QRPage");
        }
    }
}