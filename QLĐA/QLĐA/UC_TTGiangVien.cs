using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLĐA
{
    public partial class UC_TTGiangVien : UserControl
    {
        private string connectionString = "Data Source=DESKTOP-OREV608\\SQLEXPRESS;Initial Catalog=qldatn_final;Integrated Security=True;Encrypt=False";
        private string maGiangVien;

        public UC_TTGiangVien()
        {
            InitializeComponent();
        }

        public UC_TTGiangVien(string maGV) : this()
        {
            this.maGiangVien = maGV;
            LoadThongTinGiangVien();
            LoadDanhSachDoAnHuongDan();
        }

        private void LoadThongTinGiangVien()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"
                        SELECT Ma_giang_vien, Ho_ten_gv, Ngay_sinh, Gioi_tinh, Bang_cap, Chuc_danh, Email
                        FROM Giang_vien
                        WHERE Ma_giang_vien = @maGV";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@maGV", maGiangVien);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                SetTextBoxValue("txtMaGV", reader["Ma_giang_vien"].ToString());
                                SetTextBoxValue("txtHoTen", reader["Ho_ten_gv"].ToString());
                                
                                if (reader["Ngay_sinh"] != DBNull.Value)
                                    SetTextBoxValue("txtNgaySinh", Convert.ToDateTime(reader["Ngay_sinh"]).ToString("dd/MM/yyyy"));
                                
                                SetTextBoxValue("txtGioiTinh", reader["Gioi_tinh"].ToString());
                                SetTextBoxValue("txtBangCap", reader["Bang_cap"].ToString());
                                SetTextBoxValue("txtChucDanh", reader["Chuc_danh"].ToString());
                                SetTextBoxValue("txtEmail", reader["Email"].ToString());
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
                DataGridView dgv = FindControlRecursive<DataGridView>(this, "dgvDoAnHD");
                if (dgv == null)
                {
                    return;
                }

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

                        dgv.DataSource = dt;
                        ConfigureDataGridView(dgv);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách đồ án: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureDataGridView(DataGridView dgv)
        {
            if (dgv.Columns.Count == 0) return;

            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.ReadOnly = true;
            dgv.RowHeadersVisible = true;

            if (dgv.Columns["Ma_do_an"] != null)
                dgv.Columns["Ma_do_an"].HeaderText = "Mã ĐA";
            if (dgv.Columns["Ten_de_tai"] != null)
                dgv.Columns["Ten_de_tai"].HeaderText = "Tên đề tài";
            if (dgv.Columns["Ten_sinh_vien"] != null)
                dgv.Columns["Ten_sinh_vien"].HeaderText = "Sinh viên";
            if (dgv.Columns["Ma_sinh_vien"] != null)
                dgv.Columns["Ma_sinh_vien"].HeaderText = "Mã SV";
            if (dgv.Columns["Ngay_nop"] != null)
            {
                dgv.Columns["Ngay_nop"].HeaderText = "Ngày nộp";
                dgv.Columns["Ngay_nop"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
            if (dgv.Columns["Hoc_ky"] != null)
                dgv.Columns["Hoc_ky"].HeaderText = "Học kỳ";
            if (dgv.Columns["Nam"] != null)
                dgv.Columns["Nam"].HeaderText = "Năm";
            if (dgv.Columns["Mo_ta"] != null)
                dgv.Columns["Mo_ta"].HeaderText = "Mô tả";
        }

        private void SetTextBoxValue(string controlName, string value)
        {
            Control[] controls = this.Controls.Find(controlName, true);
            if (controls.Length > 0 && controls[0] is TextBox textBox)
            {
                textBox.Text = value ?? "";
            }
        }

        private T FindControlRecursive<T>(Control root, string name) where T : Control
        {
            if (root.Name == name && root is T)
                return root as T;

            foreach (Control child in root.Controls)
            {
                T result = FindControlRecursive<T>(child, name);
                if (result != null)
                    return result;
            }

            return null;
        }
    }
}
