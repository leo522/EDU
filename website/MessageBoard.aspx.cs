using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KMU.EduActivity.ApplicationLayer.DTO;
using Telerik.Web.UI;

public partial class MessageBoard : AuthPage
{
    private int CurrentPage
    {
        get
        {
            if (ViewState["CurrentPage"] == null)
            {
                return 1;
            }
            else
            {
                return Convert.ToInt32(ViewState["CurrentPage"]);
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (CurrentPage == 1)
        {
            btnLastPage.Enabled = false;
        }
        else
        {
            btnLastPage.Enabled = true;
        }


        if (!IsPostBack)
        {
            ReadData();
            rgMessage.DataBind();
        }
    }

    private void ReadData()
    {
        List<MessageBoardDto> list = service.GetMessageBoardList(10 * (CurrentPage - 1), 9, this.AuthRoles.Contains("Admin"), this.EmpCode, ddlQTypeQuery.Text, tvcbJobCodeQuery.SelectedValue, cbIsClose.Checked);
        foreach (MessageBoardDto dto in list)
        {
            if (dto.MessageTitle == "")
            {
                dto.MessageTitle = "<無標題>";
            }
        }

        rgMessage.DataSource = list;

        if (list.Count > 0 && list.Count < 10)
        {
            int maxid = list.Min(c => c.MessageID);
            if (service.CheckIsMin(maxid))
            {
                btnNextPage.Enabled = false;
            }
            else
            {
                btnNextPage.Enabled = true;
            }
        }
        else
        {
            btnNextPage.Enabled = false;
        }
    }

    protected void rgNews_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (ddlQType.SelectedValue == null || ddlQType.SelectedValue == "")
        {
            ShowMessage("請選擇問題類別");
            return;
        }

        if (tbTitle.Text == "")
        {
            ShowMessage("請輸入標題");
            return;
        }

        if (tvcbJobCode.SelectedValue == "" || tvcbJobCode.SelectedValue == null)
        {
            ShowMessage("請選擇問題職類");
            return;
        }

        bool success = service.InsertMessageBoard(ddlQType.Text, tbTitle.Text, tvcbJobCode.SelectedValue, reContent.Content, this.EmpCode, null, cbIsPublic.Checked, false);
        if (success)
        {
            ShowMessageAndGo("留言完成!", "MessageBoard.aspx");
        }
        else
        {
            ShowMessage("留言失敗，請重試");
        }
    }
    protected void btnLastPage_Click(object sender, EventArgs e)
    {
        if (CurrentPage != 1)
        {
            ViewState["CurrentPage"] = CurrentPage - 1;
        }
        if (CurrentPage == 1)
        {
            btnLastPage.Enabled = false;
        }
        else
        {
            btnLastPage.Enabled = true;
        }
        ReadData();
        rgMessage.DataBind();
        
    }
    protected void btnNextPage_Click(object sender, EventArgs e)
    {
        ViewState["CurrentPage"] = CurrentPage + 1;
        if (CurrentPage == 1)
        {
            btnLastPage.Enabled = false;
        }
        else
        {
            btnLastPage.Enabled = true;
        }
        ReadData();
        rgMessage.DataBind();
        
    }
    protected void rgMessage_ItemCreated(object sender, Telerik.Web.UI.GridItemEventArgs e)
    {
        LinkButton lbtn = e.Item.FindControl("lbtnMessageTitle") as LinkButton;
        if (lbtn != null)
        {
            if ((e.Item as GridDataItem).GetDataKeyValue("MessageID") != null)
            {
                string id = (e.Item as GridDataItem).GetDataKeyValue("MessageID").ToString();
                lbtn.OnClientClick = "window.open('MessageBoardShow.aspx?id=" + id + "','查閱訊息');return false";
            }
        }
    }
    protected void btnQuery_Click(object sender, EventArgs e)
    {
        ReadData();
        rgMessage.DataBind();
    }
}