using System;
using System.Windows.Forms;

namespace QLĐA
{
    public partial class frmTestUC : Form
    {
        public frmTestUC()
        {
         
            InitializeUserControl();

            // ✅ CHỈ GIỮ CÁC DÒNG NÀY
            this.Text = "Test UC_TraCuu";
            this.WindowState = FormWindowState.Maximized;
        }

        private void InitializeUserControl()
        {
            // Tạo instance của UC_TraCuu
            UC_TraCuu ucTraCuu = new UC_TraCuu();
            // Đặt UserControl fill toàn bộ form
            ucTraCuu.Dock = DockStyle.Fill;
            // Thêm UserControl vào form
            this.Controls.Add(ucTraCuu);
            // Đặt tiêu đề cho form
            this.Text = "Test UC_TraCuu";
            // Đặt kích thước form phù hợp
            this.WindowState = FormWindowState.Maximized;
            // Xử lý sự kiện CloseRequested (nếu có)

        }

        private void frmTestUC_Load(object sender, EventArgs e)
        {
            // Có thể để trống
        }

        private void uC_TraCuu1_Load(object sender, EventArgs e)
        {
            // Có thể để trống
        }
    }
}
