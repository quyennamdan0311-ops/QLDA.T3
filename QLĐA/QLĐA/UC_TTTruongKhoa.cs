using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLĐA
{
    public partial class UC_TTTruongKhoa : UserControl
    {
        private string connectionString = "Data Source=DESKTOP-OREV608\\SQLEXPRESS;Initial Catalog=qldatn_final;Integrated Security=True;Encrypt=False";
        private string maTruongKhoa;

        public UC_TTTruongKhoa()
        {
            InitializeComponent();
        }

        public UC_TTTruongKhoa(string maTK) : this()
        {
            this.maTruongKhoa = maTK;
            LoadThongTinTruongKhoa();
        }

        private void LoadThongTinTruongKhoa()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"
                        SELECT Ma_giang_vien, Ho_ten_gv, Ngay_sinh, Gioi_tinh, Bang_cap, Chuc_danh, Email
                        FROM Giang_vien
                        WHERE Ma_giang_vien = @maTK";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@maTK", maTruongKhoa);

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
                                MessageBox.Show("Không tìm thấy thông tin trưởng khoa!", "Lỗi",
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
