namespace QuanLySinhVien
{
    partial class FrmThemSinhVien
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.labelTitle = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txbMaLop = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txbEmail = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txbSDT = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txbDiaChi = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbGioiTinh = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txbHoTen = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txbMaSV = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();

            // labelTitle
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.labelTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.labelTitle.Location = new System.Drawing.Point(130, 20);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(184, 24);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "THÊM SINH VIÊN";

            // panel1 (Chứa các ô nhập liệu)
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txbMaLop);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txbEmail);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txbSDT);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txbDiaChi);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cbGioiTinh);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.dtpNgaySinh);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txbHoTen);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txbMaSV);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(20, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 350);
            this.panel1.TabIndex = 1;

            // Define Label & TextBox pairs (Code rút gọn cho đỡ dài)
            // 1. MaSV
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Text = "Mã Sinh Viên:";
            this.label1.AutoSize = true;
            this.txbMaSV.Location = new System.Drawing.Point(120, 17);
            this.txbMaSV.Size = new System.Drawing.Size(250, 20);

            // 2. HoTen
            this.label2.Location = new System.Drawing.Point(20, 60);
            this.label2.Text = "Họ Tên:";
            this.label2.AutoSize = true;
            this.txbHoTen.Location = new System.Drawing.Point(120, 57);
            this.txbHoTen.Size = new System.Drawing.Size(250, 20);

            // 3. NgaySinh
            this.label3.Location = new System.Drawing.Point(20, 100);
            this.label3.Text = "Ngày Sinh:";
            this.label3.AutoSize = true;
            this.dtpNgaySinh.Location = new System.Drawing.Point(120, 97);
            this.dtpNgaySinh.Size = new System.Drawing.Size(250, 20);
            this.dtpNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Short;

            // 4. GioiTinh
            this.label4.Location = new System.Drawing.Point(20, 140);
            this.label4.Text = "Giới Tính:";
            this.label4.AutoSize = true;
            this.cbGioiTinh.Location = new System.Drawing.Point(120, 137);
            this.cbGioiTinh.Size = new System.Drawing.Size(100, 21);
            this.cbGioiTinh.Items.AddRange(new object[] { "Nam", "Nữ" });
            this.cbGioiTinh.SelectedIndex = 0;

            // 5. DiaChi
            this.label5.Location = new System.Drawing.Point(20, 180);
            this.label5.Text = "Địa Chỉ:";
            this.label5.AutoSize = true;
            this.txbDiaChi.Location = new System.Drawing.Point(120, 177);
            this.txbDiaChi.Size = new System.Drawing.Size(250, 20);

            // 6. SDT
            this.label6.Location = new System.Drawing.Point(20, 220);
            this.label6.Text = "Số ĐT:";
            this.label6.AutoSize = true;
            this.txbSDT.Location = new System.Drawing.Point(120, 217);
            this.txbSDT.Size = new System.Drawing.Size(250, 20);

            // 7. Email
            this.label7.Location = new System.Drawing.Point(20, 260);
            this.label7.Text = "Email:";
            this.label7.AutoSize = true;
            this.txbEmail.Location = new System.Drawing.Point(120, 257);
            this.txbEmail.Size = new System.Drawing.Size(250, 20);

            // 8. MaLop
            this.label8.Location = new System.Drawing.Point(20, 300);
            this.label8.Text = "Mã Lớp:";
            this.label8.AutoSize = true;
            this.txbMaLop.Location = new System.Drawing.Point(120, 297);
            this.txbMaLop.Size = new System.Drawing.Size(250, 20);

            // btnSave
            this.btnSave.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(120, 430);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 35);
            this.btnSave.Text = "LƯU";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // btnCancel
            this.btnCancel.BackColor = System.Drawing.Color.Gray;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(240, 430);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 35);
            this.btnCancel.Text = "HỦY";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // FrmThemSinhVien
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(450, 500);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmThemSinhVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thêm mới";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txbMaSV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbHoTen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpNgaySinh;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbGioiTinh;
        private System.Windows.Forms.TextBox txbDiaChi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txbSDT;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txbEmail;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txbMaLop;
        private System.Windows.Forms.Label label8;
    }
}