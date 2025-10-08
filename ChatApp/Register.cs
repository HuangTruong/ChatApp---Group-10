using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Text;
using System.Windows.Forms;

namespace ChatApp
{
    public partial class Register : Form
    {
        private IFirebaseClient firebaseClient;

        public Register()
        {
            InitializeComponent();

            IFirebaseConfig config = new FirebaseConfig
            {
                AuthSecret = "PFejsR6CHWL2zIGqFqZ1w3Orw0ljzeHnHubtuQN8",
                BasePath = "https://databeseaccess-default-rtdb.firebaseio.com/"
            };

            firebaseClient = new FireSharp.FirebaseClient(config);
            if (firebaseClient == null)
                MessageBox.Show("Không kết nối được Firebase.");
        }

        private void btnBack_Click(object sender, EventArgs e) => this.Close();

        
        private async void btnRegister_Click(object sender, EventArgs e)
        {
            string taiKhoan = txtUsername.Text;
            string matKhau = txtPassword.Text;
            string xacNhanMatKhau = txtConfirmPassword.Text;
            string email = txtEmail.Text;
            string encodedEmail = Convert.ToBase64String(Encoding.UTF8.GetBytes(email));
            string username = txtFullname.Text;
            string ngaysinh = txtNgaySinh.Text;
            string gioitinh = cbGioiTinh.Text;

            if (string.IsNullOrWhiteSpace(taiKhoan) ||
                string.IsNullOrWhiteSpace(matKhau) ||
                string.IsNullOrWhiteSpace(xacNhanMatKhau) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(ngaysinh) ||
                string.IsNullOrWhiteSpace(gioitinh))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (matKhau != xacNhanMatKhau)
            {
                MessageBox.Show("Mật khẩu và xác nhận mật khẩu không khớp!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
               
                var userExistsResponse = await firebaseClient.GetAsync($"users/{taiKhoan}");
                if (userExistsResponse.Body != "null")
                {
                    MessageBox.Show("Tên tài khoản đã tồn tại!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var emailExistsResponse = await firebaseClient.GetAsync($"emails/{encodedEmail}");
                if (emailExistsResponse.Body != "null")
                {
                    MessageBox.Show("Email đã tồn tại!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var usernameExistsResponse = await firebaseClient.GetAsync($"Username/{username}");
                if (usernameExistsResponse.Body != "null")
                {
                    MessageBox.Show("Username đã tồn tại!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // (Tùy bạn có cần kiểm tra "Password trùng" hay không; thường KHÔNG nên)

                var newUser = new UserDk
                {
                    TaiKhoan = taiKhoan,
                    MatKhau = matKhau,       
                    Email = encodedEmail,
                    Username = username,
                    Ngaysinh = ngaysinh,
                    Gioitinh = gioitinh
                };

                // ✅ SetAsync + await
                await firebaseClient.SetAsync($"users/{taiKhoan}", newUser);
                await firebaseClient.SetAsync($"emails/{encodedEmail}", true);
                await firebaseClient.SetAsync($"Username/{username}", true);
                await firebaseClient.SetAsync($"Password/{matKhau}", true); 

                MessageBox.Show("Đăng ký thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtFullname.Clear();
                txtUsername.Clear();
                txtPassword.Clear();
                txtConfirmPassword.Clear();
                txtEmail.Clear();
                txtNgaySinh.Clear();
                cbGioiTinh.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    public class UserDk
    {
        public string TaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Ngaysinh { get; set; }
        public string Gioitinh { get; set; }
    }

}
