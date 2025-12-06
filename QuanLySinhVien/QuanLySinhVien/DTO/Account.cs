using System.Data;

namespace QuanLySinhVien.DTO
{
    public class Account
    {
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public string Quyen { get; set; } // Quan trọng nhất: Admin, GiangVien, SinhVien
        public string MaNguoiDung { get; set; } // Để biết là SV nào

        public Account(DataRow row)
        {
            this.TenDangNhap = row["TenDangNhap"].ToString();
            this.MatKhau = row["MatKhau"].ToString();
            this.Quyen = row["Quyen"].ToString();
            this.MaNguoiDung = row["MaNguoiDung"].ToString();
        }
    }
}