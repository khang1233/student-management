using System;
using System.Windows.Forms;
using QuanLySinhVien.DAO;
using QuanLySinhVien.DTO;

namespace QuanLySinhVien
{
    public partial class FrmThemSinhVien : Form
    {
        // Biến này dùng để đánh dấu: Nếu nó null => Đang THÊM. Nếu có giá trị => Đang SỬA.
        private string maSVSua = null;

        // 1. Constructor mặc định (Dùng cho THÊM MỚI)
        public FrmThemSinhVien()
        {
            InitializeComponent();
            this.Text = "Thêm mới sinh viên";
            // txbMaLop.Text = "62TH1"; // Gợi ý sẵn mã lớp (Tùy chọn)
        }

        // 2. Constructor có tham số (Dùng cho SỬA)
        public FrmThemSinhVien(SinhVien sv)
        {
            InitializeComponent();
            this.Text = "Cập nhật sinh viên";
            this.labelTitle.Text = "CẬP NHẬT THÔNG TIN";

            // Lưu lại Mã SV đang sửa
            this.maSVSua = sv.MaSV;

            // Đổ dữ liệu cũ lên các ô
            txbMaSV.Text = sv.MaSV;
            txbMaSV.Enabled = false; // KHÓA ô Mã SV lại

            txbHoTen.Text = sv.HoTen;
            dtpNgaySinh.Value = sv.NgaySinh;
            cbGioiTinh.Text = sv.GioiTinh;
            txbDiaChi.Text = sv.DiaChi;
            txbSDT.Text = sv.SoDienThoai;
            txbEmail.Text = sv.Email;
            txbMaLop.Text = sv.MaLop;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // --- SỰ KIỆN LƯU (QUAN TRỌNG NHẤT) ---
        private void btnSave_Click(object sender, EventArgs e)
        {
            // 1. Lấy dữ liệu từ ô nhập
            string maSV = txbMaSV.Text.Trim();
            string hoTen = txbHoTen.Text.Trim();
            DateTime ngaySinh = dtpNgaySinh.Value;
            string gioiTinh = cbGioiTinh.Text;
            string diaChi = txbDiaChi.Text;
            string sdt = txbSDT.Text;
            string email = txbEmail.Text;
            string maLop = txbMaLop.Text;

            // 2. Kiểm tra dữ liệu (Validation)
            if (string.IsNullOrEmpty(maSV) || string.IsNullOrEmpty(hoTen))
            {
                MessageBox.Show("Vui lòng nhập Mã SV và Họ Tên!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. Xử lý Lưu xuống Database
            try
            {
                bool ketQua = false;

                // TRƯỜNG HỢP 1: THÊM MỚI (Insert)
                if (maSVSua == null)
                {
                    // Kiểm tra trùng mã
                    if (SinhVienDAO.Instance.CheckExistMaSV(maSV))
                    {
                        MessageBox.Show("Mã Sinh Viên này đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Gọi hàm Insert vào bảng SinhVien
                    ketQua = SinhVienDAO.Instance.InsertSinhVien(maSV, hoTen, ngaySinh, gioiTinh, diaChi, sdt, email, maLop);
                }
                // TRƯỜNG HỢP 2: CẬP NHẬT (Update)
                else
                {
                    // Gọi hàm Update vào bảng SinhVien
                    ketQua = SinhVienDAO.Instance.UpdateSinhVien(maSV, hoTen, ngaySinh, gioiTinh, diaChi, sdt, email, maLop);
                }

                // 4. KIỂM TRA KẾT QUẢ VÀ TỰ ĐỘNG TẠO TÀI KHOẢN
                if (ketQua)
                {
                    // --- [CODE MỚI THÊM VÀO] ---
                    // Chỉ tạo tài khoản khi đang THÊM MỚI (maSVSua == null)
                    if (maSVSua == null)
                    {
                        // Tạo thông tin tài khoản mặc định
                        string user = maSV.ToLower(); // Tên đăng nhập là mã SV viết thường
                        string pass = "1";            // Mật khẩu là 1
                        string role = "SinhVien";     // Quyền là SinhVien

                        // Gọi hàm thêm tài khoản (Hàm này bạn đã thêm vào AccountDAO ở bước trước)
                        bool tkResult = AccountDAO.Instance.InsertAccount(user, pass, role, maSV);

                        if (tkResult)
                        {
                            MessageBox.Show($"Thêm sinh viên thành công!\n\nĐã tự động cấp tài khoản:\nUser: {user}\nPass: {pass}", "Thông báo");
                        }
                        else
                        {
                            MessageBox.Show($"Thêm sinh viên thành công nhưng lỗi cấp tài khoản (Có thể User đã tồn tại).", "Cảnh báo");
                        }
                    }
                    else
                    {
                        // Trường hợp Update thì chỉ thông báo đơn giản
                        MessageBox.Show("Cập nhật thông tin sinh viên thành công!", "Thông báo");
                    }
                    // ---------------------------

                    this.DialogResult = DialogResult.OK; // Báo OK để form cha load lại danh sách
                    this.Close(); // Đóng form nhập liệu
                }
                else
                {
                    MessageBox.Show("Thao tác thất bại! Vui lòng kiểm tra lại dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Hệ Thống (SQL): " + ex.Message + "\n(Hãy kiểm tra lại Mã Lớp xem có tồn tại không?)", "Lỗi Nghiêm Trọng");
            }
        }
    }
}