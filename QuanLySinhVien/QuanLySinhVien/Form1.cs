using System;
using System.Windows.Forms;
using QuanLySinhVien.DAO; // Để dùng AccountDAO
using QuanLySinhVien.DTO; // [QUAN TRỌNG] Để dùng class Account

namespace QuanLySinhVien
{
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

        // 2. Nút Đăng Nhập
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;
            string passWord = txbPassWord.Text;

            // --- BƯỚC 1: LẤY VAI TRÒ TỪ RADIO BUTTON ---
            string role = "";

            // LƯU Ý QUAN TRỌNG: Giá trị gán cho biến 'role' phải GIỐNG HỆT trong Database
            if (rdoAdmin.Checked)
            {
                role = "Admin";
            }
            else if (rdoGiaoVien.Checked)
            {
                // SỬA: Thay "gv" thành "GiangVien" (Theo hình Database bạn gửi)
                role = "GiangVien";
            }
            else if (rdoHocSinh.Checked)
            {
                // SỬA: Thay "SV" thành "SinhVien" (Theo hình Database bạn gửi)
                role = "SinhVien";
            }

            // Kiểm tra nếu người dùng quên chọn vai trò
            if (string.IsNullOrEmpty(role))
            {
                MessageBox.Show("Vui lòng chọn vai trò đăng nhập (Admin, Giáo viên, hoặc Học sinh)!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra nhập thiếu tài khoản/mật khẩu
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(passWord))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tài khoản và mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // --- BƯỚC 2: GỌI HÀM LOGIN ---
                // Hàm này sẽ kiểm tra: User + Pass + Role có khớp trong SQL không
                if (AccountDAO.Instance.Login(userName, passWord, role))
                {
                    // --- BƯỚC 3: LẤY THÔNG TIN TÀI KHOẢN ---
                    Account loginAccount = AccountDAO.Instance.GetAccountByUserName(userName);

                    // --- BƯỚC 4: MỞ FORM MAIN ---
                    // Truyền tài khoản sang fMain để phân quyền
                    fMain f = new fMain(loginAccount);

                    this.Hide();
                    f.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("Đăng nhập thất bại!\nCó thể do:\n1. Sai tên đăng nhập/mật khẩu.\n2. Bạn chọn sai VAI TRÒ (Ví dụ: Tài khoản SV nhưng lại chọn Giáo viên).", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
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