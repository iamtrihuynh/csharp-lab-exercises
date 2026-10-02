using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLab03_01_Bai03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("==================================================");
            Console.WriteLine("             CHƯƠNG TRÌNH LỚP ĐA THỨC             ");
            Console.WriteLine("==================================================");

            // 1. Tạo đa thức P(x) bậc 2: gán bằng Indexer
            // Ví dụ: P(x) = 2x^2 + 3x - 5
            DaThuc P = new DaThuc(2);
            P[2] = 2;   // a2 = 2
            P[1] = 3;   // a1 = 3
            P[0] = -5;  // a0 = -5
            Console.WriteLine($"Đa thức P(x) = {P}");

            // 2. Tạo đa thức Q(x) bậc 3: nhập từ bàn phím
            Console.WriteLine("\n--- NHẬP ĐA THỨC Q(x) ---");
            Console.Write("Nhập bậc của đa thức Q: ");
            int bacQ = int.Parse(Console.ReadLine());
            DaThuc Q = new DaThuc(bacQ);
            Q.Nhap();
            Console.WriteLine($"Đa thức Q(x) = {Q}");

            // 3. Phép toán Cộng: P(x) + Q(x)
            DaThuc tong = P + Q;
            Console.WriteLine("\n--- PHÉP TOÁN CỘNG & TRỪ ---");
            Console.WriteLine($"P(x) + Q(x) = {tong}");

            // 4. Phép toán Trừ: P(x) - Q(x)
            DaThuc hieu = P - Q;
            Console.WriteLine($"P(x) - Q(x) = {hieu}");

            // 5. Tính giá trị đa thức P(b)
            Console.WriteLine("\n--- TÍNH GIÁ TRỊ ĐA THỨC ---");
            Console.Write("Nhập giá trị x = b để tính P(b): ");
            double b = double.Parse(Console.ReadLine());
            double ketQuaP = P.TinhGiaTri(b);
            Console.WriteLine($"Giá trị của P({b}) = {ketQuaP}");

            // 6. Kiểm tra Indexer ném ngoại lệ khi nhập bậc sai
            try
            {
                Console.Write("\nKiểm tra gán indexer ngoài bậc (P[10]): ");
                P[10] = 99;
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(">> Bắt ngoại lệ Indexer thành công: " + ex.Message);
            }

            Console.WriteLine("\nNhấn phím bất kỳ để kết thúc...");
            Console.ReadKey();
        }
    }
}
