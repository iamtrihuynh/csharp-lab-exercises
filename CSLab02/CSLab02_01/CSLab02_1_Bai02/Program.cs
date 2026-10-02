using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLab02_1_Bai02
{
    internal class Program
    {
        static void inDS(List<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write(list[i] + " ");
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            int n = 0;

            // Nhập và kiểm tra n > 0
            while (true)
            {
                Console.Write("Nhập số lượng phần tử n (n > 0): ");
                if (int.TryParse(Console.ReadLine(), out n) && n > 0)
                {
                    break;
                }
                Console.WriteLine("Giá trị n phải là số nguyên dương. Vui lòng nhập lại!");
            }

            //List<int>  ds = new List;
            List<int> ds = new List<int>();

            Random rnd = new Random();

            for (int i = 0; i < n; i++)
            {
                ds.Add(rnd.Next(1, 100));
            }

            Console.WriteLine("\n--- DÃY SỐ PHÁT SINH BAN ĐẦU ---");
            inDS(ds);

            ds.Sort();
            Console.WriteLine("\n--- DÃY SỐ SAU KHI SẮP XẾP TĂNG DẦN ---");
            inDS(ds);

            Console.WriteLine("\nNhấn phím bất kỳ để kết thúc...");
            Console.ReadKey();
        }
    }
}
