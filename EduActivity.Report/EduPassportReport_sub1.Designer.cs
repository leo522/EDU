namespace EduActivity.Report
{
    partial class EduPassportReport_sub1
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.Reporting.TableGroup tableGroup1 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup2 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule2 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule3 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.DescendantSelector descendantSelector1 = new Telerik.Reporting.Drawing.DescendantSelector();
            Telerik.Reporting.Drawing.StyleRule styleRule4 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.DescendantSelector descendantSelector2 = new Telerik.Reporting.Drawing.DescendantSelector();
            Telerik.Reporting.Drawing.StyleRule styleRule5 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.DescendantSelector descendantSelector3 = new Telerik.Reporting.Drawing.DescendantSelector();
            Telerik.Reporting.Drawing.StyleRule styleRule6 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule7 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.DescendantSelector descendantSelector4 = new Telerik.Reporting.Drawing.DescendantSelector();
            Telerik.Reporting.Drawing.StyleRule styleRule8 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.DescendantSelector descendantSelector5 = new Telerik.Reporting.Drawing.DescendantSelector();
            Telerik.Reporting.Drawing.StyleRule styleRule9 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.DescendantSelector descendantSelector6 = new Telerik.Reporting.Drawing.DescendantSelector();
            this.textBox4 = new Telerik.Reporting.TextBox();
            this.textBox5 = new Telerik.Reporting.TextBox();
            this.detail = new Telerik.Reporting.DetailSection();
            this.textBox8 = new Telerik.Reporting.TextBox();
            this.crosstab1 = new Telerik.Reporting.Crosstab();
            this.textBox7 = new Telerik.Reporting.TextBox();
            this.textBox6 = new Telerik.Reporting.TextBox();
            this.objectDataSource2 = new Telerik.Reporting.ObjectDataSource();
            this.objectDataSource1 = new Telerik.Reporting.ObjectDataSource();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // textBox4
            // 
            this.textBox4.CanShrink = false;
            this.textBox4.KeepTogether = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.4677083492279053D), Telerik.Reporting.Drawing.Unit.Cm(0.84999996423721313D));
            this.textBox4.Style.BackgroundColor = System.Drawing.Color.LightGray;
            this.textBox4.Style.Font.Name = "微軟正黑體";
            this.textBox4.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12D);
            this.textBox4.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox4.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox4.StyleName = "Office.TableGroup";
            this.textBox4.Value = "= Fields.COLUMNTITLE";
            // 
            // textBox5
            // 
            this.textBox5.KeepTogether = false;
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.7587494850158691D), Telerik.Reporting.Drawing.Unit.Cm(0.84999996423721313D));
            this.textBox5.Style.Font.Name = "微軟正黑體";
            this.textBox5.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12D);
            this.textBox5.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox5.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox5.StyleName = "Office.TableGroup";
            this.textBox5.Value = "= Fields.ITEMNAME";
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Cm(2.6000001430511475D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox8,
            this.crosstab1});
            this.detail.KeepTogether = false;
            this.detail.Name = "detail";
            this.detail.PageBreak = Telerik.Reporting.PageBreak.After;
            this.detail.Style.BackgroundColor = System.Drawing.Color.Transparent;
            this.detail.Style.BackgroundImage.MimeType = "";
            this.detail.Style.BackgroundImage.Repeat = Telerik.Reporting.Drawing.BackgroundRepeat.RepeatY;
            // 
            // textBox8
            // 
            this.textBox8.KeepTogether = true;
            this.textBox8.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.00010012308484874666D), Telerik.Reporting.Drawing.Unit.Cm(9.9921220680698752E-05D));
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(20.299900054931641D), Telerik.Reporting.Drawing.Unit.Cm(0.79990029335021973D));
            this.textBox8.Style.BackgroundColor = System.Drawing.Color.Transparent;
            this.textBox8.Style.Font.Name = "微軟正黑體";
            this.textBox8.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(14D);
            this.textBox8.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox8.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox8.Value = "= Fields.ITEMGROUPNAME";
            // 
            // crosstab1
            // 
            this.crosstab1.Bindings.Add(new Telerik.Reporting.Binding("DataSource", "=ReportItem.DataObject.REPORTITEMS"));
            this.crosstab1.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(2.4677085876464844D)));
            this.crosstab1.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Cm(0.84999996423721313D)));
            this.crosstab1.Body.SetCellContent(0, 0, this.textBox7);
            tableGroup1.Groupings.Add(new Telerik.Reporting.Grouping("=Fields.COLUMNTITLE"));
            tableGroup1.Name = "COLUMNTITLE1";
            tableGroup1.ReportItem = this.textBox4;
            this.crosstab1.ColumnGroups.Add(tableGroup1);
            this.crosstab1.Corner.SetCellContent(0, 0, this.textBox6);
            this.crosstab1.DataSource = this.objectDataSource2;
            this.crosstab1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox7,
            this.textBox4,
            this.textBox6,
            this.textBox5});
            this.crosstab1.KeepTogether = true;
            this.crosstab1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.00010012308484874666D), Telerik.Reporting.Drawing.Unit.Cm(0.80020022392272949D));
            this.crosstab1.Name = "crosstab1";
            tableGroup2.Groupings.Add(new Telerik.Reporting.Grouping("=Fields.ITEMNAME"));
            tableGroup2.Name = "ITEMNAME1";
            tableGroup2.ReportItem = this.textBox5;
            this.crosstab1.RowGroups.Add(tableGroup2);
            this.crosstab1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(5.2264575958251953D), Telerik.Reporting.Drawing.Unit.Cm(1.6999999284744263D));
            this.crosstab1.Style.BackgroundColor = System.Drawing.Color.Transparent;
            this.crosstab1.StyleName = "Office.TableNormal";
            // 
            // textBox7
            // 
            this.textBox7.CanShrink = false;
            this.textBox7.KeepTogether = true;
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.4677083492279053D), Telerik.Reporting.Drawing.Unit.Cm(0.84999996423721313D));
            this.textBox7.Style.BackgroundColor = System.Drawing.Color.Transparent;
            this.textBox7.Style.Font.Name = "微軟正黑體";
            this.textBox7.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12D);
            this.textBox7.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox7.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox7.StyleName = "Office.TableBody";
            this.textBox7.TextWrap = true;
            this.textBox7.Value = "= Fields.ITEMVALUE";
            // 
            // textBox6
            // 
            this.textBox6.KeepTogether = true;
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.7587494850158691D), Telerik.Reporting.Drawing.Unit.Cm(0.84999996423721313D));
            this.textBox6.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(244)))), ((int)(((byte)(251)))));
            this.textBox6.Style.Color = System.Drawing.Color.Black;
            this.textBox6.Style.Font.Name = "微軟正黑體";
            this.textBox6.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12D);
            this.textBox6.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox6.StyleName = "Office.TableHeader";
            this.textBox6.Value = "項目";
            // 
            // objectDataSource2
            // 
            this.objectDataSource2.DataSource = "KMU.EduActivity.ApplicationLayer.DTO.EduPassportReportItem, EduActivity.Core, Ver" +
    "sion=1.0.0.0, Culture=neutral, PublicKeyToken=null";
            this.objectDataSource2.Name = "objectDataSource2";
            // 
            // objectDataSource1
            // 
            this.objectDataSource1.DataSource = "KMU.EduActivity.ApplicationLayer.DTO.EduPassportReportGroup, EduActivity.Core, Ve" +
    "rsion=1.0.0.0, Culture=neutral, PublicKeyToken=null";
            this.objectDataSource1.Name = "objectDataSource1";
            // 
            // EduPassportReport_sub1
            // 
            this.Bindings.Add(new Telerik.Reporting.Binding("DataSource", "=ReportItem.DataObject.REPORTGROUPS"));
            this.DataSource = this.objectDataSource1;
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.detail});
            this.Name = "EduPassportReport_sub1";
            this.PageSettings.Landscape = true;
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Mm(25.399999618530273D), Telerik.Reporting.Drawing.Unit.Mm(25.399999618530273D), Telerik.Reporting.Drawing.Unit.Mm(25.399999618530273D), Telerik.Reporting.Drawing.Unit.Mm(25.399999618530273D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.Style.BackgroundColor = System.Drawing.Color.White;
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
            styleRule6.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector(typeof(Telerik.Reporting.Table), "Normal.TableNormal")});
            styleRule6.Style.BorderColor.Default = System.Drawing.Color.Black;
            styleRule6.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            styleRule6.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            styleRule6.Style.Color = System.Drawing.Color.Black;
            styleRule6.Style.Font.Name = "Tahoma";
            styleRule6.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            descendantSelector4.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.Table)),
            new Telerik.Reporting.Drawing.StyleSelector(typeof(Telerik.Reporting.ReportItem), "Normal.TableGroup")});
            styleRule7.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            descendantSelector4});
            styleRule7.Style.BorderColor.Default = System.Drawing.Color.Black;
            styleRule7.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            styleRule7.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            styleRule7.Style.Font.Name = "Tahoma";
            styleRule7.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            descendantSelector5.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.Table)),
            new Telerik.Reporting.Drawing.StyleSelector(typeof(Telerik.Reporting.ReportItem), "Normal.TableHeader")});
            styleRule8.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            descendantSelector5});
            styleRule8.Style.BorderColor.Default = System.Drawing.Color.Black;
            styleRule8.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            styleRule8.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            styleRule8.Style.Font.Name = "Tahoma";
            styleRule8.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            styleRule8.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            descendantSelector6.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.Table)),
            new Telerik.Reporting.Drawing.StyleSelector(typeof(Telerik.Reporting.ReportItem), "Normal.TableBody")});
            styleRule9.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            descendantSelector6});
            styleRule9.Style.BorderColor.Default = System.Drawing.Color.Black;
            styleRule9.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            styleRule9.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            styleRule9.Style.Font.Name = "Tahoma";
            styleRule9.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.StyleSheet.AddRange(new Telerik.Reporting.Drawing.StyleRule[] {
            styleRule1,
            styleRule2,
            styleRule3,
            styleRule4,
            styleRule5,
            styleRule6,
            styleRule7,
            styleRule8,
            styleRule9});
            this.Width = Telerik.Reporting.Drawing.Unit.Cm(26D);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.TextBox textBox8;
        private Telerik.Reporting.ObjectDataSource objectDataSource1;
        private Telerik.Reporting.ObjectDataSource objectDataSource2;
        private Telerik.Reporting.Crosstab crosstab1;
        private Telerik.Reporting.TextBox textBox7;
        private Telerik.Reporting.TextBox textBox4;
        private Telerik.Reporting.TextBox textBox6;
        private Telerik.Reporting.TextBox textBox5;
    }
}