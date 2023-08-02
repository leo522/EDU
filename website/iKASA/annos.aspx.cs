using KMU.EduActivity.ApplicationLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class iKASA_annos : iKASAPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

        }


    }

    private void ReadNewsData()
    {
        rgNews.DataSource = null;
        rgNews.MasterTableView.DataKeyNames = new string[] { "NEWID" };


        List<NewsDto> list = service.Get1600iKasaNewsToShow//(DateTime.Now.AddDays(-20), DateTime.Now.Date.AddDays(1).AddSeconds(-1), this.JobCode, this.EmpCode);
            (null, DateTime.Now.Date.AddDays(1).AddSeconds(-1), null, CurrentPersonInfo.empcode, null);
        rgNews.DataSource = list;
    }

    protected void rgNews_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        ReadNewsData();
    }
    protected void rgNews_ItemCreated(object sender, GridItemEventArgs e)
    {
        LinkButton lbtn = e.Item.FindControl("lbtnShowNews") as LinkButton;
        if (lbtn != null)
        {
            if ((e.Item as GridDataItem).GetDataKeyValue("NEWID") != null)
            {
                string newid = (e.Item as GridDataItem).GetDataKeyValue("NEWID").ToString();
                lbtn.OnClientClick = "window.open('../EduNewsShow.aspx?newid=" + newid + "','公佈欄',config='height=500px,width=700px');return false";
            }
        }
    }

}