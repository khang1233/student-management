using System;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using QuanLyTrungTam.DAO;

namespace QuanLyTrungTam
{
    public partial class FrmDangKyAdmin : Form
    {
        // --- CONTROL GIAO DIỆN ---
        private TextBox txbSearch = new TextBox();
        private DataGridView dgvHocVien = new DataGridView();

        private ComboBox cbKyNang = new ComboBox();
        private ComboBox cbLopHoc = new ComboBox();
        private Label lblHocPhi = new Label();
        private Button btnDangKy = new Button();
        private DataGridView dgvDaDangKy = new DataGridView();

        private string currentMaHV = "";
        private string currentTenHV = "";

        public FrmDangKyAdmin()
        {
            // InitializeComponent(); 
            SetupBalancedUI();
            LoadDataHocVien("");
            LoadKyNang();
        }

        // =================================================================================
        // 1. THIẾT KẾ GIAO DIỆN
        // =================================================================================
        private void SetupBalancedUI()
        {
            this.Text = "Quản Lý Đăng Ký Tuyển Sinh";
            this.BackColor = Color.WhiteSmoke;
            this.WindowState = FormWindowState.Maximized;
            this.Font = new Font("Segoe UI", 10F);

            // --- A. HEADER ---
            Panel pnlHeader = new Panel { Dock = DockStyle.Top, Height = 70, BackColor = ColorTranslator.FromHtml("#00796B"), Padding = new Padding(20) };
            Label lblTitle = new Label { Text = "QUẢN LÝ ĐĂNG KÝ & HỦY MÔN", Font = new Font("Segoe UI", 18, FontStyle.Bold), ForeColor = Color.White, AutoSize = true, Location = new Point(20, 20) };
            pnlHeader.Controls.Add(lblTitle);
            this.Controls.Add(pnlHeader);

            // --- B. CHIA CỘT ---
            SplitContainer split = new SplitContainer { Dock = DockStyle.Fill, SplitterWidth = 8, BackColor = Color.LightGray };

            // >>> TRÁI: DANH SÁCH HỌC VIÊN
            split.FixedPanel = FixedPanel.Panel1;
            split.SplitterDistance = 600;

            GroupBox grpLeft = new GroupBox { Text = " 1. Chọn Học Viên ", Dock = DockStyle.Fill, Font = new Font("Segoe UI", 11, FontStyle.Bold), ForeColor = Color.DimGray, BackColor = Color.White };
            grpLeft.Padding = new Padding(10);

            txbSearch.Dock = DockStyle.Top; txbSearch.Font = new Font("Segoe UI", 12); txbSearch.Height = 35;
            SetPlaceholder(txbSearch, "🔍 Nhập tên hoặc số điện thoại...");
            txbSearch.TextChanged += (s, e) => LoadDataHocVien(txbSearch.Text);

            Panel spacer = new Panel { Dock = DockStyle.Top, Height = 10, BackColor = Color.White };

            StyleGrid(dgvHocVien);
            dgvHocVien.CellClick += DgvHocVien_CellClick;

            grpLeft.Controls.Add(dgvHocVien); grpLeft.Controls.Add(spacer); grpLeft.Controls.Add(txbSearch);
            split.Panel1.Controls.Add(grpLeft); split.Panel1.Padding = new Padding(10);

            // >>> PHẢI: FORM ĐĂNG KÝ & DANH SÁCH LỚP
            Panel pnlRight = new Panel { Dock = DockStyle.Fill, BackColor = Color.WhiteSmoke };

            // 1. Khu vực Đăng ký (Trên)
            GroupBox grpAction = new GroupBox { Text = " 2. Đăng Ký Mới ", Dock = DockStyle.Top, Height = 250, Font = new Font("Segoe UI", 11, FontStyle.Bold), ForeColor = Color.DimGray, BackColor = Color.White };
            Panel pnlInputCenter = new Panel { Dock = DockStyle.Fill, Padding = new Padding(40, 20, 40, 0) };

            Label l1 = new Label { Text = "Môn Học:", Location = new Point(40, 30), AutoSize = true, Font = new Font("Segoe UI", 10), ForeColor = Color.Black };
            cbKyNang.Location = new Point(40, 55); cbKyNang.Width = 350; cbKyNang.Height = 30; cbKyNang.DropDownStyle = ComboBoxStyle.DropDownList; cbKyNang.Font = new Font("Segoe UI", 11);
            cbKyNang.SelectedIndexChanged += CbKyNang_SelectedIndexChanged;

            Label l2 = new Label { Text = "Lớp Học:", Location = new Point(40, 100), AutoSize = true, Font = new Font("Segoe UI", 10), ForeColor = Color.Black };
            cbLopHoc.Location = new Point(40, 125); cbLopHoc.Width = 350; cbLopHoc.Height = 30; cbLopHoc.DropDownStyle = ComboBoxStyle.DropDownList; cbLopHoc.Font = new Font("Segoe UI", 11);

            Label l3 = new Label { Text = "Học Phí:", Location = new Point(450, 30), AutoSize = true, Font = new Font("Segoe UI", 10), ForeColor = Color.Black };
            lblHocPhi.Text = "0 VNĐ"; lblHocPhi.Location = new Point(450, 55); lblHocPhi.AutoSize = true;
            lblHocPhi.Font = new Font("Segoe UI", 20, FontStyle.Bold); lblHocPhi.ForeColor = Color.Red;

            btnDangKy.Text = "XÁC NHẬN ĐĂNG KÝ";
            btnDangKy.Location = new Point(450, 115); btnDangKy.Size = new Size(200, 45);
            btnDangKy.BackColor = ColorTranslator.FromHtml("#FFC107"); btnDangKy.FlatStyle = FlatStyle.Flat; btnDangKy.FlatAppearance.BorderSize = 0;
            btnDangKy.ForeColor = Color.Black; btnDangKy.Cursor = Cursors.Hand; btnDangKy.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnDangKy.Click += BtnDangKy_Click;

            pnlInputCenter.Controls.AddRange(new Control[] { l1, cbKyNang, l2, cbLopHoc, l3, lblHocPhi, btnDangKy });
            grpAction.Controls.Add(pnlInputCenter);

            // 2. Khu vực Danh sách lớp đã ĐK (Dưới - Có nút Hủy)
            GroupBox grpHistory = new GroupBox { Text = " Các lớp học viên này đã đăng ký (Bấm nút Đỏ để Hủy) ", Dock = DockStyle.Fill, Font = new Font("Segoe UI", 11, FontStyle.Bold), ForeColor = Color.DimGray, BackColor = Color.White };
            grpHistory.Padding = new Padding(10);

            StyleGrid(dgvDaDangKy);
            // Thêm sự kiện Click nút Hủy
            dgvDaDangKy.CellContentClick += DgvDaDangKy_CellContentClick;

            grpHistory.Controls.Add(dgvDaDangKy);

            pnlRight.Controls.Add(grpHistory);
            pnlRight.Controls.Add(grpAction);

            split.Panel2.Controls.Add(pnlRight); split.Panel2.Padding = new Padding(10);
            this.Controls.Add(split);
        }

