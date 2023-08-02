using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class iKASA_EduScore : iKASAPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var data = service.QueryEduScoreData(CurrentPersonInfo.empcode, "", null, null);
        //var data = service.QueryEduScoreData("1020640", "", null, null);
        int serial = 1;
        foreach(var d in data)
        {
            d.Id = serial;
            serial++;
        }

        if (data.Count == 0)
        {
            liContent.Text = "<div align='center'><h2>無相關資訊</h2></div>";
        }
        else
        {
            string htmltemplate = @"
<div align='center'><h3>高雄醫學大學附設中和紀念醫院</h3></div>
<div align='center'><h3>實習各階段評量</h3></div>
<div align='center'>
<table border='1' width='95%'>
<tr>
<th>序</th>
<th>系級</th>
<th>實習課程名稱</th>
<th>總成績</th>
</tr>
{0}
</table>
</div>
<br>
";
 

            string htmlcontent = "";
            foreach (var d in data)
            {
                htmlcontent += "<tr>";
                htmlcontent += "<td align='center'>" + d.Id.ToString() + "</td>";
                htmlcontent += "<td align='center'>" + d.Deplevel + "</td>";
                htmlcontent += "<td align='center'>" + d.Classname + "</td>";
                htmlcontent += "<td align='center'>" + d.Score.ToString("0.00") + "</td>";
                htmlcontent += "</tr>";
            }

            liContent.Text = string.Format(htmltemplate, htmlcontent);
        }
    }
}