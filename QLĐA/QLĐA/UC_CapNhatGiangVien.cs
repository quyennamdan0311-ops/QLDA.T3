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
    public partial class UC_CapNhatGiangVien : DevExpress.XtraEditors.XtraUserControl
    {
        private string connectionString = "Data Source=DESKTOP-OREV608\\SQLEXPRESS;Initial Catalog=qlđatn_final;Integrated Security=True;Encrypt=False";
        private SqlConnection conn;
        private DataTable dtGiangVien;
        private bool isAddingNew = false;
        private bool isEditing = false;
        private int currentRowIndex = -1;

        public UC_CapNhatGiangVien()
        {
            InitializeComponent();
            conn = new SqlConnection(connectionString);
            this.Load += UC_CapNhatGiangVien_Load;
        }

        private void UC_CapNhatGiangVien_Load(object sender, EventArgs e)
        {
            LoadDanhSachGiangVien();
            ConfigureDataGridView();
            SetControlsReadOnly(true);
            ConfigureButtonStates(false, false, false);
        }

        // ===== TẢI DANH SÁCH GIẢNG VIÊN =====
        private void LoadDanhSachGiangVien()
        {
            try
            {
                string query = @"SELECT Ma_giang_vien, Ho_ten, Gioi_tinh, Ngay_sinh, 
                                Email, Bang_cap, Chuc_danh
                         FROM Giang_vien
                         ORDER BY Ma_giang_vien";

                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                {
                    dtGiangVien = new DataTable();
                    adapter.Fill(dtGiangVien);
                    dgvGiangVien.DataSource = dtGiangVien;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===== ĐỊNH DẠNG DATAGRIDVIEW =====
        private void ConfigureDataGridView()
        {
            if (dgvGiangVien.Columns.Count == 0) return;

            dgvGiangVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvGiangVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvGiangVien.MultiSelect = false;
            dgvGiangVien.ReadOnly = true;
            dgvGiangVien.AllowUserToAddRows = false;

            // Đặt tên hiển thị cho các cột
            if (dgvGiangVien.Columns["Ma_giang_vien"] != null)
                dgvGiangVien.Columns["Ma_giang_vien"].HeaderText = "Mã giảng viên";
            if (dgvGiangVien.Columns["Ho_ten"] != null)
                dgvGiangVien.Columns["Ho_ten"].HeaderText = "Họ tên";
            if (dgvGiangVien.Columns["Gioi_tinh"] != null)
                dgvGiangVien.Columns["Gioi_tinh"].HeaderText = "Giới tính";
            if (dgvGiangVien.Columns["Ngay_sinh"] != null)
            {
                dgvGiangVien.Columns["Ngay_sinh"].HeaderText = "Ngày sinh";
                dgvGiangVien.Columns["Ngay_sinh"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
            if (dgvGiangVien.Columns["Email"] != null)
                dgvGiangVien.Columns["Email"].HeaderText = "Email";
            if (dgvGiangVien.Columns["Bang_cap"] != null)
                dgvGiangVien.Columns["Bang_cap"].HeaderText = "Bằng cấp";
            if (dgvGiangVien.Columns["Chuc_danh"] != null)
                dgvGiangVien.Columns["Chuc_danh"].HeaderText = "Chức danh";

            // Sự kiện click vào cell
            dgvGiangVien.CellClick += DgvGiangVien_CellClick;
        }

        // ===== SỰ KIỆN CLICK VÀO CELL =====
        private void DgvGiangVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvGiangVien.Rows.Count)
            {
                currentRowIndex = e.RowIndex;
                DisplayGiangVienDetail(e.RowIndex);
                
                // Cho phép Sửa và Xóa khi chọn dòng
                if (!isAddingNew && !isEditing)
                {
                    ConfigureButtonStates(true, true, false);
                }
            }
        }

        // ===== HIỂN THỊ CHI TIẾT GIẢNG VIÊN =====
        private void DisplayGiangVienDetail(int rowIndex)
        {
            try
            {
                DataGridViewRow row = dgvGiangVien.Rows[rowIndex];

                txtMaGV.Text = row.Cells["Ma_giang_vien"].Value?.ToString() ?? "";
                txtHoTenGV.Text = row.Cells["Ho_ten"].Value?.ToString() ?? "";
                txtGioiTinh.Text = row.Cells["Gioi_tinh"].Value?.ToString() ?? "";
                
                if (row.Cells["Ngay_sinh"].Value != null && row.Cells["Ngay_sinh"].Value != DBNull.Value)
                    txtNgaySinh.Text = Convert.ToDateTime(row.Cells["Ngay_sinh"].Value).ToString("dd/MM/yyyy");
                else
                    txtNgaySinh.Text = "";

                txtEmail.Text = row.Cells["Email"].Value?.ToString() ?? "";
                txtBangCap.Text = row.Cells["Bang_cap"].Value?.ToString() ?? "";
                txtChucDanh.Text = row.Cells["Chuc_danh"].Value?.ToString() ?? "";
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Lỗi khi hiển thị chi tiết: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===== NÚT THÊM =====
        private void btnThem_Click(object sender, EventArgs e)
        {
            // Hiển thị thông báo hướng dẫn
            XtraMessageBox.Show(
                "Vui lòng nhập đầy đủ thông tin giảng viên mới vào form.\n\n" +
                "Sau khi nhập xong, nhấn nút 'Cập nhật' để lưu thông tin vào hệ thống.",
                "Hướng dẫn thêm giảng viên",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            isAddingNew = true;
            isEditing = false;
            
            // Xóa nội dung các textbox
            ClearTextBoxes();
            
            // Cho phép nhập liệu
            SetControlsReadOnly(false);
            
            // Focus vào mã giảng viên
            txtMaGV.Focus();
            
            // Cấu hình trạng thái button: Chỉ có Cập nhật được bật
            ConfigureButtonStates(false, false, true);
            
            // Bỏ chọn dòng trong DataGridView
            dgvGiangVien.ClearSelection();
            currentRowIndex = -1;
        }

        // ===== NÚT SỬA =====
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (currentRowIndex < 0)
            {
                XtraMessageBox.Show("Vui lòng chọn giảng viên cần sửa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Hiển thị thông báo hướng dẫn
            XtraMessageBox.Show(
                "Bạn có thể chỉnh sửa thông tin giảng viên trong form.\n\n" +
                "Lưu ý: Không thể thay đổi mã giảng viên.\n\n" +
                "Sau khi chỉnh sửa xong, nhấn nút 'Cập nhật' để lưu thay đổi.",
                "Hướng dẫn sửa thông tin",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            isEditing = true;
            isAddingNew = false;
            
            // Cho phép chỉnh sửa (trừ mã giảng viên)
            SetControlsReadOnly(false);
            txtMaGV.ReadOnly = true; // Không cho sửa mã
            
            // Focus vào họ tên
            txtHoTenGV.Focus();
            
            // Cấu hình trạng thái button: Chỉ có Cập nhật được bật
            ConfigureButtonStates(false, false, true);
        }

        // ===== NÚT XÓA =====
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (currentRowIndex < 0)
            {
                XtraMessageBox.Show("Vui lòng chọn giảng viên cần xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Hiển thị hộp thoại xác nhận xóa với thông báo rõ ràng
            DialogResult result = XtraMessageBox.Show(
                $"Bạn có chắc chắn muốn xóa giảng viên:\n\n" +
                $"Mã GV: {txtMaGV.Text}\n" +
                $"Họ tên: {txtHoTenGV.Text}\n\n" +
                $"Thao tác này không thể hoàn tác!",
                "Xác nhận xóa giảng viên",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                DeleteGiangVien();
            }
        }

        // ===== XÓA GIẢNG VIÊN =====
        private void DeleteGiangVien()
        {
            try
            {
                string maGV = txtMaGV.Text.Trim();

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Kiểm tra xem giảng viên có đang hướng dẫn sinh viên không
                    string checkQuery = "SELECT COUNT(*) FROM Sinh_vien WHERE Ma_giang_vien = @maGV";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@maGV", maGV);
                        int count = (int)checkCmd.ExecuteScalar();

                        if (count > 0)
                        {
                            XtraMessageBox.Show(
                                "Không thể xóa giảng viên này vì đang hướng dẫn sinh viên!\n\n" +
                                $"Có {count} sinh viên đang được hướng dẫn bởi giảng viên này.",
                                "Cảnh báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // Xóa giảng viên
                    string deleteQuery = "DELETE FROM Giang_vien WHERE Ma_giang_vien = @maGV";
                    using (SqlCommand deleteCmd = new SqlCommand(deleteQuery, conn))
                    {
                        deleteCmd.Parameters.AddWithValue("@maGV", maGV);
                        int rowsAffected = deleteCmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            XtraMessageBox.Show(
                                "Xóa giảng viên thành công!\n\n" +
                                "Dữ liệu đã được cập nhật trong hệ thống.",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            
                            // Reload dữ liệu
                            LoadDanhSachGiangVien();
                            ClearTextBoxes();
                            currentRowIndex = -1;
                            ConfigureButtonStates(false, false, false);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Lỗi khi xóa: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===== NÚT CẬP NHẬT =====
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            // Validate dữ liệu
            if (!ValidateInput())
                return;

            if (isAddingNew)
            {
                ThemGiangVien();
            }
            else if (isEditing)
            {
                SuaGiangVien();
            }
        }

        // ===== VALIDATE DỮ LIỆU =====
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtMaGV.Text))
            {
                XtraMessageBox.Show("Vui lòng nhập mã giảng viên!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaGV.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtHoTenGV.Text))
            {
                XtraMessageBox.Show("Vui lòng nhập họ tên!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTenGV.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtGioiTinh.Text))
            {
                XtraMessageBox.Show("Vui lòng nhập giới tính!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGioiTinh.Focus();
                return false;
            }

            // Validate ngày sinh
            if (!string.IsNullOrWhiteSpace(txtNgaySinh.Text))
            {
                DateTime ngaySinh;
                if (!DateTime.TryParseExact(txtNgaySinh.Text, "dd/MM/yyyy", 
                    System.Globalization.CultureInfo.InvariantCulture, 
                    System.Globalization.DateTimeStyles.None, out ngaySinh))
                {
                    XtraMessageBox.Show(
                        "Ngày sinh không đúng định dạng!\n\n" +
                        "Vui lòng nhập theo định dạng: dd/MM/yyyy\n" +
                        "Ví dụ: 15/08/1985",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    txtNgaySinh.Focus();
                    return false;
                }
            }

            return true;
        }

        // ===== THÊM GIẢNG VIÊN =====
        private void ThemGiangVien()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Kiểm tra mã giảng viên đã tồn tại chưa
                    string checkQuery = "SELECT COUNT(*) FROM Giang_vien WHERE Ma_giang_vien = @maGV";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@maGV", txtMaGV.Text.Trim());
                        int count = (int)checkCmd.ExecuteScalar();

                        if (count > 0)
                        {
                            XtraMessageBox.Show(
                                "Mã giảng viên đã tồn tại trong hệ thống!\n\n" +
                                "Vui lòng sử dụng mã giảng viên khác.",
                                "Cảnh báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                            txtMaGV.Focus();
                            return;
                        }
                    }

                    // Thêm giảng viên mới
                    string insertQuery = @"INSERT INTO Giang_vien 
                                          (Ma_giang_vien, Ho_ten, Gioi_tinh, Ngay_sinh, Email, Bang_cap, Chuc_danh)
                                          VALUES (@maGV, @hoTen, @gioiTinh, @ngaySinh, @email, @bangCap, @chucDanh)";

                    using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
                    {
                        insertCmd.Parameters.AddWithValue("@maGV", txtMaGV.Text.Trim());
                        insertCmd.Parameters.AddWithValue("@hoTen", txtHoTenGV.Text.Trim());
                        insertCmd.Parameters.AddWithValue("@gioiTinh", txtGioiTinh.Text.Trim());
                        
                        // Parse ngày sinh
                        if (!string.IsNullOrWhiteSpace(txtNgaySinh.Text))
                        {
                            DateTime ngaySinh = DateTime.ParseExact(txtNgaySinh.Text, "dd/MM/yyyy", 
                                System.Globalization.CultureInfo.InvariantCulture);
                            insertCmd.Parameters.AddWithValue("@ngaySinh", ngaySinh);
                        }
                        else
                        {
                            insertCmd.Parameters.AddWithValue("@ngaySinh", DBNull.Value);
                        }

                        insertCmd.Parameters.AddWithValue("@email", 
                            string.IsNullOrWhiteSpace(txtEmail.Text) ? (object)DBNull.Value : txtEmail.Text.Trim());
                        insertCmd.Parameters.AddWithValue("@bangCap", 
                            string.IsNullOrWhiteSpace(txtBangCap.Text) ? (object)DBNull.Value : txtBangCap.Text.Trim());
                        insertCmd.Parameters.AddWithValue("@chucDanh", 
                            string.IsNullOrWhiteSpace(txtChucDanh.Text) ? (object)DBNull.Value : txtChucDanh.Text.Trim());

                        int rowsAffected = insertCmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            XtraMessageBox.Show("Thêm giảng viên thành công!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            
                            // Reset trạng thái
                            isAddingNew = false;
                            LoadDanhSachGiangVien();
                            SetControlsReadOnly(true);
                            ConfigureButtonStates(false, false, false);
                            
                            // Chọn dòng vừa thêm
                            SelectRowByMaGV(txtMaGV.Text.Trim());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Lỗi khi thêm: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===== SỬA GIẢNG VIÊN =====
        private void SuaGiangVien()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string updateQuery = @"UPDATE Giang_vien 
                                          SET Ho_ten = @hoTen, 
                                              Gioi_tinh = @gioiTinh, 
                                              Ngay_sinh = @ngaySinh, 
                                              Email = @email, 
                                              Bang_cap = @bangCap, 
                                              Chuc_danh = @chucDanh
                                          WHERE Ma_giang_vien = @maGV";

                    using (SqlCommand updateCmd = new SqlCommand(updateQuery, conn))
                    {
                        updateCmd.Parameters.AddWithValue("@maGV", txtMaGV.Text.Trim());
                        updateCmd.Parameters.AddWithValue("@hoTen", txtHoTenGV.Text.Trim());
                        updateCmd.Parameters.AddWithValue("@gioiTinh", txtGioiTinh.Text.Trim());
                        
                        // Parse ngày sinh
                        if (!string.IsNullOrWhiteSpace(txtNgaySinh.Text))
                        {
                            DateTime ngaySinh = DateTime.ParseExact(txtNgaySinh.Text, "dd/MM/yyyy", 
                                System.Globalization.CultureInfo.InvariantCulture);
                            updateCmd.Parameters.AddWithValue("@ngaySinh", ngaySinh);
                        }
                        else
                        {
                            updateCmd.Parameters.AddWithValue("@ngaySinh", DBNull.Value);
                        }

                        updateCmd.Parameters.AddWithValue("@email", 
                            string.IsNullOrWhiteSpace(txtEmail.Text) ? (object)DBNull.Value : txtEmail.Text.Trim());
                        updateCmd.Parameters.AddWithValue("@bangCap", 
                            string.IsNullOrWhiteSpace(txtBangCap.Text) ? (object)DBNull.Value : txtBangCap.Text.Trim());
                        updateCmd.Parameters.AddWithValue("@chucDanh", 
                            string.IsNullOrWhiteSpace(txtChucDanh.Text) ? (object)DBNull.Value : txtChucDanh.Text.Trim());

                        int rowsAffected = updateCmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            XtraMessageBox.Show(
                                "Cập nhật thông tin giảng viên thành công!\n\n" +
                                $"Mã GV: {txtMaGV.Text}\n" +
                                $"Họ tên: {txtHoTenGV.Text}\n\n" +
                                "Dữ liệu đã được cập nhật trong hệ thống.",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            
                            // Reset trạng thái
                            isEditing = false;
                            LoadDanhSachGiangVien();
                            SetControlsReadOnly(true);
                            ConfigureButtonStates(false, false, false);
                            
                            // Chọn lại dòng vừa sửa
                            SelectRowByMaGV(txtMaGV.Text.Trim());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Lỗi khi cập nhật: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===== CHỌN DÒNG THEO MÃ GIẢNG VIÊN =====
        private void SelectRowByMaGV(string maGV)
        {
            for (int i = 0; i < dgvGiangVien.Rows.Count; i++)
            {
                if (dgvGiangVien.Rows[i].Cells["Ma_giang_vien"].Value?.ToString() == maGV)
                {
                    dgvGiangVien.ClearSelection();
                    dgvGiangVien.Rows[i].Selected = true;
                    dgvGiangVien.CurrentCell = dgvGiangVien.Rows[i].Cells[0];
                    currentRowIndex = i;
                    DisplayGiangVienDetail(i);
                    ConfigureButtonStates(true, true, false);
                    break;
                }
            }
        }

        // ===== XÓA NỘI DUNG TEXTBOX =====
        private void ClearTextBoxes()
        {
            txtMaGV.Clear();
            txtHoTenGV.Clear();
            txtGioiTinh.Clear();
            txtNgaySinh.Clear();
            txtEmail.Clear();
            txtBangCap.Clear();
            txtChucDanh.Clear();
        }

        // ===== ĐẶT TRẠNG THÁI READONLY CHO CONTROLS =====
        private void SetControlsReadOnly(bool readOnly)
        {
            txtMaGV.ReadOnly = readOnly;
            txtHoTenGV.ReadOnly = readOnly;
            txtGioiTinh.ReadOnly = readOnly;
            txtNgaySinh.ReadOnly = readOnly;
            txtEmail.ReadOnly = readOnly;
            txtBangCap.ReadOnly = readOnly;
            txtChucDanh.ReadOnly = readOnly;
        }

        // ===== CẤU HÌNH TRẠNG THÁI CÁC NÚT =====
        private void ConfigureButtonStates(bool suaEnabled, bool xoaEnabled, bool capNhatEnabled)
        {
            btnThem.Enabled = !capNhatEnabled;
            btnSua.Enabled = suaEnabled && !capNhatEnabled;
            btnXoa.Enabled = xoaEnabled && !capNhatEnabled;
            btnCapNhat.Enabled = capNhatEnabled;
        }
    }
}
