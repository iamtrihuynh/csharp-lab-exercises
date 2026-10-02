using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLab02_1_Bai01
{
    class NotNegativeException : Exception
    {
        public NotNegativeException() : base("Giá trị dưới dấu căn < 0") { }
        public NotNegativeException(string message) : base(message) { }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            try
            {
                Console.Write("Nhập số nguyên x: ");
                int x = int.Parse(Console.ReadLine());

                Console.Write("Nhập số nguyên y : ");
                int y = int.Parse(Console.ReadLine());

                int mauSo = 2 * x - y;
                if (mauSo == 0)
                {
                    throw new DivideByZeroException("Mẫu số bằng 0");
                }

                double bieuThuc = (double)(3 * x + 2 * y) / mauSo;

                if (bieuThuc < 0)
                {
                    throw new NotNegativeException();
                }

                double H = Math.Sqrt(bieuThuc);

                Console.WriteLine("------------------------------------");
                Console.WriteLine($"Kết quả H = {H:F4}");
            }
            catch (NotNegativeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException)
            {
                Console.WriteLine("Vui lòng nhập số nguyên hợp lệ.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
            }

            Console.WriteLine("\nNhấn phím bất kỳ để kết thúc...");
            Console.ReadKey();
        }
    }
}
