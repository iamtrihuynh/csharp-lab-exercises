using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDiemSinhVien
{
    internal class Program
    {
        static int NhapSoLuong() {
            int n;
            do
            {
                Console.Write("Vui long nhap vao 1 so nguyen N (N > 0): ");
                n = int.Parse(Console.ReadLine());

            } while (n <= 0);
            return n;
        }

        static void NhapThongTin(int n, string[] hoTen, double[] dtb)
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write("Vui long nhap HO VA TEN cua sinh vien thu {0}: ", i + 1);
                hoTen[i] = Console.ReadLine();

                Console.WriteLine();
                double score = 0;
                do
                {

                    Console.Write("Vui long nhap vao DIEM SO cua sinh vien thu {0} (0-10): ", i + 1);
                    score = double.Parse(Console.ReadLine());
                    Console.WriteLine();
                    
                } while (score < 0 || score > 10);

                dtb[i] = score;
                //Console.WriteLine(hoTen[i] + " " + dtb[i]);
            }
        } 

        static double DiemTrungBinh(int n, double[] dtb)
        {
            double ans = 0;
            for (int i = 0; i < n; i++)
            {
                ans += dtb[i];
            }
            return ans / (1.00*n);
        }

        static int DiemCaoNhat(int n, double[] dtb)
        {
            double ans = 0;
            int pos = 0;
            for (int i = 0; i < n; i++)
            {
                if (dtb[i] > ans)
                {
                    pos = i;
                    ans = dtb[i];
                }
            }
            return pos;

            
        }

        static int SoSVDat(int n, double[] dtb)
        {
            int dem = 0;
            for (int i = 0; i < n; i++)
            {
                if (dtb[i] >= 5.0)
                {
                    dem++;
                }
            }
            return dem;
        }
        
        static void InDanhSach(int n, string[] hoTen,  double[] dtb)
        {
            Console.WriteLine("\n==================================================");
            Console.WriteLine(string.Format("{0,-5} | {1,-30} | {2,-10}", "STT", "HỌ VÀ TÊN", "ĐIỂM SỐ"));
            Console.WriteLine("--------------------------------------------------");

            for (int i = 0; i < hoTen.Length; i++)
            {
                Console.WriteLine(string.Format("{0,-5} | {1,-30} | {2,-10:F2}", i + 1, hoTen[i], dtb[i]));
            }

            Console.WriteLine("==================================================");
        }
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            int n = NhapSoLuong();

            string[] hoTen = new string[n];
            double[] dtb = new double[n];

            NhapThongTin(n, hoTen, dtb);

            double score = DiemTrungBinh(n, dtb);
            int posMax = DiemCaoNhat(n, dtb);
            int dem = SoSVDat(n, dtb);

            Console.WriteLine("Diem trung binh cua ca lop la: {0}", score);
            Console.WriteLine("Sinh vien co diem cao nhat la {1} voi diem so {0}", dtb[posMax], hoTen[posMax]);
            Console.WriteLine("So luong SV dat la: {0}", dem);

            InDanhSach(n, hoTen, dtb);

        }
    }
}
