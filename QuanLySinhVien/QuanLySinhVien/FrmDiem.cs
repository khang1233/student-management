using System;
using System.Windows.Forms;
using QuanLySinhVien.DAO;
using QuanLySinhVien.DTO; // Bắt buộc có để dùng Account
using System.Drawing;       // Bắt buộc có để dùng Color

namespace QuanLySinhVien
{
    public partial class FrmDiem : Form
    {
        private string currentMaSV = null; // Lưu mã SV đang chọn bên trái

        // 1. Biến lưu tài khoản được truyền từ fMain sang
        private Account loginAccount;

        // 2. CONSTRUCTOR QUAN TRỌNG (Phải khớp với fMain)
        public FrmDiem(Account acc)
        {
            InitializeComponent();
            this.loginAccount = acc; // Nhận tài khoản và lưu lại
        }

        // 3. Sự kiện Load Form (Chạy ngay khi mở form)
        private void FrmDiem_Load(object sender, EventArgs e)
        {
            PhanQuyen();      // Ẩn nút nếu là sinh viên
            LoadDSSinhVien(); // Tải danh sách SV phù hợp
        }

        // --- LOGIC PHÂN QUYỀN ---
        void PhanQuyen()
        {
            string quyen = loginAccount.Quyen.Trim().ToLower();

            // Nếu là SINH VIÊN -> Chỉ được xem, không được sửa
            if (quyen == "sinhvien" || quyen == "sv")
            {
                btnSave.Visible = false;     // Ẩn nút Lưu
                dgvBangDiem.ReadOnly = true; // Chặn sửa trên lưới

                // Ẩn thêm các nút Thêm/Xóa nếu có
                if (Controls.ContainsKey("btnThem")) Controls["btnThem"].Visible = false;
                if (Controls.ContainsKey("btnXoa")) Controls["btnXoa"].Visible = false;
            }
            // Nếu là GIÁO VIÊN -> Được phép sửa
            else
            {
                btnSave.Visible = true;
                dgvBangDiem.ReadOnly = false;
            }
        }

        // --- LOGIC TẢI DANH SÁCH SINH VIÊN ---
        void LoadDSSinhVien()
        {
            string quyen = loginAccount.Quyen.Trim().ToLower();

            // --- PHÂN QUYỀN ---
            if (quyen == "sinhvien" || quyen == "sv")
            {
                // [THAY ĐỔI Ở ĐÂY]
                dgvSinhVien.Visible = true; // Hiện danh sách

                // Chỉ load 1 dòng là chính sinh viên đó
                dgvSinhVien.DataSource = SinhVienDAO.Instance.SearchSinhVienByID(loginAccount.MaNguoiDung);

                // Load luôn bảng điểm của sinh viên này
                if (!string.IsNullOrEmpty(loginAccount.MaNguoiDung))
                {
                    LoadBangDiem(loginAccount.MaNguoiDung);
                    lblTenSV.Text = "Bảng điểm cá nhân";
                }
            }
            else
            {
                // Admin: Load tất cả
                dgvSinhVien.Visible = true;
                dgvSinhVien.DataSource = SinhVienDAO.Instance.GetListSinhVien();
                lblTenSV.Text = "Vui lòng chọn sinh viên...";
            }

            // Gọi hàm setup cột (đảm bảo hàm này nằm cuối để không bị lỗi null)
            SetupDataGridView();
        }

        void SetupDataGridView()
        {
            if (dgvSinhVien.Columns["MaSV"] != null)
            {
                dgvSinhVien.Columns["MaSV"].HeaderText = "Mã SV";
                dgvSinhVien.Columns["HoTen"].HeaderText = "Họ Tên";

                // Ẩn các cột không cần thiết
                string[] cotAn = { "NgaySinh", "GioiTinh", "DiaChi", "SoDienThoai", "Email", "MaLop", "HinhAnh", "TrangThai" };
                foreach (string cot in cotAn)
                {
                    if (dgvSinhVien.Columns[cot] != null)
                        dgvSinhVien.Columns[cot].Visible = false;
                }
            }
        }

        // --- CÁC SỰ KIỆN CŨ (GIỮ NGUYÊN) ---

