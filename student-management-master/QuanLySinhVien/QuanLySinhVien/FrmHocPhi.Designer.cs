namespace QuanLySinhVien
{
    partial class FrmHocPhi
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            // --- 1. KHỞI TẠO CÁC CONTROL ---
            this.panelLeft = new System.Windows.Forms.Panel();
            this.dgvSinhVien = new System.Windows.Forms.DataGridView();
            this.labelTitleLeft = new System.Windows.Forms.Label();

            this.panelRight = new System.Windows.Forms.Panel();
            this.panelTool = new System.Windows.Forms.Panel();
            this.lblTenSV = new System.Windows.Forms.Label();

            // Các label hiển thị tiền
            this.lblTongHP = new System.Windows.Forms.Label();
            this.lblDaDong = new System.Windows.Forms.Label();
            this.lblConNo = new System.Windows.Forms.Label();

            // Khu vực nhập liệu thanh toán
            this.labelHuongDan = new System.Windows.Forms.Label();
            this.txbSoTienDong = new System.Windows.Forms.TextBox();
            this.btnXacNhanDong = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvSinhVien)).BeginInit();
            this.panelLeft.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.panelTool.SuspendLayout();
            this.SuspendLayout();

            // 
            // --- 2. CẤU HÌNH PANEL TRÁI (DANH SÁCH SINH VIÊN) ---
            // 
            this.panelLeft.Controls.Add(this.dgvSinhVien);
            this.panelLeft.Controls.Add(this.labelTitleLeft);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Size = new System.Drawing.Size(300, 450);

            // Label Tiêu đề trái
            this.labelTitleLeft.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelTitleLeft.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.labelTitleLeft.Padding = new System.Windows.Forms.Padding(10);
            this.labelTitleLeft.Text = "CHỌN SINH VIÊN";
            this.labelTitleLeft.Height = 40;
            this.labelTitleLeft.BackColor = System.Drawing.Color.WhiteSmoke;

            // DataGridView Sinh Viên
            this.dgvSinhVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSinhVien.RowHeadersVisible = false;
            this.dgvSinhVien.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSinhVien.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSinhVien.MultiSelect = false;
            this.dgvSinhVien.BackgroundColor = System.Drawing.Color.White;
            // Gắn sự kiện click
            this.dgvSinhVien.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSinhVien_CellClick);

            // 
            // --- 3. CẤU HÌNH PANEL PHẢI (THÔNG TIN HỌC PHÍ) ---
            // 
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRight.BackColor = System.Drawing.Color.White;

            // Thanh tiêu đề chứa tên SV
            this.panelTool.Controls.Add(this.lblTenSV);
            this.panelTool.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTool.Height = 60;
            this.panelTool.BackColor = System.Drawing.Color.WhiteSmoke;

            this.lblTenSV.AutoSize = true;
            this.lblTenSV.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.lblTenSV.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblTenSV.Location = new System.Drawing.Point(20, 18);
            this.lblTenSV.Text = "Vui lòng chọn sinh viên...";

            // Cấu hình các Label hiển thị tiền
            // Tổng học phí
            this.lblTongHP.AutoSize = true;
            this.lblTongHP.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lblTongHP.Location = new System.Drawing.Point(40, 100);
            this.lblTongHP.Text = "Tổng Học Phí: ...";

            // Đã đóng (Màu xanh)
            this.lblDaDong.AutoSize = true;
            this.lblDaDong.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lblDaDong.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblDaDong.Location = new System.Drawing.Point(40, 140);
            this.lblDaDong.Text = "Đã Đóng: ...";

            // Còn nợ (Màu đỏ)
            this.lblConNo.AutoSize = true;
            this.lblConNo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lblConNo.ForeColor = System.Drawing.Color.Red;
            this.lblConNo.Location = new System.Drawing.Point(40, 180);
            this.lblConNo.Text = "Còn Nợ: ...";

            // Khu vực thanh toán
            this.labelHuongDan.AutoSize = true;
            this.labelHuongDan.Location = new System.Drawing.Point(40, 250);
            this.labelHuongDan.Text = "Nhập số tiền muốn thanh toán:";
            this.labelHuongDan.Font = new System.Drawing.Font("Arial", 10F);

            this.txbSoTienDong.Location = new System.Drawing.Point(44, 280);
            this.txbSoTienDong.Size = new System.Drawing.Size(250, 30);
            this.txbSoTienDong.Font = new System.Drawing.Font("Arial", 12F);

            this.btnXacNhanDong.Text = "THANH TOÁN";
            this.btnXacNhanDong.Location = new System.Drawing.Point(310, 275);
            this.btnXacNhanDong.Size = new System.Drawing.Size(120, 40);
            this.btnXacNhanDong.BackColor = System.Drawing.Color.Teal;
            this.btnXacNhanDong.ForeColor = System.Drawing.Color.White;
            this.btnXacNhanDong.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            // Gắn sự kiện click nút thanh toán
            this.btnXacNhanDong.Click += new System.EventHandler(this.btnXacNhanDong_Click);

            // Add các control vào Panel Phải
            this.panelRight.Controls.Add(this.panelTool);
            this.panelRight.Controls.Add(this.lblTongHP);
            this.panelRight.Controls.Add(this.lblDaDong);
            this.panelRight.Controls.Add(this.lblConNo);
            this.panelRight.Controls.Add(this.labelHuongDan);
            this.panelRight.Controls.Add(this.txbSoTienDong);
            this.panelRight.Controls.Add(this.btnXacNhanDong);

            // 
            // --- 4. CẤU HÌNH FORM CHÍNH ---
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelRight); // Add Phải
            this.Controls.Add(this.panelLeft);  // Add Trái
            this.Name = "FrmHocPhi";
            this.Text = "Quản Lý Học Phí";

            ((System.ComponentModel.ISupportInitialize)(this.dgvSinhVien)).EndInit();
            this.panelLeft.ResumeLayout(false);
            this.panelRight.ResumeLayout(false);
            this.panelRight.PerformLayout();
            this.panelTool.ResumeLayout(false);
            this.panelTool.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        // Khai báo các biến Control (Để dùng bên file .cs)
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.DataGridView dgvSinhVien;
        private System.Windows.Forms.Label labelTitleLeft;

        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Panel panelTool;
        private System.Windows.Forms.Label lblTenSV;

        private System.Windows.Forms.Label lblTongHP;
        private System.Windows.Forms.Label lblDaDong;
        private System.Windows.Forms.Label lblConNo;

        private System.Windows.Forms.Label labelHuongDan;
        private System.Windows.Forms.TextBox txbSoTienDong;
        private System.Windows.Forms.Button btnXacNhanDong;
    }
}