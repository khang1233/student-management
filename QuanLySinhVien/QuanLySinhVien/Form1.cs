using System;
using System.Windows.Forms;
using QuanLyTrungTam.DAO;
using QuanLyTrungTam.DTO; // Bắt buộc để dùng Account
using QuanLyTrungTam.Utilities; // Bắt buộc để dùng AppSession

namespace QuanLyTrungTam
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Nút Thoát
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát chương trình?",
                "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        // Nút Đăng nhập
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;
            string passWord = txbPassWord.Text;

            // 1. Lấy vai trò từ RadioButton
            string role = "";

            if (rdoAdmin.Checked)
                role = "Admin";
            else if (rdoGiaoVien.Checked)
                role = "GiangVien";
            else if (rdoHocSinh.Checked)
                role = "SinhVien";

            // Kiểm tra chọn vai trò
            if (string.IsNullOrEmpty(role))
            {
                MessageBox.Show("Vui lòng chọn vai trò đăng nhập!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra tài khoản và mật khẩu
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(passWord))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tài khoản và mật khẩu!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 2. GỌI HÀM LOGIN
                if (AccountDAO.Instance.Login(userName, passWord, role))
                {
                    // 3. LẤY ĐỐI TƯỢNG ACCOUNT
                    Account loginAccount = AccountDAO.Instance.GetAccountByUserName(userName);

                    // 4. ✔ FIX QUAN TRỌNG NHẤT
                    AppSession.CurrentUser = loginAccount;

                    // 5. MỞ FORM MAIN (truyền account luôn)
                    fMain f = new fMain(loginAccount);
                    this.Hide();
                    f.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("Đăng nhập thất bại!\nCó thể do:\n" +
                                    "• Sai tên đăng nhập hoặc mật khẩu.\n" +
                                    "• Bạn đã chọn sai vai trò.",
                                    "Lỗi đăng nhập",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message);
            }
        }
        // Trong Form1.cs
        private async void btnGoogleLogin_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Lấy email từ Google (Code GoogleHelper của bạn đã ổn)
                string email = await GoogleHelper.LoginGoogleAsync();

                if (string.IsNullOrEmpty(email))
                {
                    MessageBox.Show("Đăng nhập Google thất bại hoặc bị hủy.");
                    return;
                }

                // 2. Xử lý Logic Database (Login hoặc Register)
                if (AccountDAO.Instance.LoginGoogle(email))
                {
                    // 3. Lấy thông tin account sau khi xử lý xong
                    Account acc = AccountDAO.Instance.GetAccountByUserName(email);

                    // 4. Lưu Session
                    QuanLyTrungTam.Utilities.AppSession.CurrentUser = acc;

                    // 5. Chuyển Form
                    fMain f = new fMain(acc);
                    this.Hide();
                    f.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("Lỗi hệ thống khi tạo tài khoản Google.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        private void groupBoxRole_Enter(object sender, EventArgs e)
        {

        }
    }
}
