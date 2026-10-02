using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLab02_2_Bai03_HinhChuNhat
{
    public class HinhChuNhat
    {
        // Các trường dữ liệu (fields)
        private double mChieuDai;
        private double mChieuRong;

        // Properties truy cập dữ liệu
        public double ChieuDai
        {
            get { return mChieuDai; }
            set { if (value > 0) mChieuDai = value; }
        }

        public double ChieuRong
        {
            get { return mChieuRong; }
            set { if (value > 0) mChieuRong = value; }
        }

        // Constructor không tham số
        public HinhChuNhat()
        {
            mChieuDai = 1.0;
            mChieuRong = 1.0;
        }

        // Constructor có tham số
        public HinhChuNhat(double chieuDai, double chieuRong)
        {
            this.mChieuDai = chieuDai;
            this.mChieuRong = chieuRong;
        }

        // Phương thức tính chu vi
        public double TinhChuVi()
        {
            return (mChieuDai + mChieuRong) * 2;
        }

        // Phương thức tính diện tích
        public double TinhDienTich()
        {
            return mChieuDai * mChieuRong;
        }

        // Phương thức kiểm tra có phải là hình vuông không
        public bool KiemTraHinhVuong()
        {
            return mChieuDai == mChieuRong;
        }

        // Phương thức xuất thông tin
        public void XuatThongTin()
        {
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Dài: {0} | Rộng: {1}", mChieuDai, mChieuRong);
            Console.WriteLine("Chu vi: {0} | Diện tích: {1}", TinhChuVi(), TinhDienTich());
            Console.WriteLine("Là hình vuông: {0}", KiemTraHinhVuong() ? "Đúng" : "Không (Hình chữ nhật)");
            Console.WriteLine("------------------------------------------");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("=== KIỂM TRA LỚP HÌNH CHỮ NHẬT ===");

            // Đối tượng 1: Hình chữ nhật bình thường
            HinhChuNhat hcn1 = new HinhChuNhat(10, 5);
            hcn1.XuatThongTin();

            // Đối tượng 2: Hình vuông
            HinhChuNhat hcn2 = new HinhChuNhat(8, 8);
            hcn2.XuatThongTin();

            Console.ReadKey();
        }
    }
}
