using System;
using System.Windows.Forms;
using QuanLySinhVien.DAO;
using QuanLySinhVien.DTO;

namespace QuanLySinhVien
{
    public partial class fChangePassword : Form
    {
        private Account loginAccount; // Tài khoản đang đăng nhập

        // Constructor nhận Account
        public fChangePassword(Account acc)
        {
            InitializeComponent();
            this.loginAccount = acc;
            LoadInfo();
        }

        void LoadInfo()
        {
            // Hiển thị tên đăng nhập lên và khóa lại
            txbUser.Text = loginAccount.TenDangNhap;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string passOld = txbPassOld.Text;
            string passNew = txbPassNew.Text;
            string reEnter = txbReEnter.Text;

            // 1. Kiểm tra mật khẩu cũ có đúng không?
            // (So sánh với mật khẩu đang lưu trong loginAccount hoặc check lại DB)
            if (passOld != loginAccount.MatKhau)
            {
                MessageBox.Show("Mật khẩu cũ không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Kiểm tra mật khẩu mới và nhập lại
            if (!passNew.Equals(reEnter))
            {
                MessageBox.Show("Mật khẩu nhập lại không khớp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. Cập nhật
            if (AccountDAO.Instance.UpdatePassword(loginAccount.TenDangNhap, passNew))
            {
                MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo");

                // Cập nhật lại mật khẩu cho session hiện tại luôn
                loginAccount.MatKhau = passNew;

                // Xóa trắng các ô
                txbPassOld.Text = ""; txbPassNew.Text = ""; txbReEnter.Text = "";
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra, vui lòng thử lại!");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}