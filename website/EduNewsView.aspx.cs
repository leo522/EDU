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

public partial class EduNewsView : AuthPage
{
    private List<NewsDto> CurrentList
    {
        get
        {
            return Session["EduNewsList"] as List<NewsDto>;
        }
        set
        {
            Session["EduNewsList"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        (Master.FindControl("RadScriptManager1") as RadScriptManager).RegisterPostBackControl(RadGrid1);
        if (!IsPostBack)
        {
        }
    }


    private void ReadData()
    {
        RadGrid1.DataSource = null;
        RadGrid1.MasterTableView.DataKeyNames = new string[] { "NEWID" };


        List<NewsDto> list = service.GetNews(rdpDateBegin.SelectedDate, rdpDateEnd.SelectedDate);
        CurrentList = list;
        RadGrid1.DataSource = list;
    }
    protected void RadGrid1_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        ReadData();
    }

    protected void RadGrid1_DeleteCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
    {
        if (e.CommandName != RadGrid.DeleteSelectedCommandName)
        {
            if (e.Item is GridDataItem)
            {
                if ((e.Item as GridDataItem).GetDataKeyValue("NEWID") != null)
                {
                    string newid = (e.Item as GridDataItem).GetDataKeyValue("NEWID").ToString();

                    service.DeleteNews(newid);

                    ReadData();
                    RadGrid1.DataBind();
                }
            }
        }
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
            foreach (GridItem item in RadGrid1.SelectedItems)
            {
                if (e.Item is GridDataItem)
                {
                    if ((e.Item as GridDataItem).GetDataKeyValue("NEWID") != null)
                    {
                        string newid = (e.Item as GridDataItem).GetDataKeyValue("NEWID").ToString();
                        service.DeleteNews(newid);
                    }
                }
            }
            ReadData();
            RadGrid1.DataBind();
        }
    }

    protected void RadGrid1_ItemCreated(object sender, GridItemEventArgs e)
    {
        LinkButton lbtn = e.Item.FindControl("lbtnEditNews") as LinkButton;
        if (lbtn != null)
        {
            if ((e.Item as GridDataItem).GetDataKeyValue("NEWID") != null)
            {
                string newid = (e.Item as GridDataItem).GetDataKeyValue("NEWID").ToString();
                lbtn.OnClientClick = "location.href='EduNewsEdit.aspx?newid=" + newid + "';return false;";
            }
            //lbtn.Attributes.Add("onclick", "openWin('" + CurrentList[e.Item.DataSetIndex].EduTeamStopID + "');return false;");
        }
    }
}