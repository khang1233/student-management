using System;
using System.Windows.Forms;
using QuanLySinhVien.DAO; // Để dùng AccountDAO
using QuanLySinhVien.DTO; // [QUAN TRỌNG] Để dùng class Account

namespace QuanLySinhVien
{
    // Lưu ý: Nếu tên Form của bạn là fLogin thì sửa 'Form1' thành 'fLogin'
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // 1. Nút Thoát
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát chương trình?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        // 2. Nút Đăng Nhập (Đã cập nhật Logic Phân Quyền)
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;
            string passWord = txbPassWord.Text;

            // Kiểm tra nhập thiếu
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(passWord))
            {
                MessageBox.Show("Vui lòng nhập tài khoản và mật khẩu!", "Thông báo");
                return;
            }

            try
            {
                // BƯỚC 1: Kiểm tra Đăng nhập bằng AccountDAO (Thay vì viết SQL trực tiếp)
                if (AccountDAO.Instance.Login(userName, passWord))
                {
                    // BƯỚC 2: Nếu đúng, lấy toàn bộ thông tin tài khoản (Quyền, Mã người dùng...)
                    Account loginAccount = AccountDAO.Instance.GetAccountByUserName(userName);

                    // BƯỚC 3: Mở Form Main và GỬI KÈM tài khoản sang đó
                    // (Lúc này fMain sẽ biết bạn là Admin hay Sinh viên để ẩn/hiện nút)
                    fMain f = new fMain(loginAccount);

                    this.Hide(); // Ẩn form đăng nhập
                    f.ShowDialog(); // Hiện form chính
                    this.Show(); // Khi form chính tắt thì hiện lại form đăng nhập
                }
                else
                {
                    MessageBox.Show("Sai tên tài khoản hoặc mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối hệ thống: " + ex.Message);
            }
        }
    }
}