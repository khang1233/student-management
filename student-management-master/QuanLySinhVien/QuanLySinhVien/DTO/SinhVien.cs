using System;
using System.Data;

namespace QuanLySinhVien.DTO
{
    public class SinhVien
    {
        // Các thuộc tính phải giống hệt tên cột trong SQL
        public string MaSV { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public string MaLop { get; set; }

        public SinhVien() { }

        // Hàm này giúp chuyển 1 dòng dữ liệu SQL thành 1 đối tượng SinhVien
        public SinhVien(DataRow row)
        {
            this.MaSV = row["MaSV"].ToString();
            this.HoTen = row["HoTen"].ToString();
            this.NgaySinh = (DateTime)row["NgaySinh"];
            this.GioiTinh = row["GioiTinh"].ToString();
            this.DiaChi = row["DiaChi"].ToString();
            this.SoDienThoai = row["SoDienThoai"].ToString();
            this.Email = row["Email"].ToString();
            this.MaLop = row["MaLop"].ToString();
        }
    }
}