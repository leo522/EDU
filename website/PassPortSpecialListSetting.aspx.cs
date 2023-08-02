using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KMU.EduActivity.ApplicationLayer.DTO;
using Telerik.Web.UI;

public partial class PassPortSpecialListSetting : AuthPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            BindItems();
            ReadData();
        }
    }

    private void BindItems()
    {
        List<PassPortCheckItemDto> list = service.GetPassPortCheckItems();
        rcbItem.DataValueField = "itemcode";
        rcbItem.DataTextField = "itemname";
        rcbItem.DataSource = list;
        rcbItem.DataBind();
    }

    private void ReadData()
    {
        List<PassPortSpecialListDto> list = service.GetPassPortSpecialList(null, null);
        RadGrid1.DataSource = list;
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (tbEmpCode.Text.Trim() == "")
        {
            ShowMessage("未輸入職編");
            return;
        }
        if (rcbItem.SelectedValue == null || rcbItem.SelectedValue == "")
        {
            ShowMessage("未選擇授權項目");
            return;
        }
        if (rcbLevel.SelectedValue == null || rcbLevel.SelectedValue == "")
        {
            ShowMessage("未選擇指定開始等級");
            return;
        }

        string result = service.AddPassPortSpecialList(tbEmpCode.Text, Convert.ToInt32(rcbItem.SelectedValue), rcbLevel.SelectedValue);
        if (result != null)
        {
            ShowMessage("資料寫入失敗：" + result);
        }
        else
        {
            ReadData();
            RadGrid1.DataBind();
        }
    }
    protected void RadGrid1_DeleteCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
    {
        string empcode = (e.Item as GridDataItem).GetDataKeyValue("empcode").ToString();
        int itemcode = Convert.ToInt32((e.Item as GridDataItem).GetDataKeyValue("itemcode"));

        string result = service.DeletePassPortSpecialList(empcode, itemcode);
        if(result!=null)
        {
            ShowMessage("資料刪除失敗：" + result);
        }
        else
        {
            ReadData();
            RadGrid1.DataBind();
        }

    }
}