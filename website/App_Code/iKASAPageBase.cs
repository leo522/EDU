using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KMU.EduActivity.ApplicationLayer.Services;
using KMU.EduActivity.ApplicationLayer.DTO;
using KMU.EduActivity.DomainModel.Entities;
using System.Web.Security;
using Telerik.Web.UI;
using System.IO;
using System.Text;

/// <summary>
/// Auth 的摘要描述
/// </summary>
public class iKASAPageBase : AuthPage
{
    protected EduActivityAppService service = new EduActivityAppService();

    protected string PostBackControlName
    {
        get
        {
            return this.Request.Params.Get("__EVENTTARGET");
        }
    }

    protected string FunctionID
    {
        get
        {
            return this.Request.QueryString["funcid"];

        }
    }

    protected iKASAPersonInfo CurrentPersonInfo
    {
        get
        {
            if (Session["iKasaCurrentPersonInfo"] == null)
            {
                Response.Redirect("SessionTimeout.aspx");
                return null;
            }
            return Session["iKasaCurrentPersonInfo"] as iKASAPersonInfo;
        }
    }

    protected Control PostBackControl
    {
        get
        {
            if (!String.IsNullOrEmpty(PostBackControlName))
            {
                Control ctrl = this.FindControl(PostBackControlName);
                return ctrl;
            }
            else
            {
                return null;
            }
        }
    }

    protected string BackUrl
    {
        get
        {
            return ViewState["BackUrl"] == null ? "" : ViewState["BackUrl"].ToString();
        }
        set
        {
            ViewState["BackUrl"] = value;
        }
    }

    protected Dictionary<string, string> FuncParams
    {
        get
        {
            return ViewState["FuncParams"] as Dictionary<string, string>;
        }
        set
        {
            ViewState["FuncParams"] = value;
        }
    }


