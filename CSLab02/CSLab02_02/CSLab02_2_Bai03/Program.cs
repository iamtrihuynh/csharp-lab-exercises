using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLab02_2_Bai03
{
    public class SinhVien
    {
        // Các thuộc tính cơ bản
        public int MaSV { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }

        // Property chỉ đọc (Read-only) tính tuổi
        public int Tuoi
        {
            get { return DateTime.Now.Year - NgaySinh.Year; }
        }

        // Constructor không tham số
        public SinhVien()
        {
            MaSV = 0;
            HoTen = string.Empty;
            NgaySinh = DateTime.Now;
            DiaChi = string.Empty;
            DienThoai = string.Empty;
        }

        // Constructor có tham số
        public SinhVien(int maSV, string hoTen, DateTime ngaySinh, string diaChi, string dienThoai)
        {
            this.MaSV = maSV;
            this.HoTen = hoTen;
            this.NgaySinh = ngaySinh;
            this.DiaChi = diaChi;
            this.DienThoai = dienThoai;
        }

        // Ghi đè ToString()
        public override string ToString()
        {
            return string.Format("{0} - {1}, sinh ngày {2}, {3} tuổi, ĐT: {4}, ĐC: {5}.",
                MaSV, HoTen, NgaySinh.ToString("dd/MM/yyyy"), Tuoi, DienThoai, DiaChi);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            List<SinhVien> dssv = new List<SinhVien>();

            // Tạo đối tượng qua constructor có tham số hoặc object initializer
            dssv.Add(new SinhVien(1, "Trần Văn Tèo", new DateTime(2005, 11, 28), "123 Trương Định", "0909789567"));
            dssv.Add(new SinhVien(2, "Trần Văn Quang", new DateTime(2004, 5, 12), "456 Lê Lợi", "0909567789"));

            Console.WriteLine("===== DANH SÁCH SINH VIÊN =====");
            foreach (SinhVien sv in dssv)
            {
                Console.WriteLine(sv);
            }

            Console.ReadKey();
        }
    }
}
