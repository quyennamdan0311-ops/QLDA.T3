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
    public partial class uctDanhSachBaoCao : UserControl
    {
        public uctDanhSachBaoCao()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;

            // gán sự kiện click cho mọi control con
            lblBCChuyenNganh.Click += pnBCChuyenNganh_Click;
            picCN.Click += pnBCChuyenNganh_Click;
            // ===== KHỐI 1: BÁO CÁO THEO CHUYÊN NGÀNH =====
            pnBCChuyenNganh.Cursor = Cursors.Hand;
            pnBCChuyenNganh.Click += pnBCChuyenNganh_Click;

            lblBCChuyenNganh.Cursor = Cursors.Hand;
            lblBCChuyenNganh.Click += pnBCChuyenNganh_Click;

            // nếu có icon / label phụ thì gán thêm:
            // picCN.Cursor = Cursors.Hand;
            // picCN.Click += pnBCChuyenNganh_Click;
            // lblBCChuyenNganhSV.Click += pnBCChuyenNganh_Click;
            // lblBCChuyenNganhNamKy.Click += pnBCChuyenNganh_Click;

            // ===== KHỐI 2: BÁO CÁO THEO GIẢNG VIÊN =====
            pnBCGiangVien.Cursor = Cursors.Hand;
            pnBCGiangVien.Click += pnBCGiangVien_Click;

            lblBCGiangVien.Cursor = Cursors.Hand;
            lblBCGiangVien.Click += pnBCGiangVien_Click;
            // gán thêm cho icon / label phụ nếu có

            // ===== KHỐI 3: BÁO CÁO TỔNG HỢP THEO NĂM/KỲ =====
            pnBCNamKy.Cursor = Cursors.Hand;
            pnBCNamKy.Click += pnBCNamKy_Click;

            lblBCNamKy.Cursor = Cursors.Hand;
            lblBCNamKy.Click += pnBCNamKy_Click;
            // gán thêm cho icon / label phụ nếu có
        }
        private void uctDanhSachBaoCao_Load(object sender, EventArgs e)
        {
            
        }

        private void pnHeader_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnBCChuyenNganh_Click(object sender, EventArgs e)
        {
            // TODO: sau này mở form báo cáo chi tiết
            frmBCDeTaiChuyenNganh f = new frmBCDeTaiChuyenNganh();
            f.ShowDialog();

            MessageBox.Show("Mở báo cáo đề tài theo chuyên ngành.");
        }

        private void pnBCGiangVien_Click(object sender, EventArgs e)
        {
            // TODO: sau này mở form báo cáo chi tiết theo giảng viên
             frmBaoCaoGiangVien f = new frmBaoCaoGiangVien();
             f.ShowDialog();

            MessageBox.Show("Mở báo cáo đề tài theo giảng viên.");
        }

        private void pnBCNamKy_Click(object sender, EventArgs e)
        {
            // TODO: sau này mở form báo cáo tổng hợp
             frmBaoCaoThongKe f = new frmBaoCaoThongKe();
             f.ShowDialog();

            MessageBox.Show("Mở báo cáo đề tài tổng hợp theo năm/kỳ.");
        }

        private void pnBCGiangVien_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnBCChuyenNganh_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnBCNamKy_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
