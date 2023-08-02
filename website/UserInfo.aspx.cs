using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KMU.EduActivity.ApplicationLayer.DTO;
using System.IO;

public partial class UserInfo : AuthPage
{
    private string InEmpCode
    {
        get
        {
            return Request.QueryString["empcode"];
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (InEmpCode == null)
        {
            panInfo.Visible = false;
        }
        else
        {
            ReadData();
        }
    }

    private void ReadData()
    {
        try
        {
            MemberDto dto = service.ReadMemberByEmpCode(InEmpCode);

            if (File.Exists(Server.MapPath("Avatar/" + InEmpCode + ".jpg")))
            {
                //imgCurrent.ImageUrl = "Avatar/" + InEmpCode + ".jpg";
                RadBinaryImage1.ImageUrl = "Avatar/" + InEmpCode + ".jpg";
            }

            else
            {
                //imgCurrent.ImageUrl = "Avatar/no_avatars.jpg";
                RadBinaryImage1.ImageUrl = "Avatar/no_avatars.jpg";
            }


            lbName.Text = dto.Name;
            lbEmpCode.Text = dto.IsHospMember;
            lbTeam.Text = dto.EduTeamName;
        }
        catch(Exception ex)
        {
            RadBinaryImage1.ImageUrl = "Avatar/no_avatars.jpg";
            lbName.Text = "";
            lbEmpCode.Text = "";
            lbTeam.Text = "";
        }
    }
}