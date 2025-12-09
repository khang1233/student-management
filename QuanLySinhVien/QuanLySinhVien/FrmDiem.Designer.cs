namespace QuanLySinhVien
{
    partial class FrmDiem
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.panelLeft = new System.Windows.Forms.Panel();
            this.dgvSinhVien = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.panelRight = new System.Windows.Forms.Panel();
            this.dgvBangDiem = new System.Windows.Forms.DataGridView();
            this.panelTool = new System.Windows.Forms.Panel();
            this.lblXepLoai = new System.Windows.Forms.Label();
            this.lblDiemTB = new System.Windows.Forms.Label();
            this.lblTenSV = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.panelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSinhVien)).BeginInit();
            this.panelRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBangDiem)).BeginInit();
            this.panelTool.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLeft
            // 
            this.panelLeft.Controls.Add(this.dgvSinhVien);
            this.panelLeft.Controls.Add(this.label1);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(300, 500);
            this.panelLeft.TabIndex = 1;
            // 
            // dgvSinhVien
            // 
            this.dgvSinhVien.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSinhVien.ColumnHeadersHeight = 39;
            this.dgvSinhVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSinhVien.Location = new System.Drawing.Point(0, 40);
            this.dgvSinhVien.MultiSelect = false;
            this.dgvSinhVien.Name = "dgvSinhVien";
            this.dgvSinhVien.RowHeadersVisible = false;
            this.dgvSinhVien.RowHeadersWidth = 70;
            this.dgvSinhVien.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSinhVien.Size = new System.Drawing.Size(300, 460);
            this.dgvSinhVien.TabIndex = 0;
            this.dgvSinhVien.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSinhVien_CellClick);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(10);
            this.label1.Size = new System.Drawing.Size(300, 40);
            this.label1.TabIndex = 1;
            this.label1.Text = "CHỌN SINH VIÊN";
            // 
            // panelRight
            // 
            this.panelRight.Controls.Add(this.dgvBangDiem);
            this.panelRight.Controls.Add(this.panelTool);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRight.Location = new System.Drawing.Point(300, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(600, 500);
            this.panelRight.TabIndex = 0;
            // 
            // dgvBangDiem
            // 
            this.dgvBangDiem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBangDiem.BackgroundColor = System.Drawing.Color.White;
            this.dgvBangDiem.ColumnHeadersHeight = 39;
            this.dgvBangDiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBangDiem.Location = new System.Drawing.Point(0, 90);
            this.dgvBangDiem.Name = "dgvBangDiem";
            this.dgvBangDiem.RowHeadersWidth = 70;
            this.dgvBangDiem.Size = new System.Drawing.Size(600, 410);
            this.dgvBangDiem.TabIndex = 0;
            // 
            // panelTool
            // 
            this.panelTool.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelTool.Controls.Add(this.lblXepLoai);
            this.panelTool.Controls.Add(this.lblDiemTB);
            this.panelTool.Controls.Add(this.lblTenSV);
            this.panelTool.Controls.Add(this.btnSave);
            this.panelTool.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTool.Location = new System.Drawing.Point(0, 0);
            this.panelTool.Name = "panelTool";
            this.panelTool.Size = new System.Drawing.Size(600, 90);
            this.panelTool.TabIndex = 1;
            // 
            // lblXepLoai
            // 
            this.lblXepLoai.AutoSize = true;
            this.lblXepLoai.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.lblXepLoai.ForeColor = System.Drawing.Color.Blue;
            this.lblXepLoai.Location = new System.Drawing.Point(200, 50);
            this.lblXepLoai.Name = "lblXepLoai";
            this.lblXepLoai.Size = new System.Drawing.Size(144, 30);
            this.lblXepLoai.TabIndex = 0;
            this.lblXepLoai.Text = "Xếp loại: ...";
            // 
            // lblDiemTB
            // 
            this.lblDiemTB.AutoSize = true;
            this.lblDiemTB.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.lblDiemTB.ForeColor = System.Drawing.Color.Red;
            this.lblDiemTB.Location = new System.Drawing.Point(20, 50);
            this.lblDiemTB.Name = "lblDiemTB";
            this.lblDiemTB.Size = new System.Drawing.Size(148, 30);
            this.lblDiemTB.TabIndex = 1;
            this.lblDiemTB.Text = "Điểm TK: ...";
            // 
            // lblTenSV
            // 
            this.lblTenSV.AutoSize = true;
            this.lblTenSV.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lblTenSV.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblTenSV.Location = new System.Drawing.Point(20, 15);
            this.lblTenSV.Name = "lblTenSV";
            this.lblTenSV.Size = new System.Drawing.Size(353, 33);
            this.lblTenSV.TabIndex = 2;
            this.lblTenSV.Text = "Vui lòng chọn sinh viên...";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.OrangeRed;
            this.btnSave.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(400, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 35);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "LƯU BẢNG ĐIỂM";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FrmDiem
            // 
            this.ClientSize = new System.Drawing.Size(900, 500);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelLeft);
            this.Name = "FrmDiem";
            this.Text = "Quản lý Điểm";
            this.Load += new System.EventHandler(this.FrmDiem_Load);
            this.panelLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSinhVien)).EndInit();
            this.panelRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBangDiem)).EndInit();
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