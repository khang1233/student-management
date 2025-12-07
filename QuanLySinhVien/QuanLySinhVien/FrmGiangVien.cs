using System;
using System.Windows.Forms;
using QuanLySinhVien.DAO;

namespace QuanLySinhVien
{
    public partial class FrmGiangVien : Form
    {
        // Sử dụng BindingSource để liên kết dữ liệu
        BindingSource listGiangVien = new BindingSource();

        public FrmGiangVien()
        {
            InitializeComponent();

            // Gán nguồn dữ liệu
            dgvGiangVien.DataSource = listGiangVien;

            LoadListGiangVien();
            AddGiangVienBinding();
        }

        void LoadListGiangVien()
        {
            listGiangVien.DataSource = GiangVienDAO.Instance.GetListGiangVien();

            // Định dạng tiêu đề cột
            if (dgvGiangVien.Columns["MaGV"] != null)
            {
                dgvGiangVien.Columns["MaGV"].HeaderText = "Mã GV";
                dgvGiangVien.Columns["HoTen"].HeaderText = "Họ Tên";
                dgvGiangVien.Columns["GioiTinh"].HeaderText = "Giới Tính";
                dgvGiangVien.Columns["SoDienThoai"].HeaderText = "SĐT";
                dgvGiangVien.Columns["Email"].HeaderText = "Email";
                dgvGiangVien.Columns["DiaChi"].HeaderText = "Địa Chỉ";
            }
        }

        void AddGiangVienBinding()
        {
            // Xóa binding cũ
            txbMaGV.DataBindings.Clear();
            txbHoTen.DataBindings.Clear();
            cbGioiTinh.DataBindings.Clear();
            txbSDT.DataBindings.Clear();
            txbEmail.DataBindings.Clear();
            txbDiaChi.DataBindings.Clear();

            // Liên kết dữ liệu
            txbMaGV.DataBindings.Add("Text", dgvGiangVien.DataSource, "MaGV", true, DataSourceUpdateMode.Never);
            txbHoTen.DataBindings.Add("Text", dgvGiangVien.DataSource, "HoTen", true, DataSourceUpdateMode.Never);
            cbGioiTinh.DataBindings.Add("Text", dgvGiangVien.DataSource, "GioiTinh", true, DataSourceUpdateMode.Never);
            txbSDT.DataBindings.Add("Text", dgvGiangVien.DataSource, "SoDienThoai", true, DataSourceUpdateMode.Never);
            txbEmail.DataBindings.Add("Text", dgvGiangVien.DataSource, "Email", true, DataSourceUpdateMode.Never);
            txbDiaChi.DataBindings.Add("Text", dgvGiangVien.DataSource, "DiaChi", true, DataSourceUpdateMode.Never);
        }

        // [QUAN TRỌNG] ĐÂY LÀ HÀM BẠN ĐANG THIẾU
        // Hàm này xử lý sự kiện click vào bảng. 
        // Do dùng BindingSource nên nó tự nhảy dữ liệu, hàm này để trống cũng được, nhưng PHẢI CÓ để không báo lỗi.
        private void dgvGiangVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Có thể để trống hoặc xử lý thêm nếu muốn
        }

        // Nút THÊM
        private void btnThem_Click(object sender, EventArgs e)
        {
            string ma = txbMaGV.Text;
            string ten = txbHoTen.Text;
            string gt = cbGioiTinh.Text;
            string sdt = txbSDT.Text;
            string email = txbEmail.Text;
            string dc = txbDiaChi.Text;

            if (ma == "" || ten == "")
            {
                MessageBox.Show("Vui lòng nhập Mã và Tên giảng viên!", "Cảnh báo");
                return;
            }

            try
            {
                if (GiangVienDAO.Instance.InsertGiangVien(ma, ten, gt, sdt, email, dc))
                {
                    MessageBox.Show("Thêm thành công!");
                    LoadListGiangVien();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại (Có thể trùng Mã GV)!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        // Nút SỬA
        private void btnSua_Click(object sender, EventArgs e)
        {
            string ma = txbMaGV.Text;
            string ten = txbHoTen.Text;
            string gt = cbGioiTinh.Text;
            string sdt = txbSDT.Text;
            string email = txbEmail.Text;
            string dc = txbDiaChi.Text;

            if (GiangVienDAO.Instance.UpdateGiangVien(ma, ten, gt, sdt, email, dc))
            {
                MessageBox.Show("Cập nhật thành công!");
                LoadListGiangVien();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại!");
            }
        }

        // Nút XÓA
        private void btnXoa_Click(object sender, EventArgs e)
        {
            string ma = txbMaGV.Text;

            if (MessageBox.Show("Bạn có chắc muốn xóa GV " + txbHoTen.Text + "?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (GiangVienDAO.Instance.DeleteGiangVien(ma))
                {
                    MessageBox.Show("Xóa thành công!");
                    LoadListGiangVien();
                }
                else
                {
                    MessageBox.Show("Không thể xóa (GV này đang phụ trách môn học)!");
                }
            }
        }
    }
}