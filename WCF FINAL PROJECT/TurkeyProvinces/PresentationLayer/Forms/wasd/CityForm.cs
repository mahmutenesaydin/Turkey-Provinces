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
    public partial class ProvinceForm : Form
    {
        public ProvinceForm()
        {
            InitializeComponent();
        }

        TPServiceReference.ServiceContractClient client = new TPServiceReference.ServiceContractClient();
        TurkeyProvincesEntitie3 db = new TurkeyProvincesEntitie3();
        CityBusiness cityBus = new CityBusiness();
        RegionBusiness regBus = new RegionBusiness();
        RulingPartyBusiness partyBus = new RulingPartyBusiness();
        PlaceToVisitBusiness visitBus = new PlaceToVisitBusiness();
        WhatFamousBusiness famousBus = new WhatFamousBusiness();
        TransportationServiceBusiness serviceBus = new TransportationServiceBusiness();

        CityBase _cityBase = new CityBase()
        {
            DataObject = new CityDatabaseObject()
        };

        private void ProvinceForm_Load(object sender, EventArgs e)
        {
            cmbRegion.SetDataSource<City>(cityBus.ListForComboBox(), "RegionName", "RegionID");
            cmbFamous.SetDataSource<WhatFamou>(famousBus.ListForComboBox(), "WhatFamous", "WhatFamousID");
            cmbPartyID.SetDataSource<RulingParty>(partyBus.ListForComboBox(), "Party", "PartyID");
            cmbTransportationService.SetDataSource<TransportationService>(serviceBus.ListForComboBox(), "TransportationService1", "TransportationServicesID");
            cmbVisit.SetDataSource<PlacesToVisit>(visitBus.ListForComboBox(), "PlaceToVisit", "PlaceToVisitID");
        }

        private void List()
        {
            dgvProvince.DataSource = client.ListCity();
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
            if (string.IsNullOrEmpty(txtCityName.Text) || string.IsNullOrEmpty(txtPlateCode.Text) || string.IsNullOrEmpty(txtPopulation.Text) || string.IsNullOrEmpty(pictureEdit1.Text) || string.IsNullOrEmpty(cmbPartyID.Text) || string.IsNullOrEmpty(cmbVisit.Text) || string.IsNullOrEmpty(cmbFamous.Text) || string.IsNullOrEmpty(cmbRegion.Text) || string.IsNullOrEmpty(cmbTransportationService.Text))
            {
                MessageBox.Show("Lütfen formu doldurun!", "GÜNCELLEME", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                client.AddCity(new TPServiceReference.City
                {
                    CityName = txtCityName.Text,
                    PlateCode = Convert.ToInt16(txtPlateCode.Text),
                    Population = txtPopulation.Text,
                    Picture = ImageToByte(pictureEdit1.Image),
                    PartyID = Convert.ToInt16(cmbPartyID.SelectedValue),
                    PlaceToVisitID = Convert.ToInt16(cmbVisit.SelectedValue),
                    WhatFamousID = Convert.ToInt16(cmbFamous.SelectedValue),
                    RegionID = Convert.ToInt16(cmbRegion.SelectedValue),
                    TransportationServiceID = Convert.ToInt16(cmbTransportationService.SelectedValue)
                });
                List();
                MessageBox.Show("Kayıt Başarılı!", "KAYIT OLUNDU!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCityName.Text) || string.IsNullOrEmpty(txtPlateCode.Text) || string.IsNullOrEmpty(txtPopulation.Text) || string.IsNullOrEmpty(pictureEdit1.Text) || string.IsNullOrEmpty(cmbPartyID.Text) || string.IsNullOrEmpty(cmbVisit.Text) || string.IsNullOrEmpty(cmbFamous.Text) || string.IsNullOrEmpty(cmbRegion.Text) || string.IsNullOrEmpty(cmbTransportationService.Text))
            {
                MessageBox.Show("Lütfen formu doldurun!", "GÜNCELLEME", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                client.UpdateCity(new TPServiceReference.City
                {
                    CityID = Convert.ToInt16(txtCityID.Text),
                    CityName = txtCityName.Text,
                    PlateCode = Convert.ToInt16(txtPlateCode.Text),
                    Population = txtPopulation.Text,
                    Picture = ImageToByte(pictureEdit1.Image),
                    PartyID = Convert.ToInt16(cmbPartyID.SelectedValue),
                    PlaceToVisitID = Convert.ToInt16(cmbVisit.SelectedValue),
                    WhatFamousID = Convert.ToInt16(cmbFamous.SelectedValue),
                    RegionID = Convert.ToInt16(cmbRegion.SelectedValue),
                    TransportationServiceID = Convert.ToInt16(cmbTransportationService.SelectedValue)
                });
                List();
                MessageBox.Show("Güncelleme Başarılı!", "KAYIT OLUNDU!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCityName.Text) || string.IsNullOrEmpty(txtPlateCode.Text) || string.IsNullOrEmpty(txtPopulation.Text) || string.IsNullOrEmpty(pictureEdit1.Text) || string.IsNullOrEmpty(cmbPartyID.Text) || string.IsNullOrEmpty(cmbVisit.Text) || string.IsNullOrEmpty(cmbFamous.Text) || string.IsNullOrEmpty(cmbRegion.Text) || string.IsNullOrEmpty(cmbTransportationService.Text))
            {
                MessageBox.Show("Lütfen formu doldurun!", "GÜNCELLEME", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                client.DeleteCity(Convert.ToInt16(txtCityID.Text));
                List();
                MessageBox.Show("Silme Başarılı!", "KAYIT OLUNDU!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            List();
        }

        public Image GetDataToImage(byte[] pData)
        {
            try
            {
                ImageConverter imgConverter = new ImageConverter();
                return imgConverter.ConvertFrom(pData) as Image;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void dgvProvince_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCityID.Text = dgvProvince.CurrentRow.Cells["CityID"].Value.ToString();
            txtCityName.Text = dgvProvince.CurrentRow.Cells["CityName"].Value.ToString();
            txtPlateCode.Text = dgvProvince.CurrentRow.Cells["PlateCode"].Value.ToString();
            //txtPopulation.Text = dgvProvince.CurrentRow.Cells["Population"].Value.ToString();
            //pictureEdit1.Text = dgvProvince.CurrentRow.Cells["Picture"].Value.ToString();
            pictureEdit1.Image = GetDataToImage((byte[])(dgvProvince.CurrentRow.Cells["Picture"].Value));
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clears c = new Clears();
            c.ClearAll(this);
        }

        private void bunifuMaterialTextbox1_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void txtSearch_OnValueChanged(object sender, EventArgs e)
        {
            string ara = txtSearch.Text;
            dgvProvince.DataSource = db.Cities.Where(c => c.CityName.Contains(ara)).ToList();
        }
    }
}
