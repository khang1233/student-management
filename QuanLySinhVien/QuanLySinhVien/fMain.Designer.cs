namespace QuanLySinhVien
{
    partial class fMain
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
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnSystem = new System.Windows.Forms.Button();
            this.btnHocPhi = new System.Windows.Forms.Button();
            this.btnDiem = new System.Windows.Forms.Button();
            this.btnMonHoc = new System.Windows.Forms.Button();
            this.btnLopHoc = new System.Windows.Forms.Button();
            this.btnGiangVien = new System.Windows.Forms.Button();
            this.btnSinhVien = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.lblLogo = new System.Windows.Forms.Label();
            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelDesktop = new System.Windows.Forms.Panel();
            this.labelWelcome = new System.Windows.Forms.Label();
            this.panelMenu.SuspendLayout();
            this.panelLogo.SuspendLayout();
            this.panelTitleBar.SuspendLayout();
            this.panelDesktop.SuspendLayout();
            this.SuspendLayout();

            // 
            // panelMenu (Menu Bên Trái)
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.panelMenu.Controls.Add(this.btnSystem);
            this.panelMenu.Controls.Add(this.btnHocPhi);
            this.panelMenu.Controls.Add(this.btnDiem);
            this.panelMenu.Controls.Add(this.btnMonHoc);
            this.panelMenu.Controls.Add(this.btnLopHoc);
            this.panelMenu.Controls.Add(this.btnGiangVien);
            this.panelMenu.Controls.Add(this.btnSinhVien);
            this.panelMenu.Controls.Add(this.panelLogo);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(220, 681);
            this.panelMenu.TabIndex = 0;

            // 
            // panelLogo (Vùng Logo góc trái trên)
            // 
            this.panelLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.panelLogo.Controls.Add(this.lblLogo);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(220, 80);
            this.panelLogo.TabIndex = 0;

            // 
            // lblLogo
            // 
            this.lblLogo.AutoSize = true;
            this.lblLogo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogo.ForeColor = System.Drawing.Color.LightGray;
            this.lblLogo.Location = new System.Drawing.Point(35, 30);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(145, 20);
            this.lblLogo.TabIndex = 0;
            this.lblLogo.Text = "QL SINH VIÊN";

            // --- CÁC NÚT MENU (Flat Design) ---

            // btnSinhVien
            this.btnSinhVien.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSinhVien.FlatAppearance.BorderSize = 0;
            this.btnSinhVien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSinhVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSinhVien.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnSinhVien.Location = new System.Drawing.Point(0, 80);
            this.btnSinhVien.Name = "btnSinhVien";
            this.btnSinhVien.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnSinhVien.Size = new System.Drawing.Size(220, 60);
            this.btnSinhVien.TabIndex = 1;
            this.btnSinhVien.Text = "   Sinh Viên";
            this.btnSinhVien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSinhVien.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSinhVien.UseVisualStyleBackColor = true;
            this.btnSinhVien.Click += new System.EventHandler(this.btnSinhVien_Click);

            // btnGiangVien
            this.btnGiangVien.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnGiangVien.FlatAppearance.BorderSize = 0;
            this.btnGiangVien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGiangVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGiangVien.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnGiangVien.Location = new System.Drawing.Point(0, 140);
            this.btnGiangVien.Name = "btnGiangVien";
            this.btnGiangVien.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnGiangVien.Size = new System.Drawing.Size(220, 60);
            this.btnGiangVien.TabIndex = 2;
            this.btnGiangVien.Text = "   Giảng Viên";
            this.btnGiangVien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGiangVien.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGiangVien.UseVisualStyleBackColor = true;
            this.btnGiangVien.Click += new System.EventHandler(this.btnGiangVien_Click);

            // btnLopHoc
            this.btnLopHoc.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLopHoc.FlatAppearance.BorderSize = 0;
            this.btnLopHoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLopHoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLopHoc.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnLopHoc.Location = new System.Drawing.Point(0, 200);
            this.btnLopHoc.Name = "btnLopHoc";
            this.btnLopHoc.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnLopHoc.Size = new System.Drawing.Size(220, 60);
            this.btnLopHoc.TabIndex = 3;
            this.btnLopHoc.Text = "   Lớp Học";
            this.btnLopHoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLopHoc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLopHoc.UseVisualStyleBackColor = true;
            this.btnLopHoc.Click += new System.EventHandler(this.btnLopHoc_Click);

            // btnMonHoc
            this.btnMonHoc.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMonHoc.FlatAppearance.BorderSize = 0;
            this.btnMonHoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMonHoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMonHoc.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnMonHoc.Location = new System.Drawing.Point(0, 260);
            this.btnMonHoc.Name = "btnMonHoc";
            this.btnMonHoc.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnMonHoc.Size = new System.Drawing.Size(220, 60);
            this.btnMonHoc.TabIndex = 4;
            this.btnMonHoc.Text = "   Môn Học";
            this.btnMonHoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMonHoc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMonHoc.UseVisualStyleBackColor = true;
            this.btnMonHoc.Click += new System.EventHandler(this.btnMonHoc_Click);

            // btnDiem
            this.btnDiem.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDiem.FlatAppearance.BorderSize = 0;
            this.btnDiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDiem.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnDiem.Location = new System.Drawing.Point(0, 320);
            this.btnDiem.Name = "btnDiem";
            this.btnDiem.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnDiem.Size = new System.Drawing.Size(220, 60);
            this.btnDiem.TabIndex = 5;
            this.btnDiem.Text = "   Kết Quả Học Tập";
            this.btnDiem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDiem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDiem.UseVisualStyleBackColor = true;
            this.btnDiem.Click += new System.EventHandler(this.btnDiem_Click);

            // btnHocPhi
            this.btnHocPhi.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHocPhi.FlatAppearance.BorderSize = 0;
            this.btnHocPhi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHocPhi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHocPhi.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnHocPhi.Location = new System.Drawing.Point(0, 380);
            this.btnHocPhi.Name = "btnHocPhi";
            this.btnHocPhi.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnHocPhi.Size = new System.Drawing.Size(220, 60);
            this.btnHocPhi.TabIndex = 6;
            this.btnHocPhi.Text = "   Học Phí";
            this.btnHocPhi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHocPhi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnHocPhi.UseVisualStyleBackColor = true;
            this.btnHocPhi.Click += new System.EventHandler(this.btnHocPhi_Click);

            // btnSystem (Hệ thống)
            this.btnSystem.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSystem.FlatAppearance.BorderSize = 0;
            this.btnSystem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSystem.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnSystem.Location = new System.Drawing.Point(0, 440);
            this.btnSystem.Name = "btnSystem";
            this.btnSystem.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnSystem.Size = new System.Drawing.Size(220, 60);
            this.btnSystem.TabIndex = 7;
            this.btnSystem.Text = "   Hệ Thống";
            this.btnSystem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSystem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSystem.UseVisualStyleBackColor = true;
            this.btnSystem.Click += new System.EventHandler(this.btnSystem_Click);

            // 
            // panelTitleBar (Thanh tiêu đề ngang)
            // 
            this.panelTitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.panelTitleBar.Controls.Add(this.lblTitle);
            this.panelTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitleBar.Location = new System.Drawing.Point(220, 0);
            this.panelTitleBar.Name = "panelTitleBar";
            this.panelTitleBar.Size = new System.Drawing.Size(964, 80);
            this.panelTitleBar.TabIndex = 1;

            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(420, 25);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(78, 26);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "HOME";

            // 
            // panelDesktop (Vùng hiển thị nội dung chính)
            // 
            this.panelDesktop.BackColor = System.Drawing.Color.White;
            this.panelDesktop.Controls.Add(this.labelWelcome);
            this.panelDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesktop.Location = new System.Drawing.Point(220, 80);
            this.panelDesktop.Name = "panelDesktop";
            this.panelDesktop.Size = new System.Drawing.Size(964, 601);
            this.panelDesktop.TabIndex = 2;

            // 
            // labelWelcome
            // 
            this.labelWelcome.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelWelcome.AutoSize = true;
            this.labelWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWelcome.ForeColor = System.Drawing.Color.Silver;
            this.labelWelcome.Location = new System.Drawing.Point(300, 250);
            this.labelWelcome.Name = "labelWelcome";
            this.labelWelcome.Size = new System.Drawing.Size(350, 31);
            this.labelWelcome.TabIndex = 1;
            this.labelWelcome.Text = "Chào mừng đến hệ thống!";

            // 
            // fMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 681);
            this.Controls.Add(this.panelDesktop);
            this.Controls.Add(this.panelTitleBar);
            this.Controls.Add(this.panelMenu);
            this.Name = "fMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Sinh Viên";
            this.panelMenu.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            this.panelLogo.PerformLayout();
            this.panelTitleBar.ResumeLayout(false);
            this.panelTitleBar.PerformLayout();
            this.panelDesktop.ResumeLayout(false);
            this.panelDesktop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button btnSinhVien;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Button btnSystem;
        private System.Windows.Forms.Button btnHocPhi;
        private System.Windows.Forms.Button btnDiem;
        private System.Windows.Forms.Button btnMonHoc;
        private System.Windows.Forms.Button btnLopHoc;
        private System.Windows.Forms.Button btnGiangVien;
        private System.Windows.Forms.Panel panelTitleBar;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Panel panelDesktop;
        private System.Windows.Forms.Label labelWelcome;
    }
}