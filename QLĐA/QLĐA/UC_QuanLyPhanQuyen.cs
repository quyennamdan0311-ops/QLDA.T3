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
    public partial class UC_QuanLyPhanQuyen : DevExpress.XtraEditors.XtraUserControl
    {
        private string connectionString = "Data Source=DESKTOP-OREV608\\SQLEXPRESS;Initial Catalog=qldatn_final;Integrated Security=True;Encrypt=False";
        private SqlConnection conn;
        private DataTable dtPhanQuyen;
        private string currentAction = ""; // "Add", "Edit", "Delete", ""
        private int selectedRowIndex = -1;

        public UC_QuanLyPhanQuyen()
        {
            InitializeComponent();
            conn = new SqlConnection(connectionString);
            this.Load += QuanLyPhanQuyen_Load;
        }

        private void QuanLyPhanQuyen_Load(object sender, EventArgs e)
        {
            LoadDanhSachPhanQuyen();
            ConfigureDataGridView();
            ClearTextBoxes();
            SetNormalState();
        }

        // Tải danh sách phân quyền từ database
        private void LoadDanhSachPhanQuyen()
        {
            try
            {
                string query = @"SELECT 
                    Ma_tai_khoan, 
                    Ma_vai_tro
                FROM TK_vai_tro
                ORDER BY Ma_tai_khoan";

                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                {
                    dtPhanQuyen = new DataTable();
                    adapter.Fill(dtPhanQuyen);
                    dgvDoAn.DataSource = dtPhanQuyen;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách phân quyền: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Cấu hình DataGridView
        private void ConfigureDataGridView()
        {
            if (dgvDoAn.Columns.Count == 0) return;

            dgvDoAn.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDoAn.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDoAn.MultiSelect = false;
            dgvDoAn.ReadOnly = true;
            dgvDoAn.AllowUserToAddRows = false;

            // Đặt tiêu đề cột
            if (dgvDoAn.Columns["Ma_tai_khoan"] != null)
                dgvDoAn.Columns["Ma_tai_khoan"].HeaderText = "Mã tài khoản";
            if (dgvDoAn.Columns["Ma_vai_tro"] != null)
                dgvDoAn.Columns["Ma_vai_tro"].HeaderText = "Mã vai trò";

            // Đăng ký sự kiện CellClick
            dgvDoAn.CellClick += DgvDoAn_CellClick;
        }

        // Xử lý khi click vào cell
        private void DgvDoAn_CellClick(object sender, DataGridViewCellEventArgs e)
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
                DataGridViewRow row = dgvDoAn.Rows[rowIndex];

                txtMaTaiKhoan.Text = row.Cells["Ma_tai_khoan"].Value?.ToString() ?? "";
                txtMaVaiTro.Text = row.Cells["Ma_vai_tro"].Value?.ToString() ?? "";
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
            txtMaTaiKhoan.Clear();
            txtMaVaiTro.Clear();
        }

        // Thiết lập trạng thái ReadOnly cho TextBox
        private void SetTextBoxesReadOnly(bool isReadOnly)
        {
            // Mã tài khoản luôn ReadOnly khi sửa
            if (currentAction == "Edit")
            {
                txtMaTaiKhoan.ReadOnly = true;
            }
            else
            {
                txtMaTaiKhoan.ReadOnly = isReadOnly;
            }

            txtMaVaiTro.ReadOnly = isReadOnly;
        }

        // Thiết lập trạng thái bình thường (tất cả nút enabled)
        private void SetNormalState()
        {
            currentAction = "";

            // Nút Thêm luôn enabled
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
            txtMaTaiKhoan.Focus();

            MessageBox.Show("Vui lòng nhập thông tin phân quyền mới và nhấn 'Cập nhật'", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Nút SỬA
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (selectedRowIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn một dòng để sửa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            currentAction = "Edit";
            SetTextBoxesReadOnly(false);
            SetActionState();
            txtMaVaiTro.Focus();

            MessageBox.Show("Vui lòng chỉnh sửa thông tin và nhấn 'Cập nhật'", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Nút XÓA
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (selectedRowIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa phân quyền của tài khoản '{txtMaTaiKhoan.Text}'?",
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
                        ThemPhanQuyen();
                        break;
                    case "Edit":
                        SuaPhanQuyen();
                        break;
                    case "Delete":
                        XoaPhanQuyen();
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

        // Thêm phân quyền mới
        private void ThemPhanQuyen()
        {
            // Validate dữ liệu
            if (string.IsNullOrWhiteSpace(txtMaTaiKhoan.Text))
            {
                MessageBox.Show("Vui lòng nhập mã tài khoản!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaTaiKhoan.Focus();
                throw new Exception(); // Để không reset trạng thái
            }

            if (string.IsNullOrWhiteSpace(txtMaVaiTro.Text))
            {
                MessageBox.Show("Vui lòng nhập mã vai trò!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaVaiTro.Focus();
                throw new Exception(); // Để không reset trạng thái
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Kiểm tra mã tài khoản đã tồn tại chưa
                    string checkQuery = "SELECT COUNT(*) FROM TK_vai_tro WHERE Ma_tai_khoan = @maTaiKhoan";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@maTaiKhoan", txtMaTaiKhoan.Text.Trim());
                        int count = (int)checkCmd.ExecuteScalar();

                        if (count > 0)
                        {
                            MessageBox.Show("Mã tài khoản đã có phân quyền!", "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtMaTaiKhoan.Focus();
                            throw new Exception(); // Để không reset trạng thái
                        }
                    }

                    // Kiểm tra mã tài khoản có tồn tại trong bảng Tai_khoan không
                    string checkTKQuery = "SELECT COUNT(*) FROM Tai_khoan WHERE Ma_tai_khoan = @maTaiKhoan";
                    using (SqlCommand checkTKCmd = new SqlCommand(checkTKQuery, conn))
                    {
                        checkTKCmd.Parameters.AddWithValue("@maTaiKhoan", txtMaTaiKhoan.Text.Trim());
                        int tkCount = (int)checkTKCmd.ExecuteScalar();

                        if (tkCount == 0)
                        {
                            MessageBox.Show("Mã tài khoản không tồn tại trong hệ thống!\nVui lòng kiểm tra lại.", "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtMaTaiKhoan.Focus();
                            throw new Exception(); // Để không reset trạng thái
                        }
                    }

                    // Kiểm tra mã vai trò có tồn tại trong bảng Vai_tro không
                    string checkVTQuery = "SELECT COUNT(*) FROM Vai_tro WHERE Ma_vai_tro = @maVaiTro";
                    using (SqlCommand checkVTCmd = new SqlCommand(checkVTQuery, conn))
                    {
                        checkVTCmd.Parameters.AddWithValue("@maVaiTro", txtMaVaiTro.Text.Trim());
                        int vtCount = (int)checkVTCmd.ExecuteScalar();

                        if (vtCount == 0)
                        {
                            MessageBox.Show("Mã vai trò không tồn tại trong hệ thống!\nVui lòng kiểm tra lại.", "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtMaVaiTro.Focus();
                            throw new Exception(); // Để không reset trạng thái
                        }
                    }

                    // Insert phân quyền mới
                    string insertQuery = @"INSERT INTO TK_vai_tro (Ma_tai_khoan, Ma_vai_tro)
                                         VALUES (@maTaiKhoan, @maVaiTro)";

                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@maTaiKhoan", txtMaTaiKhoan.Text.Trim());
                        cmd.Parameters.AddWithValue("@maVaiTro", txtMaVaiTro.Text.Trim());

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Thêm phân quyền thành công!", "Thành công",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadDanhSachPhanQuyen();
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
                    MessageBox.Show("Lỗi: Mã tài khoản hoặc mã vai trò không hợp lệ!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Lỗi SQL: " + sqlEx.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                throw; // Để không reset trạng thái
            }
        }

        // Sửa thông tin phân quyền
        private void SuaPhanQuyen()
        {
            if (selectedRowIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn dòng cần sửa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                throw new Exception(); // Để không reset trạng thái
            }

            if (string.IsNullOrWhiteSpace(txtMaVaiTro.Text))
            {
                MessageBox.Show("Vui lòng nhập mã vai trò!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaVaiTro.Focus();
                throw new Exception(); // Để không reset trạng thái
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Kiểm tra mã vai trò có tồn tại không
                    string checkVTQuery = "SELECT COUNT(*) FROM Vai_tro WHERE Ma_vai_tro = @maVaiTro";
                    using (SqlCommand checkVTCmd = new SqlCommand(checkVTQuery, conn))
                    {
                        checkVTCmd.Parameters.AddWithValue("@maVaiTro", txtMaVaiTro.Text.Trim());
                        int vtCount = (int)checkVTCmd.ExecuteScalar();

                        if (vtCount == 0)
                        {
                            MessageBox.Show("Mã vai trò không tồn tại trong hệ thống!\nVui lòng kiểm tra lại.", "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtMaVaiTro.Focus();
                            throw new Exception(); // Để không reset trạng thái
                        }
                    }

                    string updateQuery = @"UPDATE TK_vai_tro SET 
                                         Ma_vai_tro = @maVaiTro
                                         WHERE Ma_tai_khoan = @maTaiKhoan";

                    using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@maTaiKhoan", txtMaTaiKhoan.Text.Trim());
                        cmd.Parameters.AddWithValue("@maVaiTro", txtMaVaiTro.Text.Trim());

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Cập nhật phân quyền thành công!", "Thành công",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadDanhSachPhanQuyen();

                            // Giữ dòng đã chọn
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
                throw; // Để không reset trạng thái
            }
        }

        // Xóa phân quyền
        private void XoaPhanQuyen()
        {
            if (selectedRowIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                throw new Exception(); // Để không reset trạng thái
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string deleteQuery = "DELETE FROM TK_vai_tro WHERE Ma_tai_khoan = @maTaiKhoan";

                    using (SqlCommand cmd = new SqlCommand(deleteQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@maTaiKhoan", txtMaTaiKhoan.Text.Trim());

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Xóa phân quyền thành công!", "Thành công",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadDanhSachPhanQuyen();
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
                    MessageBox.Show("Không thể xóa phân quyền này vì đang có dữ liệu liên quan!",
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
    }
}