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
    public partial class frmXuat : Form
    {
        public int SoDong { get; set; }
        public int SoCot { get; set; }

        // 2. Kích thước cạnh button (h = 35px) và khoảng cách giữa các button (margin = 5px)
        private int h = 35;
        private int margin = 5;

        // 3. Constructor nhận tham số số dòng và số cột[cite: 30]
        public frmXuat(int dong = 1, int cot = 1)
        {
            InitializeComponent(); // Khởi tạo thành phần Form[cite: 30]

            this.SoDong = dong;
            this.SoCot = cot;

            // Khởi tạo ma trận các Button[cite: 30]
            Button btn = null;
            for (int i = 0; i < SoDong; i++)
            {
                for (int j = 0; j < SoCot; j++)
                {
                    btn = new Button();
                    btn.Width = h;
                    btn.Height = h;



                    btn.Text = (i * SoCot + j + 1).ToString();


                    btn.Left = margin * (j + 1) + h * j;
                    btn.Top = margin * (i + 1) + h * i;


                    btn.Click += btn_Click;
                    btn.MouseHover += HoChuotLenButton;


                    btn.Tag = string.Format("Dòng {0} cột {1}", i + 1, j + 1);


                    this.Controls.Add(btn);
                }
            }

            this.ClientSize = new Size(SoCot * (h + margin) + margin, SoDong * (h + margin) + margin);
        }
        private void HoChuotLenButton(object sender, EventArgs e)
        {
            Button b = sender as Button;
            if (b != null && b.Tag != null)
            {
                this.Text = b.Tag.ToString();
            }
        }

        // Sự kiện khi click chuột vào Button[cite: 31]
        private void btn_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            if (b != null)
            {
                MessageBox.Show($"Bạn vừa bấm nút số: {b.Text} ({b.Tag})", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public frmXuat()
        {
            InitializeComponent();
        }

        private void frmXuat_Load(object sender, EventArgs e)
        {

        }
    }
}
