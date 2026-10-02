using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLab02_1_Bai03
{
    struct MatHang
    {
        public int MaMH;
        public string TenMH;
        public int SoLuong;
        public float DonGia;

        // Hàm tạo (Constructor)
        public MatHang(int maMH, string tenMH, int soLuong, float donGia)
        {
            this.MaMH = maMH;
            this.TenMH = tenMH;
            this.SoLuong = soLuong;
            this.DonGia = donGia;
        }

        // Phương thức tính thành tiền
        public float ThanhTien()
        {
            return SoLuong * DonGia;
        }

        // Hàm hỗ trợ in thông tin mặt hàng
        public void XuatThongTin()
        {
            Console.WriteLine($"Mã: {MaMH,-6} | Tên: {TenMH,-20} | SL: {SoLuong,-5} | Đơn giá: {DonGia,-10:N0} | Thành tiền: {ThanhTien():N0} VNĐ");
        }
    }

    internal class Program
    {
        
        static void ThemMatHang(Hashtable danhsach, MatHang m)
        {
            danhsach.Add(m.MaMH, m);
        }


        static bool TimMatHang(Hashtable danhsach, int maMH)
        {
            return danhsach.ContainsKey(maMH);
        }


        static void XoaMatHang(Hashtable danhsach, int maMH)
        {
            if (TimMatHang(danhsach, maMH))
            {
                danhsach.Remove(maMH);
                Console.WriteLine($">> Đã xóa thành công mặt hàng có mã: {maMH}");
            }
            else
            {
                Console.WriteLine($">> Không tìm thấy mặt hàng có mã {maMH} để xóa!");
            }
        }


        static void XuatDanhSach(Hashtable danhsach)
        {
            if (danhsach.Count == 0)
            {
                Console.WriteLine("(Danh sách mặt hàng đang trống!)");
                return;
            }

            Console.WriteLine(new string('-', 75));

            foreach (MatHang mh in danhsach.Values)
            {
                mh.XuatThongTin();
            }
            Console.WriteLine(new string('-', 75));
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            Hashtable dsMatHang = new Hashtable();

            Console.WriteLine("========================================");
            Console.WriteLine("   CHƯƠNG TRÌNH QUẢN LÝ MẶT HÀNG       ");
            Console.WriteLine("========================================");

            while (true)
            {
                Console.WriteLine("\n--- NHẬP THÔNG TIN MẶT HÀNG ---");

                int ma;
                while (true)
                {
                    Console.Write("Nhập mã mặt hàng (số nguyên): ");
                    if (int.TryParse(Console.ReadLine(), out ma))
                    {
                        if (TimMatHang(dsMatHang, ma))
                        {
                            Console.WriteLine($">> Mã {ma} đã tồn tại! Vui lòng nhập mã khác.");
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine(">> Mã phải là số nguyên!");
                    }
                }

                Console.Write("Nhập tên mặt hàng: ");
                string ten = Console.ReadLine();

                int soLuong;
                while (true)
                {
                    Console.Write("Nhập số lượng: ");
                    if (int.TryParse(Console.ReadLine(), out soLuong) && soLuong >= 0) break;
                    Console.WriteLine(">> Số lượng phải là số nguyên >= 0!");
                }

                float donGia;
                while (true)
                {
                    Console.Write("Nhập đơn giá: ");
                    if (float.TryParse(Console.ReadLine(), out donGia) && donGia >= 0) break;
                    Console.WriteLine(">> Đơn giá phải là số thực >= 0!");
                }

                MatHang mhMoi = new MatHang(ma, ten, soLuong, donGia);
                ThemMatHang(dsMatHang, mhMoi);

                Console.Write("\nBạn có muốn tiếp tục nhập mặt hàng khác? (y/n): ");
                string tiepTuc = Console.ReadLine().Trim().ToLower();
                if (tiepTuc != "y")
                {
                    break;
                }
            }


            // BƯỚC 2: Xuất toàn bộ danh sách mặt hàng
            Console.WriteLine("\n\n===== DANH SÁCH MẶT HÀNG ĐÃ NHẬP =====");
            XuatDanhSach(dsMatHang);

            // BƯỚC 3: Nhập mã, tìm kiếm và xóa nếu tìm thấy
            Console.WriteLine("\n--- TÌM KIẾM VÀ XÓA MẶT HÀNG ---");
            Console.Write("Nhập mã mặt hàng cần tìm để xóa: ");
            if (int.TryParse(Console.ReadLine(), out int maCanXoa))
            {
                if (TimMatHang(dsMatHang, maCanXoa))
                {
                    Console.WriteLine($">> Tìm thấy mặt hàng có mã: {maCanXoa}. Tiến hành xóa...");
                    XoaMatHang(dsMatHang, maCanXoa);

                    Console.WriteLine("\n===== DANH SÁCH MẶT HÀNG SAU KHI XÓA =====");
                    XuatDanhSach(dsMatHang);
                }
                else
                {
                    Console.WriteLine($">> Không tìm thấy mặt hàng có mã: {maCanXoa}");
                }
            }
            else
            {
                Console.WriteLine(">> Mã nhập vào không hợp lệ!");
            }

            Console.WriteLine("\nNhấn phím bất kỳ để kết thúc...");
            Console.ReadKey();
        }
    }
}
