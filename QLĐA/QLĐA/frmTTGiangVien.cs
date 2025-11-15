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
    public partial class frmTTGiangVien : Form
    {
        private string connectionString = "Data Source=DESKTOP-OREV608\\SQLEXPRESS;Initial Catalog=qlđatn_final;Integrated Security=True;Encrypt=False";
        private string maGiangVien;

        // Constructor mặc định
        public frmTTGiangVien()
        {
            InitializeComponent();
        }

        // Constructor với mã giảng viên
        public frmTTGiangVien(string maGV) : this()
        {
            this.maGiangVien = maGV;
            LoadThongTinGiangVien();
            LoadDanhSachDoAnHuongDan();
            ConfigureDataGridView();
        }

        private void LoadThongTinGiangVien()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"
                        SELECT Ma_giang_vien, Ho_ten, Gioi_tinh, Bang_cap, Chuc_danh, Email
                        FROM Giang_vien
                        WHERE Ma_giang_vien = @maGV";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@maGV", maGiangVien);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtMaGV.Text = reader["Ma_giang_vien"].ToString();
                                txtHoTen.Text = reader["Ho_ten"].ToString();
                                txtGioiTinh.Text = reader["Gioi_tinh"].ToString();
                                txtBangCap.Text = reader["Bang_cap"].ToString();
                                txtChucDanh.Text = reader["Chuc_danh"].ToString();
                                txtEmail.Text = reader["Email"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("Không tìm thấy thông tin giảng viên!", "Lỗi",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải thông tin: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDanhSachDoAnHuongDan()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"
                        SELECT DA.Ma_do_an, DA.Ten_de_tai, SV.Ho_ten as Ten_sinh_vien,
                               SV.Ma_sinh_vien, DA.Ngay_nop, DA.Hoc_ky, DA.Nam, DA.Mo_ta
                        FROM Do_an DA
                        INNER JOIN Sinh_vien SV ON DA.Ma_sinh_vien = SV.Ma_sinh_vien
                        WHERE SV.Ma_giang_vien = @maGV
                        ORDER BY DA.Ngay_nop DESC";

                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@maGV", maGiangVien);

                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dgvDoAnHD.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách đồ án: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureDataGridView()
        {
            if (dgvDoAnHD.Columns.Count == 0) return;

            dgvDoAnHD.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDoAnHD.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDoAnHD.MultiSelect = false;
            dgvDoAnHD.ReadOnly = true;
            dgvDoAnHD.RowHeadersVisible = false;

            // Đặt tên hiển thị cho các cột
            if (dgvDoAnHD.Columns["Ma_do_an"] != null)
                dgvDoAnHD.Columns["Ma_do_an"].HeaderText = "Mã ĐA";
            if (dgvDoAnHD.Columns["Ten_de_tai"] != null)
                dgvDoAnHD.Columns["Ten_de_tai"].HeaderText = "Tên đề tài";
            if (dgvDoAnHD.Columns["Ten_sinh_vien"] != null)
                dgvDoAnHD.Columns["Ten_sinh_vien"].HeaderText = "Sinh viên";
            if (dgvDoAnHD.Columns["Ma_sinh_vien"] != null)
                dgvDoAnHD.Columns["Ma_sinh_vien"].HeaderText = "Mã SV";
            if (dgvDoAnHD.Columns["Ngay_nop"] != null)
            {
                dgvDoAnHD.Columns["Ngay_nop"].HeaderText = "Ngày nộp";
                dgvDoAnHD.Columns["Ngay_nop"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
            if (dgvDoAnHD.Columns["Hoc_ky"] != null)
                dgvDoAnHD.Columns["Hoc_ky"].HeaderText = "Học kỳ";
            if (dgvDoAnHD.Columns["Nam"] != null)
                dgvDoAnHD.Columns["Nam"].HeaderText = "Năm";
            if (dgvDoAnHD.Columns["Mo_ta"] != null)
                dgvDoAnHD.Columns["Mo_ta"].HeaderText = "Mô tả";
        }

        private void grbThongTinCaNhan_Enter(object sender, EventArgs e)
        {

        }

        private void dgvDoAnHD_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Xử lý khi click vào cell (nếu cần)
        }
    }
}
