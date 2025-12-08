using System.Data;

namespace QuanLySinhVien.DTO
{
    public class GiangVien
    {
        // Các thuộc tính tương ứng với cột trong SQL
        public string MaGV { get; set; }
        public string HoTen { get; set; }
        public string GioiTinh { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }

        // Constructor 1: Tạo đối tượng thủ công (Dùng khi thêm/sửa)
        public GiangVien(string ma, string ten, string gt, string sdt, string email, string dc)
        {
            this.MaGV = ma;
            this.HoTen = ten;
            this.GioiTinh = gt;
            this.SoDienThoai = sdt;
            this.Email = email;
            this.DiaChi = dc;
        }

        // Constructor 2: Tạo đối tượng từ dòng dữ liệu SQL (Dùng khi hiển thị lên bảng)
        public GiangVien(DataRow row)
        {
            this.MaGV = row["MaGV"].ToString();
            this.HoTen = row["HoTen"].ToString();
            this.GioiTinh = row["GioiTinh"].ToString();
            this.SoDienThoai = row["SoDienThoai"].ToString();
            this.Email = row["Email"].ToString();
            this.DiaChi = row["DiaChi"].ToString();
        }
    }
}