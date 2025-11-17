using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLĐA
{
    public partial class frmBaoCaoGiangVien : Form
    {
        SqlConnection conn = new SqlConnection(
            "Data Source=DESKTOP-OREV608\\SQLEXPRESS;Initial Catalog=qldatn_final;Integrated Security=True;Encrypt=False");

        public frmBaoCaoGiangVien()
        {
            InitializeComponent();
        }

        //=========================================================
        // FORM LOAD → LOAD GIẢNG VIÊN
        //=========================================================
        private void frmBaoCaoGiangVien_Load(object sender, EventArgs e)
        {
            LoadGiangVien();
        }

        private void LoadGiangVien()
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(conn.ConnectionString))
                {
                    string sql = "SELECT Ma_giang_vien, Ho_ten_gv FROM Giang_vien";
                    SqlDataAdapter da = new SqlDataAdapter(sql, cn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cboGiangVien.DataSource = dt;
                    cboGiangVien.DisplayMember = "Ho_ten_gv";
                    cboGiangVien.ValueMember = "Ma_giang_vien";

                    if (dt.Rows.Count > 0)
                        cboGiangVien.SelectedIndex = 0;

                    // Mặc định: cho chọn giảng viên
                    chkAllGiangVien.Checked = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load giảng viên: " + ex.Message);
            }
        }

        private void chkAllGiangVien_CheckedChanged(object sender, EventArgs e)
        {
            cboGiangVien.Enabled = !chkAllGiangVien.Checked;
        }

        //=========================================================
        // NÚT XEM BÁO CÁO
        //=========================================================
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

                    // Lọc GIẢNG VIÊN
                    if (!chkAllGiangVien.Checked)
                    {
                        sql += " AND gv.Ma_giang_vien = @MaGV";
                        cmd.Parameters.AddWithValue("@MaGV", cboGiangVien.SelectedValue);
                        dkText.Add("Giảng viên = " + cboGiangVien.Text);
                    }
                    else
                    {
                        dkText.Add("Giảng viên = Tất cả");
                    }

                    sql += " ORDER BY gv.Ho_ten_gv, da.Nam, da.Hoc_ky";
                    cmd.CommandText = sql;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvBaoCaoGV.DataSource = dt;

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

        //=========================================================
        // NÚT IN BÁO CÁO
        //=========================================================
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

                    if (!chkAllGiangVien.Checked)
                    {
                        sql += " AND gv.Ma_giang_vien = @MaGV";
                        cmd.Parameters.AddWithValue("@MaGV", cboGiangVien.SelectedValue);
                        dkText.Add("Giảng viên = " + cboGiangVien.Text);
                    }
                    else
                    {
                        dkText.Add("Giảng viên = Tất cả");
                    }

                    sql += " ORDER BY gv.Ho_ten_gv, da.Nam, da.Hoc_ky";
                    cmd.CommandText = sql;

                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Không có dữ liệu để in báo cáo.");
                        return;
                    }

                    // Tạo report
                    rptDoAnTheoGiangVien rpt = new rptDoAnTheoGiangVien();
                    rpt.DataSource = dt;
                    rpt.DataMember = "";

                    rpt.lblDKLoc.Text = "ĐK lọc: " + string.Join(" ; ", dkText);
                    rpt.lblNgayIn.Text = $"Hà Nội, ngày {DateTime.Now.Day} tháng {DateTime.Now.Month} năm {DateTime.Now.Year}";

                    rpt.ShowPreviewDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi in báo cáo: " + ex.Message);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
