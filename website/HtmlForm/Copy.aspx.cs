using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using HtmlAgilityPack;

public partial class Copy : System.Web.UI.Page
{
    private HtmlFormUtility.Components.ProcessComponent pc = new HtmlFormUtility.Components.ProcessComponent();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        HtmlFormUtility.FORM_TEMPLATES temp = pc.CopyTemplate(Convert.ToInt32(Request.QueryString["templateid"]), null, TextBox1.Text, null);
        if (temp == null)
        {
            lbMsg.Text = "複製失敗!!";
        }
        else
        {
            Response.Redirect("HtmlAgilityAdmin.aspx");
        }


    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("HtmlAgilityAdmin.aspx");
    }
}

