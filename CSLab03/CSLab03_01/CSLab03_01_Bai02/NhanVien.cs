using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSLab03_01_Bai02
{
    public class NhanVien : Nguoi
    {
        // 1. Fields riêng của NhanVien
        private string maNhanVien;
        private string email;
        private string dienThoai;
        private DateTime ngayLamViec;
        private string maCongTy;

        // 2. Properties có kiểm tra dữ liệu
        public string MaNhanVien
        {
            get { return maNhanVien; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Mã nhân viên không được để trống!");
                maNhanVien = value.Trim().ToUpper();
            }
        }

        public string Email
        {
            get { return email; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || !value.Contains("@") || !value.Contains("."))
                    throw new ArgumentException("Email nhân viên không hợp lệ!");
                email = value.Trim().ToLower();
            }
        }

        public string DienThoai
        {
            get { return dienThoai; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || !Regex.IsMatch(value.Trim(), @"^0\d{9}$"))
                    throw new ArgumentException("Số điện thoại nhân viên phải đủ 10 chữ số!");
                dienThoai = value.Trim();
            }
        }

        public DateTime NgayLamViec
        {
            get { return ngayLamViec; }
            set
            {
                if (value > DateTime.Now)
                    throw new ArgumentException("Ngày vào làm việc không thể ở tương lai!");
                if (value <= NgaySinh)
                    throw new ArgumentException("Ngày làm việc phải diễn ra sau ngày sinh!");
                ngayLamViec = value;
            }
        }

        public string MaCongTy
        {
            get { return maCongTy; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Mã công ty không được để trống!");
                maCongTy = value.Trim().ToUpper();
            }
        }

        // 3. Constructors
        public NhanVien() : base()
        {
            maNhanVien = "NV000";
            email = "nhanvien@congty.com";
            dienThoai = "0987654321";
            ngayLamViec = DateTime.Now;
            maCongTy = "CT01";
        }

        public NhanVien(string hoTen, DateTime ngaySinh, string diaChi,
                        string maNV, string email, string dienThoai, DateTime ngayLamViec, string maCT)
            : base(hoTen, ngaySinh, diaChi)
        {
            MaNhanVien = maNV;
            Email = email;
            DienThoai = dienThoai;
            NgayLamViec = ngayLamViec;
            MaCongTy = maCT;
        }

        // 4. Ghi đè phương thức XemThongTin()
        public override void XemThongTin()
        {
            base.XemThongTin();
            Console.WriteLine($"  -> [Nhân Viên] Mã NV: {MaNhanVien} | Cty: {MaCongTy} | Ngày vào làm: {NgayLamViec:dd/MM/yyyy} | Email: {Email} | ĐT: {DienThoai}");
        }
    }
}
