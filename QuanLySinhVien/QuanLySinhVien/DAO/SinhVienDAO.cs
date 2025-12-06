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
            // Câu lệnh SQL Insert (Lưu ý: HinhAnh ta tạm để NULL, TrangThai mặc định là 1)
            string query = "INSERT INTO SinhVien (MaSV, HoTen, NgaySinh, GioiTinh, DiaChi, SoDienThoai, Email, HinhAnh, MaLop, TrangThai) " +
                           "VALUES ( @maSV , @hoTen , @ngaySinh , @gioiTinh , @diaChi , @sdt , @email , NULL , @maLop , 1 )";

            // Danh sách tham số truyền vào tương ứng với @ ở trên
            object[] parameters = new object[] { maSV, hoTen, ngaySinh, gioiTinh, diaChi, sdt, email, maLop };

            // Thực thi lệnh. Nếu số dòng thêm được > 0 nghĩa là thành công
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
        public System.Collections.Generic.List<SinhVien> SearchSinhVienByName(string name)
        {
            System.Collections.Generic.List<SinhVien> list = new System.Collections.Generic.List<SinhVien>();

            // Dùng LIKE N'%...%' để tìm kiếm gần đúng và có dấu tiếng Việt
            string query = "SELECT * FROM SinhVien WHERE HoTen LIKE N'%" + name + "%'";

            System.Data.DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (System.Data.DataRow item in data.Rows)
            {
                SinhVien sv = new SinhVien(item);
                list.Add(sv);
            }
            return list;
        }
    }
}   