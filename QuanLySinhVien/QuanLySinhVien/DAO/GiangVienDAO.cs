using QuanLySinhVien.DTO;
using System.Collections.Generic;
using System.Data;

namespace QuanLySinhVien.DAO
{
    public class GiangVienDAO
    {
        private static GiangVienDAO instance;
        public static GiangVienDAO Instance
        {
            get { if (instance == null) instance = new GiangVienDAO(); return instance; }
            private set { instance = value; }
        }

        private GiangVienDAO() { }

        // 1. Lấy danh sách
        public List<GiangVien> GetListGiangVien()
        {
            List<GiangVien> list = new List<GiangVien>();
            string query = "SELECT * FROM GiangVien";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                list.Add(new GiangVien(item));
            }
            return list;
        }

        // 2. Thêm Giảng Viên (Khớp với SQL: MaGV, HoTen, GioiTinh, SDT, Email, DiaChi)
        public bool InsertGiangVien(string ma, string ten, string gioitinh, string sdt, string email, string diachi)
        {
            string query = string.Format("INSERT INTO GiangVien (MaGV, HoTen, GioiTinh, SoDienThoai, Email, DiaChi) VALUES (N'{0}', N'{1}', N'{2}', N'{3}', N'{4}', N'{5}')",
                                          ma, ten, gioitinh, sdt, email, diachi);
            return DataProvider.Instance.ExecuteNonQuery(query) > 0;
        }

        // 3. Sửa Giảng Viên
        public bool UpdateGiangVien(string ma, string ten, string gioitinh, string sdt, string email, string diachi)
        {
            string query = string.Format("UPDATE GiangVien SET HoTen = N'{1}', GioiTinh = N'{2}', SoDienThoai = N'{3}', Email = N'{4}', DiaChi = N'{5}' WHERE MaGV = N'{0}'",
                                          ma, ten, gioitinh, sdt, email, diachi);
            return DataProvider.Instance.ExecuteNonQuery(query) > 0;
        }

        // 4. Xóa Giảng Viên
        public bool DeleteGiangVien(string ma)
        {
            // Lưu ý: Nếu GV đang dạy môn học hoặc có lớp, SQL sẽ chặn xóa (do khóa ngoại)
            string query = string.Format("DELETE GiangVien WHERE MaGV = N'{0}'", ma);
            return DataProvider.Instance.ExecuteNonQuery(query) > 0;
        }
    }
}