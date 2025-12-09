using System;
using System.Windows.Forms;
using QuanLySinhVien.DAO;
using QuanLySinhVien.DTO; // Bắt buộc để dùng Account
using QuanLySinhVien.Utilities; // Bắt buộc để dùng AppSession

namespace QuanLySinhVien
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

        private void groupBoxRole_Enter(object sender, EventArgs e)
        {

        }
    }
}
