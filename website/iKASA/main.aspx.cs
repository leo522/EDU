using KMU.EduActivity.ApplicationLayer.DTO;
using KMU.EduActivity.ApplicationLayer.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class iKASA_main : System.Web.UI.Page
{
    EduActivityAppService service = new EduActivityAppService();
    private string CurrentEmpCode
    {
        get
        {
            try
            {
                if (rcbRole.SelectedValue != "")
                {
                    return CurrentRoleList.Where(c => c.memberid == rcbRole.SelectedValue).FirstOrDefault().empcode;
                }
                else
                {
                    return "";
                }
            }
            catch
            {
                return "";
            }
        }
    }

    private iKASAPersonInfo CurrentPersonInfo
    {
        get
        {
            return Session["iKasaCurrentPersonInfo"] as iKASAPersonInfo;
        }
        set
        {
            Session["iKasaCurrentPersonInfo"] = value;
        }
    }

    private string CurrentMemberID
    {
        get
        {
            if (Session["iKasaCurrentMemberID"] == null)
            {
                return null;
            }
            else
            {
                return Session["iKasaCurrentMemberID"].ToString();
            }
        }
        set
        {
            Session["iKasaCurrentMemberID"] = value;
        }
    }

    private string CurrentIDNo
    {
        get
        {
            if (Session["iKasaIdNO"] == null)
            {
                return null;
            }
            else
            {
                return Session["iKasaIdNO"].ToString();
            }
        }
        set
        {
            Session["iKasaIdNO"] = value;
        }
    }

    private List<iKASAPersonInfo> CurrentRoleList
    {
        get
        {
            return ViewState["CurrentRoleList"] as List<iKASAPersonInfo>;
        }
        set
        {
            ViewState["CurrentRoleList"] = value;
        }

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //if (CurrentIDNo == null)
            //{
            if (Request.Form["iKasaIdNo"] != null)
            {
                CurrentIDNo = Request.Form["iKasaIdNo"].ToString();
                CurrentMemberID = null;
                CurrentPersonInfo = null;
            }
            else
            {
                if(Request.QueryString["clear"] == "1")
                {
                    CurrentIDNo = null;
                    CurrentMemberID = null;
                    CurrentPersonInfo = null;
                }
                if (CurrentIDNo == null)
                {
                    if (Session["EduAct_EmpCode"] != null)
                    {
                        var emp = service.GetVKmuEmpByEmpCode(Session["EduAct_EmpCode"].ToString());
                        if (emp != null)
                        {
                            CurrentIDNo = emp.Idno; //身分證字號
                            CurrentMemberID = null;
                            CurrentPersonInfo = null;
                        }
                    }
                }
            }
        }

        if(CurrentIDNo == null)
        {
            Response.Redirect("SessionTimeout.aspx");
            return;
        }

        if (!IsPostBack)
        {
            var userinfo = service.GetiKASALoginInfo(CurrentIDNo);
            CurrentRoleList = userinfo;
            //rcbRole.Items.Clear();

            if (CurrentMemberID == null) //下拉選單-學習階段
            {
                if (userinfo.Count > 0)
                {
                    rcbRole.SelectedValue = userinfo.FirstOrDefault().memberid;
                    rcbRole.Text = userinfo.FirstOrDefault().membertypename + " - " + userinfo.FirstOrDefault().teamname;
                }
            }
            else
            {
                rcbRole.SelectedValue = CurrentMemberID;
                rcbRole.Text = userinfo.Where(c => c.memberid == CurrentMemberID).FirstOrDefault().membertypename + " - " + userinfo.Where(c => c.memberid == CurrentMemberID).FirstOrDefault().teamname;
            }

            if (rcbRole.SelectedValue != "")
            {
                CurrentPersonInfo = CurrentRoleList.Where(c => c.memberid == rcbRole.SelectedValue).FirstOrDefault();
                LoadUserData();
                LoadMenu();
                ReloadIframe();
            }
        }
    }

    private void ReloadIframe()
    {
        if (Request.QueryString["function"] != null)
        {
            var menuitem = service.GetMenuItemByID(Request.QueryString["function"]);
            if (menuitem != null)
            {
                string frameurl = menuitem.Frameurl;
                if (frameurl.Contains("?"))
                {
                    frameurl += "&";
                }
                else
                {
                    frameurl += "?";
                }

                frameurl = frameurl.Replace("{empcode}", CurrentPersonInfo.empcode);

                frameContent.Attributes["src"] = frameurl + "funcid=" + Request.QueryString["function"];
            }
        }
        else
        {
            frameContent.Attributes["src"] = "chart.aspx?funcid=1";
        }
    }


    private void LoadUserData()
    {
        try
        {
            MemberDto dto = service.ReadMemberByEmpCode(CurrentPersonInfo.empcode);

            if (File.Exists(Server.MapPath("../Avatar/" + CurrentPersonInfo.empcode + ".jpg")))
            {
                Image1.Attributes.Remove("src");
                Image1.Attributes.Add("src", "../Avatar/" + CurrentPersonInfo.empcode + ".jpg");
                li_Image1.Attributes.Remove("href");
                li_Image1.Attributes.Add("href", "../Avatar/" + CurrentPersonInfo.empcode + ".jpg");
                //RadBinaryImage1.ImageUrl = "../Avatar/" + CurrentPersonInfo.empcode + ".jpg";
            }

            else //不存在則顯示問號頭像
            {
                Image1.Attributes.Remove("src");
                Image1.Attributes.Add("src", "../Avatar/no_avatars.jpg");
                li_Image1.Attributes.Remove("href");
                li_Image1.Attributes.Add("href", "../Avatar/no_avatars.jpg");
                
                //RadBinaryImage1.ImageUrl = "../Avatar/no_avatars.jpg";
            }

            if (dto != null)
            {

                lbName.Text = dto.Name;
                lbEmpCode.Text = dto.IsHospMember;
                lbTeam.Text = dto.EduTeamName;
                lbJobName.Text = CurrentPersonInfo.membertypename;
                lbTrainRange.Text = CurrentPersonInfo.daterange;
                lbMemberCode.Text = CurrentPersonInfo.membercode;
            }
            else
            {
                var emp = service.GetVKmuEmpByEmpCode(CurrentPersonInfo.empcode);
                if(emp!= null)
                {
                    lbName.Text = emp.Empname;
                    lbEmpCode.Text = emp.Empcode;
                    lbTeam.Text = emp.Deptname;
                    lbJobName.Text = emp.Jobcode;
                    lbTrainRange.Text = "";
                    lbMemberCode.Text = "";
                }
            }
        }
        catch (Exception ex)
        {
            Image1.Attributes.Remove("src");
            Image1.Attributes.Add("src", "../Avatar/no_avatars.jpg");
            li_Image1.Attributes.Remove("href");
            li_Image1.Attributes.Add("href", "../Avatar/no_avatars.jpg");
            //RadBinaryImage1.ImageUrl = "../Avatar/no_avatars.jpg";
            lbName.Text = "";
            lbEmpCode.Text = "";
            lbTeam.Text = "";
        }
    }

    protected void LoadMenu()
    {
        string linkhtml = "<a href=\"main.aspx?function={0}\" onclick=\"$('#loader1').show();\" title=\"{1}\" style=\"text-decoration:none;\">{2}</a>";
        string singlehtml = "<div class=\"menuitem\" style=\"background-color:{0}; color:{1};\">{2}</div>";
        string menuhtml = "";

        //var menus = service.GetiKASAMenu(CurrentEmpCode);
        var menus = service.GetiKASAMenu(CurrentPersonInfo);

        foreach (var menu in menus)
        {
            string menutextleft = "";
            if (menu.Frameurl != null && menu.Frameurl != "")
            {
                menutextleft = "　";
            }
            string str1 = string.Format(singlehtml, menu.Bgcolor, menu.Fontcolor, menutextleft + menu.Menutext);
            if (menu.Frameurl != null && menu.Frameurl != "")
            {
                string str2 = string.Format(linkhtml, menu.Menuid, menu.Hinttext, str1);
                menuhtml += str2;
            }
            else
            {
                menuhtml += str1;
            }
        }

        li_menu.Text = menuhtml;
    }
    protected void rcbRole_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
    {
        var userinfo = CurrentRoleList;
        foreach (var data in userinfo)
        {
            RadComboBoxItem item = new RadComboBoxItem();

            item.Text = data.membertypename + " - " + data.teamname;
            item.Value = data.memberid;

            item.Attributes.Add("membercode", data.membercode);
            item.Attributes.Add("membertypename", data.membertypename);
            item.Attributes.Add("teamname", data.teamname);
            item.Attributes.Add("daterange", data.daterange);

            rcbRole.Items.Add(item);

            item.DataBind();
        }
    }
    protected void rcbRole_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        CurrentMemberID = rcbRole.SelectedValue;
        CurrentPersonInfo = CurrentRoleList.Where(c => c.memberid == rcbRole.SelectedValue).FirstOrDefault();
        LoadUserData();
        LoadMenu();
        ReloadIframe();
    }
}