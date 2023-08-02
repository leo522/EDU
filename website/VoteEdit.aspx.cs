using KMU.EduActivity.ApplicationLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class VoteEdit : AuthPage
{
    private bool IsCopyMode
    {
        get
        {
            return Request.QueryString["CopyByID"] != null;
        }
    }

    private int? CopyByID
    {
        get
        {
            if (Request.QueryString["CopyByID"] == null)
            {
                return null;
            }
            else
            {
                return Convert.ToInt32(Request.QueryString["CopyByID"]);
            }
        }
    }

    private VoteMainDto CurrentMain
    {
        get
        {
            return ViewState["CurrentMain"] as VoteMainDto;
        }
        set
        {
            ViewState["CurrentMain"] = value;
        }
    }

    private List<VoteGroupDto> CurrentGroups
    {
        get
        {
            return ViewState["CurrentGroups"] as List<VoteGroupDto>;
        }
        set
        {
            ViewState["CurrentGroups"] = value;
        }
    }

    private int? MainID
    {
        get
        {
            if (Request.QueryString["MainID"] == null)
            {
                return null;
            }
            else
            {
                return Convert.ToInt32(Request.QueryString["MainID"]);
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            ReadData();
        }
    }

    private void ReadData()
    {
        VoteMainDto main = null;
        if(IsCopyMode)
        {
            main = service.GetVoteMain(CopyByID.Value);
            btnSave.Text = "確定複製";
            CurrentGroups = service.GetVoteGroups(CopyByID.Value);
        }
        else
        {
            main = service.GetVoteMain(MainID.Value);
            btnSave.Text = "確定儲存";
            CurrentGroups = service.GetVoteGroups(MainID.Value);
        }
        CurrentMain = main;

        tbVoteName.Text = main.VoteName;
        rdpSdate.SelectedDate = main.Sdate;
        rdpEdate.SelectedDate = main.Edate;
        reHeader.Content = main.Header;


        rgGroups.DataSource = CurrentGroups;
        rgGroups.DataBind();

    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("VoteManage.aspx");
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        RefreashCurrentGroup();
        foreach(VoteGroupDto g in CurrentGroups)
        {
            if(g.ChoiceRate == null && g.ChoiceCount == null)
            {
                ShowMessage("未設定項目:" + g.GroupName + "的投票數");
                return;
            }

        }
        if(IsCopyMode)
        {
            VoteMainDto main = new VoteMainDto();
            main.Creater = this.EmpCode;
            main.Edate = rdpEdate.SelectedDate;
            main.Header = reHeader.Content;
            main.HospCode = CurrentMain.HospCode;
            main.Sdate = rdpSdate.SelectedDate;
            main.VoteName = tbVoteName.Text;
            main.VoteType = CurrentMain.VoteType;
            int mainid = service.CopyVoteMain(main, CopyByID.Value, CurrentGroups);
        }
        else
        {
            CurrentMain.Edate = rdpEdate.SelectedDate;
            CurrentMain.Sdate = rdpSdate.SelectedDate;
            CurrentMain.VoteName = tbVoteName.Text;
            CurrentMain.Header = reHeader.Content;
            string msg = service.UpdateVoteMain(CurrentMain, CurrentGroups);
            if(msg!=null)
            {
                ShowMessage("更新失敗:" + msg);
                return;
            }
        }

        
        Response.Redirect("VoteManage.aspx");
    }

    private void RefreashCurrentGroup()
    {
        foreach (GridDataItem item in rgGroups.Items)
        {
            RadioButton rbChoiceTypeRate = item.FindControl("rbChoiceTypeRate") as RadioButton;
            RadioButton rbChoiceTypeNum = item.FindControl("rbChoiceTypeNum") as RadioButton;
            RadNumericTextBox rntbChoiceRate = item.FindControl("rntbChoiceRate") as RadNumericTextBox;
            RadNumericTextBox rntbChoiceNum = item.FindControl("rntbChoiceNum") as RadNumericTextBox;

            string name = (item as GridDataItem).GetDataKeyValue("GroupName").ToString();

            VoteGroupDto currentGroup = CurrentGroups.Where(c => c.GroupName == name).FirstOrDefault();


            if (rbChoiceTypeRate.Checked)
            {
                if (rntbChoiceRate.Value.HasValue)
                {
                    currentGroup.ChoiceRate = Convert.ToDecimal(rntbChoiceRate.Value);
                }
                else
                {
                    currentGroup.ChoiceRate = null;
                }
                currentGroup.ChoiceCount = null;
            }

            if (rbChoiceTypeNum.Checked)
            {
                if (rntbChoiceNum.Value.HasValue)
                {
                    currentGroup.ChoiceCount = Convert.ToInt32(rntbChoiceNum.Value);
                }
                else
                {
                    currentGroup.ChoiceCount = null;
                }
                currentGroup.ChoiceRate = null;
            }
        }
    }

    protected void rgGroups_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            RadioButton rbChoiceTypeRate = e.Item.FindControl("rbChoiceTypeRate") as RadioButton;
            RadioButton rbChoiceTypeNum = e.Item.FindControl("rbChoiceTypeNum") as RadioButton;
            RadNumericTextBox rntbChoiceRate = e.Item.FindControl("rntbChoiceRate") as RadNumericTextBox;
            RadNumericTextBox rntbChoiceNum = e.Item.FindControl("rntbChoiceNum") as RadNumericTextBox;

            string name = (e.Item as GridDataItem).GetDataKeyValue("GroupName").ToString();

            VoteGroupDto currentGroup = CurrentGroups.Where(c => c.GroupName == name).FirstOrDefault();

            if (currentGroup.ChoiceRate != null)
            {
                rbChoiceTypeRate.Checked = true;
                rntbChoiceRate.Value = Convert.ToDouble(currentGroup.ChoiceRate);
            }

            if (currentGroup.ChoiceCount != null)
            {
                rbChoiceTypeNum.Checked = true;
                rntbChoiceNum.Value = Convert.ToDouble(currentGroup.ChoiceCount);
            }


        }
    }
    protected void rgGroups_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        rgGroups.DataSource = CurrentGroups;
    }
}