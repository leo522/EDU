namespace EduActivity.Report
{
    partial class EduPassportReport
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.Reporting.InstanceReportSource instanceReportSource1 = new Telerik.Reporting.InstanceReportSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EduPassportReport));
            Telerik.Reporting.Drawing.PictureWatermark pictureWatermark1 = new Telerik.Reporting.Drawing.PictureWatermark();
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule2 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule3 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.DescendantSelector descendantSelector1 = new Telerik.Reporting.Drawing.DescendantSelector();
            Telerik.Reporting.Drawing.StyleRule styleRule4 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.DescendantSelector descendantSelector2 = new Telerik.Reporting.Drawing.DescendantSelector();
            Telerik.Reporting.Drawing.StyleRule styleRule5 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.DescendantSelector descendantSelector3 = new Telerik.Reporting.Drawing.DescendantSelector();
            this.eduPassportReport_sub11 = new EduActivity.Report.EduPassportReport_sub1();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.detail = new Telerik.Reporting.DetailSection();
            this.subReport1 = new Telerik.Reporting.SubReport();
            this.objectDataSource1 = new Telerik.Reporting.ObjectDataSource();
            this.pageFooterSection1 = new Telerik.Reporting.PageFooterSection();
            this.textBox9 = new Telerik.Reporting.TextBox();
            this.textBox2 = new Telerik.Reporting.TextBox();
            this.reportHeaderSection1 = new Telerik.Reporting.ReportHeaderSection();
            this.textBox10 = new Telerik.Reporting.TextBox();
            this.textBox11 = new Telerik.Reporting.TextBox();
            this.textBox6 = new Telerik.Reporting.TextBox();
            this.textBox7 = new Telerik.Reporting.TextBox();
            this.pageHeaderSection1 = new Telerik.Reporting.PageHeaderSection();
            this.textBox4 = new Telerik.Reporting.TextBox();
            this.pictureBox1 = new Telerik.Reporting.PictureBox();
            this.textBox5 = new Telerik.Reporting.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.eduPassportReport_sub11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // eduPassportReport_sub11
            // 
            this.eduPassportReport_sub11.Name = "InternCourseReport";
            // 
            // textBox1
            // 
            this.textBox1.KeepTogether = false;
            this.textBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0.99999988079071045D));
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(25.999900817871094D), Telerik.Reporting.Drawing.Unit.Cm(0.99999988079071045D));
            this.textBox1.Style.Font.Bold = true;
            this.textBox1.Style.Font.Name = "微軟正黑體";
            this.textBox1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(20D);
            this.textBox1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox1.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox1.Value = "= Fields.HOSPNAME";
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Cm(7.2999978065490723D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.subReport1});
            this.detail.KeepTogether = false;
            this.detail.Name = "detail";
            this.detail.PageBreak = Telerik.Reporting.PageBreak.None;
            this.detail.Style.BackgroundColor = System.Drawing.Color.Transparent;
            this.detail.Style.BackgroundImage.MimeType = "";
            this.detail.Style.BackgroundImage.Repeat = ((Telerik.Reporting.Drawing.BackgroundRepeat)((Telerik.Reporting.Drawing.BackgroundRepeat.RepeatX | Telerik.Reporting.Drawing.BackgroundRepeat.RepeatY)));
            // 
            // subReport1
            // 
            this.subReport1.KeepTogether = false;
            this.subReport1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.70000004768371582D), Telerik.Reporting.Drawing.Unit.Cm(0.29999944567680359D));
            this.subReport1.Name = "subReport1";
            instanceReportSource1.ReportDocument = this.eduPassportReport_sub11;
            this.subReport1.ReportSource = instanceReportSource1;
            this.subReport1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(10.899999618530273D), Telerik.Reporting.Drawing.Unit.Cm(4.4998993873596191D));
            this.subReport1.Style.BackgroundColor = System.Drawing.Color.Transparent;
            this.subReport1.Style.BackgroundImage.MimeType = "";
            this.subReport1.Style.Visible = true;
            // 
            // objectDataSource1
            // 
            this.objectDataSource1.DataSource = "KMU.EduActivity.ApplicationLayer.DTO.EduPassportReportMain, EduActivity.Core, Ver" +
    "sion=1.0.0.0, Culture=neutral, PublicKeyToken=null";
            this.objectDataSource1.Name = "objectDataSource1";
            // 
            // pageFooterSection1
            // 
            this.pageFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(0.80000120401382446D);
            this.pageFooterSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox9});
            this.pageFooterSection1.Name = "pageFooterSection1";
            this.pageFooterSection1.PrintOnFirstPage = true;
            this.pageFooterSection1.Style.Visible = true;
            // 
            // textBox9
            // 
            this.textBox9.KeepTogether = false;
            this.textBox9.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.20000070333480835D), Telerik.Reporting.Drawing.Unit.Cm(0.10000196844339371D));
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(25.519899368286133D), Telerik.Reporting.Drawing.Unit.Cm(0.600002110004425D));
            this.textBox9.Style.Font.Bold = false;
            this.textBox9.Style.Font.Name = "微軟正黑體";
            this.textBox9.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(11D);
            this.textBox9.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox9.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox9.Value = "= Fields.HOSPNAME+\",\"+ Fields.STUDENTNAME+\",\"+\"第\"+PageNumber+\"頁,共\"+ PageCount+\"頁\"" +
    "";
            // 
            // textBox2
            // 
            this.textBox2.KeepTogether = false;
            this.textBox2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(5.0999999046325684D));
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(25.999900817871094D), Telerik.Reporting.Drawing.Unit.Cm(1.399999737739563D));
            this.textBox2.Style.Font.Bold = true;
            this.textBox2.Style.Font.Name = "微軟正黑體";
            this.textBox2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(18D);
            this.textBox2.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox2.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox2.Value = "= Fields.PASSPORTNAME";
            // 
            // reportHeaderSection1
            // 
            this.reportHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(13.100000381469727D);
            this.reportHeaderSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox2,
            this.textBox1,
            this.textBox10,
            this.textBox11,
            this.textBox6,
            this.textBox7});
            this.reportHeaderSection1.KeepTogether = false;
            this.reportHeaderSection1.Name = "reportHeaderSection1";
            this.reportHeaderSection1.PageBreak = Telerik.Reporting.PageBreak.None;
            this.reportHeaderSection1.Style.BackgroundColor = System.Drawing.Color.Transparent;
            this.reportHeaderSection1.Style.BackgroundImage.MimeType = "";
            this.reportHeaderSection1.Style.BackgroundImage.Repeat = ((Telerik.Reporting.Drawing.BackgroundRepeat)((Telerik.Reporting.Drawing.BackgroundRepeat.RepeatX | Telerik.Reporting.Drawing.BackgroundRepeat.RepeatY)));
            this.reportHeaderSection1.Style.Visible = true;
            // 
            // textBox10
            // 
            this.textBox10.KeepTogether = false;
            this.textBox10.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.00010012308484874666D), Telerik.Reporting.Drawing.Unit.Cm(7.2999997138977051D));
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(25.99980354309082D), Telerik.Reporting.Drawing.Unit.Cm(0.7998998761177063D));
            this.textBox10.Style.Font.Name = "微軟正黑體";
            this.textBox10.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(15D);
            this.textBox10.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox10.Value = "= \"學生姓名：\"+Fields.STUDENTNAME";
            // 
            // textBox11
            // 
            this.textBox11.KeepTogether = false;
            this.textBox11.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.00030682882061228156D), Telerik.Reporting.Drawing.Unit.Cm(10.5D));
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(25.999597549438477D), Telerik.Reporting.Drawing.Unit.Cm(0.7998998761177063D));
            this.textBox11.Style.Font.Name = "微軟正黑體";
            this.textBox11.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(15D);
            this.textBox11.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox11.Value = "臨床教育訓練部    編印";
            // 
            // textBox6
            // 
            this.textBox6.KeepTogether = false;
            this.textBox6.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.00030682882061228156D), Telerik.Reporting.Drawing.Unit.Cm(2.2999997138977051D));
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(25.999597549438477D), Telerik.Reporting.Drawing.Unit.Cm(0.99999988079071045D));
            this.textBox6.Style.Font.Bold = true;
            this.textBox6.Style.Font.Name = "微軟正黑體";
            this.textBox6.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(20D);
            this.textBox6.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox6.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox6.Value = "暨高雄市立小港醫院、大同醫院";
            // 
            // textBox7
            // 
            this.textBox7.KeepTogether = false;
            this.textBox7.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.00030682882061228156D), Telerik.Reporting.Drawing.Unit.Cm(11.700000762939453D));
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(25.999597549438477D), Telerik.Reporting.Drawing.Unit.Cm(0.7998998761177063D));
            this.textBox7.Style.Font.Name = "微軟正黑體";
            this.textBox7.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(15D);
            this.textBox7.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox7.Value = "財團法人醫院評鑑暨醫療品質策進會  指導";
            // 
            // pageHeaderSection1
            // 
            this.pageHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(1.2999999523162842D);
            this.pageHeaderSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox4,
            this.pictureBox1,
            this.textBox5});
            this.pageHeaderSection1.Name = "pageHeaderSection1";
            this.pageHeaderSection1.PrintOnFirstPage = false;
            this.pageHeaderSection1.Style.Visible = true;
            // 
            // textBox4
            // 
            this.textBox4.KeepTogether = false;
            this.textBox4.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(1.685208797454834D), Telerik.Reporting.Drawing.Unit.Cm(0.099999949336051941D));
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(16.614791870117188D), Telerik.Reporting.Drawing.Unit.Cm(0.7998998761177063D));
            this.textBox4.Style.Font.Bold = false;
            this.textBox4.Style.Font.Name = "微軟正黑體";
            this.textBox4.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(14D);
            this.textBox4.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox4.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox4.Value = "= Fields.HOSPNAME";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.19999989867210388D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.pictureBox1.MimeType = "image/jpeg";
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.2000001668930054D), Telerik.Reporting.Drawing.Unit.Cm(1.1662958860397339D));
            this.pictureBox1.Value = ((object)(resources.GetObject("pictureBox1.Value")));
            // 
            // textBox5
            // 
            this.textBox5.KeepTogether = false;
            this.textBox5.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(19.600000381469727D), Telerik.Reporting.Drawing.Unit.Cm(0.11675199866294861D));
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(6.1198992729187012D), Telerik.Reporting.Drawing.Unit.Cm(0.800000011920929D));
            this.textBox5.Style.Font.Name = "微軟正黑體";
            this.textBox5.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(14D);
            this.textBox5.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox5.Value = "= Fields.STUDENTNAME";
            // 
            // EduPassportReport
            // 
            this.DataSource = this.objectDataSource1;
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.detail,
            this.pageFooterSection1,
            this.reportHeaderSection1,
            this.pageHeaderSection1});
            this.Name = "EduPassportReport";
            this.PageSettings.Landscape = true;
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Mm(5D), Telerik.Reporting.Drawing.Unit.Mm(5D), Telerik.Reporting.Drawing.Unit.Mm(5D), Telerik.Reporting.Drawing.Unit.Mm(5D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            pictureWatermark1.Image = ((object)(resources.GetObject("pictureWatermark1.Image")));
            pictureWatermark1.Sizing = Telerik.Reporting.Drawing.WatermarkSizeMode.Stretch;
            this.PageSettings.Watermarks.Add(pictureWatermark1);
            this.Style.BackgroundColor = System.Drawing.Color.Transparent;
            this.Style.BackgroundImage.MimeType = "";
            this.Style.BackgroundImage.Repeat = Telerik.Reporting.Drawing.BackgroundRepeat.NoRepeat;
            styleRule1.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.TextItemBase)),
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.HtmlTextBox))});
            styleRule1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(2D);
            styleRule1.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(2D);
            styleRule2.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector(typeof(Telerik.Reporting.Table), "Office.TableNormal")});
            styleRule2.Style.BorderColor.Default = System.Drawing.Color.Black;
            styleRule2.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            styleRule2.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            styleRule2.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(34)))), ((int)(((byte)(77)))));
            styleRule2.Style.Font.Name = "Calibri";
            styleRule2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            descendantSelector1.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.Table)),
            new Telerik.Reporting.Drawing.StyleSelector(typeof(Telerik.Reporting.ReportItem), "Office.TableGroup")});
            styleRule3.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            descendantSelector1});
            styleRule3.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(244)))), ((int)(((byte)(251)))));
            styleRule3.Style.BorderColor.Default = System.Drawing.Color.Black;
            styleRule3.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            styleRule3.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            styleRule3.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(34)))), ((int)(((byte)(77)))));
            styleRule3.Style.Font.Name = "Calibri";
            styleRule3.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            descendantSelector2.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.Table)),
            new Telerik.Reporting.Drawing.StyleSelector(typeof(Telerik.Reporting.ReportItem), "Office.TableHeader")});
            styleRule4.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            descendantSelector2});
            styleRule4.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(167)))), ((int)(((byte)(227)))));
            styleRule4.Style.BorderColor.Default = System.Drawing.Color.Black;
            styleRule4.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            styleRule4.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            styleRule4.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(34)))), ((int)(((byte)(77)))));
            styleRule4.Style.Font.Name = "Calibri";
            styleRule4.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            styleRule4.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            descendantSelector3.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.Table)),
            new Telerik.Reporting.Drawing.StyleSelector(typeof(Telerik.Reporting.ReportItem), "Office.TableBody")});
            styleRule5.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            descendantSelector3});
            styleRule5.Style.BorderColor.Default = System.Drawing.Color.Black;
            styleRule5.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            styleRule5.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            styleRule5.Style.Font.Name = "Calibri";
            styleRule5.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.StyleSheet.AddRange(new Telerik.Reporting.Drawing.StyleRule[] {
            styleRule1,
            styleRule2,
            styleRule3,
            styleRule4,
            styleRule5});
            this.Width = Telerik.Reporting.Drawing.Unit.Cm(26D);
            ((System.ComponentModel.ISupportInitialize)(this.eduPassportReport_sub11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.TextBox textBox1;
        private Telerik.Reporting.ObjectDataSource objectDataSource1;
        private Telerik.Reporting.PageFooterSection pageFooterSection1;
        private Telerik.Reporting.TextBox textBox2;
        private Telerik.Reporting.ReportHeaderSection reportHeaderSection1;
        private Telerik.Reporting.TextBox textBox10;
        private Telerik.Reporting.TextBox textBox11;
        private Telerik.Reporting.PageHeaderSection pageHeaderSection1;
        private Telerik.Reporting.TextBox textBox4;
        private Telerik.Reporting.PictureBox pictureBox1;
        private Telerik.Reporting.TextBox textBox5;
        private Telerik.Reporting.TextBox textBox6;
        private Telerik.Reporting.TextBox textBox7;
        private Telerik.Reporting.TextBox textBox9;
        private Telerik.Reporting.SubReport subReport1;
        private EduPassportReport_sub1 eduPassportReport_sub11;
    }
}