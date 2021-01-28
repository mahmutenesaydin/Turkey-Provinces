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
    public partial class RegionForm : Form
    {
        public RegionForm()
        {
            InitializeComponent();
        }
        #region PanelDüzenlemeleri
        private void btnAdd_Click(object sender, EventArgs e)
        {
            panel1.BackColor = Color.IndianRed;
            panel2.BackColor = Color.Transparent;
            panel3.BackColor = Color.Transparent;
            panel4.Visible = true;
            panel5.Visible = true;
            panel6.Visible = false;
            panel7.Visible = false;
        }

        private void btnRegionUpdate_Click(object sender, EventArgs e)
        {
            panel1.BackColor = Color.Transparent;
            panel2.BackColor = Color.IndianRed;
            panel3.BackColor = Color.Transparent;
            panel4.Visible = true;
            panel5.Visible = false;
            panel6.Visible = true;
            panel7.Visible = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            panel1.BackColor = Color.Transparent;
            panel2.BackColor = Color.Transparent;
            panel3.BackColor = Color.IndianRed;
            panel4.Visible = true;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = true;
        }
        #endregion

        TPServiceReference.ServiceContractClient client = new TPServiceReference.ServiceContractClient();

        private void List()
        {
            dgvRegionAdd.DataSource = client.ListRegion();
            dgvRegionUpdate.DataSource = client.ListRegion();
            dgvRegionDelete.DataSource = client.ListRegion();
        }

        private void btnRegionAdd_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRegionName.Text))
            {
                MessageBox.Show("Lütfen formu doldurun!", "KAYIT OLUNDU", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                client.AddRegion(new TPServiceReference.Region
                {
                    RegionName = txtRegionName.Text
                });
                List();
                MessageBox.Show("Kayıt Başarılı!", "KAYIT OLUNDU!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRegionNameUpdate.Text))
            {
                MessageBox.Show("Lütfen formu doldurun!", "GÜNCELLEME", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                client.UpdateRegion(new TPServiceReference.Region
                {
                    RegionID = Convert.ToInt16(txtRegionIdUpdate.Text),
                    RegionName = txtRegionName.Text
                });
                List();
                MessageBox.Show("Güncelleme Başarılı!", "KAYIT OLUNDU!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnRegionDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRegionNameDelete.Text))
            {
                MessageBox.Show("Lütfen bilgileri doldurun!", "UYARI", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                client.DeleteRegion(Convert.ToInt16(txtRegionIdDelete.Text));
                List();
                MessageBox.Show("Silme Başarılı!", "KAYIT OLUNDU!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void dgvRegionAdd_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtRegionIdAdd.Text = dgvRegionAdd.CurrentRow.Cells["RegionID"].Value.ToString();
            txtRegionName.Text = dgvRegionAdd.CurrentRow.Cells["RegionName"].Value.ToString();
        }

        private void dgvRegionUpdate_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtRegionIdUpdate.Text = dgvRegionUpdate.CurrentRow.Cells["RegionID"].Value.ToString();
            txtRegionNameUpdate.Text = dgvRegionUpdate.CurrentRow.Cells["RegionName"].Value.ToString();
        }

        private void dgvRegionDelete_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtRegionIdDelete.Text = dgvRegionDelete.CurrentRow.Cells["RegionID"].Value.ToString();
            txtRegionName.Text = dgvRegionDelete.CurrentRow.Cells["RegionName"].Value.ToString();
        }
    }
}
