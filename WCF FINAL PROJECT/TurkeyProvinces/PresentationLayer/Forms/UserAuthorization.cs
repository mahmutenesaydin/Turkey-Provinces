using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Forms
{
    public partial class UserAuthorization : Form
    {
        public UserAuthorization()
        {
            InitializeComponent();
        }

        TPServiceReference.ServiceContractClient client = new TPServiceReference.ServiceContractClient();
        int userid;

        private void ListManager()
        {
            dgvAdmin.DataSource = client.ListByBool(false);
        }
        private void ListUser()
        {
            dgvUser.DataSource = client.ListByBool(true);
        }
        private void UserAuthorization_Load(object sender, EventArgs e)
        {
            ListManager();
            ListUser();
        }

        private void dgvAdmin_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvAdmin.CurrentRow != null)
            {
                userid = Convert.ToInt32(dgvAdmin.CurrentRow.Cells["UserID"].Value);
                txtUserName.Text = dgvAdmin.CurrentRow.Cells["UserName"].Value.ToString();
                txtPassword.Text = dgvAdmin.CurrentRow.Cells["Password"].Value.ToString();
            }
        }

        private void btnAuthorize_Click(object sender, EventArgs e)
        {
            if (bunifuCheckbox1.Checked)
            {
                client.UpdateUser(new TPServiceReference.User
                {
                    UserID = userid,
                    IsActive = false,
                    UserName = txtUserName.Text,
                    Password = txtPassword.Text
                });
                ListManager();
                ListUser();
            }
            else
            {
                client.UpdateUser(new TPServiceReference.User
                {
                    UserID = userid,
                    IsActive = true,
                    UserName = txtUserName.Text,
                    Password = txtPassword.Text
                });
                ListUser();
                ListManager();
            }
        }

        private void dgvUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            userid = Convert.ToInt32(dgvUser.CurrentRow.Cells["UserIDs"].Value);
            txtUserName.Text = dgvUser.CurrentRow.Cells["UserNames"].Value.ToString();
            txtPassword.Text = dgvUser.CurrentRow.Cells["Passwords"].Value.ToString();
        }
    }
}