        // --- HÀM STYLE GRID: THÊM CỘT NÚT HỦY ---
        private void StyleGrid(DataGridView dgv)
        {
            dgv.Dock = DockStyle.Fill;
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.FixedSingle;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.RowHeadersVisible = false;
            dgv.AllowUserToAddRows = false;
            dgv.ReadOnly = true;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.RowTemplate.Height = 35;

            dgv.ColumnHeadersHeight = 40;
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#00796B");
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgv.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#B2DFDB");
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;
        }

        // =================================================================================
        // 2. LOGIC XỬ LÝ
        // =================================================================================

        void LoadDataHocVien(string keyword)
        {
            DataTable dt = HocVienDAO.Instance.GetListHocVien();
            if (dt == null) return;

            if (!string.IsNullOrEmpty(keyword) && keyword != "🔍 Nhập tên hoặc số điện thoại...")
            {
                dt.DefaultView.RowFilter = string.Format("MaHV LIKE '%{0}%' OR HoTen LIKE '%{0}%' OR SoDienThoai LIKE '%{0}%'", keyword);
            }
            dgvHocVien.DataSource = dt;

            string[] hide = { "DiaChi", "NgaySinh", "Email", "NgayGiaNhap", "MaLop", "MaKyNang" };
            foreach (string c in hide) if (dgvHocVien.Columns.Contains(c)) dgvHocVien.Columns[c].Visible = false;

            if (dgvHocVien.Columns.Contains("MaHV")) { dgvHocVien.Columns["MaHV"].HeaderText = "Mã HV"; dgvHocVien.Columns["MaHV"].Width = 100; }
            if (dgvHocVien.Columns.Contains("HoTen")) { dgvHocVien.Columns["HoTen"].HeaderText = "Họ Tên"; dgvHocVien.Columns["HoTen"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; }
            if (dgvHocVien.Columns.Contains("SoDienThoai")) { dgvHocVien.Columns["SoDienThoai"].HeaderText = "SĐT"; dgvHocVien.Columns["SoDienThoai"].Width = 120; }
        }

        private void DgvHocVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvHocVien.Rows[e.RowIndex];
                currentMaHV = row.Cells["MaHV"].Value.ToString();
                currentTenHV = row.Cells["HoTen"].Value.ToString();

                GroupBox grpRight = (GroupBox)btnDangKy.Parent.Parent;
                grpRight.Text = $" 2. Đăng ký cho: {currentTenHV.ToUpper()} ({currentMaHV}) ";
                grpRight.ForeColor = ColorTranslator.FromHtml("#D32F2F");

                LoadDanhSachDaDangKy();
            }
        }

