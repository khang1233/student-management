using System;
using System.Windows.Forms;
using QuanLySinhVien.DAO;

namespace QuanLySinhVien
{
    public partial class FrmLop : Form
    {
        public FrmLop()
        {
            InitializeComponent();
            LoadListLop();
        }

        void LoadListLop()
        {
            dgvLop.DataSource = LopDAO.Instance.GetListLop();
            // Đặt tên tiếng Việt
            dgvLop.Columns["MaLop"].HeaderText = "Mã Lớp";
            dgvLop.Columns["TenLop"].HeaderText = "Tên Lớp";
            dgvLop.Columns["MaKhoa"].HeaderText = "Khoa";
        }

        private void dgvLop_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvLop.Rows[e.RowIndex];
                txbMaLop.Text = row.Cells["MaLop"].Value.ToString();
                txbTenLop.Text = row.Cells["TenLop"].Value.ToString();
                txbMaKhoa.Text = row.Cells["MaKhoa"].Value.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra nhập thiếu
            if (txbMaLop.Text == "" || txbTenLop.Text == "" || txbMaKhoa.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. --- ĐOẠN CODE MỚI CẦN THÊM ---
            // Kiểm tra Mã Khoa có đúng không?
            // ---------------------------------

            // 3. Code thêm cũ giữ nguyên (nhớ bọc try-catch để an toàn tuyệt đối)
            try
            {
                if (LopDAO.Instance.InsertLop(txbMaLop.Text, txbTenLop.Text, txbMaKhoa.Text))
                {
                    MessageBox.Show("Thêm lớp thành công!");
                    LoadListLop();
                }
                else MessageBox.Show("Thêm thất bại (Có thể trùng Mã Lớp).");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string maLop = txbMaLop.Text;
            string tenLop = txbTenLop.Text;
            string maKhoa = txbMaKhoa.Text;

            if (LopDAO.Instance.UpdateLop(maLop, tenLop, maKhoa))
            {
                MessageBox.Show("Sửa lớp thành công!");
                LoadListLop();
            }
            else MessageBox.Show("Có lỗi khi sửa!");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maLop = txbMaLop.Text;
            if (MessageBox.Show("Bạn có chắc muốn xóa lớp " + maLop + "?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (LopDAO.Instance.DeleteLop(maLop))
                {
                    MessageBox.Show("Xóa thành công!");
                    LoadListLop();
                }
                else MessageBox.Show("Không thể xóa (Có thể lớp này đang có sinh viên học).");
            }
        }
    }
}