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
    public partial class register : Form
    {
        public register()
        {
            InitializeComponent();

        }

        private void pnlRegister_Paint(object sender, PaintEventArgs e)
        {
            pnlRegister.Left = (this.ClientSize.Width - pnlRegister.Width) / 2;
            pnlRegister.Top = (this.ClientSize.Height - pnlRegister.Height) / 2;
        }

        private void button1_Click(object sender, EventArgs e)
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
