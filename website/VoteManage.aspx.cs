using KMU.EduActivity.ApplicationLayer.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class VoteManage : AuthPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AddPostbackControl(RadGrid1);
        if(!IsPostBack)
        {
            rdpSdateS.SelectedDate = new DateTime(DateTime.Now.AddMonths(-2).Year, DateTime.Now.AddMonths(-2).Month, 1);
            rdpSdateE.SelectedDate = DateTime.Now.AddMonths(1);

            RadGrid1.DataBind();
        }
    }

    private void ReadVoteData()
    {
        List<VoteMainDto> list = service.GetVotes(tbKeyWord.Text.Trim(), rdpSdateS.SelectedDate, rdpSdateE.SelectedDate);

        RadGrid1.DataSource = list;

    }
    protected void RadGrid1_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        ReadVoteData();
    }

    protected void btnVoteStastic_Click(object sender, EventArgs e)
    {
        GridDataItem item = (sender as Button).Parent.Parent as GridDataItem;
        string mainid = item.GetDataKeyValue("ID").ToString();

        Response.Redirect("VoteStastic.aspx?ID=" + mainid);
    }
    protected void btnQuery_Click(object sender, EventArgs e)
    {
        ReadVoteData();
        RadGrid1.DataBind();
    }
    protected void btnVoteList_Click(object sender, EventArgs e)
    {
        GridDataItem item = (sender as Button).Parent.Parent as GridDataItem;
        int mainid = Convert.ToInt32(item.GetDataKeyValue("ID"));
        List<VoteGroupDto> list = service.GetVoteGroups(mainid);


        DataTable dt = new DataTable();
        dt.Columns.Add("員工編號");
        dt.Columns.Add("姓名");
        foreach (VoteGroupDto g in list)
        {
            foreach (VoteItemDto i in g.VoteItems)
            {
                DataRow dr = dt.NewRow();
                dr["員工編號"] = i.Value;
                dr["姓名"] = i.Text;
                dt.Rows.Add(dr);
            }
        }

        Utility uti = new Utility();
        byte[] binaryData = uti.ExportDataTableToExcel(dt);

        HttpResponse response = Response;

        response.Clear();

        response.AddHeader("Content-Type", "binary/octet-stream");

        response.AddHeader("Content-Disposition", "attachment; filename=data.xls" + "; size=" + binaryData.Length.ToString());

        response.BinaryWrite(binaryData);

        response.Flush();
        response.End();
    }
    protected void btnCopy_Click(object sender, EventArgs e)
    {
        GridDataItem item = (sender as Button).Parent.Parent as GridDataItem;
        int mainid = Convert.ToInt32(item.GetDataKeyValue("ID"));

        Response.Redirect("VoteEdit.aspx?CopyByID=" + mainid.ToString());

    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        GridDataItem item = (sender as Button).Parent.Parent as GridDataItem;
        int mainid = Convert.ToInt32(item.GetDataKeyValue("ID"));

        Response.Redirect("VoteEdit.aspx?MainID=" + mainid.ToString());
    }
    protected void btnView_Click(object sender, EventArgs e)
    {
        GridDataItem item = (sender as Button).Parent.Parent as GridDataItem;
        int mainid = Convert.ToInt32(item.GetDataKeyValue("ID"));

        Response.Redirect("VotePage.aspx?ID=" + mainid.ToString());
    }
}