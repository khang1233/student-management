using System;
using System.Windows.Forms;
using QuanLySinhVien.DAO;
using QuanLySinhVien.DTO;

namespace QuanLySinhVien
{
    public partial class FrmMonHoc : Form
    {
        public FrmMonHoc()
        {
            InitializeComponent();

            // Cài đặt bảng chọn cả dòng
            dgvMonHoc.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMonHoc.MultiSelect = false;

            LoadListMonHoc(); // Tải danh sách
        }

        // Hàm tải dữ liệu
        void LoadListMonHoc()
        {
            // Gọi đúng tên dgvMonHoc
            dgvMonHoc.DataSource = MonHocDAO.Instance.GetListMonHoc();

            if (dgvMonHoc.Columns["MaMon"] != null) dgvMonHoc.Columns["MaMon"].HeaderText = "Mã Môn";
            if (dgvMonHoc.Columns["TenMon"] != null) dgvMonHoc.Columns["TenMon"].HeaderText = "Tên Môn";
            if (dgvMonHoc.Columns["SoTinChi"] != null) dgvMonHoc.Columns["SoTinChi"].HeaderText = "Tín Chỉ";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmThemMonHoc f = new FrmThemMonHoc();
            if (f.ShowDialog() == DialogResult.OK) LoadListMonHoc();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Kiểm tra dùng đúng dgvMonHoc
            if (dgvMonHoc.SelectedRows.Count > 0)
            {
                MonHoc mh = (MonHoc)dgvMonHoc.SelectedRows[0].DataBoundItem;
                FrmThemMonHoc f = new FrmThemMonHoc(mh);
                if (f.ShowDialog() == DialogResult.OK) LoadListMonHoc();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn môn cần sửa!");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvMonHoc.SelectedRows.Count > 0)
            {
                MonHoc mh = (MonHoc)dgvMonHoc.SelectedRows[0].DataBoundItem;
                if (MessageBox.Show("Xóa môn " + mh.TenMonHoc + "?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (MonHocDAO.Instance.DeleteMonHoc(mh.MaMonHoc))
                        LoadListMonHoc();
                    else
                        MessageBox.Show("Không thể xóa (Môn này đã có điểm)!");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn môn cần xóa!");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Gọi đúng biến txbSearch
            string keyword = txbSearch.Text.Trim();
            dgvMonHoc.DataSource = MonHocDAO.Instance.SearchMonHoc(keyword);
        }
    }
}