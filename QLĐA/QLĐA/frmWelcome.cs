using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLĐA
{
    public partial class frmWelcome : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public frmWelcome()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            // Ẩn form Welcome
            this.Hide();

            // Hiển thị form đăng nhập
            frmLoginPopUp loginForm = new frmLoginPopUp();
            DialogResult result = loginForm.ShowDialog();

            // Nếu đăng nhập thành công, đóng form Welcome
            // Nếu không, hiển thị lại form Welcome
            if (result == DialogResult.OK && loginForm.LoginSuccess)
            {
                // Đóng form Welcome vì đã đăng nhập thành công
                this.Close();
            }
            else
            {
                // Hiển thị lại form Welcome nếu hủy đăng nhập
                this.Show();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
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
    }
}
