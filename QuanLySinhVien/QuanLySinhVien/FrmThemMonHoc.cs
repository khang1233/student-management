using System;
using System.Windows.Forms;
using QuanLySinhVien.DAO;
using QuanLySinhVien.DTO;

namespace QuanLySinhVien
{
    public partial class FrmThemMonHoc : Form
    {
        private string maMonSua = null;

        // Constructor 1: Dùng cho THÊM MỚI
        public FrmThemMonHoc()
        {
            InitializeComponent();
            // Không làm gì thêm, để form trống
        }

        // Constructor 2: Dùng cho SỬA
        public FrmThemMonHoc(MonHoc mh)
        {
            InitializeComponent();
            this.Text = "Cập nhật môn học";
            this.labelTitle.Text = "CẬP NHẬT MÔN";
            this.maMonSua = mh.MaMon; // Đánh dấu là đang sửa mã này

            // Đổ dữ liệu cũ lên ô nhập
            txbMaMon.Text = mh.MaMon;
            txbMaMon.Enabled = false; // Khóa không cho sửa Mã
            txbTenMon.Text = mh.TenMon;
            nudTinChi.Value = mh.SoTinChi;
        }

        // Sự kiện nút Lưu
        private void btnSave_Click(object sender, EventArgs e)
        {
            string ma = txbMaMon.Text.Trim();
            string ten = txbTenMon.Text.Trim();
            int tc = (int)nudTinChi.Value;

            if (string.IsNullOrEmpty(ma) || string.IsNullOrEmpty(ten))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!");
                return;
            }

            bool ketQua = false;

            // Logic: Nếu maMonSua là null thì là THÊM, ngược lại là SỬA
            if (maMonSua == null)
            {
                if (MonHocDAO.Instance.CheckExistMaMon(ma))
                {
                    MessageBox.Show("Mã môn đã tồn tại!"); return;
                }
                ketQua = MonHocDAO.Instance.InsertMonHoc(ma, ten, tc);
            }
            else
            {
                ketQua = MonHocDAO.Instance.UpdateMonHoc(ma, ten, tc);
            }

            if (ketQua)
            {
                MessageBox.Show("Thành công!");
                this.DialogResult = DialogResult.OK; // Báo OK cho form cha tải lại list
                this.Close();
            }
            else
            {
                MessageBox.Show("Thất bại!");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}