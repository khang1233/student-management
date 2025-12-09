using System;
using System.Data;
using System.Windows.Forms;
using QuanLySinhVien.DAO;
using QuanLySinhVien.DTO;

namespace QuanLySinhVien
{
    public partial class FrmHocPhi : Form
    {
        // 1. Biến lưu mã SV đang chọn
        private string currentMaSV = null;

        // 2. Biến lưu tài khoản đăng nhập (Được truyền từ fMain)
        private Account loginAccount;

        // 3. Constructor nhận Account
        public FrmHocPhi(Account acc)
        {
            InitializeComponent();
            this.loginAccount = acc;
        }

        // 4. Sự kiện khi Form bắt đầu chạy
        private void FrmHocPhi_Load(object sender, EventArgs e)
        {
            // In ra mã người dùng để kiểm tra
           // MessageBox.Show("Quyền: " + loginAccount.Quyen + "\nID: " + loginAccount.MaNguoiDung);

            LoadGiaoDienTheoQuyen();
        }

        // --- HÀM XỬ LÝ LOGIC PHÂN QUYỀN ---
        void LoadGiaoDienTheoQuyen()
        {
            string quyen = loginAccount.Quyen.Trim().ToLower();

            // TRƯỜNG HỢP: SINH VIÊN
            if (quyen == "sinhvien" || quyen == "sv")
            {
                // Tự động lấy mã SV từ tài khoản đăng nhập
                currentMaSV = loginAccount.MaNguoiDung;

                // Ẩn danh sách chọn sinh viên (vì chỉ xem được chính mình)
                if (dgvSinhVien != null) dgvSinhVien.Visible = false;

                // Ẩn các chức năng đóng tiền (nếu chỉ cho phép xem)
                if (btnXacNhanDong != null) btnXacNhanDong.Visible = true;
                if (txbSoTienDong != null) txbSoTienDong.Visible = true;

                lblTenSV.Text = "HỌC PHÍ CỦA BẠN";

                // Load luôn học phí lên giao diện
                LoadHocPhi(currentMaSV);
            }
            // TRƯỜNG HỢP: ADMIN / GIÁO VỤ
            else
            {
                // Hiện danh sách để chọn
                if (dgvSinhVien != null) dgvSinhVien.Visible = true;
                if (btnXacNhanDong != null) btnXacNhanDong.Visible = true;
                if (txbSoTienDong != null) txbSoTienDong.Visible = true;

                lblTenSV.Text = "Vui lòng chọn sinh viên...";

                // Load danh sách tất cả sinh viên
                LoadDSSinhVien();
            }
        }

        void LoadDSSinhVien()
        {
            string quyen = loginAccount.Quyen.Trim().ToLower();

            // Setup tên cột hiển thị (làm trước để tránh lỗi)
            if (dgvSinhVien.Columns["MaSV"] != null) dgvSinhVien.Columns["MaSV"].HeaderText = "Mã SV";
            if (dgvSinhVien.Columns["HoTen"] != null) dgvSinhVien.Columns["HoTen"].HeaderText = "Họ Tên";

            // Ẩn các cột thừa
            string[] cotAn = { "NgaySinh", "GioiTinh", "DiaChi", "SoDienThoai", "Email", "MaLop", "HinhAnh", "TrangThai" };
            foreach (string cot in cotAn)
            {
                if (dgvSinhVien.Columns[cot] != null) dgvSinhVien.Columns[cot].Visible = false;
            }

            // --- PHÂN QUYỀN HIỂN THỊ DANH SÁCH ---
            if (quyen == "sinhvien" || quyen == "sv")
            {
                // [THAY ĐỔI Ở ĐÂY]
                // 1. Vẫn cho hiện danh sách
                dgvSinhVien.Visible = true;

                // 2. Chỉ tải đúng thông tin của sinh viên đang đăng nhập vào danh sách
                // Hàm SearchSinhVienByID trả về List chứa 1 người -> Rất tiện để dùng luôn
                dgvSinhVien.DataSource = SinhVienDAO.Instance.SearchSinhVienByID(loginAccount.MaNguoiDung);

                // 3. (Tùy chọn) Mặc định chọn luôn dòng đầu tiên cho đẹp
                if (dgvSinhVien.Rows.Count > 0)
                {
                    dgvSinhVien.Rows[0].Selected = true;
                }
            }
            else
            {
                // Admin/Giáo vụ: Hiện tất cả
                dgvSinhVien.Visible = true;
                dgvSinhVien.DataSource = SinhVienDAO.Instance.GetListSinhVien();
            }
        }

