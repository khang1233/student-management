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
            this.panelLeft = new System.Windows.Forms.Panel();
            this.dgvSinhVien = new System.Windows.Forms.DataGridView();
            this.labelTitleLeft = new System.Windows.Forms.Label();
            this.panelRight = new System.Windows.Forms.Panel();
            this.panelTool = new System.Windows.Forms.Panel();
            this.lblTenSV = new System.Windows.Forms.Label();
            this.lblTongHP = new System.Windows.Forms.Label();
            this.lblDaDong = new System.Windows.Forms.Label();
            this.lblConNo = new System.Windows.Forms.Label();
            this.labelHuongDan = new System.Windows.Forms.Label();
            this.txbSoTienDong = new System.Windows.Forms.TextBox();
            this.btnXacNhanDong = new System.Windows.Forms.Button();
            this.panelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSinhVien)).BeginInit();
            this.panelRight.SuspendLayout();
            this.panelTool.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLeft
            // 
            this.panelLeft.Controls.Add(this.dgvSinhVien);
            this.panelLeft.Controls.Add(this.labelTitleLeft);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Margin = new System.Windows.Forms.Padding(5);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(500, 762);
            this.panelLeft.TabIndex = 1;
            // 
            // dgvSinhVien
            // 
            this.dgvSinhVien.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSinhVien.BackgroundColor = System.Drawing.Color.White;
            this.dgvSinhVien.ColumnHeadersHeight = 39;
            this.dgvSinhVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSinhVien.Location = new System.Drawing.Point(0, 68);
            this.dgvSinhVien.Margin = new System.Windows.Forms.Padding(5);
            this.dgvSinhVien.MultiSelect = false;
            this.dgvSinhVien.Name = "dgvSinhVien";
            this.dgvSinhVien.RowHeadersVisible = false;
            this.dgvSinhVien.RowHeadersWidth = 70;
            this.dgvSinhVien.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSinhVien.Size = new System.Drawing.Size(500, 694);
            this.dgvSinhVien.TabIndex = 0;
            this.dgvSinhVien.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSinhVien_CellClick);
            // 
            // labelTitleLeft
            // 
            this.labelTitleLeft.BackColor = System.Drawing.Color.WhiteSmoke;
            this.labelTitleLeft.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelTitleLeft.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.labelTitleLeft.Location = new System.Drawing.Point(0, 0);
            this.labelTitleLeft.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelTitleLeft.Name = "labelTitleLeft";
            this.labelTitleLeft.Padding = new System.Windows.Forms.Padding(17);
            this.labelTitleLeft.Size = new System.Drawing.Size(500, 68);
            this.labelTitleLeft.TabIndex = 1;
            this.labelTitleLeft.Text = "CHỌN SINH VIÊN";
            // 
            // panelRight
            // 
            this.panelRight.BackColor = System.Drawing.Color.White;
            this.panelRight.Controls.Add(this.panelTool);
            this.panelRight.Controls.Add(this.lblTongHP);
            this.panelRight.Controls.Add(this.lblDaDong);
            this.panelRight.Controls.Add(this.lblConNo);
            this.panelRight.Controls.Add(this.labelHuongDan);
            this.panelRight.Controls.Add(this.txbSoTienDong);
            this.panelRight.Controls.Add(this.btnXacNhanDong);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRight.Location = new System.Drawing.Point(500, 0);
            this.panelRight.Margin = new System.Windows.Forms.Padding(5);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(833, 762);
            this.panelRight.TabIndex = 0;
            // 
            // panelTool
            // 
            this.panelTool.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelTool.Controls.Add(this.lblTenSV);
            this.panelTool.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTool.Location = new System.Drawing.Point(0, 0);
            this.panelTool.Margin = new System.Windows.Forms.Padding(5);
            this.panelTool.Name = "panelTool";
            this.panelTool.Size = new System.Drawing.Size(833, 102);
            this.panelTool.TabIndex = 0;
            // 
            // lblTenSV
            // 
            this.lblTenSV.AutoSize = true;
            this.lblTenSV.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.lblTenSV.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblTenSV.Location = new System.Drawing.Point(33, 30);
            this.lblTenSV.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTenSV.Name = "lblTenSV";
            this.lblTenSV.Size = new System.Drawing.Size(401, 37);
            this.lblTenSV.TabIndex = 0;
            this.lblTenSV.Text = "Vui lòng chọn sinh viên...";
            // 
            // lblTongHP
            // 
            this.lblTongHP.AutoSize = true;
            this.lblTongHP.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lblTongHP.Location = new System.Drawing.Point(67, 169);
            this.lblTongHP.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTongHP.Name = "lblTongHP";
            this.lblTongHP.Size = new System.Drawing.Size(238, 33);
            this.lblTongHP.TabIndex = 1;
            this.lblTongHP.Text = "Tổng Học Phí: ...";
            // 
            // lblDaDong
            // 
            this.lblDaDong.AutoSize = true;
            this.lblDaDong.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lblDaDong.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblDaDong.Location = new System.Drawing.Point(67, 237);
            this.lblDaDong.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblDaDong.Name = "lblDaDong";
            this.lblDaDong.Size = new System.Drawing.Size(172, 33);
            this.lblDaDong.TabIndex = 2;
            this.lblDaDong.Text = "Đã Đóng: ...";
            // 
            // lblConNo
            // 
            this.lblConNo.AutoSize = true;
            this.lblConNo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lblConNo.ForeColor = System.Drawing.Color.Red;
            this.lblConNo.Location = new System.Drawing.Point(67, 305);
            this.lblConNo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblConNo.Name = "lblConNo";
            this.lblConNo.Size = new System.Drawing.Size(159, 33);
            this.lblConNo.TabIndex = 3;
            this.lblConNo.Text = "Còn Nợ: ...";
            // 
            // labelHuongDan
            // 
            this.labelHuongDan.AutoSize = true;
            this.labelHuongDan.Font = new System.Drawing.Font("Arial", 10F);
            this.labelHuongDan.Location = new System.Drawing.Point(67, 423);
            this.labelHuongDan.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelHuongDan.Name = "labelHuongDan";
            this.labelHuongDan.Size = new System.Drawing.Size(317, 26);
            this.labelHuongDan.TabIndex = 4;
            this.labelHuongDan.Text = "Nhập số tiền muốn thanh toán:";
            // 
            // txbSoTienDong
            // 
            this.txbSoTienDong.Font = new System.Drawing.Font("Arial", 12F);
            this.txbSoTienDong.Location = new System.Drawing.Point(73, 474);
            this.txbSoTienDong.Margin = new System.Windows.Forms.Padding(5);
            this.txbSoTienDong.Name = "txbSoTienDong";
            this.txbSoTienDong.Size = new System.Drawing.Size(414, 39);
            this.txbSoTienDong.TabIndex = 5;
            // 
            // btnXacNhanDong
            // 
            this.btnXacNhanDong.BackColor = System.Drawing.Color.Teal;
            this.btnXacNhanDong.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.btnXacNhanDong.ForeColor = System.Drawing.Color.White;
            this.btnXacNhanDong.Location = new System.Drawing.Point(517, 465);
            this.btnXacNhanDong.Margin = new System.Windows.Forms.Padding(5);
            this.btnXacNhanDong.Name = "btnXacNhanDong";
            this.btnXacNhanDong.Size = new System.Drawing.Size(200, 68);
            this.btnXacNhanDong.TabIndex = 6;
            this.btnXacNhanDong.Text = "THANH TOÁN";
            this.btnXacNhanDong.UseVisualStyleBackColor = false;
            this.btnXacNhanDong.Click += new System.EventHandler(this.btnXacNhanDong_Click);
            // 
            // FrmHocPhi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1333, 762);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelLeft);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "FrmHocPhi";
            this.Text = "Quản Lý Học Phí";
            this.Load += new System.EventHandler(this.FrmHocPhi_Load);
            this.panelLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSinhVien)).EndInit();
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