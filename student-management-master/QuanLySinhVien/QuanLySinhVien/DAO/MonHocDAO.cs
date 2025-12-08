// Thay thế nội dung file MonHocDAO.cs bằng đoạn này
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

        // [SỬA QUAN TRỌNG]: Dùng AS để khớp tên cột
        public List<MonHoc> GetListMonHoc()
        {
            List<MonHoc> list = new List<MonHoc>();
            // Database là 'MaMon', nhưng Code muốn 'MaMonHoc' -> Dùng AS
            string query = "SELECT MaMon AS MaMonHoc, TenMon AS TenMonHoc, SoTinChi FROM MonHoc";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                list.Add(new MonHoc(item));
            }
            return list;
        }

        public bool InsertMonHoc(string ma, string ten, int tinchi)
        {
            string query = "INSERT INTO MonHoc (MaMon, TenMon, SoTinChi) VALUES ( @ma , @ten , @tinchi )";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { ma, ten, tinchi }) > 0;
        }

        public bool UpdateMonHoc(string ma, string ten, int tinchi)
        {
            string query = "UPDATE MonHoc SET TenMon = @ten , SoTinChi = @tinchi WHERE MaMon = @ma ";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { ten, tinchi, ma }) > 0;
        }

        public bool DeleteMonHoc(string ma)
        {
            string query = "DELETE MonHoc WHERE MaMon = @ma ";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { ma }) > 0;
        }

        public bool CheckExistMaMon(string ma)
        {
            string query = "SELECT * FROM MonHoc WHERE MaMon = '" + ma + "'";
            return DataProvider.Instance.ExecuteQuery(query).Rows.Count > 0;
        }

        public List<MonHoc> SearchMonHoc(string name)
        {
            List<MonHoc> list = new List<MonHoc>();
            // Cũng dùng AS ở đây
            string query = "SELECT MaMon AS MaMonHoc, TenMon AS TenMonHoc, SoTinChi FROM MonHoc WHERE TenMon LIKE N'%" + name + "%'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                list.Add(new MonHoc(item));
            }
            return list;
        }
    }
}