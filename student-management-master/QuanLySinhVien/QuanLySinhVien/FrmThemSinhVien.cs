using System;
using System.Windows.Forms;
using QuanLySinhVien.DAO;
using QuanLySinhVien.DTO; // Quan trọng: Cần thêm dòng này để hiểu kiểu dữ liệu SinhVien

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
            txbMaLop.Text = "62TH1"; // Gợi ý sẵn mã lớp
        }

        // 2. Constructor có tham số (Dùng cho SỬA)
        // Khi gọi cái này, form sẽ tự điền dữ liệu cũ lên
        public FrmThemSinhVien(SinhVien sv)
        {
            InitializeComponent();
            this.Text = "Cập nhật sinh viên"; // Đổi tên cửa sổ
            this.labelTitle.Text = "CẬP NHẬT THÔNG TIN"; // Đổi tiêu đề to

            // Lưu lại Mã SV đang sửa để lát nữa dùng trong câu lệnh Update
            this.maSVSua = sv.MaSV;

            // Đổ dữ liệu cũ lên các ô
            txbMaSV.Text = sv.MaSV;
            txbMaSV.Enabled = false; // KHÓA ô Mã SV lại (Không được sửa khóa chính)

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
            this.Close(); // Đóng form
        }

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

            // 2. Kiểm tra dữ liệu (Validation) cơ bản
            if (string.IsNullOrEmpty(maSV) || string.IsNullOrEmpty(hoTen))
            {
                MessageBox.Show("Vui lòng nhập Mã SV và Họ Tên!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. Xử lý Lưu xuống Database
            try
            {
                bool ketQua = false;

                // TRƯỜNG HỢP 1: THÊM MỚI (biến maSVSua là null)
                if (maSVSua == null)
                {
                    // Kiểm tra trùng mã (Chỉ kiểm tra khi thêm mới)
                    if (SinhVienDAO.Instance.CheckExistMaSV(maSV))
                    {
                        MessageBox.Show("Mã Sinh Viên này đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Gọi hàm Insert
                    ketQua = SinhVienDAO.Instance.InsertSinhVien(maSV, hoTen, ngaySinh, gioiTinh, diaChi, sdt, email, maLop);
                }
                // TRƯỜNG HỢP 2: CẬP NHẬT (biến maSVSua có giá trị)
                else
                {
                    // Gọi hàm Update
                    ketQua = SinhVienDAO.Instance.UpdateSinhVien(maSV, hoTen, ngaySinh, gioiTinh, diaChi, sdt, email, maLop);
                }

                // Kiểm tra kết quả chung
                if (ketQua)
                {
                    MessageBox.Show("Thực hiện thành công!", "Thông báo");
                    this.DialogResult = DialogResult.OK; // Báo OK để form danh sách biết mà tải lại
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Thất bại! Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi SQL: " + ex.Message + "\n(Hãy kiểm tra xem Mã Lớp đã đúng chưa?)", "Lỗi Hệ Thống");
            }
        }
    }
}