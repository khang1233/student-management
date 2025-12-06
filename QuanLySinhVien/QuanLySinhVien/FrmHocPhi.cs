using System;
using System.Data;
using System.Windows.Forms;
using QuanLySinhVien.DAO;
using QuanLySinhVien.DTO;

namespace QuanLySinhVien
{
    public partial class FrmHocPhi : Form
    {
        private string currentMaSV = null;

        public FrmHocPhi()
        {
            InitializeComponent();
            LoadDSSinhVien();
        }

        void LoadDSSinhVien()
        {
            // Tận dụng lại DAO SinhVien
            dgvSinhVien.DataSource = SinhVienDAO.Instance.GetListSinhVien();
            // Ẩn cột không cần thiết (Giống bên FrmDiem)
            dgvSinhVien.Columns["MaSV"].HeaderText = "Mã SV";
            dgvSinhVien.Columns["HoTen"].HeaderText = "Họ Tên";
            dgvSinhVien.Columns["NgaySinh"].Visible = false;
            dgvSinhVien.Columns["GioiTinh"].Visible = false;
            dgvSinhVien.Columns["DiaChi"].Visible = false;
            dgvSinhVien.Columns["SoDienThoai"].Visible = false;
            dgvSinhVien.Columns["Email"].Visible = false;
            dgvSinhVien.Columns["MaLop"].Visible = false;
        }

        private void dgvSinhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                SinhVien sv = (SinhVien)dgvSinhVien.Rows[e.RowIndex].DataBoundItem;
                currentMaSV = sv.MaSV;
                lblTenSV.Text = "Học phí của: " + sv.HoTen;

                // Tải thông tin học phí
                LoadHocPhi(currentMaSV);
            }
        }

        void LoadHocPhi(string maSV)
        {
            DataTable data = HocPhiDAO.Instance.GetHocPhi(maSV);
            if (data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];

                // Hiển thị ra Label, định dạng tiền tệ (C0) cho đẹp (ví dụ: 5,000,000 đ)
                decimal tong = Convert.ToDecimal(row["TongHocPhi"]);
                decimal daDong = Convert.ToDecimal(row["DaDong"]);
                decimal conNo = Convert.ToDecimal(row["ConNo"]);

                lblTongHP.Text = "Tổng Học Phí: " + tong.ToString("N0") + " VNĐ";
                lblDaDong.Text = "Đã Đóng: " + daDong.ToString("N0") + " VNĐ";
                lblConNo.Text = "Còn Nợ: " + conNo.ToString("N0") + " VNĐ";

                // Reset ô nhập tiền
                txbSoTienDong.Text = "";
            }
        }

        private void btnXacNhanDong_Click(object sender, EventArgs e)
        {
            if (currentMaSV == null)
            {
                MessageBox.Show("Vui lòng chọn sinh viên trước!");
                return;
            }

            // Kiểm tra nhập số
            if (double.TryParse(txbSoTienDong.Text, out double soTien))
            {
                if (HocPhiDAO.Instance.DongHocPhi(currentMaSV, soTien))
                {
                    MessageBox.Show("Đóng học phí thành công!");
                    LoadHocPhi(currentMaSV); // Load lại để cập nhật số dư
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra!");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập số tiền hợp lệ!");
            }
        }
    }
}