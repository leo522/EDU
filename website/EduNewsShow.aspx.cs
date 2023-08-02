using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KMU.EduActivity.ApplicationLayer.DTO;
using System.Globalization;
using KMU.EduActivity.ApplicationLayer.Services;
using Telerik.Web.UI;

public partial class EduNewsShow : AuthPage
{
    private string CurrentID
    {
        get
        {
            return Request.QueryString["newid"];
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            if (Request.QueryString["newid"] != null)
            {
                ReadData();
            }
        }
    }
    
    private void ReadData()
    {
        NewsDto data = service.GetNewsData(CurrentID);
        if (data != null)
        {
            lbTitle.Text = data.TITLE;
            liContent.Text = data.CONTENT;
            lbDate.Text = data.SDATE.ToString("yyyy/MM/dd");
        }
    }


    protected void rgAttachment_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            if (ViewState["CurrentAtt"] != null)
            {
                GridDataItem item = (GridDataItem)e.Item;

                string id = item.GetDataKeyValue("AttachmentID").ToString();

                List<News_AttachmentDto> list = ViewState["CurrentAtt"] as List<News_AttachmentDto>;

                News_AttachmentDto att = list.Where(c => c.AttachmentID == Convert.ToInt32(id)).FirstOrDefault();

                LinkButton lbtn = item.FindControl("lbtnAtt") as LinkButton;

                lbtn.Text = att.AttachmentName;
            }
        }
    }

    private void ReadAttachment()
    {
        List<News_AttachmentDto> list = service.GetNewsAttachment(CurrentID);
        ViewState["CurrentAtt"] = list;
        rgAttachment.DataSource = list;
    }

    protected void rgAttachment_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        ReadAttachment();
    }

    protected void lbtnAtt_Click(object sender, EventArgs e)
    {
        GridDataItem item = (sender as LinkButton).Parent.Parent as GridDataItem;
        string id = item.GetDataKeyValue("AttachmentID").ToString();

        List<News_AttachmentDto> list = ViewState["CurrentAtt"] as List<News_AttachmentDto>;

        News_AttachmentDto att = list.Where(c => c.AttachmentID == Convert.ToInt32(id)).FirstOrDefault();

        byte[] bytes = att.Attachment;


        HttpResponse response = Response;

        response.Clear();

        //response.AppendCookie(new HttpCookie("fileDownloadToken", download_token_value_id.Value));

        response.AddHeader("Content-Type", "binary/octet-stream");

        response.AddHeader("Content-Disposition", "attachment; filename=" + Server.UrlPathEncode(att.AttachmentName) + "; size=" + bytes.Length.ToString());

        response.BinaryWrite(bytes);

        response.Flush();
        response.End();
    }
}