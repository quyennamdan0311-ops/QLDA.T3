using DevExpress.XtraBars;
using DevExpress.XtraEditors;
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
    public partial class frmStudent : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        // <<< THÊM VÀO: Biến để lưu thông tin của sinh viên đang đăng nhập >>>
        private UserSession currentUser;

        // <<< SỬA LẠI: Constructor để nhận đối tượng UserSession từ frmLogin >>>
        public frmStudent(UserSession user)
        {
            InitializeComponent();
            this.currentUser = user; // Lưu lại thông tin người dùng
        }

        // <<< THÊM VÀO: Sự kiện Form_Load để hiển thị thông tin cá nhân hóa >>>
        private void frmStudent_Load(object sender, EventArgs e)
        {
            // Kiểm tra để đảm bảo currentUser không bị null
            if (currentUser == null)
            {
                XtraMessageBox.Show("Không có thông tin người dùng hợp lệ. Vui lòng đăng nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
        
            // Nếu bạn có một textbox trên form (ví dụ txtMaSV), bạn cũng có thể gán giá trị
            txtMaSV.Text = currentUser.MaNguoiDung;
            txtMaSV.ReadOnly = true; // Nên để ở chế độ chỉ đọc

            LoadStudentProfile();
        }
        private void LoadStudentProfile()
        {
            try
            {
                DataAccess db = new DataAccess();
                // Gọi phương thức trong DataAccess để lấy thông tin chi tiết
                StudentProfile profile = db.LayThongTinSinhVien(currentUser.MaNguoiDung);

                if (profile != null)
                {
                    // === ĐỔ DỮ LIỆU VÀO KHU VỰC "THÔNG TIN CÁ NHÂN" ===
                    // (Hãy đảm bảo tên các control như txtMaSV, txtHoTen... khớp với tên trong form của bạn)
                    lblHoTen.Caption = $"Xin chào: {profile.ThongTinCaNhan.HoTen}";
                    txtMaSV.Text = profile.ThongTinCaNhan.MaSinhVien;
                    txtHoTen.Text = profile.ThongTinCaNhan.HoTen;
                    txtGioiTinh.Text = profile.ThongTinCaNhan.GioiTinh;
                    txtLopNienChe.Text = profile.ThongTinCaNhan.Lop;
                    txtKhoa.Text = profile.ThongTinCaNhan.Khoa;
                    txtSDT.Text = profile.ThongTinCaNhan.SoDienThoai;
                    txtEmail.Text = profile.ThongTinCaNhan.Email;

                    // === ĐỔ DỮ LIỆU VÀO KHU VỰC "THÔNG TIN ĐỒ ÁN TỐT NGHIỆP" ===
                    if (profile.ThongTinDoAn != null) // Chỉ hiển thị nếu sinh viên có đồ án
                    {
                        txtMaDoAn.Text = profile.ThongTinDoAn.MaDoAn;
                        txtTenDoAn.Text = profile.ThongTinDoAn.TenDeTai;
                        txtMoTa.Text = profile.ThongTinDoAn.MoTa;
                        txtGVHD.Text = profile.ThongTinDoAn.TenGiangVien;
                        txtNgayNop.Text = profile.ThongTinDoAn.NgayNop?.ToString("dd/MM/yyyy");
                        txtHocKy.Text = profile.ThongTinDoAn.HocKy;
                        txtNam.Text = profile.ThongTinDoAn.Nam?.ToString();
                    }
                    else
                    {
                        // Xử lý trường hợp sinh viên chưa có đồ án
                        txtMaDoAn.Text = "(Chưa đăng ký đồ án)";
                    }
                }
                else
                {
                    XtraMessageBox.Show("Không tìm thấy thông tin chi tiết cho sinh viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                // Bắt lỗi từ lớp DataAccess và hiển thị
                XtraMessageBox.Show("Không thể tải dữ liệu từ cơ sở dữ liệu.\nLỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnLogout_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Đăng xuất khỏi phiên làm việc?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                using (var login = new frmLogin()) login.ShowDialog();
                this.Close(); // đóng form hiện tại sau khi login form xong
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            barStaticItem2.Caption = System.DateTime.Now.ToString(); 
        }

        private void lblHoTen_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnTraCuu_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (frmTraCuu frm = new frmTraCuu())
            {
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog();
            }
        }

        private void txtMaSV_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLopNienChe_TextChanged(object sender, EventArgs e)
        {

        }
    }
}