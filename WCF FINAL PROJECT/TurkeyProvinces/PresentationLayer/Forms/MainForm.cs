using PresentationLayer.Forms;
using PresentationLayer.Forms.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnRegistry_Click(object sender, EventArgs e)
        {
            RegistirationForm kayit = new RegistirationForm();
            kayit.TopLevel = false;
            panelMain.Controls.Add(kayit);
            kayit.Show();
            kayit.Dock = DockStyle.Fill;
            kayit.BringToFront();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            ReportMainForm rapor = new ReportMainForm();
            rapor.TopLevel = false;
            panelMain.Controls.Add(rapor);
            rapor.Show();
            rapor.Dock = DockStyle.Fill;
            rapor.BringToFront();
        }

        private void btnUserAutohorization_Click(object sender, EventArgs e)
        {
            UserAuthorization rapor = new UserAuthorization();
            rapor.TopLevel = false;
            panelMain.Controls.Add(rapor);
            rapor.Show();
            rapor.Dock = DockStyle.Fill;
            rapor.BringToFront();
        }
    }
}
