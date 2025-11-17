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

            // ===== CHỈ GÁN CURSOR VÀ CLICK CHO CÁC CONTROL CON =====
         
            
            lblBCChuyenNganh.Cursor = Cursors.Hand;
            lblBCChuyenNganh.Click += pnBCChuyenNganh_Click;

            picCN.Cursor = Cursors.Hand;
            picCN.Click += pnBCChuyenNganh_Click;

            lblBCGiangVien.Cursor = Cursors.Hand;
            lblBCGiangVien.Click += pnBCGiangVien_Click;

            lblBCNamKy.Cursor = Cursors.Hand;
            lblBCNamKy.Click += pnBCNamKy_Click;
        }

        private void uctDanhSachBaoCao_Load(object sender, EventArgs e)
        {
            
        }

        private void pnHeader_Paint(object sender, PaintEventArgs e)
        {

        }

        
        // XỬ LÝ MỞ BÁO CÁO THEO CHUYÊN NGÀNH
      
        private void pnBCChuyenNganh_Click(object sender, EventArgs e)
        {
            try
            {
                using (frmBCDeTaiChuyenNganh f = new frmBCDeTaiChuyenNganh())
                {
                    f.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi mở báo cáo chuyên ngành: " + ex.Message, 
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
        // XỬ LÝ MỞ BÁO CÁO THEO GIẢNG VIÊN
      
        private void pnBCGiangVien_Click(object sender, EventArgs e)
        {
            try
            {
                using (frmBaoCaoGiangVien f = new frmBaoCaoGiangVien())
                {
                    f.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi mở báo cáo giảng viên: " + ex.Message, 
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
        // XỬ LÝ MỞ BÁO CÁO TỔNG HỢP THEO NĂM/KỲ
       
        private void pnBCNamKy_Click(object sender, EventArgs e)
        {
            try
            {
                using (frmBaoCaoThongKe f = new frmBaoCaoThongKe())
                {
                    f.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi mở báo cáo thống kê: " + ex.Message, 
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
