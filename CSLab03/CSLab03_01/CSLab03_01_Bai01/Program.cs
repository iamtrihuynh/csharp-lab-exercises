using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace CSLab03_01_Bai01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            string inputFile = "HinhHoc.txt";
            string outputFile = "output.txt";

            // Tạo file dữ liệu mẫu nếu chưa tồn tại
            if (!File.Exists(inputFile))
            {
                string duLieuMau = "1\t5.3\t3.2\n2\t9.1\n1\t11\t2\n1\t12.9\t10\n2\t4.5\n2\t3.4\n1\t77\t55";
                File.WriteAllText(inputFile, duLieuMau);
            }

            List<HinhHoc> danhSachHinh = new List<HinhHoc>();

            // 1. Đọc dữ liệu từ file HinhHoc.txt
            string[] lines = File.ReadAllLines(inputFile);
            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                string[] parts = line.Split(new char[] { '\t', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length == 0) continue;

                int loaiHinh = int.Parse(parts[0]);

                if (loaiHinh == 1 && parts.Length >= 3) // 1: Hình chữ nhật (dài, rộng)
                {
                    double dai = double.Parse(parts[1], CultureInfo.InvariantCulture);
                    double rong = double.Parse(parts[2], CultureInfo.InvariantCulture);
                    danhSachHinh.Add(new HinhChuNhat(dai, rong));
                }
                else if (loaiHinh == 2 && parts.Length >= 2) // 2: Hình tròn (bán kính)
                {
                    double bk = double.Parse(parts[1], CultureInfo.InvariantCulture);
                    danhSachHinh.Add(new HinhTron(bk));
                }
            }

            // 2. Thống kê số lượng, tổng diện tích, tổng chu vi
            int soHinh = danhSachHinh.Count;
            double tongDienTich = danhSachHinh.Sum(h => h.DienTich);
            double tongChuVi = danhSachHinh.Sum(h => h.ChuVi);

            // 3. Tìm HCN có S lớn nhất và Hình tròn có P nhỏ nhất (bằng vòng lặp an toàn)
            HinhChuNhat hcnMaxS = null;
            HinhTron htMinP = null;

            foreach (HinhHoc h in danhSachHinh)
            {
                if (h is HinhChuNhat)
                {
                    HinhChuNhat hcn = (HinhChuNhat)h;
                    if (hcnMaxS == null || hcn.DienTich > hcnMaxS.DienTich)
                    {
                        hcnMaxS = hcn;
                    }
                }
                else if (h is HinhTron)
                {
                    HinhTron ht = (HinhTron)h;
                    if (htMinP == null || ht.ChuVi < htMinP.ChuVi)
                    {
                        htMinP = ht;
                    }
                }
            }

            // 4. Ghi kết quả ra output.txt theo đúng mẫu đề bài
            using (StreamWriter sw = new StreamWriter(outputFile, false, Encoding.UTF8))
            {
                sw.WriteLine("So hinh: " + soHinh);
                sw.WriteLine("Tong dien tich: " + tongDienTich.ToString("F2", CultureInfo.InvariantCulture));
                sw.WriteLine("Tong chu vi: " + tongChuVi.ToString("F2", CultureInfo.InvariantCulture));

                if (hcnMaxS != null)
                {
                    sw.WriteLine("Hinh chu nhat co dien tich lon nhat: " + hcnMaxS.ToString());
                }

                if (htMinP != null)
                {
                    sw.WriteLine("Hinh tron co chu vi nho nhat: " + htMinP.ToString());
                }
            }

            Console.WriteLine(">> Đã xử lý xong dữ liệu và ghi vào file 'output.txt' thành công!");
            Console.WriteLine("\n--- NỘI DUNG FILE OUTPUT.TXT ---");
            Console.WriteLine(File.ReadAllText(outputFile));

            Console.WriteLine("\nNhấn phím bất kỳ để kết thúc...");
            Console.ReadKey();
        }
    }
}