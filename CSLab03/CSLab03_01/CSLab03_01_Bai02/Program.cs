using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLab03_01_Bai02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("==================================================");
            Console.WriteLine("      KIỂM TRA LỚP NGUOI, SINHVIEN, NHANVIEN      ");
            Console.WriteLine("==================================================");

            // 1. Kiểm tra khởi tạo hợp lệ bằng constructor và thuộc tính
            try
            {
                Console.WriteLine("\n[1] KHỞI TẠO CÁC ĐỐI TƯỢNG HỢP LỆ:");

                Nguoi ng = new Nguoi("Nguyễn Văn An", new DateTime(1985, 3, 10), "Quận 1, TP.HCM");
                ng.XemThongTin();

                SinhVien sv = new SinhVien("Trần Thị Bình", new DateTime(2005, 5, 20), "Quận 5, TP.HCM",
                                           "SV001", "CNTT_K49", "binh.tran@st.ueh.edu.vn", "0912345678");
                sv.XemThongTin();

                NhanVien nv = new NhanVien("Lê Hoàng Cường", new DateTime(1995, 11, 2), "Quận 3, TP.HCM",
                                           "NV102", "cuong.le@fpt.com", "0987654321", new DateTime(2020, 1, 15), "FPT_SOFTWARE");
                nv.XemThongTin();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khởi tạo: " + ex.Message);
            }

            // 2. Kiểm tra tính năng đa hình bằng List
            Console.WriteLine("\n[2] DUYỆT DANH SÁCH ĐA HÌNH List:");
            List<Nguoi> danhSach = new List<Nguoi>
            {
                new SinhVien("Phạm Minh Đức", new DateTime(2004, 8, 12), "Bình Thạnh", "SV002", "DHKTPM18", "duc.pham@gmail.com", "0903123456"),
                new NhanVien("Võ Kim Yến", new DateTime(1992, 4, 25), "Thủ Đức", "NV205", "yen.vo@viettel.vn", "0977889900", new DateTime(2018, 6, 1), "VIETTEL")
            };

            foreach (Nguoi item in danhSach)
            {
                item.XemThongTin();
            }

            // 3. Kiểm tra tính năng Validation trong Property (Cố tình gán dữ liệu sai để bắt lỗi)
            Console.WriteLine("\n[3] KIỂM TRA BẮT LỖI DỮ LIỆU SAI (VALIDATION):");

            // Test 3.1: Email sinh viên sai
            try
            {
                Console.Write("Thử gán email sai cho sinh viên: ");
                SinhVien svLoi = new SinhVien();
                svLoi.Email = "emailsainaykhongcoacong";
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(">> BẮT LỖI THÀNH CÔNG: " + ex.Message);
            }

            // Test 3.2: Số điện thoại không đủ 10 chữ số
            try
            {
                Console.Write("Thử gán số điện thoại sai: ");
                NhanVien nvLoi = new NhanVien();
                nvLoi.DienThoai = "12345";
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(">> BẮT LỖI THÀNH CÔNG: " + ex.Message);
            }

            // Test 3.3: Ngày làm việc trước ngày sinh
            try
            {
                Console.Write("Thử gán ngày làm việc trước ngày sinh: ");
                NhanVien nvLoiNgay = new NhanVien("Văn A", new DateTime(2000, 1, 1), "TP.HCM",
                                                 "NV01", "a@gmail.com", "0912345678", new DateTime(1995, 1, 1), "CTY_X");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(">> BẮT LỖI THÀNH CÔNG: " + ex.Message);
            }

            Console.WriteLine("\nNhấn phím bất kỳ để tiếp tục...");
            Console.ReadKey();
        }
    
    }
}
