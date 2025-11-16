using DevExpress.CodeParser;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLĐA
{
    public partial class frmBCDeTaiChuyenNganh : Form
    {
        SqlConnection conn = new SqlConnection(
            Properties.Settings.Default.qldatn_final_4ConnectionString);

        public frmBCDeTaiChuyenNganh()
        {
            InitializeComponent();
            // KHÔNG khởi tạo lại conn ở đây nữa
        }



        private void btnXemBaoCao_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = @"
            SELECT 
                da.Ma_do_an ,
                da.Ten_de_tai ,
                sv.Ma_sinh_vien ,
                sv.Ho_ten ,
                sv.Lop ,
                cn.Ten_chuyen_nganh ,
                gv.Ho_ten_gv ,
                da.Hoc_ky ,
                da.Nam 
            FROM Do_an da
            INNER JOIN Sinh_vien sv ON da.Ma_sinh_vien = sv.Ma_sinh_vien
            INNER JOIN Chuyen_nganh cn ON sv.Ma_chuyen_nganh = cn.Ma_chuyen_nganh
            LEFT JOIN Giang_vien gv ON sv.Ma_giang_vien = gv.Ma_giang_vien
            WHERE 1 = 1
        ";

                List<string> dkText = new List<string>();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;

                    // Lọc chuyên ngành
                    if (!chkAllChuyenNganh.Checked)
                    {
                        sql += " AND cn.Ma_chuyen_nganh = @MaCN";
                        cmd.Parameters.AddWithValue("@MaCN", cboChuyenNganh.SelectedValue);
                        dkText.Add("Chuyên ngành = " + cboChuyenNganh.Text);
                    }
                    else
                    {
                        dkText.Add("Chuyên ngành = Tất cả");
                    }

                    sql += " ORDER BY cn.Ten_chuyen_nganh, da.Nam, da.Hoc_ky";

                    cmd.CommandText = sql;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvBaoCaoCN.DataSource = dt;

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Không có dữ liệu phù hợp với điều kiện lọc.");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xem báo cáo: " + ex.Message);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkAllChuyenNganh_CheckedChanged(object sender, EventArgs e)
        {
            cboChuyenNganh.Enabled = !chkAllChuyenNganh.Checked;
        }

        private void frmBCDeTaiChuyenNganh_Load(object sender, EventArgs e)
        {
            LoadChuyenNganh();

        }

        // ====== LOAD DỮ LIỆU LỌC ======

        private void LoadChuyenNganh()
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(conn.ConnectionString))
                {
                    string sql = "SELECT Ma_chuyen_nganh, Ten_chuyen_nganh FROM Chuyen_nganh";
                    SqlDataAdapter da = new SqlDataAdapter(sql, cn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cboChuyenNganh.DataSource = dt;
                    cboChuyenNganh.DisplayMember = "Ten_chuyen_nganh";
                    cboChuyenNganh.ValueMember = "Ma_chuyen_nganh";

                    if (dt.Rows.Count > 0)
                        cboChuyenNganh.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load chuyên ngành: " + ex.Message);
            }
        }





        private void btnInBaoCao_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = @"
            SELECT 
                da.Ma_do_an ,
                da.Ten_de_tai ,
                sv.Ma_sinh_vien ,
                sv.Ho_ten ,
                sv.Lop  ,
                cn.Ten_chuyen_nganh ,
                gv.Ho_ten_gv ,
                da.Hoc_ky ,
                da.Nam 
            FROM Do_an da
            INNER JOIN Sinh_vien sv ON da.Ma_sinh_vien = sv.Ma_sinh_vien
            INNER JOIN Chuyen_nganh cn ON sv.Ma_chuyen_nganh = cn.Ma_chuyen_nganh
            LEFT JOIN Giang_vien gv ON sv.Ma_giang_vien = gv.Ma_giang_vien
            WHERE 1 = 1
        ";

                List<string> dkText = new List<string>();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;

                    // Lọc chuyên ngành
                    if (!chkAllChuyenNganh.Checked)
                    {
                        sql += " AND cn.Ma_chuyen_nganh = @MaCN";
                        cmd.Parameters.AddWithValue("@MaCN", cboChuyenNganh.SelectedValue);
                        dkText.Add("Chuyên ngành = " + cboChuyenNganh.Text);
                    }
                    else
                    {
                        dkText.Add("Chuyên ngành = Tất cả");
                    }

                    sql += " ORDER BY cn.Ten_chuyen_nganh, da.Nam, da.Hoc_ky";

                    cmd.CommandText = sql;

                    // Lấy dữ liệu
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Không có dữ liệu để in báo cáo.");
                        return;
                    }

                    // Tạo report
                    rptDoAnTheoChuyenNganh rpt = new rptDoAnTheoChuyenNganh();
                    rpt.DataSource = dt;
                    rpt.DataMember = "";

                    // Gửi điều kiện lọc
                    rpt.lblDKLoc.Text = "ĐK lọc: " + string.Join(" ; ", dkText);

                    // Gửi ngày in
                    rpt.lblNgayIn.Text =
                        $"Hà Nội, ngày {DateTime.Now.Day} tháng {DateTime.Now.Month} năm {DateTime.Now.Year}";

                    // Mở báo cáo
                    rpt.ShowPreviewDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi in báo cáo: " + ex.Message);
            }
        }

        private void cboHocKy_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //private void btnInBaoCao_Click(object sender, EventArgs e)
        //{
        //    frmInBaoCaoChuyenNganh f = new frmInBaoCaoChuyenNganh();
        //    f.DuLieuBaoCao = (DataTable)dgvBaoCaoCN.DataSource;
        //    f.ShowDialog();
        //}
    }
}


