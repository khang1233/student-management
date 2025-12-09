namespace QuanLySinhVien
{
    partial class FrmLop
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.dgvLop = new System.Windows.Forms.DataGridView();
            this.panelInput = new System.Windows.Forms.Panel();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();

            this.txbMaKhoa = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txbTenLop = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txbMaLop = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.dgvLop)).BeginInit();
            this.panelInput.SuspendLayout();
            this.SuspendLayout();

            // --- PANEL NHẬP LIỆU (Bên Phải) ---
            this.panelInput.Controls.Add(this.btnXoa);
            this.panelInput.Controls.Add(this.btnSua);
            this.panelInput.Controls.Add(this.btnThem);
            this.panelInput.Controls.Add(this.txbMaKhoa);
            this.panelInput.Controls.Add(this.label3);
            this.panelInput.Controls.Add(this.txbTenLop);
            this.panelInput.Controls.Add(this.label2);
            this.panelInput.Controls.Add(this.txbMaLop);
            this.panelInput.Controls.Add(this.label1);
            this.panelInput.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelInput.Size = new System.Drawing.Size(300, 450);
            this.panelInput.BackColor = System.Drawing.Color.WhiteSmoke;

            // Các Label và TextBox
            this.label1.AutoSize = true; this.label1.Location = new System.Drawing.Point(20, 30); this.label1.Text = "Mã Lớp:";
            this.txbMaLop.Location = new System.Drawing.Point(20, 50); this.txbMaLop.Size = new System.Drawing.Size(250, 20);

            this.label2.AutoSize = true; this.label2.Location = new System.Drawing.Point(20, 90); this.label2.Text = "Tên Lớp:";
            this.txbTenLop.Location = new System.Drawing.Point(20, 110); this.txbTenLop.Size = new System.Drawing.Size(250, 20);

            this.label3.AutoSize = true; this.label3.Location = new System.Drawing.Point(20, 150); this.label3.Text = "Mã Khoa (VD: CNTT):";
            this.txbMaKhoa.Location = new System.Drawing.Point(20, 170); this.txbMaKhoa.Size = new System.Drawing.Size(250, 20);

            // Các Nút Bấm
            this.btnThem.Text = "THÊM"; this.btnThem.Location = new System.Drawing.Point(20, 230); this.btnThem.Size = new System.Drawing.Size(80, 35); this.btnThem.BackColor = System.Drawing.Color.ForestGreen; this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);

            this.btnSua.Text = "SỬA"; this.btnSua.Location = new System.Drawing.Point(110, 230); this.btnSua.Size = new System.Drawing.Size(80, 35); this.btnSua.BackColor = System.Drawing.Color.Orange;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);

            this.btnXoa.Text = "XÓA"; this.btnXoa.Location = new System.Drawing.Point(200, 230); this.btnXoa.Size = new System.Drawing.Size(70, 35); this.btnXoa.BackColor = System.Drawing.Color.Red; this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);

            // --- GRID VIEW (Bên Trái) ---
            this.dgvLop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLop.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLop.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLop.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLop_CellClick);

            // --- FORM ---
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvLop);
            this.Controls.Add(this.panelInput);
            this.Text = "Quản Lý Lớp Học";

            ((System.ComponentModel.ISupportInitialize)(this.dgvLop)).EndInit();
            this.panelInput.ResumeLayout(false);
            this.panelInput.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridView dgvLop;
        private System.Windows.Forms.Panel panelInput;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.TextBox txbMaKhoa;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbTenLop;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbMaLop;
        private System.Windows.Forms.Label label1;
    }
}