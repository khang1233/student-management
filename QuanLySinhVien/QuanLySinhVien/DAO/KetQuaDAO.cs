using QuanLySinhVien.DTO;
using System.Collections.Generic;
using System.Data;
using System;

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

        // 1. Lấy bảng điểm: JOIN trực tiếp MonHoc và KetQua (BỎ LopHocPhan)
        public List<KetQua> GetListKetQuaByMaSV(string maSV)
        {
            List<KetQua> list = new List<KetQua>();

            // SỬA CÂU LENH SQL:
            // 1. Bỏ bảng LopHocPhan.
            // 2. Map cột SQL (DiemLan1) sang tên biến C# (DiemQT) bằng lệnh AS.
            // 3. Tính DiemTongKet ngay trong câu lệnh SQL (vì bảng KetQua không lưu cột này).

            string query = "SELECT mh.TenMonHoc AS TenMon, mh.MaMonHoc AS MaMon, " +
                           "kq.DiemLan1 AS DiemQT, kq.DiemLan2 AS DiemThi, " +
                           "(ISNULL(kq.DiemLan1, 0) * 0.3 + ISNULL(kq.DiemLan2, 0) * 0.7) AS DiemTongKet " +
                           "FROM MonHoc mh " +
                           "LEFT JOIN KetQua kq ON kq.MaMonHoc = mh.MaMonHoc AND kq.MaSV = '" + maSV + "'";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                list.Add(new KetQua(item));
            }
            return list;
        }

        // 2. Lưu điểm: Sửa lại logic INSERT/UPDATE theo MaMonHoc
        public bool SaveDiem(string maSV, string maMon, double diemQT, double diemThi)
        {
            // Kiểm tra xem sinh viên này đã có điểm môn này chưa
            string check = "SELECT * FROM KetQua WHERE MaSV = '" + maSV + "' AND MaMonHoc = '" + maMon + "'";
            var data = DataProvider.Instance.ExecuteQuery(check);

            string query;
            if (data.Rows.Count > 0)
            {
                // Có rồi -> UPDATE (Dùng cột DiemLan1, DiemLan2 như trong SQL của bạn)
                query = "UPDATE KetQua SET DiemLan1 = " + diemQT + ", DiemLan2 = " + diemThi +
                        " WHERE MaSV = '" + maSV + "' AND MaMonHoc = '" + maMon + "'";
            }
            else
            {
                // Chưa có -> INSERT
                query = "INSERT INTO KetQua (MaSV, MaMonHoc, DiemLan1, DiemLan2) " +
                        "VALUES ('" + maSV + "', '" + maMon + "', " + diemQT + ", " + diemThi + ")";
            }

            return DataProvider.Instance.ExecuteNonQuery(query) > 0;
        }
        // Hàm lấy điểm cho riêng 1 sinh viên
        public System.Data.DataTable GetListDiemByMaSV(string maSV)
        {
            // Chỉ lấy những dòng có MaSV trùng với người đăng nhập
            string query = "SELECT * FROM Diem WHERE MaSV = '" + maSV + "'";

            return DataProvider.Instance.ExecuteQuery(query);
        }
    }
}