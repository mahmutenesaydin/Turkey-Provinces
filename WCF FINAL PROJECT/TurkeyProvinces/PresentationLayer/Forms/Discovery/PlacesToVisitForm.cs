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
    public partial class PlacesToVisitForm : Form
    {
        public PlacesToVisitForm()
        {
            InitializeComponent();
        }
        #region PanelAyarlamaları
        private void btnAdd_Click(object sender, EventArgs e)
        {
            panel1.BackColor = Color.IndianRed;
            panel2.BackColor = Color.Transparent;
            panel3.BackColor = Color.Transparent;
            panelAdd.Visible = true;
            panelUpdate.Visible = false;
            panelDelete.Visible = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            panel1.BackColor = Color.Transparent;
            panel2.BackColor = Color.IndianRed;
            panel3.BackColor = Color.Transparent;
            panelAdd.Visible = false;
            panelUpdate.Visible = true;
            panelDelete.Visible = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            panel1.BackColor = Color.Transparent;
            panel2.BackColor = Color.Transparent;
            panel3.BackColor = Color.IndianRed;
            panelAdd.Visible = false;
            panelUpdate.Visible = false;
            panelDelete.Visible = true;
        }
        #endregion

        //   TurkeyProvinceServiceReference.ServiceContractClient client = new TurkeyProvinceServiceReference.ServiceContractClient();

        TPServiceReference.ServiceContractClient client = new TPServiceReference.ServiceContractClient();

        private void List()
        {
            dgvVisitAdd.DataSource = client.ListPlacesToVisit();
            dgvVisitDelete.DataSource = client.ListPlacesToVisit();
            dgvVisitUpdate.DataSource = client.ListPlacesToVisit();
        }

        private void btnVisitAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtVisitAdd.Text))
            {
                MessageBox.Show("Lütfen formu doldurun!", "KAYIT OLUNDU", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                client.AddPlacesToVisit(new TPServiceReference.PlacesToVisit
                {
                    PlaceToVisit = txtVisitAdd.Text
                });
                List();
                MessageBox.Show("Kayıt Başarılı!", "KAYIT OLUNDU!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }
        private void btnVisitUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtVisitUpdate.Text))
            {
                MessageBox.Show("Lütfen formu doldurun!", "GÜNCELLEME", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                client.UpdatePlacesToVisit(new TPServiceReference.PlacesToVisit
                {
                    PlaceToVisitID = Convert.ToInt16(txtVisitIdUpdate.Text),
                    PlaceToVisit = txtVisitUpdate.Text
                });
                List();
                MessageBox.Show("Güncelleme Başarılı!", "KAYIT OLUNDU!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnVisitDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtVisitsDelete.Text))
            {
                MessageBox.Show("Lütfen bilgileri doldurun!", "UYARI", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                client.DeletePlacesToVisit(Convert.ToInt16(txtVisitIdDelete.Text));
                List();
                MessageBox.Show("Silme Başarılı!", "KAYIT OLUNDU!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void dgvVisitAdd_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtVisitIdAdd.Text = dgvVisitAdd.CurrentRow.Cells["PlaceToVisitID"].Value.ToString();
            txtVisitAdd.Text = dgvVisitAdd.CurrentRow.Cells["PlaceToVisit"].Value.ToString();
        }

        private void dgvVisitUpdate_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtVisitIdUpdate.Text = dgvVisitUpdate.CurrentRow.Cells["PlaceToVisitID"].Value.ToString();
            txtVisitUpdate.Text = dgvVisitUpdate.CurrentRow.Cells["PlaceToVisit"].Value.ToString();
        }

        private void dgvVisitDelete_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtVisitIdDelete.Text = dgvVisitDelete.CurrentRow.Cells["PlaceToVisitID"].Value.ToString();
            txtVisitsDelete.Text = dgvVisitDelete.CurrentRow.Cells["PlaceToVisit"].Value.ToString();
        }
    }
}