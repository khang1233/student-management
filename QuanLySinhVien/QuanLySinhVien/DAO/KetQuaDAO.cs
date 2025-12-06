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

        // 1. Lấy bảng điểm của 1 Sinh Viên (Kết hợp bảng MonHoc và KetQua)
        public List<KetQua> GetListKetQuaByMaSV(string maSV)
        {
            List<KetQua> list = new List<KetQua>();

            // Câu lệnh SQL "thần thánh": Lấy tất cả Môn học, nếu SV có điểm thì hiện, chưa có thì hiện NULL
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

        // 2. Lưu điểm (Tự động Insert hoặc Update)
        public bool SaveDiem(string maSV, string maMon, double diemQT, double diemThi)
        {
            // Tính điểm tổng kết (VD: 30% - 70%)
            double diemTK = (diemQT * 0.3) + (diemThi * 0.7);

            // Tìm mã lớp học phần tương ứng
            string maLopHP = "LHP_" + maMon;

            // Kiểm tra xem đã có điểm chưa?
            string check = "SELECT * FROM KetQua WHERE MaSV = '" + maSV + "' AND MaLopHP = '" + maLopHP + "'";
            var data = DataProvider.Instance.ExecuteQuery(check);

            string query;
            if (data.Rows.Count > 0)
            {
                // Có rồi -> UPDATE
                query = "UPDATE KetQua SET DiemQT = " + diemQT + ", DiemThi = " + diemThi + ", DiemTongKet = " + diemTK +
                        " WHERE MaSV = '" + maSV + "' AND MaLopHP = '" + maLopHP + "'";
            }
            else
            {
                // Chưa có -> INSERT
                query = "INSERT INTO KetQua (MaSV, MaLopHP, DiemQT, DiemThi, DiemTongKet) " +
                        "VALUES ('" + maSV + "', '" + maLopHP + "', " + diemQT + ", " + diemThi + ", " + diemTK + ")";
            }

            return DataProvider.Instance.ExecuteNonQuery(query) > 0;
        }
    }
}