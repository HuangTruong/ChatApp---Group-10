<<<<<<< HEAD
﻿using System;
=======
﻿using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
>>>>>>> ad7ae01 (Luu tam)
using System.Text;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Guna.UI2.WinForms;

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

<<<<<<< HEAD
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
                var newLogin = new ChatApp.Login();
                newLogin.Show();
                this.Close();
            }
        }

        private void Register_Load(object sender, EventArgs e) { }
        private void register_Load_1(object sender, EventArgs e) { }


        private async void btnRegister_Click(object sender, EventArgs e)
        {
            string taiKhoan = txtTaiKhoan.Text;
            string matKhau = txtMatKhau.Text;
            string xacNhanMatKhau = txtXacNhan.Text;
            string email = txtEmail.Text;
            string encodedEmail = Convert.ToBase64String(Encoding.UTF8.GetBytes(email));
            string ten = txtTen.Text;
            string ngaySinh = dtNgaySinh.Text;
            string gioiTinh = cbGioiTinh.Text;

            if (string.IsNullOrWhiteSpace(taiKhoan) ||
                string.IsNullOrWhiteSpace(matKhau) ||
                string.IsNullOrWhiteSpace(xacNhanMatKhau) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(ten) ||
                string.IsNullOrWhiteSpace(ngaySinh) ||
                string.IsNullOrWhiteSpace(gioiTinh))
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
=======
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
               
>>>>>>> ad7ae01 (Luu tam)
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

<<<<<<< HEAD
                var usernameExistsResponse = await firebaseClient.GetAsync($"Username/{ten}");
                if (usernameExistsResponse.Body != "null")
                {
                    MessageBox.Show("Tên hiển thị đã tồn tại!", "Lỗi",
=======
                var usernameExistsResponse = await firebaseClient.GetAsync($"Username/{username}");
                if (usernameExistsResponse.Body != "null")
                {
                    MessageBox.Show("Username đã tồn tại!", "Lỗi",
>>>>>>> ad7ae01 (Luu tam)
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

<<<<<<< HEAD
                var newUser = new UserDK
                {
                    TaiKhoan = taiKhoan,
                    MatKhau = matKhau,
                    Email = encodedEmail,
                    Username = ten,
                    Ngaysinh = ngaySinh,
                    Gioitinh = gioiTinh
                };

                await firebaseClient.SetAsync($"users/{taiKhoan}", newUser);
                await firebaseClient.SetAsync($"emails/{encodedEmail}", true);
                await firebaseClient.SetAsync($"Username/{ten}", true);
                await firebaseClient.SetAsync($"Password/{matKhau}", true);
=======
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
>>>>>>> ad7ae01 (Luu tam)

                MessageBox.Show("Đăng ký thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

<<<<<<< HEAD
                txtTen.Clear();
                txtTaiKhoan.Clear();
                txtMatKhau.Clear();
                txtXacNhan.Clear();
                txtEmail.Clear();
                dtNgaySinh.Clear();
=======
                txtFullname.Clear();
                txtUsername.Clear();
                txtPassword.Clear();
                txtConfirmPassword.Clear();
                txtEmail.Clear();
                txtNgaySinh.Clear();
>>>>>>> ad7ae01 (Luu tam)
                cbGioiTinh.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
<<<<<<< HEAD
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }


    public class UserDK
    {
        public string TaiKhoan { get; set; }
        public string MatKhau { get; set; }  
        public string Email { get; set; }   
=======
        }
    }
    public class UserDk
    {
        public string TaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public string Email { get; set; }
>>>>>>> ad7ae01 (Luu tam)
        public string Username { get; set; }
        public string Ngaysinh { get; set; }
        public string Gioitinh { get; set; }
    }
<<<<<<< HEAD
=======

>>>>>>> ad7ae01 (Luu tam)
}
