using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLab02_2_Bai03_SanPham
{
    public class SanPham
    {
        // Các thuộc tính
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public double Gia { get; set; }

        // Constructor mặc định
        public SanPham()
        {
            MaSP = string.Empty;
            TenSP = string.Empty;
            Gia = 0;
        }

        // Constructor 3 đối số
        public SanPham(string maSP, string tenSP, double gia)
        {
            this.MaSP = maSP;
            this.TenSP = tenSP;
            this.Gia = gia;
        }

        // Phương thức tính thuế VAT (10% đơn giá)
        public double TinhThueVAT()
        {
            return Gia * 0.10;
        }

        // Phương thức nhập dữ liệu từ bàn phím
        public void Nhap()
        {
            Console.Write("Nhập mã sản phẩm: ");
            MaSP = Console.ReadLine().Trim();

            Console.Write("Nhập tên sản phẩm: ");
            TenSP = Console.ReadLine().Trim();

            while (true)
            {
                Console.Write("Nhập đơn giá: ");
                if (double.TryParse(Console.ReadLine(), out double gia) && gia >= 0)
                {
                    Gia = gia;
                    break;
                }
                Console.WriteLine(">> Đơn giá phải là số >= 0!");
            }
        }

        // Phương thức xuất thông tin sản phẩm
        public void Xuat()
        {
            Console.WriteLine("Mã SP: {0,-8} | Tên SP: {1,-20} | Giá: {2,10:N0} đ | Thuế VAT: {3,10:N0} đ",
                MaSP, TenSP, Gia, TinhThueVAT());
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            Console.WriteLine("===== NHẬP THÔNG TIN 2 SẢN PHẨM =====");

            // Tạo đối tượng sản phẩm thứ nhất
            Console.WriteLine("\n[Nhập sản phẩm 1]");
            SanPham sp1 = new SanPham();
            sp1.Nhap();

            // Tạo đối tượng sản phẩm thứ hai
            Console.WriteLine("\n[Nhập sản phẩm 2]");
            SanPham sp2 = new SanPham();
            sp2.Nhap();

            // Xuất thông tin
            Console.WriteLine("\n===== KẾT QUẢ XUẤT THÔNG TIN =====");
            Console.WriteLine(new string('-', 70));
            sp1.Xuat();
            sp2.Xuat();
            Console.WriteLine(new string('-', 70));

            Console.ReadKey();
        }
    }
}
