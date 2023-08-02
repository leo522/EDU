using KMU.EduActivity.ApplicationLayer.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Drawing;

public partial class iKASA_chart : iKASAPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            ReadPie();
            //ReadBar();
            ReadListData();
            ReadIPDData();
        }
        catch(Exception ex)
        {

        }
    }

    private void ReadListData()
    {
        DataTable itemdata = null;
        string empcode = CurrentPersonInfo.empcode;
        //empcode = "1020640";
        List<EduPassportInstanceDto> list = service.QueryEduPassportInstance(null, null, null, empcode, null, this.CurrentPersonInfo.dateform ,this.CurrentPersonInfo.dateto , null, ref itemdata).OrderBy(c => c.CreateDate).ToList();

        rgList.DataSource = list;
        rgList.DataBind();
        //CurrentInstances = list;

    }

    protected void rgList_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            if (e.Item.Cells[4].Text != "100%")
            {
                e.Item.Cells[4].ForeColor = System.Drawing.Color.Red;
            }

            if (e.Item.Cells[5].Text != "100%")
            {
                e.Item.Cells[5].ForeColor = System.Drawing.Color.Red;
            }

            if (e.Item.Cells[6].Text != "100%")
            {
                e.Item.Cells[6].ForeColor = System.Drawing.Color.Red;
            }
        }
    }

    private void ReadIPDData() //臨床照顧能力
    {
        DataTable dt = service.GetiKASAIPDData(CurrentPersonInfo.empcode);
        RadGrid1.DataSource = dt;
        RadGrid1.DataBind();
        
    }

    private void ReadPie() //雷達圖
    {
        var rates = service.GetiKasaFormFinishRate(CurrentPersonInfo.empcode, CurrentPersonInfo.memberid);
        foreach(var r in rates)
        {
            r.Value = Math.Round(r.Value, 2);
        }
        Chart1.Series["Series1"].Points.DataBindXY(rates, "Name", rates, "Value");
        Chart1.Series["Series1"].IsValueShownAsLabel = true;
        Chart1.Series["Series1"].Font = new Font("微軟正黑體", 11);
        Chart1.Legends.Add("已完成");
        Chart1.Legends.Add("未完成");
        Chart1.Legends.Add("逾期未完成");
        Chart1.Series["Series1"].Points[0].Color = Color.LightGreen;
        Chart1.Series["Series1"].Points[1].Color = Color.Aqua;
        Chart1.Series["Series1"].Points[2].Color = Color.Orange;
        Chart1.Legends[0].Docking = Docking.Bottom;
        Chart1.Legends[1].Docking = Docking.Bottom;
        Chart1.Legends[2].Docking = Docking.Bottom;
        Chart1.Legends[0].Font = new Font("微軟正黑體", 9);
        Chart1.Legends[1].Font = new Font("微軟正黑體", 9);
        Chart1.Legends[2].Font = new Font("微軟正黑體", 9);

        string[] legtext = new string[3] { "已完成", "未完成", "逾期未完成" };

        for (int i = 0; i < 3; i++)
        {
            var p = Chart1.Series["Series1"].Points[i];
            if (p.YValues.Length > 0 && (double)p.YValues.GetValue(0) == 0)
            {
                p.IsValueShownAsLabel = false;
                p.Label = " ";
                p.LegendText = legtext[i];
            }
            else
            {
                p.IsValueShownAsLabel = true;
            }
        }

    }

    private void ReadBar() //學習護照狀況
    {
        DataTable itemdata = null;
        string empcode = CurrentPersonInfo.empcode;
        //empcode = "1020640";
        List<EduPassportInstanceDto> list = service.QueryEduPassportInstance(null, null, null, empcode, null, null, null, null, ref itemdata).OrderBy(c => c.CreateDate).ToList();
        
        foreach(var dto in list)
        {
            Chart2.Series["Series1"].Points.AddXY(dto.TemplateName, dto.FinishRateNumber);
            Chart2.Series["Series2"].Points.AddXY(dto.TemplateName, dto.NecessaryFinishRateNumber);
            Chart2.Series["Series3"].Points.AddXY(dto.TemplateName, dto.StudentFinishRateNumber);
        }

        Chart2.Series["Series1"].Color = Color.Aqua;
        Chart2.Series["Series2"].Color = Color.LightGreen;
        Chart2.Series["Series3"].Color = Color.Orange;
        Chart2.ChartAreas[0].AxisX.Interval = 1;

    }
    protected void RadGrid1_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
    {
        if(e.Item is GridDataItem)
        {
            (e.Item as GridDataItem).Width = Unit.Pixel(150);
        }
    }
}