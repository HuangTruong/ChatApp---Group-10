using ChatApp;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace ChatAppneeus 
{
    public partial class ResetPassword : Form
    {
        public ResetPassword()
        {
            InitializeComponent();

            var borderless = new Guna2BorderlessForm();
            borderless.ContainerControl = this;
            borderless.BorderRadius = 20;
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            Form loginForm = this.Tag as Form;
            if (loginForm != null && !loginForm.IsDisposed)
            {
                loginForm.Show();
                this.Close();
            }
            else
            {
                ChatApp.Login newLogin = new ChatApp.Login();
                newLogin.Show();
                this.Close();
            }
        }
    }
}
