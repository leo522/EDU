using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OAuthLibrary;
using OAuthLibrary.Extensions;
using OAuthLibrary.Extensions.Profiles;
using KMUH.EduForm.UI.MVC.SecurityReadWcf ;
using KMU.EduActivity.ApplicationLayer.DTO;
using KMU.EduActivity.ApplicationLayer.Services;



namespace KMUH.EduForm.UI.MVC.Controllers
{
    //protected EduActivityAppService service = new EduActivityAppService();
    public class HomeController : Controller
    {
        string SystemID = "EduForm"; 
        [KMUHAuthentication]
        public ActionResult Index()
        {
            return View();
        }

        [KMUHAuthentication]
        public ActionResult List()
        {
            return View();
        }

        [KMUHAuthentication]
        public ActionResult EditDataPartial()
        {
            return PartialView();
        }

        [KMUHAuthentication]
        public ActionResult EditMulti_Table()
        {
            return View();
        }


        public PartialViewResult PageHeader()
        {
            var userProfile = Request.GetUserProfile();

            ViewBag.SystemName = "高醫資訊系統公版";
            ViewBag.UserInfo = string.Format("{0}({1}) <br />{2}-{3} {4}({5})", userProfile.SourceIPAddress, userProfile.IsIntranetIP ? "院內" : "院外", userProfile.Hospital, userProfile.DepartmentName, userProfile.UserName, userProfile.UserId);

            //ViewBag.UserInfo = "";
            return PartialView("PageHeaderPartial");
        }

        public PartialViewResult FunctionMenu()
        {

            if (Session["FunctionList"] == null)
            {
                using (SecurityReadWCFServiceClient service = new SecurityReadWCFServiceClient())
                {
                    var userProfile = Request.GetUserProfile();
                    var FunctionList = service.QueryUserAppWins(userProfile.UserId, SystemID).Select(c => c.WINDOW).ToList();
                    FunctionList.Add("FunctionListTMP");
                    Session["FunctionList"] = FunctionList;
                }
            }

            ViewBag.FunctionList = (Session["FunctionList"] as List<string>);

           return PartialView("FunctionMenuPartial");            

        }

        //private void ReadToDoDate()
        //{
        //    List<ToDoListDto> list = service.GetToDoList(this.EmpCode, !lbtnDisplayAll.Visible).ToList();
        //    CurrentToDoList = list;

        //    RadGrid1.DataSource = CurrentToDoList;
        //}

    }
}