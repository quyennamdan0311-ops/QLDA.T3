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
        private string currentUserEntityType = ""; // "SinhVien" hoặc "GiangVien"

       
        public Manhinhchinh()
        {
            InitializeComponent();
        }

        // Constructor với thông tin đăng nhập
        public Manhinhchinh(string userType, string userId, string userName, string entityType) : this()
        {
            currentUserType = userType?.ToLower() ?? "";
            currentUserId = userId;
            currentUserName = userName;
            currentUserEntityType = entityType;
            
            this.Load += Manhinhchinh_Load;
        }

        private void Manhinhchinh_Load(object sender, EventArgs e)
        {
           
            this.Text = $"Quản lý đồ án - Xin chào: {currentUserName}";

       
            ConfigureMenuByRole();

         
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

            
            string role = currentUserType.Trim().ToLower();

            switch (role)
            {
                case "view_info_search":
                    // SINH VIÊN - Chỉ xem thông tin cá nhân và tra cứu
                    btnThongTinCaNhan.Visible = true;
                    btnTraCuu.Visible = true;
                    break;

                case "view_search_update_project":
                    // GIẢNG VIÊN - Xem, tra cứu và cập nhật đồ án
                    btnThongTinCaNhan.Visible = true;
                    btnTraCuu.Visible = true;
                    btnCapNhatDoAn.Visible = true;
                    break;

                case "fullaccess":
                    // ADMIN/TRƯỞNG KHOA - Toàn quyền
                    btnThongTinCaNhan.Visible = true;
                    btnTraCuu.Visible = true;
                    btnQuanLyThongTinSinhVien.Visible = true;
                    btnQuanLyThongTinGV.Visible = true;
                    btnQLDA.Visible = true;
                    btnQuanLyPhanQuyen.Visible = true;
                    btnBaoCao.Visible = true;
                    break;

                default:
                    // Vai trò không xác định
                    btnThongTinCaNhan.Visible = true;
                    btnTraCuu.Visible = true;
                    MessageBox.Show(
                        $"Vai trò '{currentUserType}' chưa được cấu hình.\n\n" +
                        "Chỉ có quyền xem Thông tin cá nhân và Tra cứu.",
                        "Cảnh báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    break;
            }
        }

        private void ShowPersonalInfo()
        {
            UserControl uc = null;

            // Dựa vào loại thực thể để load UC đúng
            switch (currentUserEntityType)
            {
                case "SinhVien":
                    uc = new UC_TTSinhVien(currentUserId);
                    break;

                case "GiangVien":
                    // Kiểm tra vai trò:
                    // - Nếu là fullaccess (trưởng khoa) 
                    // - Nếu không → dùng UC_TTGiangVien
                    if (currentUserType.Trim().ToLower() == "fullaccess")
                    {
                        uc = new UC_TTTruongKhoa(currentUserId);
                    }
                    else
                    {
                        uc = new UC_TTGiangVien(currentUserId);
                    }
                    break;

                default:
                    MessageBox.Show(
                        "Không xác định được loại người dùng!\n\n" +
                        "Vui lòng liên hệ quản trị viên.",
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
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

        // SỰ KIỆN CÁC NÚT MENU 

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

        
        private void accordionControlElement1_Click(object sender, EventArgs e)
        {
            
        }

        private void fluentDesignFormContainer1_Click(object sender, EventArgs e)
        {
            
        }

        private void barStaticItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            
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
                   
                    this.Hide();

                   
                    DialogResult loginAgainResult = MessageBox.Show(
                        "Bạn có muốn đăng nhập lại?",
                        "Đăng nhập lại",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    if (loginAgainResult == DialogResult.Yes)
                    {
                       
                        frmLoginPopUp loginForm = new frmLoginPopUp();
                        DialogResult loginResult = loginForm.ShowDialog();

                     
                        this.Close();
                    }
                    else
                    {
                       
                        this.Close();
                        Application.Exit();
                    }
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

        private void accordionControlElement2_Click(object sender, EventArgs e)
        {

        }

        private void accordionControlElement3_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Manhinhchinh_Load_1(object sender, EventArgs e)
        {

        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {                       
            uctDanhSachBaoCao uc_DanhSachBaoCao = new uctDanhSachBaoCao();
            LoadUserControl(uc_DanhSachBaoCao);
                                    
                                     
        }
    }
}
    