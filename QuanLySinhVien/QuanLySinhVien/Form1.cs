using System;
using System.Windows.Forms;
using QuanLySinhVien.DAO; // Đảm bảo dòng này không bị gạch đỏ. Nếu đỏ, hãy xóa ".DAO" đi tạm thời.

namespace QuanLySinhVien
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // --- ĐÂY LÀ 2 HÀM MÀ MÁY TÍNH ĐANG TÌM KIẾM ---

        // 1. Hàm xử lý nút X (Tắt app)
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // 2. Hàm xử lý nút Đăng Nhập
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;
            string passWord = txbPassWord.Text;

            // Nếu bạn chưa tạo xong DAO, bỏ comment dòng dưới để test nhanh:
            // MessageBox.Show("Test đăng nhập: " + userName); return;

            // Code kết nối SQL (Nếu đã tạo DataProvider và AccountDAO)
            try
            {
                // Câu lệnh SQL kiểm tra đăng nhập
                string query = "SELECT * FROM TaiKhoan WHERE TenDangNhap = '" + userName + "' AND MatKhau = '" + passWord + "'";

                // Gọi DataProvider để chạy lệnh
                var result = DataProvider.Instance.ExecuteQuery(query);

                if (result.Rows.Count > 0)
                {
                    if (result.Rows.Count > 0)
                    {
                        // 1. Thông báo nhẹ
                        MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // 2. Mở form chính
                        fMain f = new fMain(); // Tạo bản sao của form chính
                        this.Hide(); // Ẩn form đăng nhập đi
                        f.ShowDialog(); // Hiện form chính lên và đợi

                        // 3. Khi form chính tắt, thì hiện lại form đăng nhập
                        this.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Nếu chưa kết nối được SQL, nó sẽ báo lỗi ở đây
                MessageBox.Show("Lỗi kết nối: " + ex.Message);
            }
        }
    }
}