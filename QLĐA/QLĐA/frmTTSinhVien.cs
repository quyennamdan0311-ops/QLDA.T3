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
    public partial class frmTTSinhVien : Form
    {
        private string connectionString = "Data Source=DESKTOP-OREV608\\SQLEXPRESS;Initial Catalog=qlđatn_final;Integrated Security=True;Encrypt=False";
        private string maSinhVien;

        // Constructor mặc định (cho designer)
        public frmTTSinhVien()
        {
            InitializeComponent();
        }

        // Constructor với mã sinh viên
        public frmTTSinhVien(string maSV) : this()
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

                    // Truy vấn thông tin sinh viên và đồ án
                    string query = @"
                        SELECT SV.Ma_sinh_vien, SV.Ho_ten, SV.Gioi_tinh, SV.Lop, 
                               SV.Khoa, SV.Email, 
                               CN.Ten_chuyen_nganh,
                               DA.Ma_do_an, DA.Ten_de_tai, DA.Mo_ta, DA.Hoc_ky, DA.Ngay_nop,DA.Nam,
                               GV.Ho_ten as Ten_giang_vien
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
                                txtMaSV.Text = reader["Ma_sinh_vien"].ToString();
                                txtHoTen.Text = reader["Ho_ten"].ToString();
                                txtGioiTinh.Text = reader["Gioi_tinh"].ToString();
                                txtLop.Text = reader["Lop"].ToString();
                                txtChuyenNganh.Text = reader["Ten_chuyen_nganh"].ToString();
                                txtKhoa.Text = reader["Khoa"].ToString();
                                txtEmail.Text = reader["Email"].ToString();

                                // Thông tin đồ án
                                txtMaDoAn.Text = reader["Ma_do_an"]?.ToString() ?? "";
                                txtTenDoAn.Text = reader["Ten_de_tai"]?.ToString() ?? "";
                                txtMoTa.Text = reader["Mo_ta"]?.ToString() ?? "";
                                txtGVHD.Text = reader["Ten_giang_vien"]?.ToString() ?? "";
                                txtHocKy.Text = reader["Hoc_ky"]?.ToString() ?? "";
                                txtNam.Text = reader["Nam"]?.ToString() ?? "";
                                
                                // Hiển thị ngày nộp với định dạng dd/MM/yyyy
                                if (reader["Ngay_nop"] != DBNull.Value)
                                {
                                    txtNgayNop.Text = Convert.ToDateTime(reader["Ngay_nop"]).ToString("dd/MM/yyyy");
                                }
                                else
                                {
                                    txtNgayNop.Text = "";
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
    }
}
