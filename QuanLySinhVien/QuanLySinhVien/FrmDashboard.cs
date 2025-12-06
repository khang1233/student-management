using System;
using System.Windows.Forms;
using QuanLySinhVien.DAO;

namespace QuanLySinhVien
{
    public partial class FrmDashboard : Form
    {
        public FrmDashboard()
        {
            InitializeComponent();
            LoadThongKe();
        }

        void LoadThongKe()
        {
            // 1. Lấy số lượng SV
            int soSV = ThongKeDAO.Instance.GetTongSinhVien();
            lblNumSV.Text = soSV.ToString();

            // 2. Lấy số lớp
            int soLop = ThongKeDAO.Instance.GetTongLop();
            lblNumLop.Text = soLop.ToString();

            // 3. Lấy doanh thu
            decimal tien = ThongKeDAO.Instance.GetTongDoanhThu();
            lblDoanhThu.Text = tien.ToString("N0") + " VNĐ";
        }
    }
}