        // --- HÀM 1: SỰ KIỆN CLICK VÀO DANH SÁCH SINH VIÊN (BỊ THIẾU TRƯỚC ĐÓ) ---
        private void dgvSinhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Chỉ chạy nếu là Admin (vì Sinh viên đã ẩn bảng này rồi)
            if (e.RowIndex >= 0)
            {
                try
                {
                    // Lấy đối tượng SinhVien từ dòng được chọn
                    // Lưu ý: Đôi khi DataBoundItem có thể null nếu click vào dòng trống
                    if (dgvSinhVien.Rows[e.RowIndex].Cells["MaSV"].Value != null)
                    {
                        currentMaSV = dgvSinhVien.Rows[e.RowIndex].Cells["MaSV"].Value.ToString();
                        string tenSV = dgvSinhVien.Rows[e.RowIndex].Cells["HoTen"].Value.ToString();

                        lblTenSV.Text = "Học phí của: " + tenSV;
                        LoadHocPhi(currentMaSV);
                    }
                }
                catch
                {
                    // Bỏ qua lỗi nếu click nhầm 
                }
            }
        }

        // --- HÀM 2: LOAD THÔNG TIN HỌC PHÍ LÊN LABEL ---
        void LoadHocPhi(string maSV)
        {
            if (string.IsNullOrEmpty(maSV)) return;

            DataTable data = HocPhiDAO.Instance.GetHocPhi(maSV);
            if (data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];

                decimal TongTien = row["TongTien"] != DBNull.Value ? Convert.ToDecimal(row["TongTien"]) : 0;
                decimal daDong = row["DaDong"] != DBNull.Value ? Convert.ToDecimal(row["DaDong"]) : 0;
                decimal conNo = row["ConNo"] != DBNull.Value ? Convert.ToDecimal(row["ConNo"]) : 0;

                lblTongHP.Text = "Tổng Học Phí: " + TongTien.ToString("N0") + " VNĐ";
                lblDaDong.Text = "Đã Đóng: " + daDong.ToString("N0") + " VNĐ";
                lblConNo.Text = "Còn Nợ: " + conNo.ToString("N0") + " VNĐ";

                if (txbSoTienDong != null) txbSoTienDong.Text = "";
            }
            else
            {
                // Nếu chưa có dữ liệu học phí
                lblTongHP.Text = "Tổng Học Phí: 0 VNĐ";
                lblDaDong.Text = "Đã Đóng: 0 VNĐ";
                lblConNo.Text = "Còn Nợ: 0 VNĐ";
            }
        }

        // --- HÀM 3: SỰ KIỆN NÚT ĐÓNG TIỀN (BỊ THIẾU TRƯỚC ĐÓ) ---
        private void btnXacNhanDong_Click(object sender, EventArgs e)
        {
            if (currentMaSV == null)
            {
                MessageBox.Show("Vui lòng chọn sinh viên trước!");
                return;
            }

            if (double.TryParse(txbSoTienDong.Text, out double soTien))
            {
                if (HocPhiDAO.Instance.DongHocPhi(currentMaSV, soTien))
                {
                    MessageBox.Show("Đóng học phí thành công!");
                    LoadHocPhi(currentMaSV); // Load lại để cập nhật số dư
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra khi cập nhật CSDL!");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập số tiền hợp lệ!");
            }
        }
    }
}