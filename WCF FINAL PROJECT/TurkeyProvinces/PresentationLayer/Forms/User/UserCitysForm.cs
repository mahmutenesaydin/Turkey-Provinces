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
    public partial class UserCitysForm : Form
    {
        public UserCitysForm()
        {
            InitializeComponent();
        }
        TPServiceReference.ServiceContractClient client = new TPServiceReference.ServiceContractClient();
        TurkeyProvincesEntitie3 db = new TurkeyProvincesEntitie3();

        CityBase _cityBase = new CityBase
        {
            DataObject = new CityDatabaseObject()
        };

        private void List()
        {
            dgvProvince.DataSource = client.ListCity();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            List();
        }

        private void dgvProvince_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCityID.Text = dgvProvince.CurrentRow.Cells["CityID"].Value.ToString();
            txtCityName.Text = dgvProvince.CurrentRow.Cells["CityName"].Value.ToString();
            txtPlateCode.Text = dgvProvince.CurrentRow.Cells["PlateCode"].Value.ToString();
            txtPopulation.Text = dgvProvince.CurrentRow.Cells["Population"].Value.ToString();
            pictureEdit1.Text = dgvProvince.CurrentRow.Cells["Picture"].Value.ToString();
            cmbRegion.Text = dgvProvince.CurrentRow.Cells["RegionID"].Value.ToString();
            cmbVisit.Text = dgvProvince.CurrentRow.Cells["PlaceToVisitID"].Value.ToString();
            cmbFamous.Text = dgvProvince.CurrentRow.Cells["WhatFamousID"].Value.ToString();
            cmbTransportationService.Text = dgvProvince.CurrentRow.Cells["TransportationServiceID"].Value.ToString();
            cmbPartyID.Text = dgvProvince.CurrentRow.Cells["PartyID"].Value.ToString();
        }

        private void btnPrior_Click(object sender, EventArgs e)
        {
            City c = _cityBase.Prior;

            txtCityID.Text = c.CityID.ToString();
            txtCityName.Text = c.CityName;
            txtPlateCode.Text = c.PlateCode.ToString();
            txtPopulation.Text = c.Population;
            pictureEdit1.Text = c.Picture.ToString();
            cmbRegion.Text = c.RegionID.ToString();
            cmbFamous.Text = c.WhatFamousID.ToString();
            cmbVisit.Text = c.PlaceToVisitID.ToString();
            cmbTransportationService.Text = c.TransportationServiceID.ToString();
            cmbPartyID.Text = c.PartyID.ToString();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            City c = _cityBase.Next;

            txtCityID.Text = c.CityID.ToString();
            txtCityName.Text = c.CityName;
            txtPlateCode.Text = c.PlateCode.ToString();
            txtPopulation.Text = c.Population;
            pictureEdit1.Text = c.Picture.ToString();
            cmbRegion.Text = c.RegionID.ToString();
            cmbFamous.Text = c.WhatFamousID.ToString();
            cmbVisit.Text = c.PlaceToVisitID.ToString();
            cmbTransportationService.Text = c.TransportationServiceID.ToString();
            cmbPartyID.Text = c.PartyID.ToString();
        }

        private void txtSearch_OnValueChanged(object sender, EventArgs e)
        {
            string ara = txtSearch.Text;
            dgvProvince.DataSource = db.Cities.Where(c => c.CityName.Contains(ara)).ToList();
        }
    }
}
