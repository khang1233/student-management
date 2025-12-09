using System;
using System.Windows.Forms;
using QuanLySinhVien.DAO;
using QuanLySinhVien.DTO;
using System.Drawing; // Thêm thư viện này để dùng Color (Màu sắc)

namespace QuanLySinhVien
{
    public partial class FrmDiem : Form
    {
        private string currentMaSV = null; // Lưu mã SV đang chọn

        public FrmDiem()
        {
            InitializeComponent();
            LoadDSSinhVien();
        }

        // 1. Tải danh sách sinh viên lên cột bên trái
        void LoadDSSinhVien()
        {
            dgvSinhVien.DataSource = SinhVienDAO.Instance.GetListSinhVien();

            // Đặt tên tiêu đề cột
            dgvSinhVien.Columns["MaSV"].HeaderText = "Mã SV";
            dgvSinhVien.Columns["HoTen"].HeaderText = "Họ Tên";

            // Ẩn các cột không cần thiết cho gọn giao diện
            dgvSinhVien.Columns["NgaySinh"].Visible = false;
            dgvSinhVien.Columns["GioiTinh"].Visible = false;
            dgvSinhVien.Columns["DiaChi"].Visible = false;
            dgvSinhVien.Columns["SoDienThoai"].Visible = false;
            dgvSinhVien.Columns["Email"].Visible = false;
            dgvSinhVien.Columns["MaLop"].Visible = false;
        }

        // 2. Sự kiện khi click vào tên sinh viên
        private void dgvSinhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy đối tượng SinhVien từ dòng được chọn
                SinhVien sv = (SinhVien)dgvSinhVien.Rows[e.RowIndex].DataBoundItem;

                currentMaSV = sv.MaSV;
                lblTenSV.Text = "Bảng điểm của: " + sv.HoTen;

                // Tải bảng điểm và tính toán thống kê ngay lập tức
                LoadBangDiem(currentMaSV);
            }
        }

        // 3. Tải bảng điểm của sinh viên được chọn
        void LoadBangDiem(string maSV)
        {
            dgvBangDiem.DataSource = KetQuaDAO.Instance.GetListKetQuaByMaSV(maSV);

            // Cấu hình hiển thị bảng điểm
            dgvBangDiem.Columns["TenMon"].HeaderText = "Môn Học";
            dgvBangDiem.Columns["TenMon"].ReadOnly = true; // Không cho sửa tên môn

            dgvBangDiem.Columns["MaMon"].Visible = false; // Ẩn mã môn đi

            dgvBangDiem.Columns["DiemQT"].HeaderText = "Điểm QT (30%)";
            dgvBangDiem.Columns["DiemThi"].HeaderText = "Điểm Thi (70%)";

            dgvBangDiem.Columns["DiemTongKet"].HeaderText = "Tổng Kết";
            dgvBangDiem.Columns["DiemTongket"].ReadOnly = true; // Tổng kết tự tính, cấm sửa

            // --- QUAN TRỌNG: Gọi hàm tính thống kê ngay khi dữ liệu đổ về ---
            TinhVaHienThiThongKe();
        }

        // 4. Sự kiện bấm nút Lưu
        // 4. Sự kiện bấm nút Lưu
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (currentMaSV == null)
            {
                MessageBox.Show("Chưa chọn sinh viên nào!");
                return;
            }

            try
            {
                // Duyệt qua từng dòng trong bảng điểm để lưu
                foreach (DataGridViewRow row in dgvBangDiem.Rows)
                {
                    // Chỉ xử lý những dòng có Mã Môn (tránh dòng trống cuối cùng của GridView)
                    if (row.Cells["MaMon"].Value != null)
                    {
                        string maMon = row.Cells["MaMon"].Value.ToString();

                        // Parse an toàn (nếu ô rỗng thì coi như là 0 hoặc xử lý tùy ý)
                        double dQT = 0;
                        double dThi = 0;

                        if (row.Cells["DiemQT"].Value != null)
                            double.TryParse(row.Cells["DiemQT"].Value.ToString(), out dQT);

                        if (row.Cells["DiemThi"].Value != null)
                            double.TryParse(row.Cells["DiemThi"].Value.ToString(), out dThi);

                        // Gọi DAO lưu xuống SQL
                        KetQuaDAO.Instance.SaveDiem(currentMaSV, maMon, dQT, dThi);
                    }
                }

                // [THAY ĐỔI QUAN TRỌNG] 
                // Sau khi lưu xong, đóng Form và trả về OK để Dashboard biết đường cập nhật
                MessageBox.Show("Lưu bảng điểm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi nhập liệu: " + ex.Message + "\n(Điểm phải là số!)");
            }
        }

        // 5. Hàm tính toán GPA và Xếp loại (Logic cốt lõi)
        private void TinhVaHienThiThongKe()
        {
            double tongDiem = 0;
            int soMonCoDiem = 0;

            // Duyệt qua từng dòng trong GridView
            foreach (DataGridViewRow row in dgvBangDiem.Rows)
            {
                // Kiểm tra dòng dữ liệu hợp lệ
                if (row.Cells["DiemTongKet"].Value != null &&
                    double.TryParse(row.Cells["DiemTongKet"].Value.ToString(), out double diemTK))
                {
                    // Chỉ tính những môn đã có điểm (Khác 0) để tính trung bình chính xác
                    // (Hoặc tùy quy định: chưa có điểm tính là 0 hay không tính)
                    if (diemTK > 0)
                    {
                        tongDiem += diemTK;
                        soMonCoDiem++;
                    }
                }
            }

            // Tránh lỗi chia cho 0
            if (soMonCoDiem > 0)
            {
                double diemTrungBinh = tongDiem / soMonCoDiem;
                diemTrungBinh = Math.Round(diemTrungBinh, 2); // Làm tròn 2 số lẻ

                // Hiển thị điểm TB
                lblDiemTB.Text = "Điểm TK: " + diemTrungBinh.ToString();

                // Logic Xếp loại
                string xepLoai = "";
                Color mauSac = Color.Black;

                if (diemTrungBinh >= 9.0)
                {
                    xepLoai = "Xuất Sắc";
                    mauSac = Color.Green;
                }
                else if (diemTrungBinh >= 8.0)
                {
                    xepLoai = "Giỏi";
                    mauSac = Color.ForestGreen;
                }
                else if (diemTrungBinh >= 6.5)
                {
                    xepLoai = "Khá";
                    mauSac = Color.Blue;
                }
                else if (diemTrungBinh >= 5.0)
                {
                    xepLoai = "Trung Bình";
                    mauSac = Color.Orange;
                }
                else
                {
                    xepLoai = "Yếu";
                    mauSac = Color.Red;
                }

                lblXepLoai.Text = "Xếp loại: " + xepLoai;
                lblXepLoai.ForeColor = mauSac;
            }
            else
            {
                // Trường hợp SV chưa có điểm môn nào
                lblDiemTB.Text = "Điểm TK: ...";
                lblXepLoai.Text = "Xếp loại: Chưa có điểm";
                lblXepLoai.ForeColor = Color.Gray;
            }
        }
    }
}