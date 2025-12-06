using QuanLySinhVien.DTO; // Quan trọng: Phải có dòng này để dùng class Account
using System.Data;

namespace QuanLySinhVien.DAO
{
    public class AccountDAO
    {
        // Design pattern Singleton (Chỉ tạo 1 instance duy nhất)
        private static AccountDAO instance;

        public static AccountDAO Instance
        {
            get { if (instance == null) instance = new AccountDAO(); return instance; }
            private set { instance = value; }
        }

        private AccountDAO() { }

        // 1. Hàm kiểm tra đăng nhập (Trả về True nếu đúng tài khoản/mật khẩu)
        public bool Login(string userName, string passWord)
        {
            // Lưu ý: Nên mã hóa mật khẩu khi làm thật. Ở đây làm demo nên để text trần.
            string query = "SELECT * FROM TaiKhoan WHERE TenDangNhap = '" + userName + "' AND MatKhau = '" + passWord + "'";

            DataTable result = DataProvider.Instance.ExecuteQuery(query);

            return result.Rows.Count > 0;
        }

        // 2. Hàm lấy thông tin tài khoản (Để biết Quyền là gì)
        public Account GetAccountByUserName(string userName)
        {
            string query = "SELECT * FROM TaiKhoan WHERE TenDangNhap = '" + userName + "'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                // Chuyển dòng dữ liệu SQL thành đối tượng Account
                return new Account(item);
            }

            return null;
        }
    }
}