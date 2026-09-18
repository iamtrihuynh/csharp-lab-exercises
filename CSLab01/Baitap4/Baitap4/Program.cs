using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baitap4
{
    internal class Program
    {
        public static void YeuCau1()
        {
            Console.WriteLine("Vui long nhap ho, ten lot va ten. Chuong trinh se xuat ra ho ten day du\n");

            Console.Write("Vui long nhap ho: ");
            string ho = Console.ReadLine();

            Console.Write("Vui long nhap ten lot: ");
            string tenlot = Console.ReadLine();

            Console.Write("Vui long nhap ten: ");
            string ten = Console.ReadLine();

            Console.WriteLine("Ho ten day du la: " + ho + " " + tenlot + " " + ten);
            //Console.WriteLine("Ho ten day du la: {0} {1} {2}", ho, tenlot, ten);
            
            Console.ReadKey(true);
        }

        public static void YeuCau2()
        {
            Console.WriteLine("De bai: Nhap ho ten day du, sau do xuat ra tung phan: Ho, ten lot, ten\n");

            Console.Write("Vui long nhap ho ten day du: ");
            string s = Console.ReadLine();

            string[] words = s.Split(new string[] { " " }, StringSplitOptions.None);

            Console.WriteLine("Ho: {0}\nTên lót: {1}\nTên: {2}\n", words[0], words[1], words[2]);
        }

        public static void YeuCau3()
        {
            Console.WriteLine("De bai: Nhap ho ten khong theo chuan, chinh lai theo chuan va xuat ra\n");

            Console.Write("Vui long nhap ho ten day du: ");
            string s = Console.ReadLine();

            string[] words = s.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);


            if (words.Length == 1) {
                string ten = words[0].Substring(0, 1).ToUpper() + words[0].Substring(1).ToLower();
                Console.WriteLine("Ten: " + ten);
            } else if (words.Length == 2)
            {
                string ho = words[0].Substring(0, 1).ToUpper() + words[0].Substring(1).ToLower();
                string ten = words[1].Substring(0, 1).ToUpper() + words[1].Substring(1).ToLower();
                Console.WriteLine("Ho: {0}\nTên: {1}\n", ho, ten);
            }
            else
            {
                string ho = words[0].Substring(0, 1).ToUpper() + words[0].Substring(1).ToLower();
                string tenlot = words[1].Substring(0, 1).ToUpper() + words[1].Substring(1).ToLower();
                string ten = words[2].Substring(0, 1).ToUpper() + words[2].Substring(1).ToLower();

                Console.WriteLine("Ho: {0}\nTên lót: {1}\nTên: {2}\n", ho, tenlot, ten);
            }



        }
        static void Main(string[] args)
        {
            //YeuCau1();   
            //YeuCau2();
            YeuCau3();
        }
    }
}
