using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLĐA
{
    public class SinhVienInfo
    {
        public string MaSinhVien { get; set; }
        public string HoTen { get; set; }
        public string Lop { get; set; }

        public string GioiTinh { get; set; }
        public string Khoa { get; set; }
        public string Email { get; set; }
        public string SoDienThoai { get; set; }
    }

    // Lớp chứa thông tin về đồ án
    public class DoAnInfo
    {
        public string MaDoAn { get; set; }
        public string TenDeTai { get; set; }
        public string MoTa { get; set; }
        public string TenGiangVien { get; set; }
        public DateTime? NgayNop { get; set; } // Dùng DateTime? để chấp nhận giá trị NULL
        public string HocKy { get; set; }
        public int? Nam { get; set; } // Dùng int? để chấp nhận giá trị NULL
    }

    // Lớp tổng hợp, chứa cả thông tin cá nhân và đồ án
    public class StudentProfile
    {
        public SinhVienInfo ThongTinCaNhan { get; set; }
        public DoAnInfo ThongTinDoAn { get; set; }

        public StudentProfile()
        {
            ThongTinCaNhan = new SinhVienInfo();
            // ThongTinDoAn có thể là null nếu sinh viên chưa có đồ án
        }
    }
   
}
