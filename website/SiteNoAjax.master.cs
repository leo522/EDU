using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KMU.EduActivity.ApplicationLayer.Services;
using KMU.EduActivity.ApplicationLayer.DTO;
using System.Web.Security;
using KMU.EduActivity.DomainModel.Entities;
using System.IO;
using System.Text.RegularExpressions;
using System.Web.UI.HtmlControls;

public partial class SiteMaster : System.Web.UI.MasterPage
{
    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        //Page.Header.DataBind();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        //(UpdateProgress1.FindControl("progressBackgroundFilter") as HtmlGenericControl).Attributes.Add("class", "progressBackgroundFilter");
        //(UpdateProgress1.FindControl("processMessage") as HtmlGenericControl).Attributes.Add("class", "processMessage");

        lbErrMsg.Text = "";
        //if (!IsPostBack)
        //{
        //if (Session["EduMenu"] == null)
        //{
        EduActivityAppService service = new EduActivityAppService();
        //Session["EduMenu"] = service.GetMenu();
        //}

        NavigationMenu.Items.Clear();
        Menu1.Items.Clear();
        Menu1.Visible = false;
        //List<EduMenuDto> menus = Session["EduMenu"] as List<EduMenuDto>;
        List<EduMenuDto> menus = service.GetMenu(Session["EduAct_EmpCode"] == null ? null : Session["EduAct_EmpCode"].ToString(), Session["EduAct_AuthRoles"] == null ? null : Session["EduAct_AuthRoles"] as List<string>, Session["EduAct_JobCode"] == null ? null : Session["EduAct_JobCode"].ToString());
        foreach (EduMenuDto dto in menus.Where(c => c.ParentMenuText == "0"))
        {
            NavigationMenu.Items.Add(new MenuItem(dto.MenuText, dto.MenuText, null, dto.NavigateUrl));
        }

        foreach (EduMenuDto dto in menus.Where(c => c.ParentMenuText != "0"))
        {
            EduMenuDto parentdto = menus.Where(c => c.MenuText == dto.ParentMenuText).FirstOrDefault();
            if (parentdto != null)
            {
                MenuItem parentitem = NavigationMenu.FindItem(parentdto.MenuText);

                parentitem.ChildItems.Add(new MenuItem(dto.MenuText, dto.MenuText, null, dto.NavigateUrl));
            }
        }
        string u = Request.ServerVariables["HTTP_USER_AGENT"];
        Regex b = new Regex(@"(android|bb\d+|meego).+mobile|avantgo|bada\/|blackberry|blazer|compal|elaine|fennec|hiptop|iemobile|ip(hone|od)|iris|kindle|lge |maemo|midp|mmp|mobile.+firefox|netfront|opera m(ob|in)i|palm( os)?|phone|p(ixi|re)\/|plucker|pocket|psp|series(4|6)0|symbian|treo|up\.(browser|link)|vodafone|wap|windows (ce|phone)|xda|xiino", RegexOptions.IgnoreCase | RegexOptions.Multiline);
        Regex v = new Regex(@"1207|6310|6590|3gso|4thp|50[1-6]i|770s|802s|a wa|abac|ac(er|oo|s\-)|ai(ko|rn)|al(av|ca|co)|amoi|an(ex|ny|yw)|aptu|ar(ch|go)|as(te|us)|attw|au(di|\-m|r |s )|avan|be(ck|ll|nq)|bi(lb|rd)|bl(ac|az)|br(e|v)w|bumb|bw\-(n|u)|c55\/|capi|ccwa|cdm\-|cell|chtm|cldc|cmd\-|co(mp|nd)|craw|da(it|ll|ng)|dbte|dc\-s|devi|dica|dmob|do(c|p)o|ds(12|\-d)|el(49|ai)|em(l2|ul)|er(ic|k0)|esl8|ez([4-7]0|os|wa|ze)|fetc|fly(\-|_)|g1 u|g560|gene|gf\-5|g\-mo|go(\.w|od)|gr(ad|un)|haie|hcit|hd\-(m|p|t)|hei\-|hi(pt|ta)|hp( i|ip)|hs\-c|ht(c(\-| |_|a|g|p|s|t)|tp)|hu(aw|tc)|i\-(20|go|ma)|i230|iac( |\-|\/)|ibro|idea|ig01|ikom|im1k|inno|ipaq|iris|ja(t|v)a|jbro|jemu|jigs|kddi|keji|kgt( |\/)|klon|kpt |kwc\-|kyo(c|k)|le(no|xi)|lg( g|\/(k|l|u)|50|54|\-[a-w])|libw|lynx|m1\-w|m3ga|m50\/|ma(te|ui|xo)|mc(01|21|ca)|m\-cr|me(rc|ri)|mi(o8|oa|ts)|mmef|mo(01|02|bi|de|do|t(\-| |o|v)|zz)|mt(50|p1|v )|mwbp|mywa|n10[0-2]|n20[2-3]|n30(0|2)|n50(0|2|5)|n7(0(0|1)|10)|ne((c|m)\-|on|tf|wf|wg|wt)|nok(6|i)|nzph|o2im|op(ti|wv)|oran|owg1|p800|pan(a|d|t)|pdxg|pg(13|\-([1-8]|c))|phil|pire|pl(ay|uc)|pn\-2|po(ck|rt|se)|prox|psio|pt\-g|qa\-a|qc(07|12|21|32|60|\-[2-7]|i\-)|qtek|r380|r600|raks|rim9|ro(ve|zo)|s55\/|sa(ge|ma|mm|ms|ny|va)|sc(01|h\-|oo|p\-)|sdk\/|se(c(\-|0|1)|47|mc|nd|ri)|sgh\-|shar|sie(\-|m)|sk\-0|sl(45|id)|sm(al|ar|b3|it|t5)|so(ft|ny)|sp(01|h\-|v\-|v )|sy(01|mb)|t2(18|50)|t6(00|10|18)|ta(gt|lk)|tcl\-|tdg\-|tel(i|m)|tim\-|t\-mo|to(pl|sh)|ts(70|m\-|m3|m5)|tx\-9|up(\.b|g1|si)|utst|v400|v750|veri|vi(rg|te)|vk(40|5[0-3]|\-v)|vm40|voda|vulc|vx(52|53|60|61|70|80|81|83|85|98)|w3c(\-| )|webc|whit|wi(g |nc|nw)|wmlb|wonu|x700|yas\-|your|zeto|zte\-", RegexOptions.IgnoreCase | RegexOptions.Multiline);
        if ((b.IsMatch(u) || v.IsMatch(u.Substring(0, 4))))
        {
            string currentpage = System.IO.Path.GetFileName(Request.PhysicalPath);

            EduMenuDto currentp = menus.Where(c => c.NavigateUrl != null && c.NavigateUrl.Contains(currentpage)).FirstOrDefault();

            if (currentp != null)
            {
                if (currentp.ParentMenuText != "0")
                { 
                    foreach (EduMenuDto dto in menus.Where(c => c.ParentMenuText == currentp.ParentMenuText))
                    {
                        Menu1.Items.Add(new MenuItem(dto.MenuText, dto.MenuText, null, dto.NavigateUrl));
                        Menu1.Visible = true;
                    }
                }
                else
                {
                    Menu1.Visible = false;
                }
            }            
        }

