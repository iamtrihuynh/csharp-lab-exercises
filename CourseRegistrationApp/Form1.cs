using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseRegistrationApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void TinhTongHocPhi()
        {
            long tienHocPhi = 0;
            if (cboKhoaHoc.SelectedIndex == 0) tienHocPhi = 800000;
            else if (cboKhoaHoc.SelectedIndex == 1) tienHocPhi = 700000;
            else if (cboKhoaHoc.SelectedIndex == 2) tienHocPhi = 750000;
            else if (cboKhoaHoc.SelectedIndex == 3) tienHocPhi = 650000;

            long tongTien = tienHocPhi * (long)(numSoThang.Value);

            lblTongTien.Text = tongTien.ToString("N0") + " VNĐ";

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            cboKhoaHoc.Items.Clear();
            cboKhoaHoc.Items.Add("C# WinForms cơ bản");
            cboKhoaHoc.Items.Add("SQL Server cơ bản");
            cboKhoaHoc.Items.Add("Web Frontend cơ bản");
            cboKhoaHoc.Items.Add("Lập trình Python cơ bản");
            
            /// Chọn mặc định mục đầu tiên
            //cboKhoaHoc.SelectedIndex = 0;

            // Đặt giá trị mặc định cho radio button
            radOffline.Checked = false;
            numSoThang.Value = 1;
            numSoThang.Maximum = 12; 

            TinhTongHocPhi();
        }

        private void numSoThang_ValueChanged(object sender, EventArgs e)
        {
            TinhTongHocPhi();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes) {
                Application.Exit();
            }
        }

        private void cboKhoaHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            TinhTongHocPhi();
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtSoDienThoai.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoDienThoai.Focus();
                return;
            }

            if (cboKhoaHoc.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn khóa học.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboKhoaHoc.Focus();
                return;
            }

            string hinhThuc = radOffline.Checked ? "Offline" : "Online";
            string nhanEmail = chkNhanEmail.Checked ? "Có" : "Không";
            string ngaySinh = dtpNgaySinh.Value.ToString("dd/MM/yyyy");

            string thongBao = $"Họ tên: {txtHoTen.Text}\n" 
                + $"Ngày sinh: {ngaySinh}\n" 
                + $"Số điện thoại: {txtSoDienThoai.Text}\n" 
                + $"Khóa học: {cboKhoaHoc.SelectedItem.ToString()}\n" 
                + $"Hình thức: {hinhThuc}\n" 
                + $"Nhận email: {nhanEmail}\n" 
                + $"Số tháng đăng ký: {numSoThang.Value}\n" 
                + $"Tổng học phí: {lblTongTien.Text}";
            MessageBox.Show(thongBao, "Đăng ký thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtHoTen.Clear();
            txtSoDienThoai.Clear();
            dtpNgaySinh.Value = DateTime.Now;
            cboKhoaHoc.SelectedIndex = -1;

            radOffline.Checked = false;
            radOnline.Checked = true;
            chkNhanEmail.Checked = false;

            numSoThang.Value = 1;

            TinhTongHocPhi();
            txtHoTen.Focus();
        }
    }
}