    protected override void OnLoad(EventArgs e)
    {
        Page.Response.Buffer = true;
        try
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            var par = service.GetMenuItemParamByID(FunctionID);
            foreach(var p in par)
            {
                param.Add(p.Paramname, p.Paramvalue);
            }
            FuncParams = param;

            base.OnLoad(e);
        }
        catch (Exception ex)
        {
            ShowMessage("頁面載入錯誤：" + ex.Message);
        }
    }

    protected void AddPostbackControl(Control ctr)
    {
        (Master.FindControl("RadScriptManager1") as RadScriptManager).RegisterPostBackControl(ctr);
    }


    protected void ShowMessage(string message)
    {
        if (Master != null)
        {
            Label lbl1 = (Label)Master.FindControl("lbErrMsg");
        }
        //lbl1.Text = message;

        System.Web.UI.Page executingPage = HttpContext.Current.Handler as System.Web.UI.Page;
        ScriptManager objScriptManager = ScriptManager.GetCurrent(executingPage);
        
        string myScript = String.Format("alert('{0}');", JSStringEscape(message, false));

        ScriptManager.RegisterStartupScript(executingPage, executingPage.GetType(), "MessageBox" + new Guid().ToString(), myScript, true);
        //myScript = "<script>" + myScript + "</script>";
        //lbl1.Text = myScript;
        
    }

    protected void ShowMessageAndDoSomething(string message, string script)
    {
        if (Master != null)
        {
            Label lbl1 = (Label)Master.FindControl("lbErrMsg");
        }
        //lbl1.Text = message;

        System.Web.UI.Page executingPage = HttpContext.Current.Handler as System.Web.UI.Page;
        ScriptManager objScriptManager = ScriptManager.GetCurrent(executingPage);

        string myScript = String.Format("alert('{0}');", JSStringEscape(message, false));
        myScript += script;

        ScriptManager.RegisterStartupScript(executingPage, executingPage.GetType(), "MessageBox" + new Guid().ToString(), myScript, true);
        //myScript = "<script>" + myScript + "</script>";
        //lbl1.Text = myScript;

    }


    protected void ShowMessageAndGo(string message, string url)
    {
        ShowMessage(message);
        System.Web.UI.Page executingPage = HttpContext.Current.Handler as System.Web.UI.Page;
        ScriptManager objScriptManager = ScriptManager.GetCurrent(executingPage);

        string myScript = String.Format("window.location ='{0}';", url);

        ScriptManager.RegisterStartupScript(executingPage, executingPage.GetType(), "Redirect" + new Guid().ToString(), myScript, true);
    }

    protected void ShowMessageAndGoBack(string message)
    {
        ShowMessage(message);
        System.Web.UI.Page executingPage = HttpContext.Current.Handler as System.Web.UI.Page;
        ScriptManager objScriptManager = ScriptManager.GetCurrent(executingPage);

        string myScript = "window.history.back();";

        ScriptManager.RegisterStartupScript(executingPage, executingPage.GetType(), "Redirect" + new Guid().ToString(), myScript, true);
    }

    protected void OpenNewWindow(string url)
    {
        System.Web.UI.Page executingPage = HttpContext.Current.Handler as System.Web.UI.Page;
        ScriptManager objScriptManager = ScriptManager.GetCurrent(executingPage);
        string myScript = "window.open('" + url + "');";
        ScriptManager.RegisterStartupScript(executingPage, executingPage.GetType(), "OpenNewWin" + new Guid().ToString(), myScript, true);
    }

    protected void JSGoBackPage()
    {

        System.Web.UI.Page executingPage = HttpContext.Current.Handler as System.Web.UI.Page;
        ScriptManager objScriptManager = ScriptManager.GetCurrent(executingPage);

        string myScript = String.Format("window.history.back();");

        ScriptManager.RegisterStartupScript(executingPage, executingPage.GetType(), "GoBack" + new Guid().ToString(), myScript, true);

    }

    /// <returns>置換特殊字元之後的字串</returns>
    /// <remarks></remarks>
    private string JSStringEscape(string raw, bool inHtmlAttribute)
    {
        raw = raw.Replace("\r\n", "\\n").Replace("\r", "").Replace("\n", "\\n");
        if (inHtmlAttribute)
            raw = raw.Replace("\"", "&quot;").Replace("'", "\\'");
        else
            raw = raw.Replace("'", "\\'").Replace("\"", "\\\"");
        return raw;
    }



    protected byte[] ConvertHTMLToPDF(string HTMLCode)
    {

        if (string.IsNullOrEmpty(HTMLCode))
        {


            return null;


        }


        //避免當HTMLCode無任何html tag標籤的純文字時，轉PDF時會掛掉，所以一律加上<p>標籤 


        HTMLCode = "<p>" + HTMLCode + "</p>";

        MemoryStream outputStream = new MemoryStream();//要把PDF寫到哪個串流 


        byte[] data = Encoding.Default.GetBytes(HTMLCode);//字串轉成byte[] 


        MemoryStream msInput = new MemoryStream(data);


        iTextSharp.text.Document doc = new iTextSharp.text.Document();//要寫PDF的文件，建構子沒填的話預設直式A4 


        iTextSharp.text.pdf.PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(doc, outputStream);


        //指定文件預設開檔時的縮放為100% 


        iTextSharp.text.pdf.PdfDestination pdfDest = new iTextSharp.text.pdf.PdfDestination(iTextSharp.text.pdf.PdfDestination.XYZ, 0, doc.PageSize.Height, 1f);


        //開啟Document文件  


        doc.Open();


        //使用XMLWorkerHelper把Html parse到PDF檔裡 


        iTextSharp.tool.xml.XMLWorkerHelper.GetInstance().ParseXHtml(writer, doc, msInput, null, Encoding.Default, new UnicodeFontFactory());


        //將pdfDest設定的資料寫到PDF檔 


        iTextSharp.text.pdf.PdfAction action = iTextSharp.text.pdf.PdfAction.GotoLocalPage(1, pdfDest, writer);


        writer.SetOpenAction(action);


        doc.Close();


        msInput.Close();


        outputStream.Close();


        //回傳PDF檔案  


        return outputStream.ToArray(); 
    }
}