using BusinessLayer;
using BusinessLayer.UnitOfWork;
using DataLayer;
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
    public partial class VillageForm : Form
    {
        public VillageForm()
        {
            InitializeComponent();
        }

        #region PanelDüzenlemeleri
        private void btnAdd_Click(object sender, EventArgs e)
        {
            panel8.BackColor = Color.IndianRed;
            panel2.BackColor = Color.White;
            panel3.BackColor = Color.White;
            panelAdd.Visible = true;
            panelUpdate.Visible = false;
            panelDelete.Visible = false;
        }

        private void btnUpdatee_Click(object sender, EventArgs e)
        {
            panel8.BackColor = Color.White;
            panel2.BackColor = Color.IndianRed;
            panel3.BackColor = Color.White;
            panelAdd.Visible = false;
            panelUpdate.Visible = true;
            panelDelete.Visible = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            panel8.BackColor = Color.White;
            panel2.BackColor = Color.White;
            panel3.BackColor = Color.IndianRed;
            panelAdd.Visible = false;
            panelUpdate.Visible = false;
            panelDelete.Visible = true;
        }
        #endregion

        PlaceToVisitBusiness visitBus = new PlaceToVisitBusiness();
        WhatFamousBusiness famousBus = new WhatFamousBusiness();
        TownBusiness townBus = new TownBusiness();
        TurkeyProvinceService4.ServiceContractClient client = new TurkeyProvinceService4.ServiceContractClient();
        private void VillageForm_Load(object sender, EventArgs e)
        {
            cmbTownAdd.SetDataSource<Town>(townBus.ListForComboBox(), "TownName", "TownID");
            cmbTownUpdate.SetDataSource<Town>(townBus.ListForComboBox(), "TownName", "TownID");
            cmbTownDelete.SetDataSource<Town>(townBus.ListForComboBox(), "TownName", "TownID");
            cmbFamousAdd.SetDataSource<WhatFamou>(famousBus.ListForComboBox(), "WhatFamous", "WhatFamousID");
            cmbVisitAdd.SetDataSource<PlacesToVisit>(visitBus.ListForComboBox(), "PlaceToVisit", "PlaceToVisitID");
        }

        private void List()
        {
            dgvVillage.DataSource = client.ListVillage();
        }

        private void btnRegionAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtVillageNameAdd.Text) || string.IsNullOrEmpty(txtPopulationAdd.Text) || string.IsNullOrEmpty(cmbTownAdd.Text) || string.IsNullOrEmpty(cmbVisitAdd.Text) || string.IsNullOrEmpty(cmbFamousAdd.Text))
            {
                MessageBox.Show("Lütfen formu doldurun!", "GÜNCELLEME", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                client.AddVillage(new TurkeyProvinceService4.Village
                {
                    VillageName = txtVillageNameAdd.Text,
                    Population = txtPopulationAdd.Text,
                    TownID = Convert.ToInt16(cmbTownAdd.SelectedValue),
                    PlaceToVisitID = Convert.ToInt16(cmbVisitAdd.SelectedValue),
                    WhatFamousID = Convert.ToInt16(cmbFamousAdd.SelectedValue)
                });
                List();
                MessageBox.Show("Kayıt Başarılı!", "KAYIT OLUNDU!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtVillageNameAdd.Text) || string.IsNullOrEmpty(txtPopulationAdd.Text) || string.IsNullOrEmpty(cmbTownAdd.Text) || string.IsNullOrEmpty(cmbVisitAdd.Text) || string.IsNullOrEmpty(cmbFamousAdd.Text))
            {
                MessageBox.Show("Lütfen formu doldurun!", "GÜNCELLEME", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                client.UpdateVillage(new TurkeyProvinceService4.Village
                {
                    VillageID = Convert.ToInt16(txtVillageIdUpdate.Text),
                    VillageName = txtVillageNameUpdat.Text,
                    Population = txtPopulationUpdate.Text,
                    TownID = Convert.ToInt16(cmbTownUpdate.SelectedValue),
                    PlaceToVisitID = Convert.ToInt16(cmbVisitUpdate.SelectedValue),
                    WhatFamousID = Convert.ToInt16(cmbFamousUpdate.SelectedValue)
                });
                List();
                MessageBox.Show("Güncelleme Başarılı!", "KAYIT OLUNDU!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnVillageDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtVillageNameAdd.Text) || string.IsNullOrEmpty(txtPopulationAdd.Text) || string.IsNullOrEmpty(cmbTownAdd.Text) || string.IsNullOrEmpty(cmbVisitAdd.Text) || string.IsNullOrEmpty(cmbFamousAdd.Text))
            {
                MessageBox.Show("Lütfen formu doldurun!", "GÜNCELLEME", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                client.DeleteVillage(Convert.ToInt16(txtVillageIdDelete.Text));
                List();
                MessageBox.Show("Silme Başarılı!", "KAYIT OLUNDU!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1); 
            }
        }

        private void dgvVillage_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtVillageIdAdd.Text = dgvVillage.CurrentRow.Cells["VillageID"].Value.ToString();
            txtVillageNameAdd.Text = dgvVillage.CurrentRow.Cells["VillageName"].Value.ToString();
            txtPopulationAdd.Text = dgvVillage.CurrentRow.Cells["Population"].Value.ToString();
            cmbTownAdd.Text = dgvVillage.CurrentRow.Cells["TownID"].Value.ToString();
            cmbVisitAdd.Text = dgvVillage.CurrentRow.Cells["PlaceToVisitID"].Value.ToString();
            cmbFamousAdd.Text = dgvVillage.CurrentRow.Cells["WhatFamousID"].Value.ToString();
        }

        private void dgvVillageUpdate_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtVillageIdUpdate.Text = dgvVillage.CurrentRow.Cells["VillageID"].Value.ToString();
            txtVillageNameUpdat.Text = dgvVillage.CurrentRow.Cells["VillageName"].Value.ToString();
            txtPopulationUpdate.Text = dgvVillage.CurrentRow.Cells["Population"].Value.ToString();
            cmbTownUpdate.Text = dgvVillage.CurrentRow.Cells["TownID"].Value.ToString();
            cmbVisitUpdate.Text = dgvVillage.CurrentRow.Cells["PlaceToVisitID"].Value.ToString();
            cmbFamousUpdate.Text = dgvVillage.CurrentRow.Cells["WhatFamousID"].Value.ToString();
        }

        private void dgvVillageDelete_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtVillageIdDelete.Text = dgvVillage.CurrentRow.Cells["VillageID"].Value.ToString();
            txtVillageNameDelete.Text = dgvVillage.CurrentRow.Cells["VillageName"].Value.ToString();
            txtPopulationDelete.Text = dgvVillage.CurrentRow.Cells["Population"].Value.ToString();
            cmbTownDelete.Text = dgvVillage.CurrentRow.Cells["TownID"].Value.ToString();
            cmbVisitDelete.Text = dgvVillage.CurrentRow.Cells["PlaceToVisitID"].Value.ToString();
            cmbFamousDelete.Text = dgvVillage.CurrentRow.Cells["WhatFamousID"].Value.ToString();
        }
    }
}
