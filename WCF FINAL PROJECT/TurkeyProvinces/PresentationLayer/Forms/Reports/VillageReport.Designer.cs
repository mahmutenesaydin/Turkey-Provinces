namespace PresentationLayer.Forms.Reports
{
    partial class VillageReport
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.turkeyProvincesDataSet2 = new PresentationLayer.TurkeyProvincesDataSet2();
            this.turkeyProvincesDataSet2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.villageBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.villageTableAdapter = new PresentationLayer.TurkeyProvincesDataSet2TableAdapters.VillageTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.turkeyProvincesDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.turkeyProvincesDataSet2BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.villageBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.villageBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "PresentationLayer.Forms.Reports.Report3.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(879, 560);
            this.reportViewer1.TabIndex = 0;
            // 
            // turkeyProvincesDataSet2
            // 
            this.turkeyProvincesDataSet2.DataSetName = "TurkeyProvincesDataSet2";
            this.turkeyProvincesDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // turkeyProvincesDataSet2BindingSource
            // 
            this.turkeyProvincesDataSet2BindingSource.DataSource = this.turkeyProvincesDataSet2;
            this.turkeyProvincesDataSet2BindingSource.Position = 0;
            // 
            // villageBindingSource
            // 
            this.villageBindingSource.DataMember = "Village";
            this.villageBindingSource.DataSource = this.turkeyProvincesDataSet2BindingSource;
            // 
            // villageTableAdapter
            // 
            this.villageTableAdapter.ClearBeforeFill = true;
            // 
            // VillageReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 560);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "VillageReport";
            this.Text = "VillageReport";
            this.Load += new System.EventHandler(this.VillageReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.turkeyProvincesDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.turkeyProvincesDataSet2BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.villageBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource turkeyProvincesDataSet2BindingSource;
        private TurkeyProvincesDataSet2 turkeyProvincesDataSet2;
        private System.Windows.Forms.BindingSource villageBindingSource;
        private TurkeyProvincesDataSet2TableAdapters.VillageTableAdapter villageTableAdapter;
    }
}