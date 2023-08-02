using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ILCalc;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EntitiesModel1 context = new EntitiesModel1();
            var clist = (from itm in context.PassPortStudentApplicationItems
                         where itm.ApplicationMemberNumber == "1060514"
                         select new { itm.ApplicationMemberNumber, itm.ItemCode }).Distinct().ToList();

            foreach(var itm in clist)
            {
                var elist = from i in context.PassPortStudentApplicationItems
                            where i.ItemCode == itm.ItemCode && i.ApplicationMemberNumber == itm.ApplicationMemberNumber
                            && i.CheckResult.HasValue && i.CheckResult == true
                            orderby i.CheckDate
                            select i;
                int checkorder = 1;
                foreach(var ei in elist)
                {
                    ei.CheckOrder = checkorder;
                    checkorder++;
                    
                }
                context.SaveChanges();
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            CalcContext<double> calc = new CalcContext<double>();
            double value = calc.Evaluate(textBox1.Text);
            MessageBox.Show(value.ToString());
   
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            string sql = @"select InstanceID , 
b.EduStopActScheduleID+'('+
--convert(varchar, b.TimeFrom, 120)+'-'+	convert(varchar, b.TimeTo , 8)
convert(varchar, b.TimeFrom, 112)
+')'
+ replace(b.ActName ,'/','')
as filename  from RecordEduActRef a inner join EduStopActSchedule b on a.EduStopActScheduleID = b.EduStopActScheduleID where a.EduStopActScheduleID in
(
--select EduStopActScheduleID from EduStopActSchedule where DeptCode = '1300' and actname like '%晨報會%' and TimeFrom between '2021/7/1' and '2022/7/1'
--and DATENAME(WEEKDAY, timefrom ) in ('星期二','星期四','星期五')
--union all
select EduStopActScheduleID from EduStopActSchedule where DeptCode = '1350' and TimeFrom between '2021/7/1' and '2022/7/1'
and DATENAME(WEEKDAY, timefrom ) in ('星期一') and datepart(hour,timefrom) = 16
)";

            EntitiesModel1 m = new EntitiesModel1();
            List<resultData> datas = m.ExecuteQuery<resultData>(sql).ToList();

            List<MemoryStream> pdfs = new List<MemoryStream>();

            string url = "http://localhost/EduActivity/RecordEdit.aspx?InstanceID={0}&EmpCode=1020640";

            foreach (var data in datas)
            {
                //string fullurl = string.Format(url, data.InstanceID);

                //SelectPdf.HtmlToPdf converter = new SelectPdf.HtmlToPdf();


                //SelectPdf.PdfDocument doc = converter.ConvertUrl(fullurl);

                //MemoryStream stream = new MemoryStream();
                //doc.Save(stream);
                //doc.Close();
                //stream.Position = 0;

                //doc.Save(data.filename + ".pdf");
                //pdfs.Add(stream);
            }
            

            //string filename = "resume.pdf";
            //MemoryStream mergedpdf = new MemoryStream();
            //iTextSharp.text.Document mergedoc = new iTextSharp.text.Document();
            //iTextSharp.text.pdf.PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(mergedoc, new FileStream(Request.PhysicalApplicationPath + "pdfTempFile/" + filename, FileMode.Create));//iTextSharp.text.pdf.PdfWriter.GetInstance(mergedoc, mergedpdf);
            //mergedoc.SetPageSize(iTextSharp.text.PageSize.A4);
            //mergedoc.Open();
            //iTextSharp.text.pdf.PdfContentByte cb = writer.DirectContent;
            //iTextSharp.text.pdf.PdfImportedPage page;
            //iTextSharp.text.pdf.PdfReader reader;
            //iTextSharp.text.pdf.PdfAction jAction = iTextSharp.text.pdf.PdfAction.JavaScript("this.print(true);\r", writer);
            //writer.AddJavaScript(jAction);
            //foreach (MemoryStream p in pdfs)
            //{
            //    reader = new iTextSharp.text.pdf.PdfReader(p.ToArray());
            //    int pages = reader.NumberOfPages;

            //    // loop over document pages
            //    for (int i = 1; i <= pages; i++)
            //    {
            //        mergedoc.SetPageSize(iTextSharp.text.PageSize.A4);
            //        mergedoc.NewPage();
            //        page = writer.GetImportedPage(reader, i);
            //        cb.AddTemplate(page, 0, 0);
            //    }
            //}

            //mergedoc.Close();
            ////byte[] data = mergedpdf.GetBuffer();
            //mergedpdf.Flush();
            //mergedpdf.Dispose();
            //mergedoc.Close();
        }
    }

    public class resultData
    {
        public string InstanceID
        {
            get;
            set;
        }
        public string filename
        {
            get;
            set;
        }
    }
}
