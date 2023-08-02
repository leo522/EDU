using KMU.EduActivity.ApplicationLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class iKASA_files : iKASAPageBase
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

    private string DisplayMode
    {
        get
        {
            return ViewState["DisplayMode"].ToString();
        }
        set
        {
            ViewState["DisplayMode"] = value;
        }
    }

    protected List<string> AuthRoles
    {
        get
        {
            return Session["EduAct_AuthRoles"] as List<string>;
        }
    }

    private bool IsAdmin
    {
        get
        {
            return (AuthRoles != null && AuthRoles.Contains("iKUpload"));
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CurrentCategory = this.FuncParams["category"];
            DisplayMode = this.FuncParams["displaymode"];
            if(CurrentCategory == null)
            {
                ShowMessage("資料傳遞錯誤，請重新登入");
                return;
            }

            if (IsAdmin)
            {
                panAdmin.Visible = true;
            }

            ReadFiles();
        }
        
    }

    private void ReadFiles()
    {
        List<IKASA_UploadFileDto> list = service.GetiKasaUploadFiles(CurrentCategory);

        string content = "";
        if (DisplayMode == "Y")
        {
            var file = list.OrderByDescending(c => c.CreateDate).FirstOrDefault();
            if (file != null)
            {
                if (file.FileName.ToLower().EndsWith("pdf"))
                {
                    content += "<a href=\"../UserImages/iKasa/" + file.ID + "_" + file.FileName + "\">下載</a><br> <embed src=\"../UserImages/iKasa/" + file.ID + "_" + file.FileName + "#toolbar=0&navpanes=0\" width=\"100%\" height=\"400px\" />";
                        //<iframe src=\"../UserImages/iKasa/" + file.ID + "_" + file.FileName + "\" style=\"width: 100%;height: 400px;border: none;\"></iframe>";
                }
                else
                {
                    content += "<img src=\"../UserImages/iKasa/" + file.ID + "_" + file.FileName + "\" width=\"97%\"> ";
                }
            }
        }
        else
        {
            string contenttabtemplate = @"	<input id='{0}' type='radio' name='tab' {4}/>
	<label for='{1}'>{2}</label>
	<div class='tab_content'>
{3}
	</div>";

            content = @"<div class='tab_css'>
{0}
</div>";

            string contenttab = "";
            bool first = true;

            foreach (var file in list)
            {
                string ck = "checked=\"checked\"";
                if(!first)
                {
                    ck = "";
                    
                }
                if (file.FileName.ToLower().EndsWith("pdf"))
                {
                    contenttab += string.Format(contenttabtemplate, file.DisplayTitle, file.DisplayTitle, file.DisplayTitle, "<a href=\"../UserImages/iKasa/" + file.ID + "_" + file.FileName + "\">下載</a><br> <embed src=\"../UserImages/iKasa/" + file.ID + "_" + file.FileName + "#toolbar=0&navpanes=0\" width=\"100%\" height=\"550px\" />", ck);
                    //content += "<a href=\"../UserImages/iKasa/" + file.ID + "_" + file.FileName + "\">下載</a><br> <embed src=\"../UserImages/iKasa/" + file.ID + "_" + file.FileName + "#toolbar=0&navpanes=0\" width=\"100%\" height=\"400px\" />";
                }
                else
                {
                    contenttab += string.Format(contenttabtemplate,file.DisplayTitle,file.DisplayTitle,file.DisplayTitle,"<img src=\"../UserImages/iKasa/" + file.ID + "_" + file.FileName + "\" width=\"97%\">");
                    //content += "<img src=\"../UserImages/iKasa/" + file.ID + "_" + file.FileName + "\" width=\"97%\"> ";
                }

                if(first)
                {
                    first = false;
                }

                //content += "<div  style=\"border:2px black solid;\">";
                //content += "<H2>";
                //content += "<a href=\"../UserImages/iKasa/" + file.ID + "_" + file.FileName + "\" target=\"_blank\">";
                //content += file.DisplayTitle + "</a></H2>";
                //content += "<H4>";
                //content += file.Description;
                //content += "</H4></div>";
            }

            content = string.Format(content,contenttab);
        }
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

        byte[] filedata = fu_file.FileBytes;

        bool success = service.UploadiKasaFile(CurrentPersonInfo.empcode,CurrentCategory,tbTitle.Text.Trim(),tbDescription.Text.Trim(),fu_file.FileName,filedata,Server.MapPath("~/UserImages/iKasa/"));
        if(success)
        {
            ReadFiles();
        }
        else
        {
            ShowMessage("上傳失敗，請重試");
        }
    }
}