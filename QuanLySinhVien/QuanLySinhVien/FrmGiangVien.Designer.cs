namespace QuanLySinhVien
{
    partial class FrmGiangVien
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.dgvGiangVien = new System.Windows.Forms.DataGridView();
            this.panelInput = new System.Windows.Forms.Panel();

            // Các nút chức năng
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();

            // Các ô nhập liệu
            this.txbDiaChi = new System.Windows.Forms.TextBox();
            this.labelDiaChi = new System.Windows.Forms.Label();
            this.txbEmail = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txbSDT = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();

            // [MỚI] ComboBox Giới Tính
            this.cbGioiTinh = new System.Windows.Forms.ComboBox();
            this.labelGioiTinh = new System.Windows.Forms.Label();

            this.txbHoTen = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txbMaGV = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.dgvGiangVien)).BeginInit();
            this.panelInput.SuspendLayout();
            this.SuspendLayout();

            // --- PANEL NHẬP LIỆU (Bên Phải) ---
            this.panelInput.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelInput.Size = new System.Drawing.Size(300, 500); // Tăng chiều cao xíu cho thoáng
            this.panelInput.BackColor = System.Drawing.Color.WhiteSmoke;

            // 1. Mã GV
            this.label1.AutoSize = true; this.label1.Location = new System.Drawing.Point(20, 20); this.label1.Text = "Mã Giảng Viên:";
            this.txbMaGV.Location = new System.Drawing.Point(20, 40); this.txbMaGV.Size = new System.Drawing.Size(250, 20);

            // 2. Họ Tên
            this.label2.AutoSize = true; this.label2.Location = new System.Drawing.Point(20, 70); this.label2.Text = "Họ Tên:";
            this.txbHoTen.Location = new System.Drawing.Point(20, 90); this.txbHoTen.Size = new System.Drawing.Size(250, 20);

            // 3. [MỚI] Giới Tính
            this.labelGioiTinh.AutoSize = true; this.labelGioiTinh.Location = new System.Drawing.Point(20, 120); this.labelGioiTinh.Text = "Giới Tính:";
            this.cbGioiTinh.Location = new System.Drawing.Point(20, 140); this.cbGioiTinh.Size = new System.Drawing.Size(250, 20);
            this.cbGioiTinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; // Chỉ cho chọn, không cho gõ
            this.cbGioiTinh.Items.AddRange(new object[] { "Nam", "Nữ" }); // Thêm sẵn lựa chọn

            // 4. Số Điện Thoại
            this.label3.AutoSize = true; this.label3.Location = new System.Drawing.Point(20, 170); this.label3.Text = "Số Điện Thoại:";
            this.txbSDT.Location = new System.Drawing.Point(20, 190); this.txbSDT.Size = new System.Drawing.Size(250, 20);

            // 5. Email
            this.label4.AutoSize = true; this.label4.Location = new System.Drawing.Point(20, 220); this.label4.Text = "Email:";
            this.txbEmail.Location = new System.Drawing.Point(20, 240); this.txbEmail.Size = new System.Drawing.Size(250, 20);

            // 6. [MỚI] Địa Chỉ (Thay cho Mã Khoa)
            this.labelDiaChi.AutoSize = true; this.labelDiaChi.Location = new System.Drawing.Point(20, 270); this.labelDiaChi.Text = "Địa Chỉ:";
            this.txbDiaChi.Location = new System.Drawing.Point(20, 290); this.txbDiaChi.Size = new System.Drawing.Size(250, 20);

            // --- CÁC NÚT BẤM ---
            int btnY = 340; // Vị trí Y của nút
            this.btnThem.Text = "THÊM"; this.btnThem.Location = new System.Drawing.Point(20, btnY); this.btnThem.Size = new System.Drawing.Size(80, 35); this.btnThem.BackColor = System.Drawing.Color.ForestGreen; this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);

            this.btnSua.Text = "SỬA"; this.btnSua.Location = new System.Drawing.Point(110, btnY); this.btnSua.Size = new System.Drawing.Size(80, 35); this.btnSua.BackColor = System.Drawing.Color.Orange;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);

            this.btnXoa.Text = "XÓA"; this.btnXoa.Location = new System.Drawing.Point(200, btnY); this.btnXoa.Size = new System.Drawing.Size(70, 35); this.btnXoa.BackColor = System.Drawing.Color.Red; this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);

            // Add control vào panel
            this.panelInput.Controls.Add(this.btnXoa); this.panelInput.Controls.Add(this.btnSua); this.panelInput.Controls.Add(this.btnThem);
            this.panelInput.Controls.Add(this.txbDiaChi); this.panelInput.Controls.Add(this.labelDiaChi);
            this.panelInput.Controls.Add(this.txbEmail); this.panelInput.Controls.Add(this.label4);
            this.panelInput.Controls.Add(this.txbSDT); this.panelInput.Controls.Add(this.label3);
            this.panelInput.Controls.Add(this.cbGioiTinh); this.panelInput.Controls.Add(this.labelGioiTinh);
            this.panelInput.Controls.Add(this.txbHoTen); this.panelInput.Controls.Add(this.label2);
            this.panelInput.Controls.Add(this.txbMaGV); this.panelInput.Controls.Add(this.label1);

            // --- GRID VIEW (Bên Trái) ---
            this.dgvGiangVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGiangVien.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGiangVien.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // Sự kiện CellClick đã được gán tự động nếu bên code logic có hàm dgvGiangVien_CellClick
            this.dgvGiangVien.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGiangVien_CellClick);

            // --- FORM ---
            this.ClientSize = new System.Drawing.Size(900, 500);
            this.Controls.Add(this.dgvGiangVien);
            this.Controls.Add(this.panelInput);
            this.Text = "Quản Lý Giảng Viên";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen; // Hiện giữa màn hình

            ((System.ComponentModel.ISupportInitialize)(this.dgvGiangVien)).EndInit();
            this.panelInput.ResumeLayout(false);
            this.panelInput.PerformLayout();
            this.ResumeLayout(false);
        }

        // Khai báo biến (Đã cập nhật tên biến mới)
        private System.Windows.Forms.DataGridView dgvGiangVien;
        private System.Windows.Forms.Panel panelInput;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;

        private System.Windows.Forms.TextBox txbDiaChi; // Thay cho MaKhoa
        private System.Windows.Forms.Label labelDiaChi;
        private System.Windows.Forms.TextBox txbEmail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txbSDT;
        private System.Windows.Forms.Label label3;

        private System.Windows.Forms.ComboBox cbGioiTinh; // Mới
        private System.Windows.Forms.Label labelGioiTinh; // Mới

        private System.Windows.Forms.TextBox txbHoTen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbMaGV;
        private System.Windows.Forms.Label label1;
    }
}