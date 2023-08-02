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
using System.Net;
using Newtonsoft.Json;
using System.Collections.Specialized;

/// <summary>
/// Auth 的摘要描述
/// </summary>
public class AuthPage : System.Web.UI.Page
{
    protected EduActivityAppService service = new EduActivityAppService();

    protected string PostBackControlName
    {
        get
        {
            return this.Request.Params.Get("__EVENTTARGET");
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

    protected string AccessToken
    {
        get
        {
            //return "bc0f2e069d30fa8b4aa07e951310b247";
            return Convert.ToString(Session["accessToken"]);
        }
        set
        {
            Session["accessToken"] = value;
        }
    }

    protected string OAuthToken
    {
        get
        {
            //return "A0E5E3F55D9066B25F5E4F6416E8F8E2AD80D062160B170AAEE3709B629FC5CE8CB0902A1EFE3D80EB66C0721829362F996F8CA6B90FC3EB3EA30EE5DD9C6AEAC86EDB54A3095D539A7DC9404353D45D12630555E489F2770C6655BE392E128819F488A8E02193778238BB9EC1E2BB7C903E74A6D9DEAA991794A3656F0CF1418A7621CED99A7AFAA3BE53622ADC4F72A0F7319BC55CE5A3270E3491971024782622847A7905B0D76B49430A266835D349388CE5F3E83596DC1AD563DEA8B914BFE88203874EA125E0A74174C012E5D404D41985AAF1ACB6C45BF8F4137B16B226123861BD8AEB23F93CD64922F8A204933E582ADD472362584C9F11E30CC2DB71DB6238E12A87DA46D6728318610C3F1A23C8F34BB74393EDBDBC7004D3C74CC9B00C01FBC3694859C17A70540C7EF69D6086099139B130D48354E73585330AAAB250CCD927C717A579A63DC9BDA36C35C0C437A40CBFAFB55EC6F66F99DA6CBAFA83EE5972D2C1386D431AFC6939D9B3A8EF185214FBE51A2332766C07C5EE143A2702B74BC2A6C6B2106AC80CABE936EA0E93F0C20C6B8A44BD330E93B27741D0FCA08803CCEA3469D0535DF6C12B30E763AB75CDE85FDA72F57214584E06F37162091CBA9EA3CB3AED8B5F8BAC3AAF940835DDFC66B4D9B32EF4F7EEDAB4A9FAAD5B36681E0D4E223844515B6E7B862D6AD5693EB4E16AE63DB159B1BDEA72637A42E6E7314180E350A49ED75A03FB2B67CD3305DE5CD851728E4B7671E47A70B77636A91BD7A3249BE96D91D1DE2551EE5FAAFACDB04E947CCC6CDF1B111345914A8143A3F9610D6AB28A287B9B3FD952AC2B17FA2C67FB1D237F90A583DA198D783DC8A3EC1EF4C553CCE26CFD1338888D1017113AA4DC732D4DA43DBDE8990743AE8AE57EC567F6BA92A41307D376056C5105F3EA22623567FD13D981CC4C93C1C98AC60D12025C686A868A18B4A220D41AD92F8E2DB8B41912AA4C725976872F365EE739FA2B5BF87B3959BA64499A48AE022EE036CC398685B82B7875F6499FAEC615BF71C5EFE1A6C47367C305CA1E99FF2D72F96C5905094A7F6E2F7A8F062EC5254087F4298ADCA47561C1C7B652B3E5F9A4218B3AB214BBF9C9A65EA57B8E8C2FC5337DF43936BD5202112CC684451131903B69D13A09CCD6A24DEADA6B8AB40E0DC24CF36D8A1C750EF9E6EA5B7BEE22B894A023CF3096317F27F386ADCABCDDCD7C8C34221A8928FEDAFBE2E7D866CD4071EC19B14830432599101118302624E24FB40A80944D20338262EDDFFAA8185E46FC88A9FC9ECF85706DC2A9F681370CCA709C5E735661FC5E436E4CC30564EC82894B0AFC5A4E6800C54011F0C27E04B70D8DC4E3D32CB58DCF9F619549E9EC1F2D096F787134950D3C5F59205B18EBC6109E3D55C57D26894F8E66DF8E283A2260559A9438CB59989491BE272CB3371AD03B2CC9E5B09B9ECDA1AA492C612EFCBBD7386F527B79335B65B12538B7D80F6CFB37A8F3B5D66FD0CD350697EE8311DB828D17A480A7669F6ABA2A3CC854D756BE44E92A479E68C0AF7121087C1FFC83FC109CC10CDA8C63CE764B8C7E5A1B7BC8A95362E4897BFEF81D715C95043D528D158133A46BD4C3B2CD3593F14058AAD58512CBB32A4827717BD2D1E204CF47DF7DBF63252D0EE625084FB1AE7BA55B72388C30524FB77DFF4F822440F74A8D3912440C85A2957DC41C59B4069D1FF3E726CC0B897799E02F4EF357754167F423DF64383DD94A16A0D7C328E706097B0024D4933DE2C8EEA290216CACE77498BF47FDE130BE8763867EBB79EB5C5D7DB3BCDE04354AB59DA45E93DEB0D9A7EFEC194F62D630A116E90BCF647A220D6EE0C7494FDC9DA7720E1D332A7573E3E06DCBE742EE6877DC59EF55583DCCAB4897F7819F19F70B7DEE9559A3A8C492E5D6C9FFD0B173768B4F7C78067A3D973D86B1256FE7AC9D44BEB94178309F7F903D8A8ACC7186C82B51311CD1BEE1488B5EBE2B95DAC23794999091BAC16E54B7FD750F6D442C312006330245E9E0F4DD0FF65365371C17B86702E38B151E351F23194088B948972C1DD45E7CDC43E6AD6927FBFBEE18FD63F08112335BE5652A8B199127173943E3F8568F101448B853F1E248E80874CFFA4650398DBA2F3BB01AAE73844CD5A3815C5E529FE481763BBD5D8A2A7A8CD0C9ACCD590AA909499A5DE0C0F98879023DD8F068659B8E41173DCB2786F61E6553A6DD5334F9D36B6A5E73E959869096550301113DE1180B5E551A5AB7B42F6B1A80BBBF145EA755608F1D2FDC68056449B61BC06BFE24EC2BB77E3559E727267741763AE50F0452FFA3E647064BD04E7B10AC68F5F5855D1268A40842177818A52315E796CBB22558FD4B0CC15E984B251DC54AFAAE0C0FFFEEB52CA67E6F733305DB27D0F21D1A12DA02BB135EE973A40A17D8A4838E0A655B9A4C948210E361D4058B5D3B2E08D8904E99C6A11B97C857CC76F48CB0BB44BAC2E03D3C3C1B0F07CFA4C9F5E5D2CA416F130A67D4";
            return Convert.ToString(Session["OAuthToken"]);
        }
        set
        {
            Session["OAuthToken"] = value;
        }
    }

    protected string OAuthServer
    {
        get
        {
            //return "https://www.kmuh.org.tw/Web/AuthServerMVC";
            return Convert.ToString(Session["OAuthServer"]);
        }
        set
        {
            Session["OAuthServer"] = value;
        }
    }


    public string ValidToken()
    {
        return Utility.ValidToken(AccessToken, OAuthServer);
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

    protected override void OnLoad(EventArgs e)
    {
        try
        {
            if (!Page.User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Account/Login.aspx?url=" + Server.UrlEncode(Request.Url.AbsoluteUri));
                return;
            }
            else
            {
                if (EmpCode == null)
                {
                    Session.RemoveAll();
                    FormsAuthentication.SignOut();
                    Response.Redirect("~/Account/Login.aspx?url=" + Server.UrlEncode(Request.Url.AbsoluteUri));
                    return;
                }
            }
            if(!IsPostBack)
            {

                BackUrl = Request.UrlReferrer == null ? "" : Request.UrlReferrer.ToString();
                ValidToken();
            }


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

    protected string HospCode
    {
        get
        {
            if (Session["EduAct_HospCode"] != null)
            {
                return Session["EduAct_HospCode"].ToString();
            }
            else
            {
                return null;
            }
        }
    }

    protected string EmpCode
    {
        get
        {
            if (Session["EduAct_EmpCode"] != null)
            {
                return Session["EduAct_EmpCode"].ToString();
            }
            else
            {
                return null;
                //if (Page.User.Identity.IsAuthenticated)
                //{
                //    if (GetUserData())
                //    {
                //        Session["EduAct_EmpCode"] = Page.User.Identity.Name;
                //        return Session["EduAct_EmpCode"].ToString();
                //    }
                //    else
                //    {
                //        return null;
                //    }
                //}
                //else
                //{
                //    return null;
                //}
            }
        }
    }

    protected string EmpName
    {
        get
        {

            if (Session["EduAct_EmpName"] != null)
            {
                return Session["EduAct_EmpName"].ToString();
            }
            else
            {
                return null;
            }

        }
    }

    protected string DeptCode
    {
        get
        {
            if (Session["EduAct_DeptCode"] != null)
            {
                return Session["EduAct_DeptCode"].ToString();
            }
            else
            {
                return null;
            }
        }
    }

    protected string DeptName
    {
        get
        {
            if (Session["EduAct_DeptName"] != null)
            {
                return Session["EduAct_DeptName"].ToString();
            }
            else
            {
                return null;
            }
        }
    }

    protected List<string> DeptSecDep
    {
        get
        {
            return Session["EduAct_DeptSecDep"] as List<string>;
        }
    }

    protected string AreaCode
    {
        get
        {
            if (Session["EduAct_AreaCode"] != null)
            {
                return Session["EduAct_AreaCode"].ToString();
            }
            else
            {
                return null;
            }
        }
    }

    protected string LocCode
    {
        get
        {

            if (Session["EduAct_LocCode"] != null)
            {
                return Session["EduAct_LocCode"].ToString();
            }
            else
            {
                return null;
            }

        }
    }

    protected string JobCode
    {
        get
        {

            if (Session["EduAct_JobCode"] != null)
            {
                return Session["EduAct_JobCode"].ToString();
            }
            else
            {
                return null;
            }

        }
    }
    
    protected string Idno
    {
        get
        {

            if (Session["EduAct_Idno"] != null)
            {
                return Session["EduAct_Idno"].ToString();
            }
            else
            {
                return null;
            }

        }
    }

    protected MemberDto CurrentMember
    {
        get
        {
            return Session["EduAct_Member"] as MemberDto;
        }
    }

    protected List<string> AuthRoles
    {
        get
        {
            return Session["EduAct_AuthRoles"] as List<string>;
        }
    }

    public bool GetUserData()
    {
        EduActivityAppService service = new EduActivityAppService();

        AccountDto acc = service.GetSystemAccountData(Page.User.Identity.Name);
        if (acc != null)
        {
            Session["EduAct_EmpCode"] = acc.Empcode;
            Session["EduAct_EmpName"] = acc.Empname;
            Session["EduAct_DeptCode"] = acc.Deptcode;
            Session["EduAct_DeptName"] = "";
            Session["EduAct_AreaCode"] = "";
            Session["EduAct_LocCode"] = acc.Deptcode;
            Session["EduAct_JobCode"] = "";

            Session["EduAct_HospCode"] = acc.Hospcode;
            Session["EduAct_AuthRoles"] = service.GetAuthRole(acc.Empcode).Select(c => c.RoleID).ToList();

            return true;
        }

        SelectVKmuempData dto = service.ReadVKmuempData(Page.User.Identity.Name);

        if (dto != null)
        {
            Session["EduAct_EmpCode"] = dto.empcode;
            Session["EduAct_EmpName"] = dto.empname;
            Session["EduAct_DeptCode"] = dto.deptcode;
            Session["EduAct_DeptName"] = "";
            Session["EduAct_AreaCode"] = "";
            Session["EduAct_LocCode"] = dto.loccode;
            Session["EduAct_JobCode"] = dto.jobcode;
            Session["EduAct_Member"] = service.ReadMemberByLogin(dto.empcode);
            Session["EduAct_HospCode"] = dto.hospcode;
            Session["EduAct_AuthRoles"] = service.GetAuthRole(dto.empcode).Select(c => c.RoleID).ToList();
            var emp = service.GetVKmuEmpByEmpCode(Page.User.Identity.Name);
            if (emp != null)
            {
                Session["EduAct_Idno"] = emp.Idno;
            }
            if (AuthRoles.Contains("DepSec"))
            {
                Session["EduAct_DeptSecDep"] = service.GetDeptSecDeps(dto.empcode);
            }
            return true;
        }
        else
        {
            return false;
        }
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

    protected void CloseWindow(bool refresh)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), this.ClientID + "RunOpenWin", "CloseWindow(" + refresh.ToString().ToLower() + ");", true);
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