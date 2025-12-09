using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Data;
using QuanLySinhVien.DAO;

namespace QuanLySinhVien
{
    public partial class FrmDashboard : Form
    {
        // --- KHAI BÁO BIẾN TOÀN CỤC ---
        private TextBox txtSearch;
        private DataGridView dgv;

        // --- KHAI BÁO MÀU SẮC ---
        private readonly Color clrBackground = ColorTranslator.FromHtml("#F4F6F9");
        private readonly Color clrWhite = Color.White;
        private readonly Color clrTextHeader = ColorTranslator.FromHtml("#343A40");
        private readonly Color clrTextBody = ColorTranslator.FromHtml("#6C757D");
        private readonly Color clrPrimary = ColorTranslator.FromHtml("#007BFF");
        private readonly Color clrSuccess = ColorTranslator.FromHtml("#28A745");
        private readonly Color clrWarning = ColorTranslator.FromHtml("#FFC107");
        private readonly Color clrDanger = ColorTranslator.FromHtml("#DC3545");
        private readonly Color clrInfo = ColorTranslator.FromHtml("#17A2B8");
        private readonly Color clrPurple = ColorTranslator.FromHtml("#6F42C1");

        // --- MÀU SẮC CHO BIỂU ĐỒ TRÒN ---
        private readonly Color clrChartGioi = Color.ForestGreen; // Xanh lá
        private readonly Color clrChartKha = Color.DodgerBlue;   // Xanh dương
        private readonly Color clrChartTB = Color.Gold;          // Vàng
        private readonly Color clrChartYeu = Color.Red;          // Đỏ

        public FrmDashboard()
        {
            InitializeComponent();
            SetupCustomDashboard();
        }

        private void SetupCustomDashboard()
        {
            // 1. Cài đặt Form
            this.Text = "Hệ thống Quản lý Sinh viên - Dashboard";
            this.Size = new Size(1280, 800);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = clrBackground;
            this.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular);

            // --- LẤY DỮ LIỆU TỪ DAO ---
            int soSV = 0, soLop = 0, soCanhBao = 0;
            string tyLeNamNu = "0% / 0%";

            try
            {
                soSV = ThongKeDAO.Instance.GetTongSinhVien();
                soLop = ThongKeDAO.Instance.GetTongLop();
                soCanhBao = ThongKeDAO.Instance.GetSoCanhBaoHocVu();
                tyLeNamNu = ThongKeDAO.Instance.GetTyLeNamNu();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối CSDL: " + ex.Message);
            }

