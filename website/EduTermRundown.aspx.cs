using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KMU.EduActivity.ApplicationLayer.DTO;
using Telerik.Web.UI;
using System.IO;
using System.Data.OleDb;
using System.Data;

public partial class EduTermRundown : AuthPage
{
    private List<EduTeamRundownDto> CurrentList
    {
        get
        {
            return Session["EduTeamRundownList"] as List<EduTeamRundownDto>;
        }
        set
        {
            Session["EduTeamRundownList"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        (Master.FindControl("RadScriptManager1") as RadScriptManager).RegisterPostBackControl(RadGrid1);
        if (!IsPostBack)
        {
            //RadGrid1.DataBind();
            dsTermCode.Select();
        }
        lblMsg.Text = "";
    }


    private void ReadData()
    {
        RadGrid1.DataSource = null;
        RadGrid1.MasterTableView.DataKeyNames = new string[] { "EduTeamStopID" };

        List<string> jobcodes = new List<string>();
        foreach (RadComboBoxItem item in ddlJobCode.CheckedItems)
        {
            jobcodes.Add(item.Value);
        }

        List<EduTeamRundownDto> list = service.SearchEduTeamRundown(rdpDateBegin.SelectedDate, rdpDateEnd.SelectedDate, jobcodes);
        CurrentList = list;
        RadGrid1.DataSource = list;
    }
    protected void RadGrid1_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        ReadData();
    }
    protected void RadGrid1_InsertCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
    {
        GridEditableItem editedItem = e.Item as GridEditableItem;

        DateTime? datefrom = (editedItem.FindControl("rdpEditDateBegin") as RadDatePicker).SelectedDate;
        DateTime? dateto = (editedItem.FindControl("rdpEditDateEnd") as RadDatePicker).SelectedDate;
        string eduteamcode = (editedItem.FindControl("TreeViewComboBox1") as TreeViewComboBox).SelectedValue;

        EduTeamRundownDto newdto = new EduTeamRundownDto();

        newdto.DateFrom = datefrom.Value;
        newdto.DateTo = dateto.Value;
        newdto.EduTeamCode = eduteamcode;
        
        service.InsertEduTeamRundown(newdto);
    }
    protected void RadGrid1_DeleteCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
    {
        if (e.CommandName != RadGrid.DeleteSelectedCommandName)
        {
            List<EduTeamRundownDto> list = new List<EduTeamRundownDto>() { CurrentList[e.Item.DataSetIndex] };

            service.DeleteEduTeamRundowns(list);
        }
    }
    protected void RadGrid1_UpdateCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
    {
        EduTeamRundownDto dto = CurrentList[e.Item.DataSetIndex];
        GridEditableItem editedItem = e.Item as GridEditableItem;

        DateTime? datefrom = (editedItem.FindControl("rdpEditDateBegin") as RadDatePicker).SelectedDate;
        DateTime? dateto = (editedItem.FindControl("rdpEditDateEnd") as RadDatePicker).SelectedDate;
        string eduteamcode = (editedItem.FindControl("TreeViewComboBox1") as TreeViewComboBox).SelectedValue;

        dto.DateFrom = datefrom.Value;
        dto.DateTo = dateto.Value;
        dto.EduTeamCode = eduteamcode;
        
        service.UpdateEduTeamRundown(dto);

    }
    protected void btnQuery_Click(object sender, EventArgs e)
    {
        ReadData();
        RadGrid1.DataBind();
    }

    protected void RadGrid1_ItemCommand(object sender, GridCommandEventArgs e)
    {
        if (e.CommandName == RadGrid.DeleteSelectedCommandName)
        {
            List<EduTeamRundownDto> list = new List<EduTeamRundownDto>();
            foreach (GridItem item in RadGrid1.SelectedItems)
            {
                EduTeamRundownDto dto = CurrentList[item.DataSetIndex];
                list.Add(dto);
            }
            service.DeleteEduTeamRundowns(list);
        }

        if (e.CommandName == "OpenWin")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), this.ClientID + "RunOpenWin", "openWin(" + CurrentList[e.Item.DataSetIndex].EduTeamStopID + ");", true);             
        }
    }
    protected void ddlJobCode_DataBound(object sender, EventArgs e)
    {
        if (ddlJobCode.Items.Count > 0)
        {
            ddlJobCode.SelectedIndex = 0;
            foreach (RadComboBoxItem item in ddlJobCode.Items)
            {
                item.Checked = true;
            }
        }
    }
    protected void RadGrid1_ItemCreated(object sender, GridItemEventArgs e)
    {
        LinkButton lbtn = e.Item.FindControl("lbtnOpenCourse") as LinkButton;
        if (lbtn != null)
        {
            lbtn.OnClientClick = "openWin('?EduTeamStopID=" + CurrentList[e.Item.DataSetIndex].EduTeamStopID + "&sdate=" + CurrentList[e.Item.DataSetIndex].DateFrom.ToString("yyyyMMdd") + "&edate=" + CurrentList[e.Item.DataSetIndex].DateTo.ToString("yyyyMMdd") + "');return false;";
            //lbtn.Attributes.Add("onclick", "openWin('" + CurrentList[e.Item.DataSetIndex].EduTeamStopID + "');return false;");
        }
    }
    protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if ((e.Item is GridEditFormItem))
        {
            GridEditFormItem editform = (GridEditFormItem)e.Item;
            TreeViewComboBox ddl = (TreeViewComboBox)editform.FindControl("TreeViewComboBox1");
            if (ddl != null)
            {
                ddl.TreeDataSourceID = "dsTermCode";
                ddl.TreeView.DataBind();
            }
        }
    }
}