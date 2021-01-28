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
    public partial class RegistirationForm : Form
    {
        public RegistirationForm()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            RegistirationForm kayit = new RegistirationForm();
            kayit.TopLevel = false;
            panelMain.Controls.Add(kayit);
            kayit.Show();
            kayit.Dock = DockStyle.Fill;
            kayit.BringToFront();
            bunifuGradientPanel2.Visible = false;
        }

        private void tileItemVillage_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            VillageForm koyForm = new VillageForm();
            koyForm.TopLevel = false;
            panelMain.Controls.Add(koyForm);
            koyForm.Show();
            koyForm.Dock = DockStyle.Fill;
            koyForm.BringToFront();
        }
        private void tileItemRegion_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            RegionForm bolge = new RegionForm();
            bolge.TopLevel = false;
            panelMain.Controls.Add(bolge);
            bolge.Show();
            bolge.Dock = DockStyle.Fill;
            bolge.BringToFront();
        }

        private void tileItemParty_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            RulingPartyForm parti = new RulingPartyForm();
            parti.TopLevel = false;
            panelMain.Controls.Add(parti);
            parti.Show();
            parti.Dock = DockStyle.Fill;
            parti.BringToFront();
        }

        private void tileItemTransporatitonService_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            TransportationServiceForm servis = new TransportationServiceForm();
            servis.TopLevel = false;
            panelMain.Controls.Add(servis);
            servis.Show();
            servis.Dock = DockStyle.Fill;
            servis.BringToFront();  
        }

        private void tileItemVisit_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            PlacesToVisitForm ziyaret = new PlacesToVisitForm();
            ziyaret.TopLevel = false;
            panelMain.Controls.Add(ziyaret);
            ziyaret.Show();
            ziyaret.Dock = DockStyle.Fill;
            ziyaret.BringToFront();
        }

        private void tileItemWhatFamous_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            WhatFamousForm meshur = new WhatFamousForm();
            meshur.TopLevel = false;
            panelMain.Controls.Add(meshur);
            meshur.Show();
            meshur.Dock = DockStyle.Fill;
            meshur.BringToFront();
        }

        private void tileItemCity_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            ProvinceForm il = new ProvinceForm();
            il.TopLevel = false;
            panelMain.Controls.Add(il);
            il.Show();
            il.Dock = DockStyle.Fill;
            il.BringToFront();
        }

        private void tileItemTown_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            TownForm ilce = new TownForm();
            ilce.TopLevel = false;
            panelMain.Controls.Add(ilce);
            ilce.Show();
            ilce.Dock = DockStyle.Fill;
            ilce.BringToFront();
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
