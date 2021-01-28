using BusinessLayer;
using BusinessLayer.Bridge;
using BusinessLayer.UnitOfWork;
using DataLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class TownForm : Form
    {
        public TownForm()
        {
            InitializeComponent();
        }
        CityBusiness cityBus = new CityBusiness();
        TownBusiness townBus = new TownBusiness();
        RulingPartyBusiness partyBus = new RulingPartyBusiness();
        PlaceToVisitBusiness visitBus = new PlaceToVisitBusiness();
        WhatFamousBusiness famousBus = new WhatFamousBusiness();
        TransportationServiceBusiness serviceBus = new TransportationServiceBusiness();
        TurkeyProvincesEntitie3 db = new TurkeyProvincesEntitie3();
        TurkeyProvinceService4.ServiceContractClient client = new TurkeyProvinceService4.ServiceContractClient();

        TownBase _townBase = new TownBase
        {
            DataObject = new TownDatabaseObject()
        };

        private void TownForm_Load(object sender, EventArgs e)
        {
            cmbCity.SetDataSource<City>(cityBus.ListForComboBox(), "CityName", "CityID");
            cmbFamous.SetDataSource<WhatFamou>(famousBus.ListForComboBox(), "WhatFamous", "WhatFamousID");
            cmbPartyID.SetDataSource<RulingParty>(partyBus.ListForComboBox(), "Party", "PartyID");
            cmbTransportationService.SetDataSource<TransportationService>(serviceBus.ListForComboBox(), "TransportationService", "TransportationServicesID");
            cmbVisit.SetDataSource<PlacesToVisit>(visitBus.ListForComboBox(), "PlaceToVisit", "PlaceToVisitID");
        }

        private void List()
        {
            dgvTown.DataSource = client.ListTown();
        }

        private byte[] ImageToByte(Image image)
        {
            using (var ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                return ms.ToArray();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTownName.Text) || string.IsNullOrEmpty(cmbCity.Text) || string.IsNullOrEmpty(txtPopulation.Text) || string.IsNullOrEmpty(pictureEdit1.Text) || string.IsNullOrEmpty(cmbPartyID.Text) || string.IsNullOrEmpty(cmbVisit.Text) || string.IsNullOrEmpty(cmbFamous.Text) || string.IsNullOrEmpty(cmbTransportationService.Text))
            {
                MessageBox.Show("Lütfen formu doldurun!", "GÜNCELLEME", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                client.AddTown(new TurkeyProvinceService4.Town
                {
                    TownName = txtTownName.Text,
                    Population = txtPopulation.Text,
                    Picture = ImageToByte(pictureEdit1.Image),
                    CityID = Convert.ToInt16(cmbCity.SelectedValue),
                    PartyID = Convert.ToInt16(cmbPartyID.SelectedValue),
                    PlaceToVisitID = Convert.ToInt16(cmbVisit.SelectedValue),
                    WhatFamousID = Convert.ToInt16(cmbFamous.SelectedValue),
                    TransportationServiceID = Convert.ToInt16(cmbTransportationService.SelectedValue)
                });
                List();
                MessageBox.Show("Kayıt Başarılı!", "KAYIT OLUNDU!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTownName.Text) || string.IsNullOrEmpty(cmbCity.Text) || string.IsNullOrEmpty(txtPopulation.Text) || string.IsNullOrEmpty(pictureEdit1.Text) || string.IsNullOrEmpty(cmbPartyID.Text) || string.IsNullOrEmpty(cmbVisit.Text) || string.IsNullOrEmpty(cmbFamous.Text) || string.IsNullOrEmpty(cmbTransportationService.Text))
            {
                MessageBox.Show("Lütfen formu doldurun!", "GÜNCELLEME", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                client.UpdateTown(new TurkeyProvinceService4.Town
                {
                    TownID = Convert.ToInt16(txtTownID),
                    TownName = txtTownName.Text,
                    Population = txtPopulation.Text,
                    Picture = ImageToByte(pictureEdit1.Image),
                    CityID = Convert.ToInt16(cmbCity.SelectedValue),
                    PartyID = Convert.ToInt16(cmbPartyID.SelectedValue),
                    PlaceToVisitID = Convert.ToInt16(cmbVisit.SelectedValue),
                    WhatFamousID = Convert.ToInt16(cmbFamous.SelectedValue),
                    TransportationServiceID = Convert.ToInt16(cmbTransportationService.SelectedValue)
                });
                List();
                MessageBox.Show("Güncelleme Başarılı!", "KAYIT OLUNDU!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTownName.Text) || string.IsNullOrEmpty(cmbCity.Text) || string.IsNullOrEmpty(txtPopulation.Text) || string.IsNullOrEmpty(pictureEdit1.Text) || string.IsNullOrEmpty(cmbPartyID.Text) || string.IsNullOrEmpty(cmbVisit.Text) || string.IsNullOrEmpty(cmbFamous.Text) || string.IsNullOrEmpty(cmbTransportationService.Text))
            {
                MessageBox.Show("Lütfen formu doldurun!", "GÜNCELLEME", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                client.DeleteTown(Convert.ToInt16(txtTownID.Text));
                List();
                MessageBox.Show("Silme Başarılı!", "KAYIT OLUNDU!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnList_Click(object sender, EventArgs e)
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
            Town t  = _townBase.Prior;

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

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clears c = new Clears();
            c.ClearAll(this);
        }

        private void txtSearch_OnValueChanged(object sender, EventArgs e)
        {
            string ara = txtSearch.Text;
            dgvTown.DataSource = db.Towns.Where(t => t.TownName.Contains(ara)).ToList();
        }
    }
}
