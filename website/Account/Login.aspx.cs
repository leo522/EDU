using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using KMU.EduActivity.ApplicationLayer.Services;
using KMU.EduActivity.ApplicationLayer.DTO;
using KMU.EduActivity.DomainModel.Entities;

public partial class Account_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //RegisterHyperLink.NavigateUrl = "Register.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);

        
        /*
         * <input name="validate" type="hidden" id="validate" value="CheckAccount" />
         * <input name="sysurl" type="hidden" id="sysurl" value="http://mr.server.kmuh.org.tw/KMUGKPI_V2/Home/AutoLogin" />
         * <input name="loginID" type="hidden" id="loginID" value="980793" />
         * <input name="userid" type="hidden" id="userid" value="0980793" />
         * <input name="empcode" type="hidden" id="empcode" value="980793" />
         * <input name="txtID" type="hidden" id="txtID" value="980793" />
         * <input name="psnNo" type="hidden" id="psnNo" value="980793" />
         * <input name="psnName" type="hidden" id="psnName" value="張志銘" />
         * <input name="deptNo" type="hidden" id="deptNo" value="7000" />
         * <input name="deptName" type="hidden" id="deptName" value="資訊室" />
         * <input name="locNo" type="hidden" id="locNo" value="7080" />
         * <input name="locName" type="hidden" id="locName" value="經營及行政管理組" />
         * <input name="jobNo" type="hidden" id="jobNo" value="PROGMD" />
         * <input name="jobName" type="hidden" id="jobName" value="初級程式設計師" />
         * <input name="jobNoP" type="hidden" id="jobNoP" />
         * <input name="pwd" type="hidden" id="pwd" value="S7437" />
         * <input name="txtPasswd" type="hidden" id="txtPasswd" value="S7437" />
         * <input name="pwd6" type="hidden" id="pwd6" value="S12350" />
         * <input name="sysid" type="hidden" id="sysid" value="523" />
         * <input name="l_local" type="hidden" id="l_local" value="H" />
         * <input name="areaCode" type="hidden" id="areaCode" value="S" />
         * <input name="areaStatus" type="hidden" id="areaStatus" />
         * <input name="areaName" type="hidden" id="areaName" value="附院" />
         * <input name="psnflag" type="hidden" id="psnflag" value="PSN" />
         * <input name="txtrights" type="hidden" id="txtrights" value="3" />
         * <input name="pwr" type="hidden" id="pwr" />
         * <input name="timeStamp" type="hidden" id="timeStamp" value="333b09b85f7e341997468d7b7cab4853f0914c969e3c6d6243a8c2efc06280792763987bc0e24eec" />
         */

        try
        {
            if (Request.Form["accessToken"] != null)
            {
                //FillSession(Request.Form["loginID"],
                //    Request.Form["psnName"],
                //    Request.Form["deptNo"],
                //    Request.Form["deptName"],
                //    Request.Form["areaCode"],
                //    Request.Form["locNo"],
                //    Request.Form["jobNo"]);

                Session["accessToken"] = Request.Form["accessToken"];
                Session["OAuthToken"] = Request.Form["OAuthToken"];
                Session["OAuthServer"] = Request.Form["OAuthServer"];



                string empcode = Utility.ValidToken(Request.Form["accessToken"], Request.Form["OAuthServer"]);

                //string empcode = Request.Form["empcode"];
                if (empcode.Length == 7 && empcode.StartsWith("0"))
                {
                    empcode = empcode.Substring(1);
                }

                LoginUser.UserName = empcode;
                LoginUser.RememberMeSet = false;

                if (chklogin(LoginUser.UserName, LoginUser.Password, false))
                {
                    try
                    {
                        string clientip = GetClientIP();
                        EduActivityAppService service = new EduActivityAppService();

                        service.WriteLoginLog(LoginUser.UserName, true, clientip);
                    }
                    catch
                    {

                    }

                    FormsAuthentication.RedirectFromLoginPage(LoginUser.UserName, LoginUser.RememberMeSet);
                }
            }
        }
        catch (Exception ex)
        {
        }
    }

    protected string GetClientIP()
    {
        try
        {
            //判所client端是否有設定代理伺服器
            if (Request.ServerVariables["HTTP_VIA"] == null)
                return Request.ServerVariables["REMOTE_ADDR"].ToString();
            else
                return Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
        }
        catch
        {
            return "";
        }
    }

    protected void LoginUser_Authenticate(object sender, AuthenticateEventArgs e)
    {
        Session.RemoveAll();

        bool withcheck = false;
        if (Request.Url.Host.Contains("localhost") || LoginUser.UserName.ToLower() == "testdr")
        {
            withcheck = false;
        }
        else
        {
            withcheck = true;
        }
        EduActivityAppService service = new EduActivityAppService();

        string clientip = GetClientIP();

        if (chklogin(LoginUser.UserName, LoginUser.Password,withcheck))
        {

            //FormsAuthentication.RedirectFromLoginPage(LoginUser.UserName, LoginUser.RememberMeSet);

            FormsAuthentication.SetAuthCookie(LoginUser.UserName, LoginUser.RememberMeSet);

            service.WriteLoginLog(LoginUser.UserName, true, clientip);

            if (Request.QueryString["url"] != null)
            {
                Response.Redirect(Request.QueryString["url"]);
            }
            else
            {
                try
                {
                    Response.Redirect("~/Default.aspx");
                }
                catch(Exception ex)
                {
                
                }
            }
            
            
        }
        else
        {
            service.WriteLoginLog(LoginUser.UserName, false, clientip);
            //FormsAuthentication.RedirectToLoginPage("chkerror"); 

        }
    }

    private bool chklogin(string username, string pwd,bool withcheck)
    {
        try
        {
            
            
            EduActivityAppService service = new EduActivityAppService();

            AccountDto acc = service.ReadSystemAccount(username, pwd);
            if (acc != null)
            {
                SelectVKmuemp accempdto = service.ReadVKmuemp(username, pwd, false);
                string jobcode = "";
                if (accempdto != null)
                {
                    jobcode = accempdto.jobcode;

                }

                FillSession(acc.Empcode, acc.Empname, acc.Deptcode, "", "", acc.Deptcode, jobcode, acc.Hospcode);
                return true;
            }


            SelectVKmuemp dto = service.ReadVKmuemp(username, pwd, withcheck);


            bool success = false;

            if (dto != null)
            {
                FillSession(dto.empcode, dto.empname, dto.deptcode, "", "", dto.loccode, dto.jobcode, dto.hospcode);
                success = true;
            }

            if (success) return true;
            else
            {
                Literal lmsg = LoginUser.FindControl("FailureText") as Literal;
                lmsg.Text = "wrong id or password";
                return false;
            }
        }
        catch (Exception e)
        {
            return false;
        }
    }

    private void FillSession(string empcode, string empname, string deptcode, string deptname, string areacode, string loccode, string jobcode, string hospcode)
    {
        EduActivityAppService service = new EduActivityAppService();
        Session["EduAct_EmpCode"] = empcode.ToUpper();
        Session["EduAct_EmpName"] = empname;
        Session["EduAct_DeptCode"] = deptcode;
        Session["EduAct_DeptName"] = deptname;
        Session["EduAct_AreaCode"] = areacode;
        Session["EduAct_LocCode"] = loccode;
        Session["EduAct_JobCode"] = jobcode;
        Session["EduAct_Member"] = service.ReadMemberByLogin(empcode);
        Session["EduAct_HospCode"] = hospcode;

        Session["EduAct_AuthRoles"] = service.GetAuthRole(empcode).Select(c => c.RoleID).ToList();

        var emp = service.GetVKmuEmpByEmpCode(empcode);
        if (emp != null)
        {
            Session["EduAct_Idno"] = emp.Idno;
        }

        if ((Session["EduAct_AuthRoles"] as List<string>).Contains("DepSec"))
        {
            List<string> depsecdata = service.GetDeptSecDeps(empcode);
            if (!depsecdata.Contains(loccode))
            {
                depsecdata.Add(loccode);
            }
            Session["EduAct_DeptSecDep"] = depsecdata;
        }
    }

    private bool chklogin()
    {
        return true;
    }

    protected void LoginButton_Click(object sender, EventArgs e)
    {
        
    }
    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {
        //if (!Request.Url.Host.Contains("localhost"))
        //{
        //    args.IsValid = false;
        //}
        //else
        //{
            args.IsValid = true;
        //}
    }
}