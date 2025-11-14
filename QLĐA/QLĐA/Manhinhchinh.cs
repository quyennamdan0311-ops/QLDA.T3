using DevExpress.XtraBars;
using System;
using System.Windows.Forms;

namespace QLĐA
{
    public partial class Manhinhchinh : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        private string currentUserType = "";
        private string currentUserId = "";
        private string currentUserName = "";

        // Constructor mặc định (giữ lại để tránh lỗi Designer)
        public Manhinhchinh()
        {
            InitializeComponent();
        }

        // Constructor với thông tin đăng nhập
        public Manhinhchinh(string userType, string userId, string userName) : this()
        {
            currentUserType = userType?.ToLower() ?? "";
            currentUserId = userId;
            currentUserName = userName;

            // Cấu hình khi form load
            this.Load += Manhinhchinh_Load;
        }

        private void Manhinhchinh_Load(object sender, EventArgs e)
        {
            // Hiển thị thông tin người dùng trên status bar (nếu có)
            this.Text = $"Quản lý đồ án - Xin chào: {currentUserName}";

            // Cấu hình menu theo quyền
            ConfigureMenuByRole();

            // Hiển thị UC thông tin cá nhân tương ứng
            ShowPersonalInfo();
        }

        private void ConfigureMenuByRole()
        {
            // Ẩn tất cả menu trước
            btnCapNhatDoAn.Visible = false;
            btnQuanLyThongTinSinhVien.Visible = false;
            btnQuanLyThongTinGV.Visible = false;
            btnQLDA.Visible = false;
            btnQuanLyPhanQuyen.Visible = false;
            btnBaoCao.Visible = false;

            if (currentUserType.Contains("sinh viên") || currentUserType.Contains("sinh_vien") || currentUserType == "sinhvien")
            {
                // === SINH VIÊN ===
                // Chỉ có quyền: Thông tin cá nhân, Tra cứu
                btnThongTinCaNhan.Visible = true;
                btnTraCuu.Visible = true;

                btnCapNhatDoAn.Visible = false;
                btnQuanLyThongTinSinhVien.Visible = false;
                btnQuanLyThongTinGV.Visible = false;
                btnQLDA.Visible = false;
                btnQuanLyPhanQuyen.Visible = false;
                btnBaoCao.Visible = false;
            }
            else if (currentUserType.Contains("giảng viên") || currentUserType.Contains("giang_vien") || currentUserType == "giangvien")
            {
                // === GIẢNG VIÊN ===
                // Có quyền: Thông tin cá nhân, Tra cứu, Cập nhật đồ án
                btnThongTinCaNhan.Visible = true;
                btnTraCuu.Visible = true;
                btnCapNhatDoAn.Visible = true;

                btnQuanLyThongTinSinhVien.Visible = false;
                btnQuanLyThongTinGV.Visible = false;
                btnQLDA.Visible = false;
                btnQuanLyPhanQuyen.Visible = false;
                btnBaoCao.Visible = false;
            }
            else if (currentUserType.Contains("trưởng khoa") || currentUserType.Contains("truong_khoa") || 
                     currentUserType == "truongkhoa" || currentUserType == "admin")
            {
                // === TRƯỞNG KHOA / ADMIN ===
                // Có tất cả quyền
                btnThongTinCaNhan.Visible = true;
                btnTraCuu.Visible = true;
                btnCapNhatDoAn.Visible = false;
                btnQuanLyThongTinSinhVien.Visible = true;
                btnQuanLyThongTinGV.Visible = true;
                btnQLDA.Visible = true;
                btnQuanLyPhanQuyen.Visible = true;
                btnBaoCao.Visible = true;
            }
        }

        private void ShowPersonalInfo()
        {
            UserControl uc = null;

            if (currentUserType.Contains("sinh viên") || currentUserType.Contains("sinh_vien") || currentUserType == "sinhvien")
            {
                uc = new UC_TTSinhVien(currentUserId);
            }
            else if (currentUserType.Contains("giảng viên") || currentUserType.Contains("giang_vien") || currentUserType == "giangvien")
            {
                uc = new UC_TTGiangVien(currentUserId);
            }
            else if (currentUserType.Contains("trưởng khoa") || currentUserType.Contains("truong_khoa") || 
                     currentUserType == "truongkhoa" || currentUserType == "admin")
            {
                uc = new UC_TTTruongKhoa(currentUserId);
            }

            if (uc != null)
            {
                LoadUserControl(uc);
            }
        }

        // Method để load UserControl vào container
        private void LoadUserControl(UserControl userControl)
        {
            fluentDesignFormContainer1.Controls.Clear();
            userControl.Dock = DockStyle.Fill;
            fluentDesignFormContainer1.Controls.Add(userControl);
            userControl.BringToFront();
        }

        // === SỰ KIỆN CÁC NÚT MENU ===

        private void accordionControlElement7_Click(object sender, EventArgs e)
        {
            // Nút "Thông tin cá nhân"
            ShowPersonalInfo();
        }

        private void btnTraCuu_Click(object sender, EventArgs e)
        {
            UC_TraCuu ucTraCuu = new UC_TraCuu();
            LoadUserControl(ucTraCuu);
        }

        private void btnQuanLyThongTinSinhVien_Click(object sender, EventArgs e)
        {
            UC_CapNhatSinhVien uC_CapNhatSinhVien = new UC_CapNhatSinhVien();
            LoadUserControl(uC_CapNhatSinhVien);
        }

        private void btnQuanLyThongTinGV_Click(object sender, EventArgs e)
        {
            UC_CapNhatGiangVien uC_CapNhatGiangVien = new UC_CapNhatGiangVien();
            LoadUserControl(uC_CapNhatGiangVien);
        }

        private void btnQLDA_Click(object sender, EventArgs e)
        {
            UC_QuanLyDoAn uC_QuanLyDoAn = new UC_QuanLyDoAn();
            LoadUserControl(uC_QuanLyDoAn);
        }

        private void btnQuanLyPhanQuyen_Click(object sender, EventArgs e)
        {
            UC_QuanLyPhanQuyen uC_QuanLyPhanQuyen = new UC_QuanLyPhanQuyen();
            LoadUserControl(uC_QuanLyPhanQuyen);
        }

        private void btnCapNhatDoAn_Click(object sender, EventArgs e)
        {
            
           
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
 
        }

        // === CÁC SỰ KIỆN KHÁC ===

        private void accordionControlElement1_Click(object sender, EventArgs e)
        {
            // Có thể để trống
        }

        private void fluentDesignFormContainer1_Click(object sender, EventArgs e)
        {
            // Có thể để trống
        }

        private void barStaticItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            // Có thể để trống
        }

        private void btnDangXuat_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
     "Bạn có chắc chắn muốn đăng xuất?",
     "Xác nhận đăng xuất",
     MessageBoxButtons.YesNo,
     MessageBoxIcon.Question
 );

            if (result == DialogResult.Yes)
            {
                // Đóng form hiện tại và quay lại màn hình đăng nhập
                this.Close();
            }

        }

        private void btnCapNhatDoAn_Click_1(object sender, EventArgs e)
        {
            UC_Capnhatdoan uC_Capnhatdoan = new UC_Capnhatdoan(currentUserId);
            LoadUserControl(uC_Capnhatdoan);

        }

        private void btnSaoLuu_Click(object sender, EventArgs e)
        {
            UC_Saoluu uC_Saoluu = new UC_Saoluu();
            LoadUserControl(uC_Saoluu);
        }
    }
}
