namespace EduActivity.Report
{
    partial class FormStatisticReport
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
            this.detail = new Telerik.Reporting.DetailSection();
            this.objectDataSource1 = new Telerik.Reporting.ObjectDataSource();
            this.crosstab1 = new Telerik.Reporting.Crosstab();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.textBox2 = new Telerik.Reporting.TextBox();
            this.textBox5 = new Telerik.Reporting.TextBox();
            this.textBox3 = new Telerik.Reporting.TextBox();
            this.textBox4 = new Telerik.Reporting.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Cm(3D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.crosstab1});
            this.detail.Name = "detail";
            // 
            // objectDataSource1
            // 
            this.objectDataSource1.DataSource = typeof(KMU.EduActivity.ApplicationLayer.DTO.STATISTIC_EXPEND_DATA_LIST);
            this.objectDataSource1.Name = "objectDataSource1";
            // 
            // crosstab1
            // 
            this.crosstab1.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(2.5399999618530273D)));
            this.crosstab1.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Cm(1.2699999809265137D)));
            this.crosstab1.Body.SetCellContent(0, 0, this.textBox4);
            tableGroup1.Groupings.Add(new Telerik.Reporting.Grouping("=\'ColumnGroup\'"));
            tableGroup1.Name = "columnGroup";
            tableGroup1.ReportItem = this.textBox5;
            this.crosstab1.ColumnGroups.Add(tableGroup1);
            this.crosstab1.Corner.SetCellContent(0, 0, this.textBox1);
            this.crosstab1.DataSource = this.objectDataSource1;
            this.crosstab1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox1,
            this.textBox5,
            this.textBox3,
            this.textBox4});
            this.crosstab1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(9.9921220680698752E-05D), Telerik.Reporting.Drawing.Unit.Cm(9.9921220680698752E-05D));
            this.crosstab1.Name = "crosstab1";
            tableGroup2.Groupings.Add(new Telerik.Reporting.Grouping("=Fields.TargetName"));
            tableGroup2.Name = "targetName";
            tableGroup2.ReportItem = this.textBox3;
            tableGroup2.Sortings.Add(new Telerik.Reporting.Sorting("=Fields.TargetName", Telerik.Reporting.SortDirection.Asc));
            this.crosstab1.RowGroups.Add(tableGroup2);
            this.crosstab1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(5.0799999237060547D), Telerik.Reporting.Drawing.Unit.Cm(2.5399999618530273D));
            // 
            // textBox1
            // 
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.5399999618530273D), Telerik.Reporting.Drawing.Unit.Cm(1.2699999809265137D));
            // 
            // textBox2
            // 
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.5399999618530273D), Telerik.Reporting.Drawing.Unit.Cm(1.2699999809265137D));
            // 
            // textBox5
            // 
            this.textBox5.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(3.2999999523162842D), Telerik.Reporting.Drawing.Unit.Cm(0.60000008344650269D));
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.5399999618530273D), Telerik.Reporting.Drawing.Unit.Cm(1.2699999809265137D));
            this.textBox5.StyleName = "";
            this.textBox5.Value = "=Fields.GroupName";
            // 
            // textBox3
            // 
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.5399999618530273D), Telerik.Reporting.Drawing.Unit.Cm(1.2699999809265137D));
            this.textBox3.StyleName = "";
            this.textBox3.Value = "=Fields.TargetName";
            // 
            // textBox4
            // 
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.5399999618530273D), Telerik.Reporting.Drawing.Unit.Cm(1.2699999809265137D));
            this.textBox4.Value = "=Fields.Value";
            // 
            // FormStatisticReport
            // 
            this.DataSource = this.objectDataSource1;
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.detail});
            this.Name = "FormStatisticReport";
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Mm(25.399999618530273D), Telerik.Reporting.Drawing.Unit.Mm(25.399999618530273D), Telerik.Reporting.Drawing.Unit.Mm(25.399999618530273D), Telerik.Reporting.Drawing.Unit.Mm(25.399999618530273D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.Style.BackgroundColor = System.Drawing.Color.White;
            styleRule1.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.TextItemBase)),
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.HtmlTextBox))});
            styleRule1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(2D);
            styleRule1.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(2D);
            this.StyleSheet.AddRange(new Telerik.Reporting.Drawing.StyleRule[] {
            styleRule1});
            this.Width = Telerik.Reporting.Drawing.Unit.Cm(15D);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.Crosstab crosstab1;
        private Telerik.Reporting.TextBox textBox4;
        private Telerik.Reporting.TextBox textBox5;
        private Telerik.Reporting.TextBox textBox1;
        private Telerik.Reporting.ObjectDataSource objectDataSource1;
        private Telerik.Reporting.TextBox textBox3;
        private Telerik.Reporting.TextBox textBox2;
    }
}