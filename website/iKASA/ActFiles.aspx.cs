using KMU.EduActivity.ApplicationLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class iKASA_ActFiles : iKASAPageBase
{
    private string CurrentCategory
    {
        get
        {
            return ViewState["CurrentCategory"].ToString();
        }
        set
        {
            ViewState["CurrentCategory"] = value;
        }
    }

    protected List<string> AuthRoles
    {
        get
        {
            return Session["EduAct_AuthRoles"] as List<string>;
        }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CurrentCategory = this.FuncParams["category"];
            if(CurrentCategory == null)
            {
                ShowMessage("資料傳遞錯誤，請重新登入");
                return;
            }

            ReadFiles();
        }
        
    }

    private void ReadFiles()
    {
        List<IKASA_ActUploadFileDto> list = service.GetiKasaActUploadFiles(CurrentCategory,this.CurrentPersonInfo.empcode);

        string content = "";
        content+= @"
<table border='1' width='95%'>
<tr>
<th width='15%'>日期</th>
<th width='30%'>標題</th>
<th width='50%'>說明</th>
<th width='5%'>附件</th>
<th width='5%'></th>
</tr>
";



        foreach(var file in list)
        {
            content += "<tr>";
            content += "<td>" + file.ActDate.Value.ToString("yyyy/MM/dd") + "</td>";
            content += "<td>" + file.DisplayTitle + "</td>";
            content += "<td>" + file.Description + "</td>";
            content += "<td><a href=\"../UserImages/iKasa/" + file.ID + "_" + file.FileName + "\" target=\"_blank\">附件</a> </td>";
            content += "<td><input type=\"button\" value=\"刪除\" onclick=\"if(confirm('是否確定刪除?')){deletefile('" + file.ID + "');}\"> </td>";
            content += "</tr>";
        }
        content += "</table>";

        liContent.Text = content;
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if(tbTitle.Text.Trim() == "")
        {
            ShowMessage("請輸入標題");
            return;
        }

        if (!fu_file.HasFile)
        {
            ShowMessage("請選擇檔案");
            return;
        }

        if(rdpActDate.SelectedDate == null)
        {
            ShowMessage("請選擇日期");
            return;
        }

        byte[] filedata = fu_file.FileBytes;

        bool success = service.UploadiKasaActFile(CurrentPersonInfo.empcode, CurrentCategory, tbTitle.Text.Trim(), tbDescription.Text.Trim(), fu_file.FileName, filedata, Server.MapPath("~/UserImages/iKasa/"), rdpActDate.SelectedDate.Value);
        if(success)
        {
            ReadFiles();
        }
        else
        {
            ShowMessage("上傳失敗，請重試");
        }
    }

    protected void lbPostBack_Click(object sender, EventArgs e)
    {
        string fileid = hdFileID.Value;

        bool success = service.DeleteiKasaActFile(fileid);
        if(success)
        {
            ReadFiles();
        }
        else
        {
            ShowMessage("刪除失敗，請重試");
        }

    }

}