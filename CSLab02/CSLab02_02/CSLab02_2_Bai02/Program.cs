using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLab02_2_Bai02
{
    struct HangHoa
    {
        public int MaHH;
        public string TenHH;
        public int SoLuong;
        public double DonGia;

        // Constructor khởi tạo giá trị
        public HangHoa(int maHH, string tenHH, int soLuong, double donGia)
        {
            this.MaHH = maHH;
            this.TenHH = tenHH;
            this.SoLuong = soLuong;
            this.DonGia = donGia;
        }

        // Phương thức tính thành tiền
        public double ThanhTien()
        {
            return SoLuong * DonGia;
        }

        // Ghi đè phương thức ToString() để xuất thông tin định dạng chuẩn
        public override string ToString()
        {
            return string.Format("{0} - {1} - {2} cái x {3:N0} đ = {4:N0} đ",
                MaHH, TenHH, SoLuong, DonGia, ThanhTien());
        }
    }

    internal class Program
    {
        // Hàm thêm một mặt hàng vào danh sách
        static void ThemHangHoa(List<HangHoa> ds, HangHoa hh)
        {
            ds.Add(hh);
        }

        // Hàm tìm mặt hàng dựa vào mã (trả về bool)
        static bool TimHangHoa(List<HangHoa> ds, int maHH)
        {
            for (int i = 0; i < ds.Count; i++)
            {
                if (ds[i].MaHH == maHH)
                {
                    return true;
                }
            }
            return false;
        }

        // Hàm xóa mặt hàng dựa vào mã
        static bool XoaHangHoa(List<HangHoa> ds, int maHH)
        {
            for (int i = 0; i < ds.Count; i++)
            {
                if (ds[i].MaHH == maHH)
                {
                    ds.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        // Hàm xuất danh sách các mặt hàng
        static void XuatDanhSach(List<HangHoa>   ds)
        {
            if (ds.Count == 0)
            {
                Console.WriteLine("(Danh sách mặt hàng đang trống!)");
                return;
            }

            Console.WriteLine(new string('-', 60));
            foreach (HangHoa hh in ds)
            {
                Console.WriteLine(hh); // Tự động gọi phương thức hh.ToString()
            }
            Console.WriteLine(new string('-', 60));
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            List<HangHoa> dssp = new List<HangHoa>();

            Console.WriteLine("========================================");
            Console.WriteLine("       QUẢN LÝ DANH SÁCH MẶT HÀNG       ");
            Console.WriteLine("========================================");

            // BƯỚC 1: Nhập danh sách mặt hàng, hỏi tiếp tục sau mỗi lần nhập
            while (true)
            {
                Console.WriteLine("\n--- Nhập thông tin mặt hàng ---");

                int ma;
                while (true)
                {
                    Console.Write("Mã mặt hàng (số nguyên): ");
                    if (int.TryParse(Console.ReadLine(), out ma))
                    {
                        if (TimHangHoa(dssp, ma))
                        {
                            Console.WriteLine(">> Mã hàng này đã tồn tại! Vui lòng nhập mã khác.");
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine(">> Vui lòng nhập số nguyên hợp lệ!");
                    }
                }

                Console.Write("Tên mặt hàng: ");
                string ten = Console.ReadLine().Trim();

                int soLuong;
                while (true)
                {
                    Console.Write("Số lượng: ");
                    if (int.TryParse(Console.ReadLine(), out soLuong) && soLuong >= 0) break;
                    Console.WriteLine(">> Số lượng phải là số nguyên >= 0!");
                }

                double donGia;
                while (true)
                {
                    Console.Write("Đơn giá: ");
                    if (double.TryParse(Console.ReadLine(), out donGia) && donGia >= 0) break;
                    Console.WriteLine(">> Đơn giá phải là số thực >= 0!");
                }

                // Thêm vào danh sách
                HangHoa hhMoi = new HangHoa(ma, ten, soLuong, donGia);
                ThemHangHoa(dssp, hhMoi);

                Console.Write("\nBạn có muốn tiếp tục nhập nữa không? (y/n): ");
                string tiepTuc = Console.ReadLine().Trim().ToLower();
                if (tiepTuc != "y")
                {
                    break;
                }
            }

            // BƯỚC 2: Xuất toàn bộ danh sách mặt hàng
            Console.WriteLine("\n===== DANH SÁCH MẶT HÀNG HIỆN CÓ =====");
            XuatDanhSach(dssp);

            // BƯỚC 3: Nhập mã, tìm kiếm và xóa nếu tìm thấy
            Console.WriteLine("\n--- TÌM KIẾM VÀ XÓA MẶT HÀNG THEO MÃ ---");
            Console.Write("Nhập mã mặt hàng cần tìm: ");
            if (int.TryParse(Console.ReadLine(), out int maTim))
            {
                bool timThay = TimHangHoa(dssp, maTim);
                Console.WriteLine("Kết quả tìm kiếm: {0}", timThay);

                if (timThay)
                {
                    Console.WriteLine(">> Tìm thấy mã {0}! Đang tiến hành xóa...", maTim);
                    XoaHangHoa(dssp, maTim);

                    Console.WriteLine("\n===== DANH SÁCH SAU KHI XÓA =====");
                    XuatDanhSach(dssp);
                }
                else
                {
                    Console.WriteLine(">> Không tìm thấy mặt hàng có mã {0} để xóa.", maTim);
                }
            }

            Console.WriteLine("\nNhấn phím bất kỳ để kết thúc...");
            Console.ReadKey();
        }
    }
}
