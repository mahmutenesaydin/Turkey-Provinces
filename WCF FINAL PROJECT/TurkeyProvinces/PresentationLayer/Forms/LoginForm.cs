using BusinessLayer.UnitOfWork;
using PresentationLayer.Forms.User;
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

namespace PresentationLayer.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        #region PanelAyarlamaları

        private void btnAdd_Click(object sender, EventArgs e)
        {
            panel1.BackColor = Color.IndianRed;
            panel2.BackColor = Color.Transparent;
            panelLogin.Visible = true;
            panelRegister.Visible = false;
        }

        private void btnRegister_Click_1(object sender, EventArgs e)
        {
            panel1.BackColor = Color.Transparent;
            panel2.BackColor = Color.IndianRed;
            panelLogin.Visible = false;
            panelRegister.Visible = true;
            panelNewPassword.Visible = false;
        }
        #endregion

        //TurkeyProvinceServiceReference.ServiceContractClient client = new TurkeyProvinceServiceReference.ServiceContractClient();

      //  TurkeyProvinceServices.ServiceContractClient client = new TurkeyProvinceServices.ServiceContractClient();
        UserBusiness userBus = new UserBusiness();

        TPServiceReference.ServiceContractClient client = new TPServiceReference.ServiceContractClient();

        private void btnLoginLgn_Click(object sender, EventArgs e)
        {
            if (client.Login(txtUserName.Text, txtPassword.Text) == true)
            {
                this.Hide();
                MessageBox.Show("Giriş Başarılı");
                UserMainForm userMain = new UserMainForm();
                userMain.Show();

            }

            else
            {
                MessageBox.Show("Giriş Başarısız!!");
            }
        }

        private void btnRegisterReg_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtUserNameReg.Text) || string.IsNullOrEmpty(txtPasswordReg.Text))
            {
                MessageBox.Show("Lütfen formu doldurun!", "GÜNCELLEME", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                client.AddUser(new TPServiceReference.User
                {

                    UserName = txtUserNameReg.Text,
                    Password = txtPasswordReg.Text,
                    //IsActive = true
                });
                MessageBox.Show("Kayıt Başarılı!", "KAYIT OLUNDU!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private byte[] ImageToByte(Image image)
        {
            using (var ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                return ms.ToArray();
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

        private void btnChangeMyPassword_Click(object sender, EventArgs e)
        {
            client.UpdateUser(new TPServiceReference.User
            {
                Password = txtNewPassword.Text
            });
            //userBus.Edit(new DataLayer.User
            //{
            //    Password = txtNewPassword.Text
            //});
        }

        private void linkForgotYourPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panelRegister.Visible = false;
            panelLogin.Visible = false;
            panelNewPassword.Visible = true;
            panel1.BackColor = Color.Transparent;
            panel2.BackColor = Color.Transparent;
        }

        private void btnAdminLogin_Click(object sender, EventArgs e)
        {
            LoginAdmin adm = new LoginAdmin();
            adm.Show();
            this.Hide();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            //OpenFileDialog fileDialog = new OpenFileDialog();
            //fileDialog.Filter = "Image Files(*.BMP;*.JPG;*.PNG;*.GIF)|*.BMP;*.JPG;*.PNG;*.GIF";
            //if (fileDialog.ShowDialog() == DialogResult.OK)
            //{
            //    pictureBox1.Image = new Bitmap(fileDialog.FileName);
            //}
        }
    }
}