        // --- LOAD DANH SÁCH LỚP ĐÃ HỌC (THÊM NÚT HỦY) ---
        void LoadDanhSachDaDangKy()
        {
            dgvDaDangKy.DataSource = TuitionDAO.Instance.GetListDangKy(currentMaHV);

            // Xóa cột nút cũ nếu có để tránh trùng lặp
            if (dgvDaDangKy.Columns.Contains("colHuy")) dgvDaDangKy.Columns.Remove("colHuy");

            // Tạo nút Hủy
            DataGridViewButtonColumn btnCancel = new DataGridViewButtonColumn();
            btnCancel.Name = "colHuy";
            btnCancel.HeaderText = "Thao tác";
            btnCancel.Text = "Hủy Đăng Ký";
            btnCancel.UseColumnTextForButtonValue = true;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.DefaultCellStyle.BackColor = Color.Red;
            btnCancel.DefaultCellStyle.ForeColor = Color.White;
            btnCancel.DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);

            dgvDaDangKy.Columns.Add(btnCancel); // Thêm nút vào cuối

            // Định dạng cột
            if (dgvDaDangKy.Columns.Contains("TenKyNang")) dgvDaDangKy.Columns["TenKyNang"].HeaderText = "Môn Học";
            if (dgvDaDangKy.Columns.Contains("TenLop")) dgvDaDangKy.Columns["TenLop"].HeaderText = "Lớp";
            if (dgvDaDangKy.Columns.Contains("HocPhiLop"))
            {
                dgvDaDangKy.Columns["HocPhiLop"].HeaderText = "Học Phí";
                dgvDaDangKy.Columns["HocPhiLop"].DefaultCellStyle.Format = "N0";
            }
            if (dgvDaDangKy.Columns.Contains("NgayDangKy")) dgvDaDangKy.Columns["NgayDangKy"].Visible = false;

            // Ẩn cột MaLop (Cột này mới thêm trong DAO để lấy ID xóa)
            if (dgvDaDangKy.Columns.Contains("MaLop")) dgvDaDangKy.Columns["MaLop"].Visible = false;
        }

        // --- SỰ KIỆN BẤM NÚT HỦY ---
        private void DgvDaDangKy_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem có bấm đúng vào cột nút "Hủy" không
            if (e.ColumnIndex == dgvDaDangKy.Columns["colHuy"].Index && e.RowIndex >= 0)
            {
                string tenLop = dgvDaDangKy.Rows[e.RowIndex].Cells["TenLop"].Value.ToString();
                string maLop = dgvDaDangKy.Rows[e.RowIndex].Cells["MaLop"].Value.ToString(); // Lấy mã lớp ẩn

                if (MessageBox.Show($"Bạn có chắc chắn muốn hủy đăng ký lớp: {tenLop}?", "Xác nhận hủy", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (TuitionDAO.Instance.HuyDangKy(currentMaHV, maLop))
                    {
                        MessageBox.Show("Đã hủy đăng ký thành công!");
                        LoadDanhSachDaDangKy(); // Refresh lại danh sách
                    }
                    else
                    {
                        MessageBox.Show("Lỗi khi hủy đăng ký. Vui lòng thử lại.");
                    }
                }
            }
        }

        void LoadKyNang()
        {
            cbKyNang.DataSource = KyNangDAO.Instance.GetListKyNang();
            cbKyNang.DisplayMember = "TenKyNang";
            cbKyNang.ValueMember = "MaKyNang";
        }

        private void CbKyNang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbKyNang.SelectedValue != null)
            {
                DataRowView row = cbKyNang.SelectedItem as DataRowView;
                if (row != null)
                {
                    decimal hp = row["HocPhi"] != DBNull.Value ? Convert.ToDecimal(row["HocPhi"]) : 0;
                    lblHocPhi.Text = hp.ToString("N0") + " VNĐ";
                    lblHocPhi.Tag = hp;

                    string maKN = row["MaKyNang"].ToString();
                    cbLopHoc.DataSource = LopHocDAO.Instance.GetListLopByKyNang(maKN);
                    cbLopHoc.DisplayMember = "TenLop";
                    cbLopHoc.ValueMember = "MaLop";
                }
            }
        }

        private void BtnDangKy_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentMaHV)) { MessageBox.Show("Vui lòng chọn học viên ở cột bên trái trước!"); return; }
            if (cbLopHoc.SelectedValue == null) { MessageBox.Show("Vui lòng chọn lớp học!"); return; }

            string maLop = cbLopHoc.SelectedValue.ToString();
            decimal hocPhi = lblHocPhi.Tag != null ? Convert.ToDecimal(lblHocPhi.Tag) : 0;

            if (TuitionDAO.Instance.DangKyLop(currentMaHV, maLop, hocPhi))
            {
                MessageBox.Show($"Đăng ký thành công lớp {cbLopHoc.Text} cho học viên {currentTenHV}!");
                LoadDanhSachDaDangKy();
            }
            else
            {
                MessageBox.Show("Học viên này đã đăng ký lớp này rồi!", "Trùng đăng ký", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void SetPlaceholder(TextBox txt, string holder)
        {
            txt.Text = holder; txt.ForeColor = Color.Gray;
            txt.Enter += (s, e) => { if (txt.Text == holder) { txt.Text = ""; txt.ForeColor = Color.Black; } };
            txt.Leave += (s, e) => { if (string.IsNullOrWhiteSpace(txt.Text)) { txt.Text = holder; txt.ForeColor = Color.Gray; } };
        }
    }
}