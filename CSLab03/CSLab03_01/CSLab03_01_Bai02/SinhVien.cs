using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSLab03_01_Bai02
{
    public class SinhVien : Nguoi
    {
        // 1. Fields riêng của SinhVien
        private string maSV;
        private string maLop;
        private string email;
        private string dienThoai;

        // 2. Properties có kiểm tra dữ liệu chặt chẽ theo yêu cầu đề bài
        public string MaSV
        {
            get { return maSV; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Mã sinh viên không được rỗng!");
                maSV = value.Trim().ToUpper();
            }
        }

        public string MaLop
        {
            get { return maLop; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Mã lớp không được để trống!");
                maLop = value.Trim().ToUpper();
            }
        }

        public string Email
        {
            get { return email; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || !value.Contains("@") || !value.Contains("."))
                    throw new ArgumentException("Email không đúng định dạng (phải có ký tự '@' và '.')!");
                email = value.Trim().ToLower();
            }
        }

        public string DienThoai
        {
            get { return dienThoai; }
            set
            {
                // Kiểm tra số điện thoại: đúng 10 chữ số bắt đầu bằng số 0
                if (string.IsNullOrWhiteSpace(value) || !Regex.IsMatch(value.Trim(), @"^0\d{9}$"))
                    throw new ArgumentException("Số điện thoại không hợp lệ (phải bắt đầu bằng số 0 và đủ 10 chữ số)!");
                dienThoai = value.Trim();
            }
        }

        // 3. Constructors
        public SinhVien() : base()
        {
            maSV = "SV000";
            maLop = "LỚP_00";
            email = "sinhvien@gmail.com";
            dienThoai = "0123456789";
        }

        public SinhVien(string hoTen, DateTime ngaySinh, string diaChi,
                        string maSV, string maLop, string email, string dienThoai)
            : base(hoTen, ngaySinh, diaChi)
        {
            MaSV = maSV;
            MaLop = maLop;
            Email = email;
            DienThoai = dienThoai;
        }

        // 4. Ghi đè phương thức XemThongTin()
        public override void XemThongTin()
        {
            base.XemThongTin();
            Console.WriteLine($"  -> [Sinh Viên] MSSV: {MaSV} | Lớp: {MaLop} | Email: {Email} | ĐT: {DienThoai}");
        }
    }
}
