using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KMU.EduActivity.ApplicationLayer.DTO;
using EduActivity.Report;
using Telerik.Reporting;

public partial class EduPassportInstancePrint : AuthPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            ReadData();

        }
    }

    private void ReadData()
    {
        EduPassportReportMain data = service.GetEduPassportReportData(Request.QueryString["ID"].ToString());



        ////test
        //data.HOSPNAME = "醫院";
        //data.PASSPORTNAME = "某一本護照";
        //data.STUDENTNAME = "吳健璋";

        //List<EduPassportReportGroup> groups = new List<EduPassportReportGroup>();
        //EduPassportReportGroup g = new EduPassportReportGroup();
        //g.ITEMGROUPNAME = "test1";

        //List<EduPassportReportItem> items = new List<EduPassportReportItem>();
        //List<EduPassportReportItem> items1 = new List<EduPassportReportItem>();
        //List<EduPassportReportItem> items2 = new List<EduPassportReportItem>();
        //EduPassportReportItem i = new EduPassportReportItem();
        //i.COLUMNTITLE = "col1";
        //i.ITEMGROUPNAME = "test1";
        //i.ITEMNAME = "name1";
        //i.ITEMVALUE = "1-1-1";
        //items1.Add(i);
        //items.Add(i);
        //EduPassportReportItem i2 = new EduPassportReportItem();
        //i2.COLUMNTITLE = "col1";
        //i2.ITEMGROUPNAME = "test1";
        //i2.ITEMNAME = "name2";
        //i2.ITEMVALUE = "1-1-2";
        //items1.Add(i2);
        //items.Add(i2);
        //EduPassportReportItem i3 = new EduPassportReportItem();
        //i3.COLUMNTITLE = "col2";
        //i3.ITEMGROUPNAME = "test1";
        //i3.ITEMNAME = "name1";
        //i3.ITEMVALUE = "1-2-1";
        //items1.Add(i3);
        //items.Add(i3);
        //EduPassportReportItem i4 = new EduPassportReportItem();
        //i4.COLUMNTITLE = "col2";
        //i4.ITEMGROUPNAME = "test1";
        //i4.ITEMNAME = "name2";
        //i4.ITEMVALUE = "1-2-2";
        //items1.Add(i4);
        //items.Add(i4);

        //g.REPORTITEMS = items1;
        
        //EduPassportReportItem i_1 = new EduPassportReportItem();
        //i_1.COLUMNTITLE = "col1";
        //i_1.ITEMGROUPNAME = "test2";
        //i_1.ITEMNAME = "name1";
        //i_1.ITEMVALUE = "2-1-1";
        //items2.Add(i_1);
        //items.Add(i_1);
        //EduPassportReportItem i_2 = new EduPassportReportItem();
        //i_2.COLUMNTITLE = "col1";
        //i_2.ITEMGROUPNAME = "test2";
        //i_2.ITEMNAME = "name2";
        //i_2.ITEMVALUE = "2-1-2";
        //items2.Add(i_2);
        //items.Add(i_2);
        //EduPassportReportItem i_3 = new EduPassportReportItem();
        //i_3.COLUMNTITLE = "col2";
        //i_3.ITEMGROUPNAME = "test2";
        //i_3.ITEMNAME = "name1";
        //i_3.ITEMVALUE = "2-2-1";
        //items2.Add(i_3);
        //items.Add(i_3);
        //EduPassportReportItem i_4 = new EduPassportReportItem();
        //i_4.COLUMNTITLE = "col2";
        //i_4.ITEMGROUPNAME = "test2";
        //i_4.ITEMNAME = "name2";
        //i_4.ITEMVALUE = "2-2-2";
        //items2.Add(i_4);
        //items.Add(i_4);

        //EduPassportReportGroup g2 = new EduPassportReportGroup();
        //g2.ITEMGROUPNAME = "test2";
        //g2.REPORTITEMS = items2;

        //data.REPORTITEMS = items;
        //groups.Add(g);
        //groups.Add(g2);


        //test over


        EduPassportReport rep = new EduPassportReport();
        rep.DataSource = data;
        //(rep.Items.Find("subReport1", true)[0] as SubReport).Items.Find("") = data.REPORTGROUPS;
        InstanceReportSource source = new InstanceReportSource();
        source.ReportDocument = rep;
        ReportViewer1.ReportSource = source;
        ReportViewer1.DataBind();
    }

}