            // 2. Setup Layout
            TableLayoutPanel mainLayout = new TableLayoutPanel();
            mainLayout.Dock = DockStyle.Fill;
            mainLayout.ColumnCount = 1;
            mainLayout.RowCount = 5;
            mainLayout.Padding = new Padding(20);
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 110F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 60F));

            this.Controls.Add(mainLayout);
            mainLayout.BringToFront();

            // 3. Header
            Label lblHeader = new Label
            {
                Text = "Tổng quan Hệ thống",
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                ForeColor = clrTextHeader,
                AutoSize = true
            };
            mainLayout.Controls.Add(lblHeader, 0, 0);

            // 4. Cards
            TableLayoutPanel cardsPanel = new TableLayoutPanel();
            cardsPanel.Dock = DockStyle.Fill;
            cardsPanel.ColumnCount = 4;
            cardsPanel.RowCount = 1;
            cardsPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            cardsPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            cardsPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            cardsPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));

            cardsPanel.Controls.Add(CreateCard("Tổng số sinh viên", soSV.ToString("N0"), "🎓", clrPurple), 0, 0);
            cardsPanel.Controls.Add(CreateCard("Tổng số Lớp", soLop.ToString(), "🏢", clrPrimary), 1, 0);
            cardsPanel.Controls.Add(CreateCard("Tỉ lệ Nam/Nữ", tyLeNamNu, "👥", clrSuccess), 2, 0);
            cardsPanel.Controls.Add(CreateCard("Cảnh báo học vụ", soCanhBao.ToString(), "⚠️", clrDanger), 3, 0);

            mainLayout.Controls.Add(cardsPanel, 0, 1);

            // 5. Charts
            TableLayoutPanel chartsPanel = new TableLayoutPanel();
            chartsPanel.Dock = DockStyle.Fill;
            chartsPanel.ColumnCount = 2;
            chartsPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            chartsPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));

            // --- Chart 1: Học lực ---
            Panel pnlPie = CreatePanelContainer();
            Chart pieChart = CreateChart("Tỉ lệ xếp loại học lực");
            pieChart.Series.Add("HocLuc");
            pieChart.Series["HocLuc"].ChartType = SeriesChartType.Doughnut;

            try
            {
                DataTable dtHocLuc = ThongKeDAO.Instance.GetPhanBoHocLuc();
                if (dtHocLuc != null && dtHocLuc.Rows.Count > 0)
                {
                    foreach (DataRow row in dtHocLuc.Rows)
                    {
                        string xepLoai = row["XepLoai"].ToString();
                        int sl = Convert.ToInt32(row["SoLuong"]);
                        int i = pieChart.Series["HocLuc"].Points.AddXY(xepLoai, sl);

                        // [THAY ĐỔI MÀU SẮC THEO YÊU CẦU]
                        if (xepLoai.Contains("Giỏi") || xepLoai.Contains("Xuất sắc"))
                            pieChart.Series["HocLuc"].Points[i].Color = clrChartGioi; // Xanh lá
                        else if (xepLoai.Contains("Khá"))
                            pieChart.Series["HocLuc"].Points[i].Color = clrChartKha;   // Xanh dương
                        else if (xepLoai.Contains("Trung bình"))
                            pieChart.Series["HocLuc"].Points[i].Color = clrChartTB;    // Vàng
                        else
                            pieChart.Series["HocLuc"].Points[i].Color = clrChartYeu;   // Đỏ
                    }
                }
                else
                {
                    pieChart.Series["HocLuc"].Points.AddXY("Chưa có dữ liệu", 1);
                }
            }
            catch { }

            pnlPie.Controls.Add(pieChart);
            chartsPanel.Controls.Add(pnlPie, 0, 0);

            // --- Chart 2: Khoa ---
            Panel pnlBar = CreatePanelContainer();
            Chart barChart = CreateChart("Số lượng SV theo Khoa");
            barChart.Series.Add("SinhVien");
            barChart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            barChart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
            barChart.ChartAreas[0].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            barChart.Series["SinhVien"].Color = clrInfo;

            try
            {
                DataTable dtKhoa = ThongKeDAO.Instance.GetSinhVienTheoKhoa();
                if (dtKhoa != null && dtKhoa.Rows.Count > 0)
                {
                    foreach (DataRow row in dtKhoa.Rows)
                    {
                        string tenKhoa = row["TenKhoa"].ToString();
                        int sl = Convert.ToInt32(row["SoLuong"]);
                        barChart.Series["SinhVien"].Points.AddXY(tenKhoa, sl);
                    }
                }
                else
                {
                    barChart.Series["SinhVien"].Points.AddXY("Chưa có dữ liệu", 0);
                }
            }
            catch
            {
                barChart.Series["SinhVien"].Points.AddXY("Lỗi tải data", 0);
            }

            pnlBar.Controls.Add(barChart);
            chartsPanel.Controls.Add(pnlBar, 1, 0);

            mainLayout.Controls.Add(chartsPanel, 0, 2);

            // 6. Actions (Buttons & Search)
            Panel actionPanel = new Panel();
            actionPanel.Dock = DockStyle.Fill;
            actionPanel.Padding = new Padding(0, 10, 0, 10);

            Button btnAdd = CreateFlatButton("Thêm sinh viên", clrPrimary);
            btnAdd.Click += BtnAdd_Click;

            Button btnGrades = CreateFlatButton("Nhập điểm", clrSuccess);
            btnGrades.Click += BtnGrades_Click;

            Button btnExport = CreateFlatButton("Xuất báo cáo", clrSuccess);
            btnExport.Click += BtnSearch_Click;

            txtSearch = new TextBox();
            txtSearch.Text = "Tra cứu nhanh...";
            txtSearch.Font = new Font("Segoe UI", 12F);
            txtSearch.Width = 300;
            txtSearch.Location = new Point(450, 8);

            txtSearch.Enter += (s, e) => { if (txtSearch.Text == "Tra cứu nhanh...") txtSearch.Text = ""; };
            txtSearch.Leave += (s, e) => { if (string.IsNullOrWhiteSpace(txtSearch.Text)) txtSearch.Text = "Tra cứu nhanh..."; };
            txtSearch.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) BtnSearch_Click(s, e); };
            txtSearch.Click += (s, e) => { if (txtSearch.Text == "Tra cứu nhanh...") txtSearch.Text = ""; };

            btnAdd.Location = new Point(0, 5);
            btnGrades.Location = new Point(150, 5);
            btnExport.Location = new Point(300, 5);

            actionPanel.Controls.Add(btnAdd);
            actionPanel.Controls.Add(btnGrades);
            actionPanel.Controls.Add(btnExport);
            actionPanel.Controls.Add(txtSearch);

            mainLayout.Controls.Add(actionPanel, 0, 3);

            // 7. Grid & Notification
            TableLayoutPanel listPanel = new TableLayoutPanel();
            listPanel.Dock = DockStyle.Fill;
            listPanel.ColumnCount = 2;
            listPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            listPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));

            // Grid
            Panel pnlGrid = CreatePanelContainer();
            pnlGrid.Padding = new Padding(10);
            Label lblGridTitle = new Label { Text = "Top Sinh Viên Tiêu Biểu", Font = new Font("Segoe UI", 11F, FontStyle.Bold), Dock = DockStyle.Top, Height = 30 };

            dgv = new DataGridView();
            dgv.Dock = DockStyle.Fill;
            dgv.BackgroundColor = clrWhite;
            dgv.BorderStyle = BorderStyle.None;
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersHeight = 40;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F8F9FA");
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgv.RowHeadersVisible = false;
            dgv.ReadOnly = true;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            LoadDataToGrid(ThongKeDAO.Instance.GetTopSinhVien());

            pnlGrid.Controls.Add(dgv);
            pnlGrid.Controls.Add(lblGridTitle);

            // Notification
            Panel pnlNotif = CreatePanelContainer();
            pnlNotif.Padding = new Padding(10);
            Label lblNotifTitle = new Label { Text = "Thông báo", Font = new Font("Segoe UI", 11F, FontStyle.Bold), Dock = DockStyle.Top, Height = 30 };
            ListBox lstNotif = new ListBox { Dock = DockStyle.Fill, BorderStyle = BorderStyle.None };

            lstNotif.Items.Add("ℹ️ Đã cập nhật dữ liệu mới nhất");
            if (soCanhBao > 0)
                lstNotif.Items.Add("⚠️ " + soCanhBao + " sinh viên cần cảnh báo học vụ");
            else
                lstNotif.Items.Add("✅ Tình hình học tập ổn định");

            pnlNotif.Controls.Add(lstNotif);
            pnlNotif.Controls.Add(lblNotifTitle);

            listPanel.Controls.Add(pnlGrid, 0, 0);
            listPanel.Controls.Add(pnlNotif, 1, 0);

            mainLayout.Controls.Add(listPanel, 0, 4);
            // ... (Code tạo giao diện) ...

            // Load dữ liệu mặc định ngay khi mở Form
            LoadDataToGrid(ThongKeDAO.Instance.GetTopSinhVien());  // <--- DÒNG NÀY QUAN TRỌNG

            pnlGrid.Controls.Add(dgv);
            pnlGrid.Controls.Add(lblGridTitle);
            // ...
        }


        // --- CÁC HÀM HELPER ---
        // --- CÁC HÀM HELPER ---
        private void LoadDataToGrid(DataTable dt)
        {
            try
            {
                dgv.DataSource = dt;

                // Định dạng tên cột hiển thị
                if (dgv.Columns.Count >= 4)
                {
                    // [SỬA Ở ĐÂY] Thay đổi nội dung trong dấu ngoặc kép
                    dgv.Columns[0].HeaderText = "Mã sinh viên";      // Cột 0: Mã SV
                    dgv.Columns[1].HeaderText = "Họ tên";            // Cột 1: Tên
                    dgv.Columns[2].HeaderText = "Khoa";              // Cột 2: Khoa
                    dgv.Columns[3].HeaderText = "Điểm trung bình";   // Cột 3: GPA
                }
            }
            catch { }
        }

        private Panel CreateCard(string title, string value, string icon, Color accentColor)
        {
            Panel card = new Panel { Dock = DockStyle.Fill, Margin = new Padding(5), BackColor = clrWhite };
            Panel accent = new Panel { Dock = DockStyle.Left, Width = 5, BackColor = accentColor };
            Label lblIcon = new Label
            {
                Text = icon,
                Font = new Font("Segoe UI", 24F),
                ForeColor = Color.FromArgb(100, accentColor),
                AutoSize = true,
                Location = new Point(15, 20)
            };
            Label lblTitle = new Label
            {
                Text = title,
                ForeColor = clrTextBody,
                Location = new Point(75, 18),
                AutoSize = true
            };

            Label lblValue = new Label
            {
                Text = value,
                ForeColor = clrTextHeader,
                Font = new Font("Segoe UI", 13F, FontStyle.Bold),
                Location = new Point(72, 38),
                AutoSize = true,
                TextAlign = ContentAlignment.MiddleLeft
            };

            card.Controls.Add(lblValue);
            card.Controls.Add(lblTitle);
            card.Controls.Add(lblIcon);
            card.Controls.Add(accent);
            return card;
        }

        private Panel CreatePanelContainer()
        {
            return new Panel { Dock = DockStyle.Fill, Margin = new Padding(5), BackColor = clrWhite };
        }

        private Chart CreateChart(string title)
        {
            Chart c = new Chart { Dock = DockStyle.Fill };
            ChartArea ca = new ChartArea { BackColor = Color.White };
            ca.AxisX.MajorGrid.Enabled = false;
            ca.AxisY.MajorGrid.Enabled = false;
            c.ChartAreas.Add(ca);
            c.Titles.Add(new Title(title) { Font = new Font("Segoe UI", 10, FontStyle.Bold), ForeColor = clrTextBody });
            return c;
        }

        private Button CreateFlatButton(string text, Color color)
        {
            return new Button { Text = text, FlatStyle = FlatStyle.Flat, BackColor = color, ForeColor = Color.White, Size = new Size(140, 40), Font = new Font("Segoe UI", 9F, FontStyle.Bold) };
        }

        // --- CÁC SỰ KIỆN NÚT BẤM ---
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            FrmThemSinhVien f = new FrmThemSinhVien();
            if (f.ShowDialog() == DialogResult.OK)
            {
                this.Controls.Clear();
                SetupCustomDashboard();
            }
        }

        private void BtnGrades_Click(object sender, EventArgs e)
        {
            // SỬA: Truyền AppSession.CurrentUser vào Constructor
            // (Đảm bảo bạn đã có class Utilities/AppSession như các bước trước)
            FrmDiem f = new FrmDiem(QuanLySinhVien.Utilities.AppSession.CurrentUser);

            if (f.ShowDialog() == DialogResult.OK)
            {
                this.Controls.Clear();
                SetupCustomDashboard();
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(keyword) || keyword == "Tra cứu nhanh...")
            {
                try { LoadDataToGrid(ThongKeDAO.Instance.GetTopSinhVien()); } catch { }
                return;
            }

            try
            {
                DataTable dtResult = ThongKeDAO.Instance.TimKiemSinhVien(keyword);
                if (dtResult != null && dtResult.Rows.Count > 0)
                {
                    LoadDataToGrid(dtResult);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sinh viên nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgv.DataSource = null;
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tìm kiếm: " + ex.Message); }
        }

        private void lblDoanhThu_Click(object sender, EventArgs e) { }
        private void labelWelcome_Click(object sender, EventArgs e) { }
        private void FrmDashboard_Load(object sender, EventArgs e) { }
    }
}