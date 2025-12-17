using QuanLyTrungTam.DAO;
using System.Data;

namespace QuanLyTrungTam.DAO
{
    public class KyNangDAO
    {
        private static KyNangDAO instance;
        public static KyNangDAO Instance
        {
            get { if (instance == null) instance = new KyNangDAO(); return instance; }
        }
        private KyNangDAO() { }
        // --- BỔ SUNG VÀO KyNangDAO.cs ---

        // 1. Thêm Môn học (Kỹ năng)
        public bool InsertKyNang(string maKyNang, string tenKyNang, decimal hocPhi, string moTa)
        {
            string query = string.Format("INSERT INTO KyNang (MaKyNang, TenKyNang, HocPhi, MoTa) VALUES ('{0}', N'{1}', {2}, N'{3}')",
                                         maKyNang, tenKyNang, hocPhi, moTa);
            return DataProvider.Instance.ExecuteNonQuery(query) > 0;
        }

        // 2. Sửa Môn học
        public bool UpdateKyNang(string maKyNang, string tenKyNang, decimal hocPhi, string moTa)
        {
            string query = string.Format("UPDATE KyNang SET TenKyNang = N'{1}', HocPhi = {2}, MoTa = N'{3}' WHERE MaKyNang = '{0}'",
                                         maKyNang, tenKyNang, hocPhi, moTa);
            return DataProvider.Instance.ExecuteNonQuery(query) > 0;
        }

        // 3. Xóa Môn học
        public bool DeleteKyNang(string maKyNang)
        {
            // Lưu ý: Cần xử lý ràng buộc khóa ngoại nếu môn đã có lớp học
            string query = string.Format("DELETE FROM KyNang WHERE MaKyNang = '{0}'", maKyNang);
            return DataProvider.Instance.ExecuteNonQuery(query) > 0;
        }
        public DataTable GetListKyNang()
        {
            // Lấy tất cả kỹ năng đang mở (TrangThai = 1
            string query = "SELECT * FROM KyNang WHERE TrangThai = 1";
            return DataProvider.Instance.ExecuteQuery(query);
        }
    }
}