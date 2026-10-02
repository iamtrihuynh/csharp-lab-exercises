using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSLab06_Array
{
    public partial class frmNhapLieu : Form
    {
        public frmNhapLieu()
        {
            InitializeComponent();
        }

        private void btnKhoiTao_Click(object sender, EventArgs e)
        {
            int soDong = 0;
            int soCot = 0;

            // 1. Kiểm tra tính hợp lệ của Số dòng
            if (!int.TryParse(txtSoDong.Text, out soDong) || soDong <= 0)
            {
                MessageBox.Show("Vui lòng nhập số dòng là số nguyên lớn hơn 0!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoDong.Focus();
                return;
            }

            // 2. Kiểm tra tính hợp lệ của Số cột
            if (!int.TryParse(txtSoCot.Text, out soCot) || soCot <= 0)
            {
                MessageBox.Show("Vui lòng nhập số cột là số nguyên lớn hơn 0!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoCot.Focus();
                return;
            }

            // 3. Khởi tạo form xuất và truyền số dòng, số cột vào Constructor[cite: 30]
            frmXuat f = new frmXuat(soDong, soCot);
            f.StartPosition = FormStartPosition.CenterScreen; // Mở form ở giữa màn hình[cite: 31]

            // 4. Hiển thị form
            f.Show();
        }

        private void btnKhoiTao_Click_1(object sender, EventArgs e)
        {

            this.btnKhoiTao.Location = new System.Drawing.Point(264, 37);
            this.btnKhoiTao.Name = "btnKhoiTao";
            this.btnKhoiTao.Size = new System.Drawing.Size(157, 65);
            this.btnKhoiTao.TabIndex = 3;
            this.btnKhoiTao.Text = "Khởi tạo form";
            this.btnKhoiTao.UseVisualStyleBackColor = true;
            this.btnKhoiTao.Click += new System.EventHandler(this.btnKhoiTao_Click); // Bổ sung dòng này

        }
    }
}
