using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class iKASA_OSCE : iKASAPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var data = service.GetEmpiKasaOSCEExamData(CurrentPersonInfo.empcode);

        if (data.Count == 0)
        {
            liContent.Text = "<div align='center'><h2>無相關資訊</h2></div>";
        }
        else
        {
            string htmltemplate = @"
<div align='center'><h3>{0}</h3></div>
<div align='center'><h3>{1}</h3></div>
<div align='center'><h3>成績單</h3></div>
<div align='center'>
<table border='1' width='95%'>
<tr>
<th>日期</th>
<th>識別證號</th>
<th>考生姓名</th>
<th>准考證編號</th>
<th>總分</th>
<th>得分率</th>
<th>通過站數</th>
<th>落點</th>
</tr>
<tr>
<td>{2}</td>
<td>{3}</td>
<td>{4}</td>
<td>{5}</td>
<td align='right'>{6}</td>
<td align='right'>{7}</td>
<td align='right'>{8}</td>
<td>{9}</td>
</tr>
</table>
</div>
<br>
<div>
{10}
</div>
<div>
※及格標準認定<br>
    本次測驗及格標準：及格總分需達{11}分以上，且及格站數至少需通過{12}站。(含{13}站)
</div>
<div>
<pre>
<b>
※落點說明：【A】全班各站成績排名前25%、    【B】全班各站成績排名前26-50%、
           【C】全班各站成績排名前 51-75%、【D】全班各站成績排名後段25%
</b>
</pre>
</div>
";
            string subtablehtmltemplate = @"
<div align='center'>
<table border='1' width='95%'>
<tr>
<th style='width:90px'>站別</th>
{0}
</tr>
<tr>
<th style='width:90px'>教案名稱</th>
{1}
</tr>
<tr>
<th style='width:90px'>及格分數</th>
{2}
</tr>
<tr>
<th style='width:90px'>考生分數</th>
{3}
</tr>
<tr>
<th style='width:90px'>落點</th>
{4}
</tr>
<tr>
<th style='width:90px'>通過與否</th>
{5}
</tr>
</table>
</div>
";


            string htmlcontent = "";
            foreach (var exam in data)
            {
                string content1 = "";
                string content2 = "";
                string content3 = "";
                string content4 = "";
                string content5 = "";
                string content6 = "";

                foreach (var stagescore in exam.IKASA_OSCEExamScores.OrderBy(c => c.StageNo))
                {
                    content1 += "<th>第" + stagescore.StageNo.ToString() + "站</th>";
                    content2 += "<td>" + stagescore.StageName + "</td>";
                    content3 += "<td>" + stagescore.PassScore.ToString("0.00") + "</td>";
                    content4 += "<td>" + stagescore.Score.ToString("0.00") + "</td>";
                    content5 += "<td>" + stagescore.ScoreLevel + "</td>";
                    content6 += "<td>" + stagescore.IsPassStr + "</td>";
                }
                string subtable = string.Format(subtablehtmltemplate, content1, content2, content3, content4, content5, content6);

                htmlcontent += string.Format(htmltemplate, exam.HospName, exam.ExamName, exam.ExamDate.ToString("yyyy.MM.dd"), exam.QEmpCode, exam.QEmpName, exam.QExamIdno, exam.QTotalScore.ToString("0.00"), exam.QScoreRate.ToString("0.00"), exam.QPassStageCount.ToString(), exam.QScoreLevel, subtable, exam.IKASA_OSCEExamStages.Sum(c => c.PassScore).Value.ToString("0.00"), exam.PassStage.ToString(), exam.PassStage.ToString());
            }
            liContent.Text = htmlcontent;
        }
    }
}