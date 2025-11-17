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
                    TKV.Ma_tai_khoan, 
                    TK.Ten_dang_nhap,
                    TK.Mat_khau,
                    TK.Loai_nguoi_dung,
                    TKV.Ma_vai_tro,
                    VT.Ten_vai_tro,
                    TK.Ma_sinh_vien,
                    TK.Ma_giang_vien
                FROM TK_vai_tro TKV
                INNER JOIN Tai_khoan TK ON TKV.Ma_tai_khoan = TK.Ma_tai_khoan
                INNER JOIN Vai_tro VT ON TKV.Ma_vai_tro = VT.Ma_vai_tro
                ORDER BY TKV.Ma_tai_khoan";

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

            
            if (dgvDoAn.Columns["Ma_tai_khoan"] != null)
                dgvDoAn.Columns["Ma_tai_khoan"].HeaderText = "Mã tài khoản";
            if (dgvDoAn.Columns["Ten_dang_nhap"] != null)
                dgvDoAn.Columns["Ten_dang_nhap"].HeaderText = "Tên đăng nhập";
            if (dgvDoAn.Columns["Mat_khau"] != null)
            {
                dgvDoAn.Columns["Mat_khau"].HeaderText = "Mật khẩu";
                // Ẩn mật khẩu trong DataGridView bằng cách hiển thị dấu *
                dgvDoAn.Columns["Mat_khau"].DefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Regular);
                dgvDoAn.Columns["Mat_khau"].DefaultCellStyle.ForeColor = Color.Gray;
            }
            if (dgvDoAn.Columns["Loai_nguoi_dung"] != null)
                dgvDoAn.Columns["Loai_nguoi_dung"].HeaderText = "Loại người dùng";
            if (dgvDoAn.Columns["Ma_vai_tro"] != null)
                dgvDoAn.Columns["Ma_vai_tro"].HeaderText = "Mã vai trò";
            if (dgvDoAn.Columns["Ten_vai_tro"] != null)
                dgvDoAn.Columns["Ten_vai_tro"].HeaderText = "Tên vai trò";
            if (dgvDoAn.Columns["Ma_sinh_vien"] != null)
                dgvDoAn.Columns["Ma_sinh_vien"].HeaderText = "Mã sinh viên";
            if (dgvDoAn.Columns["Ma_giang_vien"] != null)
                dgvDoAn.Columns["Ma_giang_vien"].HeaderText = "Mã giảng viên";

           
            dgvDoAn.CellClick += DgvDoAn_CellClick;
            dgvDoAn.CellFormatting += DgvDoAn_CellFormatting;
        }

        // Ẩn mật khẩu trong DataGridView
        private void DgvDoAn_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDoAn.Columns[e.ColumnIndex].Name == "Mat_khau" && e.Value != null)
            {
                string password = e.Value.ToString();
                e.Value = new string('●', password.Length); // Hiển thị dấu ●
            }
        }

        // Xử lý khi click vào cell
        private void DgvDoAn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedRowIndex = e.RowIndex;

              
                if (currentAction == "" || currentAction == "Edit" || currentAction == "Delete")
                {
                    DisplayDataInTextBoxes(e.RowIndex);

                    
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
                txtTenDangNhap.Text = row.Cells["Ten_dang_nhap"].Value?.ToString() ?? "";
                
                // Hiển thị mật khẩu thật (không ẩn) trong TextBox để có thể sửa
                txtMatKhau.Text = row.Cells["Mat_khau"].Value?.ToString() ?? "";
                
                txtLoaiNguoiDung.Text = row.Cells["Loai_nguoi_dung"].Value?.ToString() ?? "";
                txtMaVaiTro.Text = row.Cells["Ma_vai_tro"].Value?.ToString() ?? "";
                txtTenVaiTro.Text = row.Cells["Ten_vai_tro"].Value?.ToString() ?? "";
                txtMaSinhVien.Text = row.Cells["Ma_sinh_vien"].Value?.ToString() ?? "";
                txtMaGiangVien.Text = row.Cells["Ma_giang_vien"].Value?.ToString() ?? "";
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
            txtTenDangNhap.Clear();
            txtMatKhau.Clear();
            txtTenVaiTro.Clear();
            txtLoaiNguoiDung.Clear();
            txtMaSinhVien.Clear();
            txtMaGiangVien.Clear();
        }

        
        private void SetTextBoxesReadOnly(bool isReadOnly)
        {
            // Mã tài khoản luôn ReadOnly khi sửa
            if (currentAction == "Edit")
            {
                txtMaTaiKhoan.ReadOnly = true;
                txtTenDangNhap.ReadOnly = true; // Không cho sửa tên đăng nhập
                txtMatKhau.ReadOnly = isReadOnly; // Cho phép sửa mật khẩu
                txtLoaiNguoiDung.ReadOnly = isReadOnly; // Cho phép sửa loại người dùng
                txtMaVaiTro.ReadOnly = isReadOnly; // Cho phép sửa mã vai trò
                txtTenVaiTro.ReadOnly = isReadOnly; // Cho phép sửa tên vai trò
            }
            else if (currentAction == "Add")
            {
                txtMaTaiKhoan.ReadOnly = isReadOnly;
                txtTenDangNhap.ReadOnly = isReadOnly; // Cho phép nhập tên đăng nhập khi thêm
                txtMatKhau.ReadOnly = isReadOnly; // Cho phép nhập mật khẩu khi thêm
                txtLoaiNguoiDung.ReadOnly = isReadOnly; // Cho phép nhập loại người dùng khi thêm
                txtMaVaiTro.ReadOnly = isReadOnly; // Cho phép nhập mã vai trò khi thêm
                txtTenVaiTro.ReadOnly = isReadOnly; // Cho phép nhập tên vai trò khi thêm
            }
            else
            {
                txtMaTaiKhoan.ReadOnly = true;
                txtTenDangNhap.ReadOnly = true;
                txtMatKhau.ReadOnly = true;
                txtLoaiNguoiDung.ReadOnly = true;
                txtMaVaiTro.ReadOnly = true;
                txtTenVaiTro.ReadOnly = true;
            }

            txtMaSinhVien.ReadOnly = isReadOnly;
            txtMaGiangVien.ReadOnly = isReadOnly;
        }

        // Thiết lập trạng thái bình thường (tất cả nút enabled)
        private void SetNormalState()
        {
            currentAction = "";

         
            btnThem.Enabled = true;

          
            btnSua.Enabled = selectedRowIndex >= 0;
            btnXoa.Enabled = selectedRowIndex >= 0;

           
            btnCapNhat.Enabled = false;

        
            SetTextBoxesReadOnly(true);
        }

        // Thiết lập trạng thái đang thao tác (Thêm/Sửa/Xóa)
        private void SetActionState()
        {
            
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

        
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

            MessageBox.Show("Vui lòng nhập thông tin tài khoản mới:\n\n" +
                "1. Nhập Mã sinh viên HOẶC Mã giảng viên (không nhập cả hai)\n" +
                "2. Nhập Tên đăng nhập (duy nhất)\n" +
                "3. Nhập Mật khẩu (bắt buộc)\n" +
                "4. Nhập Loại người dùng (VD: Admin, Sinh viên, Giảng viên)\n" +
                "5. Nhập Mã vai trò và Tên vai trò\n\n" +
                "Lưu ý: Mỗi sinh viên/giảng viên chỉ được có 1 tài khoản!", 
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            txtLoaiNguoiDung.Focus();

            MessageBox.Show("Vui lòng chỉnh sửa thông tin và nhấn 'Cập nhật'\n\n" +
                "Lưu ý: \n" +
                "- Không thể sửa Mã tài khoản và Tên đăng nhập\n" +
                "- Có thể sửa Mật khẩu, Loại người dùng, Mã vai trò, Tên vai trò, Mã sinh viên/giảng viên", "Thông báo",
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
                $"Bạn có chắc chắn muốn xóa tài khoản '{txtTenDangNhap.Text}' (Mã: {txtMaTaiKhoan.Text})?\n\n" +
                "Cảnh báo: Thao tác này sẽ xóa cả phân quyền của tài khoản!",
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
                
                SetNormalState();
            }
        }

        // Thêm phân quyền mới
        private void ThemPhanQuyen()
        {
            // Validate dữ liệu cơ bản
            if (string.IsNullOrWhiteSpace(txtMaTaiKhoan.Text))
            {
                MessageBox.Show("Vui lòng nhập mã tài khoản!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaTaiKhoan.Focus();
                throw new Exception(); 
            }

            if (string.IsNullOrWhiteSpace(txtTenDangNhap.Text))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenDangNhap.Focus();
                throw new Exception(); 
            }

            if (string.IsNullOrWhiteSpace(txtMatKhau.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhau.Focus();
                throw new Exception(); 
            }

            if (txtMatKhau.Text.Length < 6)
            {
                MessageBox.Show("Mật khẩu phải có ít nhất 6 ký tự!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhau.Focus();
                throw new Exception(); 
            }

            if (string.IsNullOrWhiteSpace(txtLoaiNguoiDung.Text))
            {
                MessageBox.Show("Vui lòng nhập loại người dùng!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLoaiNguoiDung.Focus();
                throw new Exception(); 
            }

            if (string.IsNullOrWhiteSpace(txtMaVaiTro.Text))
            {
                MessageBox.Show("Vui lòng nhập mã vai trò!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaVaiTro.Focus();
                throw new Exception(); 
            }

            if (string.IsNullOrWhiteSpace(txtTenVaiTro.Text))
            {
                MessageBox.Show("Vui lòng nhập tên vai trò!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenVaiTro.Focus();
                throw new Exception(); 
            }

            // Kiểm tra chỉ nhập một trong hai: Mã sinh viên hoặc Mã giảng viên
            bool coMaSinhVien = !string.IsNullOrWhiteSpace(txtMaSinhVien.Text);
            bool coMaGiangVien = !string.IsNullOrWhiteSpace(txtMaGiangVien.Text);

            if (!coMaSinhVien && !coMaGiangVien)
            {
                MessageBox.Show("Vui lòng nhập Mã sinh viên HOẶC Mã giảng viên!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaSinhVien.Focus();
                throw new Exception();
            }

            if (coMaSinhVien && coMaGiangVien)
            {
                MessageBox.Show("Chỉ nhập Mã sinh viên HOẶC Mã giảng viên, không nhập cả hai!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaSinhVien.Focus();
                throw new Exception();
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            // Kiểm tra mã sinh viên hoặc mã giảng viên có tồn tại và chưa có tài khoản
                            if (coMaSinhVien)
                            {
                                string checkSVQuery = "SELECT COUNT(*) FROM Sinh_vien WHERE Ma_sinh_vien = @maSinhVien";
                                using (SqlCommand checkSVCmd = new SqlCommand(checkSVQuery, conn, transaction))
                                {
                                    checkSVCmd.Parameters.AddWithValue("@maSinhVien", txtMaSinhVien.Text.Trim());
                                    int svCount = (int)checkSVCmd.ExecuteScalar();

                                    if (svCount == 0)
                                    {
                                        MessageBox.Show("Mã sinh viên không tồn tại trong hệ thống!\nVui lòng kiểm tra lại.", "Lỗi",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        txtMaSinhVien.Focus();
                                        throw new Exception();
                                    }
                                }

                                // Kiểm tra sinh viên đã có tài khoản chưa
                                string checkSVTKQuery = "SELECT COUNT(*) FROM Tai_khoan WHERE Ma_sinh_vien = @maSinhVien";
                                using (SqlCommand checkSVTKCmd = new SqlCommand(checkSVTKQuery, conn, transaction))
                                {
                                    checkSVTKCmd.Parameters.AddWithValue("@maSinhVien", txtMaSinhVien.Text.Trim());
                                    int tkCount = (int)checkSVTKCmd.ExecuteScalar();

                                    if (tkCount > 0)
                                    {
                                        MessageBox.Show("Sinh viên này đã có tài khoản!\nMỗi sinh viên chỉ được có 1 tài khoản.", "Lỗi",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        txtMaSinhVien.Focus();
                                        throw new Exception();
                                    }
                                }
                            }

                            if (coMaGiangVien)
                            {
                                string checkGVQuery = "SELECT COUNT(*) FROM Giang_vien WHERE Ma_giang_vien = @maGiangVien";
                                using (SqlCommand checkGVCmd = new SqlCommand(checkGVQuery, conn, transaction))
                                {
                                    checkGVCmd.Parameters.AddWithValue("@maGiangVien", txtMaGiangVien.Text.Trim());
                                    int gvCount = (int)checkGVCmd.ExecuteScalar();

                                    if (gvCount == 0)
                                    {
                                        MessageBox.Show("Mã giảng viên không tồn tại trong hệ thống!\nVui lòng kiểm tra lại.", "Lỗi",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        txtMaGiangVien.Focus();
                                        throw new Exception();
                                    }
                                }

                                // Kiểm tra giảng viên đã có tài khoản chưa
                                string checkGVTKQuery = "SELECT COUNT(*) FROM Tai_khoan WHERE Ma_giang_vien = @maGiangVien";
                                using (SqlCommand checkGVTKCmd = new SqlCommand(checkGVTKQuery, conn, transaction))
                                {
                                    checkGVTKCmd.Parameters.AddWithValue("@maGiangVien", txtMaGiangVien.Text.Trim());
                                    int tkCount = (int)checkGVTKCmd.ExecuteScalar();

                                    if (tkCount > 0)
                                    {
                                        MessageBox.Show("Giảng viên này đã có tài khoản!\nMỗi giảng viên chỉ được có 1 tài khoản.", "Lỗi",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        txtMaGiangVien.Focus();
                                        throw new Exception();
                                    }
                                }
                            }

                            // Kiểm tra mã tài khoản đã tồn tại chưa
                            string checkTKQuery = "SELECT COUNT(*) FROM Tai_khoan WHERE Ma_tai_khoan = @maTaiKhoan";
                            using (SqlCommand checkTKCmd = new SqlCommand(checkTKQuery, conn, transaction))
                            {
                                checkTKCmd.Parameters.AddWithValue("@maTaiKhoan", txtMaTaiKhoan.Text.Trim());
                                int tkCount = (int)checkTKCmd.ExecuteScalar();

                                if (tkCount > 0)
                                {
                                    MessageBox.Show("Mã tài khoản đã tồn tại!\nVui lòng sử dụng mã khác.", "Lỗi",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    txtMaTaiKhoan.Focus();
                                    throw new Exception(); 
                                }
                            }

                            // Kiểm tra tên đăng nhập đã tồn tại chưa
                            string checkTenDNQuery = "SELECT COUNT(*) FROM Tai_khoan WHERE Ten_dang_nhap = @tenDangNhap";
                            using (SqlCommand checkTenDNCmd = new SqlCommand(checkTenDNQuery, conn, transaction))
                            {
                                checkTenDNCmd.Parameters.AddWithValue("@tenDangNhap", txtTenDangNhap.Text.Trim());
                                int dnCount = (int)checkTenDNCmd.ExecuteScalar();

                                if (dnCount > 0)
                                {
                                    MessageBox.Show("Tên đăng nhập đã tồn tại!\nVui lòng chọn tên đăng nhập khác.", "Lỗi",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    txtTenDangNhap.Focus();
                                    throw new Exception(); 
                                }
                            }

                            // Kiểm tra mã vai trò đã tồn tại chưa, nếu chưa thì thêm mới
                            string checkVTQuery = "SELECT COUNT(*) FROM Vai_tro WHERE Ma_vai_tro = @maVaiTro";
                            using (SqlCommand checkVTCmd = new SqlCommand(checkVTQuery, conn, transaction))
                            {
                                checkVTCmd.Parameters.AddWithValue("@maVaiTro", txtMaVaiTro.Text.Trim());
                                int vtCount = (int)checkVTCmd.ExecuteScalar();

                                if (vtCount == 0)
                                {
                                    // Thêm vai trò mới
                                    string insertVTQuery = "INSERT INTO Vai_tro (Ma_vai_tro, Ten_vai_tro) VALUES (@maVaiTro, @tenVaiTro)";
                                    using (SqlCommand insertVTCmd = new SqlCommand(insertVTQuery, conn, transaction))
                                    {
                                        insertVTCmd.Parameters.AddWithValue("@maVaiTro", txtMaVaiTro.Text.Trim());
                                        insertVTCmd.Parameters.AddWithValue("@tenVaiTro", txtTenVaiTro.Text.Trim());
                                        insertVTCmd.ExecuteNonQuery();
                                    }
                                }
                            }

                            // Bước 1: Thêm vào bảng Tai_khoan
                            string insertTKQuery = @"INSERT INTO Tai_khoan (Ma_tai_khoan, Ten_dang_nhap, Mat_khau, Loai_nguoi_dung, Ma_sinh_vien, Ma_giang_vien)
                                                   VALUES (@maTaiKhoan, @tenDangNhap, @matKhau, @loaiNguoiDung, @maSinhVien, @maGiangVien)";

                            using (SqlCommand insertTKCmd = new SqlCommand(insertTKQuery, conn, transaction))
                            {
                                insertTKCmd.Parameters.AddWithValue("@maTaiKhoan", txtMaTaiKhoan.Text.Trim());
                                insertTKCmd.Parameters.AddWithValue("@tenDangNhap", txtTenDangNhap.Text.Trim());
                                insertTKCmd.Parameters.AddWithValue("@matKhau", txtMatKhau.Text.Trim());
                                insertTKCmd.Parameters.AddWithValue("@loaiNguoiDung", txtLoaiNguoiDung.Text.Trim());
                                insertTKCmd.Parameters.AddWithValue("@maSinhVien", 
                                    coMaSinhVien ? (object)txtMaSinhVien.Text.Trim() : DBNull.Value);
                                insertTKCmd.Parameters.AddWithValue("@maGiangVien", 
                                    coMaGiangVien ? (object)txtMaGiangVien.Text.Trim() : DBNull.Value);
                                
                                insertTKCmd.ExecuteNonQuery();
                            }

                            // Bước 2: Thêm vào bảng TK_vai_tro
                            string insertPQQuery = @"INSERT INTO TK_vai_tro (Ma_tai_khoan, Ma_vai_tro)
                                                   VALUES (@maTaiKhoan, @maVaiTro)";

                            using (SqlCommand insertPQCmd = new SqlCommand(insertPQQuery, conn, transaction))
                            {
                                insertPQCmd.Parameters.AddWithValue("@maTaiKhoan", txtMaTaiKhoan.Text.Trim());
                                insertPQCmd.Parameters.AddWithValue("@maVaiTro", txtMaVaiTro.Text.Trim());

                                int result = insertPQCmd.ExecuteNonQuery();

                                if (result > 0)
                                {
                                    transaction.Commit();
                                    string loaiTaiKhoan = coMaSinhVien ? "Sinh viên" : "Giảng viên";
                                    string maNguoiDung = coMaSinhVien ? txtMaSinhVien.Text.Trim() : txtMaGiangVien.Text.Trim();
                                    
                                    MessageBox.Show("Thêm tài khoản và phân quyền thành công!\n\n" +
                                        $"Loại: {loaiTaiKhoan}\n" +
                                        $"Mã {loaiTaiKhoan.ToLower()}: {maNguoiDung}\n" +
                                        $"Mã tài khoản: {txtMaTaiKhoan.Text.Trim()}\n" +
                                        $"Tên đăng nhập: {txtTenDangNhap.Text.Trim()}\n" +
                                        $"Loại người dùng: {txtLoaiNguoiDung.Text.Trim()}\n" +
                                        $"Vai trò: {txtTenVaiTro.Text.Trim()} ({txtMaVaiTro.Text.Trim()})\n" +
                                        $"Mật khẩu: {txtMatKhau.Text.Trim()}", 
                                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    LoadDanhSachPhanQuyen();
                                    ClearTextBoxes();
                                    selectedRowIndex = -1;
                                }
                            }
                        }
                        catch
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                if (sqlEx.Number == 2627 || sqlEx.Number == 2601) // Duplicate key
                {
                    MessageBox.Show("Mã tài khoản hoặc tên đăng nhập đã tồn tại!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (sqlEx.Number == 547) // Foreign key constraint
                {
                    MessageBox.Show("Lỗi: Mã sinh viên hoặc mã giảng viên không hợp lệ!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Lỗi SQL: " + sqlEx.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                throw; 
            }
        }

        // Sửa thông tin phân quyền
        private void SuaPhanQuyen()
        {
            if (selectedRowIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn dòng cần sửa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                throw new Exception(); 
            }

            if (string.IsNullOrWhiteSpace(txtMatKhau.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhau.Focus();
                throw new Exception(); 
            }

            if (txtMatKhau.Text.Length < 6)
            {
                MessageBox.Show("Mật khẩu phải có ít nhất 6 ký tự!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhau.Focus();
                throw new Exception(); 
            }

            if (string.IsNullOrWhiteSpace(txtLoaiNguoiDung.Text))
            {
                MessageBox.Show("Vui lòng nhập loại người dùng!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLoaiNguoiDung.Focus();
                throw new Exception(); 
            }

            if (string.IsNullOrWhiteSpace(txtMaVaiTro.Text))
            {
                MessageBox.Show("Vui lòng nhập mã vai trò!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaVaiTro.Focus();
                throw new Exception(); 
            }

            if (string.IsNullOrWhiteSpace(txtTenVaiTro.Text))
            {
                MessageBox.Show("Vui lòng nhập tên vai trò!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenVaiTro.Focus();
                throw new Exception(); 
            }

            // Kiểm tra chỉ nhập một trong hai: Mã sinh viên hoặc Mã giảng viên
            bool coMaSinhVien = !string.IsNullOrWhiteSpace(txtMaSinhVien.Text);
            bool coMaGiangVien = !string.IsNullOrWhiteSpace(txtMaGiangVien.Text);

            if (!coMaSinhVien && !coMaGiangVien)
            {
                MessageBox.Show("Vui lòng nhập Mã sinh viên HOẶC Mã giảng viên!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaSinhVien.Focus();
                throw new Exception();
            }

            if (coMaSinhVien && coMaGiangVien)
            {
                MessageBox.Show("Chỉ nhập Mã sinh viên HOẶC Mã giảng viên, không nhập cả hai!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaSinhVien.Focus();
                throw new Exception();
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            // Kiểm tra mã sinh viên hoặc mã giảng viên có tồn tại và chưa có tài khoản khác
                            if (coMaSinhVien)
                            {
                                string checkSVQuery = "SELECT COUNT(*) FROM Sinh_vien WHERE Ma_sinh_vien = @maSinhVien";
                                using (SqlCommand checkSVCmd = new SqlCommand(checkSVQuery, conn, transaction))
                                {
                                    checkSVCmd.Parameters.AddWithValue("@maSinhVien", txtMaSinhVien.Text.Trim());
                                    int svCount = (int)checkSVCmd.ExecuteScalar();

                                    if (svCount == 0)
                                    {
                                        MessageBox.Show("Mã sinh viên không tồn tại trong hệ thống!\nVui lòng kiểm tra lại.", "Lỗi",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        txtMaSinhVien.Focus();
                                        throw new Exception();
                                    }
                                }

                                // Kiểm tra sinh viên có tài khoản khác không
                                string checkSVTKQuery = "SELECT COUNT(*) FROM Tai_khoan WHERE Ma_sinh_vien = @maSinhVien AND Ma_tai_khoan != @maTaiKhoan";
                                using (SqlCommand checkSVTKCmd = new SqlCommand(checkSVTKQuery, conn, transaction))
                                {
                                    checkSVTKCmd.Parameters.AddWithValue("@maSinhVien", txtMaSinhVien.Text.Trim());
                                    checkSVTKCmd.Parameters.AddWithValue("@maTaiKhoan", txtMaTaiKhoan.Text.Trim());
                                    int tkCount = (int)checkSVTKCmd.ExecuteScalar();

                                    if (tkCount > 0)
                                    {
                                        MessageBox.Show("Sinh viên này đã có tài khoản khác!\nMỗi sinh viên chỉ được có 1 tài khoản.", "Lỗi",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        txtMaSinhVien.Focus();
                                        throw new Exception();
                                    }
                                }
                            }

                            if (coMaGiangVien)
                            {
                                string checkGVQuery = "SELECT COUNT(*) FROM Giang_vien WHERE Ma_giang_vien = @maGiangVien";
                                using (SqlCommand checkGVCmd = new SqlCommand(checkGVQuery, conn, transaction))
                                {
                                    checkGVCmd.Parameters.AddWithValue("@maGiangVien", txtMaGiangVien.Text.Trim());
                                    int gvCount = (int)checkGVCmd.ExecuteScalar();

                                    if (gvCount == 0)
                                    {
                                        MessageBox.Show("Mã giảng viên không tồn tại trong hệ thống!\nVui lòng kiểm tra lại.", "Lỗi",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        txtMaGiangVien.Focus();
                                        throw new Exception();
                                    }
                                }

                                // Kiểm tra giảng viên có tài khoản khác không
                                string checkGVTKQuery = "SELECT COUNT(*) FROM Tai_khoan WHERE Ma_giang_vien = @maGiangVien AND Ma_tai_khoan != @maTaiKhoan";
                                using (SqlCommand checkGVTKCmd = new SqlCommand(checkGVTKQuery, conn, transaction))
                                {
                                    checkGVTKCmd.Parameters.AddWithValue("@maGiangVien", txtMaGiangVien.Text.Trim());
                                    checkGVTKCmd.Parameters.AddWithValue("@maTaiKhoan", txtMaTaiKhoan.Text.Trim());
                                    int tkCount = (int)checkGVTKCmd.ExecuteScalar();

                                    if (tkCount > 0)
                                    {
                                        MessageBox.Show("Giảng viên này đã có tài khoản khác!\nMỗi giảng viên chỉ được có 1 tài khoản.", "Lỗi",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        txtMaGiangVien.Focus();
                                        throw new Exception();
                                    }
                                }
                            }

                            // Kiểm tra và cập nhật vai trò
                            string checkVTQuery = "SELECT COUNT(*) FROM Vai_tro WHERE Ma_vai_tro = @maVaiTro";
                            using (SqlCommand checkVTCmd = new SqlCommand(checkVTQuery, conn, transaction))
                            {
                                checkVTCmd.Parameters.AddWithValue("@maVaiTro", txtMaVaiTro.Text.Trim());
                                int vtCount = (int)checkVTCmd.ExecuteScalar();

                                if (vtCount == 0)
                                {
                                    // Thêm vai trò mới nếu chưa tồn tại
                                    string insertVTQuery = "INSERT INTO Vai_tro (Ma_vai_tro, Ten_vai_tro) VALUES (@maVaiTro, @tenVaiTro)";
                                    using (SqlCommand insertVTCmd = new SqlCommand(insertVTQuery, conn, transaction))
                                    {
                                        insertVTCmd.Parameters.AddWithValue("@maVaiTro", txtMaVaiTro.Text.Trim());
                                        insertVTCmd.Parameters.AddWithValue("@tenVaiTro", txtTenVaiTro.Text.Trim());
                                        insertVTCmd.ExecuteNonQuery();
                                    }
                                }
                                else
                                {
                                    // Cập nhật tên vai trò nếu đã tồn tại
                                    string updateVTQuery = "UPDATE Vai_tro SET Ten_vai_tro = @tenVaiTro WHERE Ma_vai_tro = @maVaiTro";
                                    using (SqlCommand updateVTCmd = new SqlCommand(updateVTQuery, conn, transaction))
                                    {
                                        updateVTCmd.Parameters.AddWithValue("@maVaiTro", txtMaVaiTro.Text.Trim());
                                        updateVTCmd.Parameters.AddWithValue("@tenVaiTro", txtTenVaiTro.Text.Trim());
                                        updateVTCmd.ExecuteNonQuery();
                                    }
                                }
                            }

                            // Cập nhật bảng Tai_khoan
                            string updateTKQuery = @"UPDATE Tai_khoan SET 
                                                   Mat_khau = @matKhau,
                                                   Loai_nguoi_dung = @loaiNguoiDung,
                                                   Ma_sinh_vien = @maSinhVien, 
                                                   Ma_giang_vien = @maGiangVien 
                                                   WHERE Ma_tai_khoan = @maTaiKhoan";

                            using (SqlCommand updateTKCmd = new SqlCommand(updateTKQuery, conn, transaction))
                            {
                                updateTKCmd.Parameters.AddWithValue("@maTaiKhoan", txtMaTaiKhoan.Text.Trim());
                                updateTKCmd.Parameters.AddWithValue("@matKhau", txtMatKhau.Text.Trim());
                                updateTKCmd.Parameters.AddWithValue("@loaiNguoiDung", txtLoaiNguoiDung.Text.Trim());
                                updateTKCmd.Parameters.AddWithValue("@maSinhVien", 
                                    coMaSinhVien ? (object)txtMaSinhVien.Text.Trim() : DBNull.Value);
                                updateTKCmd.Parameters.AddWithValue("@maGiangVien", 
                                    coMaGiangVien ? (object)txtMaGiangVien.Text.Trim() : DBNull.Value);
                                
                                updateTKCmd.ExecuteNonQuery();
                            }

                            // Cập nhật bảng TK_vai_tro
                            string updateQuery = @"UPDATE TK_vai_tro SET 
                                                 Ma_vai_tro = @maVaiTro
                                                 WHERE Ma_tai_khoan = @maTaiKhoan";

                            using (SqlCommand cmd = new SqlCommand(updateQuery, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@maTaiKhoan", txtMaTaiKhoan.Text.Trim());
                                cmd.Parameters.AddWithValue("@maVaiTro", txtMaVaiTro.Text.Trim());

                                int result = cmd.ExecuteNonQuery();

                                if (result > 0)
                                {
                                    transaction.Commit();
                                    MessageBox.Show("Cập nhật tài khoản và phân quyền thành công!", "Thành công",
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
                        catch       
                        {
                            transaction.Rollback();
                            throw;
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

        // Xóa phân quyền
        private void XoaPhanQuyen()
        {
            if (selectedRowIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                throw new Exception(); 
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
                if (sqlEx.Number == 547) 
                {
                    MessageBox.Show("Không thể xóa phân quyền này vì đang có dữ liệu liên quan!",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Lỗi SQL: " + sqlEx.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                throw; 
            }
        }
    }
}