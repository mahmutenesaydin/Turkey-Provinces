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
    public partial class UserTownForm : Form
    {
        public UserTownForm()
        {
            InitializeComponent();
        }

        TPServiceReference.ServiceContractClient client = new TPServiceReference.ServiceContractClient();
        TurkeyProvincesEntitie3 db = new TurkeyProvincesEntitie3();

        TownBase _townBase = new TownBase()
        {
            DataObject = new TownDatabaseObject()
        };

        private void List()
        {
            dgvTown.DataSource = client.ListTown();
        }

        private void btnList_Click_1(object sender, EventArgs e)
        {
            List();
        }

        private void dgvTown_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtTownID.Text = dgvTown.CurrentRow.Cells["TownID"].Value.ToString();
            txtTownName.Text = dgvTown.CurrentRow.Cells["TownName"].Value.ToString();
            txtPopulation.Text = dgvTown.CurrentRow.Cells["Population"].Value.ToString();
            pictureEdit1.Text = dgvTown.CurrentRow.Cells["Picture"].Value.ToString();
            cmbCity.Text = dgvTown.CurrentRow.Cells["CityID"].Value.ToString();
            cmbVisit.Text = dgvTown.CurrentRow.Cells["PlaceToVisitID"].Value.ToString();
            cmbFamous.Text = dgvTown.CurrentRow.Cells["WhatFamousID"].Value.ToString();
            cmbTransportationService.Text = dgvTown.CurrentRow.Cells["TransportationServiceID"].Value.ToString();
            cmbPartyID.Text = dgvTown.CurrentRow.Cells["PartyID"].Value.ToString();
        }

        private void btnPrior_Click(object sender, EventArgs e)
        {
            Town t = _townBase.Prior;

            txtTownID.Text = t.TownID.ToString();
            txtTownName.Text = t.TownName;
            txtPopulation.Text = t.Population;
            pictureEdit1.Text = t.Picture.ToString();
            cmbCity.Text = t.CityID.ToString();
            cmbFamous.Text = t.WhatFamousID.ToString();
            cmbVisit.Text = t.PlaceToVisitID.ToString();
            cmbTransportationService.Text = t.TransportationServiceID.ToString();
            cmbPartyID.Text = t.PartyID.ToString();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            Town t = _townBase.Next;

            txtTownID.Text = t.TownID.ToString();
            txtTownName.Text = t.TownName;
            txtPopulation.Text = t.Population;
            pictureEdit1.Text = t.Picture.ToString();
            cmbCity.Text = t.CityID.ToString();
            cmbFamous.Text = t.WhatFamousID.ToString();
            cmbVisit.Text = t.PlaceToVisitID.ToString();
            cmbTransportationService.Text = t.TransportationServiceID.ToString();
            cmbPartyID.Text = t.PartyID.ToString();
        }

        private void txtSearch_OnValueChanged(object sender, EventArgs e)
        {
            string ara = txtSearch.Text;
            dgvTown.DataSource = db.Towns.Where(t => t.TownName.Contains(ara)).ToList();
        }
    }
}
