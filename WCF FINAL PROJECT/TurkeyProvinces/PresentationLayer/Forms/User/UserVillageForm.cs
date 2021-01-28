using BusinessLayer.Bridge;
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

namespace PresentationLayer.Forms.User
{
    public partial class UserVillageForm : Form
    {
        public UserVillageForm()
        {
            InitializeComponent();
        }

        TPServiceReference.ServiceContractClient client = new TPServiceReference.ServiceContractClient();
        TurkeyProvincesEntitie3 db = new TurkeyProvincesEntitie3();

        VillageBase _villageBase = new VillageBase()
        {
            DataObject = new VillageDatabaseObject()
        };

        private void List()
        {
            dgvVillage.DataSource = client.ListVillage();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            List();
        }

        private void dgvVillage_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtVillageIdAdd.Text = dgvVillage.CurrentRow.Cells["VillageID"].Value.ToString();
            txtVillageNameAdd.Text = dgvVillage.CurrentRow.Cells["VillageName"].Value.ToString();
            txtVillageNameAdd.Text = dgvVillage.CurrentRow.Cells["VillageName"].Value.ToString();
            txtPopulationAdd.Text = dgvVillage.CurrentRow.Cells["Population"].Value.ToString();
            cmbTownAdd.Text = dgvVillage.CurrentRow.Cells["TownID"].Value.ToString();
            cmbVisitAdd.Text = dgvVillage.CurrentRow.Cells["PlaceToVisitID"].Value.ToString();
            cmbFamousAdd.Text = dgvVillage.CurrentRow.Cells["WhatFamousID"].Value.ToString();
        }

        private void btnPrior_Click(object sender, EventArgs e)
        {
            Village v = _villageBase.Prior;

            txtVillageIdAdd.Text = v.TownID.ToString();
            txtVillageNameAdd.Text = v.VillageName;
            txtPopulationAdd.Text = v.Population;
            cmbTownAdd.Text = v.TownID.ToString();
            cmbFamousAdd.Text = v.WhatFamousID.ToString();
            cmbVisitAdd.Text = v.PlaceToVisitID.ToString();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            Village v = _villageBase.Next;

            txtVillageIdAdd.Text = v.TownID.ToString();
            txtVillageNameAdd.Text = v.VillageName;
            txtPopulationAdd.Text = v.Population;
            cmbTownAdd.Text = v.TownID.ToString();
            cmbFamousAdd.Text = v.WhatFamousID.ToString();
            cmbVisitAdd.Text = v.PlaceToVisitID.ToString();
        }

        private void txtSearch_OnValueChanged(object sender, EventArgs e)
        {
            string ara = txtSearch.Text;
            dgvVillage.DataSource = db.Villages.Where(v => v.VillageName.Contains(ara)).ToList();
        }
    }
}
