using System.Data;

public class MonHoc
{
    public string MaMonHoc { get; set; } // Khớp với SQL
    public string TenMonHoc { get; set; } // Khớp với SQL
    public int SoTinChi { get; set; }

    public MonHoc(DataRow row)
    {
        this.MaMonHoc = row["MaMonHoc"].ToString();
        this.TenMonHoc = row["TenMonHoc"].ToString();
        this.SoTinChi = (int)row["SoTinChi"];
    }
    public MonHoc(string ma, string ten, int tinChi)
    {
        this.MaMonHoc = ma;   // Sửa tên thuộc tính theo đúng code của bạn
        this.TenMonHoc = ten;
        this.SoTinChi = tinChi;
    }
}