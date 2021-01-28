namespace PresentationLayer.Forms.Reports
{
    partial class CityReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportCity = new Microsoft.Reporting.WinForms.ReportViewer();
            this.turkeyProvincesDataSet = new PresentationLayer.TurkeyProvincesDataSet();
            this.turkeyProvincesDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.CityBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cityBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.cityTableAdapter = new PresentationLayer.TurkeyProvincesDataSetTableAdapters.CityTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.turkeyProvincesDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.turkeyProvincesDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CityBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cityBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // reportCity
            // 
            this.reportCity.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.cityBindingSource1;
            this.reportCity.LocalReport.DataSources.Add(reportDataSource1);
            this.reportCity.LocalReport.ReportEmbeddedResource = "PresentationLayer.Forms.Reports.Report1.rdlc";
            this.reportCity.Location = new System.Drawing.Point(0, 0);
            this.reportCity.Name = "reportCity";
            this.reportCity.Size = new System.Drawing.Size(879, 560);
            this.reportCity.TabIndex = 0;
            this.reportCity.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // turkeyProvincesDataSet
            // 
            this.turkeyProvincesDataSet.DataSetName = "TurkeyProvincesDataSet";
            this.turkeyProvincesDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // turkeyProvincesDataSetBindingSource
            // 
            this.turkeyProvincesDataSetBindingSource.DataSource = this.turkeyProvincesDataSet;
            this.turkeyProvincesDataSetBindingSource.Position = 0;
            // 
            // CityBindingSource
            // 
            this.CityBindingSource.DataMember = "City";
            this.CityBindingSource.DataSource = this.turkeyProvincesDataSet;
            // 
            // cityBindingSource1
            // 
            this.cityBindingSource1.DataMember = "City";
            this.cityBindingSource1.DataSource = this.turkeyProvincesDataSetBindingSource;
            // 
            // cityTableAdapter
            // 
            this.cityTableAdapter.ClearBeforeFill = true;
            // 
            // CityReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 560);
            this.Controls.Add(this.reportCity);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CityReport";
            this.Text = "CityReport";
            this.Load += new System.EventHandler(this.CityReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.turkeyProvincesDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.turkeyProvincesDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CityBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cityBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportCity;
        private System.Windows.Forms.BindingSource turkeyProvincesDataSetBindingSource;
        private TurkeyProvincesDataSet turkeyProvincesDataSet;
        private System.Windows.Forms.BindingSource CityBindingSource;
        private System.Windows.Forms.BindingSource cityBindingSource1;
        private TurkeyProvincesDataSetTableAdapters.CityTableAdapter cityTableAdapter;
    }
}