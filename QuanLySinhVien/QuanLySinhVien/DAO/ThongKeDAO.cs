using QuanLySinhVien.DTO;
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

        // 1. Tổng sinh viên
        public int GetTongSinhVien()
        {
            try { return (int)DataProvider.Instance.ExecuteScalar("SELECT COUNT(*) FROM SinhVien"); }
            catch { return 0; }
        }

        // 2. Tổng lớp
        public int GetTongLop()
        {
            try { return (int)DataProvider.Instance.ExecuteScalar("SELECT COUNT(*) FROM Lop"); }
            catch { return 0; }
        }

        // 3. Số cảnh báo học vụ (Giả sử: Sinh viên có điểm tổng kết môn nào đó < 4)
        public int GetSoCanhBaoHocVu()
        {
            try
            {
                // Đếm số sinh viên có ít nhất 1 môn điểm trung bình < 4.0
                string query = "SELECT COUNT(DISTINCT MaSV) FROM KetQua WHERE (ISNULL(DiemLan1,0)*0.3 + ISNULL(DiemLan2,0)*0.7) < 4.0";
                return (int)DataProvider.Instance.ExecuteScalar(query);
            }
            catch { return 0; }
        }

        // 4. Tỷ lệ Nam/Nữ
        public string GetTyLeNamNu()
        {
            try
            {
                int nam = (int)DataProvider.Instance.ExecuteScalar("SELECT COUNT(*) FROM SinhVien WHERE GioiTinh = N'Nam'");
                int nu = (int)DataProvider.Instance.ExecuteScalar("SELECT COUNT(*) FROM SinhVien WHERE GioiTinh = N'Nữ'");

                int tong = nam + nu;
                if (tong == 0) return "0% / 0%";

                double phanTramNam = Math.Round((double)nam / tong * 100, 1);
                double phanTramNu = 100 - phanTramNam;

                return $"{phanTramNam}% / {phanTramNu}%";
            }
            catch { return "0% / 0%"; }
        }

        // 5. Phân bố học lực (Cho biểu đồ tròn)
        public DataTable GetPhanBoHocLuc()
        {
            // Logic: Tính ĐTB của từng SV -> Xếp loại -> Đếm số lượng theo loại
            // Query này hơi phức tạp một chút để chạy 1 lần lấy hết dữ liệu
            string query = @"
                SELECT XepLoai, COUNT(*) as SoLuong
                FROM (
                    SELECT 
                        CASE 
                            WHEN AVG(ISNULL(DiemLan1,0)*0.3 + ISNULL(DiemLan2,0)*0.7) >= 8.5 THEN N'Xuất sắc'
                            WHEN AVG(ISNULL(DiemLan1,0)*0.3 + ISNULL(DiemLan2,0)*0.7) >= 8.0 THEN N'Giỏi'
                            WHEN AVG(ISNULL(DiemLan1,0)*0.3 + ISNULL(DiemLan2,0)*0.7) >= 6.5 THEN N'Khá'
                            WHEN AVG(ISNULL(DiemLan1,0)*0.3 + ISNULL(DiemLan2,0)*0.7) >= 5.0 THEN N'Trung bình'
                            ELSE N'Yếu'
                        END as XepLoai
                    FROM KetQua
                    GROUP BY MaSV
                ) as BangXepLoai
                GROUP BY XepLoai";

            return DataProvider.Instance.ExecuteQuery(query);
        }

        // 6. Số lượng SV theo Khoa (Cho biểu đồ cột)
        public DataTable GetSinhVienTheoKhoa()
        {
            string query = @"
                SELECT k.TenKhoa, COUNT(sv.MaSV) as SoLuong
                FROM Khoa k
                LEFT JOIN Lop l ON k.MaKhoa = l.MaKhoa
                LEFT JOIN SinhVien sv ON l.MaLop = sv.MaLop
                GROUP BY k.TenKhoa";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        // 7. Top Sinh viên tiêu biểu (Cho DataGridView)
        public DataTable GetTopSinhVien()
        {
            // Lấy Top 5 sinh viên có điểm trung bình cao nhất
            string query = @"
                SELECT TOP 5 
                    sv.MaSV, 
                    sv.HoTen, 
                    k.TenKhoa,
                    ROUND(AVG(ISNULL(kq.DiemLan1,0)*0.3 + ISNULL(kq.DiemLan2,0)*0.7), 2) as DiemTB
                FROM SinhVien sv
                JOIN Lop l ON sv.MaLop = l.MaLop
                JOIN Khoa k ON l.MaKhoa = k.MaKhoa
                LEFT JOIN KetQua kq ON sv.MaSV = kq.MaSV
                GROUP BY sv.MaSV, sv.HoTen, k.TenKhoa
                ORDER BY DiemTB DESC";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        // 8. Tìm kiếm sinh viên (Cho ô Search)
        public DataTable TimKiemSinhVien(string keyword)
        {
            string query = @"
                SELECT 
                    sv.MaSV, 
                    sv.HoTen, 
                    k.TenKhoa,
                    ISNULL(ROUND(AVG(ISNULL(kq.DiemLan1,0)*0.3 + ISNULL(kq.DiemLan2,0)*0.7), 2), 0) as DiemTB
                FROM SinhVien sv
                JOIN Lop l ON sv.MaLop = l.MaLop
                JOIN Khoa k ON l.MaKhoa = k.MaKhoa
                LEFT JOIN KetQua kq ON sv.MaSV = kq.MaSV
                WHERE sv.HoTen LIKE N'%" + keyword + "%' OR sv.MaSV LIKE '%" + keyword + "%'" +
                "GROUP BY sv.MaSV, sv.HoTen, k.TenKhoa";
            return DataProvider.Instance.ExecuteQuery(query);
        }
    }
}