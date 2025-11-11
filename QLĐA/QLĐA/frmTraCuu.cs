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
    public partial class frmTraCuu : DevExpress.XtraEditors.XtraForm
    {
        public frmTraCuu()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        
        private string currentPlaceholder = "";

        // ===== XỬ LÝ RADIOBUTTON =====
        private void rdoSinhVien_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoSinhVien != null && rdoSinhVien.Checked)
            {
                UpdateSearchCriteria("SinhVien");
                ShowPanel("SinhVien");
                txtTuKhoa?.Focus();
            }
        }

        private void rdoGiangVien_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoGiangVien != null && rdoGiangVien.Checked)
            {
                UpdateSearchCriteria("GiangVien");
                ShowPanel("GiangVien");
                txtTuKhoa?.Focus();
            }
        }

        private void rdoDoAn_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoDoAn != null && rdoDoAn.Checked)
            {
                UpdateSearchCriteria("DoAn");
                ShowPanel("DoAn");
                txtTuKhoa?.Focus();
            }
        }

        // ===== CẬP NHẬT TIÊU CHÍ TÌM KIẾM =====
        private void UpdateSearchCriteria(string objectType)
        {
            if (cboTieuChi == null) return;

            cboTieuChi.Items.Clear();

            switch (objectType)
            {
                case "SinhVien":
                    cboTieuChi.Items.AddRange(new object[] {
                "Mã sinh viên",
                "Họ và tên",
                "Lớp",
                "Khoa",
                "Năm học"
            });
                    UpdatePlaceholder("Nhập mã hoặc tên sinh viên...");
                    break;

                case "GiangVien":
                    cboTieuChi.Items.AddRange(new object[] {
                "Mã giảng viên",
                "Họ và tên",
                "Bằng cấp",
                "Chức danh",
                "Email"
            });
                    UpdatePlaceholder("Nhập mã hoặc tên giảng viên...");
                    break;

                case "DoAn":
                    cboTieuChi.Items.AddRange(new object[] {
                "Mã đồ án",
                "Tên đồ án",
                "Ngày nộp",
                "Học kỳ",
                "Năm học"
            });
                    UpdatePlaceholder("Nhập mã hoặc tên đồ án...");
                    break;
            }

            cboTieuChi.SelectedIndex = 0;
        }

        private void UpdatePlaceholder(string text)
        {
            if (txtTuKhoa == null) return;

            // Remove old event handlers to prevent duplicates
            txtTuKhoa.GotFocus -= TxtTuKhoa_GotFocus;
            txtTuKhoa.LostFocus -= TxtTuKhoa_LostFocus;

           
            currentPlaceholder = text;

           
            txtTuKhoa.Text = currentPlaceholder;
            txtTuKhoa.ForeColor = Color.Gray;

       
            txtTuKhoa.GotFocus += TxtTuKhoa_GotFocus;
            txtTuKhoa.LostFocus += TxtTuKhoa_LostFocus;
        }

        private void TxtTuKhoa_GotFocus(object sender, EventArgs e)
        {
            if (txtTuKhoa.Text == currentPlaceholder)
            {
                txtTuKhoa.Text = "";
                txtTuKhoa.ForeColor = Color.Black;
            }
        }

        private void TxtTuKhoa_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTuKhoa.Text))
            {
                txtTuKhoa.Text = currentPlaceholder;
                txtTuKhoa.ForeColor = Color.Gray;
            }
        }
        private void ShowPanel(string panelType)
        {
            // Ẩn tất cả các panel trước
            if (pnlSinhVien != null) pnlSinhVien.Visible = false;
            if (pnlGiangVien != null) pnlGiangVien.Visible = false;
            if (pnlDoAn != null) pnlDoAn.Visible = false;

            // Hiển thị panel được chọn
            switch (panelType)
            {
                case "SinhVien":
                    if (pnlSinhVien != null) pnlSinhVien.Visible = true;
                    break;

                case "GiangVien":
                    if (pnlGiangVien != null) pnlGiangVien.Visible = true;
                    break;

                case "DoAn":
                    if (pnlDoAn != null) pnlDoAn.Visible = true;
                    break;
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvTraCuu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pnlDoAn_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pnlGiangVien_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlSinhVien_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    }