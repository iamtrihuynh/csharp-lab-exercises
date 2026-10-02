namespace CourseRegistrationApp
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkNhanEmail = new System.Windows.Forms.CheckBox();
            this.dtpNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.txtSoDienThoai = new System.Windows.Forms.TextBox();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.lblNgaySinh = new System.Windows.Forms.Label();
            this.lblSoDienThoai = new System.Windows.Forms.Label();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.groupBox_KhoaHoc = new System.Windows.Forms.GroupBox();
            this.txtTongTien = new System.Windows.Forms.Label();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.txtSoThangDK = new System.Windows.Forms.Label();
            this.numSoThang = new System.Windows.Forms.NumericUpDown();
            this.radOffline = new System.Windows.Forms.RadioButton();
            this.radOnline = new System.Windows.Forms.RadioButton();
            this.txtChonHinhThuc = new System.Windows.Forms.Label();
            this.txtChonKhoaHoc = new System.Windows.Forms.Label();
            this.cboKhoaHoc = new System.Windows.Forms.ComboBox();
            this.btnDangKy = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox_KhoaHoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSoThang)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkNhanEmail);
            this.groupBox1.Controls.Add(this.dtpNgaySinh);
            this.groupBox1.Controls.Add(this.txtSoDienThoai);
            this.groupBox1.Controls.Add(this.txtHoTen);
            this.groupBox1.Controls.Add(this.lblNgaySinh);
            this.groupBox1.Controls.Add(this.lblSoDienThoai);
            this.groupBox1.Controls.Add(this.lblHoTen);
            this.groupBox1.Location = new System.Drawing.Point(20, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(408, 194);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thong tin hoc vien ";
            // 
            // chkNhanEmail
            // 
            this.chkNhanEmail.AutoSize = true;
            this.chkNhanEmail.Location = new System.Drawing.Point(116, 146);
            this.chkNhanEmail.Name = "chkNhanEmail";
            this.chkNhanEmail.Size = new System.Drawing.Size(161, 20);
            this.chkNhanEmail.TabIndex = 6;
            this.chkNhanEmail.Text = "Nhận Email thông báo";
            this.chkNhanEmail.UseVisualStyleBackColor = true;
            // 
            // dtpNgaySinh
            // 
            this.dtpNgaySinh.Location = new System.Drawing.Point(116, 104);
            this.dtpNgaySinh.Name = "dtpNgaySinh";
            this.dtpNgaySinh.Size = new System.Drawing.Size(229, 22);
            this.dtpNgaySinh.TabIndex = 5;
            // 
            // txtSoDienThoai
            // 
            this.txtSoDienThoai.Location = new System.Drawing.Point(116, 65);
            this.txtSoDienThoai.Name = "txtSoDienThoai";
            this.txtSoDienThoai.Size = new System.Drawing.Size(119, 22);
            this.txtSoDienThoai.TabIndex = 4;
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(116, 31);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(119, 22);
            this.txtHoTen.TabIndex = 3;
            // 
            // lblNgaySinh
            // 
            this.lblNgaySinh.AutoSize = true;
            this.lblNgaySinh.Location = new System.Drawing.Point(22, 101);
            this.lblNgaySinh.Name = "lblNgaySinh";
            this.lblNgaySinh.Size = new System.Drawing.Size(70, 16);
            this.lblNgaySinh.TabIndex = 2;
            this.lblNgaySinh.Text = "Ngày sinh ";
            // 
            // lblSoDienThoai
            // 
            this.lblSoDienThoai.AutoSize = true;
            this.lblSoDienThoai.Location = new System.Drawing.Point(22, 65);
            this.lblSoDienThoai.Name = "lblSoDienThoai";
            this.lblSoDienThoai.Size = new System.Drawing.Size(88, 16);
            this.lblSoDienThoai.TabIndex = 1;
            this.lblSoDienThoai.Text = "Số điện thoại ";
            // 
            // lblHoTen
            // 
            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Location = new System.Drawing.Point(22, 31);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(52, 16);
            this.lblHoTen.TabIndex = 0;
            this.lblHoTen.Text = "Họ Tên";
            // 
            // groupBox_KhoaHoc
            // 
            this.groupBox_KhoaHoc.Controls.Add(this.txtTongTien);
            this.groupBox_KhoaHoc.Controls.Add(this.lblTongTien);
            this.groupBox_KhoaHoc.Controls.Add(this.txtSoThangDK);
            this.groupBox_KhoaHoc.Controls.Add(this.numSoThang);
            this.groupBox_KhoaHoc.Controls.Add(this.radOffline);
            this.groupBox_KhoaHoc.Controls.Add(this.radOnline);
            this.groupBox_KhoaHoc.Controls.Add(this.txtChonHinhThuc);
            this.groupBox_KhoaHoc.Controls.Add(this.txtChonKhoaHoc);
            this.groupBox_KhoaHoc.Controls.Add(this.cboKhoaHoc);
            this.groupBox_KhoaHoc.Location = new System.Drawing.Point(20, 245);
            this.groupBox_KhoaHoc.Name = "groupBox_KhoaHoc";
            this.groupBox_KhoaHoc.Size = new System.Drawing.Size(450, 207);
            this.groupBox_KhoaHoc.TabIndex = 1;
            this.groupBox_KhoaHoc.TabStop = false;
            this.groupBox_KhoaHoc.Text = "Thông tin khóa học";
            // 
            // txtTongTien
            // 
            this.txtTongTien.AutoSize = true;
            this.txtTongTien.Location = new System.Drawing.Point(18, 159);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.Size = new System.Drawing.Size(81, 16);
            this.txtTongTien.TabIndex = 8;
            this.txtTongTien.Text = "Tổng số tiền";
            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Location = new System.Drawing.Point(153, 159);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(109, 16);
            this.lblTongTien.TabIndex = 7;
            this.lblTongTien.Text = "Tổng tiền học phí";
            // 
            // txtSoThangDK
            // 
            this.txtSoThangDK.AutoSize = true;
            this.txtSoThangDK.Location = new System.Drawing.Point(18, 118);
            this.txtSoThangDK.Name = "txtSoThangDK";
            this.txtSoThangDK.Size = new System.Drawing.Size(111, 16);
            this.txtSoThangDK.TabIndex = 6;
            this.txtSoThangDK.Text = "Số tháng đăng ký";
            // 
            // numSoThang
            // 
            this.numSoThang.Location = new System.Drawing.Point(156, 116);
            this.numSoThang.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSoThang.Name = "numSoThang";
            this.numSoThang.Size = new System.Drawing.Size(147, 22);
            this.numSoThang.TabIndex = 5;
            this.numSoThang.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSoThang.ValueChanged += new System.EventHandler(this.numSoThang_ValueChanged);
            // 
            // radOffline
            // 
            this.radOffline.AutoSize = true;
            this.radOffline.Location = new System.Drawing.Point(265, 78);
            this.radOffline.Name = "radOffline";
            this.radOffline.Size = new System.Drawing.Size(65, 20);
            this.radOffline.TabIndex = 4;
            this.radOffline.TabStop = true;
            this.radOffline.Text = "Offline";
            this.radOffline.UseVisualStyleBackColor = true;
            // 
            // radOnline
            // 
            this.radOnline.AutoSize = true;
            this.radOnline.Location = new System.Drawing.Point(156, 78);
            this.radOnline.Name = "radOnline";
            this.radOnline.Size = new System.Drawing.Size(66, 20);
            this.radOnline.TabIndex = 3;
            this.radOnline.TabStop = true;
            this.radOnline.Text = "Online";
            this.radOnline.UseVisualStyleBackColor = true;
            // 
            // txtChonHinhThuc
            // 
            this.txtChonHinhThuc.AutoSize = true;
            this.txtChonHinhThuc.Location = new System.Drawing.Point(18, 78);
            this.txtChonHinhThuc.Name = "txtChonHinhThuc";
            this.txtChonHinhThuc.Size = new System.Drawing.Size(117, 16);
            this.txtChonHinhThuc.TabIndex = 2;
            this.txtChonHinhThuc.Text = "Chọn hình thức học";
            // 
            // txtChonKhoaHoc
            // 
            this.txtChonKhoaHoc.AutoSize = true;
            this.txtChonKhoaHoc.Location = new System.Drawing.Point(18, 35);
            this.txtChonKhoaHoc.Name = "txtChonKhoaHoc";
            this.txtChonKhoaHoc.Size = new System.Drawing.Size(96, 16);
            this.txtChonKhoaHoc.TabIndex = 1;
            this.txtChonKhoaHoc.Text = "Chọn khóa học";
            // 
            // cboKhoaHoc
            // 
            this.cboKhoaHoc.FormattingEnabled = true;
            this.cboKhoaHoc.Location = new System.Drawing.Point(156, 32);
            this.cboKhoaHoc.Name = "cboKhoaHoc";
            this.cboKhoaHoc.Size = new System.Drawing.Size(140, 24);
            this.cboKhoaHoc.TabIndex = 0;
            this.cboKhoaHoc.SelectedIndexChanged += new System.EventHandler(this.cboKhoaHoc_SelectedIndexChanged);
            // 
            // btnDangKy
            // 
            this.btnDangKy.Location = new System.Drawing.Point(619, 135);
            this.btnDangKy.Name = "btnDangKy";
            this.btnDangKy.Size = new System.Drawing.Size(127, 31);
            this.btnDangKy.TabIndex = 2;
            this.btnDangKy.Text = "Đăng ký";
            this.btnDangKy.UseVisualStyleBackColor = true;
            this.btnDangKy.Click += new System.EventHandler(this.btnDangKy_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(619, 194);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(127, 31);
            this.btnLamMoi.TabIndex = 3;
            this.btnLamMoi.Text = "Xóa dữ liệu";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnThoat.Location = new System.Drawing.Point(619, 253);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(127, 31);
            this.btnThoat.TabIndex = 4;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 464);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnDangKy);
            this.Controls.Add(this.groupBox_KhoaHoc);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox_KhoaHoc.ResumeLayout(false);
            this.groupBox_KhoaHoc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSoThang)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblSoDienThoai;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.Label lblNgaySinh;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.TextBox txtSoDienThoai;
        private System.Windows.Forms.DateTimePicker dtpNgaySinh;
        private System.Windows.Forms.CheckBox chkNhanEmail;
        private System.Windows.Forms.GroupBox groupBox_KhoaHoc;
        private System.Windows.Forms.Label txtChonKhoaHoc;
        private System.Windows.Forms.ComboBox cboKhoaHoc;
        private System.Windows.Forms.Label txtSoThangDK;
        private System.Windows.Forms.NumericUpDown numSoThang;
        private System.Windows.Forms.RadioButton radOffline;
        private System.Windows.Forms.RadioButton radOnline;
        private System.Windows.Forms.Label txtChonHinhThuc;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.Button btnDangKy;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Label txtTongTien;
    }
}

