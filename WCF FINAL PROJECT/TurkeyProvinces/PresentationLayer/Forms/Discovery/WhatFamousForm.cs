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
    public partial class WhatFamousForm : Form
    {
        public WhatFamousForm()
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
            dgvFamousAdd.DataSource = client.ListWhatFamou();
            dgvFamousDelete.DataSource = client.ListWhatFamou();
            dgvFamousUpdate.DataSource = client.ListWhatFamou();
        }

        private void btnFamousAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFamousAdd.Text))
            {
                MessageBox.Show("Lütfen formu doldurun!", "KAYIT OLUNDU", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                client.AddWhatFamou(new TPServiceReference.WhatFamou
                {
                    WhatFamous = txtFamousAdd.Text,
                });
                List();
                MessageBox.Show("Kayıt Başarılı!", "KAYIT OLUNDU!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnFamousUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFamousIdUpdate.Text))
            {
                MessageBox.Show("Lütfen formu doldurun!", "GÜNCELLEME", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                client.UpdateWhatFamou(new TPServiceReference.WhatFamou
                {
                    WhatFamousID = Convert.ToInt16(txtFamousIdUpdate.Text),
                    WhatFamous = txtFamousAdd.Text,
                });
                List();
                MessageBox.Show("Güncelleme Başarılı!", "KAYIT OLUNDU!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnFamousDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFamousDelete.Text))
            {
                MessageBox.Show("Lütfen bilgileri doldurun!", "UYARI", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                client.DeleteWhatFamou(Convert.ToInt16(txtFamousIdDelete.Text));
                List();
                MessageBox.Show("Silme Başarılı!", "KAYIT OLUNDU!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void dgvFamousDelete_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtFamousIdDelete.Text = dgvFamousDelete.CurrentRow.Cells["WhatFamousID"].Value.ToString();
            txtFamousDelete.Text = dgvFamousDelete.CurrentRow.Cells["WhatFamous"].Value.ToString();
        }

        private void dgvFamousAdd_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtFamousIdAdd.Text = dgvFamousAdd.CurrentRow.Cells["WhatFamousID"].Value.ToString();
            txtFamousAdd.Text = dgvFamousAdd.CurrentRow.Cells["WhatFamous"].Value.ToString();
        }

        private void dgvFamousUpdate_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtFamousIdUpdate.Text = dgvFamousUpdate.CurrentRow.Cells["WhatFamousID"].Value.ToString();
            txtFamousUpdate.Text = dgvFamousUpdate.CurrentRow.Cells["WhatFamous"].Value.ToString();
        }
    }
}
