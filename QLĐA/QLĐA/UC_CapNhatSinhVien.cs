using DevExpress.XtraEditors;
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
    public partial class UC_CapNhatSinhVien : DevExpress.XtraEditors.XtraUserControl
    {
        private string connectionString = "Data Source=DESKTOP-OREV608\\SQLEXPRESS;Initial Catalog=qlđatn_final;Integrated Security=True;Encrypt=False";
        private SqlConnection conn;
        private DataTable dtSinhVien;
        private string currentAction = ""; // "Add", "Edit", "Delete", ""
        private int selectedRowIndex = -1;

        public UC_CapNhatSinhVien()
        {
            InitializeComponent();
            conn = new SqlConnection(connectionString);
        }   

        private void UC_CapNhatSinhVien_Load(object sender, EventArgs e)
        {
            LoadDanhSachSinhVien();
            ConfigureDataGridView();
            ClearTextBoxes();
            SetNormalState();
        }

        // Tải danh sách sinh viên từ database
        private void LoadDanhSachSinhVien()
        {
            try
            {
                string query = @"SELECT 
                    SV.Ma_sinh_vien, 
                    SV.Ho_ten, 
                    SV.Lop, 
                    SV.Khoa, 
                    SV.Email, 
                    SV.Ma_giang_vien,
                    SV.Ma_chuyen_nganh, 
                    SV.Gioi_tinh, 
                    SV.Ngay_sinh
                FROM Sinh_vien SV
                ORDER BY SV.Ma_sinh_vien";

                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                {
                    dtSinhVien = new DataTable();
                    adapter.Fill(dtSinhVien);
                    dgvSinhVien.DataSource = dtSinhVien;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách sinh viên: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Cấu hình DataGridView
        private void ConfigureDataGridView()
        {
            if (dgvSinhVien.Columns.Count == 0) return;

            dgvSinhVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSinhVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSinhVien.MultiSelect = false;
            dgvSinhVien.ReadOnly = true;
            dgvSinhVien.AllowUserToAddRows = false;

            // Đặt tiêu đề cột
            if (dgvSinhVien.Columns["Ma_sinh_vien"] != null)
                dgvSinhVien.Columns["Ma_sinh_vien"].HeaderText = "Mã sinh viên";
            if (dgvSinhVien.Columns["Ho_ten"] != null)
                dgvSinhVien.Columns["Ho_ten"].HeaderText = "Họ tên";
            if (dgvSinhVien.Columns["Lop"] != null)
                dgvSinhVien.Columns["Lop"].HeaderText = "Lớp";
            if (dgvSinhVien.Columns["Khoa"] != null)
                dgvSinhVien.Columns["Khoa"].HeaderText = "Khoa";
            if (dgvSinhVien.Columns["Email"] != null)
                dgvSinhVien.Columns["Email"].HeaderText = "Email";
            if (dgvSinhVien.Columns["Ma_giang_vien"] != null)
                dgvSinhVien.Columns["Ma_giang_vien"].HeaderText = "Mã giảng viên";
            if (dgvSinhVien.Columns["Ma_chuyen_nganh"] != null)
                dgvSinhVien.Columns["Ma_chuyen_nganh"].HeaderText = "Mã chuyên ngành";
            if (dgvSinhVien.Columns["Gioi_tinh"] != null)
                dgvSinhVien.Columns["Gioi_tinh"].HeaderText = "Giới tính";
            if (dgvSinhVien.Columns["Ngay_sinh"] != null)
            {
                dgvSinhVien.Columns["Ngay_sinh"].HeaderText = "Ngày sinh";
                dgvSinhVien.Columns["Ngay_sinh"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }

            // Đăng ký sự kiện CellClick
            dgvSinhVien.CellClick += DgvSinhVien_CellClick;
        }

        // Xử lý khi click vào cell
        private void DgvSinhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedRowIndex = e.RowIndex;
                
                // Chỉ hiển thị dữ liệu khi đang ở chế độ bình thường hoặc đang sửa/xóa
                if (currentAction == "" || currentAction == "Edit" || currentAction == "Delete")
                {
                    DisplayDataInTextBoxes(e.RowIndex);
                    
                    // Cập nhật trạng thái nút Sửa và Xóa khi chọn dòng (chỉ khi ở chế độ bình thường)
                    if (currentAction == "")
                    {
                        btnSua.Enabled = true;
                        btnXoa.Enabled = true;
                    }
                }
            }
        }

        // Hiển thị dữ liệu vào GroupBox
        private void DisplayDataInTextBoxes(int rowIndex)
        {
            try
            {
                DataGridViewRow row = dgvSinhVien.Rows[rowIndex];

                txtMaSV.Text = row.Cells["Ma_sinh_vien"].Value?.ToString() ?? "";
                txtHoTenSV.Text = row.Cells["Ho_ten"].Value?.ToString() ?? "";
                txtLop.Text = row.Cells["Lop"].Value?.ToString() ?? "";
                txtKhoa.Text = row.Cells["Khoa"].Value?.ToString() ?? "";
                
                // Sửa lại phần Email - tách riêng Email và Ma_giang_vien
                if (this.Controls.Find("txtEmail", true).Length > 0)
                {
                    TextBox txtEmail = (TextBox)this.Controls.Find("txtEmail", true)[0];
                    txtEmail.Text = row.Cells["Email"].Value?.ToString() ?? "";
                }
                
                txtMaGiangVien.Text = row.Cells["Ma_giang_vien"].Value?.ToString() ?? "";
                txtMaChuyenNganh.Text = row.Cells["Ma_chuyen_nganh"].Value?.ToString() ?? "";
                txtGioiTinh.Text = row.Cells["Gioi_tinh"].Value?.ToString() ?? "";

                if (row.Cells["Ngay_sinh"].Value != null && row.Cells["Ngay_sinh"].Value != DBNull.Value)
                {
                    txtNgaySinh.Text = Convert.ToDateTime(row.Cells["Ngay_sinh"].Value).ToString("dd/MM/yyyy");
                }
                else
                {
                    txtNgaySinh.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hiển thị dữ liệu: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Xóa nội dung các TextBox
        private void ClearTextBoxes()
        {
            txtMaSV.Clear();
            txtHoTenSV.Clear();
            txtLop.Clear();
            txtKhoa.Clear();
            
            // Clear Email nếu tồn tại
            if (this.Controls.Find("txtEmail", true).Length > 0)
            {
                TextBox txtEmail = (TextBox)this.Controls.Find("txtEmail", true)[0];
                txtEmail.Clear();
            }
            
            txtMaGiangVien.Clear();
            txtMaChuyenNganh.Clear();
            txtGioiTinh.Clear();
            txtNgaySinh.Clear();
        }

        // Thiết lập trạng thái ReadOnly cho TextBox
        private void SetTextBoxesReadOnly(bool isReadOnly)
        {
            // Mã sinh viên luôn ReadOnly khi sửa
            if (currentAction == "Edit")
            {
                txtMaSV.ReadOnly = true;
            }
            else
            {
                txtMaSV.ReadOnly = isReadOnly;
            }

            txtHoTenSV.ReadOnly = isReadOnly;
            txtLop.ReadOnly = isReadOnly;
            txtKhoa.ReadOnly = isReadOnly;
            
            // Set ReadOnly cho Email nếu tồn tại
            if (this.Controls.Find("txtEmail", true).Length > 0)
            {
                TextBox txtEmail = (TextBox)this.Controls.Find("txtEmail", true)[0];
                txtEmail.ReadOnly = isReadOnly;
            }
            
            txtMaGiangVien.ReadOnly = isReadOnly;
            txtMaChuyenNganh.ReadOnly = isReadOnly;
            txtGioiTinh.ReadOnly = isReadOnly;
            txtNgaySinh.ReadOnly = isReadOnly;
        }

        // Thiết lập trạng thái bình thường (tất cả nút enabled)
        private void SetNormalState()
        {
            currentAction = "";
            
            // Tất cả nút Thêm luôn enabled
            btnThem.Enabled = true;
            
            // Nút Sửa và Xóa chỉ enabled khi có dòng được chọn
            btnSua.Enabled = selectedRowIndex >= 0;
            btnXoa.Enabled = selectedRowIndex >= 0;
            
            // Nút Cập nhật disable ở chế độ bình thường
            btnCapNhat.Enabled = false;
            
            // TextBox ở chế độ ReadOnly
            SetTextBoxesReadOnly(true);
        }

        // Thiết lập trạng thái đang thao tác (Thêm/Sửa/Xóa)
        private void SetActionState()
        {
            // Disable các nút Thêm, Sửa, Xóa khi đang thao tác
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            
            // Enable nút Cập nhật
            btnCapNhat.Enabled = true;
        }

        // Nút THÊM
        private void btnThem_Click(object sender, EventArgs e)
        {
            currentAction = "Add";
            ClearTextBoxes();
            SetTextBoxesReadOnly(false);
            SetActionState();
            txtMaSV.Focus();

            MessageBox.Show("Vui lòng nhập thông tin sinh viên mới và nhấn 'Cập nhật'", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Nút SỬA
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (selectedRowIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn một sinh viên để sửa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            currentAction = "Edit";
            SetTextBoxesReadOnly(false);
            SetActionState();
            txtHoTenSV.Focus();

            MessageBox.Show("Vui lòng chỉnh sửa thông tin và nhấn 'Cập nhật'", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Nút XÓA
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (selectedRowIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn một sinh viên để xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa sinh viên '{txtHoTenSV.Text}'?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                currentAction = "Delete";
                SetActionState();
                MessageBox.Show("Nhấn 'Cập nhật' để xác nhận xóa", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Nút CẬP NHẬT
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
                        ThemSinhVien();
                        break;
                    case "Edit":
                        SuaSinhVien();
                        break;
                    case "Delete":
                        XoaSinhVien();
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
                // Trở về trạng thái bình thường
                SetNormalState();
            }
        }

        // Thêm sinh viên mới
        private void ThemSinhVien()
        {
            // Validate dữ liệu
            if (string.IsNullOrWhiteSpace(txtMaSV.Text))
            {
                MessageBox.Show("Vui lòng nhập mã sinh viên!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaSV.Focus();
                throw new Exception(); // Để không reset trạng thái
            }

            if (string.IsNullOrWhiteSpace(txtHoTenSV.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên sinh viên!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTenSV.Focus();
                throw new Exception(); // Để không reset trạng thái
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Kiểm tra mã sinh viên đã tồn tại chưa
                    string checkQuery = "SELECT COUNT(*) FROM Sinh_vien WHERE Ma_sinh_vien = @maSV";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@maSV", txtMaSV.Text.Trim());
                        int count = (int)checkCmd.ExecuteScalar();

                        if (count > 0)
                        {
                            MessageBox.Show("Mã sinh viên đã tồn tại!", "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtMaSV.Focus();
                            throw new Exception(); // Để không reset trạng thái
                        }
                    }

                    // Parse ngày sinh
                    DateTime? ngaySinh = null;
                    if (!string.IsNullOrWhiteSpace(txtNgaySinh.Text))
                    {
                        if (DateTime.TryParseExact(txtNgaySinh.Text, "dd/MM/yyyy",
                            System.Globalization.CultureInfo.InvariantCulture,
                            System.Globalization.DateTimeStyles.None, out DateTime tempDate))
                        {
                            ngaySinh = tempDate;
                        }
                    }

                    // Lấy giá trị Email
                    string email = "";
                    if (this.Controls.Find("txtEmail", true).Length > 0)
                    {
                        TextBox txtEmail = (TextBox)this.Controls.Find("txtEmail", true)[0];
                        email = txtEmail.Text.Trim();
                    }

                    // Insert sinh viên mới
                    string insertQuery = @"INSERT INTO Sinh_vien 
                        (Ma_sinh_vien, Ho_ten, Lop, Khoa, Email, Ma_giang_vien, Ma_chuyen_nganh, Gioi_tinh, Ngay_sinh)
                        VALUES (@maSV, @hoTen, @lop, @khoa, @email, @maGV, @maCN, @gioiTinh, @ngaySinh)";

                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@maSV", txtMaSV.Text.Trim());
                        cmd.Parameters.AddWithValue("@hoTen", txtHoTenSV.Text.Trim());
                        cmd.Parameters.AddWithValue("@lop", string.IsNullOrWhiteSpace(txtLop.Text) ? (object)DBNull.Value : txtLop.Text.Trim());
                        cmd.Parameters.AddWithValue("@khoa", string.IsNullOrWhiteSpace(txtKhoa.Text) ? (object)DBNull.Value : txtKhoa.Text.Trim());
                        cmd.Parameters.AddWithValue("@email", string.IsNullOrWhiteSpace(email) ? (object)DBNull.Value : email);
                        cmd.Parameters.AddWithValue("@maGV", string.IsNullOrWhiteSpace(txtMaGiangVien.Text) ? (object)DBNull.Value : txtMaGiangVien.Text.Trim());
                        cmd.Parameters.AddWithValue("@maCN", string.IsNullOrWhiteSpace(txtMaChuyenNganh.Text) ? (object)DBNull.Value : txtMaChuyenNganh.Text.Trim());
                        cmd.Parameters.AddWithValue("@gioiTinh", string.IsNullOrWhiteSpace(txtGioiTinh.Text) ? (object)DBNull.Value : txtGioiTinh.Text.Trim());
                        cmd.Parameters.AddWithValue("@ngaySinh", ngaySinh.HasValue ? (object)ngaySinh.Value : DBNull.Value);

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Thêm sinh viên thành công!", "Thành công",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadDanhSachSinhVien();
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
                throw; // Để không reset trạng thái
            }
        }

        // Sửa thông tin sinh viên
        private void SuaSinhVien()
        {
            if (selectedRowIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần sửa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                throw new Exception(); // Để không reset trạng thái
            }

            if (string.IsNullOrWhiteSpace(txtHoTenSV.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên sinh viên!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTenSV.Focus();
                throw new Exception(); // Để không reset trạng thái
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Parse ngày sinh
                    DateTime? ngaySinh = null;
                    if (!string.IsNullOrWhiteSpace(txtNgaySinh.Text))
                    {
                        if (DateTime.TryParseExact(txtNgaySinh.Text, "dd/MM/yyyy",
                            System.Globalization.CultureInfo.InvariantCulture,
                            System.Globalization.DateTimeStyles.None, out DateTime tempDate))
                        {
                            ngaySinh = tempDate;
                        }
                    }

                    // Lấy giá trị Email
                    string email = "";
                    if (this.Controls.Find("txtEmail", true).Length > 0)
                    {
                        TextBox txtEmail = (TextBox)this.Controls.Find("txtEmail", true)[0];
                        email = txtEmail.Text.Trim();
                    }

                    string updateQuery = @"UPDATE Sinh_vien SET 
                        Ho_ten = @hoTen, 
                        Lop = @lop, 
                        Khoa = @khoa, 
                        Email = @email, 
                        Ma_giang_vien = @maGV, 
                        Ma_chuyen_nganh = @maCN, 
                        Gioi_tinh = @gioiTinh, 
                        Ngay_sinh = @ngaySinh
                        WHERE Ma_sinh_vien = @maSV";

                    using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@maSV", txtMaSV.Text.Trim());
                        cmd.Parameters.AddWithValue("@hoTen", txtHoTenSV.Text.Trim());
                        cmd.Parameters.AddWithValue("@lop", string.IsNullOrWhiteSpace(txtLop.Text) ? (object)DBNull.Value : txtLop.Text.Trim());
                        cmd.Parameters.AddWithValue("@khoa", string.IsNullOrWhiteSpace(txtKhoa.Text) ? (object)DBNull.Value : txtKhoa.Text.Trim());
                        cmd.Parameters.AddWithValue("@email", string.IsNullOrWhiteSpace(email) ? (object)DBNull.Value : email);
                        cmd.Parameters.AddWithValue("@maGV", string.IsNullOrWhiteSpace(txtMaGiangVien.Text) ? (object)DBNull.Value : txtMaGiangVien.Text.Trim());
                        cmd.Parameters.AddWithValue("@maCN", string.IsNullOrWhiteSpace(txtMaChuyenNganh.Text) ? (object)DBNull.Value : txtMaChuyenNganh.Text.Trim());
                        cmd.Parameters.AddWithValue("@gioiTinh", string.IsNullOrWhiteSpace(txtGioiTinh.Text) ? (object)DBNull.Value : txtGioiTinh.Text.Trim());
                        cmd.Parameters.AddWithValue("@ngaySinh", ngaySinh.HasValue ? (object)ngaySinh.Value : DBNull.Value);

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Cập nhật thông tin thành công!", "Thành công",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadDanhSachSinhVien();

                            // Giữ dòng đã chọn
                            if (selectedRowIndex < dgvSinhVien.Rows.Count)
                            {
                                dgvSinhVien.Rows[selectedRowIndex].Selected = true;
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
                throw; // Để không reset trạng thái
            }
        }

        // Xóa sinh viên
        private void XoaSinhVien()
        {
            if (selectedRowIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                throw new Exception(); // Để không reset trạng thái
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string deleteQuery = "DELETE FROM Sinh_vien WHERE Ma_sinh_vien = @maSV";

                    using (SqlCommand cmd = new SqlCommand(deleteQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@maSV", txtMaSV.Text.Trim());

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Xóa sinh viên thành công!", "Thành công",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadDanhSachSinhVien();
                            ClearTextBoxes();
                            selectedRowIndex = -1;
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                if (sqlEx.Number == 547) // Foreign key constraint error
                {
                    MessageBox.Show("Không thể xóa sinh viên này vì đang có dữ liệu liên quan (đồ án, tài khoản...)!",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Lỗi SQL: " + sqlEx.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                throw; // Để không reset trạng thái
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}