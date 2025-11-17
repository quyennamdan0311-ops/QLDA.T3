using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLĐA
{
    public partial class frmLoginPopUp : Form
    {
        private string connectionString = "Data Source=DESKTOP-OREV608\\SQLEXPRESS;Initial Catalog=qldatn_final;Integrated Security=True;Encrypt=False";

        // Properties để lưu thông tin đăng nhập
        public string LoggedInUserType { get; private set; }
        public string LoggedInUserId { get; private set; }
        public string LoggedInUserName { get; private set; }
        public bool LoginSuccess { get; private set; }
        public string UserEntityType { get; private set; } // "SinhVien" hoặc "GiangVien"

        public frmLoginPopUp()
        {
            InitializeComponent();
            LoginSuccess = false;
            
            
            this.btnDangNhap.Click += new EventHandler(btnDangNhap_Click);
            this.btnThoat.Click += new EventHandler(btnThoat_Click);
            this.chkShowPassword.CheckedChanged += new EventHandler(chkShowPassword_CheckedChanged);
            
            
            txtMatKhau.UseSystemPasswordChar = true;
            this.AcceptButton = btnDangNhap; 
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

           
            AuthenticateUser(username);
        }

        private void AuthenticateUser(string username)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Lấy thông tin tài khoản và vai trò từ bảng TK_vai_tro
                    string query = @"SELECT TK.Ma_tai_khoan, TK.Ten_dang_nhap, 
                                     VT.Ten_vai_tro as Loai_nguoi_dung,
                                     TK.Ma_sinh_vien, TK.Ma_giang_vien 
                                     FROM Tai_khoan TK
                                     LEFT JOIN TK_vai_tro TKV ON TK.Ma_tai_khoan = TKV.Ma_tai_khoan
                                     LEFT JOIN Vai_tro VT ON TKV.Ma_vai_tro = VT.Ma_vai_tro
                                     WHERE TK.Ten_dang_nhap = @username";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Lấy vai trò từ bảng Vai_tro (thông qua TK_vai_tro)
                                string loaiNguoiDung = reader["Loai_nguoi_dung"]?.ToString()?.ToLower() ?? "";
                                
                                // Nếu không có vai trò trong TK_vai_tro, báo lỗi
                                if (string.IsNullOrEmpty(loaiNguoiDung))
                                {
                                    MessageBox.Show("Tài khoản chưa được phân quyền!\nVui lòng liên hệ quản trị viên.",
                                        "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    txtTenDangNhap.Focus();
                                    return;
                                }

                                string maNguoiDung = "";
                                string entityType = "";

                                // Xác định loại thực thể (Sinh viên hay Giảng viên)
                                if (reader["Ma_sinh_vien"] != DBNull.Value)
                                {
                                    maNguoiDung = reader["Ma_sinh_vien"].ToString();
                                    entityType = "SinhVien";
                                }
                                else if (reader["Ma_giang_vien"] != DBNull.Value)
                                {
                                    maNguoiDung = reader["Ma_giang_vien"].ToString();
                                    entityType = "GiangVien";
                                }

                                LoggedInUserType = loaiNguoiDung;
                                LoggedInUserId = maNguoiDung;
                                LoggedInUserName = username;
                                UserEntityType = entityType; 
                                LoginSuccess = true;

                                conn.Close();

                                MessageBox.Show(
                                    $"Đăng nhập thành công!",
                                    "Thành công",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information
                                );

                                this.Hide();

                                // Truyền thêm UserEntityType
                                Manhinhchinh mainForm = new Manhinhchinh(
                                    LoggedInUserType, 
                                    LoggedInUserId, 
                                    LoggedInUserName,
                                    UserEntityType);
                                mainForm.ShowDialog();

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