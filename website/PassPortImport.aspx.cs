using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KMU.EduActivity.ApplicationLayer.DTO;
using Telerik.Web.UI;

public partial class PassPortImport : AuthPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AddPostbackControl(rauUpload);
        AddPostbackControl(btnSubmit);

        if (!IsPostBack)
        {


        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        liResult.Text = "";


        if (rauUpload.UploadedFiles.Count == 0)
        {
            ShowMessage("未選擇檔案");
            return;
        }
        string filename = Server.MapPath(".") + "\\temp\\" + Guid.NewGuid() + rauUpload.UploadedFiles[0].FileName;
        rauUpload.UploadedFiles[0].SaveAs(filename);

        DataTable dt = Utility.ReadExcelAsTableNPOI(filename);

        try
        {
            File.Delete(filename);
        }
        catch (Exception ex)
        {
        }

        List<string[]> result = service.UploadPassPortData(dt, cbReplace.Checked);

        foreach (string[] r in result)
        {
            liResult.Text += "<font color='" + r[1] + "'>" + r[0] + "</font><br/>";
        }

    }

}