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

namespace PresentationLayer.Forms.User
{
    public partial class UserMainForm : Form
    {
        public UserMainForm()
        {
            InitializeComponent();
        }

        private void btnRegistry_Click(object sender, EventArgs e)
        {
            UserRegistirationForm kayit = new UserRegistirationForm();
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

        private void btnAdminEntry_Click(object sender, EventArgs e)
        {
            LoginAdmin loginAdmin = new LoginAdmin();
          //  loginAdmin.TopLevel = false;
            loginAdmin.Show();
            this.Hide();
        }
    }
}
