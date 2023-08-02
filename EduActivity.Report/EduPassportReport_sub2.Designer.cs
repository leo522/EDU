namespace EduActivity.Report
{
    partial class EduPassportReport_sub2
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
            Telerik.Reporting.ReportParameter reportParameter1 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule2 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule3 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.DescendantSelector descendantSelector1 = new Telerik.Reporting.Drawing.DescendantSelector();
            Telerik.Reporting.Drawing.StyleRule styleRule4 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.DescendantSelector descendantSelector2 = new Telerik.Reporting.Drawing.DescendantSelector();
            Telerik.Reporting.Drawing.StyleRule styleRule5 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.DescendantSelector descendantSelector3 = new Telerik.Reporting.Drawing.DescendantSelector();
            this.textBox4 = new Telerik.Reporting.TextBox();
            this.textBox5 = new Telerik.Reporting.TextBox();
            this.detail = new Telerik.Reporting.DetailSection();
            this.crosstab1 = new Telerik.Reporting.Crosstab();
            this.textBox7 = new Telerik.Reporting.TextBox();
            this.textBox6 = new Telerik.Reporting.TextBox();
            this.objectDataSource2 = new Telerik.Reporting.ObjectDataSource();
            this.textBox2 = new Telerik.Reporting.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // textBox4
            // 
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.335416316986084D), Telerik.Reporting.Drawing.Unit.Cm(0.84999996423721313D));
            this.textBox4.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12D);
            this.textBox4.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox4.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox4.StyleName = "Office.TableGroup";
            this.textBox4.Value = "= Fields.COLUMNTITLE";
            // 
            // textBox5
            // 
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.7166666984558105D), Telerik.Reporting.Drawing.Unit.Cm(0.84999996423721313D));
            this.textBox5.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12D);
            this.textBox5.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox5.StyleName = "Office.TableGroup";
            this.textBox5.Value = "= Fields.ITEMNAME";
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Cm(2.2000002861022949D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.crosstab1});
            this.detail.KeepTogether = false;
            this.detail.Name = "detail";
            // 
            // crosstab1
            // 
            this.crosstab1.Bindings.Add(new Telerik.Reporting.Binding("DataSource", "=ReportItem.Parent.DataObject.REPORTITEMS"));
            this.crosstab1.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(2.3354165554046631D)));
            this.crosstab1.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Cm(0.84999996423721313D)));
            this.crosstab1.Body.SetCellContent(0, 0, this.textBox7);
            tableGroup1.Groupings.Add(new Telerik.Reporting.Grouping("=Fields.COLUMNTITLE"));
            tableGroup1.Name = "COLUMNTITLE1";
            tableGroup1.ReportItem = this.textBox4;
            tableGroup1.Sortings.Add(new Telerik.Reporting.Sorting("=Fields.COLUMNTITLE", Telerik.Reporting.SortDirection.Asc));
            this.crosstab1.ColumnGroups.Add(tableGroup1);
            this.crosstab1.Corner.SetCellContent(0, 0, this.textBox6);
            this.crosstab1.DataSource = this.objectDataSource2;
            this.crosstab1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox7,
            this.textBox4,
            this.textBox6,
            this.textBox5});
            this.crosstab1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.00010012308484874666D), Telerik.Reporting.Drawing.Unit.Cm(0.00010012308484874666D));
            this.crosstab1.Name = "crosstab1";
            tableGroup2.Groupings.Add(new Telerik.Reporting.Grouping("=Fields.ITEMNAME"));
            tableGroup2.Name = "ITEMNAME1";
            tableGroup2.ReportItem = this.textBox5;
            tableGroup2.Sortings.Add(new Telerik.Reporting.Sorting("=Fields.ITEMNAME", Telerik.Reporting.SortDirection.Asc));
            this.crosstab1.RowGroups.Add(tableGroup2);
            this.crosstab1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(7.0520834922790527D), Telerik.Reporting.Drawing.Unit.Cm(1.6999999284744263D));
            this.crosstab1.StyleName = "Office.TableNormal";
            // 
            // textBox7
            // 
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.335416316986084D), Telerik.Reporting.Drawing.Unit.Cm(0.84999996423721313D));
            this.textBox7.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12D);
            this.textBox7.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox7.StyleName = "Office.TableBody";
            this.textBox7.Value = "= Fields.ITEMVALUE";
            // 
            // textBox6
            // 
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.7166666984558105D), Telerik.Reporting.Drawing.Unit.Cm(0.84999996423721313D));
            this.textBox6.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(244)))), ((int)(((byte)(251)))));
            this.textBox6.Style.Color = System.Drawing.Color.Black;
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
            // textBox2
            // 
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.5399999618530273D), Telerik.Reporting.Drawing.Unit.Cm(1.2699999809265137D));
            // 
            // EduPassportReport_sub2
            // 
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.detail});
            this.Name = "EduPassportReport_sub2";
            this.PageSettings.Landscape = true;
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Mm(25.399999618530273D), Telerik.Reporting.Drawing.Unit.Mm(25.399999618530273D), Telerik.Reporting.Drawing.Unit.Mm(25.399999618530273D), Telerik.Reporting.Drawing.Unit.Mm(25.399999618530273D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            reportParameter1.Name = "ITEMGROUPNAME";
            reportParameter1.Value = "";
            this.ReportParameters.Add(reportParameter1);
            this.Style.BackgroundColor = System.Drawing.Color.White;
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
            this.Width = Telerik.Reporting.Drawing.Unit.Cm(15D);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.TextBox textBox2;
        private Telerik.Reporting.Crosstab crosstab1;
        private Telerik.Reporting.TextBox textBox7;
        private Telerik.Reporting.TextBox textBox4;
        private Telerik.Reporting.TextBox textBox6;
        private Telerik.Reporting.ObjectDataSource objectDataSource2;
        private Telerik.Reporting.TextBox textBox5;
    }
}