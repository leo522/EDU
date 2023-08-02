using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KMU.EduActivity.ApplicationLayer.DTO;

public partial class FuncQuery : AuthPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ReadData();
        }
    }

    private void ReadData()
    {
        //List<EduMenuDto> menus = Session["EduMenu"] as List<EduMenuDto>;
        List<EduMenuDto> menus = service.GetMenu(this.EmpCode, this.AuthRoles, this.JobCode);
        foreach (EduMenuDto dto in menus)
        {
            if (dto.MenuText.Contains(Request.QueryString["keyword"]))
            {
                menuSearch.Items.Add(new MenuItem(dto.MenuText, dto.MenuText, null, dto.NavigateUrl));
            }
        }

    }
}