namespace QuanLySinhVien
{
    partial class Form1
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
            this.labelWelcome = new System.Windows.Forms.Label();
            this.labelAppName = new System.Windows.Forms.Label();
            this.panelRight = new System.Windows.Forms.Panel();
            this.groupBoxRole = new System.Windows.Forms.GroupBox();
            this.rdoHocSinh = new System.Windows.Forms.RadioButton();
            this.rdoGiaoVien = new System.Windows.Forms.RadioButton();
            this.rdoAdmin = new System.Windows.Forms.RadioButton();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.panelPass = new System.Windows.Forms.Panel();
            this.txbPassWord = new System.Windows.Forms.TextBox();
            this.panelUser = new System.Windows.Forms.Panel();
            this.txbUserName = new System.Windows.Forms.TextBox();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelUser = new System.Windows.Forms.Label();
            this.labelPass = new System.Windows.Forms.Label();
            this.panelLeft.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.groupBoxRole.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.panelLeft.Controls.Add(this.labelWelcome);
            this.panelLeft.Controls.Add(this.labelAppName);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(500, 846);
            this.panelLeft.TabIndex = 0;
            // 
            // labelWelcome
            // 
            this.labelWelcome.AutoSize = true;
            this.labelWelcome.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWelcome.ForeColor = System.Drawing.Color.White;
            this.labelWelcome.Location = new System.Drawing.Point(150, 406);
            this.labelWelcome.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelWelcome.Name = "labelWelcome";
            this.labelWelcome.Size = new System.Drawing.Size(238, 34);
            this.labelWelcome.TabIndex = 1;
            this.labelWelcome.Text = "Chào mừng bạn";
            // 
            // labelAppName
            // 
            this.labelAppName.AutoSize = true;
            this.labelAppName.Font = new System.Drawing.Font("Century Gothic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAppName.ForeColor = System.Drawing.Color.White;
            this.labelAppName.Location = new System.Drawing.Point(83, 338);
            this.labelAppName.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelAppName.Name = "labelAppName";
            this.labelAppName.Size = new System.Drawing.Size(358, 44);
            this.labelAppName.TabIndex = 0;
            this.labelAppName.Text = "QUẢN LÝ SINH VIÊN";
            // 
            // panelRight
            // 
            this.panelRight.Controls.Add(this.groupBoxRole);
            this.panelRight.Controls.Add(this.btnClose);
            this.panelRight.Controls.Add(this.btnLogin);
            this.panelRight.Controls.Add(this.panelPass);
            this.panelRight.Controls.Add(this.txbPassWord);
            this.panelRight.Controls.Add(this.panelUser);
            this.panelRight.Controls.Add(this.txbUserName);
            this.panelRight.Controls.Add(this.labelTitle);
            this.panelRight.Controls.Add(this.labelUser);
            this.panelRight.Controls.Add(this.labelPass);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRight.Location = new System.Drawing.Point(500, 0);
            this.panelRight.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(750, 846);
            this.panelRight.TabIndex = 1;
            // 
            // groupBoxRole
            // 
            this.groupBoxRole.Controls.Add(this.rdoHocSinh);
            this.groupBoxRole.Controls.Add(this.rdoGiaoVien);
            this.groupBoxRole.Controls.Add(this.rdoAdmin);
            this.groupBoxRole.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxRole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.groupBoxRole.Location = new System.Drawing.Point(75, 448);
            this.groupBoxRole.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.groupBoxRole.Name = "groupBoxRole";
            this.groupBoxRole.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.groupBoxRole.Size = new System.Drawing.Size(617, 93);
            this.groupBoxRole.TabIndex = 3;
            this.groupBoxRole.TabStop = false;
            this.groupBoxRole.Text = "Chọn vai trò";
            this.groupBoxRole.Enter += new System.EventHandler(this.groupBoxRole_Enter);
            // 
            // rdoHocSinh
            // 
            this.rdoHocSinh.AutoSize = true;
            this.rdoHocSinh.Location = new System.Drawing.Point(400, 37);
            this.rdoHocSinh.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.rdoHocSinh.Name = "rdoHocSinh";
            this.rdoHocSinh.Size = new System.Drawing.Size(119, 28);
            this.rdoHocSinh.TabIndex = 2;
            this.rdoHocSinh.TabStop = true;
            this.rdoHocSinh.Text = "Học Sinh";
            this.rdoHocSinh.UseVisualStyleBackColor = true;
            // 
            // rdoGiaoVien
            // 
            this.rdoGiaoVien.AutoSize = true;
            this.rdoGiaoVien.Location = new System.Drawing.Point(200, 37);
            this.rdoGiaoVien.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.rdoGiaoVien.Name = "rdoGiaoVien";
            this.rdoGiaoVien.Size = new System.Drawing.Size(135, 28);
            this.rdoGiaoVien.TabIndex = 1;
            this.rdoGiaoVien.TabStop = true;
            this.rdoGiaoVien.Text = "Giáo Viên";
            this.rdoGiaoVien.UseVisualStyleBackColor = true;
            // 
            // rdoAdmin
            // 
            this.rdoAdmin.AutoSize = true;
            this.rdoAdmin.Location = new System.Drawing.Point(33, 37);
            this.rdoAdmin.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.rdoAdmin.Name = "rdoAdmin";
            this.rdoAdmin.Size = new System.Drawing.Size(101, 28);
            this.rdoAdmin.TabIndex = 0;
            this.rdoAdmin.TabStop = true;
            this.rdoAdmin.Text = "Admin";
            this.rdoAdmin.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnClose.Location = new System.Drawing.Point(683, 0);
            this.btnClose.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(67, 68);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(75, 575);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(247, 59);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "ĐĂNG NHẬP";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // panelPass
            // 
            this.panelPass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.panelPass.Location = new System.Drawing.Point(75, 423);
            this.panelPass.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.panelPass.Name = "panelPass";
            this.panelPass.Size = new System.Drawing.Size(617, 3);
            this.panelPass.TabIndex = 5;
            // 
            // txbPassWord
            // 
            this.txbPassWord.BackColor = System.Drawing.SystemColors.Control;
            this.txbPassWord.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbPassWord.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbPassWord.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.txbPassWord.Location = new System.Drawing.Point(75, 381);
            this.txbPassWord.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txbPassWord.Name = "txbPassWord";
            this.txbPassWord.Size = new System.Drawing.Size(617, 28);
            this.txbPassWord.TabIndex = 2;
            this.txbPassWord.UseSystemPasswordChar = true;
            // 
            // panelUser
            // 
            this.panelUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.panelUser.Location = new System.Drawing.Point(75, 305);
            this.panelUser.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.panelUser.Name = "panelUser";
            this.panelUser.Size = new System.Drawing.Size(617, 3);
            this.panelUser.TabIndex = 3;
            // 
            // txbUserName
            // 
            this.txbUserName.BackColor = System.Drawing.SystemColors.Control;
            this.txbUserName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbUserName.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbUserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.txbUserName.Location = new System.Drawing.Point(75, 262);
            this.txbUserName.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txbUserName.Name = "txbUserName";
            this.txbUserName.Size = new System.Drawing.Size(617, 34);
            this.txbUserName.TabIndex = 1;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.labelTitle.Location = new System.Drawing.Point(63, 85);
            this.labelTitle.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(432, 43);
            this.labelTitle.TabIndex = 1;
            this.labelTitle.Text = "ĐĂNG NHẬP HỆ THỐNG";
            // 
            // labelUser
            // 
            this.labelUser.AutoSize = true;
            this.labelUser.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.labelUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.labelUser.Location = new System.Drawing.Point(67, 220);
            this.labelUser.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(185, 27);
            this.labelUser.TabIndex = 6;
            this.labelUser.Text = "Tên đăng nhập:";
            // 
            // labelPass
            // 
            this.labelPass.AutoSize = true;
            this.labelPass.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.labelPass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.labelPass.Location = new System.Drawing.Point(67, 338);
            this.labelPass.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelPass.Name = "labelPass";
            this.labelPass.Size = new System.Drawing.Size(115, 27);
            this.labelPass.TabIndex = 7;
            this.labelPass.Text = "Mật khẩu:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1250, 846);
            this.ControlBox = false;
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelLeft);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.panelLeft.ResumeLayout(false);
            this.panelLeft.PerformLayout();
            this.panelRight.ResumeLayout(false);
            this.panelRight.PerformLayout();
            this.groupBoxRole.ResumeLayout(false);
            this.groupBoxRole.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Label labelAppName;
        private System.Windows.Forms.Label labelWelcome;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.Label labelPass;
        private System.Windows.Forms.TextBox txbUserName;
        private System.Windows.Forms.TextBox txbPassWord;
        private System.Windows.Forms.Panel panelUser;
        private System.Windows.Forms.Panel panelPass;
        private System.Windows.Forms.Button btnLogin;

        // --- CÁC BIẾN MỚI THÊM VÀO ---
        private System.Windows.Forms.GroupBox groupBoxRole;
        private System.Windows.Forms.RadioButton rdoHocSinh;
        private System.Windows.Forms.RadioButton rdoGiaoVien;
        private System.Windows.Forms.RadioButton rdoAdmin;
    }
}