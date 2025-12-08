using System.Data;

namespace QuanLySinhVien.DAO
{
    public class LopDAO
    {
        private static LopDAO instance;
        public static LopDAO Instance
        {
            get { if (instance == null) instance = new LopDAO(); return instance; }
            private set { instance = value; }
        }
        private LopDAO() { }

        // 1. Lấy danh sách lớp
        public DataTable GetListLop()
        {
            return DataProvider.Instance.ExecuteQuery("SELECT * FROM Lop");
        }

        // 2. Thêm lớp
        public bool InsertLop(string maLop, string tenLop, string maKhoa)
        {
            string query = string.Format("INSERT INTO Lop (MaLop, TenLop, MaKhoa) VALUES ('{0}', N'{1}', '{2}')", maLop, tenLop, maKhoa);
            return DataProvider.Instance.ExecuteNonQuery(query) > 0;
        }

        // 3. Sửa lớp
        public bool UpdateLop(string maLop, string tenLop, string maKhoa)
        {
            string query = string.Format("UPDATE Lop SET TenLop = N'{0}', MaKhoa = '{1}' WHERE MaLop = '{2}'", tenLop, maKhoa, maLop);
            return DataProvider.Instance.ExecuteNonQuery(query) > 0;
        }

        // 4. Xóa lớp
        public bool DeleteLop(string maLop)
        {
            string query = string.Format("DELETE FROM Lop WHERE MaLop = '{0}'", maLop);
            return DataProvider.Instance.ExecuteNonQuery(query) > 0;
        }
        public bool CheckKhoaTonTai(string maKhoa)
        {
            string query = "SELECT * FROM Khoa WHERE MaKhoa = '" + maKhoa + "'";
            System.Data.DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return result.Rows.Count > 0;
        }
    }
}