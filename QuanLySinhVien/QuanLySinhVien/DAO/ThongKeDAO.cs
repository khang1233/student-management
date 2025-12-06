using System;
using System.Data;

namespace QuanLySinhVien.DAO
{
    public class ThongKeDAO
    {
        private static ThongKeDAO instance;
        public static ThongKeDAO Instance
        {
            get { if (instance == null) instance = new ThongKeDAO(); return instance; }
            private set { instance = value; }
        }
        private ThongKeDAO() { }

        // 1. Đếm tổng số sinh viên
        public int GetTongSinhVien()
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("SELECT COUNT(*) FROM SinhVien");
            }
            catch { return 0; }
        }

        // 2. Đếm tổng số lớp
        public int GetTongLop()
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("SELECT COUNT(*) FROM Lop");
            }
            catch { return 0; }
        }

        // 3. Tính tổng tiền đã thu (Doanh thu)
        public decimal GetTongDoanhThu()
        {
            try
            {
                // Nếu chưa có ai đóng tiền thì trả về 0
                object result = DataProvider.Instance.ExecuteScalar("SELECT SUM(DaDong) FROM HocPhi");
                if (result == DBNull.Value) return 0;
                return Convert.ToDecimal(result);
            }
            catch { return 0; }
        }
    }
}