using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab03_QuanLySinhVienOOP
{
    public class SinhVien : Nguoi
    {
        private double _diemTB;
        public string MSSV { get; set; }
        public string MaLop { get; set; }

        public double DiemTB
        {
            get { return _diemTB; }
            set
            {
                if (value < 0 || value > 10)
                {
                    throw new ArgumentOutOfRangeException("DiemTB phai nam trong khoang 0 den 10.");
                }
                _diemTB = value;
            }
        }

        public SinhVien()
        {
            MSSV = string.Empty;
            MaLop = string.Empty;
            DiemTB = 0.0;
        }

        public SinhVien(string mssv, string hoTen, DateTime ngaySinh, string maLop, double diemTB)
            : base(hoTen, ngaySinh)
        {
            MSSV = mssv;
            MaLop = maLop;
            DiemTB = diemTB;
        }

        public string XepLoai()
        {

            if (DiemTB >= 9.0) return "Xuất sắc";
            else if (DiemTB >= 8.0) return "Giỏi";
            else if (DiemTB >= 6.5) return "Khá";
            else if (DiemTB >= 5.0) return "Trun bình";
            
            return "Yếu";
             
        }

        public override string LayThongTin()
        {
            return $"Mã SV: {MSSV,-8} | {base.LayThongTin()} | Lớp: {MaLop,-8} | Điểm: {DiemTB,4:F1} | Xếp loại: {XepLoai()}";
        }

    }

}
