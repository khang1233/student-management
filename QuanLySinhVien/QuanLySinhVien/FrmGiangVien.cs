using System;
using System.Windows.Forms;
using QuanLySinhVien.DAO;

namespace QuanLySinhVien
{
    public partial class FrmGiangVien : Form
    {
        public FrmGiangVien()
        {
            InitializeComponent();
            LoadListGiangVien();
        }

        void LoadListGiangVien()
        {
            dgvGiangVien.DataSource = GiangVienDAO.Instance.GetListGiangVien();
            // Đặt tên tiêu đề cột
            dgvGiangVien.Columns["MaGV"].HeaderText = "Mã GV";
            dgvGiangVien.Columns["HoTen"].HeaderText = "Họ Tên";
            dgvGiangVien.Columns["SoDienThoai"].HeaderText = "SĐT";
            dgvGiangVien.Columns["Email"].HeaderText = "Email";
            dgvGiangVien.Columns["MaKhoa"].HeaderText = "Mã Khoa";
        }

        // Click vào dòng để hiện thông tin lên TextBox
        private void dgvGiangVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvGiangVien.Rows[e.RowIndex];
                txbMaGV.Text = row.Cells["MaGV"].Value.ToString();
                txbHoTen.Text = row.Cells["HoTen"].Value.ToString();
                txbSDT.Text = row.Cells["SoDienThoai"].Value.ToString();
                txbEmail.Text = row.Cells["Email"].Value.ToString();
                txbMaKhoa.Text = row.Cells["MaKhoa"].Value.ToString();
            }
        }

        // Nút Thêm
        private void btnThem_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra dữ liệu rỗng
            if (txbMaGV.Text == "" || txbHoTen.Text == "" || txbMaKhoa.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. KIỂM TRA MÃ KHOA CÓ TỒN TẠI KHÔNG? (Đây là phần bạn cần)
            if (GiangVienDAO.Instance.CheckKhoaTonTai(txbMaKhoa.Text) == false)
            {
                MessageBox.Show("Mã Khoa '" + txbMaKhoa.Text + "' không tồn tại trong hệ thống!\nVui lòng nhập mã khác (Ví dụ: CNTT, KT...).",
                                "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);

                txbMaKhoa.Focus(); // Đưa con trỏ chuột quay lại ô Mã Khoa để nhập lại
                return; // Dừng lại, không chạy lệnh Insert bên dưới nữa
            }

            // 3. Nếu Mã Khoa đúng rồi thì mới thêm
            try
            {
                if (GiangVienDAO.Instance.InsertGiangVien(txbMaGV.Text, txbHoTen.Text, txbSDT.Text, txbEmail.Text, txbMaKhoa.Text))
                {
                    MessageBox.Show("Thêm giảng viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadListGiangVien();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại! Có thể trùng Mã Giảng Viên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Bắt các lỗi khác nếu có
                MessageBox.Show("Có lỗi hệ thống: " + ex.Message);
            }
        }

        // Nút Sửa
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (GiangVienDAO.Instance.UpdateGiangVien(txbMaGV.Text, txbHoTen.Text, txbSDT.Text, txbEmail.Text, txbMaKhoa.Text))
            {
                MessageBox.Show("Cập nhật thành công!");
                LoadListGiangVien();
            }
            else MessageBox.Show("Có lỗi xảy ra!");
        }

        // Nút Xóa
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xóa GV " + txbHoTen.Text + "?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (GiangVienDAO.Instance.DeleteGiangVien(txbMaGV.Text))
                {
                    MessageBox.Show("Xóa thành công!");
                    LoadListGiangVien();
                }
                else MessageBox.Show("Không thể xóa (Có thể GV này đang dạy lớp học phần).");
            }
        }
    }
}