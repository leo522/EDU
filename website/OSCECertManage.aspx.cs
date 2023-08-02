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

public partial class OSCECertManage : AuthPage
{
    private List<OSCECertDto> CurrentData
    {
        get
        {
            return ViewState["CurrentData"] as List<OSCECertDto>;
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
            tbCreater.Text = this.EmpCode;
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

            List<string[]> result = service.UploadOSCECertData(dt, this.EmpCode);

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
        List<OSCECertDto> data = service.QueryOSCECertEmpItemData(tbEmpCodeName.Text.Trim(), tbCreater.Text.Trim(), rdpSdate.SelectedDate, rdpEdate.SelectedDate, rdpCreateSdate.SelectedDate, rdpCreateEdate.SelectedDate);
        CurrentData = data;
        RadGrid1.DataSource = data;
        RadGrid1.DataBind();
    }

    protected void btnQuery_Click(object sender, EventArgs e)
    {
        ReadData();
    }
    protected void RadGrid1_DeleteCommand(object sender, GridCommandEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            int id = Convert.ToInt32((e.Item as GridDataItem).GetDataKeyValue("ID"));
            List<int> ids = new List<int>();
            ids.Add(id);
            string result = service.DeleteOSCECertEmpItemData(ids);
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

    protected void btnDelSelect_Click(object sender, EventArgs e)
    {
        List<int> ids = new List<int>();
        foreach(GridDataItem i in RadGrid1.SelectedItems)
        {
            int id = Convert.ToInt32((i as GridDataItem).GetDataKeyValue("ID"));
            
            ids.Add(id);
        }

        string result = service.DeleteOSCECertEmpItemData(ids);
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