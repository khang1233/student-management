using QuanLyTrungTam.DAO;
using System;
using System.Data;
namespace QuanLyTrungTam.DAO
{
    public class HocVienDAO
    {
        private static HocVienDAO instance;
        public static HocVienDAO Instance
        {
            get { if (instance == null) instance = new HocVienDAO(); return instance; }
        }
        private HocVienDAO() { }
        // --- BỔ SUNG VÀO HocVienDAO.cs ---

        // 1. Thêm Học Viên
        public bool InsertHocVien(string maHV, string hoTen, DateTime ngaySinh, string sdt, string email, string diaChi)
        {
            string query = string.Format("INSERT INTO HocVien (MaHV, HoTen, NgaySinh, SoDienThoai, Email, DiaChi, NgayGiaNhap) " +
                                         "VALUES ('{0}', N'{1}', '{2}', '{3}', '{4}', N'{5}', GETDATE())",
                                         maHV, hoTen, ngaySinh.ToString("yyyy-MM-dd"), sdt, email, diaChi);
            return DataProvider.Instance.ExecuteNonQuery(query) > 0;
        }

        // 2. Sửa Học Viên
        public bool UpdateHocVien(string maHV, string hoTen, DateTime ngaySinh, string sdt, string email, string diaChi)
        {
            string query = string.Format("UPDATE HocVien SET HoTen = N'{1}', NgaySinh = '{2}', SoDienThoai = '{3}', Email = '{4}', DiaChi = N'{5}' " +
                                         "WHERE MaHV = '{0}'",
                                         maHV, hoTen, ngaySinh.ToString("yyyy-MM-dd"), sdt, email, diaChi);
            return DataProvider.Instance.ExecuteNonQuery(query) > 0;
        }

        // 3. Xóa Học Viên
        public bool DeleteHocVien(string maHV)
        {
            // Lưu ý: Cần xóa tài khoản và thông tin đăng ký trước (nếu không dùng Trigger SQL)
            // Ở đây ta xóa Tài Khoản trước để tránh lỗi khóa ngoại
            DataProvider.Instance.ExecuteNonQuery("DELETE FROM TaiKhoan WHERE MaNguoiDung = '" + maHV + "'");

            // Sau đó xóa Học Viên (Nếu đã có công nợ/đăng ký thì SQL sẽ báo lỗi khóa ngoại -> Cần xử lý kỹ hơn ở DB)
            string query = string.Format("DELETE FROM HocVien WHERE MaHV = '{0}'", maHV);
            return DataProvider.Instance.ExecuteNonQuery(query) > 0;
        }
        public DataTable GetListHocVien()
        {
            return DataProvider.Instance.ExecuteQuery("SELECT * FROM HocVien");
        }
    }
}