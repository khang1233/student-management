using QuanLySinhVien.DTO;
using System.Collections.Generic;
using System.Data;

namespace QuanLySinhVien.DAO
{
    public class KetQuaDAO
    {
        private static KetQuaDAO instance;
        public static KetQuaDAO Instance
        {
            get { if (instance == null) instance = new KetQuaDAO(); return instance; }
            private set { instance = value; }
        }
        private KetQuaDAO() { }

        public List<KetQua> GetListKetQuaByMaSV(string maSV)
        {
            List<KetQua> list = new List<KetQua>();
            // Lấy điểm của Sinh viên, hiển thị cả môn chưa có điểm
            string query = "SELECT mh.TenMon, mh.MaMon, kq.DiemQT, kq.DiemThi, kq.DiemTongKet " +
                           "FROM MonHoc mh " +
                           "LEFT JOIN LopHocPhan lhp ON lhp.MaMon = mh.MaMon " +
                           "LEFT JOIN KetQua kq ON kq.MaLopHP = lhp.MaLopHP AND kq.MaSV = '" + maSV + "'";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                list.Add(new KetQua(item));
            }
            return list;
        }

        public bool SaveDiem(string maSV, string maMon, double diemQT, double diemThi)
        {
            // Tính điểm tổng kết
            double diemTK = (diemQT * 0.3) + (diemThi * 0.7);

            // [SỬA LỖI] Tìm Mã Lớp Học Phần thực tế từ Mã Môn
            string queryFindLHP = "SELECT TOP 1 MaLopHP FROM LopHocPhan WHERE MaMon = '" + maMon + "'";
            object result = DataProvider.Instance.ExecuteScalar(queryFindLHP);

            if (result == null) return false; // Nếu chưa mở lớp học phần cho môn này thì không lưu được

            string maLopHP = result.ToString();

            // Kiểm tra đã có điểm chưa để Insert hay Update
            string check = "SELECT * FROM KetQua WHERE MaSV = '" + maSV + "' AND MaLopHP = '" + maLopHP + "'";
            DataTable data = DataProvider.Instance.ExecuteQuery(check);

            string query;
            if (data.Rows.Count > 0)
            {
                query = "UPDATE KetQua SET DiemQT = " + diemQT + ", DiemThi = " + diemThi + ", DiemTongKet = " + diemTK +
                        " WHERE MaSV = '" + maSV + "' AND MaLopHP = '" + maLopHP + "'";
            }
            else
            {
                query = "INSERT INTO KetQua (MaSV, MaLopHP, DiemQT, DiemThi, DiemTongKet) " +
                        "VALUES ('" + maSV + "', '" + maLopHP + "', " + diemQT + ", " + diemThi + ", " + diemTK + ")";
            }

            return DataProvider.Instance.ExecuteNonQuery(query) > 0;
        }
    }
}