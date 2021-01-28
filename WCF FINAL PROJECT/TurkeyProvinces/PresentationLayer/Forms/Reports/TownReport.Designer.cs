namespace PresentationLayer.Forms.Reports
{
    partial class TownReport
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
            this.reportTown = new Microsoft.Reporting.WinForms.ReportViewer();
            this.turkeyProvincesDataSet1 = new PresentationLayer.TurkeyProvincesDataSet1();
            this.turkeyProvincesDataSet1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.townBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.townTableAdapter = new PresentationLayer.TurkeyProvincesDataSet1TableAdapters.TownTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.turkeyProvincesDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.turkeyProvincesDataSet1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.townBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportTown
            // 
            this.reportTown.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.townBindingSource;
            this.reportTown.LocalReport.DataSources.Add(reportDataSource1);
            this.reportTown.LocalReport.ReportEmbeddedResource = "PresentationLayer.Forms.Reports.Report2.rdlc";
            this.reportTown.Location = new System.Drawing.Point(0, 0);
            this.reportTown.Name = "reportTown";
            this.reportTown.Size = new System.Drawing.Size(879, 560);
            this.reportTown.TabIndex = 0;
            // 
            // turkeyProvincesDataSet1
            // 
            this.turkeyProvincesDataSet1.DataSetName = "TurkeyProvincesDataSet1";
            this.turkeyProvincesDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // turkeyProvincesDataSet1BindingSource
            // 
            this.turkeyProvincesDataSet1BindingSource.DataSource = this.turkeyProvincesDataSet1;
            this.turkeyProvincesDataSet1BindingSource.Position = 0;
            // 
            // townBindingSource
            // 
            this.townBindingSource.DataMember = "Town";
            this.townBindingSource.DataSource = this.turkeyProvincesDataSet1BindingSource;
            // 
            // townTableAdapter
            // 
            this.townTableAdapter.ClearBeforeFill = true;
            // 
            // TownReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 560);
            this.Controls.Add(this.reportTown);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TownReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TownReport";
            this.Load += new System.EventHandler(this.TownReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.turkeyProvincesDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.turkeyProvincesDataSet1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.townBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportTown;
        private System.Windows.Forms.BindingSource turkeyProvincesDataSet1BindingSource;
        private TurkeyProvincesDataSet1 turkeyProvincesDataSet1;
        private System.Windows.Forms.BindingSource townBindingSource;
        private TurkeyProvincesDataSet1TableAdapters.TownTableAdapter townTableAdapter;
    }
}