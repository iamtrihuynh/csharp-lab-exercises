using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLab03_01_Bai01
{
    public class DuongTron
    {
        // 1. Fields
        private Diem tam;
        private double banKinh;

        // 2. Properties kiểm tra bán kính phải > 0
        public Diem Tam
        {
            get { return tam; }
            set { tam = value; }
        }

        public double BanKinh
        {
            get { return banKinh; }
            set
            {
                if (value > 0)
                    banKinh = value;
                else
                    throw new ArgumentException("Bán kính phải lớn hơn 0!");
            }
        }

        // 3. Constructors
        public DuongTron()
        {
            tam = new Diem(0, 0);
            banKinh = 1.0;
        }

        public DuongTron(Diem t, double r)
        {
            tam = new Diem(t);
            BanKinh = r; // Kích hoạt kiểm tra validation
        }

        public DuongTron(DuongTron dt)
        {
            tam = new Diem(dt.Tam);
            banKinh = dt.BanKinh;
        }

        // 4. Nhập xuất
        public void Nhap()
        {
            Console.WriteLine("Nhập tọa độ tâm:");
            tam.Nhap();

            while (true)
            {
                Console.Write("Nhập bán kính R (> 0): ");
                if (double.TryParse(Console.ReadLine(), out double r) && r > 0)
                {
                    banKinh = r;
                    break;
                }
                Console.WriteLine(">> Bán kính không hợp lệ, vui lòng nhập lại!");
            }
        }

        public void Xuat()
        {
            Console.WriteLine($"Đường tròn: Tâm {tam}, Bán kính R = {banKinh}");
        }

        // 5. Chu vi và Diện tích
        public double TinhChuVi()
        {
            return 2 * Math.PI * banKinh;
        }

        public double TinhDienTich()
        {
            return Math.PI * banKinh * banKinh;
        }

        // 6. Kiểm tra vị trí tương đối giữa một Điểm và Đường tròn
        public int ViTriTuongDoi(Diem m)
        {
            double d = tam.KhoangCach(m);
            if (Math.Abs(d - banKinh) < 1e-6) return 0; // Nằm trên đường tròn
            if (d < banKinh) return -1;                // Nằm trong đường tròn
            return 1;                                  // Nằm ngoài đường tròn
        }

        // 7. Kiểm tra vị trí tương đối giữa hai Đường tròn
        public string ViTriTuongDoi(DuongTron dt2)
        {
            double d = this.tam.KhoangCach(dt2.Tam);
            double r1 = this.banKinh;
            double r2 = dt2.BanKinh;

            if (d == 0 && Math.Abs(r1 - r2) < 1e-6)
                return "Hai đường tròn trùng nhau.";
            if (d == 0)
                return "Hai đường tròn đồng tâm.";
            if (Math.Abs(d - (r1 + r2)) < 1e-6)
                return "Hai đường tròn tiếp xúc ngoài.";
            if (Math.Abs(d - Math.Abs(r1 - r2)) < 1e-6)
                return "Hai đường tròn tiếp xúc trong.";
            if (d > r1 + r2)
                return "Hai đường tròn nằm ngoài nhau.";
            if (d < Math.Abs(r1 - r2))
                return "Đường tròn này chứa đường tròn kia (không giao nhau).";

            return "Hai đường tròn cắt nhau tại hai điểm.";
        }
    }
}
