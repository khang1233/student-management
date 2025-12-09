using QuanLySinhVien.DTO;

namespace QuanLySinhVien.Utilities // Hoặc dùng namespace QuanLySinhVien.DTO nếu bạn đặt trong DTO
{
    // Lớp tĩnh này sẽ giữ thông tin của người dùng đang đăng nhập
    public static class AppSession
    {
        // Biến tĩnh này lưu trữ đối tượng Account sau khi đăng nhập thành công
        // Các Form khác có thể truy cập AppSession.CurrentUser.Quyen
        public static Account CurrentUser { get; set; }
    }
}