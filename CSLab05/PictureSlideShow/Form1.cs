using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PictureSlideShow
{
    public partial class Form1 : Form
    {
        // 1. Mảng chuỗi lưu đường dẫn tất cả các file hình ảnh trong thư mục
        private string[] folderFile = null;

        // 2. Vị trí của bức ảnh hiện đang được hiển thị[cite: 26, 27]
        private int selected = 0;

        // 3. Vị trí đầu và cuối của mảng hình ảnh
        private int begin = 0;
        private int end = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void showImage(string path)
        {
            // Giải phóng bộ nhớ ảnh cũ trước khi nạp ảnh mới (tránh tràn RAM khi chạy slide liên tục)
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
            }

            // Nạp hình ảnh từ đường dẫn
            Image imgtemp = Image.FromFile(path);
            pictureBox1.Image = imgtemp;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage; // Đảm bảo hình co giãn vừa khung[cite: 28]
        }

        // Hàm lùi về ảnh trước đó[cite: 28]
        private void prevImage()
        {
            if (folderFile == null || folderFile.Length == 0) return;

            if (selected == 0)
            {
                selected = folderFile.Length - 1; // Nếu đang ở ảnh đầu, lùi về ảnh cuối cùng[cite: 28]
            }
            else
            {
                selected = selected - 1; 
    }
            showImage(folderFile[selected]);
}

        // Hàm tiến tới ảnh tiếp theo
        private void nextImage()
        {
            if (folderFile == null || folderFile.Length == 0) return;

            if (selected == folderFile.Length - 1)
            {
                selected = 0; // Nếu đang ở ảnh cuối, tiến về ảnh đầu tiên[cite: 28]
            }
            else
            {
                selected = selected + 1;
    }
            showImage(folderFile[selected]); 
}

        private void btnOpen_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();

            // Hiển thị hộp thoại chọn thư mục[cite: 27]
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = folderBrowserDialog1.SelectedPath;

                // Quét lấy danh sách file theo từng định dạng ảnh[cite: 27]
                string[] part1 = Directory.GetFiles(path, "*.jpg");
                string[] part2 = Directory.GetFiles(path, "*.jpeg");
                string[] part3 = Directory.GetFiles(path, "*.bmp");

                // Tổng hợp độ dài để khởi tạo mảng folderFile[cite: 27]
                int tongSoFile = part1.Length + part2.Length + part3.Length;

                if (tongSoFile == 0)
                {
                    MessageBox.Show("Thư mục này không chứa file ảnh hợp lệ (.jpg, .jpeg, .bmp)!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                folderFile = new string[tongSoFile];

                // Sao chép từng mảng định dạng vào mảng chung folderFile[cite: 27]
                Array.Copy(part1, 0, folderFile, 0, part1.Length);
                Array.Copy(part2, 0, folderFile, part1.Length, part2.Length);
                Array.Copy(part3, 0, folderFile, part1.Length + part2.Length, part3.Length);

                // Thiết lập lại các chỉ số điều hướng[cite: 27]
                selected = 0;
                begin = 0;
                end = folderFile.Length - 1;

                // Hiển thị ngay bức ảnh đầu tiên[cite: 27]
                showImage(folderFile[selected]);

                // Mở khóa các nút chức năng sau khi đã nạp ảnh thành công[cite: 27]
                btnPrevious.Enabled = true;
                btnNext.Enabled = true;
                btnStart.Enabled = true;
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            prevImage();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            nextImage();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            nextImage();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == true) 
            {
                timer1.Enabled = false; // Tắt tự động chạy
                btnStart.Text = "<< Bắt đầu Slide Show >>"; 
            }
            else
            {
                if (folderFile == null || folderFile.Length == 0)
                {
                    MessageBox.Show("Vui lòng mở thư mục có ảnh trước khi bắt đầu Slide Show!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                timer1.Enabled = true; // Bật tự động chạy
                btnStart.Text = "<< Kết thúc Slide Show >>"; 
            }
        }
    }
}
