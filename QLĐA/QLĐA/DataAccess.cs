using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace QLĐA
{
    public class UserSession
    {
        public string MaTaiKhoan { get; set; }
        public string TenDangNhap { get; set; }
        public string LoaiNguoiDung { get; set; } // Sẽ là "SinhVien", "GiangVien", "TruongKhoa"
        public string MaNguoiDung { get; set; } // Sẽ là MaSinhVien hoặc MaGiangVien
    }

    public class DataAccess
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["QuanLyDoAn"].ConnectionString;

        public UserSession KiemTraDangNhap(string tenDangNhap, string matKhau)
        {
            UserSession user = null; // Mặc định là null nếu đăng nhập thất bại

            // Sử dụng 'using' để đảm bảo kết nối được đóng ngay cả khi có lỗi
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // Chúng ta sẽ gọi Stored Procedure 'sp_DangNhap' bạn đã tạo
                    using (SqlCommand cmd = new SqlCommand("sp_DangNhap", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Thêm tham số để tránh lỗi SQL Injection
                        cmd.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
                        cmd.Parameters.AddWithValue("@MatKhau", matKhau); // LƯU Ý: Mật khẩu chưa mã hóa!

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read()) // Nếu tìm thấy một dòng (đăng nhập thành công)
                            {
                                user = new UserSession();
                                user.MaTaiKhoan = reader["MaTaiKhoan"].ToString();
                                user.TenDangNhap = reader["TenDangNhap"].ToString();
                                user.LoaiNguoiDung = reader["LoaiNguoiDung"].ToString();

                                // Lấy mã của sinh viên hoặc giảng viên
                                if (user.LoaiNguoiDung == "SinhVien")
                                {
                                    user.MaNguoiDung = reader["MaSinhVien"].ToString();
                                }
                                else
                                {
                                    user.MaNguoiDung = reader["MaGiangVien"].ToString();
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Có thể log lỗi ra file hoặc hiển thị thông báo
                    Console.WriteLine("Lỗi kết nối CSDL: " + ex.Message);
                }
            }
            return user;
        }
        public StudentProfile LayThongTinSinhVien(string maSinhVien)
        {
            StudentProfile profile = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_LayThongTinDayDuCuaSinhVien", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@MaSinhVien", maSinhVien);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                profile = new StudentProfile();

                                // Đọc thông tin cá nhân
                                profile.ThongTinCaNhan.MaSinhVien = reader["MaSinhVien"].ToString();
                                profile.ThongTinCaNhan.HoTen = reader["HoTen"].ToString();
                                profile.ThongTinCaNhan.GioiTinh = reader["GioiTinh"].ToString();
                                profile.ThongTinCaNhan.Lop = reader["Lop"].ToString();
                                profile.ThongTinCaNhan.Khoa = reader["Khoa"].ToString();
                                profile.ThongTinCaNhan.Email = reader["Email"].ToString();
                                profile.ThongTinCaNhan.SoDienThoai = reader["SoDienThoai"].ToString();

                                // Đọc thông tin đồ án (kiểm tra NULL trước)
                                if (reader["MaDoAn"] != DBNull.Value)
                                {
                                    profile.ThongTinDoAn = new DoAnInfo();
                                    profile.ThongTinDoAn.MaDoAn = reader["MaDoAn"].ToString();
                                    profile.ThongTinDoAn.TenDeTai = reader["TenDeTai"].ToString();
                                    profile.ThongTinDoAn.MoTa = reader["MoTa"].ToString();
                                    profile.ThongTinDoAn.TenGiangVien = reader["TenGiangVien"].ToString();
                                    profile.ThongTinDoAn.HocKy = reader["HocKy"].ToString();

                                    if (reader["NgayNop"] != DBNull.Value)
                                        profile.ThongTinDoAn.NgayNop = Convert.ToDateTime(reader["NgayNop"]);

                                    if (reader["Nam"] != DBNull.Value)
                                        profile.ThongTinDoAn.Nam = Convert.ToInt32(reader["Nam"]);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi (ví dụ: hiển thị MessageBox)
                    throw new Exception("Có lỗi xảy ra khi truy vấn thông tin sinh viên.", ex);
                }
            }
            return profile;
        }

    }
}
