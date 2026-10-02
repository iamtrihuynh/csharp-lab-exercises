using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLab03_01_Bai02
{
    public class Nguoi
    {
        // 1. Fields
        private string hoTen;
        private DateTime ngaySinh;
        private string diaChi;

        // 2. Properties get/set có kiểm tra dữ liệu
        public string HoTen
        {
            get { return hoTen; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Họ tên không được để trống!");
                hoTen = value.Trim();
            }
        }

        public DateTime NgaySinh
        {
            get { return ngaySinh; }
            set
            {
                if (value > DateTime.Now)
                    throw new ArgumentException("Ngày sinh không thể lớn hơn ngày hiện tại!");
                ngaySinh = value;
            }
        }

        public string DiaChi
        {
            get { return diaChi; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Địa chỉ không được để trống!");
                diaChi = value.Trim();
            }
        }

        // Property chỉ đọc (Read-only) tính tuổi
        public int LayTuoi
        {
            get
            {
                int tuoi = DateTime.Now.Year - ngaySinh.Year;
                // Nếu chưa đến sinh nhật trong năm hiện tại thì trừ bớt 1 tuổi
                if (DateTime.Now.DayOfYear < ngaySinh.DayOfYear)
                    tuoi--;
                return Math.Max(0, tuoi);
            }
        }

        // 3. Constructors
        public Nguoi()
        {
            hoTen = "Chưa có tên";
            ngaySinh = DateTime.Now;
            diaChi = "Chưa xác định";
        }

        public Nguoi(string hoTen, DateTime ngaySinh, string diaChi)
        {
            HoTen = hoTen;
            NgaySinh = ngaySinh;
            DiaChi = diaChi;
        }

        // 4. Phương thức hiển thị (virtual cho phép lớp con ghi đè)
        public virtual void XemThongTin()
        {
            Console.WriteLine($"Họ tên: {HoTen} | Ngày sinh: {NgaySinh:dd/MM/yyyy} ({LayTuoi} tuổi) | Đ/C: {DiaChi}");
        }
    }
}
