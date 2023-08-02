using System.Web;
using System.Web.Mvc;

namespace KMUH.EduForm.UI.MVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}