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

public partial class ERScoreManager : AuthPage
{


    protected void Page_Load(object sender, EventArgs e)
    {
        //(Master.FindControl("RadScriptManager1") as RadScriptManager).RegisterPostBackControl(RadGrid1);
        if (!IsPostBack)
        {
        }
    }


    private void ReadData()
    {
        RadGrid1.DataSource = null;
        RadGrid1.MasterTableView.DataKeyNames = new string[] { "ExamID" };


        List<IKASA_ERExamDto> list = service.GetiKasaERExams(tbExamName.Text, rdpExamDate.SelectedDate);
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
                if ((e.Item as GridDataItem).GetDataKeyValue("ExamID") != null)
                {
                    string examid = (e.Item as GridDataItem).GetDataKeyValue("ExamID").ToString();

                    service.DeleteiKasaERExam(examid);

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
                    if ((e.Item as GridDataItem).GetDataKeyValue("ExamID") != null)
                    {
                        string examid = (e.Item as GridDataItem).GetDataKeyValue("ExamID").ToString();
                        service.DeleteiKasaERExam(examid);
                    }
                }
            }
            ReadData();
            RadGrid1.DataBind();
        }
    }

    protected void RadGrid1_ItemCreated(object sender, GridItemEventArgs e)
    {
        LinkButton lbtn = e.Item.FindControl("lbtnEdit") as LinkButton;
        if (lbtn != null)
        {
            if ((e.Item as GridDataItem).GetDataKeyValue("ExamID") != null)
            {
                string examid = (e.Item as GridDataItem).GetDataKeyValue("ExamID").ToString();
                lbtn.OnClientClick = "location.href='ERScoreEdit.aspx?examid=" + examid + "';return false;";
            }
            
        }
    }
}