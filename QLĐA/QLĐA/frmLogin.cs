using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLĐA
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            // 1. Lấy thông tin từ các textbox
            // (Giả sử tên textbox của bạn là txtUsername và txtPassword)
            string tenDangNhap = txtUsername.Text.Trim();
            string matKhau = txtPassword.Text;

            // 2. Kiểm tra xem người dùng đã nhập đủ thông tin chưa
            if (string.IsNullOrWhiteSpace(tenDangNhap) || string.IsNullOrWhiteSpace(matKhau))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Dừng lại nếu chưa nhập đủ
            }

            // 3. Gọi lớp DataAccess để kiểm tra đăng nhập
            DataAccess db = new DataAccess();
            UserSession loggedInUser = db.KiemTraDangNhap(tenDangNhap, matKhau);

            // 4. Xử lý kết quả trả về
            if (loggedInUser != null)
            {
                // Đăng nhập thành công!
                this.Hide(); // Ẩn form đăng nhập đi

                // 5. PHÂN QUYỀN: Mở form tương ứng với vai trò của người dùng
                switch (loggedInUser.LoaiNguoiDung)
                {
                    case "SinhVien":
                        frmStudent formSV = new frmStudent(loggedInUser);
                        formSV.ShowDialog(); // ShowDialog sẽ đợi form này đóng rồi mới chạy code tiếp theo
                        break;

                    case "GiangVien":
                        // Bạn sẽ tạo formGiangVien sau
                        // frmGiangVien formGV = new frmGiangVien(loggedInUser);
                        // formGV.ShowDialog();
                        MessageBox.Show($"Chào mừng Giảng viên {loggedInUser.MaNguoiDung}!"); // Thông báo tạm thời
                        break;

                    case "TruongKhoa":
                        // Bạn sẽ tạo formTruongKhoa sau
                        // frmTruongKhoa formTK = new frmTruongKhoa(loggedInUser);
                        // formTK.ShowDialog();
                        MessageBox.Show($"Chào mừng Trưởng khoa {loggedInUser.MaNguoiDung}!"); // Thông báo tạm thời
                        break;

                    default:
                        MessageBox.Show("Vai trò của tài khoản không được hỗ trợ.", "Lỗi phân quyền", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }

                // Sau khi form chính (SinhVien, GiangVien...) đóng, thì đóng luôn form Login (để kết thúc chương trình)
                this.Close();
            }
            else
            {
                // Đăng nhập thất bại
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác.", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
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
    }
}
