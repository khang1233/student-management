namespace QuanLySinhVien
{
    partial class FrmDiem
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            // Khai báo biến
            this.panelLeft = new System.Windows.Forms.Panel();
            this.dgvSinhVien = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.panelRight = new System.Windows.Forms.Panel();
            this.dgvBangDiem = new System.Windows.Forms.DataGridView();
            this.panelTool = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblTenSV = new System.Windows.Forms.Label();

            // --- KHAI BÁO MỚI CHO THỐNG KÊ ---
            this.lblDiemTB = new System.Windows.Forms.Label();
            this.lblXepLoai = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.dgvSinhVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBangDiem)).BeginInit();
            this.panelLeft.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.panelTool.SuspendLayout();
            this.SuspendLayout();

            // --- CỘT TRÁI: DANH SÁCH SINH VIÊN ---
            this.panelLeft.Controls.Add(this.dgvSinhVien);
            this.panelLeft.Controls.Add(this.label1);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Size = new System.Drawing.Size(300, 500);

            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Padding = new System.Windows.Forms.Padding(10);
            this.label1.Text = "CHỌN SINH VIÊN";
            this.label1.Height = 40;

            this.dgvSinhVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSinhVien.RowHeadersVisible = false;
            this.dgvSinhVien.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSinhVien.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSinhVien.MultiSelect = false;
            // Sự kiện khi bấm vào sinh viên
            this.dgvSinhVien.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSinhVien_CellClick);

            // --- CỘT PHẢI: BẢNG ĐIỂM ---
            this.panelRight.Controls.Add(this.dgvBangDiem);
            this.panelRight.Controls.Add(this.panelTool);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Fill;

            // --- CẤU HÌNH THANH CÔNG CỤ (PANEL TOOL) ---
            this.panelTool.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTool.Height = 90; // Tăng chiều cao lên để chứa đủ thông tin
            this.panelTool.BackColor = System.Drawing.Color.WhiteSmoke;

            // Thêm các control vào panelTool
            this.panelTool.Controls.Add(this.lblXepLoai); // Mới
            this.panelTool.Controls.Add(this.lblDiemTB);  // Mới
            this.panelTool.Controls.Add(this.lblTenSV);
            this.panelTool.Controls.Add(this.btnSave);

            // Label Tên Sinh Viên
            this.lblTenSV.AutoSize = true;
            this.lblTenSV.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lblTenSV.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblTenSV.Location = new System.Drawing.Point(20, 15);
            this.lblTenSV.Text = "Vui lòng chọn sinh viên...";

            // Button Lưu
            this.btnSave.Text = "LƯU BẢNG ĐIỂM";
            this.btnSave.BackColor = System.Drawing.Color.OrangeRed;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.btnSave.Size = new System.Drawing.Size(120, 35);
            this.btnSave.Location = new System.Drawing.Point(400, 10);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // --- CẤU HÌNH LABEL THỐNG KÊ MỚI ---
            // Label Điểm Trung Bình
            this.lblDiemTB.AutoSize = true;
            this.lblDiemTB.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.lblDiemTB.ForeColor = System.Drawing.Color.Red;
            this.lblDiemTB.Location = new System.Drawing.Point(20, 50);
            this.lblDiemTB.Text = "Điểm TK: ...";

            // Label Xếp Loại
            this.lblXepLoai.AutoSize = true;
            this.lblXepLoai.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.lblXepLoai.ForeColor = System.Drawing.Color.Blue;
            this.lblXepLoai.Location = new System.Drawing.Point(200, 50);
            this.lblXepLoai.Text = "Xếp loại: ...";

            // DataGridView Bảng Điểm
            this.dgvBangDiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBangDiem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBangDiem.BackgroundColor = System.Drawing.Color.White;

            this.ClientSize = new System.Drawing.Size(900, 500);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelLeft);
            this.Name = "FrmDiem";
            this.Text = "Quản lý Điểm";

            ((System.ComponentModel.ISupportInitialize)(this.dgvSinhVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBangDiem)).EndInit();
            this.panelLeft.ResumeLayout(false);
            this.panelRight.ResumeLayout(false);
            this.panelTool.ResumeLayout(false);
            this.panelTool.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.DataGridView dgvSinhVien;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.DataGridView dgvBangDiem;
        private System.Windows.Forms.Panel panelTool;
        private System.Windows.Forms.Label lblTenSV;
        private System.Windows.Forms.Button btnSave;

        // Khai báo 2 biến mới ở đây
        private System.Windows.Forms.Label lblDiemTB;
        private System.Windows.Forms.Label lblXepLoai;
    }
}