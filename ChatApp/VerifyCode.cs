using ChatAppneeus;
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
using static System.Net.Mime.MediaTypeNames;

namespace ChatApp
{
    public partial class VerifyCode : Form
    {
        public VerifyCode()
        {
            InitializeComponent();

            var borderless = new Guna2BorderlessForm();
            borderless.ContainerControl = this;
            borderless.BorderRadius = 20;

            txtCode.PlaceholderText = "Enter the code";
            txtCode.PlaceholderForeColor = Color.Gray;
            txtCode.Font = new Font("Segoe UI", 10);
        }

        private void btNext_Click(object sender, EventArgs e)
        {
            ResetPassword resetPassword = new ResetPassword();
            resetPassword.Tag = this.Tag;
            resetPassword.Show();
            this.Close();
        }
    }
}
