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
    public partial class LoginAdmin : Form
    {
        public LoginAdmin()
        {
            InitializeComponent();
        }

        TPServiceReference.ServiceContractClient client = new TPServiceReference.ServiceContractClient();

        private void btnLoginLgn_Click(object sender, EventArgs e)
        {
            if (client.Login(txtUserName.Text, txtPassword.Text) == true)
            {
                MessageBox.Show("Giriş Başarılı");
                MainForm main = new MainForm();
                main.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Lütfen Bilgilerinizi Tekrar Kontrol Edin!", "UYARI!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void chckShowMyPassword_OnChange(object sender, EventArgs e)
        {
            if (chckShowMyPassword.Checked)
            {
                txtPassword.isPassword = false;
            }
            else
            {
                txtPassword.isPassword = true;
            }
        }

        private void linkForgotYourPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
