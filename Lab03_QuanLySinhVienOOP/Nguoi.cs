using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab03_QuanLySinhVienOOP
{
    public class Nguoi
    {
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }

        public Nguoi()
        {
            HoTen = string.Empty;
            NgaySinh = DateTime.MinValue;
        }

        public Nguoi(string _HoTen, DateTime _NgaySinh)
        {
            HoTen = _HoTen;
            NgaySinh = _NgaySinh;
        }

        public virtual string LayThongTin()
        {
            return $"Họ tên: {HoTen}, Ngày sinh: {NgaySinh.ToShortDateString()}";
        }
    }
}
