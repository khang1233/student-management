using System;
using System.Windows.Forms;
using QuanLySinhVien.DAO;

namespace QuanLySinhVien
{
    public partial class FrmGiangVien : Form
    {
        BindingSource listGiangVien = new BindingSource();

        public FrmGiangVien()
        {
            InitializeComponent();
            dgvGiangVien.DataSource = listGiangVien;
            LoadListGiangVien();
            AddGiangVienBinding();
        }

        void LoadListGiangVien()
        {
            listGiangVien.DataSource = GiangVienDAO.Instance.GetListGiangVien();
        }

        void AddGiangVienBinding()
        {
            txbMaGV.DataBindings.Clear();
            txbHoTen.DataBindings.Clear();
            cbGioiTinh.DataBindings.Clear();
            txbSDT.DataBindings.Clear();
            txbEmail.DataBindings.Clear();
            txbDiaChi.DataBindings.Clear();

            txbMaGV.DataBindings.Add("Text", dgvGiangVien.DataSource, "MaGV", true, DataSourceUpdateMode.Never);
            txbHoTen.DataBindings.Add("Text", dgvGiangVien.DataSource, "HoTen", true, DataSourceUpdateMode.Never);
            cbGioiTinh.DataBindings.Add("Text", dgvGiangVien.DataSource, "GioiTinh", true, DataSourceUpdateMode.Never);
            txbSDT.DataBindings.Add("Text", dgvGiangVien.DataSource, "SoDienThoai", true, DataSourceUpdateMode.Never);
            txbEmail.DataBindings.Add("Text", dgvGiangVien.DataSource, "Email", true, DataSourceUpdateMode.Never);
            txbDiaChi.DataBindings.Add("Text", dgvGiangVien.DataSource, "DiaChi", true, DataSourceUpdateMode.Never);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string ma = txbMaGV.Text;
            string ten = txbHoTen.Text;
            string gt = cbGioiTinh.Text;
            string sdt = txbSDT.Text;
            string email = txbEmail.Text;
            string dc = txbDiaChi.Text;
            string makhoa = "CNTT"; // [TẠM THỜI] Bạn nên thêm 1 TextBox Khoa trên Form

            if (GiangVienDAO.Instance.InsertGiangVien(ma, ten, gt, sdt, email, dc, makhoa))
            {
                MessageBox.Show("Thêm thành công!");
                LoadListGiangVien();
            }
            else MessageBox.Show("Thêm thất bại!");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string ma = txbMaGV.Text;
            string ten = txbHoTen.Text;
            string gt = cbGioiTinh.Text;
            string sdt = txbSDT.Text;
            string email = txbEmail.Text;
            string dc = txbDiaChi.Text;
            string makhoa = "CNTT"; // [TẠM THỜI]

            if (GiangVienDAO.Instance.UpdateGiangVien(ma, ten, gt, sdt, email, dc, makhoa))
            {
                MessageBox.Show("Cập nhật thành công!");
                LoadListGiangVien();
            }
            else MessageBox.Show("Cập nhật thất bại!");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string ma = txbMaGV.Text;
            if (MessageBox.Show("Xóa GV " + txbHoTen.Text + "?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (GiangVienDAO.Instance.DeleteGiangVien(ma))
                {
                    MessageBox.Show("Xóa thành công!");
                    LoadListGiangVien();
                }
                else MessageBox.Show("Lỗi xóa (Có thể do ràng buộc khóa ngoại)!");
            }
        }

        // Sự kiện click cell (bắt buộc phải có để tránh lỗi runtime nếu designer đã gán)
        private void dgvGiangVien_CellClick(object sender, DataGridViewCellEventArgs e) { }
    }
}