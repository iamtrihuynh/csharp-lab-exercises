using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLab03_01_Bai01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            // Khởi tạo đường tròn C1 tâm (0, 0), bán kính 5
            DuongTron c1 = new DuongTron(new Diem(0, 0), 5);
            Console.WriteLine("--- ĐƯỜNG TRÒN C1 ---");
            c1.Xuat();
            Console.WriteLine($"Chu vi C1: {c1.TinhChuVi():F2}");
            Console.WriteLine($"Diện tích C1: {c1.TinhDienTich():F2}");

            // Khởi tạo đường tròn C2 tâm (8, 0), bán kính 3
            DuongTron c2 = new DuongTron(new Diem(8, 0), 3);
            Console.WriteLine("\n--- ĐƯỜNG TRÒN C2 ---");
            c2.Xuat();

            // Kiểm tra vị trí tương đối giữa C1 và C2 (d = 8 == 5 + 3 => Tiếp xúc ngoài)
            Console.WriteLine($"Vị trí tương đối C1 và C2: {c1.ViTriTuongDoi(c2)}");

            // Kiểm tra điểm M(3, 4) với C1: d = sqrt(3^2 + 4^2) = 5 == R => Nằm trên đường tròn
            Diem m = new Diem(3, 4);
            int vt = c1.ViTriTuongDoi(m);
            string viTriDiem = vt == 0 ? "nằm trên" : (vt < 0 ? "nằm trong" : "nằm ngoài");
            Console.WriteLine($"Điểm M{m} {viTriDiem} đường tròn C1.");

            Console.ReadKey();
        }
    }
}
