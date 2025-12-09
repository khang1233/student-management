    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using QuanLySinhVien.DTO; // [QUAN TRỌNG] Nhớ thêm dòng này để dùng Account

    namespace QuanLySinhVien
    {
        public partial class fMain : Form
        {
            // Fields để quản lý giao diện
            private Button currentButton;
            private Form activeForm;

            // [MỚI] Biến lưu tài khoản đang đăng nhập
            private Account loginAccount;

            // [SỬA] Constructor nhận vào Account
            public fMain(Account acc)
            {
                InitializeComponent();

                this.loginAccount = acc; // Lưu tài khoản lại
                PhanQuyen(); // Gọi hàm phân quyền ngay khi mở form

                // Mở Dashboard mặc định
                OpenChildForm(new FrmDashboard(), null);
            }

        // --- HÀM PHÂN QUYỀN (LOGIC QUAN TRỌNG NHẤT) ---
        void PhanQuyen()
        {
            // 1. Chuẩn hóa chuỗi quyền (xóa khoảng trắng, chuyển thường)
            // Lưu ý: Đảm bảo khớp với dữ liệu trong SQL của bạn ("admin", "giangvien", "sinhvien")
            string quyen = loginAccount.Quyen.Trim().ToLower();

            // Hiển thị lời chào
            lblTitle.Text = "Xin chào: " + loginAccount.TenDangNhap;

            // --- TRƯỜNG HỢP 1: ADMIN ---
            if (quyen == "admin")
            {
                // Admin thấy hết -> Không cần ẩn gì cả
                // Hoặc có thể set Visible = true hết cho chắc chắn
            }

            // --- TRƯỜNG HỢP 2: GIÁO VIÊN ---
            // (Chỉ được vào Điểm, không được vào QL Sinh viên, Môn học...)
            else if (quyen == "giangvien" || quyen == "gv")
            {
                btnSinhVien.Visible = false;  // Ẩn nút Sinh viên
                btnGiangVien.Visible = false; // Ẩn nút Giảng viên
                btnLopHoc.Visible = false;    // Ẩn nút Lớp
                btnMonHoc.Visible = false;    // Ẩn nút Môn học (Yêu cầu của bạn: ko dc thêm môn)
                btnHocPhi.Visible = false;    // Ẩn học phí

                // Hiện các nút cho phép
                btnDiem.Visible = true;       // Cho phép vào sửa điểm
                btnTaiKhoan.Visible = true;   // Cho phép đổi mật khẩu
                btnSystem.Visible = true;
            }

            // --- TRƯỜNG HỢP 3: HỌC SINH ---
            // (Chỉ được xem Điểm và Học phí)
            else if (quyen == "sinhvien" || quyen == "sv")
            {
                // Ẩn hết các chức năng quản lý
                btnSinhVien.Visible = false;
                btnGiangVien.Visible = false;
                btnLopHoc.Visible = false;
                btnMonHoc.Visible = false;

                // Hiện chức năng xem
                btnDiem.Visible = true;
                btnHocPhi.Visible = true;
                btnTaiKhoan.Visible = true;
            }
        }

        // --- CÁC HÀM GIAO DIỆN (GIỮ NGUYÊN) ---

        // Hàm đổi màu nút khi được chọn (Highlight)
        private void ActivateButton(object btnSender)
            {
                if (btnSender != null)
                {
                    if (currentButton != (Button)btnSender)
                    {
                        DisableButton(); // Trả màu nút cũ về bình thường

                        Color color = Color.FromArgb(0, 150, 136); // Màu xanh giống thanh tiêu đề

                        currentButton = (Button)btnSender;
                        currentButton.BackColor = color;
                        currentButton.ForeColor = Color.White;
                        currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                        // Đổi tên tiêu đề
                        lblTitle.Text = currentButton.Text.Trim().ToUpper();
                    }
                }
            }
        // Sự kiện Click của nút Điểm
        private void btnDiem_Click(object sender, EventArgs e)
        {
            // 1. Đổi màu nút (Hiệu ứng giao diện)
            ActivateButton(sender);

            // 2. Mở Form Điểm và truyền tài khoản (loginAccount) sang
            // (Đảm bảo FrmDiem đã sửa constructor nhận Account như bài trước)
            OpenChildForm(new FrmDiem(loginAccount), sender);

            // 3. Đổi tiêu đề
            lblTitle.Text = "QUẢN LÝ ĐIỂM SỐ";
        }

        // Hàm trả màu nút về mặc định
        private void DisableButton()
            {
                foreach (Control previousBtn in panelMenu.Controls)
                {
                    if (previousBtn.GetType() == typeof(Button))
                    {
                        previousBtn.BackColor = Color.FromArgb(51, 51, 76);
                        previousBtn.ForeColor = Color.Gainsboro;
                        previousBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    }
                }
            }

            // --- KỸ THUẬT NHÚNG FORM CON VÀO PANEL ---
            private void OpenChildForm(Form childForm, object btnSender)
            {
                if (activeForm != null)
                    activeForm.Close(); // Đóng form cũ đang mở nếu có

                ActivateButton(btnSender); // Đổi màu menu

                activeForm = childForm;
                childForm.TopLevel = false;
                childForm.FormBorderStyle = FormBorderStyle.None;
                childForm.Dock = DockStyle.Fill;

                this.panelDesktop.Controls.Add(childForm); // Thêm form con vào panelDesktop
                this.panelDesktop.Tag = childForm;
                childForm.BringToFront();
                childForm.Show();
            }

            // --- CÁC SỰ KIỆN CLICK MENU ---

            private void btnSinhVien_Click(object sender, EventArgs e)
            {
                OpenChildForm(new FrmSinhVien(), sender);
                lblTitle.Text = "QUẢN LÝ SINH VIÊN";
            }

            private void btnGiangVien_Click(object sender, EventArgs e)
            {
                ActivateButton(sender);
                OpenChildForm(new FrmGiangVien(), sender);
                lblTitle.Text = "QUẢN LÝ GIẢNG VIÊN";
            }

            private void btnLopHoc_Click(object sender, EventArgs e)
            {
                ActivateButton(sender);
                OpenChildForm(new FrmLop(), sender);
                lblTitle.Text = "QUẢN LÝ LỚP HỌC";
            }

            private void btnMonHoc_Click(object sender, EventArgs e)
            {
                ActivateButton(sender);
                OpenChildForm(new FrmMonHoc(), sender);
                lblTitle.Text = "DANH MỤC MÔN HỌC";
            }



        private void btnHocPhi_Click(object sender, EventArgs e)
        {
            // Cũ: OpenChildForm(new FrmHocPhi(), sender);  <-- Sẽ báo lỗi dòng này

            // MỚI: Truyền loginAccount vào
            OpenChildForm(new FrmHocPhi(loginAccount), sender);

            lblTitle.Text = "QUẢN LÝ HỌC PHÍ";
        }
        private void btnSystem_Click(object sender, EventArgs e)
            {
                if (activeForm != null) activeForm.Close();
                OpenChildForm(new FrmDashboard(), sender);
                lblTitle.Text = "TRANG CHỦ";
            }

            // --- [MỚI] SỰ KIỆN NÚT TÀI KHOẢN (ĐỔI MẬT KHẨU) ---
            // Bạn cần tạo nút tên btnTaiKhoan trong giao diện thiết kế và gán sự kiện click vào hàm này
            private void btnTaiKhoan_Click(object sender, EventArgs e)
            {
                // Mở form đổi mật khẩu dạng Dialog (Cửa sổ nổi lên trên)
                // Truyền loginAccount vào để biết đang đổi mật khẩu cho ai
                fChangePassword f = new fChangePassword(loginAccount);
                f.ShowDialog();
            }
        }
    }