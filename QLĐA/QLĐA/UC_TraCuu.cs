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
    public partial class UC_TraCuu : UserControl
    {
        private string connectionString = "Data Source=DESKTOP-OREV608\\SQLEXPRESS;Initial Catalog=qldatn_final;Integrated Security=True;Encrypt=False";
        private SqlConnection conn;
        private bool isSearching = false;

        public UC_TraCuu()
        {
            InitializeComponent();
            conn = new SqlConnection(connectionString);
        }

        private string currentPlaceholder = "";
        private string currentSearchType = "";

        // ===== XỬ LÝ RADIOBUTTON =====
        private void rdoSinhVien_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoSinhVien != null && rdoSinhVien.Checked)
            {
               
                ClearDataGridView();

                currentSearchType = "SinhVien";
                UpdateSearchCriteria("SinhVien");
                ShowPanel("SinhVien");
                LoadAllData("SinhVien");
                txtTuKhoa?.Focus();
            }
        }

        private void rdoGiangVien_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoGiangVien != null && rdoGiangVien.Checked)
            {
                
                ClearDataGridView();

                currentSearchType = "GiangVien";
                UpdateSearchCriteria("GiangVien");
                ShowPanel("GiangVien");
                LoadAllData("GiangVien");
                txtTuKhoa?.Focus();
            }
        }

        private void rdoDoAn_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoDoAn != null && rdoDoAn.Checked)
            {
               
                ClearDataGridView();

                currentSearchType = "DoAn";
                UpdateSearchCriteria("DoAn");
                ShowPanel("DoAn");
                LoadAllData("DoAn");
                txtTuKhoa?.Focus();
            }
        }

        
        private void ClearDataGridView()
        {
            if (dgvTraCuu != null)
            {
                dgvTraCuu.DataSource = null;
                dgvTraCuu.Rows.Clear();
                dgvTraCuu.Columns.Clear();
            }
        }

        // ===== TẢI DỮ LIỆU TỪ DATABASE =====
        private void LoadAllData(string dataType)
        {
            try
            {
                string query = "";

                switch (dataType)
                {
                    case "SinhVien":
                        query = @"SELECT SV.Ma_sinh_vien, SV.Ho_ten, SV.Ngay_sinh, SV.Gioi_tinh, SV.Lop, SV.Khoa, SV.Email, 
                                GV.Ho_ten_gv as Ten_giang_vien, CN.Ten_chuyen_nganh
                         FROM Sinh_vien SV
                         LEFT JOIN Giang_vien GV ON SV.Ma_giang_vien = GV.Ma_giang_vien
                         LEFT JOIN Chuyen_nganh CN ON SV.Ma_chuyen_nganh = CN.Ma_chuyen_nganh";
                        break;

                    case "GiangVien":
                        query = @"SELECT Ma_giang_vien, Ho_ten_gv, Ngay_sinh, Gioi_tinh, Bang_cap, Chuc_danh, Email 
                         FROM Giang_vien";
                        break;

                    case "DoAn":
                        query = @"SELECT DA.Ma_do_an, DA.Ten_de_tai, DA.Mo_ta, DA.Ngay_nop, 
                                DA.Hoc_ky, DA.Nam, SV.Ho_ten as Ten_sinh_vien
                         FROM Do_an DA
                         LEFT JOIN Sinh_vien SV ON DA.Ma_sinh_vien = SV.Ma_sinh_vien";
                        break;
                }

                if (string.IsNullOrEmpty(query)) return;

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgvTraCuu.DataSource = dt;
                FormatDataGridView(dataType);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===== TÌM KIẾM DỮ LIỆU =====
        private void PerformSearch()
        {
           
            if (string.IsNullOrEmpty(currentSearchType))
            {
                XtraMessageBox.Show("Vui lòng chọn đối tượng tra cứu (Sinh viên/Giảng viên/Đồ án)!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            if (cboTieuChi?.SelectedItem == null)
            {
                XtraMessageBox.Show("Vui lòng chọn tiêu chí tìm kiếm!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            string searchValue = txtTuKhoa?.Text?.Trim() ?? "";

           
            if (string.IsNullOrWhiteSpace(searchValue) ||
                searchValue == currentPlaceholder ||
                txtTuKhoa.ForeColor == Color.Gray)
            {
                LoadAllData(currentSearchType);
                return;
            }

            try
            {
                string query = "";
                string criterion = cboTieuChi.SelectedItem.ToString();

               
                System.Diagnostics.Debug.WriteLine($"=== SEARCH DEBUG ===");
                System.Diagnostics.Debug.WriteLine($"Search Type: {currentSearchType}");
                System.Diagnostics.Debug.WriteLine($"Criterion: {criterion}");
                System.Diagnostics.Debug.WriteLine($"Search Value: '{searchValue}'");
                System.Diagnostics.Debug.WriteLine($"Text Color: {txtTuKhoa.ForeColor}");

                switch (currentSearchType)
                {
                    case "SinhVien":
                        query = BuildSearchQuery_SinhVien(criterion, searchValue);
                        break;

                    case "GiangVien":
                        query = BuildSearchQuery_GiangVien(criterion, searchValue);
                        break;

                    case "DoAn":
                        query = BuildSearchQuery_DoAn(criterion, searchValue);
                        break;
                }

                if (string.IsNullOrEmpty(query))
                {
                    XtraMessageBox.Show("Không thể tạo câu truy vấn!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

              
                System.Diagnostics.Debug.WriteLine($"Query: {query}");

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                System.Diagnostics.Debug.WriteLine($"Rows found: {dt.Rows.Count}");
                System.Diagnostics.Debug.WriteLine($"===================");

                dgvTraCuu.DataSource = dt;
                FormatDataGridView(currentSearchType);

                if (dt.Rows.Count == 0)
                {
                    XtraMessageBox.Show($"Không tìm thấy kết quả phù hợp với từ khóa: '{searchValue}'",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    XtraMessageBox.Show($"Tìm thấy {dt.Rows.Count} kết quả ! ",
                        "Kết quả tìm kiếm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (SqlException sqlEx)
            {
                XtraMessageBox.Show($"Lỗi SQL: {sqlEx.Message}\n\nChi tiết:\n{sqlEx.ToString()}",
                    "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}\n\nChi tiết:\n{ex.ToString()}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===== XÂY DỰNG TRUY VẤN TÌM KIẾM =====
        private string BuildSearchQuery_SinhVien(string criterion, string searchValue)
        {
            
            searchValue = searchValue.Replace("'", "''");

            string baseQuery = @"SELECT SV.Ma_sinh_vien, SV.Ho_ten, SV.Ngay_sinh, SV.Gioi_tinh, SV.Lop, SV.Khoa, SV.Email, 
                               GV.Ho_ten_gv as Ten_giang_vien, CN.Ten_chuyen_nganh
                        FROM Sinh_vien SV
                        LEFT JOIN Giang_vien GV ON SV.Ma_giang_vien = GV.Ma_giang_vien
                        LEFT JOIN Chuyen_nganh CN ON SV.Ma_chuyen_nganh = CN.Ma_chuyen_nganh
                        WHERE ";

            switch (criterion)
            {
                case "Mã sinh viên":
                    return baseQuery + $"SV.Ma_sinh_vien LIKE N'%{searchValue}%'";
                case "Họ và tên":
                    return baseQuery + $"SV.Ho_ten LIKE N'%{searchValue}%'";
                case "Ngày sinh":
                    return baseQuery + $"CONVERT(VARCHAR, SV.Ngay_sinh, 103) LIKE N'%{searchValue}%'";
                case "Giới tính":
                    return baseQuery + $"SV.Gioi_tinh = N'{searchValue}'";
                case "Lớp":
                    return baseQuery + $"SV.Lop = N'{searchValue}'";
                case "Chuyên ngành":
                    return baseQuery + $"CN.Ten_chuyen_nganh LIKE N'%{searchValue}%'";
                default:
                    return baseQuery + $"(SV.Ma_sinh_vien LIKE N'%{searchValue}%' OR SV.Ho_ten LIKE N'%{searchValue}%')";
            }
        }

        private string BuildSearchQuery_GiangVien(string criterion, string searchValue)
        {
          
            searchValue = searchValue.Replace("'", "''");

            string baseQuery = @"SELECT Ma_giang_vien, Ho_ten_gv, Ngay_sinh, Gioi_tinh, Bang_cap, Chuc_danh, Email 
                        FROM Giang_vien WHERE ";

            switch (criterion)
            {
                case "Mã giảng viên":
                    return baseQuery + $"Ma_giang_vien LIKE N'%{searchValue}%'";
                case "Họ và tên":
                    return baseQuery + $"Ho_ten_gv LIKE N'%{searchValue}%'";
                case "Ngày sinh":
                    return baseQuery + $"CONVERT(VARCHAR, Ngay_sinh, 103) LIKE N'%{searchValue}%'";
                case "Giới tính":
                    return baseQuery + $"Gioi_tinh = N'{searchValue}'";
                case "Bằng cấp":
                    return baseQuery + $"Bang_cap LIKE N'%{searchValue}%'";
                case "Chức danh":
                    return baseQuery + $"Chuc_danh LIKE N'%{searchValue}%'";
                case "Email":
                    return baseQuery + $"Email LIKE N'%{searchValue}%'";
                default:
                    return baseQuery + $"(Ma_giang_vien LIKE N'%{searchValue}%' OR Ho_ten_gv LIKE N'%{searchValue}%')";
            }
        }

        private string BuildSearchQuery_DoAn(string criterion, string searchValue)
        {
            searchValue = searchValue.Replace("'", "''");
            
            string baseQuery = @"SELECT DA.Ma_do_an, DA.Ten_de_tai, DA.Mo_ta, DA.Ngay_nop, 
                                   DA.Hoc_ky, DA.Nam, SV.Ho_ten as Ten_sinh_vien
                            FROM Do_an DA
                            LEFT JOIN Sinh_vien SV ON DA.Ma_sinh_vien = SV.Ma_sinh_vien
                            WHERE ";

            switch (criterion)
            {
                case "Mã đồ án":
                    return baseQuery + $"DA.Ma_do_an LIKE N'%{searchValue}%'";
                case "Tên đồ án":
                    return baseQuery + $"DA.Ten_de_tai LIKE N'%{searchValue}%'";
                case "Ngày nộp":
                    return baseQuery + $"CONVERT(VARCHAR, DA.Ngay_nop, 103) LIKE N'%{searchValue}%'";
                case "Học kỳ":
                    return baseQuery + $"DA.Hoc_ky LIKE N'%{searchValue}%'";
                case "Năm học":
                    return baseQuery + $"DA.Nam LIKE N'%{searchValue}%'";
                default:
                    return baseQuery + $"(DA.Ma_do_an LIKE N'%{searchValue}%' OR DA.Ten_de_tai LIKE N'%{searchValue}%')";
            }
        }

        // ===== ĐỊNH DẠNG DATAGRIDVIEW =====
        private void FormatDataGridView(string dataType)
        {
            if (dgvTraCuu == null || dgvTraCuu.Columns.Count == 0) return;

            dgvTraCuu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTraCuu.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvTraCuu.RowPostPaint -= DgvTraCuu_RowPostPaint;  
            dgvTraCuu.RowPostPaint += DgvTraCuu_RowPostPaint;  

            dgvTraCuu.MultiSelect = false;
            dgvTraCuu.ReadOnly = true;

            switch (dataType)
            {
                case "SinhVien":
                    if (dgvTraCuu.Columns["Ma_sinh_vien"] != null)
                        dgvTraCuu.Columns["Ma_sinh_vien"].HeaderText = "Mã SV";
                    if (dgvTraCuu.Columns["Ho_ten"] != null)
                        dgvTraCuu.Columns["Ho_ten"].HeaderText = "Họ và Tên";
                    if (dgvTraCuu.Columns["Ngay_sinh"] != null)
                    {
                        dgvTraCuu.Columns["Ngay_sinh"].HeaderText = "Ngày Sinh";
                        dgvTraCuu.Columns["Ngay_sinh"].DefaultCellStyle.Format = "dd/MM/yyyy";
                    }
                    if (dgvTraCuu.Columns["Gioi_tinh"] != null)
                        dgvTraCuu.Columns["Gioi_tinh"].HeaderText = "Giới Tính";
                    if (dgvTraCuu.Columns["Lop"] != null)
                        dgvTraCuu.Columns["Lop"].HeaderText = "Lớp";
                    if (dgvTraCuu.Columns["Khoa"] != null)
                    {
                        dgvTraCuu.Columns["Khoa"].HeaderText = "Khoa";
                        dgvTraCuu.Columns["Khoa"].Visible = false; 
                    }
                    if (dgvTraCuu.Columns["Email"] != null)
                        dgvTraCuu.Columns["Email"].HeaderText = "Email";
                    if (dgvTraCuu.Columns["Ten_giang_vien"] != null)
                        dgvTraCuu.Columns["Ten_giang_vien"].HeaderText = "Giảng viên HD";
                    if (dgvTraCuu.Columns["Ten_chuyen_nganh"] != null)
                        dgvTraCuu.Columns["Ten_chuyen_nganh"].HeaderText = "Chuyên ngành";
                    break;

                case "GiangVien":
                    if (dgvTraCuu.Columns["Ma_giang_vien"] != null)
                        dgvTraCuu.Columns["Ma_giang_vien"].HeaderText = "Mã GV";
                    if (dgvTraCuu.Columns["Ho_ten_gv"] != null)
                        dgvTraCuu.Columns["Ho_ten_gv"].HeaderText = "Họ và Tên";
                    if (dgvTraCuu.Columns["Ngay_sinh"] != null)
                    {
                        dgvTraCuu.Columns["Ngay_sinh"].HeaderText = "Ngày Sinh";
                        dgvTraCuu.Columns["Ngay_sinh"].DefaultCellStyle.Format = "dd/MM/yyyy";
                    }
                    if (dgvTraCuu.Columns["Gioi_tinh"] != null)
                        dgvTraCuu.Columns["Gioi_tinh"].HeaderText = "Giới Tính";
                    if (dgvTraCuu.Columns["Bang_cap"] != null)
                        dgvTraCuu.Columns["Bang_cap"].HeaderText = "Bằng Cấp";
                    if (dgvTraCuu.Columns["Chuc_danh"] != null)
                        dgvTraCuu.Columns["Chuc_danh"].HeaderText = "Chức Danh";
                    if (dgvTraCuu.Columns["Email"] != null)
                        dgvTraCuu.Columns["Email"].HeaderText = "Email";
                    break;

                case "DoAn":
                    if (dgvTraCuu.Columns["Ma_do_an"] != null)
                        dgvTraCuu.Columns["Ma_do_an"].HeaderText = "Mã ĐA";
                    if (dgvTraCuu.Columns["Ten_de_tai"] != null)
                        dgvTraCuu.Columns["Ten_de_tai"].HeaderText = "Tên Đề Tài";
                    if (dgvTraCuu.Columns["Mo_ta"] != null)
                        dgvTraCuu.Columns["Mo_ta"].HeaderText = "Mô Tả";
                    if (dgvTraCuu.Columns["Ngay_nop"] != null)
                    {
                        dgvTraCuu.Columns["Ngay_nop"].HeaderText = "Ngày Nộp";
                        dgvTraCuu.Columns["Ngay_nop"].DefaultCellStyle.Format = "dd/MM/yyyy";
                    }
                    if (dgvTraCuu.Columns["Hoc_ky"] != null)
                        dgvTraCuu.Columns["Hoc_ky"].HeaderText = "Học Kỳ";
                    if (dgvTraCuu.Columns["Nam"] != null)
                        dgvTraCuu.Columns["Nam"].HeaderText = "Năm";
                    if (dgvTraCuu.Columns["Ten_sinh_vien"] != null)
                        dgvTraCuu.Columns["Ten_sinh_vien"].HeaderText = "Sinh Viên";
                    break;
            }

         
        }

        // ===== CẬP NHẬT TIÊU CHÍ TÌM KIẾM =====
        private void UpdateSearchCriteria(string objectType)
        {
            if (cboTieuChi == null) return;

            cboTieuChi.Items.Clear();

            switch (objectType)
            {
                case "SinhVien":
                    cboTieuChi.Items.AddRange(new object[] {
                        "Mã sinh viên",
                        "Họ và tên",
                        "Giới tính",
                        "Lớp",
                        "Chuyên ngành"
                    });
                    UpdatePlaceholder("Nhập mã hoặc tên sinh viên...");
                    break;

                case "GiangVien":
                    cboTieuChi.Items.AddRange(new object[] {
                        "Mã giảng viên",
                        "Họ và tên",
                        "Giới tính",
                        "Bằng cấp",
                        "Chức danh",
                        "Email"
                    });
                    UpdatePlaceholder("Nhập mã hoặc tên giảng viên...");
                    break;

                case "DoAn":
                    cboTieuChi.Items.AddRange(new object[] {
                        "Mã đồ án",
                        "Tên đồ án",
                        "Ngày nộp",
                        "Học kỳ",
                        "Năm học"
                    });
                    UpdatePlaceholder("Nhập mã hoặc tên đồ án...");
                    break;
            }

            cboTieuChi.SelectedIndex = 0;
        }
        private void DgvTraCuu_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
               
                string rowNumber = (e.RowIndex + 1).ToString();

                
                Font font = new Font("Segoe UI", 10F, FontStyle.Regular);
                SolidBrush brush = new SolidBrush(dgvTraCuu.RowHeadersDefaultCellStyle.ForeColor);

              
                StringFormat format = new StringFormat()
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };

                
                e.Graphics.DrawString(
                    rowNumber,
                    font,
                    brush,
                    e.RowBounds.Left + (dgvTraCuu.RowHeadersWidth / 2),
                    e.RowBounds.Top + (e.RowBounds.Height / 2),
                    format);

                brush.Dispose();
                font.Dispose();
                format.Dispose();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error in RowPostPaint: {ex.Message}");
            }
        }

        private void UpdatePlaceholder(string text)
        {
            if (txtTuKhoa == null) return;

            txtTuKhoa.GotFocus -= TxtTuKhoa_GotFocus;
            txtTuKhoa.LostFocus -= TxtTuKhoa_LostFocus;

            currentPlaceholder = text;

            txtTuKhoa.Text = currentPlaceholder;
            txtTuKhoa.ForeColor = Color.Gray;

            txtTuKhoa.GotFocus += TxtTuKhoa_GotFocus;
            txtTuKhoa.LostFocus += TxtTuKhoa_LostFocus;
        }

        private void TxtTuKhoa_GotFocus(object sender, EventArgs e)
        {
            if (txtTuKhoa.Text == currentPlaceholder)
            {
                txtTuKhoa.Text = "";
                txtTuKhoa.ForeColor = Color.Black;
            }
        }

        private void TxtTuKhoa_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTuKhoa.Text))
            {
                txtTuKhoa.Text = currentPlaceholder;
                txtTuKhoa.ForeColor = Color.Gray;
            }
        }

        private void ShowPanel(string panelType)
        {
            // Ẩn tất cả các panel trước
            if (pnlSinhVien != null) pnlSinhVien.Visible = false;
            if (pnlGiangVien != null) pnlGiangVien.Visible = false;
            if (pnlDoAn != null) pnlDoAn.Visible = false;

            // Hiển thị panel được chọn
            switch (panelType)
            {
                case "SinhVien":
                    if (pnlSinhVien != null) pnlSinhVien.Visible = true;
                    break;

                case "GiangVien":
                    if (pnlGiangVien != null) pnlGiangVien.Visible = true;
                    break;

                case "DoAn":
                    if (pnlDoAn != null) pnlDoAn.Visible = true;
                    break;
            }
        }

        // ===== XỬ LÝ CLICK VÀO DATAGRIDVIEW =====
        private void dgvTraCuu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DisplayDetailInPanel(e.RowIndex);
        }

        private void dgvTraCuu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DisplayDetailInPanel(e.RowIndex);
        }

        // ===== HIỂN THỊ CHI TIẾT TRONG PANEL =====
        private void DisplayDetailInPanel(int rowIndex)
        {
            try
            {
                DataGridViewRow row = dgvTraCuu.Rows[rowIndex];

                switch (currentSearchType)
                {
                    case "SinhVien":
                        DisplaySinhVienDetail(row);
                        break;

                    case "GiangVien":
                        DisplayGiangVienDetail(row);
                        break;

                    case "DoAn":
                        DisplayDoAnDetail(row);
                        break;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi khi hiển thị chi tiết: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===== HIỂN THỊ CHI TIẾT SINH VIÊN =====
        private void DisplaySinhVienDetail(DataGridViewRow row)
        {
            if (pnlSinhVien.Controls["txtMaSV"] is TextBox txtMaSV)
                txtMaSV.Text = row.Cells["Ma_sinh_vien"].Value?.ToString() ?? "";

            if (pnlSinhVien.Controls["txtHoTenSV"] is TextBox txtHoTenSV)
                txtHoTenSV.Text = row.Cells["Ho_ten"].Value?.ToString() ?? "";

            if (pnlSinhVien.Controls["txtNgaySinhSV"] is TextBox txtNgaySinhSV)
            {
                if (row.Cells["Ngay_sinh"].Value != null && row.Cells["Ngay_sinh"].Value != DBNull.Value)
                    txtNgaySinhSV.Text = Convert.ToDateTime(row.Cells["Ngay_sinh"].Value).ToString("dd/MM/yyyy");
                else
                    txtNgaySinhSV.Text = "";
            }

            if (pnlSinhVien.Controls["txtGioiTinhSV"] is TextBox txtGioiTinhSV)
                txtGioiTinhSV.Text = row.Cells["Gioi_tinh"].Value?.ToString() ?? "";

            if (pnlSinhVien.Controls["txtLop"] is TextBox txtLop)
                txtLop.Text = row.Cells["Lop"].Value?.ToString() ?? "";

            if (pnlSinhVien.Controls["txtKhoa"] is TextBox txtKhoa)
                txtKhoa.Text = row.Cells["Khoa"].Value?.ToString() ?? "";

            if (pnlSinhVien.Controls["txtEmailSV"] is TextBox txtEmailSV)
                txtEmailSV.Text = row.Cells["Email"].Value?.ToString() ?? "";

            if (pnlSinhVien.Controls["txtGiangVienHD"] is TextBox txtGiangVienHD)
                txtGiangVienHD.Text = row.Cells["Ten_giang_vien"].Value?.ToString() ?? "";

            if (pnlSinhVien.Controls["txtChuyenNganh"] is TextBox txtChuyenNganh)
                txtChuyenNganh.Text = row.Cells["Ten_chuyen_nganh"].Value?.ToString() ?? "";
        }

        // ===== HIỂN THỊ CHI TIẾT GIẢNG VIÊN =====
        private void DisplayGiangVienDetail(DataGridViewRow row)
        {
            if (pnlGiangVien.Controls["txtMaGV"] is TextBox txtMaGV)
                txtMaGV.Text = row.Cells["Ma_giang_vien"].Value?.ToString() ?? "";

            if (pnlGiangVien.Controls["txtHotenGV"] is TextBox txtHoTenGV)
                txtHoTenGV.Text = row.Cells["Ho_ten_gv"].Value?.ToString() ?? "";

            if (pnlGiangVien.Controls["txtNgaySinhGV"] is TextBox txtNgaySinhGV)
            {
                if (row.Cells["Ngay_sinh"].Value != null && row.Cells["Ngay_sinh"].Value != DBNull.Value)
                    txtNgaySinhGV.Text = Convert.ToDateTime(row.Cells["Ngay_sinh"].Value).ToString("dd/MM/yyyy");
                else
                    txtNgaySinhGV.Text = "";
            }

            if (pnlGiangVien.Controls["txtGioiTinhGV"] is TextBox txtGioiTinhGV)
                txtGioiTinhGV.Text = row.Cells["Gioi_tinh"].Value?.ToString() ?? "";

            if (pnlGiangVien.Controls["txtBangCap"] is TextBox txtBangCap)
                txtBangCap.Text = row.Cells["Bang_cap"].Value?.ToString() ?? "";

            if (pnlGiangVien.Controls["txtChucDanh"] is TextBox txtChucDanh)
                txtChucDanh.Text = row.Cells["Chuc_danh"].Value?.ToString() ?? "";

            
            if (pnlGiangVien.Controls["txtEmailGiangVien"] is TextBox txtEmailGiangVien)
                txtEmailGiangVien.Text = row.Cells["Email"].Value?.ToString() ?? "";
        }

        // ===== HIỂN THỊ CHI TIẾT ĐỒ ÁN =====
        private void DisplayDoAnDetail(DataGridViewRow row)
        {
            if (pnlDoAn.Controls["txtMaDA"] is TextBox txtMaDA)
                txtMaDA.Text = row.Cells["Ma_do_an"].Value?.ToString() ?? "";

            if (pnlDoAn.Controls["txtTenDeTai"] is TextBox txtTenDeTai)
                txtTenDeTai.Text = row.Cells["Ten_de_tai"].Value?.ToString() ?? "";

            if (pnlDoAn.Controls["txtMoTa"] is TextBox txtMoTa)
                txtMoTa.Text = row.Cells["Mo_ta"].Value?.ToString() ?? "";

            if (pnlDoAn.Controls["txtNgayNop"] is TextBox txtNgayNop)
            {
                if (row.Cells["Ngay_nop"].Value != null && row.Cells["Ngay_nop"].Value != DBNull.Value)
                    txtNgayNop.Text = Convert.ToDateTime(row.Cells["Ngay_nop"].Value).ToString("dd/MM/yyyy");
                else
                    txtNgayNop.Text = "";
            }

            if (pnlDoAn.Controls["txtHocKy"] is TextBox txtHocKy)
                txtHocKy.Text = row.Cells["Hoc_ky"].Value?.ToString() ?? "";

            if (pnlDoAn.Controls["txtNam"] is TextBox txtNam)
                txtNam.Text = row.Cells["Nam"].Value?.ToString() ?? "";

            if (pnlDoAn.Controls["txtTenSinhVien"] is TextBox txtTenSinhVien)
                txtTenSinhVien.Text = row.Cells["Ten_sinh_vien"].Value?.ToString() ?? "";
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            PerformSearch();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        // ===== REFRESH - TẢI LẠI DỮ LIỆU =====
        private void RefreshData()
        {
            try
            {
                // Xóa từ khóa tìm kiếm
                if (txtTuKhoa != null)
                {
                    txtTuKhoa.GotFocus -= TxtTuKhoa_GotFocus;
                    txtTuKhoa.LostFocus -= TxtTuKhoa_LostFocus;

                    txtTuKhoa.Text = "";
                    txtTuKhoa.ForeColor = Color.Black;

                    txtTuKhoa.GotFocus += TxtTuKhoa_GotFocus;
                    txtTuKhoa.LostFocus += TxtTuKhoa_LostFocus;
                }

                // Reset tiêu chí về mặc định
                if (cboTieuChi != null && cboTieuChi.Items.Count > 0)
                {
                    cboTieuChi.SelectedIndex = 0;
                }

                // Tải lại dữ liệu theo đối tượng đang chọn
                if (!string.IsNullOrEmpty(currentSearchType))
                {
                    LoadAllData(currentSearchType);

                    // Đặt lại placeholder
                    switch (currentSearchType)
                    {
                        case "SinhVien":
                            UpdatePlaceholder("Nhập mã hoặc tên sinh viên...");
                            break;
                        case "GiangVien":
                            UpdatePlaceholder("Nhập mã hoặc tên giảng viên...");
                            break;
                        case "DoAn":
                            UpdatePlaceholder("Nhập mã hoặc tên đồ án...");
                            break;
                    }

                    XtraMessageBox.Show("Đã tải lại dữ liệu thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    
                    if (dgvTraCuu != null)
                    {
                        dgvTraCuu.DataSource = null;
                    }

                    XtraMessageBox.Show("Vui lòng chọn đối tượng tra cứu (Sinh viên/Giảng viên/Đồ án)",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi khi tải lại dữ liệu: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtTuKhoa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;  
               

               
                if (isSearching)
                {
                    System.Diagnostics.Debug.WriteLine("Already searching, skipping...");
                    return;
                }

                isSearching = true;
                try
                {
                    PerformSearch();
                }
                finally
                {
                    isSearching = false;
                }
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvTraCuu.Rows.Count > 0)
                {
                    dgvTraCuu.ClearSelection();
                    dgvTraCuu.Rows[0].Selected = true;
                    dgvTraCuu.CurrentCell = dgvTraCuu.Rows[0].Cells[0];
                    DisplayDetailInPanel(0);
                }
                else
                {
                    XtraMessageBox.Show("Không có dữ liệu để hiển thị!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi khi chuyển đến dòng đầu: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvTraCuu.Rows.Count > 0)
                {
                    int currentIndex = dgvTraCuu.CurrentRow?.Index ?? -1;

                    if (currentIndex > 0)
                    {
                        dgvTraCuu.ClearSelection();
                        dgvTraCuu.Rows[currentIndex - 1].Selected = true;
                        dgvTraCuu.CurrentCell = dgvTraCuu.Rows[currentIndex - 1].Cells[0];
                        DisplayDetailInPanel(currentIndex - 1);
                    }
                    else if (currentIndex == 0)
                    {
                        XtraMessageBox.Show("Đây là dòng đầu tiên!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        dgvTraCuu.Rows[0].Selected = true;
                        dgvTraCuu.CurrentCell = dgvTraCuu.Rows[0].Cells[0];
                        DisplayDetailInPanel(0);
                    }
                }
                else
                {
                    XtraMessageBox.Show("Không có dữ liệu để hiển thị!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi khi chuyển đến dòng trước: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvTraCuu.Rows.Count > 0)
                {
                    int currentIndex = dgvTraCuu.CurrentRow?.Index ?? -1;
                    int lastIndex = dgvTraCuu.Rows.Count - 1;

                    if (currentIndex < lastIndex && currentIndex >= 0)
                    {
                        dgvTraCuu.ClearSelection();
                        dgvTraCuu.Rows[currentIndex + 1].Selected = true;
                        dgvTraCuu.CurrentCell = dgvTraCuu.Rows[currentIndex + 1].Cells[0];
                        DisplayDetailInPanel(currentIndex + 1);
                    }
                    else if (currentIndex == lastIndex)
                    {
                        XtraMessageBox.Show("Đây là dòng cuối cùng!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        dgvTraCuu.Rows[0].Selected = true;
                        dgvTraCuu.CurrentCell = dgvTraCuu.Rows[0].Cells[0];
                        DisplayDetailInPanel(0);
                    }
                }
                else
                {
                    XtraMessageBox.Show("Không có dữ liệu để hiển thị!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi khi chuyển đến dòng sau: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvTraCuu.Rows.Count > 0)
                {
                    int lastIndex = dgvTraCuu.Rows.Count - 1;

                    dgvTraCuu.ClearSelection();
                    dgvTraCuu.Rows[lastIndex].Selected = true;
                    dgvTraCuu.CurrentCell = dgvTraCuu.Rows[lastIndex].Cells[0];
                    DisplayDetailInPanel(lastIndex);
                }
                else
                {
                    XtraMessageBox.Show("Không có dữ liệu để hiển thị!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi khi chuyển đến dòng cuối: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UC_TraCuu_Load(object sender, EventArgs e)
        {
            
            if (txtTuKhoa != null)
            {
                txtTuKhoa.KeyPress += TxtTuKhoa_KeyPress;
            }
            
           
            if (rdoSinhVien != null)
            {
                rdoSinhVien.Checked = true;
                currentSearchType = "SinhVien";
                UpdateSearchCriteria("SinhVien");
                ShowPanel("SinhVien");
                LoadAllData("SinhVien");
            }
        }

       
       
    }
}