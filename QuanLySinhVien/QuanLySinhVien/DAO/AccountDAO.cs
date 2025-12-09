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
    }
}