using KMU.EduActivity.ApplicationLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class VoteMain : AuthPage
{
    private List<VoteMainDto> CurrentVotes
    {
        get
        {
            return ViewState["CurrentVotes"] as List<VoteMainDto>;
        }
        set
        {
            ViewState["CurrentVotes"] = value;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            RadGrid1.DataBind();
        }
    }

    private void ReadVoteData()
    {
        List<VoteMainDto> list = service.GetAvailableVote(this.EmpCode, this.HospCode);
        CurrentVotes = list;
        RadGrid1.DataSource = list;

    }
    protected void RadGrid1_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        ReadVoteData();
    }
    protected void GoVote_Click(object sender, EventArgs e)
    {
        GridDataItem item = (sender as Button).Parent.Parent as GridDataItem;
        string mainid = item.GetDataKeyValue("ID").ToString();
        int id = Convert.ToInt32(mainid);
        VoteMainDto dto = CurrentVotes.Where(c => c.ID == id).FirstOrDefault();
        if(dto != null)
        {
            if(dto.Sdate.Value>DateTime.Now.Date)
            {
                ShowMessage("投票尚未開始");
                return;
            }
        }
        else
        {
            ShowMessage("資料錯誤，請重新整理頁面");
            return;
        }
        Response.Redirect("VotePage.aspx?ID=" + mainid);
    }
    protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
    {

    }
}