using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLĐA
{
    public partial class frmLogin : Form
    {
        private string connectionString ="Data Source=DESKTOP-OREV608\\SQLEXPRESS;Initial Catalog=qlđatn_final;Integrated Security=True;Encrypt=False";

        public frmLogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            // Kiểm tra input
            string username = txtUsername?.Text?.Trim() ?? "";
            string password = txtPassword?.Text?.Trim() ?? "";

            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername?.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword?.Focus();
                return;
            }

            // Xác thực đăng nhập
            AuthenticateUser(username, password);
        }

        private void AuthenticateUser(string username, string password)
        {
            // Kiểm tra mật khẩu chung
            if (password != "123456")
            {
                MessageBox.Show("Mật khẩu không đúng!", "Lỗi đăng nhập", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtPassword.Focus();
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Kiểm tra trong bảng Tai_khoan với Ten_dang_nhap
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

                                // Xác định mã người dùng dựa vào loại
                                if (reader["Ma_sinh_vien"] != DBNull.Value)
                                {
                                    maNguoiDung = reader["Ma_sinh_vien"].ToString();
                                }
                                else if (reader["Ma_giang_vien"] != DBNull.Value)
                                {
                                    maNguoiDung = reader["Ma_giang_vien"].ToString();
                                }

                                // Đóng reader trước khi mở form mới
                                reader.Close();

                                // Xác định form cần mở dựa trên loại người dùng
                                Form targetForm = null;
                                string loiChao = "";

                                if (loaiNguoiDung.Contains("sinh viên") || loaiNguoiDung.Contains("sinh_vien") || loaiNguoiDung == "sinhvien")
                                {
                                    loiChao = $"Đăng nhập thành công!";
                                    targetForm = new frmTTSinhVien(maNguoiDung);
                                }
                                else if (loaiNguoiDung.Contains("trưởng khoa") || loaiNguoiDung.Contains("truong_khoa") || loaiNguoiDung == "truongkhoa")
                                {
                                    loiChao = $"Đăng nhập thành công!";
                                    targetForm = new frmTTTruongKhoa(maNguoiDung);
                                }
                                else if (loaiNguoiDung.Contains("giảng viên") || loaiNguoiDung.Contains("giang_vien") || loaiNguoiDung == "giangvien")
                                {
                                    loiChao = $"Đăng nhập thành công!";
                                    targetForm = new frmTTGiangVien(maNguoiDung);
                                }
                                else if (loaiNguoiDung.Contains("admin") || loaiNguoiDung == "admin")
                                {
                                    loiChao = $"Đăng nhập thành công!!";
                                    // Mở form admin hoặc form trưởng khoa nếu admin dùng chung
                                    targetForm = new frmTTTruongKhoa(maNguoiDung);
                                }
                                else
                                {
                                    MessageBox.Show($"Loại người dùng '{loaiNguoiDung}' không được hỗ trợ!", "Lỗi",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }

                                if (targetForm != null)
                                {
                                    MessageBox.Show(loiChao, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Hide();
                                    targetForm.ShowDialog();
                                    this.Close();
                                }
                                return;
                            }
                            else
                            {
                                // Không tìm thấy tên đăng nhập
                                MessageBox.Show("Tên đăng nhập không tồn tại trong hệ thống!",
                                    "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtUsername.Focus();
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

        private void OpenFormByRole(string loaiNguoiDung, string maNguoiDung)
        {
            Form targetForm = null;

            switch (loaiNguoiDung.ToLower())
            {
                case "sinh viên":
                case "sinh_vien":
                case "sinhvien":
                    targetForm = new frmTTSinhVien(maNguoiDung);
                    break;

                case "giảng viên":
                case "giang_vien":
                case "giangvien":
                    targetForm = new frmTTGiangVien(maNguoiDung);
                    break;

                case "trưởng khoa":
                case "truong_khoa":
                case "truongkhoa":
                    targetForm = new frmTTTruongKhoa(maNguoiDung);
                    break;

                default:
                    MessageBox.Show($"Loại người dùng '{loaiNguoiDung}' không được hỗ trợ!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Show();
                    return;
            }

            if (targetForm != null)
            {
                targetForm.ShowDialog();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void linkForgot_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show(
                 "Vui lòng liên hệ với giảng viên chủ nhiệm để lấy lại mật khẩu.",
                 "Thông báo",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Information
            );
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }

        // Cho phép nhấn Enter để đăng nhập
        private void frmLogin_Load(object sender, EventArgs e)
        {
            this.AcceptButton = btnDangNhap; // Nhấn Enter = Click nút Đăng nhập
            txtPassword.UseSystemPasswordChar = true; // Ẩn mật khẩu mặc định
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
