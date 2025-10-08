using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatApp
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '●';
            picShowPassword.Image = Properties.Resources.eye_close;
            chkShowPassword.Checked = false;
        }

        private bool isPasswordVisible = false;
        private void picShowPassword_Click(object sender, EventArgs e)
        {
            isPasswordVisible = !isPasswordVisible;

            if (isPasswordVisible)
            {
                // Hiện mật khẩu
                txtPassword.PasswordChar = '\0';
                picShowPassword.Image = Properties.Resources.eye_open;
                chkShowPassword.Checked = true;
            }
            else
            {
                // Ẩn mật khẩu
                txtPassword.PasswordChar = '●';
                picShowPassword.Image = Properties.Resources.eye_close;
                chkShowPassword.Checked = false;
            }
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPassword.Checked)
            {
                // hiện mật khẩu
                txtPassword.PasswordChar = '\0';  
                picShowPassword.Image = Properties.Resources.eye_open;
                isPasswordVisible = true;
            }
                
            else
            {
                // ẩn mật khẩu
                txtPassword.PasswordChar = '●';   
                picShowPassword.Image = Properties.Resources.eye_close;
                isPasswordVisible = false;
            }
        }

        private void pnlLogin_Paint(object sender, PaintEventArgs e)
        {
            pnlLogin.Left = (this.ClientSize.Width - pnlLogin.Width) / 2;
            pnlLogin.Top = (this.ClientSize.Height - pnlLogin.Height) / 2;
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            register registerForm = new register();
            registerForm.Tag = this;
            registerForm.Show();
            this.Hide();
        }

        private void lnkForgetPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ForgotPassword forgotPasswordForm = new ForgotPassword();
            forgotPasswordForm.Tag = this;
            forgotPasswordForm.Show();
            this.Hide();
        }
    }
}
