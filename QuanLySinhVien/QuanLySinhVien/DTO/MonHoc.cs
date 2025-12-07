using System.Data;

namespace QuanLySinhVien.DTO
{
    public class MonHoc
    {
        public string MaMonHoc { get; set; } // Sửa tên biến cho chuẩn
        public string TenMonHoc { get; set; }
        public int SoTinChi { get; set; }
        public string MaGV { get; set; }

        public MonHoc(string ma, string ten, int tinchi, string magv)
        {
            this.MaMonHoc = ma;
            this.TenMonHoc = ten;
            this.SoTinChi = tinchi;
            this.MaGV = magv;
        }

        public MonHoc(DataRow row)
        {
            // QUAN TRỌNG: Tên trong ngoặc vuông ["..."] phải khớp y chang cột bên SQL
            this.MaMonHoc = row["MaMonHoc"].ToString();
            this.TenMonHoc = row["TenMonHoc"].ToString();

            // Xử lý số tín chỉ (tránh lỗi nếu null)
            if (row["SoTinChi"].ToString() != "")
                this.SoTinChi = (int)row["SoTinChi"];
            else
                this.SoTinChi = 0;

            this.MaGV = row["MaGV"].ToString();
        }
    }
}