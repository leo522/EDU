using KMU.EduActivity.ApplicationLayer.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class TeachPointManage : AuthPage
{
    private List<TeachPointEmpItemDatumDto> CurrentData
    {
        get
        {
            return ViewState["CurrentData"] as List<TeachPointEmpItemDatumDto>;
        }
        set
        {
            ViewState["CurrentData"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        AddPostbackControl(btnImport);
        if(!IsPostBack)
        {
            BindTeachPointCalcType();
            tbCreater.Text = this.EmpCode;
        }
    }

    private void BindTeachPointCalcType()
    {
        List<TeachPointCalcTypeDto> list = service.GetTeachPointCalcTypes();
        rcbCalcType.DataValueField = "TypeID";
        rcbCalcType.DataTextField = "TypeName";
        rcbCalcType.DataSource = list;
        rcbCalcType.DataBind();
        

        rcbCalcTypeQuery.DataValueField = "TypeID";
        rcbCalcTypeQuery.DataTextField = "TypeName";
        rcbCalcTypeQuery.DataSource = list;
        rcbCalcTypeQuery.DataBind();
        BindTeachPointItem();
        BindTeachPointItemQuery();
    }

    private void BindTeachPointItem()
    {
        if (rcbCalcType.SelectedValue != "" && rcbCalcType.SelectedValue != null)
        {
            List<TeachPointItemDto> list = service.GetTeachPointItemToUpload(Convert.ToInt32(rcbCalcType.SelectedValue));
            rcbItem.DataValueField = "ItemID";
            rcbItem.DataTextField = "FullItemName";
            rcbItem.DataSource = list;
            rcbItem.DataBind();
        }
        else
        {
            rcbItem.DataSource = null;
            rcbItem.DataBind();
        }

    }

    private void BindTeachPointItemQuery()
    {
        if (rcbCalcTypeQuery.SelectedValue != "" && rcbCalcTypeQuery.SelectedValue != null)
        {
            List<TeachPointItemDto> list = service.GetTeachPointItemToUpload(Convert.ToInt32(rcbCalcTypeQuery.SelectedValue));

            rcbItemQuery.DataValueField = "ItemID";
            rcbItemQuery.DataTextField = "FullItemName";
            rcbItemQuery.DataSource = list;
            rcbItemQuery.DataBind();
        }
        else
        {
            rcbItemQuery.DataSource = null;
            rcbItemQuery.DataBind();
        }

    }



    protected void btnImport_Click(object sender, EventArgs e)
    {
        lbMsg.Text = "";
        try
        {
            if (!FileUpload1.HasFile)
            {
                ShowMessage("未選擇檔案");
                return;
            }

            if(rcbItem.SelectedValue == null || rcbItem.SelectedValue == "")
            {
                ShowMessage("未選擇項目");
                return;
            }

            string filename = Server.MapPath(".") + "\\temp\\" + Guid.NewGuid() + FileUpload1.FileName;
            FileUpload1.SaveAs(filename);

            DataTable dt = Utility.ReadExcelAsTableNPOI(filename);

            try
            {
                File.Delete(filename);
            }
            catch (Exception ex)
            {
            }

            List<string[]> result = service.UploadTeachPointData(dt, this.EmpCode, Convert.ToInt32(rcbItem.SelectedValue));

            foreach (string[] r in result)
            {
                lbMsg.Text += "<font color='" + r[1] + "'>" + r[0] + "</font><br/>";
            }
        }
        catch(Exception ex)
        {
            lbMsg.Text = "<font color='red'>匯入資料失敗:" + ex.Message + "</font><br/>";
        }
    }

    private void ReadData()
    {
        List<TeachPointEmpItemDatumDto> data = service.QueryTeachPointEmpItemData(Convert.ToInt32(rcbItemQuery.SelectedValue), tbEmpCodeName.Text.Trim(), tbCreater.Text.Trim(), rdpSdate.SelectedDate, rdpEdate.SelectedDate);
        CurrentData = data;
        RadGrid1.DataSource = data;
        RadGrid1.DataBind();
    }

    protected void btnQuery_Click(object sender, EventArgs e)
    {
        if (rcbItemQuery.SelectedValue == "" || rcbItemQuery.SelectedValue == null)
        {
            ShowMessage("請選擇項目");
            return;
        }

        ReadData();
    }
    protected void RadGrid1_DeleteCommand(object sender, GridCommandEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            int id = Convert.ToInt32((e.Item as GridDataItem).GetDataKeyValue("ID"));

            string result = service.DeleteTeachPointEmpItemData(id);
            if (result != null)
            {
                ShowMessage("刪除失敗:" + result);
                return;
            }
            else
            {
                ReadData();
            }
        }
    }
    protected void RadGrid1_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        RadGrid1.DataSource = CurrentData;
    }
    protected void rcbCalcTypeQuery_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        BindTeachPointItemQuery();
    }
    protected void rcbCalcType_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        BindTeachPointItem();
    }
}