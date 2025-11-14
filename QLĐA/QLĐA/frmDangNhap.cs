using DevExpress.XtraBars;
using QLĐA;
using System;
using System.Windows.Forms;

namespace Project_QLDA
{
    public partial class frmDangNhap : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            
        }

        private void btnDangNhap_ItemClick_2(object sender, ItemClickEventArgs e)
        {
                try
            {
                using (frmLoginPopUp frmLogin = new frmLoginPopUp())
                {
                    if (frmLogin.ShowDialog() == DialogResult.OK && frmLogin.LoginSuccess)
                    {
                        // Đăng nhập thành công
                        // Ẩn form đăng nhập hiện tại
                        this.Hide();

                        // Mở màn hình chính với thông tin user
                        using (Manhinhchinh mainForm = new Manhinhchinh(
                            frmLogin.LoggedInUserType,
                            frmLogin.LoggedInUserId,
                            frmLogin.LoggedInUserName
                        ))
                        {
                            // Hiển thị màn hình chính (modal)
                            mainForm.ShowDialog();
                        }

                        // Nếu form đã bị dispose (ví dụ do Application.Restart hoặc restore), không tiếp tục thao tác trên nó
                        if (this.IsDisposed || this.Disposing)
                            return;

                        // Sau khi đóng màn hình chính, kiểm tra có muốn đăng nhập lại không
                        DialogResult result = MessageBox.Show(
                            "Bạn có muốn đăng nhập lại?",
                            "Đăng nhập",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question
                        );

                        if (result == DialogResult.Yes)
                        {
                            // Nếu form vẫn hợp lệ thì hiển thị lại form đăng nhập
                            if (!this.IsDisposed && !this.Disposing)
                                this.Show();
                        }
                        else
                        {
                            // Nếu form vẫn hợp lệ thì đóng ứng dụng
                            if (!this.IsDisposed && !this.Disposing)
                                this.Close();
                        }
                    }
                    else
                    {
                        // Người dùng hủy đăng nhập - không làm gì, form vẫn hiển thị
                    }
                }
            }
            catch (ObjectDisposedException)
            {
                
            }
        }

        private void btnExit_ItemClick(object sender, ItemClickEventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn thoát ứng dụng?",
                "Xác nhận thoát",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            barTimer.Caption = System.DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        // Các event handlers khác giữ nguyên
        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e) { }
        private void barButtonItem1_ItemClick_1(object sender, ItemClickEventArgs e) { }
        private void barButtonItem4_ItemClick(object sender, EventArgs e) { }
        private void barButtonItem2_ItemClick(object sender, EventArgs e) { }
        private void ribbon_Click(object sender, EventArgs e) { }
        private void btnTraCuuGiangVien_ItemClick(object sender, EventArgs e) { }
        private void btnTraCuuDoAn_ItemClick(object sender, EventArgs e) { }
        private void barButtonItem2_ItemClick_1(object sender, EventArgs e) { }
        private void barClock_ItemClick(object sender, EventArgs e) { }
        private void barTimer_ItemClick(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void label1_Click_1(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void pictureBox1_Click(object sender, EventArgs e) { }
        private void pictureBox2_Click(object sender, EventArgs e) { }
        private void ribbonStatusBar_Click(object sender, EventArgs e) { }
        private void btnTraCuu_ItemClick(object sender, EventArgs e) { }
    }
}