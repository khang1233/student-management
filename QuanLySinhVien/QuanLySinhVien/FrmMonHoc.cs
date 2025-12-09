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
            dgvMonHoc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Tự động giãn cột cho đẹp

            LoadListMonHoc(); // Tải danh sách
        }

        // Hàm tải dữ liệu
        void LoadListMonHoc()
        {
            dgvMonHoc.DataSource = MonHocDAO.Instance.GetListMonHoc();

            // SỬA: Tên cột phải trùng với tên thuộc tính trong Class DTO MonHoc (thường là MaMonHoc, TenMonHoc)
            if (dgvMonHoc.Columns["MaMonHoc"] != null)
                dgvMonHoc.Columns["MaMonHoc"].HeaderText = "Mã Môn";

            if (dgvMonHoc.Columns["TenMonHoc"] != null)
                dgvMonHoc.Columns["TenMonHoc"].HeaderText = "Tên Môn";

            if (dgvMonHoc.Columns["SoTinChi"] != null)
                dgvMonHoc.Columns["SoTinChi"].HeaderText = "Tín Chỉ";

            // Ẩn mã GV nếu không cần hiện
            if (dgvMonHoc.Columns["MaGV"] != null)
                dgvMonHoc.Columns["MaGV"].Visible = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Khởi tạo form thêm mới (gọi Constructor 1 - không tham số)
            FrmThemMonHoc f = new FrmThemMonHoc();

            // Hiện form lên dưới dạng Dialog (người dùng phải tắt form con mới thao tác được form cha)
            // Nếu khi đóng form, kết quả trả về là OK (nghĩa là đã lưu thành công)
            if (f.ShowDialog() == DialogResult.OK)
            {
                // Gọi hàm tải lại danh sách môn học để cập nhật dòng mới thêm
                LoadListMonHoc();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra xem người dùng đã chọn dòng nào chưa
            // (SelectedCells.Count > 0 đảm bảo có ít nhất 1 ô được chọn)
            if (dgvMonHoc.SelectedCells.Count > 0)
            {
                // 2. Lấy dòng hiện tại đang được chọn
                int index = dgvMonHoc.SelectedCells[0].RowIndex;
                DataGridViewRow row = dgvMonHoc.Rows[index];

                // 3. Lấy dữ liệu từ các ô (Cell) của dòng đó
                // Lưu ý: Tên cột ("MaMonHoc", "TenMonHoc"...) phải đúng với thiết kế DataGridView của bạn
                string ma = row.Cells["MaMonHoc"].Value.ToString();
                string ten = row.Cells["TenMonHoc"].Value.ToString();

                // Cần ép kiểu số Tín chỉ từ string sang int
                int tc = 0;
                int.TryParse(row.Cells["SoTinChi"].Value.ToString(), out tc);

                // 4. Tạo đối tượng MonHoc để gửi sang form con
                MonHoc mh = new MonHoc(ma, ten, tc);

                // 5. Mở form FrmThemMonHoc với constructor SỬA (truyền biến mh vào)
                FrmThemMonHoc f = new FrmThemMonHoc(mh);

                // 6. Chờ form đóng lại. Nếu kết quả là OK (đã lưu) thì tải lại danh sách
                if (f.ShowDialog() == DialogResult.OK)
                {
                    LoadListMonHoc(); // Gọi hàm tải lại danh sách để thấy thay đổi
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn môn học cần sửa!", "Thông báo");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvMonHoc.SelectedRows.Count > 0)
            {
                MonHoc mh = (MonHoc)dgvMonHoc.SelectedRows[0].DataBoundItem;
                if (MessageBox.Show("Xóa môn " + mh.TenMonHoc + "?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    // SỬA: Gọi property MaMonHoc
                    if (MonHocDAO.Instance.DeleteMonHoc(mh.MaMonHoc))
                        LoadListMonHoc();
                    else
                        MessageBox.Show("Không thể xóa (Môn này đã có điểm hoặc lỗi hệ thống)!");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn môn cần xóa!");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txbSearch.Text.Trim();
            dgvMonHoc.DataSource = MonHocDAO.Instance.SearchMonHoc(keyword);
        }
    }
}