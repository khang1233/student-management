using System;
using System.Windows.Forms;
using QuanLySinhVien.DAO; // Để gọi lệnh SQL
using QuanLySinhVien.DTO; // Để hiểu kiểu dữ liệu SinhVien

namespace QuanLySinhVien
{
    public partial class FrmSinhVien : Form
    {
        public FrmSinhVien()
        {
            InitializeComponent();

            // --- THÊM 2 DÒNG NÀY ĐỂ SỬA LỖI ---
            // 1. Khi bấm vào 1 ô, nó sẽ tự chọn hết cả dòng
            dgvSinhVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            // 2. Chỉ cho phép chọn 1 người tại 1 thời điểm (tránh lỗi khi bấm sửa nhiều người)
            dgvSinhVien.MultiSelect = false;

            LoadListSinhVien();
        }

        // Hàm tải danh sách sinh viên lên bảng
        void LoadListSinhVien()
        {
            // Lấy danh sách từ DAO
            dgvSinhVien.DataSource = SinhVienDAO.Instance.GetListSinhVien();

            // Đặt tên tiếng Việt cho các cột hiển thị đẹp hơn
            if (dgvSinhVien.Columns["MaSV"] != null) dgvSinhVien.Columns["MaSV"].HeaderText = "Mã SV";
            if (dgvSinhVien.Columns["HoTen"] != null) dgvSinhVien.Columns["HoTen"].HeaderText = "Họ Tên";
            if (dgvSinhVien.Columns["NgaySinh"] != null) dgvSinhVien.Columns["NgaySinh"].HeaderText = "Ngày Sinh";
            if (dgvSinhVien.Columns["GioiTinh"] != null) dgvSinhVien.Columns["GioiTinh"].HeaderText = "Giới Tính";
            if (dgvSinhVien.Columns["DiaChi"] != null) dgvSinhVien.Columns["DiaChi"].HeaderText = "Địa Chỉ";
            if (dgvSinhVien.Columns["SoDienThoai"] != null) dgvSinhVien.Columns["SoDienThoai"].HeaderText = "SĐT";
            if (dgvSinhVien.Columns["Email"] != null) dgvSinhVien.Columns["Email"].HeaderText = "Email";
            if (dgvSinhVien.Columns["MaLop"] != null) dgvSinhVien.Columns["MaLop"].HeaderText = "Mã Lớp";
        }

        // --- CHỨC NĂNG THÊM ---
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Mở form thêm sinh viên (Form trắng)
            FrmThemSinhVien f = new FrmThemSinhVien();

            // Nếu người dùng bấm Lưu và form trả về OK
            if (f.ShowDialog() == DialogResult.OK)
            {
                // Tải lại danh sách để thấy người mới
                LoadListSinhVien();
            }
        }

        // --- CHỨC NĂNG SỬA (Đã cập nhật logic) ---
        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có dòng nào đang được chọn không
            if (dgvSinhVien.SelectedRows.Count > 0)
            {
                // Lấy đối tượng SinhVien từ dòng đang chọn
                SinhVien svDangChon = (SinhVien)dgvSinhVien.SelectedRows[0].DataBoundItem;

                // Mở form nhập liệu nhưng truyền dữ liệu cũ vào để sửa
                FrmThemSinhVien f = new FrmThemSinhVien(svDangChon);

                // Nếu sửa xong và bấm Lưu
                if (f.ShowDialog() == DialogResult.OK)
                {
                    LoadListSinhVien(); // Tải lại danh sách
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // --- CHỨC NĂNG XÓA (Đã cập nhật logic) ---
        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có dòng nào đang được chọn không
            if (dgvSinhVien.SelectedRows.Count > 0)
            {
                // Lấy thông tin sinh viên đang chọn
                SinhVien sv = (SinhVien)dgvSinhVien.SelectedRows[0].DataBoundItem;
                string maSV = sv.MaSV;

                // Hiện hộp thoại xác nhận (Tránh xóa nhầm)
                DialogResult confirm = MessageBox.Show(
                    "Bạn có chắc chắn muốn xóa sinh viên " + sv.HoTen + " không?",
                    "Cảnh báo xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirm == DialogResult.Yes)
                {
                    // Gọi DAO để xóa trong SQL
                    if (SinhVienDAO.Instance.DeleteSinhVien(maSV))
                    {
                        MessageBox.Show("Đã xóa thành công!", "Thông báo");
                        LoadListSinhVien(); // Tải lại danh sách
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại! Có thể sinh viên này đang có điểm số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvSinhVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txbSearch.Text.Trim();
            dgvSinhVien.DataSource = SinhVienDAO.Instance.SearchSinhVienByID(keyword);
        }
        private void txbSearch_TextChanged(object sender, EventArgs e)
        {
            // Gọi lại hàm click nút tìm kiếm
            btnSearch_Click(sender, e);
        }
    }
}