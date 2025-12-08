using QuanLySinhVien.DTO;
using System.Data;

namespace QuanLySinhVien.DAO
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

        // 1. Kiểm tra đăng nhập (True/False)
        public bool Login(string userName, string passWord)
        {
            // Vẫn giữ nguyên, không cần sửa
            string query = "SELECT * FROM TaiKhoan WHERE TenDangNhap = '" + userName + "' AND MatKhau = '" + passWord + "'";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return result.Rows.Count > 0;
        }

        // 2. Lấy thông tin Account (ĐÃ SỬA để tránh lỗi MaGV/MaSV)
        public Account GetAccountByUserName(string userName)
        {
            // [SỬA ĐỔI QUAN TRỌNG]: Dùng AS để đổi tên cột MaNguoiDung thành MaGV và MaSV.
            // Điều này đảm bảo DTO Account có thể đọc được mã người dùng (GV/SV) dù nó gọi bằng tên nào.
            string query = "SELECT *, MaNguoiDung AS MaGV, MaNguoiDung AS MaSV FROM TaiKhoan WHERE TenDangNhap = '" + userName + "'";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                return new Account(item);
            }
            return null;
        }

        // Thêm hàm này vào trong class AccountDAO
        public bool UpdatePassword(string userName, string passMoi)
        {
            // Câu lệnh Update mật khẩu
            string query = "UPDATE TaiKhoan SET MatKhau = '" + passMoi + "' WHERE TenDangNhap = '" + userName + "'";
            return DataProvider.Instance.ExecuteNonQuery(query) > 0;
        }
    }
}