using System.Data;

namespace QuanLySinhVien.DTO
{
    public class KetQua
    {
        public string TenMon { get; set; } // Hiển thị tên cho dễ nhìn
        public string MaMon { get; set; }  // Dùng để xử lý
        public double DiemQT { get; set; }
        public double DiemThi { get; set; }
        public double DiemTongKet { get; set; }

        public KetQua() { }

        public KetQua(DataRow row)
        {
            this.TenMon = row["TenMon"].ToString();
            this.MaMon = row["MaMon"].ToString();

            // Xử lý lỗi null khi mới thêm môn chưa có điểm
            this.DiemQT = row["DiemQT"].ToString() != "" ? double.Parse(row["DiemQT"].ToString()) : 0;
            this.DiemThi = row["DiemThi"].ToString() != "" ? double.Parse(row["DiemThi"].ToString()) : 0;
            this.DiemTongKet = row["DiemTongKet"].ToString() != "" ? double.Parse(row["DiemTongKet"].ToString()) : 0;
        }
    }
}