using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KMU.EduActivity.ApplicationLayer.DTO;
using KMU.EduActivity.ApplicationLayer.Services;

public partial class DownloadActAttachment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["ID"] != null)
            {
                string id = Request.QueryString["ID"];


                EduActivityAppService service = new EduActivityAppService();




                EduStopActAttachmentDto att = service.GetEduActAttachment(id);

                if (att != null)
                {

                    byte[] bytes = att.Attachment;


                    HttpResponse response = Response;

                    response.Clear();

                    //response.AppendCookie(new HttpCookie("fileDownloadToken", download_token_value_id.Value));

                    response.AddHeader("Content-Type", "binary/octet-stream");

                    response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode(att.Name) + "; size=" + bytes.Length.ToString());

                    response.BinaryWrite(bytes);

                    response.Flush();
                    response.End();
                }
                else
                {
                    Response.Write("參數錯誤，無法下載附件");
                }
            }
        }
    }
}