using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KMU.EduActivity.ApplicationLayer.DTO;

public partial class ElearningVideo : AuthPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["ItemID"] == null)
        {
            ShowMessageAndGoBack("參數傳遞錯誤");
            return;
        }
        if (!IsPostBack)
        {
            ElearningItemDto dto = service.GetClassItemByID(Request.QueryString["ItemID"]);

            if (dto != null)
            {
                


                string html5 = "<video  src = \"" + dto.RefUrl + "\" width = \"100%\" height = \"600px\" autoplay = \"autoplay\" controls = \"controls\"   />";

                string content_att = string.Empty;

                content_att += "<div align='center'>";
                content_att += "<OBJECT ID='ActiveMovie1' WIDTH='100%' HEIGHT='600px' CLASSID='CLSID:05589FA1-C356-11CE-BF01-00AA0055595A'>";
                content_att += "<PARAM NAME='Version' VALUE='1'>";
                content_att += "<PARAM NAME='EnableContextMenu' VALUE='-1'>";
                content_att += "<PARAM NAME='ShowDisplay' VALUE='0'>";
                content_att += "<PARAM NAME='ShowControls' VALUE='-1'>";
                content_att += "<PARAM NAME='ShowPositionControls' VALUE='0'>";
                content_att += "<PARAM NAME='ShowSelectionControls' VALUE='0'>";
                content_att += "<PARAM NAME='EnablePositionControls' VALUE='-1'>";
                content_att += "<PARAM NAME='EnableSelectionControls' VALUE='-1'>";
                content_att += "<PARAM NAME='ShowTracker' VALUE='-1'>";
                content_att += "<PARAM NAME='EnableTracker' VALUE='-1'>";
                content_att += "<PARAM NAME='AllowHideDisplay' VALUE='-1'>";
                content_att += "<PARAM NAME='AllowHideControls' VALUE='-1'>";
                content_att += "<PARAM NAME='MovieWindowSize' VALUE='0'>";
                content_att += "<PARAM NAME='FullScreenMode' VALUE='0'>";
                content_att += "<PARAM NAME='AutoStart' VALUE='1'>";
                content_att += "<PARAM NAME='AutoRewind' VALUE='1'>";
                content_att += "<PARAM NAME='PlayCount' VALUE='99'>";
                content_att += "<PARAM NAME='SelectionStart' VALUE='0'>";
                content_att += "<PARAM NAME='SelectionEnd' VALUE='200.5151388'>";
                content_att += "<PARAM NAME='Appearance' VALUE='1'>";
                content_att += "<PARAM NAME='BorderStyle' VALUE='1'>";
                content_att += "<PARAM NAME='FileName' VALUE='" + dto.RefUrl + "'>";
                content_att += "<PARAM NAME='DisplayMode' VALUE='0'>";
                content_att += "<PARAM NAME='AllowChangeDisplayMode' VALUE='-1'>";
                content_att += "<PARAM NAME='DisplayForeColor' VALUE='16777215'>";
                content_att += "<PARAM NAME='DisplayBackColor' VALUE='0'>";
                content_att += "影音內容";
                content_att += "</OBJECT>";
                content_att += "</div>";

                System.Web.HttpBrowserCapabilities browser = Request.Browser;

                if (browser.Type.StartsWith("IE"))
                {
                    liContent.Text = content_att;
                }
                else
                {
                    liContent.Text = html5;
                }

                string err = service.SetClassItemFinish(Request.QueryString["ItemID"], this.EmpCode);
                if (err != null)
                {
                    ShowMessage("紀錄讀取狀態失敗，請重試：" + err);
                }
            }
        }
    }
}