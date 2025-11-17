using DevExpress.ExpressApp.Kpi;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace QLĐA
{
    public partial class UC_TTSinhVien : UserControl
    {
        private string connectionString = "Data Source=DESKTOP-OREV608\\SQLEXPRESS;Initial Catalog=qldatn_final;Integrated Security=True;Encrypt=False";
        private string maSinhVien;

        public UC_TTSinhVien()
        {
            InitializeComponent();
        }


        public UC_TTSinhVien(string maSV) : this()
        {
            this.maSinhVien = maSV;
            LoadThongTinSinhVien();
        }

        private void LoadThongTinSinhVien()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"
                        SELECT SV.Ma_sinh_vien, SV.Ho_ten, SV.Ngay_sinh, SV.Gioi_tinh, SV.Lop, 
                               SV.Khoa, SV.Email, 
                               CN.Ten_chuyen_nganh,
                               DA.Ma_do_an, DA.Ten_de_tai, DA.Mo_ta, DA.Hoc_ky, DA.Ngay_nop, DA.Nam,
                               GV.Ho_ten_gv as Ten_giang_vien
                        FROM Sinh_vien SV
                        LEFT JOIN Chuyen_nganh CN ON SV.Ma_chuyen_nganh = CN.Ma_chuyen_nganh
                        LEFT JOIN Do_an DA ON SV.Ma_sinh_vien = DA.Ma_sinh_vien
                        LEFT JOIN Giang_vien GV ON SV.Ma_giang_vien = GV.Ma_giang_vien
                        WHERE SV.Ma_sinh_vien = @maSV";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@maSV", maSinhVien);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Thông tin cá nhân
                                SetTextBoxValue("txtMaSV", reader["Ma_sinh_vien"].ToString());
                                SetTextBoxValue("txtHoTen", reader["Ho_ten"].ToString());
                                
                                if (reader["Ngay_sinh"] != DBNull.Value)
                                    SetTextBoxValue("txtNgaySinh", Convert.ToDateTime(reader["Ngay_sinh"]).ToString("dd/MM/yyyy"));
                                
                                SetTextBoxValue("txtGioiTinh", reader["Gioi_tinh"].ToString());
                                SetTextBoxValue("txtLop", reader["Lop"].ToString());
                                SetTextBoxValue("txtChuyenNganh", reader["Ten_chuyen_nganh"].ToString());
                                SetTextBoxValue("txtKhoa", reader["Khoa"].ToString());
                                SetTextBoxValue("txtEmail", reader["Email"].ToString());

                                // Thông tin đồ án
                                SetTextBoxValue("txtMaDoAn", reader["Ma_do_an"]?.ToString() ?? "");
                                SetTextBoxValue("txtTenDoAn", reader["Ten_de_tai"]?.ToString() ?? "");
                                SetTextBoxValue("txtMoTa", reader["Mo_ta"]?.ToString() ?? "");
                                SetTextBoxValue("txtGVHD", reader["Ten_giang_vien"]?.ToString() ?? "");
                                SetTextBoxValue("txtHocKy", reader["Hoc_ky"]?.ToString() ?? "");
                                SetTextBoxValue("txtNam", reader["Nam"]?.ToString() ?? "");
                                
                                if (reader["Ngay_nop"] != DBNull.Value)
                                {
                                    SetTextBoxValue("txtNgayNop", Convert.ToDateTime(reader["Ngay_nop"]).ToString("dd/MM/yyyy"));
                                }
                            }
                            else
                            {
                                MessageBox.Show("Không tìm thấy thông tin sinh viên!", "Lỗi",
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

        private void SetTextBoxValue(string controlName, string value)
        {
            Control[] controls = this.Controls.Find(controlName, true);
            if (controls.Length > 0 && controls[0] is TextBox textBox)
            {
                textBox.Text = value ?? "";
            }
        }
    }
}
