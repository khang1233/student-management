using QuanLyTrungTam.DTO;
using System;
using System.Data;

namespace QuanLyTrungTam.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;
        public static AccountDAO Instance
        {
            get { if (instance == null) instance = new AccountDAO(); return instance; }
            private set { instance = value; }
        }
        private AccountDAO() { }

        // --- HÀM LOGIN ĐÃ SỬA ---
        // Thêm tham số 'role' vào hàm
        // --- SỬA LẠI TÊN CỘT TRONG CÂU LỆNH SQL ---
        public bool Login(string userName, string passWord, string role)
        {
            // Thay 'LoaiTaiKhoan' thành 'Quyen' (hoặc tên cột thật của bạn)
            string query = "SELECT * FROM TaiKhoan WHERE TenDangNhap = '" + userName + "' AND MatKhau = '" + passWord + "' AND Quyen = N'" + role + "'";

            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return result.Rows.Count > 0;
        }

        // 2. Lấy thông tin Account
        public Account GetAccountByUserName(string userName)
        {
            string query = "SELECT * FROM TaiKhoan WHERE TenDangNhap = '" + userName + "'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                return new Account(item);
            }
            return null;
        }

        // 3. Cập nhật mật khẩu
        public bool UpdatePassword(string userName, string passMoi)
        {
            string query = "UPDATE TaiKhoan SET MatKhau = '" + passMoi + "' WHERE TenDangNhap = '" + userName + "'";
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        // Trong AccountDAO.cs
        public bool InsertAccount(string user, string pass, string quyen, string maNguoiDung)
        {
            string query = "INSERT INTO TaiKhoan (TenDangNhap, MatKhau, Quyen, MaNguoiDung) VALUES ( @user , @pass , @quyen , @maND )";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { user, pass, quyen, maNguoiDung }) > 0;
        }
        // Trong class AccountDAO
        public bool LoginGoogle(string email)
        {
            // 1. Check tồn tại
            string queryCheck = "SELECT * FROM TaiKhoan WHERE TenDangNhap = '" + email + "'";
            DataTable result = DataProvider.Instance.ExecuteQuery(queryCheck);

            if (result.Rows.Count > 0) return true; // Đã có -> Login luôn

            // 2. Chưa có -> Auto Register
            // Tạo mã HV tự động: HV + TikTak thời gian để không trùng
            string maHV = "HV" + DateTime.Now.Ticks.ToString().Substring(12);

            // Insert Học Viên (Lấy email làm tên tạm)
            string queryHV = string.Format("INSERT INTO HocVien (MaHV, HoTen, Email, NgayGiaNhap) VALUES ('{0}', N'{1}', '{2}', GETDATE())",
                                            maHV, email, email);
            DataProvider.Instance.ExecuteNonQuery(queryHV);

            // Insert Tài Khoản (Mật khẩu để NULL hoặc random string)
            string queryTK = string.Format("INSERT INTO TaiKhoan (TenDangNhap, Quyen, MaNguoiDung, IsGoogleAccount) VALUES ('{0}', 'HocVien', '{1}', 1)",
                                            email, maHV);

            return DataProvider.Instance.ExecuteNonQuery(queryTK) > 0;
        }
    }
}