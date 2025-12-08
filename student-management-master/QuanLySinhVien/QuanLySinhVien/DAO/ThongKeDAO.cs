using System;
using System.Data;

namespace QuanLySinhVien.DAO
{
    public class ThongKeDAO
    {
        private static ThongKeDAO instance;

        public static ThongKeDAO Instance
        {
            get { if (instance == null) instance = new ThongKeDAO(); return ThongKeDAO.instance; }
            private set { ThongKeDAO.instance = value; }
        }

        private ThongKeDAO() { }

        // 1. Tổng sinh viên
        public int GetTongSinhVien()
        {
            try { return (int)DataProvider.Instance.ExecuteScalar("SELECT COUNT(*) FROM SINHVIEN"); }
            catch { return 0; }
        }

        // 2. Tổng lớp
        public int GetTongLop()
        {
            try { return (int)DataProvider.Instance.ExecuteScalar("SELECT COUNT(*) FROM LOP"); }
            catch { return 0; }
        }

        // 3. [ĐÃ SỬA LẠI] Cảnh báo học vụ: Đếm số lượng SINH VIÊN (không đếm trùng)
        public int GetSoCanhBaoHocVu()
        {
            try
            {
                // Thêm chữ DISTINCT MaSV để chỉ đếm mỗi sinh viên 1 lần duy nhất
                string query = "SELECT COUNT(DISTINCT MaSV) FROM KETQUA WHERE DiemTongKet < 4.0";

                return (int)DataProvider.Instance.ExecuteScalar(query);
            }
            catch { return 0; }
        }

        // 4. Tỷ lệ Nam/Nữ
        public string GetTyLeNamNu()
        {
            try
            {
                int soNu = (int)DataProvider.Instance.ExecuteScalar("SELECT COUNT(*) FROM SINHVIEN WHERE GioiTinh = N'Nữ'");
                int tongSV = GetTongSinhVien();
                if (tongSV == 0) return "Chưa có dữ liệu";
                double phanTramNu = Math.Round((double)soNu * 100 / tongSV, 1);
                double phanTramNam = 100 - phanTramNu;
                return $"{phanTramNam}% Nam{Environment.NewLine}{phanTramNu}% Nữ";
            }
            catch { return "Lỗi Data"; }
        }


        // 5. Thống kê Học lực (Cho biểu đồ tròn)
        public DataTable GetPhanBoHocLuc()
        {
            string query = @"
                SELECT 
                    CASE 
                        WHEN DiemTongKet >= 8.0 THEN N'Giỏi'
                        WHEN DiemTongKet >= 6.5 THEN N'Khá'
                        WHEN DiemTongKet >= 5.0 THEN N'Trung bình'
                        ELSE N'Yếu'
                    END as XepLoai,
                    COUNT(MaSV) as SoLuong
                FROM KETQUA
                GROUP BY 
                    CASE 
                        WHEN DiemTongKet >= 8.0 THEN N'Giỏi'
                        WHEN DiemTongKet >= 6.5 THEN N'Khá'
                        WHEN DiemTongKet >= 5.0 THEN N'Trung bình'
                        ELSE N'Yếu'
                    END";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        // 6. Số lượng SV theo Khoa
        public DataTable GetSinhVienTheoKhoa()
        {
            string query = "SELECT k.TenKhoa, COUNT(s.MaSV) as SoLuong FROM KHOA k JOIN LOP l ON k.MaKhoa = l.MaKhoa JOIN SINHVIEN s ON l.MaLop = s.MaLop GROUP BY k.TenKhoa";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        // 7. Top 5 Sinh viên
        public DataTable GetTopSinhVien()
        {
            string query = "SELECT TOP 5 s.MaSV, s.HoTen, k.TenKhoa, ROUND(ISNULL(AVG(kq.DiemTongKet), 0), 2) as DiemTB FROM SINHVIEN s JOIN LOP l ON s.MaLop = l.MaLop JOIN KHOA k ON l.MaKhoa = k.MaKhoa LEFT JOIN KETQUA kq ON s.MaSV = kq.MaSV GROUP BY s.MaSV, s.HoTen, k.TenKhoa ORDER BY DiemTB DESC";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        // 8. Tìm kiếm
        public DataTable TimKiemSinhVien(string keyword)
        {
            string query = "SELECT s.MaSV, s.HoTen, k.TenKhoa, ROUND(ISNULL(AVG(kq.DiemTongKet), 0), 2) as DiemTB FROM SINHVIEN s JOIN LOP l ON s.MaLop = l.MaLop JOIN KHOA k ON l.MaKhoa = k.MaKhoa LEFT JOIN KETQUA kq ON s.MaSV = kq.MaSV WHERE s.MaSV LIKE '%" + keyword + "%' OR s.HoTen LIKE N'%" + keyword + "%' GROUP BY s.MaSV, s.HoTen, k.TenKhoa";
            return DataProvider.Instance.ExecuteQuery(query);
        }
    }
}