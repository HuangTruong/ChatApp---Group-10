using System;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

namespace ChatApp
{
    

    public partial class Login : Form
    {
        private IFirebaseClient firebaseClient;
        private bool isPasswordVisible = false;

        public Login()
        {
            InitializeComponent();

            // Khởi tạo cấu hình Firebase
            IFirebaseConfig config = new FirebaseConfig
            {
                AuthSecret = "PFejsR6CHWL2zIGqFqZ1w3Orw0ljzeHnHubtuQN8",
                BasePath = "https://fir-client-1d344-default-rtdb.firebaseio.com/"
            };

            // Khởi tạo FirebaseClient
            firebaseClient = new FireSharp.FirebaseClient(config);
            if (firebaseClient == null)
            {
                MessageBox.Show("Không kết nối được Firebase.");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '●';
            picShowPassword.Image = Properties.Resources.eye_close;
            chkShowPassword.Checked = false;
        }

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
                txtPassword.PasswordChar = '\0';
                picShowPassword.Image = Properties.Resources.eye_open;
                isPasswordVisible = true;
            }
            else
            {
                txtPassword.PasswordChar = '●';
                picShowPassword.Image = Properties.Resources.eye_close;
                isPasswordVisible = false;
            }
        }

        // Canh giữa panel đăng nhập
        private void pnlLogin_Paint(object sender, PaintEventArgs e)
        {
            pnlLogin.Left = (this.ClientSize.Width - pnlLogin.Width) / 2;
            pnlLogin.Top = (this.ClientSize.Height - pnlLogin.Height) / 2;
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            // optional
        }

        // Mở form Đăng ký
        private void btnRegister_Click(object sender, EventArgs e)
        {
            var registerForm = new Register(); 
            registerForm.Tag = this;
            registerForm.Show();
            this.Hide();
        }

        // Mở form Quên mật khẩu
        private void lnkForgetPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var forgotPasswordForm = new ForgotPassword();
            forgotPasswordForm.Tag = this;
            forgotPasswordForm.Show();
            this.Hide();
        }

        // Đăng nhập (async)
        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string taiKhoan = txtUsername.Text;
            string matKhau = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(taiKhoan))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(matKhau))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                FirebaseResponse userResponse = await firebaseClient.GetAsync($"users/{taiKhoan}");
                if (userResponse.Body == "null")
                {
                    MessageBox.Show("Tài khoản không tồn tại!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var user = userResponse.ResultAs<UserDto>();
                if (user == null || user.MatKhau != matKhau)
                {
                    MessageBox.Show("Mật khẩu không đúng!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Đăng nhập thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtUsername.Clear();
                txtPassword.Clear();

                // chuyển tiếp
                this.Hide();
                // new MainForm().Show(); // nếu có form chính, mở ở đây
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đăng nhập: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    public class UserDto
    {
        public string Username { get; set; }
        public string MatKhau { get; set; }
        public string Email { get; set; }
    }
}
