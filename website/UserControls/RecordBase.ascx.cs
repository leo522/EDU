using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.IO;

public partial class UserControls_RecordBase : System.Web.UI.UserControl
{
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        foreach (var ed in this.Controls)
        {
            if (ed is RadEditor)
            {
                (ed as RadEditor).OnClientPasteHtml = "OnClientPasteHtml";
            }
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }


}