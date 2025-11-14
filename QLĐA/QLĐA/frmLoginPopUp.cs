using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLĐA
{
    public partial class frmLoginPopUp : Form
    {
        private string connectionString = "Data Source=DESKTOP-OREV608\\SQLEXPRESS;Initial Catalog=qlđatn_final;Integrated Security=True;Encrypt=False";

        // Properties để lưu thông tin đăng nhập
        public string LoggedInUserType { get; private set; }
        public string LoggedInUserId { get; private set; }
        public string LoggedInUserName { get; private set; }
        public bool LoginSuccess { get; private set; }

        public frmLoginPopUp()
        {
            InitializeComponent();
            LoginSuccess = false;
            
            // Gắn sự kiện
            this.btnDangNhap.Click += new EventHandler(btnDangNhap_Click);
            this.btnThoat.Click += new EventHandler(btnThoat_Click);
            this.chkShowPassword.CheckedChanged += new EventHandler(chkShowPassword_CheckedChanged);
            
            // Cấu hình form
            txtMatKhau.UseSystemPasswordChar = true;
            this.AcceptButton = btnDangNhap; // Nhấn Enter = Đăng nhập
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string username = txtTenDangNhap.Text.Trim();
            string password = txtMatKhau.Text.Trim();

            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenDangNhap.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhau.Focus();
                return;
            }

            // Kiểm tra mật khẩu cố định
            if (password != "123456")
            {
                MessageBox.Show("Mật khẩu không đúng!", "Lỗi đăng nhập",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMatKhau.Clear();
                txtMatKhau.Focus();
                return;
            }

            // Xác thực với database
            AuthenticateUser(username);
        }

        private void AuthenticateUser(string username)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"SELECT Ma_tai_khoan, Ten_dang_nhap, Loai_nguoi_dung, 
                                     Ma_sinh_vien, Ma_giang_vien 
                                     FROM Tai_khoan 
                                     WHERE Ten_dang_nhap = @username";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string loaiNguoiDung = reader["Loai_nguoi_dung"]?.ToString()?.ToLower() ?? "";
                                string maNguoiDung = "";

                                // Xác định mã người dùng
                                if (reader["Ma_sinh_vien"] != DBNull.Value)
                                {
                                    maNguoiDung = reader["Ma_sinh_vien"].ToString();
                                }
                                else if (reader["Ma_giang_vien"] != DBNull.Value)
                                {
                                    maNguoiDung = reader["Ma_giang_vien"].ToString();
                                }

                                // Lưu thông tin đăng nhập
                                LoggedInUserType = loaiNguoiDung;
                                LoggedInUserId = maNguoiDung;
                                LoggedInUserName = username;
                                LoginSuccess = true;

                                // Thông báo thành công
                                string roleDisplay = "";
                                if (loaiNguoiDung.Contains("sinh viên") || loaiNguoiDung.Contains("sinh_vien"))
                                    roleDisplay = "Sinh viên";
                                else if (loaiNguoiDung.Contains("giảng viên") || loaiNguoiDung.Contains("giang_vien"))
                                    roleDisplay = "Giảng viên";
                                else if (loaiNguoiDung.Contains("trưởng khoa") || loaiNguoiDung.Contains("truong_khoa"))
                                    roleDisplay = "Trưởng khoa";
                                else if (loaiNguoiDung.Contains("admin"))
                                    roleDisplay = "Quản trị viên";

                                MessageBox.Show(
                                    "Đăng nhập thành công!",
                                    "Thành công",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information
                                );

                                this.DialogResult = DialogResult.OK;
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Tên đăng nhập không tồn tại trong hệ thống!",
                                    "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtTenDangNhap.Focus();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kết nối: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            LoginSuccess = false;
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar = !chkShowPassword.Checked;
        }
    }
}