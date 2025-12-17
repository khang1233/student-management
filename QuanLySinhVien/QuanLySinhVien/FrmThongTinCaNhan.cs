using System;
using System.Drawing;
using System.Windows.Forms;
using QuanLyTrungTam.DAO;
using QuanLyTrungTam.DTO;
using QuanLyTrungTam.Utilities;

namespace QuanLyTrungTam
{
    public partial class FrmThongTinCaNhan : Form
    {
        private Account loginAccount;

        public FrmThongTinCaNhan(Account acc)
        {
            InitializeComponent();
            this.loginAccount = acc;
            SetupUI();
            LoadInfo();
        }

        // Tạo giao diện bằng code để bạn đỡ phải kéo thả
        private void SetupUI()
        {
            this.Text = "Thông tin tài khoản";
            this.Size = new Size(500, 400);
            this.StartPosition = FormStartPosition.CenterScreen;

            Label lblTitle = new Label { Text = "THÔNG TIN CÁ NHÂN", Font = new Font("Arial", 16, FontStyle.Bold), ForeColor = Color.Blue, AutoSize = true, Location = new Point(130, 20) };

            // Các Label hiển thị thông tin
            Label lblUser = new Label { Text = "Tên đăng nhập: " + loginAccount.TenDangNhap, Location = new Point(50, 70), AutoSize = true, Font = new Font("Arial", 10) };
            Label lblRole = new Label { Text = "Vai trò: " + loginAccount.Quyen, Location = new Point(50, 100), AutoSize = true, Font = new Font("Arial", 10) };

            // Panel chứa thông tin chi tiết (Họ tên, ngày sinh...)
            GroupBox grpInfo = new GroupBox { Text = "Chi tiết", Location = new Point(40, 130), Size = new Size(400, 150) };
            Label lblName = new Label { Name = "lblName", Text = "Họ tên: ...", Location = new Point(20, 30), AutoSize = true };
            Label lblExtra = new Label { Name = "lblExtra", Text = "Thông tin khác: ...", Location = new Point(20, 60), AutoSize = true };
            grpInfo.Controls.Add(lblName);
            grpInfo.Controls.Add(lblExtra);

            // Các nút chức năng
            Button btnChangePass = new Button { Text = "Đổi mật khẩu", Location = new Point(50, 300), Size = new Size(120, 40), BackColor = Color.Orange, ForeColor = Color.White };
            Button btnLogout = new Button { Text = "Đăng xuất", Location = new Point(180, 300), Size = new Size(120, 40), BackColor = Color.Red, ForeColor = Color.White };
            Button btnClose = new Button { Text = "Đóng", Location = new Point(310, 300), Size = new Size(100, 40) };

            // Gán sự kiện
            btnChangePass.Click += BtnChangePass_Click;
            btnLogout.Click += BtnLogout_Click;
            btnClose.Click += (s, e) => { this.Close(); };

            this.Controls.Add(lblTitle);
            this.Controls.Add(lblUser);
            this.Controls.Add(lblRole);
            this.Controls.Add(grpInfo);
            this.Controls.Add(btnChangePass);
            this.Controls.Add(btnLogout);
            this.Controls.Add(btnClose);
        }

        void LoadInfo()
        {
            // Tìm các Label trong GroupBox để gán dữ liệu
            // Lưu ý: Chỉ số Controls[3] có thể khác tùy giao diện, nên dùng try-catch hoặc Find
            try
            {
                Label lblName = this.Controls.Find("lblName", true)[0] as Label;
                Label lblExtra = this.Controls.Find("lblExtra", true)[0] as Label;

                // CODE CŨ (Bị lỗi do SinhVienDAO không còn) -> COMMENT LẠI
                /*
                if (loginAccount.Quyen.ToLower() == "sinhvien") {
                    var listSV = SinhVienDAO.Instance.SearchSinhVienByID(loginAccount.MaNguoiDung);
                    if (listSV.Count > 0) { ... }
                }
                */

                // CODE MỚI (Đơn giản hóa để chạy được)
                lblName.Text = "Xin chào: " + loginAccount.TenDangNhap;
                lblExtra.Text = "Vai trò: " + loginAccount.Quyen;
            }
            catch { }
        }

        private void BtnChangePass_Click(object sender, EventArgs e)
        {
            fChangePassword f = new fChangePassword(loginAccount);
            f.ShowDialog();
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Abort; // Trả về Abort để fMain biết là user muốn đăng xuất
                this.Close();
            }
        }
    }
}