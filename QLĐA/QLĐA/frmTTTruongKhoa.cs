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
    public partial class frmTTTruongKhoa : Form
    {
        private string connectionString = "Data Source=DESKTOP-OREV608\\SQLEXPRESS;Initial Catalog=qlđatn_final;Integrated Security=True;Encrypt=False";
        private string maTruongKhoa;

        // Constructor mặc định
        public frmTTTruongKhoa()
        {
            InitializeComponent();
        }

        // Constructor với mã trưởng khoa
        public frmTTTruongKhoa(string maTK) : this()
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

                    // Giả sử trưởng khoa cũng nằm trong bảng Giang_vien
                    string query = @"
                        SELECT Ma_giang_vien, Ho_ten, Gioi_tinh, Bang_cap, Chuc_danh, Email
                        FROM Giang_vien
                        WHERE Ma_giang_vien = @maTK";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@maTK", maTruongKhoa);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Hiển thị thông tin (sử dụng đúng tên control từ Designer)
                                txtMaGV.Text = reader["Ma_giang_vien"].ToString();
                                txtHoTen.Text = reader["Ho_ten"].ToString();
                                txtGioiTinh.Text = reader["Gioi_tinh"].ToString();
                                txtBangCap.Text = reader["Bang_cap"].ToString();
                                txtChucDanh.Text = reader["Chuc_danh"].ToString();
                                txtEmail.Text = reader["Email"].ToString();
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

        private void grbThongTinCaNhan_Enter(object sender, EventArgs e)
        {

        }
    }
}
