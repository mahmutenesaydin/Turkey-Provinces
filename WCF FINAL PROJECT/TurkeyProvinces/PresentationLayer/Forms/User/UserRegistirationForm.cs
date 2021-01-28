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
    public partial class UserRegistirationForm : Form
    {
        public UserRegistirationForm()
        {
            InitializeComponent();
        }

        private void tileItem1_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            UserCitysForm il = new UserCitysForm();
            il.TopLevel = false;
            bunifuGradientPanel1.Controls.Add(il);
            il.Show();
            il.Dock = DockStyle.Fill;
            il.BringToFront();
        }

        private void tileItem2_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            UserTownForm ilce = new UserTownForm();
            ilce.TopLevel = false;
            bunifuGradientPanel1.Controls.Add(ilce);
            ilce.Show();
            ilce.Dock = DockStyle.Fill;
            ilce.BringToFront();
        }

        private void tileItem3_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            UserVillageForm koyForm = new UserVillageForm();
            koyForm.TopLevel = false;
            bunifuGradientPanel1.Controls.Add(koyForm);
            koyForm.Show();
            koyForm.Dock = DockStyle.Fill;
            koyForm.BringToFront();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            UserRegistirationForm kayit = new UserRegistirationForm();
            kayit.TopLevel = false;
            bunifuGradientPanel1.Controls.Add(kayit);
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
