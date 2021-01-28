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
    public partial class TransportationServiceForm : Form
    {
        public TransportationServiceForm()
        {
            InitializeComponent();
        }
        
        #region Panel Düzenlemeleri
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

        TPServiceReference.ServiceContractClient client = new TPServiceReference.ServiceContractClient();

        private void List()
        {
            dgvServiceAdd.DataSource = client.ListTransportationService();
            dgvServiceUpdate.DataSource = client.ListTransportationService();
            dgvServiceDelete.DataSource = client.ListTransportationService();
        }

        private void btnServiceAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtServiceAdd.Text))
            {
                MessageBox.Show("Lütfen formu doldurun!", "KAYIT OLUNDU", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                client.AddTransportationService(new TPServiceReference.TransportationService
                {
                    TransportationService1 = txtServiceAdd.Text
                });
                List();
                MessageBox.Show("Kayıt Başarılı!", "KAYIT OLUNDU!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnServiceUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtServiceUpdate.Text))
            {
                MessageBox.Show("Lütfen formu doldurun!", "GÜNCELLEME", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                client.UpdateTransportationService(new TPServiceReference.TransportationService
                {
                    TransportationServicesID = Convert.ToInt16(txtServiceIdUpdate.Text),
                    TransportationService1 = txtServiceAdd.Text
                });
                List();
                MessageBox.Show("Güncelleme Başarılı!", "KAYIT OLUNDU!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnServiceDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtServiceDelete.Text))
            {
                MessageBox.Show("Lütfen bilgileri doldurun!", "UYARI", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                client.DeleteTransportationService(Convert.ToInt16(txtServiceIdDelete.Text));
                List();
                MessageBox.Show("Silme Başarılı!", "KAYIT OLUNDU!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void dgvServiceAdd_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtServiceIdAdd.Text = dgvServiceAdd.CurrentRow.Cells["TransportationServicesID"].Value.ToString();
            txtServiceAdd.Text = dgvServiceAdd.CurrentRow.Cells["TransportationService"].Value.ToString();
        }

        private void dgvServiceUpdate_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtServiceIdUpdate.Text = dgvServiceUpdate.CurrentRow.Cells["TransportationServicesID"].Value.ToString();
            txtServiceUpdate.Text = dgvServiceUpdate.CurrentRow.Cells["TransportationService"].Value.ToString();
        }

        private void dgvServiceDelete_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtServiceIdDelete.Text = dgvServiceDelete.CurrentRow.Cells["TransportationServicesID"].Value.ToString();
            txtServiceDelete.Text = dgvServiceDelete.CurrentRow.Cells["TransportationService"].Value.ToString();
        }
    }
}
