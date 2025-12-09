using QuanLySinhVien.DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace QuanLySinhVien.DAO
{
    public class SinhVienDAO
    {
        private static SinhVienDAO instance;

        public static SinhVienDAO Instance
        {
            get { if (instance == null) instance = new SinhVienDAO(); return SinhVienDAO.instance; }
            private set { SinhVienDAO.instance = value; }
        }

        private SinhVienDAO() { }

        // Hàm lấy toàn bộ danh sách sinh viên
        public List<SinhVien> GetListSinhVien()
        {
            List<SinhVien> list = new List<SinhVien>();

            string query = "SELECT * FROM SinhVien"; // Lệnh SQL đơn giản

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                SinhVien sv = new SinhVien(item);
                list.Add(sv);
            }

            return list;
        }
        public bool InsertSinhVien(string maSV, string hoTen, DateTime ngaySinh, string gioiTinh, string diaChi, string sdt, string email, string maLop)
        {
            // Đã xóa HinhAnh và TrangThai khỏi câu lệnh SQL
            string query = "INSERT INTO SinhVien (MaSV, HoTen, NgaySinh, GioiTinh, DiaChi, SoDienThoai, Email, MaLop) " +
                           "VALUES ( @maSV , @hoTen , @ngaySinh , @gioiTinh , @diaChi , @sdt , @email , @maLop )";

            // Danh sách tham số (giữ nguyên vì số lượng tham số đầu vào không đổi)
            object[] parameters = new object[] { maSV, hoTen, ngaySinh, gioiTinh, diaChi, sdt, email, maLop };

            int result = DataProvider.Instance.ExecuteNonQuery(query, parameters);

            return result > 0;
        }

        // Hàm kiểm tra trùng mã sinh viên (Để tránh lỗi khi nhập trùng)
        public bool CheckExistMaSV(string maSV)
        {
            string query = "SELECT * FROM SinhVien WHERE MaSV = '" + maSV + "'";
            var result = DataProvider.Instance.ExecuteQuery(query);
            return result.Rows.Count > 0;
        }
        // 1. Hàm Cập nhật thông tin sinh viên
        public bool UpdateSinhVien(string maSV, string hoTen, DateTime ngaySinh, string gioiTinh, string diaChi, string sdt, string email, string maLop)
        {
            // Cập nhật tất cả trừ MaSV (vì là khóa chính)
            string query = "UPDATE SinhVien SET HoTen = @hoTen , NgaySinh = @ngaySinh , GioiTinh = @gioiTinh , DiaChi = @diaChi , SoDienThoai = @sdt , Email = @email , MaLop = @maLop WHERE MaSV = @maSV";

            object[] parameters = new object[] { hoTen, ngaySinh, gioiTinh, diaChi, sdt, email, maLop, maSV }; // Lưu ý thứ tự tham số phải khớp với query

            int result = DataProvider.Instance.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

        // 2. Hàm Xóa sinh viên
        public bool DeleteSinhVien(string maSV)
        {
            // Lưu ý: Nếu sinh viên đã có bảng điểm, bạn phải xóa điểm trước hoặc dùng Trigger trong SQL.
            // Ở mức độ cơ bản, ta xóa trực tiếp.
            string query = "DELETE FROM SinhVien WHERE MaSV = @maSV";

            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { maSV });
            return result > 0;
        }
        public List<SinhVien> SearchSinhVienByID(string id)
        {
            List<SinhVien> list = new List<SinhVien>();
            // Dùng dấu = để tìm chính xác, tránh việc SV001 nhìn thấy SV0011
            string query = "SELECT * FROM SinhVien WHERE MaSV = '" + id + "'";

            System.Data.DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (System.Data.DataRow item in data.Rows)
            {
                list.Add(new SinhVien(item));
            }
            return list;
        }
    }
}   