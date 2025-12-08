using System;
using System.Data;

namespace QuanLySinhVien.DTO
{
    public class MonHoc
    {
        // Các thuộc tính phải khớp với giao diện FrmMonHoc
        public string MaMonHoc { get; set; } // Tên này phải khớp với DAO (MaMonHoc)
        public string TenMonHoc { get; set; }
        public int SoTinChi { get; set; }

        public MonHoc(string ma, string ten, int tinchi)
        {
            this.MaMonHoc = ma;
            this.TenMonHoc = ten;
            this.SoTinChi = tinchi;
        }

        public MonHoc(DataRow row)
        {
            // QUAN TRỌNG: Tên trong row["..."] phải khớp với chữ sau chữ AS trong câu SQL bên DAO
            this.MaMonHoc = row["MaMonHoc"].ToString();
            this.TenMonHoc = row["TenMonHoc"].ToString();
            this.SoTinChi = (int)row["SoTinChi"];
        }
    }
}