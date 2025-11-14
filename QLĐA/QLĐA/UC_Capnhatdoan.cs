using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace QLĐA
{
    public partial class UC_Capnhatdoan : UserControl
    {
        private string connectionString = "Data Source=DESKTOP-OREV608\\SQLEXPRESS;Initial Catalog=qlđatn_final;Integrated Security=True;Encrypt=False";
        private SqlConnection conn;
        private DataTable dtDoAn;
        private string currentAction = ""; // "Add", "Edit", "Delete", ""
        private int selectedRowIndex = -1;

        // Mã giảng viên hiện tại - sẽ được set từ bên ngoài
        private string maGiangVien = "";

        public UC_Capnhatdoan()
        {
            InitializeComponent();
            conn = new SqlConnection(connectionString);
            this.Load += UC_Capnhatdoan_Load;
        }

        // Constructor với mã giảng viên
        public UC_Capnhatdoan(string maGV) : this()
        {
            this.maGiangVien = maGV;
        }

        // Property để set mã giảng viên từ bên ngoài
        public string MaGiangVien
        {
            get { return maGiangVien; }
            set
            {
                maGiangVien = value;
                if (!string.IsNullOrEmpty(maGiangVien))
                {
                    LoadDanhSachDoAn();
                }
            }
        }

        private void UC_Capnhatdoan_Load(object sender, EventArgs e)
        {
            // Lấy mã giảng viên từ Manhinhchinh nếu chưa có
            if (string.IsNullOrEmpty(maGiangVien))
            {
                maGiangVien = GetMaGiangVienFromParentForm();
            }

            LoadDanhSachDoAn();
            ConfigureDataGridView();
            ClearTextBoxes();
            SetNormalState();
        }

        // Lấy mã giảng viên từ form cha (Manhinhchinh)
        private string GetMaGiangVienFromParentForm()
        {
            Form parentForm = this.FindForm();
            if (parentForm != null && parentForm is Manhinhchinh)
            {
                Manhinhchinh mainForm = (Manhinhchinh)parentForm;

                var field = mainForm.GetType().GetField("currentUserId",
                    System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

                if (field != null)
                {
                    return field.GetValue(mainForm)?.ToString() ?? "";
                }
            }

            return "";
        }

        // ===== TẢI DANH SÁCH ĐỒ ÁN CỦA GIẢNG VIÊN =====
        private void LoadDanhSachDoAn()
        {
            try
            {
                if (string.IsNullOrEmpty(maGiangVien))
                {
                    MessageBox.Show("Không xác định được mã giảng viên!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string query = @"SELECT 
                    DA.Ma_do_an, 
                    DA.Ten_de_tai, 
                    DA.Mo_ta, 
                    DA.Ngay_nop, 
                    DA.Hoc_ky, 
                    DA.Nam,
                    DA.Ma_sinh_vien,
                    SV.Ho_ten as Ten_sinh_vien
                FROM Do_an DA
                INNER JOIN Sinh_vien SV ON DA.Ma_sinh_vien = SV.Ma_sinh_vien
                WHERE SV.Ma_giang_vien = @maGV
                ORDER BY DA.Ma_do_an DESC";

                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@maGV", maGiangVien);

                    dtDoAn = new DataTable();
                    adapter.Fill(dtDoAn);
                    dgvDoAn.DataSource = dtDoAn;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách đồ án: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===== CẤU HÌNH DATAGRIDVIEW =====
        private void ConfigureDataGridView()
        {
            if (dgvDoAn.Columns.Count == 0) return;

            dgvDoAn.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDoAn.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDoAn.MultiSelect = false;
            dgvDoAn.ReadOnly = true;
            dgvDoAn.AllowUserToAddRows = false;

            if (dgvDoAn.Columns["Ma_do_an"] != null)
                dgvDoAn.Columns["Ma_do_an"].HeaderText = "Mã đồ án";
            if (dgvDoAn.Columns["Ten_de_tai"] != null)
                dgvDoAn.Columns["Ten_de_tai"].HeaderText = "Tên đề tài";
            if (dgvDoAn.Columns["Mo_ta"] != null)
                dgvDoAn.Columns["Mo_ta"].HeaderText = "Mô tả";
            if (dgvDoAn.Columns["Ngay_nop"] != null)
            {
                dgvDoAn.Columns["Ngay_nop"].HeaderText = "Ngày nộp";
                dgvDoAn.Columns["Ngay_nop"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
            if (dgvDoAn.Columns["Hoc_ky"] != null)
                dgvDoAn.Columns["Hoc_ky"].HeaderText = "Học kỳ";
            if (dgvDoAn.Columns["Nam"] != null)
                dgvDoAn.Columns["Nam"].HeaderText = "Năm";
            if (dgvDoAn.Columns["Ma_sinh_vien"] != null)
                dgvDoAn.Columns["Ma_sinh_vien"].HeaderText = "Mã sinh viên";
            if (dgvDoAn.Columns["Ten_sinh_vien"] != null)
                dgvDoAn.Columns["Ten_sinh_vien"].HeaderText = "Tên sinh viên";

            dgvDoAn.CellClick -= DgvDoAn_CellClick;
            dgvDoAn.CellClick += DgvDoAn_CellClick;
        }

        // ===== XỬ LÝ KHI CLICK VÀO CELL =====
        private void DgvDoAn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedRowIndex = e.RowIndex;
                DisplayDataInTextBoxes(e.RowIndex);
            }
        }

        // ===== HIỂN THỊ DỮ LIỆU VÀO GROUPBOX =====
        private void DisplayDataInTextBoxes(int rowIndex)
        {
            try
            {
                DataGridViewRow row = dgvDoAn.Rows[rowIndex];

                txtMaDoAn.Text = row.Cells["Ma_do_an"].Value?.ToString() ?? "";
                txtTenDoAn.Text = row.Cells["Ten_de_tai"].Value?.ToString() ?? "";
                txtMoTa.Text = row.Cells["Mo_ta"].Value?.ToString() ?? "";

                if (row.Cells["Ngay_nop"].Value != null && row.Cells["Ngay_nop"].Value != DBNull.Value)
                {
                    txtNgayNop.Text = Convert.ToDateTime(row.Cells["Ngay_nop"].Value).ToString("dd/MM/yyyy");
                }
                else
                {
                    txtNgayNop.Text = "";
                }

                txtHocKy.Text = row.Cells["Hoc_ky"].Value?.ToString() ?? "";
                txtNam.Text = row.Cells["Nam"].Value?.ToString() ?? "";
                txtMaSV.Text = row.Cells["Ma_sinh_vien"].Value?.ToString() ?? "";
                txtTenSV.Text = row.Cells["Ten_sinh_vien"].Value?.ToString() ?? "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hiển thị dữ liệu: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===== XÓA NỘI DUNG CÁC TEXTBOX =====
        private void ClearTextBoxes()
        {
            txtMaDoAn.Clear();
            txtTenDoAn.Clear();
            txtMoTa.Clear();
            txtNgayNop.Clear();
            txtHocKy.Clear();
            txtNam.Clear();
            txtMaSV.Clear();
            txtTenSV.Clear();
        }

        // ===== THIẾT LẬP TRẠNG THÁI READONLY CHO TEXTBOX =====
        private void SetTextBoxesReadOnly(bool isReadOnly)
        {
            if (currentAction == "Edit")
            {
                txtMaDoAn.ReadOnly = true;
            }
            else
            {
                txtMaDoAn.ReadOnly = isReadOnly;
            }

            txtTenDoAn.ReadOnly = isReadOnly;
            txtMoTa.ReadOnly = isReadOnly;
            txtNgayNop.ReadOnly = isReadOnly;
            txtHocKy.ReadOnly = isReadOnly;
            txtNam.ReadOnly = isReadOnly;
            txtMaSV.ReadOnly = isReadOnly;
            txtTenSV.ReadOnly = isReadOnly;
        }

        // ===== THIẾT LẬP TRẠNG THÁI BÌNH THƯỜNG =====
        private void SetNormalState()
        {
            currentAction = "";

            btnThem.Enabled = true;
            btnSua.Enabled = selectedRowIndex >= 0;
            btnXoa.Enabled = selectedRowIndex >= 0;
            btnCapNhat.Enabled = false;

            SetTextBoxesReadOnly(true);
        }

        // ===== THIẾT LẬP TRẠNG THÁI ĐANG THAO TÁC =====
        private void SetActionState()
        {
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnCapNhat.Enabled = true;
        }

        // ===== NÚT THÊM =====
        private void btnThem_Click(object sender, EventArgs e)
        {
            currentAction = "Add";
            ClearTextBoxes();
            SetTextBoxesReadOnly(false);    
            SetActionState();
            txtMaDoAn.Focus();

            MessageBox.Show(
                "Vui lòng nhập thông tin đồ án mới vào form.\n\n" +
                "Sau khi nhập xong, nhấn nút 'Cập nhật' để lưu thông tin.",
                "Hướng dẫn thêm đồ án",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        // ===== NÚT SỬA =====
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (selectedRowIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn một đồ án để sửa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            currentAction = "Edit";
            SetTextBoxesReadOnly(false);
            txtMaDoAn.ReadOnly = true;
            txtMaDoAn.BackColor = Color.LightGray;
            SetActionState();
            txtTenDoAn.Focus();

            MessageBox.Show(
                "Bạn có thể chỉnh sửa thông tin đồ án trong form.\n\n" +
                "Lưu ý: Không thể thay đổi mã đồ án.\n\n" +
                "Sau khi chỉnh sửa xong, nhấn nút 'Cập nhật' để lưu thay đổi.",
                "Hướng dẫn sửa thông tin",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        // ===== NÚT XÓA =====
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (selectedRowIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn một đồ án để xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa đồ án:\n\n" +
                $"Mã đồ án: {txtMaDoAn.Text}\n" +
                $"Tên đề tài: {txtTenDoAn.Text}\n\n" +
                $"Thao tác này sẽ có hiệu lực sau khi nhấn nút 'Cập nhật'.",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                currentAction = "Delete";
                SetActionState();

                MessageBox.Show(
                    "Nhấn nút 'Cập nhật' để xác nhận xóa đồ án này.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        // ===== NÚT CẬP NHẬT =====
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(currentAction))
                {
                    MessageBox.Show("Vui lòng chọn Thêm, Sửa hoặc Xóa trước!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                switch (currentAction)
                {
                    case "Add":
                        ThemDoAn();
                        break;
                    case "Edit":
                        SuaDoAn();
                        break;
                    case "Delete":
                        XoaDoAn();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SetNormalState();
            }
        }

        // ===== THÊM ĐỒ ÁN MỚI =====
        private void ThemDoAn()
        {
            if (string.IsNullOrWhiteSpace(txtMaDoAn.Text))
            {
                MessageBox.Show("Vui lòng nhập mã đồ án!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaDoAn.Focus();
                throw new Exception();
            }

            if (string.IsNullOrWhiteSpace(txtTenDoAn.Text))
            {
                MessageBox.Show("Vui lòng nhập tên đề tài!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenDoAn.Focus();
                throw new Exception();
            }

            if (string.IsNullOrWhiteSpace(txtMaSV.Text))
            {
                MessageBox.Show("Vui lòng nhập mã sinh viên!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaSV.Focus();
                throw new Exception();
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Kiểm tra mã đồ án đã tồn tại chưa
                    string checkQuery = "SELECT COUNT(*) FROM Do_an WHERE Ma_do_an = @maDoAn";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@maDoAn", txtMaDoAn.Text.Trim());
                        int count = (int)checkCmd.ExecuteScalar();

                        if (count > 0)
                        {
                            MessageBox.Show(
                                "⚠ Mã đồ án đã tồn tại trong hệ thống!\n\n" +
                                "Vui lòng sử dụng mã khác.",
                                "Trùng mã đồ án",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                            txtMaDoAn.Focus();
                            txtMaDoAn.SelectAll();
                            throw new Exception();
                        }
                    }

                    // Kiểm tra sinh viên có thuộc giảng viên này hướng dẫn không
                    string checkSVQuery = @"SELECT COUNT(*) FROM Sinh_vien 
                                           WHERE Ma_sinh_vien = @maSV 
                                           AND Ma_giang_vien = @maGV";
                    using (SqlCommand checkSVCmd = new SqlCommand(checkSVQuery, conn))
                    {
                        checkSVCmd.Parameters.AddWithValue("@maSV", txtMaSV.Text.Trim());
                        checkSVCmd.Parameters.AddWithValue("@maGV", maGiangVien);
                        int svCount = (int)checkSVCmd.ExecuteScalar();

                        if (svCount == 0)
                        {
                            MessageBox.Show(
                                "Mã sinh viên không tồn tại hoặc không thuộc danh sách sinh viên bạn hướng dẫn!\n\n" +
                                "Vui lòng kiểm tra lại mã sinh viên.",
                                "Lỗi",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            txtMaSV.Focus();
                            throw new Exception();
                        }
                    }

                    // Parse ngày nộp
                    DateTime? ngayNop = null;
                    if (!string.IsNullOrWhiteSpace(txtNgayNop.Text))
                    {
                        if (DateTime.TryParseExact(txtNgayNop.Text, "dd/MM/yyyy",
                            System.Globalization.CultureInfo.InvariantCulture,
                            System.Globalization.DateTimeStyles.None, out DateTime tempDate))
                        {
                            ngayNop = tempDate;
                        }
                        else
                        {
                            MessageBox.Show(
                                "Ngày nộp không đúng định dạng!\n\n" +
                                "Vui lòng nhập theo định dạng: dd/MM/yyyy\n" +
                                "Ví dụ: 15/06/2024",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                            txtNgayNop.Focus();
                            throw new Exception();
                        }
                    }

                    // Insert đồ án mới
                    string insertQuery = @"INSERT INTO Do_an 
                        (Ma_do_an, Ten_de_tai, Mo_ta, Ngay_nop, Hoc_ky, Nam, Ma_sinh_vien)
                        VALUES (@maDoAn, @tenDeTai, @moTa, @ngayNop, @hocKy, @nam, @maSV)";

                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@maDoAn", txtMaDoAn.Text.Trim());
                        cmd.Parameters.AddWithValue("@tenDeTai", txtTenDoAn.Text.Trim());
                        cmd.Parameters.AddWithValue("@moTa",
                            string.IsNullOrWhiteSpace(txtMoTa.Text) ? (object)DBNull.Value : txtMoTa.Text.Trim());
                        cmd.Parameters.AddWithValue("@ngayNop",
                            ngayNop.HasValue ? (object)ngayNop.Value : DBNull.Value);
                        cmd.Parameters.AddWithValue("@hocKy",
                            string.IsNullOrWhiteSpace(txtHocKy.Text) ? (object)DBNull.Value : txtHocKy.Text.Trim());
                        cmd.Parameters.AddWithValue("@nam",
                            string.IsNullOrWhiteSpace(txtNam.Text) ? (object)DBNull.Value : txtNam.Text.Trim());
                        cmd.Parameters.AddWithValue("@maSV", txtMaSV.Text.Trim());

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show(
                                "✓ Thêm đồ án thành công!\n\n" +
                                $"Mã đồ án: {txtMaDoAn.Text}\n" +
                                $"Tên đề tài: {txtTenDoAn.Text}\n\n" +
                                "Dữ liệu đã được lưu vào hệ thống.",
                                "Thành công",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                            LoadDanhSachDoAn();
                            ClearTextBoxes();
                            selectedRowIndex = -1;
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("Lỗi SQL: " + sqlEx.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        // ===== SỬA THÔNG TIN ĐỒ ÁN =====
        private void SuaDoAn()
        {
            if (selectedRowIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn đồ án cần sửa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                throw new Exception();
            }

            if (string.IsNullOrWhiteSpace(txtTenDoAn.Text))
            {
                MessageBox.Show("Vui lòng nhập tên đề tài!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenDoAn.Focus();
                throw new Exception();
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    DateTime? ngayNop = null;
                    if (!string.IsNullOrWhiteSpace(txtNgayNop.Text))
                    {
                        if (DateTime.TryParseExact(txtNgayNop.Text, "dd/MM/yyyy",
                            System.Globalization.CultureInfo.InvariantCulture,
                            System.Globalization.DateTimeStyles.None, out DateTime tempDate))
                        {
                            ngayNop = tempDate;
                        }
                        else
                        {
                            MessageBox.Show(
                                "Ngày nộp không đúng định dạng!\n\n" +
                                "Vui lòng nhập theo định dạng: dd/MM/yyyy",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                            txtNgayNop.Focus();
                            throw new Exception();
                        }
                    }

                    string updateQuery = @"UPDATE Do_an SET 
                        Ten_de_tai = @tenDeTai, 
                        Mo_ta = @moTa, 
                        Ngay_nop = @ngayNop, 
                        Hoc_ky = @hocKy, 
                        Nam = @nam
                        WHERE Ma_do_an = @maDoAn";

                    using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@maDoAn", txtMaDoAn.Text.Trim());
                        cmd.Parameters.AddWithValue("@tenDeTai", txtTenDoAn.Text.Trim());
                        cmd.Parameters.AddWithValue("@moTa",
                            string.IsNullOrWhiteSpace(txtMoTa.Text) ? (object)DBNull.Value : txtMoTa.Text.Trim());
                        cmd.Parameters.AddWithValue("@ngayNop",
                            ngayNop.HasValue ? (object)ngayNop.Value : DBNull.Value);
                        cmd.Parameters.AddWithValue("@hocKy",
                            string.IsNullOrWhiteSpace(txtHocKy.Text) ? (object)DBNull.Value : txtHocKy.Text.Trim());
                        cmd.Parameters.AddWithValue("@nam",
                            string.IsNullOrWhiteSpace(txtNam.Text) ? (object)DBNull.Value : txtNam.Text.Trim());

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show(
                                "✓ Cập nhật thông tin đồ án thành công!\n\n" +
                                $"Mã đồ án: {txtMaDoAn.Text}\n" +
                                $"Tên đề tài: {txtTenDoAn.Text}",
                                "Thành công",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                            LoadDanhSachDoAn();

                            if (selectedRowIndex < dgvDoAn.Rows.Count)
                            {
                                dgvDoAn.Rows[selectedRowIndex].Selected = true;
                                DisplayDataInTextBoxes(selectedRowIndex);
                            }
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("Lỗi SQL: " + sqlEx.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        // ===== XÓA ĐỒ ÁN =====
        private void XoaDoAn()
        {
            if (selectedRowIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn đồ án cần xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                throw new Exception();
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string deleteQuery = "DELETE FROM Do_an WHERE Ma_do_an = @maDoAn";

                    using (SqlCommand cmd = new SqlCommand(deleteQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@maDoAn", txtMaDoAn.Text.Trim());

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show(
                                "✓ Xóa đồ án thành công!\n\n" +
                                $"Đã xóa đồ án: {txtTenDoAn.Text}",
                                "Thành công",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                            LoadDanhSachDoAn();
                            ClearTextBoxes();
                            selectedRowIndex = -1;
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                if (sqlEx.Number == 547)
                {
                    MessageBox.Show(
                        "Không thể xóa đồ án này vì đang có dữ liệu liên quan!",
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Lỗi SQL: " + sqlEx.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                throw;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
        }
    }
}