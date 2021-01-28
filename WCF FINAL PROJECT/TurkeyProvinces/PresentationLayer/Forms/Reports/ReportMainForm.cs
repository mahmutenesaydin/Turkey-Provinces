using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Forms.Reports
{
    public partial class ReportMainForm : Form
    {
        public ReportMainForm()
        {
            InitializeComponent();
        }

        private void tileItem1_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            CityReport il = new CityReport();
            il.TopLevel = false;
            tileControl1.Controls.Add(il);
            il.Show();
            il.Dock = DockStyle.Fill;
            il.BringToFront();
        }

        private void tileItem2_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            TownReport ilce = new TownReport();
            ilce.TopLevel = false;
            tileControl1.Controls.Add(ilce);
            ilce.Show();
            ilce.Dock = DockStyle.Fill;
            ilce.BringToFront();
        }

        private void tileItem3_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            VillageReport koyForm = new VillageReport();
            koyForm.TopLevel = false;
            tileControl1.Controls.Add(koyForm);
            koyForm.Show();
            koyForm.Dock = DockStyle.Fill;
            koyForm.BringToFront();
        }

        private void tileItem4_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            PieCharts pieCht = new PieCharts();
            pieCht.TopLevel = false;
            tileControl1.Controls.Add(pieCht);
            pieCht.Show();
            pieCht.Dock = DockStyle.Fill;
            pieCht.BringToFront();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ReportMainForm kayit = new ReportMainForm();
            kayit.TopLevel = false;
            tileControl1.Controls.Add(kayit);
            kayit.Show();
            kayit.Dock = DockStyle.Fill;
            kayit.BringToFront();
            bunifuGradientPanel2.Visible = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Programdan çıkmayı gerçekten istiyor musunuz?", "UYARI!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialog == DialogResult.Yes)
            {
                Application.Exit();
            };
        }
    }
}
