using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KMU.EduActivity.ApplicationLayer.DTO;
using Telerik.Web.UI;
using System.IO;
using System.Data.OleDb;
using System.Data;

public partial class MyListManage : AuthPage
{

    private List<MyListDto> CurrentList
    {
        get
        {
            return ViewState["CurrentList"] as List<MyListDto>;
        }
        set
        {
            ViewState["CurrentList"] = value;
        }
    }

    private List<MyListDetDto> CurrentDetList
    {
        get
        {
            return ViewState["CurrentDetList"] as List<MyListDetDto>;
        }
        set
        {
            ViewState["CurrentDetList"] = value;
        }
    }

    private MyListDto SelectedList
    {
        get
        {
            if(rgList.SelectedItems.Count == 0)
            {
                return null;
            }
            else
            {
                GridDataItem item = rgList.SelectedItems[0] as GridDataItem;
                string listid = item.GetDataKeyValue("ListID").ToString();

                MyListDto dto = CurrentList.Where(c => c.ListID == listid).FirstOrDefault();
                return dto;
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //AddPostbackControl(RadGrid1);
        if (!IsPostBack)
        {
            ReadListData();
            rgList.DataBind();
        }
        lblMsg.Text = "";
    }
    protected void CloseWindow()
    {
        if (SelectedList == null)
        {
            ShowMessage("未選擇欲帶回的清單");
            return;
        }

        string codes = "";
        string names = "";
        foreach (MyListDetDto item in CurrentDetList)
        {
            string id = item.EmpCode;
            string name = item.EmpName;

            codes += id + "#spilter#";
            names += name + "#spilter#";

        }

        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), this.ClientID + "RunOpenWin", @"
var oWindow = null;
            if (window.radWindow) oWindow = window.radWindow;
            else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow;
            var oArg = new Object();
            oArg.SelectMyListID = '" + SelectedList.ListID + @"';
            oArg.SelectMyListName = '" + SelectedList.ListName + @"';
            oArg.SelectCodes = '" +codes+@"';
            oArg.SelectNames = '"+names+@"';
            oWindow.close(oArg);", true);
    }

    private void ReadListData()
    {
        List<MyListDto> list = service.GetMyList(this.EmpCode);
        CurrentList = list;
        rgList.DataSource = CurrentList;

    }


    protected void RadGrid1_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        ReadListData();
    }


    protected void btnQuery_Click(object sender, EventArgs e)
    {
        ReadListData();
        rgEmp.DataBind();
    }

    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        CloseWindow();
    }
    protected void btnAddList_Click(object sender, EventArgs e)
    {
        if(tbListName.Text.Trim() == "")
        {
            ShowMessage("未輸入新增名單名稱");
            return;
        }

        service.CreateMyList(this.EmpCode, tbListName.Text.Trim(), false);

        ReadListData();
        
        rgList.DataBind();
        rgList.Items[rgList.Items.Count - 1].Selected = true;
        ReadListEmpData();
        rgEmp.DataBind();
    }
    protected void rgList_SelectedIndexChanged(object sender, EventArgs e)
    {
        ReadListEmpData();
        rgEmp.DataBind();
    }

    private void ReadListEmpData()
    {
        if (SelectedList == null)
        {
            rgEmp.DataSource = null;

        }
        else
        {
            CurrentDetList = service.GetMyListDet(SelectedList.ListID);
            rgEmp.DataSource = CurrentDetList;
        }
    }
    protected void btnAddEmp_Click(object sender, EventArgs e)
    {
        if(VsSelector1.SelectedValue == null || VsSelector1.SelectedValue == "")
        {
            ShowMessage("未選擇員工");
            return;
        }
        if (SelectedList == null)
        {
            ShowMessage("未選擇名單");
            return;
        }

        service.AddMyListEmp(SelectedList.ListID, VsSelector1.SelectedValue, null);
        ReadListEmpData();
        rgEmp.DataBind();
    }
    protected void rgList_DeleteCommand(object sender, GridCommandEventArgs e)
    {
        string listid = (e.Item as GridDataItem).GetDataKeyValue("ListID").ToString();
        string msg = service.DeleteMyList(listid);
        if(msg == null)
        {
            ReadListData();
            rgList.DataBind();
            ReadListEmpData();
            rgEmp.DataBind();
        }
        else
        {
            ShowMessage("刪除失敗:" + msg);
            return;
        }
    }
    protected void rgEmp_DeleteCommand(object sender, GridCommandEventArgs e)
    {
        string listid = (e.Item as GridDataItem).GetDataKeyValue("ListID").ToString();
        string empcode = (e.Item as GridDataItem).GetDataKeyValue("EmpCode").ToString();

        string msg = service.DeleteMyListEmp(listid, empcode);
        if (msg == null)
        {
            ReadListEmpData();
            rgEmp.DataBind();
        }
        else
        {
            ShowMessage("刪除失敗:" + msg);
            return;
        }
    }
}