        //}

        Label loginName = HeadLoginView.FindControl("HeadLoginName") as Label;
        Image AvatarSmall = HeadLoginView.FindControl("AvatarSmall") as Image;
        if (loginName != null && Page.User.Identity.IsAuthenticated)
        {
            if (Session["EduAct_EmpCode"] == null)
            {
                AuthPage p = new AuthPage();
                if (p.GetUserData())
                {
                    loginName.Text = Session["EduAct_EmpCode"].ToString() + "-" + Session["EduAct_EmpName"].ToString();
                    //if (Session["EduAct_Member"] != null)
                    //{


                    //    NavigationMenu.Items.Remove(NavigationMenu.FindItem("學員管理"));
                    //    NavigationMenu.Items.Remove(NavigationMenu.FindItem("課程管理"));
                    //    NavigationMenu.Items.Remove(NavigationMenu.FindItem("教師設定"));
                    //}
                    if (File.Exists(Server.MapPath("Avatar/" + Session["EduAct_EmpCode"].ToString() + "s.jpg")))
                    {
                        AvatarSmall.ImageUrl = "Avatar/" + Session["EduAct_EmpCode"].ToString() + "s.jpg";
                    }
                    else
                    {
                        AvatarSmall.ImageUrl = "Avatar/no_avatars.jpg";
                    }


                }
                else
                {
                    FormsAuthentication.SignOut();
                    Response.Redirect("/");
                }
                
            }
            else
            {
                loginName.Text = Session["EduAct_EmpCode"] + "-" + Session["EduAct_EmpName"];
                //if (Session["EduAct_Member"] != null)
                //{
                //    NavigationMenu.Items.Remove(NavigationMenu.FindItem("學員管理"));
                //    NavigationMenu.Items.Remove(NavigationMenu.FindItem("課程管理"));
                //    NavigationMenu.Items.Remove(NavigationMenu.FindItem("教師設定"));
                //    NavigationMenu.Items.Remove(NavigationMenu.FindItem("報表列印"));
                //}
                if (!File.Exists(Server.MapPath("Avatar/" + Session["EduAct_EmpCode"].ToString() + "s.jpg")))
                {
                    AvatarSmall.ImageUrl = "Avatar/no_avatars.jpg";
                }
                else
                {
                    AvatarSmall.ImageUrl = "Avatar/" + Session["EduAct_EmpCode"].ToString() + "s.jpg";
                }
            }

            //if ((!Request.Url.Host.Contains("localhost")) && (Session["EduAct_DeptCode"] != null && Session["EduAct_DeptCode"].ToString() != "7100") && (Session["EduAct_DeptCode"] != null && Session["EduAct_DeptCode"].ToString() != "7000"))
            //{
            //    NavigationMenu.Items.Remove(NavigationMenu.FindItem("表單管理"));
            //}
        }
        else
        {
            NavigationMenu.Items.Clear();
            Menu1.Visible = false;
        }

        LoginStatus st = HeadLoginView.FindControl("HeadLoginStatus") as LoginStatus;

    }



    protected void HeadLoginStatus_LoggedOut(object sender, EventArgs e)
    {
        Session.Clear();
    }

}
