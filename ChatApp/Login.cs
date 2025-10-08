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
                txtPassword.PasswordChar = '\0';
                picShowPassword.Image = Properties.Resources.eye_open;
                chkShowPassword.Checked = true;
            }
            else
            {
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

        // ⭐ SỬA 1: event handler dùng await thì phải async void
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
                // ⭐ SỬA 2: dùng await hợp lệ trong async method
                FirebaseResponse userResponse = await firebaseClient.GetAsync($"users/{taiKhoan}");

                if (userResponse.Body == "null")
                {
                    MessageBox.Show("Tài khoản không tồn tại!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // ⭐ SỬA 3: có class User để map dữ liệu
                var user = userResponse.ResultAs<User>();

                if (user.MatKhau != matKhau)
                {
                    MessageBox.Show("Mật khẩu không đúng!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Đăng nhập thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtUsername.Text = "";
                txtPassword.Text = "";
                this.Hide();
            }
            // ⭐ SỬA 4: bổ sung catch để hết CS1524
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đăng nhập: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Register f = new Register();
            f.ShowDialog();
        }

        private void lnkForgetPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ForgetPassword f = new ForgetPassword();
            f.ShowDialog();
        }
    }
    public class User
    {
        public string Username { get; set; }
        public string MatKhau { get; set; }
        public string Email { get; set; }
    }
}
