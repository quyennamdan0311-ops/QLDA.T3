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
    public partial class UC_QuanLyDoAn : DevExpress.XtraEditors.XtraUserControl
    {
        private string connectionString = "Data Source=DESKTOP-OREV608\\SQLEXPRESS;Initial Catalog=qldatn_final;Integrated Security=True;Encrypt=False";
        private SqlConnection conn;
        private DataTable dtDoAn;
        private string currentAction = ""; // "Add", "Edit", "Delete", ""
        private int selectedRowIndex = -1;

        public UC_QuanLyDoAn()
        {
            InitializeComponent();
            conn = new SqlConnection(connectionString);
            this.Load += UC_QuanLyDoAn_Load;
        }

        private void UC_QuanLyDoAn_Load(object sender, EventArgs e)
        {
            LoadDanhSachDoAn();
            ConfigureDataGridView();
            ClearTextBoxes();
            SetNormalState();
        }

        // Tải danh sách đồ án từ database
        private void LoadDanhSachDoAn()
        {
            try
            {
                string query = @"SELECT 
                    Ma_do_an, 
                    Ten_de_tai, 
                    Mo_ta, 
                    Ngay_nop, 
                    Hoc_ky, 
                    Nam,
                    Ma_sinh_vien
                FROM Do_an
                ORDER BY Ma_do_an";

                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                {
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

        // Cấu hình DataGridView
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

            
            dgvDoAn.CellClick += DgvDoAn_CellClick;
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

                txtMaDoAn.Text = row.Cells["Ma_do_an"].Value?.ToString() ?? "";
                txtTenDeTai.Text = row.Cells["Ten_de_tai"].Value?.ToString() ?? "";
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
                MaSV.Text = row.Cells["Ma_sinh_vien"].Value?.ToString() ?? "";
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
            txtMaDoAn.Clear();
            txtTenDeTai.Clear();
            txtMoTa.Clear();
            txtNgayNop.Clear();
            txtHocKy.Clear();
            txtNam.Clear();
            MaSV.Clear();
        }

        // Thiết lập trạng thái ReadOnly cho TextBox
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

            txtTenDeTai.ReadOnly = isReadOnly;
            txtMoTa.ReadOnly = isReadOnly;
            txtNgayNop.ReadOnly = isReadOnly;
            txtHocKy.ReadOnly = isReadOnly;
            txtNam.ReadOnly = isReadOnly;
            MaSV.ReadOnly = isReadOnly;
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
            txtMaDoAn.Focus();

            MessageBox.Show("Vui lòng nhập thông tin đồ án mới và nhấn 'Cập nhật'", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Nút SỬA
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
            SetActionState();
            txtTenDeTai.Focus();

            MessageBox.Show("Vui lòng chỉnh sửa thông tin và nhấn 'Cập nhật'", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Nút XÓA
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (selectedRowIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn một đồ án để xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa đồ án '{txtTenDeTai.Text}'?",
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

       
        private void ThemDoAn()
        {
            
            if (string.IsNullOrWhiteSpace(txtMaDoAn.Text))
            {
                MessageBox.Show("Vui lòng nhập mã đồ án!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaDoAn.Focus();
                throw new Exception(); 
            }

            if (string.IsNullOrWhiteSpace(txtTenDeTai.Text))
            {
                MessageBox.Show("Vui lòng nhập tên đề tài!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenDeTai.Focus();
                throw new Exception(); 
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    
                    string checkQuery = "SELECT COUNT(*) FROM Do_an WHERE Ma_do_an = @maDoAn";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@maDoAn", txtMaDoAn.Text.Trim());
                        int count = (int)checkCmd.ExecuteScalar();

                        if (count > 0)
                        {
                            MessageBox.Show("Mã đồ án đã tồn tại!", "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtMaDoAn.Focus();
                            throw new Exception(); 
                        }
                    }

                   
                    if (!string.IsNullOrWhiteSpace(MaSV.Text))
                    {
                        string checkSVQuery = "SELECT COUNT(*) FROM Sinh_vien WHERE Ma_sinh_vien = @maSV";
                        using (SqlCommand checkSVCmd = new SqlCommand(checkSVQuery, conn))
                        {
                            checkSVCmd.Parameters.AddWithValue("@maSV", MaSV.Text.Trim());
                            int svCount = (int)checkSVCmd.ExecuteScalar();

                            if (svCount == 0)
                            {
                                MessageBox.Show("Mã sinh viên không tồn tại trong hệ thống!\nVui lòng kiểm tra lại.", "Lỗi",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                                MaSV.Focus();
                                throw new Exception(); 
                            }
                        }
                    }

                    
                    DateTime? ngayNop = null;
                    if (!string.IsNullOrWhiteSpace(txtNgayNop.Text))
                    {
                        if (DateTime.TryParseExact(txtNgayNop.Text, "dd/MM/yyyy",
                            System.Globalization.CultureInfo.InvariantCulture,
                            System.Globalization.DateTimeStyles.None, out DateTime tempDate))
                        {
                            ngayNop = tempDate;
                        }
                    }

                    
                    string insertQuery = @"INSERT INTO Do_an 
                (Ma_do_an, Ten_de_tai, Mo_ta, Ngay_nop, Hoc_ky, Nam, Ma_sinh_vien)
                VALUES (@maDoAn, @tenDeTai, @moTa, @ngayNop, @hocKy, @nam, @maSV)";

                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@maDoAn", txtMaDoAn.Text.Trim());
                        cmd.Parameters.AddWithValue("@tenDeTai", txtTenDeTai.Text.Trim());
                        cmd.Parameters.AddWithValue("@moTa", string.IsNullOrWhiteSpace(txtMoTa.Text) ? (object)DBNull.Value : txtMoTa.Text.Trim());
                        cmd.Parameters.AddWithValue("@ngayNop", ngayNop.HasValue ? (object)ngayNop.Value : DBNull.Value);
                        cmd.Parameters.AddWithValue("@hocKy", string.IsNullOrWhiteSpace(txtHocKy.Text) ? (object)DBNull.Value : txtHocKy.Text.Trim());
                        cmd.Parameters.AddWithValue("@nam", string.IsNullOrWhiteSpace(txtNam.Text) ? (object)DBNull.Value : txtNam.Text.Trim());
                        cmd.Parameters.AddWithValue("@maSV", string.IsNullOrWhiteSpace(MaSV.Text) ? (object)DBNull.Value : MaSV.Text.Trim());

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Thêm đồ án thành công!", "Thành công",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    MessageBox.Show("Lỗi: Mã sinh viên không hợp lệ hoặc không tồn tại trong hệ thống!", "Lỗi",
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

        // Sửa thông tin đồ án
        private void SuaDoAn()
        {
            if (selectedRowIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn đồ án cần sửa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                throw new Exception(); 
            }

            if (string.IsNullOrWhiteSpace(txtTenDeTai.Text))
            {
                MessageBox.Show("Vui lòng nhập tên đề tài!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenDeTai.Focus();
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
                    }

                    string updateQuery = @"UPDATE Do_an SET 
                        Ten_de_tai = @tenDeTai, 
                        Mo_ta = @moTa, 
                        Ngay_nop = @ngayNop, 
                        Hoc_ky = @hocKy, 
                        Nam = @nam, 
                        Ma_sinh_vien = @maSV
                        WHERE Ma_do_an = @maDoAn";

                    using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@maDoAn", txtMaDoAn.Text.Trim());
                        cmd.Parameters.AddWithValue("@tenDeTai", txtTenDeTai.Text.Trim());
                        cmd.Parameters.AddWithValue("@moTa", string.IsNullOrWhiteSpace(txtMoTa.Text) ? (object)DBNull.Value : txtMoTa.Text.Trim());
                        cmd.Parameters.AddWithValue("@ngayNop", ngayNop.HasValue ? (object)ngayNop.Value : DBNull.Value);
                        cmd.Parameters.AddWithValue("@hocKy", string.IsNullOrWhiteSpace(txtHocKy.Text) ? (object)DBNull.Value : txtHocKy.Text.Trim());
                        cmd.Parameters.AddWithValue("@nam", string.IsNullOrWhiteSpace(txtNam.Text) ? (object)DBNull.Value : txtNam.Text.Trim());
                        cmd.Parameters.AddWithValue("@maSV", string.IsNullOrWhiteSpace(MaSV.Text) ? (object)DBNull.Value : MaSV.Text.Trim());

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Cập nhật thông tin thành công!", "Thành công",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        // Xóa đồ án
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
                            MessageBox.Show("Xóa đồ án thành công!", "Thành công",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    MessageBox.Show("Không thể xóa đồ án này vì đang có dữ liệu liên quan!",
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

        private void txtTenDeTai_TextChanged(object sender, EventArgs e)
        {

        }
    }
}