using QuanLySinhVien.DTO;
using System.Collections.Generic;
using System.Data;

namespace QuanLySinhVien.DAO
{
    public class MonHocDAO
    {
        private static MonHocDAO instance;
        public static MonHocDAO Instance
        {
            get { if (instance == null) instance = new MonHocDAO(); return instance; }
            private set { instance = value; }
        }
        private MonHocDAO() { }

        // 1. Lấy toàn bộ danh sách môn học
        public List<MonHoc> GetListMonHoc()
        {
            List<MonHoc> list = new List<MonHoc>();
            string query = "SELECT * FROM MonHoc";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                list.Add(new MonHoc(item));
            }
            return list;
        }

        // 2. Thêm môn học mới
        public bool InsertMonHoc(string ma, string ten, int tinchi)
        {
            // SỬA: MaMon -> MaMonHoc, TenMon -> TenMonHoc
            string query = "INSERT INTO MonHoc (MaMonHoc, TenMonHoc, SoTinChi) VALUES ( @ma , @ten , @tinchi )";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { ma, ten, tinchi });
            return result > 0;
        }

        // 3. Cập nhật môn học
        public bool UpdateMonHoc(string ma, string ten, int tinchi)
        {
            // SỬA: MaMon -> MaMonHoc, TenMon -> TenMonHoc
            string query = "UPDATE MonHoc SET TenMonHoc = @ten , SoTinChi = @tinchi WHERE MaMonHoc = @ma ";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { ten, tinchi, ma });
            return result > 0;
        }

        // 4. Xóa môn học
        public bool DeleteMonHoc(string ma)
        {
            // SỬA: MaMon -> MaMonHoc
            string query = "DELETE MonHoc WHERE MaMonHoc = @ma ";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { ma });
            return result > 0;
        }

        // 5. Kiểm tra mã môn đã tồn tại chưa
        public bool CheckExistMaMon(string ma)
        {
            // SỬA: MaMon -> MaMonHoc
            string query = "SELECT * FROM MonHoc WHERE MaMonHoc = '" + ma + "'";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return result.Rows.Count > 0;
        }

        // 6. Tìm kiếm môn học theo tên
        // 6. Tìm kiếm môn học theo Tên HOẶC Mã
        public List<MonHoc> SearchMonHoc(string keyword)
        {
            List<MonHoc> list = new List<MonHoc>();

            // SỬA CÂU LỆNH SQL: 
            // Thêm đoạn: OR MaMonHoc LIKE '%" + keyword + "%'
            // Ý nghĩa: Tìm những dòng mà Tên chứa từ khóa HOẶC Mã chứa từ khóa

            string query = "SELECT * FROM MonHoc WHERE TenMonHoc LIKE N'%" + keyword + "%' OR MaMonHoc LIKE '%" + keyword + "%'";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                list.Add(new MonHoc(item));
            }
            return list;
        }
    }
}