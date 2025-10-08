using Guna.UI2.WinForms;
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
    public partial class ForgotPassword : Form
    {
        public ForgotPassword()
        {
            InitializeComponent();

            var borderless = new Guna2BorderlessForm();
            borderless.ContainerControl = this;
            borderless.BorderRadius = 20;

            txtEmail.PlaceholderText = "Phone or email";
            txtEmail.PlaceholderForeColor = Color.Gray;
            txtEmail.Font = new Font("Segoe UI", 10);
        }

        private void btNext_Click(object sender, EventArgs e)
        {
            VerifyCode verify = new VerifyCode();
            verify.Tag = this.Tag;
            verify.Show();
            this.Close();
        }

        private void ForgotPassword_Load(object sender, EventArgs e)
        {

        }
    }
}
