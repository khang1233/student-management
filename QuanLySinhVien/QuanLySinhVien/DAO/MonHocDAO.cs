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
            string query = "INSERT INTO MonHoc (MaMon, TenMon, SoTinChi) VALUES ( @ma , @ten , @tinchi )";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { ma, ten, tinchi });
            return result > 0;
        }

        // 3. Cập nhật môn học
        public bool UpdateMonHoc(string ma, string ten, int tinchi)
        {
            string query = "UPDATE MonHoc SET TenMon = @ten , SoTinChi = @tinchi WHERE MaMon = @ma ";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { ten, tinchi, ma });
            return result > 0;
        }

        // 4. Xóa môn học
        public bool DeleteMonHoc(string ma)
        {
            // Lưu ý: Nếu môn học đã có điểm thì không nên xóa (sẽ lỗi khóa ngoại)
            string query = "DELETE MonHoc WHERE MaMon = @ma ";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { ma });
            return result > 0;
        }

        // 5. Kiểm tra mã môn đã tồn tại chưa (HÀM BẠN ĐANG THIẾU)
        public bool CheckExistMaMon(string ma)
        {
            string query = "SELECT * FROM MonHoc WHERE MaMon = '" + ma + "'";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return result.Rows.Count > 0;
        }

        // 6. Tìm kiếm môn học theo tên
        public List<MonHoc> SearchMonHoc(string name)
        {
            List<MonHoc> list = new List<MonHoc>();
            string query = "SELECT * FROM MonHoc WHERE TenMon LIKE N'%" + name + "%'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                list.Add(new MonHoc(item));
            }
            return list;
        }
    }
}