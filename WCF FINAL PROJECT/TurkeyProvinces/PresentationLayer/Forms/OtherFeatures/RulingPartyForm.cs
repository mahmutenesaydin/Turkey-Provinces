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
    public partial class RulingPartyForm : Form
    {
        public RulingPartyForm()
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
            dgvPartyAdd.DataSource = client.ListRulingParty();
            dgvPartyUpdate.DataSource = client.ListRulingParty();
            dgvPartyDelete.DataSource = client.ListRulingParty();
        }

        private void btnPartyAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPartyAdd.Text))
            {
                MessageBox.Show("Lütfen formu doldurun!", "KAYIT OLUNDU", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                client.AddRulingParty(new TPServiceReference.RulingParty
                {
                    Party = txtPartyAdd.Text,
                });
                List();
                MessageBox.Show("Kayıt Başarılı!", "KAYIT OLUNDU!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnPartyUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPartyUpdate.Text))
            {
                MessageBox.Show("Lütfen formu doldurun!", "GÜNCELLEME", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                client.UpdateRulingParty(new TPServiceReference.RulingParty
                {
                    PartyID = Convert.ToInt16(txtPartyIdUpdate.Text),
                    Party = txtPartyUpdate.Text
                });
                List();
                MessageBox.Show("Güncelleme Başarılı!", "KAYIT OLUNDU!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnPartyDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPartyDelete.Text))
            {
                MessageBox.Show("Lütfen bilgileri doldurun!", "UYARI", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                client.DeleteRulingParty(Convert.ToInt16(txtPartyIdDelete.Text));
                List();
                MessageBox.Show("Silme Başarılı!", "KAYIT OLUNDU!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void dgvPartyAdd_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtPartyIdAdd.Text = dgvPartyAdd.CurrentRow.Cells["PartyID"].Value.ToString();
            txtPartyAdd.Text = dgvPartyAdd.CurrentRow.Cells["Party"].Value.ToString();
        }

        private void dgvPartyUpdate_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtPartyIdUpdate.Text = dgvPartyUpdate.CurrentRow.Cells["PartyID"].Value.ToString();
            txtPartyUpdate.Text = dgvPartyUpdate.CurrentRow.Cells["Party"].Value.ToString();
        }

        private void dgvPartyDelete_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtPartyIdDelete.Text = dgvPartyDelete.CurrentRow.Cells["PartyID"].Value.ToString();
            txtPartyDelete.Text = dgvPartyDelete.CurrentRow.Cells["Party"].Value.ToString();
        }
    }
}
