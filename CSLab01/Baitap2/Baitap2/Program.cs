using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baitap2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            try {
                Console.Write("Nhap he so A: ");
                double A = double.Parse(Console.ReadLine());
                Console.Write("Nhap he so B: ");
                double B = double.Parse(Console.ReadLine());
                if (A == 0)
                {
                    if (B == 0)
                    {
                        Console.Write("Phương trình vo so nghiem");
                    }
                    else
                    {
                        Console.Write("Phương trình vo nghiem");
                    }
                }
                else
                {
                    double ans = -B / A;
                    Console.WriteLine("Nghiem cua phuong trinh la: " + ans);
                }
            }
            catch (FormatException) {
                Console.WriteLine("Input is invalid");
            } catch (Exception ex) {
                Console.WriteLine("Undefined Errors: " + ex.Message);
            } finally
            {
                Console.WriteLine("The 'Try catch' is finish");
            }


        }
    }
}
