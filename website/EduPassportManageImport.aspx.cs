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

public partial class EduPassportManageImport : AuthPage
{
   

    protected void Page_Load(object sender, EventArgs e)
    {
        AddPostbackControl(btnDownload);
        AddPostbackControl(btnImport);
        //AddPostbackControl(FileUpload1);
        if(!IsPostBack)
        {
            BindPassport();
        }
    }


    private void BindPassport()
    {
        List<EduPassportTemplateDto> list = service.GetEduPassportTemplates(null, null, null);

        EduPassportTemplateDto empty = new EduPassportTemplateDto();
        empty.TemplateName = "";
        empty.TemplateID = "";
        list.Insert(0, empty);

        rcbTemplateID.DataValueField = "TemplateID";
        rcbTemplateID.DataTextField = "TemplateName";
        rcbTemplateID.DataSource = list;
        rcbTemplateID.DataBind();

    }


    private void BindTemplateItems()
    {
        rcbTemplateItem.ClearSelection();
        List<EduPassportTemplateItemDto> list = service.GetEduPassportTemplateWithItem(rcbTemplateID.SelectedValue).EduPassportTemplateItems.ToList();

        rcbTemplateItem.DataValueField = "ItemID";
        rcbTemplateItem.DataTextField = "ItemName";
        rcbTemplateItem.DataSource = list;
        rcbTemplateItem.DataBind();
    }


    protected void rcbTemplateID_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        if(rcbTemplateID.SelectedValue!="")
        {
            panItemFilter.Visible = true;
            BindTemplateItems();
        }
        else
        {
            panItemFilter.Visible = false;
        }
    }

    protected void btnDownload_Click(object sender, EventArgs e)
    {
        if(rcbTemplateItem.SelectedValue == "" || rcbTemplateItem.SelectedValue == null)
        {
            ShowMessage("未選擇項目");
            return;
        }
        EduPassportItemDto item = service.GetEduPassportItemWithDet(rcbTemplateItem.SelectedValue);
        
        DataTable dt = new DataTable();
        dt.Columns.Add("樣本代號(請複製下面值填入每行)");
        dt.Columns.Add("項目代號(請複製下面值填入每行)");
        dt.Columns.Add("學生職編");
        dt.Columns.Add("審核老師職編(管理者直接審核免填)");
        dt.Columns.Add("審核狀態(0:未送出,1:待審核,V:已完成)");
        foreach(EduPassportItemDetDto det in item.EduPassportItemDets)
        {
            dt.Columns.Add(det.FieldDesc + "{{" + det.ID.ToString() + "}}");
        }

        DataRow dr = dt.NewRow();
        dr["樣本代號(請複製下面值填入每行)"] = rcbTemplateID.SelectedValue;
        dr["項目代號(請複製下面值填入每行)"] = rcbTemplateItem.SelectedValue;
        dt.Rows.Add(dr);


        Utility uti = new Utility();

        byte[] bytes = uti.ExportDataTableToExcel(dt);


        HttpResponse response = Response;

        response.Clear();

        response.AddHeader("Content-Type", "binary/octet-stream");

        response.AddHeader("Content-Disposition", "attachment; filename=sample.xls" + "; size=" + bytes.Length.ToString());

        response.BinaryWrite(bytes);

        response.Flush();
        response.End();

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

            List<string[]> result = service.UploadEduPassportData(dt, this.EmpCode);

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

    protected void btnToSendPassport_Click(object sender, EventArgs e)
    {
        Response.Redirect("EduPassportManageSend.aspx");
    }
    protected void btnToManage_Click(object sender, EventArgs e)
    {
        Response.Redirect("EduPassportManage.aspx");
    }
}