        // Khi click vào sinh viên bên trái
        // Sự kiện khi click vào danh sách sinh viên bên trái
        private void dgvSinhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra dòng hợp lệ (không click vào tiêu đề)
            if (e.RowIndex >= 0)
            {
                try
                {
                    // CÁCH SỬA: Lấy trực tiếp giá trị từ ô "MaSV"
                    // Đảm bảo cột MaSV trong DataGridView của bạn có Name là "MaSV"
                    DataGridViewRow row = dgvSinhVien.Rows[e.RowIndex];

                    // Kiểm tra null để tránh lỗi
                    if (row.Cells["MaSV"].Value != null)
                    {
                        currentMaSV = row.Cells["MaSV"].Value.ToString();
                        string tenSV = row.Cells["HoTen"].Value.ToString();

                        // Cập nhật giao diện
                        lblTenSV.Text = "Bảng điểm của: " + tenSV;

                        // Tải bảng điểm ngay lập tức
                        LoadBangDiem(currentMaSV);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi chọn sinh viên: " + ex.Message);
                }
            }
        }

        // Tải bảng điểm
        void LoadBangDiem(string maSV)
        {
            dgvBangDiem.DataSource = KetQuaDAO.Instance.GetListKetQuaByMaSV(maSV);

            // Cấu hình hiển thị
            if (dgvBangDiem.Columns["TenMon"] != null)
            {
                dgvBangDiem.Columns["TenMon"].HeaderText = "Môn Học";
                dgvBangDiem.Columns["TenMon"].ReadOnly = true;
                dgvBangDiem.Columns["MaMon"].Visible = false;
                dgvBangDiem.Columns["DiemQT"].HeaderText = "Điểm QT (30%)";
                dgvBangDiem.Columns["DiemThi"].HeaderText = "Điểm Thi (70%)";
                dgvBangDiem.Columns["DiemTongKet"].HeaderText = "Tổng Kết";
                dgvBangDiem.Columns["DiemTongKet"].ReadOnly = true;
            }
            TinhVaHienThiThongKe();
        }

        // Lưu điểm
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (currentMaSV == null) { MessageBox.Show("Chưa chọn sinh viên!"); return; }

            try
            {
                foreach (DataGridViewRow row in dgvBangDiem.Rows)
                {
                    if (row.Cells["MaMon"].Value != null)
                    {
                        string maMon = row.Cells["MaMon"].Value.ToString();
                        double dQT = 0, dThi = 0;

                        if (row.Cells["DiemQT"].Value != null) double.TryParse(row.Cells["DiemQT"].Value.ToString(), out dQT);
                        if (row.Cells["DiemThi"].Value != null) double.TryParse(row.Cells["DiemThi"].Value.ToString(), out dThi);

                        KetQuaDAO.Instance.SaveDiem(currentMaSV, maMon, dQT, dThi);
                    }
                }
                MessageBox.Show("Lưu thành công!");
                LoadBangDiem(currentMaSV);
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        // Tính điểm trung bình
        private void TinhVaHienThiThongKe()
        {
            double tongDiem = 0;
            int soMon = 0;

            foreach (DataGridViewRow row in dgvBangDiem.Rows)
            {
                if (row.Cells["DiemTongKet"].Value != null &&
                    double.TryParse(row.Cells["DiemTongKet"].Value.ToString(), out double dtb))
                {
                    if (dtb > 0) { tongDiem += dtb; soMon++; }
                }
            }

            if (soMon > 0)
            {
                double final = Math.Round(tongDiem / soMon, 2);
                lblDiemTB.Text = "Điểm TK: " + final;

                string xl = ""; Color c = Color.Black;
                if (final >= 9) { xl = "Xuất Sắc"; c = Color.Green; }
                else if (final >= 8) { xl = "Giỏi"; c = Color.ForestGreen; }
                else if (final >= 6.5) { xl = "Khá"; c = Color.Blue; }
                else if (final >= 5) { xl = "Trung Bình"; c = Color.Orange; }
                else { xl = "Yếu"; c = Color.Red; }

                lblXepLoai.Text = "Xếp loại: " + xl;
                lblXepLoai.ForeColor = c;
            }
            else
            {
                lblDiemTB.Text = "Điểm TK: ...";
                lblXepLoai.Text = "Chưa có điểm";
            }
        }
    }
}