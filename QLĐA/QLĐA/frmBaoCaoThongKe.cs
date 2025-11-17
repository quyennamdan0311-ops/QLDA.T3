using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLĐA
{
    public partial class frmBaoCaoThongKe : Form
    {
        private string connectionString = "Data Source=DESKTOP-OREV608\\SQLEXPRESS;Initial Catalog=qldatn_final;Integrated Security=True;Encrypt=False";

        public frmBaoCaoThongKe()
        {
            InitializeComponent();
        }

        // =============================================================
        // FORM LOAD
        // =============================================================
        private void frmBaoCaoThongKe_Load(object sender, EventArgs e)
        {
            LoadChuyenNganh();
            LoadHocKy();
            LoadNam();

            chkAllChuyenNganh.Checked = true;
            chkAllHocKy.Checked = true;
            chkAllNam.Checked = true;
        }

        // =============================================================
        // LOAD DỮ LIỆU CHUYÊN NGÀNH
        // =============================================================
        private void LoadChuyenNganh()
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
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

        // =============================================================
        // LOAD HỌC KỲ
        // =============================================================
        private void LoadHocKy()
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string sql = "SELECT DISTINCT Hoc_ky FROM Do_an ORDER BY Hoc_ky";
                    SqlDataAdapter da = new SqlDataAdapter(sql, cn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cboHocKy.DataSource = dt;
                    cboHocKy.DisplayMember = "Hoc_ky";
                    cboHocKy.ValueMember = "Hoc_ky";

                    if (dt.Rows.Count > 0)
                        cboHocKy.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load học kỳ: " + ex.Message);
            }
        }

        // =============================================================
        // LOAD NĂM
        // =============================================================
        private void LoadNam()
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string sql = "SELECT DISTINCT Nam FROM Do_an ORDER BY Nam";
                    SqlDataAdapter da = new SqlDataAdapter(sql, cn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cboNam.DataSource = dt;
                    cboNam.DisplayMember = "Nam";
                    cboNam.ValueMember = "Nam";

                    if (dt.Rows.Count > 0)
                        cboNam.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load năm: " + ex.Message);
            }
        }

        // =============================================================
        // CHECKBOX TẤT CẢ
        // =============================================================
        private void chkAllChuyenNganh_CheckedChanged(object sender, EventArgs e)
        {
            cboChuyenNganh.Enabled = !chkAllChuyenNganh.Checked;
        }

        private void chkAllHocKy_CheckedChanged(object sender, EventArgs e)
        {
            cboHocKy.Enabled = !chkAllHocKy.Checked;
        }

        private void chkAllNam_CheckedChanged(object sender, EventArgs e)
        {
            cboNam.Enabled = !chkAllNam.Checked;
        }

        // =============================================================
        // NÚT XEM BÁO CÁO
        // =============================================================
        private void btnXemBaoCao_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = @"
        SELECT 
            cn.Ten_chuyen_nganh,
            da.Hoc_ky,
            da.Nam,
            COUNT(*) AS SoLuongDoAn
        FROM Do_an da
        INNER JOIN Sinh_vien sv ON da.Ma_sinh_vien = sv.Ma_sinh_vien
        INNER JOIN Chuyen_nganh cn ON sv.Ma_chuyen_nganh = cn.Ma_chuyen_nganh
        LEFT JOIN Giang_vien gv ON sv.Ma_giang_vien = gv.Ma_giang_vien
        WHERE 1 = 1
        ";

                List<string> dkText = new List<string>();
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;

                    // --- Lọc chuyên ngành ---
                    if (!chkAllChuyenNganh.Checked)
                    {
                        sql += " AND cn.Ma_chuyen_nganh = @MaCN";
                        cmd.Parameters.AddWithValue("@MaCN", cboChuyenNganh.SelectedValue);
                        dkText.Add("Chuyên ngành = " + cboChuyenNganh.Text);
                    }
                    else dkText.Add("Chuyên ngành = Tất cả");

                    // --- Lọc học kỳ ---
                    if (!chkAllHocKy.Checked)
                    {
                        sql += " AND da.Hoc_ky = @HocKy";
                        cmd.Parameters.AddWithValue("@HocKy", cboHocKy.SelectedValue);
                        dkText.Add("Học kỳ = " + cboHocKy.Text);
                    }
                    else dkText.Add("Học kỳ = Tất cả");

                    // --- Lọc năm ---
                    if (!chkAllNam.Checked)
                    {
                        sql += " AND da.Nam = @Nam";
                        cmd.Parameters.AddWithValue("@Nam", cboNam.SelectedValue);
                        dkText.Add("Năm = " + cboNam.Text);
                    }
                    else dkText.Add("Năm = Tất cả");

                    // NHỚ: GROUP BY trước, ORDER BY sau
                    sql += @"
        GROUP BY 
            cn.Ten_chuyen_nganh,
            da.Hoc_ky,
            da.Nam
        ORDER BY 
            cn.Ten_chuyen_nganh,
            da.Nam,
            da.Hoc_ky";

                    cmd.CommandText = sql;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvBaoCaoTK.DataSource = dt;

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

        private void btnInBaoCao_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = @"
        SELECT 
            cn.Ten_chuyen_nganh,
            da.Hoc_ky,
            da.Nam,
            COUNT(*) AS SoLuongDoAn
        FROM Do_an da
        INNER JOIN Sinh_vien sv ON da.Ma_sinh_vien = sv.Ma_sinh_vien
        INNER JOIN Chuyen_nganh cn ON sv.Ma_chuyen_nganh = cn.Ma_chuyen_nganh
        LEFT JOIN Giang_vien gv ON sv.Ma_giang_vien = gv.Ma_giang_vien
        WHERE 1 = 1
        ";

                List<string> dkText = new List<string>();
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;

                    // --- Lọc chuyên ngành ---
                    if (!chkAllChuyenNganh.Checked)
                    {
                        sql += " AND cn.Ma_chuyen_nganh = @MaCN";
                        cmd.Parameters.AddWithValue("@MaCN", cboChuyenNganh.SelectedValue);
                        dkText.Add("Chuyên ngành = " + cboChuyenNganh.Text);
                    }
                    else dkText.Add("Chuyên ngành = Tất cả");

                    // --- Lọc học kỳ ---
                    if (!chkAllHocKy.Checked)
                    {
                        sql += " AND da.Hoc_ky = @HocKy";
                        cmd.Parameters.AddWithValue("@HocKy", cboHocKy.SelectedValue);
                        dkText.Add("Học kỳ = " + cboHocKy.Text);
                    }
                    else dkText.Add("Học kỳ = Tất cả");

                    // --- Lọc năm ---
                    if (!chkAllNam.Checked)
                    {
                        sql += " AND da.Nam = @Nam";
                        cmd.Parameters.AddWithValue("@Nam", cboNam.SelectedValue);
                        dkText.Add("Năm = " + cboNam.Text);
                    }
                    else dkText.Add("Năm = Tất cả");

                    sql += @"
        GROUP BY 
            cn.Ten_chuyen_nganh,
            da.Hoc_ky,
            da.Nam
        ORDER BY 
            cn.Ten_chuyen_nganh,
            da.Nam,
            da.Hoc_ky";

                    cmd.CommandText = sql;

                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Không có dữ liệu để in báo cáo.");
                        return;
                    }

                    // Tạo report THỐNG KÊ
                    rptBaoCaoThongKe rpt = new rptBaoCaoThongKe();
                    rpt.DataSource = dt;
                    rpt.DataMember = "";

                    rpt.lblDKLoc.Text = "ĐK lọc: " + string.Join(" ; ", dkText);
                    rpt.lblNgayIn.Text =
                        $"Hà Nội, ngày {DateTime.Now.Day} tháng {DateTime.Now.Month} năm {DateTime.Now.Year}";

                    rpt.ShowPreviewDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi in báo cáo: " + ex.Message);
            }
        }

        
    }
}
