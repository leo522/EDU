using KMU.EduActivity.ApplicationLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class AccountRole : AuthPage
{
    private List<AccountRoleDto> CurrentList
    {
        get
        {
            return ViewState["CurrentList"] as List<AccountRoleDto>;
        }
        set
        {
            ViewState["CurrentList"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        AddPostbackControl(RadGrid1);
        if(!IsPostBack)
        {
            BindRoles();
            ReadData();
            RadGrid1.DataSource = CurrentList;
            RadGrid1.DataBind();

        }
    }

    private void BindRoles()
    {
        List<AuthRoleDto> roles = service.GetAuthRoles();
        ddlRoles.DataValueField = "RoleID";
        ddlRoles.DataTextField = "RoleName";
        ddlRoles.DataSource = roles;
        
        ddlRoles.DataBind();
    }


    private void ReadData()
    {
        List<AccountRoleDto> list = service.GetAccountRoles(null, null);
        CurrentList = list;
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if(VsSelector1.SelectedValue == null || VsSelector1.SelectedValue == "")
        {
            ShowMessage("未選擇員工");
            return;
        }

        if(ddlRoles.SelectedValue == "" || ddlRoles.SelectedValue == null)
        {
            ShowMessage("未選擇角色");
            return;
        }

        string msg = service.AddAccountRole(VsSelector1.SelectedValue, ddlRoles.SelectedValue);
        if(msg !=null)
        {
            ShowMessage("新增失敗:" + msg);
        }
        else
        {
            ReadData();
            RadGrid1.DataSource = CurrentList;
            RadGrid1.DataBind();
        }
    }
    protected void RadGrid1_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        RadGrid1.DataSource = CurrentList;
    }
    protected void RadGrid1_DeleteCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
    {
        GridDataItem item = e.Item as GridDataItem;
        string empcode = item.GetDataKeyValue("EmpCode").ToString();
        string roleid = item.GetDataKeyValue("RoleID").ToString();

        string msg = service.RemoveAccountRole(empcode, roleid);
        if (msg != null)
        {
            ShowMessage("刪除失敗:" + msg);
        }
        else
        {
            ReadData();
            RadGrid1.DataSource = CurrentList;
            RadGrid1.DataBind();
        }

    }
}