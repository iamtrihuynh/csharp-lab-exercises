using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLab03_01_Bai01
{
    public class Diem
    {
        // 1. Trường dữ liệu (Fields)
        private double x;
        private double y;

        // 2. Thuộc tính (Properties)
        public double X
        {
            get { return x; }
            set { x = value; }
        }

        public double Y
        {
            get { return y; }
            set { y = value; }
        }

        // 3. Các hàm khởi tạo (Constructors)
        public Diem()
        {
            x = 0;
            y = 0;
        }

        public Diem(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public Diem(Diem p)
        {
            this.x = p.X;
            this.y = p.Y;
        }

        // 4. Nhập tọa độ từ bàn phím
        public void Nhap()
        {
            Console.Write("  Nhập hoành độ x: ");
            double.TryParse(Console.ReadLine(), out x);
            Console.Write("  Nhập tung độ y: ");
            double.TryParse(Console.ReadLine(), out y);
        }

        // 5. Tính khoảng cách từ điểm hiện tại đến điểm b
        public double KhoangCach(Diem b)
        {
            return Math.Sqrt(Math.Pow(this.x - b.X, 2) + Math.Pow(this.y - b.Y, 2));
        }

        // 6. Ghi đè hiển thị dạng (x, y)
        public override string ToString()
        {
            return $"({x}, {y})";
        }
    }
}
