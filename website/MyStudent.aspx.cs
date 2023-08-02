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

public partial class MyStudent : AuthPage
{


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int eduyeare = DateTime.Now.Year - 1911;
            int eduyears = eduyeare - 1;
            tbEduYearS.Text = eduyears.ToString();
            tbEduYearE.Text = eduyeare.ToString();


            //rdpEDate.SelectedDate = DateTime.Now.Date;
            //rdpSDate.SelectedDate = DateTime.Now.Date.AddMonths(-1);
        }
    }


    private void ReadData()
    {
        RadGrid1.DataSource = null;


        List<EduStudentData> list = service.GetMyStudentData(this.EmpCode, tbEduYearS.Text.Trim(), tbEduYearE.Text.Trim(), TreeViewComboBox1.SelectedValue, rdpSDate.SelectedDate, rdpEDate.SelectedDate);
        RadGrid1.DataSource = list;
    }
    protected void RadGrid1_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        ReadData();
    }

    protected void btnQuery_Click(object sender, EventArgs e)
    {
        ReadData();
        RadGrid1.DataBind();
    }

    protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridGroupHeaderItem)
        {

            (e.Item as GridGroupHeaderItem).DataCell.Text = (e.Item as GridGroupHeaderItem).DataCell.Text.Substring((e.Item as GridGroupHeaderItem).DataCell.Text.IndexOf(":") + 1);

        }


        if (e.Item is GridDataItem)
        {
            string idno = (e.Item as GridDataItem).GetDataKeyValue("IDNo").ToString();
            Button btn = e.Item.FindControl("btniKasa") as Button;
            if (btn != null)
            {
                btn.OnClientClick = "post_to_url('iKASA/main.aspx',{'iKasaIdNo':'" + idno + "'}); return false;";
            }
        }
    }
}