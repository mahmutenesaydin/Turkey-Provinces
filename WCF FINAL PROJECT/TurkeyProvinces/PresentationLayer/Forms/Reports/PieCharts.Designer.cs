namespace PresentationLayer.Forms
{
    partial class PieCharts
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pieChtTownByCity = new LiveCharts.WinForms.PieChart();
            this.pieChtVillageByTown = new LiveCharts.WinForms.PieChart();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(879, 560);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pieChtTownByCity);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(871, 534);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "İle Göre İlçe Sayısı";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.pieChtVillageByTown);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(871, 534);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "İlçeye Göre Köy Sayısı";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // pieChtTownByCity
            // 
            this.pieChtTownByCity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pieChtTownByCity.Location = new System.Drawing.Point(3, 3);
            this.pieChtTownByCity.Name = "pieChtTownByCity";
            this.pieChtTownByCity.Size = new System.Drawing.Size(865, 528);
            this.pieChtTownByCity.TabIndex = 2;
            this.pieChtTownByCity.Text = "pieChart1";
            // 
            // pieChtVillageByTown
            // 
            this.pieChtVillageByTown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pieChtVillageByTown.Location = new System.Drawing.Point(3, 3);
            this.pieChtVillageByTown.Name = "pieChtVillageByTown";
            this.pieChtVillageByTown.Size = new System.Drawing.Size(865, 528);
            this.pieChtVillageByTown.TabIndex = 2;
            this.pieChtVillageByTown.Text = "pieChtVillageByTown";
            // 
            // PieCharts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 560);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PieCharts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PieCharts";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private LiveCharts.WinForms.PieChart pieChtTownByCity;
        private LiveCharts.WinForms.PieChart pieChtVillageByTown;
    }
}