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

        // 1. Lấy danh sách GV
        public DataTable GetListGiangVien()
        {
            return DataProvider.Instance.ExecuteQuery("SELECT * FROM GiangVien");
        }

        // 2. Thêm GV
        public bool InsertGiangVien(string maGV, string hoTen, string sdt, string email, string maKhoa)
        {
            string query = string.Format("INSERT INTO GiangVien (MaGV, HoTen, SoDienThoai, Email, MaKhoa) VALUES ('{0}', N'{1}', '{2}', '{3}', '{4}')", maGV, hoTen, sdt, email, maKhoa);
            return DataProvider.Instance.ExecuteNonQuery(query) > 0;
        }

        // 3. Sửa GV
        public bool UpdateGiangVien(string maGV, string hoTen, string sdt, string email, string maKhoa)
        {
            string query = string.Format("UPDATE GiangVien SET HoTen = N'{0}', SoDienThoai = '{1}', Email = '{2}', MaKhoa = '{3}' WHERE MaGV = '{4}'", hoTen, sdt, email, maKhoa, maGV);
            return DataProvider.Instance.ExecuteNonQuery(query) > 0;
        }

        // 4. Xóa GV
        public bool DeleteGiangVien(string maGV)
        {
            string query = string.Format("DELETE FROM GiangVien WHERE MaGV = '{0}'", maGV);
            return DataProvider.Instance.ExecuteNonQuery(query) > 0;
        }
        public bool CheckKhoaTonTai(string maKhoa)
        {
            // Tìm xem trong bảng Khoa có mã này không
            string query = "SELECT * FROM Khoa WHERE MaKhoa = '" + maKhoa + "'";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);

            // Nếu số dòng > 0 nghĩa là Có tồn tại
            return result.Rows.Count > 0;
        }
    }
}