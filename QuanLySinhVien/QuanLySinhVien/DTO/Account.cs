using System.Data;

namespace QuanLySinhVien.DTO
{
    public class Account
    {
        // Các thuộc tính khớp với bảng SQL TaiKhoan
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public string Quyen { get; set; } // Admin, GiangVien, SinhVien
        public string MaNguoiDung { get; set; } // Liên kết với SV hoặc GV

        public Account(DataRow row)
        {
            this.TenDangNhap = row["TenDangNhap"].ToString();
            this.MatKhau = row["MatKhau"].ToString();
            this.Quyen = row["Quyen"].ToString();

            // Xử lý null cho cột MaNguoiDung (vì Admin sẽ bị null)
            if (row["MaNguoiDung"].ToString() != "")
                this.MaNguoiDung = row["MaNguoiDung"].ToString();
            else
                this.MaNguoiDung = "";
        }
    }
}