using System.Data;

namespace QuanLySinhVien.DTO
{
    public class MonHoc
    {
        public string MaMon { get; set; }
        public string TenMon { get; set; }
        public int SoTinChi { get; set; }

        public MonHoc() { }

        public MonHoc(DataRow row)
        {
            this.MaMon = row["MaMon"].ToString();
            this.TenMon = row["TenMon"].ToString();
            this.SoTinChi = (int)row["SoTinChi"];
        }
    }
}