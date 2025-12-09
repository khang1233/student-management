using System.Data;

namespace QuanLySinhVien.DAO
{
    public class HocPhiDAO
    {
        private static HocPhiDAO instance;
        public static HocPhiDAO Instance
        {
            get { if (instance == null) instance = new HocPhiDAO(); return instance; }
            private set { instance = value; }
        }
        private HocPhiDAO() { }

        // 1. Lấy thông tin học phí của 1 sinh viên
        public DataTable GetHocPhi(string maSV)
        {
            // SỬA TẠI DÒNG DƯỚI ĐÂY:
            string init = "INSERT INTO HocPhi (MaSV, TongTien, DaDong) " +
                          "SELECT '" + maSV + "', 5000000, 0 " +
                          "WHERE NOT EXISTS (SELECT * FROM HocPhi WHERE MaSV = '" + maSV + "')";

            DataProvider.Instance.ExecuteNonQuery(init);

            string query = "SELECT * FROM HocPhi WHERE MaSV = '" + maSV + "'";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        // 2. Cập nhật số tiền đã đóng
        public bool DongHocPhi(string maSV, double soTienMoiDong)
        {
            // Cộng dồn số tiền mới vào số tiền cũ
            string query = "UPDATE HocPhi SET DaDong = DaDong + " + soTienMoiDong + " WHERE MaSV = '" + maSV + "'";
            return DataProvider.Instance.ExecuteNonQuery(query) > 0;
        }
